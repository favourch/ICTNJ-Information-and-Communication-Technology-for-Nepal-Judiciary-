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

public partial class MODULES_CMS_Forms_SearchCaseRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("1,22,1") == true)
        {
            Session["OrgID"] = user.OrgID;
            if (this.IsPostBack == false)
            {
                ClearControls();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void ClearControls()
    {
        this.colCaseSearch.Collapsed = false;
        this.colCaseSearch.ClientState = "false";
        
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void CaseSearchControl_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        //this.grdLitigantRes.DataSource = null;
        //DataBind();
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
        Session["CaseNo"] = caseID;
        Response.Redirect("CaseRegistrationInfo.aspx");
        //LoadRespondents(caseID);
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
    

    

    

   
    protected void grdPraEvidence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }

    
    

    protected void grdPraDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[3].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
            ((LinkButton)e.Row.FindControl("lnkPratiuttarDocuments")).CommandName = e.Row.RowIndex.ToString();
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

    protected void grdPraDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdPraDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[5].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
            ((LinkButton)e.Row.FindControl("lnkDocumentName")).CommandName = e.Row.RowIndex.ToString();
    }

    

    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }



    protected void lnkDocumentName_Click(object sender, EventArgs e)
    {

    }

    protected void grdLitDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
    protected void CaseSearchControl_Load(object sender, EventArgs e)
    {

    }
}
