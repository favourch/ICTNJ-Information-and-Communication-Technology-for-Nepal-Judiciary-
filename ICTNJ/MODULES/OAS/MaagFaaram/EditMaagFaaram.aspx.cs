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

public partial class MODULES_OAS_MaagFaaram_EditMaagFaaram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (user.MenuList.ContainsKey("5,12,1") == true)
        {
            if (!this.IsPostBack)
            {
                DropDownList ddl = ((DropDownList)appMaagHeadControl.FindControl("ddlOrgUnits"));
                if (((ATTUserLogin)Session["Login_User_Detail"]).UnitID > 0)
                    ddl.SelectedValue = ((ATTUserLogin)Session["Login_User_Detail"]).UnitID.ToString();
                ddl.Enabled = false;
                LoadOrganizationUnits();
                LoadItemsCategory();
                this.pnlMaagDetail.Visible = false;
                Session["MaagDetail"] = new List<ATTMaagFaaramDetail>();

            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }


    void LoadOrganizationUnits()
    {
        try
        {
            this.ddlOrgUnits_Rqd.Items.Add("छान्नुहोस");
            List<ATTOrganizationUnit> lstOrgUnits = BLLOrganizationUnit.GetOrganizationUnits(((ATTUserLogin)Session["Login_User_Detail"]).OrgID, null);
            this.ddlOrgUnits_Rqd.DataSource = lstOrgUnits;
            this.ddlOrgUnits_Rqd.DataTextField = "UNITNAME";
            this.ddlOrgUnits_Rqd.DataValueField = "UNITID";
            this.ddlOrgUnits_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadItemsCategory()
    {
        try
        {
            List<ATTInvItemsCategory> lstItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
            lstItemsCategory.Insert(0, (new ATTInvItemsCategory(0, "छान्नुहोस", "", "", "")));
            Session["ItemsCategory"] = lstItemsCategory;
            this.ddlItemsCategory_Rqd.DataSource = lstItemsCategory;
            this.ddlItemsCategory_Rqd.DataTextField = "ITEMSCATEGORYNAME";
            this.ddlItemsCategory_Rqd.DataValueField = "ITEMSCATEGORYID";
            this.ddlItemsCategory_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void MaagDetails(int? orgID, int? unitID, int? reqNo, string reqDate,string reqPurpose,string issueType, string isApproved, string isIssued)
    {
        if (CheckNullString(isIssued) != "")
        {
            this.lblStatusMessage.Text = "यो मागको रेकर्ड स्टोरबाट इडिट भईसकेको छ ।";
            return;
        }

        if (CheckNullString(isApproved) != "")
        {
            this.lblStatusMessage.Text = "यो मागको आदेश भईसकेको छ ।";
            return;
        }

        ATTMaagFaaramDetail objMaagDet = new ATTMaagFaaramDetail();
        objMaagDet.OrgID = orgID;
        objMaagDet.UnitID = unitID;
        objMaagDet.ReqNo = reqNo;
        List<ATTMaagFaaramDetail> lstMaagDet = BLLMaagFaaramDetail.GetMaagFaaramDetail(objMaagDet);
        this.grdItems.DataSource = lstMaagDet;
        Session["MaagDetail"] = lstMaagDet;
        this.grdItems.DataBind();
        this.grdItems.SelectedIndex = -1;
        if (lstMaagDet.Count > 0)
        {
            this.pnlMaagDetail.Visible = true;
            this.ddlOrgUnits_Rqd.SelectedValue = unitID.ToString();
            this.ddlOrgUnits_Rqd.Enabled = false;
            this.txtReqNo.Text = reqNo.ToString();
            this.txtMaagDate_RDT.Text = reqDate;
            this.txtPurpose.Text = reqPurpose;
            this.rdblstIssueType.SelectedValue = issueType;
        }
        else
            this.pnlMaagDetail.Visible = false;
    }


    protected void ddlItemsCategory_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlItemsSubCategory_Rqd.Items.Clear();
        this.ddlItemsSubCategory_Rqd.DataSource = "";
        this.ddlItemsSubCategory_Rqd.DataBind();
        this.ddlItems_Rqd.Items.Clear();
        this.ddlItems_Rqd.DataSource = "";
        this.ddlItems_Rqd.DataBind();
        if (this.ddlItemsCategory_Rqd.SelectedIndex > 0)
        {
            try
            {
                this.ddlItemsSubCategory_Rqd.Items.Add("छान्नुहोस");
                List<ATTInvItemsCategory> lstItemsCategory = (List<ATTInvItemsCategory>)(Session["ItemsCategory"]);
                this.ddlItemsSubCategory_Rqd.DataSource = lstItemsCategory[this.ddlItemsCategory_Rqd.SelectedIndex].LstItemSubCategory;
                this.ddlItemsSubCategory_Rqd.DataTextField = "ITEMSSUBCATEGORYNAME";
                this.ddlItemsSubCategory_Rqd.DataValueField = "ITEMSSUBCATEGORYID";
                this.ddlItemsSubCategory_Rqd.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }
    protected void ddlItemsSubCategory_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlItems_Rqd.Items.Clear();
        this.ddlItems_Rqd.DataSource = "";
        this.ddlItems_Rqd.DataBind();
        if (this.ddlItemsSubCategory_Rqd.SelectedIndex > 0)
        {
            try
            {
                this.ddlItems_Rqd.Items.Add("छान्नुहोस");
                List<ATTInvOrgItemsPrice> lstItems = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(((ATTUserLogin)Session["Login_User_Detail"]).OrgID, int.Parse(this.ddlItemsCategory_Rqd.SelectedValue), int.Parse(this.ddlItemsSubCategory_Rqd.SelectedValue));
                Session["ItemsList"] = lstItems;
                this.ddlItems_Rqd.DataSource = lstItems;
                this.ddlItems_Rqd.DataTextField = "ITEMNAME";
                this.ddlItems_Rqd.DataValueField = "ITEMSID";
                this.ddlItems_Rqd.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }


    protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[12].Visible = false;
    }
    protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        List<ATTMaagFaaramDetail> lstMaagDet = (List<ATTMaagFaaramDetail>)Session["MaagDetail"];
        try
        {
            if (grdItems.Rows[i].Cells[12].Text == "A")
                lstMaagDet.RemoveAt(i);
            else if (grdItems.Rows[i].Cells[12].Text == "D")
                lstMaagDet[i].Action = "E";
            else
                lstMaagDet[i].Action = "D";
            this.grdItems.DataSource = lstMaagDet;
            this.grdItems.DataBind();
            SetGridColor(12, 14, this.grdItems);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTMaagFaaramDetail> lstMaagDet = (List<ATTMaagFaaramDetail>)Session["MaagDetail"];
        if (lstMaagDet[this.grdItems.SelectedIndex].Action == "D")
        {
            this.grdItems.SelectedIndex = -1;
            return;
        }
        else
        {
            try
            {
                this.ddlItemsCategory_Rqd.SelectedValue = lstMaagDet[this.grdItems.SelectedIndex].ItemsCategoryID.ToString();
                this.ddlItemsCategory_Rqd_SelectedIndexChanged(sender, e);
                this.ddlItemsSubCategory_Rqd.SelectedValue = lstMaagDet[this.grdItems.SelectedIndex].ItemsSubCategoryID.ToString();
                this.ddlItemsSubCategory_Rqd_SelectedIndexChanged(sender, e);
                this.ddlItems_Rqd.SelectedValue = lstMaagDet[this.grdItems.SelectedIndex].ItemsID.ToString();
                this.txtReqQty_Rqd.Text = lstMaagDet[this.grdItems.SelectedIndex].ReqQty.ToString();
                this.txtRemarks.Text = lstMaagDet[this.grdItems.SelectedIndex].Remarks;
                this.grdItems.SelectedRow.Focus();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.ddlOrgUnits_Rqd.SelectedIndex == 0 || this.txtMaagDate_RDT.Text == "____/__/__" || this.ddlItems_Rqd.SelectedIndex == 0 || this.txtReqQty_Rqd.Text == "")
            return;
        double reqNo = 0;
        List<ATTInvOrgItemsPrice> lstItems = (List<ATTInvOrgItemsPrice>)Session["ItemsList"];
        List<ATTMaagFaaramDetail> lstMaagDet = (List<ATTMaagFaaramDetail>)Session["MaagDetail"];

        ATTMaagFaaramDetail objMaagDet = new ATTMaagFaaramDetail(
            ((ATTUserLogin)Session["Login_User_Detail"]).OrgID,
            int.Parse(this.ddlOrgUnits_Rqd.SelectedValue),
            reqNo,
            int.Parse(this.ddlItemsCategory_Rqd.SelectedValue),
            int.Parse(this.ddlItemsSubCategory_Rqd.SelectedValue),
            int.Parse(this.ddlItems_Rqd.SelectedValue),
            int.Parse(this.txtReqQty_Rqd.Text)
        );
        //objMaagDet.UnitID = "";
        objMaagDet.ItemsCategoryName = this.ddlItemsCategory_Rqd.SelectedItem.Text;
        objMaagDet.ItemsSubCategoryName = this.ddlItemsSubCategory_Rqd.SelectedItem.Text;
        objMaagDet.ItemsName = this.ddlItems_Rqd.SelectedItem.Text;
        objMaagDet.Specifications = lstItems[this.ddlItems_Rqd.SelectedIndex - 1].Specifications;
        objMaagDet.ItemsUnitName = lstItems[this.ddlItems_Rqd.SelectedIndex - 1].ItemsUnitName;
        objMaagDet.JiKhaPaNo = lstItems[this.ddlItems_Rqd.SelectedIndex - 1].JiKhaPaNo;
        objMaagDet.Remarks = this.txtRemarks.Text.Trim();
        objMaagDet.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        if (this.grdItems.SelectedIndex > -1)
            if (lstMaagDet[this.grdItems.SelectedIndex].Action == "A")
                objMaagDet.Action = "A";
            else
                objMaagDet.Action = "E";
        else
            objMaagDet.Action = "A";

        bool exists = false;
        if (this.grdItems.SelectedIndex == -1)
        {
            exists = lstMaagDet.Exists
                (
                delegate(ATTMaagFaaramDetail obj)
                {
                    return obj.ItemsCategoryID == int.Parse(this.ddlItemsCategory_Rqd.SelectedValue) &&
                        obj.ItemsSubCategoryID == int.Parse(this.ddlItemsSubCategory_Rqd.SelectedValue) &&
                        obj.ItemsID == int.Parse(this.ddlItems_Rqd.SelectedValue);
                }
                );
        }
        else if (this.grdItems.SelectedIndex > -1)
        {
            int idx = lstMaagDet.FindIndex
                (
            delegate(ATTMaagFaaramDetail obj)
            {
                return obj.ItemsCategoryID == int.Parse(this.ddlItemsCategory_Rqd.SelectedValue) &&
                    obj.ItemsSubCategoryID == int.Parse(this.ddlItemsSubCategory_Rqd.SelectedValue) &&
                    obj.ItemsID == int.Parse(this.ddlItems_Rqd.SelectedValue);
            }
            );

            if (idx > 0)
            {
                if (idx != grdItems.SelectedIndex)
                {
                    exists = false;
                }
            }
        }

        if (exists)
        {
            this.lblStatusMessage.Text = "यो सामानको माग भईसकेको छ |";
            this.programmaticModalPopup.Show();
            return;
        }


        if (this.grdItems.SelectedIndex > -1)
        {
            lstMaagDet[this.grdItems.SelectedIndex].OrgID = objMaagDet.OrgID;
            lstMaagDet[this.grdItems.SelectedIndex].UnitID = objMaagDet.UnitID;
            lstMaagDet[this.grdItems.SelectedIndex].ReqNo = objMaagDet.ReqNo;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsCategoryID = objMaagDet.ItemsCategoryID;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsSubCategoryID = objMaagDet.ItemsSubCategoryID;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsID = objMaagDet.ItemsID;
            lstMaagDet[this.grdItems.SelectedIndex].ReqQty = objMaagDet.ReqQty;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsCategoryName = objMaagDet.ItemsCategoryName;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsSubCategoryName = objMaagDet.ItemsSubCategoryName;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsName = objMaagDet.ItemsName;
            lstMaagDet[this.grdItems.SelectedIndex].Specifications = objMaagDet.Specifications;
            lstMaagDet[this.grdItems.SelectedIndex].ItemsUnitName = objMaagDet.ItemsUnitName;
            lstMaagDet[this.grdItems.SelectedIndex].JiKhaPaNo = objMaagDet.JiKhaPaNo;
            lstMaagDet[this.grdItems.SelectedIndex].Remarks = objMaagDet.Remarks;
            lstMaagDet[this.grdItems.SelectedIndex].Action = objMaagDet.Action;
        }
        else
            lstMaagDet.Add(objMaagDet);

        this.grdItems.SelectedIndex = -1;
        this.grdItems.DataSource = lstMaagDet;
        this.grdItems.DataBind();
        SetGridColor(12, 14, this.grdItems);
        ClearControls(null);

    }

    void SetGridColor(int col, int delCol, GridView grd)
    {
        for (int j = 0; j < grd.Rows.Count; j++)
        {

            if (grd.Rows[j].Cells[col].Text == "D")
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Undo";
                grd.Rows[j].ForeColor = System.Drawing.Color.Red;
            }

            else
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Delete";
                grd.Rows[j].ForeColor = System.Drawing.Color.FromName("#1D2A5B");

            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlOrgUnits_Rqd.SelectedIndex == 0 || this.txtMaagDate_RDT.Text == "____/__/__")
            return;
        double reqNo = 0;
        try
        {
            if (this.txtReqNo.Text != "")
                reqNo = double.Parse(this.txtReqNo.Text.Trim());

            List<ATTMaagFaaramDetail> lstMaagDet = ((List<ATTMaagFaaramDetail>)Session["MaagDetail"]).FindAll(
                                  delegate(ATTMaagFaaramDetail obj)
                                  {
                                      return obj.Action != null;
                                  }
                                  );
            ATTMaagFaaramHead objMaagHead = new ATTMaagFaaramHead(9, int.Parse(this.ddlOrgUnits_Rqd.SelectedValue), reqNo, this.txtMaagDate_RDT.Text, ((ATTUserLogin)Session["Login_User_Detail"]).PID, this.rdblstIssueType.SelectedValue);
            objMaagHead.ReqPurpose = this.txtPurpose.Text.Trim();
            objMaagHead.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            objMaagHead.Action = "E";
            objMaagHead.LstMaagFaaramDetail = lstMaagDet;
            BLLMaagFaaramHead.SaveMaagFaaramHead(objMaagHead);

            this.lblStatusMessage.Text = "Successfully Saved.";
            this.programmaticModalPopup.Show();
            WebForm1_BubbleClickBtn(this, e);
            ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedIndex = -1;
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

    protected void grdMaagDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }

    void ClearControls(int? clearFlag)
    {
        this.ddlItemsCategory_Rqd.SelectedIndex = 0;
        this.ddlItemsSubCategory_Rqd.Items.Clear();
        this.ddlItemsSubCategory_Rqd.DataSource = "";
        this.ddlItemsSubCategory_Rqd.DataBind();
        this.ddlItems_Rqd.Items.Clear();
        this.ddlItems_Rqd.DataSource = "";
        this.ddlItems_Rqd.DataBind();
        this.txtReqQty_Rqd.Text = "";
        this.txtRemarks.Text = "";
        if (clearFlag != null)
        {
            this.ddlOrgUnits_Rqd.SelectedIndex = 0;
            this.txtMaagDate_RDT.Text = "";
            this.txtPurpose.Text = "";
            this.rdblstIssueType.SelectedValue = "P";
            this.grdItems.DataSource = "";
            this.grdItems.DataBind();
            Session["MaagDetail"] = new List<ATTMaagFaaramDetail>();
            
        }

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
        string reqDate = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[6].Text;
        string reqPurpose = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[8].Text;
        string issueType = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[15].Text;
        string isApproved = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[11].Text;
        string isIssued = ((GridView)appMaagHeadControl.FindControl("grdMaagHead")).SelectedRow.Cells[13].Text;
        MaagDetails(orgID, unitID, reqNo,reqDate,reqPurpose,issueType, isApproved, isIssued);
    }


    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
        this.pnlMaagDetail.Visible = false;
        ClearControls(1);
       
    }

    private void WebForm1_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        this.pnlMaagDetail.Visible = false;
        ClearControls(1);
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
