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

public partial class MODULES_OAS_Inventory_LookUp_InvOrganisationItems : System.Web.UI.Page
{
    int orgID = 9;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["OrgItems"] = new List<ATTInvOrgItems>();
            GetOrgItems();
            LoadItemCategory();
        }
    }

    private void GetOrgItems()
    {
        List<ATTInvOrgItems> lst = BLLInvOrgItems.GetOrgInvItems(orgID, null);
        Session["OrgItems"] = lst;
    }

    private void LoadItemCategory()
    {
        try
        {
            List<ATTInvItemsCategory> lstItemCategory = BLLInvItemsCategory.GetItemCategoryList(null,null);

            ATTInvItemsCategory obj = new ATTInvItemsCategory();

            obj.ItemsCategoryID = -5;
            obj.ItemsCategoryName = "--- छान्नुहोस् ---";

            lstItemCategory.Insert(0, obj);
            Session["Item_ItemCategory"] = lstItemCategory;
            this.DDLItemCategory.DataSource = lstItemCategory;
            this.DDLItemCategory.DataTextField = "ItemsCategoryName";
            this.DDLItemCategory.DataValueField = "ItemsCategoryID";

            this.DDLItemCategory.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (DDLItemCategory.SelectedIndex < 1 && ddlSubCategory.SelectedIndex < 1)
        {
            lblStatusMessage.Text = "Select atleast one Search Criteria";
            programmaticModalPopup.Show();
            return;
        }


        ATTInvItems obj = new ATTInvItems();
        if (DDLItemCategory.SelectedIndex > 0)
        {
            obj.ItemsCategoryID = int.Parse(DDLItemCategory.SelectedValue);
        }
        if (ddlSubCategory.SelectedIndex > 0)
        {
            obj.ItemsSubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
        }

        obj.Active = "Y";

        List<ATTInvItems> LST = BLLInvItems.GetInvItems(obj);

        Session["InvItems"] = LST;

        grdInvOrgItems.DataSource = LST;
        grdInvOrgItems.DataBind();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void grdInvOrgItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int itemsCategoryID = int.Parse(e.Row.Cells[1].Text);
            int itemsSubCategoryID = int.Parse(e.Row.Cells[2].Text);
            int itemsID = int.Parse(e.Row.Cells[3].Text);

            List<ATTInvOrgItems> items = ((List<ATTInvOrgItems>)Session["OrgItems"]).FindAll(
                                                              delegate(ATTInvOrgItems obj)
                                                              {
                                                                  return itemsCategoryID == obj.ItemsCategoryID &&
                                                                   itemsSubCategoryID == obj.ItemsSubCategoryID &&
                                                                   itemsID == obj.ItemsID &&
                                                                   obj.Active == "Y";
                                                              }
                                                      );
            if (items.Count > 0)
            {
                ((CheckBox)e.Row.FindControl("chkItems")).Checked = true;
                e.Row.Cells[9].Text = "Y";
                ((TextBox)e.Row.FindControl("txtJiKhaPaNo")).Text = items[0].PanNo;
                ((TextBox)e.Row.FindControl("txtJiKhaPaNo")).ReadOnly = false;
                e.Row.Cells[11].Text = items[0].PanNo;
            }
            else
            {
                ((CheckBox)e.Row.FindControl("chkItems")).Checked = false;
                e.Row.Cells[9].Text = "N";
                ((TextBox)e.Row.FindControl("txtJiKhaPaNo")).Text = "";
                ((TextBox)e.Row.FindControl("txtJiKhaPaNo")).ReadOnly = true;
                e.Row.Cells[11].Text = "";
            }
        }

        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[11].Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTInvOrgItems> LST = (List<ATTInvOrgItems>)Session["OrgItems"];

            List<ATTInvOrgItems> saveLst = new List<ATTInvOrgItems>();

            foreach (GridViewRow grow in grdInvOrgItems.Rows)
            {
                ATTInvOrgItems obj = new ATTInvOrgItems();

                string check = ((CheckBox)grow.FindControl("chkItems")).Checked.ToString();
                string previous = grow.Cells[9].Text;

                string PreviousJikhaPaNo = grow.Cells[11].Text;
                string NewJiKhaPaNo = ((TextBox)grow.FindControl("txtJiKhaPaNo")).Text;

                if (check == "True" && previous == "N")
                {
                    if (NewJiKhaPaNo == "")
                    {
                        lblStatusMessage.Text = "जि.ख.पा.नं छुट्यो";
                        programmaticModalPopup.Show();
                        return;

                    }

                    obj.OrgID = orgID;
                    obj.ItemsCategoryID = int.Parse(grow.Cells[1].Text);
                    obj.ItemsSubCategoryID = int.Parse(grow.Cells[2].Text);
                    obj.ItemsID = int.Parse(grow.Cells[3].Text);
                    obj.PanNo = NewJiKhaPaNo;
                    obj.Quantity = 0;
                    obj.Active = "Y";
                    obj.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

                    ATTInvOrgItems data = LST.Find(
                                                delegate(ATTInvOrgItems ob)
                                                {
                                                    return obj.OrgID == ob.OrgID &&
                                                            obj.ItemsCategoryID == ob.ItemsCategoryID &&
                                                            obj.ItemsSubCategoryID == ob.ItemsSubCategoryID &&
                                                            obj.ItemsID == ob.ItemsID;
                                                }
                                            );
                    if (data != null)
                    {
                        obj.Action = "E";
                        obj.Quantity = data.Quantity;
                    }
                    else
                    {
                        obj.Action = "A";
                        obj.Quantity = 0;
                    }

                    saveLst.Add(obj);
                }
                else if (check == "False" && previous == "Y")
                {
                    if (NewJiKhaPaNo == "")
                    {
                        lblStatusMessage.Text = "जि.ख.पा.नं छुट्यो";
                        programmaticModalPopup.Show();
                        return;
                    }


                    obj.OrgID = orgID;
                    obj.ItemsCategoryID = int.Parse(grow.Cells[1].Text);
                    obj.ItemsSubCategoryID = int.Parse(grow.Cells[2].Text);
                    obj.ItemsID = int.Parse(grow.Cells[3].Text);
                    obj.PanNo = PreviousJikhaPaNo;
                    //obj.Quantity = 0;
                    obj.Active = "N";
                    obj.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

                    obj.Action = "E";

                    ATTInvOrgItems item = LST.Find(
                                                delegate(ATTInvOrgItems ob)
                                                {
                                                    return obj.OrgID == obj.OrgID &&
                                                           obj.ItemsCategoryID == obj.ItemsCategoryID &&
                                                           obj.ItemsSubCategoryID == obj.ItemsSubCategoryID &&
                                                           obj.ItemsID == obj.ItemsID;

                                                }

                        );
                    obj.Quantity = item.Quantity;

                    saveLst.Add(obj);
                }
                else if (check == "True" && previous == "Y" && PreviousJikhaPaNo != NewJiKhaPaNo)
                {
                    obj.OrgID = orgID;
                    obj.ItemsCategoryID = int.Parse(grow.Cells[1].Text);
                    obj.ItemsSubCategoryID = int.Parse(grow.Cells[2].Text);
                    obj.ItemsID = int.Parse(grow.Cells[3].Text);
                    obj.PanNo = NewJiKhaPaNo;

                    obj.Active = "Y";
                    obj.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
                    obj.Action = "E";
                    ATTInvOrgItems data = LST.Find(
                                                delegate(ATTInvOrgItems ob)
                                                {
                                                    return obj.OrgID == ob.OrgID &&
                                                            obj.ItemsCategoryID == ob.ItemsCategoryID &&
                                                            obj.ItemsSubCategoryID == ob.ItemsSubCategoryID &&
                                                            obj.ItemsID == ob.ItemsID;
                                                }
                                            );
                    obj.Quantity = data.Quantity;


                    saveLst.Add(obj);
                }
            }


            if (BLLInvOrgItems.SaveOrgItems(saveLst))
            {
                lblStatusMessage.Text = "Saved Successfully";
                programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Data Could Not be Saved";
                programmaticModalPopup.Show();
            }

            DDLItemCategory.SelectedIndex = -1;
            ddlSubCategory.DataSource = "";
            ddlSubCategory.DataBind();
            ddlSubCategory.SelectedIndex = -1;
            grdInvOrgItems.DataSource = null;
            grdInvOrgItems.DataBind();
            GetOrgItems();

        }
        catch (Exception)
        {

            throw;
        }




    }


    protected void chkItems_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow grow in grdInvOrgItems.Rows)
        {
            bool chkd = ((CheckBox)grow.FindControl("chkItems")).Checked;
            if (!chkd)
            {
                ((TextBox)grow.FindControl("txtJiKhaPaNo")).Text = "";
            }
            else
            {
                if (((TextBox)grow.FindControl("txtJiKhaPaNo")).Text == "")
                {
                    ((TextBox)grow.FindControl("txtJiKhaPaNo")).Text = grow.Cells[11].Text;
                }
            }
            ((TextBox)grow.FindControl("txtJiKhaPaNo")).ReadOnly = !chkd;
        }
    }
    protected void DDLItemCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DDLItemCategory.SelectedIndex > 0)
        {
            LoadSubCategory(int.Parse(DDLItemCategory.SelectedValue));
        }
        else
        {
            ddlSubCategory.DataSource = "";
            ddlSubCategory.DataBind();

            grdInvOrgItems.DataSource = "";
            grdInvOrgItems.DataBind();
        }
    }
    private void LoadSubCategory(int CategoryID)
    {
        List<ATTInvItemSubCategory> lst = BLLInvItemsSubCategory.GetItemSubCategory(CategoryID, "Y", true);


        ddlSubCategory.DataSource = lst;
        ddlSubCategory.DataBind();
    }
}
