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

using PCS.DLPDS.ATT;
using PCS.DLPDS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_LookUp_Sponsor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ////block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;

        if (user.MenuList.ContainsKey("Post") == true) 
        {
            if (Page.IsPostBack == false)
            {
                LoadSponsors();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

        
        if (this.Page.IsPostBack == false)
        {
        }
    }

    private void LoadSponsors()
    {
        try
        {
            List<ATTSponsor> SponsorLST = BLLSponsor.GetSponsorList(0,"N");
            Session["Sponsors"] = SponsorLST;
            lstSponsors.DataSource = SponsorLST;
            lstSponsors.DataTextField = "SponsorName";
            lstSponsors.DataValueField = "SponsorID";
            lstSponsors.DataBind();
        }
        catch (Exception ex)
        {
            throw ex; 
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTSponsor> SponsorLST = (List<ATTSponsor>)Session["Sponsors"];
        ATTSponsor obj=new ATTSponsor();
        if (lstSponsors.SelectedIndex == -1)
        {
            obj = SponsorLST.Find
                                (
                                    delegate(ATTSponsor objSp)
                                    {
                                        return objSp.SponsorName.ToLower() == this.txtSponsorName_RQD.Text.ToLower();
                                    }
                                );

            if (obj != null)
            {
                this.lblStatusMessage.Text = "Sponsor Name Already Exists";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        //else
        //{
        //    obj = SponsorLST.Find
        //                         (
        //                            delegate(ATTSponsor objSp)
        //                            {
        //                                return objSp.SponsorName.ToLower() == this.txtSponsorName_RQD.Text.ToLower() && objSp.SponsorID!=int.Parse(lstSponsors.SelectedValue);
        //                            }
        //                          );
 
        //}

        


        ATTSponsor objSponsor = new ATTSponsor(
                                                (lstSponsors.SelectedIndex == -1) ? 0 : int.Parse(lstSponsors.SelectedValue),
                                                this.txtSponsorName_RQD.Text.Trim(),
                                                (lstSponsors.SelectedIndex == -1) ? "A" : "E");

        ObjectValidation OV = BLLSponsor.Validate(objSponsor);
        if (OV.IsValid == false)
        {
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show();
            return ;
        }

        if (BLLSponsor.AddProgram(objSponsor) == true)
        {
            if (lstSponsors.SelectedIndex == -1)
                SponsorLST.Add(objSponsor);
            else
                SponsorLST[lstSponsors.SelectedIndex].SponsorName = this.txtSponsorName_RQD.Text.Trim();
        }

        lstSponsors.DataSource = SponsorLST;
        lstSponsors.DataTextField = "SponsorName";
        lstSponsors.DataValueField = "SponsorID";
        lstSponsors.DataBind();

        clearAll();

    }
    protected void lstSponsors_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTSponsor> SponsorLST =(List<ATTSponsor>) Session["Sponsors"];
        this.txtSponsorName_RQD.Text = SponsorLST[lstSponsors.SelectedIndex].SponsorName;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll();
    }

    private void clearAll()
    {
        txtSponsorName_RQD.Text = "";
        this.lstSponsors.SelectedIndex = -1;
    }

}
