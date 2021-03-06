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

public partial class MODULES_CMS_LookUp_CaseStatus : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCaseStatus();
            chkActive.Checked = true;
        }
    }
    void LoadCaseStatus()
    {

        try
        {
            Session["CaseStatus"] = BLLCaseStatus.GetCaseStatus(null, null, 0);
            List<ATTCaseStatus> CaseStatusList = (List<ATTCaseStatus>)Session["CaseStatus"];
            this.lstCaseStatus.DataSource = CaseStatusList;
            this.lstCaseStatus.DataTextField = "CaseStatusName";
            this.lstCaseStatus.DataValueField = "CaseStatusID";
            this.lstCaseStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtCaseStatus_RQD.Text == "")
        {
            lblStatusMessage.Text = "मुदाको ञव्स्था लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        int CaseStatus = 0;
        if (lstCaseStatus.SelectedIndex != -1)
            CaseStatus = int.Parse(lstCaseStatus.SelectedValue);

        foreach (ListItem lst in lstCaseStatus.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtCaseStatus_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Case Ststus Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTCaseStatus objCaseStatus = new ATTCaseStatus(CaseStatus, this.txtCaseStatus_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objCaseStatus.EntryBy = strUser;
        if (this.lstCaseStatus.SelectedIndex > -1)
            objCaseStatus.Action = "E";
        else
            objCaseStatus.Action = "A";

        try
        {
            List<ATTCaseStatus> ListCaseStatusList = (List<ATTCaseStatus>)Session["CaseStatus"];
            BLLCaseStatus.SaveCaseStatus(objCaseStatus);
            if (this.lstCaseStatus.SelectedIndex > -1)
            {
                ListCaseStatusList[this.lstCaseStatus.SelectedIndex].CaseStatusID = objCaseStatus.CaseStatusID;
                ListCaseStatusList[this.lstCaseStatus.SelectedIndex].CaseStatusName = objCaseStatus.CaseStatusName;
                ListCaseStatusList[this.lstCaseStatus.SelectedIndex].Active = objCaseStatus.Active;
            }
            else
                ListCaseStatusList.Add(objCaseStatus);
            ClearControls();
            this.lstCaseStatus.DataSource = ListCaseStatusList;
            this.lstCaseStatus.DataBind();
            this.lblStatusMessage.Text = "Case Status Successfully Saved.";
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
        this.lstCaseStatus.SelectedIndex = -1;
        this.txtCaseStatus_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstCaseStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCaseStatus> ListCaseStatus = (List<ATTCaseStatus>)Session["CaseStatus"];
            this.lstCaseStatus.SelectedValue = ListCaseStatus[this.lstCaseStatus.SelectedIndex].CaseStatusID.ToString();
            this.txtCaseStatus_RQD.Text = ListCaseStatus[this.lstCaseStatus.SelectedIndex].CaseStatusName;
            this.chkActive.Checked = ListCaseStatus[this.lstCaseStatus.SelectedIndex].Active == "Y" ? true : false;
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
