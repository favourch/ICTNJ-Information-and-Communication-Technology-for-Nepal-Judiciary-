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

public partial class MODULES_LJMS_Forms_DuplicateEntry : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

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
        if (user.MenuList.ContainsKey("2,40,1") == true)
        {
            if (!IsPostBack)
            {
                this.LoadUnit();
                this.LoadLawyerType();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadUnit()
    {
        try
        {
            this.ddlUnit.DataSource = BLLUnit.GetUnitList("", true);
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadLawyerType()
    {
        try
        {
            this.ddlType.DataSource = BLLLawyerType.GetLawyerTypeList(null, true);
            this.ddlType.DataTextField = "LawyerTypeDescription";
            this.ddlType.DataValueField = "LawyerTypeID";
            this.ddlType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            this.lblMessage.Text = "";
            string strDupCriteria = "";
            if (this.chkLicenseNo.Checked == true)
                strDupCriteria = strDupCriteria + "L";
            if (this.chkLType.Checked == true)
                strDupCriteria = strDupCriteria + "T";
            if (this.chkUnit.Checked == true)
                strDupCriteria = strDupCriteria + "U";
            if (this.chkLawyerName.Checked == true)
                strDupCriteria = strDupCriteria + "N";

            if (strDupCriteria == "")
            {
                this.lblMessage.Text = "Either One of The CheckBox Has To Be Selected.";
                return;
            }
            Session["RowsDelete"] = strDupCriteria;

            int intUnitID = (this.ddlUnit.SelectedIndex > 0 ? int.Parse(this.ddlUnit.SelectedValue.ToString()) : 0);
            int intTypeID = (this.ddlType.SelectedIndex > 0 ? int.Parse(this.ddlType.SelectedValue.ToString()) : 0);

            this.lblMessage.Text = "";
            List<ATTLawyerInfoSearch> lst;
            lst = BLLLawyerInfoSearch.getDuplicateEntry(FindDuplicateSQL(intUnitID, intTypeID, strDupCriteria));
            this.grdDisplay.DataSource = lst;
            this.grdDisplay.DataBind();
            if (lst.Count > 0)
                this.lblMessage.Text = lst.Count.ToString() + " Records Found.";
            else
                this.lblMessage.Text = "No Records Found.";
        }
        catch (Exception ex)
        {
            lblMessage.Text = "<B>" + ex.Message + "</B>";
        }
    }

    string FindDuplicateSQL(int intUnitID, int intTypeID, string strDupCriteria)
    {
        string strSelSQL;
        string strWHSQL = "";
        string strGRSQL = "";
        string strFSQL = "";
        strSelSQL = "SELECT * FROM vw_LAWYER_INFO A, ";
        string innerWhere = "";
        //strSelSQL = strSelSQL + " WHERE EXISTS( SELECT NULL FROM LAWYER_INFO B ";

        for (int i = 0; i < strDupCriteria.Length; i++)
        {
            if (strDupCriteria.Substring(i, 1) == "L")
            {
                strWHSQL = strWHSQL + " B.LICENSE_NO=A.LICENSE_NO AND";
                strGRSQL = strGRSQL + "LICENSE_NO,";
                strFSQL = strFSQL + "LICENSE_NO,";
            }
            else if (strDupCriteria.Substring(i, 1) == "T")
            {
                strWHSQL = strWHSQL + " B.lawyer_type_id=A.lawyer_type_id AND";
                strGRSQL = strGRSQL + "lawyer_type_id,";
                strFSQL = strFSQL + "lawyer_type_id,";
            }
            else if (strDupCriteria.Substring(i, 1) == "U")
            {
                strWHSQL = strWHSQL + " B.UNIT_ID=A.UNIT_ID AND";
                strGRSQL = strGRSQL + "UNIT_ID,";
                strFSQL = strFSQL + "UNIT_ID,";
            }
            else if (strDupCriteria.Substring(i, 1) == "N")
            {
                strWHSQL = strWHSQL + " B.L_NAME=A.L_NAME AND";
                strGRSQL = strGRSQL + "L_NAME,";
                strFSQL = strFSQL + "L_NAME,";
            }
        }

        if (intUnitID > 0)
        {
            strWHSQL = strWHSQL + " A.UNIT_ID=" + intUnitID + " AND";
            innerWhere = innerWhere + " and unit_id = " + intUnitID;
        }
        if (intTypeID > 0)
        {
            strWHSQL = strWHSQL + " A.lawyer_type_id=" + intTypeID + " AND";
            innerWhere = innerWhere + " and lawyer_type_id = " + intTypeID;
        }

        if (strWHSQL != "")
        {
            strWHSQL = "WHERE " + strWHSQL.Substring(0, strWHSQL.Length - 3);
            //return (strWHSQL + " " + strGRSQL);
        }
        if (strGRSQL != "")
        {
            strGRSQL = "GROUP BY " + strGRSQL.Substring(0, strGRSQL.Length - 1);
        }

        if (strFSQL != "")
        {
            strFSQL = strFSQL.Substring(0, strFSQL.Length - 1);
        }

        strSelSQL = strSelSQL + "(SELECT " + strFSQL + " FROM vw_LAWYER_INFO where 1 = 1 " + innerWhere + " " + strGRSQL + " HAVING COUNT(P_ID)>1 ) B " + strWHSQL + " order by a.lawyer_type_id, (a.LICENSE_NO)";
        return (strSelSQL);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.grdDisplay.DataSource = null;
        this.DataBind();
        this.ddlType.SelectedIndex = 0;
        this.ddlUnit.SelectedIndex = 0;
        this.chkLicenseNo.Checked = false;
        this.chkLType.Checked = false;
        this.chkUnit.Checked = false;
        this.chkLawyerName.Checked = false;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Clear();
        //Response.ClearHeaders();
        Response.AddHeader("content-disposition", "filename=Duplicate Entry List_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/ms-excel";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        this.grdDisplay.Caption = "Duplicate Entry List";
        this.grdDisplay.CaptionAlign = TableCaptionAlign.Left;
        this.grdDisplay.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void grdDisplay_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (this.grdDisplay.Rows.Count > 0)
        {
            this.lblMessage.Text = "Total Records: " + this.grdDisplay.Rows.Count.ToString();
            //btnPrint.Visible = true;
        }
        else
        {
            this.lblMessage.Text = "";
            //btnPrint.Visible = false;
        }
    }
}
