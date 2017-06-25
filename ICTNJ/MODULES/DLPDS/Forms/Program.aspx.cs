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

using PCS.DLPDS.BLL;
using PCS.DLPDS.ATT;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_Forms_Program : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("Program") == true )
        {
            if (Page.IsPostBack == false)
            {
                LoadSponsor();
                LoadProgramType();
                LoadDurationType();
                LoadProgram();
                //setSponsorTable();
                //setSessionTable();
                //setCourseTable();
                setPrgCoordinatorTable();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
        


    }

  #region "COMMENTED CODE FOR SET TABLES"
    //void setSponsorTable()
    //{
    //    DataTable tbl = new DataTable();
    //    DataColumn dtCol0 = new DataColumn("SponsorID");
    //    DataColumn dtCol1 = new DataColumn("SponsorName");
    //    DataColumn dtCol2 = new DataColumn("Budget");
    //    DataColumn dtCol3 = new DataColumn("Currency");
    //    DataColumn dtCol4 = new DataColumn("FromDate");
    //    DataColumn dtCol5 = new DataColumn("Action");

    //    DataColumn[] PK = new DataColumn[] { dtCol0 };

    //    tbl.Columns.Add(dtCol0);
    //    tbl.Columns.Add(dtCol1);
    //    tbl.Columns.Add(dtCol2);
    //    tbl.Columns.Add(dtCol3);
    //    tbl.Columns.Add(dtCol4);
    //    tbl.Columns.Add(dtCol5);
        
    //    tbl.PrimaryKey = PK;


    //    Session["SponsorTbl"] = tbl;
    //}
    //void setSessionTable()
    //{
    //    DataTable tbl = new DataTable();
    //    DataColumn dtCol0 = new DataColumn("SessionID");
    //    DataColumn dtCol1 = new DataColumn("SessionName");
    //    DataColumn dtCol2 = new DataColumn("FromDate");
    //    DataColumn dtCol3 = new DataColumn("Time");
    //    DataColumn dtCol4 = new DataColumn("Action");

    //    DataColumn[] PK = new DataColumn[] { dtCol1 };

    //    tbl.Columns.Add(dtCol0);
    //    tbl.Columns.Add(dtCol1);
    //    tbl.Columns.Add(dtCol2);
    //    tbl.Columns.Add(dtCol3);
    //    tbl.Columns.Add(dtCol4);

    //    tbl.PrimaryKey = PK;


    //    Session["SessionTbl"] = tbl;
    //}
    //void setCourseTable()
    //{
    //    DataTable tbl = new DataTable();
    //    DataColumn dtCol0 = new DataColumn("CourseID");
    //    DataColumn dtCol1 = new DataColumn("CourseTitle");
    //    DataColumn dtCol2 = new DataColumn("Description");
    //    DataColumn dtCol3 = new DataColumn("Active");
    //    DataColumn dtCol4 = new DataColumn("Action");

    //    DataColumn[] PK = new DataColumn[] { dtCol1 };

    //    tbl.Columns.Add(dtCol0);
    //    tbl.Columns.Add(dtCol1);
    //    tbl.Columns.Add(dtCol2);
    //    tbl.Columns.Add(dtCol3);
    //    tbl.Columns.Add(dtCol4);

    //    tbl.PrimaryKey = PK;


    //    Session["CourseTbl"] = tbl;
    //}
#endregion

    void setPrgCoordinatorTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("ProgramCoordinatorID");
        DataColumn dtCol1 = new DataColumn("PID");
        DataColumn dtCol2 = new DataColumn("CoordinatorName");
        DataColumn dtCol3 = new DataColumn("CoordinatorTypeID");
        DataColumn dtCol4 = new DataColumn("CoordinatorType");
        DataColumn dtCol5 = new DataColumn("Action");
        
        DataColumn[] PK = new DataColumn[] { dtCol1 };

        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);
        
        tbl.PrimaryKey = PK;


        Session["CoordinatorTbl"] = tbl;
    }

    private void LoadSponsor()
    {
        List<ATTSponsor> SponsorLST = BLLSponsor.GetSponsorList(0,"Y");
        Session["Sponsors"] = SponsorLST;
        this.ddlSponsors.DataSource = SponsorLST;
        this.ddlSponsors.DataValueField = "SponsorID";
        this.ddlSponsors.DataTextField = "SponsorName";
        this.ddlSponsors.DataBind();
    }
    private void LoadProgramType()
    {
        List<ATTProgramType> ProgramTypeLST = BLLProgramType.GetProgramTypeList(0,"Y");
        Session["ProgramTypes"] = ProgramTypeLST;
        this.ddlProgramType.DataSource = ProgramTypeLST;
        this.ddlProgramType.DataValueField = "ProgramTypeID";
        this.ddlProgramType.DataTextField = "ProgramTypeName";
        this.ddlProgramType.DataBind();
    }
    private void LoadDurationType()
    {
        List<ATTDurationType> DurationTypeLST = BLLDurationType.GetDurationTypeList(0,"Y");
        Session["DurationType"] = DurationTypeLST;
        this.ddlDurationType.DataSource = DurationTypeLST;
        this.ddlDurationType.DataValueField = "DurationTypeID";
        this.ddlDurationType.DataTextField = "DurationTypeName";
        this.DataBind();
    }
    private void LoadProgram()
    {
        List<ATTProgram> ProgramLST = BLLProgram.GetProgramList(int.Parse(Session["OrgID"].ToString()), 0,"N","N","N","N","N","N");
        Session["Programs"] = ProgramLST;
        this.lstProgram.DataSource = ProgramLST;
        this.lstProgram.DataValueField = "ProgramID";
        this.lstProgram.DataTextField = "ProgramName";
        this.DataBind();
    }

    protected void btnAddSponsors_Click(object sender, EventArgs e)
    {
        if (ddlSponsors.SelectedIndex == 0)
        {
            this.lblStatus.Text = "Add Sponsor Status";
            this.lblStatusMessage.Text = "Select Sponsor To Add";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTProgramSponsor> PrgSponsorLST = new List<ATTProgramSponsor>();
        foreach (GridViewRow gvRow in grdSponsor.Rows)
        {
            ATTProgramSponsor objEPrgSponsor = new ATTProgramSponsor
                                                                    (
                                                                        0, 0,
                                                                        int.Parse(gvRow.Cells[0].Text),
                                                                        CheckNull.NullString(gvRow.Cells[4].Text),
                                                                        CheckNull.NulldblValue(gvRow.Cells[2].Text),
                                                                        CheckNull.NullString(gvRow.Cells[3].Text),
                                                                        "",
                                                                        CheckNull.NullString(gvRow.Cells[5].Text)
                                                                    );
            objEPrgSponsor.SponsorOBJ.SponsorName = gvRow.Cells[1].Text;
            PrgSponsorLST.Add(objEPrgSponsor);
        }


        if (grdSponsor.SelectedIndex == -1)
        {
            if (PrgSponsorLST.FindIndex(delegate(ATTProgramSponsor obj)
                                        {
                                            return int.Parse(this.ddlSponsors.SelectedValue) == obj.SponsorID;
                                        }) > 0)
            {
                this.lblStatus.Text = "Add Sponsor Status";
                this.lblStatusMessage.Text = "Sponsor Already Exists";
                this.programmaticModalPopup.Show();
                return; 
            }

            ATTProgramSponsor objPrgSponsor = new ATTProgramSponsor(
                                                    0, 0,
                                                    int.Parse(this.ddlSponsors.SelectedValue),
                                                    this.txtFromDate.Text,
                                                    (this.txtBudget.Text == "") ? 0 : double.Parse(this.txtBudget.Text),
                                                    (int.Parse(this.ddlCurrency.SelectedValue) == 0) ? "" : this.ddlCurrency.SelectedItem.Text,
                                                    "",
                                                    "A");
            objPrgSponsor.SponsorOBJ.SponsorName = this.ddlSponsors.SelectedItem.Text;
            PrgSponsorLST.Add(objPrgSponsor);
        }
        else
        {
            PrgSponsorLST[grdSponsor.SelectedIndex].Budget=double.Parse( this.txtBudget.Text);
            PrgSponsorLST[grdSponsor.SelectedIndex].Currency= (this.ddlCurrency.SelectedValue=="0")?"":this.ddlCurrency.SelectedItem.Text;
            PrgSponsorLST[grdSponsor.SelectedIndex].FromDate= this.txtFromDate.Text;
            PrgSponsorLST[grdSponsor.SelectedIndex].Action = (this.grdSponsor.SelectedRow.Cells[5].Text == "A") ? "A" : "E";
        }

        
        grdSponsor.DataSource = PrgSponsorLST;
        grdSponsor.DataBind();

        this.grdSponsor.SelectedIndex = -1;
        this.ddlSponsors.SelectedIndex = -1;
        this.txtBudget.Text = "";
        this.ddlCurrency.SelectedIndex = -1;
        this.txtFromDate.Text = "";

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTProgram> ProgramLST = (List<ATTProgram>)Session["Programs"];


        ATTProgram objProgram = new ATTProgram(
                                                int.Parse(Session["OrgID"].ToString()),
                                                (this.lstProgram.SelectedIndex != -1) ? ProgramLST[lstProgram.SelectedIndex].ProgramID : 0,
                                                this.txtProgramName_RQD.Text,
                                                int.Parse(this.ddlProgramType.SelectedValue),
                                                this.txtPrgDescription.Text,
                                                (this.chkActive.Checked == true) ? "Y" : "N",
                                                this.txtLaunchDate_REQD.Text,
                                                this.txtduration.Text,
                                                int.Parse(this.ddlDurationType.SelectedValue),
                                                "",
                                                this.txtLocation.Text,
                                                (this.lstProgram.SelectedIndex != -1) ? "E" : "A"
                                             );
        ObjectValidation OV = BLLProgram.Validate(objProgram);
        if (OV.IsValid == false)
        {
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show();
            return ;
        }

        

        //PREPARES COORDINATORS TO BE SAVED
        foreach (GridViewRow gvRow in grdProgramCoordinator.Rows)
        {
            
            if (CheckNull.NullString( gvRow.Cells[6].Text) != "")
            {
                ATTProgramCoordinator objPrgCoordinator = new ATTProgramCoordinator
                                                                               (
                                                                                   int.Parse(Session["OrgID"].ToString()),
                                                                                   0,
                                                                                   int.Parse(gvRow.Cells[1].Text),
                                                                                   gvRow.Cells[3].Text,
                                                                                   double.Parse(gvRow.Cells[2].Text),
                                                                                   int.Parse(gvRow.Cells[4].Text),
                                                                                   gvRow.Cells[5].Text,
                                                                                   gvRow.Cells[6].Text
                                                                                   );
                objProgram.PrgCoordinatorLST.Add(objPrgCoordinator);
            }
            
        }

        //PREPARES SPONSORS TO BE SAVED

        foreach(GridViewRow gvRow in grdSponsor.Rows)
        {
            if (CheckNull.NullString( gvRow.Cells[5].Text) != "")
            {
                ATTProgramSponsor objPrgSponsor = new ATTProgramSponsor
                                            (
                                                int.Parse(Session["OrgID"].ToString()),
                                                0, int.Parse(gvRow.Cells[0].Text),
                                                CheckNull.NullString(gvRow.Cells[4].Text) ,
                                                CheckNull.NulldblValue( gvRow.Cells[2].Text) ,
                                                CheckNull.NullString(gvRow.Cells[3].Text) ,
                                                "",
                                                gvRow.Cells[5].Text
                                             );

                objPrgSponsor.SponsorOBJ.SponsorName = gvRow.Cells[1].Text;
                objProgram.PrgSponsorLST.Add(objPrgSponsor);
                

            }
        }


        //PREPARES SESSIONS TO BE SAVED

        foreach (GridViewRow gvRow in grdSession.Rows)
        {
            if (CheckNull.NullString(gvRow.Cells[4].Text) != "" )
            {
                objProgram.SessionLST.Add(new ATTSession
                                                        (
                                                            int.Parse(Session["OrgID"].ToString()),
                                                            0,
                                                            CheckNull.NullintValue(gvRow.Cells[0].Text) ,
                                                            gvRow.Cells[1].Text,
                                                            CheckNull.NullString(gvRow.Cells[2].Text ),
                                                            CheckNull.NullString(gvRow.Cells[3].Text ),
                                                            CheckNull.NullString(gvRow.Cells[2].Text ),
                                                            gvRow.Cells[4].Text
                                                        ));

            }
 
        }

        //PREPARES COURSES TO BE SAVED

        foreach (GridViewRow gvRow in grdCourses.Rows)
        {
            if (CheckNull.NullString(gvRow.Cells[4].Text) != "" )
            {
                objProgram.CourseLST.Add(new ATTCourse
                                                     (
                                                         int.Parse(Session["OrgID"].ToString()), 0,
                                                         CheckNull.NullintValue(gvRow.Cells[0].Text),
                                                         gvRow.Cells[1].Text,
                                                         CheckNull.NullString(gvRow.Cells[2].Text),
                                                         gvRow.Cells[3].Text,
                                                         gvRow.Cells[4].Text
                                                         ));
                                                        
            }
        }


        BLLProgram.AddProgram(objProgram);
        if (lstProgram.SelectedIndex == -1)
            ProgramLST.Add(objProgram);
        else
        {
            //EDITS THE PROGRAM
            ProgramLST[lstProgram.SelectedIndex].ProgramName = this.txtProgramName_RQD.Text;
            ProgramLST[lstProgram.SelectedIndex].ProgramTypeID = int.Parse(this.ddlProgramType.SelectedValue);
            ProgramLST[lstProgram.SelectedIndex].Active = (this.chkActive.Checked == true) ? "Y" : "N";
            ProgramLST[lstProgram.SelectedIndex].Description = this.txtPrgDescription.Text;
            ProgramLST[lstProgram.SelectedIndex].LaunchDate = this.txtLaunchDate_REQD.Text;
            ProgramLST[lstProgram.SelectedIndex].Duration = this.txtduration.Text;
            ProgramLST[lstProgram.SelectedIndex].DurationTypeID = int.Parse(this.ddlDurationType.SelectedValue);
            ProgramLST[lstProgram.SelectedIndex].Location = this.txtLocation.Text;


            //EDITS THE PROGRAM COORDINATOR LIST
            ProgramLST[lstProgram.SelectedIndex].PrgCoordinatorLST.Clear();
            foreach (GridViewRow gvRow in this.grdProgramCoordinator.Rows)
            {
                if (CheckNull.NullString(gvRow.Cells[6].Text) == "")
                {
                    ATTProgramCoordinator objPrgCoordinator = new ATTProgramCoordinator
                                                                        (
                                                                            int.Parse(Session["OrgID"].ToString()),
                                                                            int.Parse(lstProgram.SelectedValue),
                                                                            int.Parse(gvRow.Cells[1].Text),
                                                                            gvRow.Cells[3].Text,
                                                                            double.Parse(gvRow.Cells[2].Text),
                                                                            int.Parse(gvRow.Cells[4].Text),
                                                                            gvRow.Cells[5].Text,
                                                                            ""
                                                                            );
                    ProgramLST[lstProgram.SelectedIndex].PrgCoordinatorLST.Add(objPrgCoordinator);
                }
            }

            foreach(ATTProgramCoordinator obj in objProgram.PrgCoordinatorLST)
                ProgramLST[lstProgram.SelectedIndex].PrgCoordinatorLST.Add(obj);

            //EDITS THE SPONSOR LiST
            ProgramLST[lstProgram.SelectedIndex].PrgSponsorLST.Clear();
            foreach (GridViewRow gvRow in this.grdSponsor.Rows)
            {
                ATTProgramSponsor obj;
                if (gvRow.Cells[5].Text != "D")
                {
                    obj = new ATTProgramSponsor(
                                                int.Parse(Session["OrgID"].ToString()),
                                               0, int.Parse(gvRow.Cells[0].Text),
                                               CheckNull.NullString(gvRow.Cells[4].Text),
                                               CheckNull.NulldblValue(gvRow.Cells[2].Text) ,
                                               CheckNull.NullString(gvRow.Cells[3].Text ),
                                               "",
                                               ""
                                            );
                    obj.SponsorOBJ.SponsorName = gvRow.Cells[1].Text;
                    ProgramLST[lstProgram.SelectedIndex].PrgSponsorLST.Add(obj);
                }
                                                                            
            }

            //EDITS THE SESSION LIST
            ProgramLST[lstProgram.SelectedIndex].SessionLST.Clear();
            foreach (GridViewRow gvRow in this.grdSession.Rows)
            {
                if (CheckNull.NullString(gvRow.Cells[4].Text) == "" )
                {
                    ProgramLST[lstProgram.SelectedIndex].SessionLST.Add(new ATTSession
                                                        (
                                                            int.Parse(Session["OrgID"].ToString()),
                                                            0,
                                                            CheckNull.NullintValue(gvRow.Cells[0].Text),
                                                            gvRow.Cells[1].Text,
                                                            CheckNull.NullString(gvRow.Cells[2].Text),
                                                            CheckNull.NullString(gvRow.Cells[3].Text),
                                                            CheckNull.NullString(gvRow.Cells[2].Text),
                                                            ""
                                                        ));
                }
            }
            foreach (ATTSession obj in objProgram.SessionLST)
            {
                ProgramLST[lstProgram.SelectedIndex].SessionLST.Add(obj);
            }


            //EDITS COURSE LIST
            ProgramLST[lstProgram.SelectedIndex].CourseLST.Clear();
            foreach (GridViewRow gvRow in grdCourses.Rows)
            {
                if (CheckNull.NullString(gvRow.Cells[4].Text) == "" )
                {
                    ProgramLST[lstProgram.SelectedIndex].CourseLST.Add(new ATTCourse
                                                                        (
                                                                            int.Parse(Session["OrgID"].ToString()), 0,
                                                                            CheckNull.NullintValue(gvRow.Cells[0].Text) ,
                                                                            gvRow.Cells[1].Text,
                                                                            CheckNull.NullString(gvRow.Cells[2].Text),
                                                                            gvRow.Cells[3].Text,
                                                                            ""
                                                                            ));
                
                }
            }
            foreach (ATTCourse obj in objProgram.CourseLST)
            {
                ProgramLST[lstProgram.SelectedIndex].CourseLST.Add(obj);
            }

            
        }
        //END IF


        this.lstProgram.DataSource = ProgramLST;
        this.lstProgram.DataValueField = "ProgramID";
        this.lstProgram.DataTextField = "ProgramName";
        this.DataBind();

        clearAll(1);

                                                
    }
    protected void btnAddSession_Click(object sender, EventArgs e)
    {
        if (this.txtSessionName.Text=="")
        {
            this.lblStatus.Text = "Add Session Status";
            this.lblStatusMessage.Text = "Session Name Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }


        List<ATTSession> SessionLST = new List<ATTSession>();
        foreach (GridViewRow gvRow in grdSession.Rows)
        {
            SessionLST.Add(new ATTSession(
                                                    0, 0,
                                                    int.Parse(gvRow.Cells[0].Text),
                                                    CheckNull.NullString(gvRow.Cells[1].Text),
                                                    CheckNull.NullString(gvRow.Cells[2].Text),
                                                    CheckNull.NullString(gvRow.Cells[3].Text),
                                                    CheckNull.NullString(gvRow.Cells[2].Text),
                                                    CheckNull.NullString(gvRow.Cells[4].Text)
                                        ));
        }


        if (grdSession.SelectedIndex == -1)
        {
            SessionLST.Add(new ATTSession(
                                                    0, 0,
                                                    0,
                                                    this.txtSessionName.Text,
                                                    this.txtSessionFromDate.Text,
                                                    this.txtTime.Text,
                                                    this.txtSessionFromDate.Text,
                                                    "A"));
        }
        else
        {
            SessionLST[grdSession.SelectedIndex].SessionName= this.txtSessionName.Text;
            SessionLST[grdSession.SelectedIndex].FromDate = this.txtSessionFromDate.Text;
            SessionLST[grdSession.SelectedIndex].Time= this.txtTime.Text;
            SessionLST[grdSession.SelectedIndex].Action = (this.grdSession.SelectedRow.Cells[3].Text == "A") ? "A" : "E";
        }
        
        grdSession.DataSource = SessionLST;
        grdSession.DataBind();

        this.grdSession.SelectedIndex = -1;
        this.txtSessionName.Text = "";
        this.txtTime.Text = "";
        this.txtSessionFromDate.Text = "";


    }


    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
        if (this.txtCourseTitle.Text == "")
        {
            this.lblStatus.Text = "Add Course Status";
            this.lblStatusMessage.Text = "Course Title Can't be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTCourse> CourseLST = new List<ATTCourse>();
        foreach (GridViewRow gvRow in grdCourses.Rows)
        {
            CourseLST.Add(new ATTCourse(0, 0,
                                        CheckNull.NullintValue(gvRow.Cells[0].Text),
                                        gvRow.Cells[1].Text,
                                        CheckNull.NullString(gvRow.Cells[2].Text),
                                        CheckNull.NullString(gvRow.Cells[3].Text),
                                        CheckNull.NullString(gvRow.Cells[4].Text)
                                        ));
        }


        if (grdCourses.SelectedIndex == -1)
        {
            CourseLST.Add(new ATTCourse(0, 0, 0,
                                            this.txtCourseTitle.Text,
                                            this.txtCourseDescription.Text,
                                            (this.chkCourseActive.Checked == true) ? "Y" : "N",
                                            "A"
                                            ));
        }
        else
        {
            CourseLST[grdCourses.SelectedIndex].CourseTitle = this.txtCourseTitle.Text;
            CourseLST[grdCourses.SelectedIndex].Description = this.txtCourseDescription.Text;
            CourseLST[grdCourses.SelectedIndex].Active = (this.chkCourseActive.Checked == true) ? "Y" : "N";
            CourseLST[grdCourses.SelectedIndex].Action =(this.grdCourses.SelectedRow.Cells[4].Text=="A")?"A": "E";
        }

        grdCourses.SelectedIndex = -1;
        this.txtCourseTitle.Text = "";
        this.txtCourseDescription.Text = "";
        this.chkCourseActive.Checked = false;

        this.grdCourses.DataSource = CourseLST;
        this.grdCourses.DataBind();
    }


    protected void lstProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearAll(0);
        List<ATTProgram> ProgramLST = (List<ATTProgram>)Session["Programs"] ;
        this.txtProgramName_RQD.Text = ProgramLST[lstProgram.SelectedIndex].ProgramName;
        this.ddlProgramType.SelectedValue =ProgramLST[lstProgram.SelectedIndex].ProgramTypeID.ToString();
        this.chkActive.Checked = (ProgramLST[lstProgram.SelectedIndex].Active == "Y") ? true : false;
        this.txtPrgDescription.Text = ProgramLST[lstProgram.SelectedIndex].Description;
        this.txtLaunchDate_REQD.Text = ProgramLST[lstProgram.SelectedIndex].LaunchDate;
        this.txtduration.Text = ProgramLST[lstProgram.SelectedIndex].Duration;
        this.ddlDurationType.SelectedValue = ProgramLST[lstProgram.SelectedIndex].DurationTypeID.ToString();
        this.txtLocation.Text = ProgramLST[lstProgram.SelectedIndex].Location;

        //BINDS COORDINATOR DETAIL TO GRID
        this.grdProgramCoordinator.DataSource = ProgramLST[lstProgram.SelectedIndex].PrgCoordinatorLST;
        this.grdProgramCoordinator.DataBind();

        DataTable tblCoordinators = (DataTable)Session["CoordinatorTbl"];
        tblCoordinators.Rows.Clear();
        DataRow row;
        if (grdProgramCoordinator.Rows.Count > 0)
        {
            foreach (GridViewRow gvRow in grdProgramCoordinator.Rows)
            {
                row = tblCoordinators.NewRow();
                row["ProgramCoordinatorID"] = gvRow.Cells[1].Text;
                row["PID"] = gvRow.Cells[2].Text;
                row["CoordinatorName"] = gvRow.Cells[3].Text;
                row["CoordinatorTypeID"] = gvRow.Cells[4].Text;
                row["CoordinatorType"] = gvRow.Cells[5].Text;
                row["Action"] = CheckNull.NullString(gvRow.Cells[6].Text);

                try
                {
                    tblCoordinators.Rows.Add(row);
                }
                catch (Exception)
                {
                }

            }
        }


        //BINDS SPONSORS DETAIL TO GRID
        this.grdSponsor.DataSource = ProgramLST[lstProgram.SelectedIndex].PrgSponsorLST;
        this.grdSponsor.DataBind();

        //BINDS SESSION DETAIL TO GRID
        this.grdSession.DataSource = ProgramLST[lstProgram.SelectedIndex].SessionLST;
        this.grdSession.DataBind();

        //BINDS COURSE DETAIL TO GRID
        this.grdCourses.DataSource = ProgramLST[lstProgram.SelectedIndex].CourseLST;
        this.grdCourses.DataBind();

        //LOADS FACULTY MEMBERS FOR COORDINATORS
        this.LoadCoordinator(int.Parse(Session["OrgID"].ToString()), null);
        //this.LoadCoordinator(1, null);



    }

    private void clearAll(int flg)
    {
        this.txtProgramName_RQD.Text = "";
        this.ddlProgramType.SelectedIndex = -1;
        this.chkActive.Checked = false;
        this.txtPrgDescription.Text = "";
        this.txtLaunchDate_REQD.Text = "";
        this.txtduration.Text = "";
        this.ddlDurationType.SelectedIndex = -1;
        this.txtLocation.Text = "";

        this.ddlCoordinatorType.SelectedIndex = -1;
        this.grdFacultyMember.SelectedIndex = -1;
        this.grdFacultyMember.DataSource = "";
        this.grdFacultyMember.DataBind();
        this.grdProgramCoordinator.DataSource = "";
        this.grdProgramCoordinator.DataBind();

        this.ddlSponsors.SelectedIndex = -1;
        this.txtBudget.Text = "";
        this.ddlCurrency.SelectedIndex = -1;
        this.txtFromDate.Text = "";
        this.grdSponsor.DataSource = "";
        this.grdSponsor.DataBind();

        this.txtSessionName.Text = "";
        this.txtTime.Text = "";
        this.txtSessionFromDate.Text = "";
        this.grdSession.DataSource = "";
        this.grdSession.DataBind();

        this.txtCourseTitle.Text = "";
        this.txtCourseDescription.Text = "";
        this.chkCourseActive.Checked = false;
        this.grdCourses.DataSource = "";
        this.grdCourses.DataBind();


        if (flg != 0)
            lstProgram.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll(1);
    }
    protected void grdSponsor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlSponsors.SelectedValue = grdSponsor.SelectedRow.Cells[0].Text;
        this.txtBudget.Text = grdSponsor.SelectedRow.Cells[2].Text;
        this.ddlCurrency.SelectedItem.Text= (grdSponsor.SelectedRow.Cells[3].Text == "") ? "--- Select Currency ---" : grdSponsor.SelectedRow.Cells[3].Text;
        this.txtFromDate.Text = CheckNull.NullString(grdSponsor.SelectedRow.Cells[4].Text);
    }
    protected void grdSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtSessionName.Text = grdSession.SelectedRow.Cells[1].Text;
        this.txtSessionFromDate.Text = CheckNull.NullString(grdSession.SelectedRow.Cells[2].Text);
        this.txtTime.Text = CheckNull.NullString(grdSession.SelectedRow.Cells[3].Text);
    }
    protected void grdCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtCourseTitle.Text = grdCourses.SelectedRow.Cells[1].Text;
        this.txtCourseDescription.Text = CheckNull.NullString(this.grdCourses.SelectedRow.Cells[2].Text);
        this.chkCourseActive.Checked = (this.grdCourses.SelectedRow.Cells[3].Text == "Y") ? true : false;
    }
    protected void imgSearchPerson_Click(object sender, ImageClickEventArgs e)
    {
        this.LoadCoordinator(int.Parse(Session["OrgID"].ToString()), null);
    }

    void LoadCoordinator(int? orgID, int? facID)
    {
        try
        {
            this.grdFacultyMember.DataSource = BLLFacultyMember.GetFacultyMemberTable(orgID, facID);
            this.grdFacultyMember.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdCoordinator_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdFacultymember_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[10].Visible = false;
    }
    protected void btnAddCoordinator_Click(object sender, EventArgs e)
    {
        CheckBox cb;

        

        if (ddlCoordinatorType.SelectedValue == "0")
        {
            this.lblStatus.Text = "Add Coordinator to Grid";
            this.lblStatusMessage.Text = "Please Select Coordinator Type";
            this.programmaticModalPopup.Show();
            return;
        }



        DataTable tblCoordinators = (DataTable)Session["CoordinatorTbl"];
        tblCoordinators.Rows.Clear();
        DataRow row;
        if (grdProgramCoordinator.Rows.Count > 0)
        {
            foreach (GridViewRow gvRow in grdProgramCoordinator.Rows)
            {
                    row = tblCoordinators.NewRow();
                    row["ProgramCoordinatorID"] = gvRow.Cells[1].Text;
                    row["PID"] = gvRow.Cells[2].Text;
                    row["CoordinatorName"] = gvRow.Cells[3].Text;
                    row["CoordinatorTypeID"] = gvRow.Cells[4].Text;
                    row["CoordinatorType"] = gvRow.Cells[5].Text;
                    row["Action"] = CheckNull.NullString(gvRow.Cells[6].Text);

                try
                {
                    tblCoordinators.Rows.Add(row);
                }
                catch (Exception)
                {
                }

            }
        }

        
        
        
        
        foreach (GridViewRow gvRow in grdFacultyMember.Rows)
        {
            cb =(CheckBox) gvRow.FindControl("chkSelect");
            if (cb.Checked == true)
            {
                cb.Checked = false;
                row = tblCoordinators.NewRow();
                
                row["ProgramCoordinatorID"] = 0;
                row["PID"] = gvRow.Cells[4].Text;
                row["CoordinatorName"] = gvRow.Cells[5].Text;
                row["CoordinatorTypeID"] = ddlCoordinatorType.SelectedValue;
                row["CoordinatorType"] = ddlCoordinatorType.SelectedItem.Text;
                row["Action"] = "A";
        
                try
                {
                    tblCoordinators.Rows.Add(row);
                }
                catch (Exception)
                {
                }

                //tblSponsors.DefaultView.Sort = "SponsorName";

                
 
            }
        }
        
        grdProgramCoordinator.DataSource = tblCoordinators;
        grdProgramCoordinator.DataBind();
        this.ddlCoordinatorType.SelectedIndex = -1;
        this.grdProgramCoordinator.SelectedIndex = -1;
        this.grdFacultyMember.SelectedIndex = -1;
        
        Session["CoordinatorTbl"] = tblCoordinators;

        foreach (GridViewRow gvRow in grdProgramCoordinator.Rows)
        {
            if (gvRow.Cells[6].Text == "D")
                gvRow.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void grdProgramCoordinator_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["CoordinatorTbl"];


        if (grdProgramCoordinator.SelectedRow.Cells[6].Text == "A")
            dt.Rows.RemoveAt(grdProgramCoordinator.SelectedIndex);
        else
        {
            dt.Rows[grdProgramCoordinator.SelectedIndex][5] = "D";
            
            
        }

        grdProgramCoordinator.DataSource = dt;
        grdProgramCoordinator.DataBind();
        foreach (GridViewRow gvRow in grdProgramCoordinator.Rows)
        {
            if (gvRow.Cells[6].Text=="D")
                gvRow.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void grdProgramCoordinator_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;

    }
}
