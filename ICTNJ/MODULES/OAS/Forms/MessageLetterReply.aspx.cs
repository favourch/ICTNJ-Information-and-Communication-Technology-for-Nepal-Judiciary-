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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;

public partial class MODULES_OAS_Forms_MessageReply : System.Web.UI.Page
{
    public ATTMessage objRqdMsg;
    public int orgID;
    public int userID;
    public string entryBy = "";
    public bool flag ;
    public ATTUserLogin user;

    public string TodayDate
    {
        get
        {
            return (Session["LetterToDayDate"] == null) ? "" : Session["LetterToDayDate"].ToString();
        }
        set { Session["LetterToDayDate"] = value; }
    }


    public string LetterDate
    {
        get
        {
            return (Session["LetterDate"] == null) ? "" : Session["LetterDate"].ToString();
        }
        set { Session["LetterDate"] = value; }
    }

    public string LetterTitle
    {
        get
        {
            return (Session["LetterTitle"] == null) ? "" : Session["LetterTitle"].ToString();
        }
        set { Session["LetterTitle"] = value; }
    }

    public string LetterBody
    {
        get
        {
            return (Session["LetterBody"] == null) ? "" : Session["LetterBody"].ToString();
        }
        set { Session["LetterBody"] = value; }
    }

    public string LetterFooter
    {
        get
        {
            return (Session["LetterFooter"] == null) ? "" : Session["LetterFooter"].ToString();
        }
        set { Session["LetterFooter"] = value; }
    }

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

            string dateString = BLLDate.GetDateString(0, 0, "_N");


            int len = dateString.Length;
            TodayDate = dateString.Substring(0, len - 5);

            Session["LetterDate"] = null;
            Session["LetterTitle"] = null;
            Session["LetterBody"] = null;
            Session["LetterFooter"] = null;
        }

        string date = " <p align= right> मिति : " + TodayDate
                     + "  </P><br><br>";

        LetterDate = date;
                      

        
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
            objMessage.MessageTypeID = 2;

            if(this.txtSubject_rqd.Text != "")
            {
                objMessage.Subject = txtSubject_rqd.Text.Trim();

            }

            if (ddlLetterType.SelectedIndex > 0)
                objMessage.LetterType = ddlLetterType.SelectedValue.ToString();


            if (Session["LstRplyMsgAttachment"] != null)
            {
                objMessage.LstMsgAttachment = (List<ATTMessageAttachment>)Session["LstRplyMsgAttachment"];
            }

            if (this.HtmlEditor.Text != "")
            {
                 objMessage.Body = HtmlEditor.Text;
            }

            if (chkApprove.Checked)
                objMessage.Approve = "Y";
            else
                objMessage.Approve = "N";

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
        Response.Redirect("MessageLetter.aspx");
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

    protected void ddlFilterTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlUnitTo.Enabled = false;
        ddlPersonTo.Enabled = false;

        ddlUnitTo.SelectedIndex = -1;
        ddlPersonTo.SelectedIndex = -1;

        if (ddlFilterTo.SelectedIndex > 0)
        {

            List<ATTOrganization> lstOrg = new List<ATTOrganization>();

            lstOrg = BLLOrganization.GetOrganization();

            Session["OrgTo"] = lstOrg;

            ddlOrgTo.DataSource = lstOrg;
            ddlOrgTo.DataTextField = "OrgName";
            ddlOrgTo.DataValueField = "OrgId";
            ddlOrgTo.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "छान्नुहोस्";
            a.Value = "0";
            ddlOrgTo.Items.Insert(0, a);

            ddlOrgTo.Enabled = true;

            ddlFilterFrom.Enabled = true;
        }
        else
        {
            ResetHtmlEditor();

            ddlOrgTo.DataSource = "";
            ddlOrgTo.DataBind();

            ddlOrgTo.SelectedIndex = -1;

            ddlOrgTo.Enabled = false;

            LetterFooter = "";

            HtmlEditor.Text = LetterBody;

            LetterTitle = "";
            LetterFooter = "";

            ddlOrgFrom.SelectedIndex = -1;
            ddlUnitFrom.SelectedIndex = -1;
            ddlPersonFrom.SelectedIndex = -1;
            ddlFilterFrom.SelectedIndex = -1;

            ddlOrgFrom.Enabled = false;
            ddlUnitFrom.Enabled = false;
            ddlPersonFrom.Enabled = false;
            ddlFilterFrom.Enabled = false;


        }
    }
    protected void ddlOrgTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlFilterTo.SelectedIndex == 1)
            {
                SetLetterTitle();
            }
            else if (ddlFilterTo.SelectedIndex == 2 || ddlFilterTo.SelectedIndex == 3)
            {
                if (ddlOrgTo.SelectedIndex > 0)
                {
                    List<ATTOrganizationUnit> lstUnit = new List<ATTOrganizationUnit>();

                    lstUnit = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrgTo.SelectedValue.ToString()), null);

                    if (lstUnit.Count > 0)
                    {
                        this.ddlUnitTo.DataSource = lstUnit;
                        this.ddlUnitTo.DataTextField = "UnitName";
                        this.ddlUnitTo.DataValueField = "UnitID";
                        this.ddlUnitTo.DataBind();

                        ListItem a = new ListItem();
                        a.Selected = true;
                        a.Text = "छान्नुहोस्";
                        a.Value = "0";
                        ddlUnitTo.Items.Insert(0, a);

                        ddlUnitTo.Enabled = true;

                    }
                }
                else
                {
                    this.ddlUnitTo.DataSource = "";
                    this.ddlUnitTo.DataBind();


                    ddlUnitTo.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void ddlUnitTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlFilterTo.SelectedIndex == 2)
            {
                SetLetterTitle();
            }
            else if (ddlFilterTo.SelectedIndex == 3)
            {
                if (ddlUnitTo.SelectedIndex > 0)
                {

                    List<ATTMessagePerson> lstPerson = new List<ATTMessagePerson>();

                    lstPerson = BLLMessagePerson.GetMessagePersonList(int.Parse(ddlOrgTo.SelectedValue), int.Parse(ddlUnitTo.SelectedValue), "", true);

                    ddlPersonTo.DataSource = lstPerson;
                    ddlPersonTo.DataTextField = "PersonName";
                    ddlPersonTo.DataValueField = "PID";
                    ddlPersonTo.DataBind();

                    ddlPersonTo.Enabled = true;
                }
                else
                {
                    ddlPersonTo.DataSource = "";
                    ddlPersonTo.DataBind();

                    ddlPersonTo.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void ddlPersonTo_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddlFilterTo.SelectedIndex == 3)
        {
            SetLetterTitle();
        }
    }

    public void ResetHtmlEditor()
    {
        try
        {
            string val = HtmlEditor.Text;
            string body = "";

            if (LetterTitle.Length > 0 && LetterFooter.Length > 0)
                body = val.Substring(LetterTitle.Length + LetterDate.Length - 6, val.Length - LetterTitle.Length - LetterDate.Length - LetterFooter.Length + 9);
            else if (LetterTitle.Length > 0)
                body = val.Substring(LetterTitle.Length + LetterDate.Length - 6, val.Length - LetterTitle.Length - LetterDate.Length + 6);
            else
                body = val.Substring(0, val.Length);


            //if (LetterTitle.Length > 0 && LetterFooter.Length > 0)
            //   body = val.Substring(LetterTitle.Length - 2, val.Length - LetterTitle.Length - LetterFooter.Length + 5);
            //else if (LetterTitle.Length > 0)
            //   body = val.Substring(LetterTitle.Length - 2, val.Length - LetterTitle.Length + 2);
            //else  if (LetterFooter.Length > 0)
            //    body = val.Substring(0, val.Length - LetterFooter.Length + 3);
            //else
            //    body = val.Substring(0, val.Length);

            LetterBody = body;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void SetLetterFooter()
    {
        try
        {
            string footer = "";
            //LetterFooter = "";

            List<ATTOrganization> lstOrg = (List<ATTOrganization>)Session["OrgTo"];

            if (ddlFilterFrom.SelectedIndex == 1)
            {
                footer = "<br><br><br> <p align= right> "
                  + ddlOrgFrom.SelectedItem.ToString()
                  + " "
                  + "<br>...............<br> शाखा अधिकृत"
                  + "</p> ";

            }
            else if (ddlFilterFrom.SelectedIndex == 2 && ddlUnitFrom.SelectedIndex > 0)
            {


                footer = "<br> <p align= right> "
                       + ddlUnitFrom.SelectedItem.ToString()
                       + " "
                       + "<br>...............<br> शाखा अधिकृत"
                       + "</p> ";



            }
            else if (ddlFilterFrom.SelectedIndex == 3 && ddlPersonFrom.SelectedIndex > 0)
            {

                footer = "<br> <p align= right> "
                     + ddlPersonFrom.SelectedItem.ToString()
                     + " "
                     + "<br>...............<br> शाखा अधिकृत"
                     + "</p> ";

            }

            ResetHtmlEditor();

            LetterFooter = footer;

            if (LetterTitle.Length > 0)
            {

                HtmlEditor.Text = LetterDate + LetterTitle + LetterBody + LetterFooter;
            }
            else
            {
                HtmlEditor.Text = LetterBody;

                this.lblStatusMessageTitle.Text = "Letter";
                this.lblStatusMessage.Text = "First Letter Title should be set !!!";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    public void SetLetterTitle()
    {
        try
        {
            string title = "";
            List<ATTOrganization> lstOrg = (List<ATTOrganization>)Session["OrgTo"];

            if (ddlFilterTo.SelectedIndex == 1)
            {

                title += " श्री "
                      + ddlOrgTo.SelectedItem.ToString();

            }
            else if (ddlFilterTo.SelectedIndex == 2 && ddlUnitTo.SelectedIndex > 0)
            {
                title += " श्री "
                      + ddlUnitTo.SelectedItem.ToString();

            }
            else if (ddlFilterTo.SelectedIndex == 3 && ddlPersonTo.SelectedIndex > 0)
            {
                title += " श्री "
                      + ddlPersonTo.SelectedItem.ToString();

            }

            title += " <br> " + lstOrg[ddlOrgTo.SelectedIndex - 1].OrgAddress
                      + " , नेपाल।<br><br>";

            ResetHtmlEditor();

            LetterTitle = title;

            if (LetterTitle.Length > 0)
                HtmlEditor.Text = LetterDate + LetterTitle + LetterBody + LetterFooter;
            else
                HtmlEditor.Text = LetterBody;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void ddlFilterFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlUnitFrom.Enabled = false;
        ddlPersonFrom.Enabled = false;

        ddlUnitFrom.SelectedIndex = -1;
        ddlPersonFrom.SelectedIndex = -1;

        if (ddlFilterFrom.SelectedIndex > 0)
        {
            List<ATTOrganization> lstOrg = new List<ATTOrganization>();

            lstOrg = BLLOrganization.GetOrganization();

            Session["OrgFrom"] = lstOrg;

            ddlOrgFrom.DataSource = lstOrg;
            ddlOrgFrom.DataTextField = "OrgName";
            ddlOrgFrom.DataValueField = "OrgId";
            ddlOrgFrom.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "छान्नुहोस्";
            a.Value = "0";
            ddlOrgFrom.Items.Insert(0, a);

            ddlOrgFrom.Enabled = true;
        }

        else
        {
            ResetHtmlEditor();

            ddlOrgFrom.DataSource = "";
            ddlOrgFrom.DataBind();
            ddlOrgFrom.SelectedIndex = -1;
            ddlOrgFrom.Enabled = false;

            HtmlEditor.Text = LetterDate + LetterTitle + LetterBody;

            LetterFooter = "";


        }
    }
    protected void ddlOrgFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFilterFrom.SelectedIndex == 1)
        {
            SetLetterFooter();
        }
        else if (ddlFilterFrom.SelectedIndex == 2 || ddlFilterFrom.SelectedIndex == 3)
        {
            if (ddlOrgFrom.SelectedIndex > 0)
            {
                List<ATTOrganizationUnit> lstUnit = new List<ATTOrganizationUnit>();

                lstUnit = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrgFrom.SelectedValue.ToString()), null);

                if (lstUnit.Count > 0)
                {
                    this.ddlUnitFrom.DataSource = lstUnit;
                    this.ddlUnitFrom.DataTextField = "UnitName";
                    this.ddlUnitFrom.DataValueField = "UnitID";
                    this.ddlUnitFrom.DataBind();

                    ListItem a = new ListItem();
                    a.Selected = true;
                    a.Text = "छान्नुहोस्";
                    a.Value = "0";
                    ddlUnitFrom.Items.Insert(0, a);

                    ddlUnitFrom.Enabled = true;

                }
            }
            else
            {
                this.ddlUnitFrom.DataSource = "";
                this.ddlUnitFrom.DataBind();


                ddlUnitFrom.Enabled = false;

                LetterFooter = "";
            }
        }

    }
    protected void ddlUnitFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlFilterFrom.SelectedIndex == 2)
            {
                SetLetterFooter();
            }
            else if (ddlFilterFrom.SelectedIndex == 3)
            {
                List<ATTMessagePerson> lstPerson = new List<ATTMessagePerson>();

                lstPerson = BLLMessagePerson.GetMessagePersonList(int.Parse(ddlOrgFrom.SelectedValue), int.Parse(ddlUnitFrom.SelectedValue), "", true);

                ddlPersonFrom.DataSource = lstPerson;
                ddlPersonFrom.DataTextField = "PersonName";
                ddlPersonFrom.DataValueField = "PID";
                ddlPersonFrom.SelectedIndex = -1;
                ddlPersonFrom.DataBind();

                ddlPersonFrom.Enabled = true;
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void ddlPersonFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFilterFrom.SelectedIndex == 3)
        {
            SetLetterFooter();
        }
    }
}
