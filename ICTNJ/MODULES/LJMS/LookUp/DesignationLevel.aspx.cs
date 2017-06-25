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

using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_LJMS_LookUp_DesignationLevel : System.Web.UI.Page
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
        Session["UserName"] = user.UserName;
        if (user.MenuList.ContainsKey("2,33,1") == true)
        {
            if (IsPostBack == false)
            {
                GetDesignationLevel();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void GetDesignationLevel()
    {
        try
        {
            List<ATTDesignationLevel> lst_desl = BLLDesignationLevel.GetDesignationLevelList();
            lstDesignationLevel.DataSource = lst_desl;
            lstDesignationLevel.DataTextField = "LevelName";
            lstDesignationLevel.DataValueField = "LevelID";
            lstDesignationLevel.DataBind();

            Session["DesignationLevel"] = lst_desl;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControl()
    {
        this.txtLevel.Text="";
        this.lstDesignationLevel.SelectedIndex = -1;
    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strUser = Session["UserName"].ToString();
        int intDesID=0;
        List<ATTDesignationLevel> desLevel = (List<ATTDesignationLevel>)Session["DesignationLevel"];
        
        if (this.lstDesignationLevel.SelectedIndex > -1)
            intDesID = desLevel[this.lstDesignationLevel.SelectedIndex].LevelID;

        ATTDesignationLevel att_des_level = new ATTDesignationLevel(
                                                                    intDesID,
                                                                    this.txtLevel.Text,
                                                                    strUser);
        ObjectValidation OV = BLLDesignationLevel.Validate(att_des_level);

        if(OV.IsValid==false)
        {
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show(); 
            return;
        }


        try
        {
            BLLDesignationLevel.SaveDesignationLevel(att_des_level);
            if (this.lstDesignationLevel.SelectedIndex > -1)
            {
                desLevel[this.lstDesignationLevel.SelectedIndex].LevelID = att_des_level.LevelID;
                desLevel[this.lstDesignationLevel.SelectedIndex].LevelName = att_des_level.LevelName;
            }
            else
                desLevel.Add(att_des_level);

            this.lstDesignationLevel.DataSource = desLevel;
            this.lstDesignationLevel.DataBind();
            this.ClearControl();
            this.lblStatusMessage.Text = "Designation Level Successfully Saved.";
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
        ClearControl();
    }

    protected void lstDesignationLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTDesignationLevel obj = ((List<ATTDesignationLevel>)Session["DesignationLevel"])[this.lstDesignationLevel.SelectedIndex];

        this.txtLevel.Text = obj.LevelName;
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
