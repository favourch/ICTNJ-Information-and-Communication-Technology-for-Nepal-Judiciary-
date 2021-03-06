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
using PCS.SECURITY.ATT;
using PCS.CMS.ATT;
using PCS.CMS.BLL;

public partial class MODULES_CMS_Forms_Pratiuttar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //    Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
    //    Response.Expires = -1500;
    //    Response.CacheControl = "no-cache";

    //    //block if without login
    //    if (Session["Login_User_Detail"] == null)
    //        Response.Redirect("~/MODULES/Login.aspx", true);

    //    //block if from URL
    //    ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
    //    if (user.MenuList.ContainsKey("1,22,1") == true)
    //    {
    //        Session["OrgID"] = user.OrgID;
            if (this.IsPostBack == false)
            {
                ClearControls();
            }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void ClearControls()
    {
        this.colCaseSearch.Collapsed = false;
        this.colCaseSearch.ClientState = "false";
        this.colRespondent.Collapsed = true;
        this.colRespondent.ClientState = "true";
        this.colEvidence.Collapsed = true;
        this.colEvidence.ClientState = "true";

        List<ATTPratiuttarEvidence> praEvidenceList = new List<ATTPratiuttarEvidence>();
        Session["PratiuttarEvidence"] = praEvidenceList;
        this.grdPraEvidence.DataSource = praEvidenceList;
        this.grdPraEvidence.DataBind();

        List<ATTPratiuttarDocuments> praDocumentList = new List<ATTPratiuttarDocuments>();
        Session["PratiuttarDocument"] = praDocumentList;
        this.grdPraDocument.DataSource = praDocumentList;
        this.grdPraDocument.DataBind();

        this.txtPraEvidence.Text = "";
        this.txtPraDate_DT.Text = "";
        this.txtPraSummary.Text = "";
        this.grdLitigantRes.DataSource = "";
        this.grdLitigantRes.DataBind();
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void CaseSearchControl_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        this.grdLitigantRes.DataSource = null;
        DataBind();
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        CaseSearchControl.BubbleClick += new EventHandler(CaseSearchControl_BubbleClick);
        CaseSearchControl.BubbleClickBtn += new EventHandler(CaseSearchControl_BubbleClickBtn);
        CaseSearchControl.BubbleClickBtnCancel += new EventHandler(CaseSearchControl_BubbleClickBtnCancel);

    }


    private void CaseSearchControl_BubbleClick(object sender, EventArgs e)
    {
        int? caseID = int.Parse(((GridView)CaseSearchControl.FindControl("grdCase")).SelectedRow.Cells[2].Text);
        LoadRespondents(caseID);
        Session["CaseID"] = caseID;
        //this.CollapsiblePanelExtender1.ClientState = "false";
        //this.CollapsiblePanelExtender1.Collapsed = false;


    }

    private void CaseSearchControl_BubbleClickBtn(object sender, EventArgs e)
    {
        //if (((GridView)CaseSearchControl.FindControl("grdCase")).Rows.Count < 1)
        //{
        //    grdLitigantsApp.DataSource = null;
        //    grdLitigantRes.DataSource = null;
        //    grdLitigantsApp.DataBind();
        //    grdLitigantRes.DataBind();
        //}



        //this.CollapsiblePanelExtender1.Collapsed = true;
        //this.CollapsiblePanelExtender1.ClientState = "true";

    }

    void LoadRespondents(int? caseID)
    {
        ATTLitigantSearch obj = new ATTLitigantSearch();
        obj.CaseID = caseID;
        obj.LitigantType = "R";
        try
        {
            List<ATTLitigantSearch> LitigantSearch = BLLLitigantSearch.GetLitigantSearch(obj);
            this.grdLitigantRes.DataSource = LitigantSearch;
            this.grdLitigantRes.DataBind();
            if (LitigantSearch.Count > 0)
            {
                this.colCaseSearch.Collapsed = true;
                this.colCaseSearch.ClientState = "true";
                this.colRespondent.Collapsed = false;
                this.colRespondent.ClientState = "false";
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdLitigantRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[9].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[13].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "";
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chkRes")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkRes")).Attributes.Add("onclick", str);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chkRes")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkRes")).Attributes.Add("onclick", str);
        }
    }

    protected void btnAddEvidence_Click(object sender, EventArgs e)
    {
        if (this.txtPraEvidence.Text == "") return;
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        int intPraEvidence;
        List<ATTPratiuttarEvidence> lst = (List<ATTPratiuttarEvidence>)Session["PratiuttarEvidence"];
        intPraEvidence = this.grdPraEvidence.SelectedIndex > -1 ? lst[this.grdPraEvidence.SelectedIndex].EvidenceID : 0;
        ATTPratiuttarEvidence praEvidence = new ATTPratiuttarEvidence(double.Parse(Session["CaseID"].ToString()),0, intPraEvidence, this.txtPraEvidence.Text.Trim());
        praEvidence.Action = this.grdPraEvidence.SelectedIndex > -1 ? (lst[this.grdPraEvidence.SelectedIndex].Action == "A" ? "A" : "E") : "A";
        praEvidence.EntryBy = user.UserName;
        if (this.grdPraEvidence.SelectedIndex > -1) lst[this.grdPraEvidence.SelectedIndex].Evidence = praEvidence.Evidence;
        else lst.Add(praEvidence);
        this.grdPraEvidence.DataSource = lst;
        this.grdPraEvidence.DataBind();
        this.txtPraEvidence.Text = "";
        this.grdPraEvidence.SelectedIndex = -1;
        SetGridColor(4, 6, grdPraEvidence);
    }

    protected void grdPraEvidence_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtPraEvidence.Text = "";
        List<ATTPratiuttarEvidence> lst = (List<ATTPratiuttarEvidence>)Session["PratiuttarEvidence"];
        if (lst[this.grdPraEvidence.SelectedIndex].Action != "D")
            this.txtPraEvidence.Text = lst[this.grdPraEvidence.SelectedIndex].Evidence;
        else
            this.grdPraEvidence.SelectedIndex = -1;
    }

    protected void grdPraEvidence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[4].Visible = false;
    }

    protected void grdPraEvidence_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            List<ATTPratiuttarEvidence> lst = (List<ATTPratiuttarEvidence>)Session["PratiuttarEvidence"];

            if (lst[i].Action == "") lst[i].Action = "D";
            else if (lst[i].Action == "D") lst[i].Action = "E";
            else if (lst[i].Action == "A") lst.RemoveAt(i);

            this.grdPraEvidence.DataSource = lst;
            this.grdPraEvidence.DataBind();
            this.grdPraEvidence.SelectedIndex = -1;
            SetGridColor(4, 6, grdPraEvidence);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnDocPlus_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (!fileUp.HasFile) return;
        int intdocID;
        List<ATTPratiuttarDocuments> lstPraDocuments = (List<ATTPratiuttarDocuments>)Session["PratiuttarDocument"];

        intdocID = this.grdPraDocument.SelectedIndex > -1 ? lstPraDocuments[this.grdPraDocument.SelectedIndex].DocumentID : 0;
        ATTPratiuttarDocuments praDocument = new ATTPratiuttarDocuments(double.Parse(Session["CaseID"].ToString()),0, intdocID, fileUp.FileName, fileUp.FileBytes);
        praDocument.Action = this.grdPraDocument.SelectedIndex > -1 ? (lstPraDocuments[this.grdPraDocument.SelectedIndex].Action == "A" ? "A" : "E") : "A";
        praDocument.EntryBy = user.UserName;

        if (this.grdPraDocument.SelectedIndex > -1)
        {
            lstPraDocuments[this.grdPraDocument.SelectedIndex].DocumentFileName = praDocument.DocumentFileName;
            lstPraDocuments[this.grdPraDocument.SelectedIndex].DocumentContent = praDocument.DocumentContent;
        }
        else
            lstPraDocuments.Add(praDocument);
        this.grdPraDocument.DataSource = lstPraDocuments;
        this.grdPraDocument.DataBind();
        this.grdPraDocument.SelectedIndex = -1;
        SetGridColor(4,5, this.grdPraDocument);
    }

    protected void grdPraDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        List<ATTPratiuttarDocuments> lst = (List<ATTPratiuttarDocuments>)Session["PratiuttarDocument"];
        if (lst[i].Action == "") lst[i].Action = "D";
        else if (lst[i].Action == "D") lst[i].Action = "E";
        else if (lst[i].Action == "A") lst.RemoveAt(i);

        this.grdPraDocument.DataSource = lst;
        this.grdPraDocument.DataBind();
        this.grdPraDocument.SelectedIndex = -1;
        SetGridColor(4, 5, this.grdPraDocument);
    }

    protected void grdPraDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[5].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
            ((LinkButton)e.Row.FindControl("lnkDocumentName")).CommandName = e.Row.RowIndex.ToString();
    }

    protected void lnkDocumentName_Click(object sender, EventArgs e)
    {
        string mimeType = "application/octet-stream";
        int i = int.Parse(((LinkButton)sender).CommandName);
        List<ATTPratiuttarDocuments> praDocList = (List<ATTPratiuttarDocuments>)Session["PratiuttarDocument"];

        byte[] bytes = praDocList[i].DocumentContent;
        string ext = System.IO.Path.GetExtension(((LinkButton)sender).Text);
        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (regKey != null && regKey.GetValue("Content Type") != null)
            mimeType = regKey.GetValue("Content Type").ToString();

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + ((LinkButton)sender).Text);
        Response.AddHeader("Content-Length", bytes.Length.ToString());
        Response.ContentType = mimeType;
        Response.BinaryWrite(bytes);
        Response.End();

        GC.Collect();
        GC.SuppressFinalize(bytes);
        bytes = null;
    }

    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }

    void SetGridColor(int col, int delCol, GridView grd)
    {
        for (int j = 0; j < grd.Rows.Count; j++)
        {

            if (grd.Rows[j].Cells[col].Text == "D")
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Undo";
                grd.Rows[j].ForeColor = System.Drawing.Color.Red;
            }

            else
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Delete";
                grd.Rows[j].ForeColor = System.Drawing.Color.FromName("#1D2A5B");

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        ATTPratiuttar objPratiuttar = new ATTPratiuttar();
        objPratiuttar.CaseID = double.Parse(Session["CaseID"].ToString());
        objPratiuttar.PratiuttarID = 0;
        objPratiuttar.PratiuttarDate = this.txtPraDate_DT.Text.Trim();
        objPratiuttar.AccountForward = "N";
        objPratiuttar.SubmittedBy = null;
        objPratiuttar.PratiuttarSummary = this.txtPraSummary.Text.Trim();
        objPratiuttar.EntryBy = user.UserName;

        foreach (GridViewRow row in this.grdLitigantRes.Rows)
        {
            CheckBox cb = (CheckBox)(row.FindControl("chkRes"));
            if (cb.Checked)
            {
                ATTPratiuttarLitigants objPratiLitigants = new ATTPratiuttarLitigants
                    (
                    double.Parse(Session["CaseID"].ToString()),
                    objPratiuttar.PratiuttarID,
                    double.Parse(row.Cells[2].Text)
                    );
                objPratiLitigants.Action = "A";
                objPratiLitigants.EntryBy = user.UserName;
                objPratiuttar.LstPratiuttarLitigants.Add(objPratiLitigants);
            }
        }
        if (objPratiuttar.LstPratiuttarLitigants.Count == 0)
        {
            this.lblStatusMessage.Text = "Please Select Respondent(s).";
            this.programmaticModalPopup.Show();
            return;
        }

        objPratiuttar.LstPratiuttarEvidence = (List<ATTPratiuttarEvidence>)Session["PratiuttarEvidence"];
        objPratiuttar.LstPratiuttarDocuments = (List<ATTPratiuttarDocuments>)Session["PratiuttarDocument"];
        try
        {
            BLLPratiuttar.SavePratiuttar(objPratiuttar);
            this.lblStatusMessage.Text = "Pratiuttar Successfully Saved.";
            this.programmaticModalPopup.Show();
            ClearControls();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdPraDocument_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}