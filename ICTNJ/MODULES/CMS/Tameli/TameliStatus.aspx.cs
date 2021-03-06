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

public partial class MODULES_CMS_Tameli_TameliStatus : System.Web.UI.Page
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
            LoadTameliStatus();
        }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);

    }

    private void LoadTameliStatus()
    {
        try
        {
            List<ATTTameliStatus> tameliStatusLIST = BLLTameliStatus.GetTameliStatus(null, null);
            Session["TameliStatus"] = tameliStatusLIST;

            lstTameliStatus.DataSource = tameliStatusLIST;
            lstTameliStatus.DataBind();
            lstTameliStatus.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could Not Load Tameli Status </br>";
            this.programmaticModalPopup.Show();
        }


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txTameliStatusName.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Tameli Status छुट्यो </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            List<ATTTameliStatus> tameliStatusLST = (List<ATTTameliStatus>)Session["TameliStatus"];

            ATTTameliStatus tameliStatus = new ATTTameliStatus();

            tameliStatus.TameliStatusName = txTameliStatusName.Text.Trim();
            tameliStatus.Active = (chkTameliStatus.Checked) ? "Y" : "N";
            tameliStatus.EntryBy = entryBy;
            if (lstTameliStatus.SelectedIndex >= 0)
            {
                tameliStatus.Action = "E";
                tameliStatus.TameliStatusID = tameliStatusLST[lstTameliStatus.SelectedIndex].TameliStatusID;
            }
            else
            {
                tameliStatus.Action = "A";
            }
            if (BLLTameliStatus.AddEditDeleteTameliStatus(tameliStatus))
            {
                if (lstTameliStatus.SelectedIndex >= 0)
                {
                    tameliStatusLST[lstTameliStatus.SelectedIndex] = tameliStatus;
                }
                else
                {
                    tameliStatusLST.Add(tameliStatus);
                }

                lstTameliStatus.DataSource = tameliStatusLST;
                lstTameliStatus.DataBind();

                lblStatusMessage.Text = "Data Saved Successfully</br>";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
                this.programmaticModalPopup.Show();
            }
            txTameliStatusName.Text = "";
            chkTameliStatus.Checked = true;
            lstTameliStatus.SelectedIndex = -1;

        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txTameliStatusName.Text = "";
        chkTameliStatus.Checked = true;
        lstTameliStatus.SelectedIndex = -1;
        lblStatusMessage.Text = "Operation Cancelled </br>";
        this.programmaticModalPopup.Show();
    }
    protected void lstTameliStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txTameliStatusName.Text = lstTameliStatus.SelectedItem.ToString();
        chkTameliStatus.Checked = (((List<ATTTameliStatus>)Session["TameliStatus"])[lstTameliStatus.SelectedIndex].Active == "Y") ? true : false;

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
