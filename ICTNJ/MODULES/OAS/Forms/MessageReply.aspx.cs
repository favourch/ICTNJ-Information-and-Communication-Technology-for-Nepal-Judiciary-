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

using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Forms_MessageReply : System.Web.UI.Page
{
    public ATTMessage objRqdMsg;
    public int orgID;
    public int userID;
    public string entryBy = "";
    public bool flag ;
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

        if (Session["objRqdMsg"] != null)
            objRqdMsg = (ATTMessage)Session["objRqdMsg"];
        else
            Response.Redirect("MessageInbox.aspx");

        if (!IsPostBack)
        {
            Session["LstRplyMsgAttachment"] = null;


            LoadMsgData();
        }

        
    }
    protected void btnInbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageInbox.aspx");
    }

    public void LoadMsgData()
    {
        try
        {            
            if (objRqdMsg != null)
            {
                lblFromData.Text = entryBy;
                lblSentData.Text = objRqdMsg.Sender;


                if (objRqdMsg.LstMessageReceiver[0].IsGrpReceiver.Trim() == "Y")
                {
                    lblGroup.Visible = true;
                    chkGroup.Visible = true;
                }
                

            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
   
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            ATTMessage objMessage = new ATTMessage();

            objMessage.OrgID = orgID;
            objMessage.MessageID = null;
            objMessage.SenderID = userID;
            objMessage.MessageTypeID = 1;

            if(this.txtSubject_rqd.Text != "")
            {
                objMessage.Subject = txtSubject_rqd.Text.Trim();

            }

            if (Session["LstRplyMsgAttachment"] != null)
            {
                objMessage.LstMsgAttachment = (List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"];
            }

            if (this.HtmlEditor.Text != "")
            {
                 objMessage.Body = HtmlEditor.Text;
            }

            objMessage.Action = "A";
            objMessage.EntryBy = entryBy;

            int? receiverID = objRqdMsg.SenderID;
            bool flag = false;  

            if (receiverID != null)
            {
                List<ATTMessageReceiver> lstReceiver = new List<ATTMessageReceiver>();
                            
                if (chkGroup.Checked && chkGroup.Visible == true)
                {

                    int? groupID = int.Parse(objRqdMsg.LstMessageReceiver[0].GroupID.ToString());
                    int? receiverOrgID = int.Parse(objRqdMsg.LstMessageReceiver[0].ReceiverOrgID.ToString());

                    lstReceiver.Add(new ATTMessageReceiver(orgID, null, null, "Y", groupID, receiverOrgID, "", null, "A", entryBy));

                    flag = true;
                }

                if (!flag)
                {
                    lstReceiver.Add(new ATTMessageReceiver(orgID, null, null, "N", null, null, "", receiverID, "A", entryBy));
                }

                if (lstReceiver.Count > 0)
                {
                    objMessage.LstMessageReceiver = lstReceiver;
                }

            }

           
            if (BLLMessage.SaveMessage(objMessage))
            {
                ClearControls();
                flag = true;
                string confirmation = "Reply sent successfully to " + objRqdMsg.Sender + " !!!";
                this.lblStatusMessageTitle.Text = "Message";
                this.lblStatusMessage.Text = confirmation;
                this.programmaticModalPopup.Show();
                
            }
            else
            {   flag = false;
                this.lblStatusMessageTitle.Text = "Message";
                this.lblStatusMessage.Text = "Reply sent failed !!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HtmlEditor.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
         
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();

        //if(flag)
            Response.Redirect("MessageInbox.aspx");
    }

    public void ClearControls()
    {
        HtmlEditor.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Message.aspx");
    }
    protected void btnOutBox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageOutBox.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTMessageAttachment> LstRplyMsgAttachment = new List<ATTMessageAttachment>();
            string AttachedFileName = "";

            byte[] ContentFile = null;
            string ContentFileType = "";
            string displayName = "";

            if (fupdAttach.HasFile == true)
            {
                if (Session["LstRplyMsgAttachment"] != null)
                {
                    LstRplyMsgAttachment = (List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"];
                }

                ContentFile = this.fupdAttach.FileBytes;

                ContentFileType = Path.GetExtension(this.fupdAttach.FileName);
                AttachedFileName = Path.GetFileName(this.fupdAttach.PostedFile.FileName);

                if (AttachedFileName.Length > 50)
                {
                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "File Uploaded should be of less than 50 characters !!!";
                    this.programmaticModalPopup.Show();

                    return;
                }

                AttachedFileName = AttachedFileName.Replace(" ", "_");


                if (AttachedFileName.Length > 15)
                    displayName = AttachedFileName.Substring(0, 15) + ".....";
                else
                    displayName = AttachedFileName;

                LstRplyMsgAttachment.Add(new ATTMessageAttachment(ContentFile, ContentFileType, AttachedFileName, displayName, DateTime.Now));


                if (LstRplyMsgAttachment.Count > 0)
                {
                    if (LstRplyMsgAttachment.Count == 1)
                    {
                        dlUpdAttachment.Width = 30;
                    }

                    this.dlUpdAttachment.DataSource = LstRplyMsgAttachment;
                    this.dlUpdAttachment.DataBind();
                    this.dlUpdAttachment.SelectedIndex = -1;

                    Session["LstRplyMsgAttachment"] = LstRplyMsgAttachment;

                }
                else
                {
                                      this.dlUpdAttachment.DataSource = "";
                    this.dlUpdAttachment.DataBind();

                    Session["LstRplyMsgAttachment"] = null;
                  
                }

            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void dlUpdAttachment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ((List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"]).RemoveAt(dlUpdAttachment.SelectedIndex);

            if (Session["LstRplyMsgAttachment"] != null && ((List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"]).Count > 0)
            {

                if (((List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"]).Count == 1)
                {
                    dlUpdAttachment.Width = 30;
                }
                this.dlUpdAttachment.DataSource = Session["LstRplyMsgAttachment"];
                this.dlUpdAttachment.DataBind();
                dlUpdAttachment.SelectedIndex = -1;


            }
            else
            {
                //SetDivHeight(0, "dvAttachment");
                this.dlUpdAttachment.DataSource = "";
                this.dlUpdAttachment.DataBind();
                this.dlUpdAttachment.SelectedIndex = -1;

                Session["LstRplyMsgAttachment"] = null;
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    //public bool SetDivHeight(int count, string val)
    //{
    //    try
    //    {
    //        if (count == 0)
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','0');", true);

    //            if (val == "dvReceiver")
    //                dlReceiver.Height = 0;
    //            else
    //                dlUpdAttachment.Height = 0;

    //            return true;

    //        }
    //        else if (count == 1)
    //        {
    //            if (val == "dvReceiver")
    //                dlReceiver.Width = 40;
    //            else
    //                dlUpdAttachment.Width = 30;

    //            return true;

    //        }
    //        else if (count > 1)
    //        {

    //            if (count > 4)
    //            {
    //                //dlReceiver.Width = 500;
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','55');", true);

    //            }
    //            else if (count > 1 && count <= 4)
    //            {
    //                //if (count == 2)
    //                //    dlReceiver.Width = 80;
    //                //else if (count == 3)
    //                //    dlReceiver.Width = 120;


    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','27');", true);

    //            }
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        throw (ex);
    //    }
    //}

}
