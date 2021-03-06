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

public partial class MODULES_CMS_LookUp_AinType : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAinType();
            chkActive.Checked = true;
        }
    }

    void LoadAinType()
    {
        try
        {
            Session["AinType"] = BLLAinType.GetAinType(null, null, 0);
            List<ATTAinType> AinTypeList = (List<ATTAinType>)Session["AinType"];
            this.lstAinType.DataSource = AinTypeList;
            this.lstAinType.DataTextField = "AINTYPENAME";
            this.lstAinType.DataValueField = "AINTYPEID";
            this.lstAinType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtAinTypeName_RQD.Text == "")
        {
            lblStatusMessage.Text = "ऐनको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        int ainType = 0;
        if(lstAinType.SelectedIndex!=-1)
            ainType=int.Parse(lstAinType.SelectedValue);

        foreach (ListItem lst in lstAinType.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtAinTypeName_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Ain Type Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTAinType objAinType = new ATTAinType(ainType, this.txtAinTypeName_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objAinType.EntryBy = strUser;
        if (this.lstAinType.SelectedIndex > -1)
            objAinType.Action = "E";
        else
            objAinType.Action = "A";

        try
       { 
            List<ATTAinType> ListAinTypeList = (List<ATTAinType>)Session["AinType"];
            BLLAinType.SaveAinType(objAinType);
            if (this.lstAinType.SelectedIndex > -1)
            {
                ListAinTypeList[this.lstAinType.SelectedIndex].AinTypeID = objAinType.AinTypeID;
                ListAinTypeList[this.lstAinType.SelectedIndex].AinTypeName = objAinType.AinTypeName;
                ListAinTypeList[this.lstAinType.SelectedIndex].Active = objAinType.Active;
            }
            else
                ListAinTypeList.Add(objAinType);
            ClearControls();
            this.lstAinType.DataSource = ListAinTypeList;
            this.lstAinType.DataBind();
            this.lblStatusMessage.Text = "Ain Type Successfully Saved.";
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
        this.lstAinType.SelectedIndex = -1;
        this.txtAinTypeName_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstAinType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {   
            List<ATTAinType> ListAinType = (List<ATTAinType>)Session["AinType"];
            this.lstAinType.SelectedValue = ListAinType[this.lstAinType.SelectedIndex].AinTypeID.ToString();
            this.txtAinTypeName_RQD.Text = ListAinType[this.lstAinType.SelectedIndex].AinTypeName;
            this.chkActive.Checked = ListAinType[this.lstAinType.SelectedIndex].Active == "Y" ? true : false;
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
