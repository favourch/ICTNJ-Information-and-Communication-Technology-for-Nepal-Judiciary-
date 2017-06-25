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

class CourseMaterialControls
{
    private FileUpload _FileUploader;
    public FileUpload FileUploader
    {
        get { return this._FileUploader; }
        set { this._FileUploader = value; }
    }

    private CheckBox _Checkbox;
    public CheckBox Checkbox
    {
        get { return this._Checkbox; }
        set { this._Checkbox = value; }
    }

    private LinkButton _FileLink;
    public LinkButton FileLink
    {
        get { return this._FileLink; }
        set { this._FileLink = value; }
    }

    public CourseMaterialControls(FileUpload fup, CheckBox chk, LinkButton lnk)
    {
        this.FileUploader = fup;
        this.Checkbox = chk;
        this.FileLink = lnk;
    }
}

public partial class MODULES_DLPDS_Forms_CourseMemberAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }


        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("Assign Material/Member") == true)
        {
            if (this.Page.IsPostBack == false)
            {
                this.LoadProgram(user.OrgID);
                this.LoadOrganization();
                this.LoadFacultyMember(user.OrgID, null);
            }
            
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
       
        
        if (this.IsPostBack == false)
        {
        
            //Session["DLPDS_SessionCourse"] = new ATTSessionCourse();
        }
    }

    void SetAttributeToCheckbox()
    {
        this.chk1.Attributes.Add("onclick", "ActivateFup('" + this.fup1.ClientID + "')");
        this.chk2.Attributes.Add("onclick", "ActivateFup('" + this.fup2.ClientID + "')");
        this.chk3.Attributes.Add("onclick", "ActivateFup('" + this.fup3.ClientID + "')");
        this.chk4.Attributes.Add("onclick", "ActivateFup('" + this.fup4.ClientID + "')");
        this.chk5.Attributes.Add("onclick", "ActivateFup('" + this.fup5.ClientID + "')");
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrganization();
            lstOrg.Insert(0, new ATTOrganization("%fGgÚxf];", "", "", 0));
            this.ddlOrg.DataSource = lstOrg;
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadFaculty()
    {
        try
        {
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void SetAttachmentDatatable()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("OrgID"));
        tbl.Columns.Add(new DataColumn("ProgramID"));
        tbl.Columns.Add(new DataColumn("SessionID"));
        tbl.Columns.Add(new DataColumn("CourseID"));
        tbl.Columns.Add(new DataColumn("MaterialID"));
        tbl.Columns.Add(new DataColumn("MaterialName"));
        tbl.Columns.Add(new DataColumn("MaterialByte"));
        tbl.Columns.Add(new DataColumn("MaterialTypeID"));
        tbl.Columns.Add(new DataColumn("Action"));

        Session["DLPDS_FileTable"] = tbl;
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

        this.ClearME();
        this.ddlCourse_Rqd.DataSource = "";
        this.ddlCourse_Rqd.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlProgram_Rqd.SelectedIndex <= 0)
        {
            this.lblStatus.Text = "Save status";
            this.lblStatusMessage.Text = "Please select program from list.";
            this.ddlProgram_Rqd.Focus();
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlProgram_Rqd.SelectedIndex <= 0)
        {
            this.lblStatus.Text = "Save status";
            this.lblStatusMessage.Text = "Please select session from list.";
            this.ddlSession_Rqd.Focus();
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlProgram_Rqd.SelectedIndex <= 0)
        {
            this.lblStatus.Text = "Save status";
            this.lblStatusMessage.Text = "Please select course from list.";
            this.ddlSession_Rqd.Focus();
            this.programmaticModalPopup.Show(); return;
        }

        List<ATTProgram> programLst = (List<ATTProgram>)Session["DLPDS_Program_List"];
        List<ATTSession> sessionLst = programLst[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> sessionCourseLst = sessionLst[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;

        ATTSessionCourse SC = new ATTSessionCourse();

        List<CourseMaterialControls> CMCList = new List<CourseMaterialControls>();

        CMCList.Add(new CourseMaterialControls(this.fup1, this.chk1, this.lnkFile1));
        CMCList.Add(new CourseMaterialControls(this.fup2, this.chk2, this.lnkFile2));
        CMCList.Add(new CourseMaterialControls(this.fup3, this.chk3, this.lnkFile3));
        CMCList.Add(new CourseMaterialControls(this.fup4, this.chk4, this.lnkFile4));
        CMCList.Add(new CourseMaterialControls(this.fup5, this.chk5, this.lnkFile5));

        foreach (CourseMaterialControls cmc in CMCList)
        {
            if (cmc.FileLink.Text == "Filename" && cmc.FileUploader.HasFile == true)
            {
                SC.LstSessionCourseMaterial.Add
                (
                    new ATTSessionCourseMaterial
                    (
                        int.Parse( Session["OrgID"].ToString()),
                        int.Parse(this.ddlProgram_Rqd.SelectedValue),
                        int.Parse(this.ddlSession_Rqd.SelectedValue),
                        int.Parse(this.ddlCourse_Rqd.SelectedValue),
                        0,
                        cmc.FileUploader.FileName,
                        null,
                        "A",
                        cmc.FileUploader
                    )
                );
            }
            else if (cmc.FileLink.Text != "Filename" && cmc.Checkbox.Checked == true)
            {
                SC.LstSessionCourseMaterial.Add
                (
                    new ATTSessionCourseMaterial
                    (
                        int.Parse(Session["OrgID"].ToString()),
                        int.Parse(this.ddlProgram_Rqd.SelectedValue),
                        int.Parse(this.ddlSession_Rqd.SelectedValue),
                        int.Parse(this.ddlCourse_Rqd.SelectedValue),
                        int.Parse(cmc.FileLink.CommandArgument),
                        cmc.FileLink.Text,
                        null,
                        "D",
                        cmc.FileUploader
                    )
                );
            }
            else if (cmc.FileLink.Text != "Filename" && cmc.FileUploader.HasFile == false)
            {
                SC.LstSessionCourseMaterial.Add
                (
                    new ATTSessionCourseMaterial
                    (
                        int.Parse(Session["OrgID"].ToString()),
                        int.Parse(this.ddlProgram_Rqd.SelectedValue),
                        int.Parse(this.ddlSession_Rqd.SelectedValue),
                        int.Parse(this.ddlCourse_Rqd.SelectedValue),
                        int.Parse(cmc.FileLink.CommandArgument),
                        cmc.FileLink.Text,
                        null,
                        "N",
                        cmc.FileUploader
                    )
                );
            }
        }
            
        #region "Commented code of Course material items"
        //List<FileUpload> lstFup = new List<FileUpload>();

        //if (this.fup1.HasFile == true)
        //    lstFup.Add(this.fup1);
        //if (this.fup2.HasFile == true)
        //    lstFup.Add(this.fup2);
        //if (this.fup3.HasFile == true)
        //    lstFup.Add(this.fup3);
        //if (this.fup4.HasFile == true)
        //    lstFup.Add(this.fup4);
        //if (this.fup5.HasFile == true)
        //    lstFup.Add(this.fup5);

        //foreach (FileUpload fup in lstFup)
        //{
        //    SC.LstSessionCourseMaterial.Add
        //    (
        //        new ATTSessionCourseMaterial
        //        (
        //            1,
        //            int.Parse(this.ddlProgram_Rqd.SelectedValue),
        //            int.Parse(this.ddlSession_Rqd.SelectedValue),
        //            int.Parse(this.ddlCourse_Rqd.SelectedValue),
        //            0,
        //            fup.FileName,
        //            null,
        //            "A"
        //        )
        //    );
        //}
        #endregion

        bool assigned;

        foreach (GridViewRow grow in this.grdFacultymember.Rows)
        {
            CheckBox chk = ((CheckBox)grow.FindControl("chkSelect"));

            if (grow.Cells[10].Text == "Y")
                assigned = true;
            else
                assigned = false;

            #region"comment"
            //assigned = sessionCourseLst[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMember.Exists
            //                        (
            //                            delegate(ATTSessionCourseMember mem)
            //                            {
            //                                return mem.OrgID == int.Parse(grow.Cells[1].Text) &&
            //                                    //mem.ProgramID == int.Parse(this.ddlProgram_Rqd.SelectedValue) &&
            //                                    //mem.SessionID == int.Parse(this.ddlSession_Rqd.SelectedValue) &&
            //                                    //mem.CourseID == int.Parse(this.ddlCourse_Rqd.SelectedValue) &&
            //                                    mem.FacultyID == int.Parse(grow.Cells[2].Text) &&
            //                                    mem.PID == int.Parse(grow.Cells[4].Text) &&
            //                                    mem.FromDate == grow.Cells[6].Text;
            //                                    //mem.AssignmentDate == grow.Cells[7].Text;
            //                            }
            //                        );
            #endregion

            if (chk.Checked == true)
            {
                ATTSessionCourseMember member = new ATTSessionCourseMember();
                member.OrgID = int.Parse(grow.Cells[1].Text);
                member.ProgramID = int.Parse(this.ddlProgram_Rqd.SelectedValue);
                member.SessionID = int.Parse(this.ddlSession_Rqd.SelectedValue);
                member.CourseID = int.Parse(this.ddlCourse_Rqd.SelectedValue);
                member.FacultyID = int.Parse(grow.Cells[2].Text);
                member.PID = int.Parse(grow.Cells[4].Text); ;
                member.FromDate = grow.Cells[6].Text;
                member.AssignmentDate = grow.Cells[6].Text;
                member.ToDate = grow.Cells[7].Text;

                #region "delegate exists() commented"
                //assigned = lstSC.Exists
                //                    (
                //                        delegate(ATTSessionCourseMember mem)
                //                        {
                //                            return mem.OrgID == member.OrgID &&
                //                                mem.ProgramID == member.ProgramID &&
                //                                mem.SessionID == member.SessionID &&
                //                                mem.CourseID == member.CourseID &&
                //                                mem.FacultyID == member.FacultyID &&
                //                                mem.PID == member.PID &&
                //                                mem.FromDate == member.FromDate &&
                //                                mem.AssignmentDate == member.AssignmentDate;
                //                        }
                //                    );
                #endregion

                if (assigned == true)
                    member.Action = "N";
                else
                    member.Action = "A";

                SC.LstSessionCourseMember.Add(member);
            }
            else
            {
                if (assigned == true)
                {
                    ATTSessionCourseMember member = new ATTSessionCourseMember();
                    member.OrgID = int.Parse(grow.Cells[1].Text);
                    member.ProgramID = int.Parse(this.ddlProgram_Rqd.SelectedValue);
                    member.SessionID = int.Parse(this.ddlSession_Rqd.SelectedValue);
                    member.CourseID = int.Parse(this.ddlCourse_Rqd.SelectedValue);
                    member.FacultyID = int.Parse(grow.Cells[2].Text);
                    member.PID = int.Parse(grow.Cells[4].Text); ;
                    member.FromDate = grow.Cells[6].Text;
                    member.AssignmentDate = grow.Cells[6].Text;
                    member.ToDate = grow.Cells[7].Text;
                    member.Action = "D";

                    SC.LstSessionCourseMember.Add(member);
                }

            }
        }

        #region "Commented part"
        //DataTable tbl = (DataTable)Session["DLPDS_FileTable"];

        //foreach (DataRow row in tbl.Rows)
        //{
        //    object raw = row["MaterialByte"];
        //    SC.LstSessionCourseMaterial.Add
        //    (
        //        new ATTSessionCourseMaterial
        //        (
        //            int.Parse(row["OrgID"].ToString()),
        //            int.Parse(row["ProgramID"].ToString()),
        //            int.Parse(row["SessionID"].ToString()),
        //            int.Parse(row["CourseID"].ToString()),
        //            int.Parse(row["MaterialID"].ToString()),
        //            row["MaterialName"].ToString(),
        //            (byte[])row["MaterialByte"],
        //            null,
        //            row["Action"].ToString()
        //        )
        //    );
        //}
        #endregion

        try
        {
            foreach (ATTSessionCourseMaterial mat in SC.LstSessionCourseMaterial)
            {
                if (mat.Action == "A")
                    ((FileUpload)mat.FileUploader).SaveAs(Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\" + mat.MaterialName);
            }

            BLLSessionCourse.AddSessionCourseMaterialNMember(SC);

            foreach (ATTSessionCourseMaterial mat in SC.LstSessionCourseMaterial)
            {
                if (mat.Action == "D")
                    if (System.IO.File.Exists(Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\" + mat.MaterialName) == true)
                        System.IO.File.Delete(Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\" + mat.MaterialName);
            }
            SC.LstSessionCourseMaterial.RemoveAll
                (
                    delegate(ATTSessionCourseMaterial m)
                    {
                        return m.Action == "D";
                    }
                );

            sessionCourseLst[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMaterial = SC.LstSessionCourseMaterial;

            SC.LstSessionCourseMember.RemoveAll
                                                (
                                                    delegate(ATTSessionCourseMember m)
                                                    {
                                                        return m.Action == "D";
                                                    }
                                                );
            sessionCourseLst[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMember = SC.LstSessionCourseMember;

            this.ClearME();

            this.lblStatus.Text = "Save status";
            this.lblStatusMessage.Text = "Course material and member has been saved.";

            this.ddlProgram_Rqd.SelectedIndex = 0;
            this.ddlSession_Rqd.SelectedIndex = 0;
            this.ddlCourse_Rqd.SelectedIndex = 0;

            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            foreach (ATTSessionCourseMaterial mat in SC.LstSessionCourseMaterial)
            {
                if (mat.Action == "D")
                    if (System.IO.File.Exists(Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\" + mat.MaterialName) == true)
                        System.IO.File.Delete(Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\" + mat.MaterialName);
            }

            this.lblStatus.Text = "Save status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        finally
        {
            //Session["DLPDS_SessionCourse"] = new ATTSessionCourse();
        }
    }

    void GetCheckedMemberList()
    {
    }

    void ClearME()
    {
        foreach (GridViewRow row in this.grdFacultymember.Rows)
        {
            ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            row.Cells[10].Text = "N";
        }

        this.lnkFile1.Text = "Filename";
        this.lnkFile2.Text = "Filename";
        this.lnkFile3.Text = "Filename";
        this.lnkFile4.Text = "Filename";
        this.lnkFile5.Text = "Filename";

        this.lnkFile1.Enabled = false;
        this.lnkFile2.Enabled = false;
        this.lnkFile3.Enabled = false;
        this.lnkFile4.Enabled = false;
        this.lnkFile5.Enabled = false;

        this.fup1.Enabled = true;
        this.fup2.Enabled = true;
        this.fup3.Enabled = true;
        this.fup4.Enabled = true;
        this.fup5.Enabled = true;

        this.chk1.Enabled = true;
        this.chk1.Checked = false;
        this.chk2.Enabled = true;
        this.chk2.Checked = false;
        this.chk3.Enabled = true;
        this.chk3.Checked = false;
        this.chk4.Enabled = true;
        this.chk4.Checked = false;
        this.chk5.Enabled = true;
        this.chk5.Checked = false;

        this.Image1.Visible = false;
        this.Image2.Visible = false;
        this.Image3.Visible = false;
        this.Image4.Visible = false;
        this.Image5.Visible = false;
    }

    protected void ddlSession_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> lstSC = lstSession[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;

        this.ddlCourse_Rqd.DataSource = lstSC;
        this.ddlCourse_Rqd.DataTextField = "CourseName";
        this.ddlCourse_Rqd.DataValueField = "CourseID";
        this.ddlCourse_Rqd.DataBind();

        this.ClearME();
    }

    protected void btnAddFile_Click(object sender, EventArgs e)
    {
        #region "Comented code for adding material to gridview version"
        //if (this.fup1.HasFile == false)
        //    return;

        //ATTSessionCourse SC = new ATTSessionCourse();

        //SC.LstSessionCourseMaterial.Add
        //    (
        //        new ATTSessionCourseMaterial
        //        (
        //            1,
        //            int.Parse(this.ddlProgram_Rqd.SelectedValue),
        //            int.Parse(this.ddlSession_Rqd.SelectedValue),
        //            int.Parse(this.ddlCourse_Rqd.SelectedValue),
        //            0,
        //            this.fup1.FileName,
        //            this.fup1.FileBytes,
        //            null,
        //            "A",
        //            Server.MapPath("~") + "\\MODULES\\DLPDS\\COURSEMATERIAL\\"
        //        )
        //    );

        //this.grdAttachment.DataSource = SC.LstSessionCourseMaterial;
        //this.grdAttachment.DataBind();

        //DataTable tbl = (DataTable)Session["DLPDS_FileTable"];

        //DataRow row = tbl.NewRow();
        //row["OrgID"] = 1;
        //row["ProgramID"] = this.ddlProgram_Rqd.SelectedValue;
        //row["SessionID"] = this.ddlSession_Rqd.SelectedValue;
        //row["CourseID"] = this.ddlCourse_Rqd.SelectedValue;
        //row["MaterialID"] = 0;
        //row["MaterialName"] = this.fup1.FileName;
        //row["MaterialByte"] = this.fup1.FileBytes;
        //row["MaterialTypeID"] = null;
        //row["Action"] = "A";
        //tbl.Rows.Add(row);

        //this.grdAttachment.DataSource = tbl;
        //this.grdAttachment.DataBind();
        #endregion
    }

    protected void ddlCourse_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearME();
        this.LoadExistingCourseMaterial();
        this.LoadAssignedMember();
    }

    void LoadAssignedMember()
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> lstSC = lstSession[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;
        List<ATTSessionCourseMember> lstMem = lstSC[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMember;

        ATTSessionCourseMember member = new ATTSessionCourseMember();

        foreach (GridViewRow grow in this.grdFacultymember.Rows)
        {
            member.OrgID = int.Parse(grow.Cells[1].Text);
            member.FacultyID = int.Parse(grow.Cells[2].Text);
            member.PID = int.Parse(grow.Cells[4].Text);
            member.FromDate = grow.Cells[6].Text;

            bool assigned;
            assigned = lstMem.Exists
                                (
                                    delegate(ATTSessionCourseMember mem)
                                    {
                                        return mem.OrgID == member.OrgID &&
                                            mem.FacultyID == member.FacultyID &&
                                            mem.PID == member.PID &&
                                            mem.FromDate == member.FromDate;
                                    }
                                );

            ((CheckBox)grow.FindControl("chkSelect")).Checked = assigned;
            if (assigned == true)
                grow.Cells[10].Text = "Y";
            else
                grow.Cells[10].Text = "N";
        }
    }

    void LoadExistingCourseMaterial()
    {
        List<ATTSession> lstSession = ((List<ATTProgram>)Session["DLPDS_Program_List"])[this.ddlProgram_Rqd.SelectedIndex].SessionLST;
        List<ATTSessionCourse> lstSC = lstSession[this.ddlSession_Rqd.SelectedIndex].LstSessionCourse;
        List<ATTSessionCourseMaterial> lstMat = lstSC[this.ddlCourse_Rqd.SelectedIndex].LstSessionCourseMaterial;

        if (lstMat.Count >= 1)
        {
            this.lnkFile1.Text = lstMat[0].MaterialName;
            this.lnkFile1.CommandArgument = lstMat[0].MaterialID.ToString();
            this.lnkFile1.Enabled = true;
            this.Image1.Visible = true;
            this.fup1.Enabled = false;
        }
        else
        {
            this.lnkFile1.Text = "Filename";
            this.lnkFile1.Enabled = false;
            this.chk1.Enabled = false;
            this.Image1.Visible = false;
        }

        if (lstMat.Count >= 2)
        {
            this.lnkFile2.Text = lstMat[1].MaterialName;
            this.lnkFile2.CommandArgument = lstMat[1].MaterialID.ToString();
            this.lnkFile2.Enabled = true;
            this.Image2.Visible = true;
            this.fup2.Enabled = false;
        }
        else
        {
            this.lnkFile2.Text = "Filename";
            this.lnkFile2.Enabled = false;
            this.chk2.Enabled = false;
            this.Image2.Visible = false;
        }

        if (lstMat.Count >= 3)
        {
            this.lnkFile3.Text = lstMat[2].MaterialName;
            this.lnkFile3.CommandArgument = lstMat[2].MaterialID.ToString();
            this.lnkFile3.Enabled = true;
            this.Image3.Visible = true;
            this.fup3.Enabled = false;
        }
        else
        {
            this.lnkFile3.Text = "Filename";
            this.lnkFile3.Enabled = false;
            this.Image4.Visible = true;
            this.chk3.Enabled = false;
        }

        if (lstMat.Count >= 4)
        {
            this.lnkFile4.Text = lstMat[3].MaterialName;
            this.lnkFile4.CommandArgument = lstMat[3].MaterialID.ToString();
            this.lnkFile4.Enabled = true;
            this.Image4.Visible = true;
            this.fup4.Enabled = false;
        }
        else
        {
            this.lnkFile4.Text = "Filename";
            this.lnkFile4.Enabled = false;
            this.chk4.Enabled = false;
            this.Image4.Visible = false;
        }

        if (lstMat.Count >= 5)
        {
            this.lnkFile5.Text = lstMat[4].MaterialName;
            this.lnkFile5.CommandArgument = lstMat[4].MaterialID.ToString();
            this.lnkFile5.Enabled = true;
            this.Image5.Visible = true;
            this.fup5.Enabled = false;
        }
        else
        {
            this.lnkFile5.Text = "Filename";
            this.lnkFile5.Enabled = false;
            this.Image5.Visible = false;
            this.chk5.Enabled = false;
        }
    }

    protected void lnkFile5_Click(object sender, EventArgs e)
    {
        LinkButton file = (LinkButton)sender;
        if (file.Text == "Filename")
            return;
        Response.AddHeader("content-disposition", "attachment; filename=" + file.Text);
        Response.WriteFile("~/MODULES/DLPDS/COURSEMATERIAL/" + file.Text);
    }

    protected void lnkFile2_Click(object sender, EventArgs e)
    {
        LinkButton file = (LinkButton)sender;
        if (file.Text == "Filename")
            return;
        Response.AddHeader("content-disposition", "attachment; filename=" + file.Text);
        Response.WriteFile("~/MODULES/DLPDS/COURSEMATERIAL/" + file.Text);
    }

    protected void lnkFile3_Click(object sender, EventArgs e)
    {
        LinkButton file = (LinkButton)sender;
        if (file.Text == "Filename")
            return;
        Response.AddHeader("content-disposition", "attachment; filename=" + file.Text);
        Response.WriteFile("~/MODULES/DLPDS/COURSEMATERIAL/" + file.Text);
    }

    protected void lnkFile4_Click(object sender, EventArgs e)
    {
        LinkButton file = (LinkButton)sender;
        if (file.Text == "Filename")
            return;
        Response.AddHeader("content-disposition", "attachment; filename=" + file.Text);
        Response.WriteFile("~/MODULES/DLPDS/COURSEMATERIAL/" + file.Text);
    }

    protected void lnkFile1_Click(object sender, EventArgs e)
    {
        LinkButton file = (LinkButton)sender;
        if (file.Text == "Filename")
            return;
        Response.AddHeader("content-disposition", "attachment; filename=" + file.Text);
        Response.WriteFile("~/MODULES/DLPDS/COURSEMATERIAL/" + file.Text);
    }
    
    void LoadFacultyMember(int? orgID, int? facID)
    {
        try
        {
            this.grdFacultymember.DataSource = BLLFacultyMember.GetFacultyMemberTable(orgID, facID);
            this.grdFacultymember.DataBind();
            this.lblMemberCount.Text = "Total Faculty Member: " + this.grdFacultymember.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearME();
        this.ddlProgram_Rqd.SelectedIndex = 0;
        this.ddlSession_Rqd.SelectedIndex = 0;
        this.ddlCourse_Rqd.SelectedIndex = 0;
        //Session["DLPDS_SessionCourse"] = new ATTSessionCourse();
    }

    protected void grdFacultymember_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[10].Visible = false;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int? orgID;
        if (this.ddlOrg.SelectedIndex == 0)
            orgID = null;
        else
            orgID = int.Parse(this.ddlOrg.SelectedValue);

        this.LoadFacultyMember(orgID, null);
    }
}
