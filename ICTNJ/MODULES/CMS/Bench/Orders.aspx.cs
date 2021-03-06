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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using System.Collections.Generic;

public partial class MODULES_CMS_Bench_Orders : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrders();
            chkActive.Checked = true;
        }
    }

    void LoadOrders()
    {
        try
        {
            Session["Orders"] = BLLOrders.GetOrders(null, null, 0);
            List<ATTOrders> OrdersList = (List<ATTOrders>)Session["Orders"];
            this.lstOrders.DataSource = OrdersList;
            this.lstOrders.DataTextField = "OrdersName";
            this.lstOrders.DataValueField = "OrdersID";
            this.lstOrders.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (txtOrders_RQD.Text == "")
        //{
        //    lblStatusMessage.Text = "ञादेश लेख्नुस";
        //    programmaticModalPopup.Show();
        //    return;
        //}

        int Orders = 0;
        if (lstOrders.SelectedIndex != -1)
            Orders = int.Parse(lstOrders.SelectedValue);

        foreach (ListItem lst in lstOrders.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtOrders_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Orders Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTOrders objOrders = new ATTOrders(Orders, this.txtOrders_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objOrders.EntryBy = strUser;
        if (this.lstOrders.SelectedIndex > -1)
            objOrders.Action = "E";
        else
            objOrders.Action = "A";

        try
        {
            List<ATTOrders> ListOrdersList = (List<ATTOrders>)Session["Orders"];
            BLLOrders.SaveOrders(objOrders);
            if (this.lstOrders.SelectedIndex > -1)
            {
                ListOrdersList[this.lstOrders.SelectedIndex].OrdersID = objOrders.OrdersID;
                ListOrdersList[this.lstOrders.SelectedIndex].OrdersName = objOrders.OrdersName;
                ListOrdersList[this.lstOrders.SelectedIndex].Active = objOrders.Active;
            }
            else
                ListOrdersList.Add(objOrders);
            ClearControls();
            this.lstOrders.DataSource = ListOrdersList;
            this.lstOrders.DataBind();
            this.lblStatusMessage.Text = "Ain Type Successfully Saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        this.lstOrders.SelectedIndex = -1;
        this.txtOrders_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTOrders> ListOrders = (List<ATTOrders>)Session["Orders"];
            this.lstOrders.SelectedValue = ListOrders[this.lstOrders.SelectedIndex].OrdersID.ToString();
            this.txtOrders_RQD.Text = ListOrders[this.lstOrders.SelectedIndex].OrdersName;
            this.chkActive.Checked = ListOrders[this.lstOrders.SelectedIndex].Active == "Y" ? true : false;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}


