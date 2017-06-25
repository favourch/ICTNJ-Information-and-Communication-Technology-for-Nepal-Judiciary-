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

using PCS.FRAMEWORK;
using PCS.DLPDS.ATT;
using PCS.DLPDS.BLL;

using PCS.SECURITY.ATT;

public partial class MODULES_DLPDS_LookUp_Post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        ////block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;

        if (user.MenuList.ContainsKey("Post") == true )
        {
            if (Page.IsPostBack == false)
            {
                GetPost();
                SetPostTable();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

        

        
    }
    void GetPost()
    {
        try
        {
            List<ATTPost> PostList = BLLPost.GetPost(null);

            Session["Post"] = PostList;

            lstPost.DataSource = PostList;
            lstPost.DataTextField = "PostName";
            lstPost.DataValueField = "PostID";
            lstPost.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnAddPostLevel_Click(object sender, EventArgs e)
    {
        
        if (txtPostLevelName.Text == "")
        {
            this.lblStatusMessage.Text ="Enter Post level Name";
            this.programmaticModalPopup.Show();
            return;
        }

        if (txtPostName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Either select Post or Enter new one";
            this.programmaticModalPopup.Show();
            return;
        }
        
        try
        {
            DataTable tmpTbl = (DataTable)Session["PostTbl"];


            for (int i = 0; i < tmpTbl.Rows.Count; i++)
            {
                if (grdPostLevel.SelectedIndex != i)
                {
                    if (tmpTbl.Rows[i]["PostLevelName"].ToString().Trim().ToLower() == txtPostLevelName.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Post Level Already Exists";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }
            if (grdPostLevel.SelectedIndex == -1)
            {
                DataRow row = tmpTbl.NewRow();
                row[0] = 0;
                row[1] = 0;
                row[2] = txtPostLevelName.Text.Trim();
                row[3] = "A";
                tmpTbl.Rows.Add(row);

            }
            else
            {
                DataRow erow = tmpTbl.Rows[this.grdPostLevel.SelectedIndex];
                erow[0] = erow[0].ToString();
                erow[1] = erow[1].ToString();
                erow[2] = txtPostLevelName.Text.Trim();
                if (erow[3].ToString() == "A")
                    erow[3] = "A";
                else
                    erow[3] = "E";

            }

            grdPostLevel.DataSource = tmpTbl;
            grdPostLevel.DataBind();

            for (int i = 0; i < grdPostLevel.Rows.Count; i++)
            {
                if (grdPostLevel.Rows[i].Cells[3].Text == "D")
                    ((LinkButton)grdPostLevel.Rows[i].Cells[5].Controls[0]).Text = "Undo";
                else
                    ((LinkButton)grdPostLevel.Rows[i].Cells[5].Controls[0]).Text = "Delete";                
            }

            grdPostLevel.SelectedIndex = -1;
            txtPostLevelName.Text = "";

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
            
        }

    }

    void SetPostTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("PostID");
        DataColumn dtCol1 = new DataColumn("PostLevelID");
        DataColumn dtCol2 = new DataColumn("PostLevelName");
        DataColumn dtCol3 = new DataColumn("Flag");

        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);

        Session["PostTbl"] = tbl;
    }

    void ClearControls()
    {
        txtPostName_Rqd.Text = "";
        txtPostLevelName.Text = "";
        grdPostLevel.SelectedIndex = -1;
        lstPost.SelectedIndex = -1;
        grdPostLevel.DataSource = null;
        grdPostLevel.DataBind();
        SetPostTable();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTPost> PostList = (List<ATTPost>)Session["Post"];

        int PostID;

        if (lstPost.SelectedIndex == -1)
            PostID = 0;
        else
            PostID = int.Parse(lstPost.SelectedValue.ToString());
        try
        {

            ATTPost ObjAtt = new ATTPost(PostID, txtPostName_Rqd.Text.Trim());

            foreach (GridViewRow row in grdPostLevel.Rows)
            {
                if (row.Cells[3].Text.Trim() != "&nbsp;")
                {
                    ATTPostLevel attPL = new ATTPostLevel(int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()), row.Cells[2].Text.Trim(), row.Cells[3].Text.Trim());
                    ObjAtt.LstPostLevel.Add(attPL);
                }
            }

            ObjectValidation OV = BLLPost.Validate(ObjAtt);

            if (OV.IsValid == false)
            {
                lblStatusMessage.Text = OV.ErrorMessage;
                this.programmaticModalPopup.Show();
                return;
            }


            for (int i = 0; i < lstPost.Items.Count; i++)
            {
                if (lstPost.SelectedIndex != i)
                {
                    if (PostList[i].PostName.ToLower() == txtPostName_Rqd.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Post Name Already Exists";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }

            BLLPost.SavePost(ObjAtt);

            if (lstPost.SelectedIndex > -1)
            {
                PostList[lstPost.SelectedIndex].PostID = ObjAtt.PostID;
                PostList[lstPost.SelectedIndex].PostName = ObjAtt.PostName;
                PostList[lstPost.SelectedIndex].LstPostLevel.Clear();

                foreach (GridViewRow row in grdPostLevel.Rows)
                {
                    if (row.Cells[3].Text.Trim() != "D")
                    {
                        ATTPostLevel attPL = new ATTPostLevel(int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()), row.Cells[2].Text,"");
                        PostList[lstPost.SelectedIndex].LstPostLevel.Add(attPL);
                    }
                }
            }
            else
            {
                PostList.Add(ObjAtt);
            }

            lstPost.DataSource = PostList;
            lstPost.DataTextField = "PostName";
            lstPost.DataValueField = "PostID";
            lstPost.DataBind();

            ClearControls();
            
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void grdPostLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (grdPostLevel.SelectedRow.Cells[3].Text != "D")
        {
            txtPostLevelName.Text = grdPostLevel.SelectedRow.Cells[2].Text;
        }
        else
        {
            txtPostLevelName.Text = "";
        }
    }
    protected void grdPostLevel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;

        DataTable TmpTbl = (DataTable)Session["PostTbl"];
        //DataRow row = TmpTbl.Rows[i];

        if (grdPostLevel.Rows[i].Cells[3].Text == "A")
            TmpTbl.Rows.RemoveAt(i);
        else if (grdPostLevel.Rows[i].Cells[3].Text == "D")
            TmpTbl.Rows[i][3] = "";
        else
            TmpTbl.Rows[i][3] = "D";

        grdPostLevel.DataSource = TmpTbl;
        grdPostLevel.DataBind();

        for (int j = 0; j < this.grdPostLevel.Rows.Count; j++)
        {

            if (grdPostLevel.Rows[j].Cells[3].Text == "D")
                ((LinkButton)this.grdPostLevel.Rows[j].Cells[5].Controls[0]).Text = "Undo";
            else
                ((LinkButton)this.grdPostLevel.Rows[j].Cells[5].Controls[0]).Text = "Delete";
        }
    }
    protected void lstPost_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTPost> ListPost = (List<ATTPost>)Session["Post"];
        try
        {
            //this.txtPostName_Rqd.Enabled = true;
            txtPostName_Rqd.Text = ListPost[this.lstPost.SelectedIndex].PostName;
            
            this.txtPostLevelName.Text = "";
            grdPostLevel.DataSource = "";


            SetPostTable();

            if (ListPost[this.lstPost.SelectedIndex].LstPostLevel.Count > 0)
            {
                DataTable tmpTbl = (DataTable)Session["PostTbl"];

                foreach (ATTPostLevel lst in ListPost[this.lstPost.SelectedIndex].LstPostLevel)
                {
                    DataRow row = tmpTbl.NewRow();
                    row[0] = lst.PostID.ToString().Trim();
                    row[1] = lst.PostLevelID.ToString().Trim();
                    row[2] = lst.PostLevelName.ToString().Trim();
                    row[3] = "";
                    tmpTbl.Rows.Add(row);
                }

                grdPostLevel.DataSource = tmpTbl;

            }
            grdPostLevel.DataBind();
            grdPostLevel.SelectedIndex = -1;
        }


        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void grdPostLevel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
}
