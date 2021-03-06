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

public partial class MODULES_OAS_Tippani_VisitTippaniEdit : System.Web.UI.Page
{
    new ATTUserLogin User
    {
        get
        {
            return Session["Login_User_Detail"] as ATTUserLogin;
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            if (Session["TippaniInfo_Edit"] == null || Session["TippaniInfo_Edit"].ToString() == "")
            {
                return;
            }
            else
            {
                this.LoadVisitTippaniDetail();
            }
        }
    }

    void LoadVisitTippaniDetail()
    {
        ATTGeneralTippaniProcess process = Session["TippaniInfo_Edit"] as ATTGeneralTippaniProcess;
        try
        {
            //ATTGeneralTippaniSummary summary = BLLGeneralTippani.GetVisitTippaniDetail
            //                                (
            //                                    process.OrgID,
            //                                    process.TippaniID,
            //                                    1
            //                                );

            //this.lblEmployeeIdentity.Text = "कर्मचारी " + summary.EmpName + " को लागी उठाएको टप्पणी";
            //this.txtTippaniText.Text = summary.TippaniText;
            //this.VisitTippani.SetVisitTipppaniDetail(summary);

            //this.hdnOrgID.Value = summary.OrgID.ToString();
            //this.hdnTippaniID.Value = summary.TippaniID.ToString();
            //this.hdnProcessID.Value = "1";

            //Session["TippaniInfo_Edit"] = null;
            //Session.Remove("TippaniInfo_Edit");
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ATTGeneralTippani tippani = new ATTGeneralTippani();

        //tippani.TippaniName = TippaniSubject.Visit;
        //tippani.OrgID = int.Parse(this.hdnOrgID.Value);
        //tippani.TippaniID = int.Parse(this.hdnTippaniID.Value);
        //tippani.TippaniSubjectID = 2;
        //tippani.TippaniBy = this.User.UserName;
        //tippani.TippaniOn = "";
        //tippani.TippaniText = this.txtTippaniText.Text;
        //tippani.FinalStatus = 1;
        //tippani.Action = "E";

        //tippani.TippaniDetail = this.VisitTippani.GetVisitTippaniDetail(tippani.OrgID, tippani.TippaniID, 0, this.User.UserName);
        //if (tippani.TippaniDetail == null)
        //    return;

        //tippani.TippaniDetail.TippaniSNO = 1;
        //tippani.TippaniDetail.Action = "E";

        ///****************** extra added for self process ******************/
        //ATTGeneralTippaniProcess selfProcess = new ATTGeneralTippaniProcess();
        //selfProcess.OrgID = tippani.OrgID;
        //selfProcess.TippaniID = tippani.TippaniID;
        //selfProcess.TippaniProcessID = 1;
        //selfProcess.SendBy = null;
        //selfProcess.SendOn = "";
        //selfProcess.SendTo = (int)this.User.PID;
        //selfProcess.Note = this.VisitTippani.Note.Text;
        //selfProcess.Status = int.Parse(this.VisitTippani.Status.SelectedValue);
        //selfProcess.SendType = "F";
        //selfProcess.IsChannelPerson = "Y";
        //selfProcess.EntryBy = this.User.UserName;
        //selfProcess.Action = "E";

        //tippani.LstTippaniProcess.Add(selfProcess);

        //try
        //{
        //    BLLGeneralTippani.AddGeneralTippani(tippani);

        //    Response.Redirect("~/modules/oas/tippani/tippanisearch.aspx");
        //}
        //catch (Exception ex)
        //{
        //    this.lblStatusMessage.Text = ex.Message;
        //    this.programmaticModalPopup.Show();
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/modules/oas/tippani/tippanisearch.aspx");
    }
}
