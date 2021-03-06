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

public partial class MODULES_OAS_Forms_MessageLetter : System.Web.UI.Page
{

    public int orgID ;
    public int userID;
    public string entryBy = "";
    public int loginID;
    public ATTUserLogin user;

    public int? BeforeChangeUnitID
    {
        get
        {
            return (Session["BeforeChangeUnitID"] == null) ? 0 : int.Parse(Session["BeforeChangeUnitID"].ToString());
        }
        set { Session["BeforeChangeUnitID"] = value; }
    }

    public int? BeforeChangeOrgID
    {
        get
        {
            return (Session["BeforeChangeOrgID"] == null) ? 0 : int.Parse(Session["BeforeChangeOrgID"].ToString());
        }
        set { Session["BeforeChangeOrgID"] = value; }
    }

    public int? BeforeChangeFilterIndex
    {
        get
        {
            return (Session["BeforeChangeFilterIndex"] == null) ? 0 : int.Parse(Session["BeforeChangeFilterIndex"].ToString());
        }
        set { Session["BeforeChangeFilterIndex"] = value; }
    }

    public int? BeforeChangeUnitIDCc
    {
        get
        {
            return (Session["BeforeChangeUnitIDCc"] == null) ? 0 : int.Parse(Session["BeforeChangeUnitIDCc"].ToString());
        }
        set { Session["BeforeChangeUnitIDCc"] = value; }
    }

    public int? BeforeChangeOrgIDCc
    {
        get
        {
            return (Session["BeforeChangeOrgIDCc"] == null) ? 0 : int.Parse(Session["BeforeChangeOrgIDCc"].ToString());
        }
        set { Session["BeforeChangeOrgIDCc"] = value; }
    }

    public int? BeforeChangeFilterIndexCc
    {
        get
        {
            return (Session["BeforeChangeFilterIndexCc"] == null) ? 0 : int.Parse(Session["BeforeChangeFilterIndexCc"].ToString());
        }
        set { Session["BeforeChangeFilterIndexCc"] = value; }
    }

    public List<ATTMessageReceiver> LstTempPplReceiver
    {
        get
        {
            return (Session["PplReceiverLst"] == null) ? new List<ATTMessageReceiver>() : (List<ATTMessageReceiver>)Session["PplReceiverLst"];
        }
        set { Session["PplReceiverLst"] = value; }
    }

    public List<ATTMessageReceiver> LstTempPplReceiverCc
    {
        get
        {
            return (Session["PplCcReceiverLst"] == null) ? new List<ATTMessageReceiver>() : (List<ATTMessageReceiver>)Session["PplCcReceiverLst"];
        }
        set { Session["PplCcReceiverLst"] = value; }
    }

    public List<ATTMessageReceiver> LstReceiver
    {
        get
        {
            return (Session["ReceiverLst"] == null) ? new List<ATTMessageReceiver>() : (List<ATTMessageReceiver>)Session["ReceiverLst"];
        }
        set { Session["ReceiverLst"] = value; }
    }

    public List<ATTMessageReceiver> LstReceiverCc
    {
        get
        {
            return (Session["CcReceiverLst"] == null) ? new List<ATTMessageReceiver>() : (List<ATTMessageReceiver>)Session["CcReceiverLst"];
        }
        set { Session["CcReceiverLst"] = value; }
    }

    public ATTMessage objRqdMsg
    {
        get
        {
            return (Session["objRqdMsg"] == null) ? new ATTMessage() : (ATTMessage)Session["objRqdMsg"];
        }
        set { Session["objRqdMsg"] = value; }
    }
   
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

        lblUserName.Text = entryBy;

        if (!IsPostBack)
        {
            LoadControls();

            LoadMsgDetails();
        }

        string date = " <p align= right>चलानी नं : 1001 <br> मिति : " + TodayDate
                      + "  </P><br>";

        LetterDate = date;
                      
    }

    public void LoadControls()
    {
        try
        {
            Session["ReceiverLst"] = null;
            Session["LstMsgAttachment"] = null;

            SetDivHeight(0, "dvReceiver");

            Session["ReceiverCommitteLst"] = BLLMessageGroup.GetGroupList(null,"C","", false);
            grdCategory.DataSource = (List<ATTMessageGroup>)Session["ReceiverCommitteLst"];
            grdCategory.DataBind();

            grdCategoryCc.DataSource = (List<ATTMessageGroup>)Session["ReceiverCommitteLst"];
            grdCategoryCc.DataBind();


            Session["ReceiverGroupLst"] = BLLMessageGroup.GetGroupList(null, "G", "", false);
            grdGroup.DataSource = (List<ATTMessageGroup>)Session["ReceiverGroupLst"];
            grdGroup.DataBind();

            grdGroupCc.DataSource = (List<ATTMessageGroup>)Session["ReceiverGroupLst"];
            grdGroupCc.DataBind();


            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "छान्नुहोस्";
            a.Value = "0";
            ddlUnit.Items.Insert(0, a);
            ddlUnit.Enabled = false;

            chkAllPeople.Attributes.Add("onclick", "CheckUncheckAll(this);");

            chkAllPeople.Enabled = false;
            chkAllCategories.Attributes.Add("onclick", "CheckUncheckAll(this);");
            chkAllGroups.Attributes.Add("onclick", "CheckUncheckAll(this);");


            chkAllCcPeople.Attributes.Add("onclick", "CheckUncheckAll(this);");

            chkAllCcPeople.Enabled = false;
            chkAllCcCategories.Attributes.Add("onclick", "CheckUncheckAll(this);");
            chkAllCcGroups.Attributes.Add("onclick", "CheckUncheckAll(this);");



            chkAllPpl.Attributes.Add("onclick", "CheckUncheckAll(this);");
            chkAllCcPpl.Attributes.Add("onclick", "CheckUncheckAll(this);");

            LoadOrganisation();  
      

            string dateString = BLLDate.GetDateString(0, 0, "_N");

            
            int len = dateString.Length;
            TodayDate = dateString.Substring(0, len - 5);

            LetterDate = null;
            LetterTitle = null;
            LetterBody = null;
            LetterFooter = null;

            LstTempPplReceiver = null;
            LstTempPplReceiverCc = null;

            BeforeChangeFilterIndex = null;
            BeforeChangeOrgID = null;
            BeforeChangeUnitID = null;

            BeforeChangeFilterIndexCc = null;
            BeforeChangeOrgIDCc = null;
            BeforeChangeUnitIDCc = null;

            ddlLetterType.SelectedIndex = 1;

              
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
      
    }

    public void LoadMsgDetails()
    {
        try
        {
            if (objRqdMsg != null)
            {
                txtSubject_rqd.Text = objRqdMsg.Subject;
                lblUserName.Text = objRqdMsg.Sender;

                CollapsiblePanelExtender.CollapsedSize = 0;
                            
                HtmlEditiorSummary.Text = objRqdMsg.Body;

                if (objRqdMsg.LstMsgAttachment.Count > 0)
                {
                    dlUpdAttachment.DataSource = objRqdMsg.LstMsgAttachment;
                    dlUpdAttachment.DataBind();

                    Session["LstMsgAttachment"] = objRqdMsg.LstMsgAttachment;

                }

                HtmlEditiorSummary.Visible = true;
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["msgOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["msgOrgList"] != null)
            {
                this.ddlOrg.DataSource = (List<ATTOrganization>)Session["msgOrgList"];
                this.ddlOrg.DataTextField = "OrgName";
                this.ddlOrg.DataValueField = "OrgId";
                this.ddlOrg.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                ddlOrg.Items.Insert(0, a);
                
                this.ddlOrgCc.DataSource = (List<ATTOrganization>)Session["msgOrgList"];
                this.ddlOrgCc.DataTextField = "OrgName";
                this.ddlOrgCc.DataValueField = "OrgId";
                this.ddlOrgCc.DataBind();
                
                ddlOrgCc.Items.Insert(0, a);

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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

            objMessage.ParentMsgID = objRqdMsg.MessageID;

            if(this.txtSubject_rqd.Text != "")
            {
                objMessage.Subject = txtSubject_rqd.Text.Trim();

            }

            if (this.HtmlEditor1.Text != "")
            {
                 objMessage.Body = objRqdMsg.Body + "<hr> " +   HtmlEditor1.Text;
            }

            if (ddlLetterType.SelectedIndex > 0)
                objMessage.LetterType = ddlLetterType.SelectedValue.ToString();

            //if (ddlFilterTo.SelectedIndex > 0)
            //{
            //    if (ddlOrgTo.SelectedIndex > 0)
            //        objMessage.ToOrgID = int.Parse(ddlOrgTo.SelectedValue.ToString());

            //    if (ddlUnitTo.SelectedIndex > 0)
            //        objMessage.ToUnitID = int.Parse(ddlUnitTo.SelectedValue.ToString());

            //    if (ddlPersonTo.SelectedIndex > 0)
            //        objMessage.ToPID = int.Parse(ddlPersonTo.SelectedValue.ToString());


            //}

            if (ddlFilterFrom.SelectedIndex > 0)
            {
                if (ddlOrgFrom.SelectedIndex > 0)
                    objMessage.FromOrgID = int.Parse(ddlOrgFrom.SelectedValue.ToString());

                if (ddlUnitFrom.SelectedIndex > 0)
                    objMessage.FromUnitID = int.Parse(ddlUnitFrom.SelectedValue.ToString());

                if (ddlPersonFrom.SelectedIndex > 0)
                    objMessage.FromPID = int.Parse(ddlPersonFrom.SelectedValue.ToString());
            }

            if (chkApprove.Checked)
                objMessage.Approve = "Y";
            else
                objMessage.Approve = "N";

            objMessage.Action = "A";
            objMessage.EntryBy = entryBy;

            if (Session["ReceiverLst"] != null && ((List<ATTMessageReceiver>)Session["ReceiverLst"]).Count > 0)
            {
                objMessage.LstMessageReceiver = (List<ATTMessageReceiver>)Session["ReceiverLst"];
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Message";
                this.lblStatusMessage.Text = "Receiver of the message should be selected !!!";
                this.programmaticModalPopup.Show();

                return; 
            }

            if (LstReceiverCc.Count > 0)
            {
                objMessage.LstMessageCcReceiver = LstReceiverCc;
            }

            if (Session["LstMsgAttachment"] != null)
            {
                objMessage.LstMsgAttachment = (List<ATTMessageAttachment>)Session["LstMsgAttachment"];
            }

            if (BLLMessage.SaveMessage(objMessage))
            {
                ClearControls();
                Session["ReceiverLst"] = null;
                Session["LstMsgAttachment"] = null;
                LstReceiverCc = null;

                dlUpdAttachment.DataSource = null;
                dlUpdAttachment.DataBind();

                ddlFilterFrom.SelectedIndex = -1;
                ddlOrgFrom.SelectedIndex = -1;
                ddlUnitFrom.SelectedIndex = -1;
                ddlPersonFrom.SelectedIndex = -1;
                ddlOrgFrom.Enabled = false;
                ddlUnitFrom.Enabled = false;
                ddlPersonFrom.Enabled = false;

                //ddlFilterTo.SelectedIndex = -1;
                //ddlOrgTo.SelectedIndex = -1;
                //ddlUnitTo.SelectedIndex = -1;
                //ddlPersonTo.SelectedIndex = -1;
                //ddlLetterType.SelectedIndex = -1;
                //ddlOrgTo.Enabled = false;
                //ddlUnitTo.Enabled = false;
                //ddlPersonTo.Enabled = false;

                ddlFilterFrom.Enabled = false;

                LetterTitle = "";
                LetterBody = "";
                LetterFooter = "";


                this.lblStatusMessageTitle.Text = "Letter";
                this.lblStatusMessage.Text = "Letter sent successfully !!!";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Letter";
                this.lblStatusMessage.Text = "Letter sent failed !!!";
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
       
    protected void grdPeople_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;


        int i = 1;
        if (ddlFilterReceiver.SelectedIndex == 1)
        {
            while (i < 14)
            {
                if (i == 1)
                    row.Cells[i].Visible = true;
                else
                    row.Cells[i].Visible = false;

                i++;
            }
        }
        else if (ddlFilterReceiver.SelectedIndex == 2)
        {
            while (i < 9)
            {
                if (i == 1)
                    row.Cells[i].Visible = true;
                else
                    row.Cells[i].Visible = false;

                i++;
            }
        }
        else if (ddlFilterReceiver.SelectedIndex == 3)
        {
            row.Cells[2].Visible = false;
        }
       


        //row.Cells[1].Visible = false;
       
        
        
        //if (row.RowType==DataControlRowType.DataRow)
        //{
        //    ((CheckBox)row.FindControl("chkPeople")).Attributes.Add("onClick", "GetID(" + ((CheckBox)row.FindControl("chkPeople")).ClientID + ")");
            
        //}

    }

    protected void grdCategory_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[4].Visible = false;
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    public void ClearControls()
    {
        HtmlEditor1.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

        this.dlUpdAttachment.DataSource = "";
        this.dlUpdAttachment.DataBind();

        this.dlReceiver.DataSource = "";
        this.dlReceiver.DataBind();

        this.dlReceiverCc.DataSource = "";
        this.dlReceiverCc.DataBind();

        Session["LstMsgAttachment"] = null;
        Session["ReceiverLst"] = null;

         
    }
    
    protected void grdPeople_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        
        //row.Cells[1].Visible = false;
        if (row.RowType == DataControlRowType.DataRow)
        {
            //((CheckBox)row.FindControl("chkPeople")).Attributes.Add("onClick", "GetID(" + ((CheckBox)row.FindControl("chkPeople")).ClientID + ")");
            ((CheckBox)row.FindControl("chkPeople")).Attributes.Add("onClick", "SetDivScrollTop('divGridPpl');");

           
        }

      

       

    }
    protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        //row.Cells[1].Visible = false;
        if (row.RowType == DataControlRowType.DataRow)
        {
            //((CheckBox)row.FindControl("chkPeople")).Attributes.Add("onClick", "GetID(" + ((CheckBox)row.FindControl("chkPeople")).ClientID + ")");
            ((CheckBox)row.FindControl("chkCategory")).Attributes.Add("onClick", "SetDivScrollTop('divGridGrp');");

        }
    }

    protected void txtSearchPeople_TextChanged(object sender, EventArgs e)
    {
            string searchValue = txtSearchPeople.Text.Trim();
              
            try
            {
                if (searchValue != "")
                {
                    chkAllPeople.Checked = false;
                    txtSearchPeople.Text = searchValue;

                    int? orgID1 = null;
                    int? unitID = null;

                    if(ddlOrg.SelectedIndex != 0)
                    {
                        orgID1 = int.Parse(ddlOrg.SelectedValue.ToString());
                    }

                   

                    if (ddlFilterReceiver.SelectedIndex == 3)
                    {
                        if (ddlUnit.SelectedIndex != 0)
                        {
                            unitID = int.Parse(ddlUnit.SelectedValue.ToString());
                        }

                        Session["SrchReceiverPersonLst"] = BLLMessagePerson.GetMessagePersonList(orgID1, unitID, searchValue, false);
                        grdPeople.DataSource = (List<ATTMessagePerson>)Session["SrchReceiverPersonLst"];
                        grdPeople.DataBind();
                    }
                    else if (ddlFilterReceiver.SelectedIndex == 2)
                    {
                        Session["SrchReceiverPersonLst"] = BLLOrganizationUnit.SrchOrganizationUnitHead(orgID1, searchValue);
                        grdPeople.DataSource = (List<ATTOrganizationUnit>)Session["SrchReceiverPersonLst"];
                        grdPeople.DataBind();

                    }
                    else if (ddlFilterReceiver.SelectedIndex == 1)
                    {

                        Session["SrchReceiverPersonLst"] = BLLOrganization.GetOrganizationNameList(searchValue);
                        grdPeople.DataSource = (List<ATTOrganization>)Session["SrchReceiverPersonLst"];
                        grdPeople.DataBind();

                    }
                   
                }
                else
                {
                    if (ddlFilterReceiver.SelectedIndex == 3)
                    {
                        grdPeople.DataSource = (List<ATTMessagePerson>)Session["ReceiverPersonLst"];
                        grdPeople.DataBind();
                    }
                    else if (ddlFilterReceiver.SelectedIndex == 2)
                    {
                        grdPeople.DataSource = (List<ATTOrganizationUnit>)Session["ReceiverPersonLst"];
                        grdPeople.DataBind();
                    }
                    else if (ddlFilterReceiver.SelectedIndex == 1)
                    {
                        grdPeople.DataSource = (List<ATTOrganization>)Session["ReceiverPersonLst"];
                        grdPeople.DataBind();

                    }
                }

                ClearReceiverLst("N", "P");
            }
            catch (Exception ex)
            {

                throw (ex);
            }


    }

    protected void txtSearchCategory_TextChanged(object sender, EventArgs e)
    {
        
        string searchValue = txtSearchCategory.Text.Trim();
        try
        {
            if (searchValue != "")
            {
                txtSearchCategory.Text = searchValue;
                chkAllCategories.Checked = false;

                Session["SrchReceiverCommitteLst"] = BLLMessageGroup.GetGroupList(null,"C",searchValue, false);
                grdCategory.DataSource = (List<ATTMessageGroup>)Session["SrchReceiverCommitteLst"];
                grdCategory.DataBind();

            }
            else
            {
                grdCategory.DataSource = (List<ATTMessageGroup>)Session["ReceiverCommitteLst"];
                grdCategory.DataBind();
            }

            ClearReceiverLst("N", "C");
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void ClearReceiverLst(string isCC,string type)
    {
        try
        {
            List<ATTMessageReceiver> lstReceiver = new List<ATTMessageReceiver>();


            if (isCC == "N" && Session["ReceiverLst"] != null)
                lstReceiver = ((List<ATTMessageReceiver>)Session["ReceiverLst"]);
            else if(isCC == "Y")
                lstReceiver = LstReceiverCc;

            if (lstReceiver.Count > 0)
            {
                lstReceiver.RemoveAll(delegate(ATTMessageReceiver obj)
                                                       {
                                                           return (obj.ReceiverType.Trim() == type);
                                                       }

                                                  );
            }

            
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }


    protected void btnOutbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageOutBox.aspx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTMessageAttachment> lstMsgAttachment = new List<ATTMessageAttachment>();
            string AttachedFileName ="";
          
            byte[] ContentFile = null;
            string ContentFileType="";
            string displayName = "";

            if(fupdAttach.HasFile == true)
            {
                if (Session["LstMsgAttachment"] != null)
                {
                    lstMsgAttachment = (List<ATTMessageAttachment>)Session["LstMsgAttachment"];
                }

                ContentFile = this.fupdAttach.FileBytes;
               
                ContentFileType = Path.GetExtension(this.fupdAttach.FileName).Trim();
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

                lstMsgAttachment.Add(new ATTMessageAttachment(ContentFile, ContentFileType, AttachedFileName, displayName,DateTime.Now));





                if (lstMsgAttachment.Count > 0)
                {
                    if (lstMsgAttachment.Count == 1)
                    {
                        dlUpdAttachment.Width = 30;
                    }

                    if (SetDivHeight(lstMsgAttachment.Count, "dvAttachment"))
                    {

                        this.dlUpdAttachment.DataSource = lstMsgAttachment;
                        this.dlUpdAttachment.DataBind();

                        this.dlUpdAttachment.SelectedIndex = -1;

                        Session["LstMsgAttachment"] = lstMsgAttachment;
                    }
                    else
                    {
                        this.lblStatusMessageTitle.Text = "Message";
                        this.lblStatusMessage.Text = "Problem in loading Message attachments !!!";
                        this.programmaticModalPopup.Show();

                        return;

                    }
                }
                else
                {
                    //if (SetDivHeight(0, "dvAttachment"))
                    //{
                        this.dlUpdAttachment.DataSource = "";
                        this.dlUpdAttachment.DataBind();
                        this.dlUpdAttachment.SelectedIndex = -1;

                        Session["LstMsgAttachment"] = null;
                    //}
                    //else
                    //{
                    //    this.lblStatusMessageTitle.Text = "Message";
                    //    this.lblStatusMessage.Text = "Problem in loading Message attachments !!!";
                    //    this.programmaticModalPopup.Show();

                    //    return;

                    //}
                }
           
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
   
    protected void btnInbox_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageInbox.aspx");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTMessageReceiver> lstReceiver;
            lstReceiver = LstReceiver;


            lstReceiver = AddReceiverPeople(lstReceiver,"R");
            lstReceiver = AddReceiverMember(lstReceiver,"R");
            lstReceiver = AddReceiverGroup(lstReceiver,"R");
      
            if (lstReceiver.Count > 0)
            {
                if (SetDivHeight(lstReceiver.Count, "dvReceiver"))
                {

                    dlReceiver.DataSource = lstReceiver;
                    dlReceiver.DataBind();

                    dlReceiver.SelectedIndex = -1;

                    LstReceiver = lstReceiver;
                }
                else
                {
                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "Problem in loading Message receivers !!!";
                    this.programmaticModalPopup.Show();

                    return;

                }
            }
            else
            {
                dlReceiver.DataSource = "";
                dlReceiver.DataBind();
                dlReceiver.SelectedIndex = -1;

                chkAllPeople.Checked = false;
                chkAllCategories.Checked = false;
                chkAllGroups.Checked = false;

                LstReceiver = null;
            }

            SetLetterTitle();



            BeforeChangeFilterIndex = null;
            BeforeChangeOrgID = null;
            BeforeChangeUnitID = null;

            ddlFilterReceiver.SelectedIndex = -1;
            ddlOrg.SelectedIndex = -1;
            ddlUnit.SelectedIndex = -1;
            ddlOrg.Enabled = false;
            ddlUnit.Enabled = false;
            txtSearchPeople.Text = "";

            grdPeople.DataSource = "";
            grdPeople.DataBind();


            btnSend.Enabled = true;
            btnCancel.Enabled = true;
            btnCc.Enabled = true;

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
            ((List<ATTMessageAttachment>)Session["LstMsgAttachment"]).RemoveAt(dlUpdAttachment.SelectedIndex);

            if (Session["LstMsgAttachment"] != null && ((List<ATTMessageAttachment>)Session["LstMsgAttachment"]).Count > 0)
            {

                if (((List<ATTMessageAttachment>)Session["LstMsgAttachment"]).Count == 1)
                {
                    dlUpdAttachment.Width = 30;
                }
                //if (SetDivHeight(((List<ATTMessageAttachment>)Session["LstMsgAttachment"]).Count, "dvAttachment"))
                //{
                    this.dlUpdAttachment.DataSource = Session["LstMsgAttachment"];
                    this.dlUpdAttachment.DataBind();
                    this.dlUpdAttachment.SelectedIndex = -1;
                //}
                //else
                //{
                //    this.lblStatusMessageTitle.Text = "Message";
                //    this.lblStatusMessage.Text = "Problem in loading Message receivers !!!";
                //    this.programmaticModalPopup.Show();

                //    return;

                //}

                                
            }
            else
            {
                SetDivHeight(0, "dvAttachment");
                this.dlUpdAttachment.DataSource = "";
                this.dlUpdAttachment.DataBind();
                this.dlUpdAttachment.SelectedIndex = -1;

                Session["LstMsgAttachment"] = null;
            }
            
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
      
    }
   
    public void ChkTr()
    {
        try
        {
            if (Session["LstMsgAttachment"] != null)
            {
                if (((List<ATTMessageAttachment>)Session["LstMsgAttachment"]).Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showTr", "javascript:showTr('trForAttach');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:hideTr('trForAttach');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:hideTr('trForAttach');", true);
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
       
    }

    public List<ATTMessageReceiver> AddReceiverGroup(List<ATTMessageReceiver> lstReceiver,string type)
    {
        try
        {
            int count = 0;
            int? groupID ;
            int? receiverOrgID ;
            string groupName ;
            string groupDetail = "";
            bool flag ;

            string isCc = "";

            List<ATTMessageReceiver> lst = lstReceiver.FindAll(delegate(ATTMessageReceiver obj)
                                                                      {
                                                                          return (obj.GroupID != null && obj.ReceiverOrgID != null && obj.ReceiverID == null);
                                                                      }

                                                                 );

            GridView grdGroupRqd = new GridView();

            if (type == "R")
            {
                grdGroupRqd = grdGroup;
                isCc = "N";
            }
            else if (type == "Cc")
            {
                grdGroupRqd = grdGroupCc;
                isCc = "Y";
            }



            foreach (GridViewRow gvr in grdGroupRqd.Rows)
            {
                CheckBox chkGroup = (CheckBox)gvr.FindControl("chkGroup");
                flag = false;

                groupID = int.Parse(gvr.Cells[1].Text);
                receiverOrgID = int.Parse(gvr.Cells[2].Text);
                groupDetail = "";
                groupDetail = gvr.Cells[3].Text;

                groupDetail = groupDetail.Replace(" ", "_");

                if (groupDetail.Length > 15)
                    groupName = groupDetail.Substring(0, 10) + "....";
                else
                    groupName = groupDetail;

                if (chkGroup.Checked)
                {
                    if (groupID != null && receiverOrgID != null && flag == false && count <= lst.Count && lst.Count > 0)
                    {
                        flag = lst.Exists(delegate(ATTMessageReceiver obj)
                                                                               {
                                                                                   return (obj.GroupID == groupID
                                                                                           && obj.ReceiverOrgID == receiverOrgID);
                                                                               }

                                                                        );

                    }
                    else
                        flag = false;

                    if (groupID != null && receiverOrgID != null && flag == false)
                        lstReceiver.Add(new ATTMessageReceiver(orgID, null, null, "Y", groupID, receiverOrgID, "", null, "A", entryBy, groupName, groupDetail, "G", isCc));
                    else if (flag)
                    {
                        count++;
                    }
                }
                else
                {
                    if (groupID != null && receiverOrgID != null)
                    {
                        lstReceiver.Remove(
                                                lstReceiver.Find(delegate(ATTMessageReceiver objReceiver)
                                                {
                                                    return objReceiver.GroupID == groupID && objReceiver.ReceiverOrgID == receiverOrgID;
                                                })

                                           );

                        

                        if (type == "R")
                            chkAllGroups.Checked = false;
                        else if (type == "Cc")
                            chkAllCcGroups.Checked = false;
                    }
                }


            }

            return lstReceiver;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public List<ATTMessageReceiver> AddReceiverMember(List<ATTMessageReceiver> lstReceiver,string type)
    {
        try
        {
                int count = 0;
                int? groupID ;
                int? receiverOrgID ;
                string groupName ;
                string groupDetail = "";
                bool flag ;
                string isCc = "";
              
                List<ATTMessageReceiver> lst = lstReceiver.FindAll(delegate(ATTMessageReceiver obj)
                                                                       {
                                                                           return (obj.GroupID != null && obj.ReceiverOrgID != null && obj.ReceiverID == null);
                                                                       }

                                                                  );


                //lstReceiver.Remove(
                //                                    lstReceiver.Find(delegate(ATTMessageReceiver objReceiver)
                //                                    {
                //                                        return objReceiver.GroupID == groupID && objReceiver.ReceiverOrgID == receiverOrgID;
                //                                    })

                //                               );

                GridView grdCategoryRqd = new GridView();

                if (type == "R")
                {
                    grdCategoryRqd = grdCategory;
                    isCc = "N";
                }
                else if (type == "Cc")
                {
                    grdCategoryRqd = grdCategoryCc;
                    isCc = "Y";
                }




                foreach (GridViewRow gvr in grdCategoryRqd.Rows)
                {
                    CheckBox chkCategory = (CheckBox)gvr.FindControl("chkCategory");

                    flag = false;

                    groupID = int.Parse(gvr.Cells[1].Text);
                    receiverOrgID = int.Parse(gvr.Cells[2].Text);
                    groupDetail = "";
                    groupDetail = gvr.Cells[3].Text;

                    groupDetail = groupDetail.Replace(" ", "_");

                    if (groupDetail.Length > 15)
                        groupName = groupDetail.Substring(0, 10) + "....";
                    else
                        groupName = groupDetail;

                    if (chkCategory.Checked)
                    {
                        if (groupID != null && receiverOrgID != null && flag == false && count <= lst.Count && lst.Count > 0)
                        {
                            flag = lst.Exists(delegate(ATTMessageReceiver obj)
                                                                                   {
                                                                                       return (obj.GroupID == groupID
                                                                                               && obj.ReceiverOrgID == receiverOrgID);
                                                                                   }

                                                                            );

                        }
                        else
                            flag = false;

                        if (groupID != null && receiverOrgID != null && flag == false)
                            lstReceiver.Add(new ATTMessageReceiver(orgID, null, null, "Y", groupID, receiverOrgID, "", null, "A", entryBy, groupName, groupDetail, "C", isCc));
                        else if (flag)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (groupID != null && receiverOrgID != null)
                        {
                            lstReceiver.Remove(
                                                    lstReceiver.Find(delegate(ATTMessageReceiver objReceiver)
                                                    {
                                                        return objReceiver.GroupID == groupID && objReceiver.ReceiverOrgID == receiverOrgID;
                                                    })

                                               );

                            

                            if (type == "R")
                                chkAllCategories.Checked = false;
                            else if (type == "Cc")
                                chkAllCcCategories.Checked = false;


                        }
                    }


                }

                return lstReceiver;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public List<ATTMessageReceiver> AddReceiverPeople(List<ATTMessageReceiver> lstReceiver,string type)
    {
        try
        {
            int count = 0;
            string detailName = "";
            string displayName = "";
            bool flag;
            string isCc = "";

            List<ATTMessageReceiver> lst = lstReceiver.FindAll(delegate(ATTMessageReceiver obj)
                                                                   {
                                                                       return (obj.OtherReceiverID != null);
                                                                   }

                                                              );


            GridView grdPeopleRqd = new GridView();

            if (type == "R")
            {
                grdPeopleRqd = grdPeople;
                isCc = "N";

                if (LstTempPplReceiver.Count > 0)
                    RemoveUncheckedPpl(lstReceiver, type);
            }
            else if (type == "Cc")
            {
                grdPeopleRqd = grdPeopleCc;
                isCc = "Y";

                if (LstTempPplReceiverCc.Count > 0)
                    RemoveUncheckedPpl(lstReceiver, type);
            }



            foreach (GridViewRow gvr in grdPeopleRqd.Rows)
            {
                CheckBox chkPeople = (CheckBox)gvr.FindControl("chkPeople");

                flag = false;


                int? receiverOrgID = null;
                int? receiverUnitID = null;
                int? receiverID = null;



                if (chkPeople.Checked)
                {
                    if (type == "R")
                    {
                        if (BeforeChangeFilterIndex == 3)
                        {
                            //receiverOrgID = int.Parse(ddlOrg.SelectedValue.ToString());
                            //receiverUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                            receiverOrgID = BeforeChangeOrgID;
                            receiverUnitID = BeforeChangeUnitID;

                            receiverID = int.Parse(gvr.Cells[2].Text);
                        }
                        else if (BeforeChangeFilterIndex == 2)
                        {
                            //receiverOrgID = int.Parse(gvr.Cells[2].Text);
                            //receiverUnitID = int.Parse(gvr.Cells[6].Text);

                            receiverOrgID = BeforeChangeOrgID;
                            receiverID = int.Parse(gvr.Cells[4].Text);

                        }
                        else if (BeforeChangeFilterIndex == 1)
                        {

                            //receiverOrgID = int.Parse(gvr.Cells[5].Text);
                            //receiverUnitID = null;
                        }
                    }
                    else if (type == "Cc")
                    {
                        if (BeforeChangeFilterIndexCc == 3)
                        {
                            //receiverID = int.Parse(gvr.Cells[2].Text);

                            receiverOrgID = BeforeChangeOrgIDCc;
                            receiverUnitID = BeforeChangeUnitIDCc;

                            receiverID = int.Parse(gvr.Cells[2].Text);
                        }
                        else if (BeforeChangeFilterIndexCc == 2)
                        {
                            //receiverID = int.Parse(gvr.Cells[4].Text);

                            receiverOrgID = BeforeChangeOrgIDCc;
                            receiverID = int.Parse(gvr.Cells[4].Text);

                        }
                        else if (BeforeChangeFilterIndexCc == 1)
                        {
                            // receiverID = int.Parse(gvr.Cells[2].Text);
                        }
                    }


                    detailName = gvr.Cells[1].Text;



                    detailName = detailName.Replace(" ", "_");

                    if (detailName.Length > 15)
                        displayName = detailName.Substring(0, 10) + "....";
                    else
                        displayName = detailName;



                    if (receiverID != null && count <= lst.Count && lst.Count > 0)
                    {
                        flag = lst.Exists(delegate(ATTMessageReceiver obj)
                                               {
                                                   return (obj.OtherReceiverID == receiverID && obj.OtherUnitID == receiverUnitID && obj.OtherOrgID == receiverOrgID);
                                               }

                                          );
                    }
                    else
                        flag = false;


                    if (receiverID != null && flag == false)
                    {
                        lstReceiver.Add(new ATTMessageReceiver(orgID, null, null, "N", null, null, "", receiverOrgID, receiverUnitID, receiverID, "A", entryBy, displayName, detailName, "P", isCc));


                        ATTMessageReceiver objMsgReceiver = new ATTMessageReceiver();
                        objMsgReceiver.OtherOrgID = receiverOrgID;
                        objMsgReceiver.OtherUnitID = receiverUnitID;
                        objMsgReceiver.OtherReceiverID = receiverID;
                        objMsgReceiver.DetailName = detailName;

                        if (objMsgReceiver != null)
                        {
                            if (type == "R")
                            {
                                List<ATTMessageReceiver> lstTmp = LstTempPplReceiver;
                                lstTmp.Add(objMsgReceiver);

                                LstTempPplReceiver = lstTmp;
                            }
                            else if (type == "Cc")
                            {
                                List<ATTMessageReceiver> lstTmpCc = LstTempPplReceiverCc;
                                lstTmpCc.Add(objMsgReceiver);

                                LstTempPplReceiverCc = lstTmpCc;
                            }
                        }

                    }

                    else if (flag)
                    {
                        count++;
                    }

                }


                chkPeople.Checked = false;

            }

            if (type == "R")
            {
                chkAllPeople.Checked = false;

                if (LstTempPplReceiver.Count > 0)
                {
                    grdTmp.DataSource = LstTempPplReceiver;
                    grdTmp.DataBind();

                    grdTmp.SelectedIndex = -1;
                    grdTmp.Visible = true;
                }
            }
            else if (type == "Cc")
            {
                chkAllCcPeople.Checked = false;

                if (LstTempPplReceiverCc.Count > 0)
                {
                    grdCcTmp.DataSource = LstTempPplReceiverCc;
                    grdCcTmp.DataBind();

                    grdCcTmp.SelectedIndex = -1;
                    grdCcTmp.Visible = true;
                }
            }

            return lstReceiver;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

   
    protected void dlReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LstReceiver.RemoveAt(dlReceiver.SelectedIndex);

            //((List<ATTMessageReceiver>)Session["ReceiverLst"]).RemoveAt(dlReceiver.SelectedIndex);

            if (LstReceiver != null & LstReceiver.Count > 0)
            {

                if (SetDivHeight(LstReceiver.Count, "dvReceiver"))
                {
                    dlReceiver.DataSource = LstReceiver;
                    dlReceiver.DataBind();

                    dlReceiver.SelectedIndex = -1;

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "Problem in loading Message receivers !!!";
                    this.programmaticModalPopup.Show();

                    return;

                }
            }
            else
            {
                this.dlReceiver.DataSource = "";
                this.dlReceiver.DataBind();
                dlReceiver.SelectedIndex = -1;

                LstReceiver = null;
            }

            SetLetterTitle();

        }
        catch (Exception ex)
        {

            throw (ex);
        }
      
    }

    protected void imgBtnRemove1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string arguments = ((ImageButton)sender).CommandArgument.ToString();

            string[] IDs = arguments.Split(new char[] { '/' });

            int? receiverID = IDs[0].ToString() == "" ? 0 : Convert.ToInt32(IDs[0]);
            int? receiverOrgID = IDs[1].ToString() == "" ? 0 : Convert.ToInt32(IDs[1]);
            int? groupID = IDs[2].ToString() == "" ? 0 : Convert.ToInt32(IDs[2]);
            string receiverType = IDs[3].ToString();

            string isCC = IDs[4].ToString();

            if (receiverType == "P" && receiverID != 0)
            {
                GridView grdPeopleRqd = new GridView();

                DropDownList ddlFilterRqd = new DropDownList();

                List<ATTMessageReceiver> lstTmp = new List<ATTMessageReceiver>();

                if (isCC == "N")
                {
                    grdPeopleRqd = grdTmp;
                    ddlFilterRqd = ddlFilterReceiver;

                    lstTmp = LstTempPplReceiver;
                }
                else if (isCC == "Y")
                {
                    grdPeopleRqd = grdCcTmp;
                    ddlFilterRqd = ddlFilterCcReceiver;

                    lstTmp = LstTempPplReceiverCc;
                }


                foreach (GridViewRow gvr in grdPeopleRqd.Rows)
                {
                    CheckBox chkPeople = (CheckBox)gvr.FindControl("chkPeople");

                    int? receiverID1 = null;
                    receiverID1 = int.Parse(gvr.Cells[3].Text);


                    if (receiverID == receiverID1)
                    {
                        lstTmp.RemoveAt(gvr.RowIndex);
                        break;
                    }
                }

                if (isCC == "N")
                {
                    if (lstTmp.Count > 0)
                    {
                        grdTmp.DataSource = lstTmp;
                        grdTmp.DataBind();

                    }
                    else
                    {
                        grdTmp.DataSource = "";
                        grdTmp.DataBind();
                    }
                }
                else if (isCC == "Y")
                {
                    if (lstTmp.Count > 0)
                    {
                        grdCcTmp.DataSource = lstTmp;
                        grdCcTmp.DataBind();

                    }
                    else
                    {
                        grdCcTmp.DataSource = "";
                        grdCcTmp.DataBind();
                    }
                }

            }
            else if (receiverOrgID != 0 && groupID != 0)
            {
                if (receiverType == "C")
                {
                    GridView grdCategoryRqd = new GridView();

                    if (isCC == "N")
                    {
                        grdCategoryRqd = grdCategory;
                    }
                    else if (isCC == "Y")
                    {
                        grdCategoryRqd = grdCategoryCc;
                    }


                    foreach (GridViewRow gvr in grdCategoryRqd.Rows)
                    {
                        CheckBox chkCategory = (CheckBox)gvr.FindControl("chkCategory");
                        int? groupID1 = int.Parse(gvr.Cells[1].Text);
                        int? receiverOrgID1 = int.Parse(gvr.Cells[2].Text);

                        if (groupID == groupID1 && receiverOrgID == receiverOrgID1)
                        {
                            chkCategory.Checked = false;

                            if (isCC == "N")
                                chkAllCategories.Checked = false;
                            else if (isCC == "Y")
                                chkAllCcCategories.Checked = false;

                            break;
                        }
                    }
                }
                else if (receiverType == "G")
                {

                    GridView grdGroupRqd = new GridView();

                    if (isCC == "N")
                    {
                        grdGroupRqd = grdGroup;
                    }
                    else if (isCC == "Y")
                    {
                        grdGroupRqd = grdGroupCc;
                    }


                    foreach (GridViewRow gvr in grdGroupRqd.Rows)
                    {
                        CheckBox chkGroup = (CheckBox)gvr.FindControl("chkGroup");
                        int? groupID2 = int.Parse(gvr.Cells[1].Text);
                        int? receiverOrgID2 = int.Parse(gvr.Cells[2].Text);

                        if (groupID == groupID2 && receiverOrgID == receiverOrgID2)
                        {
                            chkGroup.Checked = false;


                            if (isCC == "N")
                                chkAllGroups.Checked = false;
                            else if (isCC == "Y")
                                chkAllCcGroups.Checked = false;
                            break;
                        }
                    }
                }
            }

            

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public bool SetDivHeight(int count,string val)
    {
        try
        {
            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','0');", true);

                if (val == "dvReceiver")
                    dlReceiver.Height = 0;
                else if (val == "dvReceiverCc")
                    dlReceiverCc.Height = 0;
                else
                    dlUpdAttachment.Height = 0;

                return true;
            
            }
            else if (count == 1)
            {
                if (val == "dvReceiver")
                    dlReceiver.Width = 40;
                else if (val == "dvReceiverCc")
                    dlReceiverCc.Width = 40;
                else
                    dlUpdAttachment.Width = 30;

                return true;
            }
            else if (count > 1)
            {

                if (count > 4)
                {
                    //dlReceiver.Width = 500;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','55');", true);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','48');", true);


                }
                else if (count > 1 && count <= 4)
                {
                    //if (count == 2)
                    //    dlReceiver.Width = 80;
                    //else if (count == 3)
                    //    dlReceiver.Width = 120;


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SetDivHeight", "javascript:SetDivHeight('" + val + "','27');", true);

                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void imgBtnRemove_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void txtSearchGroup_TextChanged(object sender, EventArgs e)
    {
        string searchValue = txtSearchGroup.Text.Trim();
        try
        {
            if (searchValue != "")
            {
                txtSearchGroup.Text = searchValue;
                chkAllGroups.Checked = false;

                Session["SrchReceiverGroupLst"] = BLLMessageGroup.GetGroupList(null, "G", searchValue, false);
                grdGroup.DataSource = (List<ATTMessageGroup>)Session["SrchReceiverGroupLst"];
                grdGroup.DataBind();
            }
            else
            {
                grdGroup.DataSource = (List<ATTMessageGroup>)Session["ReceiverGroupLst"];
                grdGroup.DataBind();
            }

            ClearReceiverLst("N","G");
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void grdGroup_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[4].Visible = false;
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ReloadPpl();


            if (ddlOrg.SelectedIndex > 0 && ddlFilterReceiver.SelectedIndex == 2)
            {

                BeforeChangeOrgID = int.Parse(ddlOrg.SelectedValue.ToString());

                Session["ReceiverPersonLst"] = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrg.SelectedValue.ToString()), null);


                if (Session["ReceiverPersonLst"] != null && ((List<ATTOrganizationUnit>)Session["ReceiverPersonLst"]).Count > 0)
                {
                    grdPeople.Controls.Clear();
                    grdPeople.AutoGenerateColumns = true;
                    grdPeople.DataSource = (List<ATTOrganizationUnit>)Session["ReceiverPersonLst"];
                    grdPeople.DataBind();

                    chkAllPeople.Enabled = true;
                }
                else
                {
                    grdPeople.DataSource = "";
                    grdPeople.DataBind();

                    chkAllPeople.Enabled = false;
                }

                chkAllPeople.Checked = false;
            }
            else
            {
                grdPeople.DataSource = "";
                grdPeople.DataBind();

                chkAllPeople.Checked = false;
                chkAllPeople.Enabled = false;
            }

            if (ddlOrg.SelectedIndex > 0 && ddlFilterReceiver.SelectedIndex == 3)
            {
                LoadUnit("R");
            }

            BeforeChangeFilterIndex = ddlFilterReceiver.SelectedIndex;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ReloadPpl();

            if (ddlUnit.SelectedIndex > 0)
            {
                BeforeChangeOrgID = int.Parse(ddlOrg.SelectedValue.ToString());
                BeforeChangeUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                LoadReceiverPersonLst(int.Parse(ddlOrg.SelectedValue.ToString()), int.Parse(ddlUnit.SelectedValue.ToString()), "", false, "R");
            }
            else
            {
                // LoadReceiverPersonLst(int.Parse(ddlOrg.SelectedValue.ToString()),null, "", false,"R");
                grdPeople.DataSource = "";
                grdPeople.DataBind();

                chkAllPeople.Checked = false;
                chkAllPeople.Enabled = false;
            }


            BeforeChangeFilterIndex = ddlFilterReceiver.SelectedIndex;

        }
        catch (Exception ex)
        {

            throw (ex);
        }

        
    }

    public void ClearReceiverPeople(string type)
    {
        try
        {
            int? receiverID = null;

            if (type == "R")
            {
                if (Session["ReceiverLst"] != null)
                {
                    List<ATTMessageReceiver> lstReceiver = new List<ATTMessageReceiver>();
                    lstReceiver = (List<ATTMessageReceiver>)Session["ReceiverLst"];


                    foreach (GridViewRow gvr in grdPeople.Rows)
                    {
                        CheckBox chkPeople = (CheckBox)gvr.FindControl("chkPeople");

                        receiverID = int.Parse(gvr.Cells[1].Text);



                        if (chkPeople.Checked)
                        {

                            if (receiverID != null)
                            {
                                lstReceiver.Remove(
                                                        lstReceiver.Find(delegate(ATTMessageReceiver objReceiver)
                                                        {
                                                            return objReceiver.OtherReceiverID == receiverID;
                                                        })

                                                  );

                                chkAllPeople.Checked = false;
                            }
                        }

                    }
                }
            }
            else if (type == "Cc")
            {
                if (Session["CcReceiverLst"] != null)
                {
                    List<ATTMessageReceiver> lstReceiver = new List<ATTMessageReceiver>();
                    lstReceiver = (List<ATTMessageReceiver>)Session["CcReceiverLst"];


                    foreach (GridViewRow gvr in grdPeople.Rows)
                    {
                        CheckBox chkPeople = (CheckBox)gvr.FindControl("chkPeopleCc");

                        receiverID = int.Parse(gvr.Cells[1].Text);



                        if (chkPeople.Checked)
                        {

                            if (receiverID != null)
                            {
                                lstReceiver.Remove(
                                                        lstReceiver.Find(delegate(ATTMessageReceiver objReceiver)
                                                        {
                                                            return objReceiver.OtherReceiverID == receiverID;
                                                        })

                                                  );

                                chkAllCcPeople.Checked = false;
                            }
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadUnit(string type)
    {
        try
        {
            if (type == "R")
            {
                //Session["msgUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(ddlOrg.SelectedValue.ToString()), null);

                Session["msgUnitList"] =  BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrg.SelectedValue.ToString()), null);

                if (Session["msgUnitList"] != null)
                {
                    this.ddlUnit.DataSource = (List<ATTOrganizationUnit>)Session["msgUnitList"];
                    this.ddlUnit.DataTextField = "UnitName";
                    this.ddlUnit.DataValueField = "UnitID";
                    this.ddlUnit.DataBind();

                    ListItem a = new ListItem();
                    a.Selected = true;
                    a.Text = "छान्नुहोस्";
                    a.Value = "0";
                    ddlUnit.Items.Insert(0, a);

                    ddlUnit.Enabled = true;

                    chkAllCcPeople.Enabled = true;

                }
                else
                {
                    ListItem a = new ListItem();
                    a.Selected = true;
                    a.Text = "छान्नुहोस्";
                    a.Value = "0";
                    ddlUnit.Items.Insert(0, a);

                    ddlUnit.Enabled = false;

                    chkAllCcPeople.Enabled = false;

                }

                chkAllCcPeople.Checked = false;
            }
            else if(type == "Cc")
            {
                //Session["CcmsgUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(ddlOrgCc.SelectedValue.ToString()), null);

                Session["CcmsgUnitList"] = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrgCc.SelectedValue.ToString()), null);



                if (Session["CcmsgUnitList"] != null)
                {
                    this.ddlUnitCc.DataSource = (List<ATTOrganizationUnit>)Session["CcmsgUnitList"];
                    this.ddlUnitCc.DataTextField = "UnitName";
                    this.ddlUnitCc.DataValueField = "UnitID";
                    this.ddlUnitCc.DataBind();

                    ListItem a = new ListItem();
                    a.Selected = true;
                    a.Text = "छान्नुहोस्";
                    a.Value = "0";
                    ddlUnitCc.Items.Insert(0, a);

                    ddlUnitCc.Enabled = true;
                }
                else
                {
                    ListItem a = new ListItem();
                    a.Selected = true;
                    a.Text = "छान्नुहोस्";
                    a.Value = "0";
                    ddlUnitCc.Items.Insert(0, a);

                    ddlUnitCc.Enabled = false;
                }

            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public void LoadReceiverPersonLst(int? orgID1, int? unitID,string searchValue,bool flag,string type)
    {
        try
        {
            if (type == "R")
            {
                Session["ReceiverPersonLst"] = BLLMessagePerson.GetMessagePersonList(orgID1, unitID, searchValue, flag);

                if (((List<ATTMessagePerson>)Session["ReceiverPersonLst"]).Count > 0)
                {
                    grdPeople.AutoGenerateColumns = true;
                    grdPeople.DataSource = (List<ATTMessagePerson>)Session["ReceiverPersonLst"];
                    grdPeople.DataBind();

                    chkAllPeople.Enabled = true;
                }
                else
                {
                    grdPeople.DataSource = "";
                    grdPeople.DataBind();

                    chkAllPeople.Enabled = false;
                }
            }
            else if (type == "Cc")
            {
                Session["CcReceiverPersonLst"] = BLLMessagePerson.GetMessagePersonList(orgID1, unitID, searchValue, flag);

                if (((List<ATTMessagePerson>)Session["CcReceiverPersonLst"]).Count > 0)
                {
                    grdPeopleCc.AutoGenerateColumns = true;
                    grdPeopleCc.DataSource = (List<ATTMessagePerson>)Session["CcReceiverPersonLst"];
                    grdPeopleCc.DataBind();

                    chkAllCcPeople.Enabled = true;
                }
                else
                {
                    grdPeopleCc.DataSource = "";
                    grdPeopleCc.DataBind();

                    chkAllCcPeople.Enabled = false;
                }
            }

         
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnTo_Click(object sender, EventArgs e)
    {

        btnSend.Enabled = false;
        btnCancel.Enabled = false;

        btnCc.Enabled = false;

    }

    protected void btnCc_Click(object sender, EventArgs e)
    {
        btnSend.Enabled = false;
        btnCancel.Enabled = false;

        btnTo.Enabled = false;

    }
    protected void btnCloseCc_Click(object sender, EventArgs e)
    {
        List<ATTMessageReceiver> lstReceiverCc;
        lstReceiverCc = LstReceiverCc;


        lstReceiverCc = AddReceiverPeople(lstReceiverCc, "Cc");
        lstReceiverCc = AddReceiverMember(lstReceiverCc, "Cc");
        lstReceiverCc = AddReceiverGroup(lstReceiverCc, "Cc");

        if (lstReceiverCc.Count > 0)
        {
            if (SetDivHeight(lstReceiverCc.Count, "dvReceiverCc"))
            {

                dlReceiverCc.DataSource = lstReceiverCc;
                dlReceiverCc.DataBind();

                dlReceiverCc.SelectedIndex = -1;

                LstReceiverCc = lstReceiverCc;
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Message";
                this.lblStatusMessage.Text = "Problem in loading Message receivers !!!";
                this.programmaticModalPopup.Show();

                return;

            }
        }
        else
        {        
            dlReceiverCc.DataSource = "";
            dlReceiverCc.DataBind();
            dlReceiverCc.SelectedIndex = -1;

            chkAllCcPeople.Checked = false;
            chkAllCcCategories.Checked = false;
            chkAllCcGroups.Checked = false;

            LstReceiverCc = null;
          
        }

        SetLetterTitle();


        BeforeChangeFilterIndexCc = null;
        BeforeChangeOrgIDCc = null;
        BeforeChangeUnitIDCc = null;

        ddlFilterCcReceiver.SelectedIndex = -1;
        ddlOrgCc.SelectedIndex = -1;
        ddlUnitCc.SelectedIndex = -1;
        ddlOrgCc.Enabled = false;
        ddlUnitCc.Enabled = false;
        txtSearchPeopleCc.Text = "";

        grdPeopleCc.DataSource = "";
        grdPeopleCc.DataBind();

        btnSend.Enabled = true;
        btnCancel.Enabled = true;
        btnTo.Enabled = true;


    }
    protected void ddlOrgCc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ReloadPplCc();

            if (ddlOrgCc.SelectedIndex > 0 && ddlFilterCcReceiver.SelectedIndex == 2)
            {

                BeforeChangeOrgIDCc = int.Parse(ddlOrgCc.SelectedValue.ToString());

                Session["CcReceiverPersonLst"] = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrgCc.SelectedValue.ToString()), null);

                if (Session["CcReceiverPersonLst"] != null && ((List<ATTOrganizationUnit>)Session["CcReceiverPersonLst"]).Count > 0)
                {
                    grdPeopleCc.Controls.Clear();

                    grdPeopleCc.AutoGenerateColumns = true;
                    grdPeopleCc.DataSource = (List<ATTOrganizationUnit>)Session["CcReceiverPersonLst"];
                    grdPeopleCc.DataBind();

                    chkAllCcPeople.Enabled = true;
                }
                else
                {
                    grdPeopleCc.DataSource = "";
                    grdPeopleCc.DataBind();

                    chkAllCcPeople.Enabled = false;
                }

                chkAllCcPeople.Checked = false;
            }
            else
            {
                grdPeopleCc.DataSource = "";
                grdPeopleCc.DataBind();

                chkAllCcPeople.Enabled = false;
                chkAllCcPeople.Checked = false;
            }

            //ClearReceiverPeople("Cc");


            if (ddlOrgCc.SelectedIndex > 0 && ddlFilterCcReceiver.SelectedIndex == 3)
            {
                LoadUnit("Cc");
            }


            BeforeChangeFilterIndexCc = ddlFilterCcReceiver.SelectedIndex;


        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void ddlUnitCc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ClearReceiverPeople("Cc");

            ReloadPplCc();

            if (ddlUnitCc.SelectedIndex > 0)
            {
                BeforeChangeOrgIDCc = int.Parse(ddlOrgCc.SelectedValue.ToString());
                BeforeChangeUnitIDCc = int.Parse(ddlUnitCc.SelectedValue.ToString());

                LoadReceiverPersonLst(int.Parse(ddlOrgCc.SelectedValue.ToString()), int.Parse(ddlUnitCc.SelectedValue.ToString()), "", false, "Cc");
            }
            else
            {
                //LoadReceiverPersonLst(int.Parse(ddlOrgCc.SelectedValue.ToString()), null, "", false, "Cc");

                grdPeopleCc.DataSource = "";
                grdPeopleCc.DataBind();

                chkAllCcPeople.Checked = false;
                chkAllCcPeople.Enabled = false;
            }


            BeforeChangeFilterIndexCc = ddlFilterCcReceiver.SelectedIndex;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void dlReceiverCc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LstReceiverCc.RemoveAt(dlReceiverCc.SelectedIndex);

            if (LstReceiverCc.Count > 0)
            {

                if (SetDivHeight(LstReceiverCc.Count, "dvReceiverCc"))
                {
                    dlReceiverCc.DataSource = LstReceiverCc;
                    dlReceiverCc.DataBind();

                    dlReceiverCc.SelectedIndex = -1;

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "Message";
                    this.lblStatusMessage.Text = "Problem in loading Message receivers !!!";
                    this.programmaticModalPopup.Show();

                    return;

                }
            }
            else
            {
                dlReceiverCc.DataSource = "";
                dlReceiverCc.DataBind();
                dlReceiverCc.SelectedIndex = -1;

                LstReceiverCc = null;
                
            }

            SetLetterTitle();

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void txtSearchPeopleCc_TextChanged(object sender, EventArgs e)
    {

        string searchValue = txtSearchPeopleCc.Text.Trim();

        try
        {
            if (searchValue != "")
            {
                txtSearchPeopleCc.Text = searchValue;

                chkAllCcPeople.Checked = false;

                int? orgID1 = null;
                int? unitID = null;

                if (ddlOrgCc.SelectedIndex != 0)
                {
                    orgID1 = int.Parse(ddlOrgCc.SelectedValue.ToString());
                }
               
                if (ddlFilterCcReceiver.SelectedIndex == 3)
                {
                    if (ddlUnitCc.SelectedIndex != 0)
                    {
                        unitID = int.Parse(ddlUnitCc.SelectedValue.ToString());
                    }

                    Session["SrchCcReceiverPersonLst"] = BLLMessagePerson.GetMessagePersonList(orgID1, unitID, searchValue, false);
                    grdPeopleCc.DataSource = (List<ATTMessagePerson>)Session["SrchCcReceiverPersonLst"];
                    grdPeopleCc.DataBind();
                }
                else if (ddlFilterCcReceiver.SelectedIndex == 2)
                {
                    Session["SrchCcReceiverPersonLst"] = BLLOrganizationUnit.SrchOrganizationUnitHead(orgID1, searchValue);
                    grdPeopleCc.DataSource = (List<ATTOrganizationUnit>)Session["SrchCcReceiverPersonLst"];
                    grdPeopleCc.DataBind();

                }
                else if (ddlFilterCcReceiver.SelectedIndex == 1)
                {

                    Session["SrchCcReceiverPersonLst"] = BLLOrganization.GetOrganizationNameList(searchValue);
                    grdPeopleCc.DataSource = (List<ATTOrganization>)Session["SrchCcReceiverPersonLst"];
                    grdPeopleCc.DataBind();

                }


            }
            else
            {
                if (ddlFilterCcReceiver.SelectedIndex == 3)
                {
                    grdPeopleCc.DataSource = (List<ATTMessagePerson>)Session["CcReceiverPersonLst"];
                    grdPeopleCc.DataBind();
                }
                else if (ddlFilterCcReceiver.SelectedIndex == 2)
                {
                    grdPeopleCc.DataSource = (List<ATTOrganizationUnit>)Session["CcReceiverPersonLst"];
                    grdPeopleCc.DataBind();
                }
                else if (ddlFilterCcReceiver.SelectedIndex == 1)
                {
                    grdPeopleCc.DataSource = (List<ATTOrganization>)Session["CcReceiverPersonLst"];
                    grdPeopleCc.DataBind();

                }
            }

            ClearReceiverLst("Y", "P");
        }
        catch (Exception ex)
        {

            throw (ex);
        }


    }
    protected void txtSearchCategoryCc_TextChanged(object sender, EventArgs e)
    {
        string searchValue = txtSearchCategoryCc.Text.Trim();
        try
        {
            if (searchValue != "")
            {
                txtSearchCategoryCc.Text = searchValue;
                chkAllCcCategories.Checked = false;

                Session["SrchCcReceiverCommitteLst"] = BLLMessageGroup.GetGroupList(null, "C", searchValue, false);
                grdCategoryCc.DataSource = (List<ATTMessageGroup>)Session["SrchCcReceiverCommitteLst"];
                grdCategoryCc.DataBind();
            }
            else
            {
                grdCategoryCc.DataSource = (List<ATTMessageGroup>)Session["ReceiverCommitteLst"];
                grdCategoryCc.DataBind();
            }

            ClearReceiverLst("Y", "C");
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void txtSearchGroupCc_TextChanged(object sender, EventArgs e)
    {
        string searchValue = txtSearchGroupCc.Text.Trim();
        try
        {
            if (searchValue != "")
            {
                txtSearchGroupCc.Text = searchValue;
                chkAllCcGroups.Checked = false;

                Session["SrchCcReceiverGroupLst"] = BLLMessageGroup.GetGroupList(null, "G", searchValue, false);
                grdGroupCc.DataSource = (List<ATTMessageGroup>)Session["SrchCcReceiverGroupLst"];
                grdGroupCc.DataBind();
            }
            else
            {
                grdGroupCc.DataSource = (List<ATTMessageGroup>)Session["ReceiverGroupLst"];
                grdGroupCc.DataBind();
            }

            ClearReceiverLst("Y","G");
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void ddlFilterReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ReloadPpl();

            ddlOrg.SelectedIndex = -1;
            ddlUnit.SelectedIndex = -1;
            ddlOrg.Enabled = false;
            ddlUnit.Enabled = false;
            txtSearchPeople.Text = "";

            if (ddlFilterReceiver.SelectedIndex == 1)
            {
                grdPeople.Controls.Clear();
                grdPeople.AutoGenerateColumns = true;

                Session["ReceiverPersonLst"] = BLLOrganization.GetOrganizationNameList();
                grdPeople.DataSource = (List<ATTOrganization>)Session["ReceiverPersonLst"];
                grdPeople.DataBind();

                chkAllPeople.Enabled = true;

                BeforeChangeOrgID = null;
                BeforeChangeUnitID = null;

            }
            else if (ddlFilterReceiver.SelectedIndex == 2 || ddlFilterReceiver.SelectedIndex == 3)
            {
                ddlOrg.Enabled = true;
                ddlOrg.SelectedIndex = -1;

                grdPeople.DataSource = "";
                grdPeople.DataBind();

                chkAllPeople.Enabled = false;
                chkAllPeople.Checked = false;

            }
            else
            {
                grdPeople.DataSource = "";
                grdPeople.DataBind();

                ddlOrgCc.SelectedIndex = -1;
                ddlUnitCc.SelectedIndex = -1;

                chkAllPeople.Enabled = false;
                chkAllPeople.Checked = false;

                Session["ReceiverPersonLst"] = null;

            }

            BeforeChangeFilterIndex = ddlFilterReceiver.SelectedIndex;
        }
        catch (Exception ex)
        {

            throw (ex);
        }

    
    }

    protected void ddlFilterCcReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ReloadPplCc();


            ddlOrgCc.SelectedIndex = -1;
            ddlUnitCc.SelectedIndex = -1;
            ddlOrgCc.Enabled = false;
            ddlUnitCc.Enabled = false;

            txtSearchPeopleCc.Text = "";

            if (ddlFilterCcReceiver.SelectedIndex == 1)
            {
                grdPeopleCc.Controls.Clear();
                grdPeopleCc.AutoGenerateColumns = true;
                grdPeopleCc.DataSource = BLLOrganization.GetOrganizationNameList();
                grdPeopleCc.DataBind();

                chkAllCcPeople.Enabled = true;
                chkAllCcPeople.Checked = false;


            }
            else if (ddlFilterCcReceiver.SelectedIndex == 2 || ddlFilterCcReceiver.SelectedIndex == 3)
            {
                ddlOrgCc.Enabled = true;
                ddlOrgCc.SelectedIndex = -1;

                grdPeopleCc.DataSource = "";
                grdPeopleCc.DataBind();

                chkAllCcPeople.Enabled = false;
                chkAllCcPeople.Checked = false;
            }
            else
            {
                grdPeopleCc.DataSource = "";
                grdPeopleCc.DataBind();

                ddlOrgCc.SelectedIndex = -1;
                ddlUnitCc.SelectedIndex = -1;


                chkAllCcPeople.Enabled = false;
                chkAllCcPeople.Checked = false;

                Session["CcReceiverPersonLst"] = null;

            }



            BeforeChangeFilterIndexCc = ddlFilterCcReceiver.SelectedIndex;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    
    }

   
    protected void grdPeopleCc_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        int i = 1;
        if (ddlFilterCcReceiver.SelectedIndex == 1)
        {
            while (i < 14)
            {
                if (i == 1)
                    row.Cells[i].Visible = true;
                else
                    row.Cells[i].Visible = false;

                i++;
            }
        }
        else if (ddlFilterCcReceiver.SelectedIndex == 2)
        {
            while (i < 9)
            {
                if (i == 1)
                    row.Cells[i].Visible = true;
                else
                    row.Cells[i].Visible = false;

                i++;
            }
        }
        else if (ddlFilterCcReceiver.SelectedIndex == 3)
        {
            row.Cells[2].Visible = false;
        }
    }

   
    protected void ddlFromList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string titleFooter = "";

        //titleFooter = HtmlEditor1.Text
        //            + "<br> <p align= right> "
        //            + ddlFromList.SelectedItem.ToString()
        //            + " "
        //            + "<br>...............<br> शाखा अधिकृत"
        //            + "</p> ";
       

        //HtmlEditor1.Text = titleFooter;
                

    }
    protected void ddlFilterTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlUnitTo.Enabled = false;
        //ddlPersonTo.Enabled = false;

        //ddlUnitTo.SelectedIndex = -1;
        //ddlPersonTo.SelectedIndex = -1;

        //if (ddlFilterTo.SelectedIndex > 0)
        //{

        //    List<ATTOrganization> lstOrg = new List<ATTOrganization>();

        //    lstOrg = BLLOrganization.GetOrganization();

        //    Session["OrgTo"] = lstOrg;

        //    ddlOrgTo.DataSource = lstOrg;
        //    ddlOrgTo.DataTextField = "OrgName";
        //    ddlOrgTo.DataValueField = "OrgId";
        //    ddlOrgTo.DataBind();

        //    ListItem a = new ListItem();
        //    a.Selected = true;
        //    a.Text = "छान्नुहोस्";
        //    a.Value = "0";
        //    ddlOrgTo.Items.Insert(0, a);

        //    ddlOrgTo.Enabled = true;

        //    ddlFilterFrom.Enabled = true;
        //}
        //else
        //{
        //    ResetHtmlEditor();

        //    ddlOrgTo.DataSource = "";
        //    ddlOrgTo.DataBind();

        //    ddlOrgTo.SelectedIndex = -1;

        //    ddlOrgTo.Enabled = false;

        //    LetterFooter = "";

        //    HtmlEditor1.Text = LetterBody;

        //    LetterTitle = "";
        //    LetterFooter = "";

        //    ddlOrgFrom.SelectedIndex = -1;
        //    ddlUnitFrom.SelectedIndex = -1;
        //    ddlPersonFrom.SelectedIndex = -1;
        //    ddlFilterFrom.SelectedIndex = -1;

        //    ddlOrgFrom.Enabled = false;
        //    ddlUnitFrom.Enabled = false;
        //    ddlPersonFrom.Enabled = false;
        //    ddlFilterFrom.Enabled = false;


        //}

    }

    protected void ddlOrgTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlFilterTo.SelectedIndex == 1)
            //{
            //    SetLetterTitle();
            //}
            //else if (ddlFilterTo.SelectedIndex == 2 || ddlFilterTo.SelectedIndex == 3)
            //{
            //    if (ddlOrgTo.SelectedIndex > 0)
            //    {
            //        List<ATTOrganizationUnit> lstUnit = new List<ATTOrganizationUnit>();

            //        lstUnit = BLLOrganizationUnit.GetUnitHead(int.Parse(ddlOrgTo.SelectedValue.ToString()), null);

            //        if (lstUnit.Count > 0)
            //        {
            //            this.ddlUnitTo.DataSource = lstUnit;
            //            this.ddlUnitTo.DataTextField = "UnitName";
            //            this.ddlUnitTo.DataValueField = "UnitID";
            //            this.ddlUnitTo.DataBind();

            //            ListItem a = new ListItem();
            //            a.Selected = true;
            //            a.Text = "छान्नुहोस्";
            //            a.Value = "0";
            //            ddlUnitTo.Items.Insert(0, a);

            //            ddlUnitTo.Enabled = true;

            //        }
            //    }
            //    else
            //    {
            //        this.ddlUnitTo.DataSource = "";
            //        this.ddlUnitTo.DataBind();


            //        ddlUnitTo.Enabled = false;
            //    }
            //}

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    
    }

    protected void ddlUnitTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlFilterTo.SelectedIndex == 2)
            //{
            //    SetLetterTitle();
            //}
            //else if (ddlFilterTo.SelectedIndex == 3)
            //{
            //    if (ddlUnitTo.SelectedIndex > 0)
            //    {

            //        List<ATTMessagePerson> lstPerson = new List<ATTMessagePerson>();

            //        lstPerson = BLLMessagePerson.GetMessagePersonList(int.Parse(ddlOrgTo.SelectedValue), int.Parse(ddlUnitTo.SelectedValue), "", true);

            //        ddlPersonTo.DataSource = lstPerson;
            //        ddlPersonTo.DataTextField = "PersonName";
            //        ddlPersonTo.DataValueField = "PID";
            //        ddlPersonTo.DataBind();

            //        ddlPersonTo.Enabled = true;
            //    }
            //    else
            //    {
            //        ddlPersonTo.DataSource = "";
            //        ddlPersonTo.DataBind();
                    
            //        ddlPersonTo.Enabled = false;
            //    }
            //}

        }
        catch (Exception ex)
        {
            
            throw(ex);
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

                 HtmlEditor1.Text = LetterDate + LetterTitle + LetterBody + LetterFooter;
             }
             else
             {
                 HtmlEditor1.Text = LetterBody;

                 this.lblStatusMessageTitle.Text = "Letter";
                 this.lblStatusMessage.Text = "First Letter Title should be set !!!";
                 this.programmaticModalPopup.Show();
                 return;
             }
        }
        catch (Exception ex)
        {
            
            throw(ex);
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

            HtmlEditor1.Text = LetterDate + LetterTitle +  LetterBody;

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

    public void ResetHtmlEditor()
    {
        try
        {
            string val = HtmlEditor1.Text;
            string body = "";

            if (LetterTitle.Length > 0 && LetterFooter.Length > 0)
                body = val.Substring(LetterTitle.Length + LetterDate.Length - 6, val.Length - LetterTitle.Length - LetterDate.Length - LetterFooter.Length + 9);
            else if (LetterTitle.Length > 0)
                body = val.Substring(LetterTitle.Length + LetterDate.Length - 6, val.Length - LetterTitle.Length - LetterDate.Length + 6);
            else
                body = val.Substring(0, val.Length);



            if (body.Length < 2)
            {
                body = body.Replace(">", "");
            }
            else
            {
                if (body.IndexOf(">") == 0)
                {
                   body = body.Substring(1,body.Length -1 );
                }
            }

            LetterBody = body;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void imgComment_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ReloadPpl();
            programmaticModalComment.Hide();

        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }

    protected void imgPplCcClose_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ReloadPplCc();

            programmaticModalPplCc.Hide();

        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }

    public void ReloadPpl()
    {
        try
        {
            List<ATTMessageReceiver> lstReceiver;
            lstReceiver = LstReceiver;
            LstReceiver = AddReceiverPeople(lstReceiver, "R");

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void ReloadPplCc()
    {
        try
        {
            List<ATTMessageReceiver> lstReceiverCc;
            lstReceiverCc = LstReceiverCc;
            LstReceiverCc = AddReceiverPeople(lstReceiverCc, "Cc");

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void RemoveUncheckedPpl(List<ATTMessageReceiver> lstReceiver, string type)
    {
        try
        {
            int index = 0;

            GridView grdRqd = new GridView();

            if (type == "R")
            {
                grdRqd = grdTmp;
            }
            else if (type == "Cc")
            {
                grdRqd = grdCcTmp;
            }


            foreach (GridViewRow gvr in grdRqd.Rows)
            {
                CheckBox chkTmp = (CheckBox)gvr.FindControl("chkTmp");

                if (!chkTmp.Checked)
                {

                    int? receiverOrgID = null;
                    int? receiverUnitID = null;
                    int? receiverID = null;

                    bool flag = false;

                    if (gvr.Cells[1].Text != "" && gvr.Cells[1].Text != "&nbsp;")
                    {
                        receiverOrgID = int.Parse(gvr.Cells[1].Text);
                    }

                    if (gvr.Cells[2].Text != "" && gvr.Cells[2].Text != "&nbsp;")
                    {
                        receiverUnitID = int.Parse(gvr.Cells[2].Text);
                    }

                    if (gvr.Cells[3].Text != "" && gvr.Cells[3].Text != "&nbsp;")
                    {
                        receiverID = int.Parse(gvr.Cells[3].Text);
                    }

                    if (receiverID != null)
                    {

                        flag = lstReceiver.Remove(
                                                lstReceiver.Find(delegate(ATTMessageReceiver obj)
                                                {
                                                    return (obj.OtherReceiverID == receiverID && obj.OtherUnitID == receiverUnitID && obj.OtherOrgID == receiverOrgID);
                                                })

                                          );


                    }

                    if (flag)
                    {
                        List<ATTMessageReceiver> lstTmp = new List<ATTMessageReceiver>();

                        if (type == "R")
                        {
                            lstTmp = LstTempPplReceiver;
                        }
                        else if (type == "Cc")
                        {
                            lstTmp = LstTempPplReceiverCc;
                        }


                        lstTmp.RemoveAt(index);

                        flag = false;
                    }
                    else { index++; }
                }
            }


            if (type == "R")
            {
                if (LstTempPplReceiver.Count > 0)
                {
                    grdTmp.DataSource = LstTempPplReceiver;
                    grdTmp.DataBind();

                    grdTmp.SelectedIndex = -1;
                    grdTmp.Visible = true;
                }
                else
                {
                    grdTmp.DataSource = "";
                    grdTmp.DataBind();

                }
            }
            else if (type == "Cc")
            {
                if (LstTempPplReceiverCc.Count > 0)
                {
                    grdCcTmp.DataSource = LstTempPplReceiverCc;
                    grdCcTmp.DataBind();

                    grdCcTmp.SelectedIndex = -1;
                    grdCcTmp.Visible = true;
                }
                else
                {
                    grdCcTmp.DataSource = "";
                    grdCcTmp.DataBind();

                }
            }






        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void grdTmp_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        gvRow.Cells[1].Visible = false;
        gvRow.Cells[2].Visible = false;
        gvRow.Cells[3].Visible = false;

    }
    
    protected void imgPplBooking_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            List<ATTMessageReceiver> lstReceiver;
            lstReceiver = LstReceiver;
            LstReceiver = AddReceiverPeople(lstReceiver, "R");

            if (LstReceiver.Count > 0)
            {
                chkAllPpl.Checked = true;
                this.programmaticModalComment.Show();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Letter";
                this.lblStatusMessage.Text = "No Datas in the list  !!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }



    }
    protected void imgPplBookingCc_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            List<ATTMessageReceiver> lstReceiverCc;
            lstReceiverCc = LstReceiverCc;
            LstReceiverCc = AddReceiverPeople(lstReceiverCc, "Cc");

            if (LstReceiverCc.Count > 0)
            {
                chkAllCcPpl.Checked = true;
                this.programmaticModalPplCc.Show();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Letter";
                this.lblStatusMessage.Text = "No Datas in the list  !!!";
                this.programmaticModalPopup.Show();
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

            foreach (ATTMessageReceiver objMsgR in LstReceiver)
            {

                title += "<br> श्री "
                      + objMsgR.DetailName.ToString()
                      + "," ;
            }

            foreach (ATTMessageReceiver objMsgRc in LstReceiverCc)
            {
                if (title.Length > 0)
                {
                    title += "<br>";
                }

                title += "श्री "
                      + objMsgRc.DetailName.ToString()
                      + ",";
            }

            if (title.Length > 0)
            {
                title = title.Substring(0, title.Length - 1);
                title += "।<br><br>";

            }

            ResetHtmlEditor();

            LetterTitle = title;

            if (LetterTitle.Length > 0)
            {
                HtmlEditor1.Text = LetterDate + LetterTitle + LetterBody + LetterFooter;
                ddlFilterFrom.Enabled = true;

            }
            else
            {
                HtmlEditor1.Text = LetterBody;
                ddlFilterFrom.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
}
