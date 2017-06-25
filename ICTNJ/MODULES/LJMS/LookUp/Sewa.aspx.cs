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

using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_LJMS_LookUp_Sewa : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,21,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.SetSewaSession();
                this.LoadSewaList();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadSewaList()
    {
        try
        {
            Session["sewa_list"] = BLLSewa.GetSewaList(null);

            this.lstSewa.DataSource = Session["sewa_list"];
            this.lstSewa.DataTextField = "SewaName";
            this.lstSewa.DataValueField = "SewaID";
            this.lstSewa.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void SetSewaSession()
    {
        Session["Sewa"] = new ATTSewa();
    }

    protected void btnAddSamuha_Click(object sender, EventArgs e)
    {
        if (this.txtSamuha.Text == "")
            return;
        ATTSewa sewa = (ATTSewa)Session["sewa"];

        if (this.grdSamuha.SelectedRow == null)
            sewa.LstSamuha.Add(new ATTSamuha(0, 0, this.txtSamuha.Text, "suraj", DateTime.Now, "A"));
        else
        {
            ATTSamuha ExSamuha = sewa.LstSamuha[this.grdSamuha.SelectedIndex];
            ExSamuha.SamuhaName = this.txtSamuha.Text;
        }

        this.grdSamuha.DataSource = sewa.LstSamuha;
        this.grdSamuha.DataBind();
        this.txtSamuha.Text = "";

        this.grdUpaSamuha.DataSource = "";
        this.grdUpaSamuha.DataBind();
        
        this.grdUpaSamuha.SelectedIndex = -1;
        this.grdSamuha.SelectedIndex = -1;
    }

    protected void btnAddUpaSamuha_Click(object sender, EventArgs e)
    {
        if (this.grdSamuha.SelectedIndex <= -1)
        {
            return;
        }
        if (this.txtUpaSamuha.Text == "")
            return;

        ATTSewa sewa = (ATTSewa)Session["sewa"];
        ATTSamuha samuha = sewa.LstSamuha[this.grdSamuha.SelectedIndex];

        if (this.grdUpaSamuha.SelectedRow == null)
            samuha.LstUpaSamuha.Add(new ATTUpaSamuha(0, 0, 0, this.txtUpaSamuha.Text, "suraj", DateTime.Now, "A"));
        else
        {
            ATTUpaSamuha ExUpaSamuha = samuha.LstUpaSamuha[this.grdUpaSamuha.SelectedIndex];
            ExUpaSamuha.UpaSamuhaName = this.txtUpaSamuha.Text;
        }

        this.grdUpaSamuha.DataSource = samuha.LstUpaSamuha;
        this.grdUpaSamuha.DataBind();
        this.txtUpaSamuha.Text = "";

        this.grdUpaSamuha.SelectedIndex = -1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtSewaName.Text == "")
        {
            this.lblStatus.Text = "Please enter Sewa name.";
            this.lblStatus.Focus();
            return;
        }

        ATTSewa sewa;
        if (this.lstSewa.SelectedIndex <= -1)
        {
            sewa = (ATTSewa)Session["sewa"];

            sewa.SewaID = 0;
            sewa.SewaName = this.txtSewaName.Text;
            sewa.EntryBy = "suraj";
            sewa.EntryOn = DateTime.Now;
            sewa.Action = "A";
        }
        else
        {
            sewa = ((List<ATTSewa>)Session["sewa_list"])[this.lstSewa.SelectedIndex];

            sewa.SewaName = this.txtSewaName.Text;
        }

        try
        {
            BLLSewa.AddSewa(sewa);

            if (this.lstSewa.SelectedIndex <= -1)
                ((List<ATTSewa>)Session["sewa_list"]).Add(sewa);
            else
                ((List<ATTSewa>)Session["sewa_list"])[this.lstSewa.SelectedIndex] = sewa;

            this.lstSewa.DataSource = Session["sewa_list"];
            this.lstSewa.DataTextField = "SewaName";
            this.lstSewa.DataValueField = "SewaID";
            this.lstSewa.DataBind();

            this.ClearThisObject();
            this.lstSewa.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.ToString();
        }
    }

    void ClearThisObject()
    {
        this.txtSewaName.Text = "";
        this.txtSamuha.Text = "";
        this.txtUpaSamuha.Text = "";
        this.lblStatus.Text = "";
        this.grdSamuha.DataSource = "";
        this.grdUpaSamuha.DataSource="";
        this.grdSamuha.DataBind();
        this.grdUpaSamuha.DataBind();
        this.grdSamuha.SelectedIndex = -1;
        this.grdUpaSamuha.SelectedIndex = -1;

        this.SetSewaSession();
    }

    protected void grdSamuha_SelectedIndexChanged(object sender, EventArgs e)
    {
        ATTSewa sewa = (ATTSewa)Session["sewa"];
        ATTSamuha samuha = sewa.LstSamuha[this.grdSamuha.SelectedIndex];
        List<ATTUpaSamuha> lstUpaSamuha = samuha.LstUpaSamuha;

        this.txtSamuha.Text = samuha.SamuhaName;

        this.txtUpaSamuha.Text = "";
        this.grdUpaSamuha.DataSource = lstUpaSamuha;
        this.grdUpaSamuha.DataBind();
        this.grdUpaSamuha.SelectedIndex = -1;
    }

    protected void lstSewa_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearThisObject();

        ATTSewa sewa = ((List<ATTSewa>)Session["sewa_list"])[this.lstSewa.SelectedIndex].CreateDeepCopy();
        this.SetSewaSession();
        Session["sewa"] = sewa;
        this.txtSewaName.Text = sewa.SewaName;

        this.grdSamuha.DataSource = sewa.LstSamuha;
        this.grdSamuha.DataBind();
    }

    protected void grdUpaSamuha_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtUpaSamuha.Text = this.grdUpaSamuha.SelectedRow.Cells[3].Text;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearThisObject();
        this.lstSewa.SelectedIndex = -1;
    }
}
