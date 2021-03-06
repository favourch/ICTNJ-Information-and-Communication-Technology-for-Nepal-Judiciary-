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

public partial class MODULES_OAS_UserControls_InvReturnOrder : System.Web.UI.UserControl
{
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadControls();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (i == 0)//to prevent the event below from executing more than 1 time
        {
            ClearControls();

            i++;
            OnBubbleCancelClick(e);
        }

        
    }

    public void LoadControls()
    {
        try
        {
            LoadOrganizationUnit();

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
            Session["PoOrgRetUnits"] = BLLOrganizationUnit.GetOrganizationUnits("ST", 9);

            if (Session["PoOrgRetUnits"] != null)
            {
                ddlUnit_srch.DataSource = Session["PoOrgRetUnits"];
                ddlUnit_srch.DataTextField = "UnitName";
                ddlUnit_srch.DataValueField = "UnitID";
                ddlUnit_srch.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlUnit_srch.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void OkButton_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ATTInvSrchDeliveryOrder objSrchDo = new ATTInvSrchDeliveryOrder();
            
            if (ddlUnit_srch.SelectedIndex > 0)
                objSrchDo.UnitID = int.Parse(ddlUnit_srch.SelectedValue);

            if (txtOrderNo_srch.Text != "")
                objSrchDo.OrderNo = txtOrderNo_srch.Text;

            LoadSearchedData(objSrchDo);

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void LoadSearchedData(ATTInvSrchDeliveryOrder objSrchDo)
    {
        try
        {
            btnCancel_Click(null, null);
            List<ATTInvDeliveryOrder> lstSrchedDeliveredOrder = new List<ATTInvDeliveryOrder>();
            lstSrchedDeliveredOrder = BLLInvSrchDeliveryOrder.SrchDeliveredOrder(objSrchDo);

            
            if (lstSrchedDeliveredOrder.Count > 0)
            {            
                grdDelivery.SelectedIndex = -1;
                grdDelivery.DataSource = lstSrchedDeliveredOrder;
                grdDelivery.DataBind();

                Session["lstSrchedDeliveredOrder"] = lstSrchedDeliveredOrder;

                Session["SrchRetCriteria"] = objSrchDo;
            }
            else
            {
                lblDeliveryCount.Text = "कुनै पनि रेकर्ड भेटिएन्न् !!!! ";

                grdDelivery.DataSource = "";
                grdDelivery.DataBind();

                Session["lstSrchedDeliveredOrder"] = null;
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    
    protected void grdDelivery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["lstSrchedDeliveredOrder"] != null)
        {
            if (i == 0)//to prevent the event below from executing more than 1 time
            {
                List<ATTInvDeliveryOrder> lst = (List<ATTInvDeliveryOrder>)Session["lstSrchedDeliveredOrder"];
               
                List<ATTInvDeliveryOrderDetail> lstDeliveredOrderDetail = new List<ATTInvDeliveryOrderDetail>();


                ATTInvDeliveryOrder objDo = lst.Find(delegate(ATTInvDeliveryOrder obj)
                                                              {
                                                                  return (obj.OrgID == lst[grdDelivery.SelectedIndex].OrgID &&
                                                                          obj.UnitID == lst[grdDelivery.SelectedIndex].UnitID &&
                                                                          obj.OrderNo == lst[grdDelivery.SelectedIndex].OrderNo &&
                                                                          obj.DeliverySeq == lst[grdDelivery.SelectedIndex].DeliverySeq);
                                                              }

                                                        );

                Session["objReturn"] = objDo;

                //lst[grdDelivery.SelectedIndex]


                lstDeliveredOrderDetail = BLLInvSrchDeliveryOrder.DeliveredOrderDetail(objDo);
                           

                if (lstDeliveredOrderDetail.Count > 0)
                {
                    hdnReceivedDate.Value = lst[grdDelivery.SelectedIndex].ReceivedDate;
                    grdDeliveryDetails.SelectedIndex = -1;
                    grdDeliveryDetails.DataSource = lstDeliveredOrderDetail;
                    grdDeliveryDetails.DataBind();

                }
                else
                {
                     //lblCount.Text = "No Records FOUND !!!! ";

                     grdDeliveryDetails.DataSource = "";
                     grdDeliveryDetails.DataBind();
                }

            
                i++;
                OnBubbleClick(e);
            }
        }

    }

    protected void grdDelivery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdDelivery.Rows.Count > 0)
        {
            this.lblDeliveryCount.Text = "जम्मा डेलिभरी : " + this.grdDelivery.Rows.Count.ToString();
        }
        else
        {
            this.lblDeliveryCount.Text = "";
        }
    }

    
    protected void txtReturnQty_TextChanged(object sender, EventArgs e)
    {
        if (sender != null)
        {
            TextBox txtReturnQty = (TextBox)sender;

            GridViewRow gvRow = (GridViewRow)txtReturnQty.NamingContainer;

            int? QTY = null;

            QTY = txtReturnQty.Text == "" ? 0 : int.Parse(txtReturnQty.Text);


            int? RQD = int.Parse(gvRow.Cells[11].Text)- int.Parse(gvRow.Cells[12].Text);;

            if (QTY > RQD)
            {
                txtReturnQty.Text = "";
                this.lblStatusMessageTitle.Text = "डेलिभरी सामान फर्काउने";
                this.lblStatusMessage.Text = "डेलिभरी भएको भन्दा बढी सामान फर्काउन पाइदैन ।";
                this.programmaticModalPopup.Show();

            }

        }
    }

    #region for UserControl

    public event EventHandler BubbleClick;
    public event EventHandler BubbleCancelClick;
   
    protected void OnBubbleClick(EventArgs e)
    {
        if (BubbleClick != null)
        {
            BubbleClick(this, e);
        }
    }

    protected void OnBubbleCancelClick(EventArgs e)
    {
        if (BubbleCancelClick != null)
        {
            BubbleCancelClick(this, e);
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
        this.grdDelivery.SelectedIndexChanged += new System.EventHandler(this.grdDelivery_SelectedIndexChanged);
        this.btnCancel.Click += new EventHandler(btnCancel_Click);
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    #endregion

    protected void grdDeliveryDetails_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdDeliveryDetails.Rows.Count > 0)
        {
            this.lblItemCount.Text = "जम्मा आइटम: " + this.grdDeliveryDetails.Rows.Count.ToString();
        }
        else
        {
            this.lblItemCount.Text = "";
        }
    }
    protected void grdDeliveryDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;

        gvr.Cells[1].Visible = false;
        gvr.Cells[2].Visible = false;
        gvr.Cells[3].Visible = false;
        gvr.Cells[4].Visible = false;
        gvr.Cells[5].Visible = false;
        gvr.Cells[6].Visible = false;
        gvr.Cells[7].Visible = false;
        
    }

    public void ClearControls()
    {
        try
        {
            lblDeliveryCount.Text = "";
            lblItemCount.Text = "";
            txtOrderNo_srch.Text = "";
            ddlUnit_srch.SelectedIndex = -1;

            grdDelivery.SelectedIndex = -1;
            grdDelivery.DataSource = "";
            grdDelivery.DataBind();

            grdDeliveryDetails.SelectedIndex = -1;
            grdDeliveryDetails.DataSource = "";
            grdDeliveryDetails.DataBind();

            Session["lstSrchedDeliveredOrder"] = null;
            Session["SrchRetCriteria"] = null;



        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
}
