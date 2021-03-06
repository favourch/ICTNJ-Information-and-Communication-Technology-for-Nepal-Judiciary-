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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using System.Collections.Generic;

public partial class MODULES_CMS_LookUp_OrganizationDecisionType : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LoadOrganizations(orgID);
            LoadDecisionTypes();
            ClearControls();
        }
    }

    void LoadOrganizations(int orgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(orgID);
            this.grdOrganization.DataSource = OrganizationList;
            this.grdOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDecisionTypes()
    {
        try
        {
            List<ATTDecisionType> DecisionTypeList = BLLDecisionType.GetDecisionType(null, null, 0);
            Session["DecisionType"] = DecisionTypeList;
            this.lstDecisionType.DataSource = DecisionTypeList;
            this.lstDecisionType.DataTextField = "DecisionTypeName";
            this.lstDecisionType.DataValueField = "DecisionTypeID";
            this.lstDecisionType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void lstDecisionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearOrgGrids();
        this.hdnDecTypeID.Value = this.lstDecisionType.SelectedValue;
        this.txtDecisionTypeName_RQD.Text = this.lstDecisionType.SelectedItem.Text;
        List<ATTOrgDecisionType> OrgDecisionTypeList = BLLOrgDecisionType.GetOrgDecisionType(0, int.Parse(this.lstDecisionType.SelectedValue), null, "N", 0);
        foreach (ATTOrgDecisionType orgDecType in OrgDecisionTypeList)
        {
            foreach (GridViewRow row in this.grdOrganization.Rows)
            {
                CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));

                if ((orgDecType.Active == "Y") && (orgDecType.OrgID == int.Parse(row.Cells[1].Text)) && (orgDecType.DecisionTypeID==int.Parse(this.lstDecisionType.SelectedValue.ToString()) ))
                {
                    cbSelect.Checked = true;
                    row.Cells[3].Text = "Y";
                }
                if ((orgDecType.Active == "N") && (orgDecType.OrgID == int.Parse(row.Cells[1].Text)) && (orgDecType.DecisionTypeID == int.Parse(this.lstDecisionType.SelectedValue.ToString())))
                {
                    cbSelect.Checked = false;
                    row.Cells[3].Text = "N";
                }
            }
        }
    }

    protected void grdOrganization_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtDecisionTypeName_RQD.Text == "")
        {
            lblStatusMessage.Text = "निर्नयको किसिम लेख्नुस";
            programmaticModalPopup.Show();
            return;
        }

        ATTDecisionType objDecisionType = new ATTDecisionType(int.Parse(this.hdnDecTypeID.Value), this.txtDecisionTypeName_RQD.Text.Trim(), "Y");
        objDecisionType.EntryBy = strUser;
        foreach (GridViewRow row in grdOrganization.Rows)
        {
            ATTOrgDecisionType attODT = new ATTOrgDecisionType();
            CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            string active = "";
            string action = "";
            if (cbSelect.Checked == true && row.Cells[3].Text == "")
            {
                active = "Y";
                action = "A";
            }
            else if (cbSelect.Checked == true && row.Cells[3].Text == "N")
            {
                active = "Y";
                action = "E";
            }

            else if (cbSelect.Checked == false && row.Cells[3].Text == "Y")
            {
                active = "N";
                action = "E";
            }
            else
                continue;
            attODT = new ATTOrgDecisionType(int.Parse(row.Cells[1].Text), int.Parse(this.hdnDecTypeID.Value), active);
            attODT.Action = action;
            attODT.EntryBy = strUser;
            objDecisionType.LstOrgDecisionType.Add(attODT);
        }
        try
        {
            List<ATTDecisionType> DecisionTypeList = (List<ATTDecisionType>)Session["DecisionType"];
            BLLDecisionType.SaveDecisionType(objDecisionType);
            if (this.lstDecisionType.SelectedIndex !=-1)
            {
                DecisionTypeList[this.lstDecisionType.SelectedIndex].DecisionTypeID = objDecisionType.DecisionTypeID;
                DecisionTypeList[this.lstDecisionType.SelectedIndex].DecisionTypeName = objDecisionType.DecisionTypeName;
                DecisionTypeList[this.lstDecisionType.SelectedIndex].Active = objDecisionType.Active;
            }
            else
                DecisionTypeList.Add(objDecisionType);
            this.lblStatusMessage.Text = "Successfully Saved.";
            this.programmaticModalPopup.Show();
            this.lstDecisionType.DataSource = DecisionTypeList;
            this.lstDecisionType.DataBind();
            ClearControls();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.hdnDecTypeID.Value = "0";
        this.txtDecisionTypeName_RQD.Text = "";
        this.lstDecisionType.SelectedIndex = -1;
        ClearOrgGrids();
    }

    void ClearOrgGrids()
    {
        foreach (GridViewRow row in this.grdOrganization.Rows)
        {
            CheckBox cbSelect = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            cbSelect.Checked = false;
            row.Cells[3].Text = "";

        }
    }
}