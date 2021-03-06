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

public partial class MODULES_PMS_LookUp_Sewa : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,21,1") == true)
        {
            Session["UserName"] = user.UserName;
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
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void SetSewaSession()
    {
        Session["Sewa"] = new ATTSewa();
    }

    protected void btnAddSamuha_Click(object sender, EventArgs e)
    {
        if (this.txtSamuha.Text == "")
        {
            this.lblStatusMessage.Text = "समुह छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTSewa> LSTSewa=(List<ATTSewa>)Session["sewa_list"];
        ATTSewa sewa =(ATTSewa)Session["Sewa"];


        if (this.lstSewa.SelectedIndex < 0)
        {
            sewa.SewaName = txtSewaName.Text.Trim();
            sewa.EntryBy = Session["UserName"].ToString();
            sewa.Action = "A";
            List<ATTSewa> LST = LSTSewa.FindAll(
                                                delegate(ATTSewa obj)
                                                {
                                                    return (txtSewaName.Text.Trim() == obj.SewaName.Trim().ToString());
                                                }
                                             );
            if (LST.Count > 0)
            {
                this.lblStatusMessage.Text = "सेवा पहिले नै उपलब्द छ";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                //if (string.IsNullOrEmpty(sewa.SewaName))
                //{
                    //sewa.SewaName = txtSewaName.Text.Trim();
                //}
                sewa.LstSamuha.Add(new ATTSamuha(0, 0, this.txtSamuha.Text, Session["UserName"].ToString(),DateTime.Now, "A"));
                
                //LSTSewa.Add(sewa);
            }
        }
        else 
        {
            
            if (this.grdSamuha.SelectedRow == null)
            {
                sewa.LstSamuha.Add(new ATTSamuha(0, 0, this.txtSamuha.Text, Session["UserName"].ToString(), DateTime.Now, "A"));
                LSTSewa.Add(sewa);
            }
            else
            {
                ATTSamuha ExSamuha = sewa.LstSamuha[this.grdSamuha.SelectedIndex];
                ExSamuha.SamuhaName = this.txtSamuha.Text;
                ExSamuha.Action = "M";

            }
        }

        this.grdSamuha.DataSource = sewa.LstSamuha;
        this.grdSamuha.DataBind();
        Session["Samuha"] = sewa.LstSamuha;
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
            this.lblStatusMessage.Text = "समुह छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.txtUpaSamuha.Text == "")
        {
            this.lblStatusMessage.Text = "उप-समुह छान्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        ATTSewa sewa = (ATTSewa)Session["Sewa"];
        List<ATTSamuha> LSTSamuha = sewa.LstSamuha;
        List<ATTUpaSamuha> LSTUpaSamuha=LSTSamuha[grdSamuha.SelectedIndex].LstUpaSamuha;

        if (grdUpaSamuha.SelectedIndex < 0)
        {
          LSTUpaSamuha.Add(new ATTUpaSamuha(0, 0, 0, this.txtUpaSamuha.Text.ToString(), Session["UserName"].ToString(), DateTime.Now, "A"));
        }
        else
        { 
            ATTUpaSamuha objUpaSamuha = LSTUpaSamuha[grdUpaSamuha.SelectedIndex];
            objUpaSamuha.SewaID = 0;
            objUpaSamuha.SamuhaID = 0;
            objUpaSamuha.UpaSamuhaID = 0;
            objUpaSamuha.UpaSamuhaName = this.txtUpaSamuha.Text.ToString().Trim();
            objUpaSamuha.EntryBy = Session["UserName"].ToString();
            objUpaSamuha.Action = "M";
        }
        

        this.grdUpaSamuha.DataSource = LSTUpaSamuha;
        this.grdUpaSamuha.DataBind();
        this.txtUpaSamuha.Text = "";
        this.grdUpaSamuha.SelectedIndex = -1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtSewaName.Text == "")
        {
            this.lblStatusMessage.Text = "**सेवाको नाम राख्न्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.txtSamuha.Text == "" && this.txtUpaSamuha.Text != "")
        {
            this.lblStatusMessage.Text = "**समुहको नाम राख्नुहोस्";
            this.programmaticModalPopup.Show();
            this.txtUpaSamuha.Text = "";
            return;
        }

        ATTSewa sewa = (ATTSewa)Session["Sewa"];
        if (sewa == null)
        {
            this.lblStatusMessage.Text = "**र्कपया सेवा राख्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            sewa.SewaName = txtSewaName.Text;

            foreach (ATTSamuha VAR in sewa.LstSamuha)
            {
                if (VAR.LstUpaSamuha.Count<1)
                {
                    ATTUpaSamuha obj = new ATTUpaSamuha();
                    obj.UpaSamuhaName = VAR.SamuhaName;
                    obj.Action = "A";
                    obj.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

                    VAR.LstUpaSamuha.Add(obj);                    
                }
            }

            
            try
            {
                if (BLLSewa.AddSewa(sewa))
                {
                    //if (sewa.Action == "A")
                    //{
                        this.lblStatusMessage.Text = "Sewa Saved Successfully.";
                        this.programmaticModalPopup.Show();
                    //}
                    //else
                    //{
                    //    this.lblStatusMessage.Text = "Sewa Edited Successfully";
                    //    this.programmaticModalPopup.Show();
                    //}
                }
                if (this.lstSewa.SelectedIndex == -1)
                    ((List<ATTSewa>)Session["sewa_list"]).Add(sewa);
                else
                    ((List<ATTSewa>)Session["sewa_list"])[this.lstSewa.SelectedIndex] = sewa;

                this.lstSewa.DataSource = Session["sewa_list"];
                this.lstSewa.DataTextField = "SewaName";
                this.lstSewa.DataValueField = "SewaID";
                this.lstSewa.DataBind();
                this.ClearThisObject();
                this.lstSewa.SelectedIndex = -1;
                this.txtSewaName.Focus();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
    }

    void ClearThisObject()
    {
        this.txtSewaName.Text = "";
        this.txtSamuha.Text = "";
        this.txtUpaSamuha.Text = "";
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
        ATTSewa sewa = (ATTSewa)Session["Sewa"];
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
        Session["Sewa"] = sewa;
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
