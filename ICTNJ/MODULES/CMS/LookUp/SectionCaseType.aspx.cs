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

using System.Collections.Generic;
using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_CMS_LookUp_SectionCaseType : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrganization();
        }
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lstOrgWithChilds = BLLOrganization.GetOrgWithChilds(orgID);
            lstOrganization.DataSource = lstOrgWithChilds;
            lstOrganization.DataTextField = "OrgName";
            lstOrganization.DataValueField = "OrgID";
            lstOrganization.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        lstCaseTypes.SelectedIndex = -1;
        txtFromDate_RQD.Text = "";
        foreach (GridViewRow row in grdOrgUnits.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
            cbSelect.Checked = false;
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
            List<ATTOrganizationCaseType> lstOrgCaseType = BLLOrganizationCaseType.GetOrgCaseType(int.Parse(lstOrganization.SelectedValue), null, "Y", 1, 1, 1, 1);

            lstCaseTypes.DataSource = lstOrgCaseType;
            lstCaseTypes.DataTextField = "CaseTypeName";
            lstCaseTypes.DataValueField = "CaseTypeID";
            lstCaseTypes.DataBind();

            List<ATTOrganizationUnit> OrgUnitList = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(lstOrganization.SelectedValue), null);

            OrgUnitList.RemoveAll(delegate(ATTOrganizationUnit attOU)
            {
                return attOU.UnitType != "C";
            });

            grdOrgUnits.DataSource = OrgUnitList;
            grdOrgUnits.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Organization First";
            programmaticModalPopup.Show();
            return;
        }

        if (lstCaseTypes.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Case Type First";
            programmaticModalPopup.Show();
            return;
        }
        if (grdOrgUnits.Rows.Count < 0)
        {
            lblStatusMessage.Text = "This Organization hasn't case Types..Choose next Org.";
            programmaticModalPopup.Show();
            return;
        }
        if (txtFromDate_RQD.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Please Enter from Date First";
            programmaticModalPopup.Show();
            return;
        }

        List<ATTSectionCaseType> SecCaseTypeList = new List<ATTSectionCaseType>();
        foreach (GridViewRow row in grdOrgUnits.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");

            if (cbSelect.Checked == true && row.Cells[3].Text == "")
            {
                ATTSectionCaseType attSCT = new ATTSectionCaseType();
                attSCT.OrgID = orgID;
                attSCT.CaseTypeID = int.Parse(lstCaseTypes.SelectedValue);
                attSCT.UnitID = int.Parse(row.Cells[1].Text.ToString());
                attSCT.FromDate = txtFromDate_RQD.Text.Trim();
                attSCT.EntryBy = strUser;
                attSCT.Action = "A";
                SecCaseTypeList.Add(attSCT);
            }
            else if (cbSelect.Checked == false && row.Cells[3].Text == "U")
            {
                ATTSectionCaseType attSCT = new ATTSectionCaseType();
                attSCT.OrgID = orgID;
                attSCT.CaseTypeID = int.Parse(lstCaseTypes.SelectedValue);
                attSCT.UnitID = int.Parse(row.Cells[1].Text.ToString());
                attSCT.FromDate = txtFromDate_RQD.Text.Trim();
                attSCT.EntryBy = strUser;
                attSCT.Action = "E";
                SecCaseTypeList.Add(attSCT);
            }
        }
        if (BLLSectionCaseType.SaveSectionCaseType(SecCaseTypeList))
        {
            ClearControls();
            lblStatusMessage.Text = "Successfully Saved";
            programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        lstOrganization.SelectedIndex = -1;
    }
      
    protected void lstCaseTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Organization First";
            programmaticModalPopup.Show();
            return;
        }
        foreach (GridViewRow row in grdOrgUnits.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
            cbSelect.Checked = false;
        }
        try
        {
            List<ATTSectionCaseType> lstSecCaseType = BLLSectionCaseType.GetSectionCaseType(int.Parse(lstOrganization.SelectedValue), int.Parse(lstCaseTypes.SelectedValue), null, null);
            ATTSectionCaseType attSC = new ATTSectionCaseType();
            foreach (GridViewRow row in grdOrgUnits.Rows)
            {
                CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
                attSC = lstSecCaseType.Find(delegate(ATTSectionCaseType att)
                 {
                     return att.UnitID == int.Parse(row.Cells[1].Text.ToString());
                 });
                if (attSC != null)
                {
                    cbSelect.Checked = true;
                    row.Cells[3].Text = "U";
                }
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void grdOrgUnits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
