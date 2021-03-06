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
public partial class MODULES_CMS_Tameli_TameliType : System.Web.UI.Page
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
            LoadTameliType();
        }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);

    }

    private void LoadTameliType()
    {
        try
        {
            List<ATTTameliType> tameliTypeLIST = BLLTameliType.GetTameliType(null, null);
            Session["TameliType"] = tameliTypeLIST;

            lstTameliType.DataSource = tameliTypeLIST;
            lstTameliType.DataBind();
            lstTameliType.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could Not Load Tameli Type </br>";
            this.programmaticModalPopup.Show();
        }


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txTameliTypeName.Text.Trim() == "")
        {
            lblStatusMessage.Text = "तामेलीको प्रकार छुट्यो </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            List<ATTTameliType> tameliTypeLST = (List<ATTTameliType>)Session["TameliType"];

            ATTTameliType tameliType = new ATTTameliType();

            tameliType.TameliTypeName = txTameliTypeName.Text.Trim();
            tameliType.Active = (chkTameliType.Checked) ? "Y" : "N";
            tameliType.EntryBy = entryBy;
            if (lstTameliType.SelectedIndex >= 0)
            {
                tameliType.Action = "E";
                tameliType.TameliTypeID = tameliTypeLST[lstTameliType.SelectedIndex].TameliTypeID;
            }
            else
            {
                tameliType.Action = "A";
            }
            if (BLLTameliType.AddEditDeleteTameliType(tameliType))
            {
                if (lstTameliType.SelectedIndex >= 0)
                {
                    tameliTypeLST[lstTameliType.SelectedIndex] = tameliType;
                }
                else
                {
                    tameliTypeLST.Add(tameliType);
                }

                lstTameliType.DataSource = tameliTypeLST;
                lstTameliType.DataBind();

                lblStatusMessage.Text = "Data Saved Successfully</br>";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
                this.programmaticModalPopup.Show();
            }
            txTameliTypeName.Text = "";
            chkTameliType.Checked = true;
            lstTameliType.SelectedIndex = -1;

        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Problem Occurred while Saving Data </br>";
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txTameliTypeName.Text = "";
        chkTameliType.Checked = true;
        lstTameliType.SelectedIndex = -1;
        lblStatusMessage.Text = "Operation Cancelled </br>";
        this.programmaticModalPopup.Show();
    }
    protected void lstTameliType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txTameliTypeName.Text = lstTameliType.SelectedItem.ToString();
        chkTameliType.Checked = (((List<ATTTameliType>)Session["TameliType"])[lstTameliType.SelectedIndex].Active == "Y") ? true : false;

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
