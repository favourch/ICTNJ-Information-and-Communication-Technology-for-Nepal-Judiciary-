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
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

public partial class MODULES_PMS_Forms_EmployeeLeaveApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        //if (user.MenuList.ContainsKey("3,57,1") == true)
        //{
            Session["UserName"] = user.UserName;
            Session["UserID"] = user.PID;
            txtEmpName.Text = user.UserName;
            if (!IsPostBack)
            {
                GetLeaveType();

            }
        //}

        //else
        //{
        //    Response.Redirect("~/MODULES/Login.aspx", true);
        //}
    }

    void GetLeaveType()
    {
        List<ATTLeaveType> lstLeaveType = BLLLeaveType.GetLeaveType(null, "Y");

        lstLeaveType.Insert(0, new ATTLeaveType(0, "-- छान्नुहोस --", ""));
        ddlAppType.DataSource = lstLeaveType;
        ddlAppType.DataTextField = "LeaveTypeName";
        ddlAppType.DataValueField = "LeaveTypeID";
        ddlAppType.DataBind();
           
    }

    protected void btnApplSubmit_Click(object sender, EventArgs e)
    {
        if (ddlAppType.SelectedIndex == 0)
        {
            lblStatusMessage.Text ="Please Select leave Type first";
            programmaticModalPopup.Show();
            return;
        }
        if (txtEmpDate.Text=="")
        {
            lblStatusMessage.Text = "Please Enter Application Date first";
            programmaticModalPopup.Show();
            return;
        }

        List<ATTEmployeeLeave> LSTEmpLeave = new List<ATTEmployeeLeave>();
        try
        {
            ATTEmployeeLeave att = new ATTEmployeeLeave();
            att.EmpID = int.Parse(Session["UserID"].ToString());
            att.EmpFullName = Session["UserName"].ToString();
            att.ReqdFrom = txtEmpLvFrom.Text;
            att.ReqdTo = txtEmpLvTo.Text;
            att.LeaveTypeID = int.Parse(this.ddlAppType.SelectedValue.ToString());
            att.EmpDays = int.Parse(txtEmpLvDays.Text.ToString());
            att.ApplDate = txtEmpDate.Text;
            att.EmpReason = txtEmpLvResn.Text;
            att.EntryBy = Session["UserName"].ToString();
            att.EntryDate = "";
            att.Action = "A";
            LSTEmpLeave.Add(att);

            if (BLLEmployeeLeave.SaveEmpLeaveApplication(LSTEmpLeave))
            {
                ClearControls();
                lblStatusMessage.Text = "Saved Successfully";
                programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void txtEmpLvTo_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        string errmessage = "<P><b><U>! Attention </U></b></P>";
        string s = IsDateValid(txtEmpLvFrom, txtEmpLvTo);
        try
        {
            int timespan = int.Parse(s);
            txtEmpLvDays.Text = s;
        }
        catch (Exception)
        {

            if (s == "a")
            {
                i++;
                errmessage += i.ToString() + ") अवधि देखि राख्न्नु होस् ?????? <br />";
            }
            //else if (s == "b")
            //{
            //    i++; errmessage += i.ToString() + ") Effective Till Date ?????? <br />";
            //}
            else if (s == "ab")
            {
                i++;
                errmessage += i.ToString() + ")  अवधि देखि राख्न्नु होस् ??????<br />";
                i++;
                errmessage += i.ToString() + ") अवधि सम्म राख्न्नु होस् ?????? <br />";
            }
            else if (s == "Invalid Date")
            {
                i++;
                errmessage += i.ToString() + ")" + s + " <br />";
            }
        }

        if (i > 0)
        {
            this.lblStatusMessage.Text = errmessage;
            this.programmaticModalPopup.Show();
            return;
        }
        txtEmpDate.Text = Session["NepDate"].ToString();

    }

    public string IsDateValid(TextBox txt1, TextBox txt2)
    {
        DateTime dt1;
        DateTime dt2;

        string msg = "";
        string msg1 = "";
        string msg2 = "";

        try
        {
            if (txt1.Text.Trim() == "" || txt1.Text.Trim() == "____/__/__")
            {
                msg1 = "अवधि देखि राख्न्नु होस्";
                return msg1;
            }

            if (txt2.Text.Trim() == "" || txt2.Text.Trim() == "____/__/__")
            {
                msg2 = "अवधि सम्म राख्न्नु होस्";
            }

            if (msg1 == "" && msg2 != "")
            {
                msg = "b";
            }
            else if (msg1 != "" && msg2 == "")
            {
                msg = "a";
            }
            else if (msg1 != "" && msg2 != "")
            {
                msg = "ab";
            }

            if (msg != "")
            {
                return msg;

            }

            dt1 = DateTime.Parse(txt1.Text.Trim());
            dt2 = DateTime.Parse(txt2.Text.Trim());

        }
        catch (Exception)
        {
            this.lblStatusMessage.Text = "ठिक मिति रख्न्नुहोस्";
            this.programmaticModalPopup.Show();
            txt1.Text = "";
            txt2.Text = "";
            txt1.Focus();
            return "";
        }

        TimeSpan timespan = dt2.Subtract(dt1) + new TimeSpan(1, 0, 0, 0);
        if (timespan <= new TimeSpan(0, 0, 0, 0))
        {
            txt1.Text = "";
            txt2.Text = "";
            return "अवधि देखि कम अथवा अवधि सम्म बढि हुनुपर्छ ।।। सच्याउनुहोस्";

        }
        else
        {
            return timespan.Days.ToString();
        }
    }

    void ClearControls()
    {
        txtEmpDate.Text = "";
        txtEmpLvFrom.Text = "";
        txtEmpLvTo.Text = "";
        ddlAppType.SelectedIndex = 0;
        txtEmpLvDays.Text = "";
        txtEmpLvResn.Text = "";
       
    }

    protected void btnApplCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
}
