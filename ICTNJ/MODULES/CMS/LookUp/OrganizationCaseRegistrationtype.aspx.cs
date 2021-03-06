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

public partial class MODULES_CMS_LookUp_OrganizationCaseRegistrationtype : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!this.IsPostBack)
        {
          
            LoadOrganizations(9);
            LoadRegistrationType();
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
   
    void LoadRegistrationType()
    {
        try
        {
            Session["RegistrationType"] = BLLRegistrationType.GetRegistrationType(null, null, 0);
            List<ATTRegistrationType> RegTypeList = (List<ATTRegistrationType>)Session["RegistrationType"];
            
            this.grdRegType.DataSource = RegTypeList;
            this.grdRegType.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कृपया कार्यालय छान्नुहोस. ";
            this.programmaticModalPopup.Show();
            return;
        }

        if (lstCaseType.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कृपया दर्ता किताब छान्नुहोस. ";
            this.programmaticModalPopup.Show();
            return;
        }

       

        List<ATTOrgCaseRegistrationType> OrgCaseRegTypeList = new List<ATTOrgCaseRegistrationType>();
        ATTOrgCaseRegistrationType objOrgCaseRegType = new ATTOrgCaseRegistrationType();
        foreach (GridViewRow row in grdRegType.Rows)
        {
            CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));

            if (cbSelect.Checked == true && row.Cells[3].Text == "")
                objOrgCaseRegType = new ATTOrgCaseRegistrationType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue), int.Parse(row.Cells[1].Text), "", "Y", "A");

            else if (cbSelect.Checked == false && row.Cells[3].Text == "Y")
                objOrgCaseRegType = new ATTOrgCaseRegistrationType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue), int.Parse(row.Cells[1].Text), "", "N", "E");

            else if (cbSelect.Checked == true && row.Cells[3].Text == "N")
                objOrgCaseRegType = new ATTOrgCaseRegistrationType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue), int.Parse(row.Cells[1].Text), "", "Y", "E");
            else
                continue;

            objOrgCaseRegType.EntryBy = strUser;
            OrgCaseRegTypeList.Add(objOrgCaseRegType);

            if (OrgCaseRegTypeList.Count == 0)
                return;
        }
        try
        {
            if (BLLOrgCaseRegistrationType.SaveOrgCaseRegType(OrgCaseRegTypeList))
            {
                this.lblStatusMessage.Text = "Successfully Saved. ";
                this.programmaticModalPopup.Show();
                ClearControls();
                lstCaseType.SelectedIndex = -1;
            }
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

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearControls();

        if (lstOrganization.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कृपया कार्यालय छान्नुहोस. ";
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            List<ATTOrgCaseRegistrationType> LstOrgCaseRegType = BLLOrgCaseRegistrationType.GetOrgCaseRegType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseType.SelectedValue), null, null,0);

            foreach (ATTOrgCaseRegistrationType att in LstOrgCaseRegType)
            {
                foreach (GridViewRow row in grdRegType.Rows)
                {
                    CheckBox cbActive = (CheckBox)(row.Cells[0].FindControl("chkSelect"));

                    if ((att.RegTypeID == int.Parse(row.Cells[1].Text)) && (att.Active=="Y"))
                    {
                        cbActive.Checked = true;
                        row.Cells[3].Text="Y";
                    }
                    else if ((att.RegTypeID == int.Parse(row.Cells[1].Text)) && (att.Active == "N"))
                    {
                        cbActive.Checked = false;
                        row.Cells[3].Text = "N";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
        
    }

    void ClearControls()
    {
        foreach (GridViewRow row in grdRegType.Rows)
        {
            CheckBox cbActive = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            cbActive.Checked = false;
            row.Cells[3].Text = "";
        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        lstCaseType.SelectedIndex = -1;
        lstOrganization.SelectedIndex = -1;
    }

    protected void grdRegType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
