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

public partial class MODULES_CMS_LookUp_AccountType : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAccountType();
            chkActive.Checked = true;
        }
    }

    void LoadAccountType()
    {

        try
        {
            Session["AccountType"] = BLLAccountType.GetAccountType(null, null, 0);
            List<ATTAccountType> AccountTypeList = (List<ATTAccountType>)Session["AccountType"];
            this.lstAccountType.DataSource = AccountTypeList;
            this.lstAccountType.DataTextField = "AccountTypeName";
            this.lstAccountType.DataValueField = "AccountTypeID";
            this.lstAccountType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtAccountTypeName_RQD.Text == "")
        {
            lblStatusMessage.Text = "खाताको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        int accountType = 0;
        if (lstAccountType.SelectedIndex != -1)
            accountType = int.Parse(lstAccountType.SelectedValue);

        foreach (ListItem lst in lstAccountType.Items)
        {
            if (lst.Selected == true)
                continue;
            if (lst.Text.Trim().ToLower() == txtAccountTypeName_RQD.Text.Trim().ToLower())
            {
                this.lblStatusMessage.Text = "Account Type Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        ATTAccountType objAccountType = new ATTAccountType(accountType, this.txtAccountTypeName_RQD.Text.Trim(), this.chkActive.Checked == true ? "Y" : "N");
        objAccountType.EntryBy = strUser;
        if (this.lstAccountType.SelectedIndex > -1)
            objAccountType.Action = "E";
        else
            objAccountType.Action = "A";

        try
        {
            List<ATTAccountType> ListAccountTypeList = (List<ATTAccountType>)Session["AccountType"];
            BLLAccountType.SaveAccountType(objAccountType);
            if (this.lstAccountType.SelectedIndex > -1)
            {
                ListAccountTypeList[this.lstAccountType.SelectedIndex].AccountTypeID = objAccountType.AccountTypeID;
                ListAccountTypeList[this.lstAccountType.SelectedIndex].AccountTypeName = objAccountType.AccountTypeName;
                ListAccountTypeList[this.lstAccountType.SelectedIndex].Active = objAccountType.Active;
            }
            else
                ListAccountTypeList.Add(objAccountType);
            ClearControls();
            this.lstAccountType.DataSource = ListAccountTypeList;
            this.lstAccountType.DataBind();
            this.lblStatusMessage.Text = "Account Type Successfully Saved.";
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
        this.lstAccountType.SelectedIndex = -1;
        this.txtAccountTypeName_RQD.Text = "";
        this.chkActive.Checked = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTAccountType> ListAccountType = (List<ATTAccountType>)Session["AccountType"];
            this.lstAccountType.SelectedValue = ListAccountType[this.lstAccountType.SelectedIndex].AccountTypeID.ToString();
            this.txtAccountTypeName_RQD.Text = ListAccountType[this.lstAccountType.SelectedIndex].AccountTypeName;
            this.chkActive.Checked = ListAccountType[this.lstAccountType.SelectedIndex].Active == "Y" ? true : false;
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

