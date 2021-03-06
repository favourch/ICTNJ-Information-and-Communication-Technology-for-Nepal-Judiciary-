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

public partial class MODULES_PMS_Forms_Retirement : System.Web.UI.Page
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
        Session["UserName"] = user.UserName;
        if (user.MenuList.ContainsKey("3,9,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                this.ddlEmpRetirementType.Enabled = false;
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
                LoadRetirmentApplication();
            }
        }
        else
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
    }

    private void LoadRetirmentApplication()
    {
        List<ATTRetirement> LSTRetAppl = BLLRetirement.GetEmployeeRetirement(GetFilterAppl(), "appl");
        Session["EmpRetirementAppl"] = LSTRetAppl;
        this.grdRetirementData.DataSource = LSTRetAppl;
        this.grdRetirementData.DataBind();
    }
    private ATTRetirement GetFilterAppl()
    {
        ATTRetirement objRet = new ATTRetirement();
        objRet.isDecided = "N";
        objRet.isApproved = "N";
        return objRet;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTRetirement> lst;
        this.lblSearch.Text = "";
        if (this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
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
                Session["EmpSearchResult"] = BLLRetirement.SearchEmployee(GetFilter());
                lst = (List<ATTRetirement>)Session["EmpSearchResult"];
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
        ClearControls(1);
        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    private ATTRetirement GetFilter()
    {
        ATTRetirement EmployeeSearch = new ATTRetirement();
        if (this.txtFName.Text.Trim() != "") EmployeeSearch.firstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") EmployeeSearch.midName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") EmployeeSearch.lastName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.gender = this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.dob = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.maritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.orgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.desID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.desType = "O";
        EmployeeSearch.iniType = 3;

        return EmployeeSearch;
    }
    void ClearControls(int opt)
    {
        if (opt == 1)
        {
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
        if (opt == 2)
        {
            this.txtRetirementAppDate.Text = "";
            this.RetirementDescription.Text = "";
            this.rdoRetSelfYesNo.SelectedIndex = 0;
            this.ddlEmpRetirementType.SelectedIndex = 0;
            this.grdEmployee.SelectedIndex = -1;
            this.lblEmpName.Text = "";
        }
        if (opt == 3)
        {
            this.txtApprName.Text = "";
            this.txtApprDate.Text = "";
            this.txtApprDescription.Text = "";
            this.grdEmployee.SelectedIndex = -1;
        }
        if (opt == 4)
        {
            this.txtDecName.Text = "";
            this.txtDecDate.Text = "";
            this.txtDecDexcription.Text = "";
            this.grdEmployee.SelectedIndex = -1;
        }
    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.TabContainerRetirement.ActiveTabIndex == 0)
        {
            this.lblEmpName.Text = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[3].Text).ToString();
            lblEmpName.Attributes.Add("empid", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            lblEmpName.Attributes.Add("desid", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[7].Text);
            lblEmpName.Attributes.Add("createddate", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[11].Text);
            lblEmpName.Attributes.Add("postid", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[10].Text);
            lblEmpName.Attributes.Add("fromdate", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[12].Text);
        }
        else if (this.TabContainerRetirement.ActiveTabIndex == 1)
        {
            this.txtDecName.Text = grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[3].Text;
            txtDecName.Attributes.Add("ID", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
        }
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdRetirementData.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
        }
    }
    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdRetirementData.HeaderRow.Cells[0].FindControl("chk")).Checked;
        foreach (GridViewRow row in grdRetirementData.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chk")).Checked = val;
        }
    }
    protected void btnAddApplication_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**र्कपया कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        string msg = EmptyMessage("RetAppl");
        if (msg == "")
        {
            List<ATTRetirement> LSTEmpRetirement = new List<ATTRetirement>();
            ATTRetirement objEmpRetirement = new ATTRetirement();
            objEmpRetirement.empID = int.Parse(lblEmpName.Attributes["empid"].ToString());
            objEmpRetirement.orgID = int.Parse(Session["OrgID"].ToString());
            objEmpRetirement.desID = int.Parse(lblEmpName.Attributes["desid"].ToString());
            objEmpRetirement.createdDate = lblEmpName.Attributes["createddate"].ToString();
            objEmpRetirement.postID = int.Parse(lblEmpName.Attributes["postid"].ToString());
            objEmpRetirement.fromDate = lblEmpName.Attributes["fromdate"].ToString();
            objEmpRetirement.retirementDate = this.txtRetirementAppDate.Text;
            objEmpRetirement.ApplDesc = this.RetirementDescription.Text;
            if (this.rdoRetSelfYesNo.SelectedValue == "0")
            {
                objEmpRetirement.isSelf = "Y";
            }
            else
            {
                objEmpRetirement.isSelf = "N";
            }
            if(ddlEmpRetirementType.SelectedValue=="0")
            {
                objEmpRetirement.retirementType = "A";
            }
            else if (ddlEmpRetirementType.SelectedValue == "1")
            {
                objEmpRetirement.retirementType = "S";
            }
            objEmpRetirement.entryBy = Session["UserName"].ToString();
            if (this.grdRetirementData.SelectedIndex == -1)
            {
                objEmpRetirement.action = "A";
            }
            else if (this.grdRetirementData.SelectedIndex == -1)
            {
                objEmpRetirement.action = "E";
            }
            LSTEmpRetirement.Add(objEmpRetirement);
            Session["EmpRetirementAppl"] = LSTEmpRetirement;
            this.grdRetirementData.DataSource = LSTEmpRetirement;
            this.grdRetirementData.DataBind();
            ClearControls(2);
        }
        else
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    private string EmptyMessage(string p)
    {
        int count = 0;
        string msg = "";
        if (p == "RetAppl")
        {
            if (this.txtRetirementAppDate.Text == "")
            {
                msg += "*--अवकास निवेदनको मिति भर्नुहोस्";
                count++;
            }
            if (ddlEmpRetirementType.SelectedIndex == -1)
            {
                msg += "<br/>*--अवकासको किसिम छान्नुहोस्";
                count++;
            }
        }
        else if (p == "RetDec")
        {
            if (this.txtDecDate.Text == "")
            {
                msg += "*--अवकास निर्णय मिति भर्नुहोस्";
                count++;
            }
        }
        else if (p == "RetAppr")
        {
            if (this.txtApprDate.Text == "")
            {
                msg += "*--अवकास प्रमाणिकरण मिति भर्नुहोस्";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        List<ATTRetirement> LSTRetAppl = (List<ATTRetirement>)Session["EmpRetirementAppl"];
        if (LSTRetAppl.Count == 0)
        {
            this.lblStatusMessage.Text = "**Sorry No Data To Save";
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            try
            {
                if (BLLRetirement.SaveEmpRetirement(LSTRetAppl))
                {
                    this.lblStatusMessage.Text = "Employee Retirement Saved Successfully.";
                    this.programmaticModalPopup.Show();
                    this.grdRetirementData.DataSource = null;
                    this.grdRetirementData.DataBind();
                    ClearControls(2);
                }
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message.ToString();
                this.programmaticModalPopup.Show();
            }
        }
    }

    protected void rdoRetSelfYesNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rdoRetSelfYesNo.SelectedIndex == 0)
        {
            this.ddlEmpRetirementType.Enabled = false;
        }
        else
        {
            this.ddlEmpRetirementType.Enabled = true;
        }
    }

    protected void TabContainerRetirement_ActiveTabChanged(object sender, EventArgs e)
    {
        this.grdEmployee.SelectedIndex = -1;
        if (this.TabContainerRetirement.ActiveTabIndex == 0)
        {
            List<ATTRetirement> LSTRetDec = BLLRetirement.GetEmployeeRetirement(GetFilterAppl(), "appl");
            this.grdRetirementData.DataSource = LSTRetDec;
            this.grdRetirementData.DataBind();
        }
        if (this.TabContainerRetirement.ActiveTabIndex == 1)
        {
            List<ATTRetirement> LSTRetDec = BLLRetirement.GetEmployeeRetirement(GetFilterDec(), "dec");
            this.grdRetirementData.DataSource = LSTRetDec;
            this.grdRetirementData.DataBind();
        }
        else if (this.TabContainerRetirement.ActiveTabIndex== 2)
        {
            List<ATTRetirement> LSTRetAppr = BLLRetirement.GetEmployeeRetirement(GetFilterAppr(), "appr");
            Session["EmpRetAppr"] = LSTRetAppr;
            this.grdRetirementData.DataSource = LSTRetAppr;
            this.grdRetirementData.DataBind();
        }
    }

    private ATTRetirement GetFilterAppr()
    {

        ATTRetirement objRetAppr = new ATTRetirement();
        objRetAppr.isDecided = "Y";
        objRetAppr.isApproved = "Y";
        return objRetAppr;
    }

    private ATTRetirement GetFilterDec()
    {
        ATTRetirement objRetDec = new ATTRetirement();
        objRetDec.isDecided = "N";
        objRetDec.isApproved = "N";
        return objRetDec;
    }
    protected void btnAddDecision_Click(object sender, EventArgs e)
    {
        if (grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**र्कपया कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        string msg = EmptyMessage("RetDec");
        if (msg == "")
        {
            List<ATTRetirement> LSTRetDec = (List<ATTRetirement>)Session["EmpRetirementAppl"];
            ATTRetirement objRetDec = LSTRetDec[this.grdRetirementData.SelectedIndex];
            int empid = LSTRetDec[this.grdRetirementData.SelectedIndex].empID;
            int decid = int.Parse(txtDecName.Attributes["ID"].ToString());
            if (empid == decid)
            {
                this.btnSubmit2.Enabled = false;
                this.lblStatusMessage.Text = "**अर्को कर्मचारी छान्नुहोस्";
                this.programmaticModalPopup.Show();
                this.txtDecName.Text = "";
                this.txtDecName.Focus();
                return;
            }
            objRetDec.decisionBy = decid;
            objRetDec.decisionDate = this.txtDecDate.Text;
            objRetDec.decisionDesc = this.txtDecDexcription.Text;
            if (this.chkDecision.Checked == true)
            {
                objRetDec.isDecided = "Y";
            }
            else
            {
                objRetDec.isDecided = "N";
            }
            objRetDec.action = "E";

            Session["EmpRetirementAppl"] = LSTRetDec;
            this.grdRetirementData.DataSource = LSTRetDec;
            this.grdRetirementData.DataBind();
            this.btnSubmit2.Enabled = true;
            ClearControls(4);
        }
        else
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void grdRetirementData_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.TabContainerRetirement.ActiveTabIndex == 0)
        {
            foreach (GridViewRow rw in this.grdRetirementData.Rows)
            {
                this.txtRetirementAppDate.Text = rw.Cells[5].Text;
                this.rdoRetSelfYesNo.SelectedValue = rw.Cells[6].Text;
                this.ddlEmpRetirementType.SelectedValue = rw.Cells[7].Text;
                this.RetirementDescription.Text = rw.Cells[8].Text;
            }
        }
        else if (this.TabContainerRetirement.ActiveTabIndex == 1)
        {
            this.grdEmployee.SelectedIndex = -1;
        }
        else
        {
            this.grdEmployee.SelectedIndex = -1;
        }
    }
    protected void btnAddApprove_Click(object sender, EventArgs e)
    {
        if (grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**र्कपया कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        string msg = EmptyMessage("RetAppr");
        if (msg == "")
        {
            List<ATTRetirement> LSTRetAppr = (List<ATTRetirement>)Session["EmpRetirementAppl"];
            ATTRetirement objRetDec = new ATTRetirement();
            //objRetDec.appBy= this.txtApprName.Text;
            objRetDec.appDate = this.txtApprDate.Text;
            objRetDec.appDesc = this.txtApprDescription.Text;
            if (this.chkApprove.Checked == true)
            {
                objRetDec.isApproved = "Y";
            }
            else
            {
                objRetDec.isApproved = "N";
            }
            objRetDec.action = "E";
            LSTRetAppr.Add(objRetDec);
            this.grdRetirementData.DataSource = LSTRetAppr;
            this.grdRetirementData.DataBind();
            ClearControls(3);
        }
        else
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        List<ATTRetirement> LSTRetDec = (List<ATTRetirement>)Session["EmpRetirementAppl"];
        try
        {
            int index = 0;

            foreach (GridViewRow rw in this.grdRetirementData.Rows)
            {
                if (((CheckBox)rw.FindControl("chk")).Checked==true)
                {
                    LSTRetDec[index].empID = int.Parse(LSTRetDec[index].empID.ToString());
                    LSTRetDec[index].desID = int.Parse(LSTRetDec[index].desID.ToString());
                    LSTRetDec[index].postID = int.Parse(LSTRetDec[index].postID.ToString());
                    LSTRetDec[index].createdDate=LSTRetDec[index].createdDate.ToString();
                    LSTRetDec[index].fromDate = LSTRetDec[index].fromDate.ToString();
                    LSTRetDec[index].retirementDate= LSTRetDec[index].retirementDate.ToString();
                    LSTRetDec[index].decisionBy = int.Parse(this.txtDecName.Attributes["ID"].ToString());
                    LSTRetDec[index].decisionDate = this.txtDecDate.Text;
                    LSTRetDec[index].decisionDesc = this.txtDecDexcription.Text;
                    if (this.chkDecision.Checked == true)
                    {
                        LSTRetDec[index].isDecided = "Y";
                    }
                    else
                    {
                        LSTRetDec[index].isDecided = "N";
                    }
                    LSTRetDec[index].isApproved = "N";
                    LSTRetDec[index].action= "E";
                    LSTRetDec[index].entryBy = Session["UserName"].ToString();
                }
                index++;
            }
            if (LSTRetDec.Count == 0)
            {
                this.lblStatusMessage.Text = "No Data To Save";
                this.programmaticModalPopup.Show();
                return;
            }

            if (BLLRetirement.SaveEmpRetirement(LSTRetDec))
            {
                this.lblStatusMessage.Text = "Retirement Decision Saved";
                this.programmaticModalPopup.Show();
                //List<ATTRetirement> lstRet = new List<ATTRetirement>();
                //ATTRetirement obj = new ATTRetirement();
                //obj.isDecided = "N";
                //obj.isApproved = "N";
                //lstRet=BLLRetirement.GetEmployeeRetirement(obj, "dec");
                //this.grdRetirementData.DataSource = lstRet;
                //this.grdRetirementData.DataBind();
            }
            ClearControls(4);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit3_Click(object sender, EventArgs e)
    {
        List<ATTRetirement> LSTRetAppr = (List<ATTRetirement>)Session["EmpRetirementAppl"];
        try
        {
            if (LSTRetAppr.Count != 0)
            {
                if (BLLRetirement.SaveEmpRetirement(LSTRetAppr))
                {
                    this.lblStatusMessage.Text = "Retirement Approved";
                    this.programmaticModalPopup.Show();
                }
            }
            else if (LSTRetAppr.Count == 0)
            {
                this.lblStatusMessage.Text = "No Data To Save";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
