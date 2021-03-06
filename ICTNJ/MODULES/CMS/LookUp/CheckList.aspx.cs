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

public partial class MODULES_CMS_LookUp_CheckList : System.Web.UI.Page
{
    string strUser = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            ClearControls();
            LoadCheckList();
        }
        
    }

    void LoadCheckList()
    {

        try
        {
            Session["CheckList"] = BLLCheckList.GetCheckList(null, null,0);
            List<ATTCheckList> ListCheckList = (List<ATTCheckList>)Session["CheckList"];
            this.lstCheckList.DataSource = ListCheckList;
            this.lstCheckList.DataTextField = "CHECKLISTNAME";
            this.lstCheckList.DataValueField = "CHECKLISTID";
            this.lstCheckList.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (this.ddlCheckListType.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "चेकलिष्टको किसिम छान्नहोस।";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTCheckList objCheckList = new ATTCheckList(int.Parse(this.hdnFldCheckListID.Value), this.txtCheckList.Text.Trim(), this.chkActive.Checked == true ? "Y" : "F");
        objCheckList.CheckListType = this.ddlCheckListType.SelectedValue;
        if (this.lstCheckList.SelectedIndex > -1)
            objCheckList.Action = "E";
        else
            objCheckList.Action = "A";
        objCheckList.EntryBy = strUser;
        try
        {
            List<ATTCheckList> ListCheckList = (List<ATTCheckList>)Session["CheckList"];
            BLLCheckList.SaveCheckList(objCheckList);
            if (this.lstCheckList.SelectedIndex > -1)
            {
                ListCheckList[this.lstCheckList.SelectedIndex].CheckListID = objCheckList.CheckListID;
                ListCheckList[this.lstCheckList.SelectedIndex].CheckListName = objCheckList.CheckListName;
                ListCheckList[this.lstCheckList.SelectedIndex].Active = objCheckList.Active;
                ListCheckList[this.lstCheckList.SelectedIndex].CheckListType = objCheckList.CheckListType;
            }
            else
                ListCheckList.Add(objCheckList);
            this.lstCheckList.DataSource = ListCheckList;
            this.lstCheckList.DataBind();
            ClearControls();
            this.lblStatusMessage.Text = "CheckList Items Successfully Saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.lstCheckList.SelectedIndex = -1;
        this.hdnFldCheckListID.Value = "0";
        this.txtCheckList.Text = "";
        this.chkActive.Checked = true;
        this.ddlCheckListType.SelectedValue = "0";
        
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void lstCheckList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCheckList> ListCheckList = (List<ATTCheckList>)Session["CheckList"];
            this.hdnFldCheckListID.Value = ListCheckList[this.lstCheckList.SelectedIndex].CheckListID.ToString();
            this.txtCheckList.Text = ListCheckList[this.lstCheckList.SelectedIndex].CheckListName;
            this.chkActive.Checked = ListCheckList[this.lstCheckList.SelectedIndex].Active == "Y" ? true : false;
            this.ddlCheckListType.SelectedValue = ListCheckList[this.lstCheckList.SelectedIndex].CheckListType;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
}
