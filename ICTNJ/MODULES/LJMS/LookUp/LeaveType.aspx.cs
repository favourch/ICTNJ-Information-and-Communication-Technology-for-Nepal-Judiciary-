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

public partial class MODULES_LJMS_LookUp_LeaveType : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,24,1") == true)
        {
            if (!IsPostBack)
            {
                ClearControl();
                GetLeaveType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void GetLeaveType()
    {

        try
        {
            List<ATTLeaveType> LstLeaveType = BLLLeaveType.GetLeaveType(null, null);
            Session["LeaveType"] = LstLeaveType;

            lstLeaveType.DataSource = LstLeaveType;
            lstLeaveType.DataTextField = "LeaveTypeName";
            lstLeaveType.DataValueField = "LeaveTypeID";
            lstLeaveType.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTLeaveType> LeaveTypeList = (List<ATTLeaveType>)Session["LeaveType"];
        int LeaveTypeID;

        if (lstLeaveType.SelectedIndex == -1)
            LeaveTypeID = 0;
        else
            LeaveTypeID = LeaveTypeList[lstLeaveType.SelectedIndex].LeaveTypeID;

        try
        {
            ATTLeaveType ObjAtt = new ATTLeaveType
                (
                 LeaveTypeID,
                 txtLeveType_Rqd.Text.Trim(),
                 (this.ddlGender.SelectedIndex > 0) ? this.ddlGender.SelectedValue.Trim() : "A",
                (this.chkLeaveType.Checked == true ? "Y" : "N")
             );


            ObjectValidation OV = BLLLeaveType.Validate(ObjAtt);
            if (OV.IsValid == false)
            {
                lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }

            for (int i = 0; i < lstLeaveType.Items.Count; i++)
            {
                if (lstLeaveType.SelectedIndex != i)
                {
                    if (LeaveTypeList[i].LeaveTypeName.ToLower() == txtLeveType_Rqd.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Leave Type Name Already Exists";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }




            BLLLeaveType.SaveLeaveType(ObjAtt);

            if (lstLeaveType.SelectedIndex > -1)
            {
                LeaveTypeList[lstLeaveType.SelectedIndex].LeaveTypeID = ObjAtt.LeaveTypeID;
                LeaveTypeList[lstLeaveType.SelectedIndex].LeaveTypeName = ObjAtt.LeaveTypeName;
                LeaveTypeList[lstLeaveType.SelectedIndex].Gender = ObjAtt.Gender;
                LeaveTypeList[lstLeaveType.SelectedIndex].Active = ObjAtt.Active;
            }

            else
            {
                LeaveTypeList.Add(ObjAtt);
            }


            lstLeaveType.DataSource = LeaveTypeList;
            lstLeaveType.DataTextField = "LeaveTypeName";
            lstLeaveType.DataValueField = "LeaveTypeID";
            lstLeaveType.DataBind();

            ClearControl();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTLeaveType> LeaveTypeList = (List<ATTLeaveType>)Session["LeaveType"];

            if (lstLeaveType.SelectedIndex > -1)
            {
                BLLLeaveType.DeleteLeaveType(int.Parse(lstLeaveType.SelectedValue.ToString()));

                LeaveTypeList.RemoveAt(lstLeaveType.SelectedIndex);

                lstLeaveType.DataSource = LeaveTypeList;
                lstLeaveType.DataTextField = "LeaveTypeName";
                lstLeaveType.DataValueField = "LeaveTypeID";
                lstLeaveType.DataBind();

                Session["LeaveType"] = LeaveTypeList;
             
                txtLeveType_Rqd.Text = "";
                lstLeaveType.SelectedIndex = -1;
                chkLeaveType.Checked = false;
               
            }
            else
            {
                this.lblStatusMessage.Text = "Select Leave Type for Delete";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControl();
    }


    void ClearControl()
    {
        txtLeveType_Rqd.Text = "";
        this.ddlGender.SelectedIndex = 0;
        chkLeaveType.Checked = true;
        lstLeaveType.SelectedIndex = -1;
         
    }
    protected void lstLeaveType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTLeaveType> LeaveTypeList = (List<ATTLeaveType>)Session["LeaveType"];
        ATTLeaveType Att = LeaveTypeList[lstLeaveType.SelectedIndex];

        try
        {
            txtLeveType_Rqd.Text = Att.LeaveTypeName.ToString();
            if (Att.Gender != "A")
                this.ddlGender.SelectedValue = Att.Gender;
            else
                this.ddlGender.SelectedIndex = 0;
            if (Att.Active == "Y")
                chkLeaveType.Checked = true;
            else
                chkLeaveType.Checked = false;


        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
}
