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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_FixedHoliday : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,34,1") == true)
        {
            Session["UserName"] = user.UserName;
            //this.rdoAppDateType.SelectedIndex = 0;            
            if (this.IsPostBack == false)
            {
                this.rdoFixDateType.SelectedIndex = 0;
                LoadFixedHolidays();
               
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
 
    void LoadFixedHolidays()
    {
        List<ATTFixedHoliday> LSTFxHoliday = BLLFixedHoliday.GetFixedHolidays();
        this.grdFixData.DataSource = LSTFxHoliday;
        this.grdFixData.DataBind();
        this.grdFixData.SelectedIndex = -1;
        Session["FxHoliday"] = LSTFxHoliday;
    }
    protected void btnFixedAdd_Click(object sender, EventArgs e)
    {
        string msg=EmptyMessageValidation("fx");
        List<ATTFixedHoliday> LSTFix =(List<ATTFixedHoliday>)Session["FxHoliday"];
        if (msg == "")
        {
            int frmMonth = int.Parse(this.txtFxFromMonth.Text);
            int toMonth = int.Parse(this.txtFxToMonth.Text);
            int fromDay = int.Parse(this.txtFxFromDay.Text);
            int toDay = int.Parse(this.txtFxToDay.Text);
            if (toMonth < frmMonth)
            {
                this.lblStatusMessage.Text = "**मिति सच्याउनुहोस्\n** देखि माहिना कम भयो";
                this.programmaticModalPopup.Show();
                this.txtFxToMonth.Text = "";
                this.txtFxToMonth.Focus();
                return;
            }
            if (toDay < fromDay)
            {
                this.lblStatusMessage.Text = "**मिति सच्याउनुहोस्\n** देखि दिन कम भयो";
                this.programmaticModalPopup.Show();
                this.txtFxToDay.Text = "";
                this.txtFxToDay.Focus();
                return;
            }
            ATTFixedHoliday objFix = new ATTFixedHoliday();
            objFix.FromMonth = this.txtFxFromMonth.Text.Trim();
            objFix.ToMonth = this.txtFxToMonth.Text.Trim();
            objFix.FromDay = this.txtFxFromDay.Text.Trim();
            objFix.ToDay = this.txtFxToDay.Text.Trim();
            objFix.DateType = this.rdoFixDateType.SelectedValue.ToString();
            objFix.HolidayDescription = this.txtFixDescription.Text.Trim();
            //objFix.Year = this.ddlYear.SelectedValue.ToString();
            objFix.EntryBy = Session["UserName"].ToString();
            objFix.Action = "A";
            foreach (GridViewRow row in this.grdFixData.Rows)
            {
                if (this.txtFxFromMonth.Text == row.Cells[0].Text && this.txtFxFromDay.Text == row.Cells[2].                                                                                                Text
                    && this.txtFxToMonth.Text == row.Cells[1].Text && this.txtFxToDay.Text == row.Cells[3].                                                                                                 Text
                    && this.txtFixDescription.Text == row.Cells[5].Text)
                {
                    this.lblStatusMessage.Text = "**बिदा पहिले नै छ";
                    this.programmaticModalPopup.Show();
                    ClearControls("Submit");
                    return;
                }
            }
            LSTFix.Add(objFix);
            this.grdFixData.DataSource = LSTFix;
            this.grdFixData.DataBind();
            this.grdFixData.SelectedIndex = -1;
        
            Session["FixedHoliday"] = LSTFix;
            ClearControls("Submit");
        }
        else
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    string EmptyMessageValidation(string type)
    {
        string msg = "";
        int count = 0;
        if (type == "fx")
        {
            //if (this.ddlYear.SelectedIndex <= 0)
            //{
            //    msg += "</br></br>** वर्ष छान्नुहोस् </br>";
            //    count++;
            //}
            if (this.txtFxFromMonth.Text == "")
            {
                msg += "** सुरु महिना राख्नुहोस्</br>";
                count++;
            }
            if (this.txtFxFromDay.Text == "")
            {
                msg += "** सकिने महिना राख्नुहोस्</br>";
                count++;
            }
            if (this.txtFxFromDay.Text == "")
            {
                msg += "** सुरु दिन राख्नुहोस्</br>";
                count++;
            }
            if (this.txtFxToDay.Text == "")
            {
                msg += "** सकिने दिन राख्नुहोस्</br>";
                count++;
            }
        }
        if (count > 0)
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
        }

        return msg;
    }

    protected void grdFixData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        List<ATTFixedHoliday> lst = (List<ATTFixedHoliday>)Session["FxHoliday"];
        int index = e.RowIndex;

        if (((LinkButton)grdFixData.Rows[index].FindControl("btnDelete")).Text == "Delete")
        {
            if (grdFixData.Rows[index].Cells[6].Text == "" || grdFixData.Rows[index].Cells[6].Text == "&nbsp;")
            {

                lst[index].Action = "D";

            }
            else if (grdFixData.Rows[index].Cells[6].Text == "A")
            {
                lst.RemoveAt(index);
            }
        }
        else if (((LinkButton)grdFixData.Rows[index].FindControl("btnDelete")).Text == "Undo")
        {
           lst[e.RowIndex].Action = "";
        }

        grdFixData.DataSource = lst;
        grdFixData.DataBind();
        Session["FixedHoliday"] = lst;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int count = 0;
        string msg = "";
        List<ATTFixedHoliday> LSTFix = new List<ATTFixedHoliday>();
        LSTFix = (List<ATTFixedHoliday>)Session["FixedHoliday"];
        try
        {
            if (LSTFix != null)
            {
                if (BLLFixedHoliday.SaveFixedHoliday(LSTFix))
                {
                    count++;
                    msg += "</br></br>**Fixed Holiday Saved Successfully.";
                    grdFixData.DataSource = Session["FixedHoliday"];
                    grdFixData.DataBind();
                    ClearControls("Submit");
                }
            }
           
            if (count > 0)
            {
                this.lblStatusMessage.Text = msg;
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ClearControls(string p)
    {
        if (p == "Submit")
        {
            this.txtFxFromMonth.Text = "";
            this.txtFxToMonth.Text = "";
            this.txtFxFromDay.Text = "";
            this.txtFxToDay.Text = "";
            this.txtFixDescription.Text = "";
            this.rdoFixDateType.SelectedIndex = 0;
            this.grdFixData.SelectedIndex = -1;
        }
    }

    //protected void chk_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool val = true;
    //    foreach (GridViewRow row in grdFixData.Rows)
    //    {
    //        bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
    //        if (check)
    //        {
    //            val = false;
    //        }

    //    }
    //    ((CheckBox)grdFixData.HeaderRow.Cells[0].FindControl("chk")).Checked = val;

    //}

    //protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool val = ((CheckBox)grdFixData.HeaderRow.Cells[0].FindControl("chk")).Checked;
    //    foreach (GridViewRow row in grdFixData.Rows)
    //    {
    //        ((CheckBox)row.Cells[0].FindControl("chk")).Checked = val;

    //    }

    //}

    protected void grdFixData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[6].Text == "D")
            {
                ((LinkButton)e.Row.FindControl("btnDelete")).Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[6].Text == "")
            {
                ((LinkButton)e.Row.FindControl("btnDelete")).Text = "Delete";
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
   
    protected void grdFixData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("Submit");

    }
}
