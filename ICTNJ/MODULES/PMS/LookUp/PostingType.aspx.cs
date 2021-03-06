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

using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_PostingType : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["ApplicationID"] != null)
        {
            if (Session["ApplicationID"].ToString() == "2")
            {
                this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
                this.Title = "LJMS | Posting Type";
            }
            else if (Session["ApplicationID"].ToString() == "3")
            {
                this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
                this.Title = "PMS | Posting Type";
            }
        }
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
        if ((user.MenuList.ContainsKey("3,24,1") == true) || (user.MenuList.ContainsKey("2,8,1") == true))
        {

            if (!this.IsPostBack)
                LoadPostingType();
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadPostingType()
    {
        try
        {
            List<ATTPostingType> lstPostingTypes = BLLPostingType.GetPostingType(null, null);
            Session["PostingType"] = lstPostingTypes;
            this.lstPostingType.DataSource = lstPostingTypes;
            this.lstPostingType.DataTextField = "POSTINGTYPENAME";
            this.lstPostingType.DataValueField = "POSTINGTYPEID";
            this.lstPostingType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstPostingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTPostingType> lstPostingTypes = (List<ATTPostingType>)Session["PostingType"];
        this.txtPostingType_Rqd.Text = lstPostingTypes[this.lstPostingType.SelectedIndex].PostingTypeName;
        string chkd = lstPostingTypes[this.lstPostingType.SelectedIndex].Active;
        if (chkd == "Y")
        {
            this.chkPostingType.Checked = true;
        }
        else
        {
            this.chkPostingType.Checked = false;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtPostingType_Rqd.Text = "";
        this.lstPostingType.SelectedIndex = -1;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTPostingType> lstPostingTypes = (List<ATTPostingType>)Session["PostingType"];
        int intPostingTypeID=0;
        string strActive;

        if (this.lstPostingType.SelectedIndex>-1)
            intPostingTypeID=lstPostingTypes[this.lstPostingType.SelectedIndex].PostingTypeID;
        if (this.chkPostingType.Checked == true)
        {
            strActive = "Y";
        }
        else
        {
            strActive = "N";
        }

        ATTPostingType objPostingType;
        try
        {
            objPostingType = new ATTPostingType(intPostingTypeID, this.txtPostingType_Rqd.Text.Trim(), strActive);
            ObjectValidation OV = BLLPostingType.Validate(objPostingType);
            if (!OV.IsValid)
            {
                this.lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }

            for (int i = 0; i < lstPostingType.Items.Count; i++)
            {
                if (lstPostingType.SelectedIndex != i)
                {
                    if (lstPostingTypes[i].PostingTypeName.ToLower() == txtPostingType_Rqd.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "**नियुक्तिको प्रकार पहिले नै छ";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }

            if (BLLPostingType.SavePostingType(objPostingType))
            {
                if (this.lstPostingType.SelectedIndex == -1)
                {
                    this.lblStatusMessage.Text = "Posting Type Successfully Saved";
                    this.programmaticModalPopup.Show();
                }
                else
                {
                    this.lblStatusMessage.Text = "Posting Type Successfully Updated";
                    this.programmaticModalPopup.Show();
                }
            }
            if (this.lstPostingType.SelectedIndex == -1)
                lstPostingTypes.Add(objPostingType);
            else
            {
                lstPostingTypes[this.lstPostingType.SelectedIndex].PostingTypeName = this.txtPostingType_Rqd.Text.Trim();
                lstPostingTypes[this.lstPostingType.SelectedIndex].Active = strActive;
            }
            this.lstPostingType.DataSource = lstPostingTypes;
            this.lstPostingType.DataBind();
            this.txtPostingType_Rqd.Text = "";
            this.txtPostingType_Rqd.Focus();
            this.lstPostingType.SelectedIndex = -1;
        }

        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
