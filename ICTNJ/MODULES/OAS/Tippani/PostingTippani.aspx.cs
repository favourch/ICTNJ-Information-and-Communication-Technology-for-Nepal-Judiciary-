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

public partial class MODULES_OAS_Tippani_PostingTippani : System.Web.UI.Page
{
    new private ATTUserLogin User
    {
        get
        {
            return (ATTUserLogin)Session["Login_User_Detail"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null && Path.GetFileName(Request.UrlReferrer.ToString()).ToUpper() == "TIPPANIDETAILSEARCH.ASPX" && Session["tippani_mode"] != null)
            {
                string action = "E";
                this.hdnMode.Value = action;

                string composite = Session["tippani_mode"].ToString();
                char[] token ={ '/' };

                int orgID = int.Parse(composite.Split(token)[0]);
                int tippaniID = int.Parse(composite.Split(token)[1]);
                int tipPrcID = int.Parse(composite.Split(token)[2]);

                this.hdnIDs.Value = orgID.ToString() + "/" + tippaniID.ToString() + "/" + tipPrcID.ToString();

                Session["tippani_mode"] = null;

                this.Tippani.ActionMode = action;
                this.Tippani.LoadTippaniDetail(orgID, tippaniID);

                this.PostingEntry.ActionMode = action;
                this.PostingEntry.LoadPostingDetail(orgID, tippaniID, 1);

                this.TippaniAttachment.ActionMode = action;
                this.TippaniAttachment.LoadTippaniAttachmentDetail(orgID, tippaniID);

                //status = -1 --> tippani channel visible, channel person not added
                //status = 0 --> tippani channel invisible, channel person added
                //status > 0 --> tippani has been modified by next person so not editable
                int status = BLLGeneralTippaniProcess.GetTippaniNextStatus(orgID, tippaniID, 2);
                if (status <= -1)
                {
                    this.chnlPerson.Visible = true;
                }
                else if (status == 0)
                {
                    this.chnlPerson.Visible = false;
                    this.lblFinalStatus.Text = "यो टिप्पणी पठाइसकेको हुनाले सिफारीस कर्त्ता / प्रमाणित कर्ता छान्नसक्नु हुन्न तर Submit गर्न सक्नुहुन्छ।";
                }
                else if (status > 0)
                {
                    this.btnSubmit.Enabled = false;
                    this.lblFinalStatus.Text = "यस टिप्पणीमा, टिप्पणी पाउने व्यक्तिले काम गरिसकेको हुनाले Submit गर्न सक्नुहुन्न।";
                }
            }
            //else if (Request.UrlReferrer != null && Path.GetFileName(Request.UrlReferrer.ToString()).ToUpper() == "MESSAGEVIEW.ASPX" && Session["tippani_from_message"] != null)
            else if (Session["tippani_from_message"] != null)
            {
                this.lblConfirmation.Text = "यो टिप्पणी message बाट उठाएको हो ।";
                string composite = Session["tippani_from_message"].ToString();
                Session["tippani_from_message"] = null;
                char[] token ={ '/' };

                int orgID = int.Parse(composite.Split(token)[0]);
                int msgID = int.Parse(composite.Split(token)[1]);

                this.TippaniAttachment.ActionMode = "E";
                this.TippaniAttachment.LoadAttachmentFromMessage(orgID, msgID);

                this.PostingEntry.LoadBodyFromMessage(orgID, msgID);
            }
            //else if (Request.UrlReferrer != null && Path.GetFileName(Request.UrlReferrer.ToString()).ToUpper() == "MESSAGEVIEW.ASPX" && Session["tippani_from_message"] != null)
            else if (Session["tippani_from_Dartaa_chalaani"] != null)
            {
                this.lblConfirmation.Text = "यो टिप्पणी Dartaa Chalaani बाट उठाएको हो ।";
                string composite = Session["tippani_from_Dartaa_chalaani"].ToString();
                Session["tippani_from_Dartaa_chalaani"] = null;
                char[] token ={ '_' };

                int orgID = int.Parse(composite.Split(token)[0]);
                string regDate = composite.Split(token)[1];
                int regNo = int.Parse(composite.Split(token)[2]);

                this.hdnDarIDs.Value = orgID.ToString() + "_" + regDate + "_" + regNo.ToString();

                this.TippaniAttachment.ActionMode = "E";
                this.TippaniAttachment.LoadAttachmentFromDartaaChalaani(orgID, regDate, regNo);

                this.PostingEntry.LoadBodyFromDartaaChalaani(orgID, regDate, regNo);
            }
            else
            {
                Session["tippani_mode"] = null;
            }
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    override protected void OnInit(EventArgs e)
    {
        this.InitializeEventHandler();
        base.OnInit(e);
    }

    private void InitializeEventHandler()
    {
        this.PostingEntry.ParentRetriveMethod = new MODULES_OAS_UserControls_PostingEntry.GenericMethod(this.InitializedValue);
        //AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        //trigger.ControlID = this.btnCancelSubmit.ID;
        //trigger.EventName = "Click";
        //this.PostingEntry.PostUpdatePanel.Triggers.Add(trigger);
    }

    void InitializedValue()
    {
        if (this.ggrdMemberSearch.GrdMemberEmployee.SelectedRow == null)
        {
            this.PostingEntry.EmpID = -1;
            this.PostingEntry.EmpName = "";
        }
        else
        {
            this.PostingEntry.EmpID = double.Parse(this.ggrdMemberSearch.GrdMemberEmployee.SelectedRow.Cells[0].Text);
            this.PostingEntry.EmpName = this.ggrdMemberSearch.GrdMemberEmployee.SelectedRow.Cells[2].Text;
        }
        this.PostingEntry.TippaniID = 0;
        this.PostingEntry.OrgID = this.User.OrgID;
        this.PostingEntry.EntryBy = this.User.UserName;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region validation
        if (this.Tippani.TippaniText.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया टिप्पणीको बिषय राख्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.Tippani.FileNo.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "कृपया टिप्पणीको फाइल नं राख्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.Tippani.TippaniPriority.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया टिप्पणीको प्राथमिक्ता छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        /* tippani created */
        this.Tippani.ActionMode = this.hdnMode.Value;
        ATTGeneralTippani tippani = this.Tippani.GetTippani(this.User.UserName, this.hdnMsgIDs.Value, this.hdnDarIDs.Value);  
        
        /* tippani detail created */
        this.PostingEntry.ActionMode = this.hdnMode.Value;
        tippani.LstTippaniDetail = this.PostingEntry.GetPostingList();

        /* tippani attachment created */
        this.TippaniAttachment.ActionMode = this.hdnMode.Value;
        tippani.LstTippaniAttachment = this.TippaniAttachment.GetAttachment(tippani.OrgID, tippani.TippaniID, this.User.UserName);

        /* tippani process created for self actor */
        ATTGeneralTippaniProcess selfProcess = new ATTGeneralTippaniProcess();
        if (hdnMode.Value == "A")
        {
            selfProcess.OrgID = tippani.OrgID;
            selfProcess.TippaniID = tippani.TippaniID;
            selfProcess.TippaniProcessID = 0;
        }
        else if (hdnMode.Value == "E")
        {
            char[] token ={ '/' };
            selfProcess.OrgID = int.Parse(this.hdnIDs.Value.Split(token)[0]);
            selfProcess.TippaniID = int.Parse(this.hdnIDs.Value.Split(token)[1]);
            selfProcess.TippaniProcessID = 1;
        }
        selfProcess.SenderOrgID = null;
        selfProcess.SenderUnitID = null;
        selfProcess.SendBy = null;
        selfProcess.SendOn = "";
        selfProcess.ReceiverOrgID = this.User.OrgID;
        selfProcess.ReceiverUnitID = this.User.UnitID;
        selfProcess.SendTo = (int)this.User.PID;
        selfProcess.Note = this.PostingEntry.Note.Text;
        selfProcess.Status = int.Parse(this.PostingEntry.Status.SelectedValue);
        selfProcess.SendType = "F";
        selfProcess.IsChannelPerson = "Y";
        selfProcess.EntryBy = this.User.UserName;
        selfProcess.Action = this.hdnMode.Value;

        /* created list of process for tippani movement */
        //if (this.hdnMode.Value == "A")
        {
            tippani.LstTippaniProcess = this.chnlPerson.GetTippaniProcessList(tippani.OrgID, tippani.TippaniID, this.User.UserName);
        }

        /* add self process object at the begining of the process list */
        tippani.LstTippaniProcess.Insert(0, selfProcess);

        #region Validation
        bool hasDetail = tippani.LstTippaniDetail.Exists
                                                    (
                                                        delegate(ATTGeneralTippaniDetail d)
                                                        {
                                                            return d.Action != "D";
                                                        }
                                                    );
        if (hasDetail == false)
        {
            this.lblStatusMessage.Text = "कृपया टिप्पणीको लागी कर्मचारी राख्नुहोस्।";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        try
        {
            BLLGeneralTippani.AddGeneralTippani(tippani);

            foreach (ATTGeneralTippaniAttachment attach in tippani.LstTippaniAttachment)
            {
                if (attach.RawContent != null)
                {
                    GC.Collect();
                    GC.SuppressFinalize(attach.RawContent);
                    attach.RawContent = null;
                }
            }

            this.ClearME();

            this.lblStatusMessage.Text = "Posting Tippani has been saved successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        this.PostingEntry.Clear();
        this.ggrdMemberSearch.GrdMemberEmployee.SelectedIndex = -1;
        this.TippaniAttachment.Clear();
        this.chnlPerson.Clear();
        this.Tippani.TippaniText.Text = this.Tippani.OriginalText;
        this.Tippani.FileNo.Text = "";
        this.hdnMode.Value = "A";
        this.hdnIDs.Value = "";
        this.hdnMsgIDs.Value = "";
        this.hdnDarIDs.Value = "";
        this.lblFinalStatus.Text = "";
        this.lblConfirmation.Text = "";
    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
}
