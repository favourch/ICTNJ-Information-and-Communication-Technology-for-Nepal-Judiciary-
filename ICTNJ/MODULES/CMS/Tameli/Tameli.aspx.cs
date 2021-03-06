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

public partial class MODULES_CMS_Tameli_Tameli : System.Web.UI.Page
{
    int courtID = 9;
    string entryBy = "Suman";
    int userID = 8;

    public List<ATTWitnessSearch> TameliWitPersonLST
    {
        get { return (Session["TameliWitPerson"] == null) ? new List<ATTWitnessSearch>() : (List<ATTWitnessSearch>)Session["TameliWitPerson"]; }
        set { Session["TameliWitPerson"] = value; }
    }
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
    public List<ATTMyaadType> MyaadType
    {
        get { return (Session["MyaadType"] == null) ? new List<ATTMyaadType>() : (List<ATTMyaadType>)Session["MyaadType"]; }
        set { Session["MyaadType"] = value; }
    }
    public List<ATTTameliSearch> TameliSend
    {
        get { return (Session["TameliSendDeleteNEW"] == null) ? new List<ATTTameliSearch>() : (List<ATTTameliSearch>)Session["TameliSendDeleteNEW"]; }
        set { Session["TameliSendDeleteNEW"] = value; }
    }
    public List<ATTTameliSearch> TameliAssignTamildaar
    {
        get { return (Session["TameliAssignTamildaar"] == null) ? new List<ATTTameliSearch>() : (List<ATTTameliSearch>)Session["TameliAssignTamildaar"]; }
        set { Session["TameliAssignTamildaar"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //userID= int.Parse(Session["User_ID"].ToString()); 

            LoadData();
            // pnlTamWitPerson.Visible = false;
        }

    }

    private void LoadData()
    {
        this.collCasesearch.Collapsed = false;
        this.collCasesearch.ClientState = "false";
        this.CollapsiblePanelExtender1.ClientState = "true";
        this.CollapsiblePanelExtender1.Collapsed = true;

        this.CollapsiblePanelExtender2.ClientState = "true";
        this.CollapsiblePanelExtender2.Collapsed = true;

        this.CollapsiblePanelExtender3.ClientState = "true";
        this.CollapsiblePanelExtender3.Collapsed = true;

        LoadTameliType();
        LoadMyaadType();
        LoadCourts();
        LoadTamildaar();
        pnlEmpSearch.Visible = false;
        pnlCourts.Visible = false;
        pnlTameliMedia.Visible = false;
        ////
        LoadTameliList();
        LoadDataForTamildaarAssignment();
        ////
        grdAssignTamildaar.SelectedIndex = -1;
        grdTamilDaar.SelectedIndex = -1;
        txtTamildaarReceivedDate.Text = "";
        txtamilDaarReceivedDate1.Text = "";

    }

    private void LoadTamildaar()
    {
        ATTEmployeeWorkDivision obj = new ATTEmployeeWorkDivision();
        obj.OrgID = courtID;
        obj.DesType = "O";
        obj.UnitType = "M";

        List<ATTEmployeeWorkDivision> lst = BLLEmployeeWorkDivision.SearchEmployee(obj);
        grdTamilDaar.DataSource = lst;
        grdTamilDaar.DataBind();
        grdEmpSearch.DataSource = lst;
        grdEmpSearch.DataBind();
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
    private void GetAllWitnesses(int caseID)
    {
        try
        {
            ATTWitnessSearch obj = new ATTWitnessSearch();
            obj.CaseID = caseID;
            List<ATTWitnessSearch> lst = BLLWitnessSearch.SearchWitnessPerson(obj);
            TameliWitPersonLST = lst;
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
            else pnlApp.Height = Unit.Pixel(150);


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
            else pnlRes.Height = Unit.Pixel(150);
        }
        else
        {
            LitigantsAppelant = null;
            LitigantsRespondant = null;
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
    private List<ATTWitnessSearch> GetWitnessByLitigantID(int litigantID)
    {
        List<ATTWitnessSearch> lst = TameliWitPersonLST;
        return lst.FindAll(
                                delegate(ATTWitnessSearch obj)
                                {
                                    return (obj.LItigantID == litigantID);
                                }
                           );
    }

    private void LoadTameliType()
    {
        try
        {
            List<ATTTameliType> tameliTypeLIST = BLLTameliType.GetTameliType(null, "Y");
            ATTTameliType obj = new ATTTameliType();
            obj.TameliTypeName = "छान्नुहोस्";
            obj.TameliTypeID = 0;
            tameliTypeLIST.Insert(0, obj);
            ddlTameliType.DataSource = tameliTypeLIST;
            ddlTameliType.DataBind();
        }
        catch (Exception)
        {

            lblStatusMessage.Text = "तामेलीको प्रकार लोड गर्न सकेन </br>";
            this.programmaticModalPopup.Show();
            return;
        }

    }
    private void LoadMyaadType()
    {
        try
        {
            List<ATTMyaadType> myaadTypeLIST = BLLMyaadType.GetMyaadType(null, "Y");
            MyaadType = myaadTypeLIST;
            ATTMyaadType obj = new ATTMyaadType();
            obj.MyaadTypeName = "छान्नुहोस्";
            obj.MyaadTypeID = 0;
            myaadTypeLIST.Insert(0, obj);
            ddlMyaadType.DataSource = myaadTypeLIST;
            ddlMyaadType.DataBind();
        }
        catch (Exception)
        {

            lblStatusMessage.Text = "म्यादको प्रकार लोड गर्न सकेन </br>";
            this.programmaticModalPopup.Show();
            return;
        }

    }
    void LoadCourts()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrganization(0);
            lstOrg.RemoveAll(
                                delegate(ATTOrganization obj)
                                {
                                    return (obj.OrgID == courtID);
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
            e.Row.Cells[9].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.Header)
        {
            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chk")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chk")).Attributes.Add("onclick", str);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chk")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chk")).Attributes.Add("onclick", str);

            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[12].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "<pre>        </pre>";



            int litigantID = int.Parse(e.Row.Cells[2].Text);

            GridView grd1 = (GridView)e.Row.FindControl("grdAttorney1");
            grd1.DataSource = GetAttorneyByLitigantID(litigantID);
            grd1.DataBind();

            GridView grd2 = (GridView)e.Row.FindControl("grdTamWitPerson1");
            grd2.DataSource = GetWitnessByLitigantID(litigantID);
            grd2.DataBind();


        }

    }
    //protected void chk_CheckedChanged(object sender, EventArgs e)
    //{
    //    //GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;

    //    bool val = true;
    //    foreach (GridViewRow row in grdLitigantsApp.Rows)
    //    {
    //        bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
    //        if (check)
    //        {
    //            val = false;
    //        }
    //    }
    //    ((CheckBox)grdLitigantsApp.HeaderRow.Cells[0].FindControl("chk")).Checked = val;        
    //}
    //protected void chkHEADER_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool val = ((CheckBox)grdLitigantsApp.HeaderRow.Cells[0].FindControl("chk")).Checked;
    //    ChkUncheckLitigantApp(val);

    //}

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


        if (e.Row.RowType == DataControlRowType.Header)
        {
            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chkRes")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkRes")).Attributes.Add("onclick", str);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str = "return CheckUncheck('" + ((CheckBox)e.Row.FindControl("chkRes")).ClientID + "');";
            ((CheckBox)e.Row.FindControl("chkRes")).Attributes.Add("onclick", str);

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

            //GridView grd2 = (GridView)(((Panel)e.Row.FindControl("pnlTameliWitPerson")).FindControl("grdTamWitPerson"));
            GridView grd2 = (GridView)e.Row.FindControl("grdTamWitPerson");
            grd2.DataSource = GetWitnessByLitigantID(litigantID);
            grd2.DataBind();

        }
    }
    //protected void chkRes_CheckedChanged(object sender, EventArgs e)
    //{       
    //    bool val = true;
    //    foreach (GridViewRow row in grdLitigantRes.Rows)
    //    {
    //        bool check = !((CheckBox)row.Cells[0].FindControl("chkRes")).Checked;
    //        if (check)
    //        {
    //            val = false;
    //        }            
    //    }
    //    ((CheckBox)grdLitigantRes.HeaderRow.Cells[0].FindControl("chkRes")).Checked = val;
    //}
    //protected void chkHEADERRes_CheckedChanged(object sender, EventArgs e)
    //{      
    //    bool val = ((CheckBox)grdLitigantRes.HeaderRow.Cells[0].FindControl("chkRes")).Checked;
    //    ChkUncheckLitigantRes(val);
    //}

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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    string str = "return InnerGridsCheckUncheck('" + ((CheckBox)e.Row.FindControl("chk")).ClientID + "');";
            //    ((CheckBox)e.Row.FindControl("chk")).Attributes.Add("onclick", str);
            //}
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
            //string str = "return InnerGridsCheckUncheck('" + ((CheckBox)e.Row.FindControl("chk")).ClientID + "');";
            //((CheckBox)e.Row.FindControl("chk")).Attributes.Add("onclick", str);

            string gender = e.Row.Cells[5].Text;

            if (gender == "M") e.Row.Cells[5].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[5].Text = "महिला";
            else e.Row.Cells[6].Text = "अन्य";
        }


    }
    
    #region UserControl
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);

        GetAllAttorney(caseID);
        GetAllWitnesses(caseID);
        GetAllLitigants(caseID);
        LoadLitigants();
        this.CollapsiblePanelExtender1.ClientState = "false";
        this.CollapsiblePanelExtender1.Collapsed = false;

        //if (LitigantsAppelant.Count > 0 || LitigantsRespondant.Count > 0)
        //{
        this.collCasesearch.Collapsed = true;
        this.collCasesearch.ClientState = "true";
        //}
        //else 
        //{
        //    this.collCasesearch.ClientState = "false";
        //    this.collCasesearch.Collapsed = false;
        //}

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTr", "javascript:alert('hello');", true);

        if (ddlMyaadType.SelectedIndex < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hideTra", "javascript:disableAllCheckBoxes();", true);
        }
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
    private void WebForm1_BubbleClickBtnCancel(object sender, EventArgs e)
    {


        LitigantsAppelant = null;
        LitigantsRespondant = null;


        grdLitigantsApp.DataSource = null;
        grdLitigantRes.DataSource = null;
        DataBind();


        this.CollapsiblePanelExtender1.Collapsed = true;
        this.CollapsiblePanelExtender1.ClientState = "true";

    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        CaseSearch1.BubbleClick += new EventHandler(WebForm1_BubbleClick);
        CaseSearch1.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);
        CaseSearch1.BubbleClickBtnCancel += new EventHandler(WebForm1_BubbleClickBtnCancel);

    }

    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTameliType.SelectedIndex < 1)
            {
                lblStatusMessage.Text = "तामेलीको किसिम छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (txtIssuedDate.Text == "____/__/__")
            {
                lblStatusMessage.Text = "जारी मिति छुट्यो";
                this.programmaticModalPopup.Show();
                return;
            }
            if (ddlMyaadType.SelectedIndex < 1)
            {
                lblStatusMessage.Text = "म्यादको किसिम छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (ddlTameliType.SelectedIndex == 1)
            {
                if (txtTameliMedia.Text.Trim() == "")
                {
                    lblStatusMessage.Text = "तामेलि माद्यम छुट्यो";
                    this.programmaticModalPopup.Show();
                    return;
                }
                if (txtPublicationDate.Text.Trim() == "")
                {
                    lblStatusMessage.Text = "प्रकाशन मिति छुट्यो";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
            else if (ddlTameliType.SelectedIndex == 2)
            {

                if (grdEmpSearch.SelectedIndex < 0)
                {
                    lblStatusMessage.Text = "तामिलदार छान्नुहोस्";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
            else if (ddlTameliType.SelectedIndex == 3)
            {
                if (ddlCourt.SelectedIndex < 1)
                {
                    lblStatusMessage.Text = "अदालात छान्नुहोस्";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
            //if (ddlTameliType.SelectedIndex > 1)
            //{
            //    if (txtTameliWitnessPerson.Text.Trim() == "")
            //    {
            //        lblStatusMessage.Text = "तामेलिको साक्षिको नाम छुट्यो";
            //        this.programmaticModalPopup.Show();
            //        return;
            //    }
            //    if (txtPost.Text.Trim() == "")
            //    {
            //        lblStatusMessage.Text = "तामेलिको साक्षिको पद छुट्यो";
            //        this.programmaticModalPopup.Show();
            //        return;
            //    }
            //}

            List<ATTTameli> lstTameliSave = new List<ATTTameli>();
            foreach (GridViewRow grow in grdLitigantsApp.Rows)
            {
                if (((CheckBox)grow.FindControl("chk")).Checked)
                {
                    ATTTameli obj = new ATTTameli();

                    obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                    obj.LitigantID = int.Parse(grow.Cells[2].Text.Trim());
                    obj.SeqNo = 0;


                    //
                    //
                    lstTameliSave.Add(obj);
                }
                foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney1")).Rows)
                {
                    if (((CheckBox)grow1.FindControl("chk")).Checked)
                    {
                        ATTTameli obj = new ATTTameli();
                        obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                        obj.LitigantID = int.Parse(grow1.Cells[1].Text.Trim());
                        obj.SeqNo = 0;

                        obj.AttorneyID = int.Parse(grow1.Cells[2].Text.Trim());

                        //
                        //
                        lstTameliSave.Add(obj);
                    }
                }
                foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdTamWitPerson1")).Rows)
                {
                    if (((CheckBox)grow1.FindControl("chk")).Checked)
                    {
                        ATTTameli obj = new ATTTameli();
                        obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                        obj.LitigantID = int.Parse(grow1.Cells[1].Text.Trim());
                        obj.SeqNo = 0;

                        obj.WitnessID = int.Parse(grow1.Cells[2].Text.Trim());
                        //
                        //
                        lstTameliSave.Add(obj);
                    }
                }
            }
            foreach (GridViewRow grow in grdLitigantRes.Rows)
            {
                if (((CheckBox)grow.FindControl("chkRes")).Checked)
                {
                    ATTTameli obj = new ATTTameli();

                    obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                    obj.LitigantID = int.Parse(grow.Cells[2].Text.Trim());
                    obj.SeqNo = 0;
                    //
                    //
                    lstTameliSave.Add(obj);
                }
                foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney")).Rows)
                {
                    if (((CheckBox)grow1.FindControl("chk")).Checked)
                    {
                        ATTTameli obj = new ATTTameli();
                        obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                        obj.LitigantID = int.Parse(grow1.Cells[1].Text.Trim());
                        obj.SeqNo = 0;

                        obj.AttorneyID = int.Parse(grow1.Cells[2].Text.Trim());
                        //
                        //
                        lstTameliSave.Add(obj);
                    }
                }
                foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdTamWitPerson")).Rows)
                {
                    if (((CheckBox)grow1.FindControl("chk")).Checked)
                    {
                        ATTTameli obj = new ATTTameli();
                        obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                        obj.LitigantID = int.Parse(grow1.Cells[1].Text.Trim());
                        obj.SeqNo = 0;

                        obj.WitnessID = int.Parse(grow1.Cells[2].Text.Trim());
                        //
                        //
                        lstTameliSave.Add(obj);
                    }
                }
            }
            if (lstTameliSave.Count < 1)
            {
                lblStatusMessage.Text = "No person Selected For Tameli";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                foreach (ATTTameli obj in lstTameliSave)
                {
                    obj.IssuedDate = txtIssuedDate.Text;
                    obj.IssuedBy = userID;
                    obj.TameliTypeID = int.Parse(ddlTameliType.SelectedValue);
                    obj.MyaadTypeID = MyaadType[ddlMyaadType.SelectedIndex].MyaadTypeID;
                    obj.Action = "A";
                    obj.EntryBy = entryBy;

                    if (ddlTameliType.SelectedIndex == 1)
                    {
                        ATTTameliMedia tameliMedia = new ATTTameliMedia();
                        tameliMedia.CaseID = obj.CaseID;
                        tameliMedia.LitigantID = obj.LitigantID;
                        tameliMedia.IssueDate = obj.IssuedDate;

                        tameliMedia.MediaFullName = txtTameliMedia.Text.Trim();
                        tameliMedia.MediaPublicationDate = txtPublicationDate.Text.Trim();
                        tameliMedia.EntryBy = entryBy;
                        tameliMedia.Action = "A";

                        obj.TameliMediaLIST.Add(tameliMedia);

                    }
                    else if (ddlTameliType.SelectedIndex == 2)
                    {

                        if (grdTamilDaar.SelectedIndex < 0)
                        {
                            lblStatusMessage.Text = "तामिलदार छान्नुहोस्";
                            this.programmaticModalPopup.Show();
                            return;
                        }//ReceivedBy is Tamildaar ID
                        obj.ReceivedBy = int.Parse(grdTamilDaar.Rows[grdTamilDaar.SelectedIndex].Cells[1].Text);
                        obj.ReceivedDate = txtTamildaarReceivedDate.Text.Trim();
                    }
                    else if (ddlTameliType.SelectedIndex == 3)
                    {
                        obj.TameliOrg = int.Parse(ddlCourt.SelectedValue);
                    }


                    ////// add Tameli witness person
                    //if (ddlTameliType.SelectedIndex > 1)
                    //{
                    //    ATTTameliWitnessPerson TamWitPerson = new ATTTameliWitnessPerson();
                    //    TamWitPerson.CaseID = obj.CaseID;
                    //    TamWitPerson.LitigantID = obj.LitigantID;
                    //    TamWitPerson.IssuedDate = obj.IssuedDate;

                    //    TamWitPerson.FullName = txtTameliWitnessPerson.Text.Trim();
                    //    TamWitPerson.Post = txtPost.Text.Trim();
                    //    TamWitPerson.Action = "A";
                    //    TamWitPerson.EntryBy = entryBy;
                    //    obj.TameliWitnessPersonLIST.Add(TamWitPerson);
                    //}
                    ///////

                }
            }


            BLLTameli.AddEditDeleteTameli(lstTameliSave);
            lblStatusMessage.Text = "Data Saved Successfully";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "Problem Saving Data " + ex.Message;
            this.programmaticModalPopup.Show();
        }
        ClearControls();
        LoadTameliList();
    }

    private void ClearControls()
    {
        ///// UserControl Controls
        GridView grd = (GridView)CaseSearch1.FindControl("grdCase");
        grd.DataSource = null;
        grd.DataBind();
        ((DropDownList)CaseSearch1.FindControl("ddlCaseType")).SelectedIndex = -1;
        ((TextBox)CaseSearch1.FindControl("txtCaseNo")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtRegNo")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtRegDate")).Text = "";
        ((TextBox)CaseSearch1.FindControl("txtAppelantName")).Text = "";
        ////
        grdLitigantsApp.DataSource = null;
        grdLitigantRes.DataSource = null;
        grdLitigantsApp.DataBind();
        grdLitigantRes.DataBind();


        txtIssuedDate.Text = "";
        //txtPost.Text = "";
        txtPublicationDate.Text = "";
        txtTameliMedia.Text = "";
        //txtTameliWitnessPerson.Text = "";
        ddlCourt.SelectedIndex = -1;
        ddlMyaadType.SelectedIndex = -1;
        ddlTameliType.SelectedIndex = -1;
        grdTamilDaar.SelectedIndex = -1;

        TameliWitPersonLST = null;
        ALLAttorneyLIST = null;
        LitigantsLIST = null;
        LitigantsAppelant = null;
        LitigantsRespondant = null;

        this.collCasesearch.Collapsed = false;
        this.collCasesearch.ClientState = "false";
        this.CollapsiblePanelExtender1.ClientState = "true";
        this.CollapsiblePanelExtender1.Collapsed = true;

        this.CollapsiblePanelExtender2.ClientState = "true";
        this.CollapsiblePanelExtender2.Collapsed = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();

    }

    protected void ddlTameliType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTameliType.SelectedIndex < 1)
        {
            pnlTameliMedia.Visible = false;
            pnlEmpSearch.Visible = false;
            pnlCourts.Visible = false;
        }
        if (ddlTameliType.SelectedIndex == 1)
        {
            pnlTameliMedia.Visible = true;
            pnlEmpSearch.Visible = false;
            pnlCourts.Visible = false;
        }
        else if (ddlTameliType.SelectedIndex == 2)
        {
            pnlTameliMedia.Visible = false;
            pnlEmpSearch.Visible = true;
            grdTamilDaar.SelectedIndex = -1;
            pnlCourts.Visible = false;
        }
        else if (ddlTameliType.SelectedIndex == 3)
        {
            pnlTameliMedia.Visible = false;
            pnlEmpSearch.Visible = false;
            pnlCourts.Visible = true;
        }
        else if (ddlTameliType.SelectedIndex == 4)
        {
            pnlTameliMedia.Visible = false;
            pnlEmpSearch.Visible = false;
            pnlCourts.Visible = false;
        }

        if (ddlTameliType.SelectedIndex == 2)
        {
            // pnlTamWitPerson.Visible = true;
        }
        else
        {
            // pnlTamWitPerson.Visible = false ;
        }

    }
    protected void grdEmpSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;

        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = false;

    }

    protected void grdTameli_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    private void LoadTameliList()
    {
        try
        {
            ATTTameliSearch obj = new ATTTameliSearch();

            obj.OrgID = courtID;


            //if (txtAppelantName.Text.Trim() != "") obj.Appelant = txtAppelantName.Text;
            //if (txtRespondantName.Text.Trim() != "") obj.Respondant = txtRespondantName.Text;


            obj.TameliYesNo = "null";
            obj.TameliDate = "null";
            obj.SecClrkRcvdDate = "null";
            obj.VerifiedYesNo = "null";

            List<ATTTameliSearch> lst = BLLTameliSearch.GetTameliForFeedBack(obj);
            TameliSend = lst;

            grdTameli.DataSource = lst;
            grdTameli.DataBind();

            grdTameli.SelectedIndex = -1;

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    private void LoadDataForTamildaarAssignment()
    {
        ATTTameliSearch obj = new ATTTameliSearch();

        List<ATTTameliSearch> lst = BLLTameliSearch.GetTameliForAssigningTamildaar(courtID);
        TameliAssignTamildaar = lst;

        grdAssignTamildaar.DataSource = lst;
        grdAssignTamildaar.DataBind();

        grdAssignTamildaar.SelectedIndex = -1;
    }


    protected void grdTameli_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ATTTameli tam = new ATTTameli();
            List<ATTTameli> tamlstt = new List<ATTTameli>();

            tam.CaseID = TameliSend[e.RowIndex].CaseID;
            tam.LitigantID = TameliSend[e.RowIndex].LitigantID;
            tam.IssuedDate = TameliSend[e.RowIndex].IssuedDate;
            tam.SeqNo = TameliSend[e.RowIndex].SeqNo;
            tam.Action = "D";


            ATTTameliMedia tamMed = new ATTTameliMedia();
            List<ATTTameliMedia> tamMedlstt = new List<ATTTameliMedia>();

            tamMed.CaseID = TameliSend[e.RowIndex].CaseID;
            tamMed.LitigantID = TameliSend[e.RowIndex].LitigantID;
            tamMed.IssueDate = TameliSend[e.RowIndex].IssuedDate;
            tamMed.SeqNo = TameliSend[e.RowIndex].SeqNo;
            tamMed.Action = "D";
            tamMedlstt.Add(tamMed);

            tam.TameliMediaLIST = tamMedlstt;

            


            ATTTameliWitnessPerson tamWitPerson = new ATTTameliWitnessPerson();
            List<ATTTameliWitnessPerson> tamWitPersonlstt = new List<ATTTameliWitnessPerson>();


            tamWitPerson.CaseID = TameliSend[e.RowIndex].CaseID;
            tamWitPerson.LitigantID = TameliSend[e.RowIndex].LitigantID;
            tamWitPerson.IssuedDate = TameliSend[e.RowIndex].IssuedDate;
            tamWitPerson.SeqNo = TameliSend[e.RowIndex].SeqNo;
            tamWitPerson.Action = "D";
            tamWitPersonlstt.Add(tamWitPerson);

            tam.TameliWitnessPersonLIST = tamWitPersonlstt;

            tamlstt.Add(tam);


            BLLTameli.AddEditDeleteTameli(tamlstt);
            LoadTameliList();
            ClearControls();

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "Tameli Could Not Be Deleted" + ex.Message.ToString();
            programmaticModalPopup.Show();
        }

    }
    protected void grdAssignTamildaar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
    protected void grdTamilDaar_RowCreated(object sender, GridViewRowEventArgs e)
    {

        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;

        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        e.Row.Cells[12].Visible = false;
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdAssignTamildaar.SelectedIndex==-1)
            {
                lblStatusMessage.Text = "Select Tameli" ;
                programmaticModalPopup.Show();
                return;
            }
            if (grdTamilDaar.SelectedIndex == -1)
            {
                lblStatusMessage.Text = "Select Tamildaar";
                programmaticModalPopup.Show();
                return;
            }
            if (txtamilDaarReceivedDate1.Text.Trim() == "" ||txtamilDaarReceivedDate1.Text== "____/__/__")
            {
                lblStatusMessage.Text = "Tamildaar Received Date missing";
                programmaticModalPopup.Show();
                return;
            }

            List<ATTTameliSearch> lst = TameliAssignTamildaar;
            ATTTameli obj = new ATTTameli();
            obj.CaseID = lst[grdAssignTamildaar.SelectedIndex].CaseID;
            obj.LitigantID = lst[grdAssignTamildaar.SelectedIndex].LitigantID;
            obj.IssuedDate = lst[grdAssignTamildaar.SelectedIndex].IssuedDate;
            obj.SeqNo = lst[grdAssignTamildaar.SelectedIndex].SeqNo;

            obj.ReceivedBy = int.Parse(grdTamilDaar.SelectedRow.Cells[1].Text);
            obj.ReceivedDate = txtamilDaarReceivedDate1.Text.Trim();
            BLLTameli.AssignTamildaar(obj);

            lblStatusMessage.Text = "TamilDaar Assigned";
            programmaticModalPopup.Show();

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "TamilDaar Couldn't be  Assigned" + ex.Message;
            programmaticModalPopup.Show();
        }
        ClearTameliAssign();
    }
    protected void btnCancelAssign_Click(object sender, EventArgs e)
    {
        ClearTameliAssign();
    }
    private void ClearTameliAssign()
    {
        LoadData();
        
    }
    
}
