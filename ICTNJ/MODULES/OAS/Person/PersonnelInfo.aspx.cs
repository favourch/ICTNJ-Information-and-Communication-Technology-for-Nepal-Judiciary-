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

public partial class MODULES_OAS_Forms_PersonnelInfo : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["Login_User_Detail"] == null)
        //{
        //    Response.Redirect("~/MODULES/Login.aspx", true);
        //}

        //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        //Session["OrgID"] = user.OrgID;
        //if (user.MenuList.ContainsKey("1,15,1") == true)
        //{
        //    if (this.Page.IsPostBack == false)
        //    {
        //        this.chkPesiTypeActive.Checked = true;
        //        LoadPesiType();
        //    }
        //}
        //else
        //    Response.Redirect("~/MODULES/Login.aspx", true);


        if (this.IsPostBack == false)
        {
            try
            {

                LoadReligions();
                LoadCountries();
                LoadDistricts();
                //ClearControls(sender, e);
                SetEMailTable();
                SetPhoneTable(); 
                
                if (Session["EmpID"] != null && Session["EmpFullName"] != null)
                {
                    this.lblPersonnelInfo.Text = Session["EmpFullName"].ToString() + " को बैयक्तिक विवरण";
                    this.txtPersonID.Text = Session["EmpID"].ToString();
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

    void LoadEmployeePersonnelDetails(object sender, EventArgs e)
    {
        try
        {
            ATTPerson person = BLLPerson.GetPersonWithPersonnelAttributeByID(double.Parse(this.txtPersonID.Text));
            
            this.txtFName_Rqd.Text = person.FirstName.ToString().Trim();
            this.txtMName.Text = person.MidName.ToString().Trim();
            this.txtSurName_Rqd.Text = person.SurName.ToString().Trim();
            this.txtDOB_DT.Text = person.DOB.ToString().Trim();
            
            if (person.Gender.ToString().Trim() != "")
                this.ddlGender.SelectedValue = person.Gender.ToString().Trim();
            
            if (person.MaritalStatus.ToString().Trim() != "")
                this.ddlMarStatus.SelectedValue = person.MaritalStatus.ToString().Trim();
            
            if (person.CountryId.ToString() != "")
                this.ddlCountry.SelectedValue = person.CountryId.ToString();
            
            if (person.BirthDistrict.ToString() != "")
                this.ddlBirthDistrict.SelectedValue = person.BirthDistrict.ToString();
            
            if (person.ReligionId.ToString() != "")
                this.ddlReligion.SelectedValue = person.ReligionId.ToString();

            this.LoadPersonAttributes(person);
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadPersonAttributes(ATTPerson person)
    {
        try
        {
            if (person.LstPersonAddress.Count > 0)
            {
                foreach (ATTPersonAddress PersonAddress in person.LstPersonAddress)
                {
                    if (PersonAddress.AdTypeId == "P")
                    {
                        //ClearAddressControls("P");
                        this.hdnPerAddress.Value = PersonAddress.AdSNo.ToString();
                        this.imgDelPerAddress.Visible = true;
                        if (PersonAddress.District != null)
                        {
                            this.ddlDistrict.SelectedValue = PersonAddress.District.ToString();
                            this.ddlDistrict_SelectedIndexChanged(new object(), new EventArgs());
                            if (PersonAddress.VDC != null)
                            {
                                this.ddlVDC.SelectedValue = PersonAddress.VDC.ToString();
                                this.ddlVDC_SelectedIndexChanged(new object(), new EventArgs());
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
                            this.ddlDistrictTemp_SelectedIndexChanged(new object(), new EventArgs());
                            if (PersonAddress.VDC != null)
                            {
                                this.ddlVDCTemp.SelectedValue = PersonAddress.VDC.ToString();
                                this.ddlVDCTemp_SelectedIndexChanged(new object(), new EventArgs());
                                if (PersonAddress.Ward != null)
                                    this.ddlWardTemp.SelectedValue = PersonAddress.Ward.ToString();
                            }
                        }
                        this.txtToleTemp.Text = PersonAddress.Tole.Trim();
                    }
                }
            }

            if (person.LstPersonPhone.Count > 0)
            {
                Session["PhoneTbl"] = GenericListToDataTable(person.LstPersonPhone);
                this.grdPhone.DataSource = Session["PhoneTbl"];
                this.grdPhone.DataBind();
            }
            if (person.LstPersonEMail.Count > 0)
            {
                Session["EMailTbl"] = GenericListToDataTable(person.LstPersonEMail);
                this.grdEMail.DataSource = Session["EMailTbl"];
                this.grdEMail.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

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

            // SetGridColor(7, 9, grdEMail);

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
            //SetGridColor(7, 9, grdPhone);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.ToString();
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

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        int iniUnit = 9;
        double empID = 0;
        int iniType = 5;//Application ID
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;

        string strUser = "manoz"; //user.UserName;

        List<ATTPerson> PersonLST = new List<ATTPerson>();
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
        objPerson = new ATTPerson
                                (
                                    empID,
                                    this.txtFName_Rqd.Text.Trim(),
                                    this.txtMName.Text.Trim(),
                                    this.txtSurName_Rqd.Text.Trim(),
                                    this.txtDOB_DT.Text.Trim(),
                                    ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
                                    ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
                                    "",
                                    "",
                                    intCountryId,
                                    intBirthDistrict,
                                    intReligion,
                                    iniUnit, 
                                    iniType,
                                    strUser,
                                    DateTime.Now, 
                                    new byte[0]
                                );
        objPerson.FullName = this.txtFName_Rqd.Text.Trim() + " " + this.txtMName.Text.Trim() + " " + this.txtSurName_Rqd.Text.Trim();
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

        PersonLST.Add(objPerson);

        try
        {
            BLLPerson.SavePerson(PersonLST);

            this.ClearME();

            this.lblStatusMessage.Text = "Person has been saved successfully.";
            this.programmaticModalPopup.Show();
        }
        catch(Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        //this.tabContainerEmpContact.ActiveTabIndex = 0;
        this.lblPersonnelInfo.Text = "बैयक्तिक विवरण";
        this.txtPersonID.Text = "";

        #region "CLEAR PERSONNEL INFORMATION"
        /*The Below Part Clears All The Controls Above The TabPanel. Except txtPersonID*/
        /*txtPersonID will only be cleared once Submit button or Cancel button is clicked*/
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
        //this.txtIdentityMark.Text = "";
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

        SetPhoneTable();
        SetEMailTable();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
}