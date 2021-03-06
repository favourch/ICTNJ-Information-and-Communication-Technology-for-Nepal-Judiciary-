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
    new private ATTUserLogin User
    {
        get
        {
            return (ATTUserLogin)Session["Login_User_Detail"];
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
            this.LoadOrganization();
            this.LoadTippaniStatus();
            //this.LoadChannelPerson();

            this.LoadTippaniRequest();
        }
    }

    void LoadTippaniRequest()
    {
        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = 2;//visit id
        info.ProcessToID = this.User.PID;
        try
        {
            //List<ATTGeneralTippaniRequestInfo> lst = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info);
            //this.grdRequest.DataSource = lst;
            //this.grdRequest.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadChannelPerson()
    {
        List<ATTTippaniChannel> lst = BLLTippaniChannel.GetTippaniChannelList(this.User.OrgID, 2);
        lst.RemoveAll
                    (
                        delegate(ATTTippaniChannel c)
                        {
                            return c.ChannelPersonID == this.User.PID;
                        }
                    );
        //this.grdChannelPerson.DataSource = lst;
        //this.grdChannelPerson.DataBind();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "------ कार्यालय छन्नुहोस ------"));
            this.ddlOrg.DataSource = lst;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadTippaniStatus()
    {
        try
        {
            List<ATTTippaniStatus> lst = BLLTippaniStatus.GetTippaniStatusList(true);
            this.ddlStatus.DataSource = lst;
            this.ddlStatus.DataTextField = "TippaniStatusName";
            this.ddlStatus.DataValueField = "TippaniStatusID";
            this.ddlStatus.DataBind();

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.ProcessToID = this.User.PID;
        try
        {
            //List<ATTGeneralTippaniRequestInfo> lst = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info);
            //this.grdRequest.DataSource = lst;
            //this.grdRequest.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    int orgID = 0;
    int tippaniID = 0;
    double empID = 0;
    double dynamicEmpID = 0;
    ATTGeneralTippaniRequestInfo info;
    int firstRow = -1;
    protected void grdRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[12].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((ATTGeneralTippaniRequestInfo)e.Row.DataItem).ProcessStatusName == "")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            info = (ATTGeneralTippaniRequestInfo)e.Row.DataItem;

            //if (this.hdnForm.Value == "0")
            //    dynamicEmpID = info.ProcessToID;
            //else
            //    dynamicEmpID = info.ProcessByID;

            if (orgID == info.OrgID && tippaniID == info.TippaniID)
            {
                //if (this.grdRequest.Rows[firstRow].Cells[11].RowSpan == 0)
                //    this.grdRequest.Rows[firstRow].Cells[11].RowSpan = 2;
                //else
                //    this.grdRequest.Rows[firstRow].Cells[11].RowSpan += 1;
                //e.Row.Cells[11].Visible = false;
            }

            else //It's a new category
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;

                orgID = info.OrgID;
                tippaniID = info.TippaniID;
                empID = dynamicEmpID;

                firstRow = e.Row.RowIndex;
                if (e.Row.RowIndex != 0)
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.Style.Add("border-top", "#4F69A2 1px solid");
                    }
            }

        }
    }

    protected void grdRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int orgID = int.Parse(this.grdRequest.SelectedRow.Cells[0].Text);
            int tippaniID = int.Parse(this.grdRequest.SelectedRow.Cells[2].Text);
            int tippaniProcessID = int.Parse(this.grdRequest.SelectedRow.Cells[3].Text);

            //ATTGeneralTippaniSummary summary = BLLGeneralTippani.GetVisitTippaniDetail(orgID, tippaniID, tippaniProcessID);
            ATTGeneralTippaniSummary summary = new ATTGeneralTippaniSummary();

            //this.lblTippaniText.Text = summary.TippaniText;
            //this.lblName.Text = summary.EmpName;
            //this.lblOrgName.Text = summary.OrgName;
            //this.lblDesName.Text = summary.DesName;
            //this.lblVisitSubject.Text = summary.TippaniDetail.VisitPurpose;
            //this.lblVisitLocation.Text = summary.TippaniDetail.VisitLocation;
            //this.lblVisitCountry.Text = summary.VisitCountryName;
            //this.lblVisitRemark.Text = summary.TippaniDetail.VisitRemark;
            //this.lblVisitFromDate.Text = summary.TippaniDetail.VisitFromDate;
            //this.lblVisittoDate.Text = summary.TippaniDetail.VisitToDate;
            //this.txtNote.Text = summary.Note;
            if (summary.ProcessStatus > 0)
            {
                this.ddlDStatus_Rqd.SelectedValue = summary.ProcessStatus.ToString();
            }
            else
            {
                this.ddlDStatus_Rqd.SelectedIndex = -1;
            }
            if (this.hdnForm.Value == "0")
            {
                this.ddlDStatus_Rqd.Enabled = true;
                this.btnSendBack.Enabled = true;
            }
            else if (this.hdnForm.Value == "1")
            {
                this.ddlDStatus_Rqd.Enabled = false;
                this.btnSendBack.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdChannelPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void grdRequest_DataBound(object sender, EventArgs e)
    {
        if (this.grdRequest.Rows.Count > 0)
        {
            if (this.hdnForm.Value == "0")//request from other
            {
                this.lblRequestCount.Text = "तपाईलाइ पठाएको अनुरोधहरु: " + this.grdRequest.Rows.Count.ToString();
            }
            else if (this.hdnForm.Value == "1")//request from me
            {
                this.lblRequestCount.Text = "तपाईले पठाउनु भएको अनुरोधहरु: " + this.grdRequest.Rows.Count.ToString();
            }
        }
        else
        {
            if (this.hdnForm.Value == "0")//request from other
            {
                this.lblRequestCount.Text = "तपाईको लागि कुनै पनि अनुरोध छैन।";
            }
            else if (this.hdnForm.Value == "1")//request from me
            {
                this.lblRequestCount.Text = "तपाईले कुनै पनि अनुरोध पठाउनु भएको छैन।";
            }
        }
    }

    protected void lnkSender_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.hdnForm.Value = "0";
        
        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = 2;//visit id
        info.ProcessToID = this.User.PID;

        //this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info);
        //this.grdRequest.DataBind();
    }

    protected void lnkReceiver_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.hdnForm.Value = "1";

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = 2;//visit id
        info.ProcessByID = this.User.PID;

        //this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info);
        //this.grdRequest.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        if (this.grdRequest.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको टिप्पनी छान्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlDStatus_Rqd.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमण टिप्पनीको लागी तपाईको निर्णय दिनुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();
        if (this.hdnForm.Value == "0")
        {
            process.OrgID = int.Parse(this.grdRequest.SelectedRow.Cells[0].Text);
            process.TippaniID = int.Parse(this.grdRequest.SelectedRow.Cells[2].Text);
            process.TippaniProcessID = int.Parse(this.grdRequest.SelectedRow.Cells[3].Text);
            process.Note = this.txtNote.Text;
            process.Status = int.Parse(this.ddlDStatus_Rqd.SelectedValue);
        }
        else if (this.hdnForm.Value == "1")
        {
            process = null;
        }

        List<ATTGeneralTippaniProcess> processlst = new List<ATTGeneralTippaniProcess>();

        if (this.hdnForm.Value == "0")
        {
            foreach (GridViewRow row in this.chnlPerson.ChannelPerson.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("chkSelect");
                if (box.Checked == true)
                {
                    ATTGeneralTippaniProcess pro = new ATTGeneralTippaniProcess();

                    pro.OrgID = process.OrgID; ;
                    pro.TippaniID = process.TippaniID;
                    pro.TippaniProcessID = 0;
                    pro.SendBy = this.User.PID;
                    pro.SendOn = "";
                    pro.SendTo = int.Parse(row.Cells[8].Text);
                    pro.Note = "";
                    pro.Status = null;
                    pro.SendType = "F";
                    pro.IsChannelPerson = "Y";
                    pro.Action = "A";

                    processlst.Add(pro);
                }
            }

            foreach (GridViewRow row in this.chnlPerson.GeneralPerson.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("chkGSelect");
                if (box.Checked == true)
                {
                    ATTGeneralTippaniProcess pro = new ATTGeneralTippaniProcess();

                    pro.OrgID = process.OrgID;
                    pro.TippaniID = process.TippaniID;
                    pro.TippaniProcessID = 0;
                    pro.SendBy = this.User.PID;
                    pro.SendOn = "";
                    pro.SendTo = int.Parse(row.Cells[0].Text);
                    pro.Note = "";
                    pro.Status = null;
                    pro.SendType = "F";
                    pro.IsChannelPerson = "N";
                    pro.Action = "A";

                    processlst.Add(pro);

                    box.Checked = false;
                }
            }
        }

        try
        {
            if (this.hdnForm.Value == "0")
            {
                //BLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(process, processlst);
                this.ClearME();

                this.LoadTippaniRequest();

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
        foreach (GridViewRow row in this.chnlPerson.ChannelPerson.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkSelect");
            box.Checked = false;
        }

        this.chnlPerson.GeneralPerson.DataSource = "";
        this.chnlPerson.GeneralPerson.DataBind();

        this.grdRequest.SelectedIndex = -1;

        this.lblTippaniText.Text = "";
        this.lblEmpName.Text = "";
        this.lblOrgName.Text = "";
        this.lblDesName.Text = "";
        this.lblVisitSubject.Text = "";
        this.lblVisitLocation.Text = "";
        this.lblVisitRemark.Text = "";
        this.lblVisitFromDate.Text = "";
        this.lblVisittoDate.Text = "";
        this.lblVisitCountry.Text = "";

        this.ddlDStatus_Rqd.SelectedIndex = -1;

        this.hdnForm.Value = "0";

        this.btnSendBack.Enabled = false;
    }

    protected void lnkDeleted_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
    
    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }

    protected void btnSendBack_Click(object sender, EventArgs e)
    {
        ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();
        process.OrgID = int.Parse(this.grdRequest.SelectedRow.Cells[0].Text);
        process.TippaniID = int.Parse(this.grdRequest.SelectedRow.Cells[2].Text);
        process.TippaniProcessID = 0;
        process.ProcessBy = this.User.PID;
        process.ProcessOn = "";
        process.ProcessTo = int.Parse(this.grdRequest.SelectedRow.Cells[4].Text);
        process.Status = null;
        process.SendType = "B";

        try
        {
            //BLLGeneralTippaniProcess.SendBackTippani(process, 2);
            this.ClearME();
            
            this.lblStatusMessage.Text = "Tippai send back successfully.";
            this.programmaticModalPopup.Show();    
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();    
        }
    }
    protected void grdChannelPerson_DataBound(object sender, EventArgs e)
    {

    }
    protected void btnSearchGeneral_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelGeneral_Click(object sender, EventArgs e)
    {

    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdSEmployee_DataBound(object sender, EventArgs e)
    {

    }
}
