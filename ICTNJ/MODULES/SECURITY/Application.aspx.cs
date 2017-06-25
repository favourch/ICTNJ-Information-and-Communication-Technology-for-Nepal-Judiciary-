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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;

using System.Collections.Generic;

public partial class MODULES_SECURITY_Application : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.RedirectLocation = "sss";
        if (this.IsPostBack == false)
        {
            Session["LstApp"] = BLLApplication.GetApplicationList(1);

            this.lstApplication.DataSource = (List<ATTApplication>)Session["LstApp"];
            this.lstApplication.DataTextField = "ApplicationFullName";
            this.lstApplication.DataValueField = "ApplicationID";

            this.lstApplication.DataBind();
        }
    }

    protected void btnAddForm_Click(object sender, EventArgs e)
    {
        //if (this.lstApplication.SelectedIndex < 0)
        //{
        //    List<ATTApplication> lstApp = (List<ATTApplication>)Session["LstApp"];
        //    ATTApplication app = new ATTApplication(0, this.txtShortName_Rqd.Text, this.txtApplication_Rqd.Text, this.txtAppDesc.Text, "A");

        //    ObjectValidation OV = BLLApplication.Validate(app);

        //    if (OV.IsValid == false)
        //    {
        //        this.lblStatus.Text = OV.ErrorMessage;
        //        return;
        //    }

        //    ATTApplicationForm appForm = new ATTApplicationForm(0, 0, this.txtFormName_Rqd.Text, this.txtFrmDesc.Text, "A");

        //    ObjectValidation OV = BLLApplicationForm.Validate(appForm);

        //    if (OV.IsValid == false)
        //    {
        //        this.lblStatus.Text = OV.ErrorMessage;
        //        return;
        //    }

        //    app.LstApplicationForm.Add(appForm);

        //    this.grdForm.DataSource = app.LstApplicationForm;
        //    this.grdForm.DataBind();

        //    lstApp.Add(app);

        //    this.ClearFormsControls();
        //}
    }

    private void ClearFormsControls()
    {
        //this.txtFormName_Rqd.Text = "";
        //this.txtFrmDesc.Text = "";

        //this.lblStatus.Text = "";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ATTApplication appObj = new ATTApplication(0, txtShortName_Rqd.Text, this.txtApplication_Rqd.Text, this.txtAppDesc.Text, "A");

        ObjectValidation OV = BLLApplication.Validate(appObj);

        if (OV.IsValid == false)
        {
            this.lblStatus.Text = OV.ErrorMessage;
            return;
        }

        List<ATTApplication> lst = (List<ATTApplication>)Session["LstApp"];

        try
        {
            BLLApplication.AddApplication(appObj);
            lst.Add(appObj);

            lst.Sort(delegate(ATTApplication a1, ATTApplication a2) { return a1.ApplicationFullName.CompareTo(a2.ApplicationFullName); });

            this.lstApplication.DataSource = lst;
            this.lstApplication.DataTextField = "ApplicationFullName";
            this.lstApplication.DataValueField = "ApplicationID";

            this.lstApplication.DataBind();

            this.ClearApplication();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    private void ClearApplication()
    {
        this.txtAppDesc.Text = "";
        this.txtApplication_Rqd.Text = "";
        this.txtShortName_Rqd.Text = "";
        this.lblStatus.Text = "";
        this.lstApplication.SelectedIndex = -1;
    }

    protected void lstApplication_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTApplication> lst = (List<ATTApplication>)Session["LstApp"];

        ATTApplication obj = lst[this.lstApplication.SelectedIndex];

        this.txtApplication_Rqd.Text = obj.ApplicationFullName;
        this.txtShortName_Rqd.Text = obj.ApplicationShortName;
        this.txtAppDesc.Text = obj.ApplicationDescription;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearApplication();
    }
}
