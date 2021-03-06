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

public partial class MODULES_PMS_LookUp_JudgeWork : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,36,1") == true)
        {
            if (!IsPostBack)
            {
                LoadWorkList();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }
    void LoadWorkList()
    {
      lstWorks.DataTextField = "JwcName";
      lstWorks.DataValueField = "JwcID";

        List<ATTJudgeWorkList> workList = BLLJudgeWorkList.GetJudgeWorkList(null);
        Session["WorkList"] = workList;
        lstWorks.DataSource = workList;
        lstWorks.DataBind();


       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTJudgeWorkList> workList = (List<ATTJudgeWorkList>)Session["Worklist"];
        if (txtWork.Text == "")
        {
            this.lblStatusMessage.Text = "*र्कपया विवरण भर्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        bool exists = workList.Exists(delegate(ATTJudgeWorkList obj)
                                     {
                                         return (obj.JwcName == this.txtWork.Text);
                                     }
                                 );
        if (exists)
        {
            this.lblStatusMessage.Text = "**सोहि नामको विवरण पहिले नै उपलब्द छ";
            this.programmaticModalPopup.Show();
            this.txtWork.Text = "";
            return;
        }
        
        string strUser = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        ATTJudgeWorkList objWork = new ATTJudgeWorkList((lstWorks.SelectedIndex >= 0) ? int.Parse(lstWorks.SelectedValue) : 0, txtWork.Text, chkActive.Checked, strUser);
        if (lstWorks.SelectedIndex >= 0)
        {
            objWork.Action = "E";
        }
        else
            objWork.Action="A";

        if (BLLJudgeWorkList.SaveJudgeWorkList(objWork))
        {
            if (objWork.Action == "A")
            {               
                workList.Add(objWork);
                this.lblStatusMessage.Text = "Judge Work List Saved";
                this.programmaticModalPopup.Show();
            }
            else if (objWork.Action == "E")
            {
                workList[lstWorks.SelectedIndex] = objWork;
                this.lblStatusMessage.Text = "Judge Work List Edited";
                this.programmaticModalPopup.Show();
            }

            Session["WorkList"] = workList;
            lstWorks.DataSource = workList;
            lstWorks.DataBind();

            ClearControls();
        }
    }

    void ClearControls()
    {
        txtWork.Text = "";
        chkActive.Checked = false;
        lstWorks.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void lstWorks_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTJudgeWorkList> workList = (List<ATTJudgeWorkList>)Session["Worklist"];
        ATTJudgeWorkList objWork = workList[lstWorks.SelectedIndex];

        txtWork.Text = objWork.JwcName;
        chkActive.Checked = objWork.Active;
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
