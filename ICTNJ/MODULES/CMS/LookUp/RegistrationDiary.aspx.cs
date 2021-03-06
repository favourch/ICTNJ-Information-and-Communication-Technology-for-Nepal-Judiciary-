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
using System.Collections.Generic;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_LookUp_RegistrationDiary : System.Web.UI.Page
{
    string entryBy = "shyam";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCases();
        }
    }

    void LoadCases()
    {
        try
        {
            List<ATTCaseType> CaseTypeList = BLLCaseType.GetCaseType(null, "Y",1);
            Session["CaseType"] = CaseTypeList;

            DDLCaseType_RQD.DataSource = CaseTypeList;
            DDLCaseType_RQD.DataTextField = "CaseTypeName";
            DDLCaseType_RQD.DataValueField = "CaseTypeID";
            DDLCaseType_RQD.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private void CloneCaseType()
    {
         Session["CloneOrganisations"]= new List<ATTRegistrationDiary>();
        
    }

    void ClearControls(int RegistrationDiary, int RegistrationDiarySubject, int RegistrationDiaryName, bool ListCaseType)
    {        
        if (RegistrationDiary == 1 || RegistrationDiary == 3)
        {
            txtRegistrationDiaryName.Text = "";
            txtRegistrationDiaryCode.Text = "";
            chkRegistration.Checked = true;
        }
        if (RegistrationDiary == 2 || RegistrationDiary == 3)
        {
            grdRegistrationDiary.DataSource = null;
            grdRegistrationDiary.DataBind();
            grdRegistrationDiary.SelectedIndex = -1;
        }

        if (RegistrationDiarySubject == 1 || RegistrationDiarySubject == 3)
        {
            txtCaseSubject.Text = "";
            chkSubject.Checked = true;
        }
        if (RegistrationDiarySubject == 2 || RegistrationDiarySubject == 3)
        {
            grdCaseSubject.DataSource = null;
            grdCaseSubject.DataBind();
            grdCaseSubject.SelectedIndex = -1;
        }

        if (RegistrationDiaryName == 1 || RegistrationDiaryName == 3)
        {
            txtCaseName.Text = "";
            txtCaseNameDescription.Text = "";
            chkName.Checked = true;
        }
        if (RegistrationDiaryName == 2 || RegistrationDiaryName == 3)
        {
            grdCaseName.DataSource = null;
            grdCaseName.DataBind();
            grdCaseName.SelectedIndex = -1;
        }
        if (ListCaseType)
        {
            CloneCaseType();
        }
       
    }

    protected void grdRegistrationDiary_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        txtRegistrationDiaryName.Text = grdRegistrationDiary.Rows[e.NewSelectedIndex].Cells[2].Text;
        txtRegistrationDiaryCode.Text = grdRegistrationDiary.Rows[e.NewSelectedIndex].Cells[3].Text;
        chkRegistration.Checked = (grdRegistrationDiary.Rows[e.NewSelectedIndex].Cells[5].Text == "Y") ? true : false;

        List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];

        if (grdRegistrationDiary.Rows[e.NewSelectedIndex].Cells[4].Text == "" || grdRegistrationDiary.Rows[e.NewSelectedIndex].Cells[4].Text == "&nbsp;")
            listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[e.NewSelectedIndex].Action = "E";

            grdCaseSubject.DataSource = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[e.NewSelectedIndex].RegistrationDiarySubjectLIST;
            grdCaseSubject.DataBind();
            grdCaseSubject.SelectedIndex = -1;
      
        Session["CloneOrganisations"] = listOrgCaseType;

        ClearControls(0, 1, 3, false);
    }

    protected void btnAddRegistrationDiary_Click(object sender, EventArgs e)
    {
        if (DDLCaseType_RQD.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Case Type First</br>";
            this.programmaticModalPopup.Show();
            return;
        }
        if (grdOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Organization First</br>";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtRegistrationDiaryName.Text.Trim() == "")
        {
            lblStatusMessage.Text = "दर्ता किताब छुट्यो </br>";
            this.programmaticModalPopup.Show();
            return;
        }
        try 
        {
            List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
            List<ATTRegistrationDiary> regDiaryLST = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary;
           
            if (grdRegistrationDiary.SelectedIndex == -1)
            {
                ATTRegistrationDiary regDiary = new ATTRegistrationDiary();

                regDiary.OrgID = int.Parse(grdOrganization.SelectedRow.Cells[1].Text);
                regDiary.CaseTypeID=int.Parse(DDLCaseType_RQD.SelectedValue);
                regDiary.RegistrationDiaryName = txtRegistrationDiaryName.Text.Trim();
                regDiary.RegistrationDiaryCode = txtRegistrationDiaryCode.Text.Trim();
                regDiary.Active = (chkRegistration.Checked) ? "Y" : "N";
                regDiary.Action = "A";
                regDiary.EntryBy = entryBy;

                regDiaryLST.Add(regDiary);
            }
            else
            {
                regDiaryLST[grdRegistrationDiary.SelectedIndex].RegistrationDiaryName = txtRegistrationDiaryName.Text.Trim();
                regDiaryLST[grdRegistrationDiary.SelectedIndex].RegistrationDiaryCode = txtRegistrationDiaryCode.Text.Trim();
                regDiaryLST[grdRegistrationDiary.SelectedIndex].Active = (chkRegistration.Checked) ? "Y" : "N";
                regDiaryLST[grdRegistrationDiary.SelectedIndex].Action = (grdRegistrationDiary.Rows[grdRegistrationDiary.SelectedIndex].Cells[4].Text == "A") ? "A" : "E";
                regDiaryLST[grdRegistrationDiary.SelectedIndex].EntryBy = entryBy;
            }
            Session["CloneOrganisations"] = listOrgCaseType;

            grdRegistrationDiary.DataSource = regDiaryLST;
            grdRegistrationDiary.DataBind();
            this.grdRegistrationDiary.SelectedIndex = -1;

            ClearControls(1, 3, 3, false);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "दर्ता किताब Can't be Added To Grid<BR>" + ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdRegistrationDiary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[1].Visible=false;
        e.Row.Cells[4].Visible=false;

    }

    protected void grdCaseSubject_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        txtCaseSubject.Text = this.grdCaseSubject.Rows[e.NewSelectedIndex].Cells[3].Text;
        chkSubject.Checked = (this.grdCaseSubject.Rows[e.NewSelectedIndex].Cells[5].Text == "Y") ? true : false;

        List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
        if (this.grdCaseSubject.Rows[e.NewSelectedIndex].Cells[4].Text == "" || this.grdCaseSubject.Rows[e.NewSelectedIndex].Cells[4].Text == "&nbsp;")
            listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[grdRegistrationDiary.SelectedIndex].RegistrationDiarySubjectLIST[e.NewSelectedIndex].Action = "E";

        grdCaseName.DataSource = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[grdRegistrationDiary.SelectedIndex].RegistrationDiarySubjectLIST[e.NewSelectedIndex].RegistrationDiaryNameLIST;
        grdCaseName.DataBind();
        grdCaseName.SelectedIndex = -1;

        Session["CloneOrganisations"] = listOrgCaseType;

        ClearControls(0, 0, 1, false);
    }

    protected void btnAddCaseSubject_Click(object sender, EventArgs e)
    {
        if (DDLCaseType_RQD.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Case Type First</br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Organization First </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtCaseSubject.Text.Trim() == "")
        {
            lblStatusMessage.Text = "मुद्दाको बिषय छुट्यो </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdRegistrationDiary.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Registration Diary First </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
        List<ATTRegistrationDiarySubject> regDiarySubLST = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[grdRegistrationDiary.SelectedIndex].RegistrationDiarySubjectLIST;

        try
        {
            if (grdCaseSubject.SelectedIndex == -1)
            {
                ATTRegistrationDiarySubject regDiarySubject = new ATTRegistrationDiarySubject();

                regDiarySubject.OrgID = int.Parse(grdOrganization.SelectedRow.Cells[1].Text);
                regDiarySubject.CaseTypeID = int.Parse(DDLCaseType_RQD.SelectedValue);

                regDiarySubject.SubjectName = txtCaseSubject.Text.Trim();
                regDiarySubject.Active = (chkSubject.Checked == true) ? "Y" : "N";
                regDiarySubject.Action = "A";
                regDiarySubject.EntryBy = entryBy;

                regDiarySubLST.Add(regDiarySubject);
            }
            else
            {
                regDiarySubLST[grdCaseSubject.SelectedIndex].SubjectName = this.txtCaseSubject.Text;
                regDiarySubLST[grdCaseSubject.SelectedIndex].Active = (chkSubject.Checked == true) ? "Y" : "N"; ;
                regDiarySubLST[grdCaseSubject.SelectedIndex].Action = (this.grdCaseSubject.SelectedRow.Cells[5].Text == "A") ? "A" : "E";
                regDiarySubLST[grdCaseSubject.SelectedIndex].EntryBy = entryBy;
            }
            grdCaseSubject.DataSource = regDiarySubLST;
            grdCaseSubject.DataBind();
            grdCaseSubject.SelectedIndex = -1;

            Session["CloneOrganisations"] = listOrgCaseType;

            grdCaseName.DataSource = "";
            grdCaseName.DataBind();
            grdCaseName.SelectedIndex = -1;

            ClearControls(0, 1, 1, false);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "मुद्दाको नाम Can't Be Added To Grid<BR>" + ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdCaseSubject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
    }

    protected void grdCaseName_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
        if (this.grdCaseName.Rows[e.NewSelectedIndex].Cells[6].Text == "" || this.grdCaseName.Rows[e.NewSelectedIndex].Cells[6].Text == "&nbsp;")
            listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary[grdRegistrationDiary.SelectedIndex].RegistrationDiarySubjectLIST[grdCaseSubject.SelectedIndex].RegistrationDiaryNameLIST[e.NewSelectedIndex].Action = "E";

        txtCaseName.Text = grdCaseName.Rows[e.NewSelectedIndex].Cells[4].Text;
        txtCaseNameDescription.Text = grdCaseName.Rows[e.NewSelectedIndex].Cells[5].Text;
        Session["CloneOrganisations"] = listOrgCaseType;
    }

    protected void btnAddCaseName_Click(object sender, EventArgs e)
    {
        if (DDLCaseType_RQD.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Case Type First</br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdOrganization.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Organization First</br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdRegistrationDiary.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Registration Diary First </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdCaseSubject.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Registration Diary Subject First </br>";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtCaseName.Text.Trim() == "")
        {
            lblStatusMessage.Text = "मुद्दाको नाम छुट्यो ";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
        List<ATTRegistrationDiary> regDiaryLST = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary;
        List<ATTRegistrationDiaryName> regDiaryNameLST = regDiaryLST[grdRegistrationDiary.SelectedIndex].RegistrationDiarySubjectLIST[grdCaseSubject.SelectedIndex].RegistrationDiaryNameLIST;

        try
        {
            if (grdCaseName.SelectedIndex == -1)
            {
                ATTRegistrationDiaryName regDiaryName = new ATTRegistrationDiaryName();

                regDiaryName.OrgID = int.Parse(grdOrganization.SelectedRow.Cells[1].Text);
                regDiaryName.CaseTypeID = int.Parse(DDLCaseType_RQD.SelectedValue);
                regDiaryName.RegistrationDiaryName = txtCaseName.Text.Trim();
                regDiaryName.RegistrationDiaryNameDescription = txtCaseNameDescription.Text.Trim();
                regDiaryName.Active = (chkName.Checked == true) ? "Y" : "N";
                regDiaryName.Action = "A";
                regDiaryName.EntryBy = entryBy;

                regDiaryNameLST.Add(regDiaryName);
            }
            else
            {
                regDiaryNameLST[grdCaseName.SelectedIndex].RegistrationDiaryName = txtCaseName.Text.Trim();
                regDiaryNameLST[grdCaseName.SelectedIndex].RegistrationDiaryNameDescription = txtCaseNameDescription.Text.Trim();
                regDiaryNameLST[grdCaseName.SelectedIndex].Active = (chkName.Checked == true) ? "Y" : "N"; ;
                regDiaryNameLST[grdCaseName.SelectedIndex].Action = (grdCaseName.SelectedRow.Cells[6].Text == "A") ? "A" : "E";
                regDiaryNameLST[grdCaseName.SelectedIndex].EntryBy = entryBy;
            }
            grdCaseName.DataSource = regDiaryNameLST;
            grdCaseName.DataBind();

            Session["CloneOrganisations"] = listOrgCaseType;
            grdCaseName.SelectedIndex = -1;
            ClearControls(0, 0, 1, false);
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "मुद्दाको नाम  can't Be Added To Grid " + ex.Message.ToString();
            programmaticModalPopup.Show();
        }
    }

    protected void grdCaseName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[6].Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTOrganizationCaseType> listOrgCaseType = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
            List<ATTRegistrationDiary> regDiaryLST = listOrgCaseType[grdOrganization.SelectedIndex].LstRegistrationDiary;

            if (BLLRegistrationDiary.AddEditDeleteRegistrationDiary(regDiaryLST))
            {
                LoadCases();
                ClearControls(3, 3, 3, true);
                this.lblStatusMessage.Text = "Saved Successfully";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        ClearControls(3, 3, 3, true);
        grdOrganization.DataSource = null;
        grdOrganization.DataBind();
        DDLCaseType_RQD.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(3, 3, 3, true);
        lblStatusMessage.Text = "Operation Cancelled </br>";
        this.programmaticModalPopup.Show();
        grdOrganization.DataSource = null;
        grdOrganization.DataBind();
        DDLCaseType_RQD.SelectedIndex = 0;

        CloneCaseType();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void DDLCaseType_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTCaseType> CaseTypeLst = (List<ATTCaseType>)Session["CaseType"];

        List<ATTOrganizationCaseType> lstOrg = CaseTypeLst[DDLCaseType_RQD.SelectedIndex].OrganisationCaseTypesLIST;

        Session["Organisations"] = lstOrg;

        List<ATTOrganizationCaseType> lstOrgClone=new List<ATTOrganizationCaseType>();

        foreach (ATTOrganizationCaseType orgCaseType in lstOrg)
        {
            lstOrgClone.Add((ATTOrganizationCaseType)orgCaseType.Clone());
        }
        Session["CloneOrganisations"] = lstOrgClone;
        
        grdOrganization.DataSource = lstOrg;
        grdOrganization.DataBind();
        grdOrganization.SelectedIndex = -1;
    }

    protected void grdOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTOrganizationCaseType> orgCaseTypeLst = (List<ATTOrganizationCaseType>)Session["CloneOrganisations"];
        ATTOrganizationCaseType organisation = orgCaseTypeLst[grdOrganization.SelectedIndex];
       
        txtRegistrationDiaryName.Text = "";
        txtRegistrationDiaryCode.Text = "";

        grdRegistrationDiary.DataSource = organisation.LstRegistrationDiary;
        grdRegistrationDiary.DataBind();
        grdRegistrationDiary.SelectedIndex = -1;

        txtCaseSubject.Text = "";
        chkSubject.Checked = true;

        grdCaseSubject.DataSource = null ;
        grdCaseSubject.DataBind();
        grdCaseSubject.SelectedIndex = -1;

        txtCaseName.Text = "";
        txtCaseNameDescription.Text = "";
        chkName.Checked = true;

        grdCaseName.DataSource = null;
        grdCaseName.DataBind();
        grdCaseName.SelectedIndex = -1;
    }

    protected void grdOrganization_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
