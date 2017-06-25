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
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.FRAMEWORK;


public partial class MODULES_PMS_Forms_EmpDeputationReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.SrchGrid.Height = Unit.Pixel(0);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,4,1") == true)
        {
            Session["Orgid"] = user.OrgID;
            Session["UserName"] = user.UserName;
            if (this.IsPostBack == false)
            {
                LoadEmpDepReturn();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    private void LoadEmpDepReturn()
    {
        int orgid = int.Parse(Session["Orgid"].ToString());
        string active = "Y";
        List<ATTEmployeeDeputaion> LSTEmpDepReturn = BLLEmployeeDeputation.GetEmpForDeputationReturn(orgid,active);
        Session["EmpDepReturn"] = LSTEmpDepReturn;
        this.grdEmpDepReturn.DataSource = LSTEmpDepReturn;
        this.grdEmpDepReturn.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeDeputaion> LSTEmpDeputation = (List<ATTEmployeeDeputaion>)Session["EmpDepReturn"];
       
        int countErr = 0;
        
        for (int j = 0; j <= this.grdEmpDepReturn.Rows.Count - 1; j++)
        {
            bool val = true;
            LSTEmpDeputation[j].ReturnDate = ((TextBox)grdEmpDepReturn.Rows[j].FindControl("TextBox1")).Text;
            
            string leavedate = LSTEmpDeputation[j].LeaveDate;
            string returndate = LSTEmpDeputation[j].ReturnDate;
            
            if (returndate.Trim() != "")
            {
                val = (CheckDateIsValid(leavedate, returndate));
            }
            if (!val)
            {
                countErr++;
            }

           
            LSTEmpDeputation[j].Action = "ER";
        }
        try
        {
            if (countErr == 0)
            {
                List<ATTEmployeeDeputaion> LST = LSTEmpDeputation.FindAll(
                                                                            delegate(ATTEmployeeDeputaion obj)
                                                                            {
                                                                                return obj.ReturnDate != "";
                                                                            }
                    );
                if (BLLEmployeeDeputation.SaveEmpForDeputation(LST))
                {
                    this.lblStatusMessage.Text = "**Employee Deputation Return Successfully Save";
                    this.programmaticModalPopup.Show();
                    int orgid = int.Parse(Session["Orgid"].ToString());
                    string active = "Y";
                    List<ATTEmployeeDeputaion> LSTEmpDepReturn = BLLEmployeeDeputation.GetEmpForDeputationReturn(orgid, active);
                    this.grdEmpDepReturn.DataSource = LSTEmpDepReturn;
                    this.grdEmpDepReturn.DataBind();
                    return;
                }
            }
            else 
            {
                this.lblStatusMessage.Text = countErr.ToString() + ".  data has invalid date<br/>**Leave Date Is Greater Than Return Date";
                this.programmaticModalPopup.Show();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    private bool CheckDateIsValid(string oldDate, string newDate)
    {
        string[] oldDt = oldDate.Split(new char[] { '/' });
        string[] newDt = newDate.Split(new char[] { '/' });

        int oldYr = int.Parse(oldDt[0]);
        int oldMth = int.Parse(oldDt[1]);
        int oldDy = int.Parse(oldDt[2]);

        int newYr = int.Parse(newDt[0]);
        int newMth = int.Parse(newDt[1]);
        int newDy = int.Parse(newDt[2]);

        bool val = false;

        if (newYr > oldYr)
        {
            val = true;
        }
        else if (newYr < oldYr)
        {
            val = false;
        }
        else if (newYr == oldYr)
        {
            if (newMth > oldMth)
            {
                val = true;
            }
            else if (newMth < oldMth)
            {
                val = false;
            }
            else if (newMth == oldMth)
            {
                if (newDy > oldDy)
                {
                    val = true;
                }
                else if (newDy < oldDy)
                {
                    val = false;
                }
                else if (newDy == oldDy)
                {
                    val = false;
                }
            }
        }
        return val;
    }
    protected void grdEmpDepReturn_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[11].Visible = false;
    }
}
