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
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Inventory_Forms_ReturnOrder : System.Web.UI.Page
{
    public int orgID;
    public string entryBy;
    public int loginID;
    public bool updReturnFlag = false;    

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
       
    }
 
    protected void OkButton_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ATTInvDeliveryOrder objDo = new ATTInvDeliveryOrder();
            objDo = (ATTInvDeliveryOrder)Session["objReturn"];

            ATTInvReturnOrder objRo = new ATTInvReturnOrder();
            objRo.OrgID = objDo.OrgID;
            //objRo.UnitID = objDo.UnitID;
            objRo.OrderNo = objDo.OrderNo;
            objRo.DeliverySeq = objDo.DeliverySeq;
            objRo.ReturnDate = txtReturnDate_RDT.Text;
            objRo.ReturnRemarks = txtReturnRemark_rqd.Text;
            objRo.LstReturnOrderDetail = SetReturOrderDetail();
            objRo.EntryBy = entryBy;
            objRo.Action = "A";

            if (updReturnFlag)
            {            
                this.lblStatusMessageTitle.Text = "डेलिभरी सामान फिर्ता";
                this.lblStatusMessage.Text = "कति वटा सामान फिर्ता गर्ने हो डाटा राख्नुहोस्।";
                this.programmaticModalPopup.Show();

                updReturnFlag = false;
            }
            else
            {

                if (BLLInvReturnOrder.SaveUpdateReturnOrder(objRo))
                {
                    ReloadSrchData();
                    Session["objReturn"] = null;

                    ClearControls();
                    ClearGridControls();
                    pnlReturnOrder.Visible = false;

                    this.lblStatusMessageTitle.Text = "डेलिभरी सामान फिर्ता";
                    this.lblStatusMessage.Text = " सफलतापूर्वक डेलिभरी सामान फिर्ता भयो।";
                    this.programmaticModalPopup.Show();

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "डेलिभरी सामान फिर्ता";
                    this.lblStatusMessage.Text = " डेलिभरी सामान फिर्ता गर्दा वाधा उत्पन्न भयो।";
                    this.programmaticModalPopup.Show();

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

    public void ClearControls()
    {
        txtReturnDate_RDT.Text = "";
        txtReturnRemark_rqd.Text = "";
    }

    public void ClearGridControls()
    {
        GridView grdDelivery = (GridView)this.ReturnOrder1.FindControl("grdDelivery");
        GridView grdDeliveryDetails = (GridView)this.ReturnOrder1.FindControl("grdDeliveryDetails");

        Label lblDeliveryCount = (Label)this.ReturnOrder1.FindControl("lblDeliveryCount");
        Label lblItemCount = (Label)this.ReturnOrder1.FindControl("lblItemCount");


        grdDelivery.SelectedIndex = -1;
        grdDelivery.DataSource = "";
        grdDelivery.DataBind();

        grdDeliveryDetails.SelectedIndex = -1;
        grdDeliveryDetails.DataSource = "";
        grdDeliveryDetails.DataBind();

        lblDeliveryCount.Text = "";
        lblItemCount.Text = "";

        
        
    }

    public List<ATTInvReturnOrderDetail> SetReturOrderDetail()
    {
        GridView grdDeliveryDetails = (GridView)this.ReturnOrder1.FindControl("grdDeliveryDetails");

        List<ATTInvReturnOrderDetail> lst = new List<ATTInvReturnOrderDetail>();

        if (grdDeliveryDetails.Rows.Count > 0)
        {
            int j = 0;
            foreach (GridViewRow gvr in grdDeliveryDetails.Rows)
            {
                TextBox txtReturnQty = (TextBox)gvr.Cells[13].FindControl("txtReturnQty");

                ATTInvReturnOrderDetail obj = new ATTInvReturnOrderDetail();

                obj.OrgID = int.Parse(gvr.Cells[1].Text);
                //obj.UnitID = int.Parse(gvr.Cells[2].Text);
                obj.OrderNo = gvr.Cells[3].Text;
                obj.DeliverySeq = int.Parse(gvr.Cells[4].Text);
                obj.ItemsCategoryID = int.Parse(gvr.Cells[5].Text);
                obj.ItemsSubCategoryID = int.Parse(gvr.Cells[6].Text);
                obj.ItemsID = int.Parse(gvr.Cells[7].Text);
                obj.ReturnQty = txtReturnQty.Text == "" ? 0: int.Parse(txtReturnQty.Text);
                obj.SeqNo = int.Parse(gvr.Cells[14].Text);

                if (obj.ReturnQty > 0)
                    obj.Action = "A";
                else
                {   obj.Action = "N";
                    j++;
                }

                lst.Add(obj);
            }

            if (j == grdDeliveryDetails.Rows.Count)
            {
                updReturnFlag = true;
            }
        } 

        return lst;
    }

    public void ReloadSrchData()
    {
        try
        {
            if(Session["SrchRetCriteria"] != null)
            {
                ATTInvSrchDeliveryOrder objSrchDo = (ATTInvSrchDeliveryOrder)Session["SrchRetCriteria"];
                GridView grdDelivery = (GridView)this.ReturnOrder1.FindControl("grdDelivery");
        
                List<ATTInvDeliveryOrder> lstSrchedDeliveredOrder = new List<ATTInvDeliveryOrder>();
                lstSrchedDeliveredOrder = BLLInvSrchDeliveryOrder.SrchDeliveredOrder(objSrchDo);

                if (lstSrchedDeliveredOrder.Count > 0)
                {
                    grdDelivery.SelectedIndex = -1;
                    grdDelivery.DataSource = lstSrchedDeliveredOrder;
                    grdDelivery.DataBind();

                    Session["lstSrchedDeliveredOrder"] = lstSrchedDeliveredOrder;
                }
                else
                {
                    grdDelivery.DataSource = "";
                    grdDelivery.DataBind();

                }
            }

        }
        catch (Exception)
        {

            throw;
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
        ReturnOrder1.BubbleClick += new EventHandler(ReturnOrder1_BubbleClick);
        ReturnOrder1.BubbleCancelClick += new EventHandler(ReturnOrder1_BubbleCancelClick);
      
    }

    public void ReturnOrder1_BubbleCancelClick(object sender, EventArgs e)
    {
        ClearControls();
        pnlReturnOrder.Visible = false;
    }

    #endregion

    public void ReturnOrder1_BubbleClick(object sender, EventArgs e)
    {

        //TextBox txtOrderNo_rqd = (TextBox)this.ReturnOrder1.FindControl("txtOrderNo_rqd");

        GridView grdDeliveryDetails = (GridView)this.ReturnOrder1.FindControl("grdDeliveryDetails");

        if (grdDeliveryDetails.Rows.Count > 0)
        {

            pnlReturnOrder.Visible = true;

            HiddenField hdnReceivedDate = (HiddenField)this.ReturnOrder1.FindControl("hdnReceivedDate");

            hdnDate.Value = hdnReceivedDate.Value;
        }
    }
}
