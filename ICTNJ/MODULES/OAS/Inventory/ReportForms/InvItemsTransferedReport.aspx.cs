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

using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.REPORT;
using PCS.SECURITY.ATT;


public partial class MODULES_OAS_Inventory_ReportForms_InvItemsTransferedReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadItemsType();
        }
    }
    private void LoadItemsType()
    {
        try
        {
            List<ATTInvItemType> lstItemsType = BLLInvItemsTransfered.GetItemsType(null, "Y");
            lstItemsType.Insert(0, new ATTInvItemType(0, "छान्नुहोस्", ""));
            ddlItemsType.DataTextField = "ItemsTypeName";
            ddlItemsType.DataValueField = "ItemsTypeID";
            ddlItemsType.DataSource = lstItemsType;
            ddlItemsType.DataBind();
            Session["ItemsType"] = lstItemsType;

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlItemsType.SelectedIndex > 0)
            {
                string orgName = "Supreme Court";
                string orgAddress = "Ramshah Path,Kathmandu";
                string reportName = "OAS | Inventory Item Transfer Details";
                #region date
                //if (txtFromDate.Text != "" || txtToDate.Text != "")
                //{
                //    if ((txtFromDate.Text).CompareTo(txtToDate.Text) > 0)
                //    {
                //        this.lblStatusMessage.Text = "From Date must be smaller then ToDate";
                //        this.programmaticModalPopup.Show();
                //        return;
                //    }
                //}
                #endregion
                CrystalReport objReport = new CrystalReport();
                objReport.SelectionCriteria = SetCriteria();
                objReport.UserID = "OAS_OWNER";
                objReport.Password = "OAS_OWNER";

                int itemType = int.Parse(ddlItemsType.SelectedValue);
                if (itemType == 1)
                {
                    objReport.ReportName = Server.MapPath("~") + "/MODULES/OAS/Inventory/Reports/InvItemsTransferedKBJ.rpt";
                }
                else if (itemType == 2)
                {
                    objReport.ReportName = Server.MapPath("~") + "/MODULES/OAS/Inventory/Reports/InvItemsTransferedKNJ.rpt";
                }
                objReport.ParamList.Add(new ReportParameter("orgName", orgName));
                objReport.ParamList.Add(new ReportParameter("orgAddress", orgAddress));
                objReport.ParamList.Add(new ReportParameter("ReportName", reportName));

                Session["OASReport"] = objReport;

                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";

                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
                ClearControls();
            }
            else
            {
                this.lblStatusMessage.Text = "Select Items Type";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private string SetCriteria()
    {
        try
        {
            string strFormula= "";
                if (ddlItemsType.SelectedValue == "1")
                {
                    strFormula += "  {VW_INV_ORG_ITEMS_TRANSFER.ITEMS_TYPE_ID}=" + 1;
                }

                else if (ddlItemsType.SelectedValue == "2")
                {
                    strFormula += " {VW_INV_ORG_ITEMS_TRANSFER_KNJ.ITEMS_TYPE_ID}=" + 2;
                }

                return strFormula;
           

        }
        catch (Exception)
        {

            throw;
        }
    }
    private void ClearControls()
    {
        this.ddlItemsType.SelectedIndex = 0;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
}
