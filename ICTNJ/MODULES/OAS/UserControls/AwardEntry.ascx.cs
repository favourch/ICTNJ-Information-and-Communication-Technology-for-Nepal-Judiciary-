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

public partial class MODULES_OAS_UserControls_AwardEntry : System.Web.UI.UserControl
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

    public List<ATTGeneralTippaniDetail> AwardList
    {
        get { return Session["AwardListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
    }

    public GridView AwardGrid
    {
        get { return this.grdAward; }
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
            if (this.ActionMode == "A")
            {
                this.SetAwardListSession();
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

    void SetAwardListSession()
    {
        Session["AwardListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    public List<ATTGeneralTippaniDetail> GetAwardList()
    {
        return Session["AwardListSession"] as List<ATTGeneralTippaniDetail>;
    }

    protected void btnAddAward_Click(object sender, EventArgs e)
    {
        if (this.txtAwardDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया बिभुषणको मिति राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtAwardDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया बिभुषणको बिबरण राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdAward.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.AwardList.Exists
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

        if (this.grdAward.SelectedIndex < 0)
        {
            this.AwardList.Add(this.GetAwardDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.AwardList[this.grdAward.SelectedIndex] = this.GetAwardDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdAward.DataSource = this.AwardList;
        this.grdAward.DataBind();

        this.txtAward_Rqd.Text = "";
        this.txtAwardDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        this.grdAward.SelectedIndex = -1;
    }

    private ATTGeneralTippaniSummary GetAwardDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary award = new ATTGeneralTippaniSummary();

        if (this.grdAward.SelectedIndex < 0)
        {
            award.OrgID = orgID;
            award.TippaniID = tippaniID;
            award.TippaniSNO = 0;
            award.EmpID = empID;
            award.EmpName = this.EmpName;
            award.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.AwardList[this.grdAward.SelectedIndex] as ATTGeneralTippaniSummary;
            award.OrgID = detail.OrgID;
            award.TippaniID = detail.TippaniID;
            award.TippaniSNO = detail.TippaniSNO;
            award.EmpID = detail.EmpID;
            award.EmpName = detail.EmpName;

            if (this.AwardList[this.grdAward.SelectedIndex].Action == "A")
            {
                award.Action = "A";
            }
            else
            {
                award.Action = "E";
            }
        }

        award.Award = this.txtAward_Rqd.Text;
        award.AwardDate = this.txtAwardDate_Rdt.Text;
        award.AwardRemark = this.txtRemark.Text;
        //award.Action = "A";
        award.AwdEntryBy = entryBy;

        return award;
    }

    public void Clear()
    {
        this.txtAward_Rqd.Text = "";
        this.txtAwardDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdAward.SelectedIndex = -1;
        this.grdAward.DataSource = "";
        this.grdAward.DataBind();
        this.SetAwardListSession();
    }

    protected void grdAward_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniSummary summary = e.Row.DataItem as ATTGeneralTippaniSummary;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(summary.Action);
            e.Row.ForeColor = c;

            if (summary.Action == "D")
            {
                ((LinkButton)e.Row.Cells[5].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[5].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void grdAward_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.AwardList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdAward;
        GridViewRow CurrentRow = this.grdAward.Rows[e.RowIndex];

        int DelCmdIndex = 5;

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

    public void LoadAwardDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetAwardListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetAwardTippaniDetail(orgID, tippaniID);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.AwardList.Add(summary);
            }
            this.grdAward.DataSource = this.AwardList;
            this.grdAward.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdAward_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.AwardList[this.grdAward.SelectedIndex];

        this.txtAwardDate_Rdt.Text = detail.AwardDate;
        this.txtAward_Rqd.Text = detail.Award;
        this.txtRemark.Text = detail.AwardRemark;
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
