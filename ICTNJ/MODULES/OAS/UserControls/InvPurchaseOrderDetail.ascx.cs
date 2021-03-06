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

public partial class MODULES_OAS_UserControls_InvPurchaseOrderDetail : System.Web.UI.UserControl
{
    int i;
    public static int? type = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = int.Parse(hdnType.Value);

        if (type == 0)
        { 
            pnlPurchase.Visible = true;
            pnlRecmAndApprv.Visible = false;
        }
        else if (type == 1 || type == 2)
        {
            pnlPurchase.Visible = false;
            pnlRecmAndApprv.Visible = true;

            if(type ==1)
            {   lblRecmApprv.Text = "सिफारिस विवरण" ;
                lblRecmApprv.ToolTip = "सिफारिस विवरण";

                txtRecomendDate_RDT.ToolTip = "सिफारिस मिति";
                chkRecomend_rqd.ToolTip = "सिफारिस";
            }
            else if(type ==2)
            {
                lblRecomend.Text = "प्रमाणिकरण ";
                lblRecomendDate.Text = "प्रमाणिकरण मिति";
                lblRecmApprv.Text = "प्रमाणिकरण विवरण" ;
                lblRecmApprv.ToolTip = "प्रमाणिकरण विवरण";
                txtRecomendDate_RDT.ToolTip = "प्रमाणिकरण मिति";
                chkRecomend_rqd.ToolTip = "प्रमाणिकरण";
            }
        }
        else
        {
            pnlPurchase.Visible = false;
            pnlRecmAndApprv.Visible = false;
        }

        if (!IsPostBack)
        {
            i = 0;
            LoadControls();
        }

        txtUnitPrice_TextChanged(null, null);
    }

    public void LoadControls()
    {
        try
        {
           
            LoadCategory();
            LoadSupplier();

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
            Session["PoDetCat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["PoDetCat"] != null)
            {
                ddlCategory_cat.DataSource = Session["PoDetCat"];
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
    public void LoadSupplier()
    {
        try
        {
            List<ATTInvSupplier> lst = new List<ATTInvSupplier>();
            lst = BLLInvSupplier.GetSupplierList(null);

            if (lst.Count > 0)
            {

                ddlSupplier.DataSource = lst;
                ddlSupplier.DataTextField = "supplierName";
                ddlSupplier.DataValueField = "supplierID";
                ddlSupplier.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlSupplier.Items.Insert(0, a);
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
             //int? type = null;
             //type = int.Parse(hdnType.Value);


             double price = 0.0;

             bool flag = false;

             List<ATTInvOrgItemsPrice> lstItems = new List<ATTInvOrgItemsPrice>();

             lstItems = (List<ATTInvOrgItemsPrice>)Session["PoDetItems"];

             if (ddlItems_cat.SelectedIndex > 0 && lstItems.Count > 0)
                 price = lstItems[ddlItems_cat.SelectedIndex - 1].UnitPrice;

             List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

             if(type != null)
             {
                 //
                    
                 
                 if(type == 0)
                    lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoUpdDetail"];
                 else if(type == 1)
                    lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"];
                 else if(type == 2)
                    lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"];

                 if (grdPurchaseOrderDetail.SelectedIndex > -1)
                 {
                     GridViewRow gvRow = grdPurchaseOrderDetail.SelectedRow;

                     //int i = int.Parse(gvRow.Cells[4].Text);
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
  
                         if (objPoD.Action == "N" || objPoD.Action == "E")
                             objPoD.Action = "E";
                         else
                             objPoD.Action = "A";

                         ClearAddControls();

                         ddlCategory_cat.SelectedIndex = -1;
                         ddlSubCategory_cat.SelectedIndex = -1;

                         grdPurchaseOrderDetail.SelectedIndex = -1;
                         grdPurchaseOrderDetail.DataSource = lstPoDetail;
                         grdPurchaseOrderDetail.DataBind();

                         

                         if (type == 0)
                             Session["PoUpdDetail"] = lstPoDetail;
                         else if (type == 1)
                             Session["PoRecmUpdDetail"] = lstPoDetail;
                         else if (type == 2)
                             Session["PoApprvUpdDetail"]= lstPoDetail;
                            

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
                                                               int.Parse(ddlItems_cat.SelectedValue), ddlItems_cat.SelectedItem.ToString(), price, int.Parse(txtQty_cat.Text), "A"));

                 ClearAddControls();

                 grdPurchaseOrderDetail.DataSource = lstPoDetail;
                 grdPurchaseOrderDetail.DataBind();

                 if (type == 0)
                     Session["PoUpdDetail"] = lstPoDetail;
                 else if (type == 1)
                     Session["PoRecmUpdDetail"] = lstPoDetail;
                 else if (type == 2)
                     Session["PoApprvUpdDetail"] = lstPoDetail;

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (i == 0)//to prevent the event below from executing more than 1 time
            {
                bool flag = true;

                ArrayList arrPoDetailInfo = new ArrayList();

                if(type == 0)
                {
                    if (Session["arrPoDetailInfo"] != null)
                    arrPoDetailInfo = (ArrayList)Session["arrPoDetailInfo"];
                }
                else if(type == 1)
                {
                    if (Session["arrPoRecmDetailInfo"] != null)
                    arrPoDetailInfo = (ArrayList)Session["arrPoRecmDetailInfo"];
                }
                else if(type == 2)
                {
                    if (Session["arrPoApprvDetailInfo"] != null)
                        arrPoDetailInfo = (ArrayList)Session["arrPoApprvDetailInfo"];
                }

                ATTInvPurchaseOrder objPo = new ATTInvPurchaseOrder();
                
                objPo.OrgID = int.Parse(arrPoDetailInfo[0].ToString());
                //objPo.UnitID = int.Parse(arrPoDetailInfo[1].ToString());
                objPo.OrderNo = arrPoDetailInfo[4].ToString();
                objPo.SupplierID = int.Parse(ddlSupplier.SelectedValue);
                objPo.OrderDate = txtOrderDate.Text;
                objPo.EntryBy = arrPoDetailInfo[6].ToString();
                objPo.Type = int.Parse(arrPoDetailInfo[7].ToString());
              
                if (arrPoDetailInfo[8].ToString() != "")
                    objPo.RecBy = int.Parse(arrPoDetailInfo[8].ToString());
                else
                    objPo.RecBy = null;

                objPo.RecDate = arrPoDetailInfo[9].ToString();
                objPo.RecYesNo = arrPoDetailInfo[10].ToString();


                if (chkRecomend_rqd.Checked == true && txtRecomendDate_RDT.Text != "")
                {

                    if (objPo.Type == 1)
                    {
                        objPo.RecYesNo = "Y";
                        objPo.RecDate = txtRecomendDate_RDT.Text;
                        objPo.RecBy = int.Parse(arrPoDetailInfo[11].ToString());
                    }
                    else if (objPo.Type == 2)
                    {
                        objPo.AppYesNo = "Y";
                        objPo.AppDate = txtRecomendDate_RDT.Text;
                        objPo.AppBy = int.Parse(arrPoDetailInfo[11].ToString());
                    }

                }
                else
                {
                    objPo.Type = 0;
                    objPo.Action = "E";
                }

                if (type == 0)
                {
                    if (((List<ATTInvPurchaseOrderDetail>)Session["PoUpdDetail"]).Count > 0)
                        objPo.lstPurchaseOrderDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoUpdDetail"];
                }
                else if (type == 1)
                {
                    if (((List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"]).Count > 0)
                        objPo.lstPurchaseOrderDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"];
                }
                else if (type == 2)
                {
                    if (((List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"]).Count > 0)
                        objPo.lstPurchaseOrderDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"];
                }
                else
                    flag = false;


                if (flag)
                {
                    int? updateConfirm = null;

                    if (objPo.Type == 0)
                    {
                        updateConfirm = BLLInvPurchaseOrder.SavePurchaseOrder(objPo);
                    }
                    else if (objPo.Type == 1 || objPo.Type == 2)
                    {
                        updateConfirm = BLLInvPurchaseOrder.RecomendApprovePurchaseOrder(objPo);
                    }

                    if (updateConfirm == 0)
                    {
                        ClearItemsDetailControls();

                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = "सफलतापूर्वक परिर्वतन भयो!!!";
                        this.programmaticModalPopup.Show();
                    }
                    else if (updateConfirm == 1)
                    {
                        ClearItemsDetailControls();

                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = "सफलतापूर्वक सिफारिस भयो।";
                        this.programmaticModalPopup.Show();
                    }
                    else if (updateConfirm == 2)
                    {
                        ClearItemsDetailControls();

                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = "सफलतापूर्वक प्रमाणित भयो।";
                        this.programmaticModalPopup.Show();
                    }
                    else
                    {
                        this.lblStatusMessageTitle.Text = "खरिद अर्डर ";
                        this.lblStatusMessage.Text = "वाधा उत्पन्न भयो!!!";
                        this.programmaticModalPopup.Show();
                    }
                }

                i++;
                OnBubbleClick(e);
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (type == 0)
            {
                if (sender != null)
                {
                    TextBox txtUnitPrice = (TextBox)sender;

                    GridViewRow gvRow = (GridViewRow)txtUnitPrice.NamingContainer;

                    List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

                    if (type != null)
                    {

                        if (type == 0)
                            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoUpdDetail"];
                        else if (type == 1)
                            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"];
                        else if (type == 2)
                            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"];

                        ATTInvPurchaseOrderDetail objPo = lstPoDetail.Find(delegate(ATTInvPurchaseOrderDetail obj)
                                                                                    {
                                                                                        return (obj.ItemsCategoryID == int.Parse(gvRow.Cells[1].Text) &&
                                                                                                obj.ItemsSubCategoryID == int.Parse(gvRow.Cells[2].Text) &&
                                                                                                obj.ItemsID == int.Parse(gvRow.Cells[3].Text));
                                                                                    }

                                                                          );

                        objPo.UnitPrice = double.Parse(txtUnitPrice.Text);

                        if (objPo.Action == "A")
                            objPo.Action = "A";
                        else 
                            objPo.Action = "E";
                    }
                }



                foreach (GridViewRow row in grdPurchaseOrderDetail.Rows)
                {
                    TextBox txtPrice = (TextBox)row.FindControl("txtUnitPrice");

                    row.Cells[4].Text = txtPrice.Text;

                    double totalPrice = double.Parse(txtPrice.Text) * double.Parse(row.Cells[9].Text);
                    row.Cells[10].Text = totalPrice.ToString();

                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    
    
    protected void ddlSubCategory_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubCategory_cat.SelectedIndex > 0)
            {
                Session["PoDetItems"] = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(9, int.Parse(ddlCategory_cat.SelectedValue), int.Parse(ddlSubCategory_cat.SelectedValue));

                ddlItems_cat.DataSource = (List<ATTInvOrgItemsPrice>)Session["PoDetItems"];
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
    protected void ddlCategory_cat_SelectedIndexChanged(object sender, EventArgs e)
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
                ddlSubCategory_cat.SelectedIndex = -1;
                ddlSubCategory_cat.Enabled = false;
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
   
    protected void grdPurchaseOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdPurchaseOrderDetail.SelectedRow;


        ddlCategory_cat.SelectedValue = row.Cells[1].Text;
        ddlCategory_cat_SelectedIndexChanged(null, null);
        ddlSubCategory_cat.SelectedValue = row.Cells[2].Text;
        ddlSubCategory_cat_SelectedIndexChanged(null, null);
       
        ddlItems_cat.SelectedValue = row.Cells[3].Text;

        ddlCategory_cat.Enabled = false;
        ddlSubCategory_cat.Enabled = false;
        ddlItems_cat.Enabled = false;

        txtQty_cat.Text = row.Cells[9].Text;

        btnSubmit.Enabled = false;
    }
    protected void grdPurchaseOrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           

            ((TextBox)e.Row.FindControl("txtUnitPrice")).Attributes.Add("onkeypress", "return DecimalOnly(event,this)");

            TextBox txtPrice = (TextBox)row.FindControl("txtUnitPrice");
            txtPrice.Text = row.Cells[4].Text;

            double totalPrice = double.Parse(row.Cells[4].Text) * double.Parse(row.Cells[9].Text);
            row.Cells[10].Text = totalPrice.ToString();

            LinkButton lnkBtn = (LinkButton)row.Cells[12].Controls[0];

            if (row.Cells[13].Text == "D")
            {
                lnkBtn.Text = "Undo";
                row.ForeColor = System.Drawing.Color.Red;
            }


            if (type != 0)
            {
                ((TextBox)e.Row.FindControl("txtUnitPrice")).Attributes.Add("readonly", "true");

            }
           

        }


        if (this.grdPurchaseOrderDetail.Rows.Count > 0)
        {
            this.lblCount.Text = "जम्मा आइटम : " + this.grdPurchaseOrderDetail.Rows.Count.ToString();
        }
        else
        {
            this.lblCount.Text = "";
        }

       

    }
    protected void grdPurchaseOrderDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[3].Visible = false;
        row.Cells[4].Visible = false;
        row.Cells[13].Visible = false;

        if (type != 0)
        {

            row.Cells[11].Visible = false;
            row.Cells[12].Visible = false;
        }

        
    }
    protected void grdPurchaseOrderDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int? type = null;
        type = int.Parse(hdnType.Value);

        if (type != null)
        {
            List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

            if (type == 0)
                lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoUpdDetail"];
            else if (type == 1)
                lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"];
            else if (type == 2)
                lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"];

            GridViewRow gvRow = grdPurchaseOrderDetail.Rows[e.RowIndex];

            string action = gvRow.Cells[13].Text;
            LinkButton lnkBtn = (LinkButton)gvRow.Cells[12].Controls[0];

            if (action == "A")
            {
                lstPoDetail.RemoveAt(e.RowIndex);

                grdPurchaseOrderDetail.DataSource = lstPoDetail;
                grdPurchaseOrderDetail.DataBind();
            }
            else
            {

                ATTInvPurchaseOrderDetail objPoD = lstPoDetail.Find(delegate(ATTInvPurchaseOrderDetail objPd)
                                                                                  {
                                                                                      return ((objPd.ItemsCategoryID == int.Parse(gvRow.Cells[1].Text)) &&
                                                                                              (objPd.ItemsSubCategoryID == int.Parse(gvRow.Cells[2].Text)) &&
                                                                                              (objPd.ItemsID == int.Parse(gvRow.Cells[3].Text)));
                                                                                  }

                                                                        );

                if (action == "N" || action == "E")
                {
                    lnkBtn.Text = "Undo";
                    gvRow.Cells[13].Text = "D";
                    gvRow.ForeColor = System.Drawing.Color.Red;
                }
                else if (action == "D")
                {
                    lnkBtn.Text = "Remove";
                    gvRow.Cells[13].Text = "E";
                    gvRow.ForeColor = System.Drawing.Color.Black;
                }

                if (objPoD != null)
                {
                    if ((lnkBtn.Text == "Undo") && (gvRow.Cells[13].Text == "D"))
                    {
                        objPoD.Action = "D";
                    }
                    else if ((lnkBtn.Text == "Remove") && (gvRow.Cells[13].Text == "E"))
                    {
                        objPoD.Action = "E";
                    }
                }
            }



        }
    }

    public void ClearAddControls()
    {
        try
        {

            ddlItems_cat.SelectedIndex = -1;
            txtQty_cat.Text = "";

            ddlCategory_cat.Enabled = true;
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();

        }
    }
    public void ClearItemsDetailControls()
    {
        try
        {
            Session["arrPoDetailInfo"] = null;

           
            txtOrderDate.Text = "";
            txtQty_cat.Text = "";
            txtRecomendDate_RDT.Text = "";

            chkRecomend_rqd.Checked = false;

            grdPurchaseOrderDetail.SelectedIndex = -1;
            grdPurchaseOrderDetail.DataSource = "";
            grdPurchaseOrderDetail.DataBind();

            ddlCategory_cat.SelectedIndex = -1;
            ddlSubCategory_cat.SelectedIndex = -1;
            ddlItems_cat.SelectedIndex = -1;
            ddlCategory_cat.Enabled = true;
            ddlSubCategory_cat.Enabled = false;
            ddlItems_cat.Enabled = false;

            pnlPoDetail.Visible = false;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void OkButton_Click(object sender, EventArgs e)
    {
        
        programmaticModalPopup.Hide();
    }



    #region NB:: for UserControl =====================================================================

    public event EventHandler BubbleClick;
 

    protected void OnBubbleClick(EventArgs e)
    {
        if (BubbleClick != null)
        {
            BubbleClick(this, e);
        }
    }
   
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {

        this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
       
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    #endregion=====================================================================================


    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        ddlCategory_cat.SelectedIndex = -1;
        ddlSubCategory_cat.SelectedIndex = -1;
        ddlItems_cat.SelectedIndex = -1;
        txtQty_cat.Text = "";
        grdPurchaseOrderDetail.SelectedIndex = -1;
    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {

        chkRecomend_rqd.Checked = false;
        txtRecomendDate_RDT.Text = "";

        List<ATTInvPurchaseOrderDetail> lstPoDetail = new List<ATTInvPurchaseOrderDetail>();

        if (type == 1)
            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoRecmUpdDetail"];
        else if (type == 2)
            lstPoDetail = (List<ATTInvPurchaseOrderDetail>)Session["PoApprvUpdDetail"];

        grdPurchaseOrderDetail.DataSource = lstPoDetail;
        grdPurchaseOrderDetail.DataBind();
        
    }
}
