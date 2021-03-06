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
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_OAS_MaagFaaram_IssueMaagFaaram : System.Web.UI.Page
{
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

        if (user.MenuList.ContainsKey("5,13,1") == true)
        {
            if (!this.IsPostBack)
            {
                this.pnlMaagDetail.Visible = false;
                //LoadOrganizationUnits();
                //LoadItemsCategory();
                //Session["MaagDetail"] = new List<ATTMaagFaaramDetail>();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void MaagDetails(int? orgID, int? unitID, double? reqNo, string isApproved, string isIssued)
    {
        ATTMaagFaaramDetail objMaagDet = new ATTMaagFaaramDetail();
        objMaagDet.OrgID = orgID;
        objMaagDet.UnitID = unitID;
        objMaagDet.ReqNo = reqNo;
        List<ATTMaagFaaramDetail> lstMaagDet = BLLMaagFaaramDetail.GetMaagFaaramDetail(objMaagDet);
        this.grdIssueMaagDetails.DataSource = lstMaagDet;
        this.grdIssueMaagDetails.DataBind();
        this.txtIssueDate_DT.Text = "";

        if (lstMaagDet.Count > 0)
            this.pnlMaagDetail.Visible = true;
        else
            this.pnlMaagDetail.Visible = false;
    }

    protected void grdIssueMaagDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void txtDelQty_TextChanged(object sender, EventArgs e)
    {
        if (sender != null)
        {
            TextBox txtDelQty = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txtDelQty.NamingContainer;
            int? qty = null;

            try
            {
                qty = int.Parse(txtDelQty.Text);
            }
            catch (Exception)
            {
                txtDelQty.Text = "";
            }

            qty = txtDelQty.Text == "" ? 0 : int.Parse(txtDelQty.Text);
            if ((qty + int.Parse(gvRow.Cells[12].Text)) > int.Parse(gvRow.Cells[11].Text))
            {
                txtDelQty.Text = "";
                this.lblStatusMessage.Text = "आदेश परिमाण भन्दा निकासा परिमाण धेरै हुन सक्दैन";
                this.programmaticModalPopup.Show();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTMaagIssueHead objMaagIssueHead = new ATTMaagIssueHead
            (
            int.Parse(this.grdIssueMaagDetails.Rows[0].Cells[1].Text),
            int.Parse(this.grdIssueMaagDetails.Rows[0].Cells[2].Text),
            double.Parse(this.grdIssueMaagDetails.Rows[0].Cells[3].Text),
            0,
            this.txtIssueDate_DT.Text.Trim() == "" ? null : this.txtIssueDate_DT.Text.Trim(),
            ((ATTUserLogin)Session["Login_User_Detail"]).PID,
            double.Parse(hdnRcvdBy.Value.ToString())
            );

        objMaagIssueHead.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        objMaagIssueHead.Action = "A";

        List<ATTMaagIssueDetail> lstMaagIssueDet = new List<ATTMaagIssueDetail>();
        foreach (GridViewRow row in this.grdIssueMaagDetails.Rows)
        {
            int deliverQty = 0;
            TextBox txt=(TextBox)(row.FindControl("txtDelQty"));
            try
            {
                deliverQty = int.Parse(txt.Text);
            }
            catch (Exception)
            {
            }

            if ((deliverQty + int.Parse(row.Cells[12].Text)) > int.Parse(row.Cells[11].Text))
            {
                this.lblStatusMessage.Text = "आदेश परिमाण भन्दा निकासा परिमाण धेरै हुन सक्दैन";
                this.programmaticModalPopup.Show();
                return;

            }

            if (deliverQty > 0)
            {
                ATTMaagIssueDetail objMaagIssueDet = new ATTMaagIssueDetail
                    (
                    int.Parse(row.Cells[1].Text),
                    int.Parse(row.Cells[2].Text),
                    double.Parse(row.Cells[3].Text),
                    0,
                    int.Parse(row.Cells[4].Text),
                    int.Parse(row.Cells[6].Text),
                    int.Parse(row.Cells[8].Text),
                    deliverQty
                    );
                objMaagIssueDet.Action = "A";
                lstMaagIssueDet.Add(objMaagIssueDet);
            }
        }

        if (lstMaagIssueDet.Count == 0)
        {
            this.lblStatusMessage.Text = "No Changes Have Been Made.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                objMaagIssueHead.LstMaagIssueDetail = lstMaagIssueDet;
                BLLMaagIssueHead.SaveMaagIssueHead(objMaagIssueHead);
                this.lblStatusMessage.Text = "Items Successfully Issued.";
                this.programmaticModalPopup.Show();
                WebForm1_BubbleClickBtn(sender, e);
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }


    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    #region UserControl

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        hdnOrgID.Value = "";
        hdnUnitID.Value = "";
        hdnReqNo.Value = "";
        hdnRcvdBy.Value = "";
        hdnOrgID.Value = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[1].Text;
        hdnUnitID.Value = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[3].Text;
        hdnReqNo.Value =((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[5].Text;
        string isApproved = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[11].Text;
        string isIssued = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[13].Text;
        hdnRcvdBy.Value = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[19].Text;
        MaagDetails(int.Parse(hdnOrgID.Value.ToString()), int.Parse(hdnUnitID.Value.ToString()), double.Parse(hdnReqNo.Value.ToString()), isApproved, isIssued);
    }


    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
        this.pnlMaagDetail.Visible = false;
        if (((GridView)appMaagHeadControl.FindControl("grdMaagHead")).Rows.Count < 0)
        {
            this.grdIssueMaagDetails.DataSource = "";
            this.grdIssueMaagDetails.DataBind();
        }
    }

    private void WebForm1_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        //this.grdIssueMaagDetails.DataSource = "";
        //this.grdIssueMaagDetails.DataBind();
        //this.pnlMaagDetail.Visible = false;
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        appMaagHeadControl.BubbleClick += new EventHandler(WebForm1_BubbleClick);
        appMaagHeadControl.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);
        appMaagHeadControl.BubbleClickBtnCancel += new EventHandler(WebForm1_BubbleClickBtnCancel);
    }

    #endregion



}
