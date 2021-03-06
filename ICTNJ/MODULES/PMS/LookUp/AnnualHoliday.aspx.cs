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

public partial class MODULES_PMS_LookUp_AnnualHoliday : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,35,1") == true)
        {
            Session["User"] = user.UserName;
            Session["OrgID"] = user.OrgID;
            if (this.IsPostBack == false)
            {
                GetYear();
                this.lblStatus.Text = "";
                Session["FxHoliday"] = new List<ATTFixedHoliday>();
                Session["AnnPrevHoliday"] = new List<ATTAnnualHoliday>();
                Session["LoadedData"] = new List<ATTAnnualHoliday>();
                LoadFixedHolidays();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    void GetYear()
    {
        List<ATTFixedHoliday> LSTYear = BLLFixedHoliday.GetYear();
        LSTYear.Insert(0, new ATTFixedHoliday("छान्नुहोस्", "", "", "", "", "", "", "", ""));
        this.ddlYear2.DataSource = LSTYear;
        this.ddlYear2.DataTextField = "Year";
        this.ddlYear2.DataValueField = "Year";
        this.ddlYear2.DataBind();
    }
    void LoadFixedHolidays()
    {
        List<ATTFixedHoliday> LSTFxHoliday = BLLFixedHoliday.GetFixedHolidays();
        this.grdFixData.DataSource = LSTFxHoliday;
        this.grdFixData.DataBind();
        this.grdFixData.SelectedIndex = -1;
        Session["FxHoliday"] = LSTFxHoliday;
    }
    protected void btnAppAdd_Click(object sender, EventArgs e)
    {
        string msg = EmptyMessageValidation("ann");
        List<ATTAnnualHoliday> LSTAnnual = (List<ATTAnnualHoliday>)Session["LoadedData"];
        if (msg == "")
        {
            ATTAnnualHoliday objAnnual = new ATTAnnualHoliday();
            objAnnual.OrgID =int.Parse(Session["OrgID"].ToString());
            objAnnual.FY = int.Parse(this.ddlYear2.SelectedValue.ToString().Substring(2, 2));
            objAnnual.FromDate = this.txtAnnFromDate.Text.Trim();
            objAnnual.ToDate = this.txtAnnToDate.Text.Trim();
            //objAnnual.DateType = this.rdoAppDateType.SelectedValue.ToString();
            objAnnual.HolidayDescription = this.txtAnnDescription.Text.Trim();
            objAnnual.EntryBy = Session["User"].ToString();
            if(this.rdoDateType.SelectedValue=="0")
            {
                objAnnual.DateType = "N";
            }
            else if (this.rdoDateType.SelectedValue == "1")
            {
                objAnnual.DateType = "E";
            }
            objAnnual.Action = "A";
            LSTAnnual.Add(objAnnual);
        }
        else
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        this.grdAnnualData.DataSource = LSTAnnual;
        this.grdAnnualData.DataBind();
        ClearControls("Add");
    
    }
    string EmptyMessageValidation(string type)
    {
        string msg = "";

        if (type == "ann")
        {
            int count = 0;
            if (this.ddlYear2.SelectedIndex <= 0)
            {
                msg += "</br></br>** वर्ष छान्नुहोस् </br>";
                count++;
            }
            if (this.txtAnnFromDate.Text == "")
            {
                msg += "देखी भर्नुहोस्";
                count++;
            }
            if (this.txtAnnToDate.Text == "")
            {
                msg += "सम्म भर्नुहोस्";
                count++;
            }
            if (count > 0)
            {
                this.lblStatusMessage.Text = msg;
                this.programmaticModalPopup.Show();
            }
        }
        return msg;
    }
    protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string year = "";
        if (this.ddlYear2.SelectedIndex > 0)
        {
            year = this.ddlYear2.SelectedValue.ToString().Substring(2, 2);
        }
        else
        {
            return;
        }
        List<ATTAnnualHoliday> LSTAnnHoliday = BLLAnnualHoliday.GetAnnHoliday(year);

        grdAnnualData.SelectedIndex = -1;
        grdAnnualData.DataSource = LSTAnnHoliday;
        grdAnnualData.DataBind();

        if (this.ddlYear2.SelectedIndex>0 && grdAnnualData.Rows.Count == 0)
        {
            this.lblStatus.Text = "No Record Found";
        }
        else
        {
            this.lblStatus.Text = "Records Found:" + grdAnnualData.Rows.Count.ToString();
        }
        Session["LoadedData"] = LSTAnnHoliday;
    }
    protected void grdAnnualData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[6].Visible = false;
    }
    protected void grdAnnualData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[5].Text == "D")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteAnn")).Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[5].Text == "")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteAnn")).Text = "Delete";
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    //protected void grdAnnualData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    List<ATTAnnualHoliday> lst = (List<ATTAnnualHoliday>)Session["AnnHoliday"];
    //    int index = e.RowIndex;

    //    if (((LinkButton)grdAnnualData.Rows[index].FindControl("btnDeleteAnn")).Text == "Delete")
    //    {
    //        if (grdAnnualData.Rows[index].Cells[5].Text == "" || grdAnnualData.Rows[index].Cells[5].Text == "&nbsp;")
    //        {
    //            lst[index].Action = "D";
    //        }
    //        else if (grdAnnualData.Rows[index].Cells[5].Text == "A")
    //        {
    //            lst.RemoveAt(index);
    //        }
    //    }
    //    else if (((LinkButton)grdAnnualData.Rows[index].FindControl("btnDeleteAnn")).Text == "Undo")
    //    {
    //        lst[e.RowIndex].Action = "";
    //    }
    //    grdAnnualData.DataSource = lst;
    //    grdAnnualData.DataBind();
    //    Session["AnnHoliday"] = lst;
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ddlYear2.SelectedIndex = -1;
        this.txtAnnFromDate.Text = "";
        this.txtAnnToDate.Text = "";
        this.txtAnnDescription.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTAnnualHoliday> LSTSave = new List<ATTAnnualHoliday>();
        List<ATTAnnualHoliday> lstData = (List<ATTAnnualHoliday>)Session["LoadedData"];

        List<ATTFixedHoliday> LSTFix = (List<ATTFixedHoliday>)Session["FxHoliday"];

        int index = 0;

        foreach (GridViewRow rw in this.grdFixData.Rows)
        {
            if (((CheckBox)rw.FindControl("chk")).Checked == true)
            {
                bool exits = lstData.Exists(delegate(ATTAnnualHoliday obj)
                                                            {
                                                                return obj.HolidayDescription == LSTFix[index].HolidayDescription;
                                                            }
                                                    );
                if (!exits)
                {
                    ATTAnnualHoliday obAnn = new ATTAnnualHoliday();

                    obAnn.OrgID =int.Parse(Session["OrgID"].ToString());
                    obAnn.FY = int.Parse(this.ddlYear2.SelectedValue.ToString().Substring(2, 2));
                    obAnn.FromDate = this.ddlYear2.SelectedValue.ToString() + "/" + rw.Cells[1].Text + "/" +                                                                                     rw.Cells[3].Text;
                    obAnn.ToDate = this.ddlYear2.SelectedValue.ToString() + "/" + rw.Cells[2].Text + "/" + rw                                                                                    .Cells[4].Text;
                    obAnn.DateType=rw.Cells[5].Text;
                    obAnn.HolidayDescription = rw.Cells[6].Text;
                    obAnn.EntryBy = Session["User"].ToString();
                    obAnn.Action = "A";
                    LSTSave.Add(obAnn);
                }
                else
                {
                    this.lblStatusMessage.Text = "**बिदा पहिले नै छ";
                    this.programmaticModalPopup.Show();
                    foreach (GridViewRow row in this.grdFixData.Rows)
                    {
                        ((CheckBox)row.FindControl("chk")).Checked = false;
                    }
                    return;
                }
            }
            index++;
        }

        //Second Grid
        List<ATTAnnualHoliday> lstPrev = (List<ATTAnnualHoliday>)Session["AnnPrevHoliday"];


        int index1 = 0;

        foreach (GridViewRow row in this.grdPrevData.Rows)
        {
            if (((CheckBox)row.FindControl("chk1")).Checked == true)
            {
                bool exits = lstData.Exists(delegate(ATTAnnualHoliday obj)
                                                            {
                                                                return obj.HolidayDescription == lstPrev[index1].HolidayDescription;
                                                            }
                                                    );
                if (!exits)
                {
                    ATTAnnualHoliday obAnn1 = new ATTAnnualHoliday();

                    obAnn1.OrgID = int.Parse(Session["OrgID"].ToString());
                    obAnn1.FY = int.Parse(this.ddlYear2.SelectedValue.ToString().Substring(2, 2));
                    obAnn1.FromDate = row.Cells[2].Text;
                    obAnn1.ToDate = row.Cells[3].Text;
                    obAnn1.DateType = "N";
                    obAnn1.HolidayDescription = row.Cells[4].Text;
                    obAnn1.EntryBy = Session["User"].ToString();
                    obAnn1.Action = "A";
                    LSTSave.Add(obAnn1);
                }
                else
                {
                    this.lblStatusMessage.Text = "**बिदा पहिले नै छ";
                    this.programmaticModalPopup.Show();
                    foreach (GridViewRow r in this.grdPrevData.Rows)
                    {
                        ((CheckBox)r.FindControl("chk1")).Checked = false;
                    }
                    return;
                }
            }
            index1++;
        }

        //new data and data from database

        LSTSave.AddRange(lstData);


        if (grdAnnualData.Rows.Count == 0)
        {
            this.lblStatusMessage.Text = "**Sorry! No Data To Save**";
            this.programmaticModalPopup.Show();
            return;
        }
        if (LSTSave.Count > 0)
        {
            if (BLLAnnualHoliday.SaveAnnualHoliday(LSTSave))
            {
                this.lblStatusMessage.Text = "Annual Holiday Saved Successfully";
                this.programmaticModalPopup.Show();

            }
            else
            {
                this.lblStatusMessage.Text = "Annual Holiday could not be Saved ";
                this.programmaticModalPopup.Show();
            }

        }
        ClearControls("submit");
    }
    private void ClearControls(string p)
    {
        if (p == "submit" || p == "Add")
        {
  
            this.txtAnnFromDate.Text = "";
            this.txtAnnToDate.Text = "";
            this.txtAnnDescription.Text = "";
        }
        if (p == "submit")
        {
            foreach (GridViewRow rw in this.grdFixData.Rows)
            {
                ((CheckBox)rw.FindControl("chk")).Checked = false;
            }
            this.ddlYear2.SelectedIndex = 0;
            this.grdAnnualData.DataSource = null;
            this.grdAnnualData.DataBind();
            this.grdAnnualData.SelectedIndex = -1;
        }



    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdFixData.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk")).Checked;
        }
        List<ATTFixedHoliday> LSTFx = (List<ATTFixedHoliday>)Session["FxHoliday"];
        List<ATTAnnualHoliday> LSTAnl = (List<ATTAnnualHoliday>)Session["AnnPrevHoliday"];

        List<ATTFixedHoliday> LSTFxChkd = new List<ATTFixedHoliday>();
        foreach (GridViewRow rw in this.grdFixData.Rows)
        {
            ATTFixedHoliday objFxChkd = new ATTFixedHoliday();
            if (((CheckBox)rw.FindControl("chk")).Checked == true)
            {
                objFxChkd.HolidayDescription = rw.Cells[6].Text;
                LSTFxChkd.Add(objFxChkd);
            }
        }
        
        foreach (ATTFixedHoliday var in LSTFxChkd)
        {
            int index = LSTAnl.FindIndex(delegate(ATTAnnualHoliday obj)
                                                {
                                                    return obj.HolidayDescription == var.HolidayDescription;
                                                }
                                            );
            if (index >= 0)
            {
                ((CheckBox)grdPrevData.Rows[index].FindControl("chk1")).Checked = false;
            }
        }

    }
    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdFixData.HeaderRow.Cells[0].FindControl("chk")).Checked;
        foreach (GridViewRow row in grdFixData.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chk")).Checked = val;
        }
    }
    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdPrevData.Rows)
        {
            bool check = !((CheckBox)row.Cells[0].FindControl("chk1")).Checked;
        }
        List<ATTFixedHoliday> LSTFx = (List<ATTFixedHoliday>)Session["FxHoliday"];
        List<ATTAnnualHoliday> LSTAnl = (List<ATTAnnualHoliday>)Session["AnnPrevHoliday"];

        List<ATTAnnualHoliday> LSTAnnChkd = new List<ATTAnnualHoliday>();
        foreach (GridViewRow rw in this.grdPrevData.Rows)
        {
            ATTAnnualHoliday objPrevChkd = new ATTAnnualHoliday();
            if (((CheckBox)rw.FindControl("chk1")).Checked == true)
            {
                objPrevChkd.HolidayDescription = rw.Cells[4].Text;
                LSTAnnChkd.Add(objPrevChkd);
            }
        }

        foreach (ATTAnnualHoliday var in LSTAnnChkd)
        {
            int index = LSTFx.FindIndex(delegate(ATTFixedHoliday obj)
                                                {
                                                    return obj.HolidayDescription == var.HolidayDescription;
                                                }
                                            );
            if (index >= 0)
            {
                ((CheckBox)grdFixData.Rows[index].FindControl("chk")).Checked = false;
            }
        }
    }
    protected void chkHeader1_CheckedChanged(object sender, EventArgs e)
    {
        bool val = ((CheckBox)grdPrevData.HeaderRow.Cells[0].FindControl("chk1")).Checked;
        foreach (GridViewRow row in grdPrevData.Rows)
        {
            ((CheckBox)row.Cells[0].FindControl("chk1")).Checked = val;

        }
    }
    protected void grdFixData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
    protected void grdAnnualData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTAnnualHoliday> lst = (List<ATTAnnualHoliday>)Session["LoadedData"];

        int index = e.RowIndex;

        if (((LinkButton)grdAnnualData.Rows[index].FindControl("btnDelete")).Text == "Delete")
        {
            if (grdAnnualData.Rows[index].Cells[6].Text == "" || grdAnnualData.Rows[index].Cells[6].Text == "&nbsp;")
            {

                lst[index].Action = "D";

            }
            else if (grdAnnualData.Rows[index].Cells[6].Text == "A")
            {
                lst.RemoveAt(index);
            }
        }
        else if (((LinkButton)grdAnnualData.Rows[index].FindControl("btnDelete")).Text == "Undo")
        {
            lst[e.RowIndex].Action = "";
        }

        grdAnnualData.DataSource = lst;
        grdAnnualData.DataBind();
       
    }
    protected void btnPrevYear_Click(object sender, EventArgs e)
    {
        if (this.ddlYear2.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "**र्कपया वर्ष छान्नुहोस्";
            this.programmaticModalPopup.Show();
            this.ddlYear2.Focus();
            return;
        }
        else
        {
            List<ATTAnnualHoliday> LSTAnnHolidayPrev = BLLAnnualHoliday.GetAnnHolidayPrev();
            grdPrevData.SelectedIndex = -1;
            grdPrevData.DataSource = LSTAnnHolidayPrev;
            grdPrevData.DataBind();
            Session["AnnPrevHoliday"] = LSTAnnHolidayPrev;
        }
    }
}
