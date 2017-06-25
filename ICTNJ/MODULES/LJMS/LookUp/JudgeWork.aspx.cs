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

public partial class MODULES_LJMS_LookUp_JudgeWork : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,4,1") == true)
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

        if (txtWork.Text == "")
            return;
        string strUser="suman";
        ATTJudgeWorkList objWork = new ATTJudgeWorkList((lstWorks.SelectedIndex >= 0) ? int.Parse(lstWorks.SelectedValue) : 0, txtWork.Text, chkActive.Checked, strUser);
        if (lstWorks.SelectedIndex >= 0)
        {
            objWork.Action = "E";
        }
        else
            objWork.Action="A";

        if (BLLJudgeWorkList.SaveJudgeWorkList(objWork))
        {
            List<ATTJudgeWorkList> workList = (List<ATTJudgeWorkList>)Session["Worklist"];
            if (objWork.Action == "A")
            {               
                workList.Add(objWork);
            }
            else if (objWork.Action == "E")
            {
                workList[lstWorks.SelectedIndex] = objWork;
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
}
