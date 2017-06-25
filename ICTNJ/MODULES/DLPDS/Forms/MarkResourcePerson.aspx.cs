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
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_Forms_MarkResourcePerson : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("Resource Person Marks") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadProgram(user.OrgID);
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
        





        if (this.IsPostBack == false)
        {
            

        }


    }

    void LoadProgram(int OrgID)
    {
        try
        {
            Session["DLPDS_Program_List"] = BLLProgram.GetProgramList(OrgID, 0, "Y","N","N","Y","Y","Y");
            this.ddlProgram_Rqd.DataSource = Session["DLPDS_Program_List"];
            this.ddlProgram_Rqd.DataTextField = "ProgramName";
            this.ddlProgram_Rqd.DataValueField = "ProgramID";
            this.ddlProgram_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Page loading...";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    

    protected void ddlProgram_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;

        this.ddlSession_Rqd.DataSource = lstSession;
        this.ddlSession_Rqd.DataTextField = "FullSessionName";
        this.ddlSession_Rqd.DataValueField = "SessionID";
        this.ddlSession_Rqd.DataBind();

       // this.ClearME();
        this.ddlCourse_Rqd.DataSource = "";
        this.ddlCourse_Rqd.DataBind();
    }
    protected void ddlSession_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> lstSC = lstSession[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;

        this.ddlCourse_Rqd.DataSource = lstSC;
        this.ddlCourse_Rqd.DataTextField = "CourseName";
        this.ddlCourse_Rqd.DataValueField = "CourseID";
        this.ddlCourse_Rqd.DataBind();

        List<ATTSessionCourseMember> SCMemberLST= BLLSessionCourseMember.GetSessionCourseMemberForMarks(int.Parse(Session["OrgID"].ToString()), int.Parse(this.ddlProgram_Rqd.SelectedValue), int.Parse(this.ddlSession_Rqd.SelectedValue), null);
        this.grdFacultymember.DataSource = SCMemberLST;
        this.grdFacultymember.DataBind();

        foreach (GridViewRow gvRow in this.grdFacultymember.Rows)
        {
            ((TextBox)gvRow.FindControl("txtMarksObtained")).Text = (gvRow.Cells[4].Text == "0") ? "" : gvRow.Cells[4].Text;
        }

        //this.ClearME();
    }
    protected void ddlCourse_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.ClearME();
        this.LoadAssignedMember();
    }

    void LoadAssignedMember()
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> lstSC = lstSession[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;
        List<ATTSessionCourseMember> lstMem = lstSC[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMember;

        grdFacultymember.DataSource = lstMem;
        grdFacultymember.DataBind();
        //ATTSessionCourseMember member = new ATTSessionCourseMember();

        //foreach (GridViewRow grow in this.grdFacultymember.Rows)
        //{
        //    member.OrgID = int.Parse(grow.Cells[1].Text);
        //    member.FacultyID = int.Parse(grow.Cells[2].Text);
        //    member.PID = int.Parse(grow.Cells[4].Text);
        //    member.FromDate = grow.Cells[6].Text;

        //    bool assigned;
        //    assigned = lstMem.Exists
        //                        (
        //                            delegate(ATTSessionCourseMember mem)
        //                            {
        //                                return mem.OrgID == member.OrgID &&
        //                                    mem.FacultyID == member.FacultyID &&
        //                                    mem.PID == member.PID &&
        //                                    mem.FromDate == member.FromDate;
        //                            }
        //                        );

        //    ((CheckBox)grow.FindControl("chkSelect")).Checked = assigned;
        //    if (assigned == true)
        //        grow.Cells[10].Text = "Y";
        //    else
        //        grow.Cells[10].Text = "N";
        //}
    }
    protected void grdFacultymember_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (this.ddlProgram_Rqd.SelectedIndex == 0)
        {
            this.lblStatus.Text = "Save Error";
            this.lblStatusMessage.Text = "Please Select Program";
            this.programmaticModalPopup.Show();
            return;
        }
        int ? courseID;
        if(this.ddlCourse_Rqd.SelectedIndex==0)
            courseID=null;
        else
            courseID=int.Parse(this.ddlCourse_Rqd.SelectedValue);
        List<ATTSessionCourseMember> CMMarksLST = new List<ATTSessionCourseMember>();
        
        foreach (GridViewRow gvRow in this.grdFacultymember.Rows)
        {
            if (((TextBox)gvRow.FindControl("txtMarksObtained")).Text != "")
            {
                CMMarksLST.Add(new ATTSessionCourseMember
                                                            (
                                                                int.Parse(Session["OrgID"].ToString()),
                                                                int.Parse(this.ddlProgram_Rqd.Text),
                                                                int.Parse(this.ddlSession_Rqd.Text),
                                                                courseID,
                                                                int.Parse(gvRow.Cells[0].Text),
                                                                int.Parse(gvRow.Cells[1].Text),
                                                                "", "",
                                                                int.Parse(((TextBox)gvRow.FindControl("txtMarksObtained")).Text)
                                                                ));
                                                                
            }
        }

        BLLSessionCourseMember.UpdateResourcePersonMarks(CMMarksLST);

        ClearAll();


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearAll();
    }

    private void ClearAll()
    {
        this.ddlProgram_Rqd.SelectedIndex = -1;
        this.ddlSession_Rqd.DataSource = "";
        this.ddlSession_Rqd.DataBind();

        this.ddlCourse_Rqd.DataSource = "";
        this.ddlCourse_Rqd.DataBind();


        this.grdFacultymember.DataSource = "";
        this.grdFacultymember.DataBind();
    }
}
