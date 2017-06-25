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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;

using System.Collections.Generic;

public partial class MODULES_SECURITY_ApplicationForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            Session["lstAppFM"] = BLLApplication.GetApplicationListWithFormNMenu();
            this.ddlApplication_Rqd.DataSource = (List<ATTApplication>)Session["lstAppFM"];
            this.ddlApplication_Rqd.DataTextField = "ApplicationFullName";
            this.ddlApplication_Rqd.DataValueField = "ApplicationID";

            this.ddlApplication_Rqd.DataBind();
        }
    }

    protected void btnAddForm_Click(object sender, EventArgs e)
    {
        if (this.ddlApplication_Rqd.SelectedIndex <= 0)
        {
            this.lblStatus.Text = "Please select any one application from list.";
            this.ddlApplication_Rqd.Focus();
            return;
        }

        List<ATTApplication> lstApp = (List<ATTApplication>)Session["LstAppFM"];
        List<ATTApplicationForm> lstForm = lstApp[this.ddlApplication_Rqd.SelectedIndex].LstApplicationForm;

        ATTApplicationForm appForm = new ATTApplicationForm(lstApp[this.ddlApplication_Rqd.SelectedIndex].ApplicationID, 0, this.txtFormName_Rqd.Text, this.txtFrmDesc.Text, "A");

        ObjectValidation OV = BLLApplicationForm.Validate(appForm);

        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        lstForm.Add(appForm);

        this.grdForm.DataSource = lstForm;
        this.grdForm.DataBind();

        this.ClearFormsControls();
    }

    private void ClearFormsControls()
    {
        this.txtFormName_Rqd.Text = "";
        this.txtFrmDesc.Text = "";
        this.grdForm.SelectedIndex = -1;
        this.lblStatus.Text = "";
    }

    protected void btnFrmCancel_Click(object sender, EventArgs e)
    {
        this.ClearFormsControls();
    }

    protected void ddlApplication_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTApplication> lstApp = (List<ATTApplication>)Session["lstAppFM"];

        List<ATTApplicationForm> lstForm = lstApp[this.ddlApplication_Rqd.SelectedIndex].LstApplicationForm;

        this.grdForm.SelectedIndex = -1;
        this.grdMenu.SelectedIndex = -1;

        this.grdForm.DataSource = null;
        this.grdMenu.DataSource = null;

        this.grdForm.DataSource = lstForm;
        
        this.grdForm.DataBind();
        this.grdMenu.DataBind();
    }

    protected void grdForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTApplication> lstApp = (List<ATTApplication>)Session["lstAppFM"];

        List<ATTApplicationForm> lstForm = lstApp[this.ddlApplication_Rqd.SelectedIndex].LstApplicationForm;

        List<ATTMenu> lstMenu = lstForm[this.grdForm.SelectedIndex].LstMenu;

        this.lblFormName.Text = lstForm[this.grdForm.SelectedIndex].FormName;
        
        this.grdMenu.DataSource = lstMenu;
        this.grdMenu.DataBind();
    }

    protected void btnAddMenu_Click(object sender, EventArgs e)
    {
        if (this.grdForm.SelectedIndex < 0)
        {
            this.lblStatus.Text = "Please select any form form table.";
            return;
        }

        if (this.grdMenu.Rows.Count > 1)
        {
            this.lblStatus.Text = "Only one menu for one form.";
            return;
        }

        List<ATTApplication> lstApp = (List<ATTApplication>)Session["LstAppFM"];
        List<ATTApplicationForm> lstForm = lstApp[this.ddlApplication_Rqd.SelectedIndex].LstApplicationForm;
        List<ATTMenu> lstMenu = lstForm[this.grdForm.SelectedIndex].LstMenu;

        ATTMenu appMenu = new ATTMenu
                                    (
                                        lstApp[this.ddlApplication_Rqd.SelectedIndex].ApplicationID,
                                        lstForm[this.grdForm.SelectedIndex].FormID,
                                        0,
                                        this.txtMenuName_Rqd.Text,
                                        this.txtMenuDesc.Text,
                                        (this.chkSelect.Checked == true) ? "Y" : "N",
                                        (this.chkAdd.Checked == true) ? "Y" : "N",
                                        (this.chkEdit.Checked == true) ? "Y" : "N",
                                        (this.chkDelete.Checked == true) ? "Y" : "N",
                                        "A"
                                    );

        ObjectValidation OV = BLLMenu.Validate(appMenu);

        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        lstMenu.Add(appMenu);

        this.grdMenu.DataSource = lstMenu;
        this.grdMenu.DataBind();

        this.ClearMenuControls();
    }

    private void ClearMenuControls()
    {
        this.txtMenuName_Rqd.Text = "";
        this.txtMenuDesc.Text = "";
        this.grdMenu.SelectedIndex = -1;
        this.lblStatus.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTApplication> lstApp = (List<ATTApplication>)Session["LstAppFM"];

            BLLApplicationForm.AddApplicationFormWithMenu(lstApp);

            this.grdForm.DataSource = null;
            this.grdMenu.DataSource = null;

            this.grdForm.DataBind();
            this.grdMenu.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
            this.lblStatus.Focus();
        }
    }

    protected void btnCancelMenu_Click(object sender, EventArgs e)
    {
        this.ClearMenuControls();
    }

    protected void grdForm_DataBound(object sender, EventArgs e)
    {
        if (this.grdForm.Rows.Count < 1)
            this.lblApplicationName.Text = "Form list";
        else
            this.lblApplicationName.Text = "Form(s) for " + this.ddlApplication_Rqd.SelectedItem.Text;
    }

    protected void grdMenu_DataBound(object sender, EventArgs e)
    {
        if (this.grdMenu.Rows.Count < 1)
            this.lblFormName.Text = "Menu list";
        else
            this.lblFormName.Text = "Menu(s) for " + this.grdForm.SelectedRow.Cells[2].Text;
    }
}
