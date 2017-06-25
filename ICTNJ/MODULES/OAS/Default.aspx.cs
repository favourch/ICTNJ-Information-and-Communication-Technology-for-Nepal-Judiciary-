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

public partial class MODULES_OAS_Default : System.Web.UI.Page
{
    new private ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        if (this.IsPostBack == false)
        {
            this.dlstUnreadTippani.DataSource = BLLGeneralTippani.GetUnreadTippani(this.User.PID, -1);
            this.dlstUnreadTippani.DataBind();
        }
    }
}
