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

public partial class MODULES_LJMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);
        Session["ApplicationID"] = "2";//2 is for Lawyer and Judge Management System
    }
}
