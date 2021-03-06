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

using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;


public partial class MODULES_OAS_Inventory_Forms_InvItemsTransfered : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (!IsPostBack)
        {
            #region session
            //Session["Cat"] = new List<ATTInvItemsCategory>();
            //Session["SubCat"] = new List<ATTInvItemSubCategory>();
            //Session["Items"] = new List<ATTInvOrgItemsPrice>();
            //Session["KNJItems"] = new List<ATTInvOrgItemsKNJ>();
            Session["ItemsTransfered"] = new List<ATTInvItemsTransfered>();
            //Session["Organization"] = new List<ATTOrganization>();
            Session["OrgID"] = user.OrgID;
            #endregion

            LoadCategory();
            LoadTransferOrg(int.Parse(Session["OrgID"].ToString()));
            LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
            LoadDesignations();
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel6.Visible = false;
        }
    }
    public void LoadCategory()
    {
        try
        {
            Session["Cat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["Cat"] != null)
            {
                ddlCategory.DataSource = Session["Cat"];
                ddlCategory.DataTextField = "itemsCategoryName";
                ddlCategory.DataValueField = "itemsCategoryID";
                ddlCategory.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlCategory.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    private void LoadDesignations()
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
    private void LoadOrganizationWithChilds(int p)
    {
        try
        {
            List<ATTOrganization> OrganizationList = GetOrganizationWithChild(p);
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));
            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();
            this.ddlTransfdOrg.DataSource = OrganizationList;
            this.ddlTransfdOrg.DataTextField = "ORGNAME";
            this.ddlTransfdOrg.DataValueField = "ORGID";
            this.ddlTransfdOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    void LoadTransferOrg(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = GetOrganizationWithChild(orgID);
        Session["Organization"] = LSTOrgSubType;
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        LSTOrgSubType.RemoveAll(delegate(ATTOrganization obj)
                                    {
                                        return obj.OrgID == user.OrgID;
                                    }
                               );
        LSTOrgSubType.Insert(0, new ATTOrganization(0, "छान्नुहोस्"));
        ddlTransfdOrg.DataTextField = "OrgName";
        ddlTransfdOrg.DataValueField = "OrgID";
        ddlTransfdOrg.DataSource = LSTOrgSubType;
        ddlTransfdOrg.DataBind();

    }
    void LoadOrganizationUnits(int intOrgID)
    {
        try
        {
            List<ATTOrganizationUnit> lstOrganizationUnits = BLLOrganizationUnit.GetOrganizationUnits(intOrgID, null);
            Session["OrganizationUnits"] = lstOrganizationUnits;

            //this.ddlTransOrgUnit.Items.Insert(0, new ListItem("छान्नुहोस्", "0"));
            lstOrganizationUnits.Insert(0, new ATTOrganizationUnit(0, 0, "छान्नुहोस्"));
            this.ddlTransOrgUnit.DataSource = lstOrganizationUnits;
            this.ddlTransOrgUnit.DataTextField = "UNITNAME";
            this.ddlTransOrgUnit.DataValueField = "UNITID";
            this.ddlTransOrgUnit.DataBind();
           
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    private static List<ATTOrganization> GetOrganizationWithChild(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = BLLOrganization.GetOrgWithChilds(orgID);
        return LSTOrgSubType;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;

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
                Session["EmployeeSearch"] = lst;

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearSearchControls();

    }
    private void ClearSearchControls()
    {
        txtSymbolNo.Text = "";
        txtFName.Text = "";
        txtMName.Text = "";
        txtSurName.Text = "";
        txtDOB.Text = "";
        ddlGender.SelectedIndex = -1;
        ddlMarStatus.SelectedIndex = -1;
        ddlOrganization.SelectedIndex = -1;
        ddlDesignation.SelectedIndex = -1;
        //this.CollapsiblePanelExtender1.ClientState = "true";
        //this.CollapsiblePanelExtender1.Collapsed = true;
        this.lblSearch.Text = "";
        grdEmployee.DataSource = "";
        grdEmployee.DataBind();

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                grdKNJItems.DataSource = null;
                grdKNJItems.DataBind();
                Panel1.Visible = false;

                ddlSubCategory.Items.Clear();
                ddlItemsKNJ.Items.Clear();
                List<ATTInvItemSubCategory> lst = GetItemSubCategory(int.Parse(ddlCategory.SelectedValue.ToString()));
                Session["SubCat"] = lst;

                ddlSubCategory.DataSource = lst;
                ddlSubCategory.DataTextField = "ItemsSubCategoryName";
                ddlSubCategory.DataValueField = "ItemsSubCategoryID";
                ddlSubCategory.DataBind();

                ddlSubCategory.Enabled = true;



            }
            else
            {

                ddlSubCategory.DataSource = "";
                ddlSubCategory.DataBind();
                ddlItemsKNJ.DataSource = "";
                ddlItemsKNJ.DataBind();

            }

            txtQuantiy.Text = "";
            ddlSubCategory.SelectedIndex = -1;
            ddlItemsKNJ.SelectedIndex = -1;
           
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    private List<ATTInvItemSubCategory> GetItemSubCategory(int CatId)
    {
        return BLLInvItemsSubCategory.GetItemSubCategory(CatId, "Y", true);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlSubCategory.SelectedIndex > 0)
            {

                LoadDDLItems();
            }
            else
            {
                ddlItemsKNJ.SelectedIndex = -1;
                ddlItemsKNJ.DataSource = "";
                ddlItemsKNJ.DataBind();
               
            }

            txtQuantiy.Text = "";
            grdKNJItems.DataSource = null;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    private void LoadDDLItems()
    {
        ATTInvOrgItemsPrice obj = new ATTInvOrgItemsPrice();
        obj.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        obj.ItemsCategoryID = int.Parse(ddlCategory.SelectedValue);
        obj.ItemsSubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
        obj.Quantity = 0;

        Session["Items"] = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(obj);

        ddlItemsKNJ.DataSource = (List<ATTInvOrgItemsPrice>)Session["Items"];
        ddlItemsKNJ.DataTextField = "ItemNameWithQty";
        ddlItemsKNJ.DataValueField = "ItemsID";
        ddlItemsKNJ.DataBind();

        ListItem a = new ListItem();
        a.Selected = true;
        a.Text = "----छान्नुहोस----";
        a.Value = "0";
        ddlItemsKNJ.Items.Insert(0, a);


        ddlItemsKNJ.Enabled = true;
    }
    protected void ddlItemsKNJ_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlItemsKNJ.SelectedIndex > 0)
            {
                int itemType = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeID;
                if (itemType == 2)
                {

                    ATTInvOrgItemsKNJ obj = new ATTInvOrgItemsKNJ();
                    obj.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
                    obj.ItemsCategoryID = int.Parse(ddlCategory.SelectedValue);
                    obj.ItemsSubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
                    obj.ItemsID = int.Parse(ddlItemsKNJ.SelectedValue);
                   
                    List<ATTInvOrgItemsKNJ> lstKNJItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(obj);
                    this.grdKNJItems.DataSource = lstKNJItems;
                    this.grdKNJItems.DataBind();
                    Session["KNJItems"] = lstKNJItems;

                    txtQuantiy.ReadOnly = true;
                    Panel1.Visible = true;
                }
                else
                {
                    txtQuantiy.ReadOnly = false;
                }
            }




        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        txtQuantiy.Text = "";
    }
    protected void txtQuantiy_TextChanged(object sender, EventArgs e)
    {
        List<ATTInvOrgItemsPrice> lst = (List<ATTInvOrgItemsPrice>)Session["Items"];
        int? qty = lst[this.ddlItemsKNJ.SelectedIndex - 1].Quantity;

        if (txtQuantiy.Text.Trim() != "")
        {
            if (int.Parse(this.txtQuantiy.Text) > qty)
            {
                this.lblStatusMessage.Text = "Quantity more than availabe can not be added";
                this.programmaticModalPopup.Show();
            }
            else
            {
                //this.txtQuantiy.ReadOnly = true;

            }
        }


    }
    protected void grdKNJItems_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (grdKNJItems.Rows.Count >0)
        //{ 
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
        //e.Row.Cells[4].Visible = false;
        //e.Row.Cells[7].Visible = false;
        //}
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "क्रिपया सामुह मा भाको समान छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (ddlSubCategory.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "क्रिपया  उप-सामुह मा भाको समान छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (ddlItemsKNJ.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्न लागेको समान छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (Session["ItemsTransfered"] == null)
            {
                Session["ItemsTransfered"] = new List<ATTInvItemsTransfered>();
            }

            List<ATTInvItemsTransfered> LSTItemsTrans = (List<ATTInvItemsTransfered>)Session["ItemsTransfered"];

            Panel1.Visible = false;

            int count = 0;
            int itemType = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeID;
            if (itemType == 2)
            {
                #region itemtype 2
                if (this.grdItemsTrans.SelectedIndex == -1)
                {
                    //if (ValidationControl() == true)
                    //{
                    foreach (GridViewRow rw in grdKNJItems.Rows)
                    {
                        if (((CheckBox)rw.FindControl("chkItems")).Checked == true)
                        {
                            count++;
                            ATTInvItemsTransfered objItemsTrans = new ATTInvItemsTransfered();
                            ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                            objItemsTrans.OrgID = user.OrgID;
                            objItemsTrans.ItemsCategoryID = int.Parse(this.ddlCategory.SelectedValue);
                            objItemsTrans.ItemsCategoryName = ((List<ATTInvItemsCategory>)Session["Cat"])[ddlCategory.SelectedIndex - 1].ItemsCategoryName;
                            objItemsTrans.ItemsSubCategoryID = int.Parse(this.ddlSubCategory.SelectedValue);
                            objItemsTrans.ItemsSubCategoryName = ((List<ATTInvItemSubCategory>)Session["SubCat"])[ddlSubCategory.SelectedIndex].ItemsSubCategoryName;
                            objItemsTrans.ItemsID = int.Parse(this.ddlItemsKNJ.SelectedValue);
                            objItemsTrans.ItemsName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemName;
                            objItemsTrans.ItemsTypeID = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeID;
                            objItemsTrans.ItemsTypeName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeName;
                            objItemsTrans.Quantity = count;
                            objItemsTrans.SeqNo = int.Parse(rw.Cells[9].Text);

                            objItemsTrans.Action = "A";
                            LSTItemsTrans.Add(objItemsTrans);
                        }
                    }
                    //}
                }
                else if (this.grdItemsTrans.SelectedIndex > -1)
                {

                    #region edit



                    int orgid = int.Parse(grdItemsTrans.SelectedRow.Cells[0].Text);
                    int catid = int.Parse(grdItemsTrans.SelectedRow.Cells[1].Text);
                    int subcatid = int.Parse(grdItemsTrans.SelectedRow.Cells[3].Text);
                    int itemid = int.Parse(grdItemsTrans.SelectedRow.Cells[5].Text);
                    int itemtypeid = int.Parse(grdItemsTrans.SelectedRow.Cells[7].Text);


                    /////////

                    int i = LSTItemsTrans.RemoveAll(delegate(ATTInvItemsTransfered objkvn)
                                         {
                                             return (objkvn.OrgID == orgid &&
                                                 objkvn.ItemsCategoryID == catid &&
                                                 objkvn.ItemsSubCategoryID == subcatid &&
                                                 objkvn.ItemsID == itemid &&
                                                 objkvn.ItemsTypeID == itemtypeid

                                                     );
                                         }
                         );



                    ////////////////

                    //if (ValidationControl() == true)
                    //{
                    foreach (GridViewRow rw in grdKNJItems.Rows)
                    {
                        if (((CheckBox)rw.FindControl("chkItems")).Checked == true)
                        {
                            count++;
                            ATTInvItemsTransfered objItemsTrans = new ATTInvItemsTransfered();
                            ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                            objItemsTrans.OrgID = user.OrgID;
                            objItemsTrans.ItemsCategoryID = int.Parse(this.ddlCategory.SelectedValue);
                            objItemsTrans.ItemsCategoryName = ((List<ATTInvItemsCategory>)Session["Cat"])[ddlCategory.SelectedIndex - 1].ItemsCategoryName;
                            objItemsTrans.ItemsSubCategoryID = int.Parse(this.ddlSubCategory.SelectedValue);
                            objItemsTrans.ItemsSubCategoryName = ((List<ATTInvItemSubCategory>)Session["SubCat"])[ddlSubCategory.SelectedIndex].ItemsSubCategoryName;
                            objItemsTrans.ItemsID = int.Parse(this.ddlItemsKNJ.SelectedValue);
                            objItemsTrans.ItemsName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemName;
                            objItemsTrans.ItemsTypeID = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeID;
                            objItemsTrans.ItemsTypeName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeName;
                            objItemsTrans.Quantity = count;
                            objItemsTrans.SeqNo = int.Parse(rw.Cells[9].Text);

                            objItemsTrans.Action = "A";
                            LSTItemsTrans.Add(objItemsTrans);
                        }
                    }
                    //}


                    #endregion
                }

                Clearcontrols(false);
                #endregion
            }
            else
            {

                #region  itemtype1
                if (this.grdItemsTrans.SelectedIndex == -1)
                {

                    if (this.txtQuantiy.Text == "")
                    {
                        lblStatusMessage.Text = "quantity missing";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                    else if (int.Parse(txtQuantiy.Text.Trim()) > ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlSubCategory.SelectedIndex - 1].Quantity)
                    {
                        lblStatusMessage.Text = "quantity transferred is greater than available";
                        this.programmaticModalPopup.Show();
                        return;
                    }

                    ATTInvItemsTransfered objItemsTrans = new ATTInvItemsTransfered();
                    ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                    objItemsTrans.OrgID = user.OrgID;
                    objItemsTrans.ItemsCategoryID = int.Parse(this.ddlCategory.SelectedValue);
                    objItemsTrans.ItemsCategoryName = ((List<ATTInvItemsCategory>)Session["Cat"])[ddlCategory.SelectedIndex - 1].ItemsCategoryName;
                    objItemsTrans.ItemsSubCategoryID = int.Parse(this.ddlSubCategory.SelectedValue);
                    objItemsTrans.ItemsSubCategoryName = ((List<ATTInvItemSubCategory>)Session["SubCat"])[ddlSubCategory.SelectedIndex].ItemsSubCategoryName;
                    objItemsTrans.ItemsID = int.Parse(this.ddlItemsKNJ.SelectedValue);
                    objItemsTrans.ItemsName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemName;
                    objItemsTrans.ItemsTypeID = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeID;
                    objItemsTrans.ItemsTypeName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemsTypeName;

                    objItemsTrans.Quantity = int.Parse(this.txtQuantiy.Text.Trim());


                    objItemsTrans.Action = "A";
                    objItemsTrans.EntryBy = user.UserName;
                    LSTItemsTrans.Add(objItemsTrans);

                    Session["ItemsTransfered"] = LSTItemsTrans;

                }
                else if (this.grdItemsTrans.SelectedIndex > -1)
                {
                    ATTInvItemsTransfered objItemsTrans = LSTItemsTrans[this.grdItemsTrans.SelectedIndex];
                    ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                    objItemsTrans.ItemsCategoryID = int.Parse(this.ddlCategory.SelectedValue);
                    objItemsTrans.ItemsCategoryName = ((List<ATTInvItemsCategory>)Session["Cat"])[ddlCategory.SelectedIndex - 1].ItemsCategoryName;
                    objItemsTrans.ItemsSubCategoryID = int.Parse(this.ddlSubCategory.SelectedValue);
                    objItemsTrans.ItemsSubCategoryName = ((List<ATTInvItemSubCategory>)Session["SubCat"])[ddlSubCategory.SelectedIndex].ItemsSubCategoryName;
                    objItemsTrans.ItemsID = int.Parse(this.ddlItemsKNJ.SelectedValue);
                    objItemsTrans.ItemsName = ((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].ItemName;
                    if (this.txtQuantiy.Text != "")
                    {
                        objItemsTrans.Quantity = int.Parse(this.txtQuantiy.Text.Trim());
                    }

                    objItemsTrans.Action = (((List<ATTInvOrgItemsPrice>)Session["Items"])[ddlItemsKNJ.SelectedIndex - 1].Action == "A") ? "A" : "E";
                    Session["ItemsTransfered"] = LSTItemsTrans;
                }
                Clearcontrols(false);
                #endregion

            }

            List<ATTInvItemsTransfered> lstNew = new List<ATTInvItemsTransfered>();

            foreach (ATTInvItemsTransfered var in (List<ATTInvItemsTransfered>)Session["ItemsTransfered"])
            {

                if (var.ItemsTypeID == 1)
                {
                    lstNew.Add(var);
                }
                else if (var.ItemsTypeID == 2)
                {
                    int index = -1;
                    index = lstNew.FindIndex(
                                    delegate(ATTInvItemsTransfered obj)
                                    {
                                        return (var.OrgID == obj.OrgID &&
                                            var.ItemsCategoryID == obj.ItemsCategoryID &&
                                            var.ItemsSubCategoryID == obj.ItemsSubCategoryID &&
                                            var.ItemsID == obj.ItemsID &&
                                            var.ItemsTypeID == obj.ItemsTypeID
                                            );
                                    }
                                );
                    if (index < 0)
                    {

                        lstNew.Add(var);
                    }
                    else
                    {

                        if (lstNew[index].Quantity < var.Quantity)
                        {
                            lstNew[index].Quantity = var.Quantity;
                        }
                    }
                }
            }


            foreach (ATTInvItemsTransfered var in lstNew)
            {
                List<ATTInvItemsTransfered> objlst = LSTItemsTrans.FindAll(
                                                delegate(ATTInvItemsTransfered obj) 
                                                {
                                                    return (var.OrgID == obj.OrgID &&
                                                var.ItemsCategoryID == obj.ItemsCategoryID &&
                                                var.ItemsSubCategoryID == obj.ItemsSubCategoryID &&
                                                var.ItemsID == obj.ItemsID &&
                                                var.ItemsTypeID == obj.ItemsTypeID
                                                );
                                                }
                    );

                foreach (ATTInvItemsTransfered var1 in objlst)
                {
                    var1.Quantity = var.Quantity;
                }
                
            }

            Session["GrdData"] = lstNew;

            Panel3.Visible = lstNew.Count > 0 ? true : false;

            grdItemsTrans.DataSource = lstNew;
            grdItemsTrans.DataBind();
            grdItemsTrans.SelectedIndex = -1;
           

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error:" + ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }
    protected void grdItemsTrans_SelectedIndexChanged(object sender, EventArgs e)
    {
         List<ATTInvItemsTransfered> lstItemsTrans = ((List<ATTInvItemsTransfered>)Session["GrdData"]);
        int itemType = lstItemsTrans[grdItemsTrans.SelectedIndex].ItemsTypeID;

        this.ddlCategory.SelectedValue = lstItemsTrans[grdItemsTrans.SelectedIndex].ItemsCategoryID.ToString();


        List<ATTInvItemSubCategory> lst = GetItemSubCategory(int.Parse(ddlCategory.SelectedValue.ToString()));
        Session["SubCat"] = lst;

        ddlSubCategory.DataSource = lst;
        ddlSubCategory.DataTextField = "ItemsSubCategoryName";
        ddlSubCategory.DataValueField = "ItemsSubCategoryID";
        ddlSubCategory.DataBind();

        this.ddlSubCategory.SelectedValue = lstItemsTrans[grdItemsTrans.SelectedIndex].ItemsSubCategoryID.ToString();


        LoadDDLItems();
        this.ddlItemsKNJ.SelectedValue = grdItemsTrans.SelectedRow.Cells[5].Text;

        if (itemType == 1)
        {
            this.txtQuantiy.Text = lstItemsTrans[grdItemsTrans.SelectedIndex].Quantity.ToString();
            txtQuantiy.ReadOnly = false;

        }
        else if (itemType == 2)
        {
            Panel1.Visible = true;

            this.txtQuantiy.Text = "";
            txtQuantiy.ReadOnly = true;


            ATTInvOrgItemsKNJ obj = new ATTInvOrgItemsKNJ();
            obj.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            obj.ItemsCategoryID = int.Parse(ddlCategory.SelectedValue);
            obj.ItemsSubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
            obj.ItemsID = int.Parse(grdItemsTrans.SelectedRow.Cells[5].Text);
            //obj.ItemsTypeID = 2;

            List<ATTInvOrgItemsKNJ> lstKNJItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(obj);
            this.grdKNJItems.DataSource = lstKNJItems;
            this.grdKNJItems.DataBind();
            Session["KNJItems"] = lstKNJItems;

            txtQuantiy.ReadOnly = true;



            //getmatching items checked code goes here

            foreach (GridViewRow var in grdKNJItems.Rows)
            {
                int orgid = int.Parse(var.Cells[1].Text);
                int catid = int.Parse(var.Cells[2].Text);
                int subcatid = int.Parse(var.Cells[3].Text);
                int itemid = int.Parse(var.Cells[4].Text);
                int itemtypeid = int.Parse(var.Cells[5].Text);
                int seqno = int.Parse(var.Cells[9].Text);


                List<ATTInvItemsTransfered> lstData = (List<ATTInvItemsTransfered>)Session["ItemsTransfered"];
                bool exists = lstData.Exists(delegate(ATTInvItemsTransfered objkvn)
                                     {
                                         return (objkvn.OrgID == orgid &&
                                             objkvn.ItemsCategoryID == catid &&
                                             objkvn.ItemsSubCategoryID == subcatid &&
                                             objkvn.ItemsID == itemid &&
                                             objkvn.ItemsTypeID == itemtypeid &&
                                             objkvn.SeqNo == seqno
                                                 );
                                     }
                     );


                ((CheckBox)var.FindControl("chkItems")).Checked = exists;

                         
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!ValidationControl())
            return;
        string oldDate = this.txtTransferedDate.Text.Trim();
        string newDate = this.txtDecisionDate.Text.Trim();

        bool Valid = CheckDateIsValid(oldDate, newDate);
        if (Valid)
        {
            List<ATTInvItemsTransfered> LSTItemsTrans = (List<ATTInvItemsTransfered>)Session["ItemsTransfered"];

            foreach (ATTInvItemsTransfered var in LSTItemsTrans)
            {
                var.DecisionDate = txtDecisionDate.Text.Trim();
                var.TransDate = txtTransferedDate.Text.Trim();
                var.TransORG = int.Parse(ddlTransfdOrg.SelectedValue);
                var.TransOrgUnit = int.Parse(ddlTransOrgUnit.SelectedValue);
                var.TransVia = int.Parse(this.txtMediatorEmp.Attributes["EmpID"].ToString());
                var.TransTo = int.Parse(this.txtTransferedEmp.Attributes["EmpID"].ToString());
                var.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            }

            if (BLLInvItemsTransfered.SaveItemsTransfer(LSTItemsTrans, "transfer"))
            {
                this.lblStatusMessage.Text = "Transfered Items Saved";
                this.programmaticModalPopup.Show();
            }
            Clearcontrols(true);
           
        }
        else
        {
            this.lblStatusMessage.Text = "Decision Date should be less or equal to Transfered Date";
            this.programmaticModalPopup.Show();
        }
        grdItemsTrans.DataSource = "";
        grdItemsTrans.DataBind();
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        Clearcontrols(true);
    }
    private bool ValidationControl()
    {
        
        //    if (ddlCategory.SelectedIndex == 0)
        //    {
        //        this.lblStatusMessage.Text = "क्रिपया सामुह मा भाको समान छान्नुहोस्";
        //        this.programmaticModalPopup.Show();
        //        return false;
        //    }
        //    if (ddlSubCategory.SelectedIndex == 0)
        //    {
        //        this.lblStatusMessage.Text = "क्रिपया  उप-सामुह मा भाको समान छान्नुहोस्";
        //        this.programmaticModalPopup.Show();
        //        return false;
        //    }
        //    if (ddlItemsKNJ.SelectedIndex == 0)
        //    {
        //        this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्न लागेको समान छान्नुहोस्";
        //        this.programmaticModalPopup.Show();
        //        return false;
        //    }
        
        
        if (txtTransferedDate.Text == "")
        {
            this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्ने मिति हाल्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;
        }
        if (txtDecisionDate.Text == "")
        {
            this.lblStatusMessage.Text = "क्रिपया निर्णय गर्ने मिति हाल्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;
        }
        if (ddlTransfdOrg.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्ने कार्यलय छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;
        }
        if (ddlTransOrgUnit.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्ने शाखा छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;
        }
        if (txtTransferedEmp.Text == "")
        {
            this.lblStatusMessage.Text = "क्रिपया हस्तान्तरण गर्ने ब्यक्ति खोज्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;
        }
        if (txtMediatorEmp.Text == "")
        {
            this.lblStatusMessage.Text = "क्रिपया हस्ते गर्ने ब्यक्ति खोज्नुहोस्";
            this.programmaticModalPopup.Show();
            return false;

        }

        return true;
    }
    private void Clearcontrols(bool save)
    {

        txtQuantiy.Text = "";
        txtQuantiy.ReadOnly = false;
        ddlCategory.SelectedIndex = -1;

        ddlSubCategory.DataSource = "";
        ddlSubCategory.DataBind();
        ddlSubCategory.SelectedIndex = -1;

        ddlItemsKNJ.DataSource = "";
        ddlItemsKNJ.DataBind();
        ddlItemsKNJ.SelectedIndex = -1;

        Session["Items"] = "";
        Session["KNJItems"] = "";

        grdKNJItems.DataSource = null;
        grdKNJItems.DataBind();
        grdEmployee.DataSource = null;
        grdEmployee.DataBind();
        txtTransferedDate.Text = "";
           
        if (save)
        {
            txtTransferedDate.Text = "";
            txtDecisionDate.Text = "";
            ddlTransfdOrg.SelectedIndex = -1;
            ddlTransOrgUnit.SelectedIndex = -1;
            txtTransferedEmp.Text = "";
            txtMediatorEmp.Text = "";
            Session["ItemsTransferred"] = "";
            grdItemsTrans.DataSource = null;
            grdItemsTrans.DataBind();
            grdItemsTrans.SelectedIndex = -1;
            Panel3.Visible = false;
        }
    }
    protected void grdItemsTrans_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;

    }
    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {

    }
    protected void btnMediatorSearch_Click(object sender, EventArgs e)
    {

    }
    protected void ddlTransfdOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOrganizationUnits(int.Parse(ddlTransfdOrg.SelectedValue));
        Panel6.Visible = false;
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
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lstEmployee = (List<ATTEmployeeSearch>)Session["EmployeeSearch"];


        if (HiddenField1.Value == "emp")
        {
            this.txtTransferedEmp.Text = lstEmployee[grdEmployee.SelectedIndex].RDFullName;
            txtTransferedEmp.Attributes.Add("EmpID", this.grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            ModalPopupEmployee.Hide();
        }
        else if (HiddenField1.Value == "haste")
        {
            this.txtMediatorEmp.Text = lstEmployee[grdEmployee.SelectedIndex].RDFullName;
            txtMediatorEmp.Attributes.Add("EmpID", this.grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text);
            ModalPopupHaste.Hide();

        }

        //CollapsiblePanelExtender1.ClientState = "true";
        //CollapsiblePanelExtender1.Collapsed = true;


        grdEmployee.DataSource = "";
        grdEmployee.DataBind();



        this.lblSearch.Text = "";
        //String callbackscript = "document.getElementByID('<%=txtTransferedEmp.ClientID%>').value='bikash';";
        //ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, callbackscript, true);




        ClearSearchControls();


    }
    protected void grdOrgUnitEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTEmployeeWorkDivision> lst = (List<ATTEmployeeWorkDivision>)Session["EmployeeSearch"];
        this.txtTransferedEmp.Text = lst[grdOrgUnitEmp.SelectedIndex].FullName;
        txtTransferedEmp.Attributes.Add("EmpID", this.grdOrgUnitEmp.Rows[grdOrgUnitEmp.SelectedIndex].Cells[0].Text);
        Panel6.Visible = false;
    }
    protected void btnOrgUnitEmpSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTransfdOrg.SelectedIndex <= 0)
            {
                this.lblStatusMessage.Text = "Please select transfered Org Name ";
                this.programmaticModalPopup.Show();
            }
            else
            {
                Panel6.Visible = true;
                List<ATTEmployeeWorkDivision> lst;

                Session["EmpSearchResult"] = BLLEmployeeWorkDivision.SearchEmployee(GetFilterOU());
                lst = (List<ATTEmployeeWorkDivision>)Session["EmpSearchResult"];
                this.lblEmpSearch.Text = lst.Count.ToString() + " records found.";
                this.grdOrgUnitEmp.DataSource = lst;
                this.grdOrgUnitEmp.DataBind();
                Session["EmployeeSearch"] = lst;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();

        }
    }
    private ATTEmployeeWorkDivision GetFilterOU()
    {
        ATTEmployeeWorkDivision EmployeeSearch = new ATTEmployeeWorkDivision();

        if (this.ddlTransfdOrg.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlTransfdOrg.SelectedValue);
        if (this.ddlTransOrgUnit.SelectedIndex > 0) EmployeeSearch.OrgUnitID = int.Parse(this.ddlTransOrgUnit.SelectedValue);
        return EmployeeSearch;
    }
    protected void ddlTransOrgUnit_SelectedIndexChanged(object sender, EventArgs e)
    {

        Panel6.Visible = false;

    }
}

