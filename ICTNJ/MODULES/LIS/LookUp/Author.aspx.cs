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

public partial class MODULES_LIS_LookUp_Author : System.Web.UI.Page
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

        //block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("4,4,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadAuthor();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    /// <summary>
    /// Load author list in dropdown control
    /// </summary>
    void LoadAuthor()
    {
        try
        {
            Session["Author_AuthorList"] = BLLAuthor.GetAuthorList(null);
            this.lstAuthor.DataSource = (List<ATTAuthor>)Session["Author_AuthorList"];
            this.lstAuthor.DataTextField = "AuthorName";
            this.lstAuthor.DataValueField = "AuthorID";

            this.lstAuthor.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void lstCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTAuthor> lst = (List<ATTAuthor>)Session["Author_AuthorList"];

        ATTAuthor author = lst.Find
                                    (
                                        delegate(ATTAuthor au)
                                        {
                                            return au.AuthorID== int.Parse(this.lstAuthor.SelectedValue);
                                        }
                                     );

        this.txtAuthorName_Rqd.Text = author.AuthorName;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTAuthor authorObj = new ATTAuthor
                                                (
                                                    0,
                                                    this.txtAuthorName_Rqd.Text,
                                                    ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                    DateTime.Now
                                                );

        ObjectValidation OV = BLLAuthor.Validate(authorObj);
        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTAuthor> lstAuth = (List<ATTAuthor>)Session["Author_AuthorList"];

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        
        try
        {
            if (this.lstAuthor.SelectedIndex < 0)
            {
                if (user.MenuList["4,4,1"] == null || user.MenuList["4,4,1"].PAdd == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Author.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,4,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

                BLLAuthor.AddAuthor(authorObj, pobj);
                lstAuth.Add(authorObj);
            }
            else
            {
                if (user.MenuList["4,4,1"] == null || user.MenuList["4,4,1"].PEdit == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " update Author.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,4,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);

                authorObj.AuthorID = int.Parse(this.lstAuthor.SelectedValue);

                BLLAuthor.EditAuthor(authorObj, pobj);
                lstAuth[this.lstAuthor.SelectedIndex] = authorObj;
            }


            this.lstAuthor.DataSource = lstAuth;
            this.lstAuthor.DataTextField = "AuthorName";
            this.lstAuthor.DataValueField = "AuthorID";

            this.lstAuthor.DataBind();

            this.ClearAuthorControl();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    /// <summary>
    /// Clear UI control of author
    /// </summary>
    void ClearAuthorControl()
    {
        this.txtAuthorName_Rqd.Text = "";
        this.lstAuthor.SelectedIndex = -1;
        this.lblStatus.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearAuthorControl();
    }
}
