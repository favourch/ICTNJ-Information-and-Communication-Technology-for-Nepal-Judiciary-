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
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_Common_LookUp_Religion : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value) == 10)
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
        this.Title = "PMS | Religion";
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
        if (user.MenuList.ContainsKey("3,28,1") == true)
        {
            if (!this.IsPostBack)
            {
                LoadReligions();
                ClearComponents();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void ClearComponents()
    {
        this.txtRelgNepName_rqd.Text = "";
        this.txtRelgEngName.Text = "";
        this.grdReligions.SelectedIndex = -1;
    }

    void LoadReligions()
    {
        try
        {
            List<ATTReligion> lstReligions;
            lstReligions = BLLReligion.GetReligions(null, 1);
            Session["Religions"] = lstReligions;
            this.grdReligions.DataSource = lstReligions;
            this.grdReligions.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdReligions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void grdReligions_SelectedIndexChanged(object sender, EventArgs e)
    {       
        if (this.grdReligions.SelectedIndex>-1)
        {
            List<ATTReligion> lstReligions = (List<ATTReligion>)Session["Religions"];
            this.txtRelgNepName_rqd.Text = lstReligions[this.grdReligions.SelectedIndex].ReligionNepName;
            this.txtRelgEngName.Text = lstReligions[this.grdReligions.SelectedIndex].ReligionEngName;

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblStatusMessage.Text = "";

            List<ATTReligion> lstReligions = (List<ATTReligion>)Session["Religions"];

            int religionID = 0;
            if (this.grdReligions.SelectedIndex > -1)
                religionID = lstReligions[this.grdReligions.SelectedIndex].ReligionId;

            ATTReligion objReligions = new ATTReligion(religionID, this.txtRelgNepName_rqd.Text.Trim(), this.txtRelgEngName.Text.Trim());
            religionID = BLLReligion.SaveReligions(objReligions);

            if (this.grdReligions.SelectedIndex > -1)
            {
                lstReligions[this.grdReligions.SelectedIndex].ReligionId = religionID;
                lstReligions[this.grdReligions.SelectedIndex].ReligionNepName = this.txtRelgNepName_rqd.Text.Trim();
                lstReligions[this.grdReligions.SelectedIndex].ReligionEngName = this.txtRelgEngName.Text.Trim();
            }
            else
            {
                ATTReligion objNewReligions = new ATTReligion(religionID, this.txtRelgNepName_rqd.Text.Trim(), this.txtRelgEngName.Text.Trim());
                lstReligions.Add(objNewReligions);
            }


            Session["Religions"] = lstReligions;
            this.grdReligions.DataSource = lstReligions;
            ClearComponents();
            this.lblStatusMessage.Text = "Successfully Saved";
            this.programmaticModalPopup.Show();
            this.grdReligions.DataBind();


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
