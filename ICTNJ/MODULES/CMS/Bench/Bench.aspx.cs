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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_CMS_Bench_Bench : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Bench"] = new List<ATTBench>();
            chkActive.Checked = true;
            LoadOrgWithChilds();
        }
    }

    void LoadOrgWithChilds()
    {
        try
        {
            List<ATTOrganization> orgList = BLLOrganization.GetOrgWithChilds(orgID);
            lstOrganization.DataSource = orgList;
            lstOrganization.DataTextField = "OrgName";
            lstOrganization.DataValueField = "OrgID";
            lstOrganization.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        lstOrganization.SelectedIndex = -1;
        txtBenchDesc_RQD.Text = "";
       hdnBenchID.Value = "0";
        chkActive.Checked = true;

        grdBench.DataSource = null;
        grdBench.DataBind();
        Session["Bench"] = null;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (lstOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please select organization first";
            programmaticModalPopup.Show();
            return;
        }
       
        List<ATTBench> lstBench = (List<ATTBench>)Session["Bench"];
        if (grdBench.SelectedIndex == -1)
        {
            ATTBench attBench = new ATTBench();
            attBench.OrgID = int.Parse(lstOrganization.SelectedValue);
            attBench.BenchNo = 0;
            attBench.BenchDesc = txtBenchDesc_RQD.Text.Trim();
            attBench.Active = (chkActive.Checked == true) ? "Y" : "N";
            attBench.EntryBy = strUser;
            attBench.Action = "A";
            lstBench.Add(attBench);
        }
        else
        {
            lstBench[grdBench.SelectedIndex].OrgID = int.Parse(grdBench.SelectedRow.Cells[0].Text.ToString());
            lstBench[grdBench.SelectedIndex].BenchNo = int.Parse(hdnBenchID.Value.ToString());
            lstBench[grdBench.SelectedIndex].BenchDesc = txtBenchDesc_RQD.Text.Trim();
            lstBench[grdBench.SelectedIndex].Active = (chkActive.Checked == true) ? "Y" : "N";
            lstBench[grdBench.SelectedIndex].Action = (grdBench.SelectedRow.Cells[4].Text == "A") ? "A" : "E";
        }
        Session["Bench"] = lstBench;
        grdBench.DataSource = lstBench;
        grdBench.DataBind();
        for (int i = 0; i < grdBench.Rows.Count; i++)
        {
            if (int.Parse(grdBench.Rows[i].Cells[1].Text.ToString()) > 0)
                ((LinkButton)grdBench.Rows[i].Cells[6].Controls[0]).Visible = false;
        }
        txtBenchDesc_RQD.Text = "";
        hdnBenchID.Value = "0";
        grdBench.SelectedIndex = -1;
    }

    protected void grdBench_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnBenchID.Value =grdBench.SelectedRow.Cells[1].Text.Trim();
        txtBenchDesc_RQD.Text = grdBench.SelectedRow.Cells[2].Text.Trim();
        chkActive.Checked = (grdBench.SelectedRow.Cells[3].Text == "Y") ? true : false;
       
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTBench> benchList = (List<ATTBench>)Session["Bench"];
        if (benchList.Count > 0)
            BLLBench.SaveBench(benchList);
            ClearControls();
    }

    protected void lstOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTBench> BenchLST = BLLBench.GetBench(int.Parse(lstOrganization.SelectedValue), null, "", 0);
            grdBench.DataSource = BenchLST;
            grdBench.DataBind();
            Session["Bench"] = BenchLST;

            for (int i = 0; i < grdBench.Rows.Count; i++)
            {
                ((LinkButton)grdBench.Rows[i].Cells[6].Controls[0]).Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void grdBench_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTBench> benchList = (List<ATTBench>)Session["Bench"];
        if (grdBench.Rows[e.RowIndex].Cells[4].Text == "A")
        {
            grdBench.Rows[e.RowIndex].Visible = false;
            benchList.RemoveAt(e.RowIndex);
        }
    }

    protected void grdBench_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
}
