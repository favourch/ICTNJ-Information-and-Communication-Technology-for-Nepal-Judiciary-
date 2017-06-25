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
using System.Reflection;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.FRAMEWORK;

public partial class MODULES_SECURITY_Roles : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
        //this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,52,1") == true)
        //if (user.MenuList.ContainsKey("2,14,1") == true)
        {
            if (this.IsPostBack == false)
            {
                GetApplicationsList();
                ClearComponents();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    private void GetApplicationsList()
    {
        try
        {
            List<ATTApplication> lstApplicationsDetails;
            lstApplicationsDetails = BLLApplication.GetApplicationListWithFormNMenuNRolesNRoleMenus();
            Session["ApplicationsRolesMenusList"] = lstApplicationsDetails;
            this.ddlApplication_Rqd.DataSource = lstApplicationsDetails;
            this.ddlApplication_Rqd.DataTextField = "ApplicationFullName";
            this.ddlApplication_Rqd.DataValueField = "ApplicationID";
            this.ddlApplication_Rqd.SelectedIndex = 0;
            this.ddlApplication_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlApplication_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.lstRoles.DataSource = "";
            this.grdApplMenus.DataSource = "";
            this.txtRoleName_Rqd.Text = "";
            this.txtRoleDesc_Rqd.Text = "";
            if (this.ddlApplication_Rqd.SelectedIndex > 0)
            {
                List<ATTApplication> lstApplicationRoleMenus = (List<ATTApplication>)Session["ApplicationsRolesMenusList"];
                this.lstRoles.DataSource = lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstRoles;
                this.lstRoles.DataTextField = "RoleName";
                this.lstRoles.DataValueField = "RoleID";
                if (lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstMenus.Count > 0)
                    this.lblMenus.Visible = true;
                else
                    this.lblMenus.Visible = false;
                this.grdApplMenus.DataSource = lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstMenus;

            }

            this.lstRoles.DataBind();
            this.grdApplMenus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtRoleName_Rqd.Text = "";
        this.txtRoleDesc_Rqd.Text = "";
        try
        {
            List<ATTApplication> lstApplicationRoleMenus = (List<ATTApplication>)Session["ApplicationsRolesMenusList"];
            this.grdApplMenus.DataSource = lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstMenus;
            this.grdApplMenus.DataBind();

            if (this.lstRoles.SelectedIndex > -1)
            {
                this.txtRoleName_Rqd.Text = lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleName;
                this.txtRoleDesc_Rqd.Text = lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleDescription;
                foreach (ATTRoleMenus rolemnus in lstApplicationRoleMenus[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].LstRoleMenus)
                {
                    int? intApplId;
                    int? intFormId;
                    int? intMenuId;
                    intApplId = rolemnus.ApplicationID;
                    intFormId = rolemnus.FormID;
                    intMenuId = rolemnus.MenuID;
                    foreach (GridViewRow row in this.grdApplMenus.Rows)
                    {
                        CheckBox cbSelMnu = (CheckBox)(row.Cells[5].FindControl("chkSelectMenu"));
                        CheckBox cbOldSelMnu = (CheckBox)(row.Cells[6].FindControl("chkOldSelectMenu"));
                        CheckBox cbAddMnu = (CheckBox)(row.Cells[7].FindControl("chkAddMenu"));
                        CheckBox cbOldAddMnu = (CheckBox)(row.Cells[8].FindControl("chkOldAddMenu"));
                        CheckBox cbEditMnu = (CheckBox)(row.Cells[9].FindControl("chkEditMenu"));
                        CheckBox cbOldEditMnu = (CheckBox)(row.Cells[10].FindControl("chkOldEditMenu"));
                        CheckBox cbDelMnu = (CheckBox)(row.Cells[11].FindControl("chkDelMenu"));
                        CheckBox cbOldDelMnu = (CheckBox)(row.Cells[12].FindControl("chkOldDelMenu"));
                        if ((intApplId == int.Parse(row.Cells[0].Text.ToString())) &&
                            (intFormId == int.Parse(row.Cells[1].Text.ToString())) &&
                            (intMenuId == int.Parse(row.Cells[2].Text.ToString())))
                        {
                            if (rolemnus.PSelect == "Y")
                            {
                                cbSelMnu.Checked = true;
                                cbOldSelMnu.Checked = true;
                            }
                            else
                            {
                                cbSelMnu.Checked = false;
                                cbOldSelMnu.Checked = false;
                            }

                            if (rolemnus.PAdd == "Y")
                            {
                                cbAddMnu.Checked = true;
                                cbOldAddMnu.Checked = true;
                            }
                            else
                            {
                                cbAddMnu.Checked = false;
                                cbOldAddMnu.Checked = false;
                            }

                            if (rolemnus.PEdit == "Y")
                            {
                                cbEditMnu.Checked = true;
                                cbOldEditMnu.Checked = true;
                            }
                            else
                            {
                                cbEditMnu.Checked = false;
                                cbOldEditMnu.Checked = false;
                            }

                            if (rolemnus.PDelete == "Y")
                            {
                                cbDelMnu.Checked = true;
                                cbOldDelMnu.Checked = true;
                            }
                            else
                            {
                                cbDelMnu.Checked = false;
                                cbOldDelMnu.Checked = false;
                            }
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void grdApplMenus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[12].Visible = false;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            lblStatusMessage.Text = "";

            List<ATTApplication> lstApplicationsDetails = (List<ATTApplication>)Session["ApplicationsRolesMenusList"];

            int? roleID = 0;
            if (this.lstRoles.SelectedIndex > -1)
                roleID = lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleID;

            List<ATTRoles> lstRoles = new List<ATTRoles>();
            List<ATTRoleMenus> lstRoleMenus = new List<ATTRoleMenus>();

            ATTRoles RolesAtt = new ATTRoles(roleID, int.Parse(this.ddlApplication_Rqd.SelectedValue.ToString()),
                this.txtRoleName_Rqd.Text, this.txtRoleDesc_Rqd.Text, "");
            ATTRoleMenus RoleMenus=new ATTRoleMenus();

            if (!BLLRoles.Validate(RolesAtt).IsValid)
            {
                this.lblStatusMessage.Text = BLLRoles.Validate(RolesAtt).ErrorMessage.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
            lstRoles.Add(RolesAtt);

            #region "DATABASE PART"
            foreach (GridViewRow row in this.grdApplMenus.Rows)
            {
                string strAction = "";
                string strUpdate = "";
                string strOldUpdate = "";

                CheckBox cbSelMnu = (CheckBox)(row.Cells[5].FindControl("chkSelectMenu"));
                CheckBox cbOldSelMnu = (CheckBox)(row.Cells[6].FindControl("chkOldSelectMenu"));
                CheckBox cbAddMnu = (CheckBox)(row.Cells[7].FindControl("chkAddMenu"));
                CheckBox cbOldAddMnu = (CheckBox)(row.Cells[8].FindControl("chkOldAddMenu"));
                CheckBox cbEditMnu = (CheckBox)(row.Cells[9].FindControl("chkEditMenu"));
                CheckBox cbOldEditMnu = (CheckBox)(row.Cells[10].FindControl("chkOldEditMenu"));
                CheckBox cbDelMnu = (CheckBox)(row.Cells[11].FindControl("chkDelMenu"));
                CheckBox cbOldDelMnu = (CheckBox)(row.Cells[12].FindControl("chkOldDelMenu"));

                if (((cbSelMnu.Checked) || (cbAddMnu.Checked) || (cbEditMnu.Checked) || (cbDelMnu.Checked)) &&
                    ((!cbOldSelMnu.Checked) && (!cbOldAddMnu.Checked) && (!cbOldEditMnu.Checked) && (!cbOldDelMnu.Checked)))
                    strAction = "A";

                else if (((!cbSelMnu.Checked) && (!cbAddMnu.Checked) && (!cbEditMnu.Checked) && (!cbDelMnu.Checked)) &&
                    ((cbOldSelMnu.Checked) || (cbOldAddMnu.Checked) || (cbOldEditMnu.Checked) || (cbOldDelMnu.Checked)))
                    strAction = "D";
                else
                {
                    if (cbSelMnu.Checked)
                        strUpdate += "S";
                    if (cbAddMnu.Checked)
                        strUpdate += "A";
                    if (cbEditMnu.Checked)
                        strUpdate += "E";
                    if (cbDelMnu.Checked)
                        strUpdate += "D";

                    if (cbOldSelMnu.Checked)
                        strOldUpdate += "S";
                    if (cbOldAddMnu.Checked)
                        strOldUpdate += "A";
                    if (cbOldEditMnu.Checked)
                        strOldUpdate += "E";
                    if (cbOldDelMnu.Checked)
                        strOldUpdate += "D";

                    if (strUpdate != strOldUpdate)
                        strAction = "E";
                }

                if (strAction != "")
                {
                    RoleMenus = new ATTRoleMenus(roleID, int.Parse(row.Cells[2].Text.ToString()),
                        int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()),
                        (cbSelMnu.Checked == true ? "Y" : "N"), (cbAddMnu.Checked == true ? "Y" : "N"),
                        (cbEditMnu.Checked == true ? "Y" : "N"), (cbDelMnu.Checked == true ? "Y" : "N"));
                    RoleMenus.Action = strAction;
                    RolesAtt.LstRoleMenus.Add(RoleMenus);
                }


            }
            int newroleID = 0;
            newroleID = BLLRoles.AddRolesAndRoleMenus(lstRoles);
            #endregion

            #region "UPDATE SESSION LIST"
            if (this.lstRoles.SelectedIndex > -1)
            {
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleID = newroleID;
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].ApplicationID = int.Parse(this.ddlApplication_Rqd.SelectedValue.ToString());
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleName = this.txtRoleName_Rqd.Text.Trim();
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].RoleDescription = this.txtRoleDesc_Rqd.Text.Trim();
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].LstRoleMenus.Clear();
                foreach (GridViewRow row in this.grdApplMenus.Rows)
                {
                    CheckBox cbSelMnu = (CheckBox)(row.Cells[5].FindControl("chkSelectMenu"));
                    CheckBox cbOldSelMnu = (CheckBox)(row.Cells[6].FindControl("chkOldSelectMenu"));
                    CheckBox cbAddMnu = (CheckBox)(row.Cells[7].FindControl("chkAddMenu"));
                    CheckBox cbOldAddMnu = (CheckBox)(row.Cells[8].FindControl("chkOldAddMenu"));
                    CheckBox cbEditMnu = (CheckBox)(row.Cells[9].FindControl("chkEditMenu"));
                    CheckBox cbOldEditMnu = (CheckBox)(row.Cells[10].FindControl("chkOldEditMenu"));
                    CheckBox cbDelMnu = (CheckBox)(row.Cells[11].FindControl("chkDelMenu"));
                    CheckBox cbOldDelMnu = (CheckBox)(row.Cells[12].FindControl("chkOldDelMenu"));
                    RoleMenus = new ATTRoleMenus(roleID, int.Parse(row.Cells[2].Text.ToString()),
                        int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()),
                        (cbSelMnu.Checked == true ? "Y" : "N"), (cbAddMnu.Checked == true ? "Y" : "N"),
                        (cbEditMnu.Checked == true ? "Y" : "N"), (cbDelMnu.Checked == true ? "Y" : "N"));
                    lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles[this.lstRoles.SelectedIndex].LstRoleMenus.Add(RoleMenus);
                }
            }
            else
            {
                RolesAtt = new ATTRoles(newroleID, int.Parse(this.ddlApplication_Rqd.SelectedValue.ToString()),
                    this.txtRoleName_Rqd.Text, this.txtRoleDesc_Rqd.Text, "");
                foreach (GridViewRow row in this.grdApplMenus.Rows)
                {
                    CheckBox cbSelMnu = (CheckBox)(row.Cells[5].FindControl("chkSelectMenu"));
                    CheckBox cbOldSelMnu = (CheckBox)(row.Cells[6].FindControl("chkOldSelectMenu"));
                    CheckBox cbAddMnu = (CheckBox)(row.Cells[7].FindControl("chkAddMenu"));
                    CheckBox cbOldAddMnu = (CheckBox)(row.Cells[8].FindControl("chkOldAddMenu"));
                    CheckBox cbEditMnu = (CheckBox)(row.Cells[9].FindControl("chkEditMenu"));
                    CheckBox cbOldEditMnu = (CheckBox)(row.Cells[10].FindControl("chkOldEditMenu"));
                    CheckBox cbDelMnu = (CheckBox)(row.Cells[11].FindControl("chkDelMenu"));
                    CheckBox cbOldDelMnu = (CheckBox)(row.Cells[12].FindControl("chkOldDelMenu"));
                    RoleMenus = new ATTRoleMenus(roleID, int.Parse(row.Cells[2].Text.ToString()),
                        int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()),
                        (cbSelMnu.Checked == true ? "Y" : "N"), (cbAddMnu.Checked == true ? "Y" : "N"),
                        (cbEditMnu.Checked == true ? "Y" : "N"), (cbDelMnu.Checked == true ? "Y" : "N"));
                    RolesAtt.LstRoleMenus.Add(RoleMenus);
                }
                lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles.Add(RolesAtt);

           }
            this.lstRoles.DataSource = lstApplicationsDetails[this.ddlApplication_Rqd.SelectedIndex].LstRoles;
            this.lstRoles.DataBind();
            lstRoles_SelectedIndexChanged(sender, e);
            #endregion
            this.lblStatusMessage.Text = "Role Details Successfully Saved.";
            this.programmaticModalPopup.Show();
        }


        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearComponents();
    }

    void ClearComponents()
    {
        try
        {
            this.ddlApplication_Rqd.SelectedIndex = 0;
            this.lblMenus.Visible = false;
            this.txtRoleName_Rqd.Text = "";
            this.txtRoleDesc_Rqd.Text = "";
            this.lstRoles.DataSource = "";
            this.grdApplMenus.DataSource = "";
            this.lstRoles.DataBind();
            this.grdApplMenus.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
}
