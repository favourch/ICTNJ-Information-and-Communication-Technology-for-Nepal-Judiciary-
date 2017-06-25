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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;

using PCS.FRAMEWORK;

public partial class MODULES_DLPDS_Security_Users : System.Web.UI.Page
{
        
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Password"] = this.txtPassword_RQD.Text;
        this.txtPassword_RQD.Attributes.Add("value", (string)Session["Password"]);
        Session["RePassword"] = this.txtRePassword_RQD.Text;
        this.txtRePassword_RQD.Attributes.Add("value", (string)Session["RePassword"]);


        ////block if without login
        //if (Session["Login_User_Detail"] == null)
        //{
        //    Response.Redirect("~/MODULES/LIS/Login.aspx", true);
        //}

        ////block if from URL
        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //if (user.MenuList.ContainsKey("Add User") == true || user.MenuList.ContainsKey("Update User") == true)
        //{
             if (Page.IsPostBack == false)
            {
         //        Session["SelectedOrg"] = -1;
                LoadOrganization();
            }
        //}
        //else
        //    Response.Redirect("~/MODULES/LIS/Login.aspx", true);
    }

    void LoadOrganization()
    {
        ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];

        List<ATTOrganization> lstOrganization = BLLOrganization.getOrganizationApplicationUserRole(0, 104);
        Session["Organization"] = lstOrganization;
        
        this.DDLOgranization.DataSource = Session["Organization"];
        this.DDLOgranization.DataTextField = "OrgName";
        this.DDLOgranization.DataValueField = "OrgID";
        this.DDLOgranization.DataBind();

        this.BindUserNAplication();

        List<ATTUsers> lstUsers = new BLLUsers().GetUsers("");
        Session["AllUsers"] = lstUsers;

        setRoleTable();
        setPersonTable();
    }

    
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstUsers.SelectedIndex == -1)
            {
                List<ATTUsers> lstAllUsers = (List<ATTUsers>)Session["AllUsers"];
                ATTUsers objUser = lstAllUsers.Find
                                (
                                    delegate(ATTUsers usr)
                                    {
                                        return usr.Username == this.txtUserName_RQD.Text.Trim();
                                    }
                                );
                if (objUser != null)
                {
                    this.lblStatusMessage.Text = "User Already Exists.....";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }


            if (IsUserValid() == false)
            {
                return;
            }

            ATTOrganizationUsers objOrgUser;
            if (DDLTransferTo.SelectedIndex == 0)
            {
                objOrgUser = new ATTOrganizationUsers
                                                                            (
                                                                            (DDLTransferTo.SelectedIndex == 0) ? int.Parse(this.DDLOgranization.SelectedValue) : int.Parse(this.DDLTransferTo.SelectedValue),
                                                                                txtUserName_RQD.Text,
                                                                                "",
                                                                                "",
                                                                                (lstUsers.SelectedIndex != -1) ? "E" : "A"
                                                                            );
            }
            else
            {
                objOrgUser = new ATTOrganizationUsers
                                                                                           (
                                                                                           (DDLTransferTo.SelectedIndex == -1) ? int.Parse(this.DDLOgranization.SelectedValue) : int.Parse(this.DDLTransferTo.SelectedValue),
                                                                                               txtUserName_RQD.Text,
             "",
                                                                                               "",
                                                                                               "A"
                                                                                           );
            }
            string ActvnSts;
            if (DDLTransferTo.SelectedIndex > 0)
            {
                ActvnSts = "N";
            }
            else
            { 
               ActvnSts= (chkActive.Checked == true) ? "Y" : "N";
            }
            objOrgUser.ObjUsers = new ATTUsers
                                            (
                                                    this.txtUserName_RQD.Text,
                                                    this.txtPassword_RQD.Text,
                                                    this.txtRePassword_RQD.Text,
                                                    ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                    DateTime.Now,
                                                    DateTime.Parse(this.txtValidUpto_REDT.Text),
                                                    ActvnSts,
                                                    (lstUsers.SelectedIndex != -1) ? "E" : "A",
                                                    (this.txtPersonID.Text=="")?0:double.Parse(this.txtPersonID.Text)
                                             );


            objOrgUser.LSTUserRoles = BLLUserRoles.GetLSTUserRoles(AddUserRoles());


            if (BLLOrganizationUsers.AddOrgUser(objOrgUser) == true)
            {
                    

                if (lstUsers.SelectedIndex != -1)
                {
                    List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
                    List<ATTOrganizationUsers> lstOrgUser = lstOrganization[this.DDLOgranization.SelectedIndex].LSTOrgUsers;
                    
                    if (DDLTransferTo.SelectedIndex == 0)
                    {
                        //EDITS THE LIST AFTER UPDATE IN THE DATABASE
                        lstOrgUser[lstUsers.SelectedIndex].ObjUsers = new ATTUsers
                                                                                (
                                                                                    this.txtUserName_RQD.Text,
                                                                                    this.txtPassword_RQD.Text,
                                                                                    this.txtRePassword_RQD.Text,
                                                                                    ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                                                    DateTime.Now,
                                                                                    DateTime.Parse(txtValidUpto_REDT.Text),
                                                                                    (chkActive.Checked == true) ? "Y" : "N",
                                                                                    "E",
                                                                                    (this.txtPersonID.Text == "") ? 0 :double.Parse( this.txtPersonID.Text)
                                                                                );

                        lstOrgUser[lstUsers.SelectedIndex].LSTUserRoles.Clear();

                        foreach (GridViewRow gvRow in grdRoles.Rows)
                        {
                            if (gvRow.Cells[5].Text != "R")
                            {
                                ATTUserRoles objUserRoles = new ATTUserRoles
                                                                            (
                                                                                txtUserName_RQD.Text,
                                                                                int.Parse(gvRow.Cells[0].Text),
                                                                                (gvRow.Cells[4].Text != "&nbsp;") ? gvRow.Cells[4].Text : (string)Session["NepDate"],
                                                                                "",
                                                                                int.Parse(gvRow.Cells[2].Text),
                                                                                "E"
                                                                              );
                                objUserRoles.ObjRoles = new ATTRoles
                                                                    (
                                                                        int.Parse(gvRow.Cells[0].Text),
                                                                        int.Parse(gvRow.Cells[2].Text),
                                                                        (string)gvRow.Cells[1].Text,
                                                                        "",
                                                                        "E"
                                                                    );
                                objUserRoles.ObjApplications = new ATTApplication
                                                                                (
                                                                                    int.Parse(gvRow.Cells[2].Text),
                                                                                    "",
                                                                                    gvRow.Cells[3].Text,
                                                                                    "",
                                                                                    "E"
                                                                                );

                                lstOrgUser[lstUsers.SelectedIndex].LSTUserRoles.Add(objUserRoles);
                            }
                        }
                    }
                    else if (DDLTransferTo.SelectedIndex > 0)
                    {
                    //TRANSFER TO OTHER ORGANIZATION
                        lstOrgUser[lstUsers.SelectedIndex].LSTUserRoles.Clear();
                        lstOrgUser.RemoveAt(lstUsers.SelectedIndex);

            //BINDS NEW USERLIST 
                        this.lstUsers.DataSource = lstOrgUser;
                        this.lstUsers.DataTextField = "Username";
                        this.lstUsers.DataValueField = "Username";
                        this.lstUsers.DataBind();
                    }
                }
                else
                {
                    //ADDS THE NEW USER IN THE LIST

                    List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
                    List<ATTOrganizationUsers> lstOrgUser = lstOrganization[this.DDLOgranization.SelectedIndex].LSTOrgUsers;
                    List<ATTUserRoles> lstUserRoles = new List<ATTUserRoles>();
                    foreach (GridViewRow gvRow in grdRoles.Rows)
                    {
                        if (gvRow.Cells[5].Text != "R")
                        {
                            ATTUserRoles objUserRoles = new ATTUserRoles
                                                                        (
                                                                            txtUserName_RQD.Text,
                                                                            int.Parse(gvRow.Cells[0].Text),
                                                                            (string)Session["NepDate"],
                                                                            "",
                                                                            int.Parse(gvRow.Cells[2].Text),
                                                                            "E"
                                                                          );
                            objUserRoles.ObjRoles = new ATTRoles
                                                                (
                                                                    int.Parse(gvRow.Cells[0].Text),
                                                                    int.Parse(gvRow.Cells[2].Text),
                                                                    (string)gvRow.Cells[1].Text,
                                                                    "",
                                                                    "E"
                                                                );
                            objUserRoles.ObjApplications = new ATTApplication
                                                                            (
                                                                                int.Parse(gvRow.Cells[2].Text),
                                                                                "",
                                                                                gvRow.Cells[3].Text,
                                                                                "",
                                                                                "E"
                                                                            );
                            lstUserRoles.Add(objUserRoles);

                        }
                    }

                    ATTOrganizationUsers objOrgUsers = new ATTOrganizationUsers(
                                                                int.Parse(DDLOgranization.SelectedValue),
                                                                txtUserName_RQD.Text,
                                                                "",
                                                                "",
                                                                "E"
                                                                );
                    objOrgUser.LSTUserRoles = lstUserRoles;
                    objOrgUser.ObjUsers = new ATTUsers
                                                    (
                                                        txtUserName_RQD.Text,
                                                        txtPassword_RQD.Text,
                                                        txtRePassword_RQD.Text,
                                                        ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                        DateTime.Now,
                                                        DateTime.Parse(txtValidUpto_REDT.Text),
                                                        (chkActive.Checked == true) ? "Y" : "N",
                                                        "E",
                                                        (this.txtPersonID.Text == "") ? 0 :double.Parse( this.txtPersonID.Text)
                                                    );


                    lstOrgUser.Add(objOrgUser);

                    this.lstUsers.DataSource = lstOrgUser;
                    this.lstUsers.DataTextField = "Username";
                    this.lstUsers.DataValueField = "Username";
                    this.lstUsers.DataBind();


                }



                txtUserName_RQD.Enabled = true;
                ClearContros();

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "<CENTER>Error In Saving User..</CENTER><BR><BR>" + ex.ToString();
            this.programmaticModalPopup.Show();
        }
        
    }

    

    /// <summary>
    /// Prepares a Datatable of User Roles To Pass it to the Constructor
    /// </summary>
    /// <returns>Datatable</returns>
    
    DataTable AddUserRoles()
    {

        DataTable dt = new DataTable();

        DataColumn dc1 = new DataColumn("RoleID");
        DataColumn dc2 = new DataColumn("Username");
        DataColumn dc3 = new DataColumn("ApplID");
        DataColumn dc4 = new DataColumn("FromDate");
        DataColumn dc5 = new DataColumn("Action");
        DataColumn dc6 = new DataColumn("ToDate");

        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        dt.Columns.Add(dc3);
        dt.Columns.Add(dc4);
        dt.Columns.Add(dc5);
        dt.Columns.Add(dc6);

        try
        {
            foreach (GridViewRow gvRow in this.grdRoles.Rows)
            {
                DataRow row = dt.NewRow();

                row["RoleID"] = gvRow.Cells[0].Text;
                row["Username"] = txtUserName_RQD.Text;
                row["FromDate"] = (gvRow.Cells[4].Text == "&nbsp;") ? (string) Session["NepDate"] : gvRow.Cells[4].Text;
                row["ApplID"] = gvRow.Cells[2].Text;
                row["Action"] = gvRow.Cells[5].Text;
                if (gvRow.Cells[5].Text == "R")
                    row["ToDate"] = (string)Session["NepDate"];
                else
                    row["ToDate"] = "";
                dt.Rows.Add(row);
            }
            return dt;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
            return new DataTable();
        }

    }
        
    protected void DDLOgranization_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void BindUserNAplication()
    {
        try
        {
            grdRoles.DataSource = "";
            grdRoles.DataBind();

            List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
            List<ATTOrganizationApplications> lstOrgApplication = lstOrganization[DDLOgranization.SelectedIndex].LSTOrgApplications;
            this.lstApplications.DataSource = lstOrgApplication;
            this.lstApplications.DataTextField = "ApplFullName";
            this.lstApplications.DataValueField = "ApplID";
            this.lstApplications.DataBind();

            List<ATTOrganizationUsers> lstOrgUser = lstOrganization[DDLOgranization.SelectedIndex].LSTOrgUsers;
            this.lstUsers.DataSource = lstOrgUser;
            this.lstUsers.DataTextField = "Username";
            this.lstUsers.DataValueField = "Username";
            this.lstUsers.DataBind();

            chklstRoles.DataSource = "";
            chklstRoles.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void getOrgApplications(int orgID)
    {
       
    }

    

    protected void ClearContros()
    {
        txtUserName_RQD.Text = "";
        //DDLOgranization_RQD.SelectedIndex = -1;
        DDLTransferTo.SelectedIndex = -1;
        txtPassword_RQD.Attributes.Add("value", "");
        txtRePassword_RQD.Attributes.Add("value", "");
        txtValidUpto_REDT.Text = "";
        //lstUsers.Items.Clear();
        //lstApplications.Items.Clear();
        lstUsers.SelectedIndex = -1;
        lstApplications.SelectedIndex = -1;
        grdRoles.DataSource = "";
        grdRoles.DataBind();
        chklstRoles.Items.Clear();
        chkActive.Checked = false;
        lblRoles.Visible = false;
        btnAddRolesToGrid.Visible = false;
        pnlRoles.Visible = false;
        txtUserName_RQD.Enabled = true;
        txtRePassword_RQD.Enabled = true;
        txtPassword_RQD.Enabled = true;
        lblTransferTo.Visible = false;
        DDLTransferTo.Visible = false;
        txtPersonID.Text = "";
        BindUserNAplication();
        

    }


    protected void lstApplications_SelectedIndexChanged(object sender, EventArgs e)
    {

        List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
        List<ATTOrganizationApplications> lstOrgApplication;
        
        //if (DDLTransferTo.SelectedIndex == 0)
            lstOrgApplication = lstOrganization[DDLOgranization.SelectedIndex].LSTOrgApplications;
        //else
        //    lstOrgApplication = lstOrganization[DDLTransferTo.SelectedIndex].LSTOrgApplications;

        List<ATTRoles> lstRoles = lstOrgApplication[lstApplications.SelectedIndex].LSTRoles;
        chklstRoles.DataSource = lstRoles;
        chklstRoles.DataValueField = "RoleID";
        chklstRoles.DataTextField = "RoleName";
        chklstRoles.DataBind();
        if (chklstRoles.Items.Count > 0)
        {
            lblRoles.Visible = true;
            btnAddRolesToGrid.Visible = true;
            pnlRoles.Visible = true;
        }

        foreach (GridViewRow gvRow in this.grdRoles.Rows)
        {
            foreach (ListItem lst in chklstRoles.Items)
            {
                if (gvRow.Cells[0].Text == lst.Value && lstApplications.SelectedValue==gvRow.Cells[2].Text)
                    lst.Selected = true;
            }
        }
        //if (this.grdRoles.Rows.Count > 0)
        //{
 
        //}
        
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        
       
    }
    void setPersonTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EmpID");
        DataColumn dtCol1 = new DataColumn("PID");
        DataColumn dtCol2 = new DataColumn("Employee Name");
        
        
        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        
        Session["PersonTbl"] = tbl;
    
    }

    void setRoleTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("RoleID");
        DataColumn dtCol1 = new DataColumn("RoleName");
        DataColumn dtCol2 = new DataColumn("ApplID");
        DataColumn dtCol3 = new DataColumn("ApplicationName");
        DataColumn dtCol4 = new DataColumn("FromDate");
        DataColumn dtCol5 = new DataColumn("Action");
        
        DataColumn[] PK = new DataColumn[] { dtCol0, dtCol2 };

        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);

        tbl.PrimaryKey = PK;


        Session["RoleTbl"] = tbl;
    }


    protected void btnAddRolesToGrid_Click(object sender, EventArgs e)
    {

        if (this.txtUserName_RQD.Text == "" || this.txtPassword_RQD.Text == "" || this.txtRePassword_RQD.Text == "" || this.txtValidUpto_REDT.Text == "")
        {
            this.lblStatusMessage.Text = "Either Username or Password or ValidUpto Fields are Left Blank.<BR>Please Enter The Values";
            this.programmaticModalPopup.Show();
            return;
        }
        
        DataTable tblRoles = (DataTable)Session["RoleTbl"];
        tblRoles.Rows.Clear();
        if (grdRoles.Rows.Count > 0)
        {
            foreach (GridViewRow gvRow in grdRoles.Rows)
            {
                DataRow row = tblRoles.NewRow();
                row["RoleID"] = gvRow.Cells[0].Text;
                row["RoleName"] = gvRow.Cells[1].Text;
                row["ApplID"] = gvRow.Cells[2].Text;
                row["ApplicationName"] = gvRow.Cells[3].Text;
                row["FromDate"] = (gvRow.Cells[4].Text == "&nbsp;") ? "" : gvRow.Cells[4].Text;
                row["Action"] = gvRow.Cells[5].Text;
                try
                {
                    tblRoles.Rows.Add (row);
                }
                catch(Exception)
                {
                }

            }
        }

        foreach (ListItem lst in chklstRoles.Items)
        {
            if (lst.Selected)
            {
                DataRow row = tblRoles.NewRow();

                row["RoleID"] = lst.Value;
                row["RoleName"] = lst.Text;
                row["ApplID"] = lstApplications.SelectedValue;
                row["ApplicationName"] = lstApplications.SelectedItem;
                row["FromDate"] = "";
                row["Action"] = "A";

                try
                {
                    tblRoles.Rows.Add(row);
                }
                catch (Exception)
                {
                }
            }
        }
        tblRoles.DefaultView.Sort = "ApplID";
        grdRoles.DataSource = tblRoles;
        grdRoles.DataBind();
       // Session["RoleTbl"] ="";

        

    }

   

    void DTtoLst(DataTable tbl)
    {
        
    }

    protected void grdRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //DataTable tblRoles = (DataTable)Session["RoleTbl"];
        //tblRoles.Rows.RemoveAt(grdRoles.SelectedIndex);
        
        GridViewRow row = grdRoles.SelectedRow;
        if (row.Cells[5].Text == "E" || row.Cells[5].Text == "A")
        {
            row.Cells[5].Text = "R";
            row.ForeColor = System.Drawing.Color.Red;
            ((LinkButton)this.grdRoles.Rows[this.grdRoles.SelectedIndex].Cells[6].Controls[0]).Text = "Undo";
        }
        else if (row.Cells[5].Text == "R" && row.Cells[4].Text != "&nbsp;")
        {
            row.Cells[5].Text = "E";
            row.ForeColor = System.Drawing.Color.FromArgb(333333); 
            ((LinkButton)this.grdRoles.Rows[this.grdRoles.SelectedIndex].Cells[6].Controls[0]).Text = "Remove";
        }
        else if (row.Cells[5].Text == "R" && row.Cells[4].Text=="&nbsp;" )
        {
            row.Cells[5].Text = "A";
            row.ForeColor =System.Drawing.Color.FromArgb(333333);//"; //System.Drawing.Color.Black;
            ((LinkButton)this.grdRoles.Rows[this.grdRoles.SelectedIndex].Cells[6].Controls[0]).Text = "Remove";
        }

        this.grdRoles.SelectedIndex = -1;
    }

    protected void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lstApplications.SelectedIndex = -1;

            if (this.DDLTransferTo.Items.Count <= 0)
            {

                List<ATTOrganization> lstAllOrg = BLLOrganization.GetOrganization();
                ATTOrganization orgToRemove = lstAllOrg.Find
                                                            (
                                                                delegate(ATTOrganization objOrg)
                                                                {
                                                                    return objOrg.OrgID == int.Parse(this.DDLOgranization.SelectedValue);
                                                                }
                                                            );

                lstAllOrg.Remove(orgToRemove);
                lstAllOrg.Insert(0, new ATTOrganization(0, "--- Select Organization ---", "", "", 0));

                this.DDLTransferTo.DataSource = lstAllOrg;
                this.DDLTransferTo.DataTextField = "OrgName";
                this.DDLTransferTo.DataValueField = "OrgID";
                this.DDLTransferTo.DataBind();
            }
            
            List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
            List<ATTUserRoles> lstUserRoles = lstOrganization[DDLOgranization.SelectedIndex].LSTOrgUsers[lstUsers.SelectedIndex].LSTUserRoles;
                lstUserRoles.Sort(delegate(ATTUserRoles a1, ATTUserRoles a2) { return a1.ApplID.CompareTo(a2.ApplID); });

            grdRoles.DataSource = lstUserRoles;
            grdRoles.DataBind();


            ATTUsers objUsers=lstOrganization[DDLOgranization.SelectedIndex].LSTOrgUsers[lstUsers.SelectedIndex].ObjUsers;
            this.txtPersonID.Text = (objUsers.PID==0)?"":objUsers.PID.ToString();
            this.txtUserName_RQD.Text = objUsers.Username;
            this.txtPassword_RQD.Attributes.Add("value", objUsers.Password);
            this.txtRePassword_RQD.Attributes.Add("value", objUsers.Password);
            //txtValidUpto_RDT.Text = objUsers.ValidUpto.ToShortDateString();
            string dt = this.FormateDate(objUsers.ValidUpto);
            txtValidUpto_REDT.Text = dt;
            if (objUsers.Active == "Y")
                this.chkActive.Checked = true;
            else
                this.chkActive.Checked = false;

            this.txtUserName_RQD.Enabled = false;
            this.lblTransferTo.Visible = true;
            this.DDLTransferTo.Visible = true;
            this.chklstRoles.DataSource = "";
            this.chklstRoles.DataBind();
          //  txtPassword_RQD.ReadOnly = true;
          //txtRePassword_RQD.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        } 

    }

    string FormateDate(DateTime DT)
    {
        char[] token ={ '/' };
        string[] array = DT.ToShortDateString().Split(token);

        return FormateCode(array[0], 2) + "/" + FormateCode(array[1], 2) + "/" + FormateCode(array[2], 4);
    }

    string FormateCode(string Code, int Length)
    {
        string Prefix = "00000";
        Code = Prefix + Code;
        return Code.Substring(Code.Length - Length, Length);
    }


    

    protected bool IsUserValid()
    {
        
         
        ATTUsers objUsers = new ATTUsers(
                                          this.txtUserName_RQD.Text,
                                          this.txtPassword_RQD.Text,
                                          this.txtRePassword_RQD.Text,
                                          ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                          DateTime.Now,
                                          (this.txtValidUpto_REDT.Text == "") ? DateTime.Parse("01/01/0001") : DateTime.Parse(this.txtValidUpto_REDT.Text),
                                          (this.chkActive.Checked == true) ? "Y" : "N",
                                          "",
                                          (this.txtPersonID.Text == "") ? 0 : double.Parse(this.txtPersonID.Text)
                                       );

        ObjectValidation OV = BLLUsers.Validate(objUsers);
        if (OV.IsValid == false)
        {
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show();
            return false ;
        }


        ATTOrganizationUsers objOrgUser = new ATTOrganizationUsers
                                                   (int.Parse(this.DDLOgranization.SelectedValue.ToString()),
                                                        txtUserName_RQD.Text,
                                                        ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                        DateTime.Now.AddYears(1).ToString(),
                                                        ""
                                                    );


        OV = BLLOrganizationUsers.Validate(objOrgUser);
        if (OV.IsValid == false)
        {
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show(); 
            return false;
        }

        if (BLLUsers.ValidateDate(txtValidUpto_REDT.Text) == false)
        {
            this.lblStatusMessage.Text = "Invalid Date Format:  Date should be in DD/MM/YYYY Format";
            this.programmaticModalPopup.Show();
            return false;
        }

        return true;
    }

    protected void grdRoles_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[5].Visible = false;
    }

    string previousCat = "";
    int firstRow = -1;
    protected void grdRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (previousCat == e.Row.Cells[2].Text)
            {
                if (this.grdRoles.Rows[firstRow].Cells[3].RowSpan == 0)
                    this.grdRoles.Rows[firstRow].Cells[3].RowSpan = 2;
                else
                    this.grdRoles.Rows[firstRow].Cells[3].RowSpan += 1;
                e.Row.Cells[3].Visible = false;
            }

            else //It's a new category
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;
                e.Row.Cells[3].Font.Bold = true;
                previousCat=e.Row.Cells[2].Text;
                firstRow = e.Row.RowIndex;
                //e.Row.BackColor = System.Drawing.Color.Green;
                //e.Row.BorderStyle = BorderStyle.Solid;
                //e.Row.BorderWidth = new Unit(1);
                //e.Row.BorderColor = System.Drawing.Color.Black;
            }

        }
    }
    protected void grdRoles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }
    protected void grdRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
    protected void grdRoles_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = this.grdRoles.DataSource as DataTable;
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + "ASC";
            this.grdRoles.DataSource = dataView;
            this.grdRoles.DataBind();
        }
    }


    protected void DDLTransferTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //List<ATTOrganization> lstOrganization = (List<ATTOrganization>)Session["Organization"];
        //List<ATTOrganizationApplications> lstOrgApplication = lstOrganization[DDLTransferTo.SelectedIndex].LSTOrgApplications;
        //this.lstApplications.DataSource = lstOrgApplication;
        //this.lstApplications.DataTextField = "ApplFullName";
        //this.lstApplications.DataValueField = "ApplID";
        //this.lstApplications.DataBind();
        this.lstApplications.Items.Clear();

        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUserName_RQD.Enabled = true;
        txtRePassword_RQD.Enabled = true;
        txtPassword_RQD.Enabled = true;
        ClearContros();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //List<ATTPerson> lstPerson = BLLPerson.GetPersonForUser(txtFName.Text, txtMName.Text, txtLName.Text);
       // List<ATTPerson> p = lstPerson;
    }
}
