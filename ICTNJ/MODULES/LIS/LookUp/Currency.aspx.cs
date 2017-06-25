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

public partial class MODULES_LIS_LookUp_Currency : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("4,6,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadCurrency();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadCurrency()
    {
        try
        {
            Session["Currency_CurrencyList"] = BLLCurrency.GetCurrencyList(null);
            this.lstCurrency.DataSource = (List<ATTCurrency>)Session["Currency_CurrencyList"];
            this.lstCurrency.DataTextField = "CurrencyName";
            this.lstCurrency.DataValueField = "CurrencyID";

            this.lstCurrency.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTCurrency currencyObj = new ATTCurrency
                                                (
                                                    0,
                                                    this.txtCurrencyName_Rqd.Text,
                                                    ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                                    DateTime.Now
                                                );

        ObjectValidation OV = BLLCurrency.Validate(currencyObj);
        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTCurrency> lstCurr = (List<ATTCurrency>)Session["Currency_CurrencyList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (this.lstCurrency.SelectedIndex < 0)
            {
                if (user.MenuList["4,6,1"] == null || user.MenuList["4,6,1"].PAdd == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Currency.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,6,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);
                BLLCurrency.AddCurrency(currencyObj, pobj);
                lstCurr.Add(currencyObj);
                
            }
            else
            {
                if (user.MenuList["4,6,1"] == null || user.MenuList["4,6,1"].PEdit == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " update Currency.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,6,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);

                currencyObj.CurrencyID = int.Parse(this.lstCurrency.SelectedValue);
                BLLCurrency.EditCurrency(currencyObj, pobj);
                lstCurr[this.lstCurrency.SelectedIndex] = currencyObj;
            }


            this.lstCurrency.DataSource = lstCurr;
            this.lstCurrency.DataTextField = "CurrencyName";
            this.lstCurrency.DataValueField = "CurrencyID";

            this.lstCurrency.DataBind();

            this.ClearCurrencyControl();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void ClearCurrencyControl()
    {
        this.txtCurrencyName_Rqd.Text = "";
        this.lstCurrency.SelectedIndex = -1;
        this.lblStatus.Text = "";
    }

    protected void lstCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTCurrency> lst = (List<ATTCurrency>)Session["Currency_CurrencyList"];

        ATTCurrency currency = lst.Find
                                    (
                                        delegate(ATTCurrency cu)
                                        {
                                            return cu.CurrencyID == int.Parse(this.lstCurrency.SelectedValue);
                                        }
                                     );

        this.txtCurrencyName_Rqd.Text = currency.CurrencyName;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearCurrencyControl();
    }
}
