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

public partial class MODULES_OAS_Forms_MeetingVenueManagement : System.Web.UI.Page
{
    public string entryBy = "";
    public ATTUserLogin user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        user = ((ATTUserLogin)Session["Login_User_Detail"]);
        entryBy = user.UserName;
        //userID = int.Parse(user.PID.ToString());

        if (!IsPostBack)
        {
            Session["NowDate"] = null;
            LoadControls();
        }
    }


    public void LoadControls()
    {
        try
        {
            this.LoadOrganisation();
            this.LoadPerson();
            this.LoadVenue();
            this.LoadResources();

            string dateString = BLLDate.GetDateString(0, 0, "_N");

            if (Session["NowDate"] == null)
                Session["NowDate"] = dateString;

            SetFilteredVenue();
            SetFilteredPerson();
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["BookingOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["BookingOrgList"] != null)
            {
                this.ddlOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["BookingOrgList"];
                this.ddlOrganisation_rqd.DataTextField = "OrgName";
                this.ddlOrganisation_rqd.DataValueField = "OrgId";
                this.ddlOrganisation_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                ddlOrganisation_rqd.Items.Insert(0, a);


                this.ddlOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["BookingOrgList"];
                this.ddlOrganisation_rqd.DataTextField = "OrgName";
                this.ddlOrganisation_rqd.DataValueField = "OrgId";
                this.ddlOrganisation_rqd.DataBind();

                ddlOrganisation_rqd.Items.Insert(0, a);

            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void LoadPerson()
    {
        try
        {
            Session["BookingPersonList"] = BLLEmployeePosting.GetEmployeeWithPostingList(null);
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void LoadVenue()
    {
        try
        {
            Session["BookingVenueList"] = BLLMeetingVenue.GetMeetingVenueList(null);
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadResources()
    {
        try
        {
            Session["BookingResourcesList"] = BLLMeetingResources.GetResourcesList(null);

            if (((List<ATTMeetingResources>)Session["BookingResourcesList"]).Count > 0)
            {

                this.grdResources.DataSource = (List<ATTMeetingResources>)Session["BookingResourcesList"];
                this.grdResources.DataBind();
            }
            else
            {
                this.lblStatusMessageTitle.Text = "Error Status";
                this.lblStatusMessage.Text = "Resources Couldn't be loaded";
                this.programmaticModalPopup.Show();
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void ddlOrganisation_rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlOrganisation_rqd.SelectedIndex > 0)
            {
                this.ddlVenue_rqd.Items.Clear();

                SetFilteredVenue();
                SetFilteredPerson();
                
            }
            else
            {
                ddlVenue_rqd.Enabled = false;
                ddlVenue_rqd.SelectedIndex = -1;

                ddlBookingPerson_rqd.Enabled = false;
                ddlBookingPerson_rqd.SelectedIndex = -1;
                
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void SetFilteredVenue()
    {
        try
        {

            if (ddlOrganisation_rqd.SelectedIndex > 0)
            {
                if (Session["BookingVenueList"] != null)
                {
                    List<ATTMeetingVenue> lstVenue = (List<ATTMeetingVenue>)Session["BookingVenueList"];

                    if (lstVenue.Count > 0)
                    {
                        ATTMeetingVenue objVenue = new ATTMeetingVenue();
                        objVenue.LstVenue = lstVenue.FindAll(delegate(ATTMeetingVenue objMeetingVenue)
                                                                {
                                                                    return (objMeetingVenue.OrgID == int.Parse(ddlOrganisation_rqd.SelectedValue)
                                                                            || (objMeetingVenue.OrgID == -1));
                                                                }

                                                             );


                        this.ddlVenue_rqd.DataSource = objVenue.LstVenue;
                        this.ddlVenue_rqd.DataTextField = "VenueName";
                        this.ddlVenue_rqd.DataValueField = "VenueID";
                        this.ddlVenue_rqd.DataBind();

                        ddlVenue_rqd.Enabled = true;
                    }
                    else
                    {
                        this.lblStatusMessageTitle.Text = "Error Status";
                        this.lblStatusMessage.Text = "Venue Couldn't be loaded";
                        this.programmaticModalPopup.Show();
                    }


                }
            }
            else
            {
                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = " छान्नुहोस्";
                a.Value = "0";
                ddlVenue_rqd.Items.Insert(0, a);

            }


        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void SetFilteredPerson()
    {
        try
        {
            if (ddlOrganisation_rqd.SelectedIndex > 0)
            {

                List<ATTEmployeePosting> lstPerson = (List<ATTEmployeePosting>)Session["BookingPersonList"];

                List<ATTEmployeePosting> lst = lstPerson.FindAll(delegate(ATTEmployeePosting obj)
                                                        {
                                                            return (obj.OrgID == int.Parse(ddlOrganisation_rqd.SelectedValue));
                                                        }

                                                     );

                this.ddlBookingPerson_rqd.DataSource = lst;
                this.ddlBookingPerson_rqd.DataTextField = "EmpName";
                this.ddlBookingPerson_rqd.DataValueField = "EmpID";
                this.ddlBookingPerson_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = " छान्नुहोस्";
                a.Value = "0";
                ddlBookingPerson_rqd.Items.Insert(0, a);

                this.ddlBookingPerson_rqd.Enabled = true;
            }
            else
            {
                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = " छान्नुहोस्";
                a.Value = "0";
                ddlBookingPerson_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void grdResources_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int len = Session["NowDate"].ToString().Length;
            string nowDate = Session["NowDate"].ToString().Substring(0, len - 5);

            string bookingDate = "";
            if (this.txtBookingDate_RDT.Text.Trim() != "")
            {
                bookingDate = txtBookingDate_RDT.Text.Trim();

                //if (Convert.ToDateTime(nowDate) <= Convert.ToDateTime(bookingDate))
                //{

                if(CompareDate(nowDate,bookingDate))
                {
                    string time = "00:00:00";
                   
                     if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                     {
                         time = drpHr1_rqd.SelectedValue.ToString()
                                              + ":" + drpMin1_rqd.SelectedValue.ToString();

                     }

                     if (CompareTime(time, nowDate, bookingDate))
                     {
                         ATTMeetingVenueBooking objVenueBooked = new ATTMeetingVenueBooking();
                         objVenueBooked.OrgID = int.Parse(ddlOrganisation_rqd.SelectedValue);
                         objVenueBooked.VenueID = int.Parse(ddlVenue_rqd.SelectedValue);
                         objVenueBooked.VenueName = ddlVenue_rqd.SelectedItem.ToString();
                         objVenueBooked.BookedBy = int.Parse(ddlBookingPerson_rqd.SelectedValue);
                         objVenueBooked.BookedByName = ddlBookingPerson_rqd.SelectedItem.ToString();
                         objVenueBooked.Purpose = txtBookingPurpose.Text.Trim();

                         if (this.drpHr1_rqd.SelectedIndex > 0 && this.drpMin1_rqd.SelectedIndex > 0)
                         {
                             objVenueBooked.StartTime = drpHr1_rqd.SelectedValue.ToString()
                                                  + ":" + drpMin1_rqd.SelectedValue.ToString();

                         }

                         if (this.drpHr2_rqd.SelectedIndex > 0 && this.drpMin2_rqd.SelectedIndex > 0)
                         {
                             objVenueBooked.EndTime = drpHr2_rqd.SelectedValue.ToString()
                                                     + ":" + drpMin2_rqd.SelectedValue.ToString();

                         }

                         objVenueBooked.BookingDate = txtBookingDate_RDT.Text.Trim();
                         objVenueBooked.EntryBy = entryBy;

                         objVenueBooked.LstBookedResources = GetBookedResources();

                         int bookingID = 0;
                         bookingID = BLLMeetingVenueBooking.SaveMeetingVenueBooking(objVenueBooked);

                         if (bookingID != 0)
                         {
                             ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
                             LoadResources();

                             this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                             this.lblStatusMessage.Text = "नयाँ स्थल सफलतापूर्वक बुकिङ्ग भयो!!! "
                                                        + "<br>  तपाईको बुकिङ्ग नं  <b><font color = 'black'>" + bookingID + " </font></b> हो ।"
                                                        + "<br>  समय : <b><font color = 'black'>(" + objVenueBooked.StartTime + "-" + objVenueBooked.EndTime + ")</font></b>"
                                                        + "<br>  मिति : <b><font color = 'black'>" + objVenueBooked.BookingDate + "</font></b>"
                                                        + "<br>  स्थल : <b><font color = 'black'>" + objVenueBooked.VenueName + "</font></b>"
                                                        + "<br>  बुकिङ्ग गर्नेको नाम :<b><font color = 'black'>" + objVenueBooked.BookedByName + "</font></b>";
                             this.programmaticModalPopup.Show();
                         }
                         else
                         {
                             List<ATTMeetingVenueAlreadyBookedDetails> lst = new List<ATTMeetingVenueAlreadyBookedDetails>();
                             
                             lst = BLLMeetingVenueAlreadyBookedDetails.GetVenueAlreadyBookedDetails(objVenueBooked);

                             grdBooked.DataSource = lst;
                             grdBooked.DataBind();


                             programmaticBookedVenueModalPopup.Show();
                         }
                     }
                     else
                     {   this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                         this.lblStatusMessage.Text = "स्थल व्यवस्थापनको शुरु समय नागीसक्यो !!! <br> त्यसैले अर्को शुरु समयमा स्थल व्यवस्थापन गर्नुहोस्";
                         this.programmaticModalPopup.Show();
                     }


               }
               else
               {
                    this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                    this.lblStatusMessage.Text = " मिति नागीसक्यो !!! <br> त्यसैले अर्को मितिमा राख्नुहोस्";
                    this.programmaticModalPopup.Show();
                }
            }
            else
            {


                this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                this.lblStatusMessage.Text = " बुकिङ्ग मिति राख्न अनिवार्य छ । ";
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

    public List<ATTMeetingVenueResources> GetBookedResources()
    {
        try
        {
            List<ATTMeetingVenueResources> lst = new List<ATTMeetingVenueResources>();
            CheckBox cb = new CheckBox();
            DropDownList dd = new DropDownList();
            foreach (GridViewRow gvrow in this.grdResources.Rows)
            {
                ATTMeetingVenueResources objVenueResources = new ATTMeetingVenueResources();
                cb = (CheckBox)(gvrow.Cells[0].FindControl("chkResource"));
                dd = (DropDownList)(gvrow.Cells[3].FindControl("ddlQuantity"));

                if (cb.Checked)
                {
                    objVenueResources.ResourceID = int.Parse(gvrow.Cells[1].Text);
                    objVenueResources.ResourceQty = int.Parse(dd.SelectedValue);

                    lst.Add(objVenueResources);
                }


            }

            return lst;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);
    }

    public bool CompareDate(string date1, string date2)
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
                    else if (day2 < day1)
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

            throw (ex);
        }
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

            throw (ex);
        }


    }

    protected void imbBtnClose2_Click(object sender, ImageClickEventArgs e)
    {
        programmaticBookedVenueModalPopup.Hide();
    }
}
