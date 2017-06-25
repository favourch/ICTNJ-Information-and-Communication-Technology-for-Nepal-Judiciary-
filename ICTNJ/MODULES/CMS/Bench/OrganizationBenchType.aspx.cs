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

using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;

using System.Collections.Generic;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_Bench_OrganizationBenchType : System.Web.UI.Page
{
    string entryBy = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBenchTypes();
            LoadOrganisations();
        }
    }

    private void LoadOrganisations()
    {
        try
        {
            List<ATTOrganization> orgLIST = BLLOrganization.GetOrganization();
        //Session["Organisation"] = orgLIST;

        grdOrganisation.DataSource = orgLIST;
        grdOrganisation.DataBind();

        grdOrganisation.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could not Load Organisations </br>";
            this.programmaticModalPopup.Show();
            
        }
        
    }

    private void LoadBenchTypes()
    {
        try
        {
            List<ATTBenchType> benchTypeLIST = BLLBenchType.GetBenchType(null, "Y", 0);
        Session["BenchTypes"] = benchTypeLIST;
        lstBenchType.DataSource = benchTypeLIST;
        lstBenchType.DataBind();

        lstBenchType.SelectedIndex = -1;
        }
        catch (Exception)
        {

            lblStatusMessage.Text = "Could not Load Bench Typess </br>";
            this.programmaticModalPopup.Show();
        }
        
    }

    protected void lstBenchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTOrganisationBenchType> orgBenchTypeList = ((List<ATTBenchType>)Session["BenchTypes"])[lstBenchType.SelectedIndex].OrganisationBenchTypeLIST;


        foreach (GridViewRow row in grdOrganisation.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked = false;
            row.Cells[3].Text = "";
            int index = orgBenchTypeList.FindIndex(delegate(ATTOrganisationBenchType obj)
                                                 {
                                                     return row.Cells[1].Text == obj.OrganisationID.ToString();
                                                 });
            if (index >= 0)
            {
                ((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked = (orgBenchTypeList[index].Active == "Y") ? true : false;
                row.Cells[3].Text = orgBenchTypeList[index].Active;
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTOrganisationBenchType> OrgBenchTypeLST = new List<ATTOrganisationBenchType>();
        foreach (GridViewRow row in grdOrganisation.Rows)
        {

            CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkOrganisation");
            string active = row.Cells[3].Text;

            string action = "";
            string actv = "";
            bool AddEdit = false;
            if (chk.Checked)
            {
                if (active == "")
                {
                    action = "A";
                    actv = "Y";
                    AddEdit = true;
                }
                if (active == "N")
                {
                    action = "E";
                    actv = "Y";
                    AddEdit = true;
                }
            }
            else if (!chk.Checked)
            {
                if (active == "Y")
                {
                    action = "E";
                    actv = "N";
                    AddEdit = true;
                }
            }

            if (AddEdit)
            {
                ATTOrganisationBenchType orgBenchType = new ATTOrganisationBenchType();

                orgBenchType.OrganisationID = int.Parse(row.Cells[1].Text);
                orgBenchType.BenchTypeID = int.Parse(lstBenchType.SelectedValue);
                orgBenchType.Active = actv;
                orgBenchType.Action = action;
                orgBenchType.EntryBy = entryBy;
                OrgBenchTypeLST.Add(orgBenchType);
            }
        }
        if (OrgBenchTypeLST.Count > 0)
        {
            if (BLLOrganisationBenchType.SaveOrganisationBenchType(OrgBenchTypeLST))
            {
                LoadBenchTypes();
                foreach (GridViewRow row in grdOrganisation.Rows)
                {
                    ((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked = false;
                    row.Cells[3].Text = "";
                }
                lblStatusMessage.Text = "Data Saved Successfully </br>";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Could not Save Data </br>";
                this.programmaticModalPopup.Show();
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lstBenchType.SelectedIndex = -1;
        foreach (GridViewRow row in grdOrganisation.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked = false;
            row.Cells[3].Text = "";
        }

        lblStatusMessage.Text = "Operation Cancelled </br>";
        this.programmaticModalPopup.Show();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdOrgBenchType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void chkOrganisation_CheckedChanged(object sender, EventArgs e)
    {

        bool val = true;
        foreach (GridViewRow row in grdOrganisation.Rows)
        {
            if (!((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked)
                val = false;
        }
        ((CheckBox)grdOrganisation.HeaderRow.Cells[0].FindControl("chkOrganisation")).Checked = val;
    }
    protected void chkHEADEROrganisation_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdOrganisation.HeaderRow.Cells[0].FindControl("chkOrganisation")).Checked;
        foreach (GridViewRow row in grdOrganisation.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chkOrganisation")).Checked = val;
        }
    }

}
