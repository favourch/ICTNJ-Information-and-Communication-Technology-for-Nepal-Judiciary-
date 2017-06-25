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
using Oracle.DataAccess.Client;

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;


public partial class MODULES_OAS_Forms_OASSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["DocSearchOrgList"] = null;
            Session["DocSearchUnitList"] = null;
            Session["DocSearchDocNameList"] = null;
            //Session["DocSearchResultList"] = null;
            //Session["Flag"] = null;
            
            this.LoadOrganisation();
            //this.LoadUnit();
            //this.LoadDocName();
            this.LoadFlowType();
            this.LoadDocCategory();

         


        }

        if (Session["Flag"] != null)
        {
            this.grdDocSearchResult.DataSource = (List<ATTDocument>)Session["DocSearchResultList"];
            this.grdDocSearchResult.DataBind();

            Session["Flag"] = null;
        }
    }

    public void LoadOrganisation()
    {
          try
            {
                Session["DocSearchOrgList"] = BLLOrganization.GetOrganizationNameList();
                this.drpOrganisation.DataSource = (List<ATTOrganization>)Session["DocSearchOrgList"];
                this.drpOrganisation.DataTextField = "OrgName";
                this.drpOrganisation.DataValueField = "OrgId";
                this.drpOrganisation.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "Select Organisation";
                a.Value = "0";
                drpOrganisation.Items.Insert(0, a);

                Session["DocSearchUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(null, null);
                Session["DocSearchDocNameList"] = BLLDocument.GetDocumentNameList(null, null, null);

      
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
       
    }
    public void LoadUnit()
    {
        try
        {
           // Session["DocSearchUnitList"] = BLLUnit.GetUnitList(null, null);
            //GetOrganizationUnits
            Session["DocSearchUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(null, null);
            this.drpUnit.DataSource = (List<ATTOrganizationUnit>)Session["DocSearchUnitList"];
            this.drpUnit.DataTextField = "UnitName";
            this.drpUnit.DataValueField = "UnitID";
            this.drpUnit.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Unit";
            a.Value = "0";
            drpUnit.Items.Insert(0, a);

            
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }
    public void LoadDocName()
    {
        try
        {
            Session["DocSearchDocNameList"] = BLLDocument.GetDocumentNameList(null, null, null);
            this.drpDocName.DataSource = (List<ATTDocument>)Session["DocSearchDocNameList"];
            this.drpDocName.DataTextField = "DocumentName";
            this.drpDocName.DataValueField = "DocID";
            this.drpDocName.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Document";
            a.Value = "0";
            drpDocName.Items.Insert(0, a);

        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }
    public void LoadFlowType()
    {
        try
        {
            Session["DocSearchFlowTypeList"] = BLLDocumentFlowType.GetFlowTypeList(null);
            //this.drpFlowType_rqd.DataSource = (List<ATTDocumentFlowType>)Session["DocFlowTypeList"];
            //this.drpFlowType_rqd.DataTextField = "DocFlowName";
            //this.drpFlowType_rqd.DataValueField = "DocFlowID";
            //this.drpFlowType_rqd.DataBind();

            //ListItem a = new ListItem();
            //a.Selected = true;
            //a.Text = "Select Flow Type";
            //a.Value = "0";
            //drpFlowType_rqd.Items.Insert(0, a);

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
    public void LoadDocCategory()
    {
        try
        {
            Session["DocSearchCategory"] = BLLDocumentCategory.GetDocCategoryList(null);
            //this.drpDocCategory_rqd.DataSource = (List<ATTDocumentCategory>)Session["DocSearchCategory"];
            //this.drpDocCategory_rqd.DataTextField = "CategoryName";
            //this.drpDocCategory_rqd.DataValueField = "FileCatID";
            //this.drpDocCategory_rqd.DataBind();

            //ListItem a = new ListItem();
            //a.Selected = true;
            //a.Text = "Select Category";
            //a.Value = "0";
            //drpDocCategory_rqd.Items.Insert(0, a);
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int? OrgID = null;
            int? UnitID = null;
            int? DocID = null;
            
            string DocName = "";
            string StatusID = "";
                  
            if (drpOrganisation.SelectedIndex > 0)
                OrgID = int.Parse(drpOrganisation.SelectedValue.ToString());

            if (drpUnit.SelectedIndex > 0)
                UnitID = int.Parse(drpUnit.SelectedValue.ToString());

            if (drpDocName.SelectedIndex > 0)
            {
                DocID = int.Parse(drpDocName.SelectedValue.ToString());
                DocName = drpDocName.SelectedItem.ToString();
            }

            //if (drpDocStatus.SelectedIndex > 0)
            //    StatusID = drpDocStatus.SelectedValue.ToString();

            StatusID = "";

            //if(Session["Flag"] == null)
            Session["DocSearchResultList"] = BLLDocument.SearchDocumentList(OrgID, UnitID, DocID, DocName,StatusID);

            if (Session["DocSearchResultList"] != null)
            {
                this.grdDocSearchResult.DataSource = (List<ATTDocument>)Session["DocSearchResultList"];
                this.grdDocSearchResult.DataBind();

                //Session["Flag"] = null;
            }


           
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpOrganisation.SelectedIndex = -1;
        drpUnit.SelectedIndex = -1;
        drpDocName.SelectedIndex = -1;
        drpUnit.Enabled = false;
        drpDocName.Enabled = false;
        grdDocSearchResult.DataSource = null;
        grdDocSearchResult.DataBind();
    }
   
    protected void grdDocSearchResult_DataBound(object sender, EventArgs e)
    {
       
        if (this.grdDocSearchResult.Rows.Count <= 0)
        {
            if (hfStatusHidden.Value.ToString() == "1")
                this.lblStatus.Text = " ";
            else
                this.lblStatus.Text = " No Search datas found... ";

            hfStatusHidden.Value = "0";
           
        }
        else if (this.grdDocSearchResult.Rows.Count > 0)
            this.lblStatus.Text = " ";
    }
    protected void grdDocSearchResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int rowID = e.NewEditIndex;

        //GridView editingRow = grdDocSearchResult.Rows[e.NewEditIndex];

        //string name = grdDocSearchResult.Rows[e.NewEditIndex].Cells[2].Controls[0].ToString();



            //    grvSecondaryLocations.EditIndex = e.NewEditIndex;

            //GridViewRow editingRow = grvSecondaryLocations.Rows[e.NewEditIndex];

            //DropDownList ddlPbx = (editingRow.FindControl("ddlPBXTypeNS") as DropDownList);
            //if (ddlPbx != null)
            //{
            //    ddlPbx.DataSource = _pbxTypes;
            //    ddlPbx.DataBind();
            //}

            //.... (more stuff)


    }
    protected void grdDocSearchResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //GridViewRow row = grdDocSearchResult.Rows[e.RowIndex];


        //GridView row = grdDocSearchResult.Rows[e.ro

        //GridViewRow row = myGridView.Rows[e.RowIndex];

        //if (row != null)

        //{

        //TextBox t = row.FindControl("TextBox1") as TextBox;

        //if (t != null)

        //{

        //Response.Write("The Text Entered is" + t.Text);

        //}
    }
    protected void grdDocSearchResult_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = grdDocSearchResult.Rows[e.NewSelectedIndex];

        int orgID  = int.Parse(row.Cells[1].Text.ToString());
        int unitID = int.Parse(row.Cells[2].Text.ToString());
        int DocID  = int.Parse(row.Cells[3].Text.ToString());
        Session["OasEditOrgID"] = orgID;
        Session["OasEditunitID"] = unitID;
        Session["OasEditDocID"] = DocID;

        Response.Redirect("DocumentUpdate.aspx");
    }
    protected void grdDocSearchResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[2].Visible = false;
        row.Cells[3].Visible = false;
    }
    
    protected void drpOrganisation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.drpUnit.Items.Clear();

            if (this.drpOrganisation.SelectedIndex > 0)
            {

                List<ATTOrganizationUnit> lstUnit = (List<ATTOrganizationUnit>)Session["DocSearchUnitList"];

                ATTOrganizationUnit objUnitName = new ATTOrganizationUnit();

                objUnitName.LstUnitName = lstUnit.FindAll(
                                                            delegate(ATTOrganizationUnit UnitName)
                                                            {
                                                                return UnitName.OrgID == int.Parse(this.drpOrganisation.SelectedValue);
                                                            }

                                                         );

                this.drpUnit.DataSource = objUnitName.LstUnitName;
                this.drpUnit.DataTextField = "UnitName";
                this.drpUnit.DataValueField = "UnitID";
                this.drpUnit.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "Select Unit";
                a.Value = "0";
                drpUnit.Items.Insert(0, a);

                drpUnit.Enabled = true;
            }
            else
            {
                drpUnit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            
            lblStatus.Text = ex.Message;
        }
        
       
    }

    protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.drpDocName.Items.Clear();

            if (this.drpUnit.SelectedIndex > 0)
            {

                List<ATTDocument> lstDocument = (List<ATTDocument>)Session["DocSearchDocNameList"];

                ATTDocument objDocName = new ATTDocument();

                objDocName.LstDocName = lstDocument.FindAll(
                                                                delegate(ATTDocument DocName)
                                                                {
                                                                    return DocName.UnitID == int.Parse(this.drpUnit.SelectedValue);
                                                                }

                                                            );

                this.drpDocName.DataSource = objDocName.LstDocName;
                this.drpDocName.DataTextField = "DocumentName";
                this.drpDocName.DataValueField = "DocID";
                this.drpDocName.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "Select Unit";
                a.Value = "0";
                drpDocName.Items.Insert(0, a);

                drpDocName.Enabled = true;
            }
            else
            {
                drpDocName.Enabled = false;
            }
        }
        catch (Exception ex)
        {

            lblStatus.Text = ex.Message;
        }
        
    }
}
