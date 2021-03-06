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
using PCS.SECURITY.ATT;

public partial class MODULES_OAS_Inventory_LookUp_OrganisationItemsPrice : System.Web.UI.Page
{
    int orgID = 9;
    string entryBy = "Suman";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["ItemsPrice"] = new List<ATTInvOrgItemsPrice>();
            LoadCategory();
           
        }
    }

    private void LoadSubCategory(int CategoryID)
    {
        List<ATTInvItemSubCategory> lst = BLLInvItemsSubCategory.GetItemSubCategory(CategoryID,"Y",true);
              

        ddlSubCategory.DataSource = lst;
        ddlSubCategory.DataBind();
    }

    private void LoadCategory()
    {
        List<ATTInvItemsCategory> lst = BLLInvItemsCategory.GetItemCategoryList(null,null);

        ATTInvItemsCategory obj = new ATTInvItemsCategory();
        obj.ItemsCategoryName = "----छान्नुहोस----";
        obj.ItemsCategoryID = -1;
        lst.Insert(0, obj);

        ddlCategory.DataSource = lst;
        ddlCategory.DataBind();


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlCategory.SelectedIndex < 1 && ddlSubCategory.SelectedIndex < 1)
            {
                lblStatusMessage.Text = "Select atleast one Search Criteria";
                programmaticModalPopup.Show();
                return;
            }

            int? catId = null;
            if (ddlCategory.SelectedIndex > 0) catId = int.Parse(ddlCategory.SelectedValue);
            int? subcatId = null;
            if (ddlSubCategory.SelectedIndex > 0) subcatId = int.Parse(ddlSubCategory.SelectedValue);

            List<ATTInvOrgItemsPrice> lst = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(orgID, catId, subcatId,false);

            if (lst.Count > 0)
            {
                Session["ItemsPrice"] = lst;

            }
            else
            {
                Session["ItemsPrice"] = new List<ATTInvOrgItemsPrice>();
            }
            grdInvOrgItemsPrice.DataSource = lst;
            grdInvOrgItemsPrice.DataBind();
        
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
        
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void grdInvOrgItemsPrice_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdInvOrgItemsPrice.EditIndex = e.NewEditIndex;
        grdInvOrgItemsPrice.DataSource = Session["ItemsPrice"];
        grdInvOrgItemsPrice.DataBind();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex > 0)
        {
            LoadSubCategory(int.Parse(ddlCategory.SelectedValue));
        }
        else
        {
            ddlSubCategory.DataSource = "";
            ddlSubCategory.DataBind();

            grdInvOrgItemsPrice.DataSource = "";
            grdInvOrgItemsPrice.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTInvOrgItemsPrice> lst = (List<ATTInvOrgItemsPrice>)Session["ItemsPrice"];

            if (lst.Count == 0)
            {
                return;
            }
            int index = 0;

            foreach (GridViewRow grow in grdInvOrgItemsPrice.Rows)
            {
                double newPrice=0.0;
                try
                {
                    newPrice = double.Parse(((TextBox)grow.FindControl("txtUnitPrice")).Text);
                   
                }
                catch (Exception)
                {
                    ((TextBox)grow.FindControl("txtUnitPrice")).Focus();
                    lblStatusMessage.Text = "Type Valid Unit Price";
                    programmaticModalPopup.Show();
                    return;
                }

                double oldPrice = lst[index].UnitPrice;

                string newFromDate = PCS.COMMON.BLL.BLLDate.getNepDate();
                string oldFromDate = lst[index].FromDate;

                if (newPrice != oldPrice)
                {
                    if (newFromDate == oldFromDate)
                    {
                        lst[index].Action = "E";
                        lst[index].UnitPrice = newPrice;
                    }
                    else
                    {
                        ATTInvOrgItemsPrice obj = new ATTInvOrgItemsPrice();

                        obj.OrgID = lst[index].OrgID;
                        obj.ItemsCategoryID = lst[index].ItemsCategoryID;
                        obj.ItemsSubCategoryID = lst[index].ItemsSubCategoryID;
                        obj.ItemsID = lst[index].ItemsID;
                        obj.FromDate = newFromDate;
                        obj.UnitPrice = newPrice;
                        obj.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
                        obj.Action = "A";

                        lst.Add(obj);
                    }
                }
                lst[index].EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

                index++;
            }

            if (BLLInvOrgItemsPrice.SaveOrgItemsPrice(lst))
            {
                lblStatusMessage.Text = "Information Saved Succesfully";
                programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Information Could Not be Saved";
                programmaticModalPopup.Show();
            }

            ResetSession();
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message.ToString();
            programmaticModalPopup.Show();
        }        

    }

    private void ResetSession()
    {
        ddlCategory.SelectedIndex = -1;
        ddlSubCategory.SelectedIndex = -1;

        grdInvOrgItemsPrice.DataSource = "";
        grdInvOrgItemsPrice.DataBind();


    }
    protected void grdInvOrgItemsPrice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[7].Visible = false;
        
    }
}
