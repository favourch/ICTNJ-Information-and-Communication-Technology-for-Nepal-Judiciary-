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

public partial class MODULES_CMS_Misil_DocumentType : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCaseDocumentType();
            chkActive.Checked = true;
        }
    }
    void LoadCaseDocumentType()
    {

        try
        {
            Session["CaseDocumentType"] = BLLCaseDocumentType.GetCaseDocumentType(null, null, 0);
            List<ATTCaseDocumentType> CaseDocumentTypeList = (List<ATTCaseDocumentType>)Session["CaseDocumentType"];
            this.lstCaseDocumentType.DataSource = CaseDocumentTypeList;
            this.lstCaseDocumentType.DataTextField = "CaseDocumentTypeName";
            this.lstCaseDocumentType.DataValueField = "CaseDocumentTypeID";
            this.lstCaseDocumentType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtCaseDocumentTypeName_RQD.Text == "")
        {
            lblStatusMessage.Text = "कागजपत्रको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        int CaseDocumentType = 0;
        if (lstCaseDocumentType.SelectedIndex != -1)
            CaseDocumentType = int.Parse(lstCaseDocumentType.SelectedValue);

        foreach (ListItem lst in lstCaseDocumentType.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtCaseDocumentTypeName_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Case Document type Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTCaseDocumentType objCaseDocumentType = new ATTCaseDocumentType(CaseDocumentType, this.txtCaseDocumentTypeName_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objCaseDocumentType.EntryBy = strUser;
        if (this.lstCaseDocumentType.SelectedIndex > -1)
            objCaseDocumentType.Action = "E";
        else
            objCaseDocumentType.Action = "A";

        try
        {
            List<ATTCaseDocumentType> ListCaseDocumentTypeList = (List<ATTCaseDocumentType>)Session["CaseDocumentType"];
            BLLCaseDocumentType.SaveCaseDocumentType(objCaseDocumentType);
            if (this.lstCaseDocumentType.SelectedIndex > -1)
            {
                ListCaseDocumentTypeList[this.lstCaseDocumentType.SelectedIndex].CaseDocumentTypeID = objCaseDocumentType.CaseDocumentTypeID;
                ListCaseDocumentTypeList[this.lstCaseDocumentType.SelectedIndex].CaseDocumentTypeName = objCaseDocumentType.CaseDocumentTypeName;
                ListCaseDocumentTypeList[this.lstCaseDocumentType.SelectedIndex].Active = objCaseDocumentType.Active;
            }
            else
                ListCaseDocumentTypeList.Add(objCaseDocumentType);
            ClearControls();
            this.lstCaseDocumentType.DataSource = ListCaseDocumentTypeList;
            this.lstCaseDocumentType.DataBind();
            this.lblStatusMessage.Text = "Case Document type  Successfully Saved.";
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
        this.lstCaseDocumentType.SelectedIndex = -1;
        this.txtCaseDocumentTypeName_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstCaseDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCaseDocumentType> ListCaseDocumentType = (List<ATTCaseDocumentType>)Session["CaseDocumentType"];
            this.lstCaseDocumentType.SelectedValue = ListCaseDocumentType[this.lstCaseDocumentType.SelectedIndex].CaseDocumentTypeID.ToString();
            this.txtCaseDocumentTypeName_RQD.Text = ListCaseDocumentType[this.lstCaseDocumentType.SelectedIndex].CaseDocumentTypeName;
            this.chkActive.Checked = ListCaseDocumentType[this.lstCaseDocumentType.SelectedIndex].Active == "Y" ? true : false;
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

