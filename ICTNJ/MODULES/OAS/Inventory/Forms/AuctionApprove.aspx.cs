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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using System.Collections.Generic;

public partial class MODULES_OAS_Inventory_Forms_AuctionApprove : System.Web.UI.Page
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
                this.chkApprove.Checked = true;
                LoadAuctionDetails();
                LoadItemsCategory();
                LoadItemsSubCategory();
                LoadItems();
               
            }
        //}

        //else
        //{
        //    Response.Redirect("~/MODULES/Login.aspx", true);
        //}
    }


    private void LoadItemsSubCategory()
    {
        try
        {
            List<ATTInvItemSubCategory> lst = BLLInvItemsSubCategory.GetItemSubCategory(null, "Y", true);
            ddlItemSubCategory.DataSource = lst;
            //lst.Insert(0,new ATTInvItemSubCategory(0,0,"छान्नुहोस्",""));
            ddlItemSubCategory.DataTextField = "ItemsSubCategoryName";
            ddlItemSubCategory.DataValueField = "ItemsSubCategoryID";
            ddlItemSubCategory.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
    }

    private void LoadItems()
    {
        try
        {
            List<ATTInvOrgItemsKNJ> LSTItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(null,null);
            //LSTItems.Insert(0, new ATTInvOrgItemsKNJ(0,"छान्नुहोस्"));
            Session["Items"] = LSTItems;
            this.ddlItem.DataSource = LSTItems;
            this.ddlItem.DataTextField = "ItemsDescription";
            this.ddlItem.DataValueField = "PK";
            this.ddlItem.DataBind();
            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "---छान्नुहोस---";
            a.Value = "0";
            ddlItem.Items.Insert(0, a);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
    }

    private void LoadItemsCategory()
    {
        List<ATTInvItemsCategory> LSTItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
        LSTItemsCategory.Insert(0, new ATTInvItemsCategory(0, "---छान्नुहोस्---"));
        this.ddlItemCategory.DataTextField = "ItemsCategoryName";
        this.ddlItemCategory.DataValueField = "ItemsCategoryID";
        this.ddlItemCategory.DataSource = LSTItemsCategory;
        this.ddlItemCategory.DataBind();
    }
    private void LoadAuctionDetails()
    {
        int orgid = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        List<ATTAuctionMaster> LSTAucData = BLLAuctionApprove.GetAuctionDateDetails(orgid, null, null);
        Session["AuctionDateDetails"] = LSTAucData;
        this.grdAuctionDateDetails.DataSource = LSTAucData;
        this.grdAuctionDateDetails.DataBind();
    }
    protected void grdAuctionDateDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        string AuctionDate = "";
        //string AppYesNo = "";
        List<ATTAuctionMaster> LSTAuctionDate = (List<ATTAuctionMaster>)Session["AuctionDateDetails"];
        AuctionDate = LSTAuctionDate[this.grdAuctionDateDetails.SelectedIndex].AuctionDate;
        //AppYesNo = LSTAuctionDate[this.grdAuctionDateDetails.SelectedIndex].App_Yes_No;
        List<ATTAuctionDetails> LSTAucDetails = BLLAuctionDetails.GetAuctionDetailsDT(AuctionDate);
        Session["AuctionDetails"] = LSTAucDetails;
        this.grdAuctionDetails.DataSource = LSTAucDetails;
        this.grdAuctionDetails.DataBind();
    }
    //protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlItemCategory.SelectedIndex > 0)
    //        {
    //            ddlItemSubCategory.Items.Clear();

    //            List<ATTInvItemSubCategory> lst = BLLInvItemsSubCategory.GetItemSubCategory(int.Parse(ddlItemCategory.SelectedValue.ToString()), "Y", true);
    //            ddlItemSubCategory.DataSource = lst;
    //            //lst.Insert(0,new ATTInvItemSubCategory(0,0,"छान्नुहोस्",""));
    //            ddlItemSubCategory.DataTextField = "ItemsSubCategoryName";
    //            ddlItemSubCategory.DataValueField = "ItemsSubCategoryID";
    //            ddlItemSubCategory.DataBind();

    //            ddlItemSubCategory.Enabled = true;
    //        }
    //        else
    //        {
    //            ddlItemSubCategory.Enabled = false;

    //        }

    //        ddlItemSubCategory.SelectedIndex = -1;
    //        ddlItem.SelectedIndex = -1;
    //        ddlItem.Enabled = false;

    //    }
    //    catch (Exception ex)
    //    {

    //        this.lblStatusMessage.Text = "Error Status";
    //        this.lblStatusMessage.Text = ex.Message;
    //        this.programmaticModalPopup.Show();
    //    }
    //}
    //protected void ddlItemSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (this.ddlItemSubCategory.SelectedIndex > 0)
    //        {
    //            this.ddlItem.Enabled = true;
    //            List<ATTInvOrgItemsKNJ> LSTItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(int.Parse(this.ddlItemSubCategory.SelectedValue));
    //            //LSTItems.Insert(0, new ATTInvOrgItemsKNJ(0,"छान्नुहोस्"));
    //            Session["Items"] = LSTItems;
    //            this.ddlItem.DataSource = LSTItems;
    //            this.ddlItem.DataTextField = "ItemsDescription";
    //            this.ddlItem.DataValueField = "PK";
    //            this.ddlItem.DataBind();
    //            ListItem a = new ListItem();
    //            a.Selected = true;
    //            a.Text = "छान्नुहोस";
    //            a.Value = "0";
    //            ddlItem.Items.Insert(0, a);
    //        }
    //        else
    //        {
    //            this.ddlItem.Enabled = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblStatusMessage.Text = "Error Status";
    //        this.lblStatusMessage.Text = ex.Message;
    //        this.programmaticModalPopup.Show();
    //    }
    //}

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<ATTAuctionDetails> LSTAuctDetails = (List<ATTAuctionDetails>)Session["AuctionDetails"];
        if (this.grdAuctionDateDetails.SelectedIndex > -1)
        {
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].AuctionDate = this.txtAuctionDate.Text;
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].ItemsCategoryID = int.Parse(this.ddlItemCategory.SelectedValue);
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].ItemsSubCategoryID = int.Parse(this.ddlItemSubCategory.SelectedValue);
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].ItemsID = int.Parse(this.grdAuctionDetails.SelectedRow.Cells[6].Text);
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].AuctionAmount = this.txtAuctionPrice.Text.Trim();
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].AuctionWinner = this.txtAuctionWinner.Text.Trim();
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].Remarks = this.txtDescription.Text;
            LSTAuctDetails[this.grdAuctionDetails.SelectedIndex].Action = "E";
            Session["AuctionDetails"] = LSTAuctDetails;
            this.grdAuctionDetails.DataSource = LSTAuctDetails;
            this.grdAuctionDetails.DataBind();
        }
        else
        {
            this.lblStatusMessage.Text = "**र्कपया निलामी वस्तु छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdAuctionDateDetails.SelectedIndex > -1)
        {
            List<ATTAuctionMaster> LSTAucDateDetails = (List<ATTAuctionMaster>)Session["AuctionDateDetails"];
            ATTAuctionMaster objData = new ATTAuctionMaster();
            objData.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            objData.AuctionSeq = LSTAucDateDetails[this.grdAuctionDateDetails.SelectedIndex].AuctionSeq;
            objData.AuctionDate = LSTAucDateDetails[this.grdAuctionDateDetails.SelectedIndex].AuctionDate;
            objData.App_By = ((ATTUserLogin)Session["Login_User_Detail"]).PID;
            objData.App_Date = this.txtCurrentDate.Text;
            if (this.chkApprove.Checked == true)
            {
                objData.App_Yes_No = "Y";
            }
            else
            {
                objData.App_Yes_No = "N";
            }

            objData.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

            if (this.grdAuctionDetails.SelectedIndex > -1)
            {
                objData.Action = "E";
                objData.LstAuctionDetails = (List<ATTAuctionDetails>)Session["AuctionDetails"];
            }
            else
            {
                objData.Action = "App";
            }
            if (BLLAuctionMaster.SaveAuctionMaster(objData))
            {
                if (objData.Action == "E")
                {
                    this.lblStatusMessage.Text = "Auction Details Edited Successfully";
                    this.programmaticModalPopup.Show();
                }
                else if (objData.Action == "App")
                {
                    this.lblStatusMessage.Text = "Auction Details Approved Successfully";
                    this.programmaticModalPopup.Show();
                }
            }
            ClearControls("submit");
        }
        else
        {
            this.lblStatusMessage.Text = "**र्कपया निलामी मिति छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("cancel");
    }

    private void ClearControls(string p)
    {
        if (p == "cancel")
        {
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionDateDetails.SelectedIndex = -1;

        }
        if (p == "add")
        {
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionDateDetails.SelectedIndex = -1;
        }
        if (p == "submit")
        {
            this.grdAuctionDateDetails.SelectedIndex = -1;
            this.grdAuctionDateDetails.SelectedIndex = -1;
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtAuctionDate.Text = "";
            this.txtAuctionPrice.Text = "";
            this.txtAuctionWinner.Text = "";
            this.txtDescription.Text = "";
            this.grdAuctionDetails.SelectedIndex = -1;
            this.grdAuctionDetails.DataSource = null;
            this.grdAuctionDetails.DataBind();
        }
    }

    protected void grdAuctionDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTAuctionDetails> LSTAuctionDetails = (List<ATTAuctionDetails>)Session["AuctionDetails"];
        this.txtAuctionDate.Text = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].AuctionDate;
        this.ddlItemCategory.SelectedValue = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].ItemsCategoryID.ToString();
        this.ddlItemSubCategory.SelectedValue = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].ItemsSubCategoryID.ToString();
        GridViewRow row = this.grdAuctionDetails.SelectedRow;
        string itemSel = row.Cells[0].Text + row.Cells[1].Text + row.Cells[2].Text + row.Cells[4].Text + row.Cells[6].Text;
        this.ddlItem.SelectedValue = itemSel;
        this.txtAuctionPrice.Text = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].AuctionAmount;
        this.txtAuctionWinner.Text = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].AuctionWinner;
        this.txtDescription.Text = LSTAuctionDetails[this.grdAuctionDetails.SelectedIndex].Remarks;
        this.txtCurrentDate.Text = System.DateTime.Now.ToString();
    }

    protected void grdAuctionDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[13].Visible = false;
    }
}
