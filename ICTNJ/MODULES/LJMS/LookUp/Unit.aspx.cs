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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;
using PCS.LJMS.ATT;
using PCS.LJMS.BLL;

public partial class MODULES_LJMS_LookUp_Unit : System.Web.UI.Page
{
    public ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

    public string MenuName
    {
        get { return Session["List_Menuname"].ToString(); }
    }

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
        if (user.MenuList.ContainsKey("2,37,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadUnit();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadUnit()
    {
        try
        {
            this.grdUnit.DataSource = BLLUnit.GetUnitList(null, false);
            this.grdUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdUnit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void grdUnit_DataBound(object sender, EventArgs e)
    {
        if (this.grdUnit.Rows.Count <= 0)
        {
            this.lblCount.Text = "No unit found.";
        }
        else
        {
            this.lblCount.Text = "Total unit: " + this.grdUnit.Rows.Count.ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Please enter unit name.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtAddress_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Please enter unit address.";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.txtPhone_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Please enter unit phone number.";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUnit unit = new ATTUnit();
        unit.UnitID = 0;
        unit.UnitName = this.txtName_Rqd.Text;
        unit.UnitAddress = this.txtAddress_Rqd.Text;
        unit.UnitPhone = this.txtPhone_Rqd.Text;
        unit.Active = this.cnkActive.Checked == true ? "Y" : "N";
        unit.Action = "A";

        if (this.grdUnit.SelectedIndex >= 0)
        {
            unit.UnitID = int.Parse(this.grdUnit.SelectedRow.Cells[0].Text);
            unit.Action = "E";
        }

        if (this.grdUnit.SelectedIndex < 0)
        {
            if (this.User.MenuList[this.MenuName] == null || this.User.MenuList[this.MenuName].PAdd == "N")
            {
                string s = Utilities.PreviledgeMsg + " add lawyer unit.";
                this.ShowMessage(null, s);
                return;
            }
        }
        else
        {
            if (this.User.MenuList[this.MenuName] == null || this.User.MenuList[this.MenuName].PEdit == "N")
            {
                string s = Utilities.PreviledgeMsg + " edit lawyer unit.";
                this.ShowMessage(null, s);
                return;
            }
        }

        try
        {
            BLLUnit.AddUnit(unit);
            this.Clear();
            this.LoadUnit();
            this.lblStatusMessage.Text = "Unit has been saved successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void Clear()
    {
        this.txtName_Rqd.Text = "";
        this.txtAddress_Rqd.Text = "";
        this.txtPhone_Rqd.Text = "";
        this.cnkActive.Checked = false;
        this.grdUnit.SelectedIndex = -1;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.Clear();
    }

    void ShowMessage(Exception ex, string msg)
    {
        string s;
        if (ex != null)
            s = ex.Message;
        else
            s = msg;

        this.lblStatusMessage.Text = s;
        this.programmaticModalPopup.Show();
    }

    protected void grdUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = this.grdUnit.SelectedRow;

        this.txtName_Rqd.Text = row.Cells[1].Text;
        this.txtAddress_Rqd.Text = FilterText(row.Cells[2].Text);
        this.txtPhone_Rqd.Text = FilterText(row.Cells[3].Text);
        this.cnkActive.Checked = row.Cells[4].Text == "Y" ? true : false;

        this.grdUnit.SelectedRow.Focus();
    }

    string FilterText(string s)
    {
        if (s == "&nbsp;" || s == "&NBSP;")
            return "";
        else
            return s;
    }
}
