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

using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;




using System.Collections.Generic;
using System.Reflection;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_Tameli_TameliFeedBack : System.Web.UI.Page
{
    int orgID = 9;
    string entryBy = "Suman";
    double userID = 213.0;


    public List<ATTTameliSearch> TameliSend
    {
        get { return (Session["TameliSend"] == null) ? new List<ATTTameliSearch>() : (List<ATTTameliSearch>)Session["TameliSend"]; }
        set { Session["TameliSend"] = value; }
    }

    public List<ATTTameliSearch> TameliProcesss
    {
        get { return (Session["TameliProcesssDelete"] == null) ? new List<ATTTameliSearch>() : (List<ATTTameliSearch>)Session["TameliProcesssDelete"]; }
        set { Session["TameliProcesssDelete"] = value; }
    }

    public List<ATTTameliWitnessPerson> TameliWitnessPers
    {
        get { return (Session["TameliWitnessPers"] == null) ? new List<ATTTameliWitnessPerson>() : (List<ATTTameliWitnessPerson>)Session["TameliWitnessPers"]; }
        set { Session["TameliWitnessPers"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearSession();
            LoadTameliList();
            LoadTameliStatus();
            LoadDeleteData();
            pnlTamWitPerson.Visible = false;
            lblTameliStatus.Visible = false;
            ddlTameliStatus.Visible = false;
            grdWitPerson.Visible = false;

        }
    }


    private void ClearSession()
    {
        TameliSend = null;
        TameliProcesss = null;
        TameliWitnessPers = null;

    }
    private void LoadTameliList()
    {
        try
        {
            ATTTameliSearch obj = new ATTTameliSearch();

            obj.OrgID = orgID;            
           
            obj.TameliYesNo = "null";
            obj.TameliDate = "null";
            obj.SecClrkRcvdDate = "null";
            obj.VerifiedYesNo = "null";

            List<ATTTameliSearch> lst = BLLTameliSearch.GetTameliForFeedBack(obj);
            TameliSend = lst;

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
    private void LoadTameliStatus()
    {
        try
        {
            List<ATTTameliStatus> tameliStatusLIST = BLLTameliStatus.GetTameliStatus(null, null);
            tameliStatusLIST.Insert(0, new ATTTameliStatus(0, "Choose", "Y"));

            ddlTameliStatus.DataSource = tameliStatusLIST;
            ddlTameliStatus.DataBind();
            ddlTameliStatus.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could Not Load Tameli Status </br>";
            this.programmaticModalPopup.Show();
        }


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

            if (txtTameliDate.Text == "____/__/__" || txtTameliDate.Text.Trim() == "")
            {
                lblStatusMessage.Text = "Tameli Date Missing";
                this.programmaticModalPopup.Show();
                return;
            }
            if (txtSecClrkRcvdDate.Text == "____/__/__" || txtSecClrkRcvdDate.Text.Trim() == "")
            {
                lblStatusMessage.Text = "SectionClerk Received Date Missing";
                this.programmaticModalPopup.Show();
                return;
            }
            if (rdblstTameliSuccess.SelectedIndex < 0)
            {
                lblStatusMessage.Text = "Choose Success Yes/No";
                this.programmaticModalPopup.Show();
                return;
            }
            else if (rdblstTameliSuccess.SelectedIndex == 0)
            {
                if (ddlTameliStatus.SelectedIndex < 1)
                {
                    lblStatusMessage.Text = "Select Tameli Status";
                    this.programmaticModalPopup.Show();
                    return;
                }
                //if (ddlTameliStatus.SelectedIndex == 1)
                //{
                //    if (true)
                //    {
                        //if (txtTameliWitnessPerson.Text.Trim() == "")
                        //{
                        //    lblStatusMessage.Text = "Tameli Witness Person Missing";
                        //    this.programmaticModalPopup.Show();
                        //    return;
                        //}
                        //if (txtPost.Text.Trim() == "")
                        //{
                        //    lblStatusMessage.Text = "Post of Tameli Witness Person Missing";
                        //    this.programmaticModalPopup.Show();
                        //    return;
                        //}
                //    }
                //}
            }
            
            

            ATTTameli tamProcess = new ATTTameli();

            ATTTameliSearch tamSearch = TameliSend[grdTameli.SelectedIndex];

            tamProcess.CaseID = tamSearch.CaseID;
            tamProcess.LitigantID = tamSearch.LitigantID;
            tamProcess.IssuedDate = tamSearch.IssuedDate;
            tamProcess.SeqNo = tamSearch.SeqNo;

            tamProcess.TameliDate = txtTameliDate.Text.Trim();
            tamProcess.SecClrkRcvdDate = txtSecClrkRcvdDate.Text.Trim();
            tamProcess.TameliYesNo = rdblstTameliSuccess.SelectedValue;
            tamProcess.TameliStatusID = int.Parse(ddlTameliStatus.SelectedValue);

            //tamProcess.TameliStatusID = (tamProcess.TameliYesNo == "Y") ? int.Parse(ddlTameliStatus.SelectedValue) : null;
            tamProcess.TamilDaarRemrks = txtTameliRemarks.Text.ToString();


            //if (tamProcess.TameliStatusID==1)
            if (tamProcess.TameliYesNo == "Y")
            {
                List<ATTTameliWitnessPerson> lst = TameliWitnessPers;

                foreach (ATTTameliWitnessPerson var in lst)
                {                    
                    var.CaseID = tamProcess.CaseID;
                    var.LitigantID = tamProcess.LitigantID ;
                    var.IssuedDate = tamProcess.IssuedDate;
                    var.SeqNo = tamProcess.SeqNo;                
                    var.Action = "A";
                    var.EntryBy = entryBy;
                }
                tamProcess.TameliWitnessPersonLIST = lst;                           
            }          



            if (BLLTameli.SaveTamelildaarFeedBack(tamProcess))
            {
                lblStatusMessage.Text = "Tameli Processed Successfully";
                this.programmaticModalPopup.Show();
            }
            else
            {
                lblStatusMessage.Text = "Problem Occured";
                this.programmaticModalPopup.Show();
            }
            ClearSession();
            LoadTameliList();
            ClearControls();
            LoadDeleteData();
            
            
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = "Select Tameli To Be Processed " + ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void grdTameli_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    protected void rdblstTameliSuccess_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblstTameliSuccess.SelectedIndex == 0)
        {
            ddlTameliStatus.Visible = true;
            lblTameliStatus.Visible = true;
            ddlTameliStatus.SelectedIndex = -1;

            pnlTamWitPerson.Visible = true;
            grdWitPerson.Visible = true;
        }
        else
        {
            ddlTameliStatus.Visible = false;
            lblTameliStatus.Visible = false;
            pnlTamWitPerson.Visible = false;
            grdWitPerson.Visible = false;

        }
    }
    //protected void ddlTameliStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTameliStatus.SelectedIndex == 1)
    //    {
    //        pnlTamWitPerson.Visible = true;
    //    }
    //    else pnlTamWitPerson.Visible = false;
    //}

    private void ClearControls()
    {
        LoadTameliList();
        txtTameliDate.Text = "";
        txtSecClrkRcvdDate.Text = "";
        rdblstTameliSuccess.SelectedIndex = -1;
        ddlTameliStatus.SelectedIndex = -1;
        ddlTameliStatus.Visible = false;
        txtTameliWitnessPerson.Text = "";
        txtPost.Text = "";
        pnlTamWitPerson.Visible = false;
        txtTameliRemarks.Text = "";
        lblTameliStatus.Visible = false;

    }
    protected void grdTam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
    protected void grdTam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ATTTameli tam = new ATTTameli();            

            tam.CaseID = TameliProcesss[e.RowIndex].CaseID;
            tam.LitigantID = TameliProcesss[e.RowIndex].LitigantID;
            tam.IssuedDate = TameliProcesss[e.RowIndex].IssuedDate;
            tam.SeqNo = TameliProcesss[e.RowIndex].SeqNo;

            tam.TameliDate = null;
            tam.TameliYesNo = null;
            tam.SecClrkRcvdDate = null;
            tam.TamilDaarRemrks = null;
            tam.TameliStatusID = null;

            ATTTameliWitnessPerson TamWitPerson = new ATTTameliWitnessPerson();
            TamWitPerson.CaseID = tam.CaseID;
            TamWitPerson.LitigantID = tam.LitigantID;
            TamWitPerson.IssuedDate = tam.IssuedDate;
            TamWitPerson.SeqNo = tam.SeqNo; 
            TamWitPerson.Action = "D";


            tam.TameliWitnessPersonLIST.Clear();
            tam.TameliWitnessPersonLIST.Add(TamWitPerson);

            BLLTameli.SaveTamelildaarFeedBack(tam);
            LoadTameliList();
            ClearControls();
            LoadDeleteData();

        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = "Tameli  Could Not Be Deleted" + ex.Message.ToString();
            programmaticModalPopup.Show();
        }
    }

    private void LoadDeleteData()
    {
        ATTTameliSearch obj = new ATTTameliSearch();

        obj.OrgID = orgID;//new

        obj.TameliYesNo = "Y";
        //obj.TameliYesNo = "notnull";
        obj.VerifiedYesNo = "null";
        obj.TameliDate = "notnull";
        obj.SecClrkRcvdDate = "notnull";

        List<ATTTameliSearch> lst = BLLTameliSearch.GetTameliSearch(obj);
        TameliProcesss = lst;
        grdTam.DataSource = lst;


        grdTam.DataBind();
        grdTam.SelectedIndex = -1;

    }
    protected void grdWitPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTTameliWitnessPerson> TameliWitness = TameliWitnessPers;

        TameliWitness.RemoveAt(e.RowIndex);        

        TameliWitnessPers = TameliWitness;

        grdWitPerson.DataSource = TameliWitnessPers;
        grdWitPerson.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtTameliWitnessPerson.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Tameli Witness Person Missing";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtPost.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Post of Tameli Witness Person Missing";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTTameliWitnessPerson> TameliWitness = TameliWitnessPers;


        ATTTameliWitnessPerson obj = new ATTTameliWitnessPerson();
        obj.FullName = txtTameliWitnessPerson.Text.Trim();
        obj.Post = txtPost.Text;
        TameliWitness.Add(obj);

        TameliWitnessPers = TameliWitness;

        grdWitPerson.DataSource = TameliWitnessPers;
        grdWitPerson.DataBind();

        txtTameliWitnessPerson.Text = "";
        txtPost.Text = "";

    }
    protected void grdTameli_SelectedIndexChanged(object sender, EventArgs e)
    {
        TameliWitnessPers = null;
    }
}
