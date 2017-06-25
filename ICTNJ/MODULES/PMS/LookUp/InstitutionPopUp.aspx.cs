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

//using PCS.PMS.BLL;
//using PCS.PMS.ATT;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_InstitutionPopUp : System.Web.UI.Page
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
        if (((user.MenuList.ContainsKey("3,11,1")) == true) || (user.MenuList.ContainsKey("2,10,1")) == true)
        {
            if (IsPostBack == false)
            {
                GetInstitution();
                GetCountry();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);


    }

    void GetCountry()
    {
        try
        {
            List<ATTCountry> CountryList = BLLCountry.GetCountries(null, 0);

            ddlCountry_Rqd.DataSource = CountryList;
            ddlCountry_Rqd.DataTextField = "CountryEngName";
            ddlCountry_Rqd.DataValueField = "CountryID";
            ddlCountry_Rqd.DataBind();

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void GetInstitution()
    {
        try
        {
            List<ATTInstitution> LstInstitutionName = BLLInstitution.GetInstitution(null, null);
            Session["Institution"] = LstInstitutionName;

            lstInstitution.DataSource = LstInstitutionName;
            lstInstitution.DataTextField = "InstitutionName";
            lstInstitution.DataValueField = "InstitutionID";
            lstInstitution.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTInstitution> InstitutionList = (List<ATTInstitution>)Session["Institution"];
        long InstitutionID;
        string InsType = "";
        if (lstInstitution.SelectedIndex == -1)
            InstitutionID = 0;
        else
            InstitutionID = InstitutionList[lstInstitution.SelectedIndex].InstitutionID;

        if (this.ddlInstitutionType.SelectedIndex == 1)
        {
            InsType = "A";
        }

        else if (this.ddlInstitutionType.SelectedIndex == 2)
        {
            InsType = "T";
        }
        else if (this.ddlInstitutionType.SelectedIndex == 3)
        {
            InsType = "B";
        }

        try
        {
            ATTInstitution ObjAtt = new ATTInstitution
                (
                 InstitutionID,
                 txtInstitutionName_Rqd.Text.Trim(),
                 txtBoardName_Rqd.Text.Trim(),
                 txtLocation_Rqd.Text.Trim(),
                 int.Parse(ddlCountry_Rqd.SelectedValue.ToString()),
                 (this.chkActive.Checked == true ? "Y" : "N"),
                 InsType,
                 user.UserName
                );


            ObjectValidation OV = BLLInstitution.Validate(ObjAtt);
            if (OV.IsValid == false)
            {
                lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }

            for (int i = 0; i < lstInstitution.Items.Count; i++)
            {
                if (lstInstitution.SelectedIndex != i)
                {
                    if (InstitutionList[i].InstitutionName.ToLower() == txtInstitutionName_Rqd.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Institution Name Already Exists";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }




            long NewInstitutionID = BLLInstitution.SaveInstitution(ObjAtt);
            if (NewInstitutionID != null)
            {
                this.lblStatusMessage.Text = "Institution Saved";
                this.programmaticModalPopup.Show();
            }
            if (lstInstitution.SelectedIndex > -1)
            {
                InstitutionList[lstInstitution.SelectedIndex].InstitutionID = NewInstitutionID;
                InstitutionList[lstInstitution.SelectedIndex].InstitutionName = txtInstitutionName_Rqd.Text.Trim();
                InstitutionList[lstInstitution.SelectedIndex].BoardName = txtBoardName_Rqd.Text.Trim();
                InstitutionList[lstInstitution.SelectedIndex].Location = txtLocation_Rqd.Text.Trim();
                InstitutionList[lstInstitution.SelectedIndex].CountryID = int.Parse(ddlCountry_Rqd.SelectedValue.ToString());
                InstitutionList[lstInstitution.SelectedIndex].Active = (chkActive.Checked == true) ? "Y" : "N";
            }

            else
            {
                ObjAtt.InstitutionID = NewInstitutionID;
                InstitutionList.Add(ObjAtt);
            }

            lstInstitution.DataSource = InstitutionList;
            lstInstitution.DataTextField = "InstitutionName";
            lstInstitution.DataValueField = "InstitutionID";
            lstInstitution.DataBind();

            ClearControl();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstInstitution.SelectedIndex > -1)
            {
                BLLInstitution.DeleteInstitution(int.Parse(lstInstitution.SelectedValue.ToString()));

                lstInstitution.Items.RemoveAt(lstInstitution.SelectedIndex);
                txtInstitutionName_Rqd.Text = "";
                txtBoardName_Rqd.Text = "";
                txtLocation_Rqd.Text = "";
                ddlCountry_Rqd.SelectedIndex = -1;
                lstInstitution.SelectedIndex = -1;
                chkActive.Checked = false;
                ddlInstitutionType.SelectedIndex = -1;

                if (lstInstitution.Items.Count == 0)
                    Session["Institution"] = new List<ATTInstitution>();
            }
            else
            {
                this.lblStatusMessage.Text = "Select institution for Delete";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void ClearControl()
    {
        if (lstInstitution.Items.Count == 0)
            Session["Institution"] = new List<ATTInstitution>();
        txtInstitutionName_Rqd.Text = "";
        txtBoardName_Rqd.Text = "";
        txtLocation_Rqd.Text = "";
        ddlCountry_Rqd.SelectedIndex = -1;
        lstInstitution.SelectedIndex = -1;
        chkActive.Checked = false;
        this.ddlInstitutionType.SelectedIndex = -1;
    }

    protected void lstInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTInstitution> InstitutionList = (List<ATTInstitution>)Session["Institution"];
        ATTInstitution Att = InstitutionList[lstInstitution.SelectedIndex];

        try
        {
            txtInstitutionName_Rqd.Text = Att.InstitutionName.ToString();
            txtBoardName_Rqd.Text = Att.BoardName.ToString();
            txtLocation_Rqd.Text = Att.Location.ToString();
            ddlCountry_Rqd.SelectedValue = Att.CountryID.ToString();
            if (Att.Active == "Y")
                chkActive.Checked = true;
            else
                chkActive.Checked = false;
            if (Att.InstitutionType == "A")
            {
                ddlInstitutionType.SelectedIndex = 1;
            }
            else if (Att.InstitutionType == "T")
            {
                ddlInstitutionType.SelectedIndex = 2;
            }
            else if (Att.InstitutionType == "B")
            {
                ddlInstitutionType.SelectedIndex = 3;
            }
            else
            {
                ddlInstitutionType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControl();
    }
}
