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



public partial class MODULES_OAS_Forms_Dartaa : System.Web.UI.Page
{
    int orgID = 9;
    string entryBy = "suman";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUnit();
           
        }

    }

    
    private void LoadUnit()
    {
      
       ddlUnit.DataSource = GetOrgUnits(orgID);
        ddlUnit.DataBind();        
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

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnit.SelectedIndex < 1)
        {
            grdEmpSearch.DataSource = null;
            grdEmpSearch.DataBind();
            
        }
        else
        {
            ATTEmployeeWorkDivision obj = new ATTEmployeeWorkDivision();
            obj.OrgID = orgID;
            obj.OrgUnitID = int.Parse(ddlUnit.SelectedValue);

            grdEmpSearch.DataSource = GetOrgUnits(obj);
            grdEmpSearch.DataBind();
 
        }
    }
    private List<ATTEmployeeWorkDivision> GetOrgUnits(ATTEmployeeWorkDivision ob)
    {       

        return BLLEmployeeWorkDivision.SearchEmployee(ob);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtRegDate.Text=="")
        {
            lblStatusMessage.Text = "दर्ता मिति छुट्यो";
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
        if (fupRegFile.HasFile==false)
        {
            lblStatusMessage.Text = "दर्ता हुने फाइल छुट्यो";
            this.programmaticModalPopup.Show();
            return;
            
        }
        if (ddlUnit.SelectedIndex<1)
        {
            lblStatusMessage.Text = "शाखा छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;

        }

        try
        {
            ATTDartaaChalaani obj = new ATTDartaaChalaani();

            obj.OrgID = orgID;
            obj.RegType = "D";
            obj.RegDate = txtRegDate.Text;
            obj.Subject = txtSubject.Text;
            obj.Description = txtDescription.Text;
            obj.PhysicalDigital = rdbPhyDig.SelectedValue.ToString();
            obj.RegFile = fupRegFile.FileBytes;
            obj.FwdUnit = int.Parse(ddlUnit.SelectedValue);
            if (grdEmpSearch.SelectedIndex>=0)
            {
                obj.FwdPerson = int.Parse(grdEmpSearch.SelectedRow.Cells[0].Text);
                
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
        catch(Exception ex)
        {

            throw ex;
        }

    }
    private void ClearControls()
    {
        txtRegDate.Text = "";
        txtSubject.Text = "";
        rdbPhyDig.SelectedIndex = -1;
        ddlUnit.SelectedIndex = -1;
        txtDescription.Text = "";
        grdEmpSearch.DataSource = "";
        grdEmpSearch.DataBind();
    }

    protected void grdEmpSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[3].Visible=false;
        e.Row.Cells[4].Visible=false;
        e.Row.Cells[5].Visible=false;
        e.Row.Cells[7].Visible=false;
        e.Row.Cells[9].Visible=false;
        e.Row.Cells[11].Visible=false;
        e.Row.Cells[12].Visible=false;

    }
}
