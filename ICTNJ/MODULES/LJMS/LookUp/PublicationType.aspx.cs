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

using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.PMS.DLL;
using PCS.COMMON;
using PCS.COMMON.ATT;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_LJMS_LookUp_PublicationType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if ((user.MenuList.ContainsKey("3,17,1") == true) || (user.MenuList.ContainsKey("2,12,1") == true))
        {
        this.chkActive.Checked = true;

        if (IsPostBack == false)
        {
            GetPublicationType();
        }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    public void GetPublicationType()
    {
        List<ATTPublicationType> LSTPublicationType = BLLPublicationType.GetPublicationType(null,null);
        lstPubType.DataSource = LSTPublicationType;
        lstPubType.DataTextField = "PubTypeName";
        lstPubType.DataValueField = "PubTypeID";
        lstPubType.DataBind();
        Session["PublicationTypes"] = LSTPublicationType;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtPublicationType.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTPublicationType> LSTPubType = (List<ATTPublicationType>)Session["PublicationTypes"];
        ATTPublicationType obj = new ATTPublicationType();
        int? PubID = 0;
        if (this.txtPublicationType.Text == "")
        {
            this.lblStatusMessage.Text = "र्कपया पब्लिकेसनको किसिम छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }

        if (this.lstPubType.SelectedIndex > -1)
        {
            PubID = int.Parse(LSTPubType[this.lstPubType.SelectedIndex].PubTypeID.ToString());
        }

        if (this.lstPubType.SelectedIndex < 0)
        {

            obj = LSTPubType.Find
                               (
                                   delegate(ATTPublicationType objPbType)
                                   {
                                       return objPbType.PubTypeName.ToLower() == this.txtPublicationType.Text.ToLower();
                                   }
                               );

            if (obj != null)
            {
                this.lblStatusMessage.Text = "पब्लिकेशनको किसिम पहिले नै उपलब्द छ";
                this.programmaticModalPopup.Show();
                return;
            }

            PubID = 0;
        }

        ATTPublicationType objPubType = new ATTPublicationType(PubID, this.txtPublicationType.Text.Trim(), (this.chkActive.Checked) ? "Y" : "N", "jipin", (lstPubType.SelectedIndex < 0) ? "A" : "E");

        try
        {
            if (BLLPublicationType.SavePublicationType(objPubType) == true)
            {
                if (this.lstPubType.SelectedIndex < 0)
                {
                    LSTPubType.Add(objPubType);
                }
                else if (this.lstPubType.SelectedIndex >-1)
                {
                    LSTPubType[lstPubType.SelectedIndex].PubTypeName = this.txtPublicationType.Text.ToString().Trim();
                }
                lstPubType.DataSource = LSTPubType;
                lstPubType.DataTextField = "PubTypeName";
                lstPubType.DataValueField = "PubTypeID";
                lstPubType.DataBind();
                this.txtPublicationType.Text = "";
                this.lblStatusMessage.Text = "पब्लिकेशनको किसिम सेभ भयो";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
           this.lblStatusMessage.Text=ex.Message;
           this.programmaticModalPopup.Show();
        }
    }
    protected void lstPubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTPublicationType> lstPubTypes = (List<ATTPublicationType>)Session["PublicationTypes"];
        this.txtPublicationType.Text = lstPubTypes[this.lstPubType.SelectedIndex].PubTypeName;
    }
}

