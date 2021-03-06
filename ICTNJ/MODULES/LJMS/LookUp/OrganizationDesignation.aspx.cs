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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_LookUp_OrganizationDesignation : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
        this.Title = "LJMS | Post";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if ((user.MenuList.ContainsKey("3,6,1") == true) || (user.MenuList.ContainsKey("2,7,1") == true))
        {
            Session["OrgID"] = user.OrgID;
            if (!this.IsPostBack)
            {
                Session["OrganizationDesignation"] = "";
                LoadOrganizationAndDesignation(int.Parse(Session["OrgID"].ToString()));
                LoadDesignation();
                LoadDesignationLevel();
                LoadSewa();
                ClearControls();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadDesignation()
    {
        string desType =  "J";

        try
        {
            List<ATTDesignation> DesignationList = BLLDesignation.GetDesignation(null, desType);
            DesignationList.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
            this.ddlDesignation_Rqd.DataSource = DesignationList;
            this.ddlDesignation_Rqd.DataTextField = "DESIGNATIONNAME";
            this.ddlDesignation_Rqd.DataValueField = "DESIGNATIONID";
            this.ddlDesignation_Rqd.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void LoadSewa()
    {
        List<ATTSewa> SewaList = BLLSewa.GetSewaList(null);
        Session["SewaList"] = SewaList;
        SewaList.Insert(0, new ATTSewa(0, "छान्नुहोस", "", DateTime.Now, ""));
        this.ddlSewa_Rqd.DataSource = SewaList;
        this.ddlSewa_Rqd.DataTextField = "SEWANAME";
        this.ddlSewa_Rqd.DataValueField = "SEWAID";
        this.ddlSewa_Rqd.DataBind();
    }

    void LoadDesignationLevel()
    {
        List<ATTDesignationLevel> DesignationLevelList = BLLDesignationLevel.GetDesignationLevelList();
        DesignationLevelList.Insert(0, new ATTDesignationLevel(0, "छान्नुहोस"));
        this.ddlDesignationLevel_Rqd.DataSource = DesignationLevelList;
        this.ddlDesignationLevel_Rqd.DataTextField = "LEVELNAME";
        this.ddlDesignationLevel_Rqd.DataValueField = "LEVELID";
        this.ddlDesignationLevel_Rqd.DataBind();
    }

    void LoadOrganizationAndDesignation(int OrgID)
    {
        string desType = "J";
        List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
        OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));
        this.ddlOrganization_Rqd.DataSource = OrganizationList;
        this.ddlOrganization_Rqd.DataTextField = "ORGNAME";
        this.ddlOrganization_Rqd.DataValueField = "ORGID";
        this.ddlOrganization_Rqd.DataBind();
        this.ddlOrganization_Rqd.SelectedValue = Session["OrgID"].ToString();

        List<ATTOrganizationDesignation> OrgDesignationList = BLLOrganizationDesignation.GetOrganizationDesignation(OrgID, null, desType);
        Session["OrganizationDesignation"] = OrgDesignationList;
        this.grdOrgDesignation.DataSource = OrgDesignationList;
        this.grdOrgDesignation.DataBind();
    }

    protected void grdOrgDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
    }

    protected void grdOrgDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.grdOrgDesignation.SelectedIndex > -1)
        {
            this.ddlDesignation_Rqd.Enabled = false;
            this.ddlOrganization_Rqd.Enabled = false;
            List<ATTOrganizationDesignation> OrgDesignationList = (List<ATTOrganizationDesignation>)Session["OrganizationDesignation"];
            this.ddlOrganization_Rqd.SelectedValue = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].OrgID.ToString();
            this.ddlDesignation_Rqd.SelectedValue = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].DesID.ToString();
            this.txtTotalSeats_Rqd.Text = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].TotalSeats.ToString();
            this.ddlSewa_Rqd.SelectedValue = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].SewaID.ToString();
            this.ddlSewa_Rqd_SelectedIndexChanged(sender, e);
            this.ddlSamuha_Rqd.SelectedValue = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].SamuhaID.ToString();
            this.ddlSamuha_Rqd_SelectedIndexChanged(sender, e);
            this.ddlUpaSamuha_Rqd.Text = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].UpaSamuhaID.ToString();
            this.ddlDesignationLevel_Rqd.SelectedValue = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].DesgLevelID.ToString();
            this.txtCreatedDate_DT.Text = OrgDesignationList[this.grdOrgDesignation.SelectedIndex].CreatedDate.ToString();
            this.btnCreatePost.Text = "Update Post";
            this.grdOrgDesignation.SelectedRow.Focus();

            this.grdDesPost.DataSource = "";
            this.grdDesPost.DataBind();
            List<ATTPost> PostList = BLLPost.GetOrgDesgPost(int.Parse(this.ddlOrganization_Rqd.SelectedValue.ToString()), int.Parse(this.ddlDesignation_Rqd.SelectedValue.ToString()),this.txtCreatedDate_DT.Text.Trim());
            Session["PostTbl"] = PostList;
            this.grdDesPost.DataSource = PostList;
            this.grdDesPost.DataBind();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    void ClearControls()
    {
        this.ddlDesignation_Rqd.Enabled = true;
        this.ddlOrganization_Rqd.Enabled = true;
        this.ddlDesignation_Rqd.SelectedIndex = 0;
        this.txtTotalSeats_Rqd.Text = "";
        this.grdOrgDesignation.SelectedIndex = -1;
        this.btnCreatePost.Text = "Create Post";
        this.grdDesPost.DataSource = "";
        this.grdDesPost.DataBind();
        this.SetPostsTable();
        this.ddlOrganization_Rqd.Focus();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<ATTOrganizationDesignation> OrgDesignationList = (List<ATTOrganizationDesignation>)Session["OrganizationDesignation"];
        ATTOrganizationDesignation objOrgDesignation = new ATTOrganizationDesignation();
        ATTPost objPost = new ATTPost();
        int intDesignationID = 0;
        int intOrganizationID = 0;
        int intTotalSeats = 0;
        int intSewaID = 0;
        int intSamuhaID = 0;
        int intUpaSamuhaID = 0;
        int intDesgLevelID = 0;
        string strUser = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;

        if (this.ddlDesignation_Rqd.SelectedIndex > 0) intDesignationID = int.Parse(this.ddlDesignation_Rqd.SelectedValue.ToString());
        if (this.ddlOrganization_Rqd.SelectedIndex > 0) intOrganizationID = int.Parse(this.ddlOrganization_Rqd.SelectedValue.ToString());
        if (this.ddlSewa_Rqd.SelectedIndex > 0) intSewaID = int.Parse(this.ddlSewa_Rqd.SelectedValue.ToString());
        if (this.ddlSamuha_Rqd.SelectedIndex > 0) intSamuhaID = int.Parse(this.ddlSamuha_Rqd.SelectedValue.ToString());
        if (this.ddlUpaSamuha_Rqd.SelectedIndex > 0) intUpaSamuhaID = int.Parse(this.ddlUpaSamuha_Rqd.SelectedValue.ToString());
        if (this.ddlDesignationLevel_Rqd.SelectedIndex > 0) intDesgLevelID = int.Parse(this.ddlDesignationLevel_Rqd.SelectedValue.ToString());

        foreach (GridViewRow row in this.grdDesPost.Rows)
        {
            CheckBox chkDelete = (CheckBox)(row.Cells[8].FindControl("chkPostSelect"));
            if (!chkDelete.Checked)
                intTotalSeats += 1;
        }

        if (this.grdDesPost.Rows.Count == 0)
        {
            this.lblStatusMessage.Text = "Enter The Total Quantity And Click Create Post (or) Update Post.";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            objOrgDesignation = new ATTOrganizationDesignation(intOrganizationID, intDesignationID, intTotalSeats, intSewaID, intSamuhaID, intUpaSamuhaID, intDesgLevelID);
            ObjectValidation OV = BLLOrganizationDesignation.Validate(objOrgDesignation);
            if (!OV.IsValid)
            {
                this.lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }
            if (this.txtCreatedDate_DT.Text.Trim() != "")
                objOrgDesignation.CreatedDate = this.txtCreatedDate_DT.Text.Trim(); //"2066.10.09";
            objOrgDesignation.EntryBy = strUser;
            if (this.grdOrgDesignation.SelectedIndex == -1) objOrgDesignation.Action = "A";
            else objOrgDesignation.Action = "E";


            foreach (GridViewRow row in this.grdDesPost.Rows)
            {
                string strPostName = "";
                string strOldPostName = "";

                CheckBox cb = (CheckBox)(row.Cells[8].FindControl("chkPostSelect"));
                TextBox txtboxPostName = (TextBox)(row.Cells[5].FindControl("txtPostName"));
                TextBox txtboxOldPostName = (TextBox)(row.Cells[6].FindControl("txtOldPostName"));
                strPostName = txtboxPostName.Text.Trim();
                strOldPostName = txtboxOldPostName.Text.Trim();
                objPost = new ATTPost(int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()),row.Cells[8].Text.ToString(), int.Parse(row.Cells[2].Text.ToString()), strPostName, row.Cells[7].Text.ToString().Trim());
                objPost.EntryBy = strUser;
                objPost.Action = "";
                if (row.Cells[2].Text.ToString().Trim() == "0" && !cb.Checked)
                    objPost.Action = "A";
                if (row.Cells[2].Text.ToString().Trim() != "0")
                {
                    if (cb.Checked)
                        objPost.Action = "D";
                    else if ((strPostName != strOldPostName) && !cb.Checked)
                        objPost.Action = "E";
                }

                if (objPost.Action != "")
                {
                    ObjectValidation OValidate = BLLPost.Validate(objPost);
                    if (!OValidate.IsValid)
                    {
                        this.lblStatusMessage.Text = OValidate.ErrorMessage;
                        this.programmaticModalPopup.Show();
                        return;
                    }
                    objOrgDesignation.LstPosts.Add(objPost);
                }
            }


            //if (this.ddlParentOrganization.SelectedIndex > 0)
            //    objOrgDesignation.ParentOrg = int.Parse(this.ddlParentOrganization.SelectedValue.ToString());
            //if (this.ddlParentDesignation.SelectedIndex > 0)
            //    objOrgDesignation.ParentDes = int.Parse(this.ddlParentDesignation.SelectedValue.ToString());
            objOrgDesignation.OrgName = this.ddlOrganization_Rqd.SelectedItem.Text;
            objOrgDesignation.DesName = this.ddlDesignation_Rqd.SelectedItem.Text;
            objOrgDesignation.SewaName = this.ddlSewa_Rqd.SelectedItem.Text;
            objOrgDesignation.SamuhaName = this.ddlSamuha_Rqd.SelectedItem.Text;
            objOrgDesignation.UpaSamuhaName = this.ddlUpaSamuha_Rqd.SelectedItem.Text;
            objOrgDesignation.DesgLevelName = this.ddlDesignationLevel_Rqd.SelectedItem.Text;

            if (BLLOrganizationDesignation.SaveOrganizationDesignation(objOrgDesignation))
            {
                if (this.grdOrgDesignation.SelectedIndex > -1)
                {
                    OrgDesignationList[this.grdOrgDesignation.SelectedIndex].OrgID = int.Parse(this.ddlOrganization_Rqd.SelectedValue.ToString());
                    OrgDesignationList[this.grdOrgDesignation.SelectedIndex].DesID = int.Parse(this.ddlDesignation_Rqd.SelectedValue.ToString());
                    OrgDesignationList[this.grdOrgDesignation.SelectedIndex].OrgName = this.ddlOrganization_Rqd.SelectedItem.Text.ToString();
                    OrgDesignationList[this.grdOrgDesignation.SelectedIndex].DesName = this.ddlDesignation_Rqd.SelectedItem.Text.ToString();
                    OrgDesignationList[this.grdOrgDesignation.SelectedIndex].TotalSeats = objOrgDesignation.TotalSeats;
                }
                else
                    OrgDesignationList.Add(objOrgDesignation);
                this.grdOrgDesignation.DataSource = OrgDesignationList;
                this.grdOrgDesignation.DataBind();
                ClearControls();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

   protected void btnCreatePost_Click(object sender, EventArgs e)
    {
        if (this.ddlOrganization_Rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Select Organization.";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.ddlDesignation_Rqd.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "Select Designation.";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.txtTotalSeats_Rqd.Text=="")
        {
            this.lblStatusMessage.Text = "Enter Total Quantity.";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            if (this.grdOrgDesignation.SelectedIndex == -1)
            {
                List<ATTPost> NewDesPost = new List<ATTPost>();
                for (int i = 1; i <= int.Parse(this.txtTotalSeats_Rqd.Text); i++)
                {
                    ATTPost post = new ATTPost();
                    post.OrgID = int.Parse(this.ddlOrganization_Rqd.SelectedValue.ToString());
                    post.DesID = int.Parse(this.ddlDesignation_Rqd.SelectedValue.ToString());
                    post.PostID = 0;
                    post.OrgName = this.ddlOrganization_Rqd.SelectedItem.Text;
                    post.DesName = this.ddlDesignation_Rqd.SelectedItem.Text;
                    post.PostName = this.ddlDesignation_Rqd.SelectedItem.Text;
                    post.Occupied = "NO";
                    post.CreatedDate = this.txtCreatedDate_DT.Text.Trim();
                    NewDesPost.Add(post);
                }
                this.grdDesPost.DataSource = NewDesPost;
                this.grdDesPost.DataBind();
            }

            else
            {
                List<ATTPost> PostList = (List<ATTPost>)Session["PostTbl"];
                if (int.Parse(this.txtTotalSeats_Rqd.Text.ToString()) < this.grdDesPost.Rows.Count)
                {
                    this.lblStatusMessage.Text = "Total Quantity Should Be Less Than (or) Equal To Previous Quantity.";
                    this.programmaticModalPopup.Show();
                    return;
                }
                for (int i = 1; i <= int.Parse(this.txtTotalSeats_Rqd.Text)-this.grdDesPost.Rows.Count; i++)
                {
                    ATTPost post = new ATTPost();
                    post.OrgID = int.Parse(this.ddlOrganization_Rqd.SelectedValue.ToString());
                    post.DesID = int.Parse(this.ddlDesignation_Rqd.SelectedValue.ToString());
                    post.OrgName = this.ddlOrganization_Rqd.SelectedItem.Text;
                    post.DesName = this.ddlDesignation_Rqd.SelectedItem.Text;
                    post.PostName = this.ddlDesignation_Rqd.SelectedItem.Text;
                    post.Occupied = "NO";
                    post.CreatedDate = this.txtCreatedDate_DT.Text.Trim(); 
                    PostList.Add(post);
                }
                this.grdDesPost.DataSource = PostList;
                this.grdDesPost.DataBind();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void SetPostsTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtcol0 = new DataColumn("ORGID");
        DataColumn dtcol1 = new DataColumn("DESID");
        DataColumn dtcol2 = new DataColumn("POSTID");
        DataColumn dtcol3 = new DataColumn("ORGNAME");
        DataColumn dtcol4 = new DataColumn("DESNAME");
        DataColumn dtcol5 = new DataColumn("txtPostName");
        DataColumn dtcol6 = new DataColumn("txtOldPostName");
        DataColumn dtcol7 = new DataColumn("OCCUPIED");
        DataColumn dtcol8 = new DataColumn("CREATEDDATE");
        DataColumn dtcol9 = new DataColumn("chkPostSelect");

        tbl.Columns.Add(dtcol0);
        tbl.Columns.Add(dtcol1);
        tbl.Columns.Add(dtcol2);
        tbl.Columns.Add(dtcol3);
        tbl.Columns.Add(dtcol4);
        tbl.Columns.Add(dtcol5);
        tbl.Columns.Add(dtcol6);
        tbl.Columns.Add(dtcol7);
        tbl.Columns.Add(dtcol8);
        tbl.Columns.Add(dtcol9);

        Session["PostTbl"] = tbl;
    }

    protected void grdDesPost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
    }

    protected void ddlSewa_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlUpaSamuha_Rqd.DataSource = "";
        this.ddlUpaSamuha_Rqd.Items.Clear();
        this.ddlUpaSamuha_Rqd.DataBind();
        this.ddlSamuha_Rqd.DataSource = "";
        this.ddlSamuha_Rqd.Items.Clear();
        if (this.ddlSewa_Rqd.SelectedIndex > 0)
        {
            List<ATTSewa> SewaList = (List<ATTSewa>)Session["SewaList"];
            this.ddlSamuha_Rqd.DataSource = SewaList[this.ddlSewa_Rqd.SelectedIndex].LstSamuha;
            this.ddlSamuha_Rqd.DataTextField = "SAMUHANAME";
            this.ddlSamuha_Rqd.DataValueField = "SAMUHAID";
            this.ddlSamuha_Rqd.Items.Add(new ListItem("छान्नुहोस", "0"));
        }
        this.ddlSamuha_Rqd.DataBind();
    }

    protected void ddlSamuha_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlUpaSamuha_Rqd.DataSource = "";
        this.ddlUpaSamuha_Rqd.Items.Clear();
        if (this.ddlSamuha_Rqd.SelectedIndex > 0)
        {
            List<ATTSewa> SewaList = (List<ATTSewa>)Session["SewaList"];
            this.ddlUpaSamuha_Rqd.DataSource = SewaList[this.ddlSewa_Rqd.SelectedIndex].LstSamuha[this.ddlSamuha_Rqd.SelectedIndex-1].LstUpaSamuha;
            this.ddlUpaSamuha_Rqd.DataTextField = "UPASAMUHANAME";
            this.ddlUpaSamuha_Rqd.DataValueField = "UPASAMUHAID";
            this.ddlUpaSamuha_Rqd.Items.Add(new ListItem("छान्नुहोस", "0"));
        }
        this.ddlUpaSamuha_Rqd.DataBind();

    }
}
