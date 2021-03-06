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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Inventory_Forms_DirectEntry : System.Web.UI.Page
{
    public int orgID;
    public string entryBy;
    public int loginID;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        orgID = user.OrgID;
        entryBy = user.UserName;
        loginID = int.Parse(user.PID.ToString());


        if (!IsPostBack)
        {
            this.LoadControls();
        }
               
    }

    public void LoadControls()
    {
        LoadCategory();
        Session["grdKnjRow"] = null;
        Session["lstDak"] = null;

        Session["DECurrentDate"] = null;

        string dateString = BLLDate.GetDateString(0, 0, "_N");
        if (dateString != null)
        {
            int len = dateString.ToString().Length;
            Session["DECurrentDate"] = dateString.ToString().Substring(0, len - 5);
        }
    }
    public void LoadCategory()
    {
        try
        {
            Session["DakhilaCat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["DakhilaCat"] != null)
            {
                ddlCategory_rqd.DataSource = Session["DakhilaCat"];
                ddlCategory_rqd.DataTextField = "itemsCategoryName";
                ddlCategory_rqd.DataValueField = "itemsCategoryID";
                ddlCategory_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlCategory_rqd.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkDonation.Checked)
            {
                lblDonOrg.Visible = true;
                txtDonOrg_rqd.Visible = true;
            }
            else
            {
                lblDonOrg.Visible = false;
                txtDonOrg_rqd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
        
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory_rqd.SelectedIndex > 0)
            {
                ddlSubCategory_rqd.Items.Clear();
                ddlSubCategory_rqd.DataSource = BLLInvItemsSubCategory.GetItemSubCategory(int.Parse(ddlCategory_rqd.SelectedValue.ToString()), "Y", true);
                ddlSubCategory_rqd.DataTextField = "ItemsSubCategoryName";
                ddlSubCategory_rqd.DataValueField = "ItemsSubCategoryID";
                ddlSubCategory_rqd.DataBind();

                ddlSubCategory_rqd.Enabled = true;

            }
            else
            {
                ddlSubCategory_rqd.SelectedIndex = -1;
                ddlSubCategory_rqd.Enabled = false;
                //ddlItems_cat.SelectedIndex = -1;
                //ddlItems_cat.Enabled = false;

            }

            //txtQty_cat.Text = "";

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubCategory_rqd.SelectedIndex > 0)
            {
                ATTInvItems obj = new ATTInvItems();
                obj.ItemsCategoryID = int.Parse(ddlCategory_rqd.SelectedValue);
                obj.ItemsSubCategoryID =int.Parse(ddlSubCategory_rqd.SelectedValue);
                obj.Active = "Y";


                Session["DakhilaItems"] = BLLInvItems.GetInvItems(obj);

                //Session["DakhilaItems"] = BLLInvOrgItemsPrice.GetOrgInvItemsPrice(9, int.Parse(ddlCategory.SelectedValue), int.Parse(ddlSubCategory.SelectedValue));

                ddlItems_rqd.DataSource = (List<ATTInvItems>)Session["DakhilaItems"];
                ddlItems_rqd.DataTextField = "ItemsName";
                ddlItems_rqd.DataValueField = "ItemsID";
                ddlItems_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "----छान्नुहोस----";
                a.Value = "0";
                ddlItems_rqd.Items.Insert(0, a);


                ddlItems_rqd.Enabled = true;
            }
            else
            {
                ddlItems_rqd.SelectedIndex = -1;
                ddlItems_rqd.Enabled = false;
            }

            //txtQty_cat.Text = "";
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            ATTInvOrgItems objInvOItems = new ATTInvOrgItems();

            objInvOItems.OrgID = orgID;
            objInvOItems.ItemsCategoryID = int.Parse(ddlCategory_rqd.SelectedValue.ToString());
            objInvOItems.ItemsSubCategoryID = int.Parse(ddlSubCategory_rqd.SelectedValue.ToString());
            objInvOItems.ItemsID = int.Parse(ddlItems_rqd.SelectedValue.ToString());

            
            count = BLLInvOrgItems.CheckExistsOrgItems(objInvOItems);

            if (count > 0)
            {
                lblJelaaKhataNo.Visible = false;
                txtJelaaKhataNo_rqd.Visible = false;

            }
            else
            {
                lblJelaaKhataNo.Visible = true;
                txtJelaaKhataNo_rqd.Visible = true;
            }


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void grdDakhila_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (row.Cells[4].Text == "1")
            {
                row.Cells[10].Text = "खर्च भईजाने";
            }
            else
            {
                row.Cells[10].Text = "खर्च नभईजाने";
            }

            double totalPrice = double.Parse(row.Cells[13].Text) * double.Parse(row.Cells[14].Text);
            row.Cells[15].Text = totalPrice.ToString();

            if (row.Cells[19].Text == "A")
            {
                row.Cells[11].Text = "हो";
            }
            else 
            {
                row.Cells[11].Text = "होइन";
            }

            if (row.Cells[5].Text == "1")
            {
                Button btnKnj = (Button)row.Cells[18].FindControl("btnKnj");
                btnKnj.Visible = false;
            }

        }

        if (this.grdDakhila.Rows.Count > 0)
        {
            this.lblEntryCount.Text = "जम्मा दाखिला : " + this.grdDakhila.Rows.Count.ToString();
        }
        else
        {
            this.lblEntryCount.Text = "";
        }

    }
    protected void grdDakhila_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[3].Visible = false;
        row.Cells[4].Visible = false;
        row.Cells[5].Visible = false;
        row.Cells[12].Visible = false;
        row.Cells[19].Visible = false;
        row.Cells[20].Visible = false;  
    }
    protected void grdDakhila_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdDakhila.SelectedRow;

        ddlCategory_rqd.SelectedValue = row.Cells[2].Text;

        ddlSubCategory_rqd.SelectedValue = row.Cells[3].Text;

        ddlItems_rqd.SelectedValue = row.Cells[4].Text;

        txtDakhilaDate_RDT.Text = row.Cells[9].Text;

        txtUnitPrice_rqd.Text = row.Cells[13].Text;
        txtQty_rqd.Text = row.Cells[14].Text;


        List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

        if (Session["lstDak"] != null)
            lst = (List<ATTInvDakhila>)Session["lstDak"];

        if (lst[grdDakhila.SelectedIndex].DirectEntryType == "A")
        {
            chkDonation.Checked = true;

            lblDonOrg.Visible = true;
            txtDonOrg_rqd.Visible = true;

            txtDonOrg_rqd.Text = lst[grdDakhila.SelectedIndex].DonationOrg;
        }
        else
        {
            chkDonation.Checked = false;
            lblDonOrg.Visible = false;
            txtDonOrg_rqd.Visible = false;  

        }


        if (lst[grdDakhila.SelectedIndex].JelaaKhataNo != "")
        {
            lblJelaaKhataNo.Visible = true;
            txtJelaaKhataNo_rqd.Visible = true;

            txtJelaaKhataNo_rqd.Text = lst[grdDakhila.SelectedIndex].JelaaKhataNo;


        }
        else
        {
            lblJelaaKhataNo.Visible = false;
            txtJelaaKhataNo_rqd.Visible = false;
            txtJelaaKhataNo_rqd.Text = "";
        }

        //ddlItems.Width = 476;

        ddlCategory_rqd.Enabled = false;
        ddlSubCategory_rqd.Enabled = false;
        ddlItems_rqd.Enabled = false;   

        btnSubmit.Enabled = false;
    }
    protected void grdDakhila_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

        if (Session["lstDak"] != null)
        {
            lst = (List<ATTInvDakhila>)Session["lstDak"];

            lst.RemoveAt(e.RowIndex);

            if (lst.Count > 0)
            {

                grdDakhila.DataSource = lst;
                grdDakhila.DataBind();
            }
            else
            {
                grdDakhila.DataSource = "";
                grdDakhila.DataBind();

                this.lblEntryCount.Text = "";
            }
        }
    }
    protected void grdNonExpendible_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["DECurrentDate"] != null && txtDakhilaDate_RDT.Text != "")
            {
                if (CompareDate(txtDakhilaDate_RDT.Text,Session["DECurrentDate"].ToString()))
                {


                    List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

                    if (Session["lstDak"] != null)
                        lst = (List<ATTInvDakhila>)Session["lstDak"];

                    bool flag = false;

                    if (grdDakhila.SelectedIndex > -1)
                    {
                        GridViewRow gvRow = grdDakhila.SelectedRow;

                        ATTInvDakhila objDak = lst.Find(delegate(ATTInvDakhila obj)
                                                                     {
                                                                         return ((obj.ItemsCategoryID == int.Parse(gvRow.Cells[2].Text)) &&
                                                                                 (obj.ItemsSubCategoryID == int.Parse(gvRow.Cells[3].Text)) &&
                                                                                 (obj.ItemsID == int.Parse(gvRow.Cells[4].Text)));
                                                                     }

                                                                );

                        if (objDak != null)
                        {
                            objDak.DirectEntryDate = txtDakhilaDate_RDT.Text;

                            if (chkDonation.Checked)
                            {
                                objDak.DirectEntryType = "A";
                                objDak.DonationOrg = txtDonOrg_rqd.Text;
                            }
                            else
                            {
                                objDak.DirectEntryType = "D";
                                objDak.DonationOrg = "";
                            }

                            objDak.UnitPrice = int.Parse(txtUnitPrice_rqd.Text);
                            objDak.Quantity = int.Parse(txtQty_rqd.Text);

                            if (txtJelaaKhataNo_rqd.Text != "")
                            {
                                objDak.JelaaKhataNo = txtJelaaKhataNo_rqd.Text;
                            }
                            else
                            {
                                objDak.JelaaKhataNo = "";
                            }

                            if (objDak.Action == "N" || objDak.Action == "E")
                                objDak.Action = "E";
                            else
                                objDak.Action = "A";

                            ClearControls();

                            ddlCategory_rqd.SelectedIndex = -1;
                            ddlSubCategory_rqd.SelectedIndex = -1;
                            ddlItems_rqd.SelectedIndex = -1;

                            ddlCategory_rqd.Enabled = true;
                            ddlSubCategory_rqd.Enabled = true;
                            ddlItems_rqd.Enabled = true;

                            grdDakhila.SelectedIndex = -1;
                            grdDakhila.DataSource = lst;
                            grdDakhila.DataBind();
                  
                        }


                        flag = true;
                    }
                    else
                    {
                        flag = lst.Exists(delegate(ATTInvDakhila objDak)
                                                              {
                                                                  return ((objDak.ItemsCategoryID == int.Parse(ddlCategory_rqd.SelectedValue)) &&
                                                                          (objDak.ItemsSubCategoryID == int.Parse(ddlSubCategory_rqd.SelectedValue)) &&
                                                                          (objDak.ItemsID == int.Parse(ddlItems_rqd.SelectedValue)));
                                                              }

                                                      );

                        if (flag)
                        {
                            this.lblStatusMessageTitle.Text = "दाखिला ";
                            this.lblStatusMessage.Text = " यो सामान पहिले नै दाखिलाको  निमित्त राख्नु भइसक्यो । कृपया अर्को सामान छान्नुहोस्।";
                            this.programmaticModalPopup.Show();


                        }
                    }

                    if(!flag)
                    {
                       

                        ATTInvDakhila objDak = new ATTInvDakhila();
                        objDak.OrgID = orgID;
                        objDak.ItemsCategoryID = int.Parse(ddlCategory_rqd.SelectedValue.ToString());
                        objDak.ItemsCategoryName = ddlCategory_rqd.SelectedItem.ToString();
                        objDak.ItemsSubCategoryID = int.Parse(ddlSubCategory_rqd.SelectedValue.ToString());
                        objDak.ItemsSubCategoryName = ddlSubCategory_rqd.SelectedItem.ToString();
                        objDak.ItemsID = int.Parse(ddlItems_rqd.SelectedValue.ToString());
                        objDak.ItemsName = ddlItems_rqd.SelectedItem.ToString();

                        if(((List<ATTInvItems>)Session["DakhilaItems"]).Count > 0)
                            objDak.ItemsTypeID = ((List<ATTInvItems>)Session["DakhilaItems"])[ddlItems_rqd.SelectedIndex-1].ItemsTypeID;

                        objDak.DirectEntryDate = txtDakhilaDate_RDT.Text;

                        if (chkDonation.Checked)
                        {
                            objDak.DirectEntryType = "A";
                            objDak.DonationOrg = txtDonOrg_rqd.Text;
                        }
                        else
                        {
                            objDak.DirectEntryType = "D";
                            objDak.DonationOrg = "";
                        }

                        if (txtJelaaKhataNo_rqd.Text != "")
                        {
                            objDak.JelaaKhataNo = txtJelaaKhataNo_rqd.Text;
                        }


                        objDak.UnitPrice = double.Parse(txtUnitPrice_rqd.Text.ToString());

                        objDak.Quantity = int.Parse(txtQty_rqd.Text.ToString());

                        if (objDak.Action == "N" || objDak.Action == "E")
                            objDak.Action = "E";
                        else
                            objDak.Action = "A";

                        //objDak.EntryBy = "sj";
                        objDak.EntryBy = entryBy;

                        lst.Add(objDak);

                        grdDakhila.DataSource = lst;
                        grdDakhila.DataBind();

                    }

                    Session["lstDak"] = lst;
                    ClearControls();
                    btnSubmit.Enabled = true;

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "दाखिला ";
                    this.lblStatusMessage.Text = "दाखिला मिति आजको मिति भन्दा पछिको मितिमा राख्न पाइदैन। त्यसैले अर्को दाखिला मिति राख्नुहोस् !!!";
                    this.programmaticModalPopup.Show();

                    return;
                }
            }
            else
            {
                this.lblStatusMessageTitle.Text = "दाखिला ";
                this.lblStatusMessage.Text = "कृपया मिति राख्नुहोस् !!!";
                this.programmaticModalPopup.Show();

                return;
            }
            
           


        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["lstDak"] != null)
            {
                List<ATTInvDakhila> lst = (List<ATTInvDakhila>)Session["lstDak"];
                if (BLLInvDakhila.SaveDakhila(lst))
                {
                    ClearControls();
                    chkDonation.Checked = false;
                    lblDonOrg.Visible = false;
                    txtDonOrg_rqd.Visible = false;
                    lblEntryCount.Text = "";

                    grdDakhila.DataSource = "";
                    grdDakhila.DataBind();

                    this.lblStatusMessageTitle.Text = "दाखिला";
                    this.lblStatusMessage.Text = "दाखिला सफलतापूर्वक सेभ भयो।";
                    this.programmaticModalPopup.Show();
                }
                else
                {
                    this.lblStatusMessageTitle.Text = "दाखिला";
                    this.lblStatusMessage.Text = "दाखिला सेभ गर्दा वाधा उत्पन्न भयो।";
                    this.programmaticModalPopup.Show();
                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }



    }
    protected void btnKnj_Click(object sender, EventArgs e)
    {
        Button btnKNJ = (Button)sender;

        GridViewRow row = (GridViewRow)btnKNJ.NamingContainer;

        Session["grdKnjRow"] = row;

        int qty = int.Parse(row.Cells[14].Text);
        SetItemTbl(qty);

        this.programmaticCommentModalPopup.Show();

    }
    protected void btnKNJ_Click(object sender, EventArgs e)
    {
        try
        {
            int rowIndex = -1;

            List<ATTInvOrgItemsKNJ> lstKNJ = new List<ATTInvOrgItemsKNJ>();
            List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

            if (Session["grdKnjRow"] != null)
            {
                GridViewRow gvRow = (GridViewRow)Session["grdKnjRow"];

                rowIndex = gvRow.RowIndex;
            
  
             
                foreach (GridViewRow row in grdNonExpendible.Rows)
                {
                    ATTInvOrgItemsKNJ objOKnj = new ATTInvOrgItemsKNJ();

                    objOKnj.OrgID = int.Parse(gvRow.Cells[1].Text);
                    objOKnj.ItemsCategoryID = int.Parse(gvRow.Cells[2].Text);
                    objOKnj.ItemsSubCategoryID = int.Parse(gvRow.Cells[3].Text);
                    objOKnj.ItemsID = int.Parse(gvRow.Cells[4].Text);
                    objOKnj.ItemsStatus = "S";
                    objOKnj.Action = "A";
                    objOKnj.EntryBy = entryBy;

                    TextBox txtBox1 = (TextBox)row.FindControl("txtBox1");
                    TextBox txtBox2 = (TextBox)row.FindControl("txtBox2");

                    objOKnj.ItemsAttrib = txtBox1.Text;
                    objOKnj.VehRegNo = txtBox2.Text;

                    lstKNJ.Add(objOKnj);
                }

                if (Session["lstDak"] != null)
                {
                    lst = (List<ATTInvDakhila>)Session["lstDak"];
                }


                if (rowIndex != -1)
                {
                    lst[rowIndex].LstKNJ = lstKNJ;
                    Session["grdKnjRow"] = null;
                    rowIndex = -1;
                }
            }

            this.programmaticCommentModalPopup.Hide();
  

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        DataTable tbl = (DataTable)Session["tblOItemKNJ"];

        grdNonExpendible.DataSource = tbl;
        grdNonExpendible.DataBind();

        this.programmaticCommentModalPopup.Show();
    }

    protected void imbBtnClose2_Click(object sender, ImageClickEventArgs e)
    {
        this.programmaticCommentModalPopup.Hide();
    }

    public bool CompareDate(string date1, string date2)
    {
        try
        {
            string[] d1 = date1.Split('/');
            string[] d2 = date2.Split('/');

            int year1 = int.Parse(d1[0].ToString());
            int month1 = int.Parse(d1[1].ToString());
            int day1 = int.Parse(d1[2].ToString());

            int year2 = int.Parse(d2[0].ToString());
            int month2 = int.Parse(d2[1].ToString());
            int day2 = int.Parse(d2[2].ToString());

            if (year2 > year1)
            {
                return true;
            }
            else if (year1 == year2)
            {
                if (month2 > month1)
                {
                    return true;
                }
                else if (month1 == month2)
                {
                    if (day2 >= day1)
                    {
                        return true;
                    }
                    else if (day2 < day1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }



            return true;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    public void SetItemTbl(int j)
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("VehRegNo");
        DataColumn dtCol1 = new DataColumn("ItemAttrib");
      
        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);

        int i = 0;
        while (i < j)
        {

            DataRow row = tbl.NewRow();
            tbl.Rows.Add(row);


            i++;
        }

        grdNonExpendible.DataSource = tbl;
        grdNonExpendible.DataBind();

        List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

        if (Session["lstDak"] != null)
        {
            lst = (List<ATTInvDakhila>)Session["lstDak"];

            GridViewRow gvRow = (GridViewRow)Session["grdKnjRow"];
            if (lst[gvRow.RowIndex].LstKNJ.Count > 0)
            {
                //string yes = "###";
                ReloadItemKNJ(lst[gvRow.RowIndex].LstKNJ);
            }
        }

       



        Session["tblOItemKNJ"] = tbl;

    }

    public void ReloadItemKNJ(List<ATTInvOrgItemsKNJ> lst)
    {
        try
        {
            int i = 0;
            foreach (GridViewRow row in grdNonExpendible.Rows)
            {
                TextBox txtBox1 = (TextBox)row.FindControl("txtBox1");
                TextBox txtBox2 = (TextBox)row.FindControl("txtBox2");



                txtBox1.Text = lst[i].ItemsAttrib;
                txtBox2.Text = lst[i].VehRegNo;

                i++;
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void ClearControls()
    {
        try
        {
           
            txtQty_rqd.Text = "";
            txtUnitPrice_rqd.Text = "";
            txtJelaaKhataNo_rqd.Text = "";
            
            txtDonOrg_rqd.Text = "";

            txtDakhilaDate_RDT.Text = "";

            grdDakhila.SelectedIndex = -1;

            ddlItems_rqd.SelectedIndex = -1;

            lblJelaaKhataNo.Visible = false;
            txtJelaaKhataNo_rqd.Visible = false;

            ddlCategory_rqd.SelectedIndex = -1;
            ddlSubCategory_rqd.SelectedIndex = -1;

            chkDonation.Checked = false;
            lblDonOrg.Visible = false;
            txtDonOrg_rqd.Visible = false;

            Session["grdKnjRow"] = null;

            btnSubmit.Enabled = true;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

}
