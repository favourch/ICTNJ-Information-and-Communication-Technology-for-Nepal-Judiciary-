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

public partial class MODULES_CMS_Forms_CaseAccount : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // ClearControls();
            LoadUnPiadAmount();
        }
    }

    void LoadUnPiadAmount()
    {
        try
        {
            List<ATTCaseAccountForward> AccountForwardedList = BLLCaseAccountForward.GetUnPaidAmount(9, "N");
            grdCaseAccount.DataSource = AccountForwardedList;
            grdCaseAccount.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void ClearControls()
    {
        foreach (GridViewRow row in grdCaseAccount.Rows)
        {
            CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkPaid");
            cbSelect.Checked = false;
        }

        grdLitigants.SelectedIndex = -1;
        grdLitigants.DataSource = null;
        grdLitigants.DataBind();
       

        txtTranDate_RQD.Text = "";
        txtRemarks.Text = "";
        //txtTranDate_RQD.Text = Session["NepDate"].ToString();
    }

    protected void grdLitigants_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void grdCaseAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
  
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTranDate_RQD.Text == "")
        {
            lblStatus.Text = "Saving Error";
            lblStatusMessage.Text = "Enter Trasaction Date first";
            programmaticModalPopup.Show();
            return;
        }

        double caseID = 0;
        //int tranSeq = 0;
        ATTCaseAccountMaster attCM = new ATTCaseAccountMaster();
        foreach (GridViewRow gRow in grdCaseAccount.Rows)
        {
            CheckBox cbSelect = (CheckBox)gRow.Cells[0].FindControl("chkPaid");
            if (cbSelect.Checked == true)
            {
                caseID = double.Parse(gRow.Cells[1].Text);
                //tranSeq = int.Parse(gRow.Cells[2].Text);

                ATTCaseAccountDetails attCD = new ATTCaseAccountDetails(double.Parse(gRow.Cells[1].Text), txtTranDate_RQD.Text, 0, int.Parse(gRow.Cells[2].Text), double.Parse(gRow.Cells[4].Text));
                attCD.EntryBy = strUser;
                attCM.LstAccountDetails.Add(attCD);

                ATTCaseAccountForward attCAF = new ATTCaseAccountForward(double.Parse(gRow.Cells[1].Text), int.Parse(gRow.Cells[2].Text), double.Parse(gRow.Cells[4].Text), "Y");
                attCAF.EntryBy = strUser;
                attCM.LstAccountForward.Add(attCAF);
            }
        }
        
        if (grdLitigants.SelectedIndex > -1)
        {
            GridViewRow row = grdLitigants.SelectedRow;
            attCM.CaseID = double.Parse(row.Cells[0].Text);
            attCM.TransactionDate = txtTranDate_RQD.Text.Trim();
            attCM.TransactionSequence = 0;
            attCM.LitigantID = double.Parse(row.Cells[1].Text);
            attCM.AttorneyID = double.Parse(row.Cells[2].Text);
            attCM.Remarks = txtRemarks.Text.Trim();
            attCM.EntryBy = strUser;
        }
        else
        {
            attCM.CaseID = caseID;
            attCM.TransactionDate = txtTranDate_RQD.Text.Trim();
            attCM.TransactionSequence = 0;
            attCM.LitigantID = null;
            attCM.AttorneyID = null;
            attCM.Remarks = txtRemarks.Text.Trim();
            attCM.EntryBy = strUser;
        }
        if (BLLCaseAccountMaster.SaveCaseAccountMaster(attCM))
        {
            LoadUnPiadAmount();
            ClearControls();
        }
    }

    protected void chkPaid_CheckedChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in grdCaseAccount.Rows)
        //{
        //    CheckBox cbSelect = (CheckBox)row.Cells[0].FindControl("chkPaid");

        //    if (cbSelect.Checked == true)
        //    {
        //        ATTLitigantSearch attLitigant = new ATTLitigantSearch();
        //        attLitigant.CaseID = int.Parse(row.Cells[1].Text);
        //        int? caseID = attLitigant.CaseID;
        //        List<ATTLitigantSearch> LitigantList = BLLLitigantSearch.GetLitigantSearch(attLitigant);
        //        List<ATTAttorney> AttorneyList = BLLAttorney.GetAttorney(caseID, null, null, "");

        //        List<ATTLitigantandAttorney> lstLA = new List<ATTLitigantandAttorney>();
        
        //        foreach (ATTLitigantSearch attL in LitigantList)
        //        {
        //            ATTLitigantandAttorney attLA = new ATTLitigantandAttorney();
        //            attLA.CaseID = attL.CaseID;
        //            attLA.LitigantID = attL.LitigantID;
        //            attLA.AttorneyID = 0;
        //            attLA.Name = attL.LitigantName;
        //            attLA.Gender = attL.Gender;
        //            attLA.DOB = attL.DOB;
        //            lstLA.Add(attLA);
        //        }
        //        foreach (ATTAttorney attA in AttorneyList)
        //        {
        //            ATTLitigantandAttorney attLA = new ATTLitigantandAttorney();
        //            attLA.CaseID = attA.CaseID;
        //            attLA.AttorneyID = attA.LitigantID;
        //            attLA.LitigantID = 0;
        //            attLA.Name = attA.AttorneyName;
        //            attLA.Gender = attA.Gender;
        //            attLA.DOB = attA.DOB;
        //            lstLA.Add(attLA);
        //        }

        //        grdLitigants.DataSource = lstLA;
        //        grdLitigants.DataBind();
        //    }
        //}
    }

    protected void grdCaseAccount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[5].Visible = false;
    }

    protected void grdLitigants_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        double previousCaseID = 0;
        double newCaseID = 0;
        foreach (GridViewRow row in this.grdCaseAccount.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkPaid");
            if (cb.Checked)
            {
                previousCaseID = double.Parse(row.Cells[1].Text);
                break;
            }
        }

        if (previousCaseID != 0)
        {
            foreach (GridViewRow row in this.grdCaseAccount.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkPaid");
                if (cb.Checked)
                {
                    newCaseID = double.Parse(row.Cells[1].Text);
                    if (newCaseID != previousCaseID)
                    {
                        this.lblStatusMessage.Text = "Please Select Row of Only One Case.";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
                //cb.Checked = false;
            }
        }
        else
        {
            this.lblStatusMessage.Text = "Please Select Atleast One Row.";
            this.programmaticModalPopup.Show();
            return;
        }

        LoadLitigantsAndAttorney(newCaseID);
    }

    void LoadLitigantsAndAttorney(double caseID)
    {
        try
        {
            ATTLitigantSearch attLitigant = new ATTLitigantSearch();
            attLitigant.CaseID = caseID;
           
            List<ATTLitigantSearch> LitigantList = BLLLitigantSearch.GetLitigantSearch(attLitigant);
            List<ATTAttorney> AttorneyList = BLLAttorney.GetAttorney(caseID,"Y");

            List<ATTLitigantandAttorney> lstLA = new List<ATTLitigantandAttorney>();

            foreach (ATTLitigantSearch attL in LitigantList)
            {
                ATTLitigantandAttorney attLA = new ATTLitigantandAttorney();
                attLA.CaseID = attL.CaseID;
                attLA.LitigantID = attL.LitigantID;
                attLA.AttorneyID = 0;
                attLA.Name = attL.LitigantName;
                attLA.Gender = attL.Gender;
                attLA.DOB = attL.DOB;
                lstLA.Add(attLA);
            }
            foreach (ATTAttorney attA in AttorneyList)
            {
                ATTLitigantandAttorney attLA = new ATTLitigantandAttorney();
                attLA.CaseID = attA.CaseID;
                attLA.AttorneyID = attA.LitigantID;
                attLA.LitigantID = 0;
                attLA.Name = attA.AttorneyName;
                attLA.Gender = attA.AttorneyGender;
                attLA.DOB = attA.AttorneyDOB;
                lstLA.Add(attLA);
            }

            grdLitigants.DataSource = lstLA;
            grdLitigants.DataBind();
        }

        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdCaseAccount_Sorting(object sender, GridViewSortEventArgs e)
    {
        
    }
}
