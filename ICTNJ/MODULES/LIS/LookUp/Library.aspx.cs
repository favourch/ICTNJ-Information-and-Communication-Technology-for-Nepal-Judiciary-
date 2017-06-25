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

public partial class MODULES_LIS_LookUp_Library : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("4,1,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadOrganization();
                this.LoadLibrary();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadOrganization()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            this.ddlOrg_Rqd.DataSource = BLLOrganization.GetOrganizationByID(user.OrgID);
            this.ddlOrg_Rqd.DataTextField = "OrgName";
            this.ddlOrg_Rqd.DataValueField = "OrgID";
            this.ddlOrg_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadLibrary()
    {
        try
        {
            Session["Library_LibraryList"] = BLLLibrary.GetLibraryList(int.Parse(this.ddlOrg_Rqd.SelectedValue), null, 'N');

            this.lslLibrary.DataSource = (List<ATTLibrary>)Session["Library_LibraryList"];
            this.lslLibrary.DataTextField = "LibraryName";
            this.lslLibrary.DataValueField = "LibraryID";
            
            this.lslLibrary.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnAddLibrary_Click(object sender, EventArgs e)
    {
        ATTLibrary objLib = new ATTLibrary
                                        (
                                            0,
                                            int.Parse(this.ddlOrg_Rqd.SelectedValue),
                                            this.txtLibraryName.Text,
                                            this.txtLibraryLocation.Text,
                                            ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                                            DateTime.Now
                                        );
        
        ObjectValidation OV = BLLLibrary.Validate(objLib);
        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTLibrary> ltLibrary = (List<ATTLibrary>)Session["Library_LibraryList"];
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (this.lslLibrary.SelectedIndex < 0)
            {
                if (this.lslLibrary.Items.Count > 1)
                {
                    this.lblStatus.Text = "More then one library cannot be create.";
                    return;
                }

                if (user.MenuList["4,1,1"] == null || user.MenuList["4,1,1"].PAdd == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Library.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,1,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_ADD);


                BLLLibrary.AddLibrary(objLib, pobj);
                ltLibrary.Add(objLib);

            }
            else
            {
                objLib.LibraryID = int.Parse(this.lslLibrary.SelectedValue);

                if (user.MenuList["4,1,1"] == null || user.MenuList["4,1,1"].PEdit == "N")
                {
                    this.lblStatus.Text = Utilities.PreviledgeMsg + " add Currency.";
                    return;
                }
                Previlege pobj = new Previlege(user.UserName, "4,1,1", int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value), Previlege.PrevilegeType.P_EDIT);
                BLLLibrary.EditLibrary(objLib,pobj);

                ltLibrary[this.lslLibrary.SelectedIndex] = objLib;

            }


            this.lslLibrary.DataSource = ltLibrary;
            this.lslLibrary.DataTextField = "LibraryName";
            this.lslLibrary.DataValueField = "LibraryID";

            this.lslLibrary.DataBind();

            this.ClearLibraryControl();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void ClearLibraryControl()
    {
        this.txtLibraryName.Text = "";
        this.txtLibraryLocation.Text = "";
        this.lblStatus.Text = "";
        this.lslLibrary.SelectedIndex = -1;
    }

    protected void lslLibrary_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTLibrary> lst = (List<ATTLibrary>)Session["Library_LibraryList"];

        ATTLibrary library = lst.Find
                                    (
                                        delegate(ATTLibrary li)
                                        {
                                            return li.LibraryID == int.Parse(this.lslLibrary.SelectedValue)
                                            &&
                                            li.OrgID == int.Parse(this.ddlOrg_Rqd.SelectedValue);
                                        }
                                     );

        this.txtLibraryName.Text = library.LibraryName;
        this.txtLibraryLocation.Text = library.Location;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearLibraryControl();
    }
}
