using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Oracle.DataAccess.Client;

using System.Collections.Generic;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.REPORT;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_PMS_Forms_EmployeeAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,45,1") == true)
        {
            //grdAttendance.Visible = false;

            if (!IsPostBack)
            {
                ddlMonth.Enabled = false;
                Session["MonthlyHolidays"] = "null";
                GetYear();
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadOrganizationUnit(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
                //GetApprovedLeaves();
                //LoadGridHeader();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    void LoadOrganizationWithChilds(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));

            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();
            this.ddlOrganization.DataBind();
            ddlOrganization.SelectedIndex= OrganizationList.FindIndex(delegate(ATTOrganization obj) 
                                        {
                                            return obj.OrgID == OrgID;
                                        });

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    private void LoadOrganizationUnit(int orgId)
    {
        try
        {
            List<ATTOrganizationUnit> LSTOrgUnit = BLLOrganizationUnit.GetOrganizationUnits(orgId, null);
            LSTOrgUnit.Insert(0,new ATTOrganizationUnit(0,0,"छान्नुहोस"));
            this.ddlorgUnit.DataSource = LSTOrgUnit;
            this.ddlorgUnit.DataTextField = "UnitName";
            this.ddlorgUnit.DataValueField="UnitID";
            this.ddlorgUnit.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "",0,0));
            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    private void LoadAnnualHoliday()
    {
        string year = this.ddlYear.SelectedValue.ToString().Substring(2, 2);
        List<ATTAnnualHoliday> LSTAnnHoliday = BLLAnnualHoliday.GetAnnHoliday(year);
        Session["AnnHoliday"] = LSTAnnHoliday;
    }

    void GetYear()
    {
        List<ATTFixedHoliday> LSTYear = BLLFixedHoliday.GetYear();
        LSTYear.Insert(0, new ATTFixedHoliday("छान्नुहोस्", "", "", "", "", "", "", "", ""));
        this.ddlYear.DataSource = LSTYear;
        this.ddlYear.DataTextField = "Year";
        this.ddlYear.DataValueField = "Year";
        this.ddlYear.DataBind();
    }

    void GetCalender()
    {
        int year = int.Parse(this.ddlYear.SelectedValue);
        int month = int.Parse(this.ddlMonth.SelectedValue);

        string str = BLLDate.GetDateString(year, month, "_N");
        Session["Month"] = str;
        

        int days = GetDays();

        string[] array = str.Split('/');

        int i = GetNoOfSaturdays(int.Parse(array[3]), int.Parse(array[4]));
        LoadGridHeader();
        Session["Saturdays_Date"] = i;
    }

    private int GetNoOfSaturdays(int firstday,int totaldays)
    {
        int count = 0;
        int sat = 0;
        string satday = "";
        for (int i = 0; i < totaldays; i++)
        {
            int j = i + firstday;
            if (j%7==0)
            {
                count++;
                sat = i + 1;
                satday = satday + sat.ToString() + ",";
            }   
        }
        satday = satday.Substring(0, satday.LastIndexOf(','));
        Session["Saturday"] = satday;
        return count;
        
    }

    void LoadGridHeader()
    {
        DataTable dt = SetDataTable();
        DataRow dr=dt.NewRow();
        dt.Rows.Add(dr);
        this.grdAttendance.DataSource = dt;
        DataBind();
        //grdAttendance.Visible = true;
    }

    private static DataTable SetDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("SNo"));
        dt.Columns.Add(new DataColumn("FullName"));
        dt.Columns.Add(new DataColumn("01"));
        dt.Columns.Add(new DataColumn("02"));
        dt.Columns.Add(new DataColumn("03"));
        dt.Columns.Add(new DataColumn("04"));
        dt.Columns.Add(new DataColumn("05"));
        dt.Columns.Add(new DataColumn("06"));
        dt.Columns.Add(new DataColumn("07"));
        dt.Columns.Add(new DataColumn("08"));
        dt.Columns.Add(new DataColumn("09"));
        dt.Columns.Add(new DataColumn("10"));
        dt.Columns.Add(new DataColumn("11"));
        dt.Columns.Add(new DataColumn("12"));
        dt.Columns.Add(new DataColumn("13"));
        dt.Columns.Add(new DataColumn("14"));
        dt.Columns.Add(new DataColumn("15"));
        dt.Columns.Add(new DataColumn("16"));
        dt.Columns.Add(new DataColumn("17"));
        dt.Columns.Add(new DataColumn("18"));
        dt.Columns.Add(new DataColumn("19"));
        dt.Columns.Add(new DataColumn("20"));
        dt.Columns.Add(new DataColumn("21"));
        dt.Columns.Add(new DataColumn("22"));
        dt.Columns.Add(new DataColumn("23"));
        dt.Columns.Add(new DataColumn("24"));
        dt.Columns.Add(new DataColumn("25"));
        dt.Columns.Add(new DataColumn("26"));
        dt.Columns.Add(new DataColumn("27"));
        dt.Columns.Add(new DataColumn("28"));
        dt.Columns.Add(new DataColumn("29"));
        dt.Columns.Add(new DataColumn("30"));
        dt.Columns.Add(new DataColumn("31"));
        dt.Columns.Add(new DataColumn("32"));
        dt.Columns.Add(new DataColumn("WorkingDays"));
        dt.Columns.Add(new DataColumn("Leave"));
        dt.Columns.Add(new DataColumn("Holiday"));
        dt.Columns.Add(new DataColumn("Weekend"));
        dt.Columns.Add(new DataColumn("Absent"));
        dt.Columns.Add(new DataColumn("Present"));
        return dt;
    }

    private static DataTable SetDataTableSummary()
    {
        DataTable dtS = new DataTable();
        dtS.Columns.Add(new DataColumn("SNo"));
        dtS.Columns.Add(new DataColumn("EmpFullName"));
        dtS.Columns.Add(new DataColumn("TotDays"));
        dtS.Columns.Add(new DataColumn("WorkingDays"));
        dtS.Columns.Add(new DataColumn("Present"));
        dtS.Columns.Add(new DataColumn("Saturday"));
        dtS.Columns.Add(new DataColumn("Leave"));
        dtS.Columns.Add(new DataColumn("AnnualHoliday"));
        dtS.Columns.Add(new DataColumn("Absent"));
        return dtS;
    }

    void GetMonthlyHolidays()
    {
        string str = Session["Month"].ToString();
        string year = str.Substring(0, 4);
        string month = int.Parse(str.Substring(5, 1)).ToString();
        string actMonth = 00 + month;
        string dysFrom = str.Substring(7, 1);
        string dysTo = str.Substring((str.LastIndexOf('/') + 1), (str.Length - (str.LastIndexOf('/') + 1)));
        string fromDate = year + "/" + actMonth + "/" + dysFrom;
        string toDate = year + "/" + actMonth + "/" + dysTo;
        Session["FromDate"] = fromDate;
        Session["ToDate"] = toDate;

        string monthlyHolidays = BLLAnnualHoliday.GetMonthlyHoliday(fromDate, toDate);
        int holidays=0;
        if (monthlyHolidays != "null")
        {
            string[] mhcount = monthlyHolidays.Split(',');
            holidays = mhcount.Length;
        }
        else
        {
            holidays = 0;
        }
        Session["MonthlyHolidays"] = monthlyHolidays;
        Session["MonthlyHolidaysCount"] = holidays;
        LoadGridHeader();
    }    

    private int GetDays()
    {
        string str = Session["Month"].ToString();
        string dys = str.Substring((str.LastIndexOf('/') + 1), (str.Length - (str.LastIndexOf('/') + 1)));
        int dy = int.Parse(dys);
        Session["Days"] = dy;
        return dy;
    }   

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //int leaveCount=0;
        if (ddlMonth.SelectedIndex <=0)
        {
            this.lblStatusMessage.Text = "महिना छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        GetCalender();
        GetMonthlyHolidays();
        int sata = (int)Session["Saturdays_Date"];
        int holidayCounts = (int)Session["MonthlyHolidaysCount"];
        foreach (GridViewRow rw in this.grdAttendance.Rows)
        {
            rw.Cells[36].Text = holidayCounts.ToString();
            rw.Cells[37].Text = sata.ToString();
        }
        int orgid = int.Parse(this.ddlOrganization.SelectedValue.ToString());
        int desid = 0;
        if (this.ddlDesignation.SelectedIndex > 0)
        {
            desid = int.Parse(this.ddlDesignation.SelectedValue.ToString());
        }
//-----------------------------------------------------------------------------------------------------------
        #region Leave

        DataTable dt = SetDataTable();
        string FromDate = ddlYear.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + "01";
        string ToDate = "";
        if (ddlMonth.SelectedIndex>0 && ddlMonth.SelectedValue != "12")
        {
             ToDate = ddlYear.SelectedValue + "/" + 00 + (int.Parse(ddlMonth.SelectedValue) + 1) + "/" + "01";
        }
        else if (ddlMonth.SelectedIndex>0 & ddlMonth.SelectedValue == "12")
        {
            ToDate = (int.Parse(ddlYear.SelectedValue) + 1) + "/" + 00 + (int.Parse(ddlMonth.SelectedValue) + 1) + "/" + "01";
        }
        List<ATTEmployeeLeave> LSTEmpLeave = BLLEmployeeLeaveApprove.GetaApprovedLeave(FromDate, ToDate, orgid, desid);
        List<ATTEmployeeLeave> PersonLv = new List<ATTEmployeeLeave>();
        foreach (ATTEmployeeLeave lst in LSTEmpLeave)
        {
            bool existed = PersonLv.Exists(
                                            delegate(ATTEmployeeLeave obj)
                                            {
                                                return obj.EmpID == lst.EmpID;
                                            }
                                         );
            if (!existed)
            {
                ATTEmployeeLeave objLeave = new ATTEmployeeLeave();
                objLeave = lst;
                PersonLv.Add(objLeave);
            }
        }
        if (PersonLv.Count > 0)
        {
            
            foreach (ATTEmployeeLeave lsts in PersonLv)
            {
                DataRow dr = dt.NewRow();

                int i = LSTEmpLeave.FindIndex(delegate(ATTEmployeeLeave obj)
                                                {
                                                    return obj.EmpID == lsts.EmpID;
                                                }
                                             );

                if (i >= 0)
                {
                    dr[1] = LSTEmpLeave[i].EmpFullName.ToString();
                    dt.Rows.Add(dr);
                }
            }
        }

        if (LSTEmpLeave.Count > 0)
        {
            int k=0;
            foreach (ATTEmployeeLeave lsts in LSTEmpLeave)
            {
                
                if (lsts.ApprovedLeaves.Trim() != "")
                {
                    string[] lvs = lsts.ApprovedLeaves.Split(',');
                    for (int j = 0; j < lvs.Length; j++)
                    {
                        if (lvs[j].Length == 1)
                        {
                            lvs[j] = "0" + lvs[j];
                        }
                        dt.Rows[k][lvs[j]] = "L";
                    }
                    dt.Rows[k]["Leave"] = lvs.Length;
                }
                k++;
            }
        }
        else
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr); 
            //GetCalender();
        }

        #endregion

//-----------------------------------------------------------------------------------------------------------
        #region Present

        string yearmonth = this.ddlYear.SelectedValue.ToString() + "/" + ddlMonth.SelectedValue.ToString();
        List<ATTAttendance> LSTAttendance = BLLAttendance.GetEmpAttendance(orgid, desid, yearmonth);
        List<ATTAttendance> Persons = new List<ATTAttendance>();
        foreach (ATTAttendance lst in LSTAttendance)
        {
            bool existed = Persons.Exists(
                                            delegate(ATTAttendance obj)
                                            {
                                                return obj.EmpID == lst.EmpID;
                                            }
                                         );
            if (!existed)
            {
                ATTAttendance objAttn = new ATTAttendance();
                objAttn = lst;
                Persons.Add(objAttn);
            }
        }
        //DataTable dt = SetDataTable();

        if (Persons.Count > 0)
        {
            foreach (ATTAttendance lst in Persons)
            {
                int i = LSTEmpLeave.FindIndex(delegate(ATTEmployeeLeave obj)
                                                {
                                                    return obj.EmpID == lst.EmpID;
                                                }
                                             );
                if (i >= 0)
                {
                    //DataRow dr = dt.NewRow();

                    //dt.Rows[i]["FullName"] = lst.EmpFullName.ToString();

                    List<ATTAttendance> LST = LSTAttendance.FindAll(delegate(ATTAttendance obj)
                                             {
                                                 return lst.EmpID == obj.EmpID;
                                             });

                    foreach (ATTAttendance var in LST)
                    {
                        string day = var.PresentDate.Substring((var.PresentDate.LastIndexOf('/') + 1), 2);
                        if (day != null)
                        {
                            dt.Rows[i][day] = "P";
                        }
                    }
                }
            }
        }
        //else
        //{
        //    DataRow dr = dt.NewRow();
        //    dt.Rows.Add(dr);
        //    //GetCalender();
        //}

        #endregion        
//-----------------------------------------------------------------------------------------------------------
        string holidays=Session["Month"].ToString();
        //string fromDate=holidays.Substring(1,4) ((str.LastIndexOf('/') + 1), (str.Length - (str.LastIndexOf('/') + 1)));

        int sat = (int)Session["Saturdays_Date"];
        int holidayCount = (int)Session["MonthlyHolidaysCount"];
        int daysCount=(int)Session["Days"];
        //int leaveCount = (int)Session["ApprovedLeavesCount"];
       
        //foreach (GridViewRow rw in this.grdAttendance.Rows)
        //{
        //    //rw.Cells[35].Text = LeaveCount.ToString();
        //    rw.Cells.["Holiday"].Text = holidayCount.ToString();
        //    rw.Cells["Weekend"].Text = sat.ToString();
        //}
        foreach (DataRow rw in dt.Rows)
        {
            int leaveCount = 0;
            string lvCnt = rw["Leave"].ToString();
            if (lvCnt != "")
            {
                leaveCount = int.Parse(lvCnt);
            }
            //rw.Cells[35].Text = LeaveCount.ToString();
            rw["Holiday"] = holidayCount.ToString();
            rw["Weekend"] = sat.ToString();
            string workingDays = (daysCount - (holidayCount + sat)).ToString();
            rw["WorkingDays"] = workingDays;
            Session["WorkDays"] = workingDays;

            foreach (DataColumn dc in dt.Columns)
            {
                string st = rw[dc].ToString().Trim();
                if (st == "")
                {
                    rw[dc] = "A";
                }
            }
            string ACheck = rw["Leave"].ToString().Trim();
            string FCheck = rw["FullName"].ToString().Trim();
            if (ACheck == "A")
            {
                rw["Leave"] = "";
            }
            if (FCheck == "A")
            {
                rw["FullName"] = "";
            }
        }
        int colCount = dt.Columns.Count;
        foreach (DataRow dr in dt.Rows)
        {

            int AbsCount = 0;
            int PresCount = 0;
            for (int i = 0; i < colCount - 1; i++)
            {
                if (dr[i].ToString() == "A")
                {
                    AbsCount++;
                }
                else if (dr[i].ToString() == "P")
                {
                    PresCount++;
                }
            }
           dr["Absent"] = AbsCount.ToString();
           dr["Present"] = PresCount.ToString();
        }


        grdAttendance.DataSource = dt;
        grdAttendance.DataBind();
        Session["Data"] = dt;
    }

    protected void ddlYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlMonth.Enabled = true;
        ddlMonth.SelectedIndex = -1;
        grdAttendance.DataSource = null;
        grdAttendance.DataBind();
        //LoadAnnualHoliday();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ddlDesignation.SelectedIndex = 0;
        this.ddlorgUnit.SelectedIndex = 0;
        this.ddlYear.SelectedIndex = 0;
        this.ddlMonth.SelectedIndex = 0;
        this.grdAttendance.DataSource = null;
        this.grdAttendance.DataBind();
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdAttendance.DataSource = null;
        this.grdAttendance.DataBind();
        //GetCalender();
        //GetMonthlyHolidays();
        //int sat = (int)Session["Saturdays_Date"];
        //int holidayCount =(int)Session["MonthlyHolidaysCount"];
        //foreach (GridViewRow rw in this.grdAttendance.Rows)
        //{
        //    rw.Cells[36].Text = holidayCount.ToString();
        //    rw.Cells[37].Text = sat.ToString();
        //}
    }

    protected void grdAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            int dy = GetDays();

            int val = 32 - dy;

            int r = 32;

            for (int i = 0; i < val; i++)
            {
                e.Row.Cells[r + 1].Visible = false;
                r--;
            }
            if (Session["MonthlyHolidays"].ToString() != "null")
            {
                string[] monthlyHolidays = Session["MonthlyHolidays"].ToString().Split(',');
                for (int j = 0; j < monthlyHolidays.Length; j++)
                {
                    if (e.Row.RowType != DataControlRowType.Header)
                    {
                        e.Row.Cells[int.Parse(monthlyHolidays[j]) + 1].Text = "H";
                    }
                    e.Row.Cells[int.Parse(monthlyHolidays[j]) + 1].BackColor = (e.Row.RowType == DataControlRowType.Header) ? System.Drawing.Color.Chocolate : System.Drawing.Color.Cornsilk;

                }
            }

            if (Session["Saturday"] != null)
            {
                string[] saturdays = Session["Saturday"].ToString().Split(',');

                for (int i = 0; i < saturdays.Length; i++)
                {
                    if (e.Row.Cells[int.Parse(saturdays[i]) + 1].Text == "H")
                    {
                        if (e.Row.RowType != DataControlRowType.Header)
                        {
                            e.Row.Cells[int.Parse(saturdays[i]) + 1].Text = "<b>S/H</b>";
                        }
                        e.Row.Cells[int.Parse(saturdays[i]) + 1].BackColor = (e.Row.RowType == DataControlRowType.Header) ? System.Drawing.Color.Crimson : System.Drawing.Color.OldLace;
                    }
                    else 
                    {
                        if (e.Row.RowType != DataControlRowType.Header)
                        {
                            e.Row.Cells[int.Parse(saturdays[i]) + 1].Text = "<b>S</b>";
                        }
                        e.Row.Cells[int.Parse(saturdays[i]) + 1].BackColor = (e.Row.RowType == DataControlRowType.Header) ? System.Drawing.Color.CadetBlue : System.Drawing.Color.Moccasin;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnExportData_Click(object sender, EventArgs e)
    {
        string mimeType;
        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(".xlsx");
        if (regKey != null && regKey.GetValue("Content Type") != null)
            mimeType = regKey.GetValue("Content Type").ToString();
        else
            return;

        if (this.ddlExportWhat.SelectedIndex==1 && this.ddlExportOption.SelectedIndex == 1)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Employee Attendance_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".doc");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/word";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            this.grdAttendance.Caption = "Employee Attendance";
            this.grdAttendance.CaptionAlign = TableCaptionAlign.Left;
            this.grdAttendance.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();
        }

        else if (this.ddlExportWhat.SelectedIndex==1 && this.ddlExportOption.SelectedIndex == 2)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Employee Attendance_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            this.grdAttendance.Caption = "Employee Attendance";
            this.grdAttendance.CaptionAlign = TableCaptionAlign.Left;
            this.grdAttendance.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();
        }

        else if (this.ddlExportWhat.SelectedIndex == 2 && this.ddlExportOption.SelectedIndex == 1)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Employee Attendance Summary_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".doc");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/application/word";
            this.EnableViewState = false;

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            this.grdAttendanceSummary.Caption = "Employee Attendance Summary";
            this.grdAttendanceSummary.CaptionAlign = TableCaptionAlign.Left;
            this.grdAttendanceSummary.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();
        }

        else if (this.ddlExportWhat.SelectedIndex == 2 && this.ddlExportOption.SelectedIndex == 2)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Employee Attendance Summary_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            this.grdAttendanceSummary.Caption = "Employee Attendance Summary";
            this.grdAttendanceSummary.CaptionAlign = TableCaptionAlign.Left;
            this.grdAttendanceSummary.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    #region SecondGrid

    protected void lnkSummary_Click(object sender, EventArgs e)
    {
        DataTable dt=SetDataTableSummary();
       
        foreach (DataRow rw in ((DataTable)Session["Data"]).Rows)
        {
            DataRow dr = dt.NewRow();
            dr["EmpFullName"] =Server.HtmlDecode(rw["FullName"].ToString());
            dr["TotDays"] = Session["Days"].ToString();
            dr["Present"] = Server.HtmlDecode(rw["Present"].ToString());
            string string3=Session["Saturday"].ToString();
            dr["Saturday"] =string3.Split(',').Length;
            dr["Leave"] =Server.HtmlDecode(rw["Leave"].ToString());
            dr["AnnualHoliday"] =Server.HtmlDecode(rw["Holiday"].ToString());
            //string str = Session["Days"].ToString();
            //string str1 = Session["Saturday"].ToString();
            string str2 = Session["WorkDays"].ToString();
            int h = int.Parse(str2);
            dr["WorkingDays"] = h;
            dr["Absent"] = Server.HtmlDecode(rw["Absent"].ToString());
            dt.Rows.Add(dr);
        }
        grdAttendanceSummary.DataSource = dt;
        grdAttendanceSummary.DataBind();
    }

    #endregion
}
