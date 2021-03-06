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
using PCS.SECURITY.ATT;
using PCS.CMS.ATT;
using PCS.CMS.BLL;

public partial class MODULES_CMS_Forms_CaseVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("1,25,1") == true)
        {
            Session["OrgID"] = user.OrgID;
            if (this.IsPostBack == false)
            {
                //ClearControls();
                LoadCaseType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }


    private void LoadCaseType()
    {
        List<ATTCaseType> caseTypeLST = BLLCaseType.GetCaseType(null, "Y", 1);

        ddlCaseType.DataSource = caseTypeLST;
        ddlCaseType.DataBind();
    }

    //void ClearControls()
    //{
    //    this.colCaseSearch.Collapsed = false;
    //    this.colCaseSearch.ClientState = "false";

    //}

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void CaseSearchControl_BubbleClickBtnCancel(object sender, EventArgs e)
    {
        //this.grdLitigantRes.DataSource = null;
        //DataBind();
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        
    }


    

    private void CaseSearchControl_BubbleClickBtn(object sender, EventArgs e)
    {
        

    }







    protected void grdPraEvidence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }




    protected void grdPraDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }










    

    



    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }



    protected void lnkDocumentName_Click(object sender, EventArgs e)
    {

    }

    protected void grdLitDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
    protected void CaseSearchControl_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.ddlCaseType.SelectedIndex < 1) && (this.txtRegDate.Text == "____/__/__") && (this.txtAppelantName.Text.Trim() == "") && (this.txtRespondantName.Text.Trim() == ""))
        {
            this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
            this.programmaticModalPopup.Show();
            return;
        }


        try
        {
            ATTCaseSearch obj = new ATTCaseSearch();
            //obj.CourtID = orgID;
            if (ddlCaseType.SelectedIndex > 0) obj.CaseTypeID = int.Parse(ddlCaseType.SelectedValue);
            if (txtRegDate.Text.Trim() != "" && txtRegDate.Text.Trim() != "____/__/__") obj.RegDate = txtRegDate.Text;
            if (txtAppelantName.Text.Trim() != "") obj.Appelant = txtAppelantName.Text;
            if (txtRespondantName.Text.Trim() != "") obj.Respondant = txtRespondantName.Text;

            obj.Verified = "U";
            obj.DecisionYesNo = null;


            List<ATTCaseSearch> lst = BLLCaseSearch.GetCaseSearch(obj);
            Session["CaseRegistration"] = lst;
            grdCase.DataSource = lst;
           // CaseCount = lst.Count;

            grdCase.DataBind();
            grdCase.SelectedIndex = -1;

            this.lblSearch.Text = "Total Records:- " + lst.Count;

            

            
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancelSearch_Click(object sender, EventArgs e)
    {
        this.ddlCaseType.SelectedValue = "0";
        this.txtRegDate.Text = "";
        this.txtAppelantName.Text = "";
        this.txtRespondantName.Text = "";
    }
    protected void grdCase_SelectedIndexChanged(object sender, EventArgs e)
    {
            pnlCaseInfo.Visible = true;

            getCaseRegDetails(double.Parse(this.grdCase.SelectedRow.Cells[2].Text));


    }
    protected void grdCase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
    }


    protected void getCaseRegDetails(double caseID)
    {
        ATTCaseRegistration CaseRegOBJ = BLLCaseRegistration.GetCaseRegistration(caseID, 0, 1, 1, 1, 1, 1, 1, 1, 1, null)[0];
        
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
                    return CaseRegOBJ.CaseLawyerLST.IndexOf(obj)!=CaseRegOBJ.CaseLawyerLST.FindIndex(
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
                            return obj.WitnessID== obj1.WitnessID;
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
    protected void ddlVerify_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlVerify.SelectedValue == "N")
        {
            this.lblDarpit.Visible = true;
            this.txtDarpit.Visible = true;
        }
        else
        {
            this.lblDarpit.Visible = false;
            this.txtDarpit.Visible = false;
            this.txtDarpit.Text = "";
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.grdCase.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "Please Select Case To Verify";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.ddlVerify.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "No Case is Verified";
            this.programmaticModalPopup.Show(); 
            return;
            
         
        }
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTCaseSearch> CaseRegLST = (List<ATTCaseSearch>)Session["CaseRegistration"];
        ATTCaseRegistration CaseRegOBJ = new ATTCaseRegistration();
        CaseRegOBJ.CaseID = double.Parse(this.grdCase.SelectedRow.Cells[2].Text);
        CaseRegOBJ.CourtID = CaseRegLST[this.grdCase.SelectedIndex].CourtID;
        CaseRegOBJ.CaseTypeID = CaseRegLST[this.grdCase.SelectedIndex].CaseTypeID;
        CaseRegOBJ.RegDiaryID = CaseRegLST[this.grdCase.SelectedIndex].RegistrationDiaryID;
        CaseRegOBJ.CaseRegistrationDate = CaseRegLST[this.grdCase.SelectedIndex].CaseRegDate;
        CaseRegOBJ.VerifiedYesNo = this.ddlVerify.SelectedValue;
        CaseRegOBJ.VerifiedBy = user.PID;
        CaseRegOBJ.VerifiedDate = this.txtVerifiedDate.Text;
        CaseRegOBJ.DarpithRemarks = this.txtDarpit.Text;
        CaseRegOBJ.Action = "E";

        if (BLLCaseRegistration.RegisterCase(CaseRegOBJ) == true)
        {
            CaseRegLST.RemoveAll(delegate(ATTCaseSearch obj)
                                                   {
                                                       return obj.CaseID == double.Parse(this.grdCase.SelectedRow.Cells[2].Text);
                                                   });
        }

        this.grdCase.DataSource = CaseRegLST;
        this.grdCase.DataBind();
        this.grdCase.SelectedIndex = -1;
        this.lblSearch.Text ="Total Records:- "+ CaseRegLST.Count.ToString();

        ClearControls(false);
            



    }


    void ClearControls(bool clearSearchControls)
    {
        if (clearSearchControls == true)
        {
            this.ddlCaseType.SelectedValue = "0";
            this.txtRegDate.Text = "";
            this.txtAppelantName.Text = "";
            this.txtRespondantName.Text = "";

            this.grdCase.DataSource = "";
            this.grdCase.DataBind();
        }


        this.lblCaseType.Text = "";
        this.lblRegType.Text = "";
        this.lblRegDiary.Text = "";
        this.lblRegSubject.Text = "";
        this.lblRegSubName.Text = "";
        this.lblRegDate.Text = "";
        this.lblPreceedingType.Text = "";
        this.lblForwardToAccount.Text = "";


        //APPELLANTS DETAILS
        this.grdAppellant.DataSource = "";
        this.grdAppellant.DataBind();

        //RESPONDANTS DETAILS
        this.grdRespondant.DataSource = "";
        this.grdRespondant.DataBind();




        //LAWYERS DETAILS
        this.grdLawyers.DataSource = "";
        this.grdLawyers.DataBind();

        //WITNESS DETAILS
        this.grdWitness.DataSource = "";
        this.grdWitness.DataBind();

        //EVIDENCE DETAILS
        this.grdEvidence.DataSource = "";
        this.grdEvidence.DataBind();

        //DOCUMENTS DETAILS
        this.grdLitDocument.DataSource = "";
        this.grdLitDocument.DataBind();

        //CASE SUMMARY
        this.litCaseSummary.Text = "";

        this.ddlVerify.SelectedValue = "0";
        this.txtVerifiedDate.Text = "";
        this.txtDarpit.Text = "";


        pnlCaseInfo.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(true);
    }
    protected void grdCheckList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void grdAccountFWD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
}
