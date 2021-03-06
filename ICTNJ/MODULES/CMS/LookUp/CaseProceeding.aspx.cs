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
using System.Collections.Generic;

public partial class MODULES_CMS_LookUp_CaseProceeding : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCaseProceeding();
            chkActive.Checked = true;
        }
    }
    void LoadCaseProceeding()
    {

        try
        {
            Session["CaseProceeding"] = BLLCaseProceeding.GetCaseProceeding(null, null, 0);
            List<ATTCaseProceeding> CaseProceedingList = (List<ATTCaseProceeding>)Session["CaseProceeding"];
            this.lstCaseProceeding.DataSource = CaseProceedingList;
            this.lstCaseProceeding.DataTextField = "CaseProceedingName";
            this.lstCaseProceeding.DataValueField = "CaseProceedingID";
            this.lstCaseProceeding.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtCaseProceedingName_RQD.Text == "")
        {
            lblStatusMessage.Text = "कामको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        int CaseProceeding = 0;
        if (lstCaseProceeding.SelectedIndex != -1)
            CaseProceeding = int.Parse(lstCaseProceeding.SelectedValue);

        foreach (ListItem lst in lstCaseProceeding.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtCaseProceedingName_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Case Proceeding Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTCaseProceeding objCaseProceeding = new ATTCaseProceeding(CaseProceeding, this.txtCaseProceedingName_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objCaseProceeding.EntryBy = strUser;
        if (this.lstCaseProceeding.SelectedIndex > -1)
            objCaseProceeding.Action = "E";
        else
            objCaseProceeding.Action = "A";

        try
        {
            List<ATTCaseProceeding> ListCaseProceedingList = (List<ATTCaseProceeding>)Session["CaseProceeding"];
            BLLCaseProceeding.SaveCaseProceeding(objCaseProceeding);
            if (this.lstCaseProceeding.SelectedIndex > -1)
            {
                ListCaseProceedingList[this.lstCaseProceeding.SelectedIndex].CaseProceedingID = objCaseProceeding.CaseProceedingID;
                ListCaseProceedingList[this.lstCaseProceeding.SelectedIndex].CaseProceedingName = objCaseProceeding.CaseProceedingName;
                ListCaseProceedingList[this.lstCaseProceeding.SelectedIndex].Active = objCaseProceeding.Active;
            }
            else
                ListCaseProceedingList.Add(objCaseProceeding);
            ClearControls();
            this.lstCaseProceeding.DataSource = ListCaseProceedingList;
            this.lstCaseProceeding.DataBind();
            this.lblStatusMessage.Text = "Case Proceeding  Successfully Saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        this.lstCaseProceeding.SelectedIndex = -1;
        this.txtCaseProceedingName_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstCaseProceeding_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCaseProceeding> ListCaseProceeding = (List<ATTCaseProceeding>)Session["CaseProceeding"];
            this.lstCaseProceeding.SelectedValue = ListCaseProceeding[this.lstCaseProceeding.SelectedIndex].CaseProceedingID.ToString();
            this.txtCaseProceedingName_RQD.Text = ListCaseProceeding[this.lstCaseProceeding.SelectedIndex].CaseProceedingName;
            this.chkActive.Checked = ListCaseProceeding[this.lstCaseProceeding.SelectedIndex].Active == "Y" ? true : false;
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
}
