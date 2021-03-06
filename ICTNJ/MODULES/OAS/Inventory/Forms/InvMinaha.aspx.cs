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
/*
  Author         
  Shanjeev sah   
*/

public partial class MODULES_OAS_Inventry_Forms_InvMinaha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (!IsPostBack)
        {
            this.ddlItemSubCategory.Enabled = false;
            this.ddlItem.Enabled = false;
          
            Session["ItemsWriteOff"] = new ATTInvItemsWriteOff();
            LoadItemsCategory();
            
            
        }

    }

    protected void OkButton_Click(object sender, EventArgs e)
    {

    }


    private void LoadItemsCategory()
    {
        //List<ATTInvItemsCategory> LSTItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
        //Session["ItemsCategory"] = LSTItemsCategory;
        //LSTItemsCategory.Insert(0, new ATTInvItemsCategory(0, "छान्नुहोस्", "", "", ""));
        //this.ddlItemCategory.DataTextField = "ItemsCategoryName";
        //this.ddlItemCategory.DataValueField = "ItemsCategoryID";
        //this.ddlItemCategory.DataSource = LSTItemsCategory;
        //this.ddlItemCategory.DataBind();

        List<ATTInvItemsCategory> LSTItemsCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y");
        LSTItemsCategory.Insert(0, new ATTInvItemsCategory(0, "छान्नुहोस्", "", "", ""));
        this.ddlItemCategory.DataTextField = "ItemsCategoryName";
        this.ddlItemCategory.DataValueField = "ItemsCategoryID";
        this.ddlItemCategory.DataSource = LSTItemsCategory;
        this.ddlItemCategory.DataBind();
    }

    protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)// load itemSubCategory
    {

        //List<ATTInvItemSubCategory> LSTItemsSubCategory = BLLInvItemsSubCategory.GetItemSubCategoryList(int.Parse(this.ddlItemCategory.SelectedValue), "Y");

        //LSTItemsSubCategory.Insert(0, new ATTInvItemSubCategory(0, 0, "छान्नुहोस्", "", "", ""));
        //this.ddlItemSubCategory.DataTextField = "ItemsSubCategoryName";
        //this.ddlItemSubCategory.DataValueField = "ItemsSubCategoryID";
        //this.ddlItemSubCategory.DataSource = LSTItemsSubCategory;
        //this.ddlItemSubCategory.DataBind();
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

    protected void ddlItemSubCategory_SelectedIndexChanged(object sender, EventArgs e)//loads items
    {
        //List<ATTInvOrgItemsKNJ> LSTItems = BLLInvOrgItemsKNJ.SearchItemsKNJ(int.Parse(this.ddlItemCategory.SelectedValue),int.Parse(this.ddlItemSubCategory.SelectedValue));
        //Session["Items"] = LSTItems;

        //LSTItems.Insert(0, new ATTInvOrgItemsKNJ(0, "छान्नुहोस्"));
        //this.ddlItem.DataTextField = "ItemsName";
        //this.ddlItem.DataValueField = "PK";
        //this.ddlItem.DataSource = LSTItems;
        //this.ddlItem.DataBind();
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

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.ddlItemCategory.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "Please select Item Name Name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        if (this.ddlItemSubCategory.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please select Iten Category Name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        if (this.ddlItem.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please select the Item Name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        
        if (this.txtRemarks.Text == "")
        {
            this.lblStatusMessage.Text = "Please Enter Remarks.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
         
        ATTInvItemsWriteOff obj = (ATTInvItemsWriteOff)Session["ItemsWriteOff"];

        //List<ATTInvItemsWriteOff> lstItemsWriteOff = (List<ATTInvItemsWriteOff>)Session["ItemsWriteOff"];

        if (grdMinahaList.SelectedIndex > -1)
        {


            List<ATTInvOrgItemsKNJ> LSTSeq = (List<ATTInvOrgItemsKNJ>)Session["Items"];// how to get seq no it comes from DLLInvOrgItemsKNJ
           
            obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].ItemsCategoryID = int.Parse(ddlItemCategory.SelectedValue);
            obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].ItemsSubCategoryID = int.Parse(ddlItemSubCategory.SelectedValue);
            obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].ItemsID = LSTSeq[ddlItem.SelectedIndex -1].ItemsID;
            obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].Remarks = txtRemarks.Text;
            obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].Action = (obj.LstItemsWriteOffDT[grdMinahaList.SelectedIndex].Action == "A" ? "A" : "E");
          

        }
        else
        {
            //List<ATTInvOrgItemsKNJ> LSTAucItems = (List<ATTInvOrgItemsKNJ>)Session["Items"];
            //int itemID = LSTAucItems[this.ddlItem.SelectedIndex - 1].ItemsID;
            List<ATTInvOrgItemsKNJ> LSTSeq = (List<ATTInvOrgItemsKNJ>)Session["Items"];
            ATTInvItemsWriteOffDT ob = new ATTInvItemsWriteOffDT();
            int itemid=LSTSeq[ddlItem.SelectedIndex-1].ItemsID;
            
            foreach (GridViewRow row in this.grdMinahaList.Rows)
            {
                if (int.Parse(row.Cells[4].Text) == itemid)
                    {
                        this.lblStatusMessage.Text = "**सामान पहिले नै उपलब्द छ";
                        this.programmaticModalPopup.Show();
                        return;
                    }
            }

            ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

            //ATTInvItemsWriteOffDT ob = new ATTInvItemsWriteOffDT();

            ob.OrgID = user.OrgID;
            ob.ItemsCategoryID = int.Parse(ddlItemCategory.SelectedValue);
            ob.ItemsSubCategoryID = int.Parse(ddlItemSubCategory.SelectedValue);
            //get ItemID from session
           // List<ATTInvOrgItemsKNJ> LSTSeq = (List<ATTInvOrgItemsKNJ>)Session["Items"];// get ItemID from session -- (DLLInvOrgItemsKNJ)
            ob.ItemsID = itemid;

            ob.SeqNo = LSTSeq[ddlItem.SelectedIndex - 1].KNJSeq;
            ob.Remarks = txtRemarks.Text;
            ob.Action = "A";
            obj.LstItemsWriteOffDT.Add(ob);
            this.grdMinahaList.SelectedIndex = -1;
            this.ddlItemCategory.SelectedIndex = 0;
            this.ddlItemSubCategory.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtRemarks.Text = "";
 
        }
        this.grdMinahaList.DataSource = obj.LstItemsWriteOffDT;
        this.grdMinahaList.DataBind();
        this.grdMinahaList.SelectedIndex = -1;
        this.txtRemarks.Text = "";
        this.ddlItemCategory.SelectedIndex =0;
        this.ddlItemSubCategory.SelectedIndex = 0;
        this.ddlItem.SelectedIndex = 0;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        
        ATTInvItemsWriteOff itemsWriteOff = (ATTInvItemsWriteOff)Session["ItemsWriteOff"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        itemsWriteOff.OrgID = user.OrgID;
        if (txtMinahaDate.Text == "")
        {
            //DateTime.Now.ToShortDateString();
            string shortDateString = DateTime.Now.ToString("dd/MM/yyyy");  
            itemsWriteOff.WriteoffDate = shortDateString;
        }
        else
        {
            itemsWriteOff.WriteoffDate = txtMinahaDate.Text;
 
        }

        //itemsWriteOff.WriteoffDate = txtMinahaDate.Text;
        itemsWriteOff.AppBy = null; //This is field at the time of Approval
        itemsWriteOff.AppDate = null;  //This is field at the time of Approval
        itemsWriteOff.AppYesNo = null;//This is field at the time of Approval
        itemsWriteOff.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        itemsWriteOff.Action = "A";

        if (BLLInvItemsWriteOff.AddUpdateItemsWriteOff(itemsWriteOff))
        {
            this.lblStatusMessage.Text = "Information Saved";
            this.programmaticModalPopup.Show();
        }
        else
        {
            this.lblStatusMessage.Text = "Information could not be Saved";
            this.programmaticModalPopup.Show();
        }
        ClearControl();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControl();

    }

    void ClearControl()
    {
        
        this.grdMinahaList.SelectedIndex = -1;
        this.grdMinahaList.DataSource = "";
        grdMinahaList.DataBind();
        this.ddlItemCategory.SelectedIndex = 0;
        this.ddlItemSubCategory.SelectedIndex = 0;
        this.ddlItem.SelectedIndex = 0;
        this.txtRemarks.Text = "";
        Session["ItemsWriteOff"] = new ATTInvItemsWriteOff();
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

    protected void grdMinahaList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ATTInvItemsWriteOff obj = (ATTInvItemsWriteOff)Session["ItemsWriteOff"];

        List<ATTInvItemsWriteOffDT> itemsWriteOffDT = obj.LstItemsWriteOffDT;
        this.ddlItemCategory.SelectedValue = itemsWriteOffDT[this.grdMinahaList.SelectedIndex].ItemsCategoryID.ToString();
        this.ddlItemSubCategory.SelectedValue = itemsWriteOffDT[this.grdMinahaList.SelectedIndex].ItemsSubCategoryID.ToString();
        //ItemID values can be set from session 
        GridViewRow row = grdMinahaList.SelectedRow;

        string selVal = (row.Cells[0].Text + row.Cells[2].Text + row.Cells[3].Text + row.Cells[4].Text + row.Cells[5].Text);
        this.ddlItem.SelectedValue = selVal ;

       
       this.txtRemarks.Text = itemsWriteOffDT[this.grdMinahaList.SelectedIndex].Remarks;
       itemsWriteOffDT[grdMinahaList.SelectedIndex].Action = (itemsWriteOffDT[grdMinahaList.SelectedIndex].Action == "A" ? "A" : "E");  
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {

    }
    protected void grdMinahaList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        ATTInvItemsWriteOff itemsWriteOff = (ATTInvItemsWriteOff)Session["ItemsWriteOff"];
       

        List<ATTInvItemsWriteOffDT> itemsWriteOffDT = itemsWriteOff.LstItemsWriteOffDT;

        if ((itemsWriteOffDT[i].Action == null) || (itemsWriteOffDT[i].Action == "E"))
            itemsWriteOffDT[i].Action = "D";
        else if (itemsWriteOffDT[i].Action == "D")
            itemsWriteOffDT[i].Action = "E";
        else if (itemsWriteOffDT[i].Action == "A")
            itemsWriteOffDT.RemoveAt(i);

        this.grdMinahaList.DataSource = itemsWriteOffDT;
        this.grdMinahaList.DataBind();

        this.grdMinahaList.SelectedIndex = -1;
        SetGridColor(7, 9, this.grdMinahaList);
    }

    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdMinahaList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
    }
}
