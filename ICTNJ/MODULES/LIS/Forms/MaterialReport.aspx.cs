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
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;

using Oracle.DataAccess.Client;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class MODULES_LIS_Forms_MaterialReport : System.Web.UI.Page
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

       // block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("4,10,4") == true)
        {
            if (!IsPostBack)
            {
                this.LoadOrganisation();
                Session["Rpt"] = null;
                Session["SelectionCriteria"] = null;
            }

            if ( Session["Rpt"] != null)
            {
                this.ReportViewer.ReportSource = (ReportDocument)Session["Rpt"];
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    protected void btnGenerateRpt_Click(object sender, EventArgs e)
    {
        try
        {
            string strSelection = "";

            if (drpOrganisation.SelectedIndex > 0 && drpLibrary.SelectedIndex > 0)
                strSelection = " {VW_LIBRARY_INFO.ORG_ID}=" + drpOrganisation.SelectedValue + " AND {VW_LIBRARY_INFO.LIBRARY_ID} = " + drpLibrary.SelectedValue ;
            else if (drpOrganisation.SelectedIndex > 0 && drpLibrary.SelectedIndex == 0)
                strSelection = " {VW_LIBRARY_INFO.ORG_ID}=" + drpOrganisation.SelectedValue ;
            else if (drpOrganisation.SelectedIndex == 0 && drpLibrary.SelectedIndex > 0)
                strSelection = " {VW_LIBRARY_INFO.LIBRARY_ID} = " + drpLibrary.SelectedValue;
        
         
            ReportDocument Rpt = new ReportDocument();
            string path = Server.MapPath("~") + "\\MODULES\\LIS\\REPORTS\\LIS.rpt";
            Rpt.Load(path);

            Rpt.RecordSelectionFormula = strSelection;

            Rpt.SetDatabaseLogon("LIS_OWNER", "LIS_OWNER", "ictnjdb", "");

            this.ReportViewer.ReportSource = Rpt;
            Session["Rpt"] = Rpt;
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["OrgList"] = BLLOrganization.GetOrganizationNameList();
            this.drpOrganisation.DataSource = (List<ATTOrganization>)Session["OrgList"];
            this.drpOrganisation.DataTextField = "OrgName";
            this.drpOrganisation.DataValueField = "OrgId";
            this.drpOrganisation.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Organisation";
            a.Value = "0";
            drpOrganisation.Items.Insert(0, a);

            Session["LibList"] = BLLLibrary.GetLibraryNameList();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void drpOrganisation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.drpLibrary.Items.Clear();

            Session["Rpt"] = null;
            
            if (this.drpOrganisation.SelectedIndex > 0)
            {
                List<ATTLibrary> lstLib = (List<ATTLibrary>)Session["LibList"];


                ATTLibrary ObjLibraryName = new ATTLibrary();
                ObjLibraryName.LstLibraryName = lstLib.FindAll(

                                                                    delegate(ATTLibrary Lib)
                                                                    {
                                                                        return Lib.OrgID == int.Parse(this.drpOrganisation.SelectedValue);
                                                                    }
                                                               );

                this.drpLibrary.DataSource = ObjLibraryName.LstLibraryName;
                this.drpLibrary.DataTextField = "LibraryName";
                this.drpLibrary.DataValueField = "LibraryID";
                this.drpLibrary.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "Select Library";
                a.Value = "0";
                drpLibrary.Items.Insert(0, a);

                drpLibrary.Enabled = true;
            }
            else
            {
                drpLibrary.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
       
    }
}
