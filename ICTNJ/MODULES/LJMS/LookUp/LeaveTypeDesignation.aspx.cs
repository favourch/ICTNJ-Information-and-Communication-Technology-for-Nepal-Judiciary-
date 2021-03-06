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
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.SECURITY.ATT;

public partial class MODULES_LJMS_LookUp_LeaveTypeDesignation : System.Web.UI.Page
{
    string entryBy = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        entryBy = user.UserName;
        if (user.MenuList.ContainsKey("2,25,1") == true)
        {
            if (!IsPostBack)
            {
                LoadLeaveTypes();
                LoadDesignation();
				EnableAddControls(false);
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    private void LoadLeaveTypes()
    {
        try
        {
            List<ATTLeaveType> leaveTypeLst = BLLLeaveType.GetLeaveType(null, "Y");
            leaveTypeLst.Insert(0, new ATTLeaveType(0, "छान्नुहोस", "",""));

            ddlLeaveTypes.DataTextField = "LeaveTypeName";
            ddlLeaveTypes.DataValueField = "LeaveTypeID";

            ddlLeaveTypes.DataSource = leaveTypeLst;
            ddlLeaveTypes.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    private void LoadDesignation()
    {
        try
        {
            List<ATTDesignation> lstDesignation = BLLDesignation.GetDesignation(null,"J");
            lstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));

            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationID";

            ddlDesignation.DataSource = lstDesignation;
            ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show(); 
        }
        
    }
   
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    void ClearControls(bool Add, bool Other)
    {
        if (Add)
        {
            ddlDesignation.SelectedIndex = 0;
            txtDays.Text = "";
            rdblstPeriodTypes.SelectedIndex = -1;
            txtPeriodTimes.Text = "";
            chkIsAccural.Checked = false;
            txtAccuralDays.Text = "";
            txtEffectiveFrom.Text = "";
            //txtEffectiveTill.Text = "";
            chkIsActive.Checked = false;
        }

        if (Other)
        {
            ddlDesignation.Enabled = true;
            Session["LeaveTypeDesignation"] = new List<ATTLeaveTypeDesignation>();
            grdLeaveDetails.DataSource = null;
            grdLeaveDetails.DataBind();
            ddlLeaveTypes.SelectedIndex = -1;
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ddlLeaveTypes.Enabled = true;
        try
        {
            int i = 0;
            string errmessage = "";

            if (ddlDesignation.SelectedIndex < 1)
            { i++; errmessage += i.ToString() + ") Designation छान्नुहोस् <br />"; }

            if (ddlLeaveTypes.SelectedIndex < 1)
            { i++; errmessage += i.ToString() + ") बिदा छान्नुहोस् <br />"; }

            if (txtDays.Text.Trim() == "" || txtDays.Text.Trim() == "0")
            { i++; errmessage += i.ToString() + ") बिदाको दिन छुट्यो  <br />"; }


            if (rdblstPeriodTypes.SelectedIndex < 0)
            { i++; errmessage += i.ToString() + ") अवधि छान्नुहोस्  <br />"; }
            if (rdblstPeriodTypes.SelectedIndex == 4)
            {
                if (txtPeriodTimes.Text.Trim() == "" || txtPeriodTimes.Text.Trim() == "0")
                { i++; errmessage += i.ToString() + ") अवधिको दिन छुट्यो <br />"; }
            }            

            if (chkIsAccural.Checked)
            {
                if (txtAccuralDays.Text.Trim() == "" || txtAccuralDays.Text.Trim() == "0")
                { i++; errmessage += i.ToString() + ") जम्मा हुने दिन छुट्यो <br />"; }
            }
            if (txtEffectiveFrom.Text == "")
            { i++; errmessage += i.ToString() + ") लागु हुने मिति छुट्यो <br />"; }
            //else
            //{
            //   string engDate= BLLDate.getEngDate(txtEffectiveFrom.Text);
            //   try
            //   {
            //       DateTime engDt=DateTime.Parse(
            //   }
            //   catch (Exception)
            //   {

            //       throw;
            //   }
            //}

            if (i > 0)
            {
                this.lblStatusMessage.Text = errmessage;
                this.programmaticModalPopup.Show();
                return;

            }

            ATTLeaveTypeDesignation leaveTypeDesignation = new ATTLeaveTypeDesignation();
            leaveTypeDesignation.LeaveTypeID = int.Parse(ddlLeaveTypes.SelectedValue);
            leaveTypeDesignation.LeaveType = ddlLeaveTypes.SelectedItem.ToString();
            //leaveTypeEmployee.EmpID = 0;
            leaveTypeDesignation.DesignationID = int.Parse(ddlDesignation.SelectedValue);
            leaveTypeDesignation.Days = int.Parse(txtDays.Text);
            leaveTypeDesignation.PeriodType = rdblstPeriodTypes.SelectedValue.ToString();
            if (rdblstPeriodTypes.SelectedIndex == 4)
            {
                leaveTypeDesignation.PeriodTimes = int.Parse(txtPeriodTimes.Text);
            }
            leaveTypeDesignation.IsAccural = chkIsAccural.Checked;
            if (chkIsAccural.Checked) { leaveTypeDesignation.AccuralDays = int.Parse(txtAccuralDays.Text); }
            else { leaveTypeDesignation.AccuralDays = null; }
            leaveTypeDesignation.Active = chkIsActive.Checked;
            leaveTypeDesignation.EffectiveFromDate = txtEffectiveFrom.Text;
            //leaveTypeDesignation.EffectiveTillDate = txtEffectiveTill.Text;
            leaveTypeDesignation.Action = "A";
            leaveTypeDesignation.EntryBy = entryBy;


            List<ATTLeaveTypeDesignation> lstLeaveTypeDesignation = (List<ATTLeaveTypeDesignation>)Session["LeaveTypeDesignation"];

            if (lstLeaveTypeDesignation == null)
            {
                lstLeaveTypeDesignation = new List<ATTLeaveTypeDesignation>();
            }
            if (lstLeaveTypeDesignation.Count > 0)
            {
                btnSave.Enabled = true;
            }

            foreach (ATTLeaveTypeDesignation leave in lstLeaveTypeDesignation)
            {
                if (leave.LeaveTypeID == int.Parse(ddlLeaveTypes.SelectedValue) && leave.DesignationID == int.Parse(ddlDesignation.SelectedValue))
                {

                    string[] data = leave.EffectiveFromDate.Split('/');
                    string[] data1 = txtEffectiveFrom.Text.Split('/');

                    int dataYR = int.Parse(data[0]);
                    int dataMTH = int.Parse(data[1]);
                    int dataDY = int.Parse(data[2]);

                    int data1YR = int.Parse(data1[0]);
                    int data1MTH = int.Parse(data1[1]);
                    int data1DY = int.Parse(data1[2]);


                    bool val = false;
                    if (data1YR < dataYR)
                    {
                        val = true;
                    }
                    else if (data1YR == dataYR)
                    {
                        if (data1MTH < dataMTH)
                        {
                            val = true;
                        }
                        else if (data1MTH == dataMTH)
                        {
                            if (data1DY <= dataDY)
                            {
                                val = true;
                            }
                        }
                    }


                    if (val)
                    {
                        grdLeaveDetails.SelectedIndex = -1;
                        i++;
                        this.lblStatusMessage.Text = errmessage + i.ToString() + ") This Leave Type Already Exists.So New EffectiveFromDate Must Be Greater Than Old EffectiveFromDate ";
                        this.programmaticModalPopup.Show();

                        return;
                    }
                }
            }
            if (grdLeaveDetails.SelectedIndex == -1)
            {
                //if (lstLeaveTypeDesignation.Count > 0)
                //{
                
                //}
                lstLeaveTypeDesignation.Add(leaveTypeDesignation);
            }
            else
            {
                leaveTypeDesignation.Action = (lstLeaveTypeDesignation[grdLeaveDetails.SelectedIndex].Action == "A" ? "A" : "E");
                lstLeaveTypeDesignation[grdLeaveDetails.SelectedIndex] = leaveTypeDesignation;
                grdLeaveDetails.SelectedIndex = -1;
            }
            
            Session["LeaveTypeDesignation"] = lstLeaveTypeDesignation;
            grdLeaveDetails.DataSource = lstLeaveTypeDesignation;
            grdLeaveDetails.DataBind();
            ClearControls(true,false);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
            return;
        }

    }
    public string IsDateValid()
    {
        DateTime dt1;
        //DateTime dt2;

        //string msg="";
        string msg1 = "";
        //string msg2="";

        try
        {
            if (this.txtEffectiveFrom.Text.Trim() == "" || this.txtEffectiveFrom.Text.Trim() == "____/__/__")
            {
                msg1 = "Effective From Date Missing";
                return msg1;
            }

            //if (this.txtEffectiveTill.Text.Trim() == "" || this.txtEffectiveTill.Text.Trim() == "____/__/__")
            //{
            //    msg2 = "Effective Till Date Missing";
            //}

            //if (msg1 == "" && msg2 != "")
            //{
            //    msg = "2";
            //}
            //else if (msg1 != "" && msg2 == "")
            //{
            //    msg = "1";
            //}
            //else if (msg1 != "" && msg2 != "")
            //{
            //    msg = "12";
            //}

            //if (msg!="")
            //{
            //    return msg;

            //}

            dt1 = DateTime.Parse(txtEffectiveFrom.Text.Trim());
            return msg1;
            //dt2 = DateTime.Parse(txtEffectiveTill.Text.Trim());            

        }
        catch (Exception)
        {
            txtEffectiveFrom.Text = "";
            //txtEffectiveTill.Text = "";
            return "Invalid Date";

        }

        //TimeSpan timespan = dt2.Subtract(dt1);
        //if (timespan <= new TimeSpan(0, 0, 0, 0))
        //{
        //    txtEffectiveTill.Text = "";
        //    return "From Date must be less than To Date";  

        //}
        //else
        //{
        //    return "";
        //}

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdLeaveDetails.Rows.Count < 1)
                return;            

            List<ATTLeaveTypeDesignation> lstLeaveTypeDesignation = (List<ATTLeaveTypeDesignation>)Session["LeaveTypeDesignation"];
           
            if (BLLLeaveTypeDesignation.SaveLeaveTypeDesignation(lstLeaveTypeDesignation))
            {
                ClearControls(true,true);
                //btnSave.Visible = true;
                //btnCancel.Visible = true;
                //Panel2.Enabled = true;
                //Panel3.Enabled = true;
                this.lblStatusMessage.Text = "Information Saved.";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessage.Text = "Problem Saving Information .";
                this.programmaticModalPopup.Show();
            }



        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
            return;

        }
    }
    protected void grdLeaveDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string str = grdLeaveDetails.SelectedRow.Cells[1].Text.Trim();

            ddlLeaveTypes.SelectedValue = grdLeaveDetails.SelectedRow.Cells[0].Text.Trim();
            txtDays.Text = grdLeaveDetails.SelectedRow.Cells[3].Text.Trim();
            rdblstPeriodTypes.SelectedValue = grdLeaveDetails.SelectedRow.Cells[4].Text.Trim();
            txtPeriodTimes.Text = grdLeaveDetails.SelectedRow.Cells[5].Text.Trim();
            chkIsAccural.Checked = bool.Parse(grdLeaveDetails.SelectedRow.Cells[6].Text.Trim());
            txtAccuralDays.Text = grdLeaveDetails.SelectedRow.Cells[7].Text.Trim();
            txtEffectiveFrom.Text = grdLeaveDetails.SelectedRow.Cells[8].Text.Trim();
            //txtEffectiveTill.Text = grdLeaveDetails.SelectedRow.Cells[9].Text.Trim();
            chkIsActive.Checked = bool.Parse(grdLeaveDetails.SelectedRow.Cells[10].Text.Trim());

            List<ATTLeaveTypeDesignation> lst = (List<ATTLeaveTypeDesignation>)Session["LeaveTypeDesignation"];
            if (lst[grdLeaveDetails.SelectedIndex].Action == "" ||
                lst[grdLeaveDetails.SelectedIndex].Action == "E")
            {
                ddlLeaveTypes.Enabled = false;
                txtEffectiveFrom.ReadOnly = true;
            }
            else
            {
                ddlLeaveTypes.Enabled = true;
                txtEffectiveFrom.ReadOnly = false;
            }
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show(); 
        }
        
    }
    protected void chkIsAccural_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsAccural.Checked) { txtAccuralDays.ReadOnly = false; }
        else { txtAccuralDays.Text = ""; txtAccuralDays.ReadOnly = true; }



    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDesignation.SelectedIndex<1)
        {
            grdLeaveDetails.DataSource = null;
            grdLeaveDetails.DataBind();
            return;
        }
        try
        {

            EnableAddControls(true);
            List<ATTLeaveTypeDesignation> lstLeaveTypeDesignation = BLLLeaveTypeDesignation.GetLeaveTypeDesignation(null, int.Parse(ddlDesignation.SelectedValue));
            Session["LeaveTypeDesignation"] = lstLeaveTypeDesignation;
            //if (lstLeaveTypeDesignation.Count>0)
            //{
            //    ddlDesignation.Enabled = false;
            //}

            grdLeaveDetails.DataSource = lstLeaveTypeDesignation;
            grdLeaveDetails.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(true,true);
        //Panel2.Enabled = true;
        //Panel3.Enabled = true;
    }
    protected void grdLeaveDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[13].Visible = false;
    }



    protected void rdblstPeriodTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblstPeriodTypes.SelectedIndex == 4)
        {
            txtPeriodTimes.Text = "";
            txtPeriodTimes.ReadOnly = false;
            chkIsAccural.Checked = false;
            chkIsAccural.Enabled = false;
            txtAccuralDays.Text = "";
            txtAccuralDays.ReadOnly = true;
        }
        else if (rdblstPeriodTypes.SelectedIndex == 0 || rdblstPeriodTypes.SelectedIndex == 1 || rdblstPeriodTypes.SelectedIndex == 2 || rdblstPeriodTypes.SelectedIndex == 3)
        {
            txtPeriodTimes.Text = "";
            txtPeriodTimes.ReadOnly = true;
            chkIsAccural.Checked = true;
            chkIsAccural.Enabled = true;
            txtAccuralDays.Text = "";
            txtAccuralDays.ReadOnly = false;
        }

    }

    void EnableAddControls(bool enable)
    {

        ddlLeaveTypes.SelectedIndex = -1;
        txtDays.Text = "";
        rdblstPeriodTypes.SelectedIndex = -1;
        txtPeriodTimes.Text = "";
        chkIsAccural.Checked = true;
        txtAccuralDays.Text = "";
        txtEffectiveFrom.Text = "";
        chkIsActive.Checked = false;
        if (enable)
        {
            ddlLeaveTypes.Enabled = true;
            txtDays.ReadOnly = false;
            rdblstPeriodTypes.Enabled = true;
            txtPeriodTimes.ReadOnly = false;
            chkIsAccural.Enabled = true;
            txtAccuralDays.ReadOnly = true;
            txtEffectiveFrom.ReadOnly = false;
            chkIsActive.Enabled = true;

        }
        else
        {
            ddlLeaveTypes.Enabled = false;
            txtDays.ReadOnly = true;
            //rdblstPeriodTypes.Enabled = false;
            txtPeriodTimes.ReadOnly = true;
            chkIsAccural.Enabled = false;
            txtAccuralDays.ReadOnly = true;
            txtEffectiveFrom.ReadOnly = true;
            chkIsActive.Enabled = false;
        }

    }
}
