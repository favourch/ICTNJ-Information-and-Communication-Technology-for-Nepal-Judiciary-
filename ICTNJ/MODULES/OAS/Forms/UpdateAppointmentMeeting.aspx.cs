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

public partial class MODULES_OAS_Forms_UpdateAppointMeeting : System.Web.UI.Page
{
    public int orgID, unitID, meetingID;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadControls();

            if (Session["meetingAgruments"] != null)
            {

                if (CalculateIDs())
                {
                    if (Session["MeetingEvents"] != null)
                    {
                        List<ATTEvent> lstRqdEvent = new List<ATTEvent>();

                        lstRqdEvent = SearchRqdLst(orgID, unitID, meetingID);

                        if (lstRqdEvent.Count > 0)
                        {
                            LoadEventDatas(lstRqdEvent);

                        }
                    }

                   
                }
            }
        }
    }

    public bool CalculateIDs()
    {
        try
        {
            string arguments = Session["meetingAgruments"].ToString();
            string[] IDs = arguments.Split(new char[] { '/' });

            orgID = Convert.ToInt32(IDs[0]);
            unitID = Convert.ToInt32(IDs[1]);
            meetingID = Convert.ToInt32(IDs[2]);
            
            Session["meetingAgruments"] = null;

            return true;
        }
        catch (Exception ex)
        {
            throw(ex);
        }

    }
    public List<ATTEvent> SearchRqdLst(int orgID, int unitID, int meetingID)
    {
        try
        {
            List<ATTEvent> lstEvent = new List<ATTEvent>();
            List<ATTEvent> lst = new List<ATTEvent>();
            ATTEvent objRqdEvent = new ATTEvent();
           
            lstEvent = (List<ATTEvent>)Session["MeetingEvents"];


            lst =    lstEvent.FindAll(
                                                delegate(ATTEvent objEvent)
                                                {
                                                    return ((objEvent.OrgID == orgID) && (objEvent.UnitID == unitID) && (objEvent.EventID == meetingID));
                                                }

                                        );
            return lst;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    public void LoadEventDatas(List<ATTEvent> lstRqdEvent)
    {
        try
        {
            foreach (ATTEvent objEvent in lstRqdEvent)
            {
                foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                {
                    drpOrganisation_rqd.SelectedValue = objMeeting.OrgID.ToString();
                    drpUnit_rqd.SelectedValue = objMeeting.UnitID.ToString();
                    drpVenue_rqd.SelectedValue = objMeeting.VenueID.ToString();
                    drpCalledBy_rqd.SelectedValue = objMeeting.CalledBy.ToString();
                    drpMeetingType_rqd.SelectedValue = objMeeting.MeetingTypeID.ToString();

                    txtSubject_rqd.Text = objMeeting.Subject;

                    string startTime = objMeeting.StartTime;
                    string hr1 = startTime.Substring(0, startTime.Length - 6).ToString();
                    string min1 = startTime.Substring(3, startTime.Length - 6).ToString();
                    string amPm1 = startTime.Substring(5, startTime.Length - 5).ToString();

                    drpHr1_rqd.SelectedValue = hr1;
                    drpMin1_rqd.SelectedValue = min1;

                    if (amPm1.Trim() == "AM")
                    {
                        drpAmPm1.SelectedValue = "0";
                    }
                    else
                    {

                        drpAmPm1.SelectedValue = "1";
                    }

                    string endTime = objMeeting.EndTime;
                    string hr2 = endTime.Substring(0, endTime.Length - 6).ToString();
                    string min2 = endTime.Substring(3, endTime.Length - 6).ToString();
                    string amPm2 = endTime.Substring(5, endTime.Length - 5).ToString();

                    drpHr2_rqd.SelectedValue = hr2;
                    drpMin2_rqd.SelectedValue = min2;

                    if (amPm2.Trim() == "AM")
                    {
                        drpAmPm2.SelectedValue = "0";
                    }
                    else
                    {

                        drpAmPm2.SelectedValue = "1";
                    }

                    txtMeetingDate_rqd.Text = objMeeting.MeetingDate.ToString().Replace("/","÷");

                    if (objMeeting.LstMeetingAgenda.Count > 0)
                    {
                        grdAgenda.DataSource = objMeeting.LstMeetingAgenda;
                        grdAgenda.DataBind();
                    }

                    if (objMeeting.LstMeetingParticipant.Count > 0)
                    {
                        grdParticipant.DataSource = objMeeting.LstMeetingParticipant;
                        grdParticipant.DataBind();
                    }
                }
              
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("Appointment_Meeting.aspx");
    }
    protected void drpOrgansiation_rqd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void LoadControls()
    {
        try
        {
            this.LoadOrganisation();
            LoadUnit();
            this.LoadVenue();
            this.LoadMeetingType();
            this.LoadPerson();
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            if (Session["meetingOrgList"] != null)
            {
                this.drpOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["meetingOrgList"];
                this.drpOrganisation_rqd.DataTextField = "OrgName";
                this.drpOrganisation_rqd.DataValueField = "OrgId";
                this.drpOrganisation_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "संस्था छान्नुहोस्";
                a.Value = "0";
                drpOrganisation_rqd.Items.Insert(0, a);

            }
       
        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }

    public void LoadUnit()
    {
        try
        {
            if (Session["meetingUnitList"] != null)
            {
                this.drpUnit_rqd.DataSource = (List<ATTOrganizationUnit>)Session["meetingUnitList"];
                this.drpUnit_rqd.DataTextField = "UnitName";
                this.drpUnit_rqd.DataValueField = "UnitID";
                this.drpUnit_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "शाखा छान्नुहोस्";
                a.Value = "0";
                drpUnit_rqd.Items.Insert(0, a);

                drpUnit_rqd.Enabled = true;

            }
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
            if (Session["MeetingVenueList"] != null)
            {
                this.drpVenue_rqd.DataSource = (List<ATTMeetingVenue>)Session["MeetingVenueList"];
                this.drpVenue_rqd.DataTextField = "VenueName";
                this.drpVenue_rqd.DataValueField = "VenueID";
                this.drpVenue_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "स्थल छान्नुहोस्";
                a.Value = "0";
                drpVenue_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void LoadMeetingType()
    {
        try
        {
            if (Session["MeetingMeetingTypeList"] != null)
            {
                this.drpMeetingType_rqd.DataSource = (List<ATTMeetingType>)Session["MeetingMeetingTypeList"];
                this.drpMeetingType_rqd.DataTextField = "MeetingTypeName";
                this.drpMeetingType_rqd.DataValueField = "MeetingTypeID";
                this.drpMeetingType_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "मिटिङ्गको प्रकार छान्नुहोस्";
                a.Value = "0";
                drpMeetingType_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public void LoadPerson()
    {
        try
        {
            if (Session["MeetingPersonList"] != null)
            {
                this.drpCalledBy_rqd.DataSource = (List<ATTPerson>)Session["MeetingPersonList"];
                this.drpCalledBy_rqd.DataTextField = "FullName";
                this.drpCalledBy_rqd.DataValueField = "PId";
                this.drpCalledBy_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "Select Person";
                a.Value = "0";
                drpCalledBy_rqd.Items.Insert(0, a);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

}
