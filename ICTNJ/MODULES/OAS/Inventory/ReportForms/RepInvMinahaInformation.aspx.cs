using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
using PCS.REPORT;
using PCS.SECURITY.ATT;
/*
  Author         
  Shanjeev sah  sep 2010 
*/
public partial class MODULES_OAS_Inventory_ReportForms_RepInvMinahaInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlItemSubCategory.Enabled = false;
            this.ddlItem.Enabled = false;

            //Session["ItemsWriteOff"] = new ATTInvItemsWriteOff();
            LoadItemsCategory();


        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {

    }
    private void LoadItemsCategory()
    {

        List<ATTInvItemsCategory> LSTItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
        LSTItemsCategory.Insert(0, new ATTInvItemsCategory(0, "छान्नुहोस्", "", "", ""));
        this.ddlItemCategory.DataTextField = "ItemsCategoryName";
        this.ddlItemCategory.DataValueField = "ItemsCategoryID";
        this.ddlItemCategory.DataSource = LSTItemsCategory;
        this.ddlItemCategory.DataBind();
    }
    protected void ddlItemCategory_SelectedIndexChanged1(object sender, EventArgs e)
    {

        try
        {
            if (ddlItemCategory.SelectedIndex > 0)
            {
                ddlItemSubCategory.Items.Clear();

                List<ATTInvItemSubCategory> lst = BLLInvItemsSubCategory.GetItemSubCategory(int.Parse(ddlItemCategory.SelectedValue.ToString()), "Y", true);
                ddlItemSubCategory.DataSource = lst;
                //lst.Insert(0,new ATTInvItemSubCategory(0,0,"छान्नुहोस्",""));
                ddlItemSubCategory.DataTextField = "ItemsSubCategoryName";
                ddlItemSubCategory.DataValueField = "ItemsSubCategoryID";
                ddlItemSubCategory.DataBind();

                ddlItemSubCategory.Enabled = true;

            }
            else
            {

                ddlItemSubCategory.Enabled = false;

            }

            ddlItemSubCategory.SelectedIndex = -1;
            ddlItem.SelectedIndex = -1;
            ddlItem.Enabled = false;

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlItemSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlItemSubCategory.SelectedIndex > 0)
            {
                this.ddlItem.Enabled = true;
                List<ATTInvOrgItemsKNJ> LSTItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(int.Parse(this.ddlItemCategory.SelectedValue), int.Parse(this.ddlItemSubCategory.SelectedValue));
                //LSTItems.Insert(0, new ATTInvOrgItemsKNJ(0,"छान्नुहोस्"));

                Session["Items"] = LSTItems;
                this.ddlItem.DataSource = LSTItems;
                this.ddlItem.DataTextField = "ItemsDescription";
                this.ddlItem.DataValueField = "PK";
                this.ddlItem.DataBind();
                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस";
                a.Value = "0";
                ddlItem.Items.Insert(0, a);
            }
            else
            {
                this.ddlItem.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        CrystalReport objReport = new CrystalReport();

        objReport.ReportName = Server.MapPath("~") + "/MODULES/OAS/Inventory/Reports/MInhaInformation.rpt";
        objReport.SelectionCriteria = SetCriteria();
       
        objReport.UserID = "OAS_ADMIN";
        objReport.Password = "OAS_ADMIN";

        Session["OASReport"] = objReport;
        Session["OASReportTitle"] = null;
        Session["OASReportTitle"] = "OAS |Minaha Information";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += " var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "OAS", script);
    }
    string SetCriteria()
    {
        List<ATTInvOrgItemsKNJ> LSTSeq = (List<ATTInvOrgItemsKNJ>)Session["Items"];

        string strFormula = "1 = 1";

        if (txtMinahaDate.Text != "")
            strFormula += " AND {vw_inv_org_items_writeoff.writeoff_date}= '" + txtMinahaDate.Text.Trim() + "'";
        if (this.ddlItemCategory.SelectedIndex > 0)
            strFormula += " AND {vw_inv_org_items_writeoff.items_category_id}=" + int.Parse(this.ddlItemCategory.SelectedValue);
        if (this.ddlItemSubCategory.SelectedIndex > 0)
            strFormula += " AND {vw_inv_org_items_writeoff.items_sub_category_id}=" + int.Parse(this.ddlItemSubCategory.SelectedValue);
        if (this.ddlItem.SelectedIndex > 0)
            strFormula += " AND {vw_inv_org_items_writeoff.items_id}=" + LSTSeq[ddlItem.SelectedIndex -1].ItemsID;

        
        
        return strFormula;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {



        this.txtMinahaDate.Text = "";
        this.ddlItemCategory.SelectedIndex = 0;
        this.ddlItemSubCategory.SelectedIndex = 0;
        this.ddlItem.SelectedIndex = 0;
       
    }
}
