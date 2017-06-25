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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;

public partial class MODULES_OAS_Inventory_Forms_InvDonationPurchases : System.Web.UI.Page
{
    new public ATTUserLogin User
    {
        get { return (ATTUserLogin)Session["Login_User_Detail"]; }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadItemCategory();
            btnOK.Visible = false;
            txtReceivedBy_Rqd.Enabled = false;            
        }
    }

    private void LoadItemCategory()
    {
        try
        {
            List<ATTInvItemsCategory> lstItemCategory = BLLInvItemsCategory.GetItemCategoryList(null, "Y", "Y", true);
            Session["Item_ItemCategory"] = lstItemCategory;
            this.DDLItemsCategory_Rqd.DataSource = lstItemCategory;
            this.DDLItemsCategory_Rqd.DataTextField = "ItemsCategoryName";
            this.DDLItemsCategory_Rqd.DataValueField = "ItemCategoryID";
            this.DDLItemsCategory_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void DDLItemsCategory_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClearControls(1);
            if (this.DDLItemsCategory_Rqd.SelectedIndex > 0)
            {

                List<ATTInvItemsCategory> lstItemsCategory = (List<ATTInvItemsCategory>)Session["Item_ItemCategory"];
                this.DDLItemsSubCategory_Rqd.DataSource = lstItemsCategory[this.DDLItemsCategory_Rqd.SelectedIndex].LstItemSubCategory;
                this.DDLItemsSubCategory_Rqd.DataTextField = "ItemsSubCategoryName";
                this.DDLItemsSubCategory_Rqd.DataValueField = "ItemsSubCategoryID";
                this.DDLItemsSubCategory_Rqd.DataBind();
            }            
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }   

    protected void DDLItemsSubCategory_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClearControls(2);
            List<ATTInvOrgItemsPrice> lstItems = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(9, int.Parse(this.DDLItemsCategory_Rqd.SelectedValue), int.Parse(this.DDLItemsSubCategory_Rqd.SelectedValue), true);
            this.DDLItems_Rqd.DataSource = lstItems;
            this.DDLItems_Rqd.DataTextField = "ITEMNAME";
            this.DDLItems_Rqd.DataValueField = "ITEMSID";
            this.DDLItems_Rqd.DataBind();
        }
        catch(Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        grdViewEmployees.DataSource = "";
        grdViewEmployees.DataBind();
        List<ATTEmployeeSearch> lstEmployee;        
        if (this.txtFirstName.Text.Trim() == "" && this.txtMiddleName.Text.Trim() == "" && this.txtSurname.Text.Trim() == ""
            && this.DDLGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            try
            {                
                lstEmployee = BLLEmployeeSearch.SearchEmployee(GetFilter());
                Session["Employee"] = lstEmployee;               
                this.grdViewEmployees.DataSource = lstEmployee;
                this.grdViewEmployees.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
        btnOK.Visible = true;
    }

    private ATTEmployeeSearch GetFilter()
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
       
        if (this.txtFirstName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFirstName.Text.Trim();
        if (this.txtMiddleName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMiddleName.Text.Trim();
        if (this.txtSurname.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurname.Text.Trim();
        if (this.DDLGender.SelectedIndex > 0) EmployeeSearch.Gender = this.DDLGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        EmployeeSearch.OrgID = 9;
        EmployeeSearch.DesType = "O";      
        return EmployeeSearch;
    }

    protected void grdViewEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string strChkSelection = "return FuncCheckSelect('" + ((CheckBox)e.Row.FindControl("chkSelection")).ClientID + "');";
        //    ((CheckBox)e.Row.FindControl("chkSelection")).Attributes.Add("onclick", strChkSelection);
        //}
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in this.grdViewEmployees.Rows)
            {
                CheckBox cb = (CheckBox)(row.FindControl("chkSelection"));
                if (cb.Checked)
                {
                    this.txtReceivedBy_Rqd.Text = row.Cells[6].Text.Trim();
                    this.txtEmpID.Text = row.Cells[1].Text.Trim();
                    break;
                }

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ATTInvDonationsPurchases objDonPur = new ATTInvDonationsPurchases();
            objDonPur.OrgID = User.OrgID;
            objDonPur.ItemsCategoryID = int.Parse(DDLItemsCategory_Rqd.SelectedValue);
            objDonPur.ItemsSubCategoryID = int.Parse(DDLItemsSubCategory_Rqd.SelectedValue);
            objDonPur.ItemsID = int.Parse(DDLItems_Rqd.SelectedValue);
            objDonPur.DonationPurchaseDate = txtDonationPurchaseDate_RDT.Text;
            objDonPur.DonationPurchaseSeq = null;
            objDonPur.DonationPurchaseType = chkDonation.Checked ? "D" : "P";
            objDonPur.DonationPurchaseOrg = txtOrganization_Rqd.Text;
            objDonPur.DonationPurchaseQty = int.Parse(txtQuantity_Rqd.Text);
            if (chkDonation.Checked)
            {
                objDonPur.DonationPurchaseUnitPrice = 0;
            }
            else
            {
                if (txtPrice.Text == "")
                {
                    this.lblStatusMessage.Text = "Enter price";
                    this.programmaticModalPopup.Show();
                    return;
                }
                else
                    objDonPur.DonationPurchaseUnitPrice = int.Parse(txtPrice.Text);
            }                
            objDonPur.ReceivedBy = int.Parse(txtEmpID.Text);
            objDonPur.ReceivedDate = txtReceivedDate_RDT.Text;
            objDonPur.EntrBy = User.UserName;
            objDonPur.Action = "A";
            BLLInvDonationsPurchases.saveDonationPurchases(objDonPur);
            this.lblStatusMessage.Text = "Donation Purchases Successfully saved";
            this.programmaticModalPopup.Show();
            ClearControls(0);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(0);
    }

    protected void chkDonation_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDonation.Checked)
            txtPrice.Enabled = false;
        else
            txtPrice.Enabled = true;
    }

    private void ClearControls(int intflag)
    {     
        txtQuantity_Rqd.Text = "";
        chkDonation.Checked = false;
        txtPrice.Text = "";
        txtPrice.Enabled = true;
        txtOrganization_Rqd.Text = "";
        txtDonationPurchaseDate_RDT.Text = "";
        txtReceivedBy_Rqd.Text = "";
        txtReceivedDate_RDT.Text = "";
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtSurname.Text = "";
        txtDOB.Text = "";
        DDLGender.SelectedIndex = 0;
        grdViewEmployees.DataSource = "";
        grdViewEmployees.DataBind();
        btnOK.Visible = false;
        if (intflag == 0)
        {
            DDLItemsCategory_Rqd.SelectedIndex = 0;           
        }
        if (intflag == 1 || intflag==0)
        {            
            DDLItemsSubCategory_Rqd.DataSource = "";
            DDLItemsSubCategory_Rqd.DataBind();
            DDLItems_Rqd.DataSource = "";
            DDLItems_Rqd.DataBind();
        }
        if (intflag == 2)
        {            
            DDLItems_Rqd.DataSource = "";
            DDLItems_Rqd.DataBind();
        }
    }
}
