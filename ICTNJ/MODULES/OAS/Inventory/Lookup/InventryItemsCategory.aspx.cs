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

using AjaxControlToolkit;

using System.Collections.Generic;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.OAS.DLL;


public partial class MODULES_OAS_Inventry_LookUp_InventryItemsCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (!Page.IsPostBack)
        {
            LoadItemCategoryList();
            Session["ItemCategory"] = new ATTInvItemsCategory();//
        }
        /*   
                if (user.MenuList.ContainsKey("5,5,1") == true)
                {
                    if (!Page.IsPostBack)
                    {
                        // load grid;
                
                    }
                }
                else
                    Response.Redirect("~/MODULES/Login.aspx", true);
        
        */

    }
    void LoadItemCategoryList()
    {
        try
        {
            chkICActive.Checked = true;
            chkISCActive.Checked = true;

            Session["ItemCategory_List"] = BLLInvItemsCategory.GetItemCategoryList(null, null); //data select from database and assign to Session variable
            this.lstItemCategory.DataSource = (List<ATTInvItemsCategory>)Session["ItemCategory_List"];
            this.lstItemCategory.DataValueField = "ItemsCategoryID";
            this.lstItemCategory.DataTextField = "ItemsCategoryName";
            this.lstItemCategory.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtItemCategoryName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Please enter item category name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        ATTInvItemsCategory itemsCategory = (ATTInvItemsCategory)Session["ItemCategory"];

        List<ATTInvItemsCategory> lstall = (List<ATTInvItemsCategory>)Session["ItemCategory_List"];

        if (lstItemCategory.SelectedIndex == -1)
        {

            bool Exists = lstall.Exists(
                                                    delegate(ATTInvItemsCategory ob)
                                                    {
                                                        return ob.ItemsCategoryName == txtItemCategoryName_Rqd.Text;
                                                    }

                                          );

            if (Exists)
            {

                this.lblStatusMessage.Text = "Item category name already exists";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                int count = 0;

                foreach (ATTInvItemSubCategory varNew in itemsCategory.LstItemSubCategory)
                {


                    foreach (ATTInvItemsCategory var in lstall)
                    {

                        int index = var.LstItemSubCategory.FindIndex(
                                                 delegate(ATTInvItemSubCategory ob)
                                                 {
                                                     return ob.ItemsSubCategoryName == varNew.ItemsSubCategoryName;
                                                 }
                                                    );
                        if (index >= 0) count++;

                    }




                }

                if (count > 0)
                {
                    this.lblStatusMessage.Text = "Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
                else
                {
                    itemsCategory.Active = (chkICActive.Checked ? "Y" : "N");
                    itemsCategory.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
                    itemsCategory.ItemsCategoryName = txtItemCategoryName_Rqd.Text;
                    if (lstItemCategory.SelectedIndex >= 0) itemsCategory.Action = "E";
                    else itemsCategory.Action = "A";

                    if (BLLInvItemsCategory.AddUpdateItemCategory(itemsCategory))
                    {
                        this.lblStatusMessage.Text = "Information Saved";
                        this.programmaticModalPopup.Show();
                    }
                    else
                    {
                        this.lblStatusMessage.Text = "Information could not be Saved";
                        this.programmaticModalPopup.Show();
                    }
                }
            }
        }
        else
        {

            bool valid = true;
            int indx = lstall.FindIndex(
                                                 delegate(ATTInvItemsCategory ob)
                                                 {
                                                     return ob.ItemsCategoryName == txtItemCategoryName_Rqd.Text;
                                                 }

                                       );

            if (indx > 0)
            {
                if (indx != lstItemCategory.SelectedIndex)
                {
                    valid = false;
                }
            }
            if (!valid)
            {

                this.lblStatusMessage.Text = "Item category name already exists";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                int count = 0;

                foreach (ATTInvItemSubCategory varNew in itemsCategory.LstItemSubCategory)
                {

                    for (int i = 0; i < lstall.Count; i++)
                    {
                        if (i != lstItemCategory.SelectedIndex)
                        {
                            int index = lstall[i].LstItemSubCategory.FindIndex(
                                                 delegate(ATTInvItemSubCategory ob)
                                                 {
                                                     return ob.ItemsSubCategoryName == varNew.ItemsSubCategoryName;
                                                 }
                                                    );
                            if (index >= 0) count++;
                        }

                    }
                }

                if (count > 0)
                {
                    this.lblStatusMessage.Text = "Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
                else
                {
                    itemsCategory.Active = (chkICActive.Checked ? "Y" : "N");
                    itemsCategory.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
                    itemsCategory.ItemsCategoryName = txtItemCategoryName_Rqd.Text;
                    if (lstItemCategory.SelectedIndex >= 0) itemsCategory.Action = "E";
                    else itemsCategory.Action = "A";

                    if (BLLInvItemsCategory.AddUpdateItemCategory(itemsCategory))
                    {
                        this.lblStatusMessage.Text = "Information Saved";
                        this.programmaticModalPopup.Show();
                    }
                    else
                    {
                        this.lblStatusMessage.Text = "Information could not be Saved";
                        this.programmaticModalPopup.Show();
                    }
                }
            }
        }




        ClearitemCategory();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearitemCategory();


    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }


    protected void btnAddItemSubCategory_Click(object sender, EventArgs e)
    {
        if (this.txSubCategory_Rqd.Text == "")
            return;


        //////////
        ATTInvItemsCategory itemsCategory = (ATTInvItemsCategory)Session["ItemCategory"];

        List<ATTInvItemsCategory> lstall = (List<ATTInvItemsCategory>)Session["ItemCategory_List"];

        if (lstItemCategory.SelectedIndex == -1)
        {

            foreach (ATTInvItemsCategory var in lstall)
            {
                int index = var.LstItemSubCategory.FindIndex(
                                         delegate(ATTInvItemSubCategory ob)
                                         {
                                             return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                         }
                                            );
                if (index >= 0)
                {
                    this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
                else
                {
                    if (grdItemSubCategory.SelectedIndex < 0)
                    {
                        if (itemsCategory.LstItemSubCategory.Exists(
                                            delegate(ATTInvItemSubCategory ob)
                                            {
                                                return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                            }
                                                               ))
                        {
                            this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                            this.programmaticModalPopup.Show();
                            return;
                        }

                    }
                    else
                    {
                        int ind = itemsCategory.LstItemSubCategory.FindIndex(
                                            delegate(ATTInvItemSubCategory ob)
                                            {
                                                return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                            }
                                                               );
                        if (ind >= 0)
                        {
                            if (ind != grdItemSubCategory.SelectedIndex)
                            {
                                this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                                this.programmaticModalPopup.Show();
                                return;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            int index = -1;

            for (int i = 0; i < lstall.Count; i++)
            {
                if (i != lstItemCategory.SelectedIndex)
                {
                    index = lstall[i].LstItemSubCategory.FindIndex(
                                        delegate(ATTInvItemSubCategory ob)
                                        {
                                            return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                        }
                                           );

                }

                if (index >= 0)
                {
                    this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
                else
                {
                    if (grdItemSubCategory.SelectedIndex < 0)
                    {
                        if (itemsCategory.LstItemSubCategory.Exists(
                                            delegate(ATTInvItemSubCategory ob)
                                            {
                                                return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                            }
                                                               ))
                        {
                            this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                            this.programmaticModalPopup.Show();
                            return;
                        }

                    }
                    else
                    {
                        int ind = itemsCategory.LstItemSubCategory.FindIndex(
                                            delegate(ATTInvItemSubCategory ob)
                                            {
                                                return ob.ItemsSubCategoryName == txSubCategory_Rqd.Text;
                                            }
                                                               );
                        if (ind >= 0)
                        {
                            if (ind != grdItemSubCategory.SelectedIndex)
                            {
                                this.lblStatusMessage.Text = "Item SubCategory Already Exists";
                                this.programmaticModalPopup.Show();
                                return;
                            }
                        }
                    }
                }

            }
        }

        //////////






        ATTInvItemsCategory obj = (ATTInvItemsCategory)Session["ItemCategory"];
        if (grdItemSubCategory.SelectedIndex > -1)
        {

            obj.LstItemSubCategory[grdItemSubCategory.SelectedIndex].ItemsSubCategoryName = txSubCategory_Rqd.Text;
            obj.LstItemSubCategory[grdItemSubCategory.SelectedIndex].Active = (chkISCActive.Checked == true ? "Y" : "N");
            obj.LstItemSubCategory[grdItemSubCategory.SelectedIndex].Action = (obj.LstItemSubCategory[grdItemSubCategory.SelectedIndex].Action == "A" ? "A" : "E");
            obj.LstItemSubCategory[grdItemSubCategory.SelectedIndex].EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        }
        else
        {
            ATTInvItemSubCategory ob = new ATTInvItemSubCategory();
            ob.ItemsSubCategoryName = txSubCategory_Rqd.Text;
            ob.Active = chkISCActive.Checked == true ? "Y" : "N";
            ob.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            ob.Action = "A";
            obj.LstItemSubCategory.Add(ob);
            this.grdItemSubCategory.SelectedIndex = -1;
            this.txSubCategory_Rqd.Text = "";
            this.chkISCActive.Checked = true;

        }
        grdItemSubCategory.DataSource = obj.LstItemSubCategory;
        grdItemSubCategory.DataBind();
        grdItemSubCategory.SelectedIndex = -1;
        txSubCategory_Rqd.Text = "";
        this.chkISCActive.Checked = true;

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
    void ClearitemCategory()
    {
        this.lstItemCategory.SelectedIndex = -1;
        this.txtItemCategoryName_Rqd.Text = "";
        this.chkICActive.Checked = true;
        this.grdItemSubCategory.SelectedIndex = -1;
        this.grdItemSubCategory.DataSource = "";
        grdItemSubCategory.DataBind();
        this.txSubCategory_Rqd.Text = "";
        this.chkISCActive.Checked = true;
        this.lblStatus.Text = "";
        LoadItemCategoryList();
        Session["ItemCategory"] = new ATTInvItemsCategory();
    }


    protected void lstItemCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        chkICActive.Checked = true;
        chkISCActive.Checked = true;
        this.grdItemSubCategory.DataSource = "";
        grdItemSubCategory.DataBind();
        //grdItemSubCategory.SelectedIndex = -1;

        List<ATTInvItemsCategory> invItemsCategory = (List<ATTInvItemsCategory>)Session["ItemCategory_List"];


        ATTInvItemsCategory obj = invItemsCategory[this.lstItemCategory.SelectedIndex].CreateDeepCopy();

        Session["ItemCategory"] = obj;

        this.txtItemCategoryName_Rqd.Text = obj.ItemsCategoryName;

        string chk = obj.Active;


        if (chk == "Y")
        {
            this.chkICActive.Checked = true;
        }
        else
        {
            this.chkICActive.Checked = false;
        }


        this.grdItemSubCategory.DataSource = obj.LstItemSubCategory;
        grdItemSubCategory.DataBind();
        this.txSubCategory_Rqd.Text = "";


    }
    protected void grdItemSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {


        ATTInvItemsCategory obj = (ATTInvItemsCategory)Session["ItemCategory"];
        List<ATTInvItemSubCategory> itemsSubCategory = obj.LstItemSubCategory;


        string chkd = itemsSubCategory[grdItemSubCategory.SelectedIndex].Active;
        this.txSubCategory_Rqd.Text = itemsSubCategory[this.grdItemSubCategory.SelectedIndex].ItemsSubCategoryName;
        chkISCActive.Checked = (chkd == "Y") ? true : false;
        itemsSubCategory[grdItemSubCategory.SelectedIndex].Action = (itemsSubCategory[grdItemSubCategory.SelectedIndex].Action == "A" ? "A" : "E");
    }
    protected void grdItemSubCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        ATTInvItemsCategory itemsCategory = (ATTInvItemsCategory)Session["ItemCategory"];
        List<ATTInvItemSubCategory> itemSubCategory = itemsCategory.LstItemSubCategory;

        if ((itemSubCategory[i].Action == null) || (itemSubCategory[i].Action == "E"))
            itemSubCategory[i].Action = "D";
        else if (itemSubCategory[i].Action == "D")
            itemSubCategory[i].Action = "E";
        else if (itemSubCategory[i].Action == "A")
            itemSubCategory.RemoveAt(i);
        this.grdItemSubCategory.DataSource = itemSubCategory;
        this.grdItemSubCategory.DataBind();
        this.grdItemSubCategory.SelectedIndex = -1;
        SetGridColor(4, 6, this.grdItemSubCategory);

    }
    protected void grdItemSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;

    }
}