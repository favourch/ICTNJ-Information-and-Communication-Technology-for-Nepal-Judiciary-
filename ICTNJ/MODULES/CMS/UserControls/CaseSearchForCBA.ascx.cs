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


using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;


    //public enum Verified1
    //{
    //    O, // For Whole Data
    //    Y,//For Verified Data
    //    N,//For Rejected Data
    //    U //For UnVerified Data
    //}
    //public enum Decision1
    //{
    //    O, // For Whole Data
    //    Y,//For Decided Data
    //    N,//For Negative Decision Data
    //    U //For UnDecided Data
    //}

public partial class MODULES_CMS_UserControls_CaseSearchForCBA : System.Web.UI.UserControl
{
    //private Verified1 _VerifiedYesNo;
    //public Verified1 VerifiedYesNo
    //{
    //    get { return this._VerifiedYesNo; }
    //    set { this._VerifiedYesNo = value; }
    //}

    //private Decision1 _DecisionYesNo;
    //public Decision1 DecisionYesNo
    //{
    //    get { return this._DecisionYesNo; }
    //    set { this._DecisionYesNo = value; }
    //}

    private int _CaseCount;
    private int CaseCount
    {
        get { return _CaseCount; }
        set { _CaseCount = value; }
    }


    int i;
    int i1;
    int i2;
    int orgID = 9;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            i = 0;
            i1 = 0;
            i2 = 0;
            //LoadCaseType();
        }
    }

    //private void LoadCaseType()
    //{
    //    List<ATTCaseType> caseTypeLST = BLLCaseType.GetCaseType(null, "Y", 1);

    //    ddlCaseType.DataSource = caseTypeLST;
    //    ddlCaseType.DataBind();
    //}
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.txtCauseListDate.Text == "____/__/__") || (this.txtCauseListDate.Text.Trim() == "") )
        {
            this.lblStatusMessage.Text = "Please Enter Cause List Date .";
            this.programmaticModalPopup.Show();
            return;
        }


        try
        {
            ATTCaseSearchForCBA obj = new ATTCaseSearchForCBA();
            obj.CourtID = orgID;
            obj.ClDate = txtCauseListDate.Text;
            //if (ddlCaseType.SelectedIndex > 0) obj.CaseTypeID = int.Parse(ddlCaseType.SelectedValue);
            //if (txtRegNo.Text.Trim() != "" && txtRegNo.Text.Trim() != "__-___-_____") obj.RegNo = txtRegNo.Text;
            //if (txtCaseNo.Text.Trim() != "" && txtCaseNo.Text.Trim() != "___-__-____") obj.CaseNo = txtCaseNo.Text;
            //if (txtCauseListDate.Text.Trim() != "" && txtCauseListDate.Text.Trim() != "____/__/__") obj.RegDate = txtCauseListDate.Text;
            //if (txtAppelantName.Text.Trim() != "") obj.Appelant = txtAppelantName.Text;
            //if (txtRespondantName.Text.Trim() != "") obj.Respondant = txtRespondantName.Text;


            //if (VerifiedYesNo.ToString() == "Y") obj.Verified = "Y";
            //else if (VerifiedYesNo.ToString() == "N") obj.Verified = "N";
            //else if (VerifiedYesNo.ToString() == "U") obj.Verified = "U";
            //else obj.Verified = null;


            //if (DecisionYesNo.ToString() == "Y") obj.DecisionYesNo = "Y";
            //else if (DecisionYesNo.ToString() == "N") obj.DecisionYesNo = "N";
            //else if (DecisionYesNo.ToString() == "U") obj.DecisionYesNo = "U";
            //else obj.DecisionYesNo = null;
            

            List<ATTCaseSearchForCBA> lst = BLLCaseSeachForCBA.GetCaseSearch(obj);
            grdCase.DataSource = lst;
            CaseCount = lst.Count;

            grdCase.DataBind();
            grdCase.SelectedIndex = -1;

            if (lst.Count > 0)
            {
                pnlCase.Height = Unit.Pixel(150);
            }
            else pnlCase.Height = Unit.Pixel(30);

            if (i1 == 0)//to prevent the event below from executing more than 1 time
            {
                i1++;
                OnBubbleClickBtn(e);
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancelSearch_Click(object sender, EventArgs e)
    {


        clearControls();
        pnlCase.Height = Unit.Pixel(30);
        if (i2 == 0)//to prevent the event below from executing more than 1 time
        {
            i2++;
            OnBubbleClickBtnCancel(e);
        }
        this.lblStatusMessage.Text = "Operation Cancelled";
        this.programmaticModalPopup.Show();
    }

    private void clearControls()
    {
        //ddlCaseType.SelectedIndex = -1;
        //txtCaseNo.Text = "";
        //txtRegNo.Text = "";
        //txtCauseListDate.Text = "";
        //txtAppelantName.Text = "";
        txtCauseListDate.Text = "";
        grdCase.DataSource = null;
        grdCase.DataBind();
    }
    protected void grdCase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (CaseCount > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

    }
    //protected void grdCase_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //this.Page.FindControl("grdLitigantsApp").Visible = false;
    //    if (i == 0)//to prevent the event below from executing more than 1 time
    //    {
    //        i++;
    //        OnBubbleClick(e);
    //    }
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "EndRequestHandler", "javascript:EndRequestHandler();", true);

    //}

    #region for UserControl

    //public event EventHandler BubbleClick;
    public event EventHandler BubbleClickBtn;
    public event EventHandler BubbleClickBtnCancel;



    //protected void OnBubbleClick(EventArgs e)
    //{
    //    if (BubbleClick != null)
    //    {
    //        BubbleClick(this, e);
    //    }
    //}
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
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        //this.grdCase.SelectedIndexChanged += new System.EventHandler(this.grdCase_SelectedIndexChanged);
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    #endregion

    
}

