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
using PCS.CMS.ATT;
using PCS.CMS.BLL;
using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;

public partial class MODULES_CMS_MelMilaapKartaa_MelMilaapKartaa : System.Web.UI.Page
{
    string strUser = "shyam";
    int orgID=9;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["MelMilaapKartaaInfo"]!= null)
        {
            List<ATTPerson> lstPerson = (List<ATTPerson>)Session["MelMilaapKartaaInfo"];
            txtPerson_RQD.Text = lstPerson[0].FullName;
            hdnPersonID.Value = lstPerson[0].PId.ToString();

        }
        if (Session["MelMilaapKartaa"]==null)
        {
            Session["MelMilaapKartaa"] = new List<ATTMelMilaapKartaa>();
        }
        if (IsPostBack == false)
        {
            LoadOrganization();
            //LoadJudgeList();
           
        }
        
    }
    
    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrgWithChilds(orgID);
            lstOrganization.DataSource = lstOrg;
            lstOrganization.DataTextField = "OrgName";
            lstOrganization.DataValueField = "OrgID";
            lstOrganization.DataBind();
         
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }
    void LoadJudgeList()
    {
        List<ATTJudgeWorkList> lst = new List<ATTJudgeWorkList>();

        lst.Add(new ATTJudgeWorkList(0, "छान्नुहोस्"));
        lst.AddRange(BLLJudgeWorkList.GetCurrentJudgesList(int.Parse(lstOrganization.SelectedValue)));

        //lst = BLLJudgeWorkList.GetCurrentJudgesList(int.Parse(lstOrganization.SelectedValue));
        //grdJudges.DataSource = lst;
        //grdJudges.DataBind();
         ddlJudge.DataSource =lst;
        ddlJudge.DataBind();
       

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnSearchPerson_Click(object sender, EventArgs e)
    {
        txtPerson_RQD.Text = "";
        hdnPersonID.Value = "0";
        programmaticPersonModalPopup.Show();
    }
    
    protected void OkPersonButton_Click(object sender, EventArgs e)
    {
        if (grdPersonSearch.SelectedIndex > -1 && txtPerson_RQD.Text == "")
        {
            txtPerson_RQD.Text = grdPersonSearch.SelectedRow.Cells[2].Text.Trim();
            hdnPersonID.Value = grdPersonSearch.SelectedRow.Cells[1].Text;
        }
        else
        {
            lblStatusMessage.Text = "Select Person First.";
            programmaticModalPopup.Show();
            return;
        }
        ClearPersonSearchFields();
        programmaticPersonModalPopup.Hide();
    }
    
    protected void btnPersonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLPersonSearch.SearchPerson(GetFilter());
            Session["PopupPersonSearch"] = lstPersonSearch;
            this.grdPersonSearch.DataSource = lstPersonSearch;
            this.grdPersonSearch.DataBind();
            this.programmaticPersonModalPopup.Show();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }
    
    private ATTPersonSearch GetFilter()
    {
        ATTPersonSearch SearchPerson = new ATTPersonSearch();
        if (this.txtSFirstName.Text.Trim() != "") SearchPerson.FirstName = this.txtSFirstName.Text.Trim();
        if (this.txtSMName.Text.Trim() != "") SearchPerson.MiddleName = this.txtSMName.Text.Trim();
        if (this.txtSLastName.Text.Trim() != "") SearchPerson.SurName = this.txtSLastName.Text.Trim();
        if (this.ddlSGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlSGender.SelectedValue;
        if (this.ddlSHomeDistrict.SelectedIndex > 0) SearchPerson.BirthDistrict = int.Parse(this.ddlSHomeDistrict.SelectedValue);
        if (this.ddlSMarStatus.SelectedIndex > 0) SearchPerson.IniType = this.ddlSMarStatus.SelectedValue;
        return SearchPerson;
    }
    
    void ClearPersonSearchFields()
    {
        this.txtSFirstName.Text = "";
        this.txtSMName.Text = "";
        this.txtSLastName.Text = "";
        this.ddlSGender.SelectedIndex = 0;
        this.txtSDOB_DT.Text = "";
        this.ddlSMarStatus.SelectedIndex = 0;
        this.ddlSHomeDistrict.SelectedIndex = 0;
        this.grdPersonSearch.SelectedIndex = -1;
        //this.grdPersonSearch.DataSource = "";
        //this.grdPersonSearch.DataBind();
    }

    void ClearControls()
    {
        hdnPersonID.Value = "0";
        txtPerson_RQD.Text = "";
        txtFromDate_RQD.Text = "";
        txtPost.Text = "";
        txtExp.Text = "";
        grdMMK.DataSource = null;
        grdMMK.DataBind();
        lstOrganization.SelectedIndex = -1;

        btnSearchPerson.Enabled = true;
        btnNewPerson.Enabled = true;
        txtPerson_RQD.ReadOnly = false;
    }

    protected void btnCancelPersonSearch_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
    }
    
    protected void grdPersonSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdPersonSearch.SelectedRow.Focus();
        programmaticPersonModalPopup.Show();
    }
    
    protected void btnNewPerson_Click(object sender, EventArgs e)
    {
        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('MelMilaapKartaaInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }
   
    protected void grdPersonSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        programmaticPersonModalPopup.Show();
    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTPerson> PersonList = (List<ATTPerson>)Session["MelMilaapKartaaInfo"];
        List<ATTMelMilaapKartaa> MMKList = (List<ATTMelMilaapKartaa>)Session["MelMilaapKartaa"];
        
        try
        {
            BLLMelMilaapKartaa.SaveMelMilaapKarta(MMKList, PersonList);
            ClearControls();
            lblStatusMessage.Text = "MelMilaap Kartaa saved successfully";
            programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdnPersonID.Value.Trim() == "" || txtPerson_RQD.Text.Trim()=="")
            {
                lblStatusMessage.Text = "MelMilaapKartaa Missing";
                this.programmaticModalPopup.Show();
                return;
            }
            if (txtFromDate_RQD.Text.Trim() == "____/__/__")
            {
                lblStatusMessage.Text = "From Date Missing";
                this.programmaticModalPopup.Show();
                return;
            }
            

            List<ATTMelMilaapKartaa> MMKList = (List<ATTMelMilaapKartaa>)Session["MelMilaapKartaa"];
            ATTMelMilaapKartaa attMMK = new ATTMelMilaapKartaa();

            if (grdMMK.SelectedIndex == -1)
            {
                attMMK.OrgID = int.Parse(lstOrganization.SelectedValue);
                attMMK.FullName = txtPerson_RQD.Text.Trim();
                attMMK.PID = double.Parse(hdnPersonID.Value.ToString());
                attMMK.FromDate = txtFromDate_RQD.Text.Trim();
                attMMK.Post = txtPost.Text.Trim();
                attMMK.Experience = txtExp.Text.Trim();
                attMMK.EntryBy = strUser;
                attMMK.Action = "A";
                attMMK.OathJudges = ddlJudge.SelectedItem.ToString();

                ATTMelMilapKartaOath oath = new ATTMelMilapKartaOath();

                oath.OrgID = attMMK.OrgID;
                oath.PersonID = attMMK.PID;
                oath.FromDate = attMMK.FromDate;
                oath.JudgeID = int.Parse(ddlJudge.SelectedValue);
                oath.EntryBy = strUser;
                oath.Action = "A";


                attMMK.OathLst.Add(oath);

                MMKList.Add(attMMK);
            }
            else
            {
                MMKList[grdMMK.SelectedIndex].OrgID = int.Parse(lstOrganization.SelectedValue);
                MMKList[grdMMK.SelectedIndex].FullName = txtPerson_RQD.Text.Trim();
                MMKList[grdMMK.SelectedIndex].PID = double.Parse(hdnPersonID.Value.ToString());
                MMKList[grdMMK.SelectedIndex].FromDate = txtFromDate_RQD.Text.Trim();
                MMKList[grdMMK.SelectedIndex].Post = txtPost.Text.Trim();
                MMKList[grdMMK.SelectedIndex].Experience = txtExp.Text.Trim();
                MMKList[grdMMK.SelectedIndex].EntryBy = strUser;
                MMKList[grdMMK.SelectedIndex].Action = "E";

                MMKList[grdMMK.SelectedIndex].OathJudges = ddlJudge.SelectedItem.ToString();


                MMKList[grdMMK.SelectedIndex].OathLst[0].OrgID = MMKList[grdMMK.SelectedIndex].OrgID;
                MMKList[grdMMK.SelectedIndex].OathLst[0].PersonID = MMKList[grdMMK.SelectedIndex].PID;
                MMKList[grdMMK.SelectedIndex].OathLst[0].FromDate = MMKList[grdMMK.SelectedIndex].FromDate;
                MMKList[grdMMK.SelectedIndex].OathLst[0].JudgeID = double.Parse(ddlJudge.SelectedValue);
                MMKList[grdMMK.SelectedIndex].OathLst[0].EntryBy = MMKList[grdMMK.SelectedIndex].EntryBy;
                MMKList[grdMMK.SelectedIndex].OathLst[0].Action = "E";
            }

            grdMMK.DataSource = Session["MelMilaapKartaa"];
            grdMMK.DataBind();

            hdnPersonID.Value = "";
            txtPerson_RQD.Text = "";
            txtPost.Text = "";
            txtFromDate_RQD.Text = "";
            txtExp.Text = "";
            ddlJudge.SelectedIndex = -1;

            grdMMK.SelectedIndex = -1;
            btnSearchPerson.Enabled = true;
            btnNewPerson.Enabled = true;
            txtPerson_RQD.ReadOnly = false;

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "Could not Add MelMilaapKartaa :" + ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
       
    }   

    protected void lstOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["MelMilaapKartaa"] = BLLMelMilaapKartaa.GetMelMilaapKartaa(int.Parse(lstOrganization.SelectedValue));
        
        
        grdMMK.DataSource = Session["MelMilaapKartaa"];
        grdMMK.DataBind();

        grdMMK.SelectedIndex = -1;

        LoadJudgeList();

    }
   
    protected void grdMMK_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lstOrganization.SelectedValue = grdMMK.SelectedRow.Cells[1].Text;
        hdnPersonID.Value = grdMMK.SelectedRow.Cells[0].Text;
        txtPerson_RQD.Text = grdMMK.SelectedRow.Cells[2].Text.Trim();
        txtFromDate_RQD.Text = grdMMK.SelectedRow.Cells[3].Text.Trim();
        txtPost.Text = grdMMK.SelectedRow.Cells[4].Text.Trim();
        txtExp.Text = grdMMK.SelectedRow.Cells[5].Text.Trim();
        List<ATTMelMilaapKartaa> MMKList = (List<ATTMelMilaapKartaa>)Session["MelMilaapKartaa"];

        ddlJudge.SelectedValue = int.Parse(MMKList[grdMMK.SelectedIndex].OathLst[0].JudgeID.ToString()).ToString();


        btnSearchPerson.Enabled = false;
        btnNewPerson.Enabled = false;
        txtPerson_RQD.ReadOnly = true;
       
    }

    protected void grdMMK_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTMelMilaapKartaa> MMKList = (List<ATTMelMilaapKartaa>)Session["MelMilaapKartaa"];
        if (grdMMK.Rows[e.RowIndex].Cells[6].Text == "A")
            MMKList.RemoveAt(e.RowIndex);
        else if (grdMMK.Rows[e.RowIndex].Cells[6].Text == "D")
            MMKList[e.RowIndex].Action = "";
        else
        {
            MMKList[e.RowIndex].Action = "D";
            MMKList[e.RowIndex].EntryBy = strUser;
        }
        grdMMK.DataSource = MMKList;
        grdMMK.DataBind();

        for (int i = 0; i < grdMMK.Rows.Count; i++)
        {
            if (grdMMK.Rows[i].Cells[6].Text == "D")
                ((LinkButton)grdMMK.Rows[i].Cells[9].Controls[0]).Text = "Undo";
            else
                ((LinkButton)grdMMK.Rows[i].Cells[9].Controls[0]).Text = "Delete";
        }
        hdnPersonID.Value = "";
        txtPerson_RQD.Text = "";
        txtPost.Text = "";
        txtFromDate_RQD.Text = "";
        txtExp.Text = "";
    }
   
    protected void grdMMK_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[6].Visible = false;
        
    }
    protected void grdJudges_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (grdJudges.Rows.Count>0)
        //{
        //    e.Row.Cells[1].Visible = false;            
        //}
    }
}
