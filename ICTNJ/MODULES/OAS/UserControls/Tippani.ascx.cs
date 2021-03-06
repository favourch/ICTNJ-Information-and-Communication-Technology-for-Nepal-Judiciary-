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


public partial class MODULES_OAS_UserControls_Tippani : System.Web.UI.UserControl
{
    public DropDownList Organization
    {
        get
        {
            return this.ddlOrg;
        }
    }

    public DropDownList TippaniSubject
    {
        get
        {
            return this.ddlTippaniSubject;
        }
    }

    public TextBox TippaniText
    {
        get
        {
            return this.txtTippaniText;
        }
    }

    public TextBox FileNo
    {
        get
        {
            return this.txtFileNo;
        }
    }

    public DropDownList TippaniPriority
    {
        get { return this.ddlPriority; }
    }

    private PCS.OAS.ATT.TippaniSubject _TippaniSubjectType;
    public PCS.OAS.ATT.TippaniSubject TippaniSubjectType
    {
        get { return this._TippaniSubjectType; }
        set { this._TippaniSubjectType = value; }
    }

    public string OriginalText
    {
        get
        {
            return Session["OriginalText"] as string;
        }
    }

    private ATTUserLogin User
    {
        get
        {
            return (ATTUserLogin)Session["Login_User_Detail"];
        }
    }

    private int _TippaniSubjectID;
    public int TippaniSubjectID
    {
        get { return this._TippaniSubjectID; }
        set { this._TippaniSubjectID = value; }
    }

    private string _ActionMode = "A";
    public string ActionMode
    {
        set { this._ActionMode = value; }
        get { return this._ActionMode.Trim(); }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            this.LoadTippaniSubject();
            this.LoadPriority();

            int orgID = this.User.OrgID;
            int tippaniSubjectID = this.TippaniSubjectID;
            double empID = this.User.PID;

            bool channelMember = BLLTippaniChannel.CheckLoginUserIsChannelMember(orgID, tippaniSubjectID, empID);
            
            this.txtTippaniText.ReadOnly = !channelMember;
            this.txtFileNo.ReadOnly = !channelMember;

            if (channelMember == false)
            {
                this.lblPersonStatus.Text = "टिप्पणी उठाउनको लागी Login User टिप्पणी च्यानलको सदस्य हुनुपर्छ।";
                this.lblPersonStatus.Visible = true;
            }
            else
            {
                this.lblPersonStatus.Text = "";
                this.lblPersonStatus.Visible = false;
            }
        }
    }

    void LoadPriority()
    {
        this.ddlPriority.DataSource = BLLTippaniPriority.GetTippaniPriority();
        this.ddlPriority.DataTextField = "PriorityName";
        this.ddlPriority.DataValueField = "PriorityID";
        this.ddlPriority.DataBind();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();

            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));

            this.ddlOrg.DataSource = lst;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();

            this.ddlOrg.SelectedValue = this.User.OrgID.ToString();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public ATTGeneralTippani GetTippani(string entryBy, string msgIDs, string darIDs)
    {
        ATTGeneralTippani tippani = new ATTGeneralTippani();

        int? MsgOrgID = null;
        int? MsgID = null;
        int? DarOrgID = null;
        string DarRegDate = null;
        int? DarRegNo = null;

        if (msgIDs != "")
        {
            char[] token ={ '/' };
            MsgOrgID = int.Parse(msgIDs.Split(token)[0]);
            MsgID = int.Parse(msgIDs.Split(token)[1]);
        }

        if (darIDs != "")
        {
            char[] token ={ '_' };
            DarOrgID = int.Parse(msgIDs.Split(token)[0]);
            DarRegDate = msgIDs.Split(token)[1];
            DarRegNo = int.Parse(msgIDs.Split(token)[2]);
        }

        if (this.ActionMode == "A")
        {
            tippani.OrgID = int.Parse(this.ddlOrg.SelectedValue);
            tippani.TippaniID = 0;
            tippani.Action = "A";
        }
        else
        {
            string ids = this.hdnIDS.Value;
            char[] token ={ '/' };

            tippani.OrgID = int.Parse(ids.Split(token)[0]);
            tippani.TippaniID = int.Parse(ids.Split(token)[1]);
            tippani.Action = "E";
        }

        tippani.TippaniName = this.TippaniSubjectType;
        tippani.TippaniSubjectID = int.Parse(this.ddlTippaniSubject.SelectedValue);
        tippani.TippaniBy = this.User.UserName;
        tippani.TippaniOn = "";
        tippani.TippaniText = this.txtTippaniText.Text;
        tippani.FileNo = double.Parse(this.txtFileNo.Text);
        tippani.PriorityID = int.Parse(this.ddlPriority.SelectedValue);
        tippani.TippaniBy = entryBy;
        tippani.FinalStatus = 1;
        tippani.CreatedBy = this.User.PID;
        tippani.MsgOrgID = MsgOrgID;
        tippani.MsgID = MsgID;
        tippani.DarOrgID = DarOrgID;
        tippani.DarRegDate = DarRegDate;
        tippani.DarRegNo = DarRegNo;
        
        return tippani;
    }

    void LoadTippaniSubject()
    {
        try
        {
            List<ATTTippaniSubject> lst = new List<ATTTippaniSubject>();
            lst = BLLTippaniSubject.GetTippaniSubjectList(this.User.OrgID, true);
            
            this.ddlTippaniSubject.DataSource = lst;
            this.ddlTippaniSubject.DataTextField = "TippaniSubjectName";
            this.ddlTippaniSubject.DataValueField = "TippaniSubjectID";
            this.ddlTippaniSubject.DataBind();

            this.ddlTippaniSubject.SelectedValue = this.TippaniSubjectID.ToString();
            //ATTTippaniSubject subject = lst.Find
            //                                (
            //                                    delegate(ATTTippaniSubject s)
            //                                    {
            //                                        return s.TippaniSubjectID == this.TippaniSubjectID;
            //                                    }
            //                                );
            //if (subject != null)
            //{
            //    this.txtTippaniText.Text = subject.TippaniSubjectText;
            //    Session["OriginalText"] = this.txtTippaniText.Text;
            //}
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadTippaniDetail(int orgID, int tippaniID)
    {
        try
        {
            ATTGeneralTippani tippani = BLLGeneralTippani.GetTippaniDetail(orgID, tippaniID);
            this.txtTippaniText.Text = tippani.TippaniText;
            this.txtFileNo.Text = tippani.FileNo.ToString();
            this.ddlPriority.SelectedValue = tippani.PriorityID.ToString();

            this.hdnIDS.Value = orgID.ToString() + "/" + tippaniID.ToString();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
