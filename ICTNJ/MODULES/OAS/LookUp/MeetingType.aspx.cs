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

public partial class MODULES_OAS_LookUp_MeetingType : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("5,1,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadMeetingType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadMeetingType()
    {
        try
        {
            Session["MeetingTypeLst"] = BLLMeetingType.GetMeetingTypeList();
            this.lstMeetingType.DataSource = Session["MeetingTypeLst"];
            this.lstMeetingType.DataTextField = "MeetingTypeName";
            this.lstMeetingType.DataValueField = "MeetingTypeID";
            this.lstMeetingType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTMeetingType Mtype = new ATTMeetingType();
        Mtype.MeetingTypeName = this.txtMeetingType.Text;
        Mtype.MeetingTypeDesc = this.txtDescription.Text;

        if (this.lstMeetingType.SelectedIndex < 0)//add mode
        {
            Mtype.MeetingTypeID = 0;
            Mtype.Action = "A";
        }
        else //edit mode
        {
            Mtype.MeetingTypeID = ((List<ATTMeetingType>)Session["MeetingTypeLst"])[this.lstMeetingType.SelectedIndex].MeetingTypeID;
            Mtype.Action = "E";
        }

        ObjectValidation result = BLLMeetingType.Validate(Mtype);
        if (result.IsValid == false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLMeetingType.AddMeetingType(Mtype);
            List<ATTMeetingType> lst = ((List<ATTMeetingType>)Session["MeetingTypeLst"]);

            if (Mtype.Action == "A")
                lst.Add(Mtype);
            else
                lst[this.lstMeetingType.SelectedIndex] = Mtype;

            this.lstMeetingType.DataSource = lst;
            this.lstMeetingType.DataTextField = "MeetingTypeName";
            this.lstMeetingType.DataValueField = "MeetingTypeID";
            this.lstMeetingType.DataBind();

            this.ClearME();
            this.lstMeetingType.SelectedIndex = -1;
            this.lblStatusMessage.Text = "Meeting Type successfully saved.";
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
        this.txtMeetingType.Text = "";
        this.txtDescription.Text = "";
    }

    protected void lstMeetingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTMeetingType obj = ((List<ATTMeetingType>)Session["MeetingTypeLst"])[this.lstMeetingType.SelectedIndex];
        
        this.ClearME();

        this.txtMeetingType.Text = obj.MeetingTypeName;
        this.txtDescription.Text = obj.MeetingTypeDesc;
    }
}
