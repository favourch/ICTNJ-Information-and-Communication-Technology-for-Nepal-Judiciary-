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

public partial class MODULES_LJMS_LookUp_LeaveTypeJudge : System.Web.UI.Page
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
        Session["OrgID"] = 9;
        if (user.MenuList.ContainsKey("2,27,1") == true)
        {
            if (!IsPostBack)
            {
                LoadLeaveTypes();
				EnableAddControls(false);
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
                
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
            leaveTypeLst.Insert(0, new ATTLeaveType(0, "छान्नुहोस", "", ""));

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

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    void ClearControls(bool search, bool add, bool other)
    {
        if (search)
        {
            txtSymbolNo.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtSurName.Text = "";
            ddlSearchGender.SelectedIndex = -1;
            txtDOB.Text = "";
            ddlOrganization.SelectedIndex = 0;
            ddlDesignation.SelectedIndex = 0;
            grdEmployee.DataSource = null;
            grdEmployee.DataBind();
        }
        if (add)
        {


            txtDays.Text = "";
            rdblstPeriodTypes.SelectedIndex = -1;
            txtPeriodTimes.Text = "";
            chkIsAccural.Checked = false;
            txtAccuralDays.Text = "";
            txtEffectiveFrom.Text = "";
            //txtEffectiveTill.Text = "";
            chkIsActive.Checked = false;

        }
        if (other)
        {
            txtEmployee.Text = "";
            txtEmployee.Attributes.Clear();
            Session["LeaveTypeEmployee"] = new List<ATTLeaveTypeEmployee>();
            ddlLeaveTypes.SelectedIndex = -1;
            grdLeaveDetails.DataSource = null;
            grdLeaveDetails.DataBind();
        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtEmployee.Text = grdEmployee.SelectedRow.Cells[5].Text;


            txtEmployee.Attributes.Add("ID", grdEmployee.SelectedRow.Cells[0].Text);

            this.colEmployee.Collapsed = true;
            this.colEmployee.ClientState = "true";

            EnableAddControls(true);
            List<ATTLeaveTypeEmployee> lstLeaveTypeEmployee = BLLLeaveTypeEmployee.GetLeaveTypeEmployee(null, int.Parse(txtEmployee.Attributes["ID"].ToString()));
            Session["LeaveTypeEmployee"] = lstLeaveTypeEmployee;

            grdLeaveDetails.DataSource = lstLeaveTypeEmployee;
            grdLeaveDetails.DataBind();
            
            //if (lstLeaveTypeEmployee.Count > 0)
            //{
            //    pnlCol.Enabled = false;
            //    pnlEmployeeSearch.Enabled = false;
            //}

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ddlLeaveTypes.Enabled = true;
        try
        {
            int i = 0;
            string errmessage = "";

            if (txtEmployee.Text.Trim() == "" || txtEmployee.HasAttributes == false)
            { i++; errmessage += i.ToString() + ") कर्मचारि छान्नुहोस् <br />"; }

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

            ATTLeaveTypeEmployee leaveTypeEmployee = new ATTLeaveTypeEmployee();
            leaveTypeEmployee.LeaveTypeID = int.Parse(ddlLeaveTypes.SelectedValue);
            leaveTypeEmployee.LeaveType = ddlLeaveTypes.SelectedItem.ToString();
            //leaveTypeEmployee.EmpID = 0;
            leaveTypeEmployee.EmpID = int.Parse(txtEmployee.Attributes["ID"].ToString());
            leaveTypeEmployee.Days = int.Parse(txtDays.Text);
            leaveTypeEmployee.PeriodType = rdblstPeriodTypes.SelectedValue.ToString();
            if (rdblstPeriodTypes.SelectedIndex == 4)
            {
                leaveTypeEmployee.PeriodTimes = int.Parse(txtPeriodTimes.Text);
            }
            leaveTypeEmployee.IsAccural = chkIsAccural.Checked;
            if (chkIsAccural.Checked) { leaveTypeEmployee.AccuralDays = int.Parse(txtAccuralDays.Text); }
            else { leaveTypeEmployee.AccuralDays = null; }
            leaveTypeEmployee.Active = chkIsActive.Checked;
            leaveTypeEmployee.EffectiveFromDate = txtEffectiveFrom.Text;
            //leaveTypeEmployee.EffectiveTillDate = txtEffectiveTill.Text;
            leaveTypeEmployee.Action = "A";
            leaveTypeEmployee.EntryBy = entryBy;



            List<ATTLeaveTypeEmployee> lstLeaveTypeEmployee = (List<ATTLeaveTypeEmployee>)Session["LeaveTypeEmployee"];

            if (lstLeaveTypeEmployee == null)
            {
                lstLeaveTypeEmployee = new List<ATTLeaveTypeEmployee>();
            }
            if (lstLeaveTypeEmployee.Count > 0)
            {
                btnSave.Enabled = true;
            }
            foreach (ATTLeaveTypeEmployee leave in lstLeaveTypeEmployee)
            {
                if (leave.LeaveTypeID == int.Parse(ddlLeaveTypes.SelectedValue) && leave.EmpID == int.Parse(txtEmployee.Attributes["ID"].ToString()))
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
                //if (leave.LeaveTypeID == int.Parse(ddlLeaveTypes.SelectedValue) && leave.EmpID == int.Parse(txtEmployee.Attributes["ID"].ToString()) && leave.EffectiveFromDate == txtEffectiveFrom.Text)
                //{
                //    grdLeaveDetails.SelectedIndex = -1;
                //    i++;
                //    this.lblStatusMessage.Text = errmessage + i.ToString() + ") This Leave Type Already Exists. ";
                //    this.programmaticModalPopup.Show();

                //    return;
                //}
            }

            if (grdLeaveDetails.SelectedIndex == -1)
            {
                //if (lstLeaveTypeEmployee.Count > 0)
                //{
               
                //}
                lstLeaveTypeEmployee.Add(leaveTypeEmployee);
            }
            else
            {
                leaveTypeEmployee.Action = (lstLeaveTypeEmployee[grdLeaveDetails.SelectedIndex].Action == "A" ? "A" : "E");
                lstLeaveTypeEmployee[grdLeaveDetails.SelectedIndex] = leaveTypeEmployee;
                grdLeaveDetails.SelectedIndex = -1;
            }


            Session["LeaveTypeEmployee"] = lstLeaveTypeEmployee;
            grdLeaveDetails.DataSource = lstLeaveTypeEmployee;
            grdLeaveDetails.DataBind();
            ClearControls(false, true, false);

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

            List<ATTLeaveTypeEmployee> lstLeaveTypeEmployee = (List<ATTLeaveTypeEmployee>)Session["LeaveTypeEmployee"];

            if (BLLLeaveTypeEmployee.SaveLeaveTypeEmployee(lstLeaveTypeEmployee))
            {
                ClearControls(true, true, true);
                //btnSave.Visible = true;
                //btnCancel.Visible = true;
                pnlCol.Enabled = true;
                pnlEmployeeSearch.Enabled = true;
                this.lblSearch.Text = "";
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

            List<ATTLeaveTypeEmployee> lst = (List<ATTLeaveTypeEmployee>)Session["LeaveTypeEmployee"];
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(true, true, true);
        pnlCol.Enabled = true;
        pnlEmployeeSearch.Enabled = true;
        this.lblSearch.Text = "";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;
        this.lblSearch.Text = "";
        if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
            && this.ddlSearchGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "" && this.ddlMarStatus.SelectedIndex == 0
            && this.ddlOrganization.SelectedIndex == 0 && this.ddlDesignation.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                //lst = BLLEmployeeSearch.SearchEmployee(GetFilter());
                Session["EmpSearchResult"] = BLLEmployeeSearch.SearchEmployee(GetFilter());
                lst = (List<ATTEmployeeSearch>)Session["EmpSearchResult"];
                this.lblSearch.Text = lst.Count.ToString() + " records found.";
                this.grdEmployee.DataSource = lst;
                this.grdEmployee.DataBind();

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }

    void LoadDesignations()
    {
        string desType = "J";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    void LoadOrganizationWithChilds(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));

            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    private ATTEmployeeSearch GetFilter()
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
        if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.txtFName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurName.Text.Trim();
        if (this.ddlSearchGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlSearchGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        //EmployeeSearch.DesType = "J";
        EmployeeSearch.IniType = 2;

        return EmployeeSearch;
    }
}
