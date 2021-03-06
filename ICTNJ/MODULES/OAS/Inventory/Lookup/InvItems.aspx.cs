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
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_OAS_Inventory_Forms_InvItems : System.Web.UI.Page
{
    new public ATTUserLogin User
    {
        get { return (ATTUserLogin)Session["Login_User_Detail"]; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadItemCategory();
            LoadItemType();
            LoadItemUnit();
            this.chkActive.Checked = true;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    private void LoadItemCategory()
    {
        try
        {
            List<ATTInvItemsCategory> lstItemCategory = BLLInvItemsCategory.GetItemCategory(null,"Y","Y",true);
            Session["Item_ItemCategory"] = lstItemCategory;
            this.DDLItemCategory_Rqd.DataSource = lstItemCategory;
            this.DDLItemCategory_Rqd.DataTextField = "ItemsCategoryName";
            this.DDLItemCategory_Rqd.DataValueField = "ItemsCategoryID";
            this.DDLItemCategory_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    private void LoadItemType()
    {
        try
        {
            List<ATTInvItemType> lstItemType = BLLInvItemType.GetItemType(null, "Y");
            lstItemType.Insert(0, new ATTInvItemType(0, "छान्नुहोस", ""));
            Session["Item_ItemType"] = lstItemType;
            this.DDLItemType_Rqd.DataSource = lstItemType;
            this.DDLItemType_Rqd.DataTextField = "ItemsTypeName";
            this.DDLItemType_Rqd.DataValueField = "ItemsTypeID";

            this.DDLItemType_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    private void LoadItemUnit()
    {
        try
        {
            List<ATTInvItemUnit> lstItemUnit = BLLInvItemUnit.GetItemList(null, "Y", true);
            Session["Item_ItemUnit"] = lstItemUnit;
            this.DDLItemUnit_Rqd.DataSource = lstItemUnit;
            this.DDLItemUnit_Rqd.DataTextField = "ItemUnitName";
            this.DDLItemUnit_Rqd.DataValueField = "ItemUnitID";
            this.DDLItemUnit_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClearControls(2);
            if (this.DDLItemCategory_Rqd.SelectedIndex > 0)
            {

                List<ATTInvItemsCategory> lstItemsCategory = (List<ATTInvItemsCategory>)Session["Item_ItemCategory"];
                DDLItemsSubCategory_Rqd.DataSource = lstItemsCategory[this.DDLItemCategory_Rqd.SelectedIndex].LstItemSubCategory;
                //List<ATTInvItemsSubCategory> lstitemsSubCategory = BLLInvItemsSubCategory.GetItemSubCategory(lstItemsCategory[DDLItemCategory_Rqd.SelectedIndex].ItemCategoryID, "Y", true);
                //Session["Items_SubCategory"] = lstitemsSubCategory;
                //DDLItemsSubCategory_Rqd.DataSource = lstitemsSubCategory;
                DDLItemsSubCategory_Rqd.DataTextField = "ItemsSubCategoryName";
                DDLItemsSubCategory_Rqd.DataValueField = "ItemsSubCategoryID";
                DDLItemsSubCategory_Rqd.DataBind();
            }
            //ClearControls();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void lstInvItem_SelectedIndexChanged(object sender, EventArgs e)
    {        
        try
        {
            List<ATTInvItems> lstitems = (List<ATTInvItems>)Session["Items"];
            this.txtItemName_Rqd.Text = lstitems[lstInvItem.SelectedIndex].ItemsName;
            this.txtItemShortName.Text = lstitems[lstInvItem.SelectedIndex].ItemsShortName;
            this.DDLItemCategory_Rqd.SelectedValue = lstitems[lstInvItem.SelectedIndex].ItemsCategoryID.ToString();
            this.DDLItemCategory_Rqd.Enabled = false;
            this.DDLItemsSubCategory_Rqd.SelectedValue = lstitems[lstInvItem.SelectedIndex].ItemsSubCategoryID.ToString();
            this.DDLItemsSubCategory_Rqd.Enabled = false;
            this.DDLItemType_Rqd.SelectedValue = lstitems[lstInvItem.SelectedIndex].ItemsTypeID.ToString();
            this.DDLItemUnit_Rqd.SelectedValue = lstitems[lstInvItem.SelectedIndex].ItemsUnitID.ToString();
            this.txtItemCD.Text = lstitems[lstInvItem.SelectedIndex].ItemsCD;
            this.chkActive.Checked = lstitems[lstInvItem.SelectedIndex].Active == "Y" ? true : false;
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    private void ClearControls(int intFlag)
    {
        /*
         * 1-Clear All Controls - Submit
         * 2-Clear Controls according to Category
         * 3-Clear Controls according to Sub-Category
         * 4-Clear controls after Cancel */

        this.txtItemName_Rqd.Text = "";
        this.txtItemShortName.Text = "";
        this.txtItemCD.Text = "";        
        lblStatus.Text = "";
        chkActive.Checked = true;
        this.DDLItemType_Rqd.SelectedIndex = 0;
        this.DDLItemUnit_Rqd.SelectedIndex = 0;
        this.DDLItemCategory_Rqd.Enabled = true;
        this.DDLItemsSubCategory_Rqd.Enabled = true;
        lstInvItem.SelectedIndex = -1;

        if (intFlag != 1)
        {
            //this.lstInvItem.DataSource = "";
            //this.lstInvItem.DataBind();
            this.lstInvItem.Items.Clear();
            if (intFlag == 2)
            {
                this.DDLItemsSubCategory_Rqd.DataSource = "";
                this.DDLItemsSubCategory_Rqd.DataBind();
            }
            if (intFlag == 4)
            {
                this.DDLItemCategory_Rqd.SelectedIndex = 0;
                this.DDLItemsSubCategory_Rqd.DataSource = "";
                this.DDLItemsSubCategory_Rqd.DataBind();
            }

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTInvItems> lst = (List<ATTInvItems>)Session["Items"];
            string active;
            active = chkActive.Checked ? "Y" : "N";
            List<ATTInvItems> lstitems = new List<ATTInvItems>();       
            ATTInvItems objitem = new ATTInvItems(
                                       int.Parse((DDLItemCategory_Rqd.SelectedValue).ToString()),
                                       int.Parse((DDLItemsSubCategory_Rqd.SelectedValue).ToString()),
                                       0,
                                       txtItemCD.Text,
                                       txtItemName_Rqd.Text,
                                       txtItemShortName.Text,
                                       int.Parse((DDLItemType_Rqd.SelectedValue).ToString()),
                                       int.Parse((DDLItemUnit_Rqd.SelectedValue).ToString()),
                                       active,
                                       this.User.UserName); //"sj");
            ObjectValidation OV = BLLInvItems.Validate(objitem);
            if (OV.IsValid == false)
            {
                this.lblStatus.Text = OV.ErrorMessage;
                return;
            }

            if (lstInvItem.SelectedIndex < 0)
            {
                objitem.Action = "A";
            }
            else
            {
                objitem.Action = "E";
                objitem.ItemsID = int.Parse((lstInvItem.SelectedValue).ToString());
            }
            lstitems.Add(objitem);
            BLLInvItems.SaveItems(lstitems);
            if (lstInvItem.SelectedIndex < 0 && objitem.Active == "Y")
            {
                lst.Add(objitem);
            }
            else
            {
                lst[this.lstInvItem.SelectedIndex] = objitem;
            }
            this.lblStatusMessage.Text = "Items successfully saved.";
            this.programmaticModalPopup.Show();            
            lstInvItem.DataSource = lst;
            lstInvItem.DataTextField = "ItemsName";
            lstInvItem.DataValueField = "ItemsID";
            lstInvItem.DataBind();            
            ClearControls(1);
        }
        catch(Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }                              
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(4);        
    }

    protected void DDLItemsSubCategory_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearControls(3);
        try
        {
            List<ATTInvItemsCategory> lstItemsCategory = (List<ATTInvItemsCategory>)Session["Item_ItemCategory"];
            ATTInvItems obj = new ATTInvItems();
            obj.ItemsCategoryID = lstItemsCategory[DDLItemCategory_Rqd.SelectedIndex].ItemsCategoryID;
            obj.ItemsSubCategoryID = int.Parse((DDLItemsSubCategory_Rqd.SelectedValue).ToString());
            List<ATTInvItems> lstItems = BLLInvItems.GetInvItems(obj);
            Session["Items"] = lstItems;
            lstInvItem.DataSource = lstItems;
            lstInvItem.DataTextField = "ItemsName";
            lstInvItem.DataValueField = "ItemsID";
            lstInvItem.DataBind();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void DDLItemType_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
