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

using PCS.FRAMEWORK;
using PCS.PMS.BLL;
using PCS.PMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_Designation : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["ApplicationID"].ToString() == "2")
        {
            this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
            this.Title = "LJMS | Designation";
        }
        else if (Session["ApplicationID"].ToString() == "3")
        {
            this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
            this.Title = "PMS | Designation";
        }
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
        if ((user.MenuList.ContainsKey("3,25,1") == true) || (user.MenuList.ContainsKey("2,12,1") == true))
        {

            if (IsPostBack == false)
            {
                GetDesignation();
                ClearControls();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    
    void GetDesignation()
    {
        string desType="";
        if (Session["ApplicationID"].ToString() == "2")
            desType = "J";
        else if (Session["ApplicationID"].ToString() == "3")
            desType = "O";
        try
            {
                List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null,desType);
                Session["Designation"] = LstDesignation;
                lstDesignation.DataSource = LstDesignation;
                lstDesignation.DataTextField = "DesignationName";
                lstDesignation.DataValueField = "DesignationID";
                lstDesignation.DataBind();

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

        if (this.txtDesignation_Rqd.Text == "" || this.txtServicePeriod.Text=="" || this.txtAgeLimit.Text=="")
        {
            this.lblStatusMessage.Text = "**कृपया पद,सेवा,उमेर सिमा भर्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTDesignation> DesignationList = (List<ATTDesignation>)Session["Designation"];
        int DesgID;
        if (lstDesignation.SelectedIndex == -1)
            DesgID = 0;
        else 
            DesgID = DesignationList[lstDesignation.SelectedIndex].DesignationID;
        string desType="O";
        if (Session["ApplicationID"].ToString() == "2")
            desType = "J";
        int servicePeriod = 0;
        if (this.txtServicePeriod.Text != "")
        {
            servicePeriod = int.Parse(this.txtServicePeriod.Text);
        }
        int ageLimit = 0;
        if (this.txtAgeLimit.Text != "")
        {
            ageLimit = int.Parse(this.txtAgeLimit.Text);
        }
        try
        {
            ATTDesignation ObjAtt = new ATTDesignation(DesgID, txtDesignation_Rqd.Text.Trim(), desType,servicePeriod,ageLimit);

            for (int i = 0; i < lstDesignation.Items.Count; i++)
            {
                if (lstDesignation.SelectedIndex != i)
                {
                    if (DesignationList[i].DesignationName.ToLower() == txtDesignation_Rqd.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Designation Name Already Exists";
                        this.programmaticModalPopup.Show();
                        this.txtDesignation_Rqd.Text = "";
                        this.txtServicePeriod.Text = "";
                        this.txtAgeLimit.Text = "";
                        return;
                    }
                }
            }

            if (BLLDesignation.SaveDesignation(ObjAtt))
            {
                this.lblStatusMessage.Text = "Designation Successfully Saved";
                this.programmaticModalPopup.Show();
            }

            if (lstDesignation.SelectedIndex > -1)
            {
                DesignationList[this.lstDesignation.SelectedIndex].DesignationID = ObjAtt.DesignationID;
                DesignationList[this.lstDesignation.SelectedIndex].DesignationName = txtDesignation_Rqd.Text.Trim();
                DesignationList[this.lstDesignation.SelectedIndex].DesignationType = desType;
                DesignationList[this.lstDesignation.SelectedIndex].ServicePeriod = servicePeriod;
                DesignationList[this.lstDesignation.SelectedIndex].AgeLimit = ageLimit;
            }

            else
            {
                DesignationList.Add(ObjAtt);
            }

            lstDesignation.DataSource = DesignationList;
            lstDesignation.DataTextField = "DesignationName";
            lstDesignation.DataValueField = "DesignationID";
            lstDesignation.DataBind();
            this.lblStatusMessage.Text = "Designation Saved Successfully.";
            this.programmaticModalPopup.Show();
            ClearControls();
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
            List<ATTDesignation> DesignationList = (List<ATTDesignation>)Session["Designation"];

            if (lstDesignation.SelectedIndex > -1)
            {
                BLLDesignation.DeleteDesignation(int.Parse(lstDesignation.SelectedValue.ToString()));

                DesignationList.RemoveAt(lstDesignation.SelectedIndex);
                lstDesignation.DataSource = DesignationList;
                lstDesignation.DataTextField = "DesignationName";
                lstDesignation.DataValueField = "DesignationID";
                lstDesignation.DataBind();
                Session["Designation"] = DesignationList;

                txtDesignation_Rqd.Text = "";
                lstDesignation.SelectedIndex = -1;
             
            }
            else
            {
                this.lblStatusMessage.Text = "Select Designation to Delete";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.lstDesignation.SelectedIndex = -1;
        txtDesignation_Rqd.Text = "";
        this.txtServicePeriod.Text = "";
        this.txtAgeLimit.Text = "";
    }

    protected void lstDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTDesignation> DesignationList = (List<ATTDesignation>)Session["Designation"];
        this.txtDesignation_Rqd.Text = DesignationList[this.lstDesignation.SelectedIndex].DesignationName.Trim();
        this.txtServicePeriod.Text = DesignationList[this.lstDesignation.SelectedIndex].ServicePeriod.ToString();
        this.txtAgeLimit.Text = DesignationList[this.lstDesignation.SelectedIndex].AgeLimit.ToString();
    }

}
