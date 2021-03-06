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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.LJMS.ATT;
using PCS.LJMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_LJMS_Forms_DefaulterList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("2,38,1") == true)
        {
            if (!IsPostBack)
            {
                LoadControls();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
  
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTLawyerInfoSearch> lstLISrch = new List<ATTLawyerInfoSearch>();
            lstLISrch = BLLLawyerInfoSearch.GetLawyerInfoSearchList(GetFilter());


            if (lstLISrch.Count > 0)
            {
                grdDisplay.DataSource = lstLISrch;
                grdDisplay.DataBind();

                Session["lstLISrch"] = lstLISrch;
            }
            else
            {
                this.grdDisplay.DataSource = "";
                this.grdDisplay.DataBind();
                lblSearchStatus.Text = " No Records Found !!!! ";
                btnExport.Visible = false;  
            }

           

            string rdType = "";

            if (this.optNBA.Checked == true)
                rdType = "optNBA";
            else
                rdType = "optNBC";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "diplayFields", "javascript:DisplayFields('" + rdType + "');", true);

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        

        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadControls()
    {
        LoadUnit();
        LoadLawyerType();
    }

    public void LoadLawyerType()
    {
        try
        {
            List<ATTLawyerType> lstLawyerType;
            lstLawyerType = BLLLawyerType.GetLawyerTypeList(null, true);
            ddlType.DataSource = lstLawyerType;
            ddlType.DataTextField = "LawyerTypeDescription";
            ddlType.DataValueField = "LawyerTypeID";
            ddlType.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadUnit()
    {
        try
        {
            ddlUnit.DataSource = BLLUnit.GetUnitList(null, true);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitID";
            ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTLawyerInfoSearch GetFilter()
    {
        try
        {
            ATTLawyerInfoSearch objLIsrch = new ATTLawyerInfoSearch();

            if (this.optNBA.Checked == true)
                objLIsrch.PLRENEWALUPTO = this.txtDate.Text.Trim();
            else if (this.optNBC.Checked == true)
                objLIsrch.LRENEWALUPTO = this.txtDate.Text.Trim();

            if (txtToDate.Text != "")
            {
                objLIsrch.TODATE = this.txtToDate.Text.Trim();
            }


            if (this.ddlUnit.SelectedIndex > 0)
                objLIsrch.UNITID = int.Parse(this.ddlUnit.SelectedValue.ToString());

            if (this.ddlType.SelectedIndex > 0)
                objLIsrch.LTYPEID = int.Parse(this.ddlType.SelectedValue.ToString());

            if (this.chkInRange.Checked)
            {
                objLIsrch.INRANGE = "Y";
            }
            else
            {
                objLIsrch.INRANGE = "N";
            }


            return objLIsrch;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        
    }


    public void Clear()
    {
        this.optNBA.Checked = true;
        this.optNBC.Checked = false;
        this.ddlUnit.SelectedIndex = -1;
        this.ddlType.SelectedIndex = -1;
        this.grdDisplay.DataSource = null;
        this.grdDisplay.DataBind();

        this.txtDate.Text = "";
        this.txtToDate.Text = "";
        this.lblSearchStatus.Text = "";
        this.btnExport.Visible = false;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void grdDisplay_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "filename=Defaulter List_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".xls");
            Response.Charset = "";

            //NB: If you want the option to open the Excel file without saving then comment out the line below
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/ms-excel";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            this.grdDisplay.Caption = "Defaulter List";
            this.grdDisplay.CaptionAlign = TableCaptionAlign.Left;
            this.grdDisplay.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void grdDisplay_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdDisplay.Rows.Count > 0)
        {
            this.lblSearchStatus.Text = "Total Records: " + this.grdDisplay.Rows.Count.ToString();
            btnExport.Visible = true;
        }
        else
        {
            this.lblSearchStatus.Text = "";
            btnExport.Visible = false;  
        }

       if (e.Row.RowType == DataControlRowType.DataRow)
        {
           GridViewRow row = e.Row;
           
           LinkButton lnkBtn = (LinkButton)row.Cells[9].Controls[0];
            
           if (row.Cells[8].Text.Trim() == "N")
           {
                lnkBtn.Text = "निष्कृय";

                e.Row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "return confirm('सक्रिय पार्न चाहनुहुन्छ ?');");
           }
           else
            {
                lnkBtn.Text = "सक्रिय";
                ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "return confirm('निष्कृय पार्न चाहनुहुन्छ ?');");
            }
         
        }
    }

    protected void grdDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = grdDisplay.Rows[e.RowIndex];
        LinkButton lnkBtn = (LinkButton)row.Cells[9].Controls[0];

        int pID = int.Parse(row.Cells[1].Text);

        ATTLawyerInfoSearch objLInfo = new ATTLawyerInfoSearch();
        objLInfo.PERSONID = int.Parse(row.Cells[1].Text);
        objLInfo.LTYPEID = int.Parse(row.Cells[10].Text);
        objLInfo.LICENSENO = row.Cells[11].Text;

        string active ="";

        if (row.Cells[8].Text.Trim() == "N" || row.Cells[8].Text.Trim() == "")
            active = "Y";
        else if (row.Cells[8].Text.Trim() == "Y")
            active = "N";

        objLInfo.ACTIVE = active;

        if (BLLLawyer.UpdateLawyerDetails(objLInfo))
        {
            row.Cells[8].Text = active;

            if (active == "N")
            {
                lnkBtn.Text = "निष्कृय";
                row.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lnkBtn.Text = "सक्रिय";
                row.ForeColor = System.Drawing.Color.FromArgb(51,51,51);
            }

        }


    }
}
