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

using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_LookUp_LitigantSubType : System.Web.UI.Page
{
    string entryBy = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["Login_User_Detail"] == null)
        //{
        //    Response.Redirect("~/MODULES/Login.aspx", true);
        //}

        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = "bikash"; //user.OrgID;
        //if (user.MenuList.ContainsKey("Course Management") == true)
        //{
        if (!Page.IsPostBack)
        {
            LoadLitigantSubType();
        }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);

    }

    private void LoadLitigantSubType()
    {
        try
        {
            List<ATTLitigantSubType> litigantStatusLIST = BLLLitigantSubType.GetLitigantSubType(null,null,0);
            Session["LitigantSubType"] = litigantStatusLIST;

            lstLitigantSubType.DataSource = litigantStatusLIST;
            lstLitigantSubType.DataBind();
            lstLitigantSubType.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could Not Load Tameli Type </br>";
            this.programmaticModalPopup.Show();
        }


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txLitigantSubTypeName.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Litigant Sub Type छुट्यो </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            List<ATTLitigantSubType> litigantStatusLST = (List<ATTLitigantSubType>)Session["LitigantSubType"];

            ATTLitigantSubType litigantStatus = new ATTLitigantSubType();

            litigantStatus.LitigantSubTypeName = txLitigantSubTypeName.Text.Trim();
            litigantStatus.Active = (chkLitigantSubType.Checked) ? "Y" : "N";
            litigantStatus.EntryBy = entryBy;
            if (lstLitigantSubType.SelectedIndex >= 0)
            {
                litigantStatus.Action = "E";
                litigantStatus.LitigantSubTypeID = litigantStatusLST[lstLitigantSubType.SelectedIndex].LitigantSubTypeID;
            }
            else
            {
                litigantStatus.Action = "A";
            }
            if (BLLLitigantSubType.AddEditDeleteLitigantSubType(litigantStatus))
            {
                if (lstLitigantSubType.SelectedIndex >= 0)
                {
                    litigantStatusLST[lstLitigantSubType.SelectedIndex] = litigantStatus;
                }
                else
                {
                    litigantStatusLST.Add(litigantStatus);
                }

                lstLitigantSubType.DataSource = litigantStatusLST;
                lstLitigantSubType.DataBind();

                lblStatusMessage.Text = "Data Saved Successfully</br>";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
                this.programmaticModalPopup.Show();
            }
            txLitigantSubTypeName.Text = "";
            chkLitigantSubType.Checked = true;
            lstLitigantSubType.SelectedIndex = -1;

        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txLitigantSubTypeName.Text = "";
        chkLitigantSubType.Checked = true;
        lstLitigantSubType.SelectedIndex = -1;
        lblStatusMessage.Text = "Operation Cancelled </br>";
        this.programmaticModalPopup.Show();
    }
    protected void lstLitigantSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txLitigantSubTypeName.Text = lstLitigantSubType.SelectedItem.ToString();
        chkLitigantSubType.Checked = (((List<ATTLitigantSubType>)Session["LitigantSubType"])[lstLitigantSubType.SelectedIndex].Active == "Y") ? true : false;

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
