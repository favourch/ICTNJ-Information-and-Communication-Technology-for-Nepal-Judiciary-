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

using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.REPORT;
using PCS.SECURITY.ATT;



public partial class MODULES_OAS_Inventory_ReportForms_InvItemsTransfered : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            LoadCategory();
        }
    }
    private void LoadCategory()
    {
        try
        {
            Session["Cat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["Cat"] != null)
            {
                ddlCategory.DataSource = Session["Cat"];
                ddlCategory.DataTextField = "itemsCategoryName";
                ddlCategory.DataValueField = "itemsCategoryID";
                ddlCategory.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlCategory.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                ddlSubCategory.Items.Clear();
                List<ATTInvItemSubCategory> lst = GetItemSubCategory(int.Parse(ddlCategory.SelectedValue.ToString()));
                Session["SubCat"] = lst;

                ddlSubCategory.DataSource = lst;
                ddlSubCategory.DataTextField = "ItemsSubCategoryName";
                ddlSubCategory.DataValueField = "ItemsSubCategoryID";
                ddlSubCategory.DataBind();
            }
            else
            {

                ddlSubCategory.DataSource = "";
                ddlSubCategory.DataBind();


            }

            ddlItems.DataSource = "";
            ddlItems.DataBind();
            ddlSubCategory.SelectedIndex = -1;
            ddlItems.SelectedIndex = -1;

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    private List<ATTInvItemSubCategory> GetItemSubCategory(int CatId)
    {
        return BLLInvItemsSubCategory.GetItemSubCategory(CatId, "Y", true);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlSubCategory.SelectedIndex > 0)
            {

                LoadDDLItems();
            }
            else
            {
                ddlItems.SelectedIndex = -1;
                ddlItems.DataSource = "";
                ddlItems.DataBind();

            }

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    private void LoadDDLItems()
    {
        ATTInvOrgItemsPrice obj = new ATTInvOrgItemsPrice();
        obj.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        obj.ItemsCategoryID = int.Parse(ddlCategory.SelectedValue);
        obj.ItemsSubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
        obj.Quantity = 0;

        Session["Items"] = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(obj);

        ddlItems.DataSource = (List<ATTInvOrgItemsPrice>)Session["Items"];
        ddlItems.DataTextField = "ItemNameWithQty";
        ddlItems.DataValueField = "ItemsID";
        ddlItems.DataBind();

        ListItem a = new ListItem();
        a.Selected = true;
        a.Text = "----छान्नुहोस----";
        a.Value = "0";
        ddlItems.Items.Insert(0, a);
    }
    protected void btnGenereate_Click(object sender, EventArgs e)
    {
        string orgName = "Supreme Court";
        string orgAddress = "Ramshah Path,Kathmandu";
        string reportName = "OAS | Inventory Item Transfer Details";
        #region date
        //if (txtFromDate.Text != "" || txtToDate.Text != "")
        //{
        //    if ((txtFromDate.Text).CompareTo(txtToDate.Text) > 0)
        //    {
        //        this.lblStatusMessage.Text = "From Date must be smaller then ToDate";
        //        this.programmaticModalPopup.Show();
        //        return;
        //    }
        //}
        #endregion
        CrystalReport objReport = new CrystalReport();
        objReport.SelectionCriteria=SetCriteria();
        objReport.UserID = "OAS_OWNER";
        objReport.Password = "OAS_OWNER";

        objReport.ReportName = Server.MapPath("~") +"/MODULES/OAS/Inventory/Reports/InvItemsTransfered.rpt";

        objReport.ParamList.Add(new ReportParameter("orgName", orgName));
        objReport.ParamList.Add(new ReportParameter("orgAddress", orgAddress));
        objReport.ParamList.Add(new ReportParameter("ReportName", reportName));

        Session["OASReport"] = objReport;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
        ClearControls();
    }
    private string SetCriteria()
    {
        List<ATTInvOrgItemsPrice> LSTSeq = (List<ATTInvOrgItemsPrice>)Session["Items"];

        string strFormula = "1 = 1";
        if (this.ddlCategory.SelectedIndex > 0)
            strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.ITEMS_CATEGORY_ID}=" + int.Parse(this.ddlCategory.SelectedValue);
        if (this.ddlSubCategory.SelectedIndex > 0)
            strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.ITEMS_SUB_CATEGORY_ID}=" + int.Parse(this.ddlSubCategory.SelectedValue);
        if (this.ddlItems.SelectedIndex > 0)
            strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.ITEMS_ID}=" + LSTSeq[ddlItems.SelectedIndex - 1].ItemsID;
        //if (this.txtFromDate.Text != "")
        //    strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.FROM_DATE}= '" + txtFromDate.Text.Trim() + "'";
        //if (this.txtToDate.Text != "")
        //    strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.TO_DATE}= '" + txtToDate.Text.Trim() + "'";
        if (this.rdoItemType.SelectedIndex == 1)
        {
            strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER.ITEMS_TYPE_ID}=" + 1;
        }
        else if (this.rdoItemType.SelectedIndex == 2)
        {
            strFormula += " AND {VW_INV_ORG_ITEMS_TRANSFER_KNJ.ITEMS_TYPE_ID}=" + 2;
        }
        return strFormula;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    private void ClearControls()
    {
        ddlCategory.SelectedIndex = -1;
        ddlSubCategory.SelectedIndex = -1;
        ddlItems.SelectedIndex = -1;
        foreach (ListItem lst in rdoItemType.Items)
        {
            if (lst.Selected==true)
            {
                lst.Selected = false;
            }
        }
        ddlSubCategory.DataSource = "";
        ddlSubCategory.DataBind();
        ddlItems.DataSource = "";
        ddlItems.DataBind();
    }
}
