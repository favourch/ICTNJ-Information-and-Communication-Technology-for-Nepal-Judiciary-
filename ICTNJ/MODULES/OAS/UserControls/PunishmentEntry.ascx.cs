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

public partial class MODULES_OAS_UserControls_PunishmentEntry : System.Web.UI.UserControl
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

    public List<ATTGeneralTippaniDetail> PunishmentList
    {
        get { return Session["PunishmentListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
    }

    public GridView PunishmentGrid
    {
        get { return this.grdPunishment; }
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
                this.SetPunishmentListSession();
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

    void SetPunishmentListSession()
    {
        Session["PunishmentListSession"] = new List<ATTGeneralTippaniDetail>();
    }

    public List<ATTGeneralTippaniDetail> GetPunishmentList()
    {
        return Session["PunishmentListSession"] as List<ATTGeneralTippaniDetail>;
    }

    protected void btnAddPunishment_Click(object sender, EventArgs e)
    {
        if (this.txtPunishmentDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया सजायको मिति राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPunishmentDate_Rdt.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया सजायको बिबरण राख्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdPunishment.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.PunishmentList.Exists
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

        if (this.grdPunishment.SelectedIndex < 0)
        {
            this.PunishmentList.Add(this.GetPunishmentDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.PunishmentList[this.grdPunishment.SelectedIndex] = this.GetPunishmentDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdPunishment.DataSource = this.PunishmentList;
        this.grdPunishment.DataBind();

        this.txtPunishment_Rqd.Text = "";
        this.txtPunishmentDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        this.grdPunishment.SelectedIndex = -1;
    }

    private ATTGeneralTippaniSummary GetPunishmentDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        ATTGeneralTippaniSummary punishment = new ATTGeneralTippaniSummary();

        if (this.grdPunishment.SelectedIndex < 0)
        {
            punishment.OrgID = orgID;
            punishment.TippaniID = tippaniID;
            punishment.TippaniSNO = 0;
            punishment.EmpID = empID;
            punishment.EmpName = this.EmpName;
            punishment.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.PunishmentList[this.grdPunishment.SelectedIndex] as ATTGeneralTippaniSummary;
            punishment.OrgID = detail.OrgID;
            punishment.TippaniID = detail.TippaniID;
            punishment.TippaniSNO = detail.TippaniSNO;
            punishment.EmpID = detail.EmpID;
            punishment.EmpName = detail.EmpName;

            if (this.PunishmentList[this.grdPunishment.SelectedIndex].Action == "A")
            {
                punishment.Action = "A";
            }
            else
            {
                punishment.Action = "E";
            }
        }

        punishment.Punishment = this.txtPunishment_Rqd.Text;
        punishment.PunishmentDate = this.txtPunishmentDate_Rdt.Text;
        punishment.PunishmentRemark = this.txtRemark.Text;
        //punishment.Action = "A";
        punishment.PunEntryBy = entryBy;

        return punishment;
    }

    public string GetPunishmentNote()
    {
        return this.txtNote.Text;
    }

    public void Clear()
    {
        this.txtPunishment_Rqd.Text = "";
        this.txtPunishmentDate_Rdt.Text = "";
        this.txtRemark.Text = "";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdPunishment.SelectedIndex = -1;
        this.grdPunishment.DataSource = "";
        this.grdPunishment.DataBind();
        this.SetPunishmentListSession();
    }

    protected void grdPunishment_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ((LinkButton)e.Row.Cells[5].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[5].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void grdPunishment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.PunishmentList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdPunishment;
        GridViewRow CurrentRow = this.grdPunishment.Rows[e.RowIndex];

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

    public void LoadPunishmentDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetPunishmentListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetPunishmentTippaniDetail(orgID, tippaniID);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.PunishmentList.Add(summary);
            }
            this.grdPunishment.DataSource = this.PunishmentList;
            this.grdPunishment.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdPunishment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniDetail detail = this.PunishmentList[this.grdPunishment.SelectedIndex];

        this.txtPunishmentDate_Rdt.Text = detail.PunishmentDate;
        this.txtPunishment_Rqd.Text = detail.Punishment;
        this.txtRemark.Text = detail.PunishmentRemark;
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
