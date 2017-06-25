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
//Using section
using PCS.LIS.ATT; 
using PCS.LIS.BLL;
using System.Collections.Generic;
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;



public partial class MODULES_LIS_LookUp_LkLanguage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("4,7,1")== true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadLanguageType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ATTLookupLanguage ObjLT;
        if (LBLanguage.SelectedIndex == -1)
        {
            ObjLT = new ATTLookupLanguage(0, txtLookupName_Rqd.Text, "User_Ashok", DateTime.Now.ToString());
        }
        else
        {
            ObjLT = new ATTLookupLanguage(int.Parse(this.LBLanguage.SelectedValue), txtLookupName_Rqd.Text, "User_Ashok", DateTime.Now.ToString());
        }
        List<ATTLookupLanguage> ltLanguage = (List<ATTLookupLanguage>)Session["LanguageTypeList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (LBLanguage.SelectedIndex == -1)
            {
                if (user.MenuList["4,7,1"] == null || user.MenuList["4,7,1"].PAdd == "N")
                {
                    this.LblStatus.Text = Utilities.PreviledgeMsg + " add Language.";
                    return;
                }

                Previlege pobj = new Previlege(user.UserName, "4,7,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

                if (BLLLanguage.SaveLanguage(ObjLT,pobj))
                {
                    ltLanguage.Add(ObjLT);
                    LblStatus.Text = "Language Inserted as: " + txtLookupName_Rqd.Text + ".";
                    txtLookupName_Rqd.Text = "";
                    txtLookupName_Rqd.Focus();
                }
            }
            else
            {
                if (user.MenuList["4,7,1"] == null || user.MenuList["4,7,1"].PEdit == "N")
                {
                    this.LblStatus.Text = Utilities.PreviledgeMsg + " update Language.";
                    return;
                }

                Previlege pobj = new Previlege(user.UserName, "4,7,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);

                if (BLLLanguage.UpdateLanguageType(ObjLT,pobj))
                {
                    ltLanguage[this.LBLanguage.SelectedIndex] = ObjLT;
                    LblStatus.Text = "Record updated...";
                }
            }
            LBLanguage.DataSource = ltLanguage;
            LBLanguage.DataTextField = "LookupLanguageName";
            LBLanguage.DataValueField = "LookupLanguageID";
            LBLanguage.DataBind();
        }
        catch (Exception ex)
        {
            this.LblStatus.Text = ex.Message;
        }
    }
    public void LoadLanguageType()
    {
        try
        {
            Session["LanguageTypeList"] = BLLLanguage.GetLanguageList();
            this.LBLanguage.DataSource = (List<ATTLookupLanguage>)Session["LanguageTypeList"];
            this.LBLanguage.DataTextField = "LookupLanguageName";
            this.LBLanguage.DataValueField = "LookupLanguageID";
            this.LBLanguage.DataBind();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }



    protected void LBLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTLookupLanguage> lst = (List<ATTLookupLanguage>)Session["LanguageTypeList"];
        ATTLookupLanguage LanguageType = lst.Find(delegate(ATTLookupLanguage LT)
                                                    {
                                                        return LT.LookupLanguageID == int.Parse(this.LBLanguage.SelectedValue);
                                                    }
                                                  );
        this.txtLookupName_Rqd.Text = LanguageType.LookupLanguageName;
        this.LblStatus.Text = "";
 
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        LBLanguage.SelectedIndex = -1;
        txtLookupName_Rqd.Text = "";
        LblStatus.Text = "";
        txtLookupName_Rqd.Focus();
    }

    //Delete
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        ATTLookupLanguage ObjLT;
        if (LBLanguage.SelectedIndex > -1)
        {
            ObjLT = new ATTLookupLanguage(int.Parse(LBLanguage.SelectedValue));
            BLLLanguage.DeleteLanguage(ObjLT);
            LBLanguage.Items.Remove(LBLanguage.SelectedItem);
            txtLookupName_Rqd.Text = "";
            LblStatus.Text = "Deleted..";
        }
    }
}
