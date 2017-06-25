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
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.FRAMEWORK;


public partial class MODULES_OAS_LookUp_AppointmentStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            GetAppointmentStatusList();
        }


    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void GetAppointmentStatusList()
    {
        Session["AppointmentStatus"] = BLLAppointmentStatus.GetMeetingStatusList(null, false);
        List<ATTAppointmentStatus> listAppntStatus = (List<ATTAppointmentStatus>)Session["AppointmentStatus"];
        lstAppointmentStatus.DataSource = listAppntStatus;
        lstAppointmentStatus.DataTextField = "AppointmentStatusName";
        lstAppointmentStatus.DataValueField = "AppointmentStatusID";
        lstAppointmentStatus.DataBind();
    }

    protected void lstAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
       // ClearControls();
         List<ATTAppointmentStatus> listAppntStatus = (List<ATTAppointmentStatus>)Session["AppointmentStatus"];
         this.txtAppointmentStatus.Text = this.lstAppointmentStatus.SelectedItem.ToString();
        this.ColorPicker.Color = listAppntStatus[this.lstAppointmentStatus.SelectedIndex].AppointmentStatusColor.ToString();
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTAppointmentStatus attObj = new ATTAppointmentStatus();
        attObj.AppointmentStatusName = txtAppointmentStatus.Text;
        attObj.AppointmentStatusColor = ColorPicker.Color.ToString();

        if (lstAppointmentStatus.SelectedIndex < 0)
        {
            //add
            attObj.Action = "A";

        }
        else if (lstAppointmentStatus.SelectedIndex > -1)
        {
            //edit
            attObj.Action = "E";
             attObj.AppointmentStatusID = int.Parse(this.lstAppointmentStatus.SelectedValue);
        }

        ObjectValidation result = BLLAppointmentStatus.Validate(attObj);
        if (result.IsValid == false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLAppointmentStatus.AddAppointmentStatus(attObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        List<ATTAppointmentStatus> lst = (List<ATTAppointmentStatus>)Session["AppointmentStatus"];

        if (this.lstAppointmentStatus.SelectedIndex > -1)
        {
            lst[this.lstAppointmentStatus.SelectedIndex].AppointmentStatusName = attObj.AppointmentStatusName;
            lst[this.lstAppointmentStatus.SelectedIndex].AppointmentStatusID = attObj.AppointmentStatusID;
        }
        else
            lst.Add(attObj);
        this.lstAppointmentStatus.DataSource = lst;
        lstAppointmentStatus.DataBind();

        ClearControls();
    }

    protected void ClearControls()
    {
        this.txtAppointmentStatus.Text = "";
        this.lstAppointmentStatus.SelectedIndex = -1;
        this.ColorPicker.Color = "";
            
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
}
