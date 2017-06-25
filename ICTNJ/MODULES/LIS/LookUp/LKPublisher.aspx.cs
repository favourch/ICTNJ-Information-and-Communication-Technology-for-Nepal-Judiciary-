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
//Using parts
//Using section
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using System.Collections.Generic;
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;

public partial class MODULES_LIS_LookUp_LKPublisher : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("4,8,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadPublisherType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ATTPublisher ObjPT;
        if (LBPublisher.SelectedIndex == -1)
        {
            ObjPT = new   ATTPublisher(0, txtPublisherName_Rqd.Text, txtLookupAddress_Rqd.Text, "User_Ashok", DateTime.Now.ToString());
        }
        else
        {
            ObjPT = new ATTPublisher(int.Parse(this.LBPublisher.SelectedValue), txtPublisherName_Rqd.Text, txtLookupAddress_Rqd.Text, "User_Ashok", DateTime.Now.ToString());
        }
        List<ATTPublisher> ltPublisher = (List<ATTPublisher>)Session["PublisherTypeList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (LBPublisher.SelectedIndex == -1)
            {

                if (user.MenuList["4,8,1"] == null || user.MenuList["4,8,1"].PAdd == "N")
                {
                    this.LblStatus.Text = Utilities.PreviledgeMsg + " add Publisher.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,8,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

                if (BLLPublisher.SavePublisher(ObjPT,pobj))
                {
                    ltPublisher.Add(ObjPT);
                    LblStatus.Text = "Publisher Inserted as: " + txtPublisherName_Rqd.Text + ".";
                    txtPublisherName_Rqd.Text = "";
                    txtLookupAddress_Rqd.Text = "";
                    btnSave.Text = "Save";
                    txtPublisherName_Rqd.Focus();
                }
            }
            else
            {
                if (user.MenuList["4,8,1"] == null || user.MenuList["4,8,1"].PEdit == "N")
                {
                    this.LblStatus.Text = Utilities.PreviledgeMsg + " add Publisher.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,8,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);

                if (BLLPublisher.UpdatePublisherType(ObjPT, pobj))
                {
                    ltPublisher[this.LBPublisher.SelectedIndex] = ObjPT;
                    LblStatus.Text = "Publisher Record Updated...";
                    btnSave.Text = "Save";
                    txtPublisherName_Rqd.Text = "";
                    txtLookupAddress_Rqd.Text = "";
                    txtPublisherName_Rqd.Focus();

                }
            }
            LBPublisher.DataSource = ltPublisher;
            LBPublisher.DataTextField = "PublisherName";
            LBPublisher.DataValueField = "PublisherID";
            LBPublisher.DataBind();

        }
        catch (Exception ex)
        {
            this.LblStatus.Text = ex.Message;
        }
    }
    public void LoadPublisherType()
    {
        try
        {
            Session["PublisherTypeList"] =  BLLPublisher.GetPublisherList();
            this.LBPublisher.DataSource = (List<ATTPublisher>)Session["PublisherTypeList"];
            this.LBPublisher.DataTextField = "PublisherName";
            this.LBPublisher.DataValueField = "PublisherID";
            this.LBPublisher.DataBind();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void LBPublisher_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnDelete.Enabled = true;
        this.btnSave.Text = "Update";
        List<ATTPublisher> lst = (List<ATTPublisher>)Session["PublisherTypeList"];
        ATTPublisher PublisherType = lst.Find(delegate(ATTPublisher PT)
                                                    {
                                                        return PT.PublisherID == int.Parse(this.LBPublisher.SelectedValue);
                                                    }
                                                  );
        this.txtPublisherName_Rqd.Text = PublisherType.PublisherName;
        this.txtLookupAddress_Rqd.Text = PublisherType.PublisherAddress;
        this.LblStatus.Text = "";
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        LBPublisher.SelectedIndex = -1;
        btnSave.Text = "Save";
        BtnDelete.Enabled = false;
        txtPublisherName_Rqd.Text = "";
        txtLookupAddress_Rqd.Text = "";
        LblStatus.Text = "";
        txtPublisherName_Rqd.Focus();
    }


    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        ATTPublisher ObjPT;
        if (LBPublisher.SelectedIndex > -1)
        {
            ObjPT = new ATTPublisher(int.Parse(LBPublisher.SelectedValue));
            BLLPublisher.DeletePublisher(ObjPT);
            LBPublisher.Items.Remove(LBPublisher.SelectedItem);
            btnSave.Text = "Save";
            this.txtPublisherName_Rqd.Text = "";
            this.txtLookupAddress_Rqd.Text = "";
            this.txtPublisherName_Rqd.Focus();
            LblStatus.Text = "Deleted..";
        }
    }
}
