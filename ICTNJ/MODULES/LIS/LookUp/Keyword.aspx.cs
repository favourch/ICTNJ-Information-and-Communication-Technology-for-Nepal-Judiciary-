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

using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_LIS_LookUp_Keyword : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        string master = Request.Params["master"];
        if (master == "0")
        {
            this.Page.MasterPageFile = "~/modules/lis/Default.master";
        }
    }

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
        if (user.MenuList.ContainsKey("4,5,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadKeyword();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadKeyword()
    {
        try
        {
            Session["Keyword_KeywordList"] = BLLKeyword.GetKeywordList(null);
            this.lstKeyword.DataSource = (List<ATTKeyword>)Session["Keyword_KeywordList"];
            this.lstKeyword.DataTextField = "KeywordName";
            this.lstKeyword.DataValueField = "KeywordID";

            this.lstKeyword.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTKeyword keywordObj = new ATTKeyword
                                                (
                                                    0,
                                                    this.txtKeywordName_Rqd.Text,
                                                    ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                    DateTime.Now
                                                );

        ObjectValidation OV = BLLKeyword.Validate(keywordObj);
        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTKeyword> lstKey = (List<ATTKeyword>)Session["Keyword_KeywordList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (this.lstKeyword.SelectedIndex < 0)
            {

                if (user.MenuList["4,5,1"] == null || user.MenuList["4,5,1"].PAdd == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Keyword.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,5,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

               BLLKeyword.AddKeyword(keywordObj, pobj);
                lstKey.Add(keywordObj);


            }
            else
            {
                if (user.MenuList["4,5,1"] == null || user.MenuList[Session["List_Menuname"].ToString()].PEdit == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " update Keyword.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,5,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);

                BLLKeyword.EditKeyword(keywordObj,pobj);
                lstKey[this.lstKeyword.SelectedIndex] = keywordObj;
            }


            this.lstKeyword.DataSource = lstKey;
            this.lstKeyword.DataTextField = "KeywordName";
            this.lstKeyword.DataValueField = "KeywordID";

            this.lstKeyword.DataBind();

            this.ClearKeywordControl();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void ClearKeywordControl()
    {
        this.lstKeyword.SelectedIndex = -1;
        this.txtKeywordName_Rqd.Text = "";
        this.lblStatus.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearKeywordControl();
    }

    protected void lstKeyword_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTKeyword> lst = (List<ATTKeyword>)Session["Keyword_KeywordList"];

        ATTKeyword keyword = lst.Find
                                    (
                                        delegate(ATTKeyword key)
                                        {
                                            return key.KeywordID == int.Parse(this.lstKeyword.SelectedValue);
                                        }
                                     );

        this.txtKeywordName_Rqd.Text = keyword.KeywordName;
    }
}
