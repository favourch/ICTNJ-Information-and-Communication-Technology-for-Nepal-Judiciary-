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

public partial class MODULES_OAS_UserControls_CommitteeEntry : System.Web.UI.UserControl
{
    public ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

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

    public DropDownList Status
    {
        get { return this.ddlTippaniStatus; }
    }

    public FreeTextBoxControls.FreeTextBox Note
    {
        get
        {
            return this.txtNote;
        }
    }

    public List<ATTGeneralTippaniDetail> CommitteeMemberList
    {
        get { return Session["CommitteeMemberListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    private string _EmployeeType;
    public string EmployeeType
    {
        get { return this._EmployeeType.Trim(); }
        set { this._EmployeeType = value; }
    }

    public GridView CommitteeMemberGrid
    {
        get { return this.grdCommittee; }
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
            this.LoadOrganization();
            this.LoadTippaniStatus();

            if (this.ActionMode == "A")
            {
                this.SetCommitteeMemberSessionList();
            }
        }
    }

    void SetCommitteeMemberSessionList()
    {
        Session["CommitteeMemberListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            ATTOrganization org = new ATTOrganization(-1, "--- कार्यालय छान्नुहोस् ---");
            lst.Insert(0, org);
            this.ddlOrg_Rqd.DataSource = lst;
            this.ddlOrg_Rqd.DataTextField = "OrgName";
            this.ddlOrg_Rqd.DataValueField = "OrgID";
            this.ddlOrg_Rqd.DataBind();
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

    public List<ATTGeneralTippaniDetail> GetCommitteeMemberList()
    {
        return this.CommitteeMemberList;
    }

    public ATTCommitteeByTippani GetCommittee()
    {
        ATTCommitteeByTippani committee = new ATTCommitteeByTippani();
        
        committee.CommitteeOrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        if (this.hdnIDs.Value.Trim() == "")
        {
            committee.CommitteeID = 0;
            committee.Action = "A";
        }
        else
        {
            char[] token ={ '/' };
            committee.CommitteeID = int.Parse(this.hdnIDs.Value.Split(token)[1]);
            committee.Action = "E";
        }
        committee.CommitteeName = this.txtCommittee_Rqd.Text;
        committee.Description = this.txtDesc.Text;
        committee.Type = "C";
        committee.OrgID = this.User.OrgID;
        committee.TippaniID = 0;
        committee.EntryBy=this.User.UserName;
        
        return committee;
    }

    public ATTGeneralTippaniSummary GetCommitteeMemberDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary comm = new ATTGeneralTippaniSummary();

        if (this.grdCommittee.SelectedIndex < 0)
        {
            comm.OrgID = orgID;
            comm.TippaniID = tippaniID;
            comm.TippaniSNO = 0;
            comm.EmpID = empID;
            comm.EmpName = this.EmpName;
            comm.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.CommitteeMemberList[this.grdCommittee.SelectedIndex] as ATTGeneralTippaniSummary;
            comm.OrgID = detail.OrgID;
            comm.TippaniID = detail.TippaniID;
            comm.TippaniSNO = detail.TippaniSNO;
            comm.EmpID = detail.EmpID;
            comm.EmpName = detail.EmpName;

            if (this.CommitteeMemberList[this.grdCommittee.SelectedIndex].Action == "A")
            {
                comm.Action = "A";
            }
            else
            {
                comm.Action = "E";
            }
        }

        comm.CommitteeOrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        comm.CommitteeOrgName = this.ddlOrg_Rqd.SelectedItem.Text;
        comm.CommitteeID = 0;
        comm.CommitteeName = this.txtCommittee_Rqd.Text;
        comm.EntryBy = entryBy;
        //visit.Action = "A";

        return comm;
    }

    public void SetVisitTipppaniDetail(ATTGeneralTippaniSummary summary)
    {
        //this.txtLocation_Rqd.Text = summary.TippaniDetail.VisitLocation;
        //this.ddlCountry_Rqd.SelectedValue = summary.TippaniDetail.VisitCountryID.ToString();
        //this.txtFromDate_Rdt.Text = summary.TippaniDetail.VisitFromDate;
        //this.txtToDate_Rdt.Text = summary.TippaniDetail.VisitToDate;
        //this.txtSubject_Rqd.Text = summary.TippaniDetail.VisitPurpose;
        //this.txtRemarks_Rdt.Text = summary.TippaniDetail.VisitRemark;

        //this.txtNote.Text = summary.Note;
        //this.ddlTippaniStatus.SelectedValue = summary.ProcessStatus.ToString();
    }

    public void Clear()
    {
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.txtCommittee_Rqd.Text = "";
        this.txtDesc.Text = "";
        this.txtNote.Text = "";
        this.ddlTippaniStatus.SelectedIndex = 0;
        this.hdnIDs.Value = "";
        this.ddlOrg_Rqd.Enabled = true;
        this.ActionMode = "A";
        this.grdCommittee.SelectedIndex = -1;
        this.grdCommittee.DataSource = "";
        this.grdCommittee.DataBind();
        this.SetCommitteeMemberSessionList();
    }

    protected void grdCommittee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniSummary summary = e.Row.DataItem as ATTGeneralTippaniSummary;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(summary.Action);
            e.Row.ForeColor = c;

            if (summary.Action == "D")
            {
                ((LinkButton)e.Row.Cells[2].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[2].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        if (this.ddlOrg_Rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "क्रिपया कार्यालय छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtCommittee_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया कमिटिको नाम राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdCommittee.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.CommitteeMemberList.Exists
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

        if (this.grdCommittee.SelectedIndex < 0)
        {
            this.CommitteeMemberList.Add(this.GetCommitteeMemberDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.CommitteeMemberList[this.grdCommittee.SelectedIndex] = this.GetCommitteeMemberDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdCommittee.DataSource = this.CommitteeMemberList;
        this.grdCommittee.DataBind();

        //this.ddlOrg_Rqd.SelectedIndex = 0;
        //this.txtCommittee_Rqd.Text = "";
        //this.txtDesc.Text = "";
        this.ddlTippaniStatus.SelectedIndex = 0;
        this.grdCommittee.SelectedIndex = -1;
    }

    protected void grdCommittee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.CommitteeMemberList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridViewRow CurrentRow = this.grdCommittee.Rows[e.RowIndex];

        int DelCmdIndex = 2;

        if (currentO.Action == "A")
        {
            this.CommitteeMemberList.RemoveAt(e.RowIndex);
            this.grdCommittee.DataSource = this.CommitteeMemberList;
            this.grdCommittee.DataBind();
        }
        else if (currentO.Action == "N" || currentO.Action == "D" || currentO.Action == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                this.grdCommittee.DataSource = lst;
                this.grdCommittee.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                this.grdCommittee.DataSource = lst;
                this.grdCommittee.DataBind();
            }
        }
    }

    public void LoadCommitteeMemberDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetCommitteeMemberSessionList();
        ATTCommitteeByTippani committee = null;
        try
        {
            committee = BLLCommitteeByTippani.GetCommitteeByTippaniByTIDs(orgID, tippaniID);
            if (committee == null)
            {
                this.lblStatusMessage.Text = "Error:: Zero object or multiple objects are selected.<br>Please check the system.";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                this.ddlOrg_Rqd.SelectedValue = committee.CommitteeOrgID.ToString();
                this.txtCommittee_Rqd.Text = committee.CommitteeName;
                this.txtDesc.Text = committee.Description;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetCommitteeTippaniDetail(orgID, tippaniID);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.CommitteeMemberList.Add(summary);
            }
            this.grdCommittee.DataSource = this.CommitteeMemberList;
            this.grdCommittee.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

        this.hdnIDs.Value = committee.CommitteeOrgID.ToString() + "/" + committee.CommitteeID.ToString();
        this.ddlOrg_Rqd.Enabled = false;
    }

    protected void grdCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    public void LoadBodyFromMessage(int orgID, int msgID)
    {
        try
        {
            List<ATTMessage> lst = BLLMessage.GetMessageByIDs(orgID, msgID);
            if (lst.Count == 1)
            {
                this.txtNote.Text = lst[0].Body;
            }
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
