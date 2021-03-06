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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Inventory_Forms_AuctionDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        //Response.Expires = -1500;
        //Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //Session["OrgID"] = user.OrgID;
        //if (user.MenuList.ContainsKey("3,32,1") == true)
        //{
            //Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                Session["AuctionList"] = new List<ATTAuctionDetails>();
                this.ddlItemSubCategory.Enabled = false;
                this.ddlItem.Enabled = false;
                LoadItemsCategory();
            }
        //}

        //else
        //{
        //    Response.Redirect("~/MODULES/Login.aspx", true);
        //}
    }

    private void LoadItemsCategory()
    {
        List<ATTInvItemsCategory> LSTItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
        LSTItemsCategory.Insert(0,new ATTInvItemsCategory(0,"छान्नुहोस्"));
        this.ddlItemCategory.DataTextField = "ItemsCategoryName";
        this.ddlItemCategory.DataValueField = "ItemsCategoryID";
        this.ddlItemCategory.DataSource = LSTItemsCategory;
        this.ddlItemCategory.DataBind();
    }

    //private void LoadItemsSubCategory()
    //{
    //    List<ATTInvItemSubCategory> LSTItemsSubCategory = BLLInvItemsSubCategory.GetItemSubCategoryList(int.Parse(this.ddlItemCategory.SelectedValue), "Y");
    //    LSTItemsSubCategory.Insert(0, new ATTInvItemSubCategory(0, 0, "छान्नुहोस्", ""));
    //    this.ddlItemSubCategory.DataTextField = "ItemsSubCategoryName";
    //    this.ddlItemSubCategory.DataValueField = "ItemsSubCategoryID";
    //    this.ddlItemSubCategory.DataSource = LSTItemsSubCategory;
    //    this.ddlItemSubCategory.DataBind();
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("cancel");
    }

    private void ClearControls(string opt)
    {
        if (opt == "cancel")
        {
            this.txtAuctionDate.Text = "";
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionList.SelectedIndex = -1;
        }
        if (opt == "add")
        {
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionList.SelectedIndex = -1;
        }
        if (opt == "submit")
        {
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionList.SelectedIndex = -1;
            this.grdAuctionList.DataSource = null;
            this.grdAuctionList.DataBind();
        }
    }
    protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
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
                List<ATTInvOrgItemsKNJ> LSTItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(int.Parse(this.ddlItemCategory.SelectedValue),int.Parse(this.ddlItemSubCategory.SelectedValue));
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string msg = EmptyMessage("add");
        if (msg != "")
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTAuctionDetails> LSTAuctDetails = (List<ATTAuctionDetails>)Session["AuctionList"];
        if (Session["AuctionList"] == null)
        {
            LSTAuctDetails = new List<ATTAuctionDetails>();
        }
        if (this.grdAuctionList.SelectedIndex > -1)
        {
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].AuctionDate = this.txtAuctionDate.Text.Trim();
            //LSTAuctDetails[this.grdAuctionList.SelectedIndex].AuctionSequence =0;
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].ItemsCategoryID = int.Parse(this.ddlItemCategory.SelectedValue);
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].ItemsSubCategoryID = int.Parse(this.ddlItemSubCategory.SelectedValue);
            List<ATTAuctionDetails> LSTAucItmID = (List<ATTAuctionDetails>)Session["Items"];
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].ItemsID = LSTAucItmID[this.ddlItem.SelectedIndex - 1].ItemsID;
            //LSTAuctDetails[this.grdAuctionList.SelectedIndex].SeqNo = ;
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].AuctionAmount = this.txtAuctionPrice.Text.Trim();
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].AuctionWinner = this.txtAuctionWinner.Text.Trim();
            LSTAuctDetails[this.grdAuctionList.SelectedIndex].Remarks = this.txtDescription.Text;
        }
        else
        {
            List<ATTInvOrgItemsKNJ> LSTAucItems = (List<ATTInvOrgItemsKNJ>)Session["Items"];
            int itemID=LSTAucItems[this.ddlItem.SelectedIndex - 1].ItemsID;
            foreach (GridViewRow rw in this.grdAuctionList.Rows)
            {
                if (int.Parse(rw.Cells[4].Text) == itemID)
                {
                    this.lblStatusMessage.Text = "**सामान पहिले नै उपलब्द छ";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
            ATTAuctionDetails objAuctionItem = new ATTAuctionDetails();
            objAuctionItem.AuctionDate = this.txtAuctionDate.Text.Trim();
            objAuctionItem.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;            
            objAuctionItem.AuctionSequence = 0;
            objAuctionItem.ItemsCategoryID = int.Parse(this.ddlItemCategory.SelectedValue);
            objAuctionItem.ItemsCategoryName = this.ddlItemCategory.SelectedItem.ToString();
            objAuctionItem.ItemsSubCategoryID = int.Parse(this.ddlItemSubCategory.SelectedValue);
            objAuctionItem.ItemsSubCategoryName = this.ddlItemSubCategory.SelectedItem.ToString();
            objAuctionItem.ItemsID = itemID;
            objAuctionItem.ItemsName = this.ddlItem.SelectedItem.ToString();
            objAuctionItem.SeqNo = LSTAucItems[this.ddlItem.SelectedIndex - 1].KNJSeq;
            objAuctionItem.AuctionAmount = this.txtAuctionPrice.Text.Trim();
            objAuctionItem.AuctionWinner = this.txtAuctionWinner.Text.Trim();
            objAuctionItem.Remarks = this.txtDescription.Text;
            objAuctionItem.Action = "A";
            LSTAuctDetails.Add(objAuctionItem);
        }
 
        //objAucMaster.LstAuctionDetails.Add(objAuctionItem);

        Session["AuctionDetails"] = LSTAuctDetails;
        this.grdAuctionList.DataSource = LSTAuctDetails;
        this.grdAuctionList.DataBind();
        ClearControls("add");
    }

    string EmptyMessage(string choice)
    {
        int count = 0;
        string msg = "";
        if (choice == "add")
        {
            if (this.txtAuctionDate.Text == "")
            {
                msg += "*--निलामी मिति भर्नुहोस्";
                count++;
            }
            if (this.ddlItemCategory.SelectedIndex == 0)
            {
                msg += "<br/>*--समुह छान्नुहोस्";
                count++;
            }
            if (this.ddlItemSubCategory.SelectedIndex == 0)
            {
                msg += "<br/>*--उपसमुह छान्नुहोस्";
                count++;
            }
            if (this.ddlItem.SelectedIndex == 0)
            {
                msg += "<br/>*--सामान छान्नुहोस्";
                count++;
            }
            if (this.txtAuctionPrice.Text == "")
            {
                msg += "<br/>*--सामान मुल्य भर्नुहोस्";
                count++;
            }
            if (this.txtAuctionWinner.Text == "")
            {
                msg += "<br/>*--जित्ने व्यक्ति/कर्यालय भर्नुहोस्";
                count++;
            }
        }
        if (count > 0)
        {
            return msg;
        }
        else
        {
            return "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ATTAuctionMaster objData=new ATTAuctionMaster();
            objData.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            objData.AuctionSeq=0;
            objData.AuctionDate=this.txtAuctionDate.Text;
            objData.App_By=0;
            objData.App_Date="";
            objData.App_Yes_No="";
            objData.Action = "A";
            objData.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            objData.LstAuctionDetails = (List<ATTAuctionDetails>)Session["AuctionList"];

            if (BLLAuctionMaster.SaveAuctionMaster(objData))
            {
                this.lblStatusMessage.Text = "Auction Details Saved Successfully";
                this.programmaticModalPopup.Show();
            }

            //List<ATTAuctionDetails> LSTAuctionDetails = (List<ATTAuctionDetails>)Session["AuctionDetails"];
            //if (LSTAuctionDetails.Count <= 0)
            //{
            //    this.lblStatusMessage.Text = "Sorry No Data To Save";
            //    this.programmaticModalPopup.Show();
            //    return;
            //}
            //for (int j = 0; j <= this.grdAuctionList.Rows.Count - 1; j++)
            //{
            //    LSTAuctionDetails[j].Remarks = ((TextBox)grdAuctionList.Rows[j].FindControl("txtDescription")).Text;

            //}
            
            this.ClearControls("submit");
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    protected void grdAuctionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTAuctionDetails> LSTAuctionDetails = (List<ATTAuctionDetails>)Session["AuctionDetails"];
        this.txtAuctionDate.Text = LSTAuctionDetails[this.grdAuctionList.SelectedIndex].AuctionDate;
        this.ddlItemCategory.SelectedValue = LSTAuctionDetails[this.grdAuctionList.SelectedIndex].ItemsCategoryID.ToString();
        this.ddlItemSubCategory.SelectedValue =LSTAuctionDetails[this.grdAuctionList.SelectedIndex].ItemsSubCategoryID.ToString();
        GridViewRow row = this.grdAuctionList.SelectedRow;
        string itemSel = row.Cells[0].Text + row.Cells[1].Text + row.Cells[2].Text + row.Cells[3].Text + row.Cells[4].Text;
        this.ddlItem.SelectedValue = itemSel;
        this.txtAuctionPrice.Text = LSTAuctionDetails[this.grdAuctionList.SelectedIndex].AuctionAmount;
        this.txtAuctionWinner.Text = LSTAuctionDetails[this.grdAuctionList.SelectedIndex].AuctionAmount;
        this.txtDescription.Text = LSTAuctionDetails[this.grdAuctionList.SelectedIndex].Remarks;
    }
    protected void grdAuctionList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[13].Visible = false;
    }
}
