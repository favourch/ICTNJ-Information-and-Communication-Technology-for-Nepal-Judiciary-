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

public partial class MODULES_CMS_Tarikh_TarikhCourtBato : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            LoadOrganizationWithChilds();
        }
    }

    void LoadOrganizationWithChilds()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrgWithChilds(orgID);
            lstCourt.DataSource = lstOrg;
            lstCourt.DataTextField = "OrgName";
            lstCourt.DataValueField = "OrgID";
            lstCourt.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        this.txtFromDate_RQD.Text = "";
        this.txtTotalDays_RQD.Text = "";
        this.txtBatoKoMyaad_RQD.Text = "";
        this.txtFromDate_RQD.Attributes.Clear();
        this.txtTotalDays_RQD.Attributes.Clear();
        this.txtBatoKoMyaad_RQD.Attributes.Clear();
        this.lstCourt.SelectedIndex = -1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtFromDate_RQD.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Please Enter From Date First.";
            programmaticModalPopup.Show();
            return;
        }
        if (txtTotalDays_RQD.Text == "")
        {
            lblStatusMessage.Text = "Please Enter Total Days First.";
            programmaticModalPopup.Show();
            return;
        }
        if (txtBatoKoMyaad_RQD.Text == "")
        {
            lblStatusMessage.Text = "Please Enter Bato ko Myaad First.";
            programmaticModalPopup.Show();
            return;
        }
        ATTTarekhCourtBato attTCB = new ATTTarekhCourtBato();
        try
        {
            if (this.lstCourt.SelectedIndex > -1)
            {
                attTCB.CourtID = int.Parse(lstCourt.SelectedValue);
                attTCB.FromDate = txtFromDate_RQD.Text.Trim();
                attTCB.TotalDays = int.Parse(txtTotalDays_RQD.Text.ToString());
                attTCB.BatoKoMayad = int.Parse(txtBatoKoMyaad_RQD.Text.ToString());
                attTCB.EntryBy = strUser;

                if ((this.txtFromDate_RQD.HasAttributes) && (this.txtTotalDays_RQD.HasAttributes) && (this.txtBatoKoMyaad_RQD.HasAttributes))
                {
                    if ((this.txtFromDate_RQD.Text == this.txtFromDate_RQD.Attributes["FromDate"].ToString()) && (this.txtTotalDays_RQD.Text == this.txtTotalDays_RQD.Attributes["TotalDays"].ToString()) && (this.txtBatoKoMyaad_RQD.Text == this.txtBatoKoMyaad_RQD.Attributes["BatoKoMyaad"].ToString()))
                    {
                        this.lblStatusMessage.Text = "No Changes Have Been Made.";
                        this.programmaticModalPopup.Show();
                        return;
                    }

                    if ((txtFromDate_RQD.Text.Trim()).CompareTo(this.txtFromDate_RQD.Attributes["FromDate"].ToString()) < 0)
                    {
                        lblStatusMessage.Text = "Please Enter Date Greater Than (Or) Equal To " + this.txtFromDate_RQD.Attributes["FromDate"].ToString();
                        programmaticModalPopup.Show();
                        return;
                    }

                    if (this.txtFromDate_RQD.Text == this.txtFromDate_RQD.Attributes["FromDate"].ToString())
                        attTCB.Action = "E";
                    else attTCB.Action = "A";
                }

                else
                {
                    attTCB.Action = "A";
                }
                BLLTarekhCourtBato.SaveTarikhCourtBato(attTCB);
                ClearControls();
            }
            else
            {
                lblStatusMessage.Text = "Please Select The Court.";
                programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstCourt_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.txtFromDate_RQD.Text = "";
            this.txtTotalDays_RQD.Text = "";
            this.txtBatoKoMyaad_RQD.Text = "";
            List<ATTTarekhCourtBato> LstTarekhCourtBato = BLLTarekhCourtBato.GetTarikhCourtBato(int.Parse(this.lstCourt.SelectedValue));
            if (LstTarekhCourtBato.Count == 1)
            {
                this.txtFromDate_RQD.Text = LstTarekhCourtBato[0].FromDate.Trim();
                this.txtFromDate_RQD.Attributes.Add("FromDate", LstTarekhCourtBato[0].FromDate.Trim());
                this.txtTotalDays_RQD.Text = LstTarekhCourtBato[0].TotalDays.ToString();
                this.txtTotalDays_RQD.Attributes.Add("TotalDays", LstTarekhCourtBato[0].TotalDays.ToString());
                this.txtBatoKoMyaad_RQD.Text = LstTarekhCourtBato[0].BatoKoMayad.ToString();
                this.txtBatoKoMyaad_RQD.Attributes.Add("BatoKoMyaad", LstTarekhCourtBato[0].BatoKoMayad.ToString());
            }
            else if (LstTarekhCourtBato.Count > 1)
            {
                this.lblStatusMessage.Text = "Multiple Rows Found For This Organization.";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
