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

public partial class MODULES_CMS_Misil_Misil : System.Web.UI.Page
{
    int orgID = 9;
    string strUser = "shyam";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PersonName"] == null)
            Session["PersonName"] = "";
        if (Session["PersonID"] == null)
            Session["PersonID"] = 0;
        if (Session["Rec"] == null)
            Session["Rec"] = "";
        if (Session["ReqRec"] == null)
            Session["ReqRec"] = "";
        if(Session["CaseID"]==null)
            Session["CaseID"] = 0;

        if ((string)Session["PersonName"] != "" && (double)Session["PersonID"] > 0 && (string)Session["ReqRec"] == "ReqRec")
        {
            txtReqRecPerson.Text = (string)Session["PersonName"];
            hdnReqRecPersonID.Value = Session["PersonID"].ToString();
        }
        else if ((string)Session["PersonName"] != "" && (double)Session["PersonID"] > 0 && (string)Session["Rec"] == "Rec")
        {
            txtRecPerson.Text = (string)Session["PersonName"];
            hdnRecPersonID.Value = Session["PersonID"].ToString();
        }
        Session["PersonName"] = null;
        Session["PersonID"] = 0;
        Session["Rec"] = "";
        Session["ReqRec"] = "";
      
        if (!IsPostBack)
        {
            LoadDocumentType();
            LoadDistrict();
            LoadOrganization();
            chkIsReturned.Checked = true;
        }
    }

    void LoadDocumentType()
    {
        try
        {
            List<ATTDocumentType> CaseDocTypeList = BLLDocumentType.GetDocumentType(null, "Y", 1);
            DDLMisilType.DataSource = CaseDocTypeList;
            DDLMisilType.DataTextField = "DocumentTypeName";
            DDLMisilType.DataValueField = "DocumentTypeID";
            DDLMisilType.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadDistrict()
    {
        try
        {
            List<ATTDistrict> lstDistricts;
            lstDistricts = BLLDistrict.GetDistrictList(null);
            lstDistricts.Insert(0, new ATTDistrict(0, "छान्नुहोस", "Select District", 0));
            this.ddlSHomeDistrict.DataSource = lstDistricts;
            this.ddlSHomeDistrict.DataTextField = "NepDistName";
            this.ddlSHomeDistrict.DataValueField = "DistCode";
            this.ddlSHomeDistrict.SelectedIndex = 0;
            this.ddlSHomeDistrict.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrganizationNameList();
            lstOrg.Insert(0,new ATTOrganization(0,"कार्यालय छान्नुस् "));
            
            DDLReqOrg.DataSource = lstOrg;
            DDLReqOrg.DataTextField = "OrgName";
            DDLReqOrg.DataValueField = "OrgID";
            DDLReqOrg.DataBind();

            DDLReqOrg.SelectedValue = orgID.ToString();
            pnlChalaniNo.Visible = false;
            pnlProcessMisil.Visible = false;
            pnlReplyMisil.Visible = false;    
        }
        catch (Exception ex)
        {
           
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        ATTLitigantSearch obj = new ATTLitigantSearch();
        if (txtCaseNo.Text.Trim() == "___-__-____" && txtRegNo.Text.Trim() == "__-___-_____")
        {
            lblStatusMessage.Text = "All Fields Can't be empty";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtRegNo.Text.Trim() == "__-___-____")
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

        List<ATTLitigantSearch> AppellantList = new List<ATTLitigantSearch>();
        List<ATTLitigantSearch> RespondantList = new List<ATTLitigantSearch>();

        try
        {
            List<ATTLitigantSearch> LitigantList = BLLLitigantSearch.GetLitigantSearch(obj);
            Session["CaseID"] = double.Parse(LitigantList[0].CaseID.ToString());
             foreach (ATTLitigantSearch att in LitigantList)
             {
                 if (att.LitigantType == "A")
                 {
                     ATTLitigantSearch attA = new ATTLitigantSearch();
                     attA.LitigantName = att.LitigantName;
                     attA.Gender = att.Gender;
                     attA.DOB = att.DOB;
                     attA.IsPrisoned = att.IsPrisoned;
                     attA.LitigantSubTypeName = att.LitigantSubTypeName;

                     AppellantList.Add(attA);
                 }
                 else
                 {
                     ATTLitigantSearch attR = new ATTLitigantSearch();
                     attR.LitigantName = att.LitigantName;
                     attR.Gender = att.Gender;
                     attR.DOB = att.DOB;
                     attR.IsPrisoned = att.IsPrisoned;
                     attR.LitigantSubTypeName = att.LitigantSubTypeName;

                     RespondantList.Add(attR);
                 }

             }

             grdAppellant.DataSource = AppellantList;
             grdAppellant.DataBind();

             grdRespondent.DataSource = RespondantList;
             grdRespondent.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }

    }

    protected void btnReqRecSearchPerson_Click(object sender, EventArgs e)
    {
        Session["ReqRec"] = "ReqRec";
        programmaticPersonModalPopup.Show();
    }

    protected void btnRecPersonSearch_Click(object sender, EventArgs e)
    {
        Session["Rec"] = "Rec";
        programmaticPersonModalPopup.Show();
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

    protected void btnCancelPersonSearch_Click(object sender, EventArgs e)
    {
        ClearPersonSearchFields();
    }

    protected void OkPersonButton_Click(object sender, EventArgs e)
    {
        if ((string)Session["Rec"] == "Rec")
        {
            txtRecPerson.Text = "";
            hdnRecPersonID.Value = "0";
        }
        else if ((string)Session["ReqRec"] == "ReqRec")
        {
            txtReqRecPerson.Text = "";
            hdnReqRecPersonID.Value = "0";
        }

        if (grdPersonSearch.SelectedIndex > -1 && txtReqRecPerson.Text == "")
        {
            txtReqRecPerson.Text = grdPersonSearch.SelectedRow.Cells[2].Text.Trim();
            hdnReqRecPersonID.Value = grdPersonSearch.SelectedRow.Cells[1].Text;
        }
        else if (grdPersonSearch.SelectedIndex > -1 && txtRecPerson.Text == "")
        {
            txtRecPerson.Text = grdPersonSearch.SelectedRow.Cells[2].Text.Trim();
            hdnRecPersonID.Value = grdPersonSearch.SelectedRow.Cells[1].Text;
        }
        else
        {
            lblStatusMessage.Text = "Select Person First.";
            programmaticModalPopup.Show();
            return;
        }
        ClearPersonSearchFields();
        Session["Rec"] = null;
        Session["ReqRec"] = null;
        programmaticPersonModalPopup.Hide();
    }

    protected void grdPersonSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdPersonSearch.SelectedRow.Focus();
        programmaticPersonModalPopup.Show();
    }

    protected void grdPersonSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        programmaticPersonModalPopup.Show();
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

    void ClearCotrols()
    {
        txtReqDate.Text = "";
        txtReqChalaniNo.Text = "";
        txtReqRecDate.Text = "";
        txtReqRecRegNo.Text = "";
        txtReqRecPerson.Text = "";
        txtReqReplyDate.Text = "";
        txtReqReplyChalaniNo.Text = "";
        txtRecDate.Text = "";
        txtRecRegNo.Text = "";
        txtRecPerson.Text = "";
        txtReturnDate.Text = "";
        txtRemarks.Text = "";

        DDLMisilType.SelectedIndex = -1;
        DDLReqOrg.SelectedValue = orgID.ToString();

        chkIsReturned.Checked = false;
        Session["Rec"] = null;
        Session["ReqRec"] = null;
        Session["PersonName"] = null;
        Session["PersonID"] = null;
        Session["CaseID"] = null;
    }

    protected void btnReqRecNewPerson_Click(object sender, EventArgs e)
    {
        Session["ReqRec"] = "ReqRec";
        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('MisilInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnRecNewPerson_Click(object sender, EventArgs e)
    {
        Session["Rec"] = "Rec";
        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('MisilInfo.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["CaseID"] == null)
        {
            lblStatusMessage.Text = "Please Litigant First";
            programmaticModalPopup.Show();
            return;
        }
        if (DDLMisilType.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Misil Type First";
            programmaticModalPopup.Show();
            return;
        }
        if (DDLReqOrg.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Please Organization First";
            programmaticModalPopup.Show();
            return;
        }
        if (txtReqDate.Text == "")
        {
            lblStatusMessage.Text = "Please Enter Requested Date First";
            programmaticModalPopup.Show();
            return;
        }

        ATTMisil objMisil = new ATTMisil();
        objMisil.CaseID = double.Parse(Session["CaseID"].ToString());
        objMisil.ReqDate = txtReqDate.Text.Trim();
        objMisil.ReqOrg = int.Parse(DDLReqOrg.SelectedValue);
        objMisil.DocTypeID = int.Parse(DDLMisilType.SelectedValue);
        objMisil.ReqChalaniNo = txtReqChalaniNo.Text.Trim();
        objMisil.ReqRecDate = txtReqRecDate.Text.Trim();
        objMisil.ReqRecDartaNo = txtReqRecRegNo.Text.Trim();
        objMisil.ReqRecPID = double.Parse(hdnReqRecPersonID.Value.ToString());
        objMisil.ReqReplyDate = txtReqReplyDate.Text.Trim();
        objMisil.ReqReplyChalaniNo = txtReqReplyChalaniNo.Text.Trim();
        objMisil.RecDate = txtRecDate.Text.Trim();
        objMisil.RecDartaNo = txtRecRegNo.Text.Trim();
        objMisil.RecPID = double.Parse(hdnRecPersonID.Value.ToString());
        objMisil.IsReturn = (chkIsReturned.Checked == true) ? "Y" : "N";
        objMisil.ReturnDate = txtReturnDate.Text.Trim();
        objMisil.Remarks = txtRemarks.Text.Trim();
        objMisil.EntryBy = strUser;

        try
        {
            BLLMisil.SaveMisil(objMisil);
            ClearCotrols();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearCotrols();
    }

    protected void DDLReqOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(DDLReqOrg.SelectedValue) == orgID)
        {
            pnlChalaniNo.Visible = false;
            pnlProcessMisil.Visible = false;
            pnlReplyMisil.Visible = false;
        }
        else
        {
            pnlChalaniNo.Visible = true;
            pnlProcessMisil.Visible = true;
            pnlReplyMisil.Visible = true;
        }
    }

    protected void chkIsReturned_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsReturned.Checked == false)
        {
            txtReturnDate.Visible = false;
            lblReturnDate.Visible = false;
        }
        else
        {
            txtReturnDate.Visible = true;
            lblReturnDate.Visible = true;
        }
    }
    
}
