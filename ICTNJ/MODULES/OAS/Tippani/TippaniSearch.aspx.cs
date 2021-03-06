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

public partial class MODULES_OAS_Tippani_TippaniSearch : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    int GetMaxRecordNumber()
    {
        return 2;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            //this.LoadTippaniSubejct();
            this.LoadTippaniStatus();
        }
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

    void LoadTippaniSubejct()
    {
        try
        {
            int orgID = int.Parse(ddlOrg_Rqd.SelectedValue);
            List<ATTTippaniSubject> lst = BLLTippaniSubject.GetTippaniSubjectList(orgID, true);
            this.ddlTipaniSubject_Rqd.DataSource = lst;
            this.ddlTipaniSubject_Rqd.DataTextField = "TippaniSubjectName";
            this.ddlTipaniSubject_Rqd.DataValueField = "TippaniSubjectID";
            this.ddlTipaniSubject_Rqd.DataBind();
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
            List<ATTTippaniStatus> lst = BLLTippaniStatus.GetTippaniStatusList(true);
            this.ddlStatus.DataSource = lst;
            this.ddlStatus.DataTextField = "TippaniStatusName";
            this.ddlStatus.DataValueField = "TippaniStatusID";
            this.ddlStatus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrg_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlPost.DataSource = "";
        this.ddlPost.Items.Clear();
        this.ddlPost.DataBind();
        this.ddlPost.DataSource = "";
        this.ddlPost.Items.Clear();

        List<ATTPost> DispOrgAvailableDesgPost = new List<ATTPost>();
        try
        {
            if (this.ddlOrg_Rqd.SelectedIndex > 0)
            {
                List<ATTPost> OrgAvailableDesgPost = BLLPost.GetOrgAvailableDesgPost(int.Parse(this.ddlOrg_Rqd.SelectedValue.ToString()), null, "CO", "O");
                int intDesID = 0;
                foreach (ATTPost lstPost in OrgAvailableDesgPost)
                {
                    if (intDesID != lstPost.DesID)
                        DispOrgAvailableDesgPost.Add(lstPost);
                    intDesID = lstPost.DesID;
                }
                if (DispOrgAvailableDesgPost.Count > 0)
                {
                    this.ddlPost.DataSource = DispOrgAvailableDesgPost;
                    this.ddlPost.DataTextField = "DESNAME";
                    this.ddlPost.DataValueField = "DESID";
                    this.ddlPost.Items.Add(new ListItem("--- छान्नुहोस ---", "0"));
                }
            }
            this.ddlPost.DataBind();

            this.LoadTippaniSubejct();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.ddlTipaniSubject_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "कृपया टिप्पणीको बिषय छान्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        this.hdnIndex.Value = "0";

        this.LoadTippani(1);

        if (this.grdTippaniLst.Rows.Count > 0)
        {
            this.lnkNext.Visible = true;
            this.lnkBack.Visible = true;
        }
    }

    void LoadTippani(int Count)
    {
        ATTGeneralTippaniRequestInfo info = new ATTGeneralTippaniRequestInfo();

        info.OrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        info.TippaniSubjectID = int.Parse(this.ddlTipaniSubject_Rqd.SelectedValue);
        info.FromDate = this.txtFromDate.Text;
        info.ToDate = this.txtToDate.Text;
        info.TippaniStatusID = int.Parse(this.ddlStatus.SelectedValue);
        info.ProcessBy = this.txtFirstName.Text;

        try
        {
            decimal totalRecord = Count;
            int sIndex = int.Parse(this.hdnIndex.Value);
            int eIndex = this.GetMaxRecordNumber();

            this.grdTippaniLst.DataSource = BLLGeneralTippani.GetGeneralTippaniInfo(info, sIndex, eIndex, ref totalRecord);
            this.grdTippaniLst.DataBind();

            if (Count > 0)
            {
                this.hdnTotalRecord.Value = totalRecord.ToString();
            }

            if (this.grdTippaniLst.Rows.Count > 0)
            {
                decimal lastIndex = sIndex + eIndex;

                if (lastIndex > decimal.Parse(this.hdnTotalRecord.Value))
                    lastIndex = decimal.Parse(this.hdnTotalRecord.Value);

                this.lblPaging.Text = "Record (" + (sIndex + 1).ToString() + " - " + lastIndex.ToString() + ") of " + this.hdnTotalRecord.Value;
            }
            else
            {
                this.lblPaging.Text = "";
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdTippaniLst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }

    protected void grdTippaniLst_DataBound(object sender, EventArgs e)
    {
        if (this.grdTippaniLst.Rows.Count > 0)
        {
            this.lblTippaniCount.Text = "Total tippani: " + this.grdTippaniLst.Rows.Count.ToString();
        }
        else
        {
            this.lblTippaniCount.Text = "No tippani found.";
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        int nextIndex = int.Parse(this.hdnIndex.Value) + this.GetMaxRecordNumber();
        if (this.grdTippaniLst.Rows.Count > 0)
        {
            this.hdnIndex.Value = nextIndex.ToString();
            this.LoadTippani(-1);
        }
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        int nextIndex = int.Parse(this.hdnIndex.Value) - this.GetMaxRecordNumber();
        if (nextIndex >= 0)
        {
            this.hdnIndex.Value = nextIndex.ToString();
            this.LoadTippani(-1);
        }
    }

    protected void grdTippaniLst_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();
        process.OrgID = int.Parse(this.grdTippaniLst.SelectedRow.Cells[0].Text);
        process.TippaniID = int.Parse(this.grdTippaniLst.SelectedRow.Cells[1].Text);
        process.ProcessBy = double.Parse(this.grdTippaniLst.SelectedRow.Cells[2].Text);

        Session["TippaniInfo_Edit"] = process;

        Response.Redirect("~/modules/oas/tippani/visittippaniedit.aspx");
    }

    protected void grdTippaniLst_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //ATTGeneralTippaniSummary summary = BLLGeneralTippaniDetail.GetPostingTippaniDetail(9, 4, 3, 1);

        //string js = "<script language='javascript'>alert('');</script>";
        //Label l = new Label();
        //l.Text = js;
        //this.Page.Controls.Add(l);

        //this.lblTippaniText.Text = summary.TippaniText;
        //this.lblEmployeeName.Text = summary.EmpName;
        //this.lblOldOrg.Text = summary.OrgName;
        //this.lblOldPost.Text = summary.DesName;
        //this.lblNewOrg.Text = summary.PostOrgName;
        //this.lblNewPost.Text = summary.PostDesName;
        //this.lblPostingType.Text = summary.PostTypeName;
        //this.llblPostingDate.Text = summary.TippaniDetail.FromDate;
        //this.lblDecisionDate.Text = summary.TippaniDetail.DecisionDate;
        //this.lblLeaveDate.Text = summary.TippaniDetail.LeaveDate;
        //this.lblJoiningDate.Text = summary.TippaniDetail.JoiningDate;
    }
}
