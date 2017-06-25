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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;


public partial class MODULES_SECURITY_Forms_OrganizationApplication : System.Web.UI.Page
{
     protected void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
        //this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       //block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("Add Org Application") == true || user.MenuList.ContainsKey("Update Org Application") == true)
        {
            if (this.IsPostBack == false)
            {
                LoadOrganization();
                LoadApplications();
            }
        }
        else
            Response.Redirect("~/MODULES/LIS/Login.aspx", true);
    }

    private void LoadOrganization()
    {
        Session["Organization"] = BLLOrganization.getOrganizationApplication(0);
        ddlOrganization.DataSource =(List<ATTOrganization>) Session["Organization"]; 
        ddlOrganization.DataValueField = "OrgId";
        ddlOrganization.DataTextField = "OrgName";
        ddlOrganization.DataBind();
    }

    private void LoadApplications()
    {
        chklstApplications.DataSource = BLLApplication.GetApplicationList(1);
        chklstApplications.DataValueField = "ApplicationId";
        chklstApplications.DataTextField = "ApplicationFullName";
        chklstApplications.DataBind();
    }
    protected void btnRight_Click(object sender, EventArgs e)
    {
        //AddApplications();
    }
    protected void btnLeft_Click(object sender, EventArgs e)
    {
        //RemoveApplications();
    }
    protected void chklstApplications_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrganization.SelectedIndex == 0)
        {
            ClearAll();
            this.lblStatusMessage.Text = "Please Select Organization..";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTOrganizationApplications> lstOrgAppl = (List<ATTOrganizationApplications>)Session["OrgAppl"];
        foreach (ListItem lst in chklstApplications.Items)
        {
            int lstIndex = lstOrgAppl.FindIndex
                                (
                                    delegate(ATTOrganizationApplications orgAppl)
                                    {
                                        return orgAppl.ApplID==int.Parse( lst.Value);
                                    }
                                );
            if (lstIndex<0 && lst.Selected == true)
            {
                lstOrgAppl.Add(new ATTOrganizationApplications
                                                                (
                                                                   int.Parse( this.ddlOrganization.SelectedValue),
                                                                    int.Parse( lst.Value),
                                                                    (string)Session["Nepdate"],
                                                                    "",
                                                                    "A"
                                                                 ));
            }
            else if (lstIndex>-1 && lst.Selected == false)
            {
                lstOrgAppl[lstIndex].Action = "R";
                lstOrgAppl[lstIndex].ToDate =(string) Session["NepDate"];
            }
            else if (lstIndex > -1 && lst.Selected == false && lstOrgAppl[lstIndex].Action == "A")
            {
                lstOrgAppl.RemoveAt(lstIndex);
            }
            Session["OrgAppl"]=lstOrgAppl;
        }
                
        
            
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem lst in chklstApplications.Items)
        {
            lst.Selected = false;
        }

        
 
        List<ATTOrganization> lstOrg = (List<ATTOrganization>)Session["Organization"];
        foreach (ATTOrganization objOrg in lstOrg)
        {
            
            objOrg.LSTOrgApplications.RemoveAll(
                                              delegate(ATTOrganizationApplications orgAppl)
                                              {
                                                  return orgAppl.Action == "A";
                                              }
                                           );
            
        }
        List<ATTOrganizationApplications> lstOrgAppl= lstOrg[ddlOrganization.SelectedIndex].LSTOrgApplications;
        Session["OrgAppl"] = lstOrgAppl;
        foreach (ATTOrganizationApplications AttObj in lstOrgAppl)
        {
            foreach (ListItem lst in chklstApplications.Items)
            {
                if (lst.Value == AttObj.ApplID.ToString())
                {
                    lst.Selected = true;
                }
            }
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (BLLOrganizationApplications.AddOrganizationApplications((List<ATTOrganizationApplications>)Session["OrgAppl"]))
            {
                List<ATTOrganizationApplications> lstOrgAppl = (List<ATTOrganizationApplications>)Session["OrgAppl"];

                lstOrgAppl.RemoveAll(
                                       delegate(ATTOrganizationApplications orgAppl)
                                       {
                                           return orgAppl.Action == "R";
                                       }
                                    );
                foreach (ATTOrganizationApplications objOrgAppl in lstOrgAppl)
                {

                    objOrgAppl.Action = "E";
                }

                ClearAll();
            }
            
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error In Saving Organization Applications<BR><BR>"+ex.ToString();
            this.programmaticModalPopup.Show();
        }
        
    }

    private void ClearAll()
    {
        this.ddlOrganization.SelectedIndex = -1;
        foreach (ListItem lst in chklstApplications.Items)
        {
            lst.Selected = false;
        }
    }
}
