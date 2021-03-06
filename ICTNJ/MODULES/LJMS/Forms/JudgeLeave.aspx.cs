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

public partial class MODULES_LJMS_Forms_JudgeLeave : System.Web.UI.Page
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

        if (user.MenuList.ContainsKey("2,22,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
            }
        }
        else
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    //gridview events
  
    protected void grdLeaveApplications_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtEmpName.Text = grdLeaveApplications.SelectedRow.Cells[1].Text.Trim();
            txtEmpDate.Text = grdLeaveApplications.SelectedRow.Cells[4].Text.Trim();
            ddlAppType.SelectedValue = grdLeaveApplications.SelectedRow.Cells[2].Text.Trim();
            txtEmpLvFrom.Text = grdLeaveApplications.SelectedRow.Cells[5].Text.Trim();
            txtEmpLvTo.Text = grdLeaveApplications.SelectedRow.Cells[6].Text.Trim();
            txtEmpLvDays.Text = grdLeaveApplications.SelectedRow.Cells[7].Text.Trim();
            txtEmpLvResn.Text = Server.HtmlDecode(grdLeaveApplications.SelectedRow.Cells[8].Text.Trim()).ToString();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();

        }
    }
    protected void grdLeaveApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[10].Text == "Y")
            {
                //e.Row.Cells[11].Enabled = false
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkselect");
                btn.Enabled = false;
            }
        }
    }
    protected void grdLeaveApplications_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LinkButton btn = (LinkButton)grdLeaveApplications.Rows[e.RowIndex].FindControl("lnkDelete");
        List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];

        if (btn.Text == "Delete")
        {
            lstEmployeeLeave[e.RowIndex].Action = "D";
            //ClearControls(false);
        }
        else if (btn.Text == "Undo")
        {
            lstEmployeeLeave[e.RowIndex].Action = "E";
            //ClearControls(false);
        }
        //}
        grdLeaveApplications.DataSource = lstEmployeeLeave;
        grdLeaveApplications.DataBind();

        Session["EmployeeLeave"] = lstEmployeeLeave;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);

        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";

        string Name = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
        int id = 0;
        List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();

        id = int.Parse(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
        txtEmpName.Text = Name;
        txtEmpName.Attributes.Add("ID", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
        lstEmployeeLeave = BLLEmployeeLeave.GetEmployeeLeave(id, "REQ");
        grdEmployee.SelectedIndex = -1;
        Session["EmployeeLeave"] = lstEmployeeLeave;
        grdLeaveApplications.DataSource = lstEmployeeLeave;
        grdLeaveApplications.DataBind();

        //Loading Leave Type Drop Down List

        int eid = int.Parse(txtEmpName.Attributes["ID"].ToString());
        List<ATTEmployeeLeave> LSTEmpDesLeave = BLLEmployeeLeave.GetEmpDesLeave(eid);
        //LSTEmpDesLeave.Insert(0, new ATTEmployeeLeave(0, 0, "-बिदाको किसिम छान्नुहोस्-"));
        ddlAppType.DataSource = LSTEmpDesLeave;
        ddlAppType.DataTextField = "LeaveType";
        ddlAppType.DataValueField = "LeaveTypeID";
        ddlAppType.DataBind();
        List<ATTLeaveTypeEmployee> LSTLeaveTypeEmp = BLLLeaveTypeEmployee.GetLeaveTypeEmployee(null, eid);
        List<ATTLeaveTypeDesignation> LSTLeaveTypeDes = new List<ATTLeaveTypeDesignation>();
        int desID = 0;
        List<ATTEmployeePosting> LSTEmpPosting = BLLEmployeePosting.GetEmpPosting(double.Parse(eid.ToString()));
        if (LSTEmpPosting.Count > 0)
        {
            desID = LSTEmpPosting[0].DesID;
        }

        if (desID > 0)
        {
            LSTLeaveTypeDes = BLLLeaveTypeDesignation.GetLeaveTypeDesignation(null, desID);
            //LSTLeaveTypeDes.Insert(0, new ATTEmployeeLeave(0, 0, "-बिदाको किसिम छान्नुहोस्-"));
        }
        //int? accrDays;
        if (LSTLeaveTypeEmp.Count < 1)
        {
            ddlAppType.DataSource = LSTLeaveTypeDes;
            ddlAppType.DataTextField = "LeaveType";
            ddlAppType.DataValueField = "LeaveTypeID";
            ddlAppType.DataBind();
        }
        else
        {

            List<ATTLeaveType> lstLeavetype = new List<ATTLeaveType>();
            foreach (ATTLeaveTypeEmployee var in LSTLeaveTypeEmp)
            {
                ATTLeaveType attlv = new ATTLeaveType(var.LeaveTypeID, var.LeaveType, "");
                lstLeavetype.Add(attlv);
            }
            if (desID > 0)
            {
                foreach (ATTLeaveTypeEmployee var in LSTLeaveTypeEmp)
                {
                    int i = LSTLeaveTypeDes.FindIndex(delegate(ATTLeaveTypeDesignation obj)
                                                    {
                                                        return obj.LeaveTypeID != var.LeaveTypeID;

                                                    });
                    if (i > 0)
                    {
                        ATTLeaveType attlv = new ATTLeaveType(LSTLeaveTypeDes[i].LeaveTypeID, LSTLeaveTypeDes[i].LeaveType, "");
                        lstLeavetype.Add(attlv);
                    }


                }

            }
            //lstLeavetype.Insert(0, new ATTEmployeeLeave(0, 0, "-बिदाको किसिम छान्नुहोस्-"));
            ddlAppType.DataSource = lstLeavetype;
            ddlAppType.DataTextField = "LeaveTypeName";
            ddlAppType.DataValueField = "LeaveTypeID";
            ddlAppType.DataBind();
        }

        List<ATTEmployeeLeave> LSTEmpLeave = BLLEmployeeLeave.GetEmployeeLeave(eid, "REQ");
        Session["EmployeeLeave"] = LSTEmpLeave;


        if (BLLEmployeeLeave.GetEmployeeLeave(eid, "REQ").Count > 0)
        {
            PanelSearch.Enabled = true;
        }
        grdLeaveApplications.DataSource = LSTEmpLeave;
        grdLeaveApplications.DataBind();
    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
    }

    //text change events
    protected void txtEmpLvFrom_TextChanged(object sender, EventArgs e)
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

    }
   

    //button events
    protected void btnAddApplication_Click(object sender, EventArgs e)
    {
        ddlAppType.Enabled = true;

        string msg = EmptyMessage("appl");
        if (msg != "")
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            try
            {
                List<ATTEmployeeLeave> LSTEmpLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];

                if (LSTEmpLeave == null)
                {
                    LSTEmpLeave = new List<ATTEmployeeLeave>();
                }
                else if (LSTEmpLeave.Count > 0)
                {
                    btnApplSubmit.Enabled = true;
                }

                ATTEmployeeLeave objEmpLST = new ATTEmployeeLeave();
                objEmpLST.EmpID = int.Parse(txtEmpName.Attributes["ID"].ToString());
                objEmpLST.EmpFullName = this.txtEmpName.Text;
                objEmpLST.ApplDate = this.txtEmpDate.Text;
                objEmpLST.LeaveTypeID = int.Parse(this.ddlAppType.SelectedValue.ToString());
                objEmpLST.LeaveType = this.ddlAppType.SelectedItem.ToString();
                objEmpLST.ReqdFrom = this.txtEmpLvFrom.Text;
                objEmpLST.ReqdTo = this.txtEmpLvTo.Text;
                objEmpLST.EmpDays = int.Parse(this.txtEmpLvDays.Text.ToString());
                objEmpLST.EmpReason = this.txtEmpLvResn.Text;

                objEmpLST.EntryBy = Session["UserName"].ToString();
                objEmpLST.EntryDate = "";
                objEmpLST.Action = "A";


                if (grdLeaveApplications.SelectedIndex == -1)
                {
                    //if (lstLeaveTypeEmployee.Count > 0)
                    //{
                    foreach (ATTEmployeeLeave leave in LSTEmpLeave)
                    {
                        if (leave.LeaveTypeID == int.Parse(ddlAppType.SelectedValue))
                        {
                            grdLeaveApplications.SelectedIndex = -1;

                            this.lblStatusMessage.Text = " This Leave Type Already Exists. ";
                            this.programmaticModalPopup.Show();

                            return;
                        }
                    }
                    //}
                    LSTEmpLeave.Add(objEmpLST);
                }
                else
                {
                    objEmpLST.Action = (LSTEmpLeave[grdLeaveApplications.SelectedIndex].Action == "A" ? "A" : "E");
                    LSTEmpLeave[grdLeaveApplications.SelectedIndex] = objEmpLST;
                }


                Session["EmployeeLeave"] = LSTEmpLeave;

                grdLeaveApplications.DataSource = LSTEmpLeave;
                grdLeaveApplications.DataBind();
                if (LSTEmpLeave.Count > 0)
                {
                    this.grdLeaveApplications.Visible = true;
                }
                ClearControls(1,2,0);
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
    }

    protected void btnApplSubmit_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeLeave> LSTEmpLeave = new List<ATTEmployeeLeave>();

        LSTEmpLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
        grdLeaveApplications.SelectedIndex = -1;
        try
        {
            if (BLLEmployeeLeave.SaveEmpLeaveApplication(LSTEmpLeave))
            {
                this.lblStatusMessage.Text = "Information Saved.";
                this.programmaticModalPopup.Show();
                grdLeaveApplications.DataSource = null;
                grdLeaveApplications.DataBind();
                ClearControls(1,1,0);
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnApplCancel_Click(object sender, EventArgs e)
    {
        ClearControls(0,2,0);
        this.grdLeaveApplications.Visible = false;
        grdLeaveApplications.SelectedIndex = -1;
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;
        this.lblSearch.Text = "";
        if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
            && this.ddlGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "" && this.ddlMarStatus.SelectedIndex == 0
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(1,0,0);
        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";
    }

    //functions
    void ClearControls(int search, int add_app, int other)
    {
        if (search==1)
        {
            this.txtSymbolNo.Text = "";
            this.txtFName.Text = "";
            this.txtMName.Text = "";
            this.txtSurName.Text = "";
            this.txtDOB.Text = "";
            this.ddlGender.SelectedIndex = 0;
            this.ddlMarStatus.SelectedIndex = 0;
            this.ddlOrganization.SelectedIndex = 0;
            this.ddlDesignation.SelectedIndex = 0;
            this.grdEmployee.DataSource = null;
            this.grdEmployee.DataBind();
            this.lblSearch.Text = "";
        }
        if (add_app == 1 || add_app == 2)
        {
            if (add_app == 1)
            {
                txtEmpName.Text = "";
                txtEmpDate.Text = "";
                txtEmpLvFrom.Text = "";
                txtEmpLvTo.Text = "";
                ddlAppType.SelectedIndex = 0;
                txtEmpLvDays.Text = "";
                txtEmpLvResn.Text = "";
                grdLeaveApplications.DataSource = null;
                grdLeaveApplications.DataBind();
                ClearControls(1, 0, 0);
            }
            else if (add_app == 2)
            {
                txtEmpName.Text = "";
                txtEmpDate.Text = "";
                txtEmpLvFrom.Text = "";
                txtEmpLvTo.Text = "";
                ddlAppType.SelectedIndex = 0;
                txtEmpLvDays.Text = "";
                txtEmpLvResn.Text = "";
            }
        }
        if (other==1)
        {
            PanelSearch.Enabled = false;
        }
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
            txt1.Text = "";
            txt2.Text = "";
            return "ठिक मिति रख्न्नुहोस्";

        }

        TimeSpan timespan = dt2.Subtract(dt1)+new TimeSpan(1,0,0,0);
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
        return "";
    }
    private ATTEmployeeSearch GetFilter()
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
        if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.txtFName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.DesType = "J";
        EmployeeSearch.IniType = 2;

        return EmployeeSearch;
    }
    void LoadDesignations()
    {
            string desType = "J";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null,desType);
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
    string EmptyMessage(string choice)
    {
        int count = 0;
        string msg = "";
        if (choice == "appl")
        {
            if (this.txtEmpName.Text == "")
            {
                msg += "*--निवेदकको नाम भर्नुहोस्";
                count++;
            }
            if (this.txtEmpLvFrom.Text == "")
            {
                msg += "<br/>*--अवधि देखि भर्नुहोस्";
                count++;
            }
            if (this.txtEmpLvTo.Text == "")
            {
                msg += "<br/>*--अवधि सम्म भर्नुहोस्";
                count++;
            }
            if (this.txtEmpDate.Text == "")
            {
                msg += "<br/>*--निवेदन मिति भर्नुहोस्";
                count++;
            }
            if (this.txtEmpLvDays.Text == "")
            {
                msg += "<br/>*--जम्मा दिन भर्नुहोस्";
                count++;
            }
            if (this.txtEmpLvResn.Text == "")
            {
                msg += "<br/>*--कैफियत भर्नुहोस्";
                count++;
            }
        }
        if (count > 0)
        {
            return msg;
        }
        else
        {
            return "";
        }
    }
}