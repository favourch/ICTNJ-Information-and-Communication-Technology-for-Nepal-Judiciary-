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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_CMS_LookUp_PesiType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("1,15,1") == true)
        {
            if (this.Page.IsPostBack == false)
            {
                this.chkPesiTypeActive.Checked = true;
                LoadPesiType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadPesiType()
    {
        Session["PesiType"] = BLLPesiType.GetPesiType(null, null, 0);
        lstPesiType.DataSource = (List<ATTPesiType>)Session["PesiType"];
        lstPesiType.DataValueField = "PesiTypeID";
        lstPesiType.DataTextField = "PesiTypeName";
        lstPesiType.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtPesiType.Text == "")
        {
            this.lblStatusMessage.Text = "Pesi Type Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);


        List<ATTPesiType> PesiTypeLST = (List<ATTPesiType>)Session["PesiType"];
        int i = -1;

        if (this.lstPesiType.SelectedIndex > -1)
        {
            i = PesiTypeLST.FindIndex(delegate(ATTPesiType obj)
                                                                    {
                                                                        return this.txtPesiType.Text == obj.PesiTypeName && this.lstPesiType.SelectedItem.Text != this.txtPesiType.Text;
                                                                    });
        }
        else
        {
            i = PesiTypeLST.FindIndex(delegate(ATTPesiType obj)
                                                                               {
                                                                                   return this.txtPesiType.Text == obj.PesiTypeName;
                                                                               });
        }
        if (i > -1)
        {
            this.lblStatusMessage.Text = "Pesi Type Name Already Exists";
            this.programmaticModalPopup.Show();
            return;
        }


        ATTPesiType objPesiType = new ATTPesiType();
        objPesiType.PesiTypeID= (this.lstPesiType.SelectedIndex == -1) ? 0 : int.Parse(this.lstPesiType.SelectedValue);
        objPesiType.PesiTypeName = this.txtPesiType.Text;
        objPesiType.Active = (chkPesiTypeActive.Checked == true) ? "Y" : "N";
        objPesiType.EntryBy = user.UserName;
        objPesiType.Action = (this.lstPesiType.SelectedIndex == -1) ? "A" : "E";

        try
        {

            if (BLLPesiType.SavePesiType(objPesiType) == true)
            {
                if (this.lstPesiType.SelectedIndex == -1)
                {
                    PesiTypeLST.Add(objPesiType);
                }
                else
                {
                    PesiTypeLST.RemoveAt(this.lstPesiType.SelectedIndex);
                    PesiTypeLST.Add(objPesiType);
                }

                lstPesiType.DataSource = PesiTypeLST;
                lstPesiType.DataValueField = "PesiTypeID";
                lstPesiType.DataTextField = "PesiTypeName";
                lstPesiType.DataBind();

                clearAll();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Pesi Type Couldn't Be Saved<BR>" + ex.Message;
            this.programmaticModalPopup.Show();
        }


    }
    protected void lstPesiType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTPesiType> PesiTypeLST = (List<ATTPesiType>)Session["PesiType"];
        this.txtPesiType.Text = PesiTypeLST[this.lstPesiType.SelectedIndex].PesiTypeName;
        this.chkPesiTypeActive.Checked = (PesiTypeLST[this.lstPesiType.SelectedIndex].Active == "Y") ? true : false;

    }

    void clearAll()
    {
        this.txtPesiType.Text = "";
        this.chkPesiTypeActive.Checked = true;
        this.lstPesiType.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll();
    }
   

}
