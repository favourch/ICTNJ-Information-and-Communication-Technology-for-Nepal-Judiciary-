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

using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using System.Collections.Generic;
using System.Reflection;

using PCS.FRAMEWORK;


public partial class MODULES_CMS_Bench_CaseBenchAssignment : System.Web.UI.Page
{
    int orgID = 9;
    string entryBy = "Suman";
    int userID = 8;
    private int _CaseCount;
    private int CaseCount
    {
        get { return _CaseCount; }
        set { _CaseCount = value; }
    }
    public List<ATTBenchFormation> BenchFormation
    {
        get { return (Session["BenchFormation"] == null) ? new List<ATTBenchFormation>() : (List<ATTBenchFormation>)Session["BenchFormation"]; }
        set { Session["BenchFormation"] = value; }
    }

    public List<ATTCaseSearchForCBA> Cases
    {
        get { return (Session["Cases"] == null) ? new List<ATTCaseSearchForCBA>() : (List<ATTCaseSearchForCBA>)Session["Cases"]; }
        set { Session["Cases"] = value; }
    }
    public List<ATTCaseSearchForCBA> CasesNotAssigned
    {
        get { return (Session["CasesNotAssigned"] == null) ? new List<ATTCaseSearchForCBA>() : (List<ATTCaseSearchForCBA>)Session["CasesNotAssigned"]; }
        set { Session["CasesNotAssigned"] = value; }
    }
    public List<ATTCaseSearchForCBA> CasesSave
    {
        get { return (Session["CasesSave"] == null) ? new List<ATTCaseSearchForCBA>() : (List<ATTCaseSearchForCBA>)Session["CasesSave"]; }
        set { Session["CasesSave"] = value; }
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBench();
        }
    }

    private void LoadBench()
    {
        try
        {
            List<ATTBenchFormation> lst = BLLBenchFormation.GetBenchFormation(orgID,0);
            BenchFormation = lst;
            lstBench.DataTextField = "Name";
            lstBench.DataValueField = "CompositeKey";
            lstBench.DataSource = lst;
            lstBench.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "बेन्च लोड गर्न सकेन :" + ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    //#region for UserControl
    //override protected void OnInit(EventArgs e)
    //{
    //    InitializeComponent();
    //    base.OnInit(e);
    //}

    ////private void WebForm1_BubbleClick(object sender, EventArgs e)
    ////{
    //    //Response.Write("WebForm1 :: WebForm1_BubbleClick from " +
    //    //               sender.GetType().ToString() + "<BR>");

    //    //int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);

    //    //Session["CaseID"] = caseID;
    //    //LoadLitigants();
    //    //LoadAttorney();

    //    //this.CollapsiblePanelExtender1.ClientState = "false";
    //    //this.CollapsiblePanelExtender1.Collapsed = false;


    ////}
    //private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    //{
    //    //Response.Write("WebForm1 :: WebForm1_BubbleClick from " +
    //    //               sender.GetType().ToString() + "<BR>");

    //    //int rowCount = ((GridView)CaseSearch1.FindControl("grdCase")).Rows.Count;

    //    //if (rowCount < 1)
    //    //{
    //    //    AttorneyLIST = null;
    //    //    LitigantsAppelant = null;
    //    //    LitigantsRespondant = null;

    //    //    grdAttorney.DataSource = null;
    //    //    grdLitigantsApp.DataSource = null;
    //    //    grdLitigantRes.DataSource = null;
    //    //    DataBind();


    //    //    this.CollapsiblePanelExtender1.Collapsed = true;
    //    //    this.CollapsiblePanelExtender1.ClientState = "true";
    //    //}
    //}
    //private void WebForm1_BubbleClickBtnCancel(object sender, EventArgs e)
    //{

    //    //AttorneyLIST = null;
    //    //LitigantsAppelant = null;
    //    //LitigantsRespondant = null;

    //    //grdAttorney.DataSource = null;
    //    //grdLitigantsApp.DataSource = null;
    //    //grdLitigantRes.DataSource = null;
    //    //DataBind();


    //    //this.CollapsiblePanelExtender1.Collapsed = true;
    //    //this.CollapsiblePanelExtender1.ClientState = "true";

    //}

    //private void InitializeComponent()
    //{
    //    this.Load += new System.EventHandler(this.Page_Load);
    //    //CaseSearchForCBA1.BubbleClick += new EventHandler(WebForm1_BubbleClick);
    //    CaseSearchForCBA1.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);
    //    CaseSearchForCBA1.BubbleClickBtnCancel += new EventHandler(WebForm1_BubbleClickBtnCancel);
    //}

    //#endregion
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            foreach (GridViewRow gr in grdCase.Rows)
            {
                if (((CheckBox)gr.FindControl("chk")).Checked)
                {
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                lblStatusMessage.Text = "मुद्दा्/मुद्दाहरु छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }

            if (lstBench.SelectedIndex < 0)
            {
                lblStatusMessage.Text = "बेन्च छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            //if (ddlPriority.SelectedIndex < 1)
            if (txtPriority.Text.Trim() == "")
            {
                lblStatusMessage.Text = "प्राथमिकता छुट्यो";
                this.programmaticModalPopup.Show();
                return;
            }

            List<ATTBenchFormation> lstSession = BenchFormation;

            List<ATTCaseBenchAssignment> lstSAve = new List<ATTCaseBenchAssignment>();
            foreach (GridViewRow grow in grdCase.Rows)
            {
                if (((CheckBox)grow.FindControl("chk")).Checked)
                {
                    ATTCaseBenchAssignment obj = new ATTCaseBenchAssignment();
                    obj.OrgID = orgID;
                    obj.BenchTypeID = lstSession[lstBench.SelectedIndex].BenchTypeID;
                    obj.BenchNo = lstSession[lstBench.SelectedIndex].BenchNo;
                    obj.FromDate = lstSession[lstBench.SelectedIndex].FromDate;
                    obj.SeqNo = lstSession[lstBench.SelectedIndex].SeqNo;

                    obj.CaseID = int.Parse(grow.Cells[3].Text);
                    obj.AssignmentDate = grow.Cells[12].Text;



                    obj.Action = "A";
                    obj.EntryBy = entryBy;
                    //obj.Priority = int.Parse(ddlPriority.SelectedValue);
                    obj.Priority = int.Parse(txtPriority.Text);

                    lstSAve.Add(obj);
                }
            }

            if (BLLCaseBenchAssignment.AddEditDeleteCaseBenchAssignment(lstSAve))
            {
                lblStatusMessage.Text = "Data Saved Successfully";
                this.programmaticModalPopup.Show();
                ClearControls();
            }
            else
            {
                lblStatusMessage.Text = "Data Could not be Saved ";
                this.programmaticModalPopup.Show();

            }
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = "Data Could not be Saved :"+ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    private void ClearControls()
    {
        
        grdCase.DataSource = null;
        grdCase.DataBind();
        txtCauseListDate.Text = null;
        

        lstBench.SelectedIndex = -1;

        lstJudges.Items.Clear();
        lstJudges.DataSource = null;
        lstJudges.DataBind();
        lstJudges.SelectedIndex = -1;
        txtPriority.Text = "";
        //ddlPriority.SelectedIndex = -1;


        grdCaseBenchAssignment.DataSource = null;
        grdCaseBenchAssignment.DataBind();
        pnlCase.Height = Unit.Pixel(5);

        Cases = null;
        CasesNotAssigned = null;
        CasesSave = null;

    }
    protected void lstBench_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstJudges.DataSource = BenchFormation[lstBench.SelectedIndex].JudgeList;
        lstJudges.DataBind();

        CasesSave=Cases.FindAll(
                                    delegate(ATTCaseSearchForCBA obj)
                                    {
                                     return(obj.BenchTypeID==BenchFormation[lstBench.SelectedIndex].BenchTypeID &&
                                            obj.BenchNo==BenchFormation[lstBench.SelectedIndex].BenchNo );
                                    }
                                );
        grdCaseBenchAssignment.DataSource = CasesSave;
        grdCaseBenchAssignment.DataBind();
    }
    protected void btnAddCaseBenchAssignment_Click(object sender, EventArgs e)
    {
        //int count = 0;
        //foreach (GridViewRow gr in grdCase.Rows)
        //{
        //    if (((CheckBox)gr.FindControl("chk")).Checked)
        //    {
        //        count++;
        //        break;
        //    }
        //}
        //if (count==0)
        //{
        //    lblStatusMessage.Text = "मुद्दा्/मुद्दाहरु छान्नुहोस्";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //if (lstBench.SelectedIndex<0)
        //{
        //    lblStatusMessage.Text = "बेन्च छान्नुहोस्";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}
        //if (ddlPriority.SelectedIndex < 1)
        //{
        //    lblStatusMessage.Text = "प्राथमिकता छान्नुहोस्";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //List<ATTCaseSearchForCBA> lst = CasesSave;
        //List<ATTBenchFormation> lstSession = BenchFormation;

        //ATTCaseBenchAssignment obj = new ATTCaseBenchAssignment();

        //obj.OrgID = orgID;
        //obj.BenchTypeID = lstSession[lstBench.SelectedIndex].BenchTypeID;
        //obj.BenchNo = lstSession[lstBench.SelectedIndex].BenchNo;
        //obj.FromDate = lstSession[lstBench.SelectedIndex].FromDate;
        //obj.SeqNo = lstSession[lstBench.SelectedIndex].SeqNo;

        //obj.CaseID = int.Parse(grow.Cells[3].Text);
        //obj.AssignmentDate = grow.Cells[9].Text;



        //obj.Action = "A";
        //obj.EntryBy = entryBy;
        //obj.Priority = int.Parse(ddlPriority.SelectedValue);
        //lstSAve.Add(obj);


        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.txtCauseListDate.Text == "____/__/__") || (this.txtCauseListDate.Text.Trim() == ""))
        {
            this.lblStatusMessage.Text = "Please Enter Cause List Date .";
            this.programmaticModalPopup.Show();
            return;
        }
        
        try
        {
            ////reset sessions
            Cases = null;
            CasesNotAssigned = null;
            CasesSave = null;
            //////

            ATTCaseSearchForCBA obj = new ATTCaseSearchForCBA();
            obj.CourtID = orgID;
            obj.ClDate = txtCauseListDate.Text;           

            List<ATTCaseSearchForCBA> lst = BLLCaseSeachForCBA.GetCaseSearch(obj);
            Cases = lst;
            CasesNotAssigned = lst.FindAll(
                                                delegate(ATTCaseSearchForCBA ob)
                                                {
                                                    return(string.IsNullOrEmpty( ob.AssignmentDate));
                                                }
                                           );
            grdCase.DataSource = CasesNotAssigned;
            CaseCount = lst.Count;

            grdCase.DataBind();
            grdCase.SelectedIndex = -1;

            if (lst.Count > 0)
            {
                pnlCase.Height = Unit.Pixel(150);
            }
            else pnlCase.Height = Unit.Pixel(5);
            
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancelSearch_Click(object sender, EventArgs e)
    {
        ClearControls();       
        
        this.lblStatusMessage.Text = "Search Cancelled";
        this.programmaticModalPopup.Show();
    }
    protected void grdCase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (CaseCount > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }

    }
    protected void grdCaseBenchAssignment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
}
