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
using PCS.LJMS.ATT;
using PCS.LJMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;

public partial class MODULES_PMS_Forms_Employee : System.Web.UI.Page
{
    private List<ATTLawyer> LawyerLst
    {
        get { return Session["LawyerList"] as List<ATTLawyer>; }
    }


    private List<ATTPrivateLawyer> PrivateLawyerLst
    {
        get { return Session["PrivateLawyerList"] as List<ATTPrivateLawyer>; }
    }

    void SetLawyerSession()
    {
        Session["LawyerList"] = new List<ATTLawyer>();
        //Session["PrivateLawyerList"] = new List<ATTPrivateLawyer>();
        //Session["LawyerTbl"] = new List<ATTLawyer>();
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        //if (Session["Login_User_Detail"] == null) 
        //    Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //if (user.MenuList.ContainsKey("3,2,1") == true)
        //{
        //Session["OrgID"] = user.OrgID;
        Session["OrgID"] = 9;
        if (this.IsPostBack == false)
        {
            try
            {
                this.LoadReligions();
                this.LoadCountries();
                this.LoadDistricts();
                this.LoadDegrees();
                this.LoadInstitutions();
                this.LoadRelationType();
                this.LoadLawyerType();
                this.LoadUnit();
                this.LoadPrivateLawyer();

                this.ClearControls(sender, e);

                if(Session["PIDforLawyerDetail"] != null)
                {
                    double PID = double.Parse(Session["PIDforLawyerDetail"].ToString());

                    if (PID > 0)
                    {
                        this.LoadLawyerDetails(PID);
                    }
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
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);

    }

    public void LoadLawyerDetails(double PID)
    {
        try
        {
            ATTLawyerPerson objLawyerPerson = BLLLawyerPerson.GetLawyerWithDetailInfoByID(PID);

            hdnPID.Value = objLawyerPerson.PId.ToString();

            //hdnLDate.Value = objLawyerPerson.DOB.ToString().Trim(); 
            //hdnPlDate.Value = objLawyerPerson.DOB.ToString().Trim(); 

            this.txtFName_Rqd.Text = objLawyerPerson.FirstName.ToString().Trim();
            this.txtMName.Text = objLawyerPerson.MidName.ToString().Trim();
            this.txtSurName_Rqd.Text = objLawyerPerson.SurName.ToString().Trim();
            this.txtDOB_DT.Text = objLawyerPerson.DOB.ToString().Trim();

            if (objLawyerPerson.Gender.ToString().Trim() != "")
                this.ddlGender.SelectedValue = objLawyerPerson.Gender.ToString().Trim();

            if (objLawyerPerson.MaritalStatus.ToString().Trim() != "")
                this.ddlMarStatus.SelectedValue = objLawyerPerson.MaritalStatus.ToString().Trim();

            if (objLawyerPerson.CountryId.ToString() != "")
                this.ddlCountry.SelectedValue = objLawyerPerson.CountryId.ToString();

            if (objLawyerPerson.BirthDistrict.ToString() != "")
                this.ddlBirthDistrict.SelectedValue = objLawyerPerson.BirthDistrict.ToString();

            if (objLawyerPerson.ReligionId.ToString() != "")
                this.ddlReligion.SelectedValue = objLawyerPerson.ReligionId.ToString();


            if (objLawyerPerson.LstPersonPhone.Count > 0)
            {
                //this.grdPhone.SelectedIndex = -1;
                //this.grdPhone.DataSource = objLawyerPerson.LstPersonPhone;

                Session["PhoneTbl"] = GenericListToDataTable(objLawyerPerson.LstPersonPhone);
                this.grdPhone.SelectedIndex = -1;
                this.grdPhone.DataSource = Session["PhoneTbl"];
                this.grdPhone.DataBind();
            }

            if (objLawyerPerson.LstPersonEMail.Count > 0)
            {
                //this.grdEMail.SelectedIndex = -1;
                //this.grdEMail.DataSource = objLawyerPerson.LstPersonEMail;
                //this.grdEMail.DataBind();
                Session["EMailTbl"] = GenericListToDataTable(objLawyerPerson.LstPersonEMail);
                grdEMail.SelectedIndex = -1;
                this.grdEMail.DataSource = Session["EMailTbl"];
                this.grdEMail.DataBind();
            }

            if(objLawyerPerson.LstPersonQualification.Count > 0)
            {
                //this.grdQualification.SelectedIndex = - 1;
                //this.grdQualification.DataSource = objLawyerPerson.LstPersonQualification;
                //this.grdQualification.DataBind();

                Session["QualificationTbl"] = GenericListToDataTable(objLawyerPerson.LstPersonQualification);
                this.grdQualification.SelectedIndex = -1;
                this.grdQualification.DataSource = Session["QualificationTbl"];
                this.grdQualification.DataBind();
            }

            if (objLawyerPerson.LstLawyer.Count > 0)
            {
                this.grdNepalBarCouncil.SelectedIndex = -1;
                this.grdNepalBarCouncil.DataSource = objLawyerPerson.LstLawyer;
                this.grdNepalBarCouncil.DataBind();

                Session["LawyerList"] = objLawyerPerson.LstLawyer;
            }

            Session["PIDforLawyerDetail"] = "";
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
            if (objEmployee.ObjPerson.LstPersonQualification.Count > 0)
            {
                Session["QualificationTbl"] = GenericListToDataTable(objEmployee.ObjPerson.LstPersonQualification);
                this.grdQualification.DataSource = Session["QualificationTbl"];
                this.grdQualification.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadPrivateLawyer()
    {
        try
        {
            this.SetLawyerSession();
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadLawyerType()
    {
        try
        {   List<ATTLawyerType> lstLawyerType;
            lstLawyerType = BLLLawyerType.GetLawyerTypeList(null,true);
            this.ddlLawyerType_nba.DataSource = lstLawyerType;
            this.ddlLawyerType_nba.DataTextField = "LawyerTypeDescription";
            this.ddlLawyerType_nba.DataValueField = "LawyerTypeID";
            this.ddlLawyerType_nba.SelectedIndex = -1;
            this.ddlLawyerType_nba.DataBind();
            
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    void LoadUnit()
    {
        try
        {
            this.ddlPrivateUnit_pl.DataSource = BLLUnit.GetUnitList(null, true);
            this.ddlPrivateUnit_pl.DataTextField = "UnitName";
            this.ddlPrivateUnit_pl.DataValueField = "UnitID";
            this.ddlPrivateUnit_pl.DataBind();
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
            this.ddlCountry.DataBind();

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
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void SetLawyerInfoTable()
    {
        try 
	    {
            DataTable tbl = new DataTable();
            DataColumn dtCol0 = new DataColumn("PID");
            DataColumn dtCol1 = new DataColumn("LAWYERTYPEID");
            DataColumn dtCol2 = new DataColumn("LAWYERTYPENAME");
            DataColumn dtCol3 = new DataColumn("LICENSENO");
            DataColumn dtCol4 = new DataColumn("FROMDATE");
            DataColumn dtCol5 = new DataColumn("ACTION");

            tbl.Columns.Add(dtCol0);
            tbl.Columns.Add(dtCol1);
            tbl.Columns.Add(dtCol2);
            tbl.Columns.Add(dtCol3);
            tbl.Columns.Add(dtCol4);
            tbl.Columns.Add(dtCol5);

            Session["LawyerInfoTbl"] = tbl;
	    }
	    catch (Exception ex)
	    {
    		
		    throw(ex);
	    }
     }

    public void SetLawyerRenewalTable()
    {
        try
        {

            DataTable tbl = new DataTable();
            DataColumn dtCol0 = new DataColumn("PID");
            DataColumn dtCol1 = new DataColumn("LAWYERTYPEID");
            DataColumn dtCol2 = new DataColumn("LAWYERTYPENAME");
            DataColumn dtCol3 = new DataColumn("LICENSENO");
            DataColumn dtCol4 = new DataColumn("RENEWALDATE");
            DataColumn dtCol5 = new DataColumn("RENEWALUPTO");
            DataColumn dtCol6 = new DataColumn("ACTION");

            tbl.Columns.Add(dtCol0);
            tbl.Columns.Add(dtCol1);
            tbl.Columns.Add(dtCol2);
            tbl.Columns.Add(dtCol3);
            tbl.Columns.Add(dtCol4);
            tbl.Columns.Add(dtCol5);
            tbl.Columns.Add(dtCol6);

            Session["LawyerRenewalTbl"] = tbl;

        }
        catch (Exception ex)
        {
            
            throw(ex);
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

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ATTLawyer objLawyer = new ATTLawyer();
        //ATTPerson objPerson;

        ATTLawyerPerson objPerson ;

        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;

        try
        {
            //string strUser = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            //int iniType = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
            string strUser = "Raju";
            //int iniType = 2;
            //int iniUnit = 9;
            byte[] ImageData = new byte[0];
            int iniType = 2;
            int iniUnit = 9;
            double empID = 0;
            //if (this.txtEmployeeID.Text.Trim() != "")
            //    empID = double.Parse(this.txtEmployeeID.Text.Trim());
            if (this.ddlCountry.SelectedIndex > 0)
                intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
            if (this.ddlBirthDistrict.SelectedIndex > 0)
                intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
            if (this.ddlReligion.SelectedIndex > 0)
                intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());

            #region "PERSONTABLE"
            objPerson = new ATTLawyerPerson(empID, this.txtFName_Rqd.Text.Trim(),
                this.txtMName.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
                this.txtDOB_DT.Text.Trim(), ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
                ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
                "", "", intCountryId, intBirthDistrict, intReligion,
                iniUnit, iniType, strUser, DateTime.Now, ImageData);

            //public ATTPerson(double pId, string firstName, string midName, string surName, string dOB, string gender, string maritalStatus, string fatherName, string gFatherName, int? countryId, int? birthDistrict, int? religionId, int iniUnit, int iniType, string entryBy, DateTime entryDate, byte[] photo);

            #endregion

            //objEmployee.ObjPerson = objPerson;

           
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
            objPerson.EntityType = "P";

            if (hdnPID.Value != "")
                objPerson.PId = double.Parse(hdnPID.Value);

            //objLawyer.ObjPerson = objPerson;

            //objPerson.LstLawyer = 

            #region "LAWYER INFO"
            //foreach (GridViewRow row in this.grdNepalBarCouncil.Rows)
            //{
            //    objLawyer.PID = int.Parse(row.Cells[0].Text);
            //    objLawyer.LawyerTypeID = int.Parse(row.Cells[1].Text);
            //    objLawyer.LicenseNo = row.Cells[3].Text;
            //    objLawyer.FromDate = row.Cells[4].Text;
            //    objLawyer.Action = row.Cells[5].Text;

            //}
            #endregion

            #region "LAWYER RENEWAL"
            //foreach (GridViewRow row in grdLawyerRenewal.Rows)
            //{
            //    ATTLawyerRenewal objLawyerRenew = new ATTLawyerRenewal();
            //    objLawyerRenew.PID = int.Parse(row.Cells[0].Text);
            //    objLawyerRenew.LawyerTypeID = int.Parse(row.Cells[1].Text);
            //    objLawyerRenew.LicenseNo = row.Cells[3].Text;
            //    objLawyerRenew.RenewalDate = row.Cells[4].Text;
            //    objLawyerRenew.RenewalUpto = row.Cells[5].Text;
            //    objLawyerRenew.Action = row.Cells[6].Text;

            //    objLawyer.LstLawyerRenewal.Add(objLawyerRenew);
                
            //}

            #endregion

            //List<ATTLawyer> lst =  this.LawyerLst;

            objPerson.LstLawyer = (List<ATTLawyer>) this.LawyerLst;


            //if(BLLLawyer.SaveLawyerDetails(objLawyer))
            if (BLLLawyerPerson.SaveLawyerPerson(objPerson))
            {

                if (hdnPID.Value != "")
                {
                    lblStatusMessage.Text = "वकिलको विवरण सफलतापूर्वक परिवर्तन भयो";
                    hdnPID.Value = "";
                }
                else
                    lblStatusMessage.Text = "वकिलको विवरण सफलतापूर्वक संञ्चयमा भयो";

                ClearControls(sender, e);

                Session["LawyerList"] = "";

                grdNepalBarCouncil.SelectedIndex = -1;
                grdNepalBarCouncil.DataSource = "";
                grdNepalBarCouncil.DataBind();

                ResetControls();

                Session["PIDforLawyerDetail"] = "";


            }
            else
            {
                lblStatusMessage.Text = "वकिलको विवरण संञ्चयमा वाधा उत्पन्न भयो";
            }
            this.programmaticModalPopup.Show();
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
        this.lblPersonnelInfo.Text = "बैयक्तिक विवरण";

        #region "CLEAR PERSONNEL INFORMATION"
        /*The Below Part Clears All The Controls Above The TabPanel. Except txtEmployeeID*/
        /*txtEmployeeID will only be cleared once Submit button or Cancel button is clicked*/
        //this.txtSymbolNo.Text = "";
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
        //this.ddlDistrict.SelectedIndex = 0;
        //this.ddlVDC.DataSource = "";
        //this.ddlVDC.Items.Clear();
        //this.ddlVDC.DataBind();
        //this.ddlWard.DataSource = "";
        //this.ddlWard.Items.Clear();
        //this.ddlWard.DataBind();
        //this.txtTole.Text = "";

        //this.ddlDistrictTemp.SelectedIndex = 0;
        //this.ddlVDCTemp.DataSource = "";
        //this.ddlVDCTemp.Items.Clear();
        //this.ddlVDCTemp.DataBind();
        //this.ddlWardTemp.DataSource = "";
        //this.ddlWardTemp.Items.Clear();
        //this.ddlWardTemp.DataBind();
        //this.txtToleTemp.Text = "";

        //this.hdnPerAddress.Value = "0";
        //this.hdnTempAddress.Value = "0";
        //this.imgDelPerAddress.Visible = false;
        //this.imgDelTempAddress.Visible = false;

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

        //this.txtTrainSubject_Training.Text = "";
        //this.txtTrainCertificate_Training.Text = "";
        //this.ddlTrainInstitution_Training.SelectedIndex = 0;
        //this.txtTrainFromDate_UDTTraining.Text = "";
        //this.txtTrainToDate_UDTTraining.Text = "";
        //this.txtTrainGrade.Text = "";
        //this.txtTrainPercentage.Text = "";
        //this.txtTrainRemarks.Text = "";
        //this.grdTraining.DataSource = "";
        //this.grdTraining.DataBind();
        #endregion

        #region "CLEAR VISIT,DOCUMENTS"
        //this.txtVisitLocation_Visit.Text = "";
        //this.ddlVisitCountry_Visit.SelectedIndex = 0;
        //this.txtVisitFromDate_URDTVisit.Text = "";
        //this.txtVisitToDate_UDTVisit.Text = "";
        //this.txtVisitPurpose_Visit.Text = "";
        //this.txtVisitRemarks.Text = "";
        //this.grdVisits.DataSource = "";
        //this.grdVisits.DataBind();

        //this.ddlDocType_Documents.SelectedIndex = 0;
        //this.txtDocNumber_Documents.Text = "";
        //this.ddlDocIssuedFrom.SelectedIndex = 0;
        //this.txtDocIssuedOn_UDTDocuments.Text = "";
        //this.txtDocIssuedBy.Text = "";
        //this.grdDocuments.DataSource = "";
        //this.grdDocuments.DataBind();
        #endregion

        #region "CLEAR EXPERIENCES"
        //this.txtExpPostingLocation_Experience.Text = "";
        //this.txtExpJobLocation_Experience.Text = "";
        //this.txtExpFromDate_UDTExperience.Text = "";
        //this.txtExpToDate_UDTExperience.Text = "";
        //this.ddlExpClassification.SelectedIndex = 0;
        //this.txtExpRemarks.Text = "";
        //this.grdExperiences.DataSource = "";
        //this.grdExperiences.DataBind();
        #endregion

        #region "CLEAR POSTINGS"
        //ClearPostings();
        //this.grdEmpPostings.DataSource = "";
        //this.grdEmpPostings.DataBind();
        #endregion

        #region "CLEAR RELATIVES"
        //ClearRelativeControls();
        //this.grdEmpRelatives.DataSource = "";
        //this.grdEmpRelatives.DataBind();
        #endregion

        SetPhoneTable();
        SetEMailTable();
        SetQualificationTable();
        SetTrainingTable();
        SetVisitsTable();
        SetExperienceTable();
        SetDocumentsTable();
        SetRelativesTable();
        SetPostingTable();
        SetLawyerInfoTable();
        SetLawyerRenewalTable();
        this.SetPublicationTable();
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
        //this.LoadDocumentsType();
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
        //this.txtEmployeeID.Text = "";

        Session["LawyerList"] = "";

        grdNepalBarCouncil.SelectedIndex = -1;
        grdNepalBarCouncil.DataSource = "";
        grdNepalBarCouncil.DataBind();

        ResetControls();
        Session["PIDforLawyerDetail"] = "";
        

        ClearControls(sender, e);

        LoadPrivateLawyer();

        

        

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
        //ClearPersonSearchFields();
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



    protected void grdEmpPostings_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void imgAddInstitution_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnAddNBA_Click(object sender, EventArgs e)
    {
        try
        {

            if (this.ddlLawyerType_nba.SelectedIndex <= 0)
            {
                this.lblStatusMessage.Text = "Please select lawyer Type.";
                this.programmaticModalPopup.Show();
                return;
            }

            if (this.txtLicence_nba.Text.Trim() == "")
            {
                this.lblStatusMessage.Text = "Please enter the license number.";
                this.programmaticModalPopup.Show();
                return;
            }

            if (this.txtFromDate_nba.Text.Trim() == "")
            {
                this.lblStatusMessage.Text = "Please enter the From Date.";
                this.programmaticModalPopup.Show();
                return;
            }

            List<ATTLawyer> lst = this.LawyerLst;


            ATTLawyer objlawyer = new ATTLawyer();

            if (hdnPID.Value != "")
                objlawyer.PID = double.Parse(hdnPID.Value);
            else
                objlawyer.PID = 0;

            objlawyer.LawyerTypeID = int.Parse(ddlLawyerType_nba.SelectedValue.ToString());
            objlawyer.LawyerTypeName = ddlLawyerType_nba.SelectedItem.ToString();
            objlawyer.LicenseNo = txtLicence_nba.Text;
            objlawyer.FromDate = txtFromDate_nba.Text;

            objlawyer.Action = "A";

            if (this.grdNepalBarCouncil.SelectedIndex >= 0)
            {
                if (this.grdNepalBarCouncil.SelectedRow.Cells[5].Text == "A")
                {
                    objlawyer.Action = this.grdNepalBarCouncil.SelectedRow.Cells[5].Text;
                }
                else
                {
                    objlawyer.Action = "E";
                    objlawyer.PID = int.Parse(this.grdNepalBarCouncil.SelectedRow.Cells[0].Text);
                }
            }


            if (this.grdNepalBarCouncil.SelectedIndex < 0)
                lst.Add(objlawyer);
            else
            {
                lst[this.grdNepalBarCouncil.SelectedIndex].PID = objlawyer.PID;
                lst[this.grdNepalBarCouncil.SelectedIndex].LawyerTypeID = objlawyer.LawyerTypeID;
                lst[this.grdNepalBarCouncil.SelectedIndex].LawyerTypeName = objlawyer.LawyerTypeName;
                lst[this.grdNepalBarCouncil.SelectedIndex].LicenseNo = objlawyer.LicenseNo;
                lst[this.grdNepalBarCouncil.SelectedIndex].FromDate = objlawyer.FromDate;
                lst[this.grdNepalBarCouncil.SelectedIndex].ToDate = objlawyer.ToDate;
                lst[this.grdNepalBarCouncil.SelectedIndex].Action = objlawyer.Action;
            }

            this.grdNepalBarCouncil.SelectedIndex = -1;
            this.grdNepalBarCouncil.DataSource = lst;
            this.grdNepalBarCouncil.DataBind();




            //lblStatusMessage.Text = "";
            //DataTable tmpLawyerInfoTbl = (DataTable)Session["LawyerInfoTbl"];

            //if (tmpLawyerInfoTbl.Rows.Count < 1)
            //{
            //    if (grdNepalBarCouncil.SelectedIndex == -1)
            //    {
            //        DataRow row = tmpLawyerInfoTbl.NewRow();

            //        row[0] = 0;
            //        row[1] = ddlLawyerType_nba.SelectedValue.ToString();
            //        row[2] = ddlLawyerType_nba.SelectedItem.ToString();
            //        row[3] = txtLicence_nba.Text;
            //        row[4] = txtFromDate_nba.Text;
            //        //row[5] = txtToDate_nba.Text;
            //        row[5] = "A";

            //        tmpLawyerInfoTbl.Rows.Add(row);

            //    }
            //    else if(grdNepalBarCouncil.SelectedIndex > 1)
            //    {
            //    }
            //}

            //grdNepalBarCouncil.DataSource = tmpLawyerInfoTbl;
            //grdNepalBarCouncil.DataBind();
            //grdNepalBarCouncil.SelectedIndex = -1;

            ddlLawyerType_nba.SelectedIndex = -1;
            txtFromDate_nba.Text = "";
            txtLicence_nba.Text = "";

            ResetControls();

            //Session["LawyerInfoTbl"] = tmpLawyerInfoTbl;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void grdNepalBarCouncil_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Session["nba_SelectedIndex"] = e.NewSelectedIndex;
    }
    protected void btnAddRenewal_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTLawyer> lst = this.LawyerLst;
            List<ATTLawyerRenewal> lstLawyerRenewal = lst[this.grdNepalBarCouncil.SelectedIndex].LstLawyerRenewal;

            GridViewRow gvRow = this.grdNepalBarCouncil.SelectedRow;

            ATTLawyerRenewal objRenewal = new ATTLawyerRenewal();
            objRenewal.PID = int.Parse(gvRow.Cells[0].Text);
            objRenewal.LawyerTypeID = int.Parse(gvRow.Cells[1].Text);
            objRenewal.LawyerTypeName = gvRow.Cells[2].Text;
            objRenewal.LicenseNo = gvRow.Cells[3].Text;
            objRenewal.RenewalDate = txtRenewalDate_ren.Text;
            objRenewal.RenewalUpto = txtRenewalUpto_ren.Text;
            objRenewal.Action = "A";

            if (this.grdLawyerRenewal.SelectedIndex >= 0)
            {
                if (this.grdLawyerRenewal.SelectedRow.Cells[6].Text == "A")
                {
                    objRenewal.Action = this.grdLawyerRenewal.SelectedRow.Cells[6].Text;
                }
                else
                {
                    objRenewal.Action = "E";
                }
            }


            if (this.grdLawyerRenewal.SelectedIndex < 0)
                lstLawyerRenewal.Add(objRenewal);
            else
            {
                lstLawyerRenewal[this.grdLawyerRenewal.SelectedIndex] = objRenewal;
            }

            this.grdLawyerRenewal.SelectedIndex = -1;
            this.grdLawyerRenewal.DataSource = lstLawyerRenewal;
            this.grdLawyerRenewal.DataBind();

            txtRenewalDate_ren.Text = "";
            txtRenewalUpto_ren.Text = "";
            txtRenewalDate_ren.ReadOnly = false;


            #region "tblVersion"
            //DataTable tmpLawyerRenwTbl = (DataTable)Session["LawyerRenewalTbl"];


            //if (grdLawyerRenewal.SelectedIndex == -1)
            //{
            //    GridViewRow gvRow = grdNepalBarCouncil.Rows[int.Parse(Session["nba_SelectedIndex"].ToString())];
            //    DataRow row = tmpLawyerRenwTbl.NewRow();

            //    row[0] = gvRow.Cells[0].Text;
            //    row[1] = gvRow.Cells[1].Text;
            //    row[2] = gvRow.Cells[2].Text;
            //    row[3] = gvRow.Cells[3].Text;
            //    row[4] = txtRenewalDate_ren.Text;
            //    row[5] = txtRenewalUpto_ren.Text;
            //    row[6] = "A";

            //    tmpLawyerRenwTbl.Rows.Add(row);

            //}
            //else
            //{
            //    DataRow row = tmpLawyerRenwTbl.Rows[this.grdLawyerRenewal.SelectedIndex];

            //    //row[0] = gvRow.Cells[0].Text;
            //    //row[1] = gvRow.Cells[1].Text;
            //    //row[2] = gvRow.Cells[2].Text;
            //    //row[3] = gvRow.Cells[3].Text;
            //    row[4] = txtRenewalDate_ren.Text;
            //    row[5] = txtRenewalUpto_ren.Text;
            //    if ((CheckNullString(row[6].ToString()) == "E") || (CheckNullString(row[6].ToString()) == "") || (CheckNullString(row[6].ToString()) == "N"))
            //        row[6] = "E";
            //    else
            //        row[6] = "A";
            //}

            //grdLawyerRenewal.DataSource = tmpLawyerRenwTbl;
            //grdLawyerRenewal.DataBind();
            //grdLawyerRenewal.SelectedIndex = -1;

            //txtRenewalDate_ren.Text = "";
            //txtRenewalUpto_ren.Text = "";

            ////Session["nba_SelectedIndex"] = "";
            //Session["LawyerRenewalTbl"] = tmpLawyerRenwTbl;



            //List<ATTPrivateLawyer> lst = this.PrivateLawyerLst;
            //List<ATTPrivateLawyerRenewal> lstRenewal = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal;

            //GridViewRow row = this.grdPrivateLawyer.SelectedRow;

            //ATTPrivateLawyerRenewal renewal = new ATTPrivateLawyerRenewal();
            //renewal.PersonID = 0;
            //renewal.LawyerTypeID = int.Parse(row.Cells[1].Text);
            //renewal.Lisence = row.Cells[2].Text;
            //renewal.UnitID = int.Parse(row.Cells[3].Text);
            //renewal.UnitName = row.Cells[4].Text; ;
            //renewal.RenewalDate = this.txtPrivateRenFrom.Text;
            //renewal.RenewalUpto = this.txtPrivateRenUpto.Text;
            //renewal.EntryBy = "sj";
            //renewal.Action = "A";

            //if (this.grdPrivateRenewal.SelectedIndex >= 0)
            //{
            //    if (this.grdPrivateRenewal.SelectedRow.Cells[8].Text == "A")
            //    {
            //        renewal.Action = this.grdPrivateRenewal.SelectedRow.Cells[8].Text;
            //    }
            //    else
            //    {
            //        renewal.Action = "E";
            //    }
            //}

            //if (this.grdPrivateRenewal.SelectedIndex < 0)
            //    lstRenewal.Add(renewal);
            //else
            //{
            //    lstRenewal[this.grdPrivateRenewal.SelectedIndex] = renewal;
            //}

            //this.grdPrivateRenewal.SelectedIndex = -1;
            //this.grdPrivateRenewal.DataSource = lstRenewal;
            //this.grdPrivateRenewal.DataBind();

            //this.txtPrivateRenFrom.Text = "";
            //this.txtPrivateRenUpto.Text = "";
            #endregion


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void grdNepalBarCouncil_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[0].Visible = false;
        row.Cells[1].Visible = false;
        row.Cells[5].Visible = false;
    }
    protected void grdLawyerRenewal_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[0].Visible = false;
        row.Cells[1].Visible = false;
        row.Cells[6].Visible = false;
    }

    protected void btnAddPrivateLawyer_Click(object sender, EventArgs e)
    {
        try
        {

            if (this.ddlPrivateUnit_pl.SelectedIndex <= 0)
            {
                this.lblStatusMessage.Text = "Please select unit from list.";
                this.programmaticModalPopup.Show();
                return;
            }

            if (this.txtPrivateFromDate_pl.Text.Trim() == "")
            {
                this.lblStatusMessage.Text = "Please enter private registration date.";
                this.programmaticModalPopup.Show();
                return;
            }

            //GridViewRow gvRow = grdNepalBarCouncil.Rows[int.Parse(Session["nba_SelectedIndex"].ToString())];

            GridViewRow gvRow = grdNepalBarCouncil.SelectedRow;

            List<ATTLawyer> lstLawyer = this.LawyerLst;

            List<ATTPrivateLawyer> lst = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstPrivateLawyer;


            //List<ATTPrivateLawyer> lst = this.PrivateLawyerLst;


            ATTPrivateLawyer lawyer = new ATTPrivateLawyer();
            //lawyer.PersonID = 0;
            lawyer.PersonID = int.Parse(gvRow.Cells[0].Text);
            //lawyer.LawyerTypeID = 1;
            //lawyer.Lisence = "1632";
            lawyer.LawyerTypeID = int.Parse(gvRow.Cells[1].Text);
            lawyer.Lisence = gvRow.Cells[3].Text; ;
            lawyer.UnitID = int.Parse(this.ddlPrivateUnit_pl.SelectedValue);
            lawyer.UnitName = this.ddlPrivateUnit_pl.SelectedItem.Text;
            lawyer.FromDate = this.txtPrivateFromDate_pl.Text;
            lawyer.ToDate = "";
            lawyer.EntryBy = "sj";
            lawyer.Action = "A";

            if (this.grdPrivateLawyer.SelectedIndex >= 0)
            {
                if (this.grdPrivateLawyer.SelectedRow.Cells[8].Text == "A")
                {
                    lawyer.Action = this.grdPrivateLawyer.SelectedRow.Cells[8].Text;
                }
                else
                {
                    lawyer.Action = "E";
                }
            }

            if (this.grdPrivateLawyer.SelectedIndex < 0)
                lst.Add(lawyer);
            else
            {
                lst[this.grdPrivateLawyer.SelectedIndex].PersonID = lawyer.PersonID;
                lst[this.grdPrivateLawyer.SelectedIndex].LawyerTypeID = lawyer.LawyerTypeID;
                lst[this.grdPrivateLawyer.SelectedIndex].UnitID = lawyer.UnitID;
                lst[this.grdPrivateLawyer.SelectedIndex].UnitName = lawyer.UnitName;
                lst[this.grdPrivateLawyer.SelectedIndex].Lisence = lawyer.Lisence;
                lst[this.grdPrivateLawyer.SelectedIndex].FromDate = lawyer.FromDate;
                lst[this.grdPrivateLawyer.SelectedIndex].ToDate = lawyer.ToDate;
                lst[this.grdPrivateLawyer.SelectedIndex].Action = lawyer.Action;
            }

            this.grdPrivateLawyer.SelectedIndex = -1;
            this.grdPrivateLawyer.DataSource = lst;
            this.grdPrivateLawyer.DataBind();

            this.ClearPrivateLawyer();
            this.ClearRenewal();

            ddlPrivateUnit_pl.Enabled = true;

            //hdnPlDate.Value = "";

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    void Clear()
    {
        this.ClearLawyer();
        this.ClearRenewal();
    }

    void ClearLawyer()
    {
        this.ddlPrivateUnit_pl.SelectedIndex = 0;
        this.txtPrivateFromDate_pl.Text = "";
        this.grdPrivateLawyer.SelectedIndex = -1;
        this.grdPrivateLawyer.DataSource = "";
        this.grdPrivateLawyer.DataBind();
    }

    void ClearPrivateLawyer()
    {
        this.ddlPrivateUnit_pl.SelectedIndex = 0;
        this.txtPrivateFromDate_pl.Text = "";
    }

    void ClearRenewal()
    {
        this.txtPrivateRenFrom_plr.Text = "";
        this.txtPrivateRenUpto_plr.Text = "";
        this.grdPrivateRenewal.SelectedIndex = -1;
        this.grdPrivateRenewal.DataSource = "";
        this.grdPrivateRenewal.DataBind();
    }


    protected void btnAddPrivateRenewal_Click(object sender, EventArgs e)
    {
        if (this.grdPrivateLawyer.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select private lawyer registration.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPrivateRenFrom_plr.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Please enter registration renwal date.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPrivateRenUpto_plr.Text.Trim() == "")
        {
            this.lblStatusMessage.Text = "Please enter registration renewal upto date.";
            this.programmaticModalPopup.Show();
            return;
        }

        //List<ATTPrivateLawyer> lst = this.PrivateLawyerLst;
        //List<ATTPrivateLawyerRenewal> lstRenewal = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal;

        List<ATTLawyer> lstLawyer = this.LawyerLst;
        List<ATTPrivateLawyer> lst = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstPrivateLawyer;
        List<ATTPrivateLawyerRenewal> lstRenewal = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal;

        GridViewRow row = this.grdPrivateLawyer.SelectedRow;

        ATTPrivateLawyerRenewal renewal = new ATTPrivateLawyerRenewal();
        renewal.PersonID = int.Parse(row.Cells[0].Text);
        renewal.LawyerTypeID = int.Parse(row.Cells[1].Text);
        renewal.Lisence = row.Cells[2].Text;
        renewal.UnitID = int.Parse(row.Cells[3].Text);
        renewal.UnitName = row.Cells[4].Text; ;
        renewal.RenewalDate = this.txtPrivateRenFrom_plr.Text;
        renewal.RenewalUpto = this.txtPrivateRenUpto_plr.Text;
        renewal.EntryBy = "sj";
        renewal.Action = "A";

        if (this.grdPrivateRenewal.SelectedIndex >= 0)
        {
            if (this.grdPrivateRenewal.SelectedRow.Cells[8].Text == "A")
            {
                renewal.Action = this.grdPrivateRenewal.SelectedRow.Cells[8].Text;
            }
            else
            {
                renewal.Action = "E";
            }
        }

        if (this.grdPrivateRenewal.SelectedIndex < 0)
            lstRenewal.Add(renewal);
        else
        {
            lstRenewal[this.grdPrivateRenewal.SelectedIndex] = renewal;
        }

        this.grdPrivateRenewal.SelectedIndex = -1;
        this.grdPrivateRenewal.DataSource = lstRenewal;
        this.grdPrivateRenewal.DataBind();

        this.txtPrivateRenFrom_plr.Text = "";
        this.txtPrivateRenUpto_plr.Text = "";

        txtPrivateRenFrom_plr.ReadOnly = false;
    }
    protected void grdPrivateLawyer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
    }
    protected void grdPrivateLawyer_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool flag = false;

        GridViewRow gvRow = grdPrivateLawyer.Rows[grdPrivateLawyer.SelectedIndex];
        
        if (gvRow.Cells[8].Text.Trim() == "A")
        {
            ddlPrivateUnit_pl.Enabled = true;
        }
        else
        {
            ddlPrivateUnit_pl.Enabled = false;
        }


        LinkButton lnkBtn = (LinkButton)gvRow.Cells[9].Controls[0];

        if (lnkBtn.Text.Trim() == "Select")
        {
            hdnPlDate.Value = gvRow.Cells[5].Text;

            //string id = hdnLDate.Value;
            lnkBtn.Text = "UnSelect";

            List<ATTLawyer> lstLawyer = this.LawyerLst;
            List<ATTPrivateLawyer> lst = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstPrivateLawyer;
            List<ATTPrivateLawyerRenewal> lstRenewal = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal;

            this.ddlPrivateUnit_pl.SelectedValue = lst[this.grdPrivateLawyer.SelectedIndex].UnitID.ToString();
            this.txtPrivateFromDate_pl.Text = lst[this.grdPrivateLawyer.SelectedIndex].FromDate;

            this.grdPrivateRenewal.SelectedIndex = -1;
            this.grdPrivateRenewal.DataSource = lstRenewal;
            this.grdPrivateRenewal.DataBind();

            Label411.Visible = true;
            Label405.Visible = true;
            txtPrivateRenFrom_plr.Visible = true;
            txtPrivateRenUpto_plr.Visible = true;
            btnAddPrivateRenewal.Visible = true;

            flag = true;
        }
        else
        {

            lnkBtn.Text = "Select";

            grdPrivateLawyer.SelectedIndex = -1;
            this.grdPrivateRenewal.DataSource = "";
            this.grdPrivateRenewal.DataBind();

            Label411.Visible = false;
            Label405.Visible = false;
            txtPrivateRenFrom_plr.Visible = false;
            txtPrivateRenUpto_plr.Visible = false;
            btnAddPrivateRenewal.Visible = false;

            ddlPrivateUnit_pl.SelectedIndex = -1;

            this.txtPrivateFromDate_pl.Text = "";

            ddlPrivateUnit_pl.Enabled = true;

            //hdnPlDate.Value = "";
        }

        this.txtPrivateRenFrom_plr.Text = "";
        this.txtPrivateRenUpto_plr.Text = "";

        


        if (flag)
        {
            foreach (GridViewRow gvr in grdPrivateLawyer.Rows)
            {
                if (gvr.RowIndex != grdPrivateLawyer.SelectedIndex)
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[9].Controls[0];

                    if (lnkBtn1.Text.Trim() == "UnSelect")
                    {
                        lnkBtn1.Text = "Select";
                    }
                }
            }
        }
    }
    protected void grdPrivateRenewal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
    }
    protected void grdPrivateRenewal_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool flag = false;
        GridViewRow gvRow = grdPrivateRenewal.Rows[grdPrivateRenewal.SelectedIndex];

        if (gvRow.Cells[8].Text.Trim() == "A")
        {
            txtPrivateRenFrom_plr.ReadOnly = false;
        }
        else
        {
            txtPrivateRenFrom_plr.ReadOnly= true;
        }

        LinkButton lnkBtn = (LinkButton)gvRow.Cells[9].Controls[0];

        if (lnkBtn.Text.Trim() == "Select")
        {
            lnkBtn.Text = "UnSelect";

            List<ATTLawyer> lstLawyer = this.LawyerLst;
            List<ATTPrivateLawyer> lst = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstPrivateLawyer;
            List<ATTPrivateLawyerRenewal> lstRenewal = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal;

            this.txtPrivateRenFrom_plr.Text = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal[this.grdPrivateRenewal.SelectedIndex].RenewalDate;
            this.txtPrivateRenUpto_plr.Text = lst[this.grdPrivateLawyer.SelectedIndex].LstRenewal[this.grdPrivateRenewal.SelectedIndex].RenewalUpto;

            flag = true;
        }
        else
        {
            lnkBtn.Text = "Select";

            this.txtPrivateRenFrom_plr.Text = "";
            this.txtPrivateRenUpto_plr.Text = "";

            grdPrivateRenewal.SelectedIndex = -1;

            txtPrivateRenFrom_plr.ReadOnly = false;

        }

        if (flag)
        {
            foreach (GridViewRow gvr in grdPrivateRenewal.Rows)
            {
                if (gvr.RowIndex != grdPrivateRenewal.SelectedIndex)
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[9].Controls[0];

                    if (lnkBtn1.Text.Trim() == "UnSelect")
                    {
                        lnkBtn1.Text = "Select";
                    }
                }
            }
        }
        
    }
    protected void grdNepalBarCouncil_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadUnit();
        ResetControls();

        bool flag = false;

        GridViewRow gvRow = grdNepalBarCouncil.Rows[grdNepalBarCouncil.SelectedIndex];
        LinkButton lnkBtn = (LinkButton)gvRow.Cells[6].Controls[0];

        if (lnkBtn.Text.Trim() == "Select")
        {
            lnkBtn.Text = "UnSelect";

            hdnLDate.Value = gvRow.Cells[4].Text;

            //TextBox1.Text = gvRow.Cells[4].Text;

            List<ATTLawyer> lstLawyer = this.LawyerLst;
            List<ATTLawyerRenewal> lstRenewal = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstLawyerRenewal;
            List<ATTPrivateLawyer> lst = lstLawyer[this.grdNepalBarCouncil.SelectedIndex].LstPrivateLawyer;

            if (lstRenewal.Count > 0)
            {

                this.grdLawyerRenewal.SelectedIndex = -1;
                this.grdLawyerRenewal.DataSource = lstRenewal;
                this.grdLawyerRenewal.DataBind();
            }
            else
            {
                this.grdLawyerRenewal.DataSource = "";
                this.grdLawyerRenewal.DataBind();
            }

            if (lst.Count > 0)
            {
                this.grdPrivateLawyer.SelectedIndex = -1;
                this.grdPrivateLawyer.DataSource = lst;
                this.grdPrivateLawyer.DataBind();
            }
            else
            {
                this.grdPrivateLawyer.SelectedIndex = -1;
                this.grdPrivateLawyer.DataSource = "";
                this.grdPrivateLawyer.DataBind();
            }

            btnAddNBA.Visible = false;

            flag = true;
        }
        else
        {
            lnkBtn.Text = "Select";

            this.grdNepalBarCouncil.SelectedIndex = -1;

            this.grdLawyerRenewal.DataSource = "";
            this.grdLawyerRenewal.DataBind();

            this.grdPrivateLawyer.DataSource = "";
            this.grdPrivateLawyer.DataBind();

            btnAddNBA.Visible = true;

            lblRenewalDate.Visible = false;
            txtRenewalDate_ren.Visible = false;
            lblRenewalUpTo.Visible = false;
            txtRenewalUpto_ren.Visible = false;
            btnAddRenewal.Visible = false;

            lblUnit.Visible = false;
            ddlPrivateUnit_pl.Visible = false;
            lblFromDate1.Visible = false;
            txtPrivateFromDate_pl.Visible = false;
            btnAddPrivateLawyer.Visible = false;

            hdnLDate.Value = "";
        }

        if (flag)
        {
            foreach (GridViewRow gvr in grdNepalBarCouncil.Rows)
            {
                if (gvr.RowIndex != grdNepalBarCouncil.SelectedIndex)
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[6].Controls[0];

                    if (lnkBtn1.Text.Trim() == "UnSelect")
                    {
                        lnkBtn1.Text = "Select";
                    }
                }
            }
        }

        

        this.txtRenewalDate_ren.Text = "";
        this.txtRenewalUpto_ren.Text = "";
        
    }

    public void ResetControls()
    {
        if (grdNepalBarCouncil.SelectedIndex > -1)
        {
            btnAddNBA.Visible = false;

            lblRenewalDate.Visible = true;
            txtRenewalDate_ren.Visible = true;
            lblRenewalUpTo.Visible = true;
            txtRenewalUpto_ren.Visible = true;
            btnAddRenewal.Visible = true;

            lblUnit.Visible = true;
            ddlPrivateUnit_pl.Visible = true;
            lblFromDate1.Visible = true;
            txtPrivateFromDate_pl.Text = "";
            txtPrivateFromDate_pl.Visible = true;
            btnAddPrivateLawyer.Visible = true;


            Label411.Visible = false;
            Label405.Visible = false;
            txtPrivateRenFrom_plr.Visible = false;
            txtPrivateRenUpto_plr.Visible = false;
            btnAddPrivateRenewal.Visible = false;

            grdLawyerRenewal.SelectedIndex = -1;
            grdLawyerRenewal.DataSource = "";
            grdLawyerRenewal.DataBind();

            grdPrivateLawyer.SelectedIndex = -1;
            grdPrivateLawyer.DataSource = "";
            grdPrivateLawyer.DataBind();

            grdPrivateRenewal.SelectedIndex = -1;
            grdPrivateRenewal.DataSource = "";
            grdPrivateRenewal.DataBind();
        }
        else
        {
            btnAddNBA.Visible = true;

            lblRenewalDate.Visible = false;
            txtRenewalDate_ren.Visible = false;
            lblRenewalUpTo.Visible = false;
            txtRenewalUpto_ren.Visible = false;
            btnAddRenewal.Visible = false;

            lblUnit.Visible = false;
            ddlPrivateUnit_pl.Visible = false;
            lblFromDate1.Visible = false;
            txtPrivateFromDate_pl.Visible = false;
            btnAddPrivateLawyer.Visible = false;


            Label411.Visible = false;
            Label405.Visible = false;
            txtPrivateRenFrom_plr.Visible = false;
            txtPrivateRenUpto_plr.Visible = false;
            btnAddPrivateRenewal.Visible = false;

            grdLawyerRenewal.SelectedIndex = -1;
            grdLawyerRenewal.DataSource = "";
            grdLawyerRenewal.DataBind();

            grdPrivateLawyer.SelectedIndex = -1;
            grdPrivateLawyer.DataSource = "";
            grdPrivateLawyer.DataBind();

            grdPrivateRenewal.SelectedIndex = -1;
            grdPrivateRenewal.DataSource = "";
            grdPrivateRenewal.DataBind();
        }

        
    }
    protected void grdLawyerRenewal_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvRow = grdLawyerRenewal.Rows[grdLawyerRenewal.SelectedIndex];

        bool flag = false;

        LinkButton lnkBtn = (LinkButton)gvRow.Cells[7].Controls[0];

        if (gvRow.Cells[6].Text.Trim() == "A")
        {
            txtRenewalDate_ren.ReadOnly = false;
        }
        else
        {
            txtRenewalDate_ren.ReadOnly = true;
        }


        if (lnkBtn.Text.Trim() == "Select")
        {
            lnkBtn.Text = "UnSelect";
            txtRenewalDate_ren.Text = gvRow.Cells[4].Text;
            txtRenewalUpto_ren.Text = gvRow.Cells[5].Text;

            flag = true;
        }
        else
        {
            lnkBtn.Text = "Select";
            txtRenewalDate_ren.Text = "";
            txtRenewalUpto_ren.Text = "";
            grdLawyerRenewal.SelectedIndex = -1;

            txtRenewalDate_ren.ReadOnly = false;
            //grdLawyerRenewal.SelectedIndex = -1;
        }

        

        if (flag)
        {
            foreach (GridViewRow gvr in grdLawyerRenewal.Rows)
            {
                if (gvr.RowIndex != grdLawyerRenewal.SelectedIndex)
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[7].Controls[0];

                    if (lnkBtn1.Text.Trim() == "UnSelect")
                    {
                        lnkBtn1.Text = "Select";
                    }
                }
            }
        }

    }
}