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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;



public partial class MODULES_OAS_Forms_newCal : System.Web.UI.Page
{
    public int orgID, unitID, appointmentID;
    public string alreadyCheckedList1;
    public string entryBy;
    public int userOrgID;
    public string isIndoorAppointee;
    public string inOut;
    public int loginID;
    public bool flagSet;

    public ATTAppointment ObjAppointment
    {
        get
        {
            return (Session["ObjAppointment"] == null) ? new ATTAppointment() : (ATTAppointment)Session["ObjAppointment"];
        }
        set { Session["ObjAppointment"] = value; }
    }

    public String Action
    {
        get
        {
            return (Session["A_Action"].ToString());
        }
        set { Session["A_Action"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        entryBy = user.UserName;
        userOrgID = int.Parse(user.OrgID.ToString());
        loginID = int.Parse(user.PID.ToString());


        if (user.MenuList.ContainsKey("5,9,1") == true)
        {
            if (Page.IsPostBack == false)
            {
               
                LoadControls();

                if (user.MenuList["5,9,1"].PAdd == "Y")
                {
                    this.btnCreateEvent.Visible = true;
                }
              
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

       

        LoadPostBackControls();

    }

 
    public bool CompareTime(string time, string date1, string date2)
    {
        try
        {
            if (date1.Trim() == date2.Trim())
            {
                string currentTime = BLLTime.GetCurrentTime();


                string[] t1 = currentTime.Split('/');
                string[] t2 = time.Split(':');

                int hr1 = int.Parse(t1[0].ToString());
                int min1 = int.Parse(t1[1].ToString());

                int hr2 = int.Parse(t2[0].ToString());
                int min2 = int.Parse(t2[1].ToString());

                if (hr2 > hr1)
                {
                    return true;
                }
                else
                {
                    if (min2 > min1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
        

    }

    public bool CompareDate(string date1,string date2)
    {
        try
        {
            string[] d1 = date1.Split('/');
            string[] d2 = date2.Split('/');

            int year1 = int.Parse(d1[0].ToString());
            int month1 = int.Parse(d1[1].ToString());
            int day1 = int.Parse(d1[2].ToString());

            int year2 = int.Parse(d2[0].ToString());
            int month2 = int.Parse(d2[1].ToString());
            int day2 = int.Parse(d2[2].ToString());

            if (year2 > year1)
            {
                return true;
            }
            else if (year1 == year2)
            {
                if (month2 > month1)
                {
                    return true;
                }
                else if (month1 == month2)
                {
                    if (day2 >= day1)
                    {
                        return true;
                    }
                    else if(day2 < day1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;   
                }

            }
            else
            {
                return false;
            }



            return true;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
          
    public string GetEnglisValue(string value)
    {
        try
        {
            string englishVal;
            englishVal = value;
            englishVal = englishVal.Replace("०", "0");
            englishVal = englishVal.Replace("१", "1");
            englishVal = englishVal.Replace("२", "2");
            englishVal = englishVal.Replace("३", "3");
            englishVal = englishVal.Replace("४", "4");
            englishVal = englishVal.Replace("५", "5");
            englishVal = englishVal.Replace("६", "6");
            englishVal = englishVal.Replace("७", "7");
            englishVal = englishVal.Replace("८", "8");
            englishVal = englishVal.Replace("९", "9");

            return englishVal;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public string GetNepaliValue(int value)
    {
        try
        {
             string nepaliVal;

             nepaliVal = value.ToString();
             nepaliVal = nepaliVal.Replace("0", "०");
             nepaliVal = nepaliVal.Replace("1", "१");
             nepaliVal = nepaliVal.Replace("2", "२");
             nepaliVal = nepaliVal.Replace("3", "३");
             nepaliVal = nepaliVal.Replace("4", "४");
             nepaliVal = nepaliVal.Replace("5", "५");
             nepaliVal = nepaliVal.Replace("6", "६");
             nepaliVal = nepaliVal.Replace("7", "७");
             nepaliVal = nepaliVal.Replace("8", "८");
             nepaliVal = nepaliVal.Replace("9", "९");
          
             return nepaliVal;
        }
        catch (Exception ex)
        {
            throw(ex);
        }
    }
    public string GetFormated(string  value)
    {
        value = "00" + value;
        return value.Substring(value.Length - 2, 2);
    }
    public int GetRowIndex(int Day)
    {
        if (Day >= 1 && Day <= 7)
            return 1;
        else if (Day >= 8 && Day <= 14)
            return 2;
        else if (Day >= 15 && Day <= 21)
            return 3;
        else if (Day >= 22 && Day <= 28)
            return 4;
        else if (Day >= 29 && Day <= 35)
            return 5;
        else if (Day >= 36 && Day <= 42)
            return 6;

        return 0;
    }
    public int GetCellIndex(int Day)
    {
        if (Day >= 1 && Day <= 7)
            return Day;
        else if (Day >= 8 && Day <= 14)
            return Day - 7;
        else if (Day >= 15 && Day <= 21)
            return Day - 14;
        else if (Day >= 22 && Day <= 28)
            return Day - 21;
        else if (Day >= 29 && Day <= 35)
            return Day - 28;
        else if (Day >= 36 && Day <= 42)
            return Day - 35;

        return 0;
    }
    public string GetNextYearNMonth()
    {
        int month = int.Parse(this.lblMonth.Text);
        int year = int.Parse(this.lblYear.Text);

        month = month + 1;

        if (month > 12)
        {
            month = 1;
            year = year + 1;
        }
        string maxYear = GetEnglisValue(this.ddlYear.Items[this.ddlYear.Items.Count - 1].Text);
        string minYear = GetEnglisValue(this.ddlYear.Items[1].Text);

        if (year > int.Parse(maxYear))
            year = int.Parse(minYear);

        //if (year > int.Parse(this.ddlYear.val[this.ddlYear.Items.Count - 1].Text))

        return year.ToString() + "/" + month.ToString();
    }
    public string GetPreviousYearNMonth()
    {
        int month = int.Parse(this.lblMonth.Text);
        int year = int.Parse(this.lblYear.Text);

        month = month - 1;

        if (month == 0)
        {
            month = 12;
            year = year - 1;
        }

        //if (year < int.Parse(this.ddlYear.Items[1].Text))
        //    year = int.Parse(this.ddlYear.Items[this.ddlYear.Items.Count - 1].Text);

        string maxYear = GetEnglisValue(this.ddlYear.Items[this.ddlYear.Items.Count - 1].Text);
        string minYear = GetEnglisValue(this.ddlYear.Items[1].Text);

        if (year < int.Parse(minYear))
            year = int.Parse(maxYear);

        return year.ToString() + "/" + month.ToString();
    }

    protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
    {
        string s = this.GetPreviousYearNMonth();

        char[] token ={ '/' };

        int year = int.Parse(s.Split(token)[0]);
        int month = int.Parse(s.Split(token)[1]);

        try
        {
            this.LoadNepaliCalender(year, month, "_N");
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void imgNext_Click(object sender, ImageClickEventArgs e)
    {
        string s = this.GetNextYearNMonth();

        char[] token ={ '/' };

        int year = int.Parse(s.Split(token)[0]);
        int month = int.Parse(s.Split(token)[1]);

        try
        {
            this.LoadNepaliCalender(year, month, "_N");
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void imgShow_Click(object sender, ImageClickEventArgs e)
    {
        ShowCalendar();
    }

    public void ShowCalendar()
    {
        if (this.ddlYear.SelectedIndex <= 0)
            return;
        if (this.ddlMonth.SelectedIndex <= 0)
            return;

        try
        {
            this.LoadNepaliCalender(int.Parse(this.ddlYear.SelectedValue.ToString()), int.Parse(this.ddlMonth.SelectedValue), "_N");
        
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadNepaliCalender(int year, int month, string LP)
    {
        try
        {


            string dateString = BLLDate.GetDateString(year, month, "_N");


            if (Session["CurrentDate1"] == null)
            {
                Session["CurrentDate1"] = dateString;
                int len = Session["CurrentDate1"].ToString().Length;
                string currentDate = Session["CurrentDate1"].ToString().Substring(0, len - 5);

                hdnCurrentDate.Value = currentDate;
            }

            char[] token ={ '/' };

            int Year = int.Parse(dateString.Split(token)[0]);
            int Month = int.Parse(dateString.Split(token)[1]);
            int Day = int.Parse(dateString.Split(token)[2]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int TDay = int.Parse(dateString.Split(token)[4]);

            this.lblYear.Text = Year.ToString();
            this.lblYear1.Text = GetNepaliValue(int.Parse(Year.ToString()));

            hdnMonth.Value = Month.ToString();

            this.lblMonth.Text = Month.ToString();
            this.lblMonthText.Text = PCS.FRAMEWORK.Utilities.NepaliMonthList[Month - 1];

            Label lbl;


            this.ClearDayEvent();

            int day = 0;
            int lastRowIndex = 0;
            for (int i = SDay; i < TDay + SDay; i++)
            {
                day = day + 1;
                lbl = ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("Day" + i.ToString()));

                //lbl.Text = day.ToString();

                lbl.Text = GetNepaliValue(day);

                lastRowIndex = GetRowIndex(i);

                this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onclick", "OnCellClick(this)");

                this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Style.Add("cursor", "hand");

                if (this.GetCellIndex(i) != 7)
                {
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseover", "OnMouseOverX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseout", "OnMouseOutX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.White;

                }
                else
                {
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseover", "OnMouseOverX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Add("onmouseout", "OnMouseOutX(this)"); ;
                    this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.White;

            
                    //this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].BackColor = System.Drawing.Color.FromName("#c6d8e2");
                    ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Controls[0]).ForeColor = System.Drawing.Color.Red;
                }

            }

            if (lastRowIndex == 5)
                this.tblAM.Rows[6].Visible = false;
            else
                this.tblAM.Rows[6].Visible = true;


            LoadEvents();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadYear()
    {
        this.ddlYear.Items.Add(new ListItem("साल", "0"));

        DataTable tbl = BLLDate.GetMaxMinYear();

        for (int i = int.Parse(tbl.Rows[0]["Min_Year"].ToString()); i <= int.Parse(tbl.Rows[0]["Max_Year"].ToString()); i++)
        {
            string year = GetNepaliValue(i);

            this.ddlYear.Items.Add(new ListItem(year, i.ToString()));
        }

    }
    public void LoadMonth()
    {
        this.ddlMonth.Items.Add(new ListItem("महिना", "0"));
        int value = 0;
        foreach (string month in PCS.FRAMEWORK.Utilities.NepaliMonthList)
        {
            value = value + 1;
            this.ddlMonth.Items.Add(new ListItem(month, value.ToString()));
        }
    }
    public void LoadEvents()
    {
        try
        {

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            ArrayList arrEventLst = new ArrayList();

            List<ATTAppointmentEvent> lstEvent = new List<ATTAppointmentEvent>();
            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

            Session["AppointmentEvents"] = BLLAppointmentEvent.GetEventList(dateString,objUserLogin);
          
            lstEvent = (List<ATTAppointmentEvent>)Session["AppointmentEvents"];

            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int tDay = int.Parse(dateString.Split(token)[4]);

            for (int i = 1; i <= tDay; i++)
            {

                List<ATTAppointmentEvent> lst = new List<ATTAppointmentEvent>();

                lst = lstEvent.FindAll(
                                                            delegate(ATTAppointmentEvent objEvent)
                                                            {
                                                                return objEvent.Day == i;
                                                            }

                                                         );
                DataList dLst;

                dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(SDay)].Cells[this.GetCellIndex(SDay) - 1].FindControl("DataList" + SDay.ToString()));

                if (lst.Count > 0)
                {
                    if (dLst != null)
                    {
                        arrEventLst.Add(i.ToString());

                        dLst.Attributes.Add("onclick", "chkPopup()");

                        dLst.DataSource = lst;
                        dLst.DataBind();
                    }
                }
                else
                {
                    if (dLst != null)
                    {
                        dLst.DataSource = "";
                        dLst.DataBind();
                    }
                }


                SDay++;
            }

            if (arrEventLst.Count > 0)
            {

                Session["arrEventLst"] = (object)arrEventLst;
            }
            else
            {
                Session["arrEventLst"] = null;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void ReLoadEvents()
    {
        try
        {

            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            List<ATTAppointmentEvent> lstEvent = new List<ATTAppointmentEvent>();

            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

            lstEvent = (List<ATTAppointmentEvent>)Session["AppointmentEvents"];

            char[] token ={ '/' };

            int year = int.Parse(dateString.Split(token)[0]);
            int month = int.Parse(dateString.Split(token)[1]);
            int SDay = int.Parse(dateString.Split(token)[3]);
            int tDay = int.Parse(dateString.Split(token)[4]);

            ArrayList arrEventLst = new ArrayList();

            if (Session["arrEventLst"] != null)
                arrEventLst = (ArrayList)Session["arrEventLst"];

            int j = 0;
            
            int tmpSDay = SDay;
            
           /* for (int i = 1; i <= tDay; i++)
            {*/

                int i = 0;
                while (arrEventLst.Count > j)
                {
                i = int.Parse(arrEventLst[j].ToString());
                SDay = tmpSDay + (i - 1);
                
                List<ATTAppointmentEvent> lst = new List<ATTAppointmentEvent>();

                lst = lstEvent.FindAll(
                                                            delegate(ATTAppointmentEvent objEvent)
                                                            {
                                                                return objEvent.Day == i;
                                                            }

                                                         );
                DataList dLst;

                dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(SDay)].Cells[this.GetCellIndex(SDay) - 1].FindControl("DataList" + SDay.ToString()));

                if (lst.Count > 0)
                {
                    if (dLst != null)
                    {
                        dLst.Attributes.Add("onclick", "chkPopup()");

                        dLst.DataSource = lst;
                        dLst.DataBind();
                    }
                }
                else
                {
                    if (dLst != null)
                    {
                        dLst.DataSource = "";
                        dLst.DataBind();
                    }
                }


               
                
             j++;
            }
            /*SDay++;
            }*/

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public bool LoadEventDatas(List<ATTAppointmentEvent> lstRqdEvent, LinkButton lnk)
    {
        try
        {
            //ClearControls();

            foreach (ATTAppointmentEvent objEvent in lstRqdEvent)
            {
                if (objEvent.InOut == "IN")
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;

                    btnIndoor.Visible = true;
                    btnOutdoor.Visible = true;

                    inOut = "IN";

                }
                else
                {
                    btnUpdate.Visible = true;
                    //btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnIndoor.Visible = false;
                    btnOutdoor.Visible = false;


                    //--------------------------
                    txtSubject_rqd.ReadOnly = true;
                    txtVenue_rqd.ReadOnly = true;
                    drpHr1_rqd.Enabled = false;
                    drpMin1_rqd.Enabled = false;
                    drpStatus_rqd.Enabled = false;

                    inOut = "OUT";
                }

                Session["chkInOut"] = inOut;

                foreach (ATTAppointment objAppointment in objEvent.LstAppointment)
                {
                    string startTime, hr1, min1;

                    string endTime, hr2, min2;

                    LoadStatus();

                    drpStatus_rqd.SelectedValue = objAppointment.Status.ToString();

                    startTime = objAppointment.StartTime;

                    hr1 = startTime.Substring(0, startTime.Length - 3).ToString();

                    if (startTime.Length == 4)
                    {
                        min1 = startTime.Substring(2, startTime.Length - 2).ToString();
                    }
                    else
                        min1 = startTime.Substring(3, startTime.Length - 3).ToString();

                    drpHr1_rqd.SelectedValue = hr1;
                    drpMin1_rqd.SelectedValue = min1;


                    endTime = objAppointment.EndTime;

                    hr2 = endTime.Substring(0, endTime.Length - 3).ToString();

                    if (endTime.Length == 4)
                    {
                        min2 = endTime.Substring(2, endTime.Length - 2).ToString();
                    }
                    else
                        min2 = endTime.Substring(3, endTime.Length - 3).ToString();

                    drpHr2_rqd.SelectedValue = hr2;
                    drpMin2_rqd.SelectedValue = min2;

                    txtMeetingDate_rqd.Text = hdnMDate.Value;

                    txtSubject_rqd.Text = objAppointment.AppointmentSubject;
                    txtVenue_rqd.Text = objAppointment.Venue;

                    if (objAppointment.LstAppointee.Count > 0)
                    {
                        grdAppointee.DataSource = objAppointment.LstAppointee;
                        grdAppointee.DataBind();

                        Session["lstAppointee"] = objAppointment.LstAppointee;
                    }

                    btnCreateEvent.Visible = false;

                    if (objEvent.InOut == "IN")
                    {
                        if (objAppointment.Status == 2)
                        {
                            btnUpdate.Visible = false;
                        }
                    }

                    __EventDetail.Value = "yes";
                }
            }


            return true;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }
    }
    public void LoadControls()
    {
        try
        {
            Session["arrEventLst"] = null;
            Session["apCmnt"] = null;
            Session["chkInOut"] = null;
            Session["isIndoorAppointee"] = null;
            Session["lstAppointee"] = null;
            Session["AppointmentStatus"] = BLLAppointmentStatus.GetMeetingStatusList(null, false);
            this.LoadYear();
            this.LoadMonth();
            this.LoadNepaliCalender(0, 0, "_N");
            this.LoadOrganisation();
            this.LoadStatus();
            this.LoadDesignations();

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadDesignations()
    {
        string desType = "";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
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
    public void LoadOrganisation()
    {
        try
        {
            Session["meetingOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["meetingOrgList"] != null)
            {
                this.dllOrgSrch.DataSource = (List<ATTOrganization>)Session["meetingOrgList"];
                this.dllOrgSrch.DataTextField = "OrgName";
                this.dllOrgSrch.DataValueField = "OrgId";
                this.dllOrgSrch.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                dllOrgSrch.Items.Insert(0, a);

            }
         
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    public void LoadVenue()
    {
        try
        {
            Session["MeetingVenueList"] = BLLMeetingVenue.GetMeetingVenueList(null);
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadStatus()
    {
        try
        {

            if (Session["AppointmentStatus"] != null)
            {
                drpStatus_rqd.DataSource = (List<ATTAppointmentStatus>)Session["AppointmentStatus"];
                drpStatus_rqd.DataTextField = "AppointmentStatusName";
                drpStatus_rqd.DataValueField = "AppointmentStatusID";
                drpStatus_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                drpStatus_rqd.Items.Insert(0, a);

                dLstAppointmentStatus.DataSource = (List<ATTAppointmentStatus>)Session["AppointmentStatus"];
                dLstAppointmentStatus.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public void LoadPostBackControls()
    {
        try
        {

            txtMeetingDate_rqd.Text = hdnMDate.Value;

            if (Session["CurrentDate1"] != null)
            {
                int len = Session["CurrentDate1"].ToString().Length;
                string currentDate = Session["CurrentDate1"].ToString().Substring(0, len - 5);

                hdnCurrentDate.Value = currentDate;
            }


            //LoadEvents();

            ReLoadEvents();


            btnIndoor.Visible = true;
            btnOutdoor.Visible = true;

            string scrpt = "function mousepos(event){" +
                                "if(chkObject('dvMeeting')) {" +
                                "floatingd = document.getElementById('dvMeeting');" +
                                "if(drag==1){" +
                                "floatingd.style.left = event.clientX-xdif+'px';" +
                                "floatingd.style.top = event.clientY-ydif+'px';" +
                                "}}}";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", scrpt, true);

            if (Session["chkInOut"] != null && Session["chkInOut"].ToString() == "IN")
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                btnIndoor.Visible = true;
                btnOutdoor.Visible = true;

            }
            else if (Session["chkInOut"] != null && Session["chkInOut"].ToString() == "OUT")
            {
                // btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnIndoor.Visible = false;
                btnOutdoor.Visible = false;

                //------------------------------------------

                txtSubject_rqd.ReadOnly = true;
                txtVenue_rqd.ReadOnly = true;
                drpHr1_rqd.Enabled = false;
                drpMin1_rqd.Enabled = false;
                drpStatus_rqd.Enabled = false;

            }
            else
            {
                btnIndoor.Visible = true;
                btnOutdoor.Visible = true;

                txtSubject_rqd.ReadOnly = false;
                txtVenue_rqd.ReadOnly = false;
                drpHr1_rqd.Enabled = true;
                drpMin1_rqd.Enabled = true;
                drpStatus_rqd.Enabled = true;
            }

            if (txtComment.Text == "")
            {
                txtComment.Visible = false;
                lblComment.Visible = false;
            }




            //NB: in the masterpage, of the body tag is "MainBody"

            /* HtmlGenericControl masterPageBodyTag = (HtmlGenericControl)Page.Master.FindControl("MainBody");

             masterPageBodyTag.Attributes.Add("onMouseMove", "mousepos(event)");*/


            if (Session["flagSet"] != null)
            {
                if (Session["flagSet"].ToString() == "1")
                    flagSet = true;
                else
                    flagSet = false;
            }
            else
                flagSet = true;

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["chkInOut"] = null;

            __EventDetail.Value = "";

            Session["flagSet"] = null;
            flagSet = false;


            Session["lstAppointee"] = null;
            lblCreateMeetingStatus.Text = "";

            grdAppointee.DataSource = null;
            grdAppointee.DataBind();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCreateEvent.Visible = true;

            txtComment.Visible = false;
            lblComment.Visible = false;


            //=========================
            btnIndoor.Visible = true;
            btnOutdoor.Visible = true;

            txtSubject_rqd.ReadOnly = false;
            txtVenue_rqd.ReadOnly = false;
            drpHr1_rqd.Enabled = true;
            drpMin1_rqd.Enabled = true;
            drpStatus_rqd.Enabled = true;

            //=========================

            ddlMonth.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;
            LoadEvents();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
            

     
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void LinkEventHandler(object sender, EventArgs e)
    {
        try
        {
            string arguments = ((LinkButton)sender).CommandArgument.ToString();
           
            if (CalculateIDs(arguments))
            {
               
                List<ATTAppointmentEvent> lstRqdEvent = new List<ATTAppointmentEvent>();
               
                lstRqdEvent = SearchRqdLst();
                Session["RqdEvent"] = lstRqdEvent;

                if (lstRqdEvent.Count > 0)
                {
                    if (LoadEventDatas(lstRqdEvent,(LinkButton)sender))
                    {
                        Session["appointmentAgruments"] = arguments;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "javascript:callDiv();", true);
                    }

                }
                  
            }
            

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public bool CalculateIDs(string arguments)
    {
        try
        {
            string[] IDs = arguments.Split(new char[] { '/' });

            orgID = Convert.ToInt32(IDs[0]);
            unitID = Convert.ToInt32(IDs[1]);
            appointmentID = Convert.ToInt32(IDs[2]);

            Session["appointmentAgruments"] = null;

            return true;
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }

    }

    public List<ATTAppointmentEvent> SearchRqdLst()
    {
        try
        {
            List<ATTAppointmentEvent> lstEvent = new List<ATTAppointmentEvent>();
            List<ATTAppointmentEvent> lst = new List<ATTAppointmentEvent>();

            lstEvent = (List<ATTAppointmentEvent>)Session["AppointmentEvents"];


            lst = lstEvent.FindAll(
                                    delegate(ATTAppointmentEvent objEvent)
                                    {
                                        return ((objEvent.OrgID == orgID) && (objEvent.EventID == appointmentID));
                                    }

                                   );
            return lst;

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return new List<ATTAppointmentEvent>();
        }
    }

    public List<int> GetCheckedValueList(CheckBoxList lst)
    {
        List<int> chkLst = new List<int>();

        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                chkLst.Add(int.Parse(li.Value));
        }
        return chkLst;
    }
    public List<string> GetCheckedItemList(CheckBoxList lst)
    {
        List<string> chkLst = new List<string>();

        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                chkLst.Add(li.Text);
        }
        return chkLst;
    }
    
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        //LoadEvents();
        this.programmaticModalPopup.Hide();
    }
       
    protected void btnOutdoor_Click(object sender, EventArgs e)
    {
        Session["isIndoorAppointee"] = "N";
        this.programmaticPersonModalPopup1.Show();
    }
    protected void btnIndoor_Click(object sender, EventArgs e)
    {
        lblSearchTitle.Text = "आन्तरिक सहभागीहरु खोज्नुहोस ";
        Session["isIndoorAppointee"] = "Y";
     
        lblOrgSrch.Visible = true;
        dllOrgSrch.Visible = true;
        lblDesignation.Visible = true;
        ddlDesignation.Visible = true;

        lblSex.Visible = false;
        ddlSGender.Visible = false;
        lblMarriageStatus.Visible = false;
        ddlSMarStatus.Visible = false;
        lblDoB.Visible = false;
        txtSDOB_DT.Visible = false;

        this.programmaticPersonModalPopup.Show();
    }

    protected void btnCreateEvent_Click(object sender, EventArgs e)
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            string currentDate = "";

            currentDate = GetCurrentDate();
            
            string appointmentSetDate = "";
            if (this.txtMeetingDate_rqd.Text != "")
            {
               appointmentSetDate = lblYear.Text.ToString() + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);
            }

            if(CompareDate(currentDate,appointmentSetDate))
            {
                 string time = "00:00:00";
                 if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                 {
                      time = drpHr1_rqd.SelectedValue.ToString()
                                          + ":" + drpMin1_rqd.SelectedValue.ToString();
                 }

                 if (CompareTime(time, currentDate, appointmentSetDate))
                 {
                     ATTAppointment objAppointment = new ATTAppointment();

                     objAppointment.OrgID = userOrgID;
                     objAppointment.AppointmentCalledBy = loginID;
                     objAppointment.AppointmentSubject = txtSubject_rqd.Text;
                     objAppointment.AppointmentDate = appointmentSetDate;

                     if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                     {
                         objAppointment.StartTime = drpHr1_rqd.SelectedValue.ToString()
                                              + ":" + drpMin1_rqd.SelectedValue.ToString();
                     }

                     if (this.drpHr2_rqd.SelectedIndex > 0 && this.drpMin2_rqd.SelectedIndex > 0)
                     {
                         objAppointment.EndTime = drpHr2_rqd.SelectedValue.ToString()
                                              + ":" + drpMin2_rqd.SelectedValue.ToString();
                     }

                     objAppointment.Venue = txtVenue_rqd.Text.Trim();
                     objAppointment.Status = int.Parse(drpStatus_rqd.SelectedValue);
                     objAppointment.EntryBy = entryBy;
                     objAppointment.EntryOn = DateTime.Parse(DateTime.Now.ToString());


                     if (Session["lstAppointee"] != null)
                         objAppointment.LstAppointee = (List<ATTAppointee>)Session["lstAppointee"];

                     ObjectValidation OV = BLLAppointment.ValidateAppointmentEntry(objAppointment);

                     if (OV.IsValid == false)
                     {
                         this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                         this.lblStatusMessage.Text = OV.ErrorMessage;
                         this.programmaticModalPopup.Show();
                         return;
                     }

                     ObjAppointment = objAppointment;
                     Action = "A";

                     ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];

                     List<ATTCheckEvents> lst = new List<ATTCheckEvents>();
                     lst = BLLCheckEvents.CheckEvents(objUserLogin, objAppointment.AppointmentDate,objAppointment.StartTime,objAppointment.EndTime);

                     if (lst.Count > 0)
                     {
                         grdChkEvents.DataSource = lst;
                         grdChkEvents.DataBind();
                         
                         ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);
                         programmaticBookedVenueModalPopup.Show();
                     }
                     else
                     {
                         SaveEvent();
                     }

                     
                 }
                 else
                 {


                     this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                     this.lblStatusMessage.Text = "एपोइन्टमेन्टको समय नागीसक्यो !!! <br> त्यसैले अर्को समयमा एपोइन्टमेन्ट बनाउनुहोस्";
                     this.programmaticModalPopup.Show();
                 }

            }
            else
            {


                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "एपोइन्टमेन्टको मिति नागीसक्यो !!! <br> त्यसैले अर्को मितिमा एपोइन्टमेन्ट बनाउनुहोस्";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

   


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;
            CalculateIDs(Session["appointmentAgruments"].ToString());

            List<ATTAppointmentEvent> lstEventToRemove = new List<ATTAppointmentEvent>();

            lstEventToRemove = SearchRqdLst();


            if (lstEventToRemove.Count > 0)
            {
                foreach (ATTAppointmentEvent objEvent in lstEventToRemove)
                {
                    foreach (ATTAppointment objAppointment in objEvent.LstAppointment)
                    {
                        if (BLLAppointment.DeleteAppointmentEvents(objAppointment))
                        {
                            flag = true;
                        }
                    }

                    /* if (flag)
                     {
                         ClearEventLink(objEvent,1);
                     }*/
                }
            }

            if (flag)
            {
                ClearControls();
                Session["chkInOut"] = null;

                LoadEvents();

                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "एपोइन्टमेन्ट हटाउने कार्य सफलतापूर्वक भयो !!!";
                this.programmaticModalPopup.Show();

            }
            else
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "एपोइन्टमेन्ट हटाउने कार्यमा वाधा  उत्पन्न भयो!!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }


    private ATTGroupPersonSearch GetFilter()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtSFirstName.Text.Trim();
        SearchPerson.MiddleName = this.txtSMName.Text.Trim();
        SearchPerson.SurName = this.txtSLastName.Text.Trim();

        if (this.txtMeetingDate_rqd.Text.Trim() != "") SearchPerson.DOB = this.txtSDOB_DT.Text.Trim();
        if (this.ddlSGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlSGender.SelectedValue;
        if (this.ddlSMarStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlSMarStatus.SelectedValue;
        if (this.dllOrgSrch.SelectedIndex > 0) SearchPerson.IniType = this.dllOrgSrch.SelectedValue;
        if (this.ddlDesignation.SelectedIndex > 0) SearchPerson.PostName = this.ddlDesignation.SelectedValue;

        return SearchPerson;
    }
    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {

        ClearPersonSearchFields();
        //if(btnCreateEvent.Visible)
        //{
        //      btnUpdate.Visible = false;
        //      btnDelete.Visible = false;
        //}
        this.programmaticPersonModalPopup.Hide();
    }

    public void ClearDayEvent()
    {
        Label lbl;
        DataList dLst;

        for (int i = 1; i <= 42; i++)
        {
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onmouseover");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onmouseout");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Attributes.Remove("onclick");
            this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].Style.Add("cursor", "default");

            lbl = ((Label)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("Day" + i.ToString()));
            lbl.Text = "";

            //if (i < 4)
            //{

            dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("DataList" + i.ToString()));
            dLst.DataSource = "";
            dLst.DataBind();
            // }


        }
    }
    public void ClearPersonSearchFields()
    {
        this.txtSFirstName.Text = "";
        this.txtSMName.Text = "";
        this.txtSLastName.Text = "";
        this.ddlSGender.SelectedIndex = -1;
        this.txtSDOB_DT.Text = "";
        this.ddlSMarStatus.SelectedIndex = -1;

        this.dllOrgSrch.SelectedIndex = -1;
        this.ddlDesignation.SelectedIndex = -1;

        lblSearchStatus.Text = "";

        grdPersonSearch.DataSource = "";
        grdPersonSearch.DataBind();

    }
    public void ClearEventLink(ATTAppointmentEvent objEvent,int type)
    {
        try
        {
            DataList dLst;
            string dateString = BLLDate.GetDateString(int.Parse(lblYear.Text), int.Parse(lblMonth.Text), "_N");

            char[] token ={ '/' };

            int SDay = int.Parse(dateString.Split(token)[3]);
            string day = GetEnglisValue(hdnDay.Value.ToString());

            int i = SDay + int.Parse(day) - 1;

           

            if (type == 1)
            {
                List<ATTAppointmentEvent> lstEvent = new List<ATTAppointmentEvent>();
                lstEvent = (List<ATTAppointmentEvent>)Session["AppointmentEvents"];
                lstEvent.Remove(objEvent);
                Session["AppointmentEvents"] = lstEvent;
            }

            dLst = ((DataList)this.tblAM.Rows[this.GetRowIndex(i)].Cells[this.GetCellIndex(i) - 1].FindControl("DataList" + i.ToString()));

            if (dLst != null)
            {
                dLst.DataSource = "";
                dLst.DataBind();
            }

            

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    public void ClearControls()
    {
        try
        {
            __EventDetail.Value = "";

            Session["lstAppointee"] = null;

            grdAppointee.DataSource = null;
            grdAppointee.DataBind();

            drpStatus_rqd.SelectedIndex = -1;

            btnCreateEvent.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            string currentDate = "";

            currentDate = GetCurrentDate();
            
            string appointmentSetDate = "";
            if (this.txtMeetingDate_rqd.Text != "")
            {
                appointmentSetDate = lblYear.Text.ToString() + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day);
            }


            string time = "00:00:00";
            if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
            {
                time = drpHr1_rqd.SelectedValue.ToString()
                                    + ":" + drpMin1_rqd.SelectedValue.ToString();
            }

            if (CompareTime(time, currentDate, appointmentSetDate))
            {
                //bool flag = false;

                if (Session["RqdEvent"] != null)
                {
                    foreach (ATTAppointmentEvent objEvent in (List<ATTAppointmentEvent>)Session["RqdEvent"])
                    {
                        foreach (ATTAppointment objAppointment in objEvent.LstAppointment)
                        {
                            // string day = GetEnglisValue(hdnDay.Value.ToString());

                            objAppointment.AppointmentSubject = txtSubject_rqd.Text;


                            //if(Session["chkInOut"] == "IN")
                            objAppointment.AppointmentDate = int.Parse(lblYear.Text.ToString()) + "/" + GetFormated(lblMonth.Text.ToString()) + "/" + GetFormated(day); ;

                            if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                            {
                                objAppointment.StartTime = drpHr1_rqd.SelectedValue.ToString()
                                                     + ":" + drpMin1_rqd.SelectedValue.ToString();
                            }

                            if (this.drpHr2_rqd.SelectedIndex > 0 && this.drpMin2_rqd.SelectedIndex > 0)
                            {
                                objAppointment.EndTime = drpHr2_rqd.SelectedValue.ToString()
                                                     + ":" + drpMin2_rqd.SelectedValue.ToString();
                            }


                            objAppointment.Venue = txtVenue_rqd.Text.Trim();
                            objAppointment.Status = int.Parse(drpStatus_rqd.SelectedValue);
                            objAppointment.EntryBy = entryBy;

                            if (Session["lstAppointee"] != null)
                            {

                                foreach (ATTAppointee objAppointee in (List<ATTAppointee>)Session["lstAppointee"])
                                {
                                    objAppointee.OrgID = objAppointment.OrgID;
                                    objAppointee.AppointmentID = objAppointment.AppointmentID;


                                    if (objAppointee.AppointeeID == loginID)
                                    {
                                        if (txtComment.Text != "" && flagSet == true)
                                        {
                                            objAppointee.Flag = "1";
                                            objAppointee.Remark = txtComment.Text;

                                        }
                                        else
                                        {
                                            objAppointee.Flag = "";
                                            objAppointee.Remark = "";

                                        }

                                        objAppointee.Action = "E";
                                        objAppointee.EntryBy = objAppointment.EntryBy;
                                    }
                                }

                                objAppointment.LstAppointee = (List<ATTAppointee>)Session["lstAppointee"];

                            }
                            ObjectValidation OV = BLLAppointment.ValidateAppointmentEntry(objAppointment);

                            if (OV.IsValid == false)
                            {
                                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                                this.lblStatusMessage.Text = OV.ErrorMessage;
                                this.programmaticModalPopup.Show();
                                return;
                            }

                            ObjAppointment = objAppointment;
                            Action = "E";

                            // NB: Chk Events
                            ATTUserLogin objUserLogin = (ATTUserLogin)Session["Login_User_Detail"];
                            

                            List<ATTCheckEvents> lst = new List<ATTCheckEvents>();
                            lst = BLLCheckEvents.CheckEvents(objUserLogin, objAppointment.AppointmentDate, objAppointment.StartTime, objAppointment.EndTime);

                            lst.RemoveAll(
                                            (delegate(ATTCheckEvents obj)
                                                {
                                                    return objAppointment.OrgID == obj.OrgID && objAppointment.AppointmentID == obj.ID;
                                                }
                                             )
                                         );


                            if (lst.Count > 0)
                            {
                                grdChkEvents.DataSource = lst;
                                grdChkEvents.DataBind();



                                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideDiv", "javascript:hideDiv();", true);
                                programmaticBookedVenueModalPopup.Show();
                            }
                            else
                            {
                                UpdateEvent();
                            }
                         

                            //if (BLLAppointment.UpdateAppointmentEvents(objAppointment))
                            //{

                            //    flag = true;
                            //}
                        }

                    }

                }

                //if (flag)
                //{
                //    Session["flagSet"] = null;

                //    flagSet = false;

                //    ClearControls();

                //    LoadEvents();

                //    this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                //    this.lblStatusMessage.Text = " एपोइन्टमेन्टको परिवर्तन सफलतापूर्वक भयो !!!";
                //    this.programmaticModalPopup.Show();

                //}
                //else
                //{
                //    this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                //    this.lblStatusMessage.Text = "एपोइन्टमेन्ट परिवर्तन गर्दा वाधा उत्पन्न भयो!!!";
                //    this.programmaticModalPopup.Show();
                //}
                
            }
            else
            {


                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "एपोइन्टमेन्टको समय नागीसक्यो !!! <br> त्यसैले अर्को समयमा एपोइन्टमेन्ट बनाउनुहोस्";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnPersonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            List<ATTGroupPersonSearch> lst;

            lstPersonSearch = BLLGroupPersonSearch.GetGroupPersonWithEmployee(GetFilter(), "5, 3");
            

            lst = GetFilteredSrchLst(lstPersonSearch);

            Session["PopupPersonSearch"] = lst;

            if (lstPersonSearch.Count > 0)
            {
                this.grdPersonSearch.DataSource = lst;
                this.grdPersonSearch.DataBind();
            }
            else
            {
                this.grdPersonSearch.DataSource = "";
                this.grdPersonSearch.DataBind();
                lblSearchStatus.Text = " No Records Found !!!! ";
            }
            this.programmaticPersonModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public List<ATTGroupPersonSearch> GetFilteredSrchLst(List<ATTGroupPersonSearch> lst)
    {
        try
        {


            if (Session["lstAppointee"] != null)
            {
 
                foreach (ATTAppointee obj in (List<ATTAppointee>)Session["lstAppointee"])
                {

                    lst.Remove(
                                     lst.Find(delegate(ATTGroupPersonSearch objPSrch)
                                                  {
                                                      return (objPSrch.PersonID == obj.AppointeeID);
                                                  }

                                            )
                               );
                }
            }

            return lst;




        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearPersonSearchFields();

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox cb = new CheckBox();
            int participantID;
            string participant;
            bool flag = false;
            string alreadyCheckedList;

            List<ATTAppointee> lstAppointee = new List<ATTAppointee>();


            if (Session["lstAppointee"] != null)
            {
                lstAppointee = (List<ATTAppointee>)Session["lstAppointee"];

            }

            GetCheckedAppointeeList();


            alreadyCheckedList = ChkIfAlreadyExist();

            if (alreadyCheckedList.Length == 0)
            {
                foreach (GridViewRow gvrow in this.grdPersonSearch.Rows)
                {
                    cb = (CheckBox)(gvrow.Cells[0].FindControl("chkMember"));

                    if (cb.Checked)
                    {
                        participantID = int.Parse(gvrow.Cells[1].Text);
                        participant = gvrow.Cells[2].Text;
                        lstAppointee.Add(new ATTAppointee(participantID, participant, Session["isIndoorAppointee"].ToString(), "", "A", entryBy, DateTime.Now));

                        flag = true;

                    }
                }
            }
            else
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = alreadyCheckedList;
                this.programmaticModalPopup.Show();
            }

            if (flag)
            {
                Session["lstAppointee"] = lstAppointee;

                if (lstAppointee.Count > 0)
                {
                    grdAppointee.DataSource = lstAppointee;
                    grdAppointee.DataBind();
                }

                this.grdPersonSearch.DataSource = "";
                this.grdPersonSearch.DataBind();

                ClearPersonSearchFields();

                this.programmaticPersonModalPopup.Hide();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "Please check the  members to be added !!!!";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnAddOutdoorMembers_Click(object sender, EventArgs e)
    {
        try
        {
            string fullName = "", organisation = "";
            List<ATTAppointmentOutdoorParticipant> lst = new List<ATTAppointmentOutdoorParticipant>();
            if (Session["OutdoorParticipant"] != null)
            {
                lst = (List<ATTAppointmentOutdoorParticipant>)Session["OutdoorParticipant"];

            }

            if (txtOutDoorFullName.Text != "")
                fullName = txtOutDoorFullName.Text;

            if (txtOutDoorMemOrg.Text != "")
                organisation = txtOutDoorMemOrg.Text;


            lst.Add(new ATTAppointmentOutdoorParticipant(fullName, organisation, DateTime.Now));

            if (lst.Count > 0)
            {
                grdOutsideParticipant.DataSource = lst;
                grdOutsideParticipant.DataBind();

                Session["OutdoorParticipant"] = lst;

                txtOutDoorFullName.Text = "";
                txtOutDoorMemOrg.Text = "";
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void btnAddOutDoorMem_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTAppointee> lstAppointee = new List<ATTAppointee>();
            bool flag = false;
            string appointee;
            string outdoorOrgname = "";

            DateTime dt;

            if (Session["lstAppointee"] != null)
            {
                lstAppointee = (List<ATTAppointee>)Session["lstAppointee"];

            }

            foreach (GridViewRow gvrow in this.grdOutsideParticipant.Rows)
            {

                appointee = gvrow.Cells[1].Text;
                outdoorOrgname = gvrow.Cells[2].Text;
                dt = DateTime.Parse(gvrow.Cells[3].Text);

                lstAppointee.Add(new ATTAppointee(null, appointee, Session["isIndoorAppointee"].ToString(), outdoorOrgname, "A", entryBy, dt));

                flag = true;

            }

            if (flag)
            {
                Session["lstAppointee"] = lstAppointee;

                if (lstAppointee.Count > 0)
                {
                    grdAppointee.DataSource = lstAppointee;
                    grdAppointee.DataBind();
                }

                Session["OutdoorParticipant"] = null;

                this.grdOutsideParticipant.DataSource = "";
                this.grdOutsideParticipant.DataBind();
                this.programmaticPersonModalPopup1.Hide();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "Please check the  members to be added !!!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void btnOutdoorCancel_Click(object sender, EventArgs e)
    {
        Session["OutdoorParticipant"] = null;
        txtOutDoorFullName.Text = "";
        txtOutDoorMemOrg.Text = "";

        grdOutsideParticipant.DataSource = "";
        grdOutsideParticipant.DataBind();
    }

    protected void grdPersonSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;

        if (this.grdPersonSearch.Rows.Count > 0)
        {
            this.lblSearchStatus.Text = "Total person: " + this.grdPersonSearch.Rows.Count.ToString();
        }
        else
        {
            this.lblSearchStatus.Text = "";
        }

    } 
    protected void grdAppointee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

               

        if (row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkBtn = (LinkButton)row.Cells[10].Controls[0];
            CheckBox chkStatus = (CheckBox)row.FindControl("chkStatus");

            if (row.Cells[3].Text.Trim() == "N")
            {
                row.Cells[3].Text = "बाहिरी";

                chkStatus.Enabled = false;

                lnkBtn.Text = "";
            }
            else if (row.Cells[3].Text.Trim() == "Y")
            {
                row.Cells[3].Text = "आन्तरिक";

                if (row.Cells[1].Text != loginID.ToString())
                {
                    chkStatus.Enabled = false;
                }

                if (row.Cells[8].Text.Trim() == "1")
                {
                    chkStatus.Checked = true;

                    row.ForeColor = System.Drawing.Color.Purple;

                }
                else
                {
                    lnkBtn.Text = "";
                }

                int appointeeID = int.Parse(row.Cells[1].Text.ToString());

                if (loginID == appointeeID)
                {
                    if (chkStatus.Checked)
                    {
                        txtComment.Text = row.Cells[9].Text.Trim();
                        txtComment.Visible = true;
                        lblComment.Visible = true;
                        CollapsiblePanelExtender1.ExpandedSize = 350;

                    }
                }
            }

           

           
        }
    }
    protected void grdAppointee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = grdAppointee.Rows[e.RowIndex];
        LinkButton lnkBtn = (LinkButton)row.Cells[7].Controls[0];
        bool flag = false;
        int appointeeID = 0;
        DateTime dateTime = DateTime.Now; 

        if (row.Cells[3].Text == "आन्तरिक")
        {
            appointeeID = int.Parse(row.Cells[1].Text.ToString());
        }
        else
        {
            dateTime = DateTime.Parse(row.Cells[6].Text.ToString());
        }

        if (lnkBtn.Text == "Remove")
        {
            foreach (ATTAppointee objAppointee in (List<ATTAppointee>)Session["lstAppointee"])
            {
                if ((objAppointee.AppointeeID == appointeeID) || (objAppointee.EntryOn.ToString() == dateTime.ToString()))
                {
                    if (objAppointee.Action == "A")
                    {
                        break;
                    }
                    else
                    {
                        objAppointee.Action = "D";
                        flag = true;
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (ATTAppointee objAppointee in (List<ATTAppointee>)Session["lstAppointee"])
            {
                if ((objAppointee.AppointeeID == appointeeID) || (objAppointee.EntryOn.ToString() == dateTime.ToString()))
                {
                    objAppointee.Action = "N";
                    flag = true;
                    break;
                }
            }
        }

        if (flag)
        {
            if (lnkBtn.Text == "Remove")
            {
                lnkBtn.Text = "Undo";
                row.Cells[5].Text = "D";

                row.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lnkBtn.Text = "Remove";
                row.Cells[5].Text = "";
                row.ForeColor = System.Drawing.Color.Black;
            }
        }
        else
        {
            List<ATTAppointee> lst = new List<ATTAppointee>();

            lst = (List<ATTAppointee>)Session["lstAppointee"];

            lst.Remove(
                             lst.Find(delegate(ATTAppointee obj)
                             {
                                 return ((obj.AppointeeID == appointeeID) || (obj.EntryOn.ToString() == dateTime.ToString()));
                             })

                         );



            Session["lstAppointee"] = lst;

            grdAppointee.DataSource = lst;
            grdAppointee.DataBind();

            foreach (GridViewRow gvr in grdAppointee.Rows)
            {
                if (gvr.Cells[5].Text == "D")
                {
                    LinkButton lnkBtn1 = (LinkButton)gvr.Cells[7].Controls[0];
                    lnkBtn1.Text = "Undo";
                    gvr.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        
    }
    protected void grdAppointee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        row.Cells[1].Visible = false;
        row.Cells[5].Visible = false;
        row.Cells[6].Visible = false;
        row.Cells[8].Visible = false;
        row.Cells[9].Visible = false;

        if (Session["chkInOut"] != null && Session["chkInOut"].ToString() == "OUT")
        {
            row.Cells[7].Visible = false ;
        }
        else
        {
            row.Cells[7].Visible = true;
        }

    }
    protected void grdOutsideParticipant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((List<ATTAppointmentOutdoorParticipant>)Session["OutdoorParticipant"]).RemoveAt(grdOutsideParticipant.SelectedIndex);

        if (Session["OutdoorParticipant"] != null)
        {
            this.grdOutsideParticipant.DataSource = Session["OutdoorParticipant"];
            this.grdOutsideParticipant.DataBind();
            this.grdOutsideParticipant.SelectedIndex = -1;

        }
    }
    protected void grdOutsideParticipant_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[3].Visible = false;
    }
    protected void grdAppointee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdAppointee.SelectedRow;

        if (row != null)
        {
            txtPName.Text = row.Cells[2].Text;
            txtPType.Text = row.Cells[3].Text;
            txtPReason.Text = row.Cells[9].Text;

            this.programmaticModalComment.Show();
        }
    }

    public void GetCheckedAppointeeList()
    {
        try
        {
            ArrayList checkedAppointeeValue = new ArrayList();
            ArrayList checkedAppointeeItem = new ArrayList();
            CheckBox cb = new CheckBox();
            foreach (GridViewRow gvrow in this.grdPersonSearch.Rows)
            {
                cb = (CheckBox)(gvrow.Cells[0].FindControl("chkMember"));

                if (cb.Checked)
                {
                    string appointeeID = gvrow.Cells[1].Text;
                    checkedAppointeeValue.Add(appointeeID);
                    checkedAppointeeItem.Add(gvrow.Cells[2].Text);
                }

            }
            Session["checkedAppointeeValue"] = (object)checkedAppointeeValue;
            Session["checkedAppointeeItem"] = (object)checkedAppointeeItem;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    public string ChkIfAlreadyExist()
    {
        try
        {
            string alreadyCheckedList = "";

            if ((Session["lstAppointee"] != null))
            {
                if (Session["checkedAppointeeValue"] != null)
                {
                    ArrayList checkedOtherMemberValue = new ArrayList();
                    ArrayList checkedOtherMemberItem = new ArrayList();
                    checkedOtherMemberValue = (ArrayList)Session["checkedAppointeeValue"];
                    checkedOtherMemberItem = (ArrayList)Session["checkedAppointeeItem"];

                    foreach (ATTAppointee objAppointee in (List<ATTAppointee>)Session["lstAppointee"])
                    {
                        for (int j = 0; j < checkedOtherMemberValue.Count; j++)
                        {
                            if ((objAppointee.AppointeeID == int.Parse(checkedOtherMemberValue[j].ToString())))
                            {
                                alreadyCheckedList += "                   ->  " + checkedOtherMemberItem[j].ToString() + " <br>";

                            }
                        }
                    }
                }

                if (alreadyCheckedList.Length > 0)
                {
                    alreadyCheckedList = " Following members : <br><br> " + alreadyCheckedList;
                    alreadyCheckedList += " <br> already added. ";
                }



            }

            Session["checkedAppointeeValue"] = null;
            Session["checkedAppointeeItem"] = null;

            return alreadyCheckedList;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return "";
        }
    }
          
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        txtOutDoorFullName.Text = "";
        txtOutDoorMemOrg.Text = "";

        Session["OutdoorParticipant"] = "";

        grdOutsideParticipant.DataSource = "";
        grdOutsideParticipant.DataBind();

        programmaticPersonModalPopup1.Hide();

    }
    protected void chkStatus_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;

        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        CheckBox chkStatus = (CheckBox)row.FindControl("chkStatus");


        if (row.Cells[1].Text == loginID.ToString())
        {
            
            if (chkStatus.Checked)
            {
                lblComment.Visible = true;
                txtComment.Visible = true;

                CollapsiblePanelExtender1.ExpandedSize = 350;
          
                row.Cells[8].Text = "1";

                Session["flagSet"] = "1";
            }
            else
            {
                lblComment.Visible = false;
                txtComment.Visible = false;

                CollapsiblePanelExtender1.ExpandedSize = 320;

                row.Cells[8].Text = "0";
                row.Cells[9].Text = "";
                txtComment.Text = "";

                LinkButton lnkBtn = (LinkButton)row.Cells[10].Controls[0];
                lnkBtn.Text = "";

                row.ForeColor = System.Drawing.Color.Black;

                Session["flagSet"] = "0";

            }
        }
       
          
    }
   
    protected void imgComment_Click(object sender, ImageClickEventArgs e)
    {
        txtPName.Text = "";
        txtPType.Text = "";
        txtPReason.Text = "";

        grdAppointee.SelectedIndex = -1;

        programmaticModalComment.Hide();
    }

    public string GetCurrentDate()
    {
        try
        {
            string day = GetEnglisValue(hdnDay.Value.ToString());
            int len = Session["CurrentDate1"].ToString().Length;
            string currentDate = Session["CurrentDate1"].ToString().Substring(0, len - 5);

            return currentDate;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void SaveEvent()
    {
        try
        {
            bool flag = false;

            string day = GetEnglisValue(hdnDay.Value.ToString());

            string eventIDs = "";

            ATTAppointment objAppointment = ObjAppointment;

            eventIDs = BLLAppointment.SaveAppointmentEvents(objAppointment);

            if (eventIDs != "")
            {
                //ATTAppointmentEvent objEvent = new ATTAppointmentEvent();
                //string[] IDs = eventIDs.Split(new char[] { '/' });

                //objEvent.Day = int.Parse(day);
                //objEvent.OrgID = userOrgID;
                //objEvent.EventID = int.Parse(IDs[0]);

                //if (Session["MeetingStatus"] != null)
                //{

                //    List<ATTMeetingStatus> lstStatus = (List<ATTMeetingStatus>)Session["MeetingStatus"];

                //    ATTMeetingStatus objMS = lstStatus.Find(delegate(ATTMeetingStatus obj)
                //                                                          {
                //                                                              return (obj.MeetingStatusID == int.Parse(drpStatus_rqd.SelectedValue));
                //                                                          }

                //                                                   );

                //    if (objMS != null)
                //    {
                //        objEvent.StatusColor = objMS.MeetingStatusColor;
                //    }
                //}


                //if (txtSubject_rqd.Text.Length > 15)
                //    objEvent.Event = txtSubject_rqd.Text.Substring(0, 15) + ".....";
                //else
                //    objEvent.Event = txtSubject_rqd.Text;

                flag = true;

            }

            if (flag)
            {
                ClearControls();

                LoadEvents();

                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "नयाँ एपोइन्टमेन्ट सफलतापूर्वक बन्यो !!!";
                this.programmaticModalPopup.Show();
            }
            else 
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "नयाँ एपोइन्टमेन्ट बनाउँदा वाधा उत्पन्न भयो!!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void UpdateEvent()
    {
        try
        {
            bool flag = false;
            ATTAppointment objAppointment = ObjAppointment;

            if (BLLAppointment.UpdateAppointmentEvents(objAppointment))
            {    flag = true;
            }

            if (flag)
            {
                Session["flagSet"] = null;

                flagSet = false;

                ClearControls();

                LoadEvents();

                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = " एपोइन्टमेन्टको परिवर्तन सफलतापूर्वक भयो !!!";
                this.programmaticModalPopup.Show();

            }
            else
            {
                this.lblStatusMessageTitle.Text = "एपोइन्टमेन्ट";
                this.lblStatusMessage.Text = "एपोइन्टमेन्ट परिवर्तन गर्दा वाधा उत्पन्न भयो!!!";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnChkEOk_Click(object sender, EventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();

        if (Action == "A")
            SaveEvent();
        else
            UpdateEvent();
    }
    protected void btnChkECancel_Click(object sender, EventArgs e)
    {
        try
        {
            programmaticBookedVenueModalPopup.Hide();

            ClearControls();
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void grdChkEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (gvRow.Cells[2].Text == "M")
            {
                gvRow.Cells[2].Text = "मिटिङ्ग";
            }
            else
            {
                gvRow.Cells[2].Text = "एपोइन्टमेन्ट";
            }
        }
    }
    protected void btnChkUpdate_Click(object sender, EventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "callDiv", "javascript:callDiv();", true);
                            

       // this.programmaticModalPopup.Show();
    }
}

