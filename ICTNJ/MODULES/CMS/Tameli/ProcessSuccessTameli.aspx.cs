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


using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;



public partial class MODULES_CMS_Tameli_ProcessSuccessTameli : System.Web.UI.Page
{
    public List<ATTTameliSearch> TameliProcesss
    {
        get { return (Session["TameliProcesssSuccess"] == null) ? new List<ATTTameliSearch>() : (List<ATTTameliSearch>)Session["TameliProcesssSuccess"]; }
        set { Session["TameliProcesssSuccess"] = value; }
    }

    int orgID = 9;
    string entryBy = "Suman";
    double userID = 213.0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCaseType();
        }

    }
    private void LoadCaseType()
    {
        List<ATTCaseType> caseTypeLST = BLLCaseType.GetCaseType(null, "Y", 1);

        ddlCaseType.DataSource = caseTypeLST;
        ddlCaseType.DataBind();
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.ddlCaseType.SelectedIndex < 1) && (this.txtCaseNo.Text == "___-__-____") && (this.txtRegNo.Text == "__-___-_____") &&
                   (this.txtRegDate.Text == "____/__/__") && (this.txtVerifiedDate.Text.Trim() == "") && (this.txtRespondantName.Text.Trim() == ""))
        {
            this.lblStatusMessage.Text = "Please Enter (Or) Select Atleast One Field.";
            this.programmaticModalPopup.Show();
            return;
        }
        

        try
        {
            ATTTameliSearch obj = new ATTTameliSearch();

            obj.OrgID = orgID;

            if (ddlCaseType.SelectedIndex > 0) obj.CaseTypeID = int.Parse(ddlCaseType.SelectedValue);
            if (txtRegNo.Text.Trim() != "" && txtRegNo.Text.Trim() != "__-___-_____") obj.RegNo = txtRegNo.Text;
            if (txtCaseNo.Text.Trim() != "" && txtCaseNo.Text.Trim() != "___-__-____") obj.CaseNo = txtCaseNo.Text;
            if (txtRegDate.Text.Trim() != "" && txtRegDate.Text.Trim() != "____/__/__") obj.CaseRegDate = txtRegDate.Text;
            //if (txtAppelantName.Text.Trim() != "") obj.Appelant = txtAppelantName.Text;
            //if (txtRespondantName.Text.Trim() != "") obj.Respondant = txtRespondantName.Text;


            obj.TameliYesNo = "Y";
            obj.VerifiedYesNo = "null";
            obj.TameliDate = "notnull";
            obj.SecClrkRcvdDate = "notnull";

            List<ATTTameliSearch> lst = BLLTameliSearch.GetTameliSearch(obj);
            TameliProcesss = lst;
            grdTameli.DataSource = lst;
          

            grdTameli.DataBind();
            grdTameli.SelectedIndex = -1;

            
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnCancelSearch_Click(object sender, EventArgs e)
    {


       ClearControls(true,false);
        
        this.lblStatusMessage.Text = "Search Cancelled";
        this.programmaticModalPopup.Show();
    }

    private void ClearControls(bool search, bool other)
    {
        if (search)
        {
            ddlCaseType.SelectedIndex = -1;
            txtCaseNo.Text = "";
            txtRegNo.Text = "";
            txtRegDate.Text = "";
            txtRespondantName.Text = "";
            txtAppelantName.Text = "";
        }

        if (other)
        {
            txtVerifiedDate.Text = "";
            rdblstVerify.SelectedIndex = -1;
            txtRemarks.Text = "";
            grdTameli.DataSource = null;
            grdTameli.DataBind();
        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdTameli.SelectedIndex < 0)
            {
                lblStatusMessage.Text = "Select Tameli To Be Processed";
                this.programmaticModalPopup.Show();
                return;
            }

            if (txtVerifiedDate.Text == "____/__/__" || txtVerifiedDate.Text.Trim() == "")
            {
                lblStatusMessage.Text = "Verified Date Missing";
                this.programmaticModalPopup.Show();
                return;
            }
            if (rdblstVerify.SelectedIndex < 0)
            {
                lblStatusMessage.Text = "Select Verify Yes/No";
                this.programmaticModalPopup.Show();
                return;
            }

            ATTTameli tamProcess = new ATTTameli();

            ATTTameliSearch tamSearch = TameliProcesss[grdTameli.SelectedIndex];

            tamProcess.CaseID = tamSearch.CaseID;
            tamProcess.LitigantID = tamSearch.LitigantID;
            tamProcess.IssuedDate = tamSearch.IssuedDate;
            tamProcess.SeqNo = tamSearch.SeqNo;

            tamProcess.VerifiedDate = txtVerifiedDate.Text.Trim();
            tamProcess.VerifiedBy = userID;
            tamProcess.VerifiedYesNo = (rdblstVerify.SelectedIndex == 0) ? "Y" : "N";
            tamProcess.VerifiedRemarks = txtRemarks.Text.ToString();
            if (BLLTameli.ProcessTameli(tamProcess))
            {
                lblStatusMessage.Text = "Tameli Processed Successfully";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Problem Occured";
                this.programmaticModalPopup.Show();
            }
            ClearControls(true, true);
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = "Select Tameli To Be Processed " + ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(true, true);
    }
    protected void grdTameli_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[0].Visible = false;

    }
}
