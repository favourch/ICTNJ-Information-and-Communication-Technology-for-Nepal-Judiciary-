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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_CMS_LookUp_SectionClerkCase : System.Web.UI.Page
{
    string strUser = "shyam";
    int orgID = 9;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
           
        }
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
  
    void ClearControls()
    {
        txtClrkFromDate_RQD.Text = "";
        foreach (GridViewRow row in grdClerk.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
            cbSelect.Checked = false;
        }
        lstOrgUnits.SelectedIndex = -1;
        Session["CaseID"] = null;
        Session["CaseTypeID"] = null;
    }

    void ClearCaseSearch()
    {
        ((GridView)CaseSearch1.FindControl("grdCase")).SelectedIndex = -1;
        ((GridView)CaseSearch1.FindControl("grdCase")).DataSource = "";
        ((GridView)CaseSearch1.FindControl("grdCase")).DataBind();
        ((DropDownList)CaseSearch1.FindControl("ddlCaseType")).SelectedIndex = -1;
        ((TextBox)CaseSearch1.FindControl("txtRegNo")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtCaseNo")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtRegDate")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtAppelantName")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtRespondantName")).Text = "";
    }

    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        //uctl grd selected index changed
        Session["CaseID"] = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
        Session["CaseTypeID"] = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[0].Text);

        try
        {
            List<ATTSectionCaseType> OrgUnitList = BLLSectionCaseType.GetSecCaseType(orgID, (int)Session["CaseTypeID"]);

            Session["UnitList"] = OrgUnitList;
            lstOrgUnits.DataSource = OrgUnitList;
            lstOrgUnits.DataTextField = "UnitName";
            lstOrgUnits.DataValueField = "UnitID";
            lstOrgUnits.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }

    }

    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
            //uctl btn click
  
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        CaseSearch1.BubbleClick += new EventHandler(WebForm1_BubbleClick);
        CaseSearch1.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide(); 
    }

    protected void CaseSearch1_Load(object sender, EventArgs e)
    {

    }
   
    protected void lstOrgUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {
            ATTEmployeeWorkDivision attEWD = new ATTEmployeeWorkDivision();
            attEWD.OrgID = orgID;
            attEWD.OrgUnitID = int.Parse(lstOrgUnits.SelectedValue);
            attEWD.DesType = "O";
            List<ATTEmployeeWorkDivision> lstEWD = BLLEmployeeWorkDivision.SearchEmployee(attEWD);
            grdClerk.DataSource = lstEWD;
            grdClerk.DataBind();

            List<ATTSectionClerkCase> SecClerkList = BLLSectionClerkCase.GetSecClerkCase(double.Parse(Session["CaseID"].ToString()));
            ATTSectionClerkCase att = new ATTSectionClerkCase();
            foreach (GridViewRow row in grdClerk.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkSelect");
                att = SecClerkList.Find(delegate(ATTSectionClerkCase objAtt)
                {
                    return objAtt.SectionClerkID == double.Parse(row.Cells[1].Text.ToString());
                });
                if (att != null)
                {
                    cb.Checked = true;
                    row.Cells[5].Text = "U";
                }
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtClrkFromDate_RQD.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Select Clerk From Date First";
            programmaticModalPopup.Show();
            return;
        }
        if (lstOrgUnits.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Select Unit First";
            programmaticModalPopup.Show();
            return;
        }
        if (grdClerk.Rows.Count <= 0)
        {
            lblStatusMessage.Text = "This Section has no any Employees to assign for Clerk";
            programmaticModalPopup.Show();
            return;
        }
        List<ATTSectionCaseType> OrgUnitList = (List<ATTSectionCaseType>)Session["UnitList"];
        List<ATTSectionClerkCase> lstSCC = new List<ATTSectionClerkCase>();
       
        try
        {
            foreach (GridViewRow row in grdClerk.Rows)
            {
                CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
                if (cbSelect.Checked == true && row.Cells[5].Text=="")
                {
                    ATTSectionClerkCase attSCC = new ATTSectionClerkCase();
                    attSCC.OrgID = orgID;
                    attSCC.UnitID = int.Parse(lstOrgUnits.SelectedValue);
                    attSCC.CaseID = double.Parse(Session["CaseID"].ToString());
                    attSCC.CaseTypeID = int.Parse(Session["CaseTypeID"].ToString());
                    attSCC.FromDate = OrgUnitList[lstOrgUnits.SelectedIndex].FromDate;
                    attSCC.SectionClerkID = int.Parse(row.Cells[1].Text.ToString());
                    attSCC.SectionClerkFromDate = txtClrkFromDate_RQD.Text.Trim();
                    attSCC.Action = "A";
                    attSCC.EntryBy = strUser;
                    lstSCC.Add(attSCC);
                }
                else if (cbSelect.Checked == false && row.Cells[5].Text == "U")
                {
                    ATTSectionClerkCase attSCC = new ATTSectionClerkCase();
                    attSCC.OrgID = orgID;
                    attSCC.UnitID = int.Parse(lstOrgUnits.SelectedValue);
                    attSCC.CaseID = double.Parse(Session["CaseID"].ToString());
                    attSCC.CaseTypeID = int.Parse(Session["CaseTypeID"].ToString());
                    attSCC.FromDate = OrgUnitList[lstOrgUnits.SelectedIndex].FromDate;
                    attSCC.SectionClerkID = int.Parse(row.Cells[1].Text.ToString());
                    attSCC.SectionClerkFromDate = txtClrkFromDate_RQD.Text.Trim();
                    attSCC.Action = "E";
                    attSCC.EntryBy = strUser;
                    lstSCC.Add(attSCC);
                }
            }
            if (lstSCC.Count > 0)
            {
                BLLSectionClerkCase.SaveSectionClerkCase(lstSCC);
                ClearControls();
                lblStatusMessage.Text = "Successfully Saved";
                programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        ClearCaseSearch();
    }

    protected void grdClerk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       e.Row.Cells[1].Visible = false;
       e.Row.Cells[5].Visible = false;
    }
}
