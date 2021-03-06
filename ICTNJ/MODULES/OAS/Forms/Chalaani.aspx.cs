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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using System.Collections.Generic;


public partial class MODULES_OAS_Forms_Chalaani : System.Web.UI.Page
{
    int orgID = 9;
    string entryBy = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            LoadOrganisations();
        }

    }   
    private void LoadSendUnit(int organisationID)
    {

        ddlSendUnit.DataSource = GetOrgUnits(organisationID);
        ddlSendUnit.DataBind();
    }
    private List<ATTOrganizationUnit> GetOrgUnits(int organisationID)
    {
        List<ATTOrganizationUnit> lst = BLLOrganizationUnit.GetOrganizationUnits(organisationID, null);
        ATTOrganizationUnit obj = new ATTOrganizationUnit();
        obj.UnitName = " छान्नुहोस् ";
        obj.UnitID = -2;
        lst.Insert(0, obj);

        return lst;

    }
    private void LoadOrganisations()
    {
        List<ATTOrganization> lst = BLLOrganization.GetOrganization();
        ATTOrganization obj = new ATTOrganization();
        obj.OrgName = " छान्नुहोस् ";
        obj.OrgID = -2;
        lst.Insert(0, obj);
        int i = lst.FindIndex(
                delegate(ATTOrganization ob)
                {
                    return ob.OrgID == orgID;
                }
            );
        if (i >= 0)
        {
            lst.RemoveAt(i);
        }


        ddlOrg.DataSource = lst;
        ddlOrg.DataBind();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    private List<ATTEmployeeWorkDivision> GetOrgUnits(ATTEmployeeWorkDivision ob)
    {

        return BLLEmployeeWorkDivision.SearchEmployee(ob);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtRegDate.Text == "")
        {
            lblStatusMessage.Text = "चलानी मिति छुट्यो";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtSubject.Text == "")
        {
            lblStatusMessage.Text = "बिषय छुट्यो";
            this.programmaticModalPopup.Show();
            return;
        }
        if (rdbPhyDig.SelectedIndex == -1)
        {
            lblStatusMessage.Text = "फिजिकल/डिजिटल छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;

        }
        if (fupRegFile.HasFile == false)
        {
            lblStatusMessage.Text = "चलानी हुने फाइल छुट्यो";
            this.programmaticModalPopup.Show();
            return;

        }
        if (ddlOrg.SelectedIndex < 1)
        {
            lblStatusMessage.Text = "कार्यलय छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;

        }
        if (ddlSendUnit.SelectedIndex < 1)
        {
            lblStatusMessage.Text = "शाखा छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;

        }


        try
        {
            ATTDartaaChalaani obj = new ATTDartaaChalaani();

            obj.OrgID = orgID;
            obj.RegType = "C";
            obj.RegDate = txtRegDate.Text;
            obj.Subject = txtSubject.Text;
            obj.Description = txtDescription.Text;
            obj.PhysicalDigital = rdbPhyDig.SelectedValue.ToString();
            obj.RegFile = fupRegFile.FileBytes;

            
                obj.SendOrg = int.Parse(ddlOrg.SelectedValue);
                obj.SendUnit = int.Parse(ddlSendUnit.SelectedValue);
                if (grdSendEmp.SelectedIndex >= 0)
                {
                    obj.SendPerson = int.Parse(grdSendEmp.SelectedRow.Cells[0].Text);
                }
                obj.EntryBy = entryBy;
                if (BLLDartaaChalaani.SaveDartaaChalaani(obj))
                {
                    lblStatusMessage.Text = "Data Saved";
                    programmaticModalPopup.Show();
                    ClearControls();
                }
                else
                {
                    lblStatusMessage.Text = "Failed To Save Data";
                    programmaticModalPopup.Show();
                }

                
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = "Failed To Save Data"+ex.Message.ToString();
            programmaticModalPopup.Show();
        }

    }

    private void ClearControls()
    {
        txtRegDate.Text = "";
        txtSubject.Text = "";
        rdbPhyDig.SelectedIndex = -1;
        ddlOrg.SelectedIndex = -1;
        ddlSendUnit.SelectedIndex = -1;
        txtDescription.Text = "";
        grdSendEmp.DataSource = "";
        grdSendEmp.DataBind();
    }

   
    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlSendUnit.Items.Clear();
        LoadSendUnit(int.Parse(ddlOrg.SelectedValue));
    }
    protected void ddlSendUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSendUnit.SelectedIndex < 1)
        {
            grdSendEmp.DataSource = null;
            grdSendEmp.DataBind();

        }
        else
        {
            ATTEmployeeWorkDivision obj = new ATTEmployeeWorkDivision();
            obj.OrgID = int.Parse(ddlSendUnit.SelectedValue);
            obj.OrgUnitID = int.Parse(ddlSendUnit.SelectedValue);

            grdSendEmp.DataSource = GetOrgUnits(obj);
            grdSendEmp.DataBind();

        }
    }
}
