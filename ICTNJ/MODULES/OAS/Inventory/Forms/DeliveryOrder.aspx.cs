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
    public bool updDelvFlag = false;    

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
     
    }
    public void LoadControls()
    {
        try
        {
            LoadOrganizationUnit();

            Panel pnlDeliveryOrder = (Panel)this.DeliveryOrder1.FindControl("pnlDeliveryOrder");
            pnlDeliveryOrder.Visible = false;

        }
        catch (Exception ex)
        {

            throw (ex);
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
    
    public void ClearControls()
    {
        try
        {
            lblCount.Text = "";
            txtOrderNo_rqd.Text = "";
            //ddlUnit_rqd.SelectedIndex =-1;

            grdDeliveryDetails.SelectedIndex = -1;
            grdDeliveryDetails.DataSource = "";
            grdDeliveryDetails.DataBind();

            Panel pnlDeliveryOrder = (Panel)this.DeliveryOrder1.FindControl("pnlDeliveryOrder");
            pnlDeliveryOrder.Visible = false;  

            
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    public void ClearDeliveryControls()
    {

        TextBox txtOrderNo = (TextBox)this.DeliveryOrder1.FindControl("txtOrderNo");
        TextBox txtDeliveryDate_RDT = (TextBox)this.DeliveryOrder1.FindControl("txtDeliveryDate_RDT");
        TextBox txtDeliveryPer_delv = (TextBox)this.DeliveryOrder1.FindControl("txtDeliveryPer_delv");
        TextBox txtInvoiceNo_delv = (TextBox)this.DeliveryOrder1.FindControl("txtInvoiceNo_delv");
        TextBox txtReceivedDate_RDT = (TextBox)this.DeliveryOrder1.FindControl("txtReceivedDate_RDT");

        Panel pnlDeliveryOrder = (Panel)this.DeliveryOrder1.FindControl("pnlDeliveryOrder");
         
        txtOrderNo.Text = "";
        txtDeliveryDate_RDT.Text = "";
        txtDeliveryPer_delv.Text = "";
        txtInvoiceNo_delv.Text = "";
        txtReceivedDate_RDT.Text = "";

        pnlDeliveryOrder.Visible = false;

    }
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["DelivSrchCriteria"] = null;

            ATTInvSrchDeliveryOrder objSrchDo = new ATTInvSrchDeliveryOrder();
         
            if (txtOrderNo_rqd.Text != "")
                objSrchDo.OrderNo = txtOrderNo_rqd.Text;

            LoadSearchedData(objSrchDo);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadSearchedData(ATTInvSrchDeliveryOrder objSrchDo)
    {
        try
        {
            List<ATTInvDeliveryOrderDetail> lstSearchedDeliveryOrder = new List<ATTInvDeliveryOrderDetail>();
            lstSearchedDeliveryOrder = BLLInvSrchDeliveryOrder.SrchDeliveryOrder(objSrchDo);
            
            Panel pnlDeliveryOrder = (Panel)this.DeliveryOrder1.FindControl("pnlDeliveryOrder");
            
            if (lstSearchedDeliveryOrder.Count > 0)
            {
                pnlDeliveryOrder.Visible = true;

                TextBox txtOrderNo  = (TextBox)this.DeliveryOrder1.FindControl("txtOrderNo");
                TextBox txtApproveDate = (TextBox)this.DeliveryOrder1.FindControl("txtApproveDate");

                txtOrderNo.Text = lstSearchedDeliveryOrder[0].OrderNo;
                txtApproveDate.Text = lstSearchedDeliveryOrder[0].ApproveDate;
       

                grdDeliveryDetails.SelectedIndex = -1;
                grdDeliveryDetails.DataSource = lstSearchedDeliveryOrder;
                grdDeliveryDetails.DataBind();

                Session["lstSrchDelivOrder"] = lstSearchedDeliveryOrder;
                Session["DelivSrchCriteria"] = objSrchDo;


            }
            else
            {
                pnlDeliveryOrder.Visible = false;

                lblCount.Text = "कुनै पनि रेकर्ड भेटिएन्न् !!!!";

                grdDeliveryDetails.DataSource = "";
                grdDeliveryDetails.DataBind();
            }

        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void grdDeliveryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         GridViewRow row = e.Row;

         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             ((TextBox)e.Row.FindControl("txtCurrentQty")).Attributes.Add("onkeypress", "return NumberOnly(event,this)");
          
            

         }

         if (this.grdDeliveryDetails.Rows.Count > 0)
         {
             this.lblCount.Text = "जम्मा सामान : " + this.grdDeliveryDetails.Rows.Count.ToString();
         }
         else
         {
             this.lblCount.Text = "";
         }

    }
    protected void txtCurrentQty_TextChanged(object sender, EventArgs e)
    {
        if (sender != null)
        {
            TextBox txtCurrentQty = (TextBox)sender;

            GridViewRow gvRow = (GridViewRow)txtCurrentQty.NamingContainer;


            int? QTY = null;

            QTY = txtCurrentQty.Text == "" ? 0 : int.Parse(txtCurrentQty.Text);

            
            int? RQD = int.Parse(gvRow.Cells[4].Text) - int.Parse(gvRow.Cells[5].Text);

            if (QTY > RQD)
            {
                 txtCurrentQty.Text = "";
                this.lblStatusMessageTitle.Text = "डेलिभरी अर्डर";
                this.lblStatusMessage.Text = " माग भएको  भन्दा बढी  संख्यामा सामान डेलिभरी गर्न पाइदैन ।";
                this.programmaticModalPopup.Show();

            }
           
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
        this.Load += new System.EventHandler(this.Page_Load);
        DeliveryOrder1.BubbleClick += new EventHandler(DeliveryOrder1_BubbleClick);
        DeliveryOrder1.BubbleCancelClick +=new EventHandler(DeliveryOrder1_BubbleCancelClick);
                       
    }

    #endregion

    private void DeliveryOrder1_BubbleClick(object sender, EventArgs e)
    {
        List<ATTInvDeliveryOrderDetail> lstDeliveryOrder = new List<ATTInvDeliveryOrderDetail>();
        lstDeliveryOrder = (List<ATTInvDeliveryOrderDetail>) Session["lstSrchDelivOrder"] ;

        TextBox txtDeliveryDate_RDT = (TextBox)this.DeliveryOrder1.FindControl("txtDeliveryDate_RDT");
        TextBox txtDeliveryPer_delv = (TextBox)this.DeliveryOrder1.FindControl("txtDeliveryPer_delv");
        TextBox txtInvoiceNo_delv = (TextBox)this.DeliveryOrder1.FindControl("txtInvoiceNo_delv");
        TextBox txtReceivedDate_RDT = (TextBox)this.DeliveryOrder1.FindControl("txtReceivedDate_RDT");

        ATTInvDeliveryOrder objDo = new ATTInvDeliveryOrder();

        objDo.OrgID = lstDeliveryOrder[0].OrgID;
        objDo.UnitID = lstDeliveryOrder[0].UnitID;
        objDo.OrderNo = lstDeliveryOrder[0].OrderNo;
        objDo.DeliveryDate = txtDeliveryDate_RDT.Text;
        objDo.DeliveryPerson = txtDeliveryPer_delv.Text;
        objDo.InvoiceNo = txtInvoiceNo_delv.Text;
        objDo.ReceiverID = loginID;
        objDo.ReceivedDate = txtReceivedDate_RDT.Text;

        objDo.lstDeliveryOrderDetail = CalculateDeliveryDetails();

        objDo.Action = "A";
        objDo.EntryBy = entryBy;

        if (updDelvFlag)
        {
            this.lblStatusMessageTitle.Text = "डेलिभरी अर्डर";
            this.lblStatusMessage.Text = "डेलिभरीको लागी सामान हाल्नुहोस्!!!";
            this.programmaticModalPopup.Show();

            updDelvFlag = false;    
        }
        else
        {

            if (BLLInvDeliveryOrder.SaveUpdateDeliveryOrder(objDo))
            {
                ClearControls();
                ClearDeliveryControls();

                this.lblStatusMessageTitle.Text = "डेलिभरी अर्डर";
                this.lblStatusMessage.Text = "डेलिभरी सफलतापूर्वक भयो!!!";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "डेलिभरी अर्डर";
                this.lblStatusMessage.Text = "डेलिभरीमा वाधा उत्पन्न भयो!!!";
                this.programmaticModalPopup.Show();
            }
        }

    }
    private void DeliveryOrder1_BubbleCancelClick(object sender, EventArgs e)
    {

        //ClearControls();
    }

    public List<ATTInvDeliveryOrderDetail> CalculateDeliveryDetails()
    {
        try
        {
            List<ATTInvDeliveryOrderDetail> lstDeliveryOrder = new List<ATTInvDeliveryOrderDetail>();
            lstDeliveryOrder = (List<ATTInvDeliveryOrderDetail>)Session["lstSrchDelivOrder"];

            ArrayList arrTotalQty = new ArrayList();
            TextBox txtCurrentQty;

            int i = 0;
            int currentQty = 0;

            if (grdDeliveryDetails.Rows.Count > 0)
            {

                foreach (GridViewRow gvr in grdDeliveryDetails.Rows)
                {
                    txtCurrentQty = (TextBox)gvr.FindControl("txtCurrentQty");

                    currentQty = txtCurrentQty.Text == "" ? 0 : int.Parse(txtCurrentQty.Text);

                    arrTotalQty.Add(currentQty.ToString());

                }

                int? total;

                int j = 0;

                foreach (ATTInvDeliveryOrderDetail obj in lstDeliveryOrder)
                {
                    total = 0;

                    if (i < arrTotalQty.Count)
                    {
                        obj.TotalDeliveryQty = int.Parse(arrTotalQty[i].ToString());

                        total = obj.DeliveredQty + obj.TotalDeliveryQty;

                        if (obj.TotalDeliveryQty != 0)
                        {
                            if (obj.RequiredQty >= total)
                                obj.Action = "A";
                            else
                            {
                                j++;
                                obj.Action = "N";
                            }
                        }
                        else
                        {
                            j++;
                            obj.Action = "N";
                        }
                    }
                    i++;
                }

                if (j == lstDeliveryOrder.Count)
                {
                    updDelvFlag = true;
                }
            }

            return lstDeliveryOrder;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
       

    }


   
}
