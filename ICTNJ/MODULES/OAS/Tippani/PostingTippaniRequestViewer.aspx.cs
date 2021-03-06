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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_Tippani_PostingTippaniRequestViewer : System.Web.UI.Page
{
    new public ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            string type = BLLTippaniChannel.GetLoginEmpType(this.User.OrgID, (int)this.TippaniRequestViewer.TippaniSubjectType, this.User.PID);
            this.LoadTippaniStatus(type);
        }
    }

    void LoadTippaniStatus(string type)
    {
        try
        {
            List<ATTTippaniStatus> lst = BLLTippaniStatus.GetTippaniStatusList(true, type);

            this.ddlDStatus_Rqd.DataSource = lst;
            this.ddlDStatus_Rqd.DataTextField = "TippaniStatusName";
            this.ddlDStatus_Rqd.DataValueField = "TippaniStatusID";
            this.ddlDStatus_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView grd = sender as GridView;
            int orgID = int.Parse(grd.SelectedRow.Cells[0].Text);
            int tippaniID = int.Parse(grd.SelectedRow.Cells[1].Text);
            int tippaniProcessID = int.Parse(grd.SelectedRow.Cells[2].Text);

            this.hdnTippaniStatus.Value = grd.SelectedRow.Cells[13].Text;

            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetPostingTippaniDetail(orgID, tippaniID, 3, tippaniProcessID);

            this.grdPostList.DataSource = lst;
            this.grdPostList.DataBind();

            if (this.hdnForm.Value == "0")
            {
                this.ddlDStatus_Rqd.Enabled = true;
                this.btnSendBack.Enabled = true;
                this.btnSubmit.Enabled = true;

                if (this.TippaniRequestViewer.IsValidForSending == true)
                {
                    this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tippaniProcessID);
                    this.btnSaveAsDraft.Enabled = true;
                }
            }
            else if (this.hdnForm.Value == "1")
            {
                this.ddlDStatus_Rqd.Enabled = false;
                this.btnSendBack.Enabled = false;
                this.btnSubmit.Enabled = false;
                this.btnSaveAsDraft.Enabled = false;
            }

            ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
            info.OrgID = orgID;
            info.TippaniID = tippaniID;
            info.RequestType = TippaniProcessRequestType.History;

            this.TippaniHistory.ProcessID = tippaniProcessID;
            this.TippaniHistory.LoadTippaniHistory(info);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lnkSender_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.TippaniRequestViewer.LoadSender();
        this.hdnForm.Value = "0";
    }

    protected void lnkReceiver_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.TippaniRequestViewer.LoadReceiver();
        this.hdnForm.Value = "1";
    }

    override protected void OnInit(EventArgs e)
    {
        this.InitializeEventHandler();
        base.OnInit(e);
    }

    private void InitializeEventHandler()
    {
        this.TippaniRequestViewer.GrdRequestViewer.SelectedIndexChanged += new EventHandler(this.grdRequest_SelectedIndexChanged);
        this.TippaniRequestViewer.LnkSender.Click += new EventHandler(this.lnkSender_Click);
        this.TippaniRequestViewer.LnkrReceiver.Click += new EventHandler(this.lnkReceiver_Click);

        this.TippaniRequestViewer.ParentClearMethod = new MODULES_OAS_UserControls_TippaniRequestViewer.GenericMethod(this.ClearME);
    }

    private bool IsTippaniValidate()
    {
        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया नियुक्तिको टिप्पनी छान्नुहोस।";
            this.programmaticModalPopup.Show();
            return false;
        }

        if (this.TippaniRequestViewer.IsValidForSending == false)
        {
            this.lblStatusMessage.Text = "यो टिप्पणी पहिलेनै पठाइसकेको छ।<br>त्यसैले फेरी पठाउन सक्नु हन्न।";
            this.programmaticModalPopup.Show();
            return false;
        }

        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "3" || this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "4")
        {
            this.lblStatusMessage.Text = "तपाईले Final approve भएको टिप्पणीमा काम गर्न सक्नुहुन्न।";
            this.programmaticModalPopup.Show();
            return false;
        }

        if (this.ddlDStatus_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "क्रिपया नियुक्ति टिप्पनीको लागी तपाईको निर्णय दिनुहोस।";
            this.programmaticModalPopup.Show();
            return false;
        }

        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation

        if (this.IsTippaniValidate() == false)
            return;

        #endregion

        ATTGeneralTippaniProcess updateProcess = new ATTGeneralTippaniProcess();
        if (this.hdnForm.Value == "0")
        {
            updateProcess = this.TippaniRequestViewer.GetSelfActorProcess();
            updateProcess.Note = this.txtNote.Text;
            updateProcess.Status = int.Parse(this.ddlDStatus_Rqd.SelectedValue);
        }
        else if (this.hdnForm.Value == "1")
        {
            updateProcess = null;

            this.ClearME();
            this.hdnForm.Value = "1";
            this.lblStatusMessage.Text = "तपाईले पठाउनु भएको टिप्पणीमा तपाईले काम गर्न सक्नुहुन्न।";
            this.programmaticModalPopup.Show();

            return;
        }

        List<ATTGeneralTippaniProcess> processlst = new List<ATTGeneralTippaniProcess>();

        if (this.hdnForm.Value == "0")
        {
            processlst = this.chnlPerson.GetTippaniProcessList(updateProcess.OrgID, updateProcess.TippaniID, this.User.UserName);
        }

        List<ATTGeneralTippaniAttachment> lstAttachment = this.TippaniAttachment.GetAttachment(updateProcess.OrgID, updateProcess.TippaniID, this.User.UserName);

        try
        {
            if (this.hdnForm.Value == "0")
            {
                BLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(updateProcess, processlst, lstAttachment, this.TippaniRequestViewer.TippaniSubjectType);
                this.ClearME();

                this.TippaniRequestViewer.LoadTippaniRequest(1);

                this.lblStatusMessage.Text = "Your decision and process has been saved successfully.";
                this.programmaticModalPopup.Show();
            }
            else if (this.hdnForm.Value == "1")
            {
                this.ClearME();
                this.hdnForm.Value = "1";
                this.lblStatusMessage.Text = "तपाईले पठाउनु भएको टिप्पणीमा तपाईले काम गर्न सक्नुहुन्न।.";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        this.TippaniRequestViewer.Clear();
        this.chnlPerson.Clear();

        this.grdPostList.DataSource = "";
        this.grdPostList.DataBind();

        this.txtNote.Text = "";

        this.TippaniHistory.ClearTippaniHistory();
        this.EvaluationTab.ActiveTabIndex = 0;

        this.ddlDStatus_Rqd.SelectedIndex = -1;

        this.hdnForm.Value = "0";

        this.btnSendBack.Enabled = false;
        this.btnSubmit.Enabled = false;
        this.btnSaveAsDraft.Enabled = false;

        this.TippaniAttachment.Clear();
    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }

    protected void btnSendBack_Click(object sender, EventArgs e)
    {
        if (this.IsTippaniValidate() == false)
            return;

        ATTGeneralTippaniProcess updateProcess = new ATTGeneralTippaniProcess();
        if (this.hdnForm.Value == "0")
        {
            /* created update process */
            updateProcess = this.TippaniRequestViewer.GetSelfActorProcess();
            updateProcess.Note = this.txtNote.Text;
            updateProcess.Status = int.Parse(this.ddlDStatus_Rqd.SelectedValue);
        }
        else if (this.hdnForm.Value == "1")
        {
            updateProcess = null;
        }

        /* created sendback process */
        ATTGeneralTippaniProcess process = this.TippaniRequestViewer.GetSendBackProcess();

        List<ATTGeneralTippaniProcess> lstProcess = new List<ATTGeneralTippaniProcess>();
        lstProcess.Add(process);

        List<ATTGeneralTippaniAttachment> lstAttachment = this.TippaniAttachment.GetAttachment(process.OrgID, process.TippaniID, this.User.UserName);
        foreach (ATTGeneralTippaniAttachment attachment in lstAttachment)
        {
            attachment.TippaniID = process.TippaniID;
            attachment.TippaniProcessID = process.TippaniProcessID;
        }

        try
        {
            BLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(updateProcess, lstProcess, lstAttachment, this.TippaniRequestViewer.TippaniSubjectType);
            this.ClearME();

            this.lblStatusMessage.Text = "Tippani send back successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdPostList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[14].Visible = false;
    }

    protected void btnSaveAsDraft_Click(object sender, EventArgs e)
    {
        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया टिप्पनी छान्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.TippaniRequestViewer.IsValidForSending == false)
        {
            this.lblStatusMessage.Text = "यो टिप्पणी पहिलेनै पठाइसकेको छ।<br>त्यसैले यो टिप्पणीको लागी लेख Draft गर्न सक्नुहुन्न।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "3" || this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "4")
        {
            this.lblStatusMessage.Text = "तपाईले Final approve भएको टिप्पणीमा काम गर्न सक्नुहुन्न।";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTGeneralTippaniProcess updateProcess = new ATTGeneralTippaniProcess();
        if (this.hdnForm.Value == "0")
        {
            updateProcess = this.TippaniRequestViewer.GetSelfActorProcess();
            updateProcess.Note = this.txtNote.Text;
            updateProcess.Status = null;
        }
        else if (this.hdnForm.Value == "1")
        {
            updateProcess = null;

            this.ClearME();
            this.hdnForm.Value = "1";
            this.lblStatusMessage.Text = "तपाईले पठाउनु भएको टिप्पणीमा तपाईले काम गर्न सक्नुहुन्न।.";
            this.programmaticModalPopup.Show();

            return;
        }

        try
        {
            if (this.hdnForm.Value == "0")
            {
                BLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(updateProcess, null, null, this.TippaniRequestViewer.TippaniSubjectType);
                this.ClearME();

                this.TippaniRequestViewer.LoadTippaniRequest(1);

                this.lblStatusMessage.Text = "Tippani text has been saved as draft.";
                this.programmaticModalPopup.Show();
            }
            else if (this.hdnForm.Value == "1")
            {
                this.ClearME();
                this.hdnForm.Value = "1";
                this.lblStatusMessage.Text = "तपाईले पठाउनु भएको टिप्पणीमा तपाईले काम गर्न सक्नुहुन्न।.";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
