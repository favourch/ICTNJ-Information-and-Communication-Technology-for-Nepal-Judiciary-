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

public partial class MODULES_COMMON_LookUp_Institution : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (int.Parse(((HiddenField)this.Master.FindControl("hdnApplicationID")).Value) == 10)
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,29,1") == true)
        {
            if (IsPostBack == false)
            {
                GetInstitution();
                GetCountry();
                chkActive.Checked = true;
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
            List<ATTInstitution> LstInstitutionName = BLLInstitution.GetInstitution(null,"");
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
        string msg = EmptyMessage();
        if (msg != "")
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTInstitution> InstitutionList = (List<ATTInstitution>)Session["Institution"];
        long InstitutionID;

        if (lstInstitution.SelectedIndex == -1)
            InstitutionID = 0;
        else
            InstitutionID = InstitutionList[lstInstitution.SelectedIndex].InstitutionID;

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
                 ddlInstitutionType.SelectedValue,
                 ((ATTUserLogin)Session["Login_User_Detail"]).UserName
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
            if (NewInstitutionID > 0)
            {
                lblStatusMessage.Text = "Saved Successfully";
                programmaticModalPopup.Show();
            }
            if (lstInstitution.SelectedIndex > -1)
            {
                InstitutionList[lstInstitution.SelectedIndex].InstitutionID = NewInstitutionID;
                InstitutionList[lstInstitution.SelectedIndex].InstitutionName = txtInstitutionName_Rqd.Text.Trim();
                InstitutionList[lstInstitution.SelectedIndex].InstitutionType = ddlInstitutionType.SelectedValue;
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

    private string EmptyMessage()
    {
        int count = 0;
        string msg = "";

        if (this.txtInstitutionName_Rqd.Text == "")
        {
            msg += "*--तालिम केन्द्रको नाम भर्नुहोस्";
            count++;
        }
        if (this.txtBoardName_Rqd.Text == "")
        {
            msg += "<br/>*--बोर्डको नाम भर्नुहोस्";
            count++;
        }
        if (this.txtLocation_Rqd.Text == "")
        {
            msg += "<br/>*--ठेगाना भर्नुहोस्";
            count++;
        }
        if (this.ddlCountry_Rqd.SelectedIndex == 0)
        {
            msg += "<br/>*--देशको नाम छान्नुहोस्";
            count++;
        }
        if (this.ddlInstitutionType.Text == "")
        {
            msg += "<br/>*--तालिम केन्द्रको किसिम छान्नुहोस्";
            count++;
        }
        
        if (count > 0)
        {
            return msg;
        }
        else
        {
            return "";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            List<ATTInstitution> InstitutionLST = (List<ATTInstitution>)Session["Institution"];
            if (lstInstitution.SelectedIndex != -1)
            {
                if (BLLInstitution.DeleteInstitution(int.Parse(lstInstitution.SelectedValue)) == true)
                {
                    InstitutionLST.RemoveAt(lstInstitution.SelectedIndex);
                    lstInstitution.DataSource = InstitutionLST;
                    lstInstitution.DataTextField = "InstitutionName";
                    lstInstitution.DataValueField = "InstitutionID";
                    lstInstitution.DataBind();
                    ClearControl();
                }
                else
                {
                    this.lblStatusMessage.Text = "Institution doesn't save successfully";
                    this.programmaticModalPopup.Show();
                    return;
                }
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
        txtBoardName_Rqd.Text  = "";
        txtLocation_Rqd.Text  = "";
        ddlCountry_Rqd.SelectedIndex = -1;
        lstInstitution.SelectedIndex = -1;
        ddlInstitutionType.SelectedIndex = 0;
        txtInstitutionName_Rqd.Focus();
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
            ddlInstitutionType.SelectedValue = Att.InstitutionType;
            if (Att.Active == "Y")
                chkActive.Checked = true;
            else
                chkActive.Checked = false;
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
