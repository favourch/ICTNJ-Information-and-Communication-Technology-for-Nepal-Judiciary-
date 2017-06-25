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


public partial class MODULES_OAS_Inventory_LookUp_Supplier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (!Page.IsPostBack)
        {
            LoadSupplierList();  // load list data of Supplier

            Session["Supplier"] = new ATTInvSupplier();
        }
  
    }
  
    void LoadSupplierList()
    {
        try
        {
            Session["supplier_list"] = BLLInvSupplier.GetSupplierList(null);

            this.lstSupplier.DataSource = (List<ATTInvSupplier>)Session["supplier_list"];
            this.lstSupplier.DataTextField = "SupplierName";
            this.lstSupplier.DataValueField = "SupplierID";
            this.lstSupplier.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void lstSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTInvSupplier> supplier = (List<ATTInvSupplier>)Session["supplier_list"];

        ATTInvSupplier obj = supplier[this.lstSupplier.SelectedIndex].CreateDeepCopy();

        Session["Supplier"] = obj;
        
        this.txtSupplierName_Rqd.Text = obj.SupplierName;
        this.txtSupplierAddress.Text = obj.SupplierAddress;
        this.txtPanNo.Text = obj.PanNo;
        string chk=obj.Active;


        if (chk == "Y")
        {
            this.chkSActive.Checked = true;
        }
        else
        {
            this.chkSActive.Checked = false;
        }

        
        this.grdSupplierContact.DataSource = obj.LstSupplierContact;
        grdSupplierContact.DataBind();
    }

    protected void grdSupplierContact_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTInvSupplier obj = (ATTInvSupplier)Session["Supplier"];
        List<ATTInvSupplierContact> suppContact = obj.LstSupplierContact;        
        this.txtContactPerson_Rqd.Text = suppContact[this.grdSupplierContact.SelectedIndex].ContactPerson;// supplierContact.ContactPerson;
        this.txtContactPhone.Text = suppContact[this.grdSupplierContact.SelectedIndex].ContactPhone;//supplierContact.ContactPhone;
        this.txtEmail.Text = suppContact[this.grdSupplierContact.SelectedIndex].ContactEmail;//supplierContact.ContactEmail;
        suppContact[grdSupplierContact.SelectedIndex].Action = (suppContact[grdSupplierContact.SelectedIndex].Action == "A" ? "A" : "E");
    
    }


    protected void btnAddSupplierContact_Click(object sender, EventArgs e)
    {
        if (this.txtContactPerson_Rqd.Text == "")
            return;


        ATTInvSupplier obj = (ATTInvSupplier)Session["Supplier"];

        if (this.grdSupplierContact.SelectedIndex > -1)
        {
           obj.LstSupplierContact[grdSupplierContact.SelectedIndex].ContactPerson=txtContactPerson_Rqd.Text;
           obj.LstSupplierContact[grdSupplierContact.SelectedIndex].ContactPhone=txtContactPhone.Text;
           obj.LstSupplierContact[grdSupplierContact.SelectedIndex].ContactEmail = txtEmail.Text;
           obj.LstSupplierContact[grdSupplierContact.SelectedIndex].Action = (obj.LstSupplierContact[grdSupplierContact.SelectedIndex].Action == "A" ? "A" : "E");
           obj.LstSupplierContact[grdSupplierContact.SelectedIndex].EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName; 
        }
        else
        {
            ATTInvSupplierContact ob = new ATTInvSupplierContact();
            ob.ContactPerson = txtContactPerson_Rqd.Text;
            ob.ContactPhone = txtContactPhone.Text;
            ob.ContactEmail = txtEmail.Text;
            ob.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            ob.Action = "A";
            obj.LstSupplierContact.Add(ob);
            this.grdSupplierContact.SelectedIndex = -1;
            this.txtContactPerson_Rqd.Text = "";
            this.txtContactPhone.Text = "";
            this.txtEmail.Text = "";


        }
        
        this.grdSupplierContact.DataSource = obj.LstSupplierContact;
        this.grdSupplierContact.DataBind();
        this.grdSupplierContact.SelectedIndex = -1;
        this.txtContactPerson_Rqd.Text = "";
        this.txtContactPhone.Text = "";
        this.txtEmail.Text = "";
    }

    protected void grdSupplierContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        ATTInvSupplier  supplier = (ATTInvSupplier)Session["Supplier"];
        List<ATTInvSupplierContact> suppContact = supplier.LstSupplierContact;

        if ((suppContact[i].Action == null)||(suppContact[i].Action == "E")) suppContact[i].Action = "D";
        else if (suppContact[i].Action == "D") suppContact[i].Action = "E";
        else if (suppContact[i].Action == "A") suppContact.RemoveAt(i);

        this.grdSupplierContact.DataSource = suppContact;
        this.grdSupplierContact.DataBind();

        this.grdSupplierContact.SelectedIndex = -1;
        SetGridColor(5, 7, this.grdSupplierContact);
      
    }


    protected void grdSupplierContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
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


    void ClearSupplier()
    {
        this.lstSupplier.SelectedIndex = -1;
        this.txtSupplierName_Rqd.Text = "";
        this.txtSupplierAddress.Text = "";
        this.txtPanNo.Text = "";
        this.chkSActive.Checked = true;
        this.grdSupplierContact.SelectedIndex = -1;
        this.grdSupplierContact.DataSource = "";
        grdSupplierContact.DataBind();
        this.txtContactPerson_Rqd.Text = "";
        this.txtContactPhone.Text = "";
        this.txtEmail.Text = "";
        this.lblStatus.Text = "";
        LoadSupplierList();
        Session["Supplier"] = new ATTInvSupplier();
    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtSupplierName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Please enter supplier name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        ATTInvSupplier supplier = (ATTInvSupplier)Session["Supplier"];

        supplier.SupplierName = txtSupplierName_Rqd.Text;
        supplier.PanNo = txtPanNo.Text;
        supplier.SupplierAddress = txtSupplierAddress.Text;
        supplier.Active = (chkSActive.Checked ? "Y" : "N");
        supplier.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        if (lstSupplier.SelectedIndex>=0)supplier.Action = "E";
        else supplier.Action = "A";

        if (BLLInvSupplier.AddSupplier(supplier))
        {
            this.lblStatusMessage.Text = "Information Saved";
            this.programmaticModalPopup.Show();
        }
        else
        {
            this.lblStatusMessage.Text = "Information could not be Saved";
            this.programmaticModalPopup.Show();
        }


        ClearSupplier();


    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearSupplier();

    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
