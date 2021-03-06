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
        hdnType.Value = "1";
      
    }

    public void LoadControls()
    {
        try
        {
            Session["PoRecmUpdDetail"] = null;

            Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");

            pnlPoDetail.Visible = false;

            //LoadOrganizationUnit();
            LoadSupplier();

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
            Session["PoRecmSupplier"] = BLLInvSupplier.GetSupplierList(null);

            if (Session["PoRecmSupplier"] != null)
            {

                ddlSupplier.DataSource = Session["PoRecmSupplier"];
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
    public void LoadOrganizationUnit()
    {
        try
        {
            //Session["PoOrgUnits"] = BLLOrganizationUnit.GetOrganizationUnits("ST", orgID);

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

                Session["lstSrchRecmPurOrder"] = lstSearchedPurOrder;
                Session["SrchRecmCriteria"] = objSrchPo;


            }
            else
            {
                lblCount.Text = "कुनै पनि रेकर्ड भेटिएन्न् !!!! ";

                //lblCount.Text = "";

                grdSrchPurchaseOrder.DataSource = "";
                grdSrchPurchaseOrder.DataBind();
            }

            ClearItemsDetailControls();
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void ClearControls()
    {
        try
        {
              txtODate_DT.Text = "";
              txtOrderNo.Text = "";

              //ddlUnit_rqd.SelectedIndex = -1;

              ddlSupplier.SelectedIndex = -1;

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
            TextBox txtOrderDate = (TextBox)this.PurposeOrderDetail.FindControl("txtOrderDate");
            TextBox txtQty = (TextBox)this.PurposeOrderDetail.FindControl("txtQty_cat");
         
            DropDownList ddlCategory_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlCategory_cat");
            DropDownList ddlSubCategory_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlSubCategory_cat");
            DropDownList ddlItems_cat = (DropDownList)this.PurposeOrderDetail.FindControl("ddlItems_cat");

            GridView gvDetail = (GridView)this.PurposeOrderDetail.FindControl("grdPurchaseOrderDetail");

            Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");

            txtOrderDate.Text = "";
            txtQty.Text = "";
                               
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
             ATTInvSrchPurchaseOrder objSrchPo = new ATTInvSrchPurchaseOrder();
        
            //if(ddlUnit_rqd.SelectedIndex > 0)
            //    objSrchPo.UnitID = int.Parse(ddlUnit_rqd.SelectedValue);
         
            if (txtOrderNo.Text != "")
                objSrchPo.OrderNo = txtOrderNo.Text;

            if (txtODate_DT.Text != "")
                objSrchPo.OrderDate = txtODate_DT.Text;


            if (ddlSupplier.SelectedIndex > 0)
                objSrchPo.SupplierID = int.Parse(ddlSupplier.SelectedValue);


            LoadSearchedData(objSrchPo);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        ClearItemsDetailControls();
    }

    protected void grdSrchPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdSrchPurchaseOrder.Rows.Count > 0)
        {
            this.lblCount.Text = "जम्मा अर्डर  : " + this.grdSrchPurchaseOrder.Rows.Count.ToString();
        }
        else
        {
            this.lblCount.Text = "";
        }
    }
    protected void grdSrchPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["arrPoRecmDetailInfo"] = null;

        List<ATTInvPurchaseOrder> lstSrchPurOrder = (List<ATTInvPurchaseOrder>)Session["lstSrchRecmPurOrder"];

      
        GridViewRow gvRow = grdSrchPurchaseOrder.SelectedRow;

        string orderNo = gvRow.Cells[8].Text;

        List<ATTInvPurchaseOrderDetail> lst = new List<ATTInvPurchaseOrderDetail>();
        lst = BLLInvPurchaseOrderDetail.GetPurchaseOrderDetail(orderNo);

        this.ClearItemsDetailControls();

        Panel pnlPoDetail = (Panel)this.PurposeOrderDetail.FindControl("pnlPoDetail");
        pnlPoDetail.Visible = true;
     
        DropDownList ddlSupplier = (DropDownList)this.PurposeOrderDetail.FindControl("ddlSupplier");

        ArrayList arrPoDetailInfo = new ArrayList();
        arrPoDetailInfo.Add(gvRow.Cells[1].Text);
        arrPoDetailInfo.Add(gvRow.Cells[2].Text);
        arrPoDetailInfo.Add(gvRow.Cells[3].Text);
        arrPoDetailInfo.Add(gvRow.Cells[4].Text);
        arrPoDetailInfo.Add(gvRow.Cells[8].Text);
        arrPoDetailInfo.Add(gvRow.Cells[9].Text);
        arrPoDetailInfo.Add(entryBy);
        arrPoDetailInfo.Add("1");

        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecBy.ToString());
        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecDate.ToString());
        arrPoDetailInfo.Add(lstSrchPurOrder[grdSrchPurchaseOrder.SelectedIndex].RecYesNo.ToString());

        arrPoDetailInfo.Add(loginID);
      
        HiddenField hdnDate = (HiddenField)this.PurposeOrderDetail.FindControl("hdnDate");
        hdnDate.Value = gvRow.Cells[9].Text;

        GridView gvDetail = (GridView)this.PurposeOrderDetail.FindControl("grdPurchaseOrderDetail");
        gvDetail.SelectedIndex = -1;
        gvDetail.DataSource = lst;
        gvDetail.DataBind();
               

        Session["arrPoRecmDetailInfo"] = (object)arrPoDetailInfo;
        Session["PoRecmUpdDetail"] = lst;

        LoadCurrentDate();
       

    }

    public void LoadCurrentDate()
    {
        try
        {
            string dateString = BLLDate.GetDateString(0, 0, "_N");
            string currentDate;
            int len;

            TextBox txtRecomendDate_RDT = (TextBox)this.PurposeOrderDetail.FindControl("txtRecomendDate_RDT");
            
            if (dateString != null)
            {
                len = dateString.ToString().Length;
                currentDate = dateString.ToString().Substring(0, len - 5);


                txtRecomendDate_RDT.Text = currentDate;
            }
           
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void grdSrchPurchaseOrder_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        gvRow.Cells[1].Visible = false;
        gvRow.Cells[2].Visible = false;
        gvRow.Cells[3].Visible = false;
        gvRow.Cells[4].Visible = false;

        gvRow.Cells[6].Visible = false;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    #region UserControl =================================================================
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        grdSrchPurchaseOrder.SelectedIndex = -1;
        ATTInvSrchPurchaseOrder objSrchPo = (ATTInvSrchPurchaseOrder)Session["SrchRecmCriteria"];

        LoadSearchedData(objSrchPo);


    }
    private void InitializeComponent()
    {

        this.Load += new System.EventHandler(this.Page_Load);
        PurposeOrderDetail.BubbleClick += new EventHandler(WebForm1_BubbleClick);


    }

    #endregion ===========================================================================


    protected void PurposeOrderDetail_Load(object sender, EventArgs e)
    {

    }
}
