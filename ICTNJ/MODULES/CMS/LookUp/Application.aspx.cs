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

using PCS.COMMON.BLL;
using PCS.COMMON.ATT;

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.FRAMEWORK;

public partial class MODULES_CMS_LookUp_Application : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack == false)
        {
            chkApplicationActive.Checked = true;
            LoadOrganizationWithChilds(9);
            LoadApplications();
        }

    }

    void LoadApplications()
    {
        try
        {
            List<ATTApplication> orgApplicationLST = BLLApplication.GetApplication(null, null, null, 0);
            Session["Applications"] = orgApplicationLST;
            lstApplication.DataSource = orgApplicationLST;
            lstApplication.DataValueField = "ApplicationID";
            lstApplication.DataTextField = "ApplicationName";
            lstApplication.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Loading Applications<BR>"+ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadOrganizationWithChilds(int orgID)
    {
        try
        {
            Session["Organizations"] = BLLOrganization.GetOrgWithChilds(orgID);
            this.grdOrganization.DataSource = (List<ATTOrganization>)Session["Organizations"];
            this.grdOrganization.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Couldn't Load Organization<BR>"+ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    
    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTApplication> ApplicationLST = (List<ATTApplication>)Session["Applications"];


        int i = -1;
        if (this.lstApplication.SelectedIndex > -1)
        {
            i = ApplicationLST.FindIndex(delegate(ATTApplication obj)
                                                                    {
                                                                        return this.txtApplication_RQD.Text.ToUpper() == obj.ApplicationName.ToUpper() && this.lstApplication.SelectedItem.Text.ToUpper() != this.txtApplication_RQD.Text.ToUpper();
                                                                    });
        }
        else
        {
            i = ApplicationLST.FindIndex(delegate(ATTApplication obj)
                                                                               {
                                                                                   return this.txtApplication_RQD.Text.ToUpper() == obj.ApplicationName.ToUpper();
                                                                               });
        }

        if (i > -1)
        {
            this.lblStatusMessage.Text = "Application Already Exists";
            this.programmaticModalPopup.Show();
            return;
        }



        if (this.txtApplication_RQD.Text == "")
        {
            this.lblStatusMessage.Text = "Application Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.ddlApplicationType.SelectedValue == "0")
        {
            this.lblStatusMessage.Text = "Please Select Application Type";
            this.programmaticModalPopup.Show();
            return;
        }
        

        ATTApplication objApplication = new ATTApplication();
        objApplication.ApplicationID = lstApplication.SelectedIndex == -1 ? 0 : int.Parse(lstApplication.SelectedValue);
        objApplication.ApplicationName = this.txtApplication_RQD.Text;
        objApplication.ApplicationType = this.ddlApplicationType.SelectedValue;
        objApplication.Active = this.chkApplicationActive.Checked == true ? "Y" : "N";
        objApplication.EntryBy = "manoz";
        objApplication.Action = lstApplication.SelectedIndex == -1 ? "A" : "E";

        CheckBox cb;
        foreach (GridViewRow gvRow in this.grdOrganization.Rows)
        {
            ATTOrgApplication objOrgAppl = new ATTOrgApplication();
            cb = (CheckBox)gvRow.FindControl("chkSelect");
            if (cb.Checked == true || CheckNull.NullString(gvRow.Cells[3].Text)!="")
            {
                objOrgAppl.OrgID = int.Parse(gvRow.Cells[1].Text);
                objOrgAppl.ApplicationID = (lstApplication.SelectedIndex > -1) ? int.Parse(lstApplication.SelectedValue) : 0;
                if (CheckNull.NullString(gvRow.Cells[3].Text) == "" && cb.Checked == true)
                {
                    objOrgAppl.Active = "Y";
                    objOrgAppl.Action = "A";
                    
                }
                if ((CheckNull.NullString(gvRow.Cells[3].Text) == "Y" && cb.Checked == false))
                {
                    objOrgAppl.Active = "N";
                    objOrgAppl.Action = "E";
                }

                if ((CheckNull.NullString(gvRow.Cells[3].Text) == "N" && cb.Checked == true)||(CheckNull.NullString(gvRow.Cells[3].Text) == "Y" && cb.Checked == true))
                {
                    objOrgAppl.Active = "Y";
                    objOrgAppl.Action = "E";
                }


                objOrgAppl.EntryBy = "manoz";

                objApplication.OrgApplicationLST.Add(objOrgAppl);

            }
           
        }

        try
        {

            if (BLLApplication.SaveApplication(objApplication) == true)
            {
                if (lstApplication.SelectedIndex == -1)
                {
                    ApplicationLST.Add(objApplication);
                }
                else
                {
                    ApplicationLST.RemoveAt(lstApplication.SelectedIndex);
                    ApplicationLST.Add(objApplication);
                }
                this.lstApplication.DataSource = ApplicationLST;
                this.lstApplication.DataValueField = "ApplicationID";
                this.lstApplication.DataTextField = "ApplicationName";
                this.lstApplication.DataBind();


                ClearAll();

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error in Saving Application<BR>"+ ex.Message;
            this.programmaticModalPopup.Show();
        }


    }
    protected void lstApplication_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTApplication> ApplicationLST = (List<ATTApplication>)Session["Applications"];

        this.txtApplication_RQD.Text = ApplicationLST[this.lstApplication.SelectedIndex].ApplicationName;
        this.chkApplicationActive.Checked = (ApplicationLST[this.lstApplication.SelectedIndex].Active == "Y") ? true : false;
        this.ddlApplicationType.SelectedValue = ApplicationLST[this.lstApplication.SelectedIndex].ApplicationType;

        CheckBox cb;
        foreach (GridViewRow gvRow in this.grdOrganization.Rows)
        {
            cb = (CheckBox)gvRow.FindControl("chkSelect");
            int i=ApplicationLST[this.lstApplication.SelectedIndex].OrgApplicationLST.FindIndex(
                                                                        delegate(ATTOrgApplication obj)
                                                                        {
                                                                            return int.Parse(gvRow.Cells[1].Text) == obj.OrgID;
                                                                        });
            if (i>-1)
            {
                
                gvRow.Cells[3].Text = ApplicationLST[this.lstApplication.SelectedIndex].OrgApplicationLST[i].Active;
                if (gvRow.Cells[3].Text == "Y")
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
            else
            {
                cb.Checked = false;
                gvRow.Cells[3].Text = "";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearAll();
    }

    void ClearAll()
    {
        this.txtApplication_RQD.Text = "";
        this.chkApplicationActive.Checked = true;
        this.ddlApplicationType.SelectedValue = "0";

        this.grdOrganization.DataSource = (List<ATTOrganization>)Session["Organizations"];
        this.grdOrganization.DataBind();

        this.lstApplication.SelectedIndex = -1;
    }
    protected void grdOrganization_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
}
