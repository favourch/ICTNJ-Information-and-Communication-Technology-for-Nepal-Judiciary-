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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_Forms_Participants : System.Web.UI.Page
{
    internal string strProgramID
    {
        get { return this.lstProgram.SelectedValue; }
    }

    internal string strProgramName
    {
        get { return this.lstProgram.SelectedItem.Text; }
    }

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

        if (user.MenuList.ContainsKey("Participants") == true || user.MenuList.ContainsKey("Resource Person") == true)
        {
            if (Page.IsPostBack == false)
            {
                GetProgram();
                LoadDistricts();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

        
        
    }

    void LoadDistricts()
    {
        List<ATTDistrict> lstDistricts;
        try
        {
            lstDistricts = BLLDistrict.GetDistrictList(null);
            lstDistricts.Insert(0, new ATTDistrict(0, "%fGg'xf];", "Select District", 0));

            this.ddlDistrict.DataSource = lstDistricts;
            this.ddlDistrict.DataTextField = "NepDistName";
            this.ddlDistrict.DataValueField = "DistCode";
            this.ddlDistrict.SelectedIndex = 0;
            this.ddlDistrict.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void GetProgram()
    {
        

        List<ATTProgram> ProgramList = BLLProgram.GetProgramList(int.Parse(Session["OrgID"].ToString()), 0,"N","N","N","N","N","N");
        try
        {
            lstProgram.DataSource = ProgramList;
            lstProgram.DataTextField = "ProgramName";
            lstProgram.DataValueField = "ProgramID";
            lstProgram.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnAddParticipant_Click(object sender, EventArgs e)
    {
        if (lstProgram.SelectedIndex > -1)
            Server.Transfer("PersonnelInfo.aspx");
        else
        {
            this.lblStatusMessage.Text = "Select Program First";
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void grdParticipant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
    }

    void ClearControls()
    {
        lstProgram.SelectedIndex = -1;
        grdParticipant.DataSource = "";
        grdParticipant.DataBind();
        grdPerson.DataSource = "";
        grdPerson.DataBind();
          

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lstProgram.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "Select Program First";
            this.programmaticModalPopup.Show();
            return;
        }

        if (grdParticipant.Rows.Count > 0)
        {
            List<ATTParticipant> lstParticipant = new List<ATTParticipant>();
            try
            {
                foreach (GridViewRow rowPerson in grdPerson.Rows)
                {
                    bool blnPersonAlreadyExists = false;
                    CheckBox cb;
                    cb = (CheckBox)(rowPerson.Cells[0].FindControl("chkSelectPerson"));
                    if (cb.Checked)
                    {
                        foreach (GridViewRow row in grdParticipant.Rows)
                        {
                            if (row.Cells[2].Text.Trim() == rowPerson.Cells[1].Text.Trim())
                            {
                                blnPersonAlreadyExists = true;
                                break;
                            }
                            else
                                blnPersonAlreadyExists = false;
                        }

                        if (!blnPersonAlreadyExists)
                        {
                            ATTParticipant attP = new ATTParticipant((int)Session["OrgID"], int.Parse(lstProgram.SelectedValue.ToString()), int.Parse(rowPerson.Cells[1].Text.ToString()), "",Session["NepDate"].ToString(), "");
                            lstParticipant.Add(attP);
                        }
                    }
                }
                BLLParticipant.SaveParticipant(lstParticipant);
                this.lstProgram_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
                return;
            }

        }
        else
        {
            this.lblStatusMessage.Text = "Search Person to add Participant";
            this.programmaticModalPopup.Show();
            return;
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstProgram_SelectedIndexChanged(object sender, EventArgs e)
    {

        grdParticipant.DataSource = "";
        grdParticipant.DataBind();
        List<ATTParticipant> PTList = BLLParticipant.GetParticipant((int)Session["OrgID"], int.Parse(lstProgram.SelectedValue.ToString()));
        grdParticipant.DataSource = PTList;
        grdParticipant.DataBind();
    }

    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlDistrict.SelectedIndex = 0;
        this.lblSearch.Text = "";
        this.grdPerson.DataSource = "";
        this.grdPerson.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.txtFName.Text.Trim() == "") && (this.txtMName.Text.Trim() == "") && (this.txtSurName.Text.Trim() == "") &&
    (this.ddlGender.SelectedIndex == 0) && (this.ddlDistrict.SelectedIndex == 0))
        {
            this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTParticipantSearch> lst;
        this.lblSearch.Text = "";
        try
        {
            lst = BLLParticipantSearch.SearchParticipant(GetFilter());
            this.lblSearch.Text = lst.Count.ToString() + " records found.";
            this.grdPerson.DataSource = lst;
            this.grdPerson.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTParticipantSearch GetFilter()
    {
        ATTParticipantSearch SearchParticipant = new ATTParticipantSearch();
        if (this.txtFName.Text.Trim() != "") SearchParticipant.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") SearchParticipant.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") SearchParticipant.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) SearchParticipant.Gender = this.ddlGender.SelectedValue;
        if (this.ddlDistrict.SelectedIndex > 0) SearchParticipant.District = this.ddlDistrict.SelectedItem.Text;
        return SearchParticipant;
    }

    string previousCat = "";
    int firstRow = -1;

    protected void grdPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (previousCat == e.Row.Cells[1].Text)
            {
                if (this.grdPerson.Rows[firstRow].Cells[0].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[1].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[1].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[1].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[5].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[6].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[7].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[7].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[7].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[9].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[10].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[10].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[10].RowSpan += 1;

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }

            else //It's a new category
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;
                previousCat = e.Row.Cells[1].Text;
                firstRow = e.Row.RowIndex;
            }
        }
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:#5D7B9D";
        }

    }

    protected void grdPerson_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

}