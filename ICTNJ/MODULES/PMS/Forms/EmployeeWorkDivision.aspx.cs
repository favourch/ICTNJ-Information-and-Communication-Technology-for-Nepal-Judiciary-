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
using PCS.PMS.DLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_Forms_EmployeeWorkDivision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        //this.SrchGrid.Height = Unit.Pixel(0);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,5,1") == true)
        {
            Session["Orgid"] = user.OrgID;
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                //this.chkUnitHead.Enabled = false;               
                this.ddlUnit.Enabled = false;
                LoadOrganization(int.Parse(Session["Orgid"].ToString()));
                LoadDesignations();
                LoadUnit();
                //LoadEmpName();
                ClearControls("disable");
                Session["EmpWorkDiv"] = new List<ATTEmployeeWorkDivision>();
                Session["EmpWorkDivSave"] = new List<ATTEmployeeWorkDivision>();

                CollapsiblePnlSearch.Collapsed = true;
                CollapsiblePnlSearch.ClientState = "true";
                CollapsiblePanelExtender1.Collapsed = true;
                CollapsiblePanelExtender1.ClientState = "true";
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }
    void SetOrgSession()
    {
        Session["OrgUnitObj"] = new ATTOrganizationUnit();
    }

    //void LoadEmpName()
    //{
    //    List<ATTEmployeeDetailSearch> LSTEmpDetSearch = BLLEmployeeDetailSearch.DetailSearchEmployeeList(new ATTEmployeeDetailSearch());
    //    Session["EmployeeName"] = LSTEmpDetSearch;
    //}
    void LoadOrganization(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = BLLOrganization.GetOrgWithChilds(orgID);
        Session["Organization"]=LSTOrgSubType;
        LSTOrgSubType.Insert(0,new ATTOrganization(0,"छान्नुहोस्"));
        Session["SubOrganization"] = LSTOrgSubType;
        ddlOrganization.DataSource = LSTOrgSubType;
        ddlOrganization.DataTextField = "OrgName";
        ddlOrganization.DataValueField = "OrgID";
        ddlOrganization.DataBind();
    }

    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "", 0, 0));
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

    void LoadUnit()
    {
        int orgid = int.Parse(Session["Orgid"].ToString());
        List<ATTOrganizationUnit> LSTOrgUnit = BLLOrganizationUnit.GetOrganizationUnits(orgid, null);
        ddlUnit.DataSource = LSTOrgUnit;
        Session["OrgUnit"] = LSTOrgUnit;
        LSTOrgUnit.Insert(0, new ATTOrganizationUnit(0, 0, "छान्नुहोस्"));
        ddlUnit.DataTextField = "UnitName";
        ddlUnit.DataValueField = "UnitID";
        ddlUnit.DataBind();
    }
  
    void ClearControls(string str)
    {
        if (str == "disable" || str == "submit")
        {
            //this.ddlFant.Enabled = false;
            //this.ddlSection.SelectedIndex = -1;
            //this.ddlSection.Enabled = false;
            this.txtFromDate.Enabled = false;
            this.txtResponsibility.Enabled = false;
            ddlOrganization.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            grdEmpSearch.DataSource = null;
            grdEmpSearch.DataBind();
        }
        if (str == "chkDisable")
        {
            this.ddlUnit.Enabled = false;
            //this.ddlSection.Enabled = false;
            this.txtFromDate.Enabled = false;
            this.txtResponsibility.Enabled = false;
            ddlOrganization.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
        }
        if (str == "enable")
        {
            this.ddlUnit.Enabled = true;
            //this.ddlSection.Enabled = true;
            this.txtFromDate.Enabled = true;
            this.txtResponsibility.Enabled = true;
        }
        if (str == "add" || str == "submit")
        {
            //this.ddlSection.SelectedIndex = -1;
            //this.ddlSection.Enabled = false;
            this.ddlUnit.SelectedIndex = 0;  
            txtResponsibility.Text = "";
            txtFromDate.Text = "";
            this.chkUnitHead.Checked = false;
            //this.chkSectionHead.Checked = false;
            //foreach (GridViewRow rw in this.grdEmpSearch.Rows)
            //{
            //    CheckBox chk = (CheckBox)rw.FindControl("chk");
            //    chk.Checked = false;
            //}
            grdEmpSearch.SelectedIndex = -1;
        }
        if (str == "wrkGrd")
        {   
            ddlUnit.Enabled = true;
            txtFromDate.Enabled = true;
            txtResponsibility.Enabled = true;

            chkUnitHead.Enabled = true;
        }
        if (str == "Cancel")
        {
            ddlUnit.SelectedIndex = -1;
            txtFromDate.Text = "";
            txtResponsibility.Text = "";
            lblSearch.Text = "";
            grdEmployeeWork.DataSource = null;
            grdEmployeeWork.DataBind();
            grdEmpSearch.DataSource = null;
            grdEmpSearch.DataBind();
            ddlOrganization.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            //foreach (GridViewRow rw in this.grdEmpSearch.Rows)
            //{
            //    CheckBox chk = (CheckBox)rw.FindControl("chk");
            //    chk.Checked = false;
            //}
            grdEmpSearch.SelectedIndex = -1;

            
        }
        if (str == "search") 
        {
            ddlOrganization.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            grdEmpSearch.DataSource = null;
            grdEmpSearch.DataBind();
            lblSearch.Text = "";
            
            //foreach (GridViewRow rw in this.grdEmpSearch.Rows)
            //{
            //    CheckBox chk = (CheckBox)rw.FindControl("chk");
            //    chk.Checked = false;
            //}
            grdEmpSearch.SelectedIndex = -1;

        }
    }
    string EmptyMessage()
    {
        int count = 0;
        int countchk = 0;
        string msg = "";
   
        foreach (GridViewRow rw in this.grdEmpSearch.Rows)
        {
            CheckBox chk = (CheckBox)rw.FindControl("chk");
            if (chk.Checked == true)
            {
                countchk++;
            }
        }
        if (countchk == 0)
        {
            msg += "*--कर्मचारी छान्नुहोस्";
            count++;
        }
        if (this.ddlUnit.SelectedIndex < 1)
        {
            msg += "<br/>*--शाखा छान्नुहोस्";
            count++;
        }
        if (this.txtFromDate.Text == "")
        {
            msg += "<br/>*--देखि भर्नुहोस्";
            count++;
        }

        if (this.txtResponsibility.Text == "")
        {
            msg += "<br/>*--जिम्मेवारी भर्नुहोस्";
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
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {   
        if (ddlOrganization.SelectedIndex ==0)
        {
            ddlBranch.Items.Clear();         
        }
        else
        {
            ddlBranch.DataSource = GetUnitsByOrgID(int.Parse(ddlOrganization.SelectedValue));
            ddlBranch.DataTextField = "UnitName";
            ddlBranch.DataValueField = "UnitID";
            ddlBranch.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeWorkDivision> LSTEmp = new List<ATTEmployeeWorkDivision>() ;
        if (this.ddlOrganization.SelectedIndex <1 && this.ddlBranch.SelectedIndex <1)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                LSTEmp = BLLEmployeeWorkDivision.SearchEmployee(GetEmployeeFilter());
                if(LSTEmp.Count==0)
                {
                    lblSearch.Text = "No records found";
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        //LSTEmp.RemoveAll(delegate(ATTEmployeeWorkDivision obj) {return obj.DesType == "J"; });
        grdEmpSearch.DataSource = LSTEmp;
        this.grdEmpSearch.DataBind();
        this.grdEmpSearch.SelectedIndex = -1;
        Session["EmpWorkDiv"] = LSTEmp;
        //CollapsiblePnlSearch.Collapsed = false;
        //CollapsiblePnlSearch.ClientState = "false";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CollapsiblePanelExtender1.Collapsed = false;
        CollapsiblePanelExtender1.ClientState = "false";
        
        this.btnSearchCancel.Enabled = false;

        if (grdEmpSearch.SelectedIndex == -1 && grdEmployeeWork.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (ddlUnit.SelectedIndex < 1)
        {
            this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtFromDate.Text == "")
        {
            this.lblStatusMessage.Text = "मिति छुट्यो";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            List<ATTEmployeeWorkDivision> lstSave = (List<ATTEmployeeWorkDivision>)Session["EmpWorkDivSave"];

            if (grdEmpSearch.SelectedIndex>=0 && grdEmployeeWork.SelectedIndex==-1)
            {               

                ATTEmployeeWorkDivision objEmpWrkDiv = new ATTEmployeeWorkDivision();

                GridViewRow rw = grdEmpSearch.Rows[grdEmpSearch.SelectedIndex];

                objEmpWrkDiv.EmpID = int.Parse(rw.Cells[1].Text);
                bool exists = lstSave.Exists(
                                                delegate(ATTEmployeeWorkDivision obj)
                                                {
                                                    return obj.EmpID == objEmpWrkDiv.EmpID;
                                                }
                                             );


                if (!exists)
                {
                    bool val = false;
                    if (Server.HtmlDecode(rw.Cells[17].Text) == "" || rw.Cells[17].Text == "&nbsp;")
                    {
                        val = true;
                    }
                    else
                    {
                        val = (CheckDateIsValid(rw.Cells[17].Text, this.txtFromDate.Text));
                    }
                    if (val)
                    {
                        objEmpWrkDiv.FullName = rw.Cells[2].Text;
                        objEmpWrkDiv.OrgID = int.Parse(rw.Cells[4].Text);
                        objEmpWrkDiv.OrgName = rw.Cells[5].Text;
                        objEmpWrkDiv.DesID = int.Parse(rw.Cells[6].Text);
                        objEmpWrkDiv.DesName = rw.Cells[7].Text;
                        objEmpWrkDiv.CreatedDate = rw.Cells[9].Text;
                        objEmpWrkDiv.PostID = int.Parse(rw.Cells[10].Text);
                        objEmpWrkDiv.FromDate = rw.Cells[11].Text;
                        objEmpWrkDiv.OrgUnitID = int.Parse(this.ddlUnit.SelectedValue);
                        objEmpWrkDiv.UnitName = this.ddlUnit.SelectedItem.ToString();
                        //objEmpWrkDiv.SectionID = int.Parse(this.ddlSection.SelectedValue);
                        //objEmpWrkDiv.SectionName = this.ddlSection.SelectedItem.ToString();
                        objEmpWrkDiv.UnitFromDate = this.txtFromDate.Text;
                        objEmpWrkDiv.Responsibility = this.txtResponsibility.Text;
                        objEmpWrkDiv.EntryBy = Session["UserName"].ToString();


                        if (this.chkUnitHead.Checked == true)
                        {
                            bool pres = lstSave.Exists(
                                               delegate(ATTEmployeeWorkDivision obj)
                                               {
                                                   return obj.UnitName == objEmpWrkDiv.UnitName &&
                                                       obj.IsHeadOfUnit == "Y";
                                               }
                                            );

                            if (pres)
                            {
                                EnableDisableAddPanel(false);
                                grdEmpSearch.SelectedIndex = -1;

                                lblStatusMessage.Text = "Another Unit Head Already Exists";
                                programmaticModalPopup.Show();
                                return;
                            }
                            else
                            {
                                List<ATTEmployeeWorkDivision> lstEmpWrkDiv = (List<ATTEmployeeWorkDivision>)Session["EmpWorkDiv"];
                                bool present = lstEmpWrkDiv.Exists(
                                               delegate(ATTEmployeeWorkDivision obj)
                                               {
                                                   return obj.UnitName == objEmpWrkDiv.UnitName &&
                                                       obj.IsHeadOfUnit == "Y";
                                               }
                                            );
                                if (present)
                                {
                                    EnableDisableAddPanel(false);
                                    grdEmpSearch.SelectedIndex = -1;

                                    lblStatusMessage.Text = "Another Unit Head Already Exists";
                                    programmaticModalPopup.Show();
                                    return;
                                }
                                else
                                {
                                    objEmpWrkDiv.IsHeadOfUnit = "Y";
                                }

                            }
                        }
                        else
                        {
                            objEmpWrkDiv.IsHeadOfUnit = "N";
                        }
                        //if (this.chkSectionHead.Checked == true)
                        //{
                        //    objEmpWrkDiv.IsHeadOfSection = "Y";
                        //}
                        //else
                        //{
                        //    objEmpWrkDiv.IsHeadOfSection = "N";
                        //}
                        objEmpWrkDiv.Action = "A";


                        lstSave.Add(objEmpWrkDiv);
                    }
                    else
                    {
                        this.lblStatusMessage.Text = "  data has invalid date<br/>**New From Date Greater Than Previous From Date";
                        this.programmaticModalPopup.Show();
                        this.txtFromDate.Text = "";
                        ddlUnit.SelectedIndex = -1;
                        txtResponsibility.Text = "";
                        chkUnitHead.Checked = false;

                        this.txtFromDate.Focus();
                        grdEmpSearch.SelectedIndex = -1;

                        return;
                    }

                    
                }
                else
                {
                    EnableDisableAddPanel(false);
                    grdEmpSearch.SelectedIndex = -1;
                    lblStatusMessage.Text = "Already Assigned";
                    programmaticModalPopup.Show();
                    return;

                }


            }
            else if (grdEmployeeWork.SelectedIndex >= 0)
            {
                List<ATTEmployeeWorkDivision> lstEmpWrkDiv = (List<ATTEmployeeWorkDivision>)Session["EmpWorkDiv"];

                if (chkUnitHead.Checked)
                {

                    List<ATTEmployeeWorkDivision> lst = lstEmpWrkDiv.FindAll(
                                                                        delegate(ATTEmployeeWorkDivision obj)
                                                                        {
                                                                            return obj.OrgUnitID == int.Parse(ddlUnit.SelectedValue);
                                                                        }
                                                                                );

                    if (lst.Count > 0)
                    {

                        bool exist = lst.Exists(
                                                   delegate(ATTEmployeeWorkDivision obj)
                                                   {
                                                       return obj.IsHeadOfUnit == "Y";
                                                   }
                                                           );
                        if (exist)
                        {
                            lblStatusMessage.Text = "Another Unit Head Already Exists";
                            programmaticModalPopup.Show();
                            return;

                        }
                    }

                }
                

                ATTEmployeeWorkDivision objEmpWrkDiv = lstSave[grdEmployeeWork.SelectedIndex];

               int indx = lstEmpWrkDiv.FindIndex(
                                                                         delegate(ATTEmployeeWorkDivision obj)
                                                                         {
                                                                             return obj.EmpID == objEmpWrkDiv.EmpID;
                                                                         }
                                                                                 );
               bool validd = false;
               if (indx >= 0)
               {
                   string oldDate = lstEmpWrkDiv[indx].UnitFromDate;
                   string newDate = txtFromDate.Text;
                   if (oldDate.Trim() == "")
                   {
                       validd = true;
                   }
                   else
                   {
                       validd = CheckDateIsValid(oldDate, newDate);
                   }
               }

               if (validd)
               {
                   objEmpWrkDiv.OrgUnitID = int.Parse(ddlUnit.SelectedValue);

                   objEmpWrkDiv.UnitName = ddlUnit.SelectedItem.ToString();
                   objEmpWrkDiv.IsHeadOfUnit = (chkUnitHead.Checked) ? "Y" : "N";
                   objEmpWrkDiv.Responsibility = txtResponsibility.Text;
                   objEmpWrkDiv.UnitFromDate = txtFromDate.Text;
               }
               else
               {
                   this.lblStatusMessage.Text = "  data has invalid date<br/>**New From Date Greater Than Previous From Date";
                   this.programmaticModalPopup.Show();
                   this.txtFromDate.Text = "";
                   ddlUnit.SelectedIndex = -1;
                   txtResponsibility.Text = "";
                   chkUnitHead.Checked = false;

                   this.txtFromDate.Focus();
                   grdEmpSearch.SelectedIndex = -1;

                   return;
               } 
            }
            grdEmployeeWork.DataSource = lstSave;
            grdEmployeeWork.DataBind();
            ClearControls("add");        
        }
        catch (Exception ex)
        {
            throw ex;
        }


        grdEmployeeWork.SelectedIndex = -1;
        grdEmpSearch.SelectedIndex = -1;
        EnableDisableAddPanel(false);
        //}
    }

    private void EnableDisableAddPanel(bool enable)
    {
        pnlUp.Enabled = true;
        ddlUnit.SelectedIndex = -1;
        chkUnitHead.Checked = false;
        txtResponsibility.Text = "";
        txtFromDate.Text = "";
       

        this.chkUnitHead.Enabled = enable;
        this.ddlUnit.Enabled = enable;

        this.txtResponsibility.Enabled = enable;
        this.txtFromDate.Enabled = enable;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        this.btnSearchCancel.Enabled = true;
        List<ATTEmployeeWorkDivision> LSTEmpWrkDiv = (List<ATTEmployeeWorkDivision>)Session["EmpWorkDivSave"];
        try
        {
            if (BLLEmployeeWorkDivision.SaveEmpWorkDivision(LSTEmpWrkDiv))
            {
                LSTEmpWrkDiv = new List<ATTEmployeeWorkDivision>();
                this.lblStatusMessage.Text = "Employee Work Division Saved Successfully";
                this.programmaticModalPopup.Show();
                grdEmployeeWork.DataSource = null;
                grdEmployeeWork.DataBind();
                ClearControls("submit");

                CollapsiblePanelExtender1.Collapsed = true;
                CollapsiblePanelExtender1.ClientState = "true";

                CollapsiblePnlSearch.Collapsed = true;
                CollapsiblePnlSearch.ClientState = "true";
                
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.btnSearchCancel.Enabled = true;
        ClearControls("Cancel");
    }
    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        ClearControls("search");
    }
    private ATTEmployeeWorkDivision GetEmployeeFilter()
    {
        ATTEmployeeWorkDivision EmployeeSearch = new ATTEmployeeWorkDivision();
        if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlBranch.SelectedIndex > 0) EmployeeSearch.OrgUnitID = int.Parse(this.ddlBranch.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        //if (this.ddlFant.SelectedIndex > 0) EmployeeSearch.SectionID = int.Parse(this.ddlFant.SelectedValue);
        EmployeeSearch.DesType = "O";
        //EmployeeSearch.ToDate = null;
        return EmployeeSearch;
    }
    private ATTEmployeeWorkDivision GetEmpByPost()
    {
        ATTEmployeeWorkDivision EmployeeSearch = new ATTEmployeeWorkDivision();
        return EmployeeSearch;
    }
    List<ATTOrganizationUnit> GetUnitsByOrgID(int orgID)
    {
        List<ATTOrganizationUnit> LSTSubOrganization = (List<ATTOrganizationUnit>)Session["OrgUnit"];
        List<ATTOrganizationUnit> data = new List<ATTOrganizationUnit>();
        data = LSTSubOrganization.FindAll(delegate(ATTOrganizationUnit org)
                                            {return org.OrgID == orgID; }
                                         );
        data.Insert(0, new ATTOrganizationUnit(0, 0, "छान्नुहोस्"));
        return data;
    }
    List<ATTOrganizationSection> GetSection(int unitID)
    {
        List<ATTOrganizationSection> LSTSection = (List<ATTOrganizationSection>)Session["Section"];
        List<ATTOrganizationSection> data = new List<ATTOrganizationSection>();
        data = LSTSection.FindAll(delegate(ATTOrganizationSection org)
                                            { return org.UnitID == unitID; }
                                         );
        //data.Insert(0, new ATTOrganizationUnit(0, 0, "----छान्नुहोस्----"));
        return data;
    }
    List<ATTOrganizationDesignation> GetPostByOrgID(int orgID)
    {
        List<ATTOrganizationDesignation> LSTPost = (List<ATTOrganizationDesignation>)Session["Post"];
        List<ATTOrganizationDesignation> data2 = new List<ATTOrganizationDesignation>();

        data2 = LSTPost.FindAll(delegate(ATTOrganizationDesignation post)
                                    { return post.OrgID == orgID; }
                               );
        data2.Insert(0, new ATTOrganizationDesignation(0, 0, 0, 0, 0, 0, 0, "छान्नुहोस्"));
        return data2;                   
    }
    //List<ATTEmployeeDetailSearch> GetEmployeeNameByPost(string Post)
    //{
    //    List<ATTEmployeeDetailSearch> LSTEmpName = (List<ATTEmployeeDetailSearch>)Session["EmployeeName"];
    //    List<ATTEmployeeDetailSearch> data1 = new List<ATTEmployeeDetailSearch>();

    //    data1 = LSTEmpName.FindAll(delegate(ATTEmployeeDetailSearch post)
    //                                {return post.PostName == Post;}
    //                              );
    //    return data1;
    //}
    protected void grdEmployeeWork_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
          
            if (grdEmployeeWork.SelectedRow.Cells[9].Text != "" && grdEmployeeWork.SelectedRow.Cells[9].Text != "&nbsp;")
            {
                ddlUnit.SelectedValue = grdEmployeeWork.SelectedRow.Cells[9].Text.Trim();
            }
            txtResponsibility.Text = Server.HtmlDecode(grdEmployeeWork.SelectedRow.Cells[14].Text.Trim());
            txtFromDate.Text = Server.HtmlDecode(grdEmployeeWork.SelectedRow.Cells[13].Text.Trim());
            if (Server.HtmlDecode(grdEmployeeWork.SelectedRow.Cells[15].Text.Trim()) == "Y")
            {
                this.chkUnitHead.Checked = true;
            }
            else
            {
                this.chkUnitHead.Checked = false;
 
            }
           
            ClearControls("wrkGrd");

            grdEmpSearch.SelectedIndex = -1;
        }
        catch (Exception ex)
        { 
            throw ex;
        }
    }
    protected void grdEmpSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
        
        e.Row.Cells[0].Visible = false;

        e.Row.Cells[1].Visible=false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        //e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[14].Visible = false;
        e.Row.Cells[15].Visible = false;
        e.Row.Cells[16].Visible = false;
        e.Row.Cells[18].Visible = false;
        e.Row.Cells[20].Visible = false;

    }
    private bool CheckDateIsValid(string oldDate, string newDate)
    {
        string[] oldDt = oldDate.Split(new char[] { '/' });
        string[] newDt = newDate.Split(new char[] { '/' });

        int oldYr = int.Parse(oldDt[0]);
        int oldMth = int.Parse(oldDt[1]);
        int oldDy = int.Parse(oldDt[2]);

        int newYr = int.Parse(newDt[0]);
        int newMth = int.Parse(newDt[1]);
        int newDy = int.Parse(newDt[2]);

        bool val = false;

        if (newYr > oldYr)
        {
            val = true;
        }
        else if (newYr < oldYr)
        {
            val = false;
        }
        else if (newYr == oldYr)
        {
            if (newMth > oldMth)
            {
                val = true;
            }
            else if (newMth < oldMth)
            {
                val = false;
            }
            else if (newMth == oldMth)
            {
                if (newDy > oldDy)
                {
                    val = true;
                }
                else if (newDy < oldDy)
                {
                    val = false;
                }
                else if (newDy == oldDy)
                {
                    val = false;
                }
            }
        }

        return val;
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
      
        bool val = true;
        foreach (GridViewRow row in grdEmpSearch.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
            if (check)
            {
                val = false;
            }
           
        }
        ((CheckBox)grdEmpSearch.HeaderRow.Cells[0].FindControl("chk")).Checked = val;
        CheckBox chkd = null;
        int countChkd = 0;
        foreach (GridViewRow rw in grdEmpSearch.Rows)
        {
            chkd = (CheckBox)rw.FindControl("chk");
            if (chkd.Checked==true)
            {
                countChkd++;
            }
            
        }
        if (countChkd > 0)
        {
            ClearControls("enable");
        }
        else
        {
            ClearControls("chkDisable");
        }

        
    }
    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdEmpSearch.HeaderRow.Cells[0].FindControl("chk")).Checked;
        foreach (GridViewRow row in grdEmpSearch.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chk")).Checked = val;
            
        }
        CheckBox chkd = null;
        int countChkd = 0;
        foreach (GridViewRow rw in grdEmpSearch.Rows)
        {
            chkd = (CheckBox)rw.FindControl("chk");
            if (chkd.Checked==true)
            {
                countChkd++;
            }

        }
        if (countChkd > 0)
        {
            ClearControls("enable");
        }
        else
        {
            ClearControls("chkDisable");
        }
    }
    protected void grdEmployeeWork_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[14].Visible = false;
        e.Row.Cells[15].Visible = false;
      
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////if (ddlBranch.SelectedIndex < 1)
        ////{
        ////    ddlFant.DataSource = null;
        ////    ddlFant.DataBind();
        ////}
        ////else
        ////{
        ////    int org_id = int.Parse(this.ddlOrganization.SelectedValue.ToString());
        ////    int unit_id = int.Parse(this.ddlBranch.SelectedValue.ToString());
        ////    List<ATTOrganizationSection> LSTOrgSec = BLLOrganizationSection.GetOrgSection(org_id, unit_id);
        ////    LSTOrgSec.Insert(0, new ATTOrganizationSection(0, 0, 0, "छान्नुहोस्", "", ""));
        ////    ddlFant.DataSource = LSTOrgSec;
        ////    ddlFant.DataValueField = "SectionID";
        ////    ddlFant.DataTextField = "SectionName";
        ////    ddlFant.DataBind();
        ////}
    }
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlUnit.SelectedIndex < 1)
        //{
        //    ddlSection.DataSource = null;
        //    ddlSection.DataBind();
        //}
        //else
        //{
        //    int org_id = int.Parse(this.ddlOrganization.SelectedValue.ToString());
        //    int unit_id = int.Parse(this.ddlUnit.SelectedValue.ToString());
        //    List<ATTOrganizationSection> LSTOrgSec = BLLOrganizationSection.GetOrgSection(org_id, unit_id);
        //    LSTOrgSec.Insert(0, new ATTOrganizationSection(0, 0, 0, "छान्नुहोस्", "", ""));
        //    ddlSection.DataSource = LSTOrgSec;
        //    ddlSection.DataValueField = "SectionID";
        //    ddlSection.DataTextField = "SectionName";
        //    ddlSection.DataBind();
        //    this.chkUnitHead.Enabled = true;
        //}

    }
    //protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    this.chkSectionHead.Enabled = true;
    //}
    protected void chkUnitHead_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    protected void grdEmpSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        EnableDisableAddPanel(true);
        chkUnitHead.Checked = false;

        grdEmployeeWork.SelectedIndex = -1;
        CollapsiblePnlSearch.Collapsed = false;
        CollapsiblePnlSearch.ClientState = "false";
    }
    protected void grdEmployeeWork_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        
    }
}