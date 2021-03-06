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

public partial class MODULES_OAS_UserControls_VisitEntry : System.Web.UI.UserControl
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

    public List<ATTGeneralTippaniDetail> VisitorList
    {
        get { return Session["VisitListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    private string _EmployeeType;
    public string EmployeeType
    {
        get { return this._EmployeeType.Trim(); }
        set { this._EmployeeType = value; }
    }

    public GridView VisitorGrid
    {
        get { return this.grdVisiterDetail; }
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
            this.LoadCountry();
            this.LoadTippaniStatus();

            if (this.ActionMode == "A")
            {
                this.SetVisitorSessionList();
            }
        }
    }

    void SetVisitorSessionList()
    {
        Session["VisitListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    void LoadCountry()
    {
        try
        {
            this.ddlCountry_Rqd.DataSource = BLLCountry.GetCountries(null, 0);
            this.ddlCountry_Rqd.DataTextField = "CountryNepName";
            this.ddlCountry_Rqd.DataValueField = "COuntryID";
            this.ddlCountry_Rqd.DataBind();
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

    public List<ATTGeneralTippaniDetail> GetVisitorList()
    {
        return this.VisitorList;
    }

    public ATTGeneralTippaniSummary GetVisitorDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary visit = new ATTGeneralTippaniSummary();

        if (this.grdVisiterDetail.SelectedIndex < 0)
        {
            visit.OrgID = orgID;
            visit.TippaniID = tippaniID;
            visit.TippaniSNO = 0;
            visit.EmpID = empID;
            visit.EmpName = this.EmpName;
            visit.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.VisitorList[this.grdVisiterDetail.SelectedIndex] as ATTGeneralTippaniSummary;
            visit.OrgID = detail.OrgID;
            visit.TippaniID = detail.TippaniID;
            visit.TippaniSNO = detail.TippaniSNO;
            visit.EmpID = detail.EmpID;
            visit.EmpName = detail.EmpName;

            if (this.VisitorList[this.grdVisiterDetail.SelectedIndex].Action == "A")
            {
                visit.Action = "A";
            }
            else
            {
                visit.Action = "E";
            }
        }

        visit.VisitLocation = this.txtLocation_Rqd.Text;
        visit.VisitCountryID = int.Parse(this.ddlCountry_Rqd.SelectedValue);
        visit.VisitCountryName = this.ddlCountry_Rqd.SelectedItem.Text;
        visit.VisitFromDate = this.txtFromDate_Rdt.Text;
        visit.VisitToDate = this.txtToDate_Rdt.Text;
        visit.VisitVehicle = this.txtVehicle_Rqd.Text;
        visit.VisitPurpose = this.txtSubject_Rqd.Text;
        visit.VisitRemark = this.txtRemarks.Text;
        visit.VisitEntryBy = entryBy;
        //visit.Action = "A";

        return visit;
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
        this.txtLocation_Rqd.Text = "";
        this.ddlCountry_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtSubject_Rqd.Text = "";
        this.txtRemarks.Text = "";
        this.txtVehicle_Rqd.Text = "";
        this.txtNote.Text = "";
        this.ddlTippaniStatus.SelectedIndex = 0;
        this.ActionMode = "A";
        this.grdVisiterDetail.SelectedIndex = -1;
        this.grdVisiterDetail.DataSource = "";
        this.grdVisiterDetail.DataBind();
        this.SetVisitorSessionList();
    }

    protected void grdVisiterDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniSummary summary = e.Row.DataItem as ATTGeneralTippaniSummary;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(summary.Action);
            e.Row.ForeColor = c;

            if (summary.Action == "D")
            {
                ((LinkButton)e.Row.Cells[9].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[9].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnAddVisiter_Click(object sender, EventArgs e)
    {
        if (this.txtLocation_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको स्थना छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlCountry_Rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको देश छन्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtFromDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया अवधि देखि को मिति राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtToDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया अवधि सम्म को मिति राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtSubject_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "क्रिपया भ्रमणको बिषय राख्न्नुहोस ।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdVisiterDetail.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.VisitorList.Exists
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

        if (this.grdVisiterDetail.SelectedIndex < 0)
        {
            this.VisitorList.Add(this.GetVisitorDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.VisitorList[this.grdVisiterDetail.SelectedIndex] = this.GetVisitorDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdVisiterDetail.DataSource = this.VisitorList;
        this.grdVisiterDetail.DataBind();

        this.txtLocation_Rqd.Text = "";
        this.ddlCountry_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtSubject_Rqd.Text = "";
        this.txtRemarks.Text = "";
        this.txtVehicle_Rqd.Text = "";
        //this.txtNote.Text = "";
        this.ddlTippaniStatus.SelectedIndex = 0;
        this.grdVisiterDetail.SelectedIndex = -1;
    }

    protected void grdVisiterDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.VisitorList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridViewRow CurrentRow = this.grdVisiterDetail.Rows[e.RowIndex];

        int DelCmdIndex = 9;

        if (currentO.Action == "A")
        {
            this.VisitorList.RemoveAt(e.RowIndex);
            this.grdVisiterDetail.DataSource = this.VisitorList;
            this.grdVisiterDetail.DataBind();
        }
        else if (currentO.Action == "N" || currentO.Action == "D" || currentO.Action == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                this.grdVisiterDetail.DataSource = lst;
                this.grdVisiterDetail.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                this.grdVisiterDetail.DataSource = lst;
                this.grdVisiterDetail.DataBind();
            }
        }
    }

    public void LoadVisitDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetVisitorSessionList();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetVisitTippaniDetail(orgID, tippaniID, tipPrcID);
            
            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.VisitorList.Add(summary);
            }
            this.grdVisiterDetail.DataSource = this.VisitorList;
            this.grdVisiterDetail.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdVisiterDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.VisitorList[this.grdVisiterDetail.SelectedIndex];

        this.txtLocation_Rqd.Text = detail.VisitLocation;
        this.ddlCountry_Rqd.SelectedValue = detail.VisitCountryID.ToString();
        this.txtFromDate_Rdt.Text = detail.VisitFromDate;
        this.txtToDate_Rdt.Text = detail.VisitToDate;
        this.txtVehicle_Rqd.Text = detail.VisitVehicle;
        this.txtSubject_Rqd.Text = detail.VisitPurpose;
        this.txtRemarks.Text = detail.VisitRemark;
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
