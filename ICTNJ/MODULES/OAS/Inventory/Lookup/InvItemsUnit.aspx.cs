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
using PCS.OAS.BLL;
using PCS.OAS.ATT;
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;

public partial class MODULES_OAS_Inventory_LookUp_InvItemsUnit : System.Web.UI.Page
{
    
    new public ATTUserLogin User
    {
        get { return (ATTUserLogin)Session["Login_User_Detail"]; }        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadItems();
            chkActive.Checked = true;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    private void LoadItems()
    {
        try
        {
            List<ATTInvItemUnit> lstItem = BLLInvItemUnit.GetItemList(null,null,false);
            Session["Item_ItemList"] = lstItem;
            this.lstInvItems.DataSource = lstItem;
            this.lstInvItems.DataTextField = "ItemUnitName";
            this.lstInvItems.DataValueField = "ItemUnitID";

            this.lstInvItems.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strActive;
        strActive = chkActive.Checked ? "Y" : "N";
        ATTInvItemUnit itemObj = new ATTInvItemUnit
                                                (
                                                    0,
                                                    this.txtInvItem_Rqd.Text,
                                                    strActive,
                                                    this.User.UserName
                                                );

        ObjectValidation OV = BLLInvItemUnit.Validate(itemObj);
        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTInvItemUnit> lstItem = (List<ATTInvItemUnit>)Session["Item_ItemList"];        

        try
        {
            if (this.lstInvItems.SelectedIndex < 0)
                itemObj.Action = "A";
            else
            {
                itemObj.Action = "E";
                itemObj.ItemUnitID = int.Parse(this.lstInvItems.SelectedValue);
            }

            BLLInvItemUnit.SaveItemUnit(itemObj);

            if (this.lstInvItems.SelectedIndex < 0)
                lstItem.Add(itemObj);
            else
                lstItem[this.lstInvItems.SelectedIndex] = itemObj;

            this.lblStatusMessage.Text = "Items successfully saved.";
            this.programmaticModalPopup.Show();

            this.lstInvItems.DataSource = lstItem;
            this.lstInvItems.DataTextField = "ItemUnitName";
            this.lstInvItems.DataValueField = "ItemUnitID";

            this.lstInvItems.DataBind();

            this.ClearInvItemUnitControl();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void ClearInvItemUnitControl()
    {
        this.txtInvItem_Rqd.Text = "";
        this.lstInvItems.SelectedIndex = -1;
        this.lblStatus.Text = "";
        chkActive.Checked = true;
    }


    protected void lstInvItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTInvItemUnit> lst = (List<ATTInvItemUnit>)Session["Item_ItemList"];       
        //ATTInvItemUnit item = lst.Find
        //                            (
        //                                delegate(ATTInvItemUnit au)
        //                                {
        //                                    return au.ItemID == int.Parse(this.lstInvItems.SelectedValue);
        //                                }
        //                             );

        this.txtInvItem_Rqd.Text = lst[this.lstInvItems.SelectedIndex].ItemUnitName;
        this.chkActive.Checked = (lst[this.lstInvItems.SelectedIndex].Active == "Y" ? true : false);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearInvItemUnitControl();
    }
}
