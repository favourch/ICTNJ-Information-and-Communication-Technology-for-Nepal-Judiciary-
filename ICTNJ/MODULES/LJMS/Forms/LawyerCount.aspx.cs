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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;
using PCS.LJMS.ATT;
using PCS.LJMS.BLL;
using PCS.REPORT;

public partial class MODULES_LJMS_Forms_LawyerCount : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("2,39,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadLawyerType();
                this.LoadUnit();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadLawyerType()
    {
        try
        {
            List<ATTLawyerType> lst = BLLLawyerType.GetLawyerTypeList(null, true);
            this.ddlLawyerType.DataSource = lst;
            this.ddlLawyerType.DataTextField = "LawyerTypeDescription";
            this.ddlLawyerType.DataValueField = "LawyerTypeID";
            this.ddlLawyerType.DataBind();

            this.ddlPLawyerType.DataSource = lst;
            this.ddlPLawyerType.DataTextField = "LawyerTypeDescription";
            this.ddlPLawyerType.DataValueField = "LawyerTypeID";
            this.ddlPLawyerType.DataBind();
        }
        catch (Exception ex)
        {
            this.ShowMessage(ex, null);
        }
    }

    void LoadUnit()
    {
        try
        {
            List<ATTUnit> lst = BLLUnit.GetUnitList(null, true);

            this.ddlUnit.DataSource = lst;
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.ShowMessage(ex, null);
        }
    }

    void ShowMessage(Exception ex, string m)
    {
        string msg;
        if (ex == null)
            msg = m;
        else
            msg = ex.Message;

        this.lblStatusMessage.Text = msg;
        this.programmaticModalPopup.Show();
    }

    protected void btnSearchLawyer_Click(object sender, EventArgs e)
    {
        ATTLawyerCount lawyer = new ATTLawyerCount();
        lawyer.LawyerTypeID = int.Parse(this.ddlLawyerType.SelectedValue);
        lawyer.Type = LawyerType.NepalBarAssociation;

        try
        {
            this.grdCount.DataSource = BLLLawyerSearch.GetLawyerCount(lawyer);
            this.grdCount.DataBind();
            this.grdCount.Columns[0].Visible = false;
        }
        catch (Exception ex)
        {
            this.ShowMessage(ex, null);
        }
    }

    protected void grdCount_DataBound(object sender, EventArgs e)
    {
        if (this.grdCount.Rows.Count > 0)
        {
            this.lblCount.Text = "Total record: " + this.grdCount.Rows.Count.ToString();
            this.btnExport.Visible = true;
        }
        else
        {
            this.lblCount.Text = "No record found.";
            this.btnExport.Visible = false;
        }
    }

    string FilterString(string s)
    {
        if (s == "&nbsp;")
            return "";
        else
            return s;
    }

    string unit = "";
    string type = "";
    int firstRow = -1;

    string unitx = "";
    int secondRow = -1;
    protected void grdCount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (FilterString(e.Row.Cells[0].Text) != "")
            {
                if (unitx == FilterString(e.Row.Cells[0].Text))
                {
                    if (this.grdCount.Rows[secondRow].Cells[0].RowSpan == 0)
                        this.grdCount.Rows[secondRow].Cells[0].RowSpan = 2;
                    else
                        this.grdCount.Rows[secondRow].Cells[0].RowSpan += 1;
                    e.Row.Cells[0].Visible = false;
                }
                else
                {
                    e.Row.VerticalAlign = VerticalAlign.Middle;
                    unitx = FilterString(e.Row.Cells[0].Text);
                    secondRow = e.Row.RowIndex;
                }
            }

            if (unit == FilterString(e.Row.Cells[0].Text) && type == FilterString(e.Row.Cells[1].Text))
            {
                if (this.grdCount.Rows[firstRow].Cells[1].RowSpan == 0)
                    this.grdCount.Rows[firstRow].Cells[1].RowSpan = 2;
                else
                    this.grdCount.Rows[firstRow].Cells[1].RowSpan += 1;
                e.Row.Cells[1].Visible = false;
            }
            else
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;
                unit = FilterString(e.Row.Cells[0].Text);
                type = FilterString(e.Row.Cells[1].Text);
                firstRow = e.Row.RowIndex;

                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.Style.Add("border-top", "solid 1px #5D7B9D");
                }
            }
        }
    }

    protected void btnPSearch_Click(object sender, EventArgs e)
    {
        ATTLawyerCount lawyer = new ATTLawyerCount();
        lawyer.LawyerTypeID = int.Parse(this.ddlPLawyerType.SelectedValue);
        lawyer.UnitID = int.Parse(this.ddlUnit.SelectedValue);
        lawyer.Type = LawyerType.NepalBarCouncil;

        try
        {
            this.grdCount.Columns[0].Visible = true;
            this.grdCount.DataSource = BLLLawyerSearch.GetLawyerCount(lawyer);
            this.grdCount.DataBind();
        }
        catch (Exception ex)
        {
            this.ShowMessage(ex, null);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Lawyer_" + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/ms-excel";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        this.grdCount.Caption = "Lawyer type wise lawyer info";
        this.grdCount.CaptionAlign = TableCaptionAlign.Left;
        this.grdCount.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void btnPrivatePreview_Click(object sender, EventArgs e)
    {
        CrystalReport report = new CrystalReport(Server.MapPath("~/MODULES/LJMS/REPORTS/PrivateLawyerCount.rpt"), "LJMS_ADMIN", "LJMS_ADMIN");
        report.SelectionCriteria = " 1 = 1 ";

        if (this.ddlUnit.SelectedIndex > 0)
            report.SelectionCriteria += " and {VW_UNIT_LAWYER_TYPE_WISE_CNT.unit_id} = " + this.ddlUnit.SelectedValue;
       
        if (this.ddlPLawyerType.SelectedIndex > 0)
            report.SelectionCriteria += " and {VW_UNIT_LAWYER_TYPE_WISE_CNT.lawyer_type_id} = " + this.ddlPLawyerType.SelectedValue;

        Session["LJMSReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('../ReportForms/CommonReportViewer.aspx', 'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        CrystalReport report = new CrystalReport(Server.MapPath("~/MODULES/LJMS/REPORTS/LawyerCount.rpt"), "LJMS_ADMIN", "LJMS_ADMIN");
        report.SelectionCriteria = " 1 = 1 ";

        if (this.ddlLawyerType.SelectedIndex > 0)
            report.SelectionCriteria += " and {VW_UNIT_LAWYER_TYPE_WISE_CNT.lawyer_type_id} = " + this.ddlLawyerType.SelectedValue;

        Session["LJMSReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('../ReportForms/CommonReportViewer.aspx', 'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }
}
