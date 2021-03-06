using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using System.Collections.Generic;

public partial class MODULES_CMS_LookUp_OrganizationCaseType : System.Web.UI.Page
{
    string strUser = "shyam";

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (!this.IsPostBack)
        {
            ClearControls();
            LoadOrganizations(9);
            LoadCaseTypes();
        }
    }

    void LoadOrganizations(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);

            this.grdOrganization.DataSource = OrganizationList;
            this.grdOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCaseTypes()
    {
        try
        {
            List<ATTCaseType> CaseTypeList = BLLCaseType.GetCaseType(null, null,0);
            Session["OrgCaseType"] = CaseTypeList;
            this.grdCaseType.DataSource = CaseTypeList;
            this.grdCaseType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ATTCaseType attCT = new ATTCaseType(int.Parse(hdnCaseTypeID.Value), txtCaseTypeName_RQD.Text,
                            txtAppellant.Text, txtRespondant.Text, chkActive.Checked == true ? "Y" : "N");
            attCT.EntryBy = strUser;

            foreach (GridViewRow row in grdOrganization.Rows)
            {
                CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
                if (cbSelect.Checked == true && row.Cells[3].Text == "")
                {
                    ATTOrganizationCaseType objOrgCaseType = new ATTOrganizationCaseType(
                        int.Parse(row.Cells[1].Text), int.Parse(hdnCaseTypeID.Value), "Y");
                    objOrgCaseType.EntryBy = strUser;
                    objOrgCaseType.Action = "A";
                    attCT.OrganisationCaseTypesLIST.Add(objOrgCaseType);
                }
                else if (cbSelect.Checked == false && row.Cells[3].Text == "Y")
                {
                    ATTOrganizationCaseType objOrgCaseType = new ATTOrganizationCaseType(
                        int.Parse(row.Cells[1].Text), int.Parse(hdnCaseTypeID.Value), "N");
                    objOrgCaseType.EntryBy = strUser;
                    objOrgCaseType.Action = "E";
                    attCT.OrganisationCaseTypesLIST.Add(objOrgCaseType);
                }
                else if (cbSelect.Checked == true && row.Cells[3].Text == "N")
                {
                    ATTOrganizationCaseType objOrgCaseType = new ATTOrganizationCaseType(
                        int.Parse(row.Cells[1].Text), int.Parse(hdnCaseTypeID.Value), "Y");
                    objOrgCaseType.EntryBy = strUser;
                    objOrgCaseType.Action = "E";
                    attCT.OrganisationCaseTypesLIST.Add(objOrgCaseType);
                }
            }
            List<ATTCaseType> LstCaseType = (List<ATTCaseType>)Session["OrgCaseType"];
            BLLCaseType.AddEditDeleteCaseType(attCT);

            foreach (GridViewRow row in grdOrganization.Rows)
            {
                CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
                if (cbSelect.Checked == true && row.Cells[3].Text == "Y")
                {
                    ATTOrganizationCaseType objOrgCaseType = new ATTOrganizationCaseType(
                        int.Parse(row.Cells[1].Text), int.Parse(hdnCaseTypeID.Value), "Y");
                    objOrgCaseType.EntryBy = strUser;
                    attCT.OrganisationCaseTypesLIST.Add(objOrgCaseType);
                }
            }

            if (grdCaseType.SelectedIndex > -1)
            {
                LstCaseType[grdCaseType.SelectedIndex].CaseTypeID = attCT.CaseTypeID;
                LstCaseType[grdCaseType.SelectedIndex].CaseTypeName = attCT.CaseTypeName;
                LstCaseType[grdCaseType.SelectedIndex].Appellant = attCT.Appellant;
                LstCaseType[grdCaseType.SelectedIndex].Respondant = attCT.Respondant;
                LstCaseType[grdCaseType.SelectedIndex].Active = attCT.Active;
                LstCaseType[grdCaseType.SelectedIndex].OrganisationCaseTypesLIST = attCT.OrganisationCaseTypesLIST;
            }
            else
                LstCaseType.Add(attCT);
            grdCaseType.DataSource = LstCaseType;
            grdCaseType.DataBind();

            ClearControls();

            this.lblStatusMessage.Text = "Successfully Saved";
            this.programmaticModalPopup.Show();

            Session["OrgCaseType"] = LstCaseType;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        ClearOrgGridCheckbox();
        this.grdCaseType.SelectedIndex = -1;
        this.txtCaseTypeName_RQD.Text = "";
        this.txtAppellant.Text = "Appellant";
        this.txtRespondant.Text = "Respondent";
        this.chkActive.Checked = true;
        hdnCaseTypeID.Value = "0";
    }

    protected void grdCaseType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible=false;
        e.Row.Cells[4].Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void grdCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCaseType> CaseTypeList = (List<ATTCaseType>)Session["OrgCaseType"];
            this.txtCaseTypeName_RQD.Text = CaseTypeList[this.grdCaseType.SelectedIndex].CaseTypeName;
            this.hdnCaseTypeID.Value = CaseTypeList[this.grdCaseType.SelectedIndex].CaseTypeID.ToString();
            this.txtAppellant.Text = CaseTypeList[this.grdCaseType.SelectedIndex].Appellant;
            this.txtRespondant.Text = CaseTypeList[this.grdCaseType.SelectedIndex].Respondant;
            this.chkActive.Checked = (CaseTypeList[this.grdCaseType.SelectedIndex].Active == "Y" ? true : false);
            ClearOrgGridCheckbox();
            foreach (ATTOrganizationCaseType orgCaseType in CaseTypeList[this.grdCaseType.SelectedIndex].OrganisationCaseTypesLIST)
            {
                foreach (GridViewRow row in this.grdOrganization.Rows)
                {
                    CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkSelect");
                    if (orgCaseType.OrgID == int.Parse(row.Cells[1].Text.ToString()) && orgCaseType.Active=="Y")
                    {
                        cb.Checked = true;
                        row.Cells[3].Text = "Y";
                    }
                    else if (orgCaseType.OrgID == int.Parse(row.Cells[1].Text.ToString()) && orgCaseType.Active == "N")
                    {
                        cb.Checked = false;
                        row.Cells[3].Text = "N";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearOrgGridCheckbox()
    {
        foreach (GridViewRow row in this.grdOrganization.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkSelect");
            cb.Checked = false;
            row.Cells[3].Text = "";
        }
    }

    protected void grdOrganization_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}


