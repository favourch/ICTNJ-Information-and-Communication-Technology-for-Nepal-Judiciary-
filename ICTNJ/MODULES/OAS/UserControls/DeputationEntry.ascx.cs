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

public partial class MODULES_OAS_UserControls_DeputationEntry : System.Web.UI.UserControl
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

    public List<ATTGeneralTippaniDetail> DeputationList
    {
        get { return Session["DeputationListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    public GridView DeputationGrid
    {
        get { return this.grdDeputation; }
    }

    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
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
            this.LoadOrganization();
            if (this.ActionMode == "A")
            {
                this.SetDeputationListSession();
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

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "छन्नुहोस्"));
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

    void SetDeputationListSession()
    {
        Session["DeputationListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    public List<ATTGeneralTippaniDetail> GetDeputationList()
    {
        return Session["DeputationListSession"] as List<ATTGeneralTippaniDetail>;
    }

    protected void btnAddDeputation_Click(object sender, EventArgs e)
    {
        if (this.txtSendDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया पठाउने मिति राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtDecisionDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया निर्णयको मिति  छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlOrg_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया काजमा पठउने कार्यालय संस्था  छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtLeaveDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया रवाना मिति राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtResponsibility_Rqd.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया जिम्मेवारी राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdDeputation.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.DeputationList.Exists
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

        if (this.grdDeputation.SelectedIndex < 0)
        {
            this.DeputationList.Add(this.GetDeputationDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.DeputationList[this.grdDeputation.SelectedIndex] = this.GetDeputationDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdDeputation.DataSource = this.DeputationList;
        this.grdDeputation.DataBind();

        this.txtSendDate_Rdt.Text = "";
        this.txtDecisionDate_Rdt.Text = "";
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.txtLeaveDate_Rdt.Text = "";
        this.txtResponsibility_Rqd.Text = "";
        //this.txtNote.Text = "";
        this.grdDeputation.SelectedIndex = -1;
    }

    private ATTGeneralTippaniSummary GetDeputationDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary deputation = new ATTGeneralTippaniSummary();

        if (this.grdDeputation.SelectedIndex < 0)
        {
            deputation.OrgID = orgID;
            deputation.TippaniID = tippaniID;
            deputation.TippaniSNO = 0;
            deputation.EmpID = empID;
            deputation.EmpName = this.EmpName;
            deputation.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.DeputationList[this.grdDeputation.SelectedIndex] as ATTGeneralTippaniSummary;
            deputation.OrgID = detail.OrgID;
            deputation.TippaniID = detail.TippaniID;
            deputation.TippaniSNO = detail.TippaniSNO;
            deputation.EmpID = detail.EmpID;
            deputation.EmpName = detail.EmpName;

            if (this.DeputationList[this.grdDeputation.SelectedIndex].Action == "A")
            {
                deputation.Action = "A";
            }
            else
            {
                deputation.Action = "E";
            }
        }

        deputation.DepOrgID = 0;
        deputation.DepDesID = 0;
        deputation.DepCreatedDate = "";
        deputation.DepPostID = 0;
        deputation.DepFromDate = this.txtSendDate_Rdt.Text;
        deputation.DepDecisionDate = this.txtDecisionDate_Rdt.Text;
        deputation.DepToOrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        deputation.DepToOrgName = this.ddlOrg_Rqd.SelectedItem.Text;
        deputation.DepLeaveDate = this.txtLeaveDate_Rdt.Text;
        deputation.DepResponsibility = this.txtResponsibility_Rqd.Text;
        //deputation.Action = "A";
        deputation.DepEntryBy = entryBy;

        return deputation;
    }

    public void Clear()
    {
        this.txtSendDate_Rdt.Text = "";
        this.txtDecisionDate_Rdt.Text = "";
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.txtLeaveDate_Rdt.Text = "";
        this.txtResponsibility_Rqd.Text = "";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdDeputation.SelectedIndex = -1;
        this.grdDeputation.DataSource = "";
        this.grdDeputation.DataBind();
        this.SetDeputationListSession();
    }

    protected void grdDeputation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[4].Visible = false;

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

    protected void grdDeputation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.DeputationList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdDeputation;
        GridViewRow CurrentRow = this.grdDeputation.Rows[e.RowIndex];

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

    public void LoadDeputationDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetDeputationListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetDeputationTippaniDetail(orgID, tippaniID);
            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.DeputationList.Add(summary);
            }
            this.grdDeputation.DataSource = this.DeputationList;
            this.grdDeputation.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdDeputation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.DeputationList[this.grdDeputation.SelectedIndex];

        this.txtSendDate_Rdt.Text = detail.DepFromDate;
        this.txtDecisionDate_Rdt.Text = detail.DepDecisionDate;
        this.ddlOrg_Rqd.SelectedValue = detail.DepToOrgID.ToString();
        this.txtLeaveDate_Rdt.Text = detail.DepLeaveDate;
        this.txtResponsibility_Rqd.Text = detail.DepResponsibility;
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
