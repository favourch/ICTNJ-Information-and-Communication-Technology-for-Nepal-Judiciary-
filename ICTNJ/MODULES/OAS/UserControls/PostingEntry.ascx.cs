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

public partial class MODULES_OAS_UserControls_PostingEntry : System.Web.UI.UserControl
{
    public delegate void GenericMethod();

    private GenericMethod _ParentRetriveMethod;
    public GenericMethod ParentRetriveMethod
    {
        get { return this._ParentRetriveMethod; }
        set { this._ParentRetriveMethod = value; }
    }

    private int _OrgID;
    public int OrgID
    {
        get { return this._OrgID; }
        set { this._OrgID = value; }
    }

    private int _TippaniID;
    public int TippaniID
    {
        get { return this._TippaniID; }
        set { this._TippaniID = value; }
    }

    private double _EmpID;
    public double EmpID
    {
        get { return this._EmpID; }
        set { this._EmpID = value; }
    }

    private string _EmpName;
    public string EmpName
    {
        get { return this._EmpName.Trim(); }
        set { this._EmpName = value; }
    }

    private string _EntryBy;
    public string EntryBy
    {
        get { return this._EntryBy.Trim(); }
        set { this._EntryBy = value; }
    }

    public FreeTextBoxControls.FreeTextBox Note
    {
        get
        {
            return this.txtNote;
        }
    }

    public List<ATTGeneralTippaniDetail> PostingList
    {
        get { return Session["PostingListSession"] as List<ATTGeneralTippaniDetail>; }
    }

    public List<ATTPost> UsedPostList
    {
        get { return Session["UsedPostListSession"] as List<ATTPost>; }
    }

    public List<ATTPost> CurrentPostList
    {
        get { return Session["CurrentPostList"] as List<ATTPost>; }
    }
    
    public UpdatePanel PostUpdatePanel
    {
        get { return this.updPost; }
    }

    public DropDownList Status
    {
        get
        {
            return this.ddlTippaniStatus;
        }
    }

    public GridView PostingGrid
    {
        get { return this.grdPostList; }
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
            this.LoadPostingType();
            this.LoadTippaniStatus();
            if (this.ActionMode == "A")
            {
                this.SetPostingListSession();
            }
        }
    }

    void SetPostingListSession()
    {
        Session["PostingListSession"] = new List<ATTGeneralTippaniDetail>();
        Session["UsedPostListSession"] = new List<ATTPost>();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));
            this.ddlOrg_Rqd.DataSource = lst;
            this.ddlOrg_Rqd.DataTextField = "OrgName";
            this.ddlOrg_Rqd.DataValueField = "OrgID";
            this.ddlOrg_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadPost()
    {
        try
        {
            List<ATTDesignation> lst = new List<ATTDesignation>();
            lst = BLLDesignation.GetDesignation(null, "");
            lst.Insert(0, new ATTDesignation(-1, "---- पद छन्नुहोस ----", ""));
            this.ddlPost_Rqd.DataSource = lst;
            this.ddlPost_Rqd.DataTextField = "DesignationName";
            this.ddlPost_Rqd.DataValueField = "DesignationID";
            this.ddlPost_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadTippaniStatus()
    {
        try
        {
            this.ddlTippaniStatus.DataSource = BLLTippaniStatus.GetTippaniStatusList(false);
            this.ddlTippaniStatus.DataTextField = "TippaniStatusName";
            this.ddlTippaniStatus.DataValueField = "TippaniStatusID";
            this.ddlTippaniStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadPostingType()
    {
        try
        {
            List<ATTPostingType> PostingTypeList = BLLPostingType.GetPostingType(null, "Y");
            PostingTypeList.Insert(0, new ATTPostingType(0, "--- छान्नुहोस ---", ""));
            this.ddlPostingType_rqd.DataSource = PostingTypeList;
            this.ddlPostingType_rqd.DataTextField = "POSTINGTYPENAME";
            this.ddlPostingType_rqd.DataValueField = "POSTINGTYPEID";
            this.ddlPostingType_rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlPost_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlAvailablePost_Rqd.DataSource = "";
            this.ddlAvailablePost_Rqd.Items.Clear();
            //this.ddlAvailablePost_Rqd.Enabled = false;
            List<ATTPost> AvailablePostList = new List<ATTPost>();
            if (this.ddlPost_Rqd.SelectedIndex > 0)
            {
                this.ddlAvailablePost_Rqd.Enabled = true;
                List<ATTPost> OrgAvailableDesgPost = (List<ATTPost>)Session["OrgAvailableDesgPost"];
                int intOrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue.ToString());
                int intDesID = int.Parse(this.ddlPost_Rqd.SelectedValue.ToString());
                foreach (ATTPost lstPost in OrgAvailableDesgPost)
                {
                    if ((intOrgID == lstPost.OrgID) && (intDesID == lstPost.DesID))
                        AvailablePostList.Add(lstPost);
                }
                //if (AvailablePostList.Count > 0)
                //{
                //    this.ddlAvailablePost_Rqd.DataSource = AvailablePostList;
                //    this.ddlAvailablePost_Rqd.DataTextField = "RDPOSTNAMEWITHCREATIONDATE";//"RDPOSTNAMEWITHCREATIONDATE";
                //    this.ddlAvailablePost_Rqd.DataValueField = "RDPOSTIDWITHCREATIONDATE";
                //    this.ddlAvailablePost_Rqd.Items.Add(new ListItem("--- छान्नुहोस ---", "0"));
                //}
            }
            //this.ddlAvailablePost_Rqd.DataBind();
            Session["CurrentPostList"] = AvailablePostList;
            this.ManageAvailablePost();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrg_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlAvailablePost_Rqd.DataSource = "";
        this.ddlAvailablePost_Rqd.Items.Clear();
        this.ddlAvailablePost_Rqd.DataBind();
        this.ddlAvailablePost_Rqd.Enabled = false;
        this.ddlPost_Rqd.DataSource = "";
        this.ddlPost_Rqd.Items.Clear();

        Session["OrgAvailableDesgPost"] = "";
        List<ATTPost> DispOrgAvailableDesgPost = new List<ATTPost>();
        try
        {
            if (this.ddlOrg_Rqd.SelectedIndex > 0)
            {
                List<ATTPost> OrgAvailableDesgPost = BLLPost.GetOrgAvailableDesgPost(int.Parse(this.ddlOrg_Rqd.SelectedValue.ToString()), null, "CO", null);
                Session["OrgAvailableDesgPost"] = OrgAvailableDesgPost;
                int intDesID = 0;
                foreach (ATTPost lstPost in OrgAvailableDesgPost)
                {
                    if (intDesID != lstPost.DesID)
                        DispOrgAvailableDesgPost.Add(lstPost);
                    intDesID = lstPost.DesID;
                }
                if (DispOrgAvailableDesgPost.Count > 0)
                {
                    this.ddlPost_Rqd.DataSource = DispOrgAvailableDesgPost;
                    this.ddlPost_Rqd.DataTextField = "DESNAME";
                    this.ddlPost_Rqd.DataValueField = "DESID";
                    this.ddlPost_Rqd.Items.Add(new ListItem("--- छान्नुहोस ---", "0"));
                }
            }
            this.ddlPost_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public List<ATTGeneralTippaniDetail> GetPostingList()
    {
        return this.PostingList;
    }

    private ATTGeneralTippaniSummary GetPostingDetail(int orgID, int tippaniID, double empID, string entryBy)
    {
        string strCreationDate;
        int intPostID;

        strCreationDate = this.ddlAvailablePost_Rqd.SelectedValue.ToString();

        intPostID = int.Parse(strCreationDate.Substring(0, strCreationDate.IndexOf('/')));
        strCreationDate = strCreationDate.Substring(strCreationDate.IndexOf('/') + 1);

        ATTGeneralTippaniSummary posting = new ATTGeneralTippaniSummary();

        if (this.grdPostList.SelectedIndex < 0)
        {
            posting.OrgID = orgID;
            posting.TippaniID = tippaniID;
            posting.TippaniSNO = 0;
            posting.EmpID = empID;
            posting.EmpName = this.EmpName;
            posting.Action = "A";
        }
        else
        {
            ATTGeneralTippaniSummary detail = this.PostingList[this.grdPostList.SelectedIndex] as ATTGeneralTippaniSummary;
            posting.OrgID = detail.OrgID;
            posting.TippaniID = detail.TippaniID;
            posting.TippaniSNO = detail.TippaniSNO;
            posting.EmpID = detail.EmpID;
            posting.EmpName = detail.EmpName;

            if (this.PostingList[this.grdPostList.SelectedIndex].Action == "A")
            {
                posting.Action = "A";
            }
            else
            {
                posting.Action = "E";
            }
        }

        posting.PostOrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        posting.PostOrgName = this.ddlOrg_Rqd.SelectedItem.Text;
        posting.DesID = int.Parse(this.ddlPost_Rqd.SelectedValue);
        posting.PostDesName = this.ddlPost_Rqd.SelectedItem.Text;
        posting.CreatedDate = strCreationDate;
        posting.PostID = intPostID;
        posting.PostName = this.ddlAvailablePost_Rqd.SelectedItem.Text;
        posting.FromDate = txtPostingDate_Rdt.Text.Trim();
        posting.ToDate = "";
        posting.PostingTypeID = int.Parse(this.ddlPostingType_rqd.SelectedValue);
        posting.PostingTypeName = this.ddlPostingType_rqd.SelectedItem.Text;
        posting.JoiningDate = this.txtJoiningDate_Dt.Text.Trim();
        posting.DecisionDate = this.txtDecisionDate_Dt.Text.Trim();
        posting.LeaveDate = this.txtLeaveDate_Dt.Text;
        posting.PostingRemark = this.txtPostingRemarks.Text;
        //posting.Action = "A";
        posting.EntryBy = entryBy;

        return posting;
    }

    public void SetPostingDetail(ATTEmployeePosting post)
    {
        this.ddlOrg_Rqd.SelectedValue = post.OrgID.ToString();
        this.ddlPostingType_rqd.SelectedValue = post.DesID.ToString();
        this.ddlAvailablePost_Rqd.SelectedValue = post.PostID.ToString();
        this.ddlPostingType_rqd.SelectedValue = post.PostingTypeID.ToString();
        this.txtPostingDate_Rdt.Text = post.FromDate;
        this.txtDecisionDate_Dt.Text = post.DecisionDate;
        this.txtLeaveDate_Dt.Text = post.LeaveDate;
        this.txtJoiningDate_Dt.Text = post.JoiningDate;
    }

    public void Clear()
    {
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.ddlPost_Rqd.DataSource = "";
        this.ddlPost_Rqd.DataBind();
        this.ddlAvailablePost_Rqd.DataSource = "";
        this.ddlAvailablePost_Rqd.DataBind();
        this.ddlPostingType_rqd.SelectedIndex = 0;
        this.txtPostingDate_Rdt.Text = "";
        this.txtDecisionDate_Dt.Text = "";
        this.txtLeaveDate_Dt.Text = "";
        this.txtJoiningDate_Dt.Text = "";
        this.txtNote.Text = "";
        this.ActionMode = "A";
        this.grdPostList.SelectedIndex = -1;
        this.grdPostList.DataSource = "";
        this.grdPostList.DataBind();
        this.SetPostingListSession();
        Session["CurrentPostList"] = new List<ATTPost>();
    }

    void ManageAvailablePost()
    {
        List<ATTPost> lstCurrentPost = Session["CurrentPostList"] as List<ATTPost>;

        foreach (GridViewRow row in this.grdPostList.Rows)
        {
            ATTPost obj= lstCurrentPost.Find
                                    (
                                        delegate(ATTPost p)
                                        {
                                            return p.OrgID == int.Parse(row.Cells[2].Text)
                                            && p.DesID == int.Parse(row.Cells[3].Text)
                                            && p.CreatedDate == row.Cells[14].Text
                                            && p.PostID == int.Parse(row.Cells[4].Text);
                                        }
                                    );

            if (obj != null)
            {
                this.UsedPostList.Add(obj);
                this.CurrentPostList.Remove(obj);
                break;
            }
        }

        this.ddlAvailablePost_Rqd.Items.Clear();
        this.ddlAvailablePost_Rqd.Items.Add(new ListItem("--- छान्नुहोस ---", "0"));
        this.ddlAvailablePost_Rqd.DataSource = lstCurrentPost;
        this.ddlAvailablePost_Rqd.DataTextField = "RDPOSTNAMEWITHCREATIONDATE";//"RDPOSTNAMEWITHCREATIONDATE";
        this.ddlAvailablePost_Rqd.DataValueField = "RDPOSTIDWITHCREATIONDATE";
        this.ddlAvailablePost_Rqd.DataBind();
    }

    protected void btnAddPostingDetail_Click(object sender, EventArgs e)
    {
        if (this.ddlAvailablePost_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया उपलब्ध पद छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlPostingType_rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया छनौट तरिका छन्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.ParentRetriveMethod.Invoke();

        if (this.grdPostList.SelectedIndex < 0)
        {
            if (this.EmpID <= 0)
            {
                this.lblStatusMessage.Text = "कृपया कर्मचारी छन्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }

            bool existence = this.PostingList.Exists
                                                    (
                                                        delegate(ATTGeneralTippaniDetail d)
                                                        {
                                                            return d.EmpID == this.EmpID;
                                                        }
                                                    );

            if (existence == true)
            {
                this.lblStatusMessage.Text = "कर्मचारी -> " + this.EmpName + "<br>" + "पहिलेनै छानिसकेकोछ। कृपया अर्को कर्मचारी छान्नुहोस।";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        if (this.grdPostList.SelectedIndex < 0)
        {
            this.PostingList.Add(this.GetPostingDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy));
        }
        else
        {
            this.PostingList[this.grdPostList.SelectedIndex] = this.GetPostingDetail(this.OrgID, this.TippaniID, this.EmpID, this.EntryBy);
        }

        this.grdPostList.DataSource = this.PostingList;
        this.grdPostList.DataBind();

        this.ddlAvailablePost_Rqd.SelectedIndex = 0;
        this.ddlPostingType_rqd.SelectedIndex = 0;
        this.txtPostingDate_Rdt.Text = "";
        this.txtDecisionDate_Dt.Text = "";
        this.txtLeaveDate_Dt.Text = "";
        this.txtJoiningDate_Dt.Text = "";
        this.grdPostList.SelectedIndex = -1;
        //this.txtNote.Text = "";

        this.ManageAvailablePost();
    }

    protected void grdPostList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[14].Visible = false;
        e.Row.Cells[15].Visible = false; //select command

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ATTGeneralTippaniSummary summary = e.Row.DataItem as ATTGeneralTippaniSummary;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(summary.Action);
            e.Row.ForeColor = c;

            if (summary.Action == "D")
            {
                ((LinkButton)e.Row.Cells[16].Controls[0]).Text = "Undo";
            }
            else if (summary.Action == "N" || summary.Action == "A" || summary.Action == "E")
            {
                ((LinkButton)e.Row.Cells[16].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void grdPostList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniDetail> lst = this.PostingList;
        ATTGeneralTippaniDetail currentO = lst[e.RowIndex];
        GridView grd = this.grdPostList;
        GridViewRow CurrentRow = this.grdPostList.Rows[e.RowIndex];

        int DelCmdIndex = 16;

        if (currentO.Action == "A")
        {
            lst.RemoveAt(e.RowIndex);
            grd.DataSource = this.PostingList;
            grd.DataBind();

            this.CurrentPostList.Add(this.UsedPostList[e.RowIndex]);
            this.UsedPostList.RemoveAt(e.RowIndex);

            this.ddlAvailablePost_Rqd.Items.Clear();
            this.ddlAvailablePost_Rqd.Items.Add(new ListItem("--- छान्नुहोस ---", "0"));
            this.ddlAvailablePost_Rqd.DataSource = this.CurrentPostList;
            this.ddlAvailablePost_Rqd.DataTextField = "RDPOSTNAMEWITHCREATIONDATE";//"RDPOSTNAMEWITHCREATIONDATE";
            this.ddlAvailablePost_Rqd.DataValueField = "RDPOSTIDWITHCREATIONDATE";
            this.ddlAvailablePost_Rqd.DataBind();
        }
        else if (currentO.Action == "N" || currentO.Action == "D" || currentO.Action == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                grd.DataSource = lst;
                grd.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                grd.DataSource = lst;
                grd.DataBind();
            }
        }
    }

    public void LoadPostingDetail(int orgID, int tippaniID, int tipPrcID)
    {
        this.SetPostingListSession();
        try
        {
            List<ATTGeneralTippaniSummary> lst = BLLGeneralTippaniDetail.GetPostingTippaniDetail(orgID, tippaniID, 3, tipPrcID);

            foreach (ATTGeneralTippaniSummary summary in lst)
            {
                this.PostingList.Add(summary);
            }
            this.grdPostList.DataSource = this.PostingList;
            this.grdPostList.DataBind();

            this.txtNote.Text = BLLGeneralTippaniProcess.GetTippaniText(orgID, tippaniID, tipPrcID);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdPosting_SelectedIndexChanged(object sender, EventArgs e)
    {
        //reserve for future use
    }

    public void LoadBodyFromMessage(int orgID, int msgID)
    {
        try
        {
            List<ATTMessage> lst = BLLMessage.GetMessageByIDs(orgID, msgID);
            this.txtNote.Text = lst[0].Body;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LoadBodyFromDartaaChalaani(int orgID, string regDate, int regNo)
    {
        try
        {
            List<ATTDartaaChalaani> lst = BLLDartaaChalaani.GetDartaaChalaaniByIDs(orgID, regDate, regNo);
            if (lst.Count == 1)
            {
                this.txtNote.Text = lst[0].Description;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
