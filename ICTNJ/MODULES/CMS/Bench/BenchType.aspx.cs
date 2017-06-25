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

using PCS.CMS.ATT;
using PCS.CMS.BLL;

public partial class MODULES_CMS_Bench_BenchType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack == false)
        {
            chkBenchTypeActive.Checked = true;
            LoadBenchType();
        }
    }

    void LoadBenchType()
    {
        Session["BenchType"] = BLLBenchType.GetBenchType(null, null, 0);
        lstBenchType.DataSource = (List<ATTBenchType>)Session["BenchType"];
        lstBenchType.DataValueField = "BenchTypeID";
        lstBenchType.DataTextField = "BenchTypeName";
        lstBenchType.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtBenchType.Text == "")
        {
            this.lblStatusMessage.Text = "Bench Type Can't Be Left Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        

        List<ATTBenchType> BenchTypeLST = (List<ATTBenchType>)Session["BenchType"];

        int i=-1;
        if (this.lstBenchType.SelectedIndex > -1)
        {
            i = BenchTypeLST.FindIndex(delegate(ATTBenchType obj)
                                                                    {
                                                                        return this.txtBenchType.Text.ToUpper() == obj.BenchTypeName.ToUpper() && this.lstBenchType.SelectedItem.Text.ToUpper() != this.txtBenchType.Text.ToUpper();
                                                                    });
        }
        else
        {
            i = BenchTypeLST.FindIndex(delegate(ATTBenchType obj)
                                                                               {
                                                                                   return this.txtBenchType.Text.ToUpper() == obj.BenchTypeName.ToUpper();
                                                                               });
        }
        if (i > -1)
        {
            this.lblStatusMessage.Text = "Bench Type Name Already Exists";
            this.programmaticModalPopup.Show();
            return;
        }
        

        ATTBenchType objBenchType = new ATTBenchType();
        objBenchType.BenchTypeID = (this.lstBenchType.SelectedIndex == -1) ? 0 : int.Parse(this.lstBenchType.SelectedValue);
        objBenchType.BenchTypeName = this.txtBenchType.Text;
        objBenchType.Active = (chkBenchTypeActive.Checked == true) ? "Y" : "N";
        objBenchType.EntryBy = "manoz";
        objBenchType.Action = (this.lstBenchType.SelectedIndex == -1) ? "A" : "E";

        try
        {

            if (BLLBenchType.SaveBenchType(objBenchType) == true)
            {
                if (this.lstBenchType.SelectedIndex == -1)
                {
                    BenchTypeLST.Add(objBenchType);
                }
                else
                {
                    BenchTypeLST.RemoveAt(this.lstBenchType.SelectedIndex);
                    BenchTypeLST.Add(objBenchType);
                }

                lstBenchType.DataSource = BenchTypeLST;
                lstBenchType.DataValueField = "BenchTypeID";
                lstBenchType.DataTextField = "BenchTypeName";
                lstBenchType.DataBind();

                clearAll();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Bench Type Couldn't Be Saved<BR>" + ex.Message;
            this.programmaticModalPopup.Show();
        }


    }
    protected void lstBenchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTBenchType> BenchTypeLST = (List<ATTBenchType>)Session["BenchType"];
        this.txtBenchType.Text = BenchTypeLST[this.lstBenchType.SelectedIndex].BenchTypeName;
        this.chkBenchTypeActive.Checked = (BenchTypeLST[this.lstBenchType.SelectedIndex].Active == "Y") ? true : false;

    }

    void clearAll()
    {
        this.txtBenchType.Text = "";
        this.chkBenchTypeActive.Checked = true;
        this.lstBenchType.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll();
    }
}
