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

using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;

public partial class MODULES_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        else
        {
            ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];
            System.Collections.Generic.List<ATTApplication> lst = BLLApplication.GetUserApplicationList(user.UserName);
            lst.RemoveAll(
                delegate(ATTApplication appl)
                {
                    return appl.ApplicationID == 8;
                }
            );
            this.dListUserApplication.DataSource = lst;
            this.dListUserApplication.DataBind();
        }
    }

    protected void Application_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgBut = (ImageButton)sender;
        
        int applID = int.Parse(imgBut.CommandArgument);
        string applName;

        switch (applID)
        {
            case 1:
                applName = "CMS";
                break;
            case 2:
                applName = "LJMS";
                break;
            case 3:
                applName = "PMS";
                break;
            case 4:
                applName = "LIS";
                break;
            case 5:
                applName = "OAS";
                break;
            case 6:
                applName = "PMES";
                break;
            case 7:
                applName = "OSS";
                break;
            case 9:
                applName = "PDIS";
                break;
            case 10:
                applName = "DLPDS";
                break;
            default:
                applName = "";
                break;
        }

        ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];
        try
        {
            user.MenuList = BLLUserLogin.GetUserApplicationMenu(user.UserName, applID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Response.Redirect("~/MODULES/" + applName + "/Default.aspx", true);
    }

    protected void dListUserApplication_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl = (Label)e.Item.FindControl("lblSeq");
            lbl.Text = (e.Item.ItemIndex + 1).ToString();
        }
    }
}
