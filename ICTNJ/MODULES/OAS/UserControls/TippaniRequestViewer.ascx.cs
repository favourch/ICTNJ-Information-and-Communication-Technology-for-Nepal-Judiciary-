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

using System.Runtime.InteropServices;

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

//this.hdnForm.Value = "0"; load sender
//this.hdnForm.Value = "1"; load receiver

public partial class MODULES_OAS_UserControls_TippaniRequestViewer : System.Web.UI.UserControl
{
    private ATTUserLogin User
    {
        get
        {
            return (ATTUserLogin)Session["Login_User_Detail"];
        }
    }

    #region some important property for delegation
    
    public delegate void GenericMethod();
    
    /// <summary>
    /// Delegate for generic event handler
    /// </summary>
    private GenericMethod _ParentClearMethod;
    public GenericMethod ParentClearMethod
    {
        get { return this._ParentClearMethod; }
        set { this._ParentClearMethod = value; }
    }

    private TippaniSubject _TippaniSubjectType;
    public TippaniSubject TippaniSubjectType
    {
        get { return this._TippaniSubjectType; }
        set { this._TippaniSubjectType = value; }
    }

    public GridView GrdRequestViewer
    {
        get { return this.grdRequest; }
    }

    public LinkButton LnkSender
    {
        get { return this.lnkSender; }
    }

    public LinkButton LnkrReceiver
    {
        get { return this.lnkReceiver; }
    }

    #endregion

    public bool IsValidForSending
    {
        get 
        {
            string s = this.grdRequest.SelectedRow.Cells[7].Text;
            if (s != "" && s != "&nbsp;")
                return false;
            else
                return true;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    int GetMaxRecordNumber()
    {
        return 8;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            this.LoadStatus();
            this.LoadPriority();
            this.LoadTippaniRequest(1);
        }
    }

    void LoadPriority()
    {
        this.ddlPriority.DataSource = BLLTippaniPriority.GetTippaniPriority();
        this.ddlPriority.DataTextField = "PriorityName";
        this.ddlPriority.DataValueField = "PriorityID";
        this.ddlPriority.DataBind();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();

            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));

            this.ddlOrg.DataSource = lst;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadStatus()
    {
        try
        {
            this.ddlStatus.DataSource = BLLTippaniStatus.GetTippaniStatusList(true);
            this.ddlStatus.DataTextField = "TippaniStatusName";
            this.ddlStatus.DataValueField = "TippaniStatusID";
            this.ddlStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadTippaniRequest(int Count)
    {
        decimal totalRecord = 1;
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = (int)this.TippaniSubjectType;
        info.ProcessToID = this.User.PID;
        info.Filter = this.GetFilter();

        try
        {
            List<ATTGeneralTippaniRequestInfo> lst = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, sIndex, eIndex, ref totalRecord);
            this.grdRequest.DataSource = lst;
            this.grdRequest.DataBind();

            if (Count > 0)
            {
                this.hdnTotalRecord.Value = totalRecord.ToString();
            }

            this.ProcessPaging();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public ATTGeneralTippaniProcess GetSelfActorProcess()
    {
        ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

        process.OrgID = int.Parse(this.grdRequest.SelectedRow.Cells[0].Text);
        process.TippaniID = int.Parse(this.grdRequest.SelectedRow.Cells[1].Text);
        process.TippaniProcessID = int.Parse(this.grdRequest.SelectedRow.Cells[2].Text);
        process.EntryBy = this.User.UserName;
        
        return process;
    }

    public ATTGeneralTippaniProcess GetSendBackProcess()
    {
        ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

        process.OrgID = int.Parse(this.grdRequest.SelectedRow.Cells[0].Text);
        process.TippaniID = int.Parse(this.grdRequest.SelectedRow.Cells[1].Text);
        process.TippaniProcessID = int.Parse(this.grdRequest.SelectedRow.Cells[2].Text);
        process.SenderOrgID = this.User.OrgID;
        process.SenderUnitID = this.User.UnitID;
        process.SendBy = this.User.PID;
        process.SendOn = "";
        process.ReceiverOrgID = int.Parse(this.grdRequest.SelectedRow.Cells[18].Text);
        process.ReceiverUnitID = int.Parse(this.grdRequest.SelectedRow.Cells[19].Text);
        process.SendTo = int.Parse(this.grdRequest.SelectedRow.Cells[3].Text);
        process.Note = "";
        process.Status = null;
        process.SendType = "B";
        process.IsChannelPerson = this.grdRequest.SelectedRow.Cells[6].Text;
        process.EntryBy = this.User.UserName;
        process.Action = "A";

        return process;
    }

    public void Clear()
    {
        this.grdRequest.SelectedIndex = -1;
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
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[13].Visible = false;
        e.Row.Cells[14].Visible = false;//sender org id
        e.Row.Cells[15].Visible = false;//sender unit id
        e.Row.Cells[18].Visible = false;//receiver org id
        e.Row.Cells[19].Visible = false;//receiver unit id

        if (this.hdnForm.Value == "0")
        {
            e.Row.Cells[16].Visible = true;
            e.Row.Cells[17].Visible = true;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
        }
        else
        {
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[20].Visible = true;
            e.Row.Cells[21].Visible = true;
        }

        //e.Row.Cells[15].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniRequestInfo info = (e.Row.DataItem as ATTGeneralTippaniRequestInfo);
            
            e.Row.ForeColor = BLLTippaniStatus.GetColor(info.TippaniStatusID);
            if (info.TippaniStatusID != 3)
            {
                e.Row.ForeColor = BLLTippaniStatus.GetColor(info.ProcessStatusID);
            }
                        
            if ((e.Row.DataItem as ATTGeneralTippaniRequestInfo).TippaniStatusID == 1)
            {
                e.Row.Cells[12].Text = "Running";
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            info = (ATTGeneralTippaniRequestInfo)e.Row.DataItem;

            if (orgID == info.OrgID && tippaniID == info.TippaniID)
            {
                if (this.grdRequest.Rows[firstRow].Cells[8].RowSpan == 0)
                    this.grdRequest.Rows[firstRow].Cells[8].RowSpan = 2;
                else
                    this.grdRequest.Rows[firstRow].Cells[8].RowSpan += 1;
                e.Row.Cells[8].Visible = false;

                if (this.grdRequest.Rows[firstRow].Cells[12].RowSpan == 0)
                    this.grdRequest.Rows[firstRow].Cells[12].RowSpan = 2;
                else
                    this.grdRequest.Rows[firstRow].Cells[12].RowSpan += 1;
                e.Row.Cells[12].Visible = false;

                if (this.grdRequest.Rows[firstRow].Cells[22].RowSpan == 0)
                    this.grdRequest.Rows[firstRow].Cells[22].RowSpan = 2;
                else
                    this.grdRequest.Rows[firstRow].Cells[22].RowSpan += 1;
                e.Row.Cells[22].Visible = false;
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

    public void LoadSender()
    {
        decimal totalRecord = 1;
        this.hdnIndex.Value = "0";
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        this.hdnForm.Value = "0";

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = (int)this.TippaniSubjectType;
        info.ProcessToID = this.User.PID;
        info.Filter = this.GetFilter();

        this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, sIndex, eIndex, ref totalRecord);
        this.grdRequest.DataBind();
        //if (Count > 0)
        {
            this.hdnTotalRecord.Value = totalRecord.ToString();
        }

        this.hdnTotalRecord.Value = totalRecord.ToString();

        this.ProcessPaging();
    }

    public void LoadSender(bool b)
    {
        //decimal totalRecord = 0;
        decimal totalRecord = 1;
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        this.hdnForm.Value = "0";

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = (int)this.TippaniSubjectType;
        info.ProcessToID = this.User.PID;
        info.Filter = this.GetFilter();

        this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, sIndex, eIndex, ref totalRecord);
        this.grdRequest.DataBind();
        //if (Count > 0)
        {
            this.hdnTotalRecord.Value = totalRecord.ToString();
        }

        this.ProcessPaging();
    }

    public void LoadReceiver()
    {
        decimal totalRecord = 1;
        this.hdnIndex.Value = "0";
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        this.hdnForm.Value = "1";

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = (int)this.TippaniSubjectType;
        info.ProcessByID = this.User.PID;
        info.Filter = this.GetFilter();

        this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, sIndex, eIndex, ref totalRecord);
        this.grdRequest.DataBind();
        //if (Count > 0)
        {
            this.hdnTotalRecord.Value = totalRecord.ToString();
        }

        this.hdnTotalRecord.Value = totalRecord.ToString();

        this.ProcessPaging();
    }

    public void LoadReceiver(bool b)
    {
        //decimal totalRecord = 0;
        decimal totalRecord = 1;
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        this.hdnForm.Value = "1";

        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();
        info.OrgID = this.User.OrgID;
        info.TippaniSubjectID = (int)this.TippaniSubjectType;
        info.ProcessByID = this.User.PID;
        info.Filter = this.GetFilter();

        this.grdRequest.DataSource = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, sIndex, eIndex, ref totalRecord);
        this.grdRequest.DataBind();
        //if (Count > 0)
        {
            this.hdnTotalRecord.Value = totalRecord.ToString();
        }

        this.ProcessPaging();
    }

    void ProcessPaging()
    {
        int sIndex = int.Parse(this.hdnIndex.Value);
        int eIndex = this.GetMaxRecordNumber();

        if (this.grdRequest.Rows.Count > 0)
        {
            decimal lastIndex = sIndex + eIndex;

            if (lastIndex > decimal.Parse(this.hdnTotalRecord.Value))
                lastIndex = decimal.Parse(this.hdnTotalRecord.Value);

            this.lblPaging.Text = "Record (" + (sIndex + 1).ToString() + " - " + lastIndex.ToString() + ") of " + this.hdnTotalRecord.Value;
        }
        else
        {
            this.lblPaging.Text = "";
        }
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        this.InvokeParentMethod();
        int nextIndex = int.Parse(this.hdnIndex.Value) - this.GetMaxRecordNumber();
        if (nextIndex >= 0)
        {
            this.hdnIndex.Value = nextIndex.ToString();
            if (this.hdnForm.Value == "0")
            {
                this.LoadSender(true);
            }
            else
            {
                this.LoadReceiver(true);
            }
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        this.InvokeParentMethod();
        int nextIndex = int.Parse(this.hdnIndex.Value) + this.GetMaxRecordNumber();

        if (this.grdRequest.Rows.Count > 0)
        {
            this.hdnIndex.Value = nextIndex.ToString();
            if (this.hdnForm.Value == "0")
            {
                this.LoadSender(true);
            }
            else
            {
                this.LoadReceiver(true);
            }
        }
    }

    void InvokeParentMethod()
    {
        if (this.ParentClearMethod != null)
            this.ParentClearMethod.Invoke();
        else
            throw new ApplicationException("Delegation has not been initialized. Please initialize it.");
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTOrganizationUnit> lst = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(this.ddlOrg.SelectedValue), null);
            lst.Insert(0, new ATTOrganizationUnit(-1, -1, "--- शाखा छन्नुहोस् ---"));
            this.ddlUnit.DataSource = lst;
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    string GetFilter()
    {
        string filter = "";
        if (this.hdnForm.Value == "0")
        {
            if (this.ddlOrg.SelectedIndex > 0)
                filter += " and V.sender_org_id = " + int.Parse(this.ddlOrg.SelectedValue);
            if (this.ddlUnit.SelectedIndex > 0)
                filter += " and V.sender_unit_id = " + int.Parse(this.ddlUnit.SelectedValue);
        }
        else
        {
            if (this.ddlOrg.SelectedIndex > 0)
                filter += " and V.receiver_org_id = " + int.Parse(this.ddlOrg.SelectedValue);
            if (this.ddlUnit.SelectedIndex > 0)
                filter += " and V.receiver_unit_id = " + int.Parse(this.ddlUnit.SelectedValue);
        }

        if (this.ddlStatus.SelectedIndex > 0)
            filter += " and V.tippani_status_id = " + int.Parse(this.ddlStatus.SelectedValue);
        
        if (this.ddlPriority.SelectedIndex > 0)
            filter += " and V.priority_id = " + int.Parse(this.ddlPriority.SelectedValue);
        
        return filter;
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (this.hdnForm.Value == "0")
        {
            this.InvokeParentMethod();
            this.LoadSender(true);
        }
        else
        {
            this.InvokeParentMethod();
            this.LoadReceiver(true);
        }
    }
}