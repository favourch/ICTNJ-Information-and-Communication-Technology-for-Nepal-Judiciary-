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
using PCS.REPORT;


public partial class MODULES_OAS_ReportForms_StockReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadControls();
        }


        if (!IsPostBack)
        {
            Session["OASRptPo"] = null;
            Session["OASRptPoSelectionCriteria"] = null;
        }
    }

    public void LoadControls()
    {
        try
        {
            LoadOrganisation();
            LoadCategory();         
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public void LoadOrganisation()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrgWithChilds(9);

            grdOrgList.DataSource = lst;
            grdOrgList.DataBind();
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadCategory()
    {
        try
        {
            Session["RptPoCat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["RptPoCat"] != null)
            {
                ddlCategory_cat.DataSource = Session["RptPoCat"];
                ddlCategory_cat.DataTextField = "itemsCategoryName";
                ddlCategory_cat.DataValueField = "itemsCategoryID";
                ddlCategory_cat.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlCategory_cat.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory_cat.SelectedIndex > 0)
            {
                ddlSubCategory_cat.Items.Clear();
                ddlSubCategory_cat.DataSource = BLLInvItemsSubCategory.GetItemSubCategory(int.Parse(ddlCategory_cat.SelectedValue.ToString()), "Y", true);
                ddlSubCategory_cat.DataTextField = "ItemsSubCategoryName";
                ddlSubCategory_cat.DataValueField = "ItemsSubCategoryID";
                ddlSubCategory_cat.DataBind();

                ddlSubCategory_cat.Enabled = true;

            }
            else
            {

                ddlSubCategory_cat.Enabled = false;


            }
            ddlSubCategory_cat.SelectedIndex = -1;
            ddlItems_cat.SelectedIndex = -1;
            ddlItems_cat.Enabled = false;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubCategory_cat.SelectedIndex > 0)
            {
                Session["RptPoItems"] = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(9, int.Parse(ddlCategory_cat.SelectedValue), int.Parse(ddlSubCategory_cat.SelectedValue));

                ddlItems_cat.DataSource = (List<ATTInvOrgItemsPrice>)Session["RptPoItems"];
                ddlItems_cat.DataTextField = "ItemName";
                ddlItems_cat.DataValueField = "ItemsID";
                ddlItems_cat.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlItems_cat.Items.Insert(0, a);


                ddlItems_cat.Enabled = true;
            }
            else
            {
                ddlItems_cat.SelectedIndex = -1;
                ddlItems_cat.Enabled = false;
            }


        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {

            CrystalReport report = new CrystalReport();
            report.SelectionCriteria = SelectionCriteria();

            report.UserID = "OAS_ADMIN";
            report.Password = "OAS_ADMIN";

            report.ReportName = Server.MapPath("~") + "\\MODULES\\OAS\\Inventory\\REPORTS\\StockReport.rpt";
      

            Session["OASReport"] = report;
            Session["OASReportTitle"] = null;
            Session["OASReportTitle"] = "OAS | Stock Report";


            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public string SelectionCriteria()
    {
        try
        {
            string strSelection = " 1=1 ";
            string chkedLst = "";


            if (ddlCategory_cat.SelectedIndex > 0)
                strSelection = " {VW_INV_ITEMS_ORG_PRICES.ITEMS_CATEGORY_ID}=" + ddlCategory_cat.SelectedValue;

            if (ddlSubCategory_cat.SelectedIndex > 0)
                strSelection += " AND {VW_INV_ITEMS_ORG_PRICES.ITEMS_SUB_CATEGORY_ID}=" + ddlSubCategory_cat.SelectedValue;

            if (ddlItems_cat.SelectedIndex > 0)
                strSelection += " AND {VW_INV_ITEMS_ORG_PRICES.ITEMS_ID}=" + ddlItems_cat.SelectedValue;


            chkedLst = GetCheckedOrgID();
 
            if(chkedLst.Length > 0)
                strSelection += " AND {VW_INV_ITEMS_ORG_PRICES.ORG_ID} in" + chkedLst;

            return strSelection;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public string GetCheckedOrgID()
    {
        try
        {
            string chkedLst = "";

            foreach (GridViewRow gvRow in grdOrgList.Rows)
            {
                CheckBox chk = new CheckBox();

                chk =(CheckBox) gvRow.Cells[0].FindControl("chkOrg");

                if (chk.Checked)
                {
                    chkedLst += gvRow.Cells[1].Text + ",";
                }
            }

            if (chkedLst.Length > 0)
            {
                chkedLst = chkedLst.Substring(0, chkedLst.Length - 1);

                chkedLst = "[" + chkedLst + "]";
            }

            return chkedLst;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void grdOrgList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        gvRow.Cells[1].Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            this.LoadOrganisation();

            ddlCategory_cat.SelectedIndex = -1;
            ddlSubCategory_cat.SelectedIndex = -1;
            ddlItems_cat.SelectedIndex = -1;

            ddlSubCategory_cat.Enabled = false;
            ddlItems_cat.Enabled = false;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
}
