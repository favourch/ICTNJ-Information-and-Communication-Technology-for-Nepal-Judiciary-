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
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.SECURITY.ATT;
public partial class MODULES_LJMS_Forms_JudgeWorkInspection : System.Web.UI.Page
{
    string entryBy = "";
    List<ATTJudgeWorkInspectionDetails> InspectionList;
    List<ATTJudgeWorkInspectionDetails> InspectionListInsert;
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
        entryBy = user.UserName;
        if (user.MenuList.ContainsKey("2,2,1") == true)
        {
            if (!IsPostBack)
            {
                InspectionList = new List<ATTJudgeWorkInspectionDetails>();

                Session["WorkDetailsLst"] = null;
                Session["WorkDetailsLst"] = InspectionList;
                LoadCourts();
                LoadWorkList();
                Session["AddEdit"] = "A";
                Check();




            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    void LoadCourts()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrganization();
            lstOrg.Insert(0, new ATTOrganization(0, "-- छान्नुहोस --"));
            ddlCourt.DataSource = lstOrg;
            ddlCourt.DataTextField = "OrgName";
            ddlCourt.DataValueField = "OrgID";

            ddlCourt.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    void LoadWorkList()
    {
        try
        {
            ddlWorkList.DataTextField = "JwcName";
            ddlWorkList.DataValueField = "JwcID";
            

            List<ATTJudgeWorkList> workList = BLLJudgeWorkList.GetJudgeWorkList(null);
            Session["WorkList"] = workList;
            
            workList.Insert(0, new ATTJudgeWorkList(0, "-- छान्नुहोस --",false,""));
           
            
            ddlWorkList.DataSource = workList;
            ddlWorkList.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();

        }




    }
    void LoadJudgeList(int orgID)
    {
        try
        {
            List<ATTJudgeWorkList> CurrentJudgesList = BLLJudgeWorkList.GetCurrentJudgesList(orgID);
            CurrentJudgesList.Insert(0, new ATTJudgeWorkList(0, "छान्नुहोस"));
            ddlJudgeList.DataSource = CurrentJudgesList;
            ddlJudgeList.DataTextField = "JudgeName";
            ddlJudgeList.DataValueField = "JudgeId";
            ddlJudgeList.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();

        }


    }
    void ClearControls(bool all)
    {
        ddlWorkList.SelectedIndex = -1;
        //chkDone.Checked = false;
        txtNoOfCases.Text = "";
        txtInspectionCaseNo.Text = "";
        txtNoDoneReason.Text = "";
        chkIsReasonValid.Checked = false;
        txtremarks.Text = "";

        ddlJudgeList.Enabled = true;
        txtFiscalYear.Enabled = true;
        //cpeDemo.Enabled = true;
        Panel3.Enabled = true;

        if (all)
        {
            ddlJudgeList.SelectedIndex = -1;
            //txtCourt.Text = "";
            txtInspection.Text = "";
            txtInspection.Attributes.Clear();
            txtInspectionDate.Text = "";
            txtFiscalYear.Text = "";

            grdWorkInspectionDetails.DataSource = null;
            grdWorkInspectionDetails.DataBind();

            Session["WorkDetailsLst"] = null;           

            Session["AddEdit"] = "A";
        }


    }
    void LoadWorkInspectionDetails()
    {


        try
        {
            

            if (ddlJudgeList.SelectedIndex>0 && txtFiscalYear.Text != "")
            {

                ATTJudgeWorkInspection obj = BLLJudgeWorkInspection.GetJudgeWorkInspection(int.Parse(ddlJudgeList.SelectedValue), txtFiscalYear.Text);


                if (obj != null)
                {
                    txtInspection.Text = obj.InspEmpName.ToString();
                    txtInspection.Attributes.Add("InspectorID", obj.InspEmpID.ToString());
                    txtInspectionDate.Text = obj.InspectionDate.ToShortDateString();

                    List<ATTJudgeWorkInspectionDetails> list = obj.Details;

                    List<ATTJudgeWorkInspectionDetails> list1 = list.FindAll(delegate(ATTJudgeWorkInspectionDetails detail)
                  {
                      return (detail.InspectionCaseNo != null && detail.InspectionCaseNo != 0);
                  });



                    Session["WorkDetailsLst"] = list1;
                    grdWorkInspectionDetails.DataSource = list1;
                    grdWorkInspectionDetails.DataBind();

                    Session["AddEdit"] = "E";

                    btnSave.Visible = true;
                    btnCancel.Visible = true;

                    ddlJudgeList.Enabled = false;
                    txtFiscalYear.Enabled = false;

                    cpeDemo.Collapsed = true;
                    Panel3.Enabled = false;
                }
                else
                {
                    grdWorkInspectionDetails.DataSource = null;
                    grdWorkInspectionDetails.DataBind();

                    Session["WorkDetailsLst"] = null;
                    Session["AddEdit"] = "A";
                }

            }
            else
                Session["AddEdit"] = "A";
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();

        }

    }
    private ATTEmployeeSearch GetFilter()
    {
        try
        {
            ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
            if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
            if (this.txtFName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFName.Text.Trim();
            if (this.txtMName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMName.Text.Trim();
            if (this.txtSurName.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurName.Text.Trim();
            if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlGender.SelectedValue;
            if (this.txtdOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtdOB.Text.Trim();

            return EmployeeSearch;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
            return null;
        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void chkDone_CheckedChanged(object sender, EventArgs e)
    {
        Check();
    }
    void Check()
    {
        if (chkDone.Checked)
        {
            txtNoOfCases.Text = "";
            txtNoOfCases.Enabled = false;
            txtNoDoneReason.Text = "";
            txtNoDoneReason.Enabled = false;
        }
        else
        {
            txtNoOfCases.Enabled = true;
            txtNoDoneReason.Enabled = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {        

        try
        {
            int i = 0;
            string errmessage = "<P><b><U>! Attention </U></b></P>";

            if (ddlJudgeList.SelectedIndex < 1)
            { i++; errmessage += i.ToString() + ") Select Judge <br />"; }

            if (ddlWorkList.SelectedIndex < 1)
            { i++; errmessage += i.ToString() + ") Work Missing <br />"; }

            if (!chkDone.Checked)
            {
                if (txtNoOfCases.Text == "")
                { i++; errmessage += i.ToString() + ") No Of Cases Missing <br />"; }
            }
            if (txtInspectionCaseNo.Text == "")
            { i++; errmessage += i.ToString() + ") Inspection Case No Missing <br />"; }

            if (txtremarks.Text == "")
            { i++; errmessage += i.ToString() + ") Remarks Missing <br />"; }

            if (i > 0)
            {
                this.lblStatusMessage.Text = errmessage;
                this.programmaticModalPopup.Show();
                return;

            }


            List<ATTJudgeWorkInspectionDetails> WorkDetailsLst = (List<ATTJudgeWorkInspectionDetails>)Session["WorkDetailsLst"];

            

            if (grdWorkInspectionDetails.SelectedIndex >= 0)
            {
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].EmployeeID = int.Parse(ddlJudgeList.SelectedValue);
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].FiscalYear = txtFiscalYear.Text;
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].JwcID = int.Parse(ddlWorkList.SelectedValue);
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].JwcName = ddlWorkList.SelectedItem.ToString();
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].WorkDone = chkDone.Checked;
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].NoOfCase = (!chkDone.Checked) ? int.Parse(txtNoOfCases.Text) : 0;
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].InspectionCaseNo = int.Parse(txtInspectionCaseNo.Text);
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].NoDoneReason = Server.HtmlDecode(txtNoDoneReason.Text);
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].IsReasonValid = chkIsReasonValid.Checked;
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].Remarks = txtremarks.Text;               

                string action = "";
                string actionAll = Session["AddEdit"].ToString();
                if (actionAll == "A")
                {
                    action = "A";
                }
                else if (actionAll == "E")
                {
                    action = (WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].Action == "") ? "E" : "EA";
                }
                    


                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].Action ="" ;
                 
                
                WorkDetailsLst[grdWorkInspectionDetails.SelectedIndex].EntryBy = entryBy;

            }
            else
            {
                if (WorkDetailsLst == null)
                    WorkDetailsLst = new List<ATTJudgeWorkInspectionDetails>();

                if (WorkDetailsLst.Count > 0)
                {
                    foreach (ATTJudgeWorkInspectionDetails work in WorkDetailsLst)
                    {
                        if (work.JwcID == int.Parse(ddlWorkList.SelectedValue))
                        {
                            i++;
                            this.lblStatusMessage.Text = errmessage + i.ToString() + ") This Work Already Exists. Please Try Another.";
                            this.programmaticModalPopup.Show();

                            return;
                        }
                    }
                }


                ATTJudgeWorkInspectionDetails obj = new ATTJudgeWorkInspectionDetails();
                obj.EmployeeID = int.Parse(ddlJudgeList.SelectedValue);
                obj.FiscalYear = txtFiscalYear.Text;
                obj.JwcID = int.Parse(ddlWorkList.SelectedValue);
                obj.JwcName = ddlWorkList.SelectedItem.ToString();
                obj.WorkDone = chkDone.Checked;
                obj.NoOfCase = (!chkDone.Checked) ? int.Parse(txtNoOfCases.Text) : 0;
                obj.InspectionCaseNo = int.Parse(txtInspectionCaseNo.Text);
                obj.NoDoneReason = txtNoDoneReason.Text;
                obj.IsReasonValid = chkIsReasonValid.Checked;
                obj.Remarks = txtremarks.Text;

                string action = "";
                string actionAll = Session["AddEdit"].ToString();
                if (actionAll == "A")
                {
                    action = "A";
                }
                else if (actionAll == "E")
                {
                    action = "EA";
                }
                    

                obj.Action = action;
                obj.EntryBy = entryBy;
                WorkDetailsLst.Add(obj);
            }

            Session["WorkDetailsLst"] = WorkDetailsLst;

            grdWorkInspectionDetails.DataSource = null;
            grdWorkInspectionDetails.DataBind();

            grdWorkInspectionDetails.DataSource = WorkDetailsLst;
            grdWorkInspectionDetails.DataBind();

            grdWorkInspectionDetails.SelectedIndex = -1;


            ClearControls(false);
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdWorkInspectionDetails.Rows.Count < 1)
                return;


            int i = 0;
            string errmessage = "<P><b><U>! Attention </U></b></P>";

            if (ddlJudgeList.SelectedIndex < 1)
            { i++; errmessage += i.ToString() + ") Select Judge <br />"; }
            if (!txtInspection.HasAttributes || txtInspection.Text == "")
            { i++; errmessage += i.ToString() + ") Inspector Missing  <br />"; }
            if (txtInspectionDate.Text == "")
            { i++; errmessage += i.ToString() + ") Inspection Date Missing  <br />"; }
            else
            {
                try
                {
                    DateTime dt = DateTime.Parse(txtInspectionDate.Text);
                }
                catch (Exception)
                {
                    i++; errmessage += i.ToString() + ") Invalid Date  <br />";
                }
            }

            if (i > 0)
            {
                this.lblStatusMessage.Text = errmessage;
                this.programmaticModalPopup.Show();
                return;

            }
         

            InspectionListInsert = new List<ATTJudgeWorkInspectionDetails>();
            int j = 0;

            foreach (ATTJudgeWorkList work in (List<ATTJudgeWorkList>)Session["WorkList"])
            {
                if (j > 0)
                {

                    ATTJudgeWorkInspectionDetails inspdet = new ATTJudgeWorkInspectionDetails();

                    inspdet.JwcID = int.Parse(work.JwcID.ToString());
                    inspdet.JwcName = work.JwcName;
                    inspdet.Action = (Session["AddEdit"].ToString() == "A" ? "A" : "");
                    inspdet.EmployeeID = int.Parse(ddlJudgeList.SelectedValue);
                    inspdet.EntryBy = entryBy;
                    inspdet.EntryOn = DateTime.Now;
                    inspdet.FiscalYear = txtFiscalYear.Text;
                    inspdet.InspectionCaseNo = null;
                    inspdet.IsReasonValid = null;
                    inspdet.NoDoneReason = "";
                    inspdet.NoOfCase = null;
                    inspdet.Remarks = "";
                    inspdet.WorkDone = false;

                    InspectionListInsert.Add(inspdet);
                }
                j++;
            }

            foreach (ATTJudgeWorkInspectionDetails inspDetails in (List<ATTJudgeWorkInspectionDetails>)Session["WorkDetailsLst"])
            {
                int k = InspectionListInsert.FindIndex(delegate(ATTJudgeWorkInspectionDetails detail)
                 {
                     return (detail.JwcID == inspDetails.JwcID);
                 });

                InspectionListInsert[k] = inspDetails;
            }

            ATTJudgeWorkInspection workInspection = new ATTJudgeWorkInspection();
            workInspection.EmployeeID = int.Parse(ddlJudgeList.SelectedValue);
            workInspection.FiscalYear = txtFiscalYear.Text;

            string st = txtInspection.Attributes["InspectorID"].ToString();
            workInspection.InspEmpID = int.Parse(txtInspection.Attributes["InspectorID"].ToString());
            workInspection.InspectionDate = DateTime.Parse(txtInspectionDate.Text);
            workInspection.EntryBy = entryBy;



            workInspection.Details = InspectionListInsert;
            workInspection.Action = Session["AddEdit"].ToString();


            if (BLLJudgeWorkInspection.SaveJudgeWorkInspection(workInspection))
            {
                ClearControls(true);
                btnSave.Visible = true;
                btnCancel.Visible = true;
                this.lblStatusMessage.Text = "Information Saved.";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessage.Text = "Problem Saving Information .";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            List<ATTEmployeeSearch> lst;
            this.lblSearch.Text = "";
            if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
                && this.ddlGender.SelectedIndex == 0 && this.txtdOB.Text.Trim() == "")
            {
                this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
                this.programmaticModalPopup.Show();
            }
            else
            {
                try
                {
                    lst = BLLEmployeeSearch.SearchEmployee(GetFilter());
                    this.lblSearch.Text = lst.Count.ToString() + " records found.";
                    this.grdEmployee.DataSource = lst;
                    this.grdEmployee.DataBind();
                }
                catch (Exception ex)
                {
                    this.lblStatusMessage.Text = ex.Message;
                    this.programmaticModalPopup.Show();
                }
            }
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        txtSymbolNo.Text = "";
        txtFName.Text = "";
        txtMName.Text = "";
        txtSurName.Text = "";
        ddlGender.SelectedIndex = -1;
        txtdOB.Text = "";
        grdEmployee.DataSource = null;
        grdEmployee.DataBind();
        lblSearch.Text = "";

        this.cpeDemo.Collapsed = true;
        this.cpeDemo.ClientState = "true";

    }

    protected void txtFiscalYear_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtInspection.Attributes.Clear();
            txtInspectionDate.Text = "";

            bool err = false;
            string strFiscal = txtFiscalYear.Text;
            char[] ch = strFiscal.ToCharArray();

            try
            {
                int i1 = int.Parse(ch[0].ToString());
                int i2 = int.Parse(ch[1].ToString());
                string i3 = ch[2].ToString();
                int i4 = int.Parse(ch[3].ToString());
                int i5 = int.Parse(ch[4].ToString());

                int i12 = i1 * 10 + i2;
                int i45 = i4 * 10 + i5;

                if (i3 != "/")
                {
                    txtFiscalYear.Text = "";
                    this.lblStatusMessage.Text = "Invalid Fiscal Year .Use '/' as separator";
                    this.programmaticModalPopup.Show();
                    return;
                }
                if (!(i12 + 1 == i45))
                {
                    err = true;
                }

            }
            catch (Exception)
            {
                err = true;
                
            }


            if (err)
            {
                txtFiscalYear.Text = "";
                this.lblStatusMessage.Text = "Invalid Fiscal Year .";
                this.programmaticModalPopup.Show();
                return;
            }

            LoadWorkInspectionDetails();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    protected void grdWorkInspectionDetails_SelectedIndexChanged(object sender, EventArgs e)
    {        

        try
        {
            ddlWorkList.SelectedValue = grdWorkInspectionDetails.SelectedRow.Cells[2].Text;
            chkDone.Checked = ((CheckBox)grdWorkInspectionDetails.SelectedRow.Cells[4].Controls[0]).Checked;
            txtNoOfCases.Text = grdWorkInspectionDetails.SelectedRow.Cells[5].Text;
            txtInspectionCaseNo.Text = grdWorkInspectionDetails.SelectedRow.Cells[6].Text;
            txtNoDoneReason.Text = Server.HtmlDecode(grdWorkInspectionDetails.SelectedRow.Cells[7].Text).ToString();
            chkIsReasonValid.Checked = ((CheckBox)grdWorkInspectionDetails.SelectedRow.Cells[8].Controls[0]).Checked;
            txtremarks.Text = grdWorkInspectionDetails.SelectedRow.Cells[9].Text;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }


    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtInspection.Text = grdEmployee.SelectedRow.Cells[5].Text;
            txtInspection.Attributes.Add("InspectorID", grdEmployee.SelectedRow.Cells[0].Text);

            this.cpeDemo.Collapsed = true;
            this.cpeDemo.ClientState = "true";
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    protected void grdWorkInspectionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            if (e.Row.Cells[10].Text == "D")
            {
                e.Row.Cells[11].Enabled = false;
                Button btn = (Button)e.Row.FindControl("btnDelete");
                btn.Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
    protected void grdWorkInspectionDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Button btn = (Button)grdWorkInspectionDetails.Rows[e.RowIndex].FindControl("btnDelete");
        List<ATTJudgeWorkInspectionDetails> WorkDetailsLst = (List<ATTJudgeWorkInspectionDetails>)Session["WorkDetailsLst"];
        if (WorkDetailsLst[e.RowIndex].Action == "A"|WorkDetailsLst[e.RowIndex].Action == "EA")
        {
            WorkDetailsLst.RemoveAt(e.RowIndex);
            ClearControls(false);
        }
        else
        {

            if (btn.Text == "Delete")
            {
                string st = WorkDetailsLst[e.RowIndex].Action;

                WorkDetailsLst[e.RowIndex].Action = "D";
                ClearControls(false);
            }
            else if (btn.Text == "Undo")
            {
                WorkDetailsLst[e.RowIndex].Action = "E";
                ClearControls(false);
            }
        }

        ddlJudgeList.Enabled = false;
        txtFiscalYear.Enabled = false;

        grdWorkInspectionDetails.DataSource = WorkDetailsLst;
        grdWorkInspectionDetails.DataBind();

        Session["WorkDetailsLst"] = WorkDetailsLst;


    }

    protected void ddlJudgeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJudgeList.SelectedIndex < 1)
        {
            return;
        }
        txtInspection.Attributes.Clear();
        txtInspectionDate.Text = "";
        LoadWorkInspectionDetails();
    }
    protected void ddlCourt_SelectedIndexChanged(object sender, EventArgs e)
    {

        txtInspection.Attributes.Clear();
        txtInspectionDate.Text = "";
        ddlJudgeList.DataSource = null;
        ddlJudgeList.DataBind();
        LoadJudgeList(int.Parse(ddlCourt.SelectedValue));
    }


}
