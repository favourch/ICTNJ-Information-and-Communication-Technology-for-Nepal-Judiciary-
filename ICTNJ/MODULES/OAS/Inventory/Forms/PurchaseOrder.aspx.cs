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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Inventory_Forms_PurchaseOrder : System.Web.UI.Page
{
    public int orgID;
    public string entryBy;
    public int loginID;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        orgID = user.OrgID;
        entryBy = user.UserName;
        loginID = int.Parse(user.PID.ToString());

        if (!IsPostBack)
        {
            LoadControls();
        }

        txtUnitPrice_TextChanged(null, null);
    }

    public void LoadControls()
    {
        try
        {
            Session["PoDetail"] = null;
            Session["PoItems"] = null;
            Session["CurrentDate"] = null;

            string dateString = BLLDate.GetDateString(0, 0, "_N");
            if (dateString != null)
            {
                int len = dateString.ToString().Length;
                Session["CurrentDate"] = dateString.ToString().Substring(0, len - 5);
            }


            LoadCategory();

            LoadSupplier();
           
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public void LoadSupplier()
    {
        try
        {
            Session["PoSupplier"] = BLLInvSupplier.GetSupplierList(null);

            if (Session["PoSupplier"] != null)
            {

                ddlSupplier_rqd.DataSource = Session["PoSupplier"];
                ddlSupplier_rqd.DataTextField = "supplierName";
                ddlSupplier_rqd.DataValueField = "supplierID";
                ddlSupplier_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlSupplier_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadOrganizationUnit()
    {
        try
        {
            //Session["PoOrgUnits"] = BLLOrganizationUnit.GetOrganizationUnits("ST",orgID);

            //if (Session["PoOrgUnits"] != null)
            //{
            //    ddlUnit_rqd.DataSource = Session["PoOrgUnits"];
            //    ddlUnit_rqd.DataTextField = "UnitName";
            //    ddlUnit_rqd.DataValueField = "UnitID";
            //    ddlUnit_rqd.DataBind();

            //    ListItem a = new ListItem();
            //    a.Selected = true;
            //    a.Text = "----छान्नुहोस----";
            //    a.Value = "0";
            //    ddlUnit_rqd.Items.Insert(0, a);
            //}

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadCategory()
    {
        try
        {
            Session["PoCat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["PoCat"] != null)
            {
                ddlCategory_cat.DataSource = Session["PoCat"];
                ddlCategory_cat.DataTextField = "itemsCategoryName";
                ddlCategory_cat.DataValueField = "itemsCategoryID";
                ddlCategory_cat.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlCategory_cat.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {
            
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory_cat.SelectedIndex > 0)
            {
                ddlSubCategory_cat.Items.Clear();
                ddlSubCategory_cat.DataSource = BLLInvItemsSubCategory.GetItemSubCategory(int.Parse(ddlCategory_cat.SelectedValue.ToString()), "Y", true);
                ddlSubCategory_cat.DataTextField = "ItemsSubCategoryName";
                ddlSubCategory_cat.DataValueField = "ItemsSubCategoryID";
                ddlSubCategory_cat.DataBind();

                ddlSubCategory_cat.Enabled = true;
                 
            }
            else
            {
                
                ddlSubCategory_cat.Enabled = false;
               
                
            }

            txtQty_cat.Text = "";
            ddlSubCategory_cat.SelectedIndex = -1;
            ddlItems_cat.SelectedIndex = -1;
            ddlItems_cat.Enabled = false;

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubCategory_cat.SelectedIndex > 0)
            {
                Session["PoItems"]  = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(9, int.Parse(ddlCategory_cat.SelectedValue), int.Parse(ddlSubCategory_cat.SelectedValue));

                ddlItems_cat.DataSource = (List<ATTInvOrgItemsPrice>)Session["PoItems"];
                ddlItems_cat.DataTextField = "ItemName";
                ddlItems_cat.DataValueField = "ItemsID";
                ddlItems_cat.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlItems_cat.Items.Insert(0, a);


                ddlItems_cat.Enabled = true;
            }
            else
            {
                ddlItems_cat.SelectedIndex = -1;
                ddlItems_cat.Enabled = false;
            }

            txtQty_cat.Text = "";
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtQty_cat.Text = "";
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
  
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CurrentDate"] != null && txtODate_RDT.Text != "")
            {
                if (CompareDate(Session["CurrentDate"].ToString(), txtODate_RDT.Text))
                {
                    bool flag = true;

                    ATTInvPurchaseOrder objPo = new ATTInvPurchaseOrder();

                    objPo.OrgID = orgID;
                    //objPo.UnitID = int.Parse(ddlUnit_rqd.SelectedValue);
                    objPo.OrderNo = txtOrderNo_rqd.Text;
                    objPo.OrderDate = txtODate_RDT.Text;
                    objPo.SupplierID = int.Parse(ddlSupplier_rqd.SelectedValue);
                    objPo.EntryBy = entryBy;
                    objPo.Action = "A";

                    if (Session["PoDetail"] != null)
                    {
                        if (((List<ATTInvPurchaseOrderDetail>)Session["PoDetail"]).Count > 0)
                            objPo.lstPurchaseOrderDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoDetail"];
                        else
                            flag = false;
                    }
                    else
                    {
                        flag = false;

                    }

                    if (flag)
                    {

                        int saveConfirm = BLLInvPurchaseOrder.SavePurchaseOrder(objPo);

                        if (saveConfirm == 0)
                        {

                            ClearControls();

                            this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                            this.lblStatusMessage.Text = "सफलतापूर्वक सेभ भयो!!!";
                            this.programmaticModalPopup.Show();
                        }
                        else if (saveConfirm == -1)
                        {
                            this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                            this.lblStatusMessage.Text = "अर्डर नंम्बर पहिला नै प्रयोग भइसक्यो!!!";
                            this.programmaticModalPopup.Show();
                        }
                        else
                        {
                            this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                            this.lblStatusMessage.Text = "सेभ गर्दा वाधा उत्पन्न भयो!!!";
                            this.programmaticModalPopup.Show();
                        }
                    }
                    else
                    {

                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = "कृपया खरिद गर्ने आइटम छान्नुहोस् ।!!!";
                        this.programmaticModalPopup.Show();
                    }
                }
                else
                {   this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                    this.lblStatusMessage.Text = "अर्डर मिति नागीसक्यो !!! त्यसैले अर्को अर्डर मिति राख्नुहोस्";
                    this.programmaticModalPopup.Show();
                }
            }
            else
            {

                this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                this.lblStatusMessage.Text = "कृपया मिति राख्नुहोस् ।!!!";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            double price = 0.0;

            bool flag = false;

            List<ATTInvOrgItemsPrice> lstItems = new List<ATTInvOrgItemsPrice>();

            lstItems = (List<ATTInvOrgItemsPrice>)Session["PoItems"];

            if(ddlItems_cat.SelectedIndex > 0 && lstItems.Count > 0)
                price = lstItems[ddlItems_cat.SelectedIndex - 1].UnitPrice;

            List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

            if (Session["PoDetail"] != null)
            {
                lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoDetail"];

                if (grdPurchaseOrder.SelectedIndex > -1)
                {
                    GridViewRow gvRow = grdPurchaseOrder.SelectedRow;

                   // double i = double.Parse(gvRow.Cells[4].Text);
                    ATTInvPurchaseOrderDetail objPoD = lstPoDetail.Find(delegate(ATTInvPurchaseOrderDetail objPd)
                                                                                 {
                                                                                     return ((objPd.ItemsCategoryID == int.Parse(gvRow.Cells[1].Text)) &&
                                                                                             (objPd.ItemsSubCategoryID == int.Parse(gvRow.Cells[2].Text)) &&
                                                                                             (objPd.ItemsID == int.Parse(gvRow.Cells[3].Text)));
                                                                                 }

                                                                       );

                    if (objPoD != null)
                    {
                        objPoD.TotalQty = int.Parse(txtQty_cat.Text);
                        objPoD.ManuCompany = txtManuCom.Text;
                        objPoD.ManuDate = txtManuDate.Text;
                        //objPoD.Specification = txtManuSpec.Text;
                        objPoD.Brand = txtBrand.Text;

                        ClearAddControls();

                        ddlCategory_cat.SelectedIndex = -1;
                        ddlSubCategory_cat.SelectedIndex = -1;

                        grdPurchaseOrder.SelectedIndex = -1;
                        grdPurchaseOrder.DataSource = lstPoDetail;
                        grdPurchaseOrder.DataBind();

                        Session["PoDetail"] = lstPoDetail;

                        flag = true;
                    }
                }
                else
                {
                    flag = lstPoDetail.Exists(delegate(ATTInvPurchaseOrderDetail objPd)
                                                      {
                                                          return ((objPd.ItemsCategoryID == int.Parse(ddlCategory_cat.SelectedValue)) &&
                                                                  (objPd.ItemsSubCategoryID == int.Parse(ddlSubCategory_cat.SelectedValue)) &&
                                                                  (objPd.ItemsID == int.Parse(ddlItems_cat.SelectedValue)));
                                                      }

                                              );

                    if (flag)
                    {
                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = " यो सामान पहिले नै खरिदको निमित्त राख्नु भइसक्यो । कृपया अर्को सामान छान्नुहोस्।";
                        this.programmaticModalPopup.Show();
                    }
                }
                    
            }

            if (!flag)
            {

                lstPoDetail.Add(new ATTInvPurchaseOrderDetail(int.Parse(ddlCategory_cat.SelectedValue), ddlCategory_cat.SelectedItem.ToString(), int.Parse(ddlSubCategory_cat.SelectedValue), ddlSubCategory_cat.SelectedItem.ToString(),
                                                              int.Parse(ddlItems_cat.SelectedValue), ddlItems_cat.SelectedItem.ToString(), price, int.Parse(txtQty_cat.Text),txtManuCom.Text,
                                                              txtManuDate.Text,txtBrand.Text, "A"));

                ClearAddControls();
               
                grdPurchaseOrder.DataSource = lstPoDetail;
                grdPurchaseOrder.DataBind();

                Session["PoDetail"] = lstPoDetail;
            }

            btnSubmit.Enabled = true;
            
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    
    protected void grdPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        GridViewRow row = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((TextBox)e.Row.FindControl("txtUnitPrice")).Attributes.Add("onkeypress", "return DecimalOnly(event,this)");
          
            TextBox txtPrice = (TextBox)row.FindControl("txtUnitPrice");
            txtPrice.Text = row.Cells[4].Text;

            double totalPrice = double.Parse(row.Cells[4].Text) * double.Parse(row.Cells[9].Text);
            row.Cells[10].Text = totalPrice.ToString();
        }

    }
    protected void grdPurchaseOrder_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[3].Visible = false;
        row.Cells[4].Visible = false;
    }
    protected void grdPurchaseOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

        if (Session["PoDetail"] != null)
        {
            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoDetail"];

            lstPoDetail.RemoveAt(e.RowIndex);


            grdPurchaseOrder.DataSource = lstPoDetail;
            grdPurchaseOrder.DataBind();

            Session["PoDetail"] = lstPoDetail;
        }

       
    }
    protected void grdPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdPurchaseOrder.SelectedRow;


        ddlCategory_cat.SelectedValue = row.Cells[1].Text;
        ddlSubCategory_SelectedIndexChanged(null, null);
        ddlSubCategory_cat.SelectedValue = row.Cells[2].Text;
        ddlItems_cat.SelectedValue = row.Cells[3].Text;

        ddlCategory_cat.Enabled = false;
        ddlSubCategory_cat.Enabled = false;
        ddlItems_cat.Enabled = false;

        txtQty_cat.Text = row.Cells[9].Text;

        if (Session["PoDetail"] != null)
        {
            List<ATTInvPurchaseOrderDetail> lst = (List<ATTInvPurchaseOrderDetail>)Session["PoDetail"];

            txtManuCom.Text = lst[grdPurchaseOrder.SelectedIndex].ManuCompany.ToString();
            txtManuDate.Text = lst[grdPurchaseOrder.SelectedIndex].ManuDate.ToString();
            txtBrand.Text = lst[grdPurchaseOrder.SelectedIndex].Brand.ToString();
            //txtManuSpec.Text = lst[grdPurchaseOrder.SelectedIndex].Specification.ToString();
            //lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecBy.ToString()
        }

        btnSubmit.Enabled = false;
    }
    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (sender != null)
            {
                TextBox txtUnitPrice = (TextBox)sender;

                GridViewRow gvRow = (GridViewRow)txtUnitPrice.NamingContainer;

                List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

                if (Session["PoDetail"] != null)
                {
                    lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoDetail"];

                    ATTInvPurchaseOrderDetail objPo = lstPoDetail.Find(delegate(ATTInvPurchaseOrderDetail obj)
                                                                                {
                                                                                    return (obj.ItemsCategoryID == int.Parse(gvRow.Cells[1].Text) &&
                                                                                            obj.ItemsSubCategoryID == int.Parse(gvRow.Cells[2].Text) &&
                                                                                            obj.ItemsID == int.Parse(gvRow.Cells[3].Text));
                                                                                }

                                                                      );

                    objPo.UnitPrice = double.Parse(txtUnitPrice.Text);
                }
            }

            

            foreach (GridViewRow row in grdPurchaseOrder.Rows)
            {
                TextBox txtPrice = (TextBox)row.FindControl("txtUnitPrice");

                row.Cells[4].Text = txtPrice.Text;

                double totalPrice = double.Parse(txtPrice.Text) * double.Parse(row.Cells[9].Text);
                row.Cells[10].Text = totalPrice.ToString();

            }
        }
        catch (Exception ex)
        {
          
            throw(ex);
        }
      
    }

    public string GetFormated(string value)
    {
        value = "00" + value;
        return value.Substring(value.Length - 2, 2);
    }

    public void ClearControls()
    {
        try
        {
            Session["PoDetail"] = null;
            Session["PoItems"] = null;

            grdPurchaseOrder.DataSource = "";
            grdPurchaseOrder.DataBind();

            ddlCategory_cat.SelectedIndex = -1;
            ddlSubCategory_cat.SelectedIndex = -1;
            ddlSubCategory_cat.Enabled = false;

            ddlItems_cat.SelectedIndex = -1;
            ddlItems_cat.Enabled = false;

            txtODate_RDT.Text = "";
            txtOrderNo_rqd.Text = "";

            //ddlUnit_rqd.SelectedIndex = -1;

            txtManuCom.Text = "";
            txtManuDate.Text = "";
            //txtManuSpec.Text = "";
            txtBrand.Text = "";

            ddlSupplier_rqd.SelectedIndex = -1;
            
            txtQty_cat.Text = "";

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public void ClearAddControls()
    {
        try
        {

            ddlItems_cat.SelectedIndex = -1;
            txtQty_cat.Text = "";

            ddlCategory_cat.Enabled = true;

            txtManuCom.Text = "";
            txtManuDate.Text = "";
            //txtManuSpec.Text = "";
            txtBrand.Text = "";
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    public bool CompareDate(string date1, string date2)
    {
        try
        {
            string[] d1 = date1.Split('/');
            string[] d2 = date2.Split('/');

            int year1 = int.Parse(d1[0].ToString());
            int month1 = int.Parse(d1[1].ToString());
            int day1 = int.Parse(d1[2].ToString());

            int year2 = int.Parse(d2[0].ToString());
            int month2 = int.Parse(d2[1].ToString());
            int day2 = int.Parse(d2[2].ToString());

            if (year2 > year1)
            {
                return true;
            }
            else if (year1 == year2)
            {
                if (month2 > month1)
                {
                    return true;
                }
                else if (month1 == month2)
                {
                    if (day2 >= day1)
                    {
                        return true;
                    }
                    else if (day2 < day1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }



            return true;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
}
