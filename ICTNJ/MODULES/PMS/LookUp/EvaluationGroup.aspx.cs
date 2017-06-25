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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_EvaluationGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,18,1") == true)
        {
            if (!this.IsPostBack)
                LoadEvaluationGroup();
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadEvaluationGroup()
    {
        try
        {
            List<ATTEvaluationGroup> EvaluationGroupList = BLLEvaluationGroup.GetEvaluationGroupList(PCS.FRAMEWORK.Default.No, PCS.FRAMEWORK.Default.No, PCS.FRAMEWORK.Default.No,"A");
            Session["EvaluationGroupList"] = EvaluationGroupList;
            this.lstEvaluationGroup.DataSource = EvaluationGroupList;
            this.lstEvaluationGroup.DataTextField = "GroupName";
            this.lstEvaluationGroup.DataValueField = "GroupID";
            this.lstEvaluationGroup.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtEvaluationGroup_Rqd.Text = "";
        this.lstEvaluationGroup.SelectedIndex = -1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int groupID = 0;
        string groupName=this.txtEvaluationGroup_Rqd.Text.Trim();
        List<ATTEvaluationGroup> EvaluationGroupList = (List<ATTEvaluationGroup>)Session["EvaluationGroupList"];
        ATTEvaluationGroup EvaluationGroup = new ATTEvaluationGroup(groupID, groupName);

        if (this.lstEvaluationGroup.SelectedIndex > -1)
        {
            EvaluationGroup.GroupID = EvaluationGroupList[this.lstEvaluationGroup.SelectedIndex].GroupID;
            EvaluationGroup.Action = "E";
        }
        else
            EvaluationGroup.Action = "A";

        try
        {
            BLLEvaluationGroup.SaveEvaluationGroup(EvaluationGroup);
            if (this.lstEvaluationGroup.SelectedIndex > -1)
                EvaluationGroupList[this.lstEvaluationGroup.SelectedIndex] = EvaluationGroup;
            else
                EvaluationGroupList.Add(EvaluationGroup);

            this.lstEvaluationGroup.DataSource = EvaluationGroupList;
            this.lstEvaluationGroup.DataBind();
            this.txtEvaluationGroup_Rqd.Text = "";
            this.lstEvaluationGroup.SelectedIndex = -1;
            this.lblStatusMessage.Text = "Evaluation Group Saved Successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void lstEvaluationGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTEvaluationGroup> EvaluationGroupList = (List<ATTEvaluationGroup>)Session["EvaluationGroupList"];
        this.txtEvaluationGroup_Rqd.Text = EvaluationGroupList[this.lstEvaluationGroup.SelectedIndex].GroupName;
    }
}
