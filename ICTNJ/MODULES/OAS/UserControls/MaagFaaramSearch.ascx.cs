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
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_OAS_UserControls_MaagFaaramSearch : System.Web.UI.UserControl
{
    /* Check AppYesNo Condition from The Database*/
    /* true=check and false=don't check*/
    private bool _SelectApproval;
    public bool SelectApproval
    {
        get { return this._SelectApproval; }
        set { this._SelectApproval = value; }
    }

    /* Check Issue Flag Condition from The Database*/
    /* true=check and false=don't check*/
    private bool _SelectIssue;
    public bool SelectIssue
    {
        get { return this._SelectIssue; }
        set { this._SelectIssue = value; }
    }

    private bool _DisplayAppYesNo;
    public bool DisplayAppYesNo
    {
        get { return this._DisplayAppYesNo; }
        set { this._DisplayAppYesNo = value; }
    }

    private bool _DisplayAppPerson;
    public bool DisplayAppPerson
    {
        get { return this._DisplayAppPerson; }
        set { this._DisplayAppPerson = value; }
    }

    private bool _DisplayAppDate;
    public bool DisplayAppDate
    {
        get { return this._DisplayAppDate; }
        set { this._DisplayAppDate = value; }
    }

    private bool _DisplayIssueFlag;
    public bool DisplayIssueFlag
    {
        get { return this._DisplayIssueFlag; }
        set { this._DisplayIssueFlag = value; }
    }

    private string _AppYesNo;
    public string AppYesNo
    {
        get { return this._AppYesNo; }
        set { this._AppYesNo = value; }
    }

    private string _IssueFlag;
    public string IssueFlag
    {
        get { return this._IssueFlag; }
        set { this._IssueFlag = value; }
    }

    private bool _Edit;
    public bool Edit
    {
        get { return this._Edit; }
        set { this._Edit = value; }
    }

    private bool _Approve;
    public bool Approve
    {
        get { return this._Approve; }
        set { this._Approve = value; }
    }

    private bool _Issue;
    public bool Issue
    {
        get { return this._Issue; }
        set { this._Issue = value; }
    }


    int SelectGrid;
    int CancelClick;
    int SearchClick;
    protected void Page_Load(object sender, EventArgs e)
    {
                    if (!this.IsPostBack)
                    {
                        pnlMaagHeadSearch.Height = Unit.Pixel(30);
                        LoadOrganizationUnits();
                    }
    }

    void LoadOrganizationUnits()
    {
        try
        {
            this.ddlOrgUnits.Items.Add("छान्नुहोस");
            List<ATTOrganizationUnit> lstOrgUnits = BLLOrganizationUnit.GetOrganizationUnits(((ATTUserLogin)Session["Login_User_Detail"]).OrgID, null);
            this.ddlOrgUnits.DataSource = lstOrgUnits;
            this.ddlOrgUnits.DataTextField = "UNITNAME";
            this.ddlOrgUnits.DataValueField = "UNITID";
            this.ddlOrgUnits.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnMaagHeadSearch_Click(object sender, EventArgs e)
    {
        if (this.ddlOrgUnits.SelectedIndex < 1)
        {
            this.lblStatusMessage.Text = "कृपया शाखा छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTMaagFaaramHead> lstMaagHead = BLLMaagFaaramHead.GetMaagFaaramHead(GetFilter());
        this.grdMaagHead.DataSource = lstMaagHead;
        this.grdMaagHead.DataBind();
        this.grdMaagHead.SelectedIndex = -1;
        if (lstMaagHead.Count > 0)
        {
            pnlMaagHeadSearch.Height = Unit.Pixel(150);
        }
        else pnlMaagHeadSearch.Height = Unit.Pixel(30);
        BubbleClickBtn(this,e);
    }

    ATTMaagFaaramHead GetFilter()
    {
        ATTMaagFaaramHead objMaagHead = new ATTMaagFaaramHead();
        objMaagHead.OrgID=((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        objMaagHead.UnitID = int.Parse(this.ddlOrgUnits.SelectedValue);
        objMaagHead.ReqDate = this.txtReqDate.Text.Trim();
        objMaagHead.AppYesNo = AppYesNo;
        objMaagHead.IssueFlag = IssueFlag;
        objMaagHead.SelectApproval = SelectApproval;
        objMaagHead.SelectIssue = SelectIssue;
        return objMaagHead;
    }

    protected void grdMaagHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[9].Visible = DisplayAppPerson;
        e.Row.Cells[10].Visible = DisplayAppDate;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = DisplayAppYesNo;
        e.Row.Cells[13].Visible = false;
        e.Row.Cells[14].Visible = DisplayIssueFlag;
        e.Row.Cells[15].Visible = false;
        e.Row.Cells[16].Visible = Edit;
        e.Row.Cells[17].Visible = Approve;
        e.Row.Cells[18].Visible = Issue;
        e.Row.Cells[19].Visible = false;
        e.Row.Cells[20].Visible = false;
    }

    protected void grdMaagHead_SelectedIndexChanged(object sender, EventArgs e)
    {
            OnBubbleClick(e);
    }

    protected void btnMaagHeadCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        pnlMaagHeadSearch.Height = Unit.Pixel(30);
        BubbleClickBtnCancel(this,e);
    }

    void ClearControls()
    {
        this.ddlOrgUnits.SelectedIndex = 0;
        this.txtReqDate.Text = "";
        this.grdMaagHead.DataSource = "";
        this.grdMaagHead.DataBind();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();

    }


    #region for UserControl

    public event EventHandler BubbleClick;
    public event EventHandler BubbleClickBtn;
    public event EventHandler BubbleClickBtnCancel;

    protected void OnBubbleClick(EventArgs e)
    {
        if (BubbleClick != null)
        {
            BubbleClick(this, e);
        }
    }
    protected void OnBubbleClickBtn(EventArgs e)
    {
        if (BubbleClickBtn != null)
        {
            BubbleClickBtn(this, e);
        }
    }
    protected void OnBubbleClickBtnCancel(EventArgs e)
    {
        if (BubbleClickBtnCancel != null)
        {
            BubbleClickBtnCancel(this, e);
        }
    }
    #region Web Form Designer generated code
    //override protected void OnInit(EventArgs e)
    //{
    //    InitializeComponent();
    //    base.OnInit(e);
    //}

    //private void InitializeComponent()
    //{
    //    this.grdMaagHead.SelectedIndexChanged += new System.EventHandler(this.grdMaagHead_SelectedIndexChanged);
    //    this.btnMaagHeadSearch.Click += new System.EventHandler(this.btnMaagHeadSearch_Click);
    //    this.btnMaagHeadCancel.Click += new System.EventHandler(this.btnMaagHeadCancel_Click);
    //    this.Load += new System.EventHandler(this.Page_Load);

    //}
    #endregion

    #endregion

}
