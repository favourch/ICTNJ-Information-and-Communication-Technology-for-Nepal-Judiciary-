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


public partial class MODULES_LIS_LookUp_MaterialType : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("4,3,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadMaterialType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ATTMaterialType ObjMT;
        if (lstMaterialType.SelectedIndex == -1)
        {
            ObjMT = new ATTMaterialType(0, txtMaterialTypeName_rqd.Text, ((ATTUserLogin)Session["Login_User_Detail"]).UserName, txtMaterialTypeDescription.Text);

        }
        else
        {
            ObjMT = new ATTMaterialType(int.Parse(lstMaterialType.SelectedValue), txtMaterialTypeName_rqd.Text, ((ATTUserLogin)Session["Login_User_Detail"]).UserName, txtMaterialTypeDescription.Text);
        }

        ObjectValidation OV = BLLMaterialType.Validate(ObjMT);

        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTMaterialType> ltMaterialType = (List<ATTMaterialType>)Session["MaterialTypeList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (lstMaterialType.SelectedIndex == -1)
            {
                if (user.MenuList["4,3,1"] == null || user.MenuList["4,3,1"].PAdd == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Material Type.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,3,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

                if (BLLMaterialType.AddMaterialType(ObjMT, pobj))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

                    ltMaterialType.Add(ObjMT);
                    lblStatus.Text = "New Record Added Successfully !!!";
                }

            }
            else
            {
                List<ATTMaterialType> lst = (List<ATTMaterialType>)Session["MaterialTypeList"];

                ATTMaterialType MaterialType = lst.Find(
                                                            delegate(ATTMaterialType MT)
                                                            {
                                                                return MT.MaterialID == int.Parse(this.lstMaterialType.SelectedValue);
                                                            }
                                                        );

                if ((txtMaterialTypeName_rqd.Text == MaterialType.MaterialTypeName) && (txtMaterialTypeDescription.Text == MaterialType.MaterialDescription))
                {
                    lblStatus.Text = "Please Change Data to Update !!!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
                }
                else
                {
                    if (user.MenuList["4,3,1"] == null || user.MenuList[Session["List_Menuname"].ToString()].PEdit == "N")
                    {
                        this.lblStatus.Text = Utilities.PreviledgeMsg + " update Material Type.";
                        return;
                    }
                    Previlege pobj = new Previlege(user.UserName, "4,3,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);

                    if (BLLMaterialType.UpdateMaterialType(ObjMT, pobj))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

                        ltMaterialType[this.lstMaterialType.SelectedIndex] = ObjMT;
                        lblStatus.Text = "Existing Record Updated Successfully !!!";
                    }

                }
            }

            this.lstMaterialType.DataSource = ltMaterialType;
            this.lstMaterialType.DataTextField = "MaterialTypeName";
            this.lstMaterialType.DataValueField = "MaterialID";
            this.lstMaterialType.DataBind();

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ProgressBar", "javascript:callProgressbar();", true);
            this.lblStatus.Text = ex.Message;
        }
    }
       
    public void LoadMaterialType()
    {
        try
        {
            Session["MaterialTypeList"] = BLLMaterialType.GetMaterialType();

            this.lstMaterialType.DataSource = (List<ATTMaterialType>)Session["MaterialTypeList"];
            this.lstMaterialType.DataTextField = "MaterialTypeName";
            this.lstMaterialType.DataValueField = "MaterialID";

            this.lstMaterialType.DataBind();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    protected void lstMaterialType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTMaterialType> lst = (List<ATTMaterialType>)Session["MaterialTypeList"];

        ATTMaterialType MaterialType = lst.Find(
                                                    delegate(ATTMaterialType MT)
                                                    {
                                                        return MT.MaterialID == int.Parse(this.lstMaterialType.SelectedValue);
                                                    }
                                                );

        this.txtMaterialTypeName_rqd.Text = MaterialType.MaterialTypeName;
        this.txtMaterialTypeDescription.Text = MaterialType.MaterialDescription;
        this.lblStatus.Text = "";

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lstMaterialType.SelectedIndex = -1;
        lblStatus.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true); 
    }
}
