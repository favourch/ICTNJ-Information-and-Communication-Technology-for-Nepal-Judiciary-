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
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_LookUp_MeetingStatus : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("5,2,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadMeetingStatus();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadMeetingStatus()
    {
        Session["MeetingStatusLst"] = BLLMeetingStatus.GetMeetingStatusList(null, false);
        this.lstMeetingStatus.DataSource = Session["MeetingStatusLst"];
        this.lstMeetingStatus.DataTextField = "MeetingStatusName";
        this.lstMeetingStatus.DataValueField = "MeetingStatusID";
        this.lstMeetingStatus.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTMeetingStatus status = new ATTMeetingStatus();
        status.MeetingStatusName = this.txtMeetingStatus.Text;

        if (this.lstMeetingStatus.SelectedIndex < 0)
        {
            status.MeetingStatusID = 0;
            status.MeetingStatusColor = this.ColorPicker.Color;
            status.Action = "A";
        }
        else
        {
            status.MeetingStatusID = ((List<ATTMeetingStatus>)Session["MeetingStatusLst"])[this.lstMeetingStatus.SelectedIndex].MeetingStatusID;
            status.MeetingStatusColor = this.ColorPicker.Color;
            status.Action = "E";
        }

        ObjectValidation result = BLLMeetingStatus.Validate(status);
        if (result.IsValid==false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLMeetingStatus.AddMeetingStatus(status);
            List<ATTMeetingStatus> lst = ((List<ATTMeetingStatus>)Session["MeetingStatusLst"]);

            if (status.Action == "A")
                lst.Add(status);
            else
                lst[this.lstMeetingStatus.SelectedIndex] = status;

            this.lstMeetingStatus.DataSource = lst;
            this.lstMeetingStatus.DataTextField = "MeetingStatusName";
            this.lstMeetingStatus.DataValueField = "MeetingStatusID";
            this.lstMeetingStatus.DataBind();

            this.ClearME();
            this.lstMeetingStatus.SelectedIndex = -1;

            this.lblStatusMessage.Text = "Meeting status successfully saved.";
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
        this.txtMeetingStatus.Text = "";
        this.ColorPicker.Color = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.lstMeetingStatus.SelectedIndex = -1;
    }

    protected void lstMeetingStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTMeetingStatus> lst = (List<ATTMeetingStatus>)Session["MeetingStatusLst"];
        this.txtMeetingStatus.Text = lst[this.lstMeetingStatus.SelectedIndex].MeetingStatusName;
        this.ColorPicker.Color = lst[this.lstMeetingStatus.SelectedIndex].MeetingStatusColor;
    }
}
