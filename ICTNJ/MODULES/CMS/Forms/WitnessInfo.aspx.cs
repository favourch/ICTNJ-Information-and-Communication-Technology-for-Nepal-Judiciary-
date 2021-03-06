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
using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;

public partial class MODULES_CMS_Forms_WitnessInfo : System.Web.UI.Page
{
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Person"] == null)
        //{
        //    Session["Person"] = new List<ATTWitnessSearch>();
        //}

        if (this.IsPostBack == false)
        {
            try
            {
                LoadReligions();
                LoadCountries();
                LoadDistricts();
                LoadRelationType();
                SetEMailTable();
                SetPhoneTable();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
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

    void ClearControls()
    {
        this.txtFName_Rqd.Text = "";
        this.txtMName.Text = "";
        this.txtSurName_Rqd.Text = "";
        this.txtIdentityMark.Text = "";
        this.txtFromDate_RQD.Text = "";
        this.txtDOB_DT.Text = "";
        this.txtEMail_EMail.Text = "";
        this.txtPersonID.Text = "";
        this.txtPhoneNumber_Phone.Text = "";
        this.txtRelationDOB_DTRelative.Text = "";
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
        //SetGridColor(7, 9, grdEMail);
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
        //SetGridColor(7, 9, grdPhone);
    }
    
    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPhoneType_Phone.SelectedValue = CheckNull.NullString(grdPhone.SelectedRow.Cells[1].Text.Trim());
        txtPhoneNumber_Phone.Text = CheckNull.NullString(grdPhone.SelectedRow.Cells[4].Text.Trim());
    }
    
    protected void grdEMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEMailType_EMail.SelectedValue = grdEMail.SelectedRow.Cells[1].Text.Trim();
        txtEMail_EMail.Text = grdEMail.SelectedRow.Cells[4].Text.Trim();
    
    }
    
    protected void grdEMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    
    protected void grdEMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    
    protected void grdPhone_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    
    protected void grdPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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
    
    protected void imgDelPerAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void imgDelTempAddress_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void btnSearchRelatives_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnAddRelatives_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnClearRelatives_Click(object sender, EventArgs e)
    {

    }
    
    protected void grdEmpRelatives_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    
    protected void btnOK_Click(object sender, EventArgs e)
    {
         // btnOK.Attributes.Add("OnClick", "self.close()");
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnAddPerson_Click(object sender, EventArgs e)
    {
        if (txtFromDate_RQD.Text == "")
        {
            this.lblStatusMessage.Text = "Enter From Date First";
            this.programmaticModalPopup.Show();
            return;
        }
        int iniUnit = 3;
        double empID = 0;
        int iniType = 9;
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;

        ATTPerson objPerson = new ATTPerson();

        if (this.txtPersonID.Text.Trim() != "")
            empID = double.Parse(this.txtPersonID.Text.Trim());
        if (this.ddlCountry.SelectedIndex > 0)
            intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
        if (this.ddlBirthDistrict.SelectedIndex > 0)
            intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
        if (this.ddlReligion.SelectedIndex > 0)
            intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());


        #region "PERSONTABLE"
        objPerson = new ATTPerson(empID, this.txtFName_Rqd.Text.Trim(),
            this.txtMName.Text.Trim(), this.txtSurName_Rqd.Text.Trim(),
            this.txtDOB_DT.Text.Trim(), ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
            ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
            "", "", intCountryId, intBirthDistrict, intReligion,
            iniUnit, iniType, strUser, DateTime.Now, new byte[0]);
        //objPerson.FullName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
        objPerson.EntityType = "P";
        #endregion

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
            0, "P", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtTole.Text.Trim(), "Y", strUser, DateTime.Now
            );

        if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value != "0")) strAddressAction = "E";
        if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value == "0")) strAddressAction = "A";
       // if (((this.ddlDistrict.SelectedIndex <= 0) && (this.txtTole.Text.Trim() == "")) && (hdnPerAddress.Value != "0")) strAddressAction = "D";
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
            0, "T", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtToleTemp.Text.Trim(), "Y", strUser, DateTime.Now
            );

        if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value != "0")) strAddressAction = "E";
        if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value == "0")) strAddressAction = "A";
        //if (((this.ddlDistrictTemp.SelectedIndex <= 0) && (this.txtToleTemp.Text.Trim() == "")) && (hdnTempAddress.Value != "0")) strAddressAction = "D";
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
            if (CheckNull.NullString(row.Cells[7].Text.ToString()) != "")
            {
                ATTPersonPhone PersonPhoneATT = new ATTPersonPhone(0, row.Cells[1].Text, int.Parse(row.Cells[3].Text.ToString()),
                      CheckNull.NullString(row.Cells[4].Text.ToString()), CheckNull.NullString(row.Cells[5].Text.ToString()),
                      CheckNull.NullString(row.Cells[6].Text.ToString()), strUser, DateTime.Now);
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
                      CheckNull.NullString(row.Cells[6].Text.ToString()), strUser, DateTime.Now);
                PersonEMailATT.Action = CheckNull.NullString(row.Cells[7].Text.ToString());
                objPerson.LstPersonEMail.Add(PersonEMailATT);
            }
        }
        #endregion

        #region "RELATIVES AND BENEFICIARIES"
        //foreach (GridViewRow row in this.grdEmpRelatives.Rows)
        //{
        //    int? countryID = null;
        //    int? birthDistrict = null;
        //    int? religionID = null;
        //    if (  CheckNull.NullString(row.Cells[11].Text) != "")
        //        birthDistrict = int.Parse(row.Cells[11].Text);
        //    byte[] RelativeImageData = new byte[0];
        //    ATTPerson objRelativePerson = new ATTPerson
        //        (double.Parse(row.Cells[1].Text), row.Cells[2].Text,   CheckNull.NullString(row.Cells[3].Text),   CheckNull.NullString(row.Cells[4].Text),
        //          CheckNull.NullString(row.Cells[8].Text),   CheckNull.NullString(row.Cells[6].Text),   CheckNull.NullString(row.Cells[9].Text), "", "",
        //        countryID, birthDistrict, religionID, iniUnit, iniType, strUser, DateTime.Now, RelativeImageData);
        //    CheckBox cb = (CheckBox)row.Cells[17].FindControl("chkRelativeActive");
        //    CheckBox cbIsBen = (CheckBox)row.Cells[16].FindControl("chkIsBeneficiary");
        //    CheckBox cbWasBen = (CheckBox)row.Cells[20].FindControl("chkWasBeneficiary");

        //    ATTEmployeeBeneficiary EmpBeneficiaryATT = new ATTEmployeeBeneficiary(0, 0, null, null);
        //    if ((cbIsBen.Checked) && (!cbWasBen.Checked))
        //        EmpBeneficiaryATT.Action = "A";
        //    else if ((!cbIsBen.Checked) && (cbWasBen.Checked))
        //    {
        //        EmpBeneficiaryATT.Action = "E";
        //        EmpBeneficiaryATT.ToDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
        //    }
        //    EmpBeneficiaryATT.EntryBy = strUser;

        //    ATTRelatives RelativesATT = new ATTRelatives(0, 0, int.Parse(row.Cells[13].Text), (cb.Checked ? "Y" : "N"));
        //    RelativesATT.Occupation =   CheckNull.NullString(row.Cells[15].Text);
        //    RelativesATT.EntryBy = strUser;
        //    if (  CheckNull.NullString(row.Cells[18].Text) == "A")
        //        RelativesATT.Action = "A";
        //    else
        //        RelativesATT.Action = "E";
        //    RelativesATT.ObjPerson = objRelativePerson;
        //    EmpBeneficiaryATT.ObjRelatives = RelativesATT;
        //    objEmployee.LstEmployeeBeneficiary.Add(EmpBeneficiaryATT);
        //}
        #endregion

        List<ATTWitnessSearch> WSearchLST = (List<ATTWitnessSearch>)Session["WSearch"];
        ATTWitnessSearch objWSearch = new ATTWitnessSearch();
        ATTWitnessPerson objCaesAndlitigant = (ATTWitnessPerson)Session["CaseAndLitigant"];//brought from witness person form caseID and litigantId

        List<ATTWitnessSearch> PersonList = new List<ATTWitnessSearch>();

        objWSearch.CaseID = objCaesAndlitigant.CaseID;
        objWSearch.LItigantID = objCaesAndlitigant.LitigantID;
        objWSearch.PersonID = 0;
        objWSearch.WitnessID = 0;
        objWSearch.WitnessName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim(); 
        objWSearch.FromDate = this.txtFromDate_RQD.Text;
        objWSearch.Action = "A";

        objWSearch.ObjPerson = objPerson;

        WSearchLST.Add(objWSearch);
        PersonList.Add(objWSearch);

        Session["WSearch"] = WSearchLST;

        this.grdPerson.DataSource = PersonList;
        this.grdPerson.DataBind();

        ClearControls();
       
    }
}
