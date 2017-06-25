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

public partial class MODULES_OAS_Forms_MessageView : System.Web.UI.Page
{
    public int orgID, msgID, attachID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rqdGrdSender"] != null)
                LoadMsgDetails();
            else if (Session["rqdOutBoxGrdSender"] != null)
                LoadOutBoxDetails();
            else
                Response.Redirect("MessageInbox.aspx");
        }

    }

    public void LoadMsgDetails()
    {
        try
        {
            GridView gv = (GridView)Session["rqdGrdSender"];

            GridViewRow row = gv.SelectedRow;

            int orgID = int.Parse(row.Cells[1].Text);
            int msgID = int.Parse(row.Cells[2].Text);

            int msgSeq = int.Parse(row.Cells[7].Text);

            if(BLLMessageReceiver.UpdateMessageReceiver(orgID,msgID,msgSeq))
            {
                List<ATTMessage> lstAllMsg = new List<ATTMessage>();
                
                lstAllMsg = (List<ATTMessage>)Session["MessageLst"];

                ATTMessage objRqdMsg = lstAllMsg.Find(delegate(ATTMessage obj)
                                                                                      {
                                                                                          return (obj.OrgID == orgID && obj.MessageID == msgID);
                                                                                      }

                                                                               );
                if (objRqdMsg != null)
                {
                    lblFromData.Text = objRqdMsg.Sender;
                    lblSentData.Text = objRqdMsg.EntryOn.ToString();
                    lblSubjectData.Text = objRqdMsg.Subject;
                    HtmlEditor.Text = objRqdMsg.Body;

                    if (objRqdMsg.Approve == "Y")
                        chkApprove.Checked = true;
                    else
                        chkApprove.Checked = false;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:hideTr('trForOutBox');", true);
                    
                    if (objRqdMsg.LstMsgAttachment.Count > 0)
                    {   
                        dlUpdAttachment.DataSource = objRqdMsg.LstMsgAttachment;
                        dlUpdAttachment.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:hideTr('trForAttach');", true);

                    }
                
                
                }

                Session["objRqdMsg"] = objRqdMsg;
                Session["rqdGrdSender"] = null;
            }
            else
            {
                 this.lblStatusMessageTitle.Text = "Message View";
                 this.lblStatusMessage.Text = "ERROR in displaying message detail !!!";
                 this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadOutBoxDetails()
    {
        try
        {
            GridView gv = (GridView)Session["rqdOutBoxGrdSender"];

            GridViewRow row = gv.SelectedRow;

            int orgID = int.Parse(row.Cells[1].Text);
            int msgID = int.Parse(row.Cells[2].Text);

            List<ATTMessage> lstAllMsg = new List<ATTMessage>();

            lstAllMsg = (List<ATTMessage>)Session["MessageOutLst"];

            ATTMessage objRqdMsg = lstAllMsg.Find(delegate(ATTMessage obj)
                                                                                  {
                                                                                      return (obj.OrgID == orgID && obj.MessageID == msgID);
                                                                                  }

                                                                           );
            if (objRqdMsg != null)
            {
                string sentToLst;
                lblFromData.Text = objRqdMsg.Sender;
                lblSentData.Text = objRqdMsg.EntryOn.ToString();
                lblSubjectData.Text = objRqdMsg.Subject;
                HtmlEditor.Text = objRqdMsg.Body;

                sentToLst = GetSentToList(objRqdMsg);
                
                lblToData.Text = sentToLst;
                if (sentToLst.Length > 168)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showTr", "javascript:setDivDimension();", true);
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showTr", "javascript:showTr('trForOutBox');", true);

                if (objRqdMsg.LstMsgAttachment.Count > 0)
                {

                    dlUpdAttachment.DataSource = GetOutboxAttachmentList(objRqdMsg);
                    
                    dlUpdAttachment.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:hideTr('trForAttach');", true);
                    
                }
            }

            Session["objRqdMsg"] = objRqdMsg;
            Session["rqdOutBoxGrdSender"] = null;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public List<ATTMessageAttachment> GetOutboxAttachmentList(ATTMessage objRqdMsg)
    {
        try
        {
            List<ATTMessageAttachment> tmpAttachmentLst = new List<ATTMessageAttachment>();
            ArrayList arrVal = new ArrayList();

            foreach (ATTMessageAttachment objAttachment in objRqdMsg.LstMsgAttachment)
            {
                int l = 0;
                bool flag = false;
                if (arrVal.Count > 0)
                {

                    for (int k = 0; k < arrVal.Count; k++)
                    {
                        if (objAttachment.AttachmentID == int.Parse(arrVal[k].ToString()))
                        {
                            flag = true;
                            break;
                        }
                    }

                }

                if (!flag)
                {
                    ATTMessageAttachment obj = new ATTMessageAttachment();
                    obj.OrgID = objAttachment.OrgID;
                    obj.MessageID = objAttachment.MessageID;
                    obj.AttachmentID = objAttachment.AttachmentID;
                    obj.FileName = objAttachment.FileName;

                    arrVal.Add(objAttachment.AttachmentID.ToString());

                    tmpAttachmentLst.Add(obj);
                }

                
            }

            return tmpAttachmentLst;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public string GetSentToList(ATTMessage objRqdMsg)
    {
        try
        {
            string sentToLst = "";

            //foreach (ATTMessageReceiver objReceiver in objRqdMsg.LstMessageReceiver)
            //{
            //    sentToLst += objReceiver.Receiver + "; ";
            //}

            foreach (ATTMessageReceiver objReceiver in objRqdMsg.LstMessageReceiver)
            {

                if(objReceiver.Receiver.Trim() != "")
                    sentToLst += objReceiver.Receiver + "; ";
                else if (objReceiver.OtherReceiver.Trim() != "")
                    sentToLst += objReceiver.OtherReceiver + "; ";
            }

            if (sentToLst.Length > 0)
            {
                sentToLst = sentToLst.Substring(0, sentToLst.Length - 2);
            }

            btnReply.Visible = false;
            Session["rqdOutBoxGrdSender"] = null;

            return sentToLst;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

       
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            string arguments = ((LinkButton)sender).CommandArgument.ToString();
            CalculateIDs(arguments);
            ATTMessage objMsg = (ATTMessage)Session["objRqdMsg"];

            List<ATTMessageAttachment> lstMsgAttachment = new List<ATTMessageAttachment>();
            lstMsgAttachment = objMsg.LstMsgAttachment;


            ATTMessageAttachment objRqdMsgAttachment = lstMsgAttachment.Find(delegate(ATTMessageAttachment obj)
                                                                                  {
                                                                                      return (obj.OrgID == orgID && obj.MessageID == msgID && obj.AttachmentID == attachID);
                                                                                  }

                                                                           );

            if (objRqdMsgAttachment != null)
            {
                byte[] fileByte = objRqdMsgAttachment.ContentFile;
                Response.Clear();

                Response.AddHeader("Content-Disposition", "attachment; filename=" + objRqdMsgAttachment.FileName);

                Response.ContentType = "application/octet-stream";

                Response.BinaryWrite(fileByte);
            }


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
       
    }

    public bool CalculateIDs(string arguments)
    {
        try
        {
            string[] IDs = arguments.Split(new char[] { '/' });

            orgID = Convert.ToInt32(IDs[0]);
            msgID = Convert.ToInt32(IDs[1]);
            attachID = Convert.ToInt32(IDs[2]);

            //Session["meetingAgruments"] = null;

            return true;
        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        HtmlEditor.Text = "";
        Response.Redirect("Message.aspx");
    }
    protected void btnInbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageInbox.aspx");
    }
    protected void btnReply_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageReply.aspx");
    }
    protected void btnOutBox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageOutBox.aspx");
    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageForward.aspx");
       // Response.Redirect("MessageLetter.aspx");
    }
    
}
