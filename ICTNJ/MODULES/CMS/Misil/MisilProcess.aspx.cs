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

public partial class MODULES_CMS_Misil_MisilProcess : System.Web.UI.Page
{
    string entryBy = "Suman";
    int orgID = 55;
    double userID = 1.0;

    public List<ATTMisil> MisilDartaa
    {
        get { return (Session["MisilInfo"] == null) ? new List<ATTMisil>() : (List<ATTMisil>)Session["MisilInfo"]; }
        set { Session["MisilInfo"] = value; }
    }
    public List<ATTMisil> MisilChalaani
    {
        get { return (Session["MisilChalaani"] == null) ? new List<ATTMisil>() : (List<ATTMisil>)Session["MisilChalaani"]; }
        set { Session["MisilChalaani"] = value; }
    }
    public List<ATTMisil> MisilReply
    {
        get { return (Session["MisilReply"] == null) ? new List<ATTMisil>() : (List<ATTMisil>)Session["MisilReply"]; }
        set { Session["MisilReply"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMisil();
            LoadMisilProcess();
            LoadMisilChalaan();
            LoadMisilReply();

        }
    }

    private void LoadMisil()
    {
        ATTMisil objmisil = new ATTMisil();

        MisilDartaa = null;
        MisilChalaani = null;
        MisilReply = null;

        objmisil.ReqOrg = orgID;
        List<ATTMisil> MisilLST = BLLMisil.GetMisilForProcessing(objmisil);

        MisilDartaa = MisilLST.FindAll(delegate(ATTMisil obj)
                                        {
                                            return (obj.ReqRecDartaNo.Trim() == "");
                                        }
                                       );

        MisilChalaani = MisilLST.FindAll(delegate(ATTMisil obj)
                                        {
                                            return obj.ReqReplyChalaniNo.Trim() == "" && obj.ReqRecDartaNo.Trim() != "";
                                        }
                                       );
        MisilReply = MisilLST.FindAll(delegate(ATTMisil obj)
                                        {
                                            return obj.ReqReplyChalaniNo.Trim() != "" && obj.ReqRecDartaNo.Trim() != "" && obj.RecDartaNo.Trim() == "";
                                        }
                                       );
        
    }

    private void LoadMisilReply()
    {
        grdReply.DataSource = MisilReply;
        grdReply.DataBind();

        grdReply.SelectedIndex = -1;
    }

    private void LoadMisilChalaan()
    {
        grdMisilChalaani.DataSource = MisilChalaani;
        grdMisilChalaani.DataBind();

        grdMisilChalaani.SelectedIndex = -1;
    }

    private void LoadMisilProcess()
    {
        grdMisil.DataSource = MisilDartaa;
        grdMisil.DataBind();

        grdMisil.SelectedIndex = -1;
    }



    #region MisilDartaa
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (grdMisil.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Misil";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtReceivedDate.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Received Date Missing";
            this.programmaticModalPopup.Show();
            return;

        }
        if (txtDartaaNo.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Dartaa No Missing";
            this.programmaticModalPopup.Show();
            return;

        }


        ATTMisil misil = MisilDartaa[grdMisil.SelectedIndex];

        misil.RecDate = txtReceivedDate.Text.Trim();
        misil.ReqRecDartaNo = txtDartaaNo.Text.Trim();
        misil.ReqRecPID = userID;


        if (BLLMisil.EditMisil(misil))
        {
            lblStatusMessage.Text = "Misil Information Saved Successfully";
            this.programmaticModalPopup.Show();
        }
        else
        {
            lblStatusMessage.Text = "Misil Information Was not Saved";
            this.programmaticModalPopup.Show();
        }
        ClearControlsDartaa();


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControlsDartaa();
    }
    private void ClearControlsDartaa()
    {
        LoadMisil();
        LoadMisilProcess();
        LoadMisilChalaan();

        txtReceivedDate.Text = "";
        txtDartaaNo.Text = "";
        txtReplyDate.Text = "";
        txtChalaaniNo.Text = "";

        
    }
    #endregion


    #region MisilChalaani
    protected void btnSubmitMisilChalaani_Click(object sender, EventArgs e)
    {
        if (grdMisilChalaani.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Misil";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtReplyDate.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Reply Date Missing";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtChalaaniNo.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Chalaani No Missing";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTMisil misil = MisilChalaani[grdMisilChalaani.SelectedIndex];

        misil.ReqReplyDate = txtReplyDate.Text.Trim();
        misil.ReqReplyChalaniNo = txtChalaaniNo.Text.Trim();

        if (BLLMisil.EditMisil(misil))
        {
            lblStatusMessage.Text = "Misil Information Saved Successfully";
            this.programmaticModalPopup.Show();
        }
        else
        {
            lblStatusMessage.Text = "Misil Information Was not Saved";
            this.programmaticModalPopup.Show();
        }
        ClearControlsChalaani();

    }
    protected void btnCancelMisilChalaani_Click(object sender, EventArgs e)
    {
        ClearControlsChalaani();
    }
    private void ClearControlsChalaani()
    {
        LoadMisil();
        LoadMisilChalaan();
        LoadMisilReply();

        txtReceivedDate.Text = "";
        txtDartaaNo.Text = "";
        txtReplyDate.Text = "";
        txtChalaaniNo.Text = "";


    }
    #endregion

    #region MisilReply
    protected void btnSubmitMisilReply_Click(object sender, EventArgs e)
    {
        if (grdReply.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "Select Misil";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtReqReplyReceivedDate.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Dartaa No Missing";
            this.programmaticModalPopup.Show();
            return;

        }
        if (txtReqReplyDartaaNo.Text.Trim() == "")
        {
            lblStatusMessage.Text = "Received Date Missing";
            this.programmaticModalPopup.Show();
            return;
        }


        ATTMisil misil = MisilReply[grdReply.SelectedIndex];

        misil.RecDate = txtReqReplyReceivedDate.Text.Trim();
        misil.RecDartaNo = txtReqReplyDartaaNo.Text.Trim();
        misil.RecPID = userID;


        if (BLLMisil.EditMisil(misil))
        {
            lblStatusMessage.Text = "Misil Information Saved Successfully";
            this.programmaticModalPopup.Show();
        }
        else
        {
            lblStatusMessage.Text = "Misil Information Was not Saved";
            this.programmaticModalPopup.Show();
        }
        ClearControlsReply();


    }
    protected void btnCancelMisilReply_Click(object sender, EventArgs e)
    {
        ClearControlsReply();
    }
    private void ClearControlsReply()
    {
        LoadMisil();
        LoadMisilReply();
        txtReqReplyReceivedDate.Text = "";
        txtReqReplyDartaaNo.Text = "";

    }
    #endregion

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdMisil_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[11].Visible = false;



    }
    protected void grdMisilChalaani_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
    protected void grdReply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
       
    }
}
