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

public partial class MODULES_PMS_LookUp_PropertyCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["LstPropCat"] = null;

            lblMasterType.Visible = false;
            dllMasterType.Visible = false;

        }

    }

    public void LoadMasterType()
    {
        try
        {
            List<ATTPropertyCategory> lst = new List<ATTPropertyCategory>();
            List<ATTPropertyCategory> lstMasterPropCat = new List<ATTPropertyCategory>();
           
            Session["SetUpMasterPropCatList"] = BLLPropertyCategory.GetPropertyCateogryList(null);
           

            lst = (List<ATTPropertyCategory>)Session["SetUpMasterPropCatList"];


            //List<ATTEvent> lst = new List<ATTEvent>();

            lstMasterPropCat = lst.FindAll(
                                                delegate(ATTPropertyCategory objPropCat)
                                                {
                                                    return objPropCat.MasterType == "0";
                                                }

                                             );

            if (lstMasterPropCat.Count > 0)
            {
                this.dllMasterType.DataSource = lstMasterPropCat;
                this.dllMasterType.DataTextField = "PCategoryName";
                this.dllMasterType.DataValueField = "PCategoryID";
                this.dllMasterType.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                dllMasterType.Items.Insert(0, a);

                lblMasterType.Visible = true;
                dllMasterType.Visible = true;
            }
            else
            {
                lblMasterType.Visible = false;
                dllMasterType.Visible = false;
            }

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
                List<ATTPropertyCategory> lstPCC = new List<ATTPropertyCategory>();
                if (Session["LstPropCat"] != null)
                {
                    lstPCC = (List<ATTPropertyCategory>)Session["LstPropCat"];
                }

                string propCatName,active,income,type="";
                int masterType = 0;
                int noOfCols = 0;

                propCatName = txtCatName.Text;
                
                if(dllNoOfCols.SelectedIndex > -1 )
                    noOfCols = int.Parse(dllNoOfCols.SelectedValue.ToString());

                if (dllType.SelectedIndex > -1)
                    type = dllType.SelectedValue.ToString();

                if (dllMasterType.SelectedIndex > -1)
                    masterType = int.Parse(dllMasterType.SelectedValue.ToString());

                if (chkActive.Checked)
                    active = "Y";
                else
                    active = "N";

                if (chkIncome.Checked)
                    income = "Y";
                else
                    income = "N";

                lstPCC.Add(new ATTPropertyCategory(propCatName,noOfCols, active,income,type,masterType.ToString()));

                ObjectValidation OV = BLLPropertyCategory.ValidatePropertyCategory(lstPCC);

                if (OV.IsValid == false)
                {
                    this.lblStatus.Text = OV.ErrorMessage;
                    return;
                }

                Session["LstPropCat"] = lstPCC;

                this.grdPropCat.DataSource = Session["LstPropCat"];
                this.grdPropCat.DataBind();

                this.txtCatName.Text = "";
                this.dllNoOfCols.SelectedIndex = -1;
                this.chkActive.Checked = false;
                this.chkIncome.Checked = false;
                this.btnSave.Visible = true;


            
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTPropertyCategory> lstPCC = new List<ATTPropertyCategory>();
        if (Session["LstPropCat"] != null)
        {
            lstPCC = (List<ATTPropertyCategory>)Session["LstPropCat"];
           
            if (BLLPropertyCategory.SavePropertyCategory(lstPCC))
            {
                this.grdPropCat.DataSource = null;
                this.grdPropCat.DataBind();

                this.btnSave.Visible = false;

                Session["LstPropCat"] = null;
            }
        }
    }
    protected void dllNoOfCols_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(dllNoOfCols.SelectedValue) > 0)
        {
            LoadMasterType();
        }
        else
        {
            lblMasterType.Visible = false;
            dllMasterType.Visible = false;
        }
    }
}
