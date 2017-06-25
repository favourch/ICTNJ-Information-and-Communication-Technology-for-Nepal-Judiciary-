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

using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;



public partial class MODULES_CMS_Bench_BenchOrders : System.Web.UI.Page
{
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
        if (user.MenuList.ContainsKey("1,24,1") == true)
        {
            Session["OrgID"] = user.OrgID;
            if (!Page.IsPostBack)
            {
                GetOrganisations();
                LoadBenchType();
                GetOrderList();
                this.assignmentDiv.Visible = false;
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void GetOrganisations()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        try
        {
            List<ATTOrganization> lstOrganisation = new List<ATTOrganization>();
            lstOrganisation = BLLOrganization.GetOrgWithChilds(user.OrgID);
            this.organisationddl_Rqd.DataSource = lstOrganisation;
            organisationddl_Rqd.DataTextField = "ORGNAME";
            organisationddl_Rqd.DataValueField = "ORGID";
            organisationddl_Rqd.DataBind();
        }
        catch (Exception exception)
        {
            this.lblStatus.Text = "Error";
            this.lblStatusMessage.Text = "Could not Load Organisations" + exception.Message;
            this.programmaticModalPopup.Show();

        }

    }
    protected void LoadBenchType()
    {
        try
        {
            Session["BenchType"] = BLLBenchType.GetBenchType(null, null, 1);
            benchtypeddl.DataSource = (List<ATTBenchType>)Session["BenchType"];
            benchtypeddl.DataValueField = "BenchTypeID";
            benchtypeddl.DataTextField = "BenchTypeName";
            benchtypeddl.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Error";
            this.lblStatusMessage.Text = "Could not Load BenchType" + ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void LoadBenchAssignment()
    {
        try
        {
            Session["BenchAssignment"] = BLLBenchOrder.GetBenchAssignments(int.Parse(this.organisationddl_Rqd.SelectedValue), int.Parse(this.benchtypeddl.SelectedValue), benchdateTxt.Text);
            List<ATTBenchOrder> lst = (List<ATTBenchOrder>)Session["BenchAssignment"];
            benchAssignmentGrid.DataSource = lst;
            benchAssignmentGrid.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Error";
            this.lblStatusMessage.Text = "Could not Load Bench Assignment" + ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        this.assignmentDiv.Visible = true;
        if (this.organisationddl_Rqd.SelectedIndex == 0)
        {
            this.lblStatus.Text = "Validation Error";
            this.lblStatusMessage.Text = "Please Select Organisation";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.benchtypeddl.SelectedIndex == 0)
        {
            this.lblStatus.Text = "Validation Error";
            this.lblStatusMessage.Text = "Please Select BenchType";
            this.programmaticModalPopup.Show();
            return;
        }
        if (!ValidateDate())
        {
            this.lblStatus.Text = "Validation Error";
            this.lblStatusMessage.Text = "Date cannot be Empty";
            this.programmaticModalPopup.Show();
            return;
        }
        LoadBenchAssignment();
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        this.organisationddl_Rqd.SelectedIndex = -1;
        this.benchtypeddl.SelectedIndex = -1;
        this.benchdateTxt.Text = "";
    }
    protected void benchAssignmentGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearGridChecks();
        this.assignmentDiv.Visible = true;
        int orgID = int.Parse(this.organisationddl_Rqd.SelectedValue);
        int benchID = int.Parse(this.benchtypeddl.SelectedValue);
        string benchDate = this.benchdateTxt.Text;
        int caseID = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[0].Text);
        int benchNo = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[3].Text);
        string fromDate = this.benchAssignmentGrid.SelectedRow.Cells[4].Text;
        int seqNo = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[5].Text);

        List<ATTBenchOrder> orderList = BLLBenchOrder.GetBenchOrders(orgID, benchID, benchNo, fromDate, seqNo, caseID, benchDate);
        List<ATTBenchOrder> orderListNew = new List<ATTBenchOrder>();
        List<ATTBenchOrder> remarksList = new List<ATTBenchOrder>();

        foreach (ATTBenchOrder obj in orderList)
        {
            if (obj.OrderID == 0)
            {
                remarksList.Add(obj);
            }
            else
            {
                orderListNew.Add(obj);
            }
        }

        Session["RemarksList"] = remarksList;
        remarksGrid.DataSource = remarksList;
        remarksGrid.DataBind();

        foreach (GridViewRow row in orderGrid.Rows)
        {
            int orderId = Convert.ToInt32(row.Cells[1].Text);

            int index = orderListNew.FindIndex
            (
                delegate(ATTBenchOrder obj)
                {
                    return obj.OrderID == orderId;
                }
            );
            if (index > -1)
            {
                CheckBox cb = ((CheckBox)row.FindControl("selectCb"));
                cb.Checked = true;

            }
        }
        Session["OrderList"] = orderListNew;
        //orderGrid.DataBind();

    }
    
    protected void GetOrderList()
    {
        List<ATTOrders> list = BLLOrders.GetOrders(null, "Y", 0);
        orderGrid.DataSource = list;
        orderGrid.DataBind();
    }
    protected void benchAssignmentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        //e.Row.Cells[5].Visible = false;
        //e.Row.Cells[4].Visible = false;
    }
    protected void remarksGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void orderGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTBenchOrder> lst = ((List<ATTBenchOrder>)Session["BenchAssignment"]);
        List<ATTBenchOrder> checkedOrderList = new List<ATTBenchOrder>();
        List<ATTBenchOrder> orderList = (List<ATTBenchOrder>)Session["OrderList"];

        foreach (GridViewRow row in orderGrid.Rows)
        {
            bool status = ((CheckBox)row.FindControl("selectCb")).Checked;
            int index = orderList.FindIndex
            (
                delegate(ATTBenchOrder objBenchOrder)
                {
                    return objBenchOrder.OrderID == Convert.ToInt32(row.Cells[1].Text);
                }
            );

            if (status == true && index > -1)
            {
                //do nothing
                orderList[index].Action = "N";

            }
            if (status == true && index < 0)
            {
                //add
                ATTBenchOrder obj = new ATTBenchOrder();
                obj.OrderID = Convert.ToInt32(row.Cells[1].Text);
                obj.Action = "A";
                orderList.Add(obj);

            }
            if (status == false && index > -1)
            {
                //remove
                orderList[index].Action = "R";
            }
         }

        List<ATTBenchOrder> remarkList = (List<ATTBenchOrder>)Session["RemarksList"];
        foreach (ATTBenchOrder obj in remarkList)
        {
            orderList.Add(obj);
        }

        foreach (ATTBenchOrder objBenchOrder in orderList)
        {
            objBenchOrder.OrgID = int.Parse(this.organisationddl_Rqd.SelectedValue);
            objBenchOrder.BenchTypeID = int.Parse(this.benchtypeddl.SelectedValue);
            objBenchOrder.BenchNo = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[3].Text);
            objBenchOrder.CaseID = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[0].Text);
            objBenchOrder.FromDate = this.benchAssignmentGrid.SelectedRow.Cells[4].Text;
            objBenchOrder.SeqNo = Convert.ToInt32(this.benchAssignmentGrid.SelectedRow.Cells[5].Text);
            objBenchOrder.AssignmentDate = this.benchAssignmentGrid.SelectedRow.Cells[6].Text;
            objBenchOrder.EntryBy = user.UserName;
        }

        try
        {
            BLLBenchOrder.UpdateCaseBenchOrders(orderList);
            ClearControls();
            this.lblStatus.Text = "Success";
            this.lblStatusMessage.Text = "Updated Successfully";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {

            this.lblStatus.Text = "Error";
            this.lblStatusMessage.Text = "Update Failed " + ex.Message;
            this.programmaticModalPopup.Show();
        }
      }

    protected bool ValidateDate()
    {
        bool status;
        if (benchdateTxt.Text.Trim() == "")
        {
            status = false;
        }
        else
        {
            status = true;
        }

        return status;

    }

    protected void cancelOrderBtn_Click(object sender, EventArgs e)
    {
        benchAssignmentGrid.DataSource = null;
        benchAssignmentGrid.DataBind();
        organisationddl_Rqd.SelectedIndex = -1;
        benchtypeddl.SelectedIndex = -1;
        this.benchdateTxt.Text = "";
        this.assignmentDiv.Visible = false;
        ClearControls();
    }
    protected void ClearGridChecks()
    {
        foreach (GridViewRow row in orderGrid.Rows)
        {
            CheckBox cb = ((CheckBox)row.FindControl("selectCb"));
            cb.Checked = false;
        }
        this.remarksGrid.SelectedIndex = -1;
    }
    protected void ClearControls()
    {
        foreach (GridViewRow row in orderGrid.Rows)
        {
            CheckBox cb = ((CheckBox)row.FindControl("selectCb"));
            cb.Checked = false;
        }
        this.benchAssignmentGrid.SelectedIndex = -1;
        this.remarksGrid.DataSource = null;
        this.remarksGrid.DataBind();
        this.othersTxt.Text = "";
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        string remarks = othersTxt.Text;
        List<ATTBenchOrder> remarkList = (List<ATTBenchOrder>)Session["RemarksList"];
        if (benchAssignmentGrid.SelectedIndex < 0)
        {
            this.lblStatus.Text = "Validation";
            this.lblStatusMessage.Text = "Please Select Bench Assignment First";
            this.programmaticModalPopup.Show();
            return;
        }
        if (othersTxt.Text == "")
        {
            this.lblStatus.Text = "Validation";
            this.lblStatusMessage.Text = "Empty Field";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTBenchOrder obj = new ATTBenchOrder();
        if (remarksGrid.SelectedIndex > -1)
        {
            remarkList[remarksGrid.SelectedIndex].Action = "E";
            remarkList[remarksGrid.SelectedIndex].Remarks = othersTxt.Text;
            remarksGrid.DataSource = remarkList;
            remarksGrid.DataBind();

        }
        else
        {
            obj.Action = "A";
            obj.Remarks = remarks;
            remarkList.Add(obj);
            remarksGrid.DataSource = remarkList;
            Session["RemarksList"] = remarkList;
            remarksGrid.DataBind();

        }

    }

    protected void delBtn_Click(object sender, EventArgs e)
    {
        if (remarksGrid.SelectedIndex < 0)
        {
            this.lblStatus.Text = "Validation";
            this.lblStatusMessage.Text = "Please Select Order First";
            this.programmaticModalPopup.Show();
            return;
        }
        List<ATTBenchOrder> remarkList = (List<ATTBenchOrder>)Session["RemarksList"];
        remarkList[remarksGrid.SelectedIndex].Action = "R";
        List<ATTBenchOrder> tempList = new List<ATTBenchOrder>();
        foreach (ATTBenchOrder obj in remarkList)
        {
            if (obj.Action != "R")
                tempList.Add(obj);
        }
        this.remarksGrid.DataSource = tempList;
        this.remarksGrid.DataBind();

    }
    protected void remarksGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTBenchOrder> remarkList = (List<ATTBenchOrder>)Session["RemarksList"];
        othersTxt.Text = remarkList[this.remarksGrid.SelectedIndex].Remarks;


    }

}
