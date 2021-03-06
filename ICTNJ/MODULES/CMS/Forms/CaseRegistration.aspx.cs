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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;


using PCS.FRAMEWORK;

using PCS.PMS.ATT;
using PCS.PMS.BLL;

using PCS.CMS.BLL;
using PCS.CMS.ATT;

using PCS.SECURITY.ATT;


public partial class MODULES_CMS_Forms_CaseRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("1,19,1") == true)
        {
            if (this.Page.IsPostBack == false)
            {
                Session["Appellant"] = new List<ATTLitigants>();
                Session["Respondant"] = new List<ATTLitigants>();
                Session["PersonDocuments"] = new List<ATTPersonDocuments>();
                Session["AccountFWD"] = new List<ATTCaseAccountForward>(); 
                //LoadRegisteredOrganization();
                LoadCaseType();
                LoadDistricts();
                LoadRelationTypes();
                LoadLitigantSubType();
                LoadCaseProceeding();
                LoadReligion();
                LoadDocumentTypes();
                LoadAccountType();
                LoadCountry();
                Session["WritSubjects"] = BLLWritSubject.GetWritSubjectDetailsLST(null, "Y", true, true, true, true);
        

                SetPhoneTable();
                SetEMailTable();
                SetRelativesTable();

                pnlPrisonDetails.Enabled = false;
                //chkActivePersonDoc.Checked = true;

                if (Session["CaseNo"] != null)
                {
                    this.txtCaseNo.Text = Session["CaseNo"].ToString();
                    Session["CaseNo"] = null;
                    LoadCaseRegistration(double.Parse(txtCaseNo.Text), sender, e);
                }
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    public void LoadCaseRegistration(double caseNo,object sender, EventArgs e)
    {
        try
        {
            ATTCaseRegistration objCR = ((List<ATTCaseRegistration>)BLLCaseRegistration.GetCaseRegistration(caseNo, 1, 1, 1, 1, 0, 0, 0, 0, 0, "Y"))[0];
            this.ddlCaseType_RQD.SelectedValue = objCR.CaseTypeID.ToString();
            this.ddlCaseType_RQD_SelectedIndexChanged(sender, e);
            this.ddlOrgCaseRegType_RQD.SelectedValue = objCR.RegTypeID.ToString();
            this.ddlOrgCaseRegType_RQD_SelectedIndexChanged(sender, e);

            this.ddlRegistrationDiary_RQD.SelectedValue = objCR.RegDiaryID.ToString();

            this.ddlRegistrationDiary_RQD_SelectedIndexChanged(sender, e);

            this.ddlRegDiarySubject_RQD.SelectedValue = objCR.RegSubjectID.ToString();

            this.ddlRegDiarySubject_RQD_SelectedIndexChanged(sender, e);

            this.ddlRegDiaryName_RQD.SelectedValue = objCR.RegDiaryNameID.ToString();
            this.txtCaseRegistrationDate_DT.Text = objCR.CaseRegistrationDate;
            this.ddlCaseProceeding_RQD.SelectedValue = objCR.ProceedingID.ToString();
            this.chkForwardToAccount.Checked = objCR.AccountForwarded == "Y" ? true : false;
            this.chkForwardToAccount_CheckedChanged(sender, e);

            this.ddlWritSubject.SelectedValue = objCR.WritSubjectID.ToString();
            this.ddlWritCategory.SelectedValue = objCR.WritCatID.ToString();
            this.ddlWritTitle.SelectedValue = objCR.WirtCatTitleID.ToString();
            this.ddlWritSubTitle.SelectedValue = objCR.WritCatSubTitleID.ToString();

            Session["AccountFWD"] = objCR.CaseAccountForwardLST;
            this.grdAccountFWD.DataSource = objCR.CaseAccountForwardLST;
            this.grdAccountFWD.DataBind();

            Session["Appellant"] = objCR.AppellantLST;
            Session["Respondant"] = objCR.RespondantLST;

            this.grdAppellant.DataSource = objCR.AppellantLST;
            this.grdAppellant.DataBind();

            this.grdRespondant.DataSource = objCR.RespondantLST;
            this.grdRespondant.DataBind();

            int i;
            foreach (GridViewRow gvRow in this.grdCheckList.Rows)
            {
                i = objCR.CaseCheckListLST.FindIndex(delegate(ATTCaseCheckList obj)
                                                        {
                                                            return obj.CheckListID == int.Parse(gvRow.Cells[1].Text) && obj.FulFilled == "Y";
                                                        });
                if (i > -1)
                {
                    ((CheckBox)gvRow.FindControl("chkSelect")).Checked = true;
                    ((TextBox)gvRow.FindControl("txtCLRemarks")).Text = objCR.CaseCheckListLST[i].Remarks;
                }
                else
                {
                    ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
                }
                //i = objCR.CaseCheckListLST.FindIndex(delegate(ATTCaseCheckList obj)
                //                                        {
                //                                            return obj.CheckListID == int.Parse(gvRow.Cells[1].Text);
                //                                        });

                //((TextBox)gvRow.FindControl("txtCLRemarks")).Text = objCR.CaseCheckListLST[i].Remarks;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region "SET GRID TABLES"
    void SetPhoneTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PID");
        DataColumn dtCol1 = new DataColumn("PTYPE");
        DataColumn dtCol2 = new DataColumn("PHONETYPE");
        DataColumn dtCol3 = new DataColumn("PSNO");
        DataColumn dtCol4 = new DataColumn("PHONE");
        DataColumn dtCol5 = new DataColumn("ACTIVE");
        DataColumn dtCol6 = new DataColumn("REMARKS");
        DataColumn dtCol7 = new DataColumn("ACTION");

        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);
        tbl.Columns.Add(dtCol6);
        tbl.Columns.Add(dtCol7);

        Session["PersonPhoneTbl"] = tbl;
        Session["OrgPhoneTbl"] = tbl;
    }

    void SetEMailTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PID");
        DataColumn dtCol1 = new DataColumn("ETYPE");
        DataColumn dtCol2 = new DataColumn("EMAILTYPE");
        DataColumn dtCol3 = new DataColumn("ESNO");
        DataColumn dtCol4 = new DataColumn("EMAIL");
        DataColumn dtCol5 = new DataColumn("ACTIVE");
        DataColumn dtCol6 = new DataColumn("REMARKS");
        DataColumn dtCol7 = new DataColumn("ACTION");


        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);
        tbl.Columns.Add(dtCol6);
        tbl.Columns.Add(dtCol7);

        Session["PersonEMailTbl"] = tbl;
        Session["OrgEMailTbl"] = tbl;
    }

    void SetRelativesTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PID");
        DataColumn dtCol1 = new DataColumn("RELATIVEID");
        DataColumn dtCol2 = new DataColumn("FIRSTNAME");
        DataColumn dtCol3 = new DataColumn("MIDNAME");
        DataColumn dtCol4 = new DataColumn("SURNAME");
        DataColumn dtCol5 = new DataColumn("RDFULLNAME");
        DataColumn dtCol6 = new DataColumn("GENDER");
        DataColumn dtCol7 = new DataColumn("RDGENDER");
        DataColumn dtCol8 = new DataColumn("DOB");
        DataColumn dtCol9 = new DataColumn("MARITALSTATUS");
        DataColumn dtCol10 = new DataColumn("RDMARITALSTATUS");
        DataColumn dtCol11 = new DataColumn("BIRTHDISTRICT");
        DataColumn dtCol12 = new DataColumn("NEPDISTNAME");
        DataColumn dtCol13 = new DataColumn("RELATIONTYPEID");
        DataColumn dtCol14 = new DataColumn("RELATIONTYPENAME");
        DataColumn dtCol15 = new DataColumn("OCCUPATION");
        DataColumn dtCol16 = new DataColumn("ISACTIVE");
        DataColumn dtCol17 = new DataColumn("ACTION");
        
        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);
        tbl.Columns.Add(dtCol6);
        tbl.Columns.Add(dtCol7);
        tbl.Columns.Add(dtCol8);
        tbl.Columns.Add(dtCol9);
        tbl.Columns.Add(dtCol10);
        tbl.Columns.Add(dtCol11);
        tbl.Columns.Add(dtCol12);
        tbl.Columns.Add(dtCol13);
        tbl.Columns.Add(dtCol14);
        tbl.Columns.Add(dtCol15);
        tbl.Columns.Add(dtCol16);
        tbl.Columns.Add(dtCol17);
        
        Session["RelativesTbl"] = tbl;

    }

    #endregion

    void LoadReligion()
    {
        this.ddlReligion.DataSource = BLLReligion.GetReligions(null, 0);
        this.ddlReligion.DataTextField = "ReligionNepName";
        this.ddlReligion.DataValueField = "ReligionId";
        this.DataBind();
    }

    void LoadCountry()
    {
        this.ddlCountry.DataSource = BLLCountry.GetCountries(null, 0);
        this.ddlCountry.DataTextField = "CountryNepName";
        this.ddlCountry.DataValueField = "CountryId";
        this.DataBind();
    }

    void LoadDocumentTypes()
    {
        List<ATTDocumentsType> PersonDocLST=BLLDocumentsType.GetDocumentsType(null, true);
        this.ddlDocumentType.DataSource = PersonDocLST;
        this.ddlDocumentType.DataTextField = "DocTypeName";
        this.ddlDocumentType.DataValueField = "DocTypeID";
        this.ddlDocumentType.DataBind();

        this.ddlSrcDocumentType.DataSource = PersonDocLST;
        this.ddlSrcDocumentType.DataTextField = "DocTypeName";
        this.ddlSrcDocumentType.DataValueField = "DocTypeID";
        this.ddlSrcDocumentType.DataBind();

    }

    void LoadRelationTypes()
    {
        Session["RelationType"] = BLLRelationType.GetRelationTypes(null, 1);
        this.ddlRelationType_Relative.DataSource = (List<ATTRelationType>)Session["RelationType"];
        this.ddlRelationType_Relative.DataTextField = "RelationTypeName";
        this.ddlRelationType_Relative.DataValueField = "RelationTypeID";
        this.DataBind();
    }
    void LoadCaseProceeding()
    {
        try
        {
            this.ddlCaseProceeding_RQD.DataSource = BLLCaseProceeding.GetCaseProceeding(null, "Y", 1);
            this.ddlCaseProceeding_RQD.DataTextField = "CaseProceedingName";
            this.ddlCaseProceeding_RQD.DataValueField = "CaseProceedingID";
            this.ddlCaseProceeding_RQD.DataBind();

        }
        catch (Exception ex)
        {
            
            this.lblStatusMessage.Text="Error In Loading Case Proceeding"+ex.ToString() ;
            this.programmaticModalPopup.Show();
           
        }
    }

    void LoadLitigantSubType()
    {
        try
        {
            this.ddlLitigantSubType.DataSource = BLLLitigantSubType.GetLitigantSubType(null, "Y",1);
            this.ddlLitigantSubType.DataTextField = "LitigantSubTypeName";
            this.ddlLitigantSubType.DataValueField = "LitigantSubTypeID";
            this.ddlLitigantSubType.DataBind();
        }
        catch (Exception)
        {
            this.lblStatusMessage.Text = "Error In Loading Litigant Sub Type";
            this.programmaticModalPopup.Show();
        }
    }

    void LoadAccountType()
    {
        this.ddlAccountType.DataSource = BLLAccountType.GetAccountType(null, "Y", 1);
        this.ddlAccountType.DataTextField = "AccountTypeName";
        this.ddlAccountType.DataValueField = "AccountTypeID";
        this.ddlAccountType.DataBind();
    }

    void LoadDistricts()
    {
        try
        {
            List<ATTDistrict> lstDistricts;
            lstDistricts = BLLDistrict.GetDistrictList(null);
            lstDistricts.Insert(0, new ATTDistrict(0, "छान्नुहोस", "Select District", 0));
            this.ddlBirthDistrict.DataSource = lstDistricts;
            this.ddlBirthDistrict.DataTextField = "NepDistName";
            this.ddlBirthDistrict.DataValueField = "DistCode";
            this.ddlBirthDistrict.SelectedIndex = 0;
            this.ddlBirthDistrict.DataBind();



            this.ddlDistrict.DataSource = lstDistricts;
            this.ddlDistrict.DataTextField = "NepDistName";
            this.ddlDistrict.DataValueField = "DistCode";
            this.ddlDistrict.SelectedIndex = 0;
            this.ddlDistrict.DataBind();

            this.ddlDistrictTemp.DataSource = lstDistricts;
            this.ddlDistrictTemp.DataTextField = "NepDistName";
            this.ddlDistrictTemp.DataValueField = "DistCode";
            this.ddlDistrictTemp.SelectedIndex = 0;
            this.ddlDistrictTemp.DataBind();

            this.ddlRelationHomeDistrict.DataSource = lstDistricts;
            this.ddlRelationHomeDistrict.DataTextField = "NepDistName";
            this.ddlRelationHomeDistrict.DataValueField = "DistCode";
            this.ddlRelationHomeDistrict.SelectedIndex = 0;
            this.ddlRelationHomeDistrict.DataBind();

            this.ddlOrgDistrict.DataSource = lstDistricts;
            this.ddlOrgDistrict.DataTextField = "NepDistName";
            this.ddlOrgDistrict.DataValueField = "DistCode";
            this.ddlOrgDistrict.SelectedIndex = 0;
            this.ddlOrgDistrict.DataBind();

            this.ddlIssuedFrom.DataSource = lstDistricts;
            this.ddlIssuedFrom.DataTextField = "NepDistName";
            this.ddlIssuedFrom.DataValueField = "DistCode";
            this.ddlIssuedFrom.SelectedIndex = 0;
            this.ddlIssuedFrom.DataBind();

            this.ddlSrcBirthDistrict.DataSource = lstDistricts;
            this.ddlSrcBirthDistrict.DataTextField = "NepDistName";
            this.ddlSrcBirthDistrict.DataValueField = "DistCode";
            this.ddlSrcBirthDistrict.SelectedIndex = 0;
            this.ddlSrcBirthDistrict.DataBind();




        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCaseType()
    {
        Session["OrgCaseType"] = BLLOrganizationCaseType.GetOrgCaseType(((ATTUserLogin)Session["Login_User_Detail"]).OrgID, null, "Y", 1, 1, 1, 1);
        this.ddlCaseType_RQD.DataSource = (List<ATTOrganizationCaseType>)Session["OrgCaseType"];
        this.ddlCaseType_RQD.DataValueField = "CaseTypeID";
        this.ddlCaseType_RQD.DataTextField = "CaseTypeName";
        this.ddlCaseType_RQD.DataBind();
    }


    
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        ClearContros(sender,e,false);
    }

    protected void ClearContros(object sender,EventArgs e, bool clearAllControls)
    {
        if (clearAllControls == true)
        {
            this.ddlOrgOrPerson.SelectedIndex = -1;
            this.ddlAppOrResp.SelectedIndex = -1;

        }

        //Personnel Info Controls
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.txtPersonID.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedValue = "SG";
        this.ddlMarStatus.SelectedValue = "SMS";
        //this.ddlCountry.SelectedValue = "SC";
        this.ddlBirthDistrict.SelectedValue = "0";
        this.ddlReligion.SelectedValue = "0";
        this.txtIdentityMark.Text = "";
        this.txtDisplayName.Text = "";
        this.ddlLitigantSubType.SelectedValue = "0";

        this.ddlDistrict.SelectedValue = "0";
        this.ddlDistrict_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtTole.Text = "";
        this.txtPerAdd.Text = "";


        this.ddlDistrictTemp.SelectedValue = "0";
        this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtToleTemp.Text = "";
        this.txttempAdd.Text = "";

        this.ddlPhoneType_Phone.SelectedValue = "N";
        this.txtPhoneNumber_Phone.Text = "";
        this.grdPhone.DataSource = "";
        this.grdPhone.DataBind();
        this.grdPhone.SelectedIndex = -1;

        this.ddlEMailType_EMail.SelectedValue = "N";
        this.txtEMail_EMail.Text = "";
        this.grdEMail.DataSource = "";
        this.grdEMail.DataBind();
        this.grdEMail.SelectedIndex = -1;

        //Organzation Info Controls
        this.txtOrgName_RQD.Text = "";
        this.txtOrgID.Text = "";
        this.txtRegNo.Text = "";
        this.txtPanNo.Text = "";
        //this.ddlOrgType.SelectedValue

        this.ddlOrgDistrict.SelectedValue = "0";
        this.ddlOrgDistrict_SelectedIndexChanged(sender, e);
        this.ddlOrgVDC_SelectedIndexChanged(sender, e);
        this.txtOrgTole.Text = "";

        this.ddlOrgPhoneType_Phone.SelectedValue = "N";
        this.txtOrgPhoneNumber_Phone.Text = "";
        this.grdOrgPhone.DataSource = "";
        this.grdOrgPhone.DataBind();
        this.grdOrgPhone.SelectedIndex = -1;

        this.ddlOrgEMailType_EMail.SelectedValue = "N";
        this.txtOrgEMail_EMail.Text = "";
        this.grdOrgEMail.DataSource = "";
        this.grdOrgEMail.DataBind();
        this.grdOrgEMail.SelectedIndex = -1;


        PnlPersonSearch.Visible = false;
        pnlOrgSearch.Visible = false;
        this.ddlGender.SelectedValue = "SG";
        this.ddlMarStatus.SelectedValue = "SMS";


        //Relative's Controls
        this.grdRelatives.DataSource = "";
        this.grdRelatives.DataBind();

        //Prison Detail's Controls
        this.chkIsPrisoned.Checked = false;
        this.txtPrisonedFromDate.Text = "";
        this.txtPrisonedToDate.Text = "";
        this.txtPrisonDescription.Text = "";

        SetPhoneTable();
        SetEMailTable();
        SetRelativesTable();

        //LITIGANT'S GRID
        this.grdAppellant.SelectedIndex = -1;
        this.grdRespondant.SelectedIndex = -1;

        //CheckList Controls
        foreach (GridViewRow gvRow in this.grdCheckList.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
            ((TextBox)gvRow.FindControl("txtCLRemarks")).Text = "";
        }



    }


    


    //protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    //{

    //}
    protected void rdlPersonOrOrg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //if (rdlAppOrResp.SelectedIndex == -1)
        //{
        //    this.lblStatusMessage.Text = "Please Either Select an Appellant or Respondant.";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //if (rdlPersonOrOrg.SelectedIndex == -1)
        //{
        //    this.lblStatusMessage.Text = "Please Either Select a Person or Organization.";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //Session["AppOrResp"] = this.rdlAppOrResp.SelectedValue;


        //this.colEmployee.Collapsed = true;
        //this.colEmployee.ClientState = "true";

        //this.colPnlApplOrResp.Collapsed = false;
        //his.colPnlApplOrResp.ClientState = "false";


        //string script = "";
        //if (rdlPersonOrOrg.SelectedValue == "P")
        //{
        //    script += "<script language='javascript' type='text/javascript'>";
        //    script += "var win=window.open('PersonnelInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        //    script += "</script>";
        //}
        //else if (rdlPersonOrOrg.SelectedValue == "O")
        //{
        //    script += "<script language='javascript' type='text/javascript'>";
        //    script += "var win=window.open('OrganizationInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        //    script += "</script>";
        //}

        //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

    }
    protected void btnSearchAR_Click(object sender, EventArgs e)
    {
        if (this.ddlAppOrResp.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Either Select an Appellant or Respondant.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlOrgOrPerson.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Either Select a Person or Organization.";
            this.programmaticModalPopup.Show();
            return;
        }

        //this.colEmployee.Collapsed = false;
        //this.colEmployee.ClientState = "false";
    }
    protected void ddlCaseType_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlWritSubject.Items.Clear();
        this.ddlWritCategory.Items.Clear();
        this.ddlWritTitle.Items.Clear();
        this.ddlWritSubTitle.Items.Clear();

        this.pnlWrit.Visible = false;

        List<ATTOrganizationCaseType> OrgCaseTypeLST = (List<ATTOrganizationCaseType>)Session["OrgCaseType"];
        this.ddlRegistrationDiary_RQD.DataSource = OrgCaseTypeLST[this.ddlCaseType_RQD.SelectedIndex].LstRegistrationDiary;
        this.ddlRegistrationDiary_RQD.DataValueField = "RegistrationDiaryID";
        this.ddlRegistrationDiary_RQD.DataTextField = "RegistrationDiaryName";
        this.ddlRegistrationDiary_RQD.DataBind();

        this.ddlOrgCaseRegType_RQD.DataSource = OrgCaseTypeLST[this.ddlCaseType_RQD.SelectedIndex].OrgCaseRegistrationTypeLST;
        this.ddlOrgCaseRegType_RQD.DataValueField = "RegTypeID";
        this.ddlOrgCaseRegType_RQD.DataTextField = "RegTypeName";
        this.ddlOrgCaseRegType_RQD.DataBind();

        if (this.ddlCaseType_RQD.SelectedValue == "3")
        {
            pnlWrit.Visible = true;
            LoadWritDetails();
        }

    }
    protected void ddlRegistrationDiary_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTOrganizationCaseType> OrgCaseTypeLST = (List<ATTOrganizationCaseType>)Session["OrgCaseType"];
        this.ddlRegDiarySubject_RQD.DataSource = OrgCaseTypeLST[this.ddlCaseType_RQD.SelectedIndex].LstRegistrationDiary[this.ddlRegistrationDiary_RQD.SelectedIndex].RegistrationDiarySubjectLIST;
        this.ddlRegDiarySubject_RQD.DataValueField = "SubjectID";
        this.ddlRegDiarySubject_RQD.DataTextField = "SubjectName";
        this.ddlRegDiarySubject_RQD.DataBind();
    }
    protected void ddlRegDiarySubject_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTOrganizationCaseType> OrgCaseTypeLST = (List<ATTOrganizationCaseType>)Session["OrgCaseType"];
        this.ddlRegDiaryName_RQD.DataSource = OrgCaseTypeLST[this.ddlCaseType_RQD.SelectedIndex].LstRegistrationDiary[this.ddlRegistrationDiary_RQD.SelectedIndex].RegistrationDiarySubjectLIST[this.ddlRegDiarySubject_RQD.SelectedIndex].RegistrationDiaryNameLIST;
        this.ddlRegDiaryName_RQD.DataValueField = "RegistrationDiaryNameID";
        this.ddlRegDiaryName_RQD.DataTextField = "RegistrationDiaryName";
        this.ddlRegDiaryName_RQD.DataBind();
    }
    protected void btnAddAR_Click(object sender, EventArgs e)
    {
        if (this.ddlAppOrResp.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Select Either Appellant or Respondant";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.ddlOrgOrPerson.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Select Either Person or Organization";
            this.programmaticModalPopup.Show();
            return;
        }

        //if (this.grdEmployee.SelectedIndex == -1)
        //{
        //    this.lblStatusMessage.Text = "Please Select Either Person or Organization from Grid";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //List<ATTPerson> AppellantLST = (List<ATTPerson>)Session["Appellant"];
        //List<ATTPerson> RespondantLST = (List<ATTPerson>)Session["Respondant"];

        //if (AppellantLST.FindIndex(delegate(ATTPerson obj)
        //                        {
        //                            return obj.PId == double.Parse(grdEmployee.SelectedRow.Cells[0].Text);
        //                        }) > -1)
        //{
        //    this.lblStatusMessage.Text = this.ddlAppOrResp.SelectedValue == "A" ? "Appellant Already Exits" : "Already Exists as Applicant.<BR> Can't Be Both Appellant and Respondant";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}


        //if (RespondantLST.FindIndex(delegate(ATTPerson obj)
        //                        {
        //                            return obj.PId == double.Parse(grdEmployee.SelectedRow.Cells[0].Text);
        //                        }) > -1)
        //{
        //    this.lblStatusMessage.Text = this.ddlAppOrResp.SelectedValue == "R" ? "Respondant Already Exists" : "Already Exists as Respondant. <BR> Same Person Can't Be Appellant as Well as Respondant";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}



        //if (this.ddlAppOrResp.SelectedValue == "A")
        //{
        //    ATTPerson objPerson = new ATTPerson();
        //    objPerson.PId = double.Parse(grdEmployee.SelectedRow.Cells[0].Text);
        //    objPerson.FullName = grdEmployee.SelectedRow.Cells[4].Text;
        //    objPerson.EntityType = this.ddlOrgOrPerson.SelectedValue == "P" ? "व्यक्ति" : "संस्था";
        //    AppellantLST.Add(objPerson);
        //    this.grdAppellant.DataSource = AppellantLST;
        //    this.grdAppellant.DataBind();

        //}
        //if (this.ddlAppOrResp.SelectedValue == "R")
        //{
        //    ATTPerson objPerson = new ATTPerson();
        //    objPerson.PId = double.Parse(grdEmployee.SelectedRow.Cells[0].Text);
        //    objPerson.FullName = grdEmployee.SelectedRow.Cells[4].Text;
        //    objPerson.EntityType = this.ddlOrgOrPerson.SelectedValue == "P" ? "व्यक्ति" : "संस्था";
        //    RespondantLST.Add(objPerson);
        //    this.grdRespondant.DataSource = RespondantLST;
        //    this.grdRespondant.DataBind();
        //}

        if (grdAppellant.Rows.Count > 0 || grdRespondant.Rows.Count > 0)
        {
            //colPnlApplOrResp.Collapsed = false;
            //colPnlApplOrResp.ClientState = "false";
        }
    }
   
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlVDC.DataSource = "";
            this.ddlWard.DataSource = "";
            this.ddlWard.Items.Clear();
            if (this.ddlDistrict.SelectedIndex > 0)
            {
                List<ATTVDC> lstVDCS;
                lstVDCS = BLLVDC.GetVDCList(int.Parse(this.ddlDistrict.SelectedItem.Value.ToString()), null);
                lstVDCS.Insert(0, new ATTVDC(0, 0, "छान्नुहोस", "Select VDC/Municipality", 0));
                this.ddlVDC.DataSource = lstVDCS;
                this.ddlVDC.DataTextField = "VdcNepName";
                this.ddlVDC.DataValueField = "VDCCode";
            }

            this.ddlVDC.DataBind();
            this.ddlWard.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlVDC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlWard.Items.Clear();
            this.ddlWard.DataSource = "";
            if (this.ddlVDC.SelectedIndex > 0)
            {
                List<ATTWard> lstWards;
                lstWards = BLLWard.GetWardList(int.Parse(this.ddlDistrict.SelectedItem.Value.ToString()), int.Parse(this.ddlVDC.SelectedItem.Value.ToString()));
                this.ddlWard.Items.Add(new ListItem("छान्नुहोस", "0"));
                this.ddlWard.DataSource = lstWards;
                this.ddlWard.DataTextField = "Ward";
                this.ddlWard.DataValueField = "Ward";
            }

            this.ddlWard.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlPhoneType_Phone_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnPhonePlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpPhoneTbl = (DataTable)Session["PersonPhoneTbl"];

        if (this.ddlPhoneType_Phone.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "फोनको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPhoneNumber_Phone.Text == "")
        {
            this.lblStatusMessage.Text = "फोन न. राख्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdPhone.SelectedIndex == -1)
        {
            DataRow row = tmpPhoneTbl.NewRow();
            row[1] = this.ddlPhoneType_Phone.SelectedValue;
            row[2] = this.ddlPhoneType_Phone.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtPhoneNumber_Phone.Text.Trim();
            row[5] = "Y";
            row[6] = "";
            row[7] = "A";
            tmpPhoneTbl.Rows.Add(row);
        }

        else
        {
            DataRow oldrow = tmpPhoneTbl.Rows[this.grdPhone.SelectedIndex];
            oldrow[1] = this.ddlPhoneType_Phone.SelectedValue;
            oldrow[2] = this.ddlPhoneType_Phone.SelectedItem.ToString();
            oldrow[4] = this.txtPhoneNumber_Phone.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlPhoneType_Phone.SelectedIndex = 0;
        this.txtPhoneNumber_Phone.Text = "";
        //this.txtPhoneRemarks.Text = "";
        this.grdPhone.DataSource = tmpPhoneTbl;
        this.grdPhone.DataBind();
        this.grdPhone.SelectedIndex = -1;
    }

    protected void grdEMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void grdPhone_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void grdPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["PersonPhoneTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdPhone.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdPhone.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdPhone.DataSource = tmpTbl;
            grdPhone.DataBind();
            //SetGridColor(7, 9, grdPhone);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdPhone.SelectedIndex > -1)
        {
            if (this.grdPhone.Rows[this.grdPhone.SelectedIndex].Cells[7].Text != "D")
            {
                row = this.grdPhone.SelectedRow;
                this.ddlPhoneType_Phone.SelectedValue = CheckNull.NullString(row.Cells[1].Text.ToString());
                this.txtPhoneNumber_Phone.Text = CheckNull.NullString(row.Cells[4].Text);
                //this.txtPhoneRemarks.Text =   CheckNull.NullString(row.Cells[6].Text);
            }
            else
                this.grdPhone.SelectedIndex = -1;
        }
    }
    protected void btnEMailPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpEMailTbl = (DataTable)Session["OrgEMailTbl"];

        if (this.ddlEMailType_EMail.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "ईमेलको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtEMail_EMail.Text == "")
        {
            this.lblStatusMessage.Text = "ईमेल ठेगाना राख्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.grdEMail.SelectedIndex == -1)
        {
            DataRow row = tmpEMailTbl.NewRow();
            row[1] = this.ddlEMailType_EMail.SelectedValue;
            row[2] = this.ddlEMailType_EMail.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtEMail_EMail.Text.Trim();
            row[5] = "Y";
            row[6] = "";
            row[7] = "A";
            tmpEMailTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpEMailTbl.Rows[this.grdEMail.SelectedIndex];
            oldrow[1] = this.ddlEMailType_EMail.SelectedValue;
            oldrow[2] = this.ddlEMailType_EMail.SelectedItem.ToString();
            oldrow[4] = this.txtEMail_EMail.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlEMailType_EMail.SelectedIndex = 0;
        this.txtEMail_EMail.Text = "";
        this.grdEMail.DataSource = tmpEMailTbl;
        this.grdEMail.DataBind();
        this.grdEMail.SelectedIndex = -1;
    }
    protected void grdEMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;

        try
        {
            DataTable tmpTbl = (DataTable)Session["PersonEMailTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdEMail.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdEMail.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdEMail.DataSource = tmpTbl;
            grdEMail.DataBind();

            //SetGridColor(7, 9, grdEMail);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdEMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdEMail.SelectedIndex > -1)
        {
            if (this.grdEMail.Rows[this.grdEMail.SelectedIndex].Cells[7].Text != "D")
            {

                row = this.grdEMail.SelectedRow;
                this.ddlEMailType_EMail.SelectedValue = CheckNull.NullString(row.Cells[1].Text.ToString());
                this.txtEMail_EMail.Text = CheckNull.NullString(row.Cells[4].Text);
            }
            else
                this.grdEMail.SelectedIndex = -1;
        }
    }
    protected void btnAddPerson_Click(object sender, EventArgs e)
    {
        #region "VALIDATIONS"

        if (this.ddlAppOrResp.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Either Appellant or Respondant";
            this.programmaticModalPopup.Show();
            return;
        }


        if (this.txtFName.Text == "")
        {
            this.lblStatusMessage.Text = "First Name Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtSurName.Text == "")
        {
            this.lblStatusMessage.Text = "Sur Name Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlBirthDistrict.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Birth District Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (chkIsPrisoned.Checked == true)
        {
            if (this.txtPrisonedFromDate.Text == "")
            {
                this.lblStatusMessage.Text = "Prison Details for Litigant Can't be Blank";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        #endregion


        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        string strUser = user.UserName;


        ATTLitigants LitigantTemp=new ATTLitigants();
        int? litigantSubType = 0;
                if (this.ddlLitigantSubType.SelectedValue == "0")
                    litigantSubType = null;
                else
                    litigantSubType = int.Parse(this.ddlLitigantSubType.SelectedValue);


        List<ATTLitigants> LitigantLST = this.ddlAppOrResp.SelectedValue == "A" ? (List<ATTLitigants>)Session["Appellant"] : (List<ATTLitigants>)Session["Respondant"];

        if (this.grdAppellant.SelectedIndex == -1 && this.grdRespondant.SelectedIndex == -1)
        {

            if (this.ddlOrgOrPerson.SelectedValue == "P")
            {
                //LITIGANT INFORMATIONS
                LitigantTemp = new ATTLitigants();
                LitigantTemp.CaseID = 0;
                LitigantTemp.LitigantID = 0;
                LitigantTemp.LitigantType = this.ddlAppOrResp.SelectedValue;
                LitigantTemp.LitigantSubTypeID = litigantSubType;
                LitigantTemp.LitigantName = this.txtFName.Text + " " + this.txtMName.Text + " " + this.txtSurName.Text;
                LitigantTemp.DisplayName = this.txtDisplayName.Text;
                LitigantTemp.SNo = "0";
                LitigantTemp.IsPrisoned = this.chkIsPrisoned.Checked == true ? "Y" : "N";
                LitigantTemp.EntityType = this.ddlOrgOrPerson.SelectedValue; ;
                LitigantTemp.EntryBy = strUser;
                LitigantTemp.Action = "A";



                //LITIGANT PRISON DETAILS
                if (this.chkIsPrisoned.Checked == true && this.lblAddEditPrisionDet.Text=="")
                {
                    ATTLitigantPrisonDetails objLitPrisonDetails = new ATTLitigantPrisonDetails();
                    objLitPrisonDetails.CaseID = 0;
                    objLitPrisonDetails.LitigantID = 0;
                    objLitPrisonDetails.FromDate = this.txtPrisonedFromDate.Text;
                    objLitPrisonDetails.ToDate = this.txtPrisonedToDate.Text;
                    objLitPrisonDetails.PrisonPlace = this.txtPrisonDescription.Text;
                    objLitPrisonDetails.EntryBy = user.UserName;
                    objLitPrisonDetails.Action = "A";
                    List<ATTLitigantPrisonDetails> objLPD = new List<ATTLitigantPrisonDetails>();
                    objLPD.Add(objLitPrisonDetails);
                    LitigantTemp.LitigantPrisonDetailsLST = objLPD;

                }


                
                //LITIGANT PERSONNEL INFO

                LitigantTemp.PersonOBJ = getPerson();
                LitigantLST.Add(LitigantTemp);

                
            }
        }
        else
        {
            LitigantTemp = this.ddlAppOrResp.SelectedValue == "A" ? LitigantLST[this.grdAppellant.SelectedIndex] : LitigantLST[this.grdRespondant.SelectedIndex];
            LitigantTemp.LitigantSubTypeID = litigantSubType;
            LitigantTemp.LitigantName = this.txtFName.Text + " " + this.txtMName.Text + " " + this.txtSurName.Text;
            LitigantTemp.DisplayName = this.txtDisplayName.Text;
            LitigantTemp.IsPrisoned = this.chkIsPrisoned.Checked == true ? "Y" : "N";
            LitigantTemp.EntryBy = strUser;
            LitigantTemp.Action = "E";


            //EDIT LITIGANT_PRISON_DETAIL
            if (this.chkIsPrisoned.Checked == true )
            {
                ATTLitigantPrisonDetails objLitPrisonDetails = new ATTLitigantPrisonDetails();
                objLitPrisonDetails.CaseID =LitigantTemp.CaseID;
                objLitPrisonDetails.LitigantID = LitigantTemp.LitigantID;
                objLitPrisonDetails.FromDate = this.txtPrisonedFromDate.Text;
                objLitPrisonDetails.ToDate = this.txtPrisonedToDate.Text;
                objLitPrisonDetails.PrisonPlace = this.txtPrisonDescription.Text;
                objLitPrisonDetails.EntryBy = user.UserName;
                objLitPrisonDetails.Action = this.lblAddEditPrisionDet.Text == "E" ? "E" : "A";
                List<ATTLitigantPrisonDetails> objLPD = new List<ATTLitigantPrisonDetails>();
                objLPD.Add(objLitPrisonDetails);
                LitigantTemp.LitigantPrisonDetailsLST = objLPD;

            }
            else if (this.chkIsPrisoned.Checked == false && this.lblAddEditPrisionDet.Text == "E")
            {
                ATTLitigantPrisonDetails objLitPrisonDetails = new ATTLitigantPrisonDetails();
                objLitPrisonDetails.CaseID = LitigantTemp.CaseID;
                objLitPrisonDetails.LitigantID = LitigantTemp.LitigantID;
                objLitPrisonDetails.FromDate = this.txtPrisonedFromDate.Text;
                objLitPrisonDetails.ToDate = this.txtPrisonedToDate.Text;
                objLitPrisonDetails.PrisonPlace = this.txtPrisonDescription.Text;
                objLitPrisonDetails.EntryBy = user.UserName;
                objLitPrisonDetails.Action = "D";
                List<ATTLitigantPrisonDetails> objLPD = new List<ATTLitigantPrisonDetails>();
                objLPD.Add(objLitPrisonDetails);
                LitigantTemp.LitigantPrisonDetailsLST = objLPD;
            }

            LitigantTemp.PersonOBJ = getPerson();
        }

        


        if (this.ddlAppOrResp.SelectedValue == "A")
        {
            Session["Appellant"] = LitigantLST;
            this.grdAppellant.DataSource = LitigantLST;
            this.grdAppellant.DataBind();
        }
        else if (this.ddlAppOrResp.SelectedValue == "R")
        {
            Session["Respondant"] = LitigantLST;
            this.grdRespondant.DataSource = LitigantLST;
            this.grdRespondant.DataBind();
        }
        

        this.grdAppellant.SelectedIndex = -1;
        this.grdRespondant.SelectedIndex = -1;
        this.grdPerson.SelectedIndex = -1;

        Session["IniType"] = null;
        Session["IniUnit"]= null;

        ClearContros(sender, e, false);




    }
    protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imgDelPerAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgDelTempAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlWardTemp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlOrgDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlOrgVDC.DataSource = "";
            this.ddlOrgWard.DataSource = "";
            this.ddlOrgWard.Items.Clear();
            if (this.ddlOrgDistrict.SelectedIndex > 0)
            {
                List<ATTVDC> lstVDCS;
                lstVDCS = BLLVDC.GetVDCList(int.Parse(this.ddlOrgDistrict.SelectedItem.Value.ToString()), null);
                lstVDCS.Insert(0, new ATTVDC(0, 0, "छान्नुहोस", "Select VDC/Municipality", 0));
                this.ddlOrgVDC.DataSource = lstVDCS;
                this.ddlOrgVDC.DataTextField = "VdcNepName";
                this.ddlOrgVDC.DataValueField = "VDCCode";
            }

            this.ddlOrgVDC.DataBind();
            this.ddlOrgWard.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlOrgVDC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlOrgWard.Items.Clear();
            this.ddlOrgWard.DataSource = "";
            if (this.ddlOrgVDC.SelectedIndex > 0)
            {
                List<ATTWard> lstWards;
                lstWards = BLLWard.GetWardList(int.Parse(this.ddlOrgDistrict.SelectedItem.Value.ToString()), int.Parse(this.ddlOrgVDC.SelectedItem.Value.ToString()));
                this.ddlOrgWard.Items.Add(new ListItem("छान्नुहोस", "0"));
                this.ddlOrgWard.DataSource = lstWards;
                this.ddlOrgWard.DataTextField = "Ward";
                this.ddlOrgWard.DataValueField = "Ward";
            }

            this.ddlOrgWard.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlOrgWard_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdOrgPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["OrgPhoneTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdOrgPhone.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdOrgPhone.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdOrgPhone.DataSource = tmpTbl;
            grdOrgPhone.DataBind();
            //SetGridColor(7, 9, grdPhone);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdOrgPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdOrgPhone.SelectedIndex > -1)
        {
            if (this.grdOrgPhone.Rows[this.grdOrgPhone.SelectedIndex].Cells[7].Text != "D")
            {
                row = this.grdOrgPhone.SelectedRow;
                this.ddlOrgPhoneType_Phone.SelectedValue = CheckNull.NullString(row.Cells[1].Text.ToString());
                this.txtOrgPhoneNumber_Phone.Text = CheckNull.NullString(row.Cells[4].Text);
                //this.txtPhoneRemarks.Text =   CheckNull.NullString(row.Cells[6].Text);
            }
            else
                this.grdOrgPhone.SelectedIndex = -1;
        }
    }
    protected void btnOrgPhonePlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpPhoneTbl = (DataTable)Session["OrgPhoneTbl"];

        if (this.ddlOrgPhoneType_Phone.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "फोनको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtOrgPhoneNumber_Phone.Text == "")
        {
            this.lblStatusMessage.Text = "फोन न. राख्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdOrgPhone.SelectedIndex == -1)
        {
            DataRow row = tmpPhoneTbl.NewRow();
            row[1] = this.ddlOrgPhoneType_Phone.SelectedValue;
            row[2] = this.ddlOrgPhoneType_Phone.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtOrgPhoneNumber_Phone.Text.Trim();
            row[5] = "Y";
            row[6] = "";
            row[7] = "A";
            tmpPhoneTbl.Rows.Add(row);
        }

        else
        {
            DataRow oldrow = tmpPhoneTbl.Rows[this.grdOrgPhone.SelectedIndex];
            oldrow[1] = this.ddlOrgPhoneType_Phone.SelectedValue;
            oldrow[2] = this.ddlOrgPhoneType_Phone.SelectedItem.ToString();
            oldrow[4] = this.txtOrgPhoneNumber_Phone.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlOrgPhoneType_Phone.SelectedIndex = 0;
        this.txtOrgPhoneNumber_Phone.Text = "";
        //this.txtPhoneRemarks.Text = "";
        this.grdOrgPhone.DataSource = tmpPhoneTbl;
        this.grdOrgPhone.DataBind();
        this.grdOrgPhone.SelectedIndex = -1;
    }
    protected void btnOrgEMailPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpEMailTbl = (DataTable)Session["OrgEMailTbl"];

        if (this.ddlOrgEMailType_EMail.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "ईमेलको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtOrgEMail_EMail.Text == "")
        {
            this.lblStatusMessage.Text = "ईमेल ठेगाना राख्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.grdOrgEMail.SelectedIndex == -1)
        {
            DataRow row = tmpEMailTbl.NewRow();
            row[1] = this.ddlOrgEMailType_EMail.SelectedValue;
            row[2] = this.ddlOrgEMailType_EMail.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtOrgEMail_EMail.Text.Trim();
            row[5] = "Y";
            row[6] = "";
            row[7] = "A";
            tmpEMailTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpEMailTbl.Rows[this.grdOrgEMail.SelectedIndex];
            oldrow[1] = this.ddlOrgEMailType_EMail.SelectedValue;
            oldrow[2] = this.ddlOrgEMailType_EMail.SelectedItem.ToString();
            oldrow[4] = this.txtOrgEMail_EMail.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlOrgEMailType_EMail.SelectedIndex = 0;
        this.txtOrgEMail_EMail.Text = "";
        this.grdOrgEMail.DataSource = tmpEMailTbl;
        this.grdOrgEMail.DataBind();
        this.grdOrgEMail.SelectedIndex = -1;
    }
    protected void grdOrgEMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;

        try
        {
            DataTable tmpTbl = (DataTable)Session["OrgEMailTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdOrgEMail.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdOrgEMail.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdOrgEMail.DataSource = tmpTbl;
            grdOrgEMail.DataBind();

            //SetGridColor(7, 9, grdEMail);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdOrgEMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdOrgEMail.SelectedIndex > -1)
        {
            if (this.grdOrgEMail.Rows[this.grdOrgEMail.SelectedIndex].Cells[7].Text != "D")
            {

                row = this.grdOrgEMail.SelectedRow;
                this.ddlOrgEMailType_EMail.SelectedValue = CheckNull.NullString(row.Cells[1].Text.ToString());
                this.txtOrgEMail_EMail.Text = CheckNull.NullString(row.Cells[4].Text);
            }
            else
                this.grdOrgEMail.SelectedIndex = -1;
        }
    }
    protected void ddlDistrictTemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlVDCTemp.DataSource = "";
            this.ddlWardTemp.DataSource = "";
            this.ddlWardTemp.Items.Clear();
            if (this.ddlDistrictTemp.SelectedIndex > 0)
            {
                List<ATTVDC> lstVDCS;
                lstVDCS = BLLVDC.GetVDCList(int.Parse(this.ddlDistrictTemp.SelectedItem.Value.ToString()), null);
                lstVDCS.Insert(0, new ATTVDC(0, 0, "छान्नुहोस", "Select VDC/Municipality", 0));
                this.ddlVDCTemp.DataSource = lstVDCS;
                this.ddlVDCTemp.DataTextField = "VdcNepName";
                this.ddlVDCTemp.DataValueField = "VDCCode";
            }

            this.ddlVDCTemp.DataBind();
            this.ddlWardTemp.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlVDCTemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlWardTemp.Items.Clear();
            this.ddlWardTemp.DataSource = "";
            if (this.ddlVDCTemp.SelectedIndex > 0)
            {
                List<ATTWard> lstWards;
                lstWards = BLLWard.GetWardList(int.Parse(this.ddlDistrictTemp.SelectedItem.Value.ToString()), int.Parse(this.ddlVDCTemp.SelectedItem.Value.ToString()));
                this.ddlWardTemp.Items.Add(new ListItem("छान्नुहोस", "0"));
                this.ddlWardTemp.DataSource = lstWards;
                this.ddlWardTemp.DataTextField = "Ward";
                this.ddlWardTemp.DataValueField = "Ward";
            }

            this.ddlWardTemp.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnSearchRelatives_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddRelatives_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        #region "VALIDATION"
        if (this.txtRelationFirstName_Relative.Text == "")
        {
            this.lblStatusMessage.Text = "कृपया पहिलो नाम राख्नुहोस.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtRelationLastName_Relative.Text == "")
        {
            this.lblStatusMessage.Text = "कृपया थर रख्नुहोस.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlRelationType_Relative.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "कृपया सम्बन्ध रोज्नुहोस.";
            this.programmaticModalPopup.Show();
            return;
        }

        //if (this.hdnRelativeID.Value.ToString() == this.txtEmployeeID.Text.Trim())
        //{
        //    this.lblStatusMessage.Text = "कर्मचारी आफै नातेदार हुन सक्दैन. कृपया अर्को नातेदार राख्नुहोस.";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        bool blnExists = false;
        if (this.hdnRelativeID.Value.ToString() != "0")
        {
            foreach (GridViewRow row in this.grdRelatives.Rows)
            {
                if (row.Cells[1].Text == this.hdnRelativeID.Value.ToString())
                {
                    blnExists = true;
                    break;
                }
            }
        }

        if (blnExists == true)
        {
            this.lblStatusMessage.Text = "यो कर्मचारीको लागी यो नातेदारको ईन्ट्री भईसकेको छ.";
            this.programmaticModalPopup.Show();
            return;
        }

        bool blnCardinality = false;
        List<ATTRelationType> RelationTypeList = (List<ATTRelationType>)Session["RelationType"];
        int? Cardinality = null;
        if (RelationTypeList[this.ddlRelationType_Relative.SelectedIndex].RelationTypeCardinality != null)
        {
            Cardinality = RelationTypeList[this.ddlRelationType_Relative.SelectedIndex].RelationTypeCardinality;
            int ExistingRelation = 0;
            foreach (GridViewRow row in this.grdRelatives.Rows)
            {
                //if((row.Cells[14].Text==this.ddlRelationType.SelectedItem.Text) && (row.Cells[21].Text=="Y"))
                if ((row.Cells[14].Text == this.ddlRelationType_Relative.SelectedItem.Text))
                {
                    ExistingRelation += 1;
                    if (ExistingRelation >= Cardinality)
                    {
                        blnCardinality = true;
                        break;
                    }
                }
            }
        }

        if (blnCardinality == true)
        {
            this.lblStatusMessage.Text = "कर्मचारीको लागी " + this.ddlRelationType_Relative.SelectedItem.Text + " " + Cardinality.ToString() + " मात्र हुनसक्नेछ";
            this.programmaticModalPopup.Show();
            return;
        }

        #endregion

        DataTable tmpRelativesTbl = (DataTable)Session["RelativesTbl"];
        string strFullName;
        if (grdRelatives.SelectedIndex == -1)
        {
            strFullName = this.txtRelationFirstName_Relative.Text.Trim();
            strFullName += (this.txtRelationMName.Text.Trim() == "" ? "" : " " + this.txtRelationMName.Text.Trim());
            strFullName += (this.txtRelationLastName_Relative.Text.Trim() == "" ? "" : " " + this.txtRelationLastName_Relative.Text.Trim());

            DataRow row = tmpRelativesTbl.NewRow();
            row[1] = 0;
            row[2] = this.txtRelationFirstName_Relative.Text.Trim();
            row[3] = this.txtRelationMName.Text.Trim();
            row[4] = this.txtRelationLastName_Relative.Text.Trim();
            row[5] = strFullName;
            if (this.ddlRelationGender.SelectedIndex > 0)
            {
                row[6] = this.ddlRelationGender.SelectedValue;
                row[7] = this.ddlRelationGender.SelectedItem.Text;
            }
            row[8] = this.txtRelationDOB_DTRelative.Text.Trim();
            if (this.ddlRelationMarStatus.SelectedIndex > 0)
            {
                row[9] = this.ddlRelationMarStatus.SelectedValue;
                row[10] = this.ddlRelationMarStatus.SelectedItem.Text;
            }
            if (this.ddlRelationHomeDistrict.SelectedIndex > 0)
            {
                row[11] = this.ddlRelationHomeDistrict.SelectedValue;
                row[12] = this.ddlRelationHomeDistrict.SelectedItem.Text;
            }
            if (this.ddlRelationType_Relative.SelectedIndex > 0)
            {
                row[13] = this.ddlRelationType_Relative.SelectedValue;
                row[14] = this.ddlRelationType_Relative.SelectedItem.Text;
            }
            row[15] = this.txtRelativeOcc.Text.Trim();
            row[17] = "A";

            tmpRelativesTbl.Rows.Add(row);
        }
        else
        {
            strFullName = this.txtRelationFirstName_Relative.Text.Trim();
            strFullName += (this.txtRelationMName.Text.Trim() == "" ? "" : " " + this.txtRelationMName.Text.Trim());
            strFullName += (this.txtRelationLastName_Relative.Text.Trim() == "" ? "" : " " + this.txtRelationLastName_Relative.Text.Trim());

            DataRow oldrow = tmpRelativesTbl.Rows[this.grdRelatives.SelectedIndex];
            oldrow[2] = this.txtRelationFirstName_Relative.Text.Trim();
            oldrow[3] = this.txtRelationMName.Text.Trim();
            oldrow[4] = this.txtRelationLastName_Relative.Text.Trim();
            oldrow[5] = strFullName;
            if (this.ddlRelationGender.SelectedIndex > 0)
            {
                oldrow[6] = this.ddlRelationGender.SelectedValue;
                oldrow[7] = this.ddlRelationGender.SelectedItem.Text;
            }
            oldrow[8] = this.txtRelationDOB_DTRelative.Text.Trim();
            if (this.ddlRelationMarStatus.SelectedIndex > 0)
            {
                oldrow[9] = this.ddlRelationMarStatus.SelectedValue;
                oldrow[10] = this.ddlRelationMarStatus.SelectedItem.Text;
            }
            if (this.ddlRelationHomeDistrict.SelectedIndex > 0)
            {
                oldrow[11] = this.ddlRelationHomeDistrict.SelectedValue;
                oldrow[12] = this.ddlRelationHomeDistrict.SelectedItem.Text;
            }
            if (this.ddlRelationType_Relative.SelectedIndex > 0)
            {
                oldrow[13] = this.ddlRelationType_Relative.SelectedValue;
                oldrow[14] = this.ddlRelationType_Relative.SelectedItem.Text;
            }
            oldrow[15] = this.txtRelativeOcc.Text.Trim();
            if ((CheckNull.NullString(oldrow[18].ToString()) == "E") || (CheckNull.NullString(oldrow[18].ToString()) == ""))
                oldrow[17] = "E";
            else
                oldrow[17] = "A";
        }
        ClearRelativeControls();
        this.grdRelatives.DataSource = tmpRelativesTbl;
        this.grdRelatives.DataBind();
        this.grdRelatives.SelectedIndex = -1;
    }


    void ClearRelativeControls()
    {
        this.hdnRelativeID.Value = "0";
        this.txtRelationFirstName_Relative.Text = "";
        this.txtRelationMName.Text = "";
        this.txtRelationLastName_Relative.Text = "";
        this.ddlRelationGender.SelectedIndex = 0;
        this.txtRelationDOB_DTRelative.Text = "";
        this.ddlRelationMarStatus.SelectedIndex = 0;
        this.ddlRelationHomeDistrict.SelectedIndex = 0;
        this.txtRelationFirstName_Relative.Enabled = true;
        this.txtRelationMName.Enabled = true;
        this.txtRelationLastName_Relative.Enabled = true;
        this.ddlRelationGender.Enabled = true;
        this.txtRelationDOB_DTRelative.Enabled = true;
        this.ddlRelationMarStatus.Enabled = true;
        this.ddlRelationHomeDistrict.Enabled = true;
        this.txtRelativeOcc.Text = "";
        this.ddlRelationType_Relative.SelectedIndex = 0;

        this.grdRelatives.DataSource = "";
        this.grdRelatives.DataBind();

        SetRelativesTable();
    }
    protected void btnClearRelatives_Click(object sender, EventArgs e)
    {

    }
    protected void grdEmpRelatives_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void imgDelOrgPerAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlOrgPhoneType_Phone_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddOrganization_Click(object sender, EventArgs e)
    {

        if (this.txtOrgName_RQD.Text == "")
        {
            this.lblStatusMessage.Text = "Organization Name Can't Be Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlAppOrResp.SelectedIndex==0)
         {
            this.lblStatusMessage.Text = "Please Select Either Appellant or Respondant";
            this.programmaticModalPopup.Show();
            return;
        }

        
        int ? litigantSubType=null;
        if (this.ddlLitigantSubType.SelectedValue != "0")
            litigantSubType = int.Parse(this.ddlLitigantSubType.SelectedValue);
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTLitigants> LitigantLST = this.ddlAppOrResp.SelectedValue == "A" ? (List<ATTLitigants>)Session["Appellant"] : (List<ATTLitigants>)Session["Respondant"];

        //PersonLST.Add(getOrganizationAsPerson());

        ATTLitigants LitigantTemp = new ATTLitigants();
        LitigantTemp.CaseID = 0;
        LitigantTemp.LitigantID = 0;
        LitigantTemp.LitigantType = this.ddlAppOrResp.SelectedValue;
        LitigantTemp.LitigantSubTypeID = litigantSubType; //int.Parse(this.ddlLitigantSubType.SelectedValue);
        LitigantTemp.LitigantName = this.txtOrgName_RQD.Text;
        LitigantTemp.DisplayName = "";// this.txtDisplayName.Text;
        LitigantTemp.SNo = "0";
        LitigantTemp.IsPrisoned = "N";
        LitigantTemp.EntityType= this.ddlOrgOrPerson.SelectedItem.Text;
        LitigantTemp.EntryBy = user.UserName;
        LitigantTemp.Action = "A";

        LitigantTemp.PersonOBJ = getOrganizationAsPersonList();

        LitigantLST.Add(LitigantTemp);
            

        if (this.ddlAppOrResp.SelectedValue == "A")
        {
            Session["Appellant"] = LitigantLST;
            this.grdAppellant.DataSource = LitigantLST;
            this.grdAppellant.DataBind();
        }
        else if (this.ddlAppOrResp.SelectedValue == "R")
        {
            Session["Respondant"] = LitigantLST;
            this.grdRespondant.DataSource = LitigantLST;
            this.grdRespondant.DataBind();
        }
       

        ClearContros(sender, e, true);
        Session["IniType"] = null;
        Session["IniUnit"] = null;

       
    }

    private ATTPerson getPerson()
    {
        int iniUnit = Session["IniUnit"] != null ? int.Parse(Session["IniUnit"].ToString()) : ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        double pID = 0;
        int iniType = Session["IniType"]!= null ? int.Parse(Session["IniType"].ToString()) : 1;
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //ATTPerson objPerson = new ATTPerson();


        if (this.txtPersonID.Text.Trim() != "")
            pID = double.Parse(this.txtPersonID.Text.Trim());
        if (this.ddlCountry.SelectedIndex > 0)
            intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
        if (this.ddlBirthDistrict.SelectedIndex > 0)
            intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
        if (this.ddlReligion.SelectedIndex > 0)
            intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());


        #region "PERSONTABLE"
        //objPerson = new ATTPerson(empID, this.txtFName_Rqd.Text.Trim(),
        //    this.txtMName.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
        //    this.txtDOB_DT.Text.Trim(), ((this.ddlGenders.SelectedIndex <= 0) ? "" : (this.ddlGenders.SelectedValue)),
        //    ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
        //    "", "", intCountryId, intBirthDistrict, intReligion,
        //    iniUnit, iniType, "manoz", DateTime.Now, new byte[0]);
        
        ATTPerson objPerson = new ATTPerson();
        objPerson.PId = pID;
        objPerson.FirstName = this.txtFName.Text.Trim();
        objPerson.MidName = this.txtMName.Text.Trim();
        objPerson.SurName = this.txtSurName.Text.Trim();
        objPerson.DOB = this.txtDOB.Text;
        objPerson.Gender= this.ddlGender.SelectedIndex <= 0 ? "" : this.ddlGender.SelectedValue;
        objPerson.MaritalStatus = this.ddlMarStatus.SelectedIndex <= 0 ? "" : this.ddlMarStatus.SelectedValue;
        objPerson.FatherName = "";
        objPerson.GFatherName = "";
        objPerson.CountryId = intCountryId;
        objPerson.BirthDistrict = intBirthDistrict;
        objPerson.ReligionId = intReligion;
        objPerson.IniUnit = iniUnit;
        objPerson.IniType = iniType;
        objPerson.EntryBy =user.UserName ;
        objPerson.EntryDate = DateTime.Now;
        objPerson.Photo = new byte[0];
        //objPerson.FullName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
        objPerson.EntityType = "P";
        if (this.grdRespondant.SelectedIndex == -1 && this.grdAppellant.SelectedIndex == -1)
            objPerson.Action = "A";
        else
        {
            if (this.grdPerson.SelectedIndex == -1)
            {
                if (this.grdAppellant.SelectedIndex > 1 && CheckNull.NullString(this.grdAppellant.SelectedRow.Cells[4].Text) == "A")
                    objPerson.Action = "A";
                else
                    objPerson.Action = "E";

                if (this.grdRespondant.SelectedIndex > -1 && CheckNull.NullString(this.grdRespondant.SelectedRow.Cells[4].Text) == "A")
                    objPerson.Action = "A";
                else
                    objPerson.Action = "E";
            }
            else
            {
                objPerson.Action = "E";
            }

        }
            
        #endregion


        #region "ADDRESS"

        int? intDistrictAddress = null;
        int? intVDCAddress = null;
        int? intWardAddress = null;
        string strAddressAction = "";
        ATTPersonAddress PersonAddressATT = null;
           
        if (this.ddlDistrict.SelectedIndex > 0 || this.ddlVDC.SelectedIndex > 0 || this.ddlWard.SelectedIndex > 0 || this.txtTole.Text != "")
        {
            if (this.ddlDistrict.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrict.SelectedValue);
            if (this.ddlVDC.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDC.SelectedValue);
            if (this.ddlWard.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWard.SelectedValue);
            PersonAddressATT = new ATTPersonAddress
                (
                0, "P", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtTole.Text.Trim(), "Y", user.UserName, DateTime.Now
                );
            if (this.txtPerAdd.Text == "")
                strAddressAction = "A";
            else
                strAddressAction = "E";
            
            if (strAddressAction != "")
            {
                PersonAddressATT.Action = strAddressAction;
                strAddressAction = "";
                objPerson.LstPersonAddress.Add(PersonAddressATT);
            }
        }


        if (this.ddlDistrictTemp.SelectedIndex > 0 || this.ddlVDCTemp.SelectedIndex > 0 || this.ddlWardTemp.SelectedIndex > 0 || this.txtToleTemp.Text != "")
        {
            strAddressAction = "";
            intDistrictAddress = null;
            intVDCAddress = null;
            intWardAddress = null;

            if (this.ddlDistrictTemp.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrictTemp.SelectedValue);
            if (this.ddlVDCTemp.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDCTemp.SelectedValue);
            if (this.ddlWardTemp.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWardTemp.SelectedValue);
            PersonAddressATT = new ATTPersonAddress
                (
                0, "T", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtToleTemp.Text.Trim(), "Y", user.UserName, DateTime.Now
                );

            if (this.txttempAdd.Text == "")
                strAddressAction = "A";
            else
                strAddressAction = "E";
            if (strAddressAction != "")
            {
                PersonAddressATT.Action = strAddressAction;
                strAddressAction = "";
                objPerson.LstPersonAddress.Add(PersonAddressATT);
            }
        }
        #endregion

        #region "PHONE"
        foreach (GridViewRow row in this.grdPhone.Rows)
        {
            if (CheckNull.NullString(row.Cells[7].Text.ToString()) != "")
            {
                ATTPersonPhone PersonPhoneATT = new ATTPersonPhone(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                      CheckNull.NullString(row.Cells[4].Text.ToString()), CheckNull.NullString(row.Cells[5].Text.ToString()),
                      CheckNull.NullString(row.Cells[6].Text.ToString()), user.UserName, DateTime.Now);
                PersonPhoneATT.Action = CheckNull.NullString(row.Cells[7].Text.ToString());
                objPerson.LstPersonPhone.Add(PersonPhoneATT);
            }
        }
        #endregion

        #region "EMAIL"
        foreach (GridViewRow row in this.grdEMail.Rows)
        {
            if (CheckNull.NullString(row.Cells[7].Text.ToString()) != "")
            {
                ATTPersonEMail PersonEMailATT = new ATTPersonEMail(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                      CheckNull.NullString(row.Cells[4].Text.ToString()), CheckNull.NullString(row.Cells[5].Text.ToString()),
                      CheckNull.NullString(row.Cells[6].Text.ToString()), user.UserName, DateTime.Now);
                PersonEMailATT.Action = CheckNull.NullString(row.Cells[7].Text.ToString());
                objPerson.LstPersonEMail.Add(PersonEMailATT);
            }
        }
        #endregion

        #region "RELATIVES AND BENEFICIARIES"
        foreach (GridViewRow row in this.grdRelatives.Rows)
        {
            int? countryID = null;
            int? birthDistrict = null;
            int? religionID = null;
            if (CheckNull.NullString(row.Cells[11].Text) != "")
                birthDistrict = int.Parse(row.Cells[11].Text);
            byte[] RelativeImageData = new byte[0];
            ATTPerson objRelativePerson = new ATTPerson
                (double.Parse(row.Cells[1].Text), row.Cells[2].Text, CheckNull.NullString(row.Cells[3].Text), CheckNull.NullString(row.Cells[4].Text),
                  CheckNull.NullString(row.Cells[8].Text), CheckNull.NullString(row.Cells[6].Text), CheckNull.NullString(row.Cells[9].Text), "", "",
                countryID, birthDistrict, religionID, iniUnit, iniType, user.UserName, DateTime.Now, RelativeImageData);
            CheckBox cb = (CheckBox)row.FindControl("chkRelativeActive");
            
            

            ATTRelatives RelativesATT = new ATTRelatives(0, 0, int.Parse(row.Cells[13].Text), (cb.Checked ? "Y" : "N"));
            RelativesATT.Occupation = CheckNull.NullString(row.Cells[15].Text);
            RelativesATT.EntryBy = user.UserName;
            if (CheckNull.NullString(row.Cells[17].Text) == "A")
                RelativesATT.Action = "A";
            else
                RelativesATT.Action = "E";
            RelativesATT.ObjPerson = objRelativePerson;
            objPerson.LstRelatives.Add(RelativesATT);
        }
        #endregion

        #region "DOCUMENTS"

        //ATTPersonDocuments objPDoc = new ATTPersonDocuments();
        //objPDoc.PId = 0;
        //objPDoc.DocTypeID = int.Parse(this.ddlDocumentType.SelectedValue);
        //objPDoc.DocNumber= this.txtDocNo.Text;
        //objPDoc.IssuedBy = this.txtIssuedBy.Text;
        //objPDoc.IssuedOn = this.txtIssuedDate.Text;
        //objPDoc.Active = "A";
        //objPDoc.Action = "A";

        objPerson.LstPersonDocuments = (List<ATTPersonDocuments>)Session["PersonDocuments"];

        #endregion

        return objPerson;

    }

    private ATTPerson getOrganizationAsPersonList()
    {
        int iniUnit = Session["IniUnit"] != null ? int.Parse(Session["IniUnit"].ToString()) : ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        int iniType = Session["IniType"] != null ? int.Parse(Session["IniType"].ToString()) : 1;
        double orgID = 0;

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        string strUser =user.UserName ;

        ATTPerson objPerson = new ATTPerson();


        if (this.txtOrgID.Text.Trim() != "")
            orgID = double.Parse(this.txtOrgID.Text.Trim());


        #region "PERSONTABLE"
        objPerson = new ATTPerson(orgID, this.txtOrgName_RQD.Text.Trim(),
            "", "",
            "", "",
            "",
            "", "", null, null, null,
            iniUnit, iniType, user.UserName, DateTime.Now, new byte[0]);
        //objPerson.FullName = this.txtOrgName_RQD.Text.Trim() + " " + this.txtMName.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
        //objPerson.EntityType = "P";
        #endregion

        objPerson.PId = orgID;
        objPerson.FirstName = this.txtOrgName_RQD.Text.Trim();
        //objPerson.FullName = this.txtOrgName_RQD.Text.Trim();
        objPerson.IniUnit = iniUnit;
        objPerson.IniType = iniType;
        objPerson.EntryBy = user.UserName;
        objPerson.EntityType = "O";
        objPerson.Photo = new byte[0];
        //objPerson.RegdNO = this.txtSearchRegNo.Text.Trim();
        //objPerson.PanNo = this.txtSearchPanNo.Text.Trim();

        #region "ADDRESS"
        int? intDistrictAddress = null;
        int? intVDCAddress = null;
        int? intWardAddress = null;
        string strAddressAction = "";
        ATTPersonAddress PersonAddressATT = null;

        if (this.ddlOrgDistrict.SelectedIndex > 0 || this.ddlOrgVDC.SelectedIndex > 0 || this.ddlOrgWard.SelectedIndex > 0 || this.txtOrgTole.Text != "")
        {
            if (this.ddlDistrict.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrict.SelectedValue);
            if (this.ddlVDC.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDC.SelectedValue);
            if (this.ddlWard.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWard.SelectedValue);
            PersonAddressATT = new ATTPersonAddress
                (
                0, "P", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtTole.Text.Trim(), "Y", user.UserName, DateTime.Now
                );



            PersonAddressATT.Action = "A"; ;
            objPerson.LstPersonAddress.Add(PersonAddressATT);
        }

        

        #endregion

        #region "PHONE"
        foreach (GridViewRow row in this.grdPhone.Rows)
        {
            if (CheckNull.NullString(row.Cells[7].Text.ToString()) != "")
            {
                ATTPersonPhone PersonPhoneATT = new ATTPersonPhone(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                      CheckNull.NullString(row.Cells[4].Text.ToString()), CheckNull.NullString(row.Cells[5].Text.ToString()),
                      CheckNull.NullString(row.Cells[6].Text.ToString()), user.UserName, DateTime.Now);
                PersonPhoneATT.Action = CheckNull.NullString(row.Cells[7].Text.ToString());
                objPerson.LstPersonPhone.Add(PersonPhoneATT);
            }
        }
        #endregion

        #region "EMAIL"
        foreach (GridViewRow row in this.grdEMail.Rows)
        {
            if (CheckNull.NullString(row.Cells[7].Text.ToString()) != "")
            {
                ATTPersonEMail PersonEMailATT = new ATTPersonEMail(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                      CheckNull.NullString(row.Cells[4].Text.ToString()), CheckNull.NullString(row.Cells[5].Text.ToString()),
                      CheckNull.NullString(row.Cells[6].Text.ToString()), user.UserName, DateTime.Now);
                PersonEMailATT.Action = CheckNull.NullString(row.Cells[7].Text.ToString());
                objPerson.LstPersonEMail.Add(PersonEMailATT);
            }
        }

        return objPerson;
        #endregion

        #region "RELATIVES"
        ATTRelatives objRelatives;// = new ATTRelatives();
        List<ATTRelatives> RelativesLST = new List<ATTRelatives>();
        ATTPerson objRelPerson;
        int? birthDistrict;


        foreach (GridViewRow  gvRow in this.grdRelatives.Rows)
        {
            objRelPerson.PId = 0;
            objRelPerson.FirstName = gvRow.Cells[2].Text;
            objRelPerson.MidName =CheckNull.NullString( gvRow.Cells[3].Text);
            objRelPerson.SurName = gvRow.Cells[4].Text;

            objRelPerson.Gender = CheckNull.NullString(gvRow.Cells[6].Text);

            objRelPerson.MaritalStatus =CheckNull.NullString( gvRow.Cells[9].Text);

            objRelPerson.DOB =CheckNull.NullString( gvRow.Cells[8].Text);

            if (ddlRelationHomeDistrict.SelectedValue == "0")
                birthDistrict = null;
            else
                birthDistrict =int.Parse( gvRow.Cells[11].Text);

            objRelPerson.BirthDistrict = birthDistrict;
            

            objRelatives = new ATTRelatives();

            
            objRelatives.PId = 0;
            objRelatives.RelativeId =double.Parse( gvRow.Cells[1].Text);
            objRelatives.RelationTypeId =int.Parse( gvRow.Cells[13].Text);
            objRelatives.Occupation =CheckNull.NullString( gvRow.Cells[15].Text);
            objRelatives.Active = "A";
            objRelatives.Action = gvRow.Cells[17].Text;

            objRelatives.ObjPerson = objRelPerson;
            RelativesLST.Add(objRelatives);
                    
        }

        objPerson.LstRelatives = RelativesLST;
        #endregion



    }

    protected void ddlOrgOrPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlOrgOrPerson.SelectedValue == "P")
        {
            //this.pnlabc.Visible = true;
            //this.pnlxyz.Visible = false;
            this.PnlPersonSearch.Visible = true;
            this.pnlOrgSearch.Visible = false;
            this.pnlPerson.Visible = true;
            this.pnlOrganization.Visible = false;

        }
        else
        {
            //this.pnlxyz.Visible = true;
            //this.pnlabc.Visible = false;
            this.PnlPersonSearch.Visible = false;
            this.pnlOrgSearch.Visible = true;
            this.pnlOrganization.Visible = true;
            this.pnlPerson.Visible = false;
        }
        
    }

    protected void ddlOrgCaseRegType_RQD_SelectedIndexChanged(object sender, EventArgs e)
    {
       List<ATTOrganizationCaseType> OrgCaseTypeLST = (List<ATTOrganizationCaseType>)Session["OrgCaseType"];
        this.grdCheckList.DataSource = OrgCaseTypeLST[this.ddlCaseType_RQD.SelectedIndex].OrgCaseRegistrationTypeLST[this.ddlOrgCaseRegType_RQD.SelectedIndex].OrgCaseRegTypeCheckListLST.FindAll(delegate(ATTOrgCaseRegTypeCheckList obj)
                                                {
                                                    return obj.CheckListType=="A";
                                                });
        this.grdCheckList.DataBind();
    }

    protected void btnAddAppOrResp_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        if (this.ddlCaseType_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Type.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlOrgCaseRegType_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Registration Type.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlRegistrationDiary_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Registration Diary.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlRegDiarySubject_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Registration Diary Subject.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlRegDiaryName_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Registration Diary Name.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlCaseProceeding_RQD.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Please Select Case Proceeding Type.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.chkForwardToAccount.Checked == true && this.grdAccountFWD.Rows.Count == 0)
        {
            this.lblStatusMessage.Text = "Account Information Not Provided";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdAppellant.Rows.Count==0)
        {
            this.lblStatusMessage.Text = "No Appellant Found In The Case.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdRespondant.Rows.Count == 0)
        {
            this.lblStatusMessage.Text = "No Respodant Found In The Case.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtCaseRegistrationDate_DT.Text.CompareTo(Session["NepDate"].ToString()) > 0)
        {
            this.lblStatusMessage.Text = "Case Registration Date Should Not Be Greater Than Current Date";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        int? writSubjectID=null;
        int? writCategoryID=null;
        int? writTitleID=null;
        int? writSubTitleID=null;

        if (this.ddlWritSubject.SelectedValue != "0" && this.ddlWritSubject.Items.Count>0)
        {
            writSubjectID =int.Parse( this.ddlWritSubject.SelectedValue);
        }
        if (this.ddlWritCategory.SelectedValue != "0" && this.ddlWritCategory.Items.Count>0)
        {
            writCategoryID = int.Parse(this.ddlWritCategory.SelectedValue);
        }
        if (this.ddlWritTitle.SelectedValue != "0" && this.ddlWritTitle.Items.Count>0)
        {
            writTitleID =int.Parse( this.ddlWritTitle.SelectedValue);
        }
        if (this.ddlWritSubTitle.SelectedValue != "0" && this.ddlWritSubTitle.Items.Count>0)
        {
            writSubTitleID = int.Parse(this.ddlWritSubTitle.SelectedValue);
        }

        ATTCaseRegistration objCaseRegistration = new ATTCaseRegistration();
        objCaseRegistration.CaseID = this.txtCaseNo.Text == "" ? 0 : double.Parse(this.txtCaseNo.Text);
        objCaseRegistration.CourtID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        objCaseRegistration.CaseTypeID = int.Parse(this.ddlCaseType_RQD.SelectedValue);
        objCaseRegistration.CaseTypeName = this.ddlCaseType_RQD.SelectedItem.Text;
        objCaseRegistration.RegTypeID = int.Parse(this.ddlOrgCaseRegType_RQD.SelectedValue);
        objCaseRegistration.RegTypeName = this.ddlOrgCaseRegType_RQD.SelectedItem.Text;
        objCaseRegistration.RegDiaryID = int.Parse(this.ddlRegistrationDiary_RQD.SelectedValue);
        objCaseRegistration.RegDiaryName = this.ddlRegistrationDiary_RQD.SelectedItem.Text;
        objCaseRegistration.RegSubjectID = int.Parse(this.ddlRegDiarySubject_RQD.SelectedValue);
        objCaseRegistration.RegSubjectName = this.ddlRegDiarySubject_RQD.SelectedItem.Text;
        objCaseRegistration.RegDiaryNameID = int.Parse(this.ddlRegDiaryName_RQD.SelectedValue);
        objCaseRegistration.RegDiarySubName = this.ddlRegDiaryName_RQD.SelectedItem.Text;
        objCaseRegistration.CaseRegistrationDate = this.txtCaseRegistrationDate_DT.Text;
        objCaseRegistration.RegistrationNumber = "";
        objCaseRegistration.CaseNumber = "";
        objCaseRegistration.WritSubjectID = writSubjectID;
        objCaseRegistration.WritCatID = writCategoryID;
        objCaseRegistration.WirtCatTitleID = writTitleID;
        objCaseRegistration.WritCatSubTitleID = writSubjectID;
        objCaseRegistration.AccountForwarded = chkForwardToAccount.Checked == true ? "Y" : "N";
        objCaseRegistration.VerifiedBy=1;
        objCaseRegistration.VerifiedYesNo="";
        objCaseRegistration.VerifiedDate="";
        objCaseRegistration.DarpithRemarks="";
        objCaseRegistration.ProceedingID = int.Parse(this.ddlCaseProceeding_RQD.SelectedValue);
        objCaseRegistration.ProceedingType = this.ddlCaseProceeding_RQD.SelectedItem.Text;
        objCaseRegistration.CaseSummary="";
        objCaseRegistration.RelatedCaseID=null;
        objCaseRegistration.FY="";
        objCaseRegistration.Action = this.txtCaseNo.Text == "" ? "A" : "E";

        objCaseRegistration.AppellantLST = (List<ATTLitigants>)Session["Appellant"];
        objCaseRegistration.AppellantLST.RemoveAll(delegate(ATTLitigants obj)
                                                    {
                                                        return obj.Action == "";
                                                    });
        objCaseRegistration.RespondantLST = (List<ATTLitigants>)Session["Respondant"];
        objCaseRegistration.RespondantLST.RemoveAll(delegate(ATTLitigants obj)
                                                    {
                                                        return obj.Action == "";
                                                    });
        
        foreach (GridViewRow gvRow in this.grdCheckList.Rows)
        {
            ATTCaseCheckList objCCL = new ATTCaseCheckList();
            objCCL.CaseID = 0;
            objCCL.OrgID = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            objCCL.CaseTypeID = int.Parse(this.ddlCaseType_RQD.SelectedValue);
            objCCL.RegTypeID = int.Parse(this.ddlOrgCaseRegType_RQD.SelectedValue);
            objCCL.CheckListID = int.Parse(gvRow.Cells[1].Text);
            objCCL.FulFilled = ((CheckBox)gvRow.FindControl("chkSelect")).Checked == true ? "Y" : "N";
            objCCL.Remarks = ((TextBox)gvRow.FindControl("txtCLRemarks")).Text;
            objCCL.EntryBy = user.UserName;
            objCCL.Action = "A";

            objCaseRegistration.CaseCheckListLST.Add(objCCL);


        }
        ((List<ATTCaseAccountForward>)Session["AccountFWD"]).RemoveAll(delegate(ATTCaseAccountForward obj)
                                                                        {
                                                                            return obj.Action == "";
                                                                        });
        objCaseRegistration.CaseAccountForwardLST = (List<ATTCaseAccountForward>)Session["AccountFWD"];


        //SAVE CASE REGISTRATION
        BLLCaseRegistration.RegisterCase(objCaseRegistration);

        if (this.txtCaseNo.Text.Trim() == "")
        {
            Session["CaseNo"] = objCaseRegistration.CaseID;
        }
        else
        {
            Session["CaseNo"] = this.txtCaseNo.Text;
            //Session["CaseRegistration"] = null;

        }

        
        Response.Redirect("CaseRegistration2.aspx");
       
    }
    protected void ddlPhoneType_Phone_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void grdRelatives_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[13].Visible = false;
        e.Row.Cells[17].Visible = false;
        
        
    }
    protected void grdAppellant_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTLitigants> LitigantLST = (List<ATTLitigants>)Session["Appellant"];

        this.grdRespondant.SelectedIndex = -1;
        this.ddlAppOrResp.SelectedValue = "A";
        if (grdAppellant.SelectedRow.Cells[3].Text == "व्यक्ति")
            this.ddlOrgOrPerson.SelectedValue = "P";
        else
            this.ddlOrgOrPerson.SelectedValue = "O";

        this.ddlOrgOrPerson_SelectedIndexChanged(sender, e);

        this.txtDisplayName.Text = LitigantLST[this.grdAppellant.SelectedIndex].DisplayName;
        this.ddlLitigantSubType.SelectedValue =LitigantLST[this.grdAppellant.SelectedIndex].LitigantSubTypeID==null?"0": LitigantLST[this.grdAppellant.SelectedIndex].LitigantSubTypeID.ToString();

        if (LitigantLST[this.grdAppellant.SelectedIndex].IsPrisoned == "Y")
        {
            lblAddEditPrisionDet.Text = "E";
            this.chkIsPrisoned.Checked = true;
            chkIsPrisoned_CheckedChanged(sender, e);

            this.txtPrisonedFromDate.Text = LitigantLST[this.grdAppellant.SelectedIndex].LitigantPrisonDetailsLST[0].FromDate;
            this.txtPrisonedToDate.Text = LitigantLST[this.grdAppellant.SelectedIndex].LitigantPrisonDetailsLST[0].ToDate;
            this.txtPrisonDescription.Text = LitigantLST[this.grdAppellant.SelectedIndex].LitigantPrisonDetailsLST[0].PrisonPlace;
        }
        else
        {
            lblAddEditPrisionDet.Text = "A";
            this.chkIsPrisoned.Checked = false;
            chkIsPrisoned_CheckedChanged(sender, e);
        }

        ATTPerson objPerson = LitigantLST[this.grdAppellant.SelectedIndex].PersonOBJ;
        if (objPerson.EntityType == "P")
            setPersonDetails(objPerson, sender, e);
        else
            setOrgAsPersonDetails(objPerson, sender, e);

        if (objPerson.IniType == int.Parse(this.lblIniType.Text) && objPerson.IniUnit == int.Parse(this.lblIniUnit.Text))
        {
            EnablePersonControls(true);
        }
        else
        {
            EnablePersonControls(false);
            this.lblStatusMessage.Text = "Selected Person / Organization Can't Be Edited";
            this.programmaticModalPopup.Show();
        }


 

    }
    protected void grdRespondant_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTLitigants> LitigantLST = (List<ATTLitigants>)Session["Respondant"];

        
        this.grdAppellant.SelectedIndex = -1;
        this.ddlAppOrResp.SelectedValue = "R";
        if (grdRespondant.SelectedRow.Cells[3].Text == "व्यक्ति")
            this.ddlOrgOrPerson.SelectedValue = "P";
        else
            this.ddlOrgOrPerson.SelectedValue = "O";

        this.ddlOrgOrPerson_SelectedIndexChanged(sender, e);

        this.txtDisplayName.Text = LitigantLST[this.grdRespondant.SelectedIndex].DisplayName;
        this.ddlLitigantSubType.SelectedValue = LitigantLST[this.grdRespondant.SelectedIndex].LitigantSubTypeID == null ? "0" : LitigantLST[this.grdRespondant.SelectedIndex].LitigantSubTypeID.ToString();
        

        ATTPerson objPerson = LitigantLST[this.grdRespondant.SelectedIndex].PersonOBJ;

        setPersonDetails(objPerson,sender,e);
        if (objPerson.IniType == int.Parse(this.lblIniType.Text) && objPerson.IniUnit == int.Parse(this.lblIniUnit.Text))
        {
            EnablePersonControls(true);
        }
        else
        {
            EnablePersonControls(false);
            this.lblStatusMessage.Text = "Selected Person / Organization Can't Be Edited";
            this.programmaticModalPopup.Show();
        }


    }

    /// <summary>
    /// sets Personnel Details of Litigant To Edit
    /// </summary>
    /// <param name="objPerson">Person Object To Be Edited </param>
    private void setPersonDetails(ATTPerson objPerson, object sender, EventArgs e)
    {
        //Clears Address Contols
        this.ddlDistrict.SelectedValue = "0";
        this.ddlDistrict_SelectedIndexChanged(sender, e);
        this.ddlVDC_SelectedIndexChanged(sender, e);
        this.txtTole.Text = "";

        this.ddlDistrictTemp.SelectedValue = "0";
        this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtToleTemp.Text = "";

        //Clears Relatives Controls
        ClearRelativeControls();
        
        

        //PERSON DETAILS
        this.txtPersonID.Text = objPerson.PId.ToString();
        this.txtFName.Text = objPerson.FirstName;
        this.txtMName.Text = objPerson.MidName;
        this.txtSurName.Text = objPerson.SurName;
        this.txtDOB.Text = objPerson.DOB;
        this.ddlGender.SelectedValue = objPerson.Gender == "" ? "SG" : objPerson.Gender;
        this.ddlMarStatus.SelectedValue = objPerson.MaritalStatus == "" ? "SMS" : objPerson.MaritalStatus;
        
        //this.ddlCountry.SelectedValue
        this.ddlBirthDistrict.SelectedValue =objPerson.BirthDistrict==null?"0": objPerson.BirthDistrict.ToString();
        this.ddlReligion.SelectedValue =objPerson.ReligionId==null?"0": objPerson.ReligionId.ToString();
        //this.txtIdentityMark.Text=objPerson.


        //ADDRESSES DETAILS
        //PERMANENT ADDRESS
        List<ATTPersonAddress> AddressLST = objPerson.LstPersonAddress;

        ATTPersonAddress objAddress = AddressLST.Find(delegate(ATTPersonAddress o1)
                                                    {
                                                        return o1.AdTypeId == "P";
                                                    });
        if (objAddress != null)
        {
            this.ddlDistrict.SelectedValue = objAddress.District.ToString();
            this.ddlDistrict_SelectedIndexChanged(sender, e);
            //this.ddlVDC_SelectedIndexChanged(sender, e);
            this.ddlVDC.SelectedValue = objAddress.VDC.ToString();
            this.ddlVDC_SelectedIndexChanged(sender, e);
            this.ddlWard.SelectedValue = objAddress.Ward.ToString();
            this.txtTole.Text = objAddress.Tole;

            this.txtPerAdd.Text = objAddress.District.ToString() + objAddress.VDC.ToString() + objAddress.Ward.ToString() + objAddress.Tole;
        }
        

        //TEMPORARY ADDRESS
        AddressLST = objPerson.LstPersonAddress;
        objAddress = AddressLST.Find(delegate(ATTPersonAddress o1)
                                                    {
                                                        return o1.AdTypeId == "T";
                                                    });
        if (objAddress != null)
        {
            this.ddlDistrictTemp.SelectedValue = objAddress.District == null ? "0" : objAddress.District.ToString();
            this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
            this.ddlVDCTemp.SelectedValue = objAddress.VDC.ToString();
            this.ddlVDCTemp_SelectedIndexChanged(sender, e);
            this.ddlWardTemp.SelectedValue = objAddress.Ward.ToString();
            this.txtToleTemp.Text = objAddress.Tole;

            this.txttempAdd.Text = objAddress.District.ToString() + objAddress.VDC.ToString() + objAddress.Ward.ToString() + objAddress.Tole;
        }


        //BINDS PHONE
        DataTable ptbl = (DataTable)Session["PersonPhoneTbl"];
        DataRow prow;
        foreach (ATTPersonPhone objPhone in objPerson.LstPersonPhone)
        {
            prow = ptbl.NewRow();
            prow[0] = objPhone.PId;
            prow[1] = objPhone.PType;
            prow[2]=objPhone.PhoneType;
            prow[3] = objPhone.PSNo;
            prow[4] = objPhone.Phone;
            prow[5] = objPhone.Active;
            prow[6] = objPhone.Remarks;
            prow[7] = objPhone.Action = "";

            ptbl.Rows.Add(prow);
        }
        Session["PersonPhoneTbl"] = ptbl;
        this.grdPhone.DataSource = objPerson.LstPersonPhone;
        this.grdPhone.DataBind();

        //BINDS EMAIL
        DataTable etbl = (DataTable)Session["PersonEmailTbl"];
        DataRow erow;
        foreach (ATTPersonEMail objEmail in objPerson.LstPersonEMail)
        {
            erow = etbl.NewRow();
            erow[0] = objEmail.PId;
            erow[1] = objEmail.EType;
            erow[2] = objEmail.EMailType;
            erow[3] = objEmail.ESNo;
            erow[4] = objEmail.EMail;
            erow[5] = objEmail.Active;
            erow[6] = objEmail.Remarks;
            erow[7] = objEmail.Action;
            etbl.Rows.Add(erow);

        }
        Session["PersonEmailTbl"] = etbl;
        this.grdEMail.DataSource = objPerson.LstPersonEMail;
        this.grdEMail.DataBind();

        //BINDS RELATIVES
        DataTable rtbl = (DataTable)Session["RelativesTbl"];
        DataRow rrow;
        foreach (ATTRelatives objRel in objPerson.LstRelatives)
        {
            rrow = rtbl.NewRow();
            rrow[0] = objRel.PId;
            rrow[1] = objRel.RelativeId;
            rrow[2] = objRel.ObjPerson.FirstName;
            rrow[3] = objRel.ObjPerson.MidName;
            rrow[4] = objRel.ObjPerson.SurName;
            rrow[5] = objRel.ObjPerson.FullName;
            rrow[6] = objRel.ObjPerson.Gender;
            rrow[7] = objRel.ObjPerson.RDGender;
            rrow[8] = objRel.ObjPerson.DOB;
            rrow[9] = objRel.ObjPerson.MaritalStatus;
            rrow[10] = objRel.ObjPerson.RDMaritalStatus;
            rrow[11] = objRel.ObjPerson.BirthDistrict;
            rrow[12] = "";
            rrow[13] = objRel.RelationTypeId;
            rrow[14] = objRel.RelationTypeName;
            rrow[15] = objRel.Occupation;
            rrow[16] = objRel.Active;
            rrow[17] = objRel.Action;

            rtbl.Rows.Add(rrow);
            
        }
        Session["RelativesTbl"] = rtbl;
        this.grdRelatives.DataSource = rtbl;// (DataTable)Session["RelativesTbl"];
        this.grdRelatives.DataBind();


        //BINDS PERSON DOCUMENTS
        Session["PersonDocuments"] = objPerson.LstPersonDocuments;
        this.grdPersonDoc.DataSource = objPerson.LstPersonDocuments;
        this.grdPersonDoc.DataBind();


    }


    private void setOrgAsPersonDetails(ATTPerson objPerson, object sender, EventArgs e)
    {
        //Clears Address Contols
        this.ddlDistrict.SelectedValue = "0";
        this.ddlDistrict_SelectedIndexChanged(sender, e);
        this.ddlVDC_SelectedIndexChanged(sender, e);
        this.txtTole.Text = "";

       
        //PERSON DETAILS
        this.txtOrgID.Text = objPerson.PId.ToString();
        this.txtOrgName_RQD.Text = objPerson.FirstName;
        this.txtRegNo.Text = objPerson.RegdNO;
        this.txtPanNo.Text = objPerson.PanNo;
        
        
        //ADDRESSES DETAILS
        //PERMANENT ADDRESS
        List<ATTPersonAddress> AddressLST = objPerson.LstPersonAddress;

        ATTPersonAddress objAddress = AddressLST.Find(delegate(ATTPersonAddress o1)
                                                    {
                                                        return o1.AdTypeId == "P";
                                                    });
        if (objAddress != null)
        {
            this.ddlDistrict.SelectedValue = objAddress.District.ToString();
            this.ddlDistrict_SelectedIndexChanged(sender, e);
            //this.ddlVDC_SelectedIndexChanged(sender, e);
            this.ddlVDC.SelectedValue = objAddress.VDC.ToString();
            this.ddlVDC_SelectedIndexChanged(sender, e);
            this.ddlWard.SelectedValue = objAddress.Ward.ToString();
            this.txtTole.Text = objAddress.Tole;

            this.txtPerAdd.Text = objAddress.District.ToString() + objAddress.VDC.ToString() + objAddress.Ward.ToString() + objAddress.Tole;
        }


        

        //BINDS PHONE
        DataTable ptbl = (DataTable)Session["PersonPhoneTbl"];
        DataRow prow;
        foreach (ATTPersonPhone objPhone in objPerson.LstPersonPhone)
        {
            prow = ptbl.NewRow();
            prow[0] = objPhone.PId;
            prow[1] = objPhone.PType;
            prow[2] = objPhone.PhoneType;
            prow[3] = objPhone.PSNo;
            prow[4] = objPhone.Phone;
            prow[5] = objPhone.Active;
            prow[6] = objPhone.Remarks;
            prow[7] = objPhone.Action = "";

            ptbl.Rows.Add(prow);
        }
        Session["PersonPhoneTbl"] = ptbl;
        this.grdPhone.DataSource = objPerson.LstPersonPhone;
        this.grdPhone.DataBind();

        //BINDS EMAIL
        DataTable etbl = (DataTable)Session["PersonEmailTbl"];
        DataRow erow;
        foreach (ATTPersonEMail objEmail in objPerson.LstPersonEMail)
        {
            erow = etbl.NewRow();
            erow[0] = objEmail.PId;
            erow[1] = objEmail.EType;
            erow[2] = objEmail.EMailType;
            erow[3] = objEmail.ESNo;
            erow[4] = objEmail.EMail;
            erow[5] = objEmail.Active;
            erow[6] = objEmail.Remarks;
            erow[7] = objEmail.Action;
            etbl.Rows.Add(erow);

        }
        Session["PersonEmailTbl"] = etbl;
        this.grdEMail.DataSource = objPerson.LstPersonEMail;
        this.grdEMail.DataBind();

        

    }
    protected void chkIsPrisoned_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsPrisoned.Checked == true)
            pnlPrisonDetails.Enabled = true;
        else
            pnlPrisonDetails.Enabled = false;
    }



    protected void ClearRelativesControl()
    {
        this.txtRelationFirstName_Relative.Text = "";
        this.txtRelationMName.Text = "";
        this.txtRelationLastName_Relative.Text = "";
        this.ddlRelationGender.SelectedValue = "SG";
        this.txtRelationDOB_DTRelative.Text = "";
        this.ddlRelationMarStatus.SelectedValue = "SMS";
        this.ddlRelationHomeDistrict.SelectedValue = "0";
        this.ddlRelationType_Relative.SelectedValue = "0";
        this.txtRelativeOcc.Text = "";
        this.grdRelatives.DataSource = "";
        this.grdRelatives.DataBind();

    }
    protected void grdAppellant_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void grdAppellant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[4].Visible = false;
    }
    protected void grdRespondant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void grdCheckList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        ClearContros(sender, e, true);
    }
    protected void grdAppellant_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTLitigants> LitigantLST = (List<ATTLitigants>)Session["Appellant"];
        if (this.grdAppellant.Rows[e.RowIndex].Cells[4].Text == "A")
        {
            LitigantLST.RemoveAt(e.RowIndex);
        }
        else
        {
            LitigantLST[e.RowIndex].Action = "D";
        }

        this.grdAppellant.DataSource = LitigantLST;
        this.grdAppellant.DataBind();
    }
    protected void btnAddPersonDocuments_Click(object sender, EventArgs e)
    {
        int? issuedFrom=null;

        #region "PERSON DOCUMENT VALIDATION"
        if (this.ddlDocumentType.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "कागज-पत्रको किसिम छान्नुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtDocNo.Text == "")
        {
            this.lblStatusMessage.Text = "कागज-पत्रको नम्बर खालि हुन सक्दैन।";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        if (this.ddlIssuedFrom.SelectedValue != "0")
        {
            issuedFrom =int.Parse( this.ddlIssuedFrom.SelectedValue);
        }

        List<ATTPersonDocuments> PersonDocLST = (List<ATTPersonDocuments>)Session["PersonDocuments"];
        ATTPersonDocuments PersonDocOBJ = new ATTPersonDocuments();
        PersonDocOBJ.PId = 0;
        PersonDocOBJ.DocTypeID = int.Parse(this.ddlDocumentType.SelectedValue);
        PersonDocOBJ.DocTypeName = this.ddlDocumentType.SelectedItem.Text;
        PersonDocOBJ.DocNumber = this.txtDocNo.Text;
        PersonDocOBJ.IssuedFrom = issuedFrom;
        PersonDocOBJ.NepDistName= issuedFrom == null ? "" : this.ddlIssuedFrom.SelectedItem.Text;
        PersonDocOBJ.IssuedOn = this.txtIssuedDate.Text;
        PersonDocOBJ.IssuedBy = this.txtIssuedBy.Text;
        PersonDocOBJ.Active = "Y";// this.chkActivePersonDoc.Checked == true ? "Y" : "N";
        PersonDocOBJ.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        if (this.grdPersonDoc.SelectedIndex == -1)
        {
            PersonDocOBJ.Action = "A";
            PersonDocLST.Add(PersonDocOBJ);

        }
        else
        {
            PersonDocOBJ.Action = this.grdPersonDoc.SelectedRow.Cells[9].Text == "A" ? "A" : "E";
            PersonDocLST[this.grdPersonDoc.SelectedIndex] = PersonDocOBJ;
        }

        
        this.grdPersonDoc.DataSource = PersonDocLST;
        this.grdPersonDoc.DataBind();

        this.grdPersonDoc.SelectedIndex = -1;

        this.ddlDocumentType.SelectedValue = "0";
        this.txtDocNo.Text = "";
        this.ddlIssuedFrom.SelectedValue = "0";
        this.txtIssuedDate.Text = "";
        this.txtIssuedBy.Text = "";
        //this.chkActivePersonDoc.Checked = true;
        

    }
    protected void grdPersonDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTPersonDocuments> PersonDocLST = (List<ATTPersonDocuments>)Session["PersonDocuments"];
        ATTPersonDocuments PersonDocOBJ = PersonDocLST[this.grdPersonDoc.SelectedIndex];

        this.ddlDocumentType.SelectedValue =PersonDocOBJ.DocTypeID.ToString() ;
        this.txtDocNo.Text = PersonDocOBJ.DocNumber;
        this.ddlIssuedFrom.SelectedValue = PersonDocOBJ.IssuedFrom == null ? "0" : PersonDocOBJ.IssuedFrom.ToString();
        this.txtIssuedDate.Text = PersonDocOBJ.IssuedOn;
        this.txtIssuedBy.Text = PersonDocOBJ.IssuedBy;
        //this.chkActivePersonDoc.Checked = PersonDocOBJ.Active == "Y" ? true : false;
        
    }
    protected void grdPersonDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTPersonDocuments> PersonDocLST = (List<ATTPersonDocuments>)Session["PersonDocuments"];
        if (this.grdPersonDoc.Rows[e.RowIndex].Cells[9].Text == "A")
        {
            PersonDocLST.RemoveAt(e.RowIndex);
        }
        else
        {
            PersonDocLST[e.RowIndex].Action = "D";
        }

        this.grdPersonDoc.DataSource = PersonDocLST;
        this.grdPersonDoc.DataBind();
    }
    protected void grdPersonDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
    }
    protected void btnSearchPerson_Click(object sender, EventArgs e)
    {
        List<ATTPersonSearch> lst;
        this.lblSearchx.Text = "";
        this.grdPerson.SelectedIndex = -1;
        if (this.txtSrcFName.Text.Trim() == "" && this.txtSrcMName.Text.Trim() == "" && this.txtSrcSName.Text.Trim() == ""
            && this.ddlSrcGender.SelectedIndex == 0 && this.txtSrcDOB.Text.Trim() == "" && this.ddlSrcMaritalStatus.SelectedIndex == 0
            && this.txtSrcDOB.Text=="" && this.ddlSrcBirthDistrict.SelectedIndex==0 && this.ddlSrcDocumentType.SelectedIndex==0 && this.txtSrcDocumentNo.Text==""  )
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                lst = BLLPersonSearch.SearchPerson(GetFilter());
                this.lblSearchx.Text = lst.Count.ToString() + " records found.";
                this.grdPerson.DataSource = lst;
                this.grdPerson.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }

    private ATTPersonSearch GetFilter()
    {
        ATTPersonSearch PersonSearch = new ATTPersonSearch();
        if (this.txtSrcFName.Text.Trim() != "") PersonSearch.FirstName = this.txtSrcFName.Text.Trim();
        if (this.txtSrcMName.Text.Trim() != "") PersonSearch.MiddleName = this.txtSrcMName.Text.Trim();
        if (this.txtSrcSName.Text.Trim() != "") PersonSearch.SurName = this.txtSrcSName.Text.Trim();
        if (this.ddlSrcGender.SelectedIndex > 0) PersonSearch.Gender = this.ddlSrcGender.SelectedValue;
        if (this.txtSrcDOB.Text.Trim() != "") PersonSearch.DOB = this.txtSrcDOB.Text.Trim();
        if (this.ddlSrcMaritalStatus.SelectedIndex > 0) PersonSearch.MaritalStatus = this.ddlSrcMaritalStatus.SelectedValue;
        if (this.ddlSrcBirthDistrict.SelectedIndex > 0) PersonSearch.BirthDistrict =int.Parse( this.ddlSrcBirthDistrict.SelectedValue);
        if (this.ddlSrcDocumentType.SelectedIndex > 0)
        {
            PersonSearch.DocumentID = int.Parse(this.ddlSrcDocumentType.SelectedValue);
            PersonSearch.DocumentNo=this.txtSrcDocumentNo.Text;
        }
        
        return PersonSearch;
    }
    protected void grdPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
    protected void grdPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool LitigantExists = false;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            if (this.grdPerson.SelectedRow.Cells[0].Text == gvRow.Cells[0].Text)
                LitigantExists = true;
        }
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            if (this.grdPerson.SelectedRow.Cells[0].Text == gvRow.Cells[0].Text)
                LitigantExists = true;
        }

        if (LitigantExists == false)
        {
            ATTPerson PersonOBJ = BLLPerson.GetPersons(double.Parse(this.grdPerson.SelectedRow.Cells[0].Text), "Y");
            this.ddlOrgOrPerson.SelectedValue = PersonOBJ.EntityType;
            this.ddlOrgOrPerson_SelectedIndexChanged(sender, e);
            if (PersonOBJ.EntityType == "P")
                setPersonDetails(PersonOBJ, sender, e);
            else
                setOrgAsPersonDetails(PersonOBJ, sender, e);
                
            if (PersonOBJ.IniType == int.Parse(this.lblIniType.Text) && PersonOBJ.IniUnit == int.Parse(this.lblIniUnit.Text))
            {
                EnablePersonControls(true);
            }
            else
            {
                EnablePersonControls(false);
            }
            Session["IniType"] = PersonOBJ.IniType.ToString();
            Session["IniUnit"]= PersonOBJ.IniUnit.ToString();

        }
        else
        {
            this.lblStatusMessage.Text = "Person Already Exists as Appellant or Respondant";
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void EnablePersonControls(bool enable)
    {
        if (enable == false)
        {
            //PERSON CONTROLS
            this.txtFName.Enabled = false;
            this.txtMName.Enabled = false;
            this.txtSurName.Enabled = false;
            this.txtDOB.Enabled = false;
            this.ddlGender.Enabled = false;
            this.ddlMarStatus.Enabled = false;
            this.ddlCountry.Enabled = false;
            this.ddlBirthDistrict.Enabled = false;
            this.ddlReligion.Enabled = false;
            this.txtIdentityMark.Enabled = false;
            this.ddlLitigantSubType.Enabled = false;

            this.tbContLitInfo.Enabled = false;

            //ORGANIZATION CONTROLS
            this.txtOrgName_RQD.Enabled = false;
            this.txtRegNo.Enabled = false;
            this.txtPanNo.Enabled = false;

            this.ddlOrgDistrict.Enabled = false;
            this.ddlOrgVDC.Enabled = false;
            this.ddlOrgWard.Enabled = false;
            this.txtOrgTole.Enabled = false;

            this.ddlOrgPhoneType_Phone.Enabled = false;
            this.txtOrgPhoneNumber_Phone.Enabled = false;

            this.ddlEMailType_EMail.Enabled = false;
            this.txtOrgEMail_EMail.Enabled = false;

        }
        else
        {
            //PERSON CONTROLS
            this.txtFName.Enabled = true;
            this.txtMName.Enabled = true;
            this.txtSurName.Enabled = true;
            this.txtDOB.Enabled = true;
            this.ddlGender.Enabled = true;
            this.ddlMarStatus.Enabled = true;
            this.ddlCountry.Enabled = true;
            this.ddlBirthDistrict.Enabled = true;
            this.ddlReligion.Enabled = true;
            this.txtIdentityMark.Enabled = true;
            this.ddlLitigantSubType.Enabled = true;

            this.tbContLitInfo.Enabled = true;

            //ORGANIZATION CONTROLS
            this.txtOrgName_RQD.Enabled = true;
            this.txtRegNo.Enabled = true;
            this.txtPanNo.Enabled = true;

            this.ddlOrgDistrict.Enabled = true;
            this.ddlOrgVDC.Enabled = true;
            this.ddlOrgWard.Enabled = true;
            this.txtOrgTole.Enabled = true;

            this.ddlOrgPhoneType_Phone.Enabled = true;
            this.txtOrgPhoneNumber_Phone.Enabled = true;

            this.ddlEMailType_EMail.Enabled = true;
            this.txtOrgEMail_EMail.Enabled = true;

        }
        

    }
    protected void btnAddAmountToBePaid_Click(object sender, EventArgs e)
    {
        if (this.ddlAccountType.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Select Account Type";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtAmount.Text == "")
        {
            this.lblStatusMessage.Text = "Amount Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }




        List<ATTCaseAccountForward> AccountFWDLST = (List<ATTCaseAccountForward>)Session["AccountFWD"];

        if (AccountFWDLST.FindIndex(delegate(ATTCaseAccountForward obj)
                                {
                                    if (this.grdAccountFWD.SelectedIndex == -1)
                                        return obj.AccountTypeID == int.Parse(this.ddlAccountType.SelectedValue);
                                    else
                                        return obj.AccountTypeID == int.Parse(this.ddlAccountType.SelectedValue) && this.grdAccountFWD.SelectedRow.Cells[0].Text != this.ddlAccountType.SelectedValue;

                                }) > -1)
        {
            this.lblStatusMessage.Text = "Account Type and Fee Already Exists";
            this.programmaticModalPopup.Show();
            return;
        }
       

        ATTCaseAccountForward AccountFWDOBJ = new ATTCaseAccountForward(0, int.Parse(this.ddlAccountType.SelectedValue),double.Parse( this.txtAmount.Text), "N");
        AccountFWDOBJ.AccountTypeName = this.ddlAccountType.SelectedItem.Text;
        if (this.grdAccountFWD.SelectedIndex == -1)
        {
            AccountFWDOBJ.Action = "A";
        }
        else
        {
            AccountFWDOBJ.Action = this.grdAccountFWD.SelectedRow.Cells[3].Text == "A" ? "A" : "E";
        }
        AccountFWDOBJ.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        if (this.grdAccountFWD.SelectedIndex == -1)
            AccountFWDLST.Add(AccountFWDOBJ);
        else
            AccountFWDLST[this.grdAccountFWD.SelectedIndex] = AccountFWDOBJ;
        
        this.grdAccountFWD.DataSource = AccountFWDLST;
        this.grdAccountFWD.DataBind();

        this.grdAccountFWD.SelectedIndex = -1;
        this.ddlAccountType.SelectedValue = "0";
        this.txtAmount.Text = "";
        this.ddlAccountType.Enabled = true;

    }
    protected void grdAccountFWD_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlAccountType.Enabled = false;
        List<ATTCaseAccountForward> AccountFWDLST = (List<ATTCaseAccountForward>)Session["AccountFWD"];
        this.ddlAccountType.SelectedValue = AccountFWDLST[this.grdAccountFWD.SelectedIndex].AccountTypeID.ToString();
        this.txtAmount.Text = AccountFWDLST[this.grdAccountFWD.SelectedIndex].TotalAmount.ToString();
    }
    protected void grdAccountFWD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTCaseAccountForward> AccountFWDLST = (List<ATTCaseAccountForward>)Session["AccountFWD"];
        if (this.grdAccountFWD.Rows[e.RowIndex].Cells[3].Text == "A")
        {
            AccountFWDLST.RemoveAt(e.RowIndex);
        }
        else
        {
            AccountFWDLST[e.RowIndex].Action = "D";
        }
        this.grdAccountFWD.DataSource = AccountFWDLST;
        this.grdAccountFWD.DataBind();
    }
    protected void chkForwardToAccount_CheckedChanged(object sender, EventArgs e)
    {
        bool ExistAccountInfo = false;
        if (chkForwardToAccount.Checked == true)
        {
            pnlAccountForward.Visible = true;
        }
        else
        {
            foreach (GridViewRow gvRow in this.grdAccountFWD.Rows)
            {
                if (gvRow.Cells[3].Text != "D")
                {
                    ExistAccountInfo = true;
                }
            }
            if (this.grdAccountFWD.Rows.Count > 0 || ExistAccountInfo==true)
            {
                this.chkForwardToAccount.Checked = true;
                this.lblStatusMessage.Text = "Couldn't Uncheck Forward To Account.<BR>First of All Delete All Account Informations";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                pnlAccountForward.Visible = false;
            }
        }
    }

    void LoadWritDetails()
    {
        List<ATTWritSubject> WritSubjectLST = (List<ATTWritSubject>)Session["WritSubjects"];
        this.ddlWritSubject.DataSource = WritSubjectLST;
        this.ddlWritSubject.DataTextField = "WritSubjectName";
        this.ddlWritSubject.DataValueField = "WritSubjectID";
        this.ddlWritSubject.DataBind();

    }

    protected void ddlWritSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlWritCategory.DataSource = ((List<ATTWritSubject>)Session["WritSubjects"])[this.ddlWritSubject.SelectedIndex].WritCategoryLST;
        this.ddlWritCategory.DataTextField = "WritSubjectCatName";
        this.ddlWritCategory.DataValueField = "WritSubjectCatID";
        this.ddlWritCategory.DataBind();
     
    }
    protected void ddlWritCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlWritTitle.DataSource = ((List<ATTWritSubject>)Session["WritSubjects"])[this.ddlWritSubject.SelectedIndex].WritCategoryLST[this.ddlWritCategory.SelectedIndex].WritCategoryTitleLST;
        this.ddlWritTitle.DataTextField = "WritSubjectCatTitleName";
        this.ddlWritTitle.DataValueField = "WritSubjectCatTitleID";
        this.ddlWritTitle.DataBind();
    }
    protected void ddlWritTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlWritSubTitle.DataSource = ((List<ATTWritSubject>)Session["WritSubjects"])[this.ddlWritSubject.SelectedIndex].WritCategoryLST[this.ddlWritCategory.SelectedIndex].WritCategoryTitleLST[this.ddlWritTitle.SelectedIndex].WritCategorySubTitleLST;
        this.ddlWritSubTitle.DataTextField = "WritSubjectCatSubTitleName";
        this.ddlWritSubTitle.DataValueField = "WritSubjectCatSubTitleID";
        this.ddlWritSubTitle.DataBind();
    }
}
