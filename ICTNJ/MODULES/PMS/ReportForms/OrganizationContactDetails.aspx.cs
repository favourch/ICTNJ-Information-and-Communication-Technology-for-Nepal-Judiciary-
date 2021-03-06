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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using System.Reflection;

using System.Drawing;

/*
 Author: Shanjeev Sah
 Created Date 27 Nov 2010
 */
public partial class MODULES_PMS_ReportForms_OrganizationContactDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //Session["OrgID"] = user.OrgID;
        Session["OrgID"] =user.OrgID;
        if (user.MenuList.ContainsKey("3,49,1") == true)
        {
            if (!IsPostBack)
            {
                GetOrganization();
                Session["LstPhone"] = null;
                Session["LstEmail"] = null;
                Session["LstPhone"] = new List<ATTPhone>();
                Session["LstEmail"] = new List<ATTEmail>();

            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlOrganization.SelectedIndex = -1;
        grdEmail.SelectedIndex = -1;
        grdPhone.SelectedIndex = -1;
        this.lblOrgName.Text = "";
        this.lblEquCode.Text = "";
        this.lblOrgAddress.Text = "";
        this.lblStreet.Text = "";
        this.lblUrl.Text = "";
        this.lblOrgDistrict.Text = "";
        this.lblOrgWardNo.Text = "";
       //this.lblOrgVdcMuni.Text = "";
        //this.lblZone.Text = "";
        this.lblVdcName.Text = "";




        grdEmail.SelectedIndex = -1;
        grdPhone.DataSource = "";
        grdPhone.DataBind();
        grdPhone.SelectedIndex = -1;
        grdEmail.DataSource = "";
        grdEmail.DataBind();
      
    }



    private void GetOrganization()
    {

        try
        {
            List<ATTOrganization> lstOrg;
            lstOrg = BLLOrganization.GetOrganization();

           lstOrg.Insert(0, new ATTOrganization(0, "छान्नुहोस"));

           
            Session["OrgList"] = lstOrg;

            this.ddlOrganization.DataSource = lstOrg;
            this.ddlOrganization.DataTextField = "OrgName";
            this.ddlOrganization.DataValueField = "OrgId";
            this.ddlOrganization.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }




    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();

    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            List<PCS.COMMON.ATT.ATTOrganization> lst = (List<PCS.COMMON.ATT.ATTOrganization>)Session["OrgList"];
            PCS.COMMON.ATT.ATTOrganization obj = lst[ddlOrganization.SelectedIndex];

           // Session["OrgId"] = obj.OrgID.ToString();
            this.lblOrgName.Text = obj.OrgName.Trim();
            this.lblOrgAddress.Text = obj.OrgAddress.ToString().Trim();
            this.lblEquCode.Text = obj.OrgEquCode.ToString().Trim();
            this.lblStreet.Text = obj.OrgStreetName.Trim();
            this.lblUrl.Text = obj.OrgUrl.ToString().Trim();
            this.lblOrgWardNo.Text = obj.OrgWardNo.ToString().Trim();
            //this.lblZone.Text = obj.ZoneName.ToString().Trim();
            this.lblVdcName.Text = obj.NepVdcname.ToString().Trim();
            this.lblOrgDistrict.Text = obj.NepDistname.ToString().Trim();
            this.grdEmail.DataSource = lst[this.ddlOrganization.SelectedIndex].LstEmail;
            this.grdEmail.DataBind();
            this.grdEmail.SelectedIndex = -1;
            Session["LstEmail"] = lst[this.ddlOrganization.SelectedIndex].LstEmail;

            this.grdPhone.DataSource = lst[this.ddlOrganization.SelectedIndex].LstPhone;
            this.grdPhone.DataBind();
            this.grdPhone.SelectedIndex = -1;
            Session["LstPhone"] = lst[this.ddlOrganization.SelectedIndex].LstPhone;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
}


    

