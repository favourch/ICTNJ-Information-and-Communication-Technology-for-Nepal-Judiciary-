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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_CMS_Bench_BenchJudgeFormation : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["OrgBenchType"] = null;
            LoadBench();
            LoadOrgBenchType();
            LoadJudges();
        }
    }

    void LoadBench()
    {
        try
        {
            List<ATTBench> lstBench = BLLBench.GetBench(orgID, null, "Y", 1);
            DDLBench_RQD.DataSource = lstBench;
            DDLBench_RQD.DataTextField = "BenchDesc";
            DDLBench_RQD.DataValueField = "BenchNo";
            DDLBench_RQD.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadOrgBenchType()
    {
        try
        {
            List<ATTOrganisationBenchType> lstOrgBenchType = BLLOrganisationBenchType.GetOrganisationBenchType(orgID, null, "Y");

            Session["OrgBenchType"] = lstOrgBenchType;
            DDLBenchType_RQD.DataSource = lstOrgBenchType;
            DDLBenchType_RQD.DataTextField = "BenchTypeName";
            DDLBenchType_RQD.DataValueField = "BenchTypeID";
            DDLBenchType_RQD.DataBind();
            DDLBenchType_RQD.Items.Insert(0, new ListItem("छान्नुस्", "0"));
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadJudges()
    {
        ATTEmployeeSearch attEmp = new ATTEmployeeSearch();
        attEmp.OrgID = orgID;
        attEmp.DesType = "J";
        try
        {
            List<ATTEmployeeSearch> lstjudge = BLLEmployeeSearch.SearchEmployee(attEmp);
            grdJudge.DataSource = lstjudge;
            grdJudge.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        txtFromDate.Text = "";
        txtBJFromDate.Text = "";
       
        DDLBench_RQD.SelectedIndex = -1;
        DDLBenchType_RQD.SelectedIndex = -1;
     
        foreach (GridViewRow row in grdJudge.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
            cbSelect.Checked = false;
        }
        
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (DDLBench_RQD.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Bench first";
            programmaticModalPopup.Show();
            return;
        }
        if (DDLBenchType_RQD.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Bench Type first";
            programmaticModalPopup.Show();
            return;
        }
        if (txtFromDate.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Please Enter From Date first";
            programmaticModalPopup.Show();
            return;
        }
        if (txtBJFromDate.Text == "___/__/__")
        {
            lblStatusMessage.Text = "Please Enter From Date for Judge first";
            programmaticModalPopup.Show();
            return;
        }
        ATTBenchFormation attBF = new ATTBenchFormation();
        attBF.OrgID = orgID;
        attBF.BenchNo = int.Parse(DDLBench_RQD.SelectedValue);
        attBF.BenchTypeID = int.Parse(DDLBenchType_RQD.SelectedValue);
        attBF.FromDate = txtFromDate.Text.Trim();
        attBF.EntryBy = strUser;


        List<ATTOrganisationBenchType> lstOBT = (List<ATTOrganisationBenchType>)Session["OrgBenchType"];
        int intFlag = 0;
        foreach (GridViewRow row in grdJudge.Rows)
        {
            if (lstOBT[intFlag].Cardinality == 1 && intFlag > 0)
            {
                lblStatusMessage.Text = "Only one judge can assign for bench type of cardinality one";
                programmaticModalPopup.Show();
                return;
            }
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
            if (cbSelect.Checked == true)
            {
                ATTBenchJudge attBJ = new ATTBenchJudge();
                attBJ.OrgID = orgID;
                attBJ.BenchNo = int.Parse(DDLBench_RQD.SelectedValue);
                attBJ.BenchTypeID = int.Parse(DDLBenchType_RQD.SelectedValue);
                attBJ.FromDate = txtFromDate.Text.Trim();
                attBJ.BJFromDate = txtBJFromDate.Text.Trim();
                attBJ.JudgeID = int.Parse(row.Cells[1].Text.ToString());
                attBJ.EntryBy = strUser;
                attBF.LstBenchJudge.Add(attBJ);
                intFlag++;
            }
        }

        if (BLLBenchFormation.SaveBenchFormation(attBF))
        {
            ClearControls();
            lblStatusMessage.Text = "Successfully Saved";
            programmaticModalPopup.Show();
        }
    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        Session["OrgBenchType"] = null;
    }

    protected void grdJudge_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
   
}

  
