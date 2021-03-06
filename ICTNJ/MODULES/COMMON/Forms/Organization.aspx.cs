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

using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;

public partial class Forms_Organization : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
        //this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,53,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (this.IsPostBack == false)
            {
                GetOrganization();
                GetOrgType();
                GetDistrict();

                Session["OrgId"] = "";
                Session["LstPhone"] = null;
                Session["LstEmail"] = null;
                Session["LstPhone"] = new List<ATTPhone>();
                Session["LstEmail"] = new List<ATTEmail>();
            }
        }
        else
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
    }

    private void GetOrganization()
    {
        
        try
        {
            List<ATTOrganization> lstOrg;
            lstOrg = BLLOrganization.GetOrganization();
            Session["OrgList"] = lstOrg;
            
            this.lstOrgList.DataSource = lstOrg;
            this.lstOrgList.DataTextField = "OrgName";
            this.lstOrgList.DataValueField = "OrgId";
            this.lstOrgList.DataBind();
           
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private void GetOrgType()
    {
        List<ATTOrganizationType> LstOrgType;
        try
        {
            LstOrgType = BLLOrganizationType.GetOrgType();

            Session["LstOrgType"] = LstOrgType;

            LstOrgType.Insert(0, new ATTOrganizationType("0", "--Select One--"));

            this.ddlOrgType_Rqd.DataSource = LstOrgType;
            this.ddlOrgType_Rqd.DataTextField = "OrgTypeDesc";
            this.ddlOrgType_Rqd.DataValueField = "OrgTypeCode";
            this.ddlOrgType_Rqd.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void GetDistrict()
    {
        List<ATTDistrict> lstDistrict;
        try
        {
            lstDistrict = PCS.COMMON.BLL.BLLDistrict.GetDistricts(null, 0);
            this.ddlOrgDistrict_Rqd.DataSource = lstDistrict;
            this.ddlOrgDistrict_Rqd.DataTextField = "DistUCode";
            this.ddlOrgDistrict_Rqd.DataValueField = "DistCode";
            this.ddlOrgDistrict_Rqd.DataBind();
            Session["DistrictList"] = lstDistrict;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
      
    }

    public void ClearControls()
    {
        try
        {
            this.txtOrgName_Rqd.Text = "";
            this.txtCourtCode_Rqd.Text = "";
            this.txtAddress_Rqd.Text = "";
            this.txtOrgEmail.Text = "";
            this.txtOrgPhone.Text = "";
            this.txtStreet.Text = "";
            this.txtUrl.Text = "";

            this.ddlOrgDistrict_Rqd.SelectedIndex = 0;
            this.ddlVdcMun_Rqd.Items.Clear();
            this.ddlWard_Rqd.Items.Clear();
            this.ddlOrgType_Rqd.SelectedIndex = 0;
            this.ddlOrgSubType_Rqd.Items.Clear();
            this.ddlOrgParent.Items.Clear();
            this.ddlPhoneType.SelectedIndex = 0;
            this.ddlEmailType.SelectedIndex = 0;
            this.chkEmail.Checked = false;
            this.chkPhone.Checked = false;
            this.lstOrgList.SelectedIndex = -1;
            this.grdPhone.DataSource = "";
            this.grdEmail.DataSource = "";
            this.grdPhone.DataBind();
            this.grdEmail.DataBind();
            this.lblCourtCode_Rqd.Visible = false;
            this.txtCourtCode_Rqd.Visible = false;

           
            Session["LstPhone"] = null;
            Session["LstPhone"] = new List<ATTPhone>();
            Session["LstEmail"] = null;
            Session["LstEmail"] = new List<ATTEmail>();

        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblStatusMessage.Text = "";

            List<ATTOrganization> lstOrg = (List<ATTOrganization>)Session["OrgList"];

            int orgID = 0;
            if (this.lstOrgList.SelectedIndex > -1)
                orgID = lstOrg[this.lstOrgList.SelectedIndex].OrgID;


            ATTOrganization objOrg = new ATTOrganization(
                                                            orgID,
                                                            this.txtOrgName_Rqd.Text.Trim(),
                                                            this.ddlOrgType_Rqd.SelectedValue,
                                                            this.ddlOrgSubType_Rqd.SelectedValue,
                                                           (ddlOrgParent.SelectedValue.ToString() == "") ? 0 : int.Parse(this.ddlOrgParent.SelectedValue.ToString())
                                                        );

            foreach (ListItem lst in lstOrgList.Items)
            {
                if (lst.Text.ToLower() == txtOrgName_Rqd.Text.Trim().ToLower() && orgID == 0)
                {
                    this.lblStatusMessage.Text = "Organization Name Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }

            objOrg.OrgAddress = txtAddress_Rqd.Text.Trim();
            objOrg.OrgDistrict = (ddlOrgDistrict_Rqd.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlOrgDistrict_Rqd.SelectedValue.ToString());
            objOrg.OrgStreetName = txtStreet.Text.Trim();
            objOrg.OrgVdcMuni = (ddlVdcMun_Rqd.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlVdcMun_Rqd.SelectedValue.ToString());
            objOrg.OrgWardNo = (ddlWard_Rqd.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlWard_Rqd.SelectedValue.ToString());
            objOrg.OrgUrl = txtUrl.Text.Trim();
            
           
            foreach (ATTOrganization Att in lstOrg)
            {
                if (txtCourtCode_Rqd.Text.Trim().ToLower() == Att.OrgEquCode.ToString().ToLower() && orgID == 0)
                {
                    this.lblStatusMessage.Text = "Organization Code Already Exists";
                    this.programmaticModalPopup.Show();
                    return;
                }
               
            }
            if (this.ddlOrgType_Rqd.SelectedValue == "CRT" && int.Parse(txtCourtCode_Rqd.Text.ToString()) == 0 && orgID > 0)
            {
                this.lblStatusMessage.Text = "Organization Code Should Not be Zero!!";
                this.programmaticModalPopup.Show();
                return;
            }


            if (this.ddlOrgType_Rqd.SelectedValue == "CRT")
                objOrg.OrgEquCode = (txtCourtCode_Rqd.Text.ToString() == "") ? 0 : int.Parse(txtCourtCode_Rqd.Text.ToString());
            else
                objOrg.OrgEquCode = 0;
  
          
            objOrg.LstPhone = (List<ATTPhone>)Session["LstPhone"];
            //objOrg.LstFax = (List<ATTFax>)Session["LstFax"];
            objOrg.LstEmail = (List<ATTEmail>)Session["LstEmail"];


            ObjectValidation OV = BLLOrganization.Validate(objOrg);
            if (OV.IsValid == false)
            {
                lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }



            int newOrgID = 0;
            newOrgID = BLLOrganization.SaveOrganization(objOrg);
            if (newOrgID != 0)
            {
                this.lblStatusMessage.Text = "Organization Information Saved Successfully";
                this.programmaticModalPopup.Show();
            }
            if (this.lstOrgList.SelectedIndex > -1)
            {
                lstOrg[this.lstOrgList.SelectedIndex].OrgID = newOrgID;
                lstOrg[this.lstOrgList.SelectedIndex].OrgName = this.txtOrgName_Rqd.Text.Trim();
                lstOrg[this.lstOrgList.SelectedIndex].OrgType = this.ddlOrgType_Rqd.SelectedValue;
                lstOrg[this.lstOrgList.SelectedIndex].OrgSubType = this.ddlOrgSubType_Rqd.SelectedValue;
                lstOrg[this.lstOrgList.SelectedIndex].ParentId = int.Parse(this.ddlOrgParent.SelectedValue.ToString());
                lstOrg[this.lstOrgList.SelectedIndex].OrgAddress = txtAddress_Rqd.Text.Trim();
                lstOrg[this.lstOrgList.SelectedIndex].OrgDistrict = int.Parse(ddlOrgDistrict_Rqd.SelectedValue.ToString());
                lstOrg[this.lstOrgList.SelectedIndex].OrgStreetName = txtStreet.Text.Trim();
                lstOrg[this.lstOrgList.SelectedIndex].OrgVdcMuni = int.Parse(ddlVdcMun_Rqd.SelectedValue.ToString());
                lstOrg[this.lstOrgList.SelectedIndex].OrgWardNo = int.Parse(ddlWard_Rqd.SelectedValue.ToString());
                lstOrg[this.lstOrgList.SelectedIndex].OrgUrl = txtUrl.Text.Trim();
                lstOrg[this.lstOrgList.SelectedIndex].OrgEquCode = int.Parse(txtCourtCode_Rqd.Text.ToString());
                lstOrg[this.lstOrgList.SelectedIndex].LstPhone.Clear();
                lstOrg[this.lstOrgList.SelectedIndex].LstEmail.Clear();

                foreach (GridViewRow row in this.grdEmail.Rows)
                {

                    ATTEmail orgEMail = new ATTEmail(row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text);
                    lstOrg[this.lstOrgList.SelectedIndex].LstEmail.Add(orgEMail);

                }

                foreach (GridViewRow row in this.grdPhone.Rows)
                {

                    ATTPhone orgPhone = new ATTPhone(row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text);
                    lstOrg[this.lstOrgList.SelectedIndex].LstPhone.Add(orgPhone);

                }
            }

            else
            {
                objOrg.OrgID = newOrgID;
                lstOrg.Add(objOrg);
            }
                


            Session["OrgList"] = lstOrg;
            this.lstOrgList.DataSource = lstOrg;
            this.lstOrgList.DataTextField = "OrgName";
            this.lstOrgList.DataValueField = "OrgId";
            this.lstOrgList.DataBind();


            ClearControls();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstOrgList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (lstOrgList.SelectedIndex > -1)
            {
                List<PCS.COMMON.ATT.ATTOrganization> lst = (List<PCS.COMMON.ATT.ATTOrganization>)Session["OrgList"];
                PCS.COMMON.ATT.ATTOrganization obj = lst[lstOrgList.SelectedIndex];

                Session["OrgId"] = obj.OrgID.ToString();

                this.txtOrgName_Rqd.Text = obj.OrgName.Trim();
                this.ddlOrgType_Rqd.SelectedValue = obj.OrgType.Trim();
                if (ddlOrgType_Rqd.SelectedValue == "CRT")
                {
                    this.txtCourtCode_Rqd.Text = obj.OrgEquCode.ToString();
                    this.lblCourtCode_Rqd.Visible = true;
                    this.txtCourtCode_Rqd.Visible = true;
                }

                ddlOrgType_Rqd_SelectedIndexChanged(sender, e);
                this.ddlOrgSubType_Rqd.SelectedValue = lst[lstOrgList.SelectedIndex].OrgSubType;

                ddlOrgSubType_Rqd_SelectedIndexChanged(sender, e);
                this.ddlOrgParent.SelectedValue = lst[lstOrgList.SelectedIndex].ParentId.ToString();

                this.txtAddress_Rqd.Text = obj.OrgAddress.ToString().Trim();
                this.txtCourtCode_Rqd.Text = obj.OrgEquCode.ToString();
                this.txtStreet.Text = obj.OrgStreetName.Trim();
                this.txtUrl.Text = obj.OrgUrl.ToString().Trim();

                this.ddlOrgDistrict_Rqd.SelectedValue = lst[lstOrgList.SelectedIndex].OrgDistrict.ToString();
                ddlOrgDistrict_Rqd_SelectedIndexChanged(sender, e);
                this.ddlVdcMun_Rqd.SelectedValue = lst[lstOrgList.SelectedIndex].OrgVdcMuni.ToString();
                ddlVdcMun_Rqd_SelectedIndexChanged(sender, e);
                this.ddlWard_Rqd.SelectedValue = lst[lstOrgList.SelectedIndex].OrgWardNo.ToString();

                this.grdEmail.DataSource = lst[this.lstOrgList.SelectedIndex].LstEmail;
                this.grdEmail.DataBind();
                this.grdEmail.SelectedIndex = -1;
                Session["LstEmail"] = lst[this.lstOrgList.SelectedIndex].LstEmail;

                this.grdPhone.DataSource = lst[this.lstOrgList.SelectedIndex].LstPhone;
                this.grdPhone.DataBind();
                this.grdPhone.SelectedIndex = -1;
                Session["LstPhone"] = lst[this.lstOrgList.SelectedIndex].LstPhone;

                this.ddlEmailType.SelectedIndex = -1;
                this.ddlPhoneType.SelectedIndex = -1;
                this.txtOrgEmail.Text = "";
                this.txtOrgPhone.Text = "";
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnAddPhone_Click(object sender, EventArgs e)
    {
        string Active;
        if (chkPhone.Checked)
            Active = "Y";
        else
            Active = "N";
        List<ATTPhone> lstPhone=new List<ATTPhone>();
      

        try
        {
            if (this.ddlPhoneType.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "Please Select Phone Type";
                this.programmaticModalPopup.Show();
                return;
            }
            if (this.txtOrgPhone.Text == "")
            {
                this.lblStatusMessage.Text = "Please Enter Phone";
                this.programmaticModalPopup.Show();
                return;
            }
            lstPhone = (List<ATTPhone>)Session["LstPhone"];
            int phoneSeq=0;
            if(this.grdPhone.SelectedIndex>-1)
                phoneSeq=lstPhone[this.grdPhone.SelectedIndex].PSno;

            ATTPhone objPhone=new ATTPhone
                (
                ddlPhoneType.SelectedItem.Text,
                ddlPhoneType.SelectedValue,
                phoneSeq,
                txtOrgPhone.Text,
                Active,
                ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
                phoneSeq==0?"A":"E"
                );
            if (this.grdPhone.SelectedIndex==-1)
                lstPhone.Add(objPhone);
            else
                lstPhone[this.grdPhone.SelectedIndex] = objPhone;


                grdPhone.DataSource = lstPhone;
                grdPhone.DataBind();

                this.grdPhone.SelectedIndex = -1;
                this.txtOrgPhone.Text = "";
                this.ddlPhoneType.SelectedIndex = 0;
                this.chkPhone.Checked = false;
                Session["LstPhone"] = lstPhone;
                      
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    
    protected void btnAddEmail_Click(object sender, EventArgs e)
    {
        string Active;
        if (chkEmail.Checked)
            Active = "Y";
        else
            Active = "N";

        List<ATTEmail> lstEmail=new List<ATTEmail>();
        try
        {
            if (this.ddlEmailType.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "Please Select Email Type";
                this.programmaticModalPopup.Show();
                return;
            }
            if (this.txtOrgEmail.Text == "")
            {

                this.lblStatusMessage.Text = "Please Enter Email";
                this.programmaticModalPopup.Show();
                return;
            }

            lstEmail = (List<ATTEmail>)Session["LstEmail"];
            int emailSeq = 0;
            if (this.grdEmail.SelectedIndex > -1)
                emailSeq = lstEmail[this.grdEmail.SelectedIndex].ESNo;


            ATTEmail objEmail = new ATTEmail
           (
           ddlEmailType.SelectedItem.Text,
           ddlEmailType.SelectedValue,
           emailSeq,
           txtOrgEmail.Text,
           Active,
           ((ATTUserLogin)Session["Login_User_Detail"]).UserName,
           emailSeq == 0 ? "A" : "E"
           );
            if (this.grdEmail.SelectedIndex==-1)
                lstEmail.Add(objEmail);
            else
                lstEmail[this.grdEmail.SelectedIndex] = objEmail;

                grdEmail.DataSource = lstEmail;
                grdEmail.DataBind();
               
                this.grdEmail.SelectedIndex = -1;
                this.txtOrgEmail.Text = "";
                this.ddlEmailType.SelectedIndex = 0;
                this.chkEmail.Checked = false;
                Session["LstEmail"] = lstEmail;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }


    }

    protected void grdPhone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row;
        try
        {
            if (grdPhone.SelectedIndex > -1)
            {
                row = grdPhone.SelectedRow;
                ddlPhoneType.SelectedValue = row.Cells[1].Text.ToString();
                txtOrgPhone.Text = row.Cells[2].Text.ToString();
                if (row.Cells[3].Text.Trim() == "Y")
                    chkPhone.Checked = true;
                else
                    chkPhone.Checked = false;
            }
        }
        catch (Exception ex)
        {
            
           this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }

    protected void grdEmail_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow rowEmail;
        try
        {
            if (grdEmail.SelectedIndex > -1)
            {
                rowEmail = grdEmail.SelectedRow;
                ddlEmailType.SelectedValue = rowEmail.Cells[1].Text.ToString();
                txtOrgEmail.Text = rowEmail.Cells[2].Text.ToString();
                if (rowEmail.Cells[3].Text.Trim() == "Y")
                    chkEmail.Checked = true;
                else
                    chkEmail.Checked = false;
            }
        }
        catch (Exception ex)
        {
            
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }

    protected void grdPhone_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;

    }

    protected void grdEmail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }

    protected void ddlVdcMun_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.ddlVdcMun_Rqd.SelectedIndex > 0)
            {
                this.ddlWard_Rqd.Items.Clear();
                List<ATTDistrict> lstDistrict = (List<ATTDistrict>)Session["DistrictList"];
                this.ddlWard_Rqd.Items.Insert(0, new ListItem("--Select Ward--", "0"));
                this.ddlWard_Rqd.DataSource = lstDistrict[this.ddlOrgDistrict_Rqd.SelectedIndex].LstVDCs[this.ddlVdcMun_Rqd.SelectedIndex].LstWards;
                this.ddlWard_Rqd.DataTextField = "Ward";
                this.ddlWard_Rqd.DataValueField = "Ward";
            }
            else
                this.ddlWard_Rqd.Items.Clear();
            this.ddlWard_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show(); 
            
        }
        
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
        ClearControls();
    }

    protected void ddlOrgDistrict_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlVdcMun_Rqd.DataSource = "";
            this.ddlWard_Rqd.Items.Clear();
            if (this.ddlOrgDistrict_Rqd.SelectedIndex > 0)
            {
                List<ATTDistrict> lstDistrict = (List<ATTDistrict>)Session["DistrictList"];
                lstDistrict[this.ddlOrgDistrict_Rqd.SelectedIndex].LstVDCs.Insert(0, new ATTVDC(0, 0, "--Select VDC--", "", 0));
                this.ddlVdcMun_Rqd.DataSource = lstDistrict[this.ddlOrgDistrict_Rqd.SelectedIndex].LstVDCs;
                this.ddlVdcMun_Rqd.DataTextField = "VdcUCode";
                this.ddlVdcMun_Rqd.DataValueField = "VdcCode";
                this.ddlVdcMun_Rqd.DataBind();
            }
            this.ddlVdcMun_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
    }

    protected void ddlOrgType_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.lblCourtCode_Rqd.Visible = false;
            this.txtCourtCode_Rqd.Visible = false;
            this.ddlOrgSubType_Rqd.DataSource = "";
            this.ddlOrgSubType_Rqd.Items.Clear();
            this.ddlOrgParent.Items.Clear();
            this.ddlOrgSubType_Rqd.DataBind();
            if (this.ddlOrgType_Rqd.SelectedIndex > 0)
            {
                List<ATTOrganizationType> LstSubType = (List<ATTOrganizationType>)Session["LstOrgType"];
                this.ddlOrgSubType_Rqd.Items.Add(new ListItem("--Select Sub Type--", "0"));
                this.ddlOrgSubType_Rqd.DataSource = LstSubType[this.ddlOrgType_Rqd.SelectedIndex].LstOrgSubType;
                this.ddlOrgSubType_Rqd.DataTextField = "OrgSubTypeDesc";
                this.ddlOrgSubType_Rqd.DataValueField = "OrgSubTypeCode";
                this.ddlOrgSubType_Rqd.DataBind();
                if (this.ddlOrgType_Rqd.SelectedValue == "CRT")
                {
                    this.lblCourtCode_Rqd.Visible = true;
                    this.txtCourtCode_Rqd.Visible = true;

                }
                else
                {
                    this.lblCourtCode_Rqd.Visible = false;
                    this.txtCourtCode_Rqd.Visible = false;

                }
            }

        }
        catch (Exception ex)
        {
          this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();  
           
        }
        
    }

    protected void ddlOrgSubType_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlOrgParent.Items.Clear();
            this.ddlOrgParent.DataSource = "";
            this.ddlOrgParent.DataBind();
            if (this.ddlOrgSubType_Rqd.SelectedIndex > 0)
            {
                List<PCS.COMMON.ATT.ATTOrganization> lst = (List<PCS.COMMON.ATT.ATTOrganization>)Session["OrgList"];
                if (this.ddlOrgSubType_Rqd.SelectedValue == "D")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "A"; });

                else if (this.ddlOrgSubType_Rqd.SelectedValue == "A" || this.ddlOrgSubType_Rqd.SelectedValue == "SP" || this.ddlOrgSubType_Rqd.SelectedValue == "S")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "S"; });

                else if (this.ddlOrgSubType_Rqd.SelectedValue == "NJABR")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "NJABR"; });

                else if (this.ddlOrgSubType_Rqd.SelectedValue == "NHRCBR")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "NHRCBR"; });

                else if (this.ddlOrgSubType_Rqd.SelectedValue == "NBCBR")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "NBCBR"; });

                else if (this.ddlOrgSubType_Rqd.SelectedValue == "NBABR")
                    lst = lst.FindAll(delegate(ATTOrganization org) { return org.OrgSubType == "NBABR"; });

                this.ddlOrgParent.Items.Insert(0, new ListItem("--Select Parent Organization--", "0"));
                this.ddlOrgParent.DataSource = lst;
                this.ddlOrgParent.DataTextField = "ORGNAME";
                this.ddlOrgParent.DataValueField = "ORGID";
                this.ddlOrgParent.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
}
