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

public partial class MODULES_OAS_UserControls_TrainingEntry : System.Web.UI.UserControl
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

    public List<ATTGeneralTippaniDetail> TrainingList
    {
        get { return Session["TrainingListSession"] as List<ATTGeneralTippaniDetail>; }
    }
    
    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
    }

    public GridView TraineeGrid
    {
        get { return this.grdTraining; }
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
            this.LoadInstitution();
            if (this.ActionMode == "A")
            {
                this.SetTrainingListSession();
            }
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

    void LoadInstitution()
    {
        try
        {
            List<ATTInstitution> lst = BLLInstitution.GetInstitution(null, "Y");
            lst.Insert(0, new ATTInstitution(-1, "छन्नुहोस्", "", "", -1, ""));
            this.ddlInstitution_Rqd.DataSource = lst;
            this.ddlInstitution_Rqd.DataTextField = "InstitutionName";
            this.ddlInstitution_Rqd.DataValueField = "InstitutionID";
            this.ddlInstitution_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void SetTrainingListSession()
    {
        Session["TrainingListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    public List<ATTGeneralTippaniDetail> GetTrainingList()
    {
        return Session["TrainingListSession"] as List<ATTGeneralTippaniDetail>;
    }

    protected void btnAddTraining_Click(object sender, EventArgs e)
    {
        if (this.txtSubject_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया भ्रमणको बिषय राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlInstitution_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया भ्रमणको संस्था  छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtFromDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया भ्रमणको अवधि देखि राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtToDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया भ्रमणको अवधि सम्म  राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdTraining.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.TrainingList.Exists
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

        if (this.grdTraining.SelectedIndex < 0)
        {
            this.TrainingList.Add(this.GetTrainingDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.TrainingList[this.grdTraining.SelectedIndex] = this.GetTrainingDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdTraining.DataSource = this.TrainingList;
        this.grdTraining.DataBind();

        this.txtSubject_Rqd.Text = "";
        this.ddlInstitution_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        //this.txtNote.Text = "";
        this.grdTraining.SelectedIndex = -1;
    }

    private ATTGeneralTippaniSummary GetTrainingDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary training = new ATTGeneralTippaniSummary();
        if (this.grdTraining.SelectedIndex < 0)
        {
            training.OrgID = orgID;
            training.TippaniID = tippaniID;
            training.TippaniSNO = 0;
            training.EmpID = empID;
            training.EmpName = this.EmpName;
            training.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.TrainingList[this.grdTraining.SelectedIndex] as ATTGeneralTippaniSummary;
            training.OrgID = detail.OrgID;
            training.TippaniID = detail.TippaniID;
            training.TippaniSNO = detail.TippaniSNO;
            training.EmpID = detail.EmpID;
            training.EmpName = detail.EmpName;

            if (this.TrainingList[this.grdTraining.SelectedIndex].Action == "A")
            {
                training.Action = "A";
            }
            else
            {
                training.Action = "E";
            }
        }

        training.TrnSubject = this.txtSubject_Rqd.Text;
        training.TrnInstitutionID = int.Parse(this.ddlInstitution_Rqd.SelectedValue);
        training.TrnInstitutionName = this.ddlInstitution_Rqd.SelectedItem.Text;
        training.TrnFromDate = this.txtFromDate_Rdt.Text;
        training.TrnToDate = this.txtToDate_Rdt.Text;
        training.TrnRemark = this.txtRemark.Text;
        //training.Action = "A";
        training.TrnEntryBy  = entryBy;

        return training;
    }

    public void Clear()
    {
        this.txtSubject_Rqd.Text = "";
        this.ddlInstitution_Rqd.SelectedIndex = 0;
        this.txtFromDate_Rdt.Text = "";
        this.txtToDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdTraining.SelectedIndex = -1;
        this.grdTraining.DataSource = "";
        this.grdTraining.DataBind();
        this.SetTrainingListSession();
    }

    protected void grdTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;

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

    protected void grdTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.TrainingList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdTraining;
        GridViewRow CurrentRow = this.grdTraining.Rows[e.RowIndex];

        int DelCmdIndex = 9;

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

    public void LoadTrainingDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetTrainingListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetTrainingTippaniDetail(orgID, tippaniID);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.TrainingList.Add(summary);
            }
            this.grdTraining.DataSource = this.TrainingList;
            this.grdTraining.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.TrainingList[this.grdTraining.SelectedIndex];

        this.txtSubject_Rqd.Text = detail.TrnSubject;
        this.ddlInstitution_Rqd.SelectedValue = detail.TrnInstitutionID.ToString();
        this.txtFromDate_Rdt.Text = detail.TrnFromDate;
        this.txtToDate_Rdt.Text = detail.TrnToDate;
        this.txtRemark.Text = detail.TrnRemark;
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
