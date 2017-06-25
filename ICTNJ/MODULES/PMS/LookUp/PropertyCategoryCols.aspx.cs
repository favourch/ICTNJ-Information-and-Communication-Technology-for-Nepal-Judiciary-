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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;

public partial class MODULES_PMS_LookUp_PropertyCategoryCols : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["SetUpPropCatList"] = null;
            Session["LstPropCatCols"] = null;
            LoadPropertyCategory();
            txtColName.ReadOnly = true;
            dllColNo.Enabled = false;
            dllColDType.Enabled = false;
            chkActive.Enabled = false;
            chkActive.Checked = false;
            btnAdd.Visible = false;
        }
    }

    public void LoadPropertyCategory()
    {
        try
        {
            Session["SetUpPropCatList"] = BLLPropertyCategory.GetPropertyCateogryList(null);

            this.dllPropCat.DataSource = (List<ATTPropertyCategory>)Session["SetUpPropCatList"];
            this.dllPropCat.DataTextField = "PCategoryName";
            this.dllPropCat.DataValueField = "PCategoryID";
            this.dllPropCat.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Category";
            a.Value = "0";
            dllPropCat.Items.Insert(0, a);
          

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int proCatID = 0;
            int colNo = 0;
            string colName ="";
            string colDataType = "";
            string active;
            List<ATTPropertyCategoryColumns> lstPCCols = new List<ATTPropertyCategoryColumns>();
           
            if (Session["LstPropCatCols"] != null)
            {
                lstPCCols = (List<ATTPropertyCategoryColumns>)Session["LstPropCatCols"];
            }

            if(dllPropCat.SelectedIndex > 0)
                proCatID = int.Parse(dllPropCat.SelectedValue.ToString());

            if (txtColName.Text != "")
                colName = txtColName.Text;

            if (dllColNo.SelectedIndex > 0)
                colNo = int.Parse(dllColNo.SelectedValue.ToString());

            if (dllColDType.SelectedIndex > 0)
                colDataType = dllColDType.SelectedValue;

            if (chkActive.Checked)
                active = "Y";
            else
                active = "N";

            lstPCCols.Add(new ATTPropertyCategoryColumns(proCatID, colNo,colName,colDataType,active));
            Session["LstPropCatCols"] = lstPCCols;

            this.grdPropCatCols.DataSource = Session["LstPropCatCols"];
            this.grdPropCatCols.DataBind();

            this.txtColName.Text = "";
            //this.dllPropCat.SelectedIndex = -1;
            this.dllColNo.SelectedIndex = -1;
            this.dllColDType.SelectedIndex = -1;
            this.chkActive.Checked = false;
            this.btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTPropertyCategoryColumns> lstPCCols = new List<ATTPropertyCategoryColumns>();
        if (Session["LstPropCatCols"] != null)
        {
            lstPCCols = (List<ATTPropertyCategoryColumns>)Session["LstPropCatCols"];

            if (BLLPropertyCategoryColumns.SavePropertyCategoryCols(lstPCCols))
            {
                this.lblStatus.Text = "Proporty Category Saved Successfully.";
                this.programmaticModalPopup.Show();
                this.grdPropCatCols.DataSource = null;
                this.grdPropCatCols.DataBind();

                dllPropCat.SelectedIndex = -1;
                dllColNo.SelectedIndex = -1;
                dllColDType.SelectedIndex = -1;
                txtColName.ReadOnly = true;
                dllColNo.Enabled = false;
                dllColDType.Enabled = false;
                chkActive.Enabled = false;
                chkActive.Checked = false;

                this.btnSave.Visible = false;

                Session["LstPropCatCols"] = null;
            }
        }
    }
    protected void dllPropCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.dllPropCat.SelectedIndex > 0)
        {

            List<ATTPropertyCategory> lstPCC = (List<ATTPropertyCategory>)Session["SetUpPropCatList"];

            ATTPropertyCategory objPC = new ATTPropertyCategory();

            objPC = lstPCC.Find(
                                    delegate(ATTPropertyCategory objProCat)
                                    {
                                        return objProCat.PCategoryID == int.Parse(this.dllPropCat.SelectedValue);
                                    }

                                );

            //int totalCols = objPC.NoOfCols;
            if (objPC.NoOfCols > 0)
            {
                LoadNoOfCols(objPC.NoOfCols);
                txtColName.ReadOnly = false;
                this.dllColNo.Enabled = true;
                this.dllColDType.Enabled = true;
                this.chkActive.Checked = false;
                chkActive.Enabled = true;
                btnAdd.Visible = true;

                grdPropCatCols.DataSource = null;
                grdPropCatCols.DataBind();
                Session["LstPropCatCols"] = null;
            }
            else
            {
                txtColName.ReadOnly = true;
                dllColNo.Enabled = false;
                dllColDType.Enabled = false;
                chkActive.Checked = false;
                chkActive.Enabled = false;
                btnAdd.Visible = false;
            }


        }
        else
        {
            txtColName.ReadOnly = true;
            dllColNo.Enabled = false;
            dllColDType.Enabled = false;
            chkActive.Enabled = false;
            btnAdd.Visible = false;
        }
    }

    public void LoadNoOfCols(int totalCols)
    {
        try
        {
            this.dllColNo.Items.Clear();

            for (int i = 0; i < totalCols; i++)
            {
                ListItem b = new ListItem();
                b.Selected = false;
                b.Text = (i+1).ToString();
                b.Value = (i + 1).ToString();
                dllColNo.Items.Insert(i, b);

            }

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Column";
            a.Value = "0";
            dllColNo.Items.Insert(0, a);
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
}
