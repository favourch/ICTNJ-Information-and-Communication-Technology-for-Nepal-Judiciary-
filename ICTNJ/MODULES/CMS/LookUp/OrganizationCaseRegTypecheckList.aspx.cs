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

public partial class MODULES_CMS_LookUp_OrganizationCaseRegTypecheckList : System.Web.UI.Page
{
    string strUser = "shyam";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrganizations(9);
            LoadCheckList();
        }
    }

    void LoadOrganizations(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);

            Session["Organization"] = OrganizationList;

            this.lstOrganization.DataSource = OrganizationList;
            this.lstOrganization.DataTextField = "ORGNAME";
            this.lstOrganization.DataValueField = "ORGID";
            this.lstOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCheckList()
    {
        try
        {
            Session["CheckList"] = BLLCheckList.GetCheckList(null, null, 0);
            List<ATTCheckList> ListCheckList = (List<ATTCheckList>)Session["CheckList"];
            this.grdCheckListType.DataSource = ListCheckList;
            this.grdCheckListType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTOrganizationCaseType> OrgCaseTypeList = BLLOrganizationCaseType.GetOrgCaseType(int.Parse(lstOrganization.SelectedValue.ToString()), null, "Y", 0,0,0,0);

            this.lstCaseType.DataSource = OrgCaseTypeList;
            this.lstCaseType.DataTextField = "CaseTypeName";
            this.lstCaseType.DataValueField = "CaseTypeID";
            this.lstCaseType.DataBind();
            ClearControls();
            lstRegistrationType.Items.Clear();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कार्यालय छान्नुस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (lstCaseType.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "मुदाको प्रकार छाननुस";
            this.programmaticModalPopup.Show();
            return;
        }

        ClearControls(); 

        try
        {
            List<ATTOrgCaseRegTypeCheckList> OrgCaseRegChkLst = BLLOrgCaseRegTypeCheckList.GetOrgCaseRegTypeCheckList
                                                                            (
                                                                            int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue),
                                                                            int.Parse(lstRegistrationType.SelectedValue), null, null
                                                                            );
            foreach (ATTOrgCaseRegTypeCheckList att in OrgCaseRegChkLst)
            {
                foreach (GridViewRow row in grdCheckListType.Rows)
                {
                    CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));

                    if ((att.CheckListID == int.Parse(row.Cells[1].Text)) && (att.Active == "Y"))
                    {
                        cbSelect.Checked = true;
                        row.Cells[3].Text = "Y";
                    }
                    else if ((att.CheckListID == int.Parse(row.Cells[1].Text)) && (att.Active == "N"))
                    {
                        cbSelect.Checked = false;
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

    protected void lstCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कार्यालय छान्नुस";
            this.programmaticModalPopup.Show();
            return;
        }
        ClearControls();
    
        try
        {
            List<ATTOrgCaseRegistrationType> LstOrgCaseRegType = BLLOrgCaseRegistrationType.GetOrgCaseRegType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue), null,"Y",0);

            this.lstRegistrationType.DataSource = LstOrgCaseRegType;
            this.lstRegistrationType.DataTextField = "RegTypeName";
            this.lstRegistrationType.DataValueField = "RegTypeID";
            this.lstRegistrationType.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    void ClearControls()
    {
        foreach (GridViewRow row in grdCheckListType.Rows)
        {
            CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            cbSelect.Checked = false;
            row.Cells[3].Text = "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कार्यालय छान्नुस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (lstCaseType.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "मुदाको प्रकार छाननुस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (lstRegistrationType.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "दर्ताको प्रकार छाननुस";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTOrgCaseRegTypeCheckList> OrgCaseRegTypeChkLst = new List<ATTOrgCaseRegTypeCheckList>();
        ATTOrgCaseRegTypeCheckList ObjOrgCaesregTypeChkLst = new ATTOrgCaseRegTypeCheckList();

        foreach (GridViewRow row in grdCheckListType.Rows)
        {
            CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));

            if (cbSelect.Checked == true && row.Cells[3].Text == "N")
                ObjOrgCaesregTypeChkLst = new ATTOrgCaseRegTypeCheckList
                                         (int.Parse(lstOrganization.SelectedValue),
                                            int.Parse(lstCaseType.SelectedValue),
                                            int.Parse(lstRegistrationType.SelectedValue),
                                            int.Parse(row.Cells[1].Text),
                                            "", strUser, "Y", "E"
                                        );
            else if (cbSelect.Checked == false && row.Cells[3].Text == "Y")
                ObjOrgCaesregTypeChkLst = new ATTOrgCaseRegTypeCheckList
                                         (int.Parse(lstOrganization.SelectedValue),
                                            int.Parse(lstCaseType.SelectedValue),
                                            int.Parse(lstRegistrationType.SelectedValue),
                                            int.Parse(row.Cells[1].Text),
                                            "", strUser, "N", "E"
                                        );
            else if (cbSelect.Checked == true && row.Cells[3].Text == "")
                ObjOrgCaesregTypeChkLst = new ATTOrgCaseRegTypeCheckList
                                         (int.Parse(lstOrganization.SelectedValue),
                                            int.Parse(lstCaseType.SelectedValue),
                                            int.Parse(lstRegistrationType.SelectedValue),
                                            int.Parse(row.Cells[1].Text),
                                            "", strUser, "Y", "A"
                                        );
            else continue;
            OrgCaseRegTypeChkLst.Add(ObjOrgCaesregTypeChkLst);
        }



        if (OrgCaseRegTypeChkLst.Count == 0)
            return;
        try
        {
            if (BLLOrgCaseRegTypeCheckList.SaveOrgCaseRegTypeCheckList(OrgCaseRegTypeChkLst))
            {
                ClearControls();
                lstRegistrationType.SelectedIndex = -1;
                this.lblStatusMessage.Text = "Successfully Saved";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        lstOrganization.SelectedIndex = -1;
        lstCaseType.SelectedIndex = -1;
        lstRegistrationType.SelectedIndex = -1;
    }

    protected void grdCheckListType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
