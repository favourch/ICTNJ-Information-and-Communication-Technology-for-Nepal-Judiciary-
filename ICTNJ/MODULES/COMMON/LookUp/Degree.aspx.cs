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
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;

public partial class MODULES_Common_LookUp_Degree : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["PopUpDegree"] != null)
        {
            this.MasterPageFile = "MODULES/COMMON/BlankMasterPage.master";
            this.Title = "Degrees";
            Session["PopUpDegree"] = null;
        }
        else
        {
            if (Session["ApplicationID"].ToString() == "2")
            {
                this.MasterPageFile = "~/MODULES/LJMS/LJMSMasterPage.master";
                this.Title = "LJMS | Degrees";
            }
            else if (Session["ApplicationID"].ToString() == "3")
            {
                this.MasterPageFile = "~/MODULES/PMS/PMSMasterPage.master";
                this.Title = "PMS | Institutions";
            }
        }
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
        if ((user.MenuList.ContainsKey("10,25,1") == true) || (user.MenuList.ContainsKey("3,26,1") == true) || (user.MenuList.ContainsKey("2,9,1")==true))
        {
            if (IsPostBack == false)
            {
                GetDegreeLevel();
                SetDegreeTable();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void GetDegreeLevel()
    {
        try
        {
            List<ATTDegreeLevel> Lst = BLLDegreeLevel.GetDegreeLevel(null,null);
            Session["LstDegreeLevel"] = Lst;

            lstDegreeLevel.DataSource = Lst;
            lstDegreeLevel.DataTextField = "DegreeLevelName";
            lstDegreeLevel.DataValueField = "DegreeLevelID";
            lstDegreeLevel.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        List<ATTDegreeLevel> LstDL = (List<ATTDegreeLevel>)Session["LstDegreeLevel"];
                  
            int DegreeLevelID;
            try
            {
                if (lstDegreeLevel.SelectedIndex == -1)
                    DegreeLevelID = 0;
                else
                    DegreeLevelID = LstDL[lstDegreeLevel.SelectedIndex].DegreeLevelID;

                ATTDegreeLevel ObjAtt = new ATTDegreeLevel(DegreeLevelID, txtDegreeLevelName_Rqd.Text.Trim(), this.chkActiveDL.Checked == true ? "Y" : "N",user.UserName);

                foreach (GridViewRow row in grdDegree.Rows)
                {
                    if (row.Cells[4].Text != "&nbsp;")
                    {
                        ATTDegree LstAtt = new ATTDegree(int.Parse(row.Cells[0].Text.ToString()), int.Parse(row.Cells[1].Text.ToString()), row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text);
                        LstAtt.EntryBy = user.UserName;
                        ObjAtt.LstDegree.Add(LstAtt);
                    }
                }

               

                ObjectValidation OV = BLLDegreeLevel.Validate(ObjAtt);

                if (OV.IsValid == false)
                {
                    lblStatusMessage.Text = OV.ErrorMessage;
                    this.programmaticModalPopup.Show();
                    return;
                }

                for (int i = 0; i < lstDegreeLevel.Items.Count; i++)
                {
                    if (lstDegreeLevel.SelectedIndex != i)
                    {
                        if (LstDL[i].DegreeLevelName.ToLower() == txtDegreeLevelName_Rqd.Text.Trim().ToLower())
                        {
                            this.lblStatusMessage.Text = "Degree Level Name Already Exists";
                            this.programmaticModalPopup.Show();
                            return;
                        }
                    }
                }


                if (BLLDegreeLevel.SaveDegreeLevel(ObjAtt))
                {                   
                    this.lblStatusMessage.Text = "Degree Information Saved";
                    this.programmaticModalPopup.Show();
                }

                if (lstDegreeLevel.SelectedIndex > -1)
                {
                    LstDL[lstDegreeLevel.SelectedIndex].DegreeLevelID = ObjAtt.DegreeLevelID;
                    LstDL[lstDegreeLevel.SelectedIndex].DegreeLevelName = txtDegreeLevelName_Rqd.Text.Trim();
                    LstDL[this.lstDegreeLevel.SelectedIndex].Active = (this.chkActiveDL.Checked == true ? "Y" : "N");
                    LstDL[lstDegreeLevel.SelectedIndex].LstDegree.Clear();


                    foreach (GridViewRow row in grdDegree.Rows)
                    {
                        if (row.Cells[4].Text.Trim() != "D")
                        {
                            ATTDegree att = new ATTDegree(int.Parse(row.Cells[0].Text), int.Parse(row.Cells[1].Text), row.Cells[2].Text, row.Cells[3].Text);
                            LstDL[lstDegreeLevel.SelectedIndex].LstDegree.Add(att);
                        }
                    }

                }
                else
                {

                    LstDL.Add(ObjAtt);
                }

                
                lstDegreeLevel.DataSource = LstDL;
                Session["LstDegreeLevel"] = LstDL;
                lstDegreeLevel.DataTextField = "DegreeLevelName";
                lstDegreeLevel.DataValueField = "DegreeLevelID";
                lstDegreeLevel.DataBind();
                
                ClearControls();
              
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
                return;
            }
    }

    void ClearControls()
    {
        lstDegreeLevel.SelectedIndex = -1;
        this.txtDegreeLevelName_Rqd.Enabled = true;
        
        this.txtDegreeLevelName_Rqd.Text = "";
        this.txtDegreeName.Text = "";
        
        this.chkActiveDL.Checked = false;
        this.chkActiveDegree.Checked = false;
        
        grdDegree.SelectedIndex = -1;
        grdDegree.DataSource = null;
        grdDegree.DataBind();
        
        SetDegreeTable();

        //Session["DegreeTbl"] = null;
    }

    protected void lstDegreeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTDegreeLevel> LstDL = (List<ATTDegreeLevel>)Session["LstDegreeLevel"];
        try
        {
            this.txtDegreeLevelName_Rqd.Enabled = true;
            txtDegreeLevelName_Rqd.Text = LstDL[this.lstDegreeLevel.SelectedIndex].DegreeLevelName;
            if (LstDL[this.lstDegreeLevel.SelectedIndex].Active == "Y")
                chkActiveDL.Checked = true;
            else
                chkActiveDL.Checked = false;

            this.txtDegreeName.Text = "";
            this.chkActiveDegree.Checked = false;
            grdDegree.DataSource = "";


            SetDegreeTable();

            if (LstDL[this.lstDegreeLevel.SelectedIndex].LstDegree.Count > 0)
            {
                DataTable tmpTbl = (DataTable)Session["DegreeTbl"];

                foreach (ATTDegree lst in LstDL[this.lstDegreeLevel.SelectedIndex].LstDegree)
                {
                    DataRow row = tmpTbl.NewRow();
                    row[0] = lst.DegreeID.ToString().Trim();
                    row[1] = lst.DegreeLevelID.ToString().Trim();
                    row[2] = lst.DegreeName.ToString().Trim();
                    row[3] = lst.Active.ToString().Trim();
                    row[4] = "";
                    tmpTbl.Rows.Add(row);
                }

                grdDegree.DataSource = tmpTbl;

            }
            grdDegree.DataBind();
            grdDegree.SelectedIndex = -1;
        }


        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
      
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    
    protected void grdDegree_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
    }

    protected void grdDegree_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int i = e.RowIndex;

        DataTable tmpTbl = (DataTable)Session["DegreeTbl"];
        DataRow row = tmpTbl.Rows[i];
        if (grdDegree.Rows[i].Cells[4].Text == "A")
            tmpTbl.Rows.RemoveAt(i);

        else if (grdDegree.Rows[i].Cells[4].Text == "D")
            tmpTbl.Rows[i][4] = "";
        else
            tmpTbl.Rows[i][4] = "D";

        grdDegree.DataSource = tmpTbl;
        grdDegree.DataBind();

        for (int j = 0; j < this.grdDegree.Rows.Count; j++)
        {

            if (grdDegree.Rows[j].Cells[4].Text == "D")
                ((LinkButton)this.grdDegree.Rows[j].Cells[6].Controls[0]).Text = "Undo";
            else
                ((LinkButton)this.grdDegree.Rows[j].Cells[6].Controls[0]).Text = "Delete";
        }
    }

    protected void grdDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (grdDegree.SelectedRow.Cells[4].Text != "D")
        {

            this.txtDegreeLevelName_Rqd.Enabled = false;
            txtDegreeName.Text = grdDegree.SelectedRow.Cells[2].Text;
            if (grdDegree.SelectedRow.Cells[3].Text == "Y")
                chkActiveDegree.Checked = true;
            else
                chkActiveDegree.Checked = false;
        }

        else
        {
            this.txtDegreeLevelName_Rqd.Enabled = true;
            txtDegreeName.Text = "";
            chkActiveDegree.Checked = false;
        }
    }

    void SetDegreeTable()
    {
        DataTable tbl = new DataTable();
        DataColumn dtCol0 = new DataColumn("DegreeID");
        DataColumn dtCol1 = new DataColumn("DegreeLevelID");
        DataColumn dtCol2 = new DataColumn("DegreeName");
        DataColumn dtCol3 = new DataColumn("Active");
        DataColumn dtCol4 = new DataColumn("Flag");
        DataColumn dtCol5 = new DataColumn("EntryBy");

        tbl.Columns.Add(dtCol0);
        tbl.Columns.Add(dtCol1);
        tbl.Columns.Add(dtCol2);
        tbl.Columns.Add(dtCol3);
        tbl.Columns.Add(dtCol4);
        tbl.Columns.Add(dtCol5);

        Session["DegreeTbl"] = tbl;
    }
    protected void btnAddDegreeName_Click1(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (txtDegreeName.Text == "")
        {
            this.lblStatusMessage.Text = "Enter Degree Name";
            this.programmaticModalPopup.Show();
            return;
        }
        if (txtDegreeLevelName_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "Either Select Degree Level or Enter New One";
            this.programmaticModalPopup.Show();
            return;
        }

        try
        {

            DataTable tmpTbl = (DataTable)Session["DegreeTbl"];

            for (int i = 0; i < tmpTbl.Rows.Count; i++)
            {
                if (grdDegree.SelectedIndex != i)
                {
                    if (tmpTbl.Rows[i]["DegreeName"].ToString().Trim().ToLower() == txtDegreeName.Text.Trim().ToLower())
                    {
                        this.lblStatusMessage.Text = "Degree Name Already Exists";
                        this.programmaticModalPopup.Show();
                        return;
                    }
                }
            }


            if (grdDegree.SelectedIndex == -1)
            {
                DataRow row = tmpTbl.NewRow();
                row[0] = 0;
                row[1] = 0;
                row[2] = txtDegreeName.Text.Trim();
                row[3] = this.chkActiveDegree.Checked == true ? "Y" : "N";
                row[4] = "A";
                row[5] = user.UserName;
                tmpTbl.Rows.Add(row);
            }
            else
            {
                DataRow erow = tmpTbl.Rows[this.grdDegree.SelectedIndex];
                erow[0] = erow[0].ToString();
                erow[1] = erow[1].ToString();
                erow[2] = txtDegreeName.Text.Trim();
                erow[3] = this.chkActiveDegree.Checked == true ? "Y" : "N";
                if (erow[4].ToString() == "A")
                    erow[4] = "A";
                else
                    erow[4] = "E";
                erow[5] = user.UserName;

            }

            grdDegree.DataSource = tmpTbl;
            grdDegree.DataBind();


            for (int i = 0; i < this.grdDegree.Rows.Count; i++)
            {
                if (grdDegree.Rows[i].Cells[4].Text == "D")
                    ((LinkButton)this.grdDegree.Rows[i].Cells[6].Controls[0]).Text = "Undo";
                else
                    ((LinkButton)this.grdDegree.Rows[i].Cells[6].Controls[0]).Text = "Delete";

            }

            grdDegree.SelectedIndex = -1;
            this.txtDegreeName.Text = "";
            this.chkActiveDegree.Checked = false;
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
}
