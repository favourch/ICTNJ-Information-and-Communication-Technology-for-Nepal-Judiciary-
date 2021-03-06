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
using PCS.FRAMEWORK;
using System.Collections.Generic;

using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_OrganizationUnit : System.Web.UI.Page
{

    public List<ATTOrganizationUnit> OrganisationUnit
    {
        get { return Session["OrganizationUnits"].ToString() == "" ? new List<ATTOrganizationUnit>() : (List<ATTOrganizationUnit>)Session["OrganizationUnits"]; }
        set { Session["OrganizationUnits"] = value; }
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
        if (user.MenuList.ContainsKey("3,23,1") == true)
        {
            if (!this.IsPostBack)
            {
                Session["OrgID"] = user.OrgID;
                LoadOrganizationUnits(int.Parse(Session["OrgID"].ToString()));
                LoadOrganizationWithChid(int.Parse(Session["OrgID"].ToString()));
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    private void LoadOrganizationWithChid(int OrgID)
    {
        try
        {
            
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);


OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));
            int index = OrganizationList.FindIndex(delegate(ATTOrganization obj)
                                                        {
                                                            return obj.OrgID == OrgID;
                                                        }
                                                   );            
            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();
            this.ddlOrganization.SelectedIndex = index;

            this.ddlParentOrganizatin.DataSource = OrganizationList;
            this.ddlParentOrganizatin.DataTextField = "ORGNAME";
            this.ddlParentOrganizatin.DataValueField = "ORGID";
            this.ddlParentOrganizatin.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }

    }

    void LoadOrganizationUnits(int intOrgID)
    {
        try
        {
            List<ATTOrganizationUnit> lstOrganizationUnits = BLLOrganizationUnit.GetOrganizationUnits(intOrgID, null);
            this.lstOrgUnits.DataSource = lstOrganizationUnits;
            this.lstOrgUnits.DataTextField = "UNITNAME";
            this.lstOrgUnits.DataValueField = "UNITID";
            this.lstOrgUnits.DataBind();
            this.ddlParentUnits.Items.Clear();
            this.ddlParentUnits.Items.Insert(0, new ListItem("छान्नुहोस्", "0"));
            this.ddlParentUnits.DataSource = lstOrganizationUnits;
            this.ddlParentUnits.DataTextField = "UNITNAME";
            this.ddlParentUnits.DataValueField = "UNITID";
            this.ddlParentUnits.DataBind();
            Session["OrganizationUnits"] = lstOrganizationUnits;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstOrgUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.grdUnits.SelectedIndex = -1;
        List<ATTOrganizationUnit> lstOrganizationUnits=new List<ATTOrganizationUnit>();
        if (Session["OrganizationUnits"].ToString() != "")
        {
            lstOrganizationUnits = (List<ATTOrganizationUnit>)Session["OrganizationUnits"];
        }
        //List<ATTOrganizationUnit> lstOrgUnitsWithChild = BLLOrganizationUnit.GetOrgUnitWithChild(int.Parse(this.ddlOrganization.SelectedValue), int.Parse(this.lstOrgUnits.SelectedValue));
        //List<ATTOrganizationUnit> lstUnitHead = BLLOrganizationUnit.GetUnitHead(int.Parse(Session["OrgID"].ToString()), int.Parse(this.lstOrgUnits.SelectedValue));
        //this.lblUnitHead.Text = lstUnitHead[0].EmpName;
        if (Session["OrganizationUnits"].ToString() != "")
        {
            this.txtUnitName_Rqd.Text = lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].UnitName.ToString();
        }
        if (Session["OrganizationUnits"].ToString() != "")
        {
            if (lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].OrgID != 0)
            {
                this.ddlOrganization.SelectedValue = lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].OrgID.ToString();
            }
        }
        //else
        //{
        //    this.ddlOrganization.SelectedIndex = 0;
        //}
        if (Session["OrganizationUnits"].ToString() != "")
        {
            if (lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].ParentUnitID != null)
            {
                this.ddlParentUnits.SelectedValue = lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].ParentUnitID.ToString();
            }
        }
        //else
        //{
        //    this.ddlParentUnits.SelectedIndex = 0;
        //}
        if (Session["OrganizationUnits"].ToString() != "")
        {
            if (lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].ParentOrgID != null)
            {
                this.ddlParentOrganizatin.SelectedValue = lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].ParentOrgID.ToString();
            }
        }
        //else
        //{
        //    this.ddlParentOrganizatin.SelectedIndex = 0;
        //}
        if (Session["OrganizationUnits"].ToString() != "")
        {
            if (lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].UnitType != null)
            {
                this.ddlUnitType.SelectedValue = lstOrganizationUnits[this.lstOrgUnits.SelectedIndex].UnitType.ToString();
            }
        }
        //else
        //{
        //    this.ddlUnitType.SelectedIndex = 0;
        //}

        this.ddlParentOrganizatin.Enabled = false;
        this.ddlParentUnits.Enabled = false;

        //Session["UnitsWithChild"] = lstOrgUnitsWithChild;
        //this.grdUnits.DataSource = lstOrgUnitsWithChild;
        //this.grdUnits.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("Submit");
    }

    void ClearControls(string p)
    {
        if (p == "Submit")
        {
            this.ddlParentOrganizatin.Enabled = true;
            this.ddlParentUnits.Enabled = true;
            this.ddlOrganization.SelectedValue = Session["OrgID"].ToString();
            this.txtUnitName_Rqd.Text = "";
            this.ddlParentOrganizatin.SelectedIndex = 0;
            if (this.ddlParentUnits.SelectedIndex > 0)
            {
                this.ddlParentUnits.SelectedIndex = 0;
            }
            this.lstOrgUnits.SelectedIndex = -1;
            this.ddlUnitType.SelectedIndex = 0;
            this.grdUnits.SelectedIndex = -1;
            this.grdUnits.DataSource = null;
            this.grdUnits.DataBind();
            Session["UnitsWithChild"] = "";
        }
        else if (p == "Add")
        {
            this.ddlParentOrganizatin.Enabled = true;
            this.ddlParentUnits.Enabled = true;
            this.txtUnitName_Rqd.Text = "";
            this.ddlParentOrganizatin.SelectedIndex = 0;
            if (this.ddlParentUnits.SelectedIndex > 0)
            {
                this.ddlParentUnits.SelectedIndex = 0;
            }
            this.ddlUnitType.SelectedIndex = 0;
            this.grdUnits.SelectedIndex = -1;
        }
        else if (p == "Add2")
        {
            this.txtUnitName_Rqd.Text = "";
        }
        else if (p == "Add3")
        {
            //this.ddlOrganization.SelectedValue = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID.ToString() ;
            this.txtUnitName_Rqd.Text = "";
            this.ddlParentOrganizatin.SelectedIndex = 0;
            this.ddlParentUnits.SelectedIndex = 0;
            this.ddlUnitType.SelectedIndex = 0;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTOrganizationUnit> OrgUnitList = OrganisationUnit;
        if (OrgUnitList.Count == 0)
        {
            this.lblStatusMessage.Text = "**No Data To Save";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            if (BLLOrganizationUnit.SaveOrganizationUnit(OrgUnitList))
            {
                this.lblStatusMessage.Text = "Organization Unit Successfully Saved.";
                this.programmaticModalPopup.Show();
            }
            List<ATTOrganizationUnit> LSTOrgUnits = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(Session["OrgID"].ToString()), null);
            this.lstOrgUnits.DataSource = LSTOrgUnits;
            this.lstOrgUnits.DataBind();
            ClearControls("Submit");
            if (this.lstOrgUnits.SelectedIndex == -1)
            {
                this.lblStatusMessage.Text = "Unit Details Saved Successfully.";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessage.Text = "Unit Details Updated Successfully .";
                this.programmaticModalPopup.Show();
            }
            this.txtUnitName_Rqd.Focus();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOrganizationUnits(int.Parse(ddlOrganization.SelectedValue));
        this.grdUnits.SelectedIndex = -1;
        this.grdUnits.DataSource = null;
        this.grdUnits.DataBind();
        Session["OrganizationUnits"] = "";
        Session["UnitsWithChild"] = "";
    }

    protected void btnAddUnits_Click(object sender, EventArgs e)
    {
        int count = 0;
        string msg = "";
        if (this.ddlOrganization.SelectedIndex == 0)
        {
            msg += "**Please Select Organization";
            count++;
        }
        if (this.txtUnitName_Rqd.Text == "")
        {
            msg += "**Please Enter Unit Name";
            count++;
        }
        if (this.ddlUnitType.SelectedIndex == 0)
        {
            msg += "**Please Select Unit Type";
            count++;
        }
        if (count > 0)
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        //List<ATTOrganizationUnit> LSTOrgUnitWC = new List<ATTOrganizationUnit>();
        List<ATTOrganizationUnit> LSTOrgUnits = new List<ATTOrganizationUnit>();
        if (Session["OrganizationUnits"].ToString() != "")
        {
            LSTOrgUnits = (List<ATTOrganizationUnit>)Session["OrganizationUnits"];
        }
        //if (Session["UnitsWithChild"].ToString() != "")
        //{
        //    LSTOrgUnitWC = (List<ATTOrganizationUnit>)Session["UnitsWithChild"];
        //}
        //if (Session["UnitsWithChild"] == null)
        //{
        //    LSTOrgUnitWC = new List<ATTOrganizationUnit>();
        //}
        //if (this.lstOrgUnits.SelectedIndex > -1)
        //{
        //    LSTOrgUnits = OrganisationUnit;
        //}

        if (this.grdUnits.SelectedIndex == -1 && this.lstOrgUnits.SelectedIndex==-1)
        {
            ATTOrganizationUnit objOrgUnit = new ATTOrganizationUnit();
            objOrgUnit.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
            objOrgUnit.UnitName = this.txtUnitName_Rqd.Text;
            if (this.ddlParentOrganizatin.SelectedIndex > 0)
            {
                objOrgUnit.ParentOrgID = int.Parse(this.ddlParentOrganizatin.SelectedValue);
            }
            else if (this.ddlParentOrganizatin.SelectedIndex == 0)
            {
                objOrgUnit.ParentOrgID = null;
            }
            if (this.ddlParentUnits.SelectedIndex > 0)
            {
                objOrgUnit.ParentUnitID = int.Parse(this.ddlParentUnits.SelectedValue);
            }
            else if (this.ddlParentUnits.SelectedIndex == 0)
            {
                objOrgUnit.ParentUnitID = null;
            }
            objOrgUnit.UnitType = this.ddlUnitType.SelectedValue;
            if (this.grdUnits.SelectedIndex == -1)
            {
                objOrgUnit.Action = "A";
            }
            objOrgUnit.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            ObjectValidation OV = BLLOrganizationUnit.Validate(objOrgUnit);
            if (!OV.IsValid)
            {
                this.lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }
            LSTOrgUnits.Add(objOrgUnit);
            foreach (GridViewRow rw in this.grdUnits.Rows)
            {
                if (rw.Cells[2].Text == objOrgUnit.UnitName)
                {
                    this.lblStatusMessage.Text = "**सोही नामको शाखा पहिलेनै छ";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
        }
        else
        {
            ATTOrganizationUnit objOrgUnit = new ATTOrganizationUnit();
            if (this.grdUnits.SelectedIndex > -1)
            {
                objOrgUnit = LSTOrgUnits[this.grdUnits.SelectedIndex];
            }
            else
            {
                objOrgUnit = LSTOrgUnits[this.lstOrgUnits.SelectedIndex];
            }
            objOrgUnit.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
            objOrgUnit.UnitName = this.txtUnitName_Rqd.Text;
            objOrgUnit.ParentOrgID = int.Parse(this.ddlParentOrganizatin.SelectedValue);
            objOrgUnit.ParentUnitID = int.Parse(this.ddlParentUnits.SelectedValue);
            objOrgUnit.UnitType = this.ddlUnitType.SelectedValue;
            //objOrgUnit.Action = (grdUnits.SelectedRow.Cells[6].Text=="A")?"A":"E";
            objOrgUnit.Action = "A";
            objOrgUnit.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
            ObjectValidation OV = BLLOrganizationUnit.Validate(objOrgUnit);
            if (!OV.IsValid)
            {
                this.lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }
        }

        this.grdUnits.DataSource = LSTOrgUnits;
        this.grdUnits.DataBind();

        Session["OrganizationUnits"] = LSTOrgUnits;
        //if (this.lstOrgUnits.SelectedIndex > -1)
        //{
        //    ClearControls("Add2");
        //}
        //else if (this.grdUnits.SelectedIndex > -1)
        //{
        //    ClearControls("Add");
        //}
        ClearControls("Add3");
    }

    protected void grdUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.grdUnits.SelectedIndex > -1)
        {
            this.txtUnitName_Rqd.Text = Server.HtmlDecode(grdUnits.SelectedRow.Cells[2].Text);
            if (grdUnits.SelectedRow.Cells[3].Text != "" && grdUnits.SelectedRow.Cells[3].Text != "&nbsp;")
            {
                this.ddlParentOrganizatin.SelectedValue = Server.HtmlDecode(grdUnits.SelectedRow.Cells[3].Text.Trim());
            }
            if (grdUnits.SelectedRow.Cells[4].Text != "" && grdUnits.SelectedRow.Cells[4].Text != "&nbsp;")
            {
                this.ddlParentUnits.SelectedValue = Server.HtmlDecode(grdUnits.SelectedRow.Cells[4].Text);
            }
            if (grdUnits.SelectedRow.Cells[5].Text != "" && grdUnits.SelectedRow.Cells[5].Text != "&nbsp;")
            {
                this.ddlUnitType.SelectedValue = Server.HtmlDecode(grdUnits.SelectedRow.Cells[5].Text);
            }
            if (this.grdUnits.SelectedRow.Cells[6].Text == "A")
            {
                this.ddlParentOrganizatin.Enabled = true;
                this.ddlParentUnits.Enabled = true;
            }
            else if (this.grdUnits.SelectedRow.Cells[6].Text == "")
            {
                this.ddlParentOrganizatin.Enabled = false;
                this.ddlParentUnits.Enabled = false;
            }
        }
    }

    protected void grdUnits_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
    }
}
