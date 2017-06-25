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

public partial class MODULES_OAS_UserControls_InvDeliveryOrder : System.Web.UI.UserControl
{
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void OkButton_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    
    public void ClearDeliveryControls()
    {
        //txtOrderNo.Text = "";
        txtDeliveryDate_RDT.Text = "";
        txtDeliveryPer_delv.Text = "";
        txtInvoiceNo_delv.Text = "";
        txtReceivedDate_RDT.Text = "";

        //pnlDeliveryOrder.Visible = false;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (i == 0)//to prevent the event below from executing more than 1 time
        {
            i++;
            OnBubbleClick(e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (i == 0)//to prevent the event below from executing more than 1 time
        {
            ClearDeliveryControls();

            i++;
            OnBubbleCancelClick(e);
        }
        
    }


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
        this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
        this.btnCancel.Click += new EventHandler(btnCancel_Click);
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion




   
}
