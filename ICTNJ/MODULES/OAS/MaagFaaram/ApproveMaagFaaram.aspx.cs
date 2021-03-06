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

public partial class MODULES_OAS_MaagFaaram_ApproveMaagFaaram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (user.MenuList.ContainsKey("5,11,1") == true)
        {
            if (!this.IsPostBack)
            {
                this.pnlMaagDetail.Visible = false;
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void MaagDetails(int? orgID, int? unitID, int? reqNo,string isApproved,string appDate,string isIssued)
    {
        if (CheckNullString(isIssued) != "")
        {
            this.lblStatusMessage.Text = "यो मागको रेकर्ड स्टोरबाट इडिट भईसकेको छ ।";
            return;
        }
        ATTMaagFaaramDetail objMaagDet = new ATTMaagFaaramDetail();
        objMaagDet.OrgID = orgID;
        objMaagDet.UnitID = unitID;
        objMaagDet.ReqNo = reqNo;
        List<ATTMaagFaaramDetail> lstMaagDet = BLLMaagFaaramDetail.GetMaagFaaramDetail(objMaagDet);
        this.grdApproveMaagDetails.DataSource = lstMaagDet;
        this.grdApproveMaagDetails.DataBind();
        if (CheckNullString(isApproved) != "")
        {
            this.rdblstAppYesNo.SelectedValue = isApproved;
            this.txtAppDate_DT.Text = appDate;
        }
        
        if (lstMaagDet.Count > 0)
            this.pnlMaagDetail.Visible = true;
        else
            this.pnlMaagDetail.Visible = false;
    }

    protected void grdApproveMaagDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void txtAppQty_TextChanged(object sender, EventArgs e)
    {
        if (sender != null)
        {
            TextBox txtAppQty = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txtAppQty.NamingContainer;
            int? qty = null;

            try
            {
                qty = int.Parse(txtAppQty.Text);
            }
            catch (Exception)
            {
                txtAppQty.Text = "";
            }

            qty = txtAppQty.Text == "" ? 0 : int.Parse(txtAppQty.Text);
            if (qty > int.Parse(gvRow.Cells[10].Text))
            {
                txtAppQty.Text = "";
                this.lblStatusMessage.Text = "माग परिमाण भन्दा आदेश परिमाण धेरै हुन सक्दैन";
                this.programmaticModalPopup.Show();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdApproveMaagDetails.Rows.Count < 0)
            return;
        try
        {
            ATTMaagFaaramHead objMaagHead = new ATTMaagFaaramHead
                (
                int.Parse(this.grdApproveMaagDetails.Rows[0].Cells[1].Text),
                int.Parse(this.grdApproveMaagDetails.Rows[0].Cells[2].Text),
                double.Parse(this.grdApproveMaagDetails.Rows[0].Cells[3].Text),
                ((ATTUserLogin)Session["Login_User_Detail"]).PID,
                (this.txtAppDate_DT.Text=="")?null: this.txtAppDate_DT.Text.Trim(),
                this.rdblstAppYesNo.SelectedValue,""
                );
            objMaagHead.Action = "APP";
            List<ATTMaagFaaramDetail> lstMaagDet = new List<ATTMaagFaaramDetail>();
            foreach (GridViewRow row in this.grdApproveMaagDetails.Rows)
            {
                ATTMaagFaaramDetail objMaagDet = new ATTMaagFaaramDetail
                    (
                    int.Parse(row.Cells[1].Text),
                    int.Parse(row.Cells[2].Text),
                    double.Parse(row.Cells[3].Text),
                    int.Parse(row.Cells[4].Text),
                    int.Parse(row.Cells[6].Text),
                    int.Parse(row.Cells[8].Text)
                    );
                TextBox txt = (TextBox)row.FindControl("txtAppQty");
                try
                {
                    objMaagDet.AppQty = int.Parse(txt.Text.Trim());
                }
                catch (Exception)
                {
                    objMaagDet.AppQty = int.Parse(row.Cells[10].Text);
                }

                if (objMaagDet.AppQty > int.Parse(row.Cells[10].Text))
                {
                    this.lblStatusMessage.Text = "माग परिमाण भन्दा आदेश परिमाण धेरै हुन सक्दैन";
                    this.programmaticModalPopup.Show();
                    return;
                }
                lstMaagDet.Add(objMaagDet);

            }
            objMaagHead.LstMaagFaaramDetail = lstMaagDet;
            BLLMaagFaaramHead.ApproveIssueMaag(objMaagHead);
            this.lblStatusMessage.Text = "Successfully Approved";
            this.programmaticModalPopup.Show();
            //appMaagHeadControl.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);
            WebForm1_BubbleClickBtn(this, e);
            ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedIndex = -1;


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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
        int? orgID = int.Parse(((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[1].Text);
        int? unitID = int.Parse(((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[3].Text);
        int? reqNo = int.Parse(((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[5].Text);
        string appDate = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[10].Text;
        string isApproved = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[11].Text;
        string isIssued = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[13].Text;
        MaagDetails(orgID, unitID, reqNo, isApproved, appDate,isIssued);
    }


    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
        this.pnlMaagDetail.Visible = false;
        if (((GridView)appMaagHeadControl.FindControl("grdMaagHead")).Rows.Count < 0)
        {
            this.grdApproveMaagDetails.DataSource = "";
            this.grdApproveMaagDetails.DataBind();
        }
    }

    private void WebForm1_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        this.grdApproveMaagDetails.DataSource = "";
        this.grdApproveMaagDetails.DataBind();
        this.pnlMaagDetail.Visible = false;
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
