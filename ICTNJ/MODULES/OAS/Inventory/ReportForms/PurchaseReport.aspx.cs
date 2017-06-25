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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.REPORT;

public partial class MODULES_OAS_Inventory_ReportForms_PurchaseReport : System.Web.UI.Page
{
    public int orgID;
    public string entryBy;
    public int loginID;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        orgID = user.OrgID;
        entryBy = user.UserName;
        loginID = int.Parse(user.PID.ToString());
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {

            CrystalReport report = new CrystalReport();
            report.SelectionCriteria = SelectionCriteria();

            report.UserID = "OAS_ADMIN";
            report.Password = "OAS_ADMIN";

            report.ReportName = Server.MapPath("~") + "\\MODULES\\OAS\\Inventory\\REPORTS\\PurchaseOrder.rpt";


            Session["OASReport"] = report;
            Session["OASReportTitle"] = null;
            Session["OASReportTitle"] = "OAS | PurchaseOrder Report";


            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public string SelectionCriteria()
    {
        try
        {
            string strSelection = " 1=1 AND {VW_INV_DELIVERY_ORDERS.ORG_ID} = " + orgID;

            if (txtOrderNo.Text != "")
                strSelection = " {VW_INV_DELIVERY_ORDERS.ORDER_NO} = '" + txtOrderNo.Text + "'";


            return strSelection;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtOrderNo.Text = "";
    }
    
}
