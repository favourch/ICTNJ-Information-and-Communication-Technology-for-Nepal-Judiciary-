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

public partial class MODULES_CMS_Tameli_MyaadType : System.Web.UI.Page
{

    protected enum Type
    {
        A,//Appelant
        R,//Respondent
        B//Both
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
            LoadMyaadType();

    }
     private void LoadMyaadType()
    {
        try
        {
            List<ATTMyaadType> myaadTypeLIST = BLLMyaadType.GetMyaadType(null,null);
            Session["MyaadType"] = myaadTypeLIST;

            lstMyaadType.DataSource = myaadTypeLIST;
            lstMyaadType.DataTextField = "MyaadTypeName";
            lstMyaadType.DataValueField = "MyaadTypeID";
            lstMyaadType.DataBind();
            lstMyaadType.SelectedIndex = -1;
        }
        catch (Exception)
        {
            lblStatusMessage.Text = "Could not Load Myaad Typess </br>";
            this.programmaticModalPopup.Show();
        }


    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void lstMyaadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTMyaadType> listMyaadType = (List<ATTMyaadType>)Session["MyaadType"];
        myaadTxt_Rqd.Text = listMyaadType[lstMyaadType.SelectedIndex].MyaadTypeName.ToString();
        isActiveCb.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Active == "Y" ? true : false);
        pratiuttarCb.Checked = (listMyaadType[lstMyaadType.SelectedIndex].MyaadTypeName == "P" ? true : false);
        rb_Lit_A.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Litigant == "A" ? true : false);
        rb_Lit_R.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Litigant == "R" ? true : false);
        rb_Lit_B.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Litigant == "B" ? true : false);

        rb_Att_A.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Attorney == "A" ? true : false);
        rb_Att_R.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Attorney == "R" ? true : false);
        rb_Att_B.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Attorney == "B" ? true : false);

        rb_Witt_A.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Witness == "A" ? true : false);
        rb_Witt_R.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Witness == "R" ? true : false);
        rb_Witt_B.Checked = (listMyaadType[lstMyaadType.SelectedIndex].Witness == "B" ? true : false);

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strUser="suman";

        if (myaadTxt_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Myad cannot be empty";
            this.programmaticModalPopup.Show();
        }
        ATTMyaadType objMyaadType = new ATTMyaadType
        (
        this.lstMyaadType.SelectedIndex > -1 ? int.Parse(this.lstMyaadType.SelectedValue) : 0,
        this.myaadTxt_Rqd.Text.Trim(),
        this.isActiveCb.Checked ? "Y" : "N"
        );
        objMyaadType.Action = this.lstMyaadType.SelectedIndex > -1 ? "E" : "A";
        objMyaadType.MyaadTypeName = pratiuttarCb.Checked == true ? "P" : "";
        objMyaadType.Litigant = (rb_Lit_A.Checked == true ? "A" : rb_Lit_R.Checked == true ? "R" : rb_Lit_B.Checked == true ? "B" : "");
        objMyaadType.Attorney = (rb_Att_A.Checked == true ? "A" : rb_Att_R.Checked == true ? "R" : rb_Att_B.Checked == true ? "B" : "");
        objMyaadType.Witness = (rb_Witt_A.Checked == true ? "A" : rb_Witt_R.Checked == true ? "R" : rb_Witt_B.Checked == true ? "B" : "");
        objMyaadType.EntryBy = strUser;
        try
        {
            BLLMyaadType.AddEditDeleteMyaadType(objMyaadType);
            lblStatusMessage.Text = "Succesfully Saved";
            this.programmaticModalPopup.Show();
            LoadMyaadType();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.lstMyaadType.SelectedIndex = -1;
        this.myaadTxt_Rqd.Text = "";
        this.isActiveCb.Checked = false;
        this.pratiuttarCb.Checked = false;
        rb_Att_A.Checked = rb_Att_B.Checked = rb_Att_R.Checked = rb_Lit_A.Checked = rb_Lit_B.Checked = rb_Lit_R.Checked = rb_Witt_A.Checked = rb_Witt_B.Checked = rb_Witt_R.Checked = false;
    }
}
