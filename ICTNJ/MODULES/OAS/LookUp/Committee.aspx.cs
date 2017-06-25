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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_LookUp_Committee : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("5,5,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadOrganization();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(0, "-------- Select Organization --------"));
            this.ddlOrg.DataSource = lst;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlOrg.SelectedIndex <= 0)
            {
                this.lblStatusMessage.Text = "Please select organization from list.";
                this.programmaticModalPopup.Show();
                return;
            }

            ATTGroup obj = new ATTGroup();

            obj.OrgID = int.Parse(this.ddlOrg.SelectedValue);
            obj.GroupID = 0;
            obj.GroupName = this.txtCommittee.Text.Trim();
            obj.Description = this.txtDescription.Text.Trim();
            obj.Active = (this.chkActive.Checked == true) ? "Y" : "N";
            obj.Type = 'C';

            ObjectValidation result = BLLGroup.Validate(obj);
            if (result.IsValid == false)
            {
                this.lblStatusMessage.Text = result.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }

            if (this.lstCommittee.SelectedIndex < 0)
                obj.Action = "A";
            else
            {
                obj.GroupID = int.Parse(this.lstCommittee.SelectedValue);
                obj.Action = "E";
            }

            BLLGroup.AddGroup(obj);
            if (obj.Action == "A")
                ((List<ATTGroup>)Session["GroupLst"]).Add(obj);
            else
                ((List<ATTGroup>)Session["GroupLst"])[this.lstCommittee.SelectedIndex] = obj;

            Session["Grouplst"] = BLLGroup.GetGroupList(int.Parse(this.ddlOrg.SelectedValue), false,'C');
            this.lstCommittee.DataSource = Session["GroupLst"];
            this.lstCommittee.DataTextField = "GroupName";
            this.lstCommittee.DataValueField = "GroupID";
            this.lstCommittee.DataBind();
            
            this.ClearME();

            this.lblStatusMessage.Text = "Committee successfully saved.";
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
        this.ddlOrg.SelectedIndex = 0;
        this.txtCommittee.Text = "";
        this.txtDescription.Text = "";
        this.chkActive.Checked = false;
        this.lstCommittee.SelectedIndex = -1;
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGroup();
        this.txtCommittee.Text = "";
        this.txtDescription.Text = "";
        this.chkActive.Checked = false;
        this.lstCommittee.SelectedIndex = -1;
    }

    void LoadGroup()
    {
        try
        {
            Session["Grouplst"] = BLLGroup.GetGroupList(int.Parse(this.ddlOrg.SelectedValue), false,'C');
            this.lstCommittee.DataSource = Session["GroupLst"];
            this.lstCommittee.DataTextField = "GroupName";
            this.lstCommittee.DataValueField = "GroupID";
            this.lstCommittee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlOrg.SelectedIndex = 0;
        this.txtCommittee.Text = "";
        this.txtDescription.Text = "";
        this.chkActive.Checked = false;

        ATTGroup obj = ((List<ATTGroup>)Session["GroupLst"])[this.lstCommittee.SelectedIndex];

        this.ddlOrg.SelectedValue = obj.OrgID.ToString();
        this.txtCommittee.Text = obj.GroupName;
        this.txtDescription.Text = obj.Description;
        this.chkActive.Checked = (obj.Active == "Y") ? true : false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
}
