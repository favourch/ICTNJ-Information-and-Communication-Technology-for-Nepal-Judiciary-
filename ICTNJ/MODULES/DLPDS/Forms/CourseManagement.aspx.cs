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

using PCS.DLPDS.ATT;
using PCS.DLPDS.BLL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_Forms_CourseManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID; 
        if (user.MenuList.ContainsKey("Course Management") == true)
        {
            if (this.Page.IsPostBack == false) LoadProgram();
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    private void LoadProgram()
    {
        List<ATTProgram> ProgramLST = BLLProgram.GetProgramList(int.Parse(Session["OrgID"].ToString()), 0,"Y","N","N","N","N","N");
        Session["Programs"] = ProgramLST;
        this.ddlPrograms.DataSource = ProgramLST;
        this.ddlPrograms.DataValueField = "ProgramID";
        this.ddlPrograms.DataTextField = "ProgramName";
        this.ddlPrograms.DataBind();
    }
   
    protected void ddlPrograms_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTProgram> ProgramLST = (List<ATTProgram>)Session["Programs"];


        //BINDS SESSION DETAIL TO DROPDOWNLIST
        this.lstSession.DataSource = ProgramLST[ddlPrograms.SelectedIndex].SessionLST;
        this.lstSession.DataValueField = "SessionID";
        this.lstSession.DataTextField = "FullSessionName";
        this.lstSession.DataBind();

        ////BINDS COURSE DETAIL TO DROPDOWNLIST
        //this.chklstCourses.DataSource = ProgramLST[ddlPrograms.SelectedIndex].CourseLST;
        //this.chklstCourses.DataValueField = "CourseID";
        //this.chklstCourses.DataTextField = "CourseTitle";
        //this.chklstCourses.DataBind();


        //BINDS COURSE DETAIL TO DROPDOWNLIST
        this.grdCourses.DataSource = ProgramLST[ddlPrograms.SelectedIndex].CourseLST;
        this.grdCourses.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlPrograms.SelectedIndex == 0)
        {
            this.lblStatus.Text = "Save Error";
            this.lblStatusMessage.Text = "Please Select Program";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.lstSession.SelectedIndex == -1)
        {
            
            this.lblStatusMessage.Text = "Save Error";
            this.lblStatusMessage.Text = "Please Select a Session To Assign Course";
            this.programmaticModalPopup.Show();
            return;
        }
        
        int count=0;
        foreach (GridViewRow gvRow in this.grdCourses.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
                count += 1;
        }
        if (count == 0)
        {
            this.lblStatus.Text = "Save Error";
            this.lblStatusMessage.Text = "Please Select a Course To be Assigned in Session";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTSessionCourse> LstSessionCourse = new List<ATTSessionCourse>();
        List<ATTProgram> ProgramLST = (List<ATTProgram>)Session["Programs"];

        ATTSession SessionLST = ProgramLST[ddlPrograms.SelectedIndex].SessionLST[lstSession.SelectedIndex];
        
        try
        {
            foreach (GridViewRow  row in grdCourses.Rows)
            {
                CheckBox CBSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
                if (CBSelect.Checked == true && row.Cells[3].Text != "E")
                {
                    ATTSessionCourse ObjSessionCourse = new ATTSessionCourse
                                                                          (
                                                                            (int)Session["OrgID"],
                                                                            int.Parse(this.ddlPrograms.SelectedValue.ToString()),
                                                                            int.Parse(this.lstSession.SelectedValue.ToString()),
                                                                            int.Parse(row.Cells[1].Text.ToString()),
                                                                            Session["NepDate"].ToString(),
                                                                            "",
                                                                            "",
                                                                            "A"
                                                                          );
                    LstSessionCourse.Add(ObjSessionCourse);
                }
                else if (CBSelect.Checked == false && row.Cells[3].Text == "E")
                {
                    ATTSessionCourse ObjSessionCourse = new ATTSessionCourse
                                                                      (
                                                                        (int)Session["OrgID"],
                                                                        int.Parse(this.ddlPrograms.SelectedValue.ToString()),
                                                                        int.Parse(this.lstSession.SelectedValue.ToString()),
                                                                        int.Parse(row.Cells[1].Text.ToString()),
                                                                        Session["NepDate"].ToString(),
                                                                        "",
                                                                        "",
                                                                        "D"
                                                                      );
                    LstSessionCourse.Add(ObjSessionCourse);
                }
            }

            if (BLLSessionCourse.SaveSessionCourse(LstSessionCourse) == true)
            {
                foreach (GridViewRow row in grdCourses.Rows)
                {
                    CheckBox CBSelect = (CheckBox)row.Cells[0].FindControl("chkSelect");
                    if (CBSelect.Checked == true && row.Cells[3].Text != "E")
                    {
                        ATTSessionCourse ObjSessionCourse = new ATTSessionCourse
                                                                              (
                                                                                (int)Session["OrgID"],
                                                                                int.Parse(this.ddlPrograms.SelectedValue.ToString()),
                                                                                int.Parse(this.lstSession.SelectedValue.ToString()),
                                                                                int.Parse(row.Cells[1].Text.ToString()),
                                                                                Session["NepDate"].ToString(),
                                                                                "",
                                                                                "",
                                                                                "E"
                                                                              );
                        SessionLST.LstSessionCourse.Add(ObjSessionCourse);
                    }
                    else if (CBSelect.Checked == false && row.Cells[3].Text == "E")
                    {
                        SessionLST.LstSessionCourse.RemoveAll(delegate(ATTSessionCourse obj)
                                                                        {
                                                                            return obj.OrgID == (int)Session["OrgID"] &&
                                                                                    obj.ProgramID == int.Parse(this.ddlPrograms.SelectedValue.ToString()) &&
                                                                                    obj.SessionID == int.Parse(this.lstSession.SelectedValue.ToString()) &&
                                                                                    obj.CourseID == int.Parse(row.Cells[1].Text.ToString());
                                                                         });
                        //ATTSessionCourse ObjSessionCourse = new ATTSessionCourse
                        //                                                  (
                        //                                                    (int)Session["OrgID"],
                        //                                                    int.Parse(this.ddlPrograms.SelectedValue.ToString()),
                        //                                                    int.Parse(this.lstSession.SelectedValue.ToString()),
                        //                                                    int.Parse(row.Cells[1].Text.ToString()),
                        //                                                    "12/12/2010",
                        //                                                    "",
                        //                                                    "",
                        //                                                    "D"
                        //                                                  );
                        //LstSessionCourse.Add(ObjSessionCourse);
                    }
                }

                
 
            }

            ddlPrograms.SelectedIndex = -1;
            lstSession.Items.Clear();
            grdCourses.DataSource = "";
            grdCourses.DataBind();

        }
        catch (Exception ex)
        {
            
            throw ex;
        }

    }
    protected void lstSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTProgram> ProgramLST = (List<ATTProgram>)Session["Programs"];
        
        //BINDS COURSE DETAIL TO DROPDOWNLIST
        this.grdCourses.DataSource = ProgramLST[ddlPrograms.SelectedIndex].CourseLST;
        this.grdCourses.DataBind();
        CheckBox chkSelect;
        foreach (ATTSessionCourse objSessionCourse in ProgramLST[ddlPrograms.SelectedIndex].SessionLST[lstSession.SelectedIndex].LstSessionCourse)
        {
            foreach (GridViewRow gvRow in grdCourses.Rows)
            {

                if (objSessionCourse.CourseID == int.Parse(gvRow.Cells[1].Text))
                {
                    chkSelect =(CheckBox) gvRow.FindControl("chkSelect");
                    chkSelect.Checked = true;

                    gvRow.Cells[3].Text = "E";
                }
            }
        }

    }
    protected void grdCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox cb;
        //if(grdCourses.SelectedRow.Cells[3].Text = "E";
        cb=(CheckBox)grdCourses.SelectedRow.FindControl("chkSelect");
        cb.Checked = false;
    }
    protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void grdCourses_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        
    }
    protected void grdCourses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlPrograms.SelectedIndex = -1;
        lstSession.Items.Clear();
        grdCourses.DataSource = "";
        grdCourses.DataBind();
    }
}
