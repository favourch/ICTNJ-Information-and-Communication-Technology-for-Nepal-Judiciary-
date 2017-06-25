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
using System.Reflection;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
//using PCS.SECURITY.BLL;
using PCS.FRAMEWORK;


public partial class MODULES_Common_LookUp_Country : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value) == 10)
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
        this.Title = "PMS | Countries";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,27,1") == true)
        {
            if (this.IsPostBack == false)
            {
                LoadCountries();
                ClearComponents();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadCountries()
    {
        try
        {
            List<ATTCountry> lstCountries;
            lstCountries = BLLCountry.GetCountries(null, 1);
            Session["Countries"] = lstCountries;
            this.grdCountries.DataSource = lstCountries;
            this.grdCountries.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearComponents()
    {
        this.txtCountryNepName_rqd.Text = "";
        this.txtCountryEngName.Text = "";
        this.txtCountryCode.Text = "";
        this.grdCountries.SelectedIndex = -1;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblStatusMessage.Text = "";

            List<ATTCountry> lstCountries = (List<ATTCountry>)Session["Countries"];

            int CountryID = 0;
            if (this.grdCountries.SelectedIndex > -1)
                CountryID = lstCountries[this.grdCountries.SelectedIndex].CountryId;

            ATTCountry objCountries = new ATTCountry(CountryID, this.txtCountryNepName_rqd.Text.Trim(), this.txtCountryEngName.Text.Trim(),this.txtCountryCode.Text.Trim());
            CountryID = BLLCountry.SaveCountries(objCountries);

            if (this.grdCountries.SelectedIndex > -1)
            {
                lstCountries[this.grdCountries.SelectedIndex].CountryId = CountryID;
                lstCountries[this.grdCountries.SelectedIndex].CountryNepName = this.txtCountryNepName_rqd.Text.Trim();
                lstCountries[this.grdCountries.SelectedIndex].CountryEngName = this.txtCountryEngName.Text.Trim();
                lstCountries[this.grdCountries.SelectedIndex].CountryCode = this.txtCountryCode.Text.Trim();
            }
            else
            {
                ATTCountry objNewCountries = new ATTCountry(CountryID, this.txtCountryNepName_rqd.Text.Trim(), this.txtCountryEngName.Text.Trim(), this.txtCountryCode.Text.Trim());
                lstCountries.Add(objNewCountries);
            }


            Session["Countries"] = lstCountries;
            this.grdCountries.DataSource = lstCountries;
            ClearComponents();
            this.lblStatusMessage.Text = "Successfully Saved";
            this.programmaticModalPopup.Show();
            this.grdCountries.DataBind();


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearComponents();
    }

    protected void grdCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (grdCountries.SelectedIndex > -1)
        {
            List<ATTCountry> lstCountries = (List < ATTCountry >) Session["Countries"];
            this.txtCountryNepName_rqd.Text = lstCountries[this.grdCountries.SelectedIndex].CountryNepName;
            this.txtCountryEngName.Text = lstCountries[this.grdCountries.SelectedIndex].CountryEngName;
            this.txtCountryCode.Text = lstCountries[this.grdCountries.SelectedIndex].CountryCode;
        }
    }

    protected void grdCountries_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
}
