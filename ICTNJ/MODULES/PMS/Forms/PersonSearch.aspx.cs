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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_Forms_PersonSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("Person Search") == true)
        {
            if (!this.IsPostBack)
            {
                LoadDistricts();
                LoadOrganizationsType();
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

    void LoadOrganizationsType()
    {
        List<ATTOrganizationType> lstOrgType;
        try
        {
            lstOrgType = BLLOrganizationType.GetOrgType();
            lstOrgType.Insert(0, new ATTOrganizationType("0", "%fGg'xf];"));
            this.ddlOrgType.DataSource = lstOrgType;
            this.ddlOrgType.DataTextField = "OrgTypeDesc";
            this.ddlOrgType.DataValueField = "OrgTypeCode";
            this.ddlOrgType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
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
            (this.ddlGender.SelectedIndex == 0) && (this.ddlDistrict.SelectedIndex == 0) && (this.ddlOrgType.SelectedIndex==0))
        {
            this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTPersonSearch> lst;
        this.lblSearch.Text = "";
        try
        {
            lst = BLLPersonSearch.SearchPerson(GetFilter());
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

    private ATTPersonSearch GetFilter()
    {
        ATTPersonSearch SearchPerson = new ATTPersonSearch();
        if (this.txtFName.Text.Trim() != "") SearchPerson.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") SearchPerson.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") SearchPerson.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlGender.SelectedValue;
        if (this.ddlDistrict.SelectedIndex > 0) SearchPerson.District = this.ddlDistrict.SelectedItem.Text;
        //if (this.ddlOrgType.SelectedIndex > 0) SearchPerson.IniType = this.ddlOrgType.SelectedValue;
        SearchPerson.IniType = "3";
        return SearchPerson;
    }

    string previousCat = "";
    int firstRow = -1;
    protected void grdPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (previousCat == e.Row.Cells[0].Text)
            {
                if (this.grdPerson.Rows[firstRow].Cells[0].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[0].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[4].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[4].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[4].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[5].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[5].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[6].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[6].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[8].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[8].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[8].RowSpan += 1;

                if (this.grdPerson.Rows[firstRow].Cells[9].RowSpan == 0)
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan = 2;
                else
                    this.grdPerson.Rows[firstRow].Cells[9].RowSpan += 1;

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
            }

            else //It's a new category
            {
                e.Row.VerticalAlign = VerticalAlign.Middle;
                previousCat = e.Row.Cells[0].Text;
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
