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

public partial class MODULES_PMS_Forms_EmployeeLeaveApprove : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,13,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                Session["index"] = -1;
                List<ATTEmployeeLeave> lstEmployeeLeave = BLLEmployeeLeave.GetEmployeeLeave(null, "APP");
                grdRecLeaveApplications.DataSource = lstEmployeeLeave;
                grdRecLeaveApplications.DataBind();
                Session["EmployeeLeave"] = lstEmployeeLeave;
                chkbxAppr.Checked = true;
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void chkbxAppr_CheckedChanged(object sender, EventArgs e)
    {
        if (chkbxAppr.Checked == false)
        {
            this.lblStatusMessage.Text = "Approval of this application will be canceled";
            this.programmaticModalPopup.Show();
        }
    }

    //Text events
    protected void txtApprFrom_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        string errmessage = "<P><b><U>! Attention </U></b></P>";
        string s = IsDateValid(txtApprFrom, txtApprTo);
        try
        {
            int timespan = int.Parse(s);
            txtApprDays.Text = s;
        }
        catch (Exception)
        {

            if (s == "a")
            {
                i++; errmessage += i.ToString() + ") अवधि देखि राख्न्नु होस् ?????? <br />";
            }
            //else if (s == "b")
            //{
            //    i++; errmessage += i.ToString() + ") Effective Till Date ?????? <br />";
            //}
            else if (s == "ab")
            {
                i++; errmessage += i.ToString() + ")  अवधि देखि राख्न्नु होस् ??????<br />";
                i++; errmessage += i.ToString() + ") अवधि सम्म राख्न्नु होस्?????? <br />";
            }
            else if (s == "Invalid Date")
            {
                i++; errmessage += i.ToString() + ")" + s + " <br />";

            }
        }

        if (i > 0)
        {
            this.lblStatusMessage.Text = errmessage;
            this.programmaticModalPopup.Show();
            return;

        }
    }
    protected void txtApprTo_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        string errmessage = "<P><b><U>! Attention </U></b></P>";
        string s = IsDateValid(txtApprFrom, txtApprTo);
        try
        {
            int timespan = int.Parse(s);
            txtApprDays.Text = s;
        }
        catch (Exception)
        {

            if (s == "a")
            {
                i++; errmessage += i.ToString() + ") अवधि देखि राख्न्नु होस् ?????? <br />";
            }          
            else if (s == "ab")
            {
                i++; errmessage += i.ToString() + ")  अवधि देखि राख्न्नु होस्??????<br />";
                i++; errmessage += i.ToString() + ") अवधि सम्म राख्न्नु होस् ?????? <br />";
            }
            else if (s == "Invalid Date")
            {
                i++; errmessage += i.ToString() + ")" + s + " <br />";

            }
        }

        if (i > 0)
        {
            this.lblStatusMessage.Text = errmessage;
            this.programmaticModalPopup.Show();
            return;

        }
    }
    
    //Button events
    //protected void btnEmpSearch_Click(object sender, EventArgs e)
    //{
    //    List<ATTEmployeeSearch> lst;
    //    this.lblSearch.Text = "";
    //    if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
    //        && this.ddlSearchGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "")
    //    {
    //        this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
    //        this.programmaticModalPopup.Show();
    //    }
    //    else
    //    {
    //        try
    //        {
    //            lst = BLLEmployeeSearch.SearchEmployee(GetEmployeeFilter());
    //            if (lst.Count > 0)
    //            {
    //                Panel3.Height=Unit.Pixel(150);
    //            }
    //            this.lblSearch.Text = lst.Count.ToString() + " records found.";
    //            this.grdEmployee.DataSource = lst;
    //            this.grdEmployee.DataBind();
    //        }
    //        catch (Exception ex)
    //        {
    //            this.lblStatusMessage.Text = ex.Message;
    //            this.programmaticModalPopup.Show();
    //        }
    //    }
    //}
    //protected void btnEmpSearchCancel_Click(object sender, EventArgs e)
    //{
    //    ClearControls("Search");    
    //}
   
    //Grid events
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
      
    }
    //protected void grdEmployee_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    //{
       
    //}
    protected void grdRecLeaveApplications_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (grdRecLeaveApplications.SelectedRow.Cells[19].Text.Trim() != null)
        //{
        //    txtApprName.Text = Server.HtmlDecode(grdRecLeaveApplications.SelectedRow.Cells[19].Text.Trim());
        //}
        //txtApprDate.Text=Server.HtmlDecode(grdRecLeaveApplications.SelectedRow.Cells[20].Text.Trim());
        txtApprFrom.Text = grdRecLeaveApplications.SelectedRow.Cells[13].Text.Trim();
        txtApprTo.Text = grdRecLeaveApplications.SelectedRow.Cells[14].Text.Trim();
        txtApprDays.Text = grdRecLeaveApplications.SelectedRow.Cells[15].Text.Trim();
        //txtApprReason.Text = Server.HtmlDecode(grdRecLeaveApplications.SelectedRow.Cells[24].Text.Trim()).ToString();
        btnAppSubmit.Enabled = false;
        Session["index"] = grdRecLeaveApplications.SelectedIndex;
    }
    protected void grdRecLeaveApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[16].Visible = false;
        e.Row.Cells[23].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[15].Text == "Y")
            {
                //e.Row.Cells[11].Enabled = false
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkselect");
                btn.Enabled = false;
            }

        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";
        string Name = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
        int id = 0;
        List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();
        id = int.Parse(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
        txtApprName.Text = Name;
        txtApprName.Attributes.Add("ID", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
    }

    //user defined functions
    void ClearControls(string control)
        {
            if (control == "Search")
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
            else if (control == "Tab")
            {
                this.txtApprName.Text = "";
                this.txtApprDate.Text = "";
                this.txtApprFrom.Text = "";
                this.txtApprTo.Text = "";
                this.txtApprDays.Text = "";
                this.txtApprReason.Text = "";
            }
            else if (control == "Submit")
            {
                this.txtApprName.Text = "";
                this.txtApprDate.Text = "";
                this.txtApprFrom.Text = "";
                this.txtApprTo.Text = "";
                this.txtApprDays.Text = "";
                this.txtApprReason.Text = "";
                //grdRecLeaveApplications.SelectedIndex = -1;
            }
        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        return;
    }
    protected void OkButton2_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
        ATTEmployeeLeave objEmp = lstEmployeeLeave[int.Parse(Session["index"].ToString())];
        if (BLLEmployeeLeaveApprove.LeaveApprove(objEmp))
        {
            this.lblStatusMessage.Text = "Information Saved";
            this.programmaticModalPopup.Show();
        }

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
        ClearControls("Search");
        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";
    }
    protected void btnApprAdd_Click(object sender, EventArgs e)
    {
        if (txtApprName.Text != "")
        {
            this.btnAppSubmit.Enabled = true;
        }
        string msg = EmptyMessage();
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

                ATTEmployeeLeave objEmpLST = LSTEmpLeave[grdRecLeaveApplications.SelectedIndex];

                //bool a = txtApprName.HasAttributes;
                objEmpLST.AppByID = int.Parse(txtApprName.Attributes["ID"].ToString());
                objEmpLST.AppByName = this.txtApprName.Text;
                objEmpLST.AppDate = this.txtApprDate.Text;
                objEmpLST.AppFrom = this.txtApprFrom.Text;
                objEmpLST.AppTo = this.txtApprTo.Text;
                objEmpLST.AppDays = int.Parse(txtApprDays.Text);
                if (chkbxAppr.Checked == true)
                {
                    objEmpLST.Approved = "Y";
                }
                else
                {
                    objEmpLST.Approved = "N";
                }
                objEmpLST.AppReason = this.txtApprReason.Text;
                objEmpLST.Action = "E";
                //LSTEmpLeave[grdRecLeaveApplications.SelectedIndex] = objEmpLST;
                //grdRecLeaveApplications.SelectedIndex = -1;

                Session["EmployeeLeave"] = LSTEmpLeave;

                grdRecLeaveApplications.DataSource = LSTEmpLeave;
                grdRecLeaveApplications.DataBind();
                btnAppSubmit.Enabled = true;
                //grdRecLeaveApplications.SelectedIndex = -1;
                ClearControls("Search");
                ClearControls("Submit");
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
    }
    protected void btnAppSubmit_Click1(object sender, EventArgs e)
    {
        try
        {
            List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
            ATTEmployeeLeave objEmp = lstEmployeeLeave[int.Parse(Session["index"].ToString())];
            objEmp.EntryBy = Session["UserName"].ToString();
            if (objEmp.Approved == "N")
            {
                if (BLLEmployeeLeaveApprove.LeaveApprove(objEmp))
                {
                    this.lblStatusMessage.Text = "Employee Leave Approved Successfully";
                    this.programmaticModalPopup.Show();
                    grdRecLeaveApplications.DataSource = BLLEmployeeLeave.GetEmployeeLeave(null, "APP");
                    grdRecLeaveApplications.DataBind();
                }
            }
            else
            {
                List<ATTEmployeeLeave> LSTLvAPP = BLLEmployeeLeaveApprove.LeaveCheck(objEmp);
                if (LSTLvAPP[0].OutMessage != "OK")
                {
                    this.lblStatusMessage2.Text = LSTLvAPP[0].OutMessage;
                    this.programmaticModalPopup2.Show();
                    return;
                }
                else if (LSTLvAPP[0].OutMessage == "OK")
                {
                    if (BLLEmployeeLeaveApprove.LeaveApprove(objEmp))
                    {
                        this.lblStatusMessage.Text = "Employee Leave Approved Successfully";
                        this.programmaticModalPopup.Show();
                        this.CollapsiblePanelExtender1.Collapsed = true;
                        this.CollapsiblePanelExtender1.ClientState = "true";
                        grdRecLeaveApplications.DataSource = BLLEmployeeLeave.GetEmployeeLeave(null, "APP");
                        grdRecLeaveApplications.DataBind();
                    }
                }
            }
            ClearControls("Submit");
        }

        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnAppCancel_Click(object sender, EventArgs e)
    {
        ClearControls("Tab");
    }

    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "",0,0));
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
        if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.DesType = "O";
        EmployeeSearch.IniType = 3;

        return EmployeeSearch;
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

        TimeSpan timespan = dt2.Subtract(dt1);
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
    string EmptyMessage()
    {
        int count = 0;
        string msg = "";

        if (this.txtApprName.Text == "")
        {
            msg += "*--प्रमाणित गर्ने कर्मचारीको नाम भर्नुहोस्";
            count++;
        }
        if (this.txtApprDate.Text == "")
        {
            msg += "<br/>*--प्रमाणित भएको मिति  भर्नुहोस्";
            count++;
        }
        if (this.txtApprFrom.Text == "")
        {
            msg += "<br/>*--अवधि देखि भर्नुहोस्";
            count++;
        }
        if (this.txtApprTo.Text == "")
        {
            msg += "<br/>*--अवधि सम्म भर्नुहोस्";
            count++;
        }

        if (this.txtApprDays.Text == "")
        {
            msg += "<br/>*--जम्मा दिन भर्नुहोस्";
            count++;
        }
        if (this.txtApprReason.Text == "")
        {
            msg += "<br/>*--प्रमाणित कैफियत भर्नुहोस्";
            count++;
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

