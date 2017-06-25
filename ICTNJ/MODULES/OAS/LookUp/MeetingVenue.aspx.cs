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


public partial class MODULES_OAS_LookUp_MeetingVenue : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("5,3,1") == true)
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

    protected void lstVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlOrg.SelectedIndex = 0;
        this.txtVenue.Text = "";
        this.txtLocation.Text = "";

        ATTMeetingVenue obj = ((List<ATTMeetingVenue>)Session["VenueLst"])[this.lstVenue.SelectedIndex];

        this.ddlOrg.SelectedValue = obj.OrgID.ToString();
        this.txtVenue.Text = obj.VenueName;
        this.txtLocation.Text = obj.VenueLocation;
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadVenue();
        this.txtVenue.Text = "";
        this.txtLocation.Text = "";
        this.lstVenue.SelectedIndex = -1;
    }

    void LoadVenue()
    {
        try
        {
            Session["Venuelst"] = BLLMeetingVenue.GetMeetingVenueList(int.Parse(this.ddlOrg.SelectedValue));
            this.lstVenue.DataSource = Session["VenueLst"];
            this.lstVenue.DataTextField = "VenueName";
            this.lstVenue.DataValueField = "VenueID";
            this.lstVenue.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlOrg.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select organization from list.";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTMeetingVenue obj = new ATTMeetingVenue();

        obj.OrgID = int.Parse(this.ddlOrg.SelectedValue);
        obj.VenueID = 0;
        obj.VenueName = this.txtVenue.Text;
        obj.VenueLocation = this.txtLocation.Text;

        ObjectValidation result = BLLMeetingVenue.Validate(obj);
        if (result.IsValid == false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.lstVenue.SelectedIndex < 0)
            obj.Action = "A";
        else
        {
            obj.VenueID = int.Parse(this.lstVenue.SelectedValue);
            obj.Action = "E";
        }

        try
        {
            BLLMeetingVenue.AddMeetingVenue(obj);
            if (obj.Action == "A")
                ((List<ATTMeetingVenue>)Session["VenueLst"]).Add(obj);
            else
                ((List<ATTMeetingVenue>)Session["VenueLst"])[this.lstVenue.SelectedIndex] = obj;

            Session["VenueLst"] = BLLMeetingVenue.GetMeetingVenueList(int.Parse(this.ddlOrg.SelectedValue));
            this.lstVenue.DataSource = Session["VenueLst"];
            this.lstVenue.DataTextField = "VenueName";
            this.lstVenue.DataValueField = "VenueID";
            this.lstVenue.DataBind();

            this.ClearME();
            this.lblStatusMessage.Text = "Venue successfully saved.";
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
        this.txtVenue.Text = "";
        this.txtLocation.Text = "";
        this.lstVenue.SelectedIndex = -1;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
}
