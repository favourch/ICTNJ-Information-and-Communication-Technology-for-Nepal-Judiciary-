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
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;


public partial class MODULES_CMS_Forms_CaseRegistration2 : System.Web.UI.Page
{
    string strAppOrResp = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.Page.IsPostBack == false)
        {
            LoadDistricts();
            LoadReligion();
            LoadCountry();
            SetPhoneTable();
            SetEMailTable();
            Session["CaseLawyer"] = new List<ATTCaseLaywer>();


            if (Session["CaseNo"] != null)
            {
                this.txtCaseID.Text = Session["CaseNo"].ToString();
                Session["CaseNo"] = null;
       
                ATTCaseRegistration objCR = ((List<ATTCaseRegistration>)BLLCaseRegistration.GetCaseRegistration(double.Parse(this.txtCaseID.Text), 1,0, 1, 0, 0, 0, 0, 0, 1, null))[0];
       
                LoadCaseRegistrationDetails(objCR, sender, e);
                LoadLawyers(double.Parse(this.txtCaseID.Text));

            }
        }
    }

    void LoadCountry()
    {
        this.ddlCountry.DataSource = BLLCountry.GetCountries(null, 0);
        this.ddlCountry.DataTextField = "CountryNepName";
        this.ddlCountry.DataValueField = "CountryId";
        this.DataBind();
    }

    public void LoadLawyers(double caseNo)
    {
        Session["CaseLawyer"] = BLLCaseLawyer.GetCaseLawyer(caseNo, null, null);
        //((List<ATTWitnessPerson>)Session["CaseLawyer"]).Sort(delegate(ATTWitnessPerson o1, ATTWitnessPerson o2)
        //                                       {
        //                                           return o1.LitigantType.CompareTo(o2.LitigantType).CompareTo(o1.LitigantID.CompareTo(o2.LitigantID));
        //                                       });

        this.grdLitigantLawyer.DataSource = (List<ATTCaseLaywer>)Session["CaseLawyer"];
        this.grdLitigantLawyer.DataBind();
    }

    public ATTCaseRegistration LoadCaseRegistrationDetails(ATTCaseRegistration objCaseRegistration, object sender, EventArgs e)
    {

        lblCaseNo.Text = objCaseRegistration.CaseID.ToString();
        //lblCaseName.Text = objCaseRegistration.RegDiaryNameID.ToString();
        //lblRegDate.Text = objCaseRegistration.CaseRegistrationDate;

        //Case Details
        this.lblCaseType.Text = objCaseRegistration.CaseTypeName;
        this.lblRegType.Text = objCaseRegistration.RegTypeName;
        this.lblRegDiary.Text = objCaseRegistration.RegDiaryName;
        this.lblRegSubject.Text = objCaseRegistration.RegSubjectName;
        this.lblRegSubName.Text = objCaseRegistration.RegDiarySubName;
        this.lblRegDate.Text = objCaseRegistration.CaseRegistrationDate;
        this.lblPreceedingType.Text = objCaseRegistration.ProceedingType;
        this.lblForwardToAccount.Text = objCaseRegistration.AccountForwarded == "Y" ? "पठाउने" : "नपठाउने";

        this.grdAppellant.DataSource = objCaseRegistration.AppellantLST;
        this.grdAppellant.DataBind();

        this.grdRespondant.DataSource = objCaseRegistration.RespondantLST;
        this.grdRespondant.DataBind();

        return objCaseRegistration;


        //ATTCaseRegistration objCR = ((List<ATTCaseRegistration>)BLLCaseRegistration.GetCaseRegistration(caseNo, 1, 1, 0, 0, 0, 0, 0, 1,null))[0];


        //Session["Appellant"] = objCR.AppellantLST;
        //Session["Respondant"] = objCR.RespondantLST;

        //this.grdAppellant.DataSource = objCR.AppellantLST;
        //this.grdAppellant.DataBind();

        //this.grdRespondant.DataSource = objCR.RespondantLST;
        //this.grdRespondant.DataBind();

        //return objCR;


    }

    #region "SET PHONE AND EMAIL TABLE"
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

    #endregion

    void LoadReligion()
    {
        this.ddlReligion.DataSource = BLLReligion.GetReligions(null, 0);
        this.ddlReligion.DataTextField = "ReligionNepName";
        this.ddlReligion.DataValueField = "ReligionId";
        this.DataBind();
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
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdAppellant_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdRespondant.SelectedIndex = -1;
        strAppOrResp = "A";
    }
    protected void grdRespondant_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdAppellant.SelectedIndex = -1;
        strAppOrResp = "R";
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
    protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void ddlWardTemp_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void grdEMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
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
    protected void imgDelPerAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgDelTempAddress_Click(object sender, ImageClickEventArgs e)
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
    protected void btnAddPerson_Click(object sender, EventArgs e)
    {



    }

    private ATTPerson getPerson()
    {
        int iniUnit = 3;
        double pID = 0;
        int iniType = 9;
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;


        //ATTPerson objPerson = new ATTPerson();
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

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
        //    this.txtMName_RQD.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
        //    this.txtDOB_DT.Text.Trim(), ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
        //    ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
        //    "", "", intCountryId, intBirthDistrict, intReligion,
        //    iniUnit, iniType, "manoz", DateTime.Now, new byte[0]);
        //objPerson.FullName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName_RQD.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
        //objPerson.EntityType = "P";

        ATTPerson objPerson = new ATTPerson();
        objPerson.PId = pID;
        objPerson.FirstName = this.txtFName_Rqd.Text.Trim();
        objPerson.MidName = this.txtMName_RQD.Text.Trim();
        objPerson.SurName = this.txtSurName_Rqd.Text.Trim();
        objPerson.DOB = this.txtDOB_DT.Text;
        objPerson.Gender = this.ddlGender.SelectedIndex <= 0 ? "" : this.ddlGender.SelectedValue;
        objPerson.MaritalStatus = this.ddlMarStatus.SelectedIndex <= 0 ? "" : this.ddlMarStatus.SelectedValue;
        objPerson.FatherName = "";
        objPerson.GFatherName = "";
        objPerson.CountryId = intCountryId;
        objPerson.BirthDistrict = intBirthDistrict;
        objPerson.ReligionId = intReligion;
        objPerson.IniUnit = iniUnit;
        objPerson.IniType = iniType;
        objPerson.EntryBy = user.UserName;
        objPerson.EntryDate = DateTime.Now;
        objPerson.Photo = new byte[0];
        //        objPerson.FullName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName_RQD.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
        objPerson.EntityType = "P";



        if (this.grdLitigantLawyer.SelectedIndex == -1)
            objPerson.Action = "A";
        else
        {
            objPerson.Action = "E";
        }

        #endregion


        #region "ADDRESS"
        //int? intDistrictAddress = null;
        //int? intVDCAddress = null;
        //int? intWardAddress = null;
        //string strAddressAction = "";
        //ATTPersonAddress PersonAddressATT = null;
        //if (this.ddlDistrict.SelectedIndex > 0 || this.ddlVDC.SelectedIndex > 0 || this.ddlWard.SelectedIndex > 0 || this.txtTole.Text != "")
        //{
        //    if (this.ddlDistrict.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrict.SelectedValue);
        //    if (this.ddlVDC.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDC.SelectedValue);
        //    if (this.ddlWard.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWard.SelectedValue);
        //    PersonAddressATT = new ATTPersonAddress
        //        (
        //        0, "P", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtTole.Text.Trim(), "Y", "manoz", DateTime.Now
        //        );

        //    if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value != "0")) strAddressAction = "E";
        //    if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value == "0")) strAddressAction = "A";
        //    if (((this.ddlDistrict.SelectedIndex <= 0) && (this.txtTole.Text.Trim() == "")) && (hdnPerAddress.Value != "0")) strAddressAction = "D";
        //    if (strAddressAction != "")
        //    {
        //        PersonAddressATT.Action = strAddressAction;
        //        strAddressAction = "";
        //        objPerson.LstPersonAddress.Add(PersonAddressATT);
        //    }
        //}

        //if (this.ddlDistrictTemp.SelectedIndex > 0 || this.ddlVDCTemp.SelectedIndex > 0 || this.ddlWardTemp.SelectedIndex > 0 || this.txtToleTemp.Text != "")
        //{
        //    strAddressAction = "";
        //    intDistrictAddress = null;
        //    intVDCAddress = null;
        //    intWardAddress = null;

        //    if (this.ddlDistrictTemp.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrictTemp.SelectedValue);
        //    if (this.ddlVDCTemp.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDCTemp.SelectedValue);
        //    if (this.ddlWardTemp.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWardTemp.SelectedValue);
        //    PersonAddressATT = new ATTPersonAddress
        //        (
        //        0, "T", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtToleTemp.Text.Trim(), "Y", "manoz", DateTime.Now
        //        );

        //    if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value != "0")) strAddressAction = "E";
        //    if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value == "0")) strAddressAction = "A";
        //    if (((this.ddlDistrictTemp.SelectedIndex <= 0) && (this.txtToleTemp.Text.Trim() == "")) && (hdnTempAddress.Value != "0")) strAddressAction = "D";
        //    if (strAddressAction != "")
        //    {
        //        PersonAddressATT.Action = strAddressAction;
        //        strAddressAction = "";
        //        objPerson.LstPersonAddress.Add(PersonAddressATT);
        //    }

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

            if (this.txtTempAdd.Text == "")
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


        return objPerson;

    }




    protected void btnAddLawyer_Click(object sender, EventArgs e)
    {
        #region "VALIDATIONS"
        if (this.txtFName_Rqd.Text == "" || this.txtSurName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Witness' First Name or Sur Name Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        //if (this.txtLawyerFromDate.Text == "")
        //{
        //    this.lblStatusMessage.Text = "Witness From Date Can't Be Left Blank";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}

        //if (this.txtLawyerToDate.Text != "")
        //{
        //    if (this.txtLawyerFromDate.Text.CompareTo(this.txtLawyerToDate.Text) >= 0)
        //    {
        //        this.lblStatusMessage.Text = "<B>अवधि देखि</B> मिति <B>अवधि सम्म</B> मिति भन्दा ठूलो हुन सक्दैन ।";
        //        this.programmaticModalPopup.Show();
        //        return;
        //    }
        //}

        int count = 0;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                count += 1;
            }
        }

        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                count += 1;
            }
        }

        if (count == 0)
        {
            this.lblStatusMessage.Text = "Please Select Either Appellant or Respondant to assign Lawyer";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTCaseLaywer> CaseLawyerLST = (List<ATTCaseLaywer>)Session["CaseLawyer"];
        ATTCaseLaywer objCaseLawyer = new ATTCaseLaywer();
        //if (this.grdLitigantLawyer.SelectedIndex==-1)
        objCaseLawyer.LitigantID = this.grdLitigantLawyer.SelectedIndex == -1 ? 0 : double.Parse(this.grdLitigantLawyer.SelectedRow.Cells[2].Text);
        //objCaseLawyer.PersonID = this.grdLitigantLawyer.SelectedIndex == -1 ? 0 : double.Parse(this.grdLitigantLawyer.SelectedRow.Cells[11].Text);
        objCaseLawyer.LawyerID= this.grdLitigantLawyer.SelectedIndex == -1 ? 0 : int.Parse(this.grdLitigantLawyer.SelectedRow.Cells[4].Text);
        objCaseLawyer.LawyerName= this.txtFName_Rqd.Text + " " + this.txtMName_RQD.Text + " " + this.txtSurName_Rqd.Text;
        objCaseLawyer.FromDate = this.lblRegDate.Text; //this.txtLawyerFromDate.Text;
        objCaseLawyer.EntryBy = user.UserName;

        objCaseLawyer.PersonOBJ = getPerson();
        if (BLLPerson.SavePerson(objCaseLawyer.PersonOBJ) == true)
        {
            objCaseLawyer.LawyerID= objCaseLawyer.PersonOBJ.PId;

            ATTCaseLaywer objCaseLawyerLit;

            //PREPARES LIST OF APPLICANTS IF APPELLANT IS SELECTED
            foreach (GridViewRow gvRow in this.grdAppellant.Rows)
            {
                objCaseLawyerLit = new ATTCaseLaywer();
                if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
                {
                    objCaseLawyerLit.CaseID = double.Parse(this.lblCaseNo.Text);
                    objCaseLawyerLit.LitigantType = "A";
                    objCaseLawyerLit.LitigantID = double.Parse(gvRow.Cells[1].Text);
                    objCaseLawyerLit.LitigantName = gvRow.Cells[2].Text;
                    //objCaseLawyer.PersonID = objCaseLawyer.PersonID;
                    objCaseLawyerLit.LawyerID = objCaseLawyer.LawyerID;
                    objCaseLawyerLit.LawyerName = objCaseLawyer.LawyerName;
                    objCaseLawyerLit.FromDate = this.lblRegDate.Text; //this.txtLawyerFromDate.Text;
                    objCaseLawyerLit.ToDate = "";// this.txtLawyerToDate.Text;
                    if (this.grdLitigantLawyer.SelectedIndex == -1)
                    {
                        objCaseLawyerLit.Action = "A";
                        CaseLawyerLST.Add(objCaseLawyerLit);
                    }
                    else
                    {
                        objCaseLawyerLit.Action = CaseLawyerLST[this.grdLitigantLawyer.SelectedIndex].Action == "A" ? "A" : "E";
                        CaseLawyerLST[this.grdLitigantLawyer.SelectedIndex] = objCaseLawyerLit;
                    }


                }
            }

            //PREPARES LIST OF RESPONDS IF RESPONDANT IS SELECTED
            foreach (GridViewRow gvRow in this.grdRespondant.Rows)
            {
                objCaseLawyerLit = new ATTCaseLaywer();
                if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
                {
                    objCaseLawyerLit.CaseID = double.Parse(this.lblCaseNo.Text);
                    objCaseLawyerLit.LitigantType = "R";
                    objCaseLawyerLit.LitigantID = double.Parse(gvRow.Cells[1].Text);
                    objCaseLawyerLit.LitigantName = gvRow.Cells[2].Text;
                    //objCaseLawyer.PersonID = objCaseLawyer.PersonID;
                    objCaseLawyerLit.LawyerName = objCaseLawyer.LawyerName;
                    objCaseLawyerLit.FromDate = this.lblRegDate.Text; //this.txtLawyerFromDate.Text;
                    objCaseLawyerLit.ToDate = "";// this.txtLawyerToDate.Text;
                    if (this.grdLitigantLawyer.SelectedIndex == -1)
                        CaseLawyerLST.Add(objCaseLawyerLit);
                    else
                        CaseLawyerLST[this.grdLitigantLawyer.SelectedIndex] = objCaseLawyerLit;
                }
            }



            //SORTS THE LIST
            //CaseLawyerLST.Sort(delegate(ATTCaseLaywer obj1, ATTCaseLaywer obj2)
            //                        {
            //                            return obj1.LitigantType.CompareTo(obj2.LitigantType);
            //                        });

            CaseLawyerLST.Sort(delegate(ATTCaseLaywer obj1, ATTCaseLaywer obj2)
                                    {
                                        return obj1.LitigantID.CompareTo(obj2.LitigantID);
                                    });

            //foreach (ATTCaseLaywer obj in CaseLawyerLST)
            //{
            //    Response.Write(obj.LitigantID+"<BR>");
            //}

            
            this.grdLitigantLawyer.DataSource = CaseLawyerLST;
            this.grdLitigantLawyer.DataBind();

            //this.grdLitigantLawyer.Sort(

            //UNCHECKS THE APPELLANT
            foreach (GridViewRow gvRow in this.grdAppellant.Rows)
            {
                ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
            }

            //UNCHECKS THE RESPONDANT
            foreach (GridViewRow gvRow in this.grdRespondant.Rows)
            {
                ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
            }

            this.grdLitigantLawyer.SelectedIndex = -1;
            this.grdAppellant.Enabled = true;
            this.grdRespondant.Enabled = true;
            this.pnlPersonnelInfo.Enabled = true;

            ClearContros(sender, e);



        }
    }
    protected void grdLitigantLawyer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtLawyerFromDate.Text = "";
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Enabled = false;
        }
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Enabled = false;
        }
        //this.grdAppellant.Enabled = false;
        //this.grdRespondant.Enabled = false;
        //this.pnlPersonnelInfo.Enabled = false;

        List<ATTCaseLaywer> WPLST = (List<ATTCaseLaywer>)Session["CaseLawyer"];

        if (this.grdLitigantLawyer.SelectedRow.Cells[1].Text == "वादि")
        {
            foreach (GridViewRow gvRow in this.grdRespondant.Rows)
            {
                ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
            }
            foreach (GridViewRow gvRow in this.grdAppellant.Rows)
            {
                if (this.grdLitigantLawyer.SelectedRow.Cells[2].Text == gvRow.Cells[1].Text)
                    ((CheckBox)gvRow.FindControl("chkSelect")).Checked = true;

            }
        }
        else
        {
            foreach (GridViewRow gvRow in this.grdAppellant.Rows)
            {
                ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
            }
            foreach (GridViewRow gvRow in this.grdRespondant.Rows)
            {
                if (this.grdLitigantLawyer.SelectedRow.Cells[2].Text == gvRow.Cells[1].Text)
                    ((CheckBox)gvRow.FindControl("chkSelect")).Checked = true;

            }
        }

        //this.txtLawyerFromDate.Text = WPLST[this.grdLitigantLawyer.SelectedIndex].FromDate;
        //this.txtLawyerToDate.Text = WPLST[this.grdLitigantLawyer.SelectedIndex].ToDate;
        ATTPerson objPerson = BLLPerson.GetPersons(double.Parse(this.grdLitigantLawyer.SelectedRow.Cells[4].Text),null);  //WPLST[this.grdLitigantLawyer.SelectedIndex].PersonOBJ;
        if (setPersonDetails(objPerson, sender, e) == false)
        {
            this.pnlPersonnelInfo.Enabled = false;
            this.lblStatusMessage.Text = "Can't Edit the Personnel Information For the Selected Witness";
            this.programmaticModalPopup.Show();
        }
    }




    protected void grdLitigantLawyer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[9].Visible = false;
    }
    protected void grdLitigantLawyer_DataBound(object sender, EventArgs e)
    {
        for (int rowIndex = grdLitigantLawyer.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = grdLitigantLawyer.Rows[rowIndex];
            GridViewRow gvPreviousRow = grdLitigantLawyer.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count - 8;
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
    protected void grdLitigantLawyer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTCaseLaywer> CaseLawyerLST = (List<ATTCaseLaywer>)Session["CaseLawyer"];
        int i = CaseLawyerLST.FindIndex(delegate(ATTCaseLaywer obj)
                                                {
                                                    return obj.LitigantID == double.Parse(this.grdLitigantLawyer.Rows[e.RowIndex].Cells[2].Text) && obj.LawyerID== double.Parse(this.grdLitigantLawyer.Rows[e.RowIndex].Cells[11].Text) && obj.LawyerID== double.Parse(this.grdLitigantLawyer.Rows[e.RowIndex].Cells[4].Text);
                                                });
        if (this.grdLitigantLawyer.Rows[e.RowIndex].Cells[8].Text == "A")
            CaseLawyerLST.RemoveAt(i);
        else
            CaseLawyerLST[i].Action = "D";
        this.grdLitigantLawyer.DataSource = CaseLawyerLST;
        this.grdLitigantLawyer.DataBind();
    }
    protected void grdLitigantLawyer_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTCaseLaywer> CaseLawyerLST = new List<ATTCaseLaywer>();
        ATTCaseLaywer objCaseLawyer;
        foreach (GridViewRow gvRow in this.grdLitigantLawyer.Rows)
        {
            if (CheckNull.NullString(gvRow.Cells[9].Text) != "")
            {
                objCaseLawyer = new ATTCaseLaywer();
                objCaseLawyer.CaseID = double.Parse(gvRow.Cells[0].Text);
                objCaseLawyer.LitigantID = double.Parse(gvRow.Cells[2].Text);
                //objWitness.PersonID = double.Parse(gvRow.Cells[4].Text);
                objCaseLawyer.LawyerID= int.Parse(gvRow.Cells[4].Text);
                objCaseLawyer.LicenceNo = CheckNull.NullString(gvRow.Cells[6].Text);
                objCaseLawyer.FromDate = CheckNull.NullString(gvRow.Cells[7].Text);
                objCaseLawyer.ToDate = CheckNull.NullString(gvRow.Cells[8].Text);
                objCaseLawyer.EntryBy = user.UserName;
                objCaseLawyer.Action = gvRow.Cells[9].Text;

                CaseLawyerLST.Add(objCaseLawyer);
            }
        }

        if (BLLCaseLawyer.SaveCaseLawyer(CaseLawyerLST) == true)
        {
            if (txtCaseID.Text == "")
                Session["CaseNo"] = null;
            else
                Session["CaseNo"] = this.txtCaseID.Text;
            Response.Redirect("CaseRegistration3.aspx");
        }

    }


    protected void ClearContros(object sender, EventArgs e)
    {
        //Personnel Info Controls
        this.txtFName_Rqd.Text = "";
        this.txtMName_RQD.Text = "";
        this.txtSurName_Rqd.Text = "";
        this.txtPersonID.Text = "";
        this.txtDOB_DT.Text = "";
        this.ddlGender.SelectedValue = "SG";
        this.ddlMarStatus.SelectedValue = "SMS";
        this.ddlBirthDistrict.SelectedValue = "0";
        this.ddlReligion.SelectedValue = "0";
        this.txtIdentityMark.Text = "";

        this.ddlDistrict.SelectedValue = "0";
        this.ddlDistrict_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtTole.Text = "";
        this.txtPerAdd.Text = "";

        this.ddlDistrictTemp.SelectedValue = "0";
        this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtToleTemp.Text = "";
        this.txtTempAdd.Text = "";

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

        //WITNESS CONTROL
        this.txtLawyerFromDate.Text = "";
        this.txtLawyerToDate.Text = "";

        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Enabled = true;
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Enabled = true;
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }



    }

    private bool setPersonDetails(ATTPerson objPerson, object sender, EventArgs e)
    {
        //Clears Person Controls
        this.txtFName_Rqd.Text = "";
        this.txtMName_RQD.Text = "";
        this.txtSurName_Rqd.Text = "";
        this.txtDOB_DT.Text = "";
        this.ddlGender.SelectedValue = "SG";
        this.ddlMarStatus.SelectedValue = "SMS";
        this.ddlBirthDistrict.SelectedValue = "0";
        this.ddlReligion.SelectedValue = "0";
        this.txtIdentityMark.Text = "";
        this.txtPersonID.Text = "";
        //this.txtWitnessFromDate.Text = "";
        //this.txtWitnessToDate.Text = "";


        //Clears Address Contols
        this.ddlDistrict.SelectedValue = "0";
        this.ddlDistrict_SelectedIndexChanged(sender, e);
        this.ddlVDC_SelectedIndexChanged(sender, e);
        this.txtTole.Text = "";
        this.txtPerAdd.Text = "";

        this.ddlDistrictTemp.SelectedValue = "0";
        this.ddlDistrictTemp_SelectedIndexChanged(sender, e);
        this.ddlVDCTemp_SelectedIndexChanged(sender, e);
        this.txtToleTemp.Text = "";
        this.txtTempAdd.Text = "";

        //clears Phone controls
        this.grdPhone.DataSource = "";
        this.grdPhone.DataBind();
        this.grdPhone.SelectedIndex = -1;
        this.ddlPhoneType_Phone.SelectedValue = "N";
        this.txtPhoneNumber_Phone.Text = "";

        //Clears Email Controls
        this.grdEMail.DataSource = "";
        this.grdEMail.DataBind();
        this.grdEMail.SelectedIndex = -1;
        this.ddlEMailType_EMail.SelectedValue = "N";
        this.txtEMail_EMail.Text = "";


        //PERSON DETAILS
        this.txtPersonID.Text = objPerson.PId.ToString();
        this.txtFName_Rqd.Text = objPerson.FirstName;
        this.txtMName_RQD.Text = objPerson.MidName;
        this.txtSurName_Rqd.Text = objPerson.SurName;
        this.txtDOB_DT.Text = objPerson.DOB;
        this.ddlGender.SelectedValue = objPerson.Gender == "" ? "SG" : objPerson.Gender;
        this.ddlMarStatus.SelectedValue = (objPerson.MaritalStatus == "") ? "SMS" : objPerson.MaritalStatus;

        //this.ddlCountry.SelectedValue
        this.ddlBirthDistrict.SelectedValue = objPerson.BirthDistrict.ToString() == "" ? "0" : objPerson.BirthDistrict.ToString();
        this.ddlReligion.SelectedValue = objPerson.ReligionId.ToString();
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
            this.ddlVDC.SelectedValue =objAddress.VDC==null?"0": objAddress.VDC.ToString();
            this.ddlVDC_SelectedIndexChanged(sender, e);
            this.ddlWard.SelectedValue =objAddress.Ward==null?"0": objAddress.Ward.ToString();
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
            this.ddlVDCTemp.SelectedValue =objAddress.VDC==null?"0": objAddress.VDC.ToString();
            this.ddlVDCTemp_SelectedIndexChanged(sender, e);
            this.ddlWardTemp.SelectedValue =objAddress.Ward==null?"0": objAddress.Ward.ToString();
            this.txtToleTemp.Text = objAddress.Tole;

            this.txtTempAdd.Text = objAddress.District.ToString() + objAddress.VDC.ToString() + objAddress.Ward.ToString() + objAddress.Tole;
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
        if (objPerson.IniType == int.Parse(lblIniType.Text) && objPerson.IniUnit == int.Parse(lblIniUnit.Text))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void chkAllApplicants_CheckedChanged(object sender, EventArgs e)
    {
        //Checks All Appellants
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = chkAllApplicants.Checked == true ? true : false;
        }

        //Unchecks AllRespondsnts
        chkAllRespondants.Checked = false;
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }
    }
    protected void chkAllRespondants_CheckedChanged(object sender, EventArgs e)
    {
        //Checks All Respondants
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = chkAllRespondants.Checked == true ? true : false;
        }

        //Unchecks All Appellants
        chkAllApplicants.Checked = false;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }
    }
    protected void grdRespondant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Enabled = false;
       // e.Row.Cells[4].Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearContros(sender, e);
    }
    protected void grdRespondant_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void grdRespondant_DataBound(object sender, EventArgs e)
    {

    }
    protected void grdAppellant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        // e.Row.Cells[4].Visible = false;
    }
}
