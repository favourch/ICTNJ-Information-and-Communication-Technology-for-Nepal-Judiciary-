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

public partial class MODULES_CMS_Forms_CaseRegistrationInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            getCaseRegDetails();
        }

    }


    protected void getCaseRegDetails()
    {
        ATTCaseRegistration CaseRegOBJ = BLLCaseRegistration.GetCaseRegistration(double.Parse(Session["CaseNo"].ToString()), 0,1, 1, 1, 1, 1, 1, 1, 1,null)[0];
        
        //Case Details
        this.lblCaseType.Text = CaseRegOBJ.CaseTypeName;
        this.lblRegType.Text = CaseRegOBJ.RegTypeName;
        this.lblRegDiary.Text = CaseRegOBJ.RegDiaryName;
        this.lblRegSubject.Text = CaseRegOBJ.RegSubjectName;
        this.lblRegSubName.Text = CaseRegOBJ.RegDiarySubName;
        this.lblRegDate.Text = CaseRegOBJ.CaseRegistrationDate;
        this.lblPreceedingType.Text = CaseRegOBJ.ProceedingType;
        this.lblForwardToAccount.Text = CaseRegOBJ.AccountForwarded == "Y" ? "पठाउने" : "नपठाउने";


        //ACCOUNT FORWARD DETAILS
        if (CaseRegOBJ.AccountForwarded == "Y")
        {
            pnlAccountInfo.Visible = true;
        }
        else
        {
            pnlAccountInfo.Visible = false;
        }
        this.grdAccountFWD.DataSource = CaseRegOBJ.CaseAccountForwardLST;
        this.grdAccountFWD.DataBind();


        //CHECK LIST DETAILS
        this.grdCheckList.DataSource = CaseRegOBJ.CaseCheckListLST;
        this.grdCheckList.DataBind();


        //APPELLANTS DETAILS
        this.grdAppellant.DataSource = CaseRegOBJ.AppellantLST;
        this.grdAppellant.DataBind();

        //RESPONDANTS DETAILS
        this.grdRespondant.DataSource = CaseRegOBJ.RespondantLST;
        this.grdRespondant.DataBind();

        //LAWYERS DETAILS
        CaseRegOBJ.CaseLawyerLST.RemoveAll(
                delegate(ATTCaseLaywer obj)
                {
                    return CaseRegOBJ.CaseLawyerLST.IndexOf(obj) != CaseRegOBJ.CaseLawyerLST.FindIndex(
                        delegate(ATTCaseLaywer obj1)
                        {
                            return obj.LawyerID == obj1.LawyerID;
                        });
                });
        this.grdLawyers.DataSource = CaseRegOBJ.CaseLawyerLST;
        this.grdLawyers.DataBind();

        //WITNESS DETAILS
        CaseRegOBJ.WitnessPersonLST.RemoveAll(
                delegate(ATTWitnessPerson obj)
                {
                    return CaseRegOBJ.WitnessPersonLST.IndexOf(obj) != CaseRegOBJ.WitnessPersonLST.FindIndex(
                        delegate(ATTWitnessPerson obj1)
                        {
                            return obj.WitnessID == obj1.WitnessID;
                        });
                });
        this.grdWitness.DataSource = CaseRegOBJ.WitnessPersonLST;
        this.grdWitness.DataBind();

        //EVIDENCE DETAILS
        this.grdEvidence.DataSource = CaseRegOBJ.CaseEvidenceLST;
        this.grdEvidence.DataBind();

        //DOCUMENTS DETAILS
        this.grdLitDocument.DataSource = CaseRegOBJ.CaseDocumentLitLST;
        this.grdLitDocument.DataBind();

        //CASE SUMMARY
        this.litCaseSummary.Text = CaseRegOBJ.CaseSummary;

        
    }
    protected void grdLitDocument_DataBound(object sender, EventArgs e)
    {
        for (int rowIndex = this.grdLitDocument.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = grdLitDocument.Rows[rowIndex];
            GridViewRow gvPreviousRow = grdLitDocument.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count - 2;
            cellCount++)
            {
                if (gvRow.Cells[cellCount].Text ==
                gvPreviousRow.Cells[cellCount].Text)
                {
                    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                    {
                        gvRow.Cells[cellCount].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[cellCount].RowSpan =
                        gvPreviousRow.Cells[cellCount].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[cellCount].Visible = false;
                }
            }
        }
    }
    protected void grdLitDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void grdLitDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void lnkFileName_Click(object sender, EventArgs e)
    {

    }
    protected void btnEditCaseRegDet_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration.aspx");
    }
    protected void btnEditSummary_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration4.aspx");
    }
    protected void btnEditDocuments_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration4.aspx");
    }
    protected void btnEditEvidence_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration4.aspx");
    }
    protected void btnEditWitness_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration3.aspx");
    }
    protected void btnEditLawyers_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration2.aspx");
    }
    protected void btnEditRespondant_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration.aspx");
    }
    protected void btnEditAppellant_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration.aspx");
    }
    protected void grdAccountFWD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void grdCheckList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void btnEditAccountForward_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration.aspx");
    }
    protected void btnEditCheckList_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseRegistration.aspx");
    }
}
