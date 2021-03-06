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

public partial class MODULES_PMS_Forms_OrgUnitHead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                
        if (user.MenuList.ContainsKey("3,6,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                LoadOrganization();
                LoadUnit();
            }
        }
        else
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganization();

            lst.Insert(0, new ATTOrganization(0, "-- कार्यालय छान्नुहोस् --"));
            ddlOrganization.DataSource = lst;
            ddlOrganization.DataTextField = "OrgName";
            ddlOrganization.DataValueField = "OrgID";
            ddlOrganization.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadUnit()
    {
        try
        {
            List<ATTOrganizationUnit> lst = BLLOrganizationUnit.GetOrganizationUnits(((ATTUserLogin)Session["Login_User_Detail"]).OrgID, null);

            lst.Insert(0, new ATTOrganizationUnit(0,0, "-- शाखा छान्नुहोस् --"));
            DDLUnit.DataSource = lst;
            DDLUnit.DataTextField = "UnitName";
            DDLUnit.DataValueField = "UnitID";
            DDLUnit.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (ddlOrganization.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "कृप्या कार्यालय छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            List<ATTEmployeeSearch> lst = BLLEmployeeSearch.SearchEmployeeForOrgUnitHead(GetFilter());
            this.grdEmployee.DataSource = lst;
            this.grdEmployee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        return EmployeeSearch;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLUnit.SelectedIndex = 0;
        chkUnitHead.Checked = false;
        chkOfficeHead.Checked = false;

        DDLUnit.SelectedValue = grdEmployee.SelectedRow.Cells[3].Text;
        chkUnitHead.Checked = grdEmployee.SelectedRow.Cells[5].Text == "Y" ? true : false;
        chkOfficeHead.Checked = grdEmployee.SelectedRow.Cells[6].Text == "Y" ? true : false;
        txtFromDate.Text = grdEmployee.SelectedRow.Cells[7].Text;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (DDLUnit.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "कृप्या शाखा छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कृप्या कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtFromDate.Text == "")
        {
            this.lblStatusMessage.Text = "कृप्या ञवधि देखि राखनुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTOrgUnitHead att = new ATTOrgUnitHead();
        att.OrgID = int.Parse(grdEmployee.SelectedRow.Cells[0].Text);
        att.UnitID = int.Parse(DDLUnit.SelectedValue.ToString());
        att.EmpID = double.Parse(grdEmployee.SelectedRow.Cells[1].Text);
        att.FromDate = txtFromDate.Text;
        att.UnitHead = chkUnitHead.Checked == true ? "Y" : "N";
        att.OfficeHead = chkOfficeHead.Checked == true ? "Y" : "N";
        att.EntryBY = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        att.Action = "A";

        if (BLLOrgUnitHead.SaveOrgUnitHead(att))
        {
            ClearControls();
            lblStatusMessage.Text = "Saved Successfully";
            programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }

    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        this.txtSymbolNo.Text = "";
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlOrganization.SelectedIndex = 0;
        this.grdEmployee.DataSource = null;
        this.grdEmployee.DataBind();
    }

    void ClearSearchControls()
    {
        this.txtSymbolNo.Text = "";
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlOrganization.SelectedIndex = 0;
        this.grdEmployee.DataSource = "";
        this.grdEmployee.DataBind();
    }

    void ClearControls()
    {
        ClearSearchControls();
        txtFromDate.Text = "";
        chkOfficeHead.Checked = false;
        chkUnitHead.Checked = false;
        DDLUnit.SelectedIndex = 0;
    }
}
