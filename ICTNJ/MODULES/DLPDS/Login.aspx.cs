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
using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using System.Collections.Generic;

public partial class MODULES_DLPDS_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();

            this.txtUsername_Rqd.Focus();
        }

    }

    void LoadOrganization()
    {
        try
        {
            this.ddlOrg.DataSource = BLLOrganization.GetOrganization();
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
            this.ddlOrg.SelectedValue = "104";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ATTUserLogin user=new ATTUserLogin();
        try
        {
            //user = BLLUserLogin.GetUserLogin(this.txtUsername_Rqd.Text, this.txtpassword_Rqd.Text, int.Parse(this.ddlOrg.SelectedValue));
        }
        catch (Exception)
        {
            this.lblStatus.Text = "Please try again..";
            return;
        }

        if (user.UserMessage.ToUpper() != "OK")
        {
            Session["Login_User_Detail"] = null;
            this.lblStatus.Text = user.UserMessage;
            this.txtUsername_Rqd.Focus();
            return;
        }
        user.UserName = this.txtUsername_Rqd.Text.Trim();
        user.OrgID = int.Parse(this.ddlOrg.SelectedValue);
        user.OrgName = this.ddlOrg.SelectedItem.Text;
        Session["Login_User_Detail"] = user;
        Response.Redirect("~/MODULES/DLPDS/Default.aspx", true);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
