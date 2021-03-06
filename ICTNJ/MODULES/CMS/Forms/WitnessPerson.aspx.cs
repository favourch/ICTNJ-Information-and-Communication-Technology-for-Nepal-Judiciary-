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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

using PCS.SECURITY.ATT;
using System.Collections.Generic;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_LookUp_WitnessPerson : System.Web.UI.Page
{
    string entryBy = "shyam";

    //private List<ATTWitnessSearch> _WitPersonList=new List<ATTWitnessSearch>();
    //public List<ATTWitnessSearch> WitPersonList
    //{
    //    get { return (Session["WitPerson"] == null) ? new List<ATTWitnessSearch>() : (List<ATTWitnessSearch>)Session["WitPerson"]; }
    //    set { Session["WitPerson"] = value; }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["WSearch"] == null)
        {
            Session["WSearch"] = new List<ATTWitnessSearch>();
        }

        if (grdWitnesses.EditIndex==-1)
        {
            List<ATTWitnessSearch> WSearch = (List<ATTWitnessSearch>)Session["WSearch"];
            grdWitnesses.DataSource = WSearch;
            grdWitnesses.DataBind();
        }
       
        if (!Page.IsPostBack)
        {
            LoadDistricts();

            if (Session["WSearch"] == null)
            {
                Session["WSearch"] = new List<ATTWitnessSearch>();
            }
            if (Session["CaseAndLitigant"] == null)
            {
                Session["CaseAndLitigant"] = new List<ATTWitnessPerson>();
            }
           
        }
    }

    void LoadDistricts()
    {
        List<ATTDistrict> lstDistricts;
        try
        {
            lstDistricts = BLLDistrict.GetDistrictList(null);
            lstDistricts.Insert(0, new ATTDistrict(0, "जिल्ला छान्नुस", "-- Select One --", 0));

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

    void ClearControls()
    {
        this.txtFromDate_RQD.Text = "";
        this.grdWitnesses.DataSource = null;
        this.grdWitnesses.DataBind();
        this.grdWitnesses.SelectedIndex = -1;
        this.grdPerson.SelectedIndex = -1;
        this.grdLitigants.SelectedIndex = -1;
        //Session["WSearch"] = WitPersonList;
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";

        this.ddlGender.SelectedIndex = 0;
        this.ddlDistrict.SelectedIndex = 0;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdLitigants_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }

    protected void grdLitigants_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ATTWitnessSearch objWP = new ATTWitnessSearch();
            objWP.CaseID = int.Parse(grdLitigants.SelectedRow.Cells[0].Text);
            objWP.LItigantID = int.Parse(grdLitigants.SelectedRow.Cells[1].Text);
            objWP.LitigantName = grdLitigants.SelectedRow.Cells[3].Text.Trim();

            List<ATTWitnessSearch> WitnessList = BLLWitnessSearch.SearchWitnessPerson(objWP);

            Session["WSearch"] = WitnessList;
            //WitPersonList = WitnessList;
            
            grdWitnesses.DataSource = WitnessList;
            grdWitnesses.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnSearchLitigants_Click(object sender, EventArgs e)
    {
        if (txtCaseNo.Text.Trim() == "" && txtRegNo.Text.Trim() == "")
        {
            lblStatusMessage.Text = "All Fields Can't be empty";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTLitigantSearch obj = new ATTLitigantSearch();
        if (txtCaseNo.Text.Trim() == "___-__-____" && txtRegNo.Text.Trim() == "__-___-_____")
        {
            lblStatusMessage.Text = "All Fields Can't be empty";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtRegNo.Text.Trim() == "__-___-_____")
        {
            obj.RegNo = "";
        }
        else
        {
            obj.RegNo = txtRegNo.Text;
        }
        if (txtCaseNo.Text.Trim() == "___-__-____")
        {
            obj.CaseNo = "";
        }
        else
        {
            obj.CaseNo = txtCaseNo.Text;
        }
        try
        {
            grdLitigants.DataSource = BLLLitigantSearch.GetLitigantSearch(obj);
            grdLitigants.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if ((this.txtFName.Text.Trim() == "") && (this.txtMName.Text.Trim() == "") && (this.txtSurName.Text.Trim() == "") &&
        //           (this.ddlGender.SelectedIndex == 0) && (this.ddlDistrict.SelectedIndex == 0))
        //{
        //    this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
        //    this.programmaticModalPopup.Show();
        //    return;
        //}
        List<ATTPersonSearch> lst;
        try
        {
            lst = BLLPersonSearch.SearchPerson(GetFilter());
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
        return SearchPerson;
    }

    protected void grdPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtFromDate_RQD.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "EndRequestHandler", "javascript:EndRequestHandler();", true);
    }

    protected void grdPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void btnAddWitness_Click(object sender, EventArgs e)
    {
        if (grdLitigants.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text ="Select Litigant First.";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTWitnessPerson att = new ATTWitnessPerson();
        att.CaseID = int.Parse(grdLitigants.SelectedRow.Cells[0].Text);
        att.LitigantID = int.Parse(grdLitigants.SelectedRow.Cells[1].Text);
        Session["CaseAndLitigant"] = att;

        string script = "";
        if (att != null)
        {
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('WitnessInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
        }
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnAddPerson_Click(object sender, EventArgs e)
    {
        if (txtFromDate_RQD.Text == "____/__/__")
        {
            this.lblStatusMessage.Text = "Enter From Date First";
            this.programmaticModalPopup.Show();
            return;
        }
        if (grdWitnesses.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "Select Witness Person First";
            this.programmaticModalPopup.Show();
            return;
        }
        foreach (GridViewRow row in grdWitnesses.Rows)
        {
            if (int.Parse(row.Cells[2].Text) == int.Parse(grdPerson.SelectedRow.Cells[0].Text))
            {
                this.lblStatusMessage.Text = "Witness Already Exits..";
                this.programmaticModalPopup.Show();
                return;
            }
        }

        List<ATTWitnessSearch> WSearchLST = (List<ATTWitnessSearch>)Session["WSearch"];
        ATTWitnessSearch obj = new ATTWitnessSearch();

        obj.CaseID = int.Parse(grdLitigants.SelectedRow.Cells[0].Text);
        obj.LItigantID = int.Parse(grdLitigants.SelectedRow.Cells[1].Text);
        obj.PersonID = int.Parse(grdPerson.SelectedRow.Cells[0].Text);
        obj.WitnessID = 0;
        obj.WitnessName = grdPerson.SelectedRow.Cells[4].Text.Trim();
        obj.FromDate = txtFromDate_RQD.Text;
        obj.WitnessGender = grdPerson.SelectedRow.Cells[5].Text;
        obj.WitnessDOB = grdPerson.SelectedRow.Cells[6].Text;
        obj.Action = "A";

        WSearchLST.Add(obj);
        Session["WSearch"] = WSearchLST;

        grdWitnesses.DataSource = WSearchLST;
        grdWitnesses.DataBind();

        this.txtFromDate_RQD.Text = "";
        this.grdPerson.SelectedIndex = -1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTWitnessSearch> WSList = (List<ATTWitnessSearch>)Session["WSearch"];
        List<ATTWitnessPerson> WPList = new List<ATTWitnessPerson>();
        foreach (ATTWitnessSearch obj in WSList)
        {
            if (obj.Action == null || obj.Action=="")
                continue;
                ATTWitnessPerson objWP = new ATTWitnessPerson();

                objWP.CaseID = obj.CaseID;
                objWP.LitigantID = obj.LItigantID;
                objWP.PersonID = obj.PersonID;
                objWP.WitnessID = obj.WitnessID;
                objWP.FromDate = obj.FromDate;
                objWP.EntryBy = entryBy;
                objWP.PersonOBJ = obj.ObjPerson;
                objWP.Action = obj.Action;

                WPList.Add(objWP);
        }

        Session["WPerson"] = WPList;
        try
        {
            if (BLLWitnessPerson.SaveWitnessPerson(WPList))
            {
                ClearControls();
                
                this.lblStatusMessage.Text = "Saved Successfully";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdWitnesses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void grdWitnesses_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected void grdWitnesses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;

        List<ATTWitnessSearch> WSearch = (List<ATTWitnessSearch>)Session["WSearch"];
        if (grdWitnesses.Rows[i].Cells[8].Text == "A")
            WSearch.RemoveAt(e.RowIndex);
        else if (grdWitnesses.Rows[i].Cells[8].Text == "D")
            WSearch[i].Action = "";
            else if (grdWitnesses.Rows[i].Cells[8].Text == "E")
            WSearch[i].Action = "D";
        else
            WSearch[i].Action = "D";
       

        grdWitnesses.DataSource = WSearch;
        grdWitnesses.DataBind();

        Session["WSearch"] = WSearch;

        for (int j = 0; j < this.grdWitnesses.Rows.Count; j++)
        {
            if (grdWitnesses.Rows[j].Cells[8].Text == "D")
                ((LinkButton)this.grdWitnesses.Rows[j].Cells[10].Controls[0]).Text = "Undo";
            else
                ((LinkButton)this.grdWitnesses.Rows[j].Cells[10].Controls[0]).Text = "Remove";
        }

    }

    //protected void grdWitnesses_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtFromDate_RQD.Text = grdWitnesses.SelectedRow.Cells[5].Text.Trim();
    //    btnAddToGrid.Visible = true;
    //}

    //protected void btnAddToGrid_Click(object sender, EventArgs e)
    //{
    //    List<ATTWitnessSearch> WSearch = (List<ATTWitnessSearch>)Session["WSearch"];
    //    WSearch[grdWitnesses.SelectedIndex].FromDate = txtFromDate_RQD.Text;
    //    WSearch[grdWitnesses.SelectedIndex].Action = "E";

    //    grdWitnesses.DataSource = WSearch;
    //    grdWitnesses.DataBind();

    //    Session["WSearch"] = WSearch;
    //    btnAddToGrid.Visible = false;
    //    txtFromDate_RQD.Text = "";
    //}

    protected void grdWitnesses_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdWitnesses.EditIndex = e.NewEditIndex;
        List<ATTWitnessSearch> WitnessList = (List<ATTWitnessSearch>)Session["WSearch"];

        grdWitnesses.DataSource = WitnessList;
        grdWitnesses.DataBind();
    }

    protected void grdWitnesses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdWitnesses.EditIndex = -1;
        List<ATTWitnessSearch> WitnessList = (List<ATTWitnessSearch>)Session["WSearch"];

        grdWitnesses.DataSource = WitnessList;
        grdWitnesses.DataBind();
  
    }

    protected void grdWitnesses_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        List<ATTWitnessSearch> WSearch = (List<ATTWitnessSearch>)Session["WSearch"];

        WSearch[e.RowIndex].FromDate = ((TextBox)grdWitnesses.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
        WSearch[e.RowIndex].Action = "E";

        Session["WSearch"] = WSearch;
        grdWitnesses.EditIndex = -1;

        grdWitnesses.DataSource = WSearch;
        grdWitnesses.DataBind();
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
}
