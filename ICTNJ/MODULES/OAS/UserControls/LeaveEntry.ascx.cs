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

public partial class MODULES_OAS_UserControls_LeaveEntry : System.Web.UI.UserControl
{
    public delegate void GenericMethod();

    private GenericMethod _ParentRetriveMethod;
    public GenericMethod ParentRetriveMethod
    {
        get { return this._ParentRetriveMethod; }
        set { this._ParentRetriveMethod = value; }
    }

    private int _OrgID;
    public int OrgID
    {
        get { return this._OrgID; }
        set { this._OrgID = value; }
    }

    private int _TippaniID;
    public int TippaniID
    {
        get { return this._TippaniID; }
        set { this._TippaniID = value; }
    }

    private double _EmpID;
    public double EmpID
    {
        get { return this._EmpID; }
        set { this._EmpID = value; }
    }

    private string _EmpName;
    public string EmpName
    {
        get { return this._EmpName.Trim(); }
        set { this._EmpName = value; }
    }

    private string _EntryBy;
    public string EntryBy
    {
        get { return this._EntryBy.Trim(); }
        set { this._EntryBy = value; }
    }

    public FreeTextBoxControls.FreeTextBox Note
    {
        get
        {
            return this.txtNote;
        }
    }

    public List<ATTGeneralTippaniDetail> LeaveList
    {
        get { return Session["LeaveListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
    }

    public GridView LeaveGrid
    {
        get { return this.grdLeave; }
    }

    public TextBox FromDate
    {
        get { return this.txtFromDate_Rdt; }
    }

    public TextBox ToDate
    {
        get { return this.txtToDate_Rdt; }
    }

    public TextBox TotalDays
    {
        get { return this.txtTotalDays_Rqd; }
    }

    private string _ActionMode = "A";
    public string ActionMode
    {
        set { this._ActionMode = value; }
        get { return this._ActionMode.Trim(); }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadTippaniStatus();
            this.LoadLeaveType();
            if (this.ActionMode == "A")
            {
                this.SetLeaveListSession();
            }
        }
    }

    void LoadLeaveType()
    {
        try
        {
            List<ATTLeaveType> lst = BLLLeaveType.GetLeaveType(null, "Y");
            lst.Insert(0, new ATTLeaveType(-1, " बिदा छन्नुहोस ", ""));
            this.ddlLeaveType_Rqd.DataSource = lst;
            this.ddlLeaveType_Rqd.DataTextField = "LeaveTypeName";
            this.ddlLeaveType_Rqd.DataValueField = "LeaveTypeID";
            this.ddlLeaveType_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadTippaniStatus()
    {
        try
        {
            this.ddlTippaniStatus.DataSource = BLLTippaniStatus.GetTippaniStatusList(false);
            this.ddlTippaniStatus.DataTextField = "TippaniStatusName";
            this.ddlTippaniStatus.DataValueField = "TippaniStatusID";
            this.ddlTippaniStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void SetLeaveListSession()
    {
        Session["LeaveListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    public List<ATTGeneralTippaniDetail> GetLeaveList()
    {
        return Session["LeaveListSession"] as List<ATTGeneralTippaniDetail>;
    }

    protected void btnAddAward_Click(object sender, EventArgs e)
    {
        if (this.ddlLeaveType_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया बिदाको किसिम छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtApplicationDate_Rdt.Text.Trim() == "" || this.txtFromDate_Rdt.Text.Trim() == "" || this.txtToDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया बिदाको मितिहरु राख्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (string.Compare(this.txtToDate_Rdt.Text.Trim(), this.txtFromDate_Rdt.Text.Trim()) < 0)
        {
            this.lblStatusMessage.Text = "बिदाको अवधि देखि मिति अवधि सम्म मिति भन्दा सानो हुनुपर्छ ।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdLeave.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.LeaveList.Exists
                                                    (
                                                        delegate(ATTGeneralTippaniDetail d)
                                                        {
                                                            return d.EmpID == this.EmpID;
                                                        }
                                                    );

            if (existence == true)
            {
                this.lblStatusMessage.Text = "कर्मचारी -> " + this.EmpName + "<br>" + "पहिलेनै छानिसकेकोछ। कृपया अर्को कर्मचारी छान्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        if (this.grdLeave.SelectedIndex < 0)
        {
            ATTGeneralTippaniDetail det = this.GetLeaveDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
            //if (det.ReqNoOfDays > 99) ;
            this.LeaveList.Add(det);
        }
        else
        {
            this.LeaveList[this.grdLeave.SelectedIndex] = this.GetLeaveDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdLeave.DataSource = this.LeaveList;
        this.grdLeave.DataBind();

        this.ddlLeaveType_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtApplicationDate_Rdt.Text = "";
        this.txtTotalDays_Rqd.Text = "0";
        this.txtRemark.Text = "";
        this.grdLeave.SelectedIndex = -1;
    }

    private ATTGeneralTippaniSummary GetLeaveDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary leave = new ATTGeneralTippaniSummary();

        if (this.grdLeave.SelectedIndex < 0)
        {
            leave.OrgID = orgID;
            leave.TippaniID = tippaniID;
            leave.TippaniSNO = 0;
            leave.EmpID = empID;
            leave.EmpName = this.EmpName;
            leave.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.LeaveList[this.grdLeave.SelectedIndex] as ATTGeneralTippaniSummary;
            leave.OrgID = detail.OrgID;
            leave.TippaniID = detail.TippaniID;
            leave.TippaniSNO = detail.TippaniSNO;
            leave.EmpID = detail.EmpID;
            leave.EmpName = detail.EmpName;

            if (this.LeaveList[this.grdLeave.SelectedIndex].Action == "A")
            {
                leave.Action = "A";
            }
            else
            {
                leave.Action = "E";
            }
        }

        leave.LeaveTypeID = int.Parse(this.ddlLeaveType_Rqd.SelectedValue);
        leave.LeaveType = this.ddlLeaveType_Rqd.SelectedItem.Text;
        leave.ReqFromDate = this.txtFromDate_Rdt.Text;
        leave.ReqToDate = this.txtToDate_Rdt.Text;
        leave.ApplicationDate = this.txtApplicationDate_Rdt.Text;
        leave.ReqNoOfDays = BLLGeneralTippani.GetDateDifference(leave.ReqToDate, leave.ReqFromDate) + 1;
        leave.ReqReason = this.txtRemark.Text.Trim();
        leave.LeaveLevel = LeaveMode.Request;
        //leave.Action = "A";
        leave.LeaveEntryBy = entryBy;

        return leave;
    }

    public void Clear()
    {
        this.ddlLeaveType_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtApplicationDate_Rdt.Text = "";
        this.txtTotalDays_Rqd.Text = "0";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdLeave.SelectedIndex = -1;
        this.grdLeave.DataSource = "";
        this.grdLeave.DataBind();
        this.SetLeaveListSession();
    }

    protected void grdLeave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[4].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniSummary summary = e.Row.DataItem as ATTGeneralTippaniSummary;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(summary.Action);
            e.Row.ForeColor = c;

            if (summary.Action == "D")
            {
                ((LinkButton)e.Row.Cells[8].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[8].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void grdLeave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.LeaveList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdLeave;
        GridViewRow CurrentRow = this.grdLeave.Rows[e.RowIndex];

        int DelCmdIndex = 8;

        if (currentO.Action == "A")
        {
            lst.RemoveAt(e.RowIndex);
            grd.DataSource = lst;
            grd.DataBind();
        }
        else if (currentO.Action == "N" || currentO.Action == "D" || currentO.Action == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                grd.DataSource = lst;
                grd.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                grd.DataSource = lst;
                grd.DataBind();
            }
        }
    }

    public void LoadLeaveDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetLeaveListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetLeaveTippaniDetail(orgID, tippaniID, tipPrcID, LeaveMode.Request);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                summary.LeaveLevel = LeaveMode.Request;
                this.LeaveList.Add(summary);
            }
            this.grdLeave.DataSource = this.LeaveList;
            this.grdLeave.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdLeave_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.LeaveList[this.grdLeave.SelectedIndex];

        this.ddlLeaveType_Rqd.SelectedValue = detail.LeaveTypeID.ToString();
        this.txtApplicationDate_Rdt.Text = detail.ApplicationDate;
        this.txtFromDate_Rdt.Text = detail.ReqFromDate;
        this.txtToDate_Rdt.Text = detail.ReqToDate;
        this.txtRemark.Text = detail.ReqReason;
    }

    public void LoadBodyFromMessage(int orgID, int msgID)
    {
        try
        {
            List<ATTMessage> lst = BLLMessage.GetMessageByIDs(orgID, msgID);
            this.txtNote.Text = lst[0].Body;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LoadBodyFromDartaaChalaani(int orgID, string regDate, int regNo)
    {
        try
        {
            List<ATTDartaaChalaani> lst = BLLDartaaChalaani.GetDartaaChalaaniByIDs(orgID, regDate, regNo);
            if (lst.Count == 1)
            {
                this.txtNote.Text = lst[0].Description;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
