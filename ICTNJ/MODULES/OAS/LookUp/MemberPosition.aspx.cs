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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_LookUp_MemberPosition : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("5,4,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadMemberPosition();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadMemberPosition()
    {
        try
        {
            Session["MemberPositionLst"] = BLLMemberPosition.GetMemberPositionList(null, false);
            this.lstMemberPosition.DataSource = Session["MemberPositionLst"];
            this.lstMemberPosition.DataTextField = "PositionName";
            this.lstMemberPosition.DataValueField = "PositionID";
            this.lstMemberPosition.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTMemberPosition MP = new ATTMemberPosition();
        MP.PositionName = this.txtPosition.Text;

        if (this.lstMemberPosition.SelectedIndex < 0)
        {
            MP.Action = "A";
            MP.PositionID = 0;
        }
        else
        {
            MP.Action = "E";
            MP.PositionID = ((List<ATTMemberPosition>)Session["MemberPositionLst"])[this.lstMemberPosition.SelectedIndex].PositionID;
        }

        ObjectValidation result = BLLMemberPosition.Validate(MP);
        if (result.IsValid==false)
        {
            this.lblStatusMessage.Text = result.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {
            BLLMemberPosition.AddMemberPosition(MP);
            List<ATTMemberPosition> lst = ((List<ATTMemberPosition>)Session["MemberPositionLst"]);
            
            if (MP.Action == "A")
                lst.Add(MP);
            else
                lst[this.lstMemberPosition.SelectedIndex] = MP;

            this.lstMemberPosition.DataSource = lst;
            this.lstMemberPosition.DataTextField = "PositionName";
            this.lstMemberPosition.DataValueField = "PositionID";
            this.lstMemberPosition.DataBind();

            this.ClearME();
            this.lstMemberPosition.SelectedIndex = -1;

            this.lblStatusMessage.Text = "Member position sucessfully saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        this.txtPosition.Text = "";
    }

    protected void lstMemberPosition_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtPosition.Text = ((List<ATTMemberPosition>)Session["MemberPositionLst"])[this.lstMemberPosition.SelectedIndex].PositionName;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtPosition.Text = "";

        lstMemberPosition.SelectedIndex = -1;
    }
}
