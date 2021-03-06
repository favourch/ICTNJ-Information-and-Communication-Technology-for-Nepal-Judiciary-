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

public partial class MODULES_OAS_Forms_MeetingVenueBookingSearch : System.Web.UI.Page
{
    public int orgId, venueID, bookingId;
    public string entryBy = "";
    public ATTUserLogin user;

    public ATTMeetingVenueBooking VenueSrchCritera
    {
        get
        {
            return (Session["VenueSrchCritera"] == null) ? new ATTMeetingVenueBooking() : (ATTMeetingVenueBooking)Session["VenueSrchCritera"];
        }
        set { Session["VenueSrchCritera"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        user = ((ATTUserLogin)Session["Login_User_Detail"]);
        entryBy = user.UserName;

        if (!IsPostBack)
        {
            LoadControls();
            

        }
    }
   
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlOrganization.SelectedIndex > 0)
            {
                GetFilteredVenue();
                GetFilteredPerson();
                
                //ddlVenue.Enabled = true;
            }
            else
            {
                ddlPerson.SelectedIndex = -1;
                ddlVenue.SelectedIndex = -1;
                ddlPerson.Enabled = false;
                ddlVenue.Enabled = false;
                //drp_MeetingCallerType_rqd.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ATTMeetingVenueBooking obj = new ATTMeetingVenueBooking();
            if(ddlOrganization.SelectedIndex > 0)
                obj.OrgID = int.Parse(ddlOrganization.SelectedValue.ToString());
            
            if(ddlVenue.SelectedIndex > 0)
                obj.VenueID = int.Parse(ddlVenue.SelectedValue.ToString());
            
            if(ddlPerson.SelectedIndex > 0)
                obj.BookedBy = int.Parse(ddlPerson.SelectedValue.ToString());
            
            if(txtBookingDate.Text != "")
                obj.BookingDate = txtBookingDate.Text;
            
            if(txtBookingID.Text != "")
                obj.BookingID = int.Parse(txtBookingID.Text);

            VenueSrchCritera = obj;

            LoadBookedVenue();

            

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void LoadBookedVenue()
    {
        try
        {
            List<ATTMeetingVenueBooking> lst = new List<ATTMeetingVenueBooking>();
            lst = BLLMeetingVenueBooking.GetBookedVenueDetails(VenueSrchCritera);

            if (lst.Count > 0)
            {
                grdBookedVenue.DataSource = lst;
                grdBookedVenue.DataBind();
                grdBookedVenue.SelectedIndex = -1;


                Session["BookedVenueSearchList"] = lst;
            }
            else
            {
                grdBookedVenue.DataSource = "";
                grdBookedVenue.DataBind();

                this.lblSearchCount.Text = "Total Records Found : 0" ;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void grdBookedVenue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;

        if (this.grdBookedVenue.Rows.Count > 0)
        {
            this.lblSearchCount.Text = "Total Records Found : " + this.grdBookedVenue.Rows.Count.ToString();
        }
        else
        {
            this.lblSearchCount.Text = "";
        }
    }

    public void LoadControls()
    {
        try
        {
            LoadOrganisation();
            LoadVenue();
            LoadPerson();

            string dateString = BLLDate.GetDateString(0, 0, "_N");

            if (Session["UpNowDate"] == null)
                Session["UpdNowDate"] = dateString;

        }
        catch (Exception ex)
        {
            
           
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["venueBookedOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["venueBookedOrgList"] != null)
            {
                this.ddlOrganization.DataSource = (List<ATTOrganization>)Session["venueBookedOrgList"];
                this.ddlOrganization.DataTextField = "OrgName";
                this.ddlOrganization.DataValueField = "OrgId";
                this.ddlOrganization.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                ddlOrganization.Items.Insert(0, a);



                this.ddlUpdOrganization_rqd.DataSource = (List<ATTOrganization>)Session["venueBookedOrgList"];
                this.ddlUpdOrganization_rqd.DataTextField = "OrgName";
                this.ddlUpdOrganization_rqd.DataValueField = "OrgId";
                this.ddlUpdOrganization_rqd.DataBind();

                ddlUpdOrganization_rqd.Items.Insert(0, a);


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
            Session["venueBookedVenueList"] = BLLMeetingVenue.GetMeetingVenueList(null);

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
            Session["venueBookedPersonList"] = BLLEmployeePosting.GetEmployeeWithPostingList(null);

           
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

   

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();

    }

    public void GetFilteredVenue()
    {
        try
        {

            if (Session["venueBookedVenueList"] != null)
            {
                List<ATTMeetingVenue> lstVenue = (List<ATTMeetingVenue>)Session["venueBookedVenueList"];
                ATTMeetingVenue objVenue = new ATTMeetingVenue();
                objVenue.LstVenue = lstVenue.FindAll(delegate(ATTMeetingVenue obj)
                                                        {
                                                            return (obj.OrgID == int.Parse(ddlOrganization.SelectedValue)||(obj.OrgID == -1));
                                                        }

                                                     );


                this.ddlVenue.DataSource = objVenue.LstVenue;
                this.ddlVenue.DataTextField = "VenueName";
                this.ddlVenue.DataValueField = "VenueID";
                this.ddlVenue.DataBind();

                ddlVenue.Enabled = true;

            }


        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void GetFilteredPerson()
    {
        try
        {
            if (Session["venueBookedPersonList"] != null)
            {
                List<ATTEmployeePosting> lstEmp = (List<ATTEmployeePosting>)Session["venueBookedPersonList"];
                List<ATTEmployeePosting> lst = new List<ATTEmployeePosting>();
                lst = lstEmp.FindAll(delegate(ATTEmployeePosting obj)
                                                        {
                                                            return (obj.OrgID == int.Parse(ddlOrganization.SelectedValue) || (obj.OrgID == -1));
                                                        }

                                                     );


                this.ddlPerson.DataSource = lst;
                this.ddlPerson.DataTextField = "EmpName";
                this.ddlPerson.DataValueField = "EmpID";
                this.ddlPerson.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = " छान्नुहोस्";
                a.Value = "0";
                ddlPerson.Items.Insert(0, a);

                ddlPerson.Enabled = true;

            }

        }

        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
    }

    public void ClearPersonSearchFields()
    {
        ddlOrganization.SelectedIndex = -1;
        ddlPerson.SelectedIndex = -1;
        ddlVenue.SelectedIndex = -1;
        txtBookingDate.Text = "";
        txtBookingID.Text = "";

        ddlPerson.Enabled = false;
        ddlVenue.Enabled = false;

        grdBookedVenue.DataSource = "";
        grdBookedVenue.DataBind();

        grdBookedVenue.SelectedIndex = -1;

        lblSearchCount.Text = "";
    }

    protected void grdBookedVenue_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = grdBookedVenue.Rows[e.NewSelectedIndex];

        orgId = int.Parse(row.Cells[1].Text);
        venueID = int.Parse(row.Cells[2].Text);
        bookingId = int.Parse(row.Cells[7].Text);

        LoadResources();
        this.ShowBookedVenueDetails();

    }

    public void ShowBookedVenueDetails()
    {
        try
        {
            List<ATTMeetingVenueBooking> lst = (List<ATTMeetingVenueBooking>)Session["BookedVenueSearchList"];

            ATTMeetingVenueBooking objRqd = lst.Find(delegate(ATTMeetingVenueBooking obj)
                                                                             {
                                                                                 return ((obj.OrgID == orgId) && (obj.VenueID == venueID) && (obj.BookingID == bookingId));
                                                                             }

                                                                      );

            ddlUpdOrganization_rqd.SelectedValue = objRqd.OrgID.ToString();

            LoadUpdateControls(int.Parse(objRqd.OrgID.ToString()));
            
            txtUpdBookingDate_RDT.Text = objRqd.BookingDate.ToString();
            txtUpdBookingNo_rqd.Text = objRqd.BookingID.ToString();
            ddlUpdPerson_rqd.SelectedValue = objRqd.BookedBy.ToString();
            ddlUpdVenue_rqd.SelectedValue = objRqd.VenueID.ToString();

            string startTime = objRqd.StartTime;

            string hr1, min1;


            hr1 = startTime.Substring(0, startTime.Length - 3).ToString();


            if (startTime.Length == 4)
            {
                min1 = startTime.Substring(2, startTime.Length - 2).ToString();
            }
            else
                min1 = startTime.Substring(3, startTime.Length - 3).ToString();

            ddlHr1_rqd.SelectedValue = hr1;
            ddlMin1_rqd.SelectedValue = min1;



            string endTime = objRqd.EndTime;

            string hr2, min2;

            hr2 = endTime.Substring(0, endTime.Length - 3).ToString();

            if (endTime.Length == 4)
            {
                min2 = endTime.Substring(2, endTime.Length - 2).ToString();
            }
            else
                min2 = endTime.Substring(3, endTime.Length - 3).ToString();

            ddlHr2_rqd.SelectedValue = hr2;
            ddlMin2_rqd.SelectedValue = min2;

            txtUpdPurpose.Text = objRqd.Purpose;

            CheckResources(objRqd.LstBookedResources);
            Session["objRqdDetail"] = objRqd;
           

            this.programmaticBookedVenueModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadUpdateControls(int updOrgID)
    {
        try
        {

            if (Session["venueBookedVenueList"] != null)
            {
                List<ATTMeetingVenue> lstVenue = (List<ATTMeetingVenue>)Session["venueBookedVenueList"];
                ATTMeetingVenue objVenue = new ATTMeetingVenue();
                objVenue.LstVenue = lstVenue.FindAll(delegate(ATTMeetingVenue obj)
                                                        {
                                                            return (obj.OrgID == updOrgID || (obj.OrgID == -1));
                                                        }

                                                     );


                this.ddlUpdVenue_rqd.DataSource = objVenue.LstVenue; ;
                this.ddlUpdVenue_rqd.DataTextField = "VenueName";
                this.ddlUpdVenue_rqd.DataValueField = "VenueID";
                this.ddlUpdVenue_rqd.DataBind();
            }

            if (Session["venueBookedPersonList"] != null)
            {
                List<ATTEmployeePosting> lstEmp = (List<ATTEmployeePosting>)Session["venueBookedPersonList"];
                List<ATTEmployeePosting> lst = new List<ATTEmployeePosting>();
                lst = lstEmp.FindAll(delegate(ATTEmployeePosting obj)
                                                        {
                                                            return (obj.OrgID == updOrgID);
                                                        }

                                                     );


                this.ddlUpdPerson_rqd.DataSource = lst;
                this.ddlUpdPerson_rqd.DataTextField = "EmpName";
                this.ddlUpdPerson_rqd.DataValueField = "EmpID";
                this.ddlUpdPerson_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = " छान्नुहोस्";
                a.Value = "0";
                ddlUpdPerson_rqd.Items.Insert(0, a);
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void CheckResources(List<ATTMeetingVenueResources> lstRes)
    {
        try
        {
            
            CheckBox chkResource;
            DropDownList ddlQuantity;

            if (grdResources.Rows.Count > 0)
            {
                foreach (ATTMeetingVenueResources objRes in lstRes)
                {

                    foreach (GridViewRow gvr in grdResources.Rows)
                    {
                        int ResourceID = int.Parse(gvr.Cells[1].Text);

                        if (objRes.ResourceID == ResourceID)
                        {
                            chkResource = (CheckBox)gvr.FindControl("chkResource");
                            ddlQuantity = (DropDownList)gvr.FindControl("ddlQuantity");

                            chkResource.Checked = true;
                            ddlQuantity.SelectedValue = objRes.ResourceQty.ToString();
                            gvr.Cells[4].Text = objRes.Action;
                            break;
                        }
                    }
                }

                Session["ResToUpdate"] = lstRes;
            }

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void imbBtnClose2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            grdBookedVenue.SelectedIndex = -1;
            this.programmaticBookedVenueModalPopup.Hide();

            ClearUpdControls();
            LoadBookedVenue();
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdResources_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[4].Visible = false;
    }

    public void LoadResources()
    {
        try
        {
            Session["BookingResourcesList"] = BLLMeetingResources.GetResourcesList(null);

            this.grdResources.DataSource = (List<ATTMeetingResources>)Session["BookingResourcesList"];
            this.grdResources.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int ID = int.Parse(txtUpdBookingNo_rqd.Text.Trim());

            int count = BLLMeetingVenueBooking.CheckBookingIDInUse(ID);
            if (count > 0)
            {
                this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                this.lblStatusMessage.Text = "यो बुकिङ्ग नम्बर प्रयोगमा छ,त्यसैले अहिले परिवर्तन गर्न मिल्दैन।";
                this.programmaticModalPopup.Show();
            }
            else
            {
                int len = Session["UpdNowDate"].ToString().Length;
                string nowDate = Session["UpdNowDate"].ToString().Substring(0, len - 5);

                string bookingDate = "";
                if (this.txtUpdBookingDate_RDT.Text.Trim() != "")
                {
                    bookingDate = txtUpdBookingDate_RDT.Text.Trim();

                    if (CompareDate(nowDate, bookingDate))
                    {
                        string time = "00:00:00";

                        if (this.ddlHr1_rqd.SelectedIndex > 0 && this.ddlMin1_rqd.SelectedIndex > 0)
                        {
                            time = ddlHr1_rqd.SelectedValue.ToString()
                                                 + ":" + ddlMin1_rqd.SelectedValue.ToString();

                        }
                        if (CompareTime(time, nowDate, bookingDate))
                        {


                            ATTMeetingVenueBooking objRqdUpd = (ATTMeetingVenueBooking)Session["objRqdDetail"];

                            objRqdUpd.OrgID = int.Parse(ddlUpdOrganization_rqd.SelectedValue);
                            objRqdUpd.VenueID = int.Parse(ddlUpdVenue_rqd.SelectedValue);
                            objRqdUpd.BookedBy = int.Parse(ddlUpdPerson_rqd.SelectedValue);

                            if (this.ddlHr1_rqd.SelectedIndex > 0 && this.ddlMin1_rqd.SelectedIndex > 0)
                            {
                                objRqdUpd.StartTime = ddlHr1_rqd.SelectedValue.ToString()
                                                     + ":" + ddlMin1_rqd.SelectedValue.ToString();

                            }

                            if (this.ddlHr2_rqd.SelectedIndex > 0 && this.ddlMin2_rqd.SelectedIndex > 0)
                            {
                                objRqdUpd.EndTime = ddlHr2_rqd.SelectedValue.ToString()
                                                        + ":" + ddlMin2_rqd.SelectedValue.ToString();

                            }

                            objRqdUpd.BookingDate = txtUpdBookingDate_RDT.Text.Trim();
                            objRqdUpd.Purpose = txtUpdPurpose.Text.Trim();
                            objRqdUpd.EntryBy = entryBy;
                            objRqdUpd.LstBookedResources = GetUpdatedResourcesData();

                            List<ATTMeetingVenueBooking> lst = new List<ATTMeetingVenueBooking>();
                            lst = BLLMeetingVenueBooking.CheckVenueIfVenueAlreadyBooked(objRqdUpd);

                            lst.RemoveAll(
                                            (delegate(ATTMeetingVenueBooking obj)
                                                {
                                                    return objRqdUpd.OrgID == obj.OrgID && objRqdUpd.BookingID == obj.BookingID;
                                                }
                                             )
                                         );


                            if (lst.Count > 0)
                            {
                                this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                                this.lblStatusMessage.Text = "अरु प्रायोजनको निमित्त स्थल बुकिङ्ग भईसकेको छ,त्यसैले अर्को स्थल छान्नुहोस् !!!";
                                this.programmaticModalPopup.Show();
                            }
                            else
                            {
                                if (BLLMeetingVenueBooking.UpdateMeetingVenueBooking(objRqdUpd))
                                {
                                    ddlUpdOrganization_rqd.SelectedIndex = -1;
                                    ddlUpdPerson_rqd.SelectedIndex = -1;
                                    ddlUpdVenue_rqd.SelectedIndex = -1;
                                    ddlHr1_rqd.SelectedIndex = -1;
                                    ddlMin1_rqd.SelectedIndex = -1;
                                    ddlHr2_rqd.SelectedIndex = -1;
                                    ddlMin2_rqd.SelectedIndex = -1;

                                    txtUpdBookingDate_RDT.Text = "";
                                    txtUpdBookingNo_rqd.Text = "";
                                    txtUpdPurpose.Text = "";

                                    grdBookedVenue.SelectedIndex = -1;

                                    programmaticBookedVenueModalPopup.Hide();

                                    btnSearch_Click(null, null);

                                    this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                                    this.lblStatusMessage.Text = "स्थल बुकिङ्गको विवरण परिवर्तन सफलतापूर्वक भयो !!!";
                                    this.programmaticModalPopup.Show();


                                }
                            }
                        }
                        else
                        {
                            this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
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
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public List<ATTMeetingVenueResources> GetUpdatedResourcesData()
    {
        List<ATTMeetingVenueResources> lst = new List<ATTMeetingVenueResources>();
        try
        {
            
            if (Session["ResToUpdate"] != null)
            {
                bool flag = false;
                CheckBox chkResource;
                DropDownList ddlQuantity;

                List<ATTMeetingVenueResources> lstRes = (List<ATTMeetingVenueResources>)Session["ResToUpdate"];
                

                if (grdResources.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in grdResources.Rows)
                    {
                        int resourceID = int.Parse(gvr.Cells[1].Text);
                        chkResource = (CheckBox)gvr.FindControl("chkResource");
                        ddlQuantity = (DropDownList)gvr.FindControl("ddlQuantity");

                        foreach (ATTMeetingVenueResources objRes in lstRes)
                        {
                            if (resourceID == objRes.ResourceID)
                            {
                                

                                if (chkResource.Checked)
                                {
                                    if (int.Parse(ddlQuantity.SelectedValue) == objRes.ResourceQty)
                                    {
                                        objRes.Action = "N";
                                    }
                                    else
                                    {
                                        objRes.Action = "E";
                                        objRes.ResourceQty = int.Parse(ddlQuantity.SelectedValue);
                                    }
                                }
                                else
                                {
                                    objRes.Action = "D";
                                }

                                lst.Add(objRes);

                                flag = true;
                                break;
                                

                            }
                        }

                        if (!flag)
                        {
                            if (chkResource.Checked)
                            {
                                ATTMeetingVenueResources obj = new ATTMeetingVenueResources();
                                obj.Action = "A";
                                obj.ResourceID = resourceID;
                                obj.ResourceQty = int.Parse(ddlQuantity.SelectedValue);
                                obj.ResourceBookID = null;

                                lst.Add(obj);
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }

                
                
            }

            return lst;
         
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();

            return lst;
        }
    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {

        grdBookedVenue.SelectedIndex = -1;
        programmaticBookedVenueModalPopup.Hide();

        ClearUpdControls();
        LoadBookedVenue();
      

    }

    public void ClearUpdControls()
    {
        try
        {
            ddlUpdOrganization_rqd.SelectedIndex = -1;
            ddlUpdPerson_rqd.SelectedIndex = -1;
            ddlUpdVenue_rqd.SelectedIndex = -1;
            txtUpdBookingDate_RDT.Text = "";
            txtUpdBookingNo_rqd.Text = "";
            ddlHr1_rqd.SelectedIndex = -1;
            ddlHr2_rqd.SelectedIndex = -1;
            ddlMin1_rqd.SelectedIndex = -1;
            ddlMin2_rqd.SelectedIndex = -1;

            grdResources.DataSource = "";
            grdResources.DataBind();
            grdResources.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int ID = int.Parse(txtUpdBookingNo_rqd.Text.Trim());

            int count = BLLMeetingVenueBooking.CheckBookingIDInUse(ID);

            if (count > 0)
            {
                this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                this.lblStatusMessage.Text = "यो बुकिङ्ग नम्बर प्रयोगमा छ,त्यसैले अहिले हटाउन मिल्दैन।";
                this.programmaticModalPopup.Show();
            }
            else
            {
                if (BLLMeetingVenueBooking.DeleteMeetingVenueBooking(ID))
                {
                    LoadBookedVenue();
                    this.programmaticBookedVenueModalPopup.Hide();
                    
                    this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                    this.lblStatusMessage.Text = "बुकिङ्ग नम्बर सफलतापुर्वक हटाइयो।";
                    this.programmaticModalPopup.Show();
                }
                else
                {
                    this.lblStatusMessageTitle.Text = "स्थल व्यवस्थापन";
                    this.lblStatusMessage.Text = "बुकिङ्ग नम्बर हटाउँदा वाधा उत्पन्न भयो।";
                    this.programmaticModalPopup.Show();
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
}
