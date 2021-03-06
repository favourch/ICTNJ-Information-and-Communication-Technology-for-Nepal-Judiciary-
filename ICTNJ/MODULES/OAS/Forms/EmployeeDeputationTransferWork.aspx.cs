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
using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using System.Reflection;

using System.Drawing;

/*
 Author: Shanjeev Sah
 Created Date 9 Nov 2010
 */

public partial class MODULES_PMS_Forms_EmployeeDeputationTransferWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.SrchGrid.Height = Unit.Pixel(0);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //if (user.MenuList.ContainsKey("3,59,1") == true)
        //{

            if (!IsPostBack)
            {
                LoadAllOrganizationNameList();
                Session["EmployeeDuptation"] = new ATTEmployeeDeputaion();
                LoadEmpCurentPostingInfo(user.PID);
                LoadEmpDeputationInfo();

            }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {

    }
 void LoadAllOrganizationNameList()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        
        List<ATTOrganization> AllOrganizationList = BLLOrganization.GetAllOrganization(null,null,null);

        int i;
        i = AllOrganizationList.FindIndex(delegate(ATTOrganization att)
        {
            return att.OrgID == user.OrgID;
        });
        AllOrganizationList.RemoveAt(i);
        AllOrganizationList.Insert(0, new ATTOrganization("",0,0,"", "छान्नुहोस", "", "", 0,"",0,0,""));
        this.ddlOrganization.DataSource = AllOrganizationList;
        this.ddlOrganization.DataTextField = "ORGNAME";
        this.ddlOrganization.DataValueField = "ORGID";
        this.ddlOrganization.DataBind();
     
    }



    void LoadEmpCurentPostingInfo( double empid)
    {

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        ATTEmployeePosting obj = BLLEmployeePosting.GetEmployeeCurrentPostingAllInfo(empid);
        Session["EmployeeCurentPosting"] = obj;
        txtName.Text = user.UserName;
        txtCurrentOrg.Text = obj.OrgName;
        txtCurrentPost.Text = obj.PostName;

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        ATTEmployeeDeputaion obj = (ATTEmployeeDeputaion)Session["EmployeeDuptation"];
        ATTEmployeePosting objEcp = (ATTEmployeePosting)Session["EmployeeCurentPosting"];
        obj.EmpID = user.PID;
        obj.OrgID = user.OrgID;
        obj.DesID = objEcp.DesID;
        obj.CreatedDate = objEcp.CreatedDate;
        obj.PostID = objEcp.PostID;
        obj.FromDate = objEcp.FromDate;
        obj.ApplicationDate = txtAppdate_DT.Text;
        obj.DepOrgID = int.Parse(ddlOrganization.SelectedValue);
        //obj.DecisionVerifiedBy = "";
        //obj.LeaveDate = "";
        //obj.LeaveVerifiedBy = "";
        //obj.ReturnDate = "";
        //obj.ReturnVerifiedBy = "";
        obj.Responsibilities = txtdescription.Text;
        obj.Active = "Y";
        obj.EntryBy = user.UserName;
        //obj.TipOrgID = "";
       // obj.TippaniID = "";
        //obj.DecisionDate = "";
        obj.Action = "A";
        if (this.ddlOrganization.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select organization Name.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        if (this.txtAppdate_DT.Text == "")
        {
            this.lblStatusMessage.Text = "Please Enter Application Date.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }
        if (this.txtdescription.Text == "")
        {
            this.lblStatusMessage.Text = "Please Enter Responsibilities.";
            this.programmaticModalPopup.Show();
            this.lblStatus.Focus();
            return;
        }

        if (BLLEmployeeDeputation.AddEmpForDeputationDetail(obj))
        {
            this.lblStatusMessage.Text = "Information Saved";
            this.programmaticModalPopup.Show();
        }
        else
        {
            this.lblStatusMessage.Text = "Information could not be Saved";
            this.programmaticModalPopup.Show();
        }
        ClearControl();
    
    }

 private void LoadEmpDeputationInfo()
    {
     ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
     List<ATTEmployeeDeputaion> LSTEmpDeputation = BLLEmployeeDeputation.GetEmpForDeputationInfo(user.OrgID,"Y",user.PID);
     // Session["EmpDeputionInfo"] = LSTEmpDeputation;
     this.grdDeputation.DataSource = LSTEmpDeputation;
     this.grdDeputation.DataBind();
    }



    protected void ClearControl()
    {
        txtAppdate_DT.Text = "";
        txtdescription.Text = "";
        ddlOrganization.SelectedIndex = -1;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControl();

    }
    
}
