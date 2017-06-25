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

public partial class MODULES_OAS_Forms_MessageInbox : System.Web.UI.Page
{
    public int orgID ;
    public int userID ;
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
        //user.PID = 251;
        userID = int.Parse(user.PID.ToString());
        //userID = 251;

        if (!IsPostBack)
        {
            LoadInbox();
            chkAllInbox.Attributes.Add("onclick", "CheckUncheckAll(this);");
        }
    }

    public void LoadInbox()
    {
        try
        {
            Session["MessageLst"] = BLLMessage.GetMessageList("IN", user, "");
            
            grdMessageInbox.DataSource = (List<ATTMessage>)Session["MessageLst"];
            grdMessageInbox.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
  
    protected void grdMessageInbox_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

      

        if (row.RowType == DataControlRowType.DataRow)
        {
            row.Cells[1].Visible = false;
            row.Cells[2].Visible = false;
            //row.Cells[6].Visible = false;
            //row.Cells[7].Visible = false;
            //row.Cells[8].Visible = false;

            row.Cells[7].Visible = false;
            row.Cells[8].Visible = false;
            row.Cells[9].Visible = false;
            row.Cells[10].Visible = false;

            row.Cells[11].Visible = false;
            row.Cells[12].Visible = false;

            row.Cells[3].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageInbox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[3].Style.Add("cursor", "pointer");

            row.Cells[4].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageInbox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[4].Style.Add("cursor", "pointer");

            row.Cells[5].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageInbox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[5].Style.Add("cursor", "pointer");


            row.Cells[6].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(grdMessageInbox, "Select$" +
            row.RowIndex.ToString()));
            row.Cells[6].Style.Add("cursor", "pointer");
        }


    }
    protected void grdMessageInbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = ((GridView)sender);
        Session["rqdGrdSender"] = gv;


        GridViewRow row = grdMessageInbox.SelectedRow;

        if (row.Cells[10].Text == "2")
        {
            Response.Redirect("MessageLetterView.aspx");     
        }
        else if (row.Cells[10].Text == "1")
        {

            Response.Redirect("MessageView.aspx");     
        }
       
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Message.aspx");
    }

   
    protected void Cancel_Click(object sender, EventArgs e)
    {
        chkAllInbox.Checked = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
          
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList arrMsgToDelete = new ArrayList();
          
            List<ATTMessage> lst = new List<ATTMessage>();

            lst = GetCheckedLst();

            if (lst.Count > 0)
            {

                if (BLLMessage.DeleteMessage(lst))
                {
                    ClearControls();
                    LoadInbox();

                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "Message Delete successfully !!!";
                    this.programmaticModalPopup.Show();

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "Message Delete failed !!!";
                    this.programmaticModalPopup.Show();
                }
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Message";
                this.lblStatusMessage.Text = "No Messages to be deleted !!!";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public List<ATTMessage> GetCheckedLst()
    {
        ArrayList arrMsgToDelete = new ArrayList();
        List<ATTMessage> lst = new List<ATTMessage>();

        try
        {
            CheckBox chkInboxMsg;
            
            if (grdMessageInbox.Rows.Count > 0)
            {
              

                foreach (GridViewRow gvr in grdMessageInbox.Rows)
                {
                    ATTMessage obj = new ATTMessage();
                    chkInboxMsg = (CheckBox)gvr.FindControl("chkInboxMsg");
                    
                    if (chkInboxMsg.Checked)
                    {
                        obj.OrgID = orgID;
                        obj.MessageID = int.Parse(gvr.Cells[2].Text);
                        obj.MsgSeq = int.Parse(gvr.Cells[7].Text);
                        obj.MsgGrpType = gvr.Cells[8].Text;

                        lst.Add(obj);

                   }
                }
            }

            return lst;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return lst;
        }
    }

    public void ClearControls()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string searchValue = txtSearch.Text.Trim();

        try
        {
            if (searchValue != "")
            {
                //ATTUserLogin userlogin = new ATTUserLogin();

                //user = ((ATTUserLogin)Session["Login_User_Detail"]);
                
                txtSearch.Text = searchValue;
                Session["SrchMessageLst"] = BLLMessage.GetMessageList("IN", user, searchValue);
                grdMessageInbox.DataSource = (List<ATTMessage>)Session["SrchMessageLst"];
                grdMessageInbox.DataBind();
            }
            else
            {
                grdMessageInbox.DataSource = (List<ATTMessage>)Session["MessageLst"];
                grdMessageInbox.DataBind();
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
    protected void btnInbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageInbox.aspx");
    }
    protected void grdMessageInbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        if (row.RowType == DataControlRowType.DataRow)
        {
            if (row.Cells[9].Text == "Y")
            {
                //row.BackColor = System.Drawing.Color.FromName("#808000");
                //row.BackColor = System.Drawing.Color.DimGray;


                Image imgMail = (Image)row.Cells[3].FindControl("imgMail");
                imgMail.ImageUrl = "~/MODULES/OAS/Images/Omail.jpg";
            }

        }
    }
}
