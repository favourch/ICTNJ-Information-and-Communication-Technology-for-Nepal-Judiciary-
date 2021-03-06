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
/*
  Author         
  Shanjeev sah   
*/

public partial class MODULES_OAS_Inventry_Forms_ApproveMinaha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (!IsPostBack)
        {
            this.chkApprove.Checked = true;
            LoadWriteOffDetails();
        }

    }

    private void LoadWriteOffDetails()
    {
        int orgid = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        List<ATTInvItemsWriteOff> LSTWriteOffData = BLLInvItemsWiiteOffAprove.GetWriteOffDateDetails(orgid, null, null);
        Session["WriteOffDateDetails"] = LSTWriteOffData;
        this.grdMinahaDetails.DataSource = LSTWriteOffData;
        this.grdMinahaDetails.DataBind();
    }
    
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdMinahaDetails.SelectedIndex > -1)
        {
            List<ATTInvItemsWriteOff> LSTAucDateDetails = (List<ATTInvItemsWriteOff>)Session["WriteOffDateDetails"];
            ATTInvItemsWriteOff objData = new ATTInvItemsWriteOff();
            objData.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            objData.WriteOffSEQ = LSTAucDateDetails[this.grdMinahaDetails.SelectedIndex].WriteOffSEQ;
            objData.WriteoffDate = LSTAucDateDetails[this.grdMinahaDetails.SelectedIndex].WriteoffDate;
            objData.AppBy = ((ATTUserLogin)Session["Login_User_Detail"]).PID;
            if (this.txtCurrentDate.Text != "")
            {
                objData.AppDate = this.txtCurrentDate.Text;
            }
            if (this.chkApprove.Checked == true)
            {
                objData.AppYesNo = "Y";
            }
            else
            {
                objData.AppYesNo = "N";
            }

            objData.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

            objData.Action = "App";
            objData.LstItemsWriteOffDT = (List<ATTInvItemsWriteOffDT>)Session["MinahaDetails"];

            if (BLLInvItemsWriteOff.AddUpdateItemsWriteOff(objData))
            {
                this.lblStatusMessage.Text = "Auction Details Approved Successfully";
                this.programmaticModalPopup.Show();
            }
            ClearControls("submit");
        }
        else
        {
            this.lblStatusMessage.Text = "**र्कपया मिनाहा मिति छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
    }

    private void ClearControls(string p)
    {
        if (p == "cancel")
        {
            this.grdMinahaDetails.SelectedIndex = -1;
            this.grdApprove.SelectedIndex = -1;
            this.grdApprove.DataSource = null;
            this.grdApprove.DataBind();
            this.chkApprove.Checked = true;
            this.txtCurrentDate.Text = "";
        }
        if (p == "submit")
        {
            this.grdMinahaDetails.SelectedIndex = -1;
            this.grdApprove.SelectedIndex = -1;
            this.grdApprove.DataSource = null;
            this.grdApprove.DataBind();
            this.chkApprove.Checked = true;
            this.txtCurrentDate.Text = "";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("cancel");
    }
    protected void grdMinahaDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        string MinahaDate = "";
        //string AppYesNo = "";
        List<ATTInvItemsWriteOff> LSTWriteOffDate = (List<ATTInvItemsWriteOff>)Session["WriteOffDateDetails"];
        MinahaDate = LSTWriteOffDate[this.grdMinahaDetails.SelectedIndex].WriteoffDate;
        //AppYesNo = LSTAuctionDate[this.grdAuctionDateDetails.SelectedIndex].App_Yes_No;
        List<ATTInvItemsWriteOffDT> LSTMinahaDetails = BLLInvItemsWriteOffDT.GetWriteOffDetailsDT(MinahaDate);
        Session["MinahaDetails"] = LSTMinahaDetails;
        this.grdApprove.DataSource = LSTMinahaDetails;
        this.grdApprove.DataBind();
    }
    protected void grdApprove_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[3].Visible=false;
        e.Row.Cells[5].Visible=false;
        e.Row.Cells[7].Visible=false;
    }
}
