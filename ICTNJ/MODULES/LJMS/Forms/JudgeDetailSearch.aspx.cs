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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_LJMS_Forms_EmployeeDetailSearch : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

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
        if (user.MenuList.ContainsKey("2,19,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadOrganization();
                this.LoadSewa();
                this.LoadLevel();
                this.LoadDistrict();
                this.LoadQualification();
                //this.LoadDesignations();
                this.LoadCountry();
                this.LoadPostingType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadOrganization()
    {
        try
        {
            this.ddlOrganization.DataSource = BLLOrganization.getOrganizationApplication(2);
            this.ddlOrganization.DataTextField = "OrgName";
            this.ddlOrganization.DataValueField = "OrgID";
            this.ddlOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    //void LoadDesignations()
    //{
    //    string desType = "J";
    //    try
    //    {
    //        List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
    //        LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
    //        this.ddlPost.DataSource = LstDesignation;
    //        this.ddlPost.DataTextField = "DesignationName";
    //        this.ddlPost.DataValueField = "DesignationID";
    //        this.ddlPost.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblStatusMessage.Text = ex.Message;
    //        this.programmaticModalPopup.Show();
    //        return;
    //    }
    //}

    void LoadOrganizationAvailablePosts(int OrgID)
    {
        this.ddlPost.DataSource = "";
        this.ddlPost.Items.Clear();

        try
        {
            string desType = "J";
            List<ATTOrganizationDesignation> lst = BLLOrganizationDesignation.GetOrganizationDesignation(OrgID, null, desType);
            if (lst.Count > 0)
            {
                ATTOrganizationDesignation obj = new ATTOrganizationDesignation();
                obj.DesName = "--- Select Designation ---";
                lst.Insert(0, obj);
            }
            this.ddlPost.DataSource = lst;
            this.ddlPost.DataTextField = "DesName";
            this.ddlPost.DataValueField = "DesID";
            this.ddlPost.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadSewa()
    {
        try
        {
            List<ATTSewa> SewaList = BLLSewa.GetSewaList(null);
            Session["SewaList"] = SewaList;

            SewaList.Insert(0, new ATTSewa(0, "छान्नुहोस", "", DateTime.Now, ""));

            this.ddlSewa.DataSource = SewaList;
            this.ddlSewa.DataTextField = "SEWANAME";
            this.ddlSewa.DataValueField = "SEWAID";
            this.ddlSewa.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadLevel()
    {
        try
        {
            List<ATTDesignationLevel> lst = BLLDesignationLevel.GetDesignationLevelList();
            if (lst.Count>0)
            {
                lst.Insert(0, new ATTDesignationLevel(0, "--- Select Level ---"));
            }
            this.ddlLevel.DataSource = lst;
            this.ddlLevel.DataTextField = "LevelName";
            this.ddlLevel.DataValueField = "LevelID";
            this.ddlLevel.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDistrict()
    {
        try
        {
            List<ATTDistrict> lst = BLLDistrict.GetDistrictList(null);
            lst.Insert(0, new ATTDistrict(0, "--- Select District ---", "", 0));
            this.ddlDistrict.DataSource = lst;
            this.ddlDistrict.DataTextField = "NepDistName";
            this.ddlDistrict.DataValueField = "DistCode";
            this.ddlDistrict.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadQualification()
    {
        try
        {
            List<ATTDegree> lst = BLLDegree.GetDegree(null, "Y");
            //if (lst.Count > 0)
            //{
            //    lst.Insert(0, new ATTDegree(0, 0, "--- Select Degree ---", "Y"));
            //}
            this.lstQualification.DataSource = lst;
            this.lstQualification.DataTextField = "DegreeName";
            this.lstQualification.DataValueField = "DegreeID";
            this.lstQualification.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCountry()
    {
        try
        {
            List<ATTCountry> lst = BLLCountry.GetCountries(null,2);
            //if (lst.Count > 0)
            //{
            //    lst.Insert(0, new ATTDegree(0, 0, "--- Select Degree ---", "Y"));
            //}
            this.lstVisit.DataSource = lst;
            this.lstVisit.DataTextField = "CountryNepName";
            this.lstVisit.DataValueField = "CountryID";
            this.lstVisit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadSamuha()
    {
        try
        {
            this.ddlUpaSamuha.DataSource = "";
            this.ddlUpaSamuha.Items.Clear();
            this.ddlUpaSamuha.DataBind();
            this.ddlUpaSamuha.DataSource = "";
            this.ddlUpaSamuha.Items.Clear();
            if (this.ddlSewa.SelectedIndex > 0)
            {
                List<ATTSewa> SewaList = (List<ATTSewa>)Session["SewaList"];
                this.ddlSamuha.DataSource = SewaList[this.ddlSewa.SelectedIndex].LstSamuha;
                this.ddlSamuha.DataTextField = "SAMUHANAME";
                this.ddlSamuha.DataValueField = "SAMUHAID";
                this.ddlSamuha.Items.Add(new ListItem("छान्नुहोस", "0"));
            }
            this.ddlSamuha.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadUpaSamuha()
    {
        try
        {
            this.ddlUpaSamuha.DataSource = "";
            this.ddlUpaSamuha.Items.Clear();
            if (this.ddlSamuha.SelectedIndex > 0)
            {
                List<ATTSewa> SewaList = (List<ATTSewa>)Session["SewaList"];
                this.ddlUpaSamuha.DataSource = SewaList[this.ddlSewa.SelectedIndex].LstSamuha[this.ddlSamuha.SelectedIndex - 1].LstUpaSamuha;
                this.ddlUpaSamuha.DataTextField = "UPASAMUHANAME";
                this.ddlUpaSamuha.DataValueField = "UPASAMUHAID";
                this.ddlUpaSamuha.Items.Add(new ListItem("छान्नुहोस", "0"));
            }
            this.ddlUpaSamuha.DataBind();

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
            List<ATTPostingType> lst = BLLPostingType.GetPostingType(null, "Y");
            if (lst.Count>0)
            {
                lst.Insert(0, new ATTPostingType(0, "--- Select Type ---", "Y"));
            }
            this.ddlPostingType.DataSource = lst;
            this.ddlPostingType.DataTextField = "PostingTypeName";
            this.ddlPostingType.DataValueField = "PostingTypeID";
            this.ddlPostingType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlSewa_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSamuha();
    }

    protected void ddlSamuha_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUpaSamuha();
    }

    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.LoadDesignations();
        this.LoadOrganizationAvailablePosts(ddlOrganization.SelectedIndex);
    }

    void ClearME()
    {
        this.ddlOrganization.SelectedIndex = -1;
        this.ddlPost.SelectedIndex = -1;
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSName.Text = "";
        this.ddlSewa.SelectedIndex = -1;
        this.ddlSamuha.SelectedIndex = -1;
        this.ddlUpaSamuha.SelectedIndex = -1;
        this.ddlPost.SelectedIndex = -1;
        this.ddlLevel.SelectedIndex = -1;
        this.ddlPostingType.SelectedIndex = -1;
        this.ddlSex.SelectedIndex = -1;
        this.ddlDistrict.SelectedIndex = -1;
        this.txtTraining.Text = "";
        this.txtRetirementDate.Text = "";
        this.UnCheckedList(this.lstQualification);
        this.UnCheckedList(this.lstVisit);
        this.grdEmployee.DataSource = "";
        this.grdEmployee.DataBind();
        this.lblRecordCount.Text = "";
    }

    void UnCheckedList(CheckBoxList lst)
    {
        foreach (ListItem li in lst.Items)
        {
            li.Selected = false;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ATTEmployeeDetailSearch search = new ATTEmployeeDetailSearch();
        if (this.ddlOrganization.SelectedIndex > 0)
            search.OrgID = int.Parse(this.ddlOrganization.SelectedValue);

        if (this.txtFName.Text.Trim() != "")
            search.FirstName = this.txtFName.Text;

        if (this.txtMName.Text.Trim() != "")
            search.MiddleName = this.txtMName.Text;

        if (this.txtSName.Text.Trim() != "")
            search.SurName = this.txtSName.Text;

        if (this.ddlSewa.SelectedIndex > 0)
            search.SewaID = int.Parse(this.ddlSewa.SelectedValue);

        if (this.ddlSamuha.SelectedIndex > 0)
            search.SamuhaID = int.Parse(this.ddlSamuha.SelectedValue);

        if (this.ddlUpaSamuha.SelectedIndex > 0)
            search.UpaSamuhaID = int.Parse(this.ddlUpaSamuha.SelectedValue);

        if (this.ddlPost.SelectedIndex > 0)
            search.PostID = int.Parse(this.ddlPost.SelectedValue);

        if (this.ddlLevel.SelectedIndex > 0)
            search.LevelID = int.Parse(this.ddlLevel.SelectedValue);

        if (this.ddlPostingType.SelectedIndex > 0)
            search.PostingTypeID = int.Parse(this.ddlPostingType.SelectedValue);

        if (this.ddlSex.SelectedIndex > 0)
            search.Gender = this.ddlSex.SelectedValue;

        if (this.ddlDistrict.SelectedIndex > 0)
            search.DistrictID = int.Parse(this.ddlDistrict.SelectedValue);

        if (this.txtTraining.Text.Trim() != "")
            search.Training = this.txtTraining.Text;

        if (this.txtRetirementDate.Text.Trim() != "")
        {
            search.RetirementDate = this.txtRetirementDate.Text;
            search.RetirementDateOperator = this.ddlROperator.SelectedItem.Text;
            search.RetirementYear = 20;
        }


        search.QualificationList = this.GetCheckedValueList(this.lstQualification);
        search.VisitList = this.GetCheckedValueList(this.lstVisit);
        
        //this.grdEmployee.DataSource = BLLEmployeeDetailSearch.DetailSearchEmployee(search);
        Session["EmployeeDetailSearch"] = BLLEmployeeDetailSearch.DetailSearchEmployeeList(search);
        this.grdEmployee.DataSource = Session["EmployeeDetailSearch"];
        this.grdEmployee.DataBind();

        //foreach (GridViewRow row in this.grdEmployee.Rows)
        //{
        //    if (row.Cells[16].Text == "hide" && row.Cells[17].Text == "hide" && row.Cells[18].Text == "hide")
        //        for (int i = 0; i <= 21; i++)
        //        {
        //            row.Cells[i].Visible = false;
        //        }
        //}

        this.LoadImageX.Width = new Unit(0);
        this.LoadImageX.Height = new Unit(0);
    }

    List<int> GetCheckedValueList(CheckBoxList lst)
    {
        List<int> chkLst = new List<int>();
        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                chkLst.Add(int.Parse(li.Value));
        }
        return chkLst;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }

    string EmpID = "";
    int empRow = -1;
    int trainRow = -1;
    int quaRow = -1;
    int visitRow = -1;
    string trainStr = "";
    string quaStr = "";
    string visitStr = "";
    string purpose = "";
    string fromDate = "";
    string toDate = "";
    ATTEmployeeDetailSearch oDegree;
    ATTEmployeeDetailSearch oTraining;
    ATTEmployeeDetailSearch oVisit;
    int rowCount = 0;

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[16].Visible = false; //subject
        e.Row.Cells[17].Visible = false; //degree
        e.Row.Cells[18].Visible = false; //visited country

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<ATTEmployeeDetailSearch> lst = (List<ATTEmployeeDetailSearch>)Session["EmployeeDetailSearch"];

            this.oTraining = lst.Find
                                    (
                                        delegate(ATTEmployeeDetailSearch s)
                                        {
                                            return s.EmpID == double.Parse(e.Row.Cells[0].Text) &&
                                                s.SubjectID == int.Parse(e.Row.Cells[16].Text);
                                        }
                                    );
            //if (oTraining == null) oTraining = new ATTEmployeeDetailSearch();

            this.oDegree = lst.Find
                                    (
                                        delegate(ATTEmployeeDetailSearch s)
                                        {
                                            return s.EmpID == double.Parse(e.Row.Cells[0].Text) &&
                                                s.DegreeID == int.Parse(e.Row.Cells[17].Text);
                                        }
                                    );
            //if (oDegree == null) oDegree = new ATTEmployeeDetailSearch();

            this.oVisit = lst.Find
                                    (
                                        delegate(ATTEmployeeDetailSearch s)
                                        {
                                            return s.EmpID == double.Parse(e.Row.Cells[0].Text) &&
                                                s.VisitCountryID == int.Parse(e.Row.Cells[18].Text);
                                        }
                                    );
            //if (oVisit == null) oVisit = new ATTEmployeeDetailSearch();

            if (this.EmpID == e.Row.Cells[0].Text)
            {
                //for (int i = 1; i <= 15; i++)
                //{
                //    if (i != 11 && i != 14 && i != 15)
                //    {
                //        if (this.grdEmployee.Rows[empRow].Cells[i].RowSpan == 0)
                //            this.grdEmployee.Rows[empRow].Cells[i].RowSpan = 2;
                //        else
                //            this.grdEmployee.Rows[empRow].Cells[i].RowSpan += 1;
                //        e.Row.Cells[i].Visible = false;
                //    }
                //}

                if (this.oTraining.IsTrainingMerged == 1)
                {
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[16].Text = "hide";
                }
                else
                {
                    this.trainStr += "<br>" + lst[e.Row.RowIndex].Training + " | ";
                    this.grdEmployee.Rows[trainRow].Cells[11].Text = this.trainStr;
                    //e.Row.VerticalAlign = VerticalAlign.Middle;
                    this.oTraining.IsTrainingMerged = 1;
                }

                if (this.oDegree.IsDegreeMerged == 1)
                {
                    e.Row.Cells[14].Text = "";
                    e.Row.Cells[17].Text = "hide";
                }
                else
                {
                    this.quaStr += "<br>" + lst[e.Row.RowIndex].QualificationName + " | ";
                    this.grdEmployee.Rows[quaRow].Cells[14].Text = this.quaStr;
                    //e.Row.VerticalAlign = VerticalAlign.Middle;
                    this.oDegree.IsDegreeMerged = 1;
                }

                if (this.oVisit.IsVisitMerged == 1)
                {
                    //e.Row.Cells[15].Text = "";
                    //e.Row.Cells[19].Text = "";
                    //e.Row.Cells[20].Text = "";
                    //e.Row.Cells[21].Text = "";
                    //e.Row.Cells[18].Text = "hide";
                }
                else
                {
                    this.visitStr += "<br>" + lst[e.Row.RowIndex].VisitCountryName + " | ";
                    this.purpose += "<br>" + lst[e.Row.RowIndex].VisitPurpose + " | ";
                    this.fromDate += "<br>" + lst[e.Row.RowIndex].VisitFromDate + " | ";
                    this.toDate += "<br>" + lst[e.Row.RowIndex].VisitToDate + " | ";

                    this.grdEmployee.Rows[visitRow].Cells[15].Text = this.visitStr;
                    this.grdEmployee.Rows[visitRow].Cells[19].Text = this.purpose;
                    this.grdEmployee.Rows[visitRow].Cells[20].Text = this.fromDate;
                    this.grdEmployee.Rows[visitRow].Cells[21].Text = this.toDate;
                    //e.Row.VerticalAlign = VerticalAlign.Middle;
                    this.oVisit.IsVisitMerged = 1;
                }


                //if (e.Row.Cells[16].Text == "hide" && e.Row.Cells[17].Text == "hide" && e.Row.Cells[18].Text == "hide")
                    for (int i = 0; i <= 21; i++)
                    {
                        e.Row.Cells[i].Visible = false;
                    }
                
            }

            #region "Commented part"
            //if (this.grdEmployee.Rows[firstRow].Cells[1].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[1].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[1].RowSpan += 1;
            //e.Row.Cells[1].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[2].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[2].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[2].RowSpan += 1;
            //e.Row.Cells[2].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[3].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[3].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[3].RowSpan += 1;
            //e.Row.Cells[3].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[4].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[4].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[4].RowSpan += 1;
            //e.Row.Cells[4].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[5].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[5].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[5].RowSpan += 1;
            //e.Row.Cells[5].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[6].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[6].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[6].RowSpan += 1;
            //e.Row.Cells[6].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[7].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[7].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[7].RowSpan += 1;
            //e.Row.Cells[7].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[8].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[8].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[8].RowSpan += 1;
            //e.Row.Cells[8].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[9].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[9].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[9].RowSpan += 1;
            //e.Row.Cells[9].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[10].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[10].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[10].RowSpan += 1;
            //e.Row.Cells[10].Visible = false;

            ////if (Training == e.Row.Cells[11].Text)
            ////{
            //    if (this.grdEmployee.Rows[firstRow].Cells[11].RowSpan == 0)
            //        this.grdEmployee.Rows[firstRow].Cells[11].RowSpan = 2;
            //    else
            //        this.grdEmployee.Rows[firstRow].Cells[11].RowSpan += 1;
            //    e.Row.Cells[11].Visible = false;
            ////}

            //if (this.grdEmployee.Rows[firstRow].Cells[12].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[12].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[12].RowSpan += 1;
            //e.Row.Cells[12].Visible = false;

            //if (this.grdEmployee.Rows[firstRow].Cells[13].RowSpan == 0)
            //    this.grdEmployee.Rows[firstRow].Cells[13].RowSpan = 2;
            //else
            //    this.grdEmployee.Rows[firstRow].Cells[13].RowSpan += 1;
            //e.Row.Cells[13].Visible = false;

            ////if (Qualification == e.Row.Cells[14].Text)
            ////{
            //    if (this.grdEmployee.Rows[firstRow].Cells[14].RowSpan == 0)
            //        this.grdEmployee.Rows[firstRow].Cells[14].RowSpan = 2;
            //    else
            //        this.grdEmployee.Rows[firstRow].Cells[14].RowSpan += 1;
            //    e.Row.Cells[14].Visible = false;
            ////}

            ////if (VisitedCoutry == e.Row.Cells[15].Text)
            ////{
            //    if (this.grdEmployee.Rows[firstRow].Cells[15].RowSpan == 0)
            //        this.grdEmployee.Rows[firstRow].Cells[15].RowSpan = 2;
            //    else
            //        this.grdEmployee.Rows[firstRow].Cells[15].RowSpan += 1;
            //    e.Row.Cells[15].Visible = false;
            ////}
            //}
            #endregion

            else
            {
                rowCount++;

                if (rowCount % 2 == 1)
                    e.Row.BackColor = System.Drawing.Color.FromName("#E7E2E2");
                else
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffffff");

                e.Row.VerticalAlign = VerticalAlign.Middle;
                for (int i = 1; i <= 21; i++)
                {
                    e.Row.Cells[i].Style.Add("border-top", "#4F69A2 1px solid");
                }

                //e.Row.Cells[0].Text = (empCount++).ToString();

                this.EmpID = e.Row.Cells[0].Text;

                this.empRow = e.Row.RowIndex;

                this.trainRow = e.Row.RowIndex;
                this.quaRow = e.Row.RowIndex;
                this.visitRow = e.Row.RowIndex;

                this.trainStr = lst[e.Row.RowIndex].Training + " | ";
                this.quaStr = lst[e.Row.RowIndex].QualificationName + " | ";
                this.visitStr = lst[e.Row.RowIndex].VisitCountryName + " | ";
                this.purpose = lst[e.Row.RowIndex].VisitPurpose + " | ";
                this.fromDate = lst[e.Row.RowIndex].VisitFromDate + " | ";
                this.toDate = lst[e.Row.RowIndex].VisitToDate + " | ";

                this.oTraining.IsTrainingMerged = 1;
                this.oDegree.IsDegreeMerged = 1;
                this.oVisit.IsVisitMerged = 1;
            }
        }
    }

    protected void grdEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdEmployee.Rows.Count <= 0)
            this.lblRecordCount.Text = "No record has been found.";
        else
            this.lblRecordCount.Text = "Total Employee(s): "+this.rowCount.ToString();
            //this.lblRecordCount.Text = this.grdEmployee.Rows[this.grdEmployee.Rows.Count].Cells[0].Text + " employee(s) has been found.";
    }
    protected void ddlUpaSamuha_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
