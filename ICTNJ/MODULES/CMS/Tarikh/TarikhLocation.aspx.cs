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
using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

using System.Collections.Generic;
using System.Reflection;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_Tarikh_TarikhLocation : System.Web.UI.Page
{
    
    int courtID = 9;
    string entryBy = "Suman";
    int userID = 8;

    
    public List<ATTAttorney> ALLAttorneyLIST
    {
        get { return (Session["ALLAttorneyLIST"] == null) ? new List<ATTAttorney>() : (List<ATTAttorney>)Session["ALLAttorneyLIST"]; }
        set { Session["ALLAttorneyLIST"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsLIST
    {
        get { return (Session["LitigantsLIST"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsLIST"]; }
        set { Session["LitigantsLIST"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsAppelant
    {
        get { return (Session["LitigantsAppelant"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsAppelant"]; }
        set { Session["LitigantsAppelant"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsRespondant
    {
        get { return (Session["LitigantsRespondant"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsRespondant"]; }
        set { Session["LitigantsRespondant"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            
            this.CollapsiblePanelExtender1.Collapsed = true;
           
            this.panel1.Visible = false;
            LoadCourts();
            displayAllControlDiv.Visible = false;
        }
    }

    private void GetAllLitigants(int caseID)
    {

        try
        {
            ATTLitigantSearch obj = new ATTLitigantSearch();
            obj.CourtID = courtID;
            obj.CaseID = caseID;
            List<ATTLitigantSearch> lstLitigants = BLLLitigantSearch.GetLitigantSearch(obj);

            LitigantsLIST = lstLitigants;
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

   }
    private void GetAllAttorney(int caseID)
    {
        try
        {
            List<ATTAttorney> lst = BLLAttorney.GetAttorney(caseID, "Y");
            ALLAttorneyLIST = lst;
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
        
    }
  
    private void LoadLitigants()
    {

        if (LitigantsLIST.Count > 0)
        {
            
            List<ATTLitigantSearch> lstLITT = LitigantsLIST;

            List<ATTLitigantSearch> lstApp = lstLITT.FindAll(
                                                                   delegate(ATTLitigantSearch litg)
                                                                   {
                                                                       return (litg.LitigantType == "A");
                                                                   }
                                                               );
            LitigantsAppelant = lstApp;
            grdLitigantsApp.DataSource = LitigantsAppelant;
            grdLitigantsApp.DataBind();
            if (lstApp.Count == 0) pnlApp.Height = Unit.Pixel(5);
            else pnlApp.Height = Unit.Pixel(200);


            List<ATTLitigantSearch> lstRes = lstLITT.FindAll(
                                                                 delegate(ATTLitigantSearch litg)
                                                                 {
                                                                     return (litg.LitigantType == "R");
                                                                 }
                                                             );
            LitigantsRespondant = lstRes;
            grdLitigantRes.DataSource = LitigantsRespondant;
            grdLitigantRes.DataBind();
            if (lstRes.Count == 0) pnlRes.Height = Unit.Pixel(5);
            else pnlRes.Height = Unit.Pixel(200);
        }
        else
        {
            grdLitigantsApp.DataSource = null;
            grdLitigantsApp.DataBind();
            grdLitigantRes.DataSource = null;
            grdLitigantRes.DataBind();
            pnlApp.Height = Unit.Pixel(5);
            pnlRes.Height = Unit.Pixel(5);
        }
    }
    private List<ATTAttorney> GetAttorneyByLitigantID(int litigantID)
    {
        List<ATTAttorney> lst = ALLAttorneyLIST;
        return lst.FindAll(
                                delegate(ATTAttorney obj)
                                {
                                    return (obj.LitigantID == litigantID && obj.ToDate == "");
                                }
                           );
    }
    

   
   
    void LoadCourts()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrganization(0);
            lstOrg.RemoveAll(
                                delegate(ATTOrganization obj)
                                {
                                    return (obj.OrgType!="CRT");
                                }
                            );
            lstOrg.Insert(0, new ATTOrganization(0, "-- छान्नुहोस --"));
            ddlCourt.DataSource = lstOrg;
            ddlCourt.DataTextField = "OrgName";
            ddlCourt.DataValueField = "OrgID";

            ddlCourt.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = "अदालातहरु लोड गर्न सकेन " + ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }


    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdLitigantsApp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (LitigantsAppelant.Count > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].Width = Unit.Pixel(200);
            e.Row.Cells[9].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[12].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "<pre>        </pre>";



            int litigantID = int.Parse(e.Row.Cells[2].Text);

            // GridView grd1 = (GridView)(((Panel)e.Row.FindControl("pnlAttorney1")).FindControl("grdAttorney1"));
            GridView grd1 = (GridView)e.Row.FindControl("grdAttorney1");
            grd1.DataSource = GetAttorneyByLitigantID(litigantID);
            grd1.DataBind();
            this.panel1.Visible = true;

       


        }

    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        //GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;

        bool val = true;
        foreach (GridViewRow row in grdLitigantsApp.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
            if (check)
            {
                val = false;
            }
        }
        ((CheckBox)grdLitigantsApp.HeaderRow.Cells[0].FindControl("chk")).Checked = val;
    }
    protected void chkHEADER_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdLitigantsApp.HeaderRow.Cells[0].FindControl("chk")).Checked;
        ChkUncheckLitigantApp(val);

    }

    protected void grdLitigantsRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (LitigantsRespondant.Count > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[9].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[12].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "<pre>        </pre>";



            int litigantID = int.Parse(e.Row.Cells[2].Text);

            //GridView grd1 = (GridView)(((Panel)e.Row.FindControl("pnlAttorney")).FindControl("grdAttorney"));
            GridView grd1 = (GridView)e.Row.FindControl("grdAttorney");


            grd1.DataSource = GetAttorneyByLitigantID(litigantID);
            grd1.DataBind();

          

        }
    }
    protected void chkRes_CheckedChanged(object sender, EventArgs e)
    {
        bool val = true;
        foreach (GridViewRow row in grdLitigantRes.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chkRes")).Checked;
            if (check)
            {
                val = false;
            }
        }
        ((CheckBox)grdLitigantRes.HeaderRow.Cells[0].FindControl("chkRes")).Checked = val;
    }
    protected void chkHEADERRes_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdLitigantRes.HeaderRow.Cells[0].FindControl("chkRes")).Checked;
        ChkUncheckLitigantRes(val);
    }

    protected void grdAttorney_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }



    }
    protected void grdTamWitPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[5].Text;

            if (gender == "M") e.Row.Cells[5].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[5].Text = "महिला";
            else e.Row.Cells[6].Text = "अन्य";
        }


    }
    //private void SortAttorneyList()
    //{
    //    //List<ATTAttorney> lstAttorney = AttorneyLIST;

    //    //lstAttorney.Sort(delegate(ATTAttorney obj1, ATTAttorney obj2)
    //    //                    {
    //    //                        return (obj1.PersonID.CompareTo(obj2.PersonID));
    //    //                    });

    //    //AttorneyLIST = lstAttorney;

    //}
    //protected void grdAttorney_DataBinding(object sender, EventArgs e)
    //{
    //    SortAttorneyList();
    //}

    private void ChkUncheckLitigantApp(bool check)
    {
        foreach (GridViewRow row in grdLitigantsApp.Rows)
        {
            ((CheckBox)row.FindControl("chk")).Checked = check;
        }
    }
    private void ChkUncheckLitigantRes(bool check)
    {
        foreach (GridViewRow row in grdLitigantRes.Rows)
        {
            ((CheckBox)row.FindControl("chkRes")).Checked = check;
        }
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        //Response.Write("WebForm1 :: WebForm1_BubbleClick from " +
        //               sender.GetType().ToString() + "<BR>");

        int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);


        //Session["CaseID"] = caseID;
        GetAllAttorney(caseID);
   
        GetAllLitigants(caseID);
        LoadLitigants();
        GetTarikhLocation();
        displayAllControlDiv.Visible = true;
        this.CollapsiblePanelExtender1.ClientState = "false";
        this.CollapsiblePanelExtender1.Collapsed = false;


    }
    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
        if (((GridView)CaseSearch1.FindControl("grdCase")).Rows.Count < 1)
        {
            grdLitigantsApp.DataSource = null;
            grdLitigantRes.DataSource = null;
            grdLitigantsApp.DataBind();
            grdLitigantRes.DataBind();
        }



        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";

    }
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        CaseSearch1.BubbleClick += new EventHandler(WebForm1_BubbleClick);
        CaseSearch1.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (ddlCourt.SelectedIndex <=0)
        {
            lblStatusMessage.Text = "Please Select Court Type";
            this.programmaticModalPopup.Show();
            return;
        }
        if (fromDateTxt.Text == "")
        {
            lblStatusMessage.Text = "जारी मिति छुट्यो";
            this.programmaticModalPopup.Show();
            return;
        }


        List<ATTTarikhLocation> lstTarikhLocation = new List<ATTTarikhLocation>();
        foreach (GridViewRow grow in grdLitigantsApp.Rows)
        {
            if (((CheckBox)grow.FindControl("chk")).Checked)
            {
                ATTTarikhLocation obj = new ATTTarikhLocation();

                obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                obj.PersonID = int.Parse(grow.Cells[2].Text.Trim());
                obj.PersonType = "S";
                lstTarikhLocation.Add(obj);

            }
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney1")).Rows)
            {
                if (((CheckBox)grow1.FindControl("chk")).Checked)
                {
                    ATTTarikhLocation obj = new ATTTarikhLocation();
                    obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                    obj.PersonID = int.Parse(grow1.Cells[2].Text.Trim());
                    obj.PersonType = "W";
                    lstTarikhLocation.Add(obj);
                 }
            }
        }

            foreach (GridViewRow grow in grdLitigantRes.Rows)
            {
                if (((CheckBox)grow.FindControl("chkRes")).Checked)
                {
                    ATTTarikhLocation obj = new ATTTarikhLocation();
                    obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                    obj.PersonID = int.Parse(grow.Cells[2].Text.Trim());
                    obj.PersonType = "S";
                    lstTarikhLocation.Add(obj);
                }
                foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney")).Rows)
                {
                    if (((CheckBox)grow1.FindControl("chk")).Checked)
                    {
                        ATTTarikhLocation obj = new ATTTarikhLocation();
                        obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                        obj.PersonID = int.Parse(grow1.Cells[2].Text.Trim());
                        obj.PersonType = "W";
                        lstTarikhLocation.Add(obj);
                    }
                }
            }


                if (lstTarikhLocation.Count > 0)
                {
                    foreach (ATTTarikhLocation obj in lstTarikhLocation)
                    {
                        obj.FromDate = fromDateTxt.Text;
                        obj.EntryBy = entryBy;
                        obj.Action = "A";
                        obj.CourtID = int.Parse(this.ddlCourt.SelectedValue.ToString());
                                  
                    }
                    //removing multiple occurences of person_id in case of attorney
                    foreach (ATTTarikhLocation obj in lstTarikhLocation)
                    {
                        int personId = obj.PersonID;
                        int count=0;
                        
                        for(int i=0; i<lstTarikhLocation.Count;i++)
                        {
                            if (personId == lstTarikhLocation[i].PersonID)
                                count++;
                            if (count > 1)
                            {
                                lstTarikhLocation[i].Action = "Rem";
                            }
                        }
                      }
                    }

                    if (lstTarikhLocation.Count == 0)
                    {
                        lblStatusMessage.Text = "No data selected";
                        this.programmaticModalPopup.Show();
                        return;
                    }
        
                try
                {
                    BLLTarikhLocation.AddTarikhLocation(lstTarikhLocation);
                   lblStatusMessage.Text = "Data Saved Successfully";
                   this.programmaticModalPopup.Show();
                   ClearControls();
                   GetTarikhLocation();
                }
                catch(Exception ex)
                {
                    lblStatusMessage.Text = "Problem Saving Data "+ex.Message;
                    this.programmaticModalPopup.Show();
                }

          

        }

 
   
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();

    }

    protected void ClearControls()
    {
        this.ddlCourt.SelectedIndex = 0;
        this.fromDateTxt.Text = "";
        foreach (GridViewRow grow in grdLitigantsApp.Rows)
        {
            CheckBox cb=(CheckBox)grow.FindControl("chk");
            cb.Checked=false;
            {
             
            }
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney1")).Rows)
            {
                CheckBox cb1 = (CheckBox)grow1.FindControl("chk");
                cb1.Checked = false;
            }
        }

        foreach (GridViewRow grow in grdLitigantRes.Rows)
        {
            CheckBox cb=(CheckBox)grow.FindControl("chkRes");
            cb.Checked=false;
            
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney")).Rows)
            {
                CheckBox cb1=(CheckBox)grow1.FindControl("chk");
                cb1.Checked=false;
            }
        }
    }


    protected void GetTarikhLocation()
    {
       int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
       tarikhLocationGrid.DataSource = BLLTarikhLocation.GetTarikhLocation(caseID);
       tarikhLocationGrid.DataBind();
    }



    protected void tarikhLocationGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
        int courtID = Convert.ToInt32((this.tarikhLocationGrid.DataKeys[(e.RowIndex)].Values["CourtID"]));
        int personID = Convert.ToInt32((this.tarikhLocationGrid.DataKeys[(e.RowIndex)].Values["PersonID"]));
        try
        {
            BLLTarikhLocation.DeleteTarikhLocation(caseID, personID, courtID);
            GetTarikhLocation();
            lblStatusMessage.Text = "Deleted Successfully";
            programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            throw ex;
            programmaticModalPopup.Show();
        }


    }
}
