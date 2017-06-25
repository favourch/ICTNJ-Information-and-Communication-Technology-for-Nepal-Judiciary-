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
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Forms_MessageOutBox : System.Web.UI.Page
{
    public int orgID;
    public int userID;
    public string entryBy = "";
    public int loginID;
    public ATTUserLogin user;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }


        user = ((ATTUserLogin)Session["Login_User_Detail"]);
        orgID = user.OrgID;
        entryBy = user.UserName;
        userID = int.Parse(user.PID.ToString());

        if (!IsPostBack)
        {
            LoadOutbox();
            chkAllOutBox.Attributes.Add("onclick", "CheckUncheckAll(this);");
        }

    }

    public void LoadOutbox()
    {
        try
        {
            Session["MessageOutLst"] = BLLMessage.GetMessageList("OUT", user, "");

            grdMessageOutBox.DataSource = (List<ATTMessage>)Session["MessageOutLst"];
            grdMessageOutBox.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
  

    protected void OkButton_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    protected void btnInbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageInbox.aspx");
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Message.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string searchValue = txtSearch.Text.Trim();

        try
        {
            if (searchValue != "")
            {
               
                txtSearch.Text = searchValue;
                Session["SrchMessageOutLst"] = BLLMessage.GetMessageList("OUT", user, searchValue);
                grdMessageOutBox.DataSource = (List<ATTMessage>)Session["SrchMessageOutLst"];
                grdMessageOutBox.DataBind();
            }
            else
            {
                grdMessageOutBox.DataSource = (List<ATTMessage>)Session["MessageOutLst"];
                grdMessageOutBox.DataBind();
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void btnOutbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageOutBox.aspx");
    }
    protected void grdMessageOutBox_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        
        if (row.RowType == DataControlRowType.DataRow)
        {
            row.Cells[1].Visible = false;
            row.Cells[2].Visible = false;

            row.Cells[6].Visible = false;

            row.Cells[3].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageOutBox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[3].Style.Add("cursor", "pointer");

            row.Cells[4].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageOutBox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[4].Style.Add("cursor", "pointer");

            row.Cells[5].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageOutBox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[5].Style.Add("cursor", "pointer");
        }
    }
    protected void grdMessageOutBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = ((GridView)sender);
        Session["rqdOutBoxGrdSender"] = gv;
        //Response.Redirect("MessageView.aspx");


        GridViewRow row = grdMessageOutBox.SelectedRow;

        if (row.Cells[6].Text == "2")
        {
            Response.Redirect("MessageLetterView.aspx");
        }
        else if (row.Cells[6].Text == "1")
        {

            Response.Redirect("MessageView.aspx");
        }
    }
}
