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
using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;

public partial class MODULES_LJMS_Forms_JudgeEntry : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,1,1") == true)
        {
            Session["OrgID"] = user.OrgID;
            if (this.IsPostBack == false)
            {
                try
                {
                    LoadReligions();
                    LoadCountries();
                    LoadDistricts();
                    LoadDegrees();
                    LoadInstitutions();
                    LoadDocumentsType();
                    LoadPostingType();
                    LoadRelationType();
                    LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                    ClearControls(sender, e);

                    if (Session["EmpID"] != null && Session["EmpFullName"] != null)
                    {
                        this.lblPersonnelInfo.Text = "न्यायाधिश " + Session["EmpFullName"].ToString() + " को बैयक्तिक विवरण";
                        this.txtEmployeeID.Text = Session["EmpID"].ToString();
                        Session["EmpID"] = null;
                        Session.Remove("EmpID");
                        Session.Remove("EmpFullName");
                        LoadEmployeePersonnelDetails(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    Session["EmpID"] = null;
                    Session.Remove("EmpID");
                    this.lblStatusMessage.Text = ex.Message;
                    this.programmaticModalPopup.Show();
                }
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadOrganizationWithChilds(int OrgID)
    {
        List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
        OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));

        this.ddlOrganization_Posting.DataSource = OrganizationList;
        this.ddlOrganization_Posting.DataTextField = "ORGNAME";
        this.ddlOrganization_Posting.DataValueField = "ORGID";
        this.ddlOrganization_Posting.DataBind();
    }

    void LoadEmployeePersonnelDetails(object sender, EventArgs e)
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
        List<ATTEmployeeSearch> lst;
        if (this.txtEmployeeID.Text.Trim() != "") EmployeeSearch.EmpID = double.Parse(this.txtEmployeeID.Text.Trim().ToString());
        try
        {
            lst = BLLEmployeeSearch.SearchEmployee(EmployeeSearch);
            this.txtSymbolNo.Text = lst[0].SymbolNo.ToString().Trim();
            this.txtFName_Rqd.Text = lst[0].FirstName.ToString().Trim();
            this.txtMName.Text = lst[0].MiddleName.ToString().Trim();
            this.txtSurName_Rqd.Text = lst[0].SurName.ToString().Trim();
            this.txtDOB_DT.Text = lst[0].DOB.ToString().Trim();
            if (lst[0].Gender.ToString().Trim() != "")
                this.ddlGender.SelectedValue = lst[0].Gender.ToString().Trim();
            if (lst[0].MaritalStatus.ToString().Trim() != "")
                this.ddlMarStatus.SelectedValue = lst[0].MaritalStatus.ToString().Trim();
            if (lst[0].CountryID != null)
                this.ddlCountry.SelectedValue = lst[0].CountryID.ToString();
            if (lst[0].BirthDistrict != null)
                this.ddlBirthDistrict.SelectedValue = lst[0].BirthDistrict.ToString();
            if (lst[0].ReligionID != null)
                this.ddlReligion.SelectedValue = lst[0].ReligionID.ToString();
            this.txtIdentityMark.Text = lst[0].IdentityMark.ToString().Trim();

            LoadEmployeeAttributes(sender, e, double.Parse(this.txtEmployeeID.Text.Trim()));
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadEmployeeAttributes(object sender, EventArgs e, double empID)
    {
        try
        {
            ATTEmployee objEmployee = BLLEmployee.GetEmployees(empID, "");
            if (objEmployee.ObjPerson.LstPersonAddress.Count > 0)
            {
                foreach (ATTPersonAddress PersonAddress in objEmployee.ObjPerson.LstPersonAddress)
                {
                    if (PersonAddress.AdTypeId == "P")
                    {
                        //ClearAddressControls("P");
                        this.hdnPerAddress.Value = PersonAddress.AdSNo.ToString();
                        this.imgDelPerAddress.Visible = true;
                        if (PersonAddress.District != null)
                        {
                            this.ddlDistrict.SelectedValue = PersonAddress.District.ToString();
                            this.ddlDistrict_SelectedIndexChanged(sender, e);
                            if (PersonAddress.VDC != null)
                            {
                                this.ddlVDC.SelectedValue = PersonAddress.VDC.ToString();
                                this.ddlVDC_SelectedIndexChanged(sender, e);
                                if (PersonAddress.Ward != null)
                                    this.ddlWard.SelectedValue = PersonAddress.Ward.ToString();
                            }
                        }
                        this.txtTole.Text = PersonAddress.Tole.Trim();
                    }
                    else if (PersonAddress.AdTypeId == "T")
                    {
                        //ClearAddressControls("T");
                        this.hdnTempAddress.Value = PersonAddress.AdSNo.ToString();
                        this.imgDelTempAddress.Visible = true;
                        if (PersonAddress.District != null)
                        {
                            this.ddlDistrictTemp.SelectedValue = PersonAddress.District.ToString();
                            this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
                            if (PersonAddress.VDC != null)
                            {
                                this.ddlVDCTemp.SelectedValue = PersonAddress.VDC.ToString();
                                this.ddlVDCTemp_SelectedIndexChanged(sender, e);
                                if (PersonAddress.Ward != null)
                                    this.ddlWardTemp.SelectedValue = PersonAddress.Ward.ToString();
                            }
                        }
                        this.txtToleTemp.Text = PersonAddress.Tole.Trim();
                    }
                }

            }
            if (objEmployee.ObjPerson.LstPersonPhone.Count > 0)
            {
                Session["PhoneTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonPhone);
                this.grdPhone.DataSource = Session["PhoneTbl"];
                this.grdPhone.DataBind();
            }
            if (objEmployee.ObjPerson.LstPersonEMail.Count > 0)
            {
                Session["EMailTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonEMail);
                this.grdEMail.DataSource = Session["EMailTbl"];
                this.grdEMail.DataBind();
            }
            if (objEmployee.ObjPerson.LstPersonDocuments.Count > 0)
            {
                Session["DocumentsTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonDocuments);
                this.grdDocuments.DataSource = Session["DocumentsTbl"];
                this.grdDocuments.DataBind();
            }
            if (objEmployee.ObjPerson.LstPersonQualification.Count > 0)
            {
                Session["QualificationTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonQualification);
                this.grdQualification.DataSource = Session["QualificationTbl"];
                this.grdQualification.DataBind();
            }
            if (objEmployee.ObjPerson.LstPersonTraining.Count > 0)
            {
                Session["TrainingTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonTraining);
                this.grdTraining.DataSource = Session["TrainingTbl"];
                this.grdTraining.DataBind();
            }
            if (objEmployee.LstEmployeeVisits.Count > 0)
            {
                Session["VisitsTbl"] = GenericListToDataTable(objEmployee.LstEmployeeVisits);
                this.grdVisits.DataSource = Session["VisitsTbl"];
                this.grdVisits.DataBind();
            }
            if (objEmployee.LstEmployeeExperience.Count > 0)
            {
                Session["ExperienceTbl"] = GenericListToDataTable(objEmployee.LstEmployeeExperience);
                this.grdExperiences.DataSource = Session["ExperienceTbl"];
                this.grdExperiences.DataBind();
            }

            if (objEmployee.LstEmployeePublication.Count > 0)
            {
                Session["EmpPublication"] = GenericListToDataTable(objEmployee.LstEmployeePublication);
                this.grdPublication.DataSource = Session["EmpPublication"];
                this.grdPublication.DataBind();
            }

            if (objEmployee.LstEmpRelativeBeneficiary.Count > 0)
            {
                Session["RelativesTbl"] = GenericListToDataTable(objEmployee.LstEmpRelativeBeneficiary);
                this.grdEmpRelatives.DataSource = Session["RelativesTbl"];
                this.grdEmpRelatives.DataBind();
            }

            if (objEmployee.LstEmployeePosting.Count > 0)
            {
                Session["PostingTbl"] = GenericListToDataTable(objEmployee.LstEmployeePosting);
                this.grdEmpPostings.DataSource = Session["PostingTbl"];
                this.grdEmpPostings.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadReligions()
    {
        try
        {
            List<ATTReligion> lstReligions;
            lstReligions = BLLReligion.GetReligions(null, 0);
            this.ddlReligion.DataSource = lstReligions;
            this.ddlReligion.DataTextField = "ReligionNepName";
            this.ddlReligion.DataValueField = "ReligionId";
            this.ddlReligion.SelectedIndex = 0;
            this.ddlReligion.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCountries()
    {
        try
        {
            List<ATTCountry> lstCountries;
            lstCountries = BLLCountry.GetCountries(null, 0);

            this.ddlCountry.DataSource = lstCountries;
            this.ddlCountry.DataTextField = "CountryNepName";
            this.ddlCountry.DataValueField = "CountryId";
            this.ddlCountry.SelectedIndex = 0;

            this.ddlVisitCountry_Visit.DataSource = lstCountries;
            this.ddlVisitCountry_Visit.DataTextField = "CountryNepName";
            this.ddlVisitCountry_Visit.DataValueField = "CountryId";
            this.ddlVisitCountry_Visit.SelectedIndex = 0;

            this.ddlCountry.DataBind();
            this.ddlVisitCountry_Visit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

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

            this.ddlSHomeDistrict.DataSource = lstDistricts;
            this.ddlSHomeDistrict.DataTextField = "NepDistName";
            this.ddlSHomeDistrict.DataValueField = "DistCode";
            this.ddlSHomeDistrict.SelectedIndex = 0;
            this.ddlSHomeDistrict.DataBind();

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

            this.ddlDocIssuedFrom.DataSource = lstDistricts;
            this.ddlDocIssuedFrom.DataTextField = "NepDistName";
            this.ddlDocIssuedFrom.DataValueField = "DistCode";
            this.ddlDocIssuedFrom.SelectedIndex = 0;
            this.ddlDocIssuedFrom.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDegrees()
    {
        try
        {
            List<ATTDegree> LstDegreeName;
            LstDegreeName = BLLDegree.GetDegree(null, "Y");
            LstDegreeName.Insert(0, new ATTDegree(0, 0, "छान्नुहोस", ""));
            this.ddlQualDegree_Qual.DataSource = LstDegreeName;
            this.ddlQualDegree_Qual.DataTextField = "DegreeName";
            this.ddlQualDegree_Qual.DataValueField = "DegreeID";
            this.ddlQualDegree_Qual.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadInstitutions()
    {
        this.ddlQualInstitution_Qual.Items.Clear();
        this.ddlQualInstitution_Qual.DataSource = "";
        this.ddlQualInstitution_Qual.DataBind();
        try
        {
            List<ATTInstitution> LstInstitutionName;
            LstInstitutionName = BLLInstitution.GetInstitution(null, "Y");
            this.ddlQualInstitution_Qual.Items.Insert(0, new ListItem("छान्नुहोस"));
            this.ddlQualInstitution_Qual.DataSource = LstInstitutionName;
            this.ddlQualInstitution_Qual.DataTextField = "InstitutionNameBoardCountry";
            this.ddlQualInstitution_Qual.DataValueField = "InstitutionID";
            this.ddlQualInstitution_Qual.DataBind();

            this.ddlTrainInstitution_Training.Items.Insert(0, new ListItem("छान्नुहोस"));
            this.ddlTrainInstitution_Training.DataSource = LstInstitutionName;
            this.ddlTrainInstitution_Training.DataTextField = "InstitutionNameBoardCountry";
            this.ddlTrainInstitution_Training.DataValueField = "InstitutionID";
            this.ddlTrainInstitution_Training.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDocumentsType()
    {
        try
        {
            List<ATTDocumentsType> LstDocumentsType;
            LstDocumentsType = BLLDocumentsType.GetDocumentsType(null);
            LstDocumentsType.Insert(0, new ATTDocumentsType(0, "छान्नुहोस"));
            this.ddlDocType_Documents.DataSource = LstDocumentsType;
            this.ddlDocType_Documents.DataTextField = "DocTypeName";
            this.ddlDocType_Documents.DataValueField = "DocTypeID";
            this.ddlDocType_Documents.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    void LoadPostingType()
    {
        try
        {
            List<ATTPostingType> PostingTypeList = BLLPostingType.GetPostingType(null, "Y");
            PostingTypeList.Insert(0, new ATTPostingType(0, "छान्नुहोस", ""));
            this.ddlPostingType_Posting.DataSource = PostingTypeList;
            this.ddlPostingType_Posting.DataTextField = "POSTINGTYPENAME";
            this.ddlPostingType_Posting.DataValueField = "POSTINGTYPEID";
            this.ddlPostingType_Posting.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadRelationType()
    {
        try
        {
            List<ATTRelationType> lstRelationType;
            lstRelationType = BLLRelationType.GetRelationTypes(null, 0);
            Session["RelationType"] = lstRelationType;
            this.ddlRelationType_Relative.DataSource = lstRelationType;
            this.ddlRelationType_Relative.DataTextField = "RELATIONTYPENAME";
            this.ddlRelationType_Relative.DataValueField = "RELATIONTYPEID";
            this.ddlRelationType_Relative.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
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

        Session["PhoneTbl"] = tbl;
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

        Session["EMailTbl"] = tbl;
    }

    void SetQualificationTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EMPID");
        DataColumn dtCol1 = new DataColumn("SEQNO");
        DataColumn dtCol2 = new DataColumn("SUBJECT");
        DataColumn dtCol3 = new DataColumn("DEGREEID");
        DataColumn dtCol4 = new DataColumn("DEGREENAME");
        DataColumn dtCol5 = new DataColumn("INSTITUTIONID");
        DataColumn dtCol6 = new DataColumn("INSTITUTIONNAME");
        DataColumn dtCol7 = new DataColumn("FROMDATE");
        DataColumn dtCol8 = new DataColumn("TODATE");
        DataColumn dtCol9 = new DataColumn("GRADE");
        DataColumn dtCol10 = new DataColumn("PERCENTAGE");
        DataColumn dtCol11 = new DataColumn("REMARKS");
        DataColumn dtCol12 = new DataColumn("ACTION");

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
        Session["QualificationTbl"] = tbl;

    }

    void SetTrainingTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EMPID");
        DataColumn dtCol1 = new DataColumn("SEQNO");
        DataColumn dtCol2 = new DataColumn("SUBJECT");
        DataColumn dtCol3 = new DataColumn("CERTIFICATENAME");
        DataColumn dtCol4 = new DataColumn("INSTITUTIONID");
        DataColumn dtCol5 = new DataColumn("INSTITUTIONNAME");
        DataColumn dtCol6 = new DataColumn("FROMDATE");
        DataColumn dtCol7 = new DataColumn("TODATE");
        DataColumn dtCol8 = new DataColumn("GRADE");
        DataColumn dtCol9 = new DataColumn("PERCENTAGE");
        DataColumn dtCol10 = new DataColumn("REMARKS");
        DataColumn dtCol11 = new DataColumn("ACTION");


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

        Session["TrainingTbl"] = tbl;

    }

    void SetVisitsTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EMPID");
        DataColumn dtCol1 = new DataColumn("SEQNO");
        DataColumn dtCol2 = new DataColumn("LOCATION");
        DataColumn dtCol3 = new DataColumn("COUNTRY");
        DataColumn dtCol4 = new DataColumn("COUNTRYNEPNAME");
        DataColumn dtCol5 = new DataColumn("FROMDATE");
        DataColumn dtCol6 = new DataColumn("TODATE");
        DataColumn dtCol7 = new DataColumn("PURPOSE");
        DataColumn dtCol8 = new DataColumn("REMARKS");
        DataColumn dtCol9 = new DataColumn("ACTION");


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

        Session["VisitsTbl"] = tbl;
    }

    void SetExperienceTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EMPID");
        DataColumn dtCol1 = new DataColumn("SEQNO");
        DataColumn dtCol2 = new DataColumn("FROMDATE");
        DataColumn dtCol3 = new DataColumn("TODATE");
        DataColumn dtCol4 = new DataColumn("POSTINGLOCATION");
        DataColumn dtCol5 = new DataColumn("JOBLOCATION");
        DataColumn dtCol6 = new DataColumn("CLASSIFICATION");
        DataColumn dtCol7 = new DataColumn("REMARKS");
        DataColumn dtCol8 = new DataColumn("ACTION");


        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);
        tbl.Columns.Add(dtCol6);
        tbl.Columns.Add(dtCol7);
        tbl.Columns.Add(dtCol8);

        Session["ExperienceTbl"] = tbl;
    }

    void SetDocumentsTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PID");
        DataColumn dtCol1 = new DataColumn("DOCTYPEID");
        DataColumn dtCol2 = new DataColumn("DOCTYPENAME");
        DataColumn dtCol3 = new DataColumn("DOCNUMBER");
        DataColumn dtCol4 = new DataColumn("ISSUEDFROM");
        DataColumn dtCol5 = new DataColumn("NEPDISTNAME");
        DataColumn dtCol6 = new DataColumn("ISSUEDON");
        DataColumn dtCol7 = new DataColumn("ISSUEDBY");
        DataColumn dtCol8 = new DataColumn("ACTIVE");
        DataColumn dtCol9 = new DataColumn("ACTION");


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

        Session["DocumentsTbl"] = tbl;

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
        DataColumn dtCol16 = new DataColumn("ISBENEFICIARY");
        DataColumn dtCol17 = new DataColumn("ISACTIVE");
        DataColumn dtCol18 = new DataColumn("ACTION");
        DataColumn dtCol21 = new DataColumn("ISBENEFICIARY");
        DataColumn dtCol22 = new DataColumn("ISACTIVE");

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
        tbl.Columns.Add(dtCol18);
        //tbl.Columns.Add(dtCol21);
        //tbl.Columns.Add(dtCol22);

        Session["RelativesTbl"] = tbl;

    }

    void SetPostingTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("EMPID");
        DataColumn dtCol1 = new DataColumn("ORGID");
        DataColumn dtCol2 = new DataColumn("ORGNAME");
        DataColumn dtCol3 = new DataColumn("DESID");
        DataColumn dtCol4 = new DataColumn("DESNAME");
        DataColumn dtCol5 = new DataColumn("POSTID");
        DataColumn dtCol6 = new DataColumn("CREATEDDATE");
        DataColumn dtCol7 = new DataColumn("POSTNAME");
        DataColumn dtCol8 = new DataColumn("POSTINGTYPEID");
        DataColumn dtCol9 = new DataColumn("POSTINGTYPENAME");
        DataColumn dtCol10 = new DataColumn("FROMDATE");
        DataColumn dtCol11 = new DataColumn("TODATE");
        DataColumn dtCol12 = new DataColumn("DECISIONDATE");
        DataColumn dtCol13 = new DataColumn("LEAVEDATE");
        DataColumn dtCol14 = new DataColumn("JOININGDATE");
        DataColumn dtCol15 = new DataColumn("ACTION");

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

        Session["PostingTbl"] = tbl;
    }

    protected void btnPhonePlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpPhoneTbl = (DataTable)Session["PhoneTbl"];

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
            if ((CheckNullString(oldrow[7].ToString()) == "E") || (CheckNullString(oldrow[7].ToString()) == ""))
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
        SetGridColor(7, 9, grdPhone);
    }

    protected void btnEMailPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpEMailTbl = (DataTable)Session["EMailTbl"];

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
            if ((CheckNullString(oldrow[7].ToString()) == "E") || (CheckNullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlEMailType_EMail.SelectedIndex = 0;
        this.txtEMail_EMail.Text = "";
        this.grdEMail.DataSource = tmpEMailTbl;
        this.grdEMail.DataBind();
        this.grdEMail.SelectedIndex = -1;
        SetGridColor(7, 9, grdEMail);
    }

    protected void btnQualificationPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (this.txtQualSubject_Qual.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter The Subject.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlQualDegree_Qual.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Select Degree.";
            this.programmaticModalPopup.Show();
            return;
        }

        DataTable tmpQualificationTbl = (DataTable)Session["QualificationTbl"];
        if (grdQualification.SelectedIndex == -1)
        {
            DataRow row = tmpQualificationTbl.NewRow();
            row[1] = 0;
            row[2] = this.txtQualSubject_Qual.Text.Trim();
            row[3] = (this.ddlQualDegree_Qual.SelectedIndex > 0 ? this.ddlQualDegree_Qual.SelectedValue : "");
            row[4] = (this.ddlQualDegree_Qual.SelectedIndex > 0 ? this.ddlQualDegree_Qual.SelectedItem.Text.Trim() : "");
            row[5] = (this.ddlQualInstitution_Qual.SelectedIndex > 0 ? this.ddlQualInstitution_Qual.SelectedValue : "");
            row[6] = (this.ddlQualInstitution_Qual.SelectedIndex > 0 ? this.ddlQualInstitution_Qual.SelectedItem.Text.Trim() : "");
            row[7] = this.txtQualFromDate_UDTQual.Text.Trim();
            row[8] = this.txtQualToDate_UDTQual.Text.Trim();
            row[9] = this.txtQualGrade.Text.Trim();
            row[10] = this.txtQualPercentage.Text.Trim();
            row[11] = this.txtQualRemarks.Text.Trim();
            row[12] = "A";
            tmpQualificationTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpQualificationTbl.Rows[this.grdQualification.SelectedIndex];
            oldrow[2] = this.txtQualSubject_Qual.Text.Trim();
            oldrow[3] = (this.ddlQualDegree_Qual.SelectedIndex > 0 ? this.ddlQualDegree_Qual.SelectedValue : "");
            oldrow[4] = (this.ddlQualDegree_Qual.SelectedIndex > 0 ? this.ddlQualDegree_Qual.SelectedItem.Text.Trim() : "");
            oldrow[5] = (this.ddlQualInstitution_Qual.SelectedIndex > 0 ? this.ddlQualInstitution_Qual.SelectedValue : "");
            oldrow[6] = (this.ddlQualInstitution_Qual.SelectedIndex > 0 ? this.ddlQualInstitution_Qual.SelectedItem.Text.Trim() : "");
            oldrow[7] = this.txtQualFromDate_UDTQual.Text.Trim();
            oldrow[8] = this.txtQualToDate_UDTQual.Text.Trim();
            oldrow[9] = this.txtQualGrade.Text.Trim();
            oldrow[10] = this.txtQualPercentage.Text.Trim();
            oldrow[11] = this.txtQualRemarks.Text.Trim();
            if ((CheckNullString(oldrow[12].ToString()) == "E") || (CheckNullString(oldrow[12].ToString()) == ""))
                oldrow[12] = "E";
            else
                oldrow[12] = "A";
        }
        this.txtQualSubject_Qual.Text = "";
        this.ddlQualDegree_Qual.SelectedIndex = 0;
        this.ddlQualInstitution_Qual.SelectedIndex = 0;
        this.txtQualFromDate_UDTQual.Text = "";
        this.txtQualToDate_UDTQual.Text = "";
        this.txtQualGrade.Text = "";
        this.txtQualPercentage.Text = "";
        this.txtQualRemarks.Text = "";

        this.grdQualification.DataSource = tmpQualificationTbl;
        this.grdQualification.DataBind();
        this.grdQualification.SelectedIndex = -1;
        SetGridColor(12, 14, grdQualification);
    }

    protected void btnTrainPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (this.txtTrainSubject_Training.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter The Subject.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtTrainCertificate_Training.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter Training Certificate Name.";
            this.programmaticModalPopup.Show();
            return;
        }

        DataTable tmpTrainingTbl = (DataTable)Session["TrainingTbl"];
        if (grdTraining.SelectedIndex == -1)
        {
            DataRow row = tmpTrainingTbl.NewRow();
            row[1] = 0;
            row[2] = this.txtTrainSubject_Training.Text.Trim();
            row[3] = this.txtTrainCertificate_Training.Text.Trim();
            row[4] = (this.ddlTrainInstitution_Training.SelectedIndex > 0 ? this.ddlTrainInstitution_Training.SelectedValue : "");
            row[5] = (this.ddlTrainInstitution_Training.SelectedIndex > 0 ? this.ddlTrainInstitution_Training.SelectedItem.Text.Trim() : "");
            row[6] = this.txtTrainFromDate_UDTTraining.Text.Trim();
            row[7] = this.txtTrainToDate_UDTTraining.Text.Trim();
            row[8] = this.txtTrainGrade.Text.Trim();
            row[9] = this.txtTrainPercentage.Text.Trim();
            row[10] = this.txtTrainRemarks.Text.Trim();
            row[11] = "A";
            tmpTrainingTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpTrainingTbl.Rows[this.grdTraining.SelectedIndex];
            oldrow[2] = this.txtTrainSubject_Training.Text.Trim();
            oldrow[3] = this.txtTrainCertificate_Training.Text.Trim();
            oldrow[4] = (this.ddlTrainInstitution_Training.SelectedIndex > 0 ? this.ddlTrainInstitution_Training.SelectedValue : "");
            oldrow[5] = (this.ddlTrainInstitution_Training.SelectedIndex > 0 ? this.ddlTrainInstitution_Training.SelectedItem.Text.Trim() : "");
            oldrow[6] = this.txtTrainFromDate_UDTTraining.Text.Trim();
            oldrow[7] = this.txtTrainToDate_UDTTraining.Text.Trim();
            oldrow[8] = this.txtTrainGrade.Text.Trim();
            oldrow[9] = this.txtTrainPercentage.Text.Trim();
            oldrow[10] = this.txtTrainRemarks.Text.Trim();
            if ((CheckNullString(oldrow[11].ToString()) == "E") || (CheckNullString(oldrow[11].ToString()) == ""))
                oldrow[11] = "E";
            else
                oldrow[11] = "A";
        }
        this.txtTrainSubject_Training.Text = "";
        this.txtTrainCertificate_Training.Text = "";
        this.ddlTrainInstitution_Training.SelectedIndex = 0;
        this.txtTrainFromDate_UDTTraining.Text = "";
        this.txtTrainToDate_UDTTraining.Text = "";
        this.txtTrainGrade.Text = "";
        this.txtTrainPercentage.Text = "";
        this.txtTrainRemarks.Text = "";

        this.grdTraining.DataSource = tmpTrainingTbl;
        this.grdTraining.DataBind();
        this.grdTraining.SelectedIndex = -1;
        SetGridColor(11, 13, grdTraining);

    }

    protected void btnVisitsPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (this.txtVisitFromDate_URDTVisit.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter Visit From Date.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtVisitPurpose_Visit.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter Visit Purpose.";
            this.programmaticModalPopup.Show();
            return;
        }

        DataTable tmpVisitsTbl = (DataTable)Session["VisitsTbl"];
        if (grdVisits.SelectedIndex == -1)
        {
            DataRow row = tmpVisitsTbl.NewRow();
            row[1] = 0;
            row[2] = this.txtVisitLocation_Visit.Text.Trim();
            row[3] = (this.ddlVisitCountry_Visit.SelectedIndex > 0 ? this.ddlVisitCountry_Visit.SelectedValue : "");
            row[4] = (this.ddlVisitCountry_Visit.SelectedIndex > 0 ? this.ddlVisitCountry_Visit.SelectedItem.Text.Trim() : "");
            row[5] = this.txtVisitFromDate_URDTVisit.Text.Trim();
            row[6] = this.txtVisitToDate_UDTVisit.Text.Trim();
            row[7] = this.txtVisitPurpose_Visit.Text.Trim();
            row[8] = this.txtVisitRemarks.Text.Trim();
            row[9] = "A";
            tmpVisitsTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpVisitsTbl.Rows[this.grdVisits.SelectedIndex];
            oldrow[2] = this.txtVisitLocation_Visit.Text.Trim();
            oldrow[3] = (this.ddlVisitCountry_Visit.SelectedIndex > 0 ? this.ddlVisitCountry_Visit.SelectedValue : "");
            oldrow[4] = (this.ddlVisitCountry_Visit.SelectedIndex > 0 ? this.ddlVisitCountry_Visit.SelectedItem.Text.Trim() : "");
            oldrow[5] = this.txtVisitFromDate_URDTVisit.Text.Trim();
            oldrow[6] = this.txtVisitToDate_UDTVisit.Text.Trim();
            oldrow[7] = this.txtVisitPurpose_Visit.Text.Trim();
            oldrow[8] = this.txtVisitRemarks.Text.Trim();
            if ((CheckNullString(oldrow[9].ToString()) == "E") || (CheckNullString(oldrow[9].ToString()) == ""))
                oldrow[9] = "E";
            else
                oldrow[9] = "A";
        }
        this.txtVisitLocation_Visit.Text = "";
        this.ddlVisitCountry_Visit.SelectedIndex = 0;
        this.txtVisitFromDate_URDTVisit.Text = "";
        this.txtVisitToDate_UDTVisit.Text = "";
        this.txtVisitPurpose_Visit.Text = "";
        this.txtVisitRemarks.Text = "";
        this.grdVisits.DataSource = tmpVisitsTbl;
        this.grdVisits.DataBind();
        this.grdVisits.SelectedIndex = -1;
        SetGridColor(9, 11, grdVisits);
    }

    protected void btnExperiencesPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (this.txtExpPostingLocation_Experience.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter Posting Location.";
            this.programmaticModalPopup.Show();
            return;
        }

        DataTable tmpExperienceTbl = (DataTable)Session["ExperienceTbl"];
        if (grdExperiences.SelectedIndex == -1)
        {
            DataRow row = tmpExperienceTbl.NewRow();
            row[1] = 0;
            row[2] = this.txtExpFromDate_UDTExperience.Text.Trim();
            row[3] = this.txtExpToDate_UDTExperience.Text.Trim();
            row[4] = this.txtExpPostingLocation_Experience.Text.Trim();
            row[5] = this.txtExpJobLocation_Experience.Text.Trim();
            row[6] = (this.ddlExpClassification.SelectedIndex > 0 ? this.ddlExpClassification.SelectedItem.Text : "");
            row[7] = this.txtExpRemarks.Text.Trim();
            row[8] = "A";
            tmpExperienceTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpExperienceTbl.Rows[this.grdExperiences.SelectedIndex];
            oldrow[2] = this.txtExpFromDate_UDTExperience.Text.Trim();
            oldrow[3] = this.txtExpToDate_UDTExperience.Text.Trim();
            oldrow[4] = this.txtExpPostingLocation_Experience.Text.Trim();
            oldrow[5] = this.txtExpJobLocation_Experience.Text.Trim();
            oldrow[6] = (this.ddlExpClassification.SelectedIndex > 0 ? this.ddlExpClassification.SelectedItem.Text : "");
            oldrow[7] = this.txtExpRemarks.Text.Trim();
            if ((CheckNullString(oldrow[8].ToString()) == "E") || (CheckNullString(oldrow[8].ToString()) == ""))
                oldrow[8] = "E";
            else
                oldrow[8] = "A";
        }

        this.txtExpFromDate_UDTExperience.Text = "";
        this.txtExpToDate_UDTExperience.Text = "";
        this.txtExpRemarks.Text = "";
        this.txtExpPostingLocation_Experience.Text = "";
        this.txtExpJobLocation_Experience.Text = "";
        this.ddlExpClassification.SelectedIndex = 0;
        this.txtVisitLocation_Visit.Text = "";
        this.grdExperiences.DataSource = tmpExperienceTbl;
        this.grdExperiences.DataBind();
        this.grdExperiences.SelectedIndex = -1;
        SetGridColor(8, 10, grdExperiences);

    }

    protected void btnDocumentsPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (this.ddlDocType_Documents.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Select Document Type.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtDocNumber_Documents.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Enter Document Number.";
            this.programmaticModalPopup.Show();
            return;
        }

        DataTable tmpDocumentTbl = (DataTable)Session["DocumentsTbl"];
        if (grdDocuments.SelectedIndex == -1)
        {
            DataRow row = tmpDocumentTbl.NewRow();
            row[1] = (this.ddlDocType_Documents.SelectedIndex > 0 ? this.ddlDocType_Documents.SelectedValue : "");
            row[2] = (this.ddlDocType_Documents.SelectedIndex > 0 ? this.ddlDocType_Documents.SelectedItem.Text : "");
            row[3] = this.txtDocNumber_Documents.Text.Trim();
            row[4] = (this.ddlDocIssuedFrom.SelectedIndex > 0 ? this.ddlDocIssuedFrom.SelectedValue : "");
            row[5] = (this.ddlDocIssuedFrom.SelectedIndex > 0 ? this.ddlDocIssuedFrom.SelectedItem.Text : "");
            row[6] = this.txtDocIssuedOn_UDTDocuments.Text.Trim();
            row[7] = this.txtDocIssuedBy.Text.Trim();
            row[8] = "Y";
            row[9] = "A";
            tmpDocumentTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpDocumentTbl.Rows[this.grdDocuments.SelectedIndex];
            oldrow[1] = (this.ddlDocType_Documents.SelectedIndex > 0 ? this.ddlDocType_Documents.SelectedValue : "");
            oldrow[2] = (this.ddlDocType_Documents.SelectedIndex > 0 ? this.ddlDocType_Documents.SelectedItem.Text : "");
            oldrow[3] = this.txtDocNumber_Documents.Text.Trim();
            oldrow[4] = (this.ddlDocIssuedFrom.SelectedIndex > 0 ? this.ddlDocIssuedFrom.SelectedValue : "");
            oldrow[5] = (this.ddlDocIssuedFrom.SelectedIndex > 0 ? this.ddlDocIssuedFrom.SelectedItem.Text : "");
            oldrow[6] = this.txtDocIssuedOn_UDTDocuments.Text.Trim();
            oldrow[7] = this.txtDocIssuedBy.Text.Trim();
            oldrow[8] = "Y";
            if ((CheckNullString(oldrow[9].ToString()) == "E") || (CheckNullString(oldrow[9].ToString()) == ""))
                oldrow[9] = "E";
            else
                oldrow[9] = "A";
        }

        this.ddlDocType_Documents.SelectedIndex = 0;
        this.txtDocNumber_Documents.Text = "";
        this.ddlDocIssuedFrom.SelectedIndex = 0;
        this.txtDocIssuedOn_UDTDocuments.Text = "";
        this.txtDocIssuedBy.Text = "";

        this.grdDocuments.DataSource = tmpDocumentTbl;
        this.grdDocuments.DataBind();
        this.grdDocuments.SelectedIndex = -1;
        SetGridColor(9, 11, grdDocuments);

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

        if (this.hdnRelativeID.Value.ToString() == this.txtEmployeeID.Text.Trim())
        {
            this.lblStatusMessage.Text = "कर्मचारी आफै नातेदार हुन सक्दैन. कृपया अर्को नातेदार राख्नुहोस.";
            this.programmaticModalPopup.Show();
            return;
        }

        bool blnExists = false;
        if (this.hdnRelativeID.Value.ToString() != "0")
        {
            foreach (GridViewRow row in this.grdEmpRelatives.Rows)
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
            foreach (GridViewRow row in this.grdEmpRelatives.Rows)
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
        if (grdEmpRelatives.SelectedIndex == -1)
        {
            strFullName = this.txtRelationFirstName_Relative.Text.Trim();
            strFullName += (this.txtRelationMName.Text.Trim() == "" ? "" : " " + this.txtRelationMName.Text.Trim());
            strFullName += (this.txtRelationLastName_Relative.Text.Trim() == "" ? "" : " " + this.txtRelationLastName_Relative.Text.Trim());

            DataRow row = tmpRelativesTbl.NewRow();
            row[1] = this.hdnRelativeID.Value.ToString();
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
            row[18] = "A";

            tmpRelativesTbl.Rows.Add(row);
        }
        else
        {
            strFullName = this.txtRelationFirstName_Relative.Text.Trim();
            strFullName += (this.txtRelationMName.Text.Trim() == "" ? "" : " " + this.txtRelationMName.Text.Trim());
            strFullName += (this.txtRelationLastName_Relative.Text.Trim() == "" ? "" : " " + this.txtRelationLastName_Relative.Text.Trim());

            DataRow oldrow = tmpRelativesTbl.Rows[this.grdEmpRelatives.SelectedIndex];
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
            if ((CheckNullString(oldrow[18].ToString()) == "E") || (CheckNullString(oldrow[18].ToString()) == ""))
                oldrow[18] = "E";
            else
                oldrow[18] = "A";
        }
        ClearRelativeControls();
        this.grdEmpRelatives.DataSource = tmpRelativesTbl;
        this.grdEmpRelatives.DataBind();
        this.grdEmpRelatives.SelectedIndex = -1;
        //SetGridColor();
    }

    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdPhone.SelectedIndex > -1)
        {
            if (this.grdPhone.Rows[this.grdPhone.SelectedIndex].Cells[7].Text != "D")
            {
                row = this.grdPhone.SelectedRow;
                this.ddlPhoneType_Phone.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
                this.txtPhoneNumber_Phone.Text = CheckNullString(row.Cells[4].Text);
                //this.txtPhoneRemarks.Text = CheckNullString(row.Cells[6].Text);
            }
            else
                this.grdPhone.SelectedIndex = -1;
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
                this.ddlEMailType_EMail.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
                this.txtEMail_EMail.Text = CheckNullString(row.Cells[4].Text);
            }
            else
                this.grdEMail.SelectedIndex = -1;
        }
    }

    protected void grdQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdQualification.SelectedIndex > -1)
        {
            if (this.grdQualification.Rows[this.grdQualification.SelectedIndex].Cells[12].Text != "D")
            {
                row = this.grdQualification.SelectedRow;
                this.txtQualSubject_Qual.Text = CheckNullString(row.Cells[2].Text.ToString());
                if (CheckNullString(row.Cells[3].Text.ToString()) != "")
                    this.ddlQualDegree_Qual.SelectedValue = CheckNullString(row.Cells[3].Text.ToString());
                if (CheckNullString(row.Cells[5].Text.ToString()) != "")
                    this.ddlQualInstitution_Qual.SelectedValue = CheckNullString(row.Cells[5].Text.ToString());
                this.txtQualFromDate_UDTQual.Text = CheckNullString(row.Cells[7].Text.ToString());
                this.txtQualToDate_UDTQual.Text = CheckNullString(row.Cells[8].Text.ToString());
                this.txtQualGrade.Text = CheckNullString(row.Cells[9].Text.ToString());
                this.txtQualPercentage.Text = CheckNullString(row.Cells[10].Text.ToString());
                this.txtQualRemarks.Text = CheckNullString(row.Cells[11].Text.ToString());

            }
            else
                this.grdQualification.SelectedIndex = -1;
        }

    }

    protected void grdTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdTraining.SelectedIndex > -1)
        {
            if (this.grdTraining.Rows[this.grdTraining.SelectedIndex].Cells[11].Text != "D")
            {
                row = this.grdTraining.SelectedRow;
                this.txtTrainSubject_Training.Text = CheckNullString(row.Cells[2].Text.ToString());
                this.txtTrainCertificate_Training.Text = CheckNullString(row.Cells[3].Text.ToString());
                if (CheckNullString(row.Cells[4].Text.ToString()) != "")
                    this.ddlTrainInstitution_Training.SelectedValue = CheckNullString(row.Cells[4].Text.ToString());
                this.txtTrainFromDate_UDTTraining.Text = CheckNullString(row.Cells[6].Text.ToString());
                this.txtTrainToDate_UDTTraining.Text = CheckNullString(row.Cells[7].Text.ToString());
                this.txtTrainGrade.Text = CheckNullString(row.Cells[8].Text.ToString());
                this.txtTrainPercentage.Text = CheckNullString(row.Cells[9].Text.ToString());
                this.txtTrainRemarks.Text = CheckNullString(row.Cells[10].Text.ToString());

            }
            else
                this.grdTraining.SelectedIndex = -1;
        }
    }

    protected void grdVisits_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdVisits.SelectedIndex > -1)
        {
            if (this.grdVisits.Rows[this.grdVisits.SelectedIndex].Cells[9].Text != "D")
            {
                row = this.grdVisits.SelectedRow;
                this.txtVisitLocation_Visit.Text = CheckNullString(row.Cells[2].Text.ToString());
                if (CheckNullString(row.Cells[3].Text.ToString()) != "")
                    this.ddlVisitCountry_Visit.SelectedValue = CheckNullString(row.Cells[3].Text.ToString());
                this.txtVisitFromDate_URDTVisit.Text = CheckNullString(row.Cells[5].Text.ToString());
                this.txtVisitToDate_UDTVisit.Text = CheckNullString(row.Cells[6].Text.ToString());
                this.txtVisitPurpose_Visit.Text = CheckNullString(row.Cells[7].Text.ToString());
                this.txtVisitRemarks.Text = CheckNullString(row.Cells[8].Text.ToString());
            }
            else
                this.grdVisits.SelectedIndex = -1;
        }
    }

    protected void grdExperiences_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdExperiences.SelectedIndex > -1)
        {
            if (this.grdExperiences.Rows[this.grdExperiences.SelectedIndex].Cells[8].Text != "D")
            {
                row = this.grdExperiences.SelectedRow;
                this.txtExpFromDate_UDTExperience.Text = CheckNullString(row.Cells[2].Text.ToString());
                this.txtExpToDate_UDTExperience.Text = CheckNullString(row.Cells[3].Text.ToString());
                this.txtExpPostingLocation_Experience.Text = CheckNullString(row.Cells[4].Text.ToString());
                this.txtExpJobLocation_Experience.Text = CheckNullString(row.Cells[5].Text.ToString());
                if (CheckNullString(row.Cells[6].Text.ToString()) != "")
                    this.ddlExpClassification.SelectedValue = CheckNullString(row.Cells[6].Text.ToString());
                this.txtExpRemarks.Text = CheckNullString(row.Cells[7].Text.ToString());
            }
            else
                this.grdExperiences.SelectedIndex = -1;
        }

    }

    protected void grdDocuments_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdDocuments.SelectedIndex > -1)
        {
            if (this.grdDocuments.Rows[this.grdDocuments.SelectedIndex].Cells[9].Text != "D")
            {
                row = this.grdDocuments.SelectedRow;
                if (CheckNullString(row.Cells[1].Text.ToString()) != "")
                    this.ddlDocType_Documents.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
                this.txtDocNumber_Documents.Text = CheckNullString(row.Cells[3].Text.ToString());
                if (CheckNullString(row.Cells[4].Text.ToString()) != "")
                    this.ddlDocIssuedFrom.SelectedValue = CheckNullString(row.Cells[4].Text.ToString());
                this.txtDocIssuedOn_UDTDocuments.Text = CheckNullString(row.Cells[6].Text.ToString());
                this.txtDocIssuedBy.Text = CheckNullString(row.Cells[7].Text.ToString());
            }
            else
                this.grdDocuments.SelectedIndex = -1;
        }

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

    protected void grdQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[12].Visible = false;
    }

    protected void grdTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[11].Visible = false;
    }

    protected void grdVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[9].Visible = false;
    }

    protected void grdExperiences_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void grdDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
    }

    protected void grdEMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;

        try
        {
            DataTable tmpTbl = (DataTable)Session["EMailTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdEMail.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdEMail.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdEMail.DataSource = tmpTbl;
            grdEMail.DataBind();

            SetGridColor(7, 9, grdEMail);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["PhoneTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdPhone.Rows[i].Cells[7].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdPhone.Rows[i].Cells[7].Text == "D")
                tmpTbl.Rows[i][7] = "";
            else
                tmpTbl.Rows[i][7] = "D";

            grdPhone.DataSource = tmpTbl;
            grdPhone.DataBind();
            SetGridColor(7, 9, grdPhone);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    protected void grdQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["QualificationTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdQualification.Rows[i].Cells[12].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdQualification.Rows[i].Cells[12].Text == "D")
                tmpTbl.Rows[i][12] = "";
            else
                tmpTbl.Rows[i][12] = "D";

            grdQualification.DataSource = tmpTbl;
            grdQualification.DataBind();
            SetGridColor(12, 14, grdQualification);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["TrainingTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdTraining.Rows[i].Cells[11].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdTraining.Rows[i].Cells[11].Text == "D")
                tmpTbl.Rows[i][11] = "";
            else
                tmpTbl.Rows[i][11] = "D";

            grdTraining.DataSource = tmpTbl;
            grdTraining.DataBind();
            SetGridColor(11, 13, grdTraining);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdVisits_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["VisitsTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdVisits.Rows[i].Cells[9].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdVisits.Rows[i].Cells[9].Text == "D")
                tmpTbl.Rows[i][9] = "";
            else
                tmpTbl.Rows[i][9] = "D";

            grdVisits.DataSource = tmpTbl;
            grdVisits.DataBind();

            SetGridColor(9, 11, grdVisits);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdExperiences_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["ExperienceTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdExperiences.Rows[i].Cells[8].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdExperiences.Rows[i].Cells[8].Text == "D")
                tmpTbl.Rows[i][8] = "";
            else
                tmpTbl.Rows[i][8] = "D";

            grdExperiences.DataSource = tmpTbl;
            grdExperiences.DataBind();
            SetGridColor(8, 10, grdExperiences);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    protected void grdDocuments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        try
        {
            DataTable tmpTbl = (DataTable)Session["DocumentsTbl"];
            DataRow row = tmpTbl.Rows[i];
            if (grdDocuments.Rows[i].Cells[9].Text == "A")
                tmpTbl.Rows.RemoveAt(i);

            else if (grdDocuments.Rows[i].Cells[9].Text == "D")
                tmpTbl.Rows[i][9] = "";
            else
                tmpTbl.Rows[i][9] = "D";

            grdDocuments.DataSource = tmpTbl;
            grdDocuments.DataBind();
            SetGridColor(9, 11, grdDocuments);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    protected void ddlOrganization_Posting_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOrganizationAvailablePosts(int.Parse(this.ddlOrganization_Posting.SelectedValue.ToString()));
    }

    void LoadOrganizationAvailablePosts(int OrgID)
    {
        this.ddlAvailablePost_Posting.DataSource = "";
        this.ddlAvailablePost_Posting.Items.Clear();
        this.ddlAvailablePost_Posting.DataBind();
        this.ddlAvailablePost_Posting.Enabled = false;
        this.ddlPost_Posting.DataSource = "";
        this.ddlPost_Posting.Items.Clear();

        Session["OrgAvailableDesgPost"] = "";
        List<ATTPost> DispOrgAvailableDesgPost = new List<ATTPost>();
        try
        {
            if (this.ddlOrganization_Posting.SelectedIndex > 0)
            {
                List<ATTPost> OrgAvailableDesgPost = BLLPost.GetOrgAvailableDesgPost(int.Parse(this.ddlOrganization_Posting.SelectedValue.ToString()), null, "CO", "J");
                Session["OrgAvailableDesgPost"] = OrgAvailableDesgPost;
                int intDesID = 0;
                foreach (ATTPost lstPost in OrgAvailableDesgPost)
                {
                    if (intDesID != lstPost.DesID)
                        DispOrgAvailableDesgPost.Add(lstPost);
                    intDesID = lstPost.DesID;
                }
                if (DispOrgAvailableDesgPost.Count > 0)
                {
                    this.ddlPost_Posting.DataSource = DispOrgAvailableDesgPost;
                    this.ddlPost_Posting.DataTextField = "DESNAME";
                    this.ddlPost_Posting.DataValueField = "DESID";
                    this.ddlPost_Posting.Items.Add(new ListItem("छान्नुहोस", "0"));
                }
            }
            this.ddlPost_Posting.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlPost_Posting_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAvailablePosts();

    }

    void LoadAvailablePosts()
    {
        this.ddlAvailablePost_Posting.DataSource = "";
        this.ddlAvailablePost_Posting.Items.Clear();
        this.ddlAvailablePost_Posting.Enabled = false;
        List<ATTPost> AvailablePostList = new List<ATTPost>();
        if (this.ddlPost_Posting.SelectedIndex > 0)
        {
            this.ddlAvailablePost_Posting.Enabled = true;
            List<ATTPost> OrgAvailableDesgPost = (List<ATTPost>)Session["OrgAvailableDesgPost"];
            int intOrgID = int.Parse(this.ddlOrganization_Posting.SelectedValue.ToString());
            int intDesID = int.Parse(this.ddlPost_Posting.SelectedValue.ToString());
            foreach (ATTPost lstPost in OrgAvailableDesgPost)
            {
                if ((intOrgID == lstPost.OrgID) && (intDesID == lstPost.DesID))
                    AvailablePostList.Add(lstPost);
            }
            if (AvailablePostList.Count > 0)
            {
                this.ddlAvailablePost_Posting.DataSource = AvailablePostList;
                this.ddlAvailablePost_Posting.DataTextField = "RDPOSTNAMEWITHCREATIONDATE";//"RDPOSTNAMEWITHCREATIONDATE";
                this.ddlAvailablePost_Posting.DataValueField = "RDPOSTIDWITHCREATIONDATE";
                this.ddlAvailablePost_Posting.Items.Add(new ListItem("छान्नुहोस", "0"));
            }
        }
        this.ddlAvailablePost_Posting.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ATTEmployee objEmployee;
        ATTPerson objPerson;

        byte[] ImageData = new byte[0];
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;
        //int? intSon = null;
        //int? intDaughter = null;

        try
        {
            string strUser = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            int iniType = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            int iniUnit = 3;
            double empID = 0;
            if (this.txtEmployeeID.Text.Trim() != "")
                empID = double.Parse(this.txtEmployeeID.Text.Trim());
            if (this.ddlCountry.SelectedIndex > 0)
                intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
            if (this.ddlBirthDistrict.SelectedIndex > 0)
                intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
            if (this.ddlReligion.SelectedIndex > 0)
                intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());
            //if (this.txtSon.Text.Trim() != "")
            //    intSon = int.Parse(this.txtSon.Text.Trim().ToString());
            //if (this.txtDaughter.Text.Trim() != "")
            //    intDaughter = int.Parse(this.txtDaughter.Text.Trim().ToString());

            #region "EMPLOYEE TABLE"
            objEmployee = new ATTEmployee(empID, this.txtSymbolNo.Text.Trim(),this.txtEmpOrgNo.Text.Trim(),this.txtIdentityMark.Text.Trim(),
                strUser);
            #endregion

            #region "PERSONTABLE"
            objPerson = new ATTPerson(empID, this.txtFName_Rqd.Text.Trim(),
                this.txtMName.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
                this.txtDOB_DT.Text.Trim(), ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
                ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
                "", "", intCountryId, intBirthDistrict, intReligion,
                iniUnit, iniType, strUser, DateTime.Now, ImageData);
            #endregion

            objEmployee.ObjPerson = objPerson;

            #region "ADDRESS"
            int? intDistrictAddress = null;
            int? intVDCAddress = null;
            int? intWardAddress = null;
            string strAddressAction = "";
            ATTPersonAddress PersonAddressATT = null;
            if (this.ddlDistrict.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrict.SelectedValue);
            if (this.ddlVDC.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDC.SelectedValue);
            if (this.ddlWard.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWard.SelectedValue);
            PersonAddressATT = new ATTPersonAddress
                (
                0, "P", int.Parse(hdnPerAddress.Value.ToString()), intDistrictAddress, intVDCAddress, intWardAddress, this.txtTole.Text.Trim(), "Y", strUser, DateTime.Now
                );

            if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value != "0")) strAddressAction = "E";
            if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value == "0")) strAddressAction = "A";
            if (((this.ddlDistrict.SelectedIndex <= 0) && (this.txtTole.Text.Trim() == "")) && (hdnPerAddress.Value != "0")) strAddressAction = "D";
            if (strAddressAction != "")
            {
                PersonAddressATT.Action = strAddressAction;
                strAddressAction = "";
                objPerson.LstPersonAddress.Add(PersonAddressATT);
            }

            strAddressAction = "";
            intDistrictAddress = null;
            intVDCAddress = null;
            intWardAddress = null;

            if (this.ddlDistrictTemp.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrictTemp.SelectedValue);
            if (this.ddlVDCTemp.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDCTemp.SelectedValue);
            if (this.ddlWardTemp.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWardTemp.SelectedValue);
            PersonAddressATT = new ATTPersonAddress
                (
                0, "T", int.Parse(hdnTempAddress.Value.ToString()), intDistrictAddress, intVDCAddress, intWardAddress, this.txtToleTemp.Text.Trim(), "Y", strUser, DateTime.Now
                );

            if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value != "0")) strAddressAction = "E";
            if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value == "0")) strAddressAction = "A";
            if (((this.ddlDistrictTemp.SelectedIndex <= 0) && (this.txtToleTemp.Text.Trim() == "")) && (hdnTempAddress.Value != "0")) strAddressAction = "D";
            if (strAddressAction != "")
            {
                PersonAddressATT.Action = strAddressAction;
                strAddressAction = "";
                objPerson.LstPersonAddress.Add(PersonAddressATT);
            }
            #endregion

            #region "PHONE"
            foreach (GridViewRow row in this.grdPhone.Rows)
            {
                if (CheckNullString(row.Cells[7].Text.ToString()) != "")
                {
                    ATTPersonPhone PersonPhoneATT = new ATTPersonPhone(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                        CheckNullString(row.Cells[4].Text.ToString()), CheckNullString(row.Cells[5].Text.ToString()),
                        CheckNullString(row.Cells[6].Text.ToString()), strUser, DateTime.Now);
                    PersonPhoneATT.Action = CheckNullString(row.Cells[7].Text.ToString());
                    objPerson.LstPersonPhone.Add(PersonPhoneATT);
                }
            }
            #endregion

            #region "EMAIL"
            foreach (GridViewRow row in this.grdEMail.Rows)
            {
                if (CheckNullString(row.Cells[7].Text.ToString()) != "")
                {
                    ATTPersonEMail PersonEMailATT = new ATTPersonEMail(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                        CheckNullString(row.Cells[4].Text.ToString()), CheckNullString(row.Cells[5].Text.ToString()),
                        CheckNullString(row.Cells[6].Text.ToString()), strUser, DateTime.Now);
                    PersonEMailATT.Action = CheckNullString(row.Cells[7].Text.ToString());
                    objPerson.LstPersonEMail.Add(PersonEMailATT);
                }
            }
            #endregion

            #region "PERSON QUALIFICATIONS"
            long? lngEmpQualInstitution;
            float? fltEmpQualPercentage;
            foreach (GridViewRow row in this.grdQualification.Rows)
            {
                if (CheckNullString(row.Cells[12].Text.ToString()) != "")
                {
                    if (CheckNullString(row.Cells[5].Text.ToString()) != "")
                        lngEmpQualInstitution = int.Parse(row.Cells[5].Text.ToString());
                    else
                        lngEmpQualInstitution = null;

                    if (CheckNullString(row.Cells[10].Text.ToString()) != "")
                        fltEmpQualPercentage = float.Parse(row.Cells[10].Text.ToString());
                    else
                        fltEmpQualPercentage = null;

                    ATTPersonQualification PersonQualificationATT = new ATTPersonQualification(0, int.Parse(row.Cells[1].Text.ToString()), CheckNullString(row.Cells[2].Text.ToString()),
                        int.Parse(row.Cells[3].Text.ToString()), lngEmpQualInstitution, CheckNullString(row.Cells[7].Text.ToString()), CheckNullString(row.Cells[8].Text.ToString()),
                        CheckNullString(row.Cells[9].Text.ToString()), fltEmpQualPercentage, CheckNullString(row.Cells[11].Text.ToString()), strUser);
                    PersonQualificationATT.Action = CheckNullString(row.Cells[12].Text.ToString());
                    objPerson.LstPersonQualification.Add(PersonQualificationATT);
                }
            }
            #endregion

            #region "PERSON TRAININGS"
            long? lngEmpTrainInstitution;
            float? fltEmpTrainPercentage;
            foreach (GridViewRow row in this.grdTraining.Rows)
            {
                if (CheckNullString(row.Cells[11].Text.ToString()) != "")
                {
                    if (CheckNullString(row.Cells[4].Text.ToString()) != "")
                        lngEmpTrainInstitution = int.Parse(row.Cells[4].Text.ToString());
                    else
                        lngEmpTrainInstitution = null;

                    if (CheckNullString(row.Cells[9].Text.ToString()) != "")
                        fltEmpTrainPercentage = float.Parse(row.Cells[9].Text.ToString());
                    else
                        fltEmpTrainPercentage = null;

                    ATTPersonTraining PersonTrainingATT = new ATTPersonTraining(0, int.Parse(row.Cells[1].Text.ToString()), CheckNullString(row.Cells[2].Text.ToString()),
                        CheckNullString(row.Cells[3].Text.ToString()), lngEmpTrainInstitution, CheckNullString(row.Cells[6].Text.ToString()), CheckNullString(row.Cells[7].Text.ToString()),
                        CheckNullString(row.Cells[8].Text.ToString()), fltEmpTrainPercentage, CheckNullString(row.Cells[10].Text.ToString()), strUser);
                    PersonTrainingATT.Action = CheckNullString(row.Cells[11].Text.ToString());
                    objPerson.LstPersonTraining.Add(PersonTrainingATT);
                }
            }
            #endregion

            #region "DOCUMENTS (Like License, Passport, Cititzenship Card etc..."
            int? intDocIssuedFrom; //This holds the district id from where the document was issued
            foreach (GridViewRow row in this.grdDocuments.Rows)
            {
                if (CheckNullString(row.Cells[9].Text.ToString()) != "")
                {
                    if (CheckNullString(row.Cells[4].Text.ToString()) != "")
                        intDocIssuedFrom = int.Parse(row.Cells[4].Text.ToString());
                    else
                        intDocIssuedFrom = null;

                    ATTPersonDocuments PersonDocumentsATT = new ATTPersonDocuments(0, int.Parse(row.Cells[1].Text.ToString()), CheckNullString(row.Cells[3].Text.ToString()), intDocIssuedFrom,
                        CheckNullString(row.Cells[6].Text.ToString()), CheckNullString(row.Cells[7].Text.ToString()), CheckNullString(row.Cells[8].Text.ToString()), strUser);
                    PersonDocumentsATT.Action = CheckNullString(row.Cells[9].Text.ToString());
                    objPerson.LstPersonDocuments.Add(PersonDocumentsATT);

                }
            }
            #endregion

            #region "EMPLOYEE VISITS"
            foreach (GridViewRow row in this.grdVisits.Rows)
            {
                int? intEmpVisitCountry;

                if (CheckNullString(row.Cells[9].Text.ToString()) != "")
                {
                    if (CheckNullString(row.Cells[3].Text.ToString()) != "")
                        intEmpVisitCountry = int.Parse(row.Cells[3].Text.ToString());
                    else
                        intEmpVisitCountry = null;
                    ATTEmployeeVisits EmployeeVisitsATT = new ATTEmployeeVisits(0, int.Parse(row.Cells[1].Text.ToString()), CheckNullString(row.Cells[7].Text.ToString()),
                        CheckNullString(row.Cells[2].Text.ToString()), intEmpVisitCountry, CheckNullString(row.Cells[5].Text.ToString()),
                        CheckNullString(row.Cells[6].Text.ToString()), CheckNullString(row.Cells[8].Text.ToString()), strUser);
                    EmployeeVisitsATT.Action = CheckNullString(row.Cells[9].Text.ToString());
                    objEmployee.LstEmployeeVisits.Add(EmployeeVisitsATT);
                }
            }
            #endregion

            #region "EMPLOYEE CLASSIFIED WORK EXPERIENCES"
            foreach (GridViewRow row in this.grdExperiences.Rows)
            {
                if (CheckNullString(row.Cells[8].Text.ToString()) != "")
                {
                    ATTEmployeeExperience EmployeeExperienceATT = new ATTEmployeeExperience(
                        0, int.Parse(row.Cells[1].Text.ToString()), CheckNullString(row.Cells[2].Text.ToString()),
                        CheckNullString(row.Cells[3].Text.ToString()), CheckNullString(row.Cells[4].Text.ToString()),
                        CheckNullString(row.Cells[5].Text.ToString()), CheckNullString(row.Cells[6].Text.ToString()),
                        CheckNullString(row.Cells[7].Text.ToString()), strUser);
                    EmployeeExperienceATT.Action = CheckNullString(row.Cells[8].Text.ToString());
                    objEmployee.LstEmployeeExperience.Add(EmployeeExperienceATT);
                }
            }

            #endregion

            #region "EMPLOYEE POSTING"
            //foreach (GridViewRow row in this.grdEmpPostings.Rows)
            //{
            //    if (CheckNullString(row.Cells[15].Text) != "")
            //    {
            //    }
            //}

            string strCreationDate;
            int intPostID;
            string strPostingDate = null;
            if (this.ddlAvailablePost_Posting.SelectedIndex > 0)
            {
                if (this.ddlPostingType_Posting.SelectedIndex <= 0)
                {
                    this.lblStatusMessage.Text = "Select Posting Type";
                    this.programmaticModalPopup.Show();
                    return;
                }
                strCreationDate = this.ddlAvailablePost_Posting.SelectedValue.ToString();
                intPostID = int.Parse(strCreationDate.Substring(0, strCreationDate.IndexOf('/')));
                strCreationDate = strCreationDate.Substring(strCreationDate.IndexOf('/') + 1);
                if (this.txtDate_UDTPosting.Text.Trim() != "")
                    strPostingDate = this.txtDate_UDTPosting.Text.Trim();
                ATTEmployeePosting EmployeePostingATT = new ATTEmployeePosting(0,
                    int.Parse(this.ddlOrganization_Posting.SelectedValue.ToString()),
                    int.Parse(this.ddlPost_Posting.SelectedValue.ToString()),
                    strCreationDate, intPostID, strPostingDate, int.Parse(this.ddlPostingType_Posting.SelectedValue.ToString()), strUser);
                EmployeePostingATT.JoiningDate = (this.txtJoinDate_UDTPosting.Text.Trim() != "" ? this.txtJoinDate_UDTPosting.Text.Trim() : null);
                EmployeePostingATT.DecisionDate = (this.txtDecisionDate_UDTPosting.Text.Trim() != "" ? this.txtDecisionDate_UDTPosting.Text.Trim() : null);
                EmployeePostingATT.LeaveDate = (this.txtLeaveDate_UDTPosting.Text.Trim() != "" ? this.txtLeaveDate_UDTPosting.Text.Trim() : null);
                EmployeePostingATT.Action = "A";
                objEmployee.LstEmployeePosting.Add(EmployeePostingATT);
            }
            #endregion

            #region "Employee's Publication Compilation"

            DataTable tbl = (DataTable)Session["EmpPublication"];
            foreach (DataRow row in tbl.Rows)
            {
                ATTEmployeePublication pub = new ATTEmployeePublication();

                pub.EmpID = double.Parse(row["EmpID"].ToString());
                pub.PublicationID = int.Parse(row["PublicationID"].ToString());
                pub.PublicationName = row["PublicationName"].ToString();
                pub.Publisher = row["Publisher"].ToString();
                pub.PublicationDate = row["PublicationDate"].ToString();
                pub.Action = row["Action"].ToString();

                objEmployee.LstEmployeePublication.Add(pub);
            }

            #endregion

            #region "RELATIVES AND BENEFICIARIES"
            foreach (GridViewRow row in this.grdEmpRelatives.Rows)
            {
                int? countryID = null;
                int? birthDistrict = null;
                int? religionID = null;
                if (CheckNullString(row.Cells[11].Text) != "")
                    birthDistrict = int.Parse(row.Cells[11].Text);
                byte[] RelativeImageData = new byte[0];
                ATTPerson objRelativePerson = new ATTPerson
                    (double.Parse(row.Cells[1].Text), row.Cells[2].Text, CheckNullString(row.Cells[3].Text), CheckNullString(row.Cells[4].Text),
                    CheckNullString(row.Cells[8].Text), CheckNullString(row.Cells[6].Text), CheckNullString(row.Cells[9].Text), "", "",
                    countryID, birthDistrict, religionID, iniUnit, iniType, strUser, DateTime.Now, RelativeImageData);
                CheckBox cb = (CheckBox)row.Cells[17].FindControl("chkRelativeActive");
                CheckBox cbIsBen = (CheckBox)row.Cells[16].FindControl("chkIsBeneficiary");
                CheckBox cbWasBen = (CheckBox)row.Cells[20].FindControl("chkWasBeneficiary");

                ATTEmployeeBeneficiary EmpBeneficiaryATT = new ATTEmployeeBeneficiary(0, 0, null, null);
                if ((cbIsBen.Checked) && (!cbWasBen.Checked))
                    EmpBeneficiaryATT.Action = "A";
                else if ((!cbIsBen.Checked) && (cbWasBen.Checked))
                {
                    EmpBeneficiaryATT.Action = "E";
                    EmpBeneficiaryATT.ToDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
                }
                EmpBeneficiaryATT.EntryBy = strUser;

                ATTRelatives RelativesATT = new ATTRelatives(0, 0, int.Parse(row.Cells[13].Text), (cb.Checked ? "Y" : "N"));
                RelativesATT.Occupation = CheckNullString(row.Cells[15].Text);
                RelativesATT.EntryBy = strUser;
                if (CheckNullString(row.Cells[18].Text) == "A")
                    RelativesATT.Action = "A";
                else
                    RelativesATT.Action = "E";
                RelativesATT.ObjPerson = objRelativePerson;
                EmpBeneficiaryATT.ObjRelatives = RelativesATT;
                objEmployee.LstEmployeeBeneficiary.Add(EmpBeneficiaryATT);
            }
            #endregion

            BLLEmployee.SaveEmployeeDetails(objEmployee);
            if (empID == 0)
                this.lblStatusMessage.Text = "Employee Details Successfully Saved.";
            else
                this.lblStatusMessage.Text = "Employee Details Successfully Modified.";

            this.programmaticModalPopup.Show();
            ClearControls(sender, e);
            this.txtEmployeeID.Text = "";
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearControls(object sender, EventArgs e)
    {
        this.tabContainerEmpContact.ActiveTabIndex = 0;
        this.lblPersonnelInfo.Text = "न्यायाधिशको बैयक्तिक विवरण";

        #region "CLEAR PERSONNEL INFORMATION"
        /*The Below Part Clears All The Controls Above The TabPanel. Except txtEmployeeID*/
        /*txtEmployeeID will only be cleared once Submit button or Cancel button is clicked*/
        this.txtSymbolNo.Text = "";
        this.txtFName_Rqd.Text = "";
        this.txtMName.Text = "";
        this.txtSurName_Rqd.Text = "";
        this.txtDOB_DT.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlMarStatus.SelectedIndex = 0;
        this.ddlCountry.SelectedIndex = 0;
        this.ddlBirthDistrict.SelectedIndex = 0;
        this.ddlReligion.SelectedIndex = 0;
        this.txtIdentityMark.Text = "";
        #endregion

        #region "CLEAR ADDRESS, PHONE, EMAIL"
        this.ddlDistrict.SelectedIndex = 0;
        this.ddlVDC.DataSource = "";
        this.ddlVDC.Items.Clear();
        this.ddlVDC.DataBind();
        this.ddlWard.DataSource = "";
        this.ddlWard.Items.Clear();
        this.ddlWard.DataBind();
        this.txtTole.Text = "";

        this.ddlDistrictTemp.SelectedIndex = 0;
        this.ddlVDCTemp.DataSource = "";
        this.ddlVDCTemp.Items.Clear();
        this.ddlVDCTemp.DataBind();
        this.ddlWardTemp.DataSource = "";
        this.ddlWardTemp.Items.Clear();
        this.ddlWardTemp.DataBind();
        this.txtToleTemp.Text = "";

        this.hdnPerAddress.Value = "0";
        this.hdnTempAddress.Value = "0";
        this.imgDelPerAddress.Visible = false;
        this.imgDelTempAddress.Visible = false;

        this.ddlPhoneType_Phone.SelectedIndex = 0;
        this.txtPhoneNumber_Phone.Text = "";
        this.grdPhone.DataSource = "";
        this.grdPhone.DataBind();

        this.ddlEMailType_EMail.SelectedIndex = 0;
        this.txtEMail_EMail.Text = "";
        this.grdEMail.DataSource = "";
        this.grdEMail.DataBind();
        #endregion

        #region "CLEAR QUALIFICATION,TRAINING"
        this.txtQualSubject_Qual.Text = "";
        this.ddlQualDegree_Qual.SelectedIndex = 0;
        this.ddlQualInstitution_Qual.SelectedIndex = 0;
        this.txtQualFromDate_UDTQual.Text = "";
        this.txtQualToDate_UDTQual.Text = "";
        this.txtQualGrade.Text = "";
        this.txtQualPercentage.Text = "";
        this.txtQualRemarks.Text = "";
        this.grdQualification.DataSource = "";
        this.grdQualification.DataBind();

        this.txtTrainSubject_Training.Text = "";
        this.txtTrainCertificate_Training.Text = "";
        this.ddlTrainInstitution_Training.SelectedIndex = 0;
        this.txtTrainFromDate_UDTTraining.Text = "";
        this.txtTrainToDate_UDTTraining.Text = "";
        this.txtTrainGrade.Text = "";
        this.txtTrainPercentage.Text = "";
        this.txtTrainRemarks.Text = "";
        this.grdTraining.DataSource = "";
        this.grdTraining.DataBind();
        #endregion

        #region "CLEAR VISIT,DOCUMENTS"
        this.txtVisitLocation_Visit.Text = "";
        this.ddlVisitCountry_Visit.SelectedIndex = 0;
        this.txtVisitFromDate_URDTVisit.Text = "";
        this.txtVisitToDate_UDTVisit.Text = "";
        this.txtVisitPurpose_Visit.Text = "";
        this.txtVisitRemarks.Text = "";
        this.grdVisits.DataSource = "";
        this.grdVisits.DataBind();

        this.ddlDocType_Documents.SelectedIndex = 0;
        this.txtDocNumber_Documents.Text = "";
        this.ddlDocIssuedFrom.SelectedIndex = 0;
        this.txtDocIssuedOn_UDTDocuments.Text = "";
        this.txtDocIssuedBy.Text = "";
        this.grdDocuments.DataSource = "";
        this.grdDocuments.DataBind();
        #endregion

        #region "CLEAR EXPERIENCES"
        this.txtExpPostingLocation_Experience.Text = "";
        this.txtExpJobLocation_Experience.Text = "";
        this.txtExpFromDate_UDTExperience.Text = "";
        this.txtExpToDate_UDTExperience.Text = "";
        this.ddlExpClassification.SelectedIndex = 0;
        this.txtExpRemarks.Text = "";
        this.grdExperiences.DataSource = "";
        this.grdExperiences.DataBind();
        #endregion

        #region "CLEAR POSTINGS"
        ClearPostings();
        this.grdEmpPostings.DataSource = "";
        this.grdEmpPostings.DataBind();
        #endregion

        #region "CLEAR RELATIVES"
        ClearRelativeControls();
        this.grdEmpRelatives.DataSource = "";
        this.grdEmpRelatives.DataBind();
        #endregion

        this.ClearPublication();
        this.grdPublication.DataSource = "";
        this.grdPublication.DataBind();

        SetPhoneTable();
        SetEMailTable();
        SetQualificationTable();
        SetTrainingTable();
        SetVisitsTable();
        SetExperienceTable();
        SetDocumentsTable();
        SetRelativesTable();
        SetPostingTable();
        this.SetPublicationTable();
    }

    void ClearAddressControls(string AddressType)
    {
        if (AddressType == "P")
        {
            this.ddlDistrict.SelectedIndex = 0;
            this.ddlVDC.DataSource = "";
            this.ddlVDC.Items.Clear();
            this.ddlVDC.DataBind();
            this.ddlWard.DataSource = "";
            this.ddlWard.Items.Clear();
            this.ddlWard.DataBind();
            this.txtTole.Text = "";
        }
        else if (AddressType == "T")
        {
            this.ddlDistrictTemp.SelectedIndex = 0;
            this.ddlVDCTemp.DataSource = "";
            this.ddlVDCTemp.Items.Clear();
            this.ddlVDCTemp.DataBind();
            this.ddlWardTemp.DataSource = "";
            this.ddlWardTemp.Items.Clear();
            this.ddlWardTemp.DataBind();
            this.txtToleTemp.Text = "";
        }
    }

    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }

    protected void imgRefreshInstitution_Click(object sender, ImageClickEventArgs e)
    {
        this.LoadInstitutions();
    }

    protected void imgRefreshDocument_Click(object sender, ImageClickEventArgs e)
    {
        this.LoadDocumentsType();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    void SetGridColor(int col, int delCol, GridView grd)
    {
        for (int j = 0; j < grd.Rows.Count; j++)
        {

            if (grd.Rows[j].Cells[col].Text == "D")
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Undo";
                grd.Rows[j].ForeColor = System.Drawing.Color.Red;
            }

            else
            {
                ((LinkButton)grd.Rows[j].Cells[delCol].Controls[0]).Text = "Delete";
                grd.Rows[j].ForeColor = System.Drawing.Color.FromName("#1D2A5B");

            }
        }
    }

    #region "GENERICLISTTODATATABLE"
    /// <summary> 
    /// Converts a generic List<> into a DataTable. 
    /// </summary> 
    /// <param name="list"></param> 
    /// <returns>DataTable</returns> 
    public static DataTable GenericListToDataTable(object list)
    {
        DataTable dt = null;
        Type listType = list.GetType();
        if (listType.IsGenericType)
        {
            //determine the underlying type the List<> contains 
            Type elementType = listType.GetGenericArguments()[0];

            //create empty table -- give it a name in case 
            //it needs to be serialized 
            dt = new DataTable(elementType.Name + "List");

            //define the table -- add a column for each public 
            //property or field 
            MemberInfo[] miArray = elementType.GetMembers(
                BindingFlags.Public | BindingFlags.Instance);
            foreach (MemberInfo mi in miArray)
            {
                //if (mi.MemberType == MemberTypes.Method)
                //{
                //    MethodInfo methodinfo = mi as MethodInfo;
                //    dt.Columns.Add(methodinfo.Name);
                //}
                if (mi.MemberType == MemberTypes.Property)
                {
                    PropertyInfo pi = mi as PropertyInfo;
                    if (pi.Name != "EntryBy" && pi.Name != "EntryDate")
                        dt.Columns.Add(pi.Name);
                }
                ////else if (mi.MemberType == MemberTypes.Field)
                ////{
                ////    FieldInfo fi = mi as FieldInfo;
                ////    dt.Columns.Add(fi.Name, fi.FieldType);
                ////}
            }

            //populate the table 
            IList il = list as IList;
            foreach (object record in il)
            {
                int i = 0;
                object[] fieldValues = new object[dt.Columns.Count];
                foreach (DataColumn c in dt.Columns)
                {
                    MemberInfo mi = elementType.GetMember(c.ColumnName)[0];

                    //if (mi.MemberType == MemberTypes.Property)
                    //{
                    //    MethodInfo m = mi as MethodInfo;
                    //    fieldValues[i] = m.GetParameters();
                    //}

                    if (mi.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo pi = mi as PropertyInfo;
                        fieldValues[i] = pi.GetValue(record, null);
                    }
                    //else if (mi.MemberType == MemberTypes.Field)
                    //{
                    //    FieldInfo fi = mi as FieldInfo;
                    //    fieldValues[i] = fi.GetValue(record);
                    //}
                    i++;
                }
                dt.Rows.Add(fieldValues);
            }
        }
        return dt;
    }

    #endregion

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtEmployeeID.Text = "";
        ClearControls(sender, e);

    }

    protected void btnAddPublication_Click(object sender, EventArgs e)
    {
        DataTable tbl = (DataTable)Session["EmpPublication"];

        DataRow row;

        if (this.grdPublication.SelectedIndex >= 0)
            row = tbl.Rows[this.grdPublication.SelectedIndex];
        else
            row = tbl.NewRow();

        row["EmpID"] = 0;
        row["PublicationName"] = this.txtPublication_Publ.Text;
        row["Publisher"] = this.txtPublisher_Publ.Text;
        row["PublicationDate"] = this.txtPubDate_UDTPubl.Text;

        if (this.grdPublication.SelectedIndex >= 0)
        {
            row["PublicationID"] = this.grdPublication.SelectedRow.Cells[1].Text;
            if (this.grdPublication.SelectedRow.Cells[5].Text == "A")
                row["Action"] = "A";
            else if (this.grdPublication.SelectedRow.Cells[5].Text == "N" || this.grdPublication.SelectedRow.Cells[5].Text == "E")
                row["Action"] = "E";
        }
        else
        {
            row["PublicationID"] = 0;
            row["Action"] = "A";
        }

        if (this.grdPublication.SelectedIndex <= -1)
            tbl.Rows.Add(row);

        this.grdPublication.DataSource = tbl;
        this.grdPublication.DataBind();

        this.ClearPublication();
        this.grdPublication.SelectedIndex = -1;
    }

    void ClearPublication()
    {
        this.txtPublication_Publ.Text = "";
        this.txtPublisher_Publ.Text = "";
        this.txtPubDate_UDTPubl.Text = "";
    }

    void SetPublicationTable()
    {
        DataTable tbl = new DataTable("Publication");

        tbl.Columns.Add(new DataColumn("EmpID"));
        tbl.Columns.Add(new DataColumn("PublicationID"));
        tbl.Columns.Add(new DataColumn("PublicationName"));
        tbl.Columns.Add(new DataColumn("Publisher"));
        tbl.Columns.Add(new DataColumn("PublicationDate"));
        tbl.Columns.Add(new DataColumn("Action"));

        Session["EmpPublication"] = tbl;
    }

    protected void grdPublication_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        //e.Row.Cells[5].Visible = false;
    }

    protected void grdPublication_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable tbl = (DataTable)Session["EmpPublication"];
        DataRow row = tbl.Rows[this.grdPublication.SelectedIndex];

        this.ClearPublication();

        if (row[5].ToString() == "D")
        {
            this.grdPublication.SelectedIndex = -1;
            return;
        }

        this.txtPublication_Publ.Text = row["PublicationName"].ToString(); ;
        this.txtPublisher_Publ.Text = row["Publisher"].ToString();
        this.txtPubDate_UDTPubl.Text = row["PublicationDate"].ToString();
    }

    protected void grdPublication_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string action = this.grdPublication.Rows[e.RowIndex].Cells[5].Text;

        DataTable tbl = (DataTable)Session["EmpPublication"];

        if (action == "A")
            tbl.Rows.RemoveAt(e.RowIndex);
        else if (action == "D")
            tbl.Rows[e.RowIndex]["Action"] = "N";
        else if (action == "N" || action == "E")
            tbl.Rows[e.RowIndex]["Action"] = "D";
        this.grdPublication.DataSource = tbl;
        this.grdPublication.DataBind();

        this.SetGridColor(5, 7, this.grdPublication);
    }

    protected void imgDelPerAddress_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.txtEmployeeID.Text != "") DeleteEmployeeAddress("P", int.Parse(hdnPerAddress.Value.ToString()));
            this.imgDelPerAddress.Visible = false;
            this.ddlDistrict.SelectedIndex = 0;
            this.ddlVDC.DataSource = "";
            this.ddlVDC.Items.Clear();
            this.ddlVDC.DataBind();
            this.ddlWard.DataSource = "";
            this.ddlWard.Items.Clear();
            this.ddlWard.DataBind();
            this.txtTole.Text = "";

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void imgDelTempAddress_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.txtEmployeeID.Text != "") DeleteEmployeeAddress("T", int.Parse(hdnTempAddress.Value.ToString()));
            this.imgDelTempAddress.Visible = false;

            this.ddlDistrictTemp.SelectedIndex = 0;
            this.ddlVDCTemp.DataSource = "";
            this.ddlVDCTemp.Items.Clear();
            this.ddlVDCTemp.DataBind();
            this.ddlWardTemp.DataSource = "";
            this.ddlWardTemp.Items.Clear();
            this.ddlWardTemp.DataBind();
            this.txtToleTemp.Text = "";
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void DeleteEmployeeAddress(string AdressType, int AdSNo)
    {
        string strUser = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        int iniType = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        int iniUnit = 3;

        double empID = 0;
        byte[] ImageData = new byte[0];
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;
        //int? intSon = null;
        //int? intDaughter = null;
        if (this.txtEmployeeID.Text.Trim() != "")
            empID = double.Parse(this.txtEmployeeID.Text.Trim());
        if (this.ddlCountry.SelectedIndex > 0)
            intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
        if (this.ddlBirthDistrict.SelectedIndex > 0)
            intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
        if (this.ddlReligion.SelectedIndex > 0)
            intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());

        #region "EMPLOYEE TABLE"
        empID = double.Parse(this.txtEmployeeID.Text);
        ATTEmployee objEmployee = new ATTEmployee(empID, this.txtSymbolNo.Text.Trim(), this.txtEmpOrgNo.Text.Trim(),this.txtIdentityMark.Text.Trim(),
            strUser);
        #endregion

        #region "PERSONTABLE"
        ATTPerson objPerson = new ATTPerson(empID, this.txtFName_Rqd.Text.Trim(),
            this.txtMName.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
            this.txtDOB_DT.Text.Trim(), ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
            ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
            "", "", intCountryId, intBirthDistrict, intReligion,
            iniUnit, iniType, strUser, DateTime.Now, ImageData);
        #endregion

        objEmployee.ObjPerson = objPerson;
        ATTPersonAddress PersonAddressATT = new ATTPersonAddress
            (double.Parse(this.txtEmployeeID.Text), AdressType, AdSNo);
        PersonAddressATT.Action = "D";
        objPerson.LstPersonAddress.Add(PersonAddressATT);
        BLLEmployee.SaveEmployeeDetails(objEmployee);
    }

    protected void OkPersonButton_Click(object sender, EventArgs e)
    {
        ClearRelativeControls();
        if (this.grdPersonSearch.SelectedIndex > -1)
        {
            List<ATTPersonSearch> lstPersonSearch = (List<ATTPersonSearch>)Session["PopupPersonSearch"];
            this.hdnRelativeID.Value = lstPersonSearch[this.grdPersonSearch.SelectedIndex].PersonID.ToString();
            this.txtRelationFirstName_Relative.Text = lstPersonSearch[this.grdPersonSearch.SelectedIndex].FirstName;
            this.txtRelationMName.Text = lstPersonSearch[this.grdPersonSearch.SelectedIndex].MiddleName;
            this.txtRelationLastName_Relative.Text = lstPersonSearch[this.grdPersonSearch.SelectedIndex].SurName;
            if (lstPersonSearch[this.grdPersonSearch.SelectedIndex].Gender != "")
                this.ddlRelationGender.SelectedValue = lstPersonSearch[this.grdPersonSearch.SelectedIndex].Gender;
            this.txtRelationDOB_DTRelative.Text = lstPersonSearch[this.grdPersonSearch.SelectedIndex].DOB;
            if (lstPersonSearch[this.grdPersonSearch.SelectedIndex].MaritalStatus != "")
                this.ddlRelationMarStatus.SelectedValue = lstPersonSearch[this.grdPersonSearch.SelectedIndex].MaritalStatus;
            if (lstPersonSearch[this.grdPersonSearch.SelectedIndex].BirthDistrict != null)
                this.ddlRelationHomeDistrict.SelectedValue = lstPersonSearch[this.grdPersonSearch.SelectedIndex].BirthDistrict.ToString();
            this.txtRelationFirstName_Relative.Enabled = false;
            this.txtRelationMName.Enabled = false;
            this.txtRelationLastName_Relative.Enabled = false;
            this.ddlRelationGender.Enabled = false;
            this.txtRelationDOB_DTRelative.Enabled = false;
            this.ddlRelationMarStatus.Enabled = false;
            this.ddlRelationHomeDistrict.Enabled = false;
        }
        this.programmaticPersonModalPopup.Hide();
    }

    void ClearPersonSearchFields()
    {
        this.txtSFirstName.Text = "";
        this.txtSMName.Text = "";
        this.txtSLastName.Text = "";
        this.ddlSGender.SelectedIndex = 0;
        this.txtSDOB_DT.Text = "";
        this.ddlSMarStatus.SelectedIndex = 0;
        this.ddlSHomeDistrict.SelectedIndex = 0;
        //this.grdPersonSearch.DataSource = "";
        //this.grdPersonSearch.DataBind();
    }

    protected void btnPersonSearch_Click(object sender, EventArgs e)
    {
        List<ATTPersonSearch> lstPersonSearch;
        lstPersonSearch = BLLPersonSearch.SearchPerson(GetFilter());
        Session["PopupPersonSearch"] = lstPersonSearch;
        this.grdPersonSearch.DataSource = lstPersonSearch;
        this.grdPersonSearch.DataBind();
        this.programmaticPersonModalPopup.Show();
    }

    private ATTPersonSearch GetFilter()
    {
        ATTPersonSearch SearchPerson = new ATTPersonSearch();
        if (this.txtSFirstName.Text.Trim() != "") SearchPerson.FirstName = this.txtSFirstName.Text.Trim();
        if (this.txtSMName.Text.Trim() != "") SearchPerson.MiddleName = this.txtSMName.Text.Trim();
        if (this.txtSLastName.Text.Trim() != "") SearchPerson.SurName = this.txtSLastName.Text.Trim();
        if (this.ddlSGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlSGender.SelectedValue;
        if (this.ddlSHomeDistrict.SelectedIndex > 0) SearchPerson.BirthDistrict = int.Parse(this.ddlSHomeDistrict.SelectedValue);
        if (this.ddlSMarStatus.SelectedIndex > 0) SearchPerson.IniType = this.ddlSMarStatus.SelectedValue;
        return SearchPerson;
    }

    protected void grdPersonSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int seqNo;
            seqNo = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = seqNo.ToString();
        }

        e.Row.Cells[1].Visible = false;
        e.Row.Cells[6].Visible = false;
    }

    protected void btnCancelPersonSearch_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
    }

    protected void btnSearchRelatives_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
        this.programmaticPersonModalPopup.Show();
    }

    protected void grdPersonSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdPersonSearch.SelectedRow.Focus();
        this.programmaticPersonModalPopup.Show();

    }

    protected void btnClearRelatives_Click(object sender, EventArgs e)
    {
        //ClearRelativeControls();
        string selectedValue = Request.Form["MyRadioButton"];
        lblStatusMessage.Text = selectedValue;
        this.programmaticModalPopup.Show();
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
    }

    protected void grdEmpRelatives_RowDataBound(object sender, GridViewRowEventArgs e)
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
        e.Row.Cells[18].Visible = false;
        e.Row.Cells[21].Visible = false;
        e.Row.Cells[22].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strUncheckOtherBen = "return UnCheckOthersBeneficiary('" + ((CheckBox)e.Row.FindControl("chkIsBeneficiary")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkRelativeActive")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkIsBeneficiary")).Attributes.Add("onclick", strUncheckOtherBen);
            string strUncheckInActiveBen = "return UnCheckBeneficiary('" + ((CheckBox)e.Row.FindControl("chkIsBeneficiary")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkRelativeActive")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkRelativeActive")).Attributes.Add("onclick", strUncheckInActiveBen);
        }
    }

    protected void grdEmpPostings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[15].Visible = false;
    }

    protected void btnPostingPlus_Click(object sender, EventArgs e)
    {
        DataTable tbl = (DataTable)Session["PostingTbl"];

        DataRow row;

        if (this.grdEmpPostings.SelectedIndex >= 0)
            row = tbl.Rows[this.grdEmpPostings.SelectedIndex];
        else
            row = tbl.NewRow();

        string strCreationDate = this.ddlAvailablePost_Posting.SelectedValue.ToString();
        int intPostID = int.Parse(strCreationDate.Substring(0, strCreationDate.IndexOf('/')));
        strCreationDate = strCreationDate.Substring(strCreationDate.IndexOf('/') + 1);
        string strPostName = this.ddlAvailablePost_Posting.SelectedItem.Text.Substring(0, this.ddlAvailablePost_Posting.SelectedItem.Text.IndexOf('('));

        row["EMPID"] = 0;
        row["ORGID"] = this.ddlOrganization_Posting.SelectedValue;
        row["ORGNAME"] = this.ddlOrganization_Posting.SelectedItem.Text;
        row["DESID"] = this.ddlPost_Posting.SelectedValue;
        row["DESNAME"] = this.ddlPost_Posting.SelectedItem.Text;
        row["POSTID"] = intPostID;
        row["CREATEDDATE"] = strCreationDate;
        row["POSTNAME"] = strPostName;
        row["POSTINGTYPEID"] = this.ddlPostingType_Posting.SelectedValue;
        row["POSTINGTYPENAME"] = this.ddlPostingType_Posting.SelectedItem.Text.Trim();
        row["FROMDATE"] = this.txtDate_UDTPosting.Text.Trim();
        row["DECISIONDATE"] = this.txtDecisionDate_UDTPosting.Text.Trim();
        row["LEAVEDATE"] = this.txtLeaveDate_UDTPosting.Text.Trim();
        row["JOININGDATE"] = this.txtJoinDate_UDTPosting.Text.Trim();

        if (this.grdEmpPostings.SelectedIndex <= -1)
        {
            row["ACTION"] = "A";
            tbl.Rows.Add(row);
        }

        this.grdEmpPostings.DataSource = tbl;
        this.grdEmpPostings.DataBind();
        this.grdEmpPostings.SelectedIndex = -1;
        ClearPostings();
    }

    void ClearPostings()
    {
        this.ddlOrganization_Posting.SelectedValue = Session["OrgID"].ToString();
        LoadOrganizationAvailablePosts(int.Parse(this.ddlOrganization_Posting.SelectedValue.ToString()));
        this.ddlPost_Posting.SelectedIndex = 0;
        LoadAvailablePosts();
        this.ddlPostingType_Posting.SelectedIndex = 0;
        this.txtDate_UDTPosting.Text = "";
        this.txtDecisionDate_UDTPosting.Text = "";
        this.txtLeaveDate_UDTPosting.Text = "";
        this.txtJoinDate_UDTPosting.Text = "";
        this.txtSalary.Text = "";
        this.txtPostingRemarks.Text = "";
    }

    protected void grdEmpPostings_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}