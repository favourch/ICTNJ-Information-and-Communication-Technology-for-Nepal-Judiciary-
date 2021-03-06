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

public partial class MODULES_OAS_Tippani_LeaveTippaniRequestViewer : System.Web.UI.Page
{
    new public ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

    private List<ATTGeneralTippaniSummary> LeaveRec
    {
        get
        {
            return Session["LeavelRecLst"] as List<ATTGeneralTippaniSummary>;
        }
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
            this.SetLeaveRecommendList();
            //int i = 0;
        }
    }

    void SetLeaveRecommendList()
    {
        Session["LeavelRecLst"] = new List<ATTGeneralTippaniSummary>();
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

            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetLeaveTippaniDetail(orgID, tippaniID, tippaniProcessID, LeaveMode.Recommend);

            this.ClearLeaveDetail();
            this.SetLeaveRecommendList();

            this.grdRecommendation.DataSource = "";
            this.grdRecommendation.DataBind();

            this.grdLeave.DataSource = lst;
            this.grdLeave.DataBind();

            this.grdLeaveDetail.DataSource = lst;
            this.grdLeaveDetail.DataBind();

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
        this.hdnForm.Value = "0";
        this.TippaniRequestViewer.LoadSender();
    }

    protected void lnkReceiver_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.hdnForm.Value = "1";
        this.TippaniRequestViewer.LoadReceiver();
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
        if (this.hdnTippaniStatus.Value == "2")
        {
            this.lblStatusMessage.Text = "यो टिप्पणीको पहिलेनै सिफारिस भइसकेको छ।<br>त्यसैले यसमा काम गर्न सक्नु हुन्न।";
            this.programmaticModalPopup.Show();
            return false;
        }

        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया बिदाको टिप्पनी छान्नुहोस।";
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
            this.lblStatusMessage.Text = "क्रिपया बिदा टिप्पनीको लागी तपाईको निर्णय दिनुहोस।";
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
            this.lblStatusMessage.Text = "तपाईले पठाउनु भएको टिप्पणीमा तपाईले काम गर्न सक्नुहुन्न।.";
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
                BLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(updateProcess, processlst, lstAttachment, this.TippaniRequestViewer.TippaniSubjectType, this.LeaveRec);
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

        this.ClearLeaveDetail();

        this.grdLeave.DataSource = "";
        this.grdLeave.DataBind();

        this.grdRecommendation.DataSource = "";
        this.grdRecommendation.DataBind();

        this.grdLeaveDetail.DataSource = "";
        this.grdLeaveDetail.DataBind();

        this.txtNote.Text = "";

        this.TippaniHistory.ClearTippaniHistory();
        this.EvaluationTab.ActiveTabIndex = 0;

        this.ddlDStatus_Rqd.SelectedIndex = -1;

        this.hdnForm.Value = "0";

        this.btnSendBack.Enabled = false;
        this.btnSubmit.Enabled = false;
        this.btnSaveAsDraft.Enabled = false;

        this.TippaniAttachment.Clear();

        this.SetLeaveRecommendList();
    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }

    protected void btnSendBack_Click(object sender, EventArgs e)
    {
        if (this.IsTippaniValidate() == false)
            return;

        if (this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "3" || this.TippaniRequestViewer.GrdRequestViewer.SelectedRow.Cells[13].Text == "4")
        {
            this.lblStatusMessage.Text = "तपाईले Final approve भएको टिप्पणीमा काम गर्न सक्नुहुन्न।";
            this.programmaticModalPopup.Show();
            return;
        }

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

    protected void grdLeave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }

    protected void grdLeave_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdRecommendation.SelectedIndex = -1;

        GridViewRow row = this.grdLeave.SelectedRow;
        this.lblDetail.Text = row.Cells[3].Text + " / " + row.Cells[4].Text + "   !!!   " + row.Cells[6].Text + " - " + row.Cells[7].Text + "  ->  " + row.Cells[8].Text;
        this.txtFromDate_Rdt.Text = row.Cells[6].Text;
        this.txtToDate_Rdt.Text = row.Cells[7].Text;
        this.txtTotalDays_Rqd.Text = row.Cells[8].Text;

        this.hdnFromDate.Value = row.Cells[6].Text;
        this.hdnToDate.Value = row.Cells[7].Text;
    }

    protected void grdRecommendation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
    }

    protected void grdRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdRecommendation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdLeave.SelectedIndex = -1;
        this.lblDetail.Text = "";

        ATTGeneralTippaniSummary leave = this.LeaveRec[this.grdRecommendation.SelectedIndex];

        this.txtFromDate_Rdt.Text = leave.RecFromDate;
        this.txtToDate_Rdt.Text = leave.RecToDate;
        this.txtTotalDays_Rqd.Text = leave.RecNoOfDays.ToString();
        this.txtRemark.Text = leave.RecReason;
        this.chkRec.Checked = leave.RecYesNo == "Y" ? true : false;

        this.hdnFromDate.Value = leave.OldFromDate;
        this.hdnToDate.Value = leave.OldToDate;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.grdRecommendation.SelectedIndex <= -1)
        {
            if (this.grdLeave.SelectedIndex <= -1)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारीको बिदाको अनुरोध बिबरण छन्नुहोस ।";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        if (this.chkRec.Checked == true)
        {
            if (this.txtFromDate_Rdt.Text.Trim() == "" || this.txtToDate_Rdt.Text.Trim() == "" || this.txtTotalDays_Rqd.Text.Trim() == "")
            {
                this.lblStatusMessage.Text = "कृपया सिफरिस गरेको कर्मचारीको लागी बिदाको सिफारिस बिबरण राख्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            if (string.Compare(this.txtToDate_Rdt.Text.Trim(), this.txtFromDate_Rdt.Text.Trim()) < 0)
            {
                this.lblStatusMessage.Text = "बिदाको अवधि देखि मिति अवधि सम्म मिति भन्दा सानो हुनुपर्छ ।";
                this.programmaticModalPopup.Show();
                return;
            }

            if (string.Compare(this.hdnFromDate.Value.Trim(), this.txtFromDate_Rdt.Text.Trim()) > 0)
            {
                this.lblStatusMessage.Text = "सिफारिसको अवधि देखि मिति अनुरोधको अवधि देखि मिति भन्दा सानो हुन सक्दैन् ।";
                this.programmaticModalPopup.Show();
                return;
            }

            if (string.Compare(this.hdnToDate.Value.Trim(), this.txtToDate_Rdt.Text.Trim()) < 0)
            {
                this.lblStatusMessage.Text = "सिफारिसको अवधि सम्म मिति अनुरोधको अवधि सम्म मिति भन्दा ठुलो हुन सक्दैन् ।";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTGeneralTippaniSummary leave = new ATTGeneralTippaniSummary();

        GridViewRow row;
        if (this.grdRecommendation.SelectedIndex < 0)
        {
            row = this.grdLeave.SelectedRow;
        }
        else
        {
            row = this.grdRecommendation.SelectedRow;
        }

        leave.OrgID = int.Parse(row.Cells[0].Text);
        leave.TippaniID = int.Parse(row.Cells[1].Text);
        leave.EmpID = double.Parse(row.Cells[2].Text);
        leave.EmpName = row.Cells[3].Text;

        if (this.grdRecommendation.SelectedIndex < 0)
        {
            bool exist = this.LeaveRec.Exists
            (
                delegate(ATTGeneralTippaniSummary l)
                {
                    return l.OrgID == leave.OrgID &&
                        l.TippaniID == leave.TippaniID &&
                        l.EmpID == leave.EmpID;
                }
            );
            if (exist == true)
            {
                this.lblStatusMessage.Text = "यस कर्मचारीको बिदाको सिफारिस बिबरण दिइसकेको छ।";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        //leave.LeaveTypeID = int.Parse(this.ddlLeaveType_Rqd.SelectedValue);
        //leave.LeaveType = this.ddlLeaveType_Rqd.SelectedItem.Text;
        leave.RecFromDate = this.txtFromDate_Rdt.Text;
        leave.RecToDate = this.txtToDate_Rdt.Text;
        leave.OldFromDate = this.hdnFromDate.Value;
        leave.OldToDate = this.hdnToDate.Value;
        leave.RecDate = ""; //set nepali date from database
        leave.RecNoOfDays = BLLGeneralTippani.GetDateDifference(leave.RecToDate, leave.RecFromDate) + 1;
        leave.RecYesNo = this.chkRec.Checked == true ? "Y" : "N";
        leave.RecReason = this.txtRemark.Text.Trim();
        leave.LeaveLevel = LeaveMode.Recommend;
        leave.Action = "A";
        leave.RecBy = this.User.PID;

        if (this.grdRecommendation.SelectedIndex < 0)
            this.LeaveRec.Add(leave);
        else
            this.LeaveRec[this.grdRecommendation.SelectedIndex] = leave;

        this.grdRecommendation.DataSource = this.LeaveRec;
        this.grdRecommendation.DataBind();

        this.ClearLeaveDetail();
    }

    void ClearLeaveDetail()
    {
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtTotalDays_Rqd.Text = "0";
        this.txtRemark.Text = "";
        this.lblDetail.Text = "";
        this.chkRec.Checked = true;

        this.grdLeave.SelectedIndex = -1;
        this.grdRecommendation.SelectedIndex = -1;
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
