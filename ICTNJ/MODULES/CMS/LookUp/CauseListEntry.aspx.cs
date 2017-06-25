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

public partial class MODULES_CMS_LookUp_CauseListEntry : System.Web.UI.Page
{
    string strUser = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            ClearControls();
            LoadCauseList();
        }
    }

    void LoadCauseList()
    {
        try
        {
            Session["CauseList"] = BLLCauseList.GetCauseList(null, null, 0);
            List<ATTCauseList> ListCauseList=(List<ATTCauseList>)Session["CauseList"];
            this.lstCauseList.DataSource=ListCauseList;
            this.lstCauseList.DataTextField = "CauseLISTNAME";
            this.lstCauseList.DataValueField="CauseLISTID";
            this.lstCauseList.DataBind();


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void lstCauseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTCauseList> ListCauseList = (List<ATTCauseList>)Session["CauseList"];
            this.hdnFldCauseListID.Value = ListCauseList[this.lstCauseList.SelectedIndex].CauseListID.ToString();
            this.txtCauseList.Text = ListCauseList[this.lstCauseList.SelectedIndex].CauseListName;
            this.chkActive.Checked = ListCauseList[this.lstCauseList.SelectedIndex].Active == "Y" ? true : false;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTCauseList objCauseList = new ATTCauseList(int.Parse(this.hdnFldCauseListID.Value), this.txtCauseList.Text.Trim(), this.chkActive.Checked == true ? "Y" : "F");
        if (this.lstCauseList.SelectedIndex > -1)
            objCauseList.Action = "E";
        else
            objCauseList.Action = "A";
        objCauseList.EntryBy = strUser;
        try
        {
            List<ATTCauseList> ListCauseList = (List<ATTCauseList>)Session["CauseList"];
            BLLCauseList.SaveCauseList(objCauseList);
            if (this.lstCauseList.SelectedIndex > -1)
            {
                ListCauseList[this.lstCauseList.SelectedIndex].CauseListID = objCauseList.CauseListID;
                ListCauseList[this.lstCauseList.SelectedIndex].CauseListName = objCauseList.CauseListName;
                ListCauseList[this.lstCauseList.SelectedIndex].Active = objCauseList.Active;
            }
            else
                ListCauseList.Add(objCauseList);
            this.lstCauseList.DataSource = ListCauseList;
            this.lstCauseList.DataBind();
            ClearControls();
            this.lblStatusMessage.Text = "CauseList Items Successfully Saved.";
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
        this.lstCauseList.SelectedIndex = -1;
        this.hdnFldCauseListID.Value = "0";
        this.txtCauseList.Text = "";
        this.chkActive.Checked = true;
    }

}
