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

public partial class MODULES_LJMS_Forms_LawyerSearch : System.Web.UI.Page
{
    new private ATTUserLogin User
    {
        get { return this.Session["Login_User_Detail"] as ATTUserLogin; }
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
        if (user.MenuList.ContainsKey("2,36,1") == true)
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
            this.ddlLawyerType.DataSource = BLLLawyerType.GetLawyerTypeList(null, true);
            this.ddlLawyerType.DataTextField = "LawyerTypeDescription";
            this.ddlLawyerType.DataValueField = "LawyerTypeID";
            this.ddlLawyerType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadUnit()
    {
        try
        {
            this.ddlUnit.DataSource = BLLUnit.GetUnitList(null, true);
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (
                this.txtFName.Text.Trim() == "" &&
                this.txtMName.Text.Trim() == "" &&
                this.txtSName.Text.Trim() == "" &&
                this.txtLisenceNo.Text.Trim() == "" &&
                this.ddlLawyerType.SelectedIndex == 0 &&
                this.ddlUnit.SelectedIndex == 0 &&
                this.ddlSex.SelectedIndex == 0
            )
        {
            this.lblStatus.Text = "Please enter atleast one criteria for record selecttion.";
            return;
        }

        ATTLawyerSearch search = this.GetFilter();

        try
        {
            List<ATTLawyerSearch> lst = BLLLawyerSearch.GetLawyerList(search);
            Session["LstSrchedData"] = lst;
            this.grdLawyer.SelectedIndex = -1;
            this.grdLawyer.DataSource = lst;
            this.grdLawyer.DataBind();
            this.lblStatus.Text = "";
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    ATTLawyerSearch GetFilter()
    {
        ATTLawyerSearch search = new ATTLawyerSearch();

        search.FirstName = this.txtFName.Text;
        search.MidName = this.txtMName.Text;
        search.SurName = this.txtSName.Text;
        search.Lisence = this.txtLisenceNo.Text;
        search.LawyerTypeID = int.Parse(this.ddlLawyerType.SelectedValue);
        search.UnitID = int.Parse(this.ddlUnit.SelectedValue);

        if (chkInActive.Checked)
            search.ACTIVE = "N";
        else
            search.ACTIVE = "";

        if (this.ddlSex.SelectedIndex > 0)
            search.Gender = this.ddlSex.SelectedValue;
        else
            search.Gender = "";

        return search;
    }

    protected void grdLawyer_DataBound(object sender, EventArgs e)
    {
        if (this.grdLawyer.Rows.Count < 0)
        {
            this.lblCount.Text = "No lawyer found.";
        }
        else
        {
            this.lblCount.Text = "Total lawyer: " + this.grdLawyer.Rows.Count.ToString();
        }
    }

    protected void grdLawyer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.BioData == true)
        {
            double PID = double.Parse((sender as GridView).Rows[this.grdLawyer.SelectedIndex].Cells[0].Text);
            this.grdLawyer.SelectedIndex = -1;
            ReloadSearched();
            this.GenerateBioData(PID);
        }
        else
        {
            if (this.User.MenuList["2,35,1"].PEdit == "N")
            {
                Response.Write("<b>Insufficient previlege to edit lawyer record.");
                Response.End();
                return;
            }

            GridViewRow gvRow = this.grdLawyer.SelectedRow;

            Session["PIDforLawyerDetail"] = gvRow.Cells[0].Text;
            Response.Redirect("LawyerInfo.aspx", true);
        }
    }

    void GenerateBioData(double PID)
    {
        if (this.User.MenuList.ContainsKey("2,36,2") == false)
        {
            Response.Write("<b>Insufficient previlege to view lawyer bio-data.");
            Response.End();
            return;
        }

        CrystalReport report = new CrystalReport(Server.MapPath("~/MODULES/LJMS/REPORTS/LawyerBioData.rpt"), "LJMS_ADMIN", "LJMS_ADMIN");
        report.SelectionCriteria = " {VW_PERSON_ADDRESS_INFO.P_ID} = " + PID.ToString();

        SubReport Phone = new SubReport();
        Phone.SubReportName = "EmpPhone";
        Phone.ParamList.Add(new ReportParameter("P_P_ID", PID));
        Phone.ParamList.Add(new ReportParameter("P_ACTIVE", "Y"));
        report.SubReportList.Add(Phone);

        SubReport PermAddress = new SubReport();
        PermAddress.SubReportName = "EmpPermAddress";
        PermAddress.ParamList.Add(new ReportParameter("P_P_ID", PID));
        PermAddress.ParamList.Add(new ReportParameter("P_ACTIVE", "Y"));
        report.SubReportList.Add(PermAddress);

        SubReport Email = new SubReport();
        Email.SubReportName = "EmpEmail";
        Email.ParamList.Add(new ReportParameter("P_P_ID", PID));
        Email.ParamList.Add(new ReportParameter("P_ACTIVE", "Y"));
        report.SubReportList.Add(Email);

        SubReport TempAddress = new SubReport();
        TempAddress.SubReportName = "EmpTempAddress";
        TempAddress.ParamList.Add(new ReportParameter("P_P_ID", PID));
        TempAddress.ParamList.Add(new ReportParameter("P_ACTIVE", "Y"));
        report.SubReportList.Add(TempAddress);

        Session["LJMSReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('../ReportForms/CommonReportViewer.aspx', 'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void grdLawyer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[11].Visible = false;

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    GridViewRow row = e.Row;

        //    //LinkButton lnkBtn = (LinkButton)row.Cells[9].Controls[0];

        //    if (row.Cells[11].Text.Trim() == "N")
        //    {
        //        e.Row.Cells[9].Text = "";
        //        e.Row.Cells[10].Text = "";
        //        e.Row.ForeColor = System.Drawing.Color.Red;
                
        //    }
        //}

        e.Row.Cells[0].Visible = false;
        e.Row.Cells[12].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow row = e.Row;

            //LinkButton lnkBtn = (LinkButton)row.Cells[9].Controls[0];

            if (row.Cells[12].Text.Trim() == "N")
            {
                e.Row.Cells[10].Text = "";
                e.Row.Cells[11].Text = "";
                e.Row.ForeColor = System.Drawing.Color.Red;

            }
        }
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        if (
                this.txtFName.Text.Trim() == "" &&
                this.txtMName.Text.Trim() == "" &&
                this.txtSName.Text.Trim() == "" &&
                this.txtLisenceNo.Text.Trim() == "" &&
                this.ddlLawyerType.SelectedIndex == 0 &&
                this.ddlUnit.SelectedIndex == 0 &&
                this.ddlSex.SelectedIndex == 0
            )
        {
            this.lblStatus.Text = "Please enter atleast one criteria for record selecttion.";
            return;
        }

        if (this.User.MenuList.ContainsKey("2,36,3") == false)
        {
            Response.Write("<b>Insufficient previlege to view general report.");
            Response.End();
            return;
        }

        string reportName;
        if (this.chkWP.Checked == true)
            reportName = "~/MODULES/LJMS/REPORTS/LawyerInfo.rpt";
        else
            reportName = "~/MODULES/LJMS/REPORTS/LawyerInfo_WithoutContact.rpt";

        CrystalReport report = new CrystalReport(Server.MapPath(reportName), "LJMS_ADMIN", "LJMS_ADMIN");
        report.SelectionCriteria = " 1 = 1 ";

        if (this.txtFName.Text.Trim() != "")
            report.SelectionCriteria += "and {VW_LAWYER_INFO.FIRST_NAME} like '*" + this.txtFName.Text.Trim() + "'";

        if (this.txtMName.Text.Trim() != "")
            report.SelectionCriteria += "and {VW_LAWYER_INFO.MID_NAME} like '*" + this.txtMName.Text.Trim() + "'";

        if (this.txtSName.Text.Trim() != "")
            report.SelectionCriteria += "and {VW_LAWYER_INFO.SUR_NAME} like '*" + this.txtSName.Text.Trim() + "'";

        if (this.txtLisenceNo.Text.Trim() != "")
            report.SelectionCriteria += "and {VW_LAWYER_INFO.LICENSE_NO} = '" + this.txtLisenceNo.Text.Trim() + "'";

        if (this.ddlLawyerType.SelectedIndex > 0)
            report.SelectionCriteria += "and {VW_LAWYER_INFO.LAWYER_TYPE_ID} = " + this.ddlLawyerType.SelectedValue;

        if (this.ddlUnit.SelectedIndex > 0)
            report.SelectionCriteria += "and {VW_LAWYER_INFO.UNIT_ID} = " + this.ddlUnit.SelectedValue;

        if (this.ddlSex.SelectedIndex > 0)
            report.SelectionCriteria += "and {VW_LAWYER_INFO.GENDER} = '" + this.ddlSex.SelectedValue + "'";

        Session["LJMSReport"] = report;

        this.lblStatus.Text = "";
        ReloadSearched();

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('../ReportForms/CommonReportViewer.aspx', 'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    private bool BioData = false;
    protected void lnkViewBioData_Click(object sender, EventArgs e)
    {
        this.BioData = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtFName.Text = "";
            txtLisenceNo.Text = "";
            txtMName.Text = "";
            txtSName.Text = "";
            ddlLawyerType.SelectedIndex = -1;
            ddlUnit.SelectedIndex = -1;

            grdLawyer.SelectedIndex = -1;
            grdLawyer.DataSource = "";
            grdLawyer.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    public void ReloadSearched()
    {
        try
        {
            if (Session["LstSrchedData"] != null)
            {

                List<ATTLawyerSearch> lst = new List<ATTLawyerSearch>();
                lst = (List<ATTLawyerSearch>)Session["LstSrchedData"];
                
                if (lst.Count > 0)
                {
                    this.grdLawyer.SelectedIndex = -1;
                    this.grdLawyer.DataSource = lst;
                    this.grdLawyer.DataBind();
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}
