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

public partial class MODULES_CMS_MelMilaapKartaa_MelMilaapKartaaInfo : System.Web.UI.Page
{
    string strUser = "shyam";
    int orgID = 9;
    protected void Page_Load(object sender, EventArgs e)
    {    
       
        if (this.IsPostBack == false)
        {
            try
            {
                LoadReligions();
                LoadCountries();
                LoadDistricts();
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
        this.txtDOB_DT.Text = "";
        this.txtEMail.Text = "";
        this.txtPersonID.Text = "";
        this.txtPhoneNumber.Text = "";
      
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

        if (this.txtEMail.Text == "")
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
            row[4] = this.txtEMail.Text.Trim();
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
            oldrow[4] = this.txtEMail.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlEMailType_EMail.SelectedIndex = 0;
        this.txtEMail.Text = "";
        this.grdEMail.DataSource = tmpEMailTbl;
        this.grdEMail.DataBind();
        for (int j = 0; j < grdEMail.Rows.Count; j++)
        {
            if (grdEMail.Rows[j].Cells[7].Text == "D")
                ((LinkButton)grdEMail.Rows[j].Cells[9].Controls[0]).Text = "UNDO";
            else
                ((LinkButton)grdEMail.Rows[j].Cells[9].Controls[0]).Text = "DELETE";
        }
        this.grdEMail.SelectedIndex = -1;
       
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

        if (this.txtPhoneNumber.Text == "")
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
            row[4] = this.txtPhoneNumber.Text.Trim();
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
            oldrow[4] = this.txtPhoneNumber.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = "";
            if ((CheckNull.NullString(oldrow[7].ToString()) == "E") || (CheckNull.NullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlPhoneType_Phone.SelectedIndex = 0;
        this.txtPhoneNumber.Text = "";
        //this.txtPhoneRemarks.Text = "";
        this.grdPhone.DataSource = tmpPhoneTbl;
        this.grdPhone.DataBind();

        for (int j = 0; j < grdPhone.Rows.Count; j++)
        {
            if (grdPhone.Rows[j].Cells[7].Text == "D")
                ((LinkButton)grdPhone.Rows[j].Cells[9].Controls[0]).Text = "UNDO";
            else
                ((LinkButton)grdPhone.Rows[j].Cells[9].Controls[0]).Text = "DELETE";
        }

        this.grdPhone.SelectedIndex = -1;
    }
    
    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPhoneType_Phone.SelectedValue = grdPhone.SelectedRow.Cells[1].Text.Trim();
        txtPhoneNumber.Text = grdPhone.SelectedRow.Cells[4].Text.Trim();
    }
    
    protected void grdEMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEMailType_EMail.SelectedValue = grdEMail.SelectedRow.Cells[1].Text.Trim();
        txtEMail.Text = grdEMail.SelectedRow.Cells[4].Text.Trim();
    }
    
    protected void grdEMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable tmpEMailTbl = (DataTable)Session["EMailTbl"];

        if (grdEMail.Rows[e.RowIndex].Cells[7].Text == "A")
            tmpEMailTbl.Rows.RemoveAt(e.RowIndex);
        else if (grdEMail.Rows[e.RowIndex].Cells[7].Text == "D")
            tmpEMailTbl.Rows[e.RowIndex][7] = "";
        else
            tmpEMailTbl.Rows[e.RowIndex][7] = "D";

        grdEMail.DataSource = tmpEMailTbl;
        grdEMail.DataBind();

        for (int j = 0; j < grdEMail.Rows.Count; j++)
        {
            if (grdEMail.Rows[j].Cells[7].Text == "D")
                ((LinkButton)grdEMail.Rows[j].Cells[9].Controls[0]).Text = "Undo";
            else
                ((LinkButton)grdEMail.Rows[j].Cells[9].Controls[0]).Text = "Delete";
        }
        this.ddlEMailType_EMail.SelectedIndex = -1;
        this.txtEMail.Text = "";
     
    }
    
    protected void grdEMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    
    protected void grdPhone_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    
    protected void grdPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable tmpPhoneTbl = (DataTable)Session["PhoneTbl"];
        if (grdPhone.Rows[e.RowIndex].Cells[7].Text == "A")
            tmpPhoneTbl.Rows.RemoveAt(e.RowIndex);
        else if (grdPhone.Rows[e.RowIndex].Cells[7].Text == "D")
            tmpPhoneTbl.Rows[e.RowIndex][7] = "";
        else
            tmpPhoneTbl.Rows[e.RowIndex][7] = "D";

        grdPhone.DataSource = tmpPhoneTbl;
        grdPhone.DataBind();

        for (int j = 0; j < grdPhone.Rows.Count; j++)
        {
            if (grdPhone.Rows[j].Cells[7].Text == "D")
                ((LinkButton)grdPhone.Rows[j].Cells[9].Controls[0]).Text = "Undo";
            else
                ((LinkButton)grdPhone.Rows[j].Cells[9].Controls[0]).Text = "Delete";
        }
        this.ddlPhoneType_Phone.SelectedIndex = -1;
        this.txtPhoneNumber.Text = "";
       
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
        int iniUnit = 3;
        double empID = 0;
        int iniType = 9;
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;
        List<ATTPerson> lstPerson = new List<ATTPerson>();
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

        //if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value != "0")) strAddressAction = "E";
        //if (((this.ddlDistrict.SelectedIndex > 0) || (this.txtTole.Text.Trim() != "")) && (hdnPerAddress.Value == "0")) strAddressAction = "A";
        //// if (((this.ddlDistrict.SelectedIndex <= 0) && (this.txtTole.Text.Trim() == "")) && (hdnPerAddress.Value != "0")) strAddressAction = "D";
        strAddressAction = "A";
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

        strAddressAction = "A";
        if (this.ddlDistrictTemp.SelectedIndex > 0) intDistrictAddress = int.Parse(this.ddlDistrictTemp.SelectedValue);
        if (this.ddlVDCTemp.SelectedIndex > 0) intVDCAddress = int.Parse(this.ddlVDCTemp.SelectedValue);
        if (this.ddlWardTemp.SelectedIndex > 0) intWardAddress = int.Parse(this.ddlWardTemp.SelectedValue);
        PersonAddressATT = new ATTPersonAddress
            (
            0, "T", 1, intDistrictAddress, intVDCAddress, intWardAddress, this.txtToleTemp.Text.Trim(), "Y", strUser, DateTime.Now
            );

        //if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value != "0")) strAddressAction = "E";
       // if (((this.ddlDistrictTemp.SelectedIndex > 0) || (this.txtToleTemp.Text.Trim() != "")) && (hdnTempAddress.Value == "0")) strAddressAction = "A";
        //if (((this.ddlDistrictTemp.SelectedIndex <= 0) && (this.txtToleTemp.Text.Trim() == "")) && (hdnTempAddress.Value != "0")) strAddressAction = "D";
        strAddressAction = "A";
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


        //lstPerson.Add(objPerson);
        double PersonID = 0;
        if (this.txtPersonID.Text.Trim() != "")
            PersonID = double.Parse(this.txtPersonID.Text.Trim());

        lstPerson.Add(objPerson);
        if (lstPerson.Count > 0)
        {
            Session["MelMilaapKartaaInfo"] = lstPerson;
            // Session["PersonID"] = objPerson.PId;
            ClearControls();
            Response.Redirect("MelMilaapKartaa.aspx");
        }
        else
        {
            lblStatusMessage.Text = "Person List doesn't contain information";
            programmaticModalPopup.Show();
            return;
        }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedItem.Text != "Nepal")
        {
            ddlBirthDistrict.DataSource = "";
            ddlBirthDistrict.DataBind();
        }
        else
        {
            List<ATTDistrict> lstDist = (List<ATTDistrict>)Session["BirthDist"];
            ddlBirthDistrict.DataSource = lstDist;
            this.ddlBirthDistrict.DataTextField = "EngDistName";
            this.ddlBirthDistrict.DataValueField = "DistCode";
            this.ddlBirthDistrict.DataBind();
        }
    }
}
