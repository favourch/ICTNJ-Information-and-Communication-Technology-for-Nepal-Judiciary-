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

public partial class MODULES_PMS_LookUp_DocumentTypePopUp : System.Web.UI.Page
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
        if ((user.MenuList.ContainsKey("3,14,1") == true) || (user.MenuList.ContainsKey("2,11,1") == true))
        {
            if (!this.IsPostBack)
            {
                LoadDocumentsType();
                this.txtDocTypeName_rqd.Text = "";
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadDocumentsType()
    {
        try
        {
            List<ATTDocumentsType> lstDocumentsType;
            lstDocumentsType = BLLDocumentsType.GetDocumentsType(null);
            Session["DocumentsType"] = lstDocumentsType;
            this.DocumentsTypeList.DataSource = lstDocumentsType;
            this.DocumentsTypeList.DataTextField = "DocTypeName";
            this.DocumentsTypeList.DataValueField = "DocTypeID";
            this.DocumentsTypeList.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void DocumentsTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DocumentsTypeList.SelectedIndex > -1)
            try
            {
                List<ATTDocumentsType> lstDocumentsType = (List<ATTDocumentsType>)Session["DocumentsType"];
                this.txtDocTypeName_rqd.Text = lstDocumentsType[this.DocumentsTypeList.SelectedIndex].DocTypeName;
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtDocTypeName_rqd.Text = "";
        this.DocumentsTypeList.SelectedIndex = -1;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        List<ATTDocumentsType> lstDocumentsType = (List<ATTDocumentsType>)Session["DocumentsType"];
        int docTypeID = 0;
        try
        {
            if (this.DocumentsTypeList.SelectedIndex > -1)
                docTypeID = lstDocumentsType[this.DocumentsTypeList.SelectedIndex].DocTypeID;

            ATTDocumentsType objDocType = new ATTDocumentsType(docTypeID, this.txtDocTypeName_rqd.Text.Trim());
            ObjectValidation OV = BLLDocumentsType.Validate(objDocType);
            if (OV.IsValid == false)
            {
                lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }

            BLLDocumentsType.SaveDocumentsType(objDocType);

            if (this.DocumentsTypeList.SelectedIndex > -1)
                lstDocumentsType[this.DocumentsTypeList.SelectedIndex].DocTypeName = this.txtDocTypeName_rqd.Text.Trim();
            else
            {
                objDocType = new ATTDocumentsType(objDocType.DocTypeID, this.txtDocTypeName_rqd.Text.Trim());
                lstDocumentsType.Add(objDocType);
            }

            this.DocumentsTypeList.DataSource = lstDocumentsType;
            this.lblStatusMessage.Text = "Documents Type Saved Successfully. ";
            this.programmaticModalPopup.Show();
            this.DocumentsTypeList.DataBind();
            this.txtDocTypeName_rqd.Text = "";
            this.DocumentsTypeList.SelectedIndex = -1;
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
