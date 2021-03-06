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


public partial class MODULES_OAS_Inventory_Forms_ApproveDirectEntry : System.Web.UI.Page
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
        try
        {
            LoadCategory();

            Session["objSrchDakhila"] = null;
            Session["SrchDECurrentDate"] = null;

            string dateString = BLLDate.GetDateString(0, 0, "_N");
            if (dateString != null)
            {
                int len = dateString.ToString().Length;
                Session["SrchDECurrentDate"] = dateString.ToString().Substring(0, len - 5);
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
       
    }
    public void LoadCategory()
    {
        try
        {
            Session["SrchDakhilaCat"] = BLLInvItemsCategory.GetItemCategoryList(null, "Y");

            if (Session["SrchDakhilaCat"] != null)
            {
                ddlCategory_rqd.DataSource = Session["SrchDakhilaCat"];
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

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void ddlCategory_rqd_SelectedIndexChanged(object sender, EventArgs e)
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
               
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void ddlSubCategory_rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubCategory_rqd.SelectedIndex > 0)
            {
                ATTInvItems obj = new ATTInvItems();
                obj.ItemsCategoryID = int.Parse(ddlCategory_rqd.SelectedValue);
                obj.ItemsSubCategoryID = int.Parse(ddlSubCategory_rqd.SelectedValue);
                obj.Active = "Y";


                Session["SrchDakhilaItems"] = BLLInvItems.GetInvItems(obj);

                ddlItems_rqd.DataSource = (List<ATTInvItems>)Session["SrchDakhilaItems"];
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

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void ClearControls()
    {
        grdDakhila.SelectedIndex = -1;
        grdDakhila.DataSource = "";
        grdDakhila.DataBind();

        lblEntryCount.Text = "";

        pnlApprove.Visible = false;

        ddlCategory_rqd.SelectedIndex = -1;
        ddlSubCategory_rqd.SelectedIndex = -1;
        ddlItems_rqd.SelectedIndex = -1;
        txtDakhilaDate_RDT.Text = "";
        hdnDate.Value = "";
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
        row.Cells[17].Visible = false;
        row.Cells[18].Visible = false;
        row.Cells[19].Visible = false;  
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
            this.lblEntryCount.Text = "प्रमाणीकरणको निमित्त कुनै दाखिला भेटिएनन्..";
        }
    }
    protected void grdDakhila_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvRow = grdDakhila.SelectedRow;
        txtApproveDate_URDT_appv.Text = "";
        hdnDate.Value = gvRow.Cells[9].Text;

        Session["DeApprvSelectedIndex"] = grdDakhila.SelectedIndex;
        pnlApprove.Visible = true;

        LoadCurrentDate();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            pnlApprove.Visible = false;

            ATTInvSrchDakhila objSrchDakhila = new ATTInvSrchDakhila();

            objSrchDakhila.OrgID = orgID;

            if (ddlCategory_rqd.SelectedIndex > 0)
                objSrchDakhila.ItemsCategoryID = int.Parse(ddlCategory_rqd.SelectedValue);

            if (ddlSubCategory_rqd.SelectedIndex > 0)
                objSrchDakhila.ItemsSubCategoryID = int.Parse(ddlSubCategory_rqd.SelectedValue);

            if (ddlItems_rqd.SelectedIndex > 0)
                objSrchDakhila.ItemsID = int.Parse(ddlItems_rqd.SelectedValue);

            if (txtDakhilaDate_RDT.Text != "")
                objSrchDakhila.DirectEntryDate = txtDakhilaDate_RDT.Text;

            Session["objSrchDakhila"] = objSrchDakhila;
            LoadDirectEntry(objSrchDakhila);

            

        }
        catch (Exception ex)
        {

            throw (ex);
        }

    }

    public void LoadDirectEntry(ATTInvSrchDakhila objSrchDakhila)
    {
        try
        {
            List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

            lst = BLLInvSrchDakhila.SrchDirectEntry(objSrchDakhila);

            if (lst.Count > 0)
            {
                grdDakhila.DataSource = lst;
                grdDakhila.DataBind();

                grdDakhila.SelectedIndex = -1;

                Session["srchedDakhila"] = lst;

            }
            else
            {
                grdDakhila.DataSource = "";
                grdDakhila.DataBind();

                this.lblEntryCount.Text = "प्रमाणीकरणको निमित्त कुनै दाखिला भेटिएनन्..";
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["SrchDECurrentDate"] != null && txtApproveDate_URDT_appv.Text != "")
            {
                if (CompareDate(Session["SrchDECurrentDate"].ToString(), txtApproveDate_URDT_appv.Text))
                {

                    List<ATTInvDakhila> lst = (List<ATTInvDakhila>)Session["srchedDakhila"];

                    int i = int.Parse(Session["DeApprvSelectedIndex"].ToString());

                    ATTInvDakhila objDak = new ATTInvDakhila();
                    objDak.OrgID = lst[i].OrgID;
                    objDak.ItemsCategoryID = lst[i].ItemsCategoryID;
                    objDak.ItemsSubCategoryID = lst[i].ItemsSubCategoryID;
                    objDak.ItemsID = lst[i].ItemsID;
                    objDak.DirectEntrySeq = lst[i].DirectEntrySeq;

                    if (chk_appv.Checked)
                    {
                        objDak.AppYesNo = "Y";
                    }
                    else
                        objDak.AppYesNo = "N";

                    if (txtApproveDate_URDT_appv.Text != "")
                        objDak.AppDate = txtApproveDate_URDT_appv.Text;

                    objDak.AppBy = loginID;

                    objDak.Action = "A";

                    if (BLLInvDakhila.ApproveDakhila(objDak))
                    {
                        //ClearControls();

                        if (Session["objSrchDakhila"] != null)
                        {
                            lblEntryCount.Text = "";
                            pnlApprove.Visible = false;

                            ATTInvSrchDakhila objSrchDakhila = (ATTInvSrchDakhila)Session["objSrchDakhila"];
                            LoadDirectEntry(objSrchDakhila);
                        }
                        else
                        {
                            ClearControls();
                        }

                        this.lblStatusMessageTitle.Text = "दाखिला प्रमाणीकरण";
                        this.lblStatusMessage.Text = "दाखिला प्रमाणीकरण सफलतापूर्वक  भयो।";
                        this.programmaticModalPopup.Show();
                    }
                    else
                    {
                        this.lblStatusMessageTitle.Text = "दाखिला प्रमाणीकरण";
                        this.lblStatusMessage.Text = "दाखिला प्रमाणीकरण गर्दा वाधा उत्पन्न भयो।";
                        this.programmaticModalPopup.Show();
                    }

                }
                else
                {
                    this.lblStatusMessageTitle.Text = "दाखिला प्रमाणीकरण ";
                    this.lblStatusMessage.Text = "दाखिला प्रमाणीकरण  मिति नागीसक्यो !!! त्यसैले अर्को दाखिला प्रमाणीकरण  मिति राख्नुहोस्";
                    this.programmaticModalPopup.Show();

                    return;
                }
            }
            else
            {
                this.lblStatusMessageTitle.Text = "दाखिला प्रमाणीकरण ";
                this.lblStatusMessage.Text = "कृपया दाखिला प्रमाणीकरण  राख्नुहोस् ।!!!";
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
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        chk_appv.Checked = false;
        txtApproveDate_URDT_appv.Text = "";
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

    public void LoadCurrentDate()
    {
        try
        {
            string dateString = BLLDate.GetDateString(0, 0, "_N");
            string currentDate;
            int len;

            if (dateString != null)
            {
                len = dateString.ToString().Length;
                currentDate = dateString.ToString().Substring(0, len - 5);


                txtApproveDate_URDT_appv.Text = currentDate;
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
}
