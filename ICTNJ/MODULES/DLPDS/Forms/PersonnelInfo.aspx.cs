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
using PCS.DLPDS.ATT;
using PCS.DLPDS.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_Forms_PersonnelInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        ////block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("Resource Person") == true || user.MenuList.ContainsKey("Participants") == true)
        {
            if (Page.IsPostBack == false)
            {
                LoadFaculty();
                LoadCountries();
                LoadDistricts();
                SetAddressTable();
                SetPhoneTable();
                SetEMailTable();
                LoadPost();
                this.lblHeader.Text = "Add Resource Person";

                try
                {
                    //MODULES_DLPDS_Forms_Participants LastPage;
                    //LastPage = (MODULES_DLPDS_Forms_Participants)Context.Handler;
                    //this.txtProgramID.Text = LastPage.strProgramID;
                    //this.lblHeader.Text = "Add Participant For Program: " + LastPage.strProgramName;
                }
                catch (Exception)
                {
                }
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);



       
    }

    private void LoadFaculty()
    {
        ATTUserLogin user=(ATTUserLogin)Session["Login_User_Detail"];
        Session["FacultyID"] = BLLFaculty.GetFacultyList(user.OrgID, 0)[0].FacultyID;
    }


    //Following code has been disabled since ddlReligion not required. Ashok.
    //void LoadReligions()
    //{
    //    try
    //    {
    //        List<ATTReligion> lstReligions;
    //        lstReligions = BLLReligion.GetReligions(null, 0);
    //        this.ddlReligion.DataSource = lstReligions;
    //        this.ddlReligion.DataTextField = "ReligionNepName";
    //        this.ddlReligion.DataValueField = "ReligionId";
    //        this.ddlReligion.SelectedIndex = 0;
    //        this.ddlReligion.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    void LoadCountries()
    {
        try
        {
            List<ATTCountry> lstCountries;
            lstCountries = BLLCountry.GetCountries(null, 0);
            this.ddlCountry.DataSource = lstCountries;
            this.ddlCountry.DataTextField = "CountryEngName";
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
            lstDistricts.Insert(0, new ATTDistrict(0, "%fGg'xf];", "Select District", 0));
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

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    void LoadPost()
    {
        try
        {
            List<ATTPost> lstPost;
            lstPost = BLLPost.GetPost(null);
            lstPost.Insert(0, new ATTPost(0, "Select Post"));
            Session["Post"] = lstPost;
            this.ddlPost.DataSource = lstPost;
            this.ddlPost.DataTextField = "PostName"; //ATTPost
            this.ddlPost.DataValueField = "PostID";
            this.ddlPost.SelectedIndex = 0;
            this.ddlPost.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPostLevel.DataSource = "";
            ddlPostLevel.Items.Clear();
            if (this.ddlPost.SelectedIndex > 0)
            {
                List<ATTPost> lstPost = (List<ATTPost>)(Session["Post"]);
                this.ddlPostLevel.Items.Add("Select Post Level");
                this.ddlPostLevel.DataSource = lstPost[this.ddlPost.SelectedIndex].LstPostLevel;
                this.ddlPostLevel.DataTextField = "PostLevelName";
                this.ddlPostLevel.DataValueField = "PostLevelID";
            }
            ddlPostLevel.DataBind();
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
                lstVDCS.Insert(0, new ATTVDC(0, 0, "%fGg'xf];", "Select VDC/Municipality", 0));
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
                this.ddlWard.Items.Add(new ListItem("%fGg'xf];", "0"));
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

    void SetAddressTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PERSONID");
        DataColumn dtCol1 = new DataColumn("ADTYPEID");
        DataColumn dtCol2 = new DataColumn("ADDRESSTYPE");
        DataColumn dtCol3 = new DataColumn("DISTRICT");
        DataColumn dtCol4 = new DataColumn("VDCMUNICIPALITY");
        DataColumn dtCol5 = new DataColumn("WARD");
        DataColumn dtCol6 = new DataColumn("TOLE");
        DataColumn dtCol7 = new DataColumn("DISTCODE");
        DataColumn dtCol8 = new DataColumn("VDCCODE");
        DataColumn dtCol9 = new DataColumn("ACTIVE");
        DataColumn dtCol10 = new DataColumn("ACTION");
        DataColumn dtCol11 = new DataColumn("ADSNO");

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

        Session["AddressTbl"] = tbl;
    }
    void SetPhoneTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PERSONID");
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
        DataColumn dtCol0 = new DataColumn("PERSONID");
        DataColumn dtCol1 = new DataColumn("ETYPE");
        DataColumn dtCol2 = new DataColumn("EMAILTYPE");
        DataColumn dtCol3 = new DataColumn("ESNO");
        DataColumn dtCol4 = new DataColumn("EMAIL");
        DataColumn dtCol5 = new DataColumn("ACTIVE");
        DataColumn dtCol6 = new DataColumn("REMARK");
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

    protected void btnAddressPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpAddrTbl = (DataTable)Session["AddressTbl"];

        if (this.ddlAddressType.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "ठेगानाको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdAddress.SelectedIndex == -1)
        {
            DataRow row = tmpAddrTbl.NewRow();
            row[1] = this.ddlAddressType.SelectedValue;
            row[2] = this.ddlAddressType.SelectedItem.ToString();

            if (this.ddlDistrict.SelectedIndex > 0)
            {
                row[3] = this.ddlDistrict.SelectedItem.ToString();
                row[7] = this.ddlDistrict.SelectedValue;
            }
            else
            {
                row[3] = "";
                row[7] = "";
            }

            if (this.ddlVDC.SelectedIndex > 0)
            {
                row[4] = this.ddlVDC.SelectedItem.ToString();
                row[8] = this.ddlVDC.SelectedValue;
            }

            else
            {
                row[4] = "";
                row[8] = "";
            }

            if (this.ddlWard.SelectedIndex > 0)
                row[5] = this.ddlWard.SelectedItem.ToString();
            else
                row[5] = "";
            row[6] = this.txtTole.Text.Trim();
            row[9] = "Y";
            row[10] = "A";
            row[11] = 0;
            tmpAddrTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpAddrTbl.Rows[this.grdAddress.SelectedIndex];
            oldrow[1] = this.ddlAddressType.SelectedValue;
            oldrow[2] = this.ddlAddressType.SelectedItem.ToString();
            if (this.ddlDistrict.SelectedIndex > 0)
            {
                oldrow[3] = this.ddlDistrict.SelectedItem.ToString();
                oldrow[7] = this.ddlDistrict.SelectedValue;
            }
            else
            {
                oldrow[3] = "";
                oldrow[7] = "";
            }

            if (this.ddlVDC.SelectedIndex > 0)
            {
                oldrow[4] = this.ddlVDC.SelectedItem.ToString();
                oldrow[8] = this.ddlVDC.SelectedValue;
            }

            else
            {
                oldrow[4] = "";
                oldrow[8] = "";
            }

            if (this.ddlWard.SelectedIndex > 0)
                oldrow[5] = this.ddlWard.SelectedItem.ToString();
            else
                oldrow[5] = "";
            oldrow[6] = this.txtTole.Text.Trim();
            oldrow[9] = "Y";
            if ((CheckNullString(oldrow[10].ToString()) == "E") || (CheckNullString(oldrow[10].ToString()) == ""))
                oldrow[10] = "E";
            else
            oldrow[10] = "A";
        }
        this.ddlDistrict.SelectedIndex = 0;
        this.ddlVDC.DataSource = "";
        this.ddlVDC.Items.Clear();
        this.ddlWard.DataSource = "";
        this.ddlWard.Items.Clear();
        this.ddlVDC.DataBind();
        this.ddlWard.DataBind();
        this.txtTole.Text = "";
        this.ddlAddressType.SelectedIndex = 0;

        this.grdAddress.DataSource = tmpAddrTbl;
        this.grdAddress.DataBind();
        this.grdAddress.SelectedIndex = -1;
    }
    protected void grdAddress_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
    protected void grdAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdAddress.SelectedIndex > -1)
        {
            row = this.grdAddress.SelectedRow;
            this.ddlDistrict.SelectedValue = CheckNullString(row.Cells[7].Text.ToString());
            this.ddlDistrict_SelectedIndexChanged(sender, e);
            if (CheckNullString(row.Cells[8].Text.ToString()) != "")
                this.ddlVDC.SelectedValue = CheckNullString(row.Cells[8].Text.ToString());
            this.ddlVDC_SelectedIndexChanged(sender, e);
            if (CheckNullString(row.Cells[5].Text.ToString()) != "")
                this.ddlWard.SelectedValue = CheckNullString(row.Cells[5].Text.ToString());
            this.txtTole.Text = CheckNullString(row.Cells[6].Text);
            this.ddlAddressType.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
        }
    }

    protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdEMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
    protected void grdPhone_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void btnPhonePlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpPhoneTbl = (DataTable)Session["PhoneTbl"];
        
        if (this.ddlPhoneType.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "फोनको किसिम छान्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPhoneNumber.Text=="")
        {
            this.lblStatusMessage.Text = "फोन न. राख्नुहोस";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdPhone.SelectedIndex == -1)
        {
            DataRow row = tmpPhoneTbl.NewRow();
            row[1] = this.ddlPhoneType.SelectedValue;
            row[2] = this.ddlPhoneType.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtPhoneNumber.Text.Trim();
            row[5] = "Y";
            row[6] = this.txtPhoneRemarks.Text.Trim();
            row[7] = "A";
            tmpPhoneTbl.Rows.Add(row);
        }

        else
        {
            DataRow oldrow = tmpPhoneTbl.Rows[this.grdPhone.SelectedIndex];
            oldrow[1] = this.ddlPhoneType.SelectedValue;
            oldrow[2] = this.ddlPhoneType.SelectedItem.ToString();
            oldrow[4] = this.txtPhoneNumber.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = this.txtPhoneRemarks.Text.Trim();
            if ((CheckNullString(oldrow[7].ToString()) == "E") || (CheckNullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlPhoneType.SelectedIndex = 0;
        this.txtPhoneNumber.Text = "";
        this.txtPhoneRemarks.Text = "";
        this.grdPhone.DataSource = tmpPhoneTbl;
        this.grdPhone.DataBind();
        this.grdPhone.SelectedIndex = -1;
    }
    protected void btnEMailPlus_Click(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        DataTable tmpEMailTbl = (DataTable)Session["EMailTbl"];

        if (this.ddlEMailType.SelectedIndex <= 0)
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
            row[1] = this.ddlEMailType.SelectedValue;
            row[2] = this.ddlEMailType.SelectedItem.ToString();
            row[3] = 0;
            row[4] = this.txtEMail.Text.Trim();
            row[5] = "Y";
            row[6] = this.txtEMailRemarks.Text.Trim();
            row[7] = "A";
            tmpEMailTbl.Rows.Add(row);
        }
        else
        {
            DataRow oldrow = tmpEMailTbl.Rows[this.grdEMail.SelectedIndex];
            oldrow[1] = this.ddlEMailType.SelectedValue;
            oldrow[2] = this.ddlEMailType.SelectedItem.ToString();
            oldrow[4] = this.txtEMail.Text.Trim();
            oldrow[5] = "Y";
            oldrow[6] = this.txtEMailRemarks.Text.Trim();
            if ((CheckNullString(oldrow[7].ToString()) == "E") || (CheckNullString(oldrow[7].ToString()) == ""))
                oldrow[7] = "E";
            else
                oldrow[7] = "A";
        }

        this.ddlEMailType.SelectedIndex = 0;
        this.txtEMail.Text = "";
        this.txtEMailRemarks.Text = "";
        this.grdEMail.DataSource = tmpEMailTbl;
        this.grdEMail.DataBind();
        this.grdEMail.SelectedIndex = -1;
    }

    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdPhone.SelectedIndex > -1)
        {
            row = this.grdPhone.SelectedRow;
            this.ddlPhoneType.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
            this.txtPhoneNumber.Text = CheckNullString(row.Cells[4].Text);
            this.txtPhoneRemarks.Text = CheckNullString(row.Cells[6].Text);
        }
    }
    protected void grdEMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        if (this.grdEMail.SelectedIndex > -1)
        {
            row = this.grdEMail.SelectedRow;
            this.ddlEMailType.SelectedValue = CheckNullString(row.Cells[1].Text.ToString());
            this.txtEMail.Text = CheckNullString(row.Cells[4].Text);
            this.txtEMailRemarks.Text = CheckNullString(row.Cells[6].Text);
        }
    }

    string CheckNullString(string NullString)
    {
        if (NullString == "&nbsp;")
            return "";
        else
            return NullString;

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ATTFacultyMember objFacultyMember=null;
        ATTParticipantPost objparticipantPost;
        ATTPerson objPerson;
        ATTParticipant objParticipant=null;

        byte[] ImageData = new byte[0];
        int? intCountryId = null;
        int? intBirthDistrict = null;
        int? intReligion = null;
        ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];
        string strUser = user.UserName;
        int intOrgID = user.OrgID;
        int intFacultyID = int.Parse(Session["FacultyID"].ToString());

        if (this.txtProgramID.Text != "")
            if (this.ddlPost.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "Select Post of Participant";
                this.programmaticModalPopup.Show();
                return;
            }

        if (this.ddlPost.SelectedIndex > 0)
            if (this.ddlPostLevel.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "Select Post Level";
                this.programmaticModalPopup.Show();
                return;
            }
        try
        {
            if (this.ddlCountry.SelectedIndex > 0)
                intCountryId = int.Parse(this.ddlCountry.SelectedValue.ToString());
            if (this.ddlBirthDistrict.SelectedIndex > 0)
                intBirthDistrict = int.Parse(this.ddlBirthDistrict.SelectedValue.ToString());
            
            //Following code has been disabled since ddlReligion not required. Ashok.
            //if (this.ddlReligion.SelectedIndex > 0)
            //    intReligion = int.Parse(this.ddlReligion.SelectedValue.ToString());

            objPerson = new ATTPerson(
                                        0,
                                        this.txtFName_Rqd.Text.Trim(),
                                        this.txtMName.Text.Trim(),
                                        this.txtSurName_Rqd.Text.Trim(),
                                        this.txtDOB.Text.Trim(),
                                        ((this.ddlGender.SelectedIndex <= 0) ? "" : (this.ddlGender.SelectedValue)),
                                        ((this.ddlMarStatus.SelectedIndex <= 0) ? "" : (this.ddlMarStatus.SelectedValue)),
                                        this.txtFatherName.Text.Trim(),
                                        this.txtGFatherName.Text.Trim(),
                                        intCountryId,
                                        intBirthDistrict,
                                        intReligion,
                                        user.OrgID,
                                        104,
                                        ((Label) this.Master.FindControl("lblUsername")).Text,
                                        DateTime.Parse(Session["EngDate"].ToString()),
                                        ImageData,
                                        "P"
                                      );

            if (this.txtProgramID.Text == "")
            {
                objFacultyMember = new ATTFacultyMember(intOrgID, intFacultyID, 0, Session["NepDate"].ToString(), "");
                objFacultyMember.ObjPerson = objPerson;
            }

            else
            {
                objParticipant = new ATTParticipant(intOrgID, int.Parse(this.txtProgramID.Text.ToString()), 0, "", Session["NepDate"].ToString(), "");
                objParticipant.ObjPerson = objPerson;
            }

            if (this.ddlPost.SelectedIndex > 0)
            {
                objparticipantPost = new ATTParticipantPost(0, int.Parse(ddlPost.SelectedValue.ToString()), int.Parse(ddlPostLevel.SelectedValue.ToString()), Session["NepDate"].ToString());
                objparticipantPost.Action = "A";
                if (this.txtProgramID.Text == "")
                    objFacultyMember.LstParticipantPost.Add(objparticipantPost);
                else
                    objParticipant.LstParticipantPost.Add(objparticipantPost);
            }

            foreach (GridViewRow row in this.grdAddress.Rows)
            {
                if (CheckNullString(row.Cells[10].Text.ToString()) != "")
                {
                    int? intDistrict = null;
                    int? intVDC = null;
                    int? intWard = null;

                    if (CheckNullString(row.Cells[7].Text.ToString()) != "")
                        intDistrict = int.Parse(CheckNullString(row.Cells[7].Text.ToString()));

                    if (CheckNullString(row.Cells[8].Text.ToString()) != "")
                        intVDC = int.Parse(CheckNullString(row.Cells[8].Text.ToString()));

                    if (CheckNullString(row.Cells[5].Text.ToString()) != "")
                        intWard = int.Parse(CheckNullString(row.Cells[5].Text.ToString()));

                    ATTPersonAddress PersonAddressATT = new ATTPersonAddress
                                                                            (
                                                                                0,
                                                                                row.Cells[1].Text,
                                                                                int.Parse(row.Cells[11].Text),
                                                                                intDistrict,
                                                                                intVDC,
                                                                                intWard,
                                                                                CheckNullString(row.Cells[6].Text), 
                                                                                CheckNullString(row.Cells[9].Text),
                                                                                ((Label)this.Master.FindControl("lblUsername")).Text,
                                                                                DateTime.Parse(Session["EngDate"].ToString())
                                                                              );

                    PersonAddressATT.Action = CheckNullString(row.Cells[10].Text.ToString());
                    objPerson.LstPersonAddress.Add(PersonAddressATT);
                }
            }

            foreach (GridViewRow row in this.grdPhone.Rows)
            {
                if (CheckNullString(row.Cells[7].Text.ToString()) != "")
                {
                    ATTPersonPhone PersonPhoneATT = new ATTPersonPhone
                                                                        (
                                                                            0,
                                                                            row.Cells[1].Text,
                                                                            int.Parse(row.Cells[3].Text),
                                                                            CheckNullString(row.Cells[4].Text),
                                                                            CheckNullString(row.Cells[5].Text),
                                                                            CheckNullString(row.Cells[6].Text),
                                                                            ((Label)this.Master.FindControl("lblUsername")).Text,
                                                                            DateTime.Parse(Session["EngDate"].ToString())
                                                                         );

                    PersonPhoneATT.Action = CheckNullString(row.Cells[7].Text.ToString());
                    objPerson.LstPersonPhone.Add(PersonPhoneATT);
                }
            }

            foreach (GridViewRow row in this.grdEMail.Rows)
            {
                if (CheckNullString(row.Cells[7].Text) != "")
                {
                    ATTPersonEMail PersonEMailATT = new ATTPersonEMail
                                                                        (   
                                                                            0,
                                                                            row.Cells[1].Text,
                                                                            int.Parse(row.Cells[3].Text),
                                                                            CheckNullString(row.Cells[4].Text),
                                                                            CheckNullString(row.Cells[5].Text),
                                                                            CheckNullString(row.Cells[6].Text),
                                                                            ((Label)this.Master.FindControl("lblUsername")).Text,
                                                                            DateTime.Parse( Session["EngDate"].ToString())
                                                                          );
                    PersonEMailATT.Action = CheckNullString(row.Cells[7].Text.ToString());
                    objPerson.LstPersonEMail.Add(PersonEMailATT);
                }
            }
            if (this.txtProgramID.Text == "")
                BLLFacultyMember.SaveFacultyMember(objFacultyMember);
            else
                BLLParticipant.SaveParticipant(objParticipant);
            ClearControls();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.txtFName_Rqd.Text = "";
        this.txtMName.Text = "";
        this.txtSurName_Rqd.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlMarStatus.SelectedIndex = 0;
        this.ddlCountry.SelectedIndex = 0;
        this.ddlBirthDistrict.SelectedIndex = 0;
        this.txtFatherName.Text = "";
        this.txtGFatherName.Text = "";

        this.ddlDistrict.SelectedIndex = 0;
        this.ddlVDC.Items.Clear();
        this.ddlWard.Items.Clear();
        this.ddlVDC.DataSource = "";
        this.ddlWard.DataSource = "";
        this.ddlVDC.DataBind();
        this.ddlWard.DataBind();
        this.txtTole.Text = "";
        this.ddlAddressType.SelectedIndex = 0;

        this.ddlPhoneType.SelectedIndex = 0;
        this.txtPhoneNumber.Text = "";
        this.txtPhoneRemarks.Text = "";

        this.ddlEMailType.SelectedIndex = 0;
        this.txtEMail.Text = "";
        this.txtEMailRemarks.Text = "";

        this.ddlPost.SelectedIndex = 0;
        this.ddlPostLevel.DataSource = "";
        this.ddlPostLevel.DataBind();

        this.grdAddress.DataSource = "";
        this.grdPhone.DataSource = "";
        this.grdEMail.DataSource = "";
        this.grdAddress.DataBind();
        this.grdPhone.DataBind();
        this.grdEMail.DataBind();
        this.SetAddressTable();
        this.SetPhoneTable();
        this.SetEMailTable();
    }
}