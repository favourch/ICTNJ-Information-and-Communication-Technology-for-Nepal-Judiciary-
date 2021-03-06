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

public partial class MODULES_PMS_Forms_EmployeeLeave : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,12,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
                tabContainerEmpLeave.ActiveTabIndex = 0;
                //Panel3.Height = Unit.Pixel(0);
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
   
    ////gridview events
  
    protected void grdLeaveApplications_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.tabContainerEmpLeave.ActiveTabIndex == 0)
            {
                txtEmpName.Text = grdLeaveApplications.SelectedRow.Cells[2].Text.Trim();
                txtEmpDate.Text = grdLeaveApplications.SelectedRow.Cells[5].Text.Trim();
                ddlAppType.SelectedValue = grdLeaveApplications.SelectedRow.Cells[3].Text.Trim();
                txtEmpLvFrom.Text = grdLeaveApplications.SelectedRow.Cells[6].Text.Trim();
                txtEmpLvTo.Text = grdLeaveApplications.SelectedRow.Cells[7].Text.Trim();
                txtEmpLvDays.Text = grdLeaveApplications.SelectedRow.Cells[8].Text.Trim();
                txtEmpLvResn.Text = Server.HtmlDecode(grdLeaveApplications.SelectedRow.Cells[9].Text.Trim()).ToString();
                btnRecSubmit.Enabled = false;
            }
            else if (this.tabContainerEmpLeave.ActiveTabIndex == 1)
            {
                txtRecName.Text = Server.HtmlDecode(grdLeaveApplications.SelectedRow.Cells[12].Text.Trim());
                txtRecDate.Text = grdLeaveApplications.SelectedRow.Cells[13].Text.Trim();
                txtRecFrom.Text = grdLeaveApplications.SelectedRow.Cells[6].Text.Trim();
                txtRecTo.Text = grdLeaveApplications.SelectedRow.Cells[7].Text.Trim();
                txtRecDays.Text = grdLeaveApplications.SelectedRow.Cells[8].Text.Trim();
                txtRecReason.Text = Server.HtmlDecode(grdLeaveApplications.SelectedRow.Cells[9].Text.Trim()).ToString();
                btnRecSubmit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();

        }
        if (tabContainerEmpLeave.ActiveTabIndex == 1)
        {
            btnRecSubmit.Enabled = false;
        }
        else
        {
            btnApplSubmit.Enabled = false;
        }
    }
    protected void grdLeaveApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        //e.Row.Cells[8].Visible = false;
        e.Row.Cells[10].Visible = false;
        if (tabContainerEmpLeave.ActiveTabIndex == 0)
        {
            e.Row.Cells[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (tabContainerEmpLeave.ActiveTabIndex == 0 && e.Row.Cells[11].Text == "Y")
            {
                //e.Row.Cells[11].Enabled = false
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkselect");
                btn.Enabled = false;

            }
            if (tabContainerEmpLeave.ActiveTabIndex == 1)
            {
                if (e.Row.Cells[9].Text == "D")
                {
                    e.Row.Cells[11].Enabled = false;
                    LinkButton btn = (LinkButton)e.Row.FindControl("lnkDelete");
                    btn.Text = "Undo";
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (tabContainerEmpLeave.ActiveTabIndex == 1 && e.Row.Cells[14].Text == "Y")
            {
                LinkButton btn = (LinkButton)e.Row.FindControl("lnkselect");
                btn.Enabled = false;
            }
        }
    }
    protected void grdLeaveApplications_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LinkButton btn = (LinkButton)grdLeaveApplications.Rows[e.RowIndex].FindControl("lnkDelete");
        List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
        //if (lstEmployeeLeave[e.RowIndex].Action == "A" | lstEmployeeLeave[e.RowIndex].Action == "E")
        //{
        //    lstEmployeeLeave.RemoveAt(e.RowIndex);
        //    //ClearControls(false);
        //}
        //else
        //{

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
        this.CollapsiblePanelExtender1.Collapsed = true;
        //System.Threading.Thread.Sleep(1000);

        this.CollapsiblePanelExtender1.ClientState = "true";
        this.CollapsiblePanelExtender1.Collapsed = true;
        

        string Name = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
        int id = 0;
        List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();
        if (tabContainerEmpLeave.ActiveTabIndex == 0)
        {
            id = int.Parse(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            txtEmpName.Text = Name;
            txtEmpName.Attributes.Add("ID", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            lstEmployeeLeave = BLLEmployeeLeave.GetEmployeeLeave(id, "REQ");
            //grdEmployee.SelectedIndex = -1;
            Session["EmployeeLeave"] = lstEmployeeLeave;
            grdLeaveApplications.DataSource = lstEmployeeLeave;
            grdLeaveApplications.DataBind();
        }
        else if (tabContainerEmpLeave.ActiveTabIndex == 1)
        {
            id = int.Parse(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            txtRecName.Text = Name;
            txtRecName.Attributes.Add("ID", grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);

        }

        //Loading Leave Type Drop Down List

        if (tabContainerEmpLeave.ActiveTabIndex == 0)
        {
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
                LSTLeaveTypeDes.Insert(0, new ATTLeaveTypeDesignation(0, "-बिदाको किसिम छान्नुहोस्-", 0, 0, "", 0, false, 0, false, "", "", ""));
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
                lstLeavetype.Insert(0, new ATTLeaveType(0,"-बिदाको किसिम छान्नुहोस्-",""));
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

    //tab container event
    protected void tabContainerEmpLeave_ActiveTabChanged(object sender, EventArgs e)
    {
        if (tabContainerEmpLeave.ActiveTabIndex == 0)
        {
            List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();
            if (Session["EmployeeLeave"] != null)
            {
                lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
            }            
            Session["EmployeeLeave"] = lstEmployeeLeave;
            grdLeaveApplications.DataSource = lstEmployeeLeave;
            grdLeaveApplications.DataBind();
        }
        else if (tabContainerEmpLeave.ActiveTabIndex == 1)
        {
            chkbxRec.Checked = true;
            List<ATTEmployeeLeave> lstEmployeeLeave = BLLEmployeeLeave.GetEmployeeLeave(null, "REQ");
            grdLeaveApplications.DataSource = lstEmployeeLeave;
            grdLeaveApplications.DataBind();
            Session["EmployeeLeave"] = lstEmployeeLeave;
        }
    }

    //text change events
    protected void txtEmpLvFrom_TextChanged(object sender, EventArgs e)
    {
    //    int i = 0;
    //    string errmessage = "<P><b><U>! Attention </U></b></P>";
    //    string s = IsDateValid(txtEmpLvFrom, txtEmpLvTo);
    //    try
    //    {
    //        int timespan = int.Parse(s);
    //        txtEmpLvDays.Text = s;
    //    }
    //    catch (Exception)
    //    {
    //        if (s == "a")
    //        {
    //            i++;
    //            errmessage += i.ToString() + ") अवधि देखि राख्न्नु होस् ?????? <br />";
    //        }

    //        else if (s == "ab")
    //        {
    //            i++;
    //            errmessage += i.ToString() + ")  अवधि देखि राख्न्नु होस् ??????<br />";
    //            i++;
    //            errmessage += i.ToString() + ") अवधि सम्म राख्न्नु होस् ?????? <br />";
    //        }
    //        else if (s == "Invalid Date")
    //        {
    //            i++;
    //            errmessage += i.ToString() + ")" + s + " <br />";
    //        }
    //    }

    //    if (i > 0)
    //    {
    //        this.lblStatusMessage.Text = errmessage;
    //        this.programmaticModalPopup.Show();
    //        return;

    //    }

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
    //protected void txtRecFrom_TextChanged(object sender, EventArgs e)
    //{
    //    int i = 0;
    //    string errmessage = "<P><b><U>! Attention </U></b></P>";
    //    string s = IsDateValid(txtRecFrom, txtRecTo);
    //    try
    //    {
    //        int timespan = int.Parse(s);
    //        txtRecDays.Text = s;
    //    }
    //    catch (Exception)
    //    {

    //        if (s == "a")
    //        {
    //            i++; errmessage += i.ToString() + ") अवधि देखि राख्न्नु होस् ?????? <br />";
    //        }
    //        //else if (s == "b")
    //        //{
    //        //    i++; errmessage += i.ToString() + ") Effective Till Date ?????? <br />";
    //        //}
    //        else if (s == "ab")
    //        {
    //            i++; errmessage += i.ToString() + ")  अवधि देखि राख्न्नु होस् ??????<br />";
    //            i++; errmessage += i.ToString() + ") अवधि सम्म राख्न्नु होस् ?????? <br />";
    //        }
    //        else if (s == "Invalid Date")
    //        {
    //            i++; errmessage += i.ToString() + ")" + s + " <br />";

    //        }
    //    }

    //    if (i > 0)
    //    {
    //        this.lblStatusMessage.Text = errmessage;
    //        this.programmaticModalPopup.Show();
    //        return;

    //    }
    //}
    protected void txtRecTo_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        string errmessage = "<P><b><U>! Attention </U></b></P>";
        string s = IsDateValid(txtRecFrom, txtRecTo);
        try
        {
            int timespan = int.Parse(s);
            txtRecDays.Text = s;
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

    //button events
    protected void btnAddApplication_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
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
                ATTEmployeeLeave objEmpLST = new ATTEmployeeLeave();
                if (this.grdLeaveApplications.SelectedIndex > -1)
                {
                    objEmpLST = LSTEmpLeave[grdLeaveApplications.SelectedIndex];
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
                    objEmpLST.Action = "E";
                }
                else
                {
                    objEmpLST.EmpID = int.Parse(grdEmployee.SelectedRow.Cells[0].Text);

                    int searchEmp = objEmpLST.EmpID;
                    List<ATTEmployeeLeave> LST = LSTEmpLeave.FindAll(
                                                                        delegate(ATTEmployeeLeave obj)
                                                                        {
                                                                            return (searchEmp == obj.EmpID);
                                                                        }
                                                                    );

                    if (LST.Count>0)
                    {
                        this.lblStatusMessage.Text = "This employee have already applied for leave and is not yet recommended";
                        this.programmaticModalPopup.Show();
                        this.btnApplSubmit.Enabled = false;
                        return;
                    }

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
                    LSTEmpLeave.Add(objEmpLST);                    

                }

                Session["EmployeeLeave"] = LSTEmpLeave;
                grdLeaveApplications.DataSource = LSTEmpLeave;
                grdLeaveApplications.DataBind();

                if (LSTEmpLeave.Count > 0)
                {
                    this.grdLeaveApplications.Visible = true;
                    btnApplSubmit.Enabled = true;
                }
                else 
                {
                    this.grdLeaveApplications.Visible = false;
                    btnApplSubmit.Enabled = false;
                }

                ClearControls(1, 2, 0, 0);
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
    }
    protected void btnAddRecommendation_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        string msg = EmptyMessage("rec");
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
                List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
                ATTEmployeeLeave objEmpLST = lstEmployeeLeave[grdLeaveApplications.SelectedIndex];

                int empid = lstEmployeeLeave[grdLeaveApplications.SelectedIndex].EmpID;
                int recid = int.Parse(txtRecName.Attributes["ID"].ToString());

                if (recid == empid)
                {
                    btnRecSubmit.Enabled = false;
                    this.lblStatusMessage.Text = "**सिफारिस गर्ने कर्मचारी मिलेन....</n>**र्कपया अर्को कर्मचारी छान्नुहोस्";
                    this.programmaticModalPopup.Show();
                    this.txtRecName.Text = "";
                    this.txtRecName.Focus();
                    return;
                }

                objEmpLST.RecByID = int.Parse(txtRecName.Attributes["ID"].ToString());
                objEmpLST.RecByName = this.txtRecName.Text;
                objEmpLST.RecDate = this.txtRecDate.Text;
                objEmpLST.RecFrom = this.txtRecFrom.Text;
                objEmpLST.RecTo = this.txtRecTo.Text;
                objEmpLST.RecDays = int.Parse(txtRecDays.Text);
                if (chkbxRec.Checked == true)
                {
                    objEmpLST.Recommended = "Y";
                }
                else
                {
                    objEmpLST.Recommended = "N";
                }
                objEmpLST.RecReason = this.txtRecReason.Text;
                //objEmpLST.Approved = "N";
                objEmpLST.Action = "E";

                //LSTEmpLeave.Add(objEmpLST);
                Session["EmployeeLeave"] = lstEmployeeLeave;

                grdLeaveApplications.DataSource = lstEmployeeLeave;
                grdLeaveApplications.DataBind();
                btnRecSubmit.Enabled = true;
                grdLeaveApplications.SelectedIndex = -1;
                ClearControls(1,0,2,0);

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
        if (grdLeaveApplications.Rows.Count==0)
        {
            this.lblStatusMessage.Text = "**Sorry No Data To Save";
            this.programmaticModalPopup.Show();
            return;
        }
        grdLeaveApplications.SelectedIndex = -1;
        try
        {
            if (BLLEmployeeLeave.SaveEmpLeaveApplication(LSTEmpLeave))
            {
                this.lblStatusMessage.Text = "Employee Leave Saved Successfully.";
                this.programmaticModalPopup.Show();
                grdLeaveApplications.DataSource = null;
                grdLeaveApplications.DataBind();
                this.CollapsiblePanelExtender1.Collapsed = true;
                this.CollapsiblePanelExtender1.ClientState = "true";
                ClearControls(1, 1, 1, 0);
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
        ClearControls(0,2,0,0);
        this.grdLeaveApplications.Visible = false;
        grdLeaveApplications.SelectedIndex = -1;
        if (txtEmpName.Text != "")
        {
            this.lblStatusMessage.Text = "Are You Sure You Want to Cancel";
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void btnRecSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTEmployeeLeave> lstEmployeeLeave = (List<ATTEmployeeLeave>)Session["EmployeeLeave"];
            int index = 0;
            foreach (GridViewRow rw in this.grdLeaveApplications.Rows)
            {
                if (((CheckBox)rw.FindControl("chk")).Checked == true)
                {
                    lstEmployeeLeave[index].RecByID = int.Parse(txtRecName.Attributes["ID"].ToString());
                    lstEmployeeLeave[index].RecByName = this.txtRecName.Text;
                    lstEmployeeLeave[index].RecDate = this.txtRecDate.Text;
                    lstEmployeeLeave[index].RecFrom = rw.Cells[6].Text;
                    lstEmployeeLeave[index].RecTo = rw.Cells[7].Text;
                    lstEmployeeLeave[index].RecDays = int.Parse(rw.Cells[8].Text);
                    if (chkbxRec.Checked == true)
                    {
                        lstEmployeeLeave[index].Recommended = "Y";
                    }
                    else
                    {
                        lstEmployeeLeave[index].Recommended = "N";
                    }
                    if (this.txtRecReason.Text == "")
                    {
                        lstEmployeeLeave[index].RecReason = "";
                    }
                    else
                    {
                        lstEmployeeLeave[index].RecReason = this.txtRecReason.Text;
                    }
                    //objEmpLST.Approved = "N";
                    lstEmployeeLeave[index].Action = "E";
                }
                index++;
            }
            if (grdLeaveApplications.Rows.Count==0)
            {
                this.lblStatusMessage.Text = "**Sorry! No Data To Save**";
                this.programmaticModalPopup.Show();
                return;
            }

            if (BLLEmployeeLeave.SaveEmpLeaveApplication(lstEmployeeLeave))
            {
                this.lblStatusMessage.Text = "Employee Leave Successfully Recommended.";
                this.programmaticModalPopup.Show();
                this.CollapsiblePanelExtender1.Collapsed = true;
                this.CollapsiblePanelExtender1.ClientState = "true";
            }
            ClearControls(1,1,1,0);
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnRecCancel_Click(object sender, EventArgs e)
    {
        ClearControls(0,0,2,0);
        if (txtRecName.Text != "")
        {
            this.lblStatusMessage.Text = "Are You Sure You Want to Cancel";
            this.programmaticModalPopup.Show();
            return;
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
        ClearControls(1,0,0,0);
        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";
    }

    //functions
    void ClearControls(int search, int add_app, int add_rec, int other)
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
        if (add_app==1 || add_app==2)
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
                ClearControls(1, 0, 0, 0);

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
        if (add_rec==1 || add_rec==2)
        {
            if (add_rec == 1)
            {
                txtRecName.Text = "";
                txtRecDate.Text = "";
                txtRecFrom.Text = "";
                txtRecTo.Text = "";
                txtRecDays.Text = "";
                chkbxRec.Checked = true;
                txtRecReason.Text = "";
                this.grdLeaveApplications.DataSource = null;
                this.grdLeaveApplications.DataBind();
                ClearControls(1, 0, 0, 0);
            }
            else if (add_rec == 2)
            {
                txtRecName.Text = "";
                txtRecDate.Text = "";
                txtRecFrom.Text = "";
                txtRecTo.Text = "";
                txtRecDays.Text = "";
                chkbxRec.Checked = true;
                txtRecReason.Text = "";
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
            this.lblStatusMessage.Text="ठिक मिति रख्न्नुहोस्";
            this.programmaticModalPopup.Show();
            txt1.Text = "";
            txt2.Text = "";
            txt1.Focus();
            return "";
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
    }
    protected void chkbxRec_CheckedChanged(object sender, EventArgs e)
    {
        if (chkbxRec.Checked == false)
        {
            this.lblStatusMessage.Text = "Recommendation of this application will be canceled";
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
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.DesType = "O";
        EmployeeSearch.IniType = 3;

        return EmployeeSearch;
    }
    void LoadDesignations()
    {
            string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null,desType);
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
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        bool val = true;
        foreach (GridViewRow row in grdLeaveApplications.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
            if (check)
            {
                val = false;
            }

        }
        ((CheckBox)grdLeaveApplications.HeaderRow.Cells[0].FindControl("chk")).Checked = val;
        CheckBox chkd = null;
        int countChkd = 0;
        foreach (GridViewRow rw in grdLeaveApplications.Rows)
        {
            chkd = (CheckBox)rw.FindControl("chk");
            if (chkd.Checked == true)
            {
                countChkd++;
            }

        }
        //if (countChkd > 0)
        //{
        //    ClearControls("enable");
        //}
        //else
        //{
        //    ClearControls("chkDisable");
        //}


    }
    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdLeaveApplications.HeaderRow.Cells[0].FindControl("chk")).Checked;
        foreach (GridViewRow row in grdLeaveApplications.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chk")).Checked = val;

        }
        CheckBox chkd = null;
        int countChkd = 0;
        foreach (GridViewRow rw in grdLeaveApplications.Rows)
        {
            chkd = (CheckBox)rw.FindControl("chk");
            if (chkd.Checked == true)
            {
                countChkd++;
            }

        }
        //if (countChkd > 0)
        //{
        //    ClearControls("enable");
        //}
        //else
        //{
        //    ClearControls("chkDisable");
        //}
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
            if (ddlAppType.SelectedIndex == 0)
            {
                msg += "<br/>*--बिदाको किसिम छान्नुहोस्";
            }
        }
        else if (choice == "rec")
        {
            if (this.txtRecName.Text == "")
            {
                msg += "*--जाच्ने कर्मचारीको नाम  भर्नुहोस्";
                count++;
            }
            if (this.txtRecDate.Text == "")
            {
                msg += "<br/>*--सिफारिस मिति  भर्नुहोस्";
                count++;
            }
            if (this.txtRecFrom.Text == "")
            {
                msg += "<br/>*--अवधि देखी भर्नुहोस्";
                count++;
            }
            if (this.txtRecTo.Text == "")
            {
                msg += "<br/>*--अवधि सम्म भर्नुहोस्";
                count++;
            }
            if (this.txtRecDays.Text == "")
            {
                msg += "<br/>*--जम्मा दिन भर्नुहोस्";
                count++;
            }
            if (this.txtRecReason.Text == "")
            {
                msg += "<br/>*--कैफिएत भर्नुहोस्";
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