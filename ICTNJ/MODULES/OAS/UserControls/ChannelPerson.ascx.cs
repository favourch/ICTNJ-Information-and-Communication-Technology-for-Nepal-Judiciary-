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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_UserControls_ChannelPerson : System.Web.UI.UserControl
{
    public ATTUserLogin User
    {
        get
        {
            return Session["Login_User_Detail"] as ATTUserLogin;
        }
    }

    public GridView ChannelPerson
    {
        get { return this.grdChannelPerson; }
    }

    public GridView GeneralPerson
    {
        get { return this.grdSEmployee; }
    }

    private int _TippaniSubjectID;
    public int TippaniSubjectID
    {
        get { return this._TippaniSubjectID; }
        set { this._TippaniSubjectID = value; }
    }

    private string _ApplicationString;
    public string ApplicationString
    {
        get { return this._ApplicationString.Trim(); }
        set { this._ApplicationString = value; }
    }

    public HiddenField ChkChannelPerson
    {
        get { return this.hdnChannelPerson; }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadOrganization();
            this.LoadDesignation();
            this.LoadChannelPerson();
        }
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));
            this.ddlSOrg.DataSource = lst;
            this.ddlSOrg.DataTextField = "OrgName";
            this.ddlSOrg.DataValueField = "OrgID";
            this.ddlSOrg.DataBind();

            this.ddlUOrg.DataSource = lst;
            this.ddlUOrg.DataTextField = "OrgName";
            this.ddlUOrg.DataValueField = "OrgID";
            this.ddlUOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadDesignation()
    {
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, "");
            LstDesignation.Insert(0, new ATTDesignation(0, "--- पद छान्नुहोस ---", ""));

            this.ddlSDesgination.DataSource = LstDesignation;
            this.ddlSDesgination.DataTextField = "DesignationName";
            this.ddlSDesgination.DataValueField = "DesignationID";
            this.ddlSDesgination.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadChannelPerson()
    {
        List<ATTTippaniChannel> lst = BLLTippaniChannel.GetTippaniChannelList(this.User.OrgID, this.TippaniSubjectID);
        lst.RemoveAll
                    (
                        delegate(ATTTippaniChannel c)
                        {
                            return c.ChannelPersonID == this.User.PID;
                        }
                    );
        this.grdChannelPerson.DataSource = lst;
        this.grdChannelPerson.DataBind();
    }

    protected void btnSearchGeneral_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLGroupPersonSearch.GetEmployeeFromWorkDistribution(GetFilterGeneral(), this.ApplicationString);

            lstPersonSearch.RemoveAll
                                        (
                                            delegate(ATTGroupPersonSearch s)
                                            {
                                                return s.PersonID == this.User.PID;
                                            }
                                        );

            double empID;
            foreach (GridViewRow row in this.grdChannelPerson.Rows)
            {
                empID = double.Parse(row.Cells[8].Text);
                lstPersonSearch.RemoveAll
                                        (
                                            delegate(ATTGroupPersonSearch s)
                                            {
                                                return s.PersonID == empID;
                                            }
                                        );
            }

            this.grdSEmployee.DataSource = lstPersonSearch;
            this.grdSEmployee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTGroupPersonSearch GetFilterGeneral()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtSFname.Text.Trim();
        SearchPerson.MiddleName = this.txtSMname.Text.Trim();
        SearchPerson.SurName = this.txtSLname.Text.Trim();

        if (this.ddlSSex.SelectedIndex > 0) SearchPerson.Gender = this.ddlSSex.SelectedValue;

        SearchPerson.DOB = this.txtSDob.Text.Trim();

        if (this.ddlSMaritalStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlSMaritalStatus.SelectedValue;

        if (this.ddlSOrg.SelectedIndex > 0) SearchPerson.IniType = this.ddlSOrg.SelectedValue;

        if (this.ddlSDesgination.SelectedIndex > 0) SearchPerson.PostName = this.ddlSDesgination.SelectedValue;

        if (this.ddlUnit.SelectedIndex > 0) SearchPerson.UnitID = int.Parse(this.ddlUnit.SelectedValue);

        return SearchPerson;
    }

    protected void btnCancelGeneral_Click(object sender, EventArgs e)
    {

    }

    protected void grdSEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdSEmployee.Rows.Count > 0)
        {
            this.lblSearchX.Text = "Total person: " + this.grdSEmployee.Rows.Count.ToString();
        }
        else
        {
            this.lblSearchX.Text = "No person found.";
        }
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
    }

    protected void grdChannelPerson_DataBound(object sender, EventArgs e)
    {
        if (this.grdChannelPerson.Rows.Count > 0)
        {
            this.lblChannelPersonCount.Text = "Total channel person for visit: " + this.grdChannelPerson.Rows.Count.ToString();
        }
        else
        {
            this.lblChannelPersonCount.Text = "No Channel person";
        }
    }

    protected void grdChannelPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
    }

    public void Clear()
    {
        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkSelect");
            box.Checked = false;
        }

        this.grdSEmployee.DataSource = "";
        this.grdSEmployee.DataBind();

        this.hdnChannelPerson.Value = "0";
    }

    public List<ATTGeneralTippaniProcess> GetTippaniProcessList(int orgID, int tippaniID,string entryBy)
    {
        List<ATTGeneralTippaniProcess> lst = new List<ATTGeneralTippaniProcess>();

        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkSelect");
            if (box.Checked == true)
            {
                ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

                process.OrgID = orgID;
                process.TippaniID = tippaniID;
                process.TippaniProcessID = 0;
                process.SenderOrgID = this.User.OrgID;
                process.SenderUnitID = this.User.UnitID;
                process.SendBy = this.User.PID;
                process.SendOn = "";
                process.ReceiverOrgID = int.Parse(row.Cells[9].Text);
                process.ReceiverUnitID = int.Parse(row.Cells[10].Text);
                process.SendTo = int.Parse(row.Cells[8].Text);
                process.Note = "";
                process.Status = null;
                process.SendType = "F";
                process.IsChannelPerson = "Y";
                process.EntryBy = entryBy;
                process.Action = "A";

                lst.Add(process);
            }
        }

        foreach (GridViewRow row in this.grdSEmployee.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkGSelect");
            if (box.Checked == true)
            {
                ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

                process.OrgID = orgID;
                process.TippaniID = tippaniID;
                process.TippaniProcessID = 0;
                process.SenderOrgID = this.User.OrgID;
                process.SenderUnitID = this.User.UnitID;
                process.SendBy = this.User.PID;
                process.SendOn = "";
                process.ReceiverOrgID = int.Parse(row.Cells[10].Text);
                process.ReceiverUnitID = int.Parse(row.Cells[11].Text);
                process.SendTo = int.Parse(row.Cells[0].Text);
                process.Note = "";
                process.Status = null;
                process.SendType = "F";
                process.IsChannelPerson = "N";
                process.EntryBy = entryBy;
                process.Action = "A";

                lst.Add(process);
            }
        }

        foreach (GridViewRow row in this.grdOrgUnitWithHead.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("chkUnitSelect");
            if (box.Checked == true)
            {
                ATTGeneralTippaniProcess process = new ATTGeneralTippaniProcess();

                process.OrgID = orgID;
                process.TippaniID = tippaniID;
                process.TippaniProcessID = 0;
                process.SenderOrgID = this.User.OrgID;
                process.SenderUnitID = this.User.UnitID;
                process.SendBy = this.User.PID;
                process.SendOn = "";
                process.ReceiverOrgID = int.Parse(row.Cells[1].Text);
                process.ReceiverUnitID = int.Parse(row.Cells[2].Text);
                process.SendTo = int.Parse(row.Cells[3].Text);
                process.Note = "";
                process.Status = null;
                process.SendType = "F";
                process.IsChannelPerson = "N";
                process.EntryBy = entryBy;
                process.Action = "A";

                lst.Add(process);
            }
        }

        return lst;
    }

    protected void ddlSOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<ATTOrganizationUnit> lst = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(this.ddlSOrg.SelectedValue), null);
            lst.Insert(0, new ATTOrganizationUnit(-1, -1, "--- शाखा ---"));
            this.ddlUnit.DataSource = lst;
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlUOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.grdOrgUnitWithHead.DataSource = BLLOrganizationUnit.GetUnitHead(int.Parse(this.ddlUOrg.SelectedValue), null);
            this.grdOrgUnitWithHead.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdOrgUnitWithHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
