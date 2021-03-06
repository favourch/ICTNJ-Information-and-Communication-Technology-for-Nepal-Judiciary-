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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using System.Collections.Generic;

public partial class MODULES_CMS_LookUp_RegistrationType : System.Web.UI.Page
{
    string strUser = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ClearControls();
            LoadRegistrationType();
        }
    }

    void LoadRegistrationType()
    {

        try
        {
            Session["RegistrationType"] = BLLRegistrationType.GetRegistrationType(null, null, 0);
            List<ATTRegistrationType> RegTypeList = (List<ATTRegistrationType>)Session["RegistrationType"];
            this.lstRegistrationType.DataSource = RegTypeList;
            this.lstRegistrationType.DataTextField = "REGTYPENAME";
            this.lstRegistrationType.DataValueField = "REGTYPEID";
            this.lstRegistrationType.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtRegTypeName_RQD.Text == "")
        {
            lblStatusMessage.Text = "दर्ताको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        ATTRegistrationType objRegTypeList = new ATTRegistrationType(int.Parse(this.hdnFldRegTypeID.Value), this.txtRegTypeName_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objRegTypeList.EntryBy = strUser;
        if (this.lstRegistrationType.SelectedIndex > -1)
            objRegTypeList.Action = "E";
        else
            objRegTypeList.Action = "A";
        try
        {
            List<ATTRegistrationType> ListRgTypeList = (List<ATTRegistrationType>)Session["RegistrationType"];
            BLLRegistrationType.SaveRegistrationType(objRegTypeList);
            if (this.lstRegistrationType.SelectedIndex > -1)
            {
                ListRgTypeList[this.lstRegistrationType.SelectedIndex].RegTypeID = objRegTypeList.RegTypeID;
                ListRgTypeList[this.lstRegistrationType.SelectedIndex].RegTypeName = objRegTypeList.RegTypeName;
                ListRgTypeList[this.lstRegistrationType.SelectedIndex].Active = objRegTypeList.Active;
            }
            else
                ListRgTypeList.Add(objRegTypeList);
            ClearControls();
            this.lstRegistrationType.DataSource = ListRgTypeList;
            this.lstRegistrationType.DataBind();
            this.lblStatusMessage.Text = "Registration Type Successfully Saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        this.lstRegistrationType.SelectedIndex = -1;
        this.hdnFldRegTypeID.Value = "0";
        this.txtRegTypeName_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTRegistrationType> ListRegistrationType = (List<ATTRegistrationType>)Session["RegistrationType"];
            this.hdnFldRegTypeID.Value = ListRegistrationType[this.lstRegistrationType.SelectedIndex].RegTypeID.ToString();
            this.txtRegTypeName_RQD.Text = ListRegistrationType[this.lstRegistrationType.SelectedIndex].RegTypeName;
            this.chkActive.Checked = ListRegistrationType[this.lstRegistrationType.SelectedIndex].Active == "Y" ? true : false;
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
