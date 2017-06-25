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
using PCS.LIS.ATT;
using PCS.LIS.BLL;



public partial class MODULES_LIS_LookUp_MaterialCategory : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("4,2,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadMaterialCategory();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {

        ATTMaterialCategory objMC;
        if (lstCategoryName.SelectedIndex == -1)
        {
            objMC = new ATTMaterialCategory(0, txtCategoryName_rqd.Text, ((ATTUserLogin)Session["Login_User_Detail"]).UserName, txtCategoryDescription.Text);

        }
        else
        {
            objMC = new ATTMaterialCategory(int.Parse(lstCategoryName.SelectedValue), txtCategoryName_rqd.Text, ((ATTUserLogin)Session["Login_User_Detail"]).UserName, txtCategoryDescription.Text);
        }


        ObjectValidation OV = BLLMaterialCategory.Validate(objMC);

        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTMaterialCategory> ltMaterialCategory = (List<ATTMaterialCategory>)Session["MaterialCategoryList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        try
        {


            if (lstCategoryName.SelectedIndex == -1)
            {
                if (user.MenuList["4,2,1"] == null || user.MenuList["4,2,1"].PAdd == "N")
                 {
                     this.lblStatus.Text = Utilities.PreviledgeMsg + " add Material Category.";
                     return;
                 }
                 Previlege pobj = new Previlege(user.UserName, "4,2,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);


                 if (BLLMaterialCategory.AddMaterialCategory(objMC, pobj))
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
                     ltMaterialCategory.Add(objMC);
                     lblStatus.Text = "New Record Added Successfully !!!";
                 }
            }
            else
            {
                List<ATTMaterialCategory> lst = (List<ATTMaterialCategory>)Session["MaterialCategoryList"];

                ATTMaterialCategory MaterialCategory = lst.Find(
                                                                    delegate(ATTMaterialCategory MC)
                                                                    {
                                                                        return MC.CategoryID == int.Parse(this.lstCategoryName.SelectedValue);
                                                                    }
                                                               );

                if ((txtCategoryName_rqd.Text == MaterialCategory.CategoryName) && (txtCategoryDescription.Text == MaterialCategory.CategoryDescription))
                {
                    lblStatus.Text = "Please Change Data to Update !!!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
                }
                else 
                {
                    if (user.MenuList["4,2,1"] == null || user.MenuList[Session["List_Menuname"].ToString()].PEdit == "N")
                    {
                        this.lblStatus.Text = Utilities.PreviledgeMsg + " update Material Category.";
                        return;
                    }
                    Previlege pobj = new Previlege(user.UserName, "4,2,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);


                    if (BLLMaterialCategory.UpdateMaterialCategory(objMC, pobj))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

                        ltMaterialCategory[this.lstCategoryName.SelectedIndex] = objMC;
                        lblStatus.Text = "Existing Record Updated Successfully !!!";
                    }
                }

            }

            this.lstCategoryName.DataSource = ltMaterialCategory;
            this.lstCategoryName.DataTextField = "CategoryName";
            this.lstCategoryName.DataValueField = "CategoryID";
            this.lstCategoryName.DataBind();
            //this.lstCategoryName.SelectedIndex = -1;

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
            this.lblStatus.Text = ex.Message;
        }
    }


    public void LoadMaterialCategory()
    {
        try
        {
            Session["MaterialCategoryList"] = BLLMaterialCategory.GetMaterialCategory();

            this.lstCategoryName.DataSource = (List<ATTMaterialCategory>)Session["MaterialCategoryList"];
            this.lstCategoryName.DataTextField = "CategoryName";
            this.lstCategoryName.DataValueField = "CategoryID";

            this.lstCategoryName.DataBind();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    protected void lstMaterialType_SelectedIndexChanged(object sender, EventArgs e)
    {

        List<ATTMaterialCategory> lst = (List<ATTMaterialCategory>)Session["MaterialCategoryList"];

        ATTMaterialCategory MaterialCategory = lst.Find(
                                                            delegate(ATTMaterialCategory MC)
                                                            {
                                                                return MC.CategoryID == int.Parse(this.lstCategoryName.SelectedValue);
                                                            }
                                                       );

        this.txtCategoryName_rqd.Text = MaterialCategory.CategoryName;
        this.txtCategoryDescription.Text = MaterialCategory.CategoryDescription;
        lblStatus.Text = "";

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lstCategoryName.SelectedIndex = -1;
        lblStatus.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
    }
}
