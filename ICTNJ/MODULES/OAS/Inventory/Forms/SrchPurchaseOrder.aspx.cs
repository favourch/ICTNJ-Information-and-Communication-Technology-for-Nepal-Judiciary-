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

        HiddenField hdnType = (HiddenField)this.PurposeOrderDetail.FindControl("hdnType");
        hdnType.Value = "0";
      
    }

    public void LoadControls()
    {
        try
        {
            Session["PoUpdDetail"] = null;

            Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");
            pnlPoDetail.Visible = false;

            //LoadUnit();
            LoadSupplier();

            //LoadOrganizationUnit();

        }
        catch (Exception ex)
        {

            throw (ex);
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
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
           /* if (ddlUnit_rqd.SelectedIndex > 0)
            {

                ddlSection_rqd.Items.Clear();
                ddlSection_rqd.DataSource = BLLOrganizationSection.GetOrgSection(9, int.Parse(ddlUnit_rqd.SelectedValue));
                ddlSection_rqd.DataTextField = "sectionname";
                ddlSection_rqd.DataValueField = "sectionid";
                ddlSection_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlSection_rqd.Items.Insert(0, a);

                ddlSection_rqd.Enabled = true;

            }
            else
            {
                ddlSection_rqd.SelectedIndex = -1;
                ddlSection_rqd.Enabled = false;
            }*/

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void ClearControls()
    {
        try
        {
              txtODate_DT.Text = "";
              txtOrderNo_rqd.Text = "";

              //ddlUnit_rqd.SelectedIndex = -1;

              //ddlSection_rqd.SelectedIndex = -1;
              //ddlSection_rqd.Enabled = false; 

              ddlSupplier_rqd.SelectedIndex = -1;

              grdSrchPurchaseOrder.SelectedIndex = -1;

              grdSrchPurchaseOrder.DataSource = "";
              grdSrchPurchaseOrder.DataBind();

              lblCount.Text = "";

             

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    public void ClearItemsDetailControls()
    {
        try
        {
           // TextBox txtUnit = (TextBox)this.PurposeOrderDetail.FindControl("txtUnit");
            //TextBox txtSection = (TextBox)this.PurposeOrderDetail.FindControl("txtSection");
            //TextBox txtOrderNo = (TextBox)this.PurposeOrderDetail.FindControl("txtOrderNo");
            TextBox txtOrderDate = (TextBox)this.PurposeOrderDetail.FindControl("txtOrderDate");
            TextBox txtQty = (TextBox)this.PurposeOrderDetail.FindControl("txtQty_cat");
            TextBox txtRecomendDate_RDT = (TextBox)this.PurposeOrderDetail.FindControl("txtRecomendDate_RDT");

            CheckBox chkRecomend_rqd = (CheckBox)this.PurposeOrderDetail.FindControl("chkRecomend_rqd");

            DropDownList ddlCategory_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlCategory_cat");
            DropDownList ddlSubCategory_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlSubCategory_cat");
            DropDownList ddlItems_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlItems_cat");

            GridView gvDetail = (GridView)this.PurposeOrderDetail.FindControl("grdPurchaseOrderDetail");

            Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");

           // txtUnit.Text = "";
            //txtSection.Text = "";
            txtOrderDate.Text = "";
            //txtOrderNo.Text = "";
            txtQty.Text = "";
            txtRecomendDate_RDT.Text = "";

            chkRecomend_rqd.Checked = false;

            gvDetail.DataSource = "";
            gvDetail.DataBind();

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
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        ClearItemsDetailControls();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["SrchCriteria"] = null;

            ATTInvSrchPurchaseOrder objSrchPo = new ATTInvSrchPurchaseOrder();
        
            if (txtOrderNo_rqd.Text != "")
                objSrchPo.OrderNo = txtOrderNo_rqd.Text;

            if (txtODate_DT.Text != "")
                objSrchPo.OrderDate = txtODate_DT.Text;

            if (ddlSupplier_rqd.SelectedIndex > 0)
                objSrchPo.SupplierID = int.Parse(ddlSupplier_rqd.SelectedValue);

            LoadSearchedData(objSrchPo);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadSearchedData(ATTInvSrchPurchaseOrder objSrchPo)
    {
        try
        {
            List<ATTInvPurchaseOrder> lstSearchedPurOrder = new List<ATTInvPurchaseOrder>();
            lstSearchedPurOrder = BLLInvSrchPurchaseOrder.SrchPurchaseOrder(objSrchPo, 1);

            if (lstSearchedPurOrder.Count > 0)
            {
                grdSrchPurchaseOrder.SelectedIndex = -1;
                grdSrchPurchaseOrder.DataSource = lstSearchedPurOrder;
                grdSrchPurchaseOrder.DataBind();

                Session["lstSrchPurOrder"] = lstSearchedPurOrder;
                Session["SrchCriteria"] = objSrchPo;


            }
            else
            {
                lblCount.Text = "कुनै पनि रेकर्ड भेटिएन्न् !!!! ";

                grdSrchPurchaseOrder.DataSource = "";
                grdSrchPurchaseOrder.DataBind();
            }

            ClearItemsDetailControls();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void grdSrchPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdSrchPurchaseOrder.Rows.Count > 0)
        {
            this.lblCount.Text = "जम्मा अर्डर : " + this.grdSrchPurchaseOrder.Rows.Count.ToString();
        }
        else
        {
            this.lblCount.Text = "";
        }
    }
    protected void grdSrchPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["arrPoDetailInfo"] = null;

        List<ATTInvPurchaseOrder> lstSrchPurOrder = (List<ATTInvPurchaseOrder>)Session["lstSrchPurOrder"];

        GridViewRow gvRow = grdSrchPurchaseOrder.SelectedRow;

        string orderNo = gvRow.Cells[8].Text;

        List<ATTInvPurchaseOrderDetail> lst = new List<ATTInvPurchaseOrderDetail>();
        lst = BLLInvPurchaseOrderDetail.GetPurchaseOrderDetail(orderNo);

        this.ClearItemsDetailControls();

        Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");
        pnlPoDetail.Visible = true;

        TextBox txtOrderDate = (TextBox)this.PurposeOrderDetail.FindControl("txtOrderDate");
        TextBox txtRecomendDate_RDT = (TextBox)this.PurposeOrderDetail.FindControl("txtRecomendDate_RDT");
        
        CheckBox chkRecomend_rqd = (CheckBox)this.PurposeOrderDetail.FindControl("chkRecomend_rqd");
        
        Label lblRecomend = (Label)this.PurposeOrderDetail.FindControl("lblRecomend");
        Label lblRecomendDate = (Label)this.PurposeOrderDetail.FindControl("lblRecomendDate");
       
        DropDownList ddlSupplier = (DropDownList)this.PurposeOrderDetail.FindControl("ddlSupplier");




        txtRecomendDate_RDT.Visible = false;
        chkRecomend_rqd.Visible = false;
        lblRecomend.Visible = false;
        lblRecomendDate.Visible = false;    

        ArrayList arrPoDetailInfo = new ArrayList();
        arrPoDetailInfo.Add(gvRow.Cells[1].Text);
        arrPoDetailInfo.Add(gvRow.Cells[2].Text);
        arrPoDetailInfo.Add(gvRow.Cells[3].Text);
        arrPoDetailInfo.Add(gvRow.Cells[4].Text);
        arrPoDetailInfo.Add(gvRow.Cells[8].Text);
        arrPoDetailInfo.Add(gvRow.Cells[9].Text);
        arrPoDetailInfo.Add(entryBy);
        arrPoDetailInfo.Add("0");

        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecBy.ToString());
        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecDate.ToString());
        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecYesNo.ToString());

    
        arrPoDetailInfo.Add(loginID);
        txtOrderDate.Text = gvRow.Cells[9].Text;
      

        ddlSupplier.SelectedValue = gvRow.Cells[4].Text;


        GridView gvDetail = (GridView)this.PurposeOrderDetail.FindControl("grdPurchaseOrderDetail");
        gvDetail.SelectedIndex = -1;
        gvDetail.DataSource = lst;
        gvDetail.DataBind();

        Session["arrPoDetailInfo"] = (object)arrPoDetailInfo;
        Session["PoUpdDetail"] = lst;

    }
    protected void grdSrchPurchaseOrder_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        gvRow.Cells[1].Visible = false;
        gvRow.Cells[2].Visible = false;
        gvRow.Cells[3].Visible = false;
        gvRow.Cells[4].Visible = false;
        gvRow.Cells[5].Visible = false;
        gvRow.Cells[6].Visible = false;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }



    #region NB:UserControl==========================================
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        grdSrchPurchaseOrder.SelectedIndex = -1;
        ATTInvSrchPurchaseOrder objSrchPo = (ATTInvSrchPurchaseOrder)Session["SrchCriteria"];

        LoadSearchedData(objSrchPo);

        
    }
    private void InitializeComponent()
    {
        
        this.Load += new System.EventHandler(this.Page_Load);
        PurposeOrderDetail.BubbleClick += new EventHandler(WebForm1_BubbleClick);
       

    }

    #endregion =====================================================
  
}
