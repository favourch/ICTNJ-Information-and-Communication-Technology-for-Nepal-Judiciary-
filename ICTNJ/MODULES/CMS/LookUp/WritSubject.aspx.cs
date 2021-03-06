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

using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;

using PCS.FRAMEWORK;

public partial class MODULES_CMS_LookUp_WritSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("1,18,1") == true)
        {
            if (this.Page.IsPostBack == false)
            {
                this.chkWritActive.Checked = true;
                this.chkWritSubCatActive.Checked = true;
                this.chkWritSubCatSubTitleActive.Checked = true;
                this.chkWritSubCatTitleActive.Checked = true;
                createTempObj();
                //Session["TempWritSubject"] = new ATTWritSubject();
                LoadWritSubjectDetails();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadWritSubjectDetails()
    {
        try
        {
            List<ATTWritSubject> WritSubjectLST = BLLWritSubject.GetWritSubjectDetailsLST(null, null, false,false,false,false);
            lstWritSubject.DataSource = WritSubjectLST;
            lstWritSubject.DataValueField = "WritSubjectID";
            lstWritSubject.DataTextField = "WritSubjectName";
            lstWritSubject.DataBind();

            Session["WritSubject"] = WritSubjectLST;
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "लोड रिट विषय";
            this.lblStatusMessage.Text = "रिट विषय लोड गर्न सकेन<BR>"+ex.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        List<ATTWritSubject> WritSubjectLST = (List<ATTWritSubject>)Session["WritSubject"];

        
        int i = -1;
        if (this.lstWritSubject.SelectedIndex > -1)
        {
            i = WritSubjectLST.FindIndex(delegate(ATTWritSubject obj)
                                                                    {
                                                                        return this.txtWritSubject_RQD.Text.ToUpper() == obj.WritSubjectName.ToUpper() && this.lstWritSubject.SelectedItem.Text.ToUpper() != this.txtWritSubject_RQD.Text.ToUpper();
                                                                    });
        }
        else
        {
            i = WritSubjectLST.FindIndex(delegate(ATTWritSubject obj)
                                                                               {
                                                                                   return this.txtWritSubject_RQD.Text.ToUpper() == obj.WritSubjectName.ToUpper();
                                                                               });
        }
        if (i > -1)
        {
            this.lblStatusMessage.Text = "Writ Subject Name Already Exists";
            this.programmaticModalPopup.Show();
            return;
        }
        

        ATTWritSubject objWritSubject = (ATTWritSubject)Session["TempWritSubject"];

        try
        {
            objWritSubject.WritSubjectName = this.txtWritSubject_RQD.Text;
            objWritSubject.Active = (chkWritActive.Checked == true) ? "Y" : "N";
            objWritSubject.EntryBy = user.UserName;
            objWritSubject.Action = (lstWritSubject.SelectedIndex == -1) ? "A" : "E";

            if (BLLWritSubject.SaveWritSubject(objWritSubject) == true)
            {
                if (lstWritSubject.SelectedIndex > -1)
                    WritSubjectLST.RemoveAt(this.lstWritSubject.SelectedIndex);

                WritSubjectLST.Add(objWritSubject);
            }

            lstWritSubject.DataSource = WritSubjectLST;
            lstWritSubject.DataValueField = "WritSubjectID";
            lstWritSubject.DataTextField = "WritSubjectName";
            lstWritSubject.DataBind();

            createTempObj();
            this.clearAll(1);
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Save Status";
            this.lblStatusMessage.Text = "Writ Subject Details Can't be Saved<BR><BR>" + ex.Message;
            this.programmaticModalPopup.Show();
        }


    }
    protected void btnAddWritSubjectCategory_Click(object sender, EventArgs e)
    {
        if (this.txtWritSubject_RQD.Text == "")
        {
            this.lblStatus.Text = "Add Writ Category Status";
            this.lblStatusMessage.Text = "Writ Subject Can't Be Blank";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.txtWritSubjectCategory.Text == "")
        {
            this.lblStatus.Text = "Add Writ Category Status";
            this.lblStatusMessage.Text = "Writ Category Can't Be Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        ATTWritSubject WritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"];
        List<ATTWritCategory> WritSubCatLST =WritSubjectOBJ.WritCategoryLST;

        try
        {
            if (grdWritCategory.SelectedIndex == -1)
            {
                ATTWritCategory objEWritCat = new ATTWritCategory();
                objEWritCat.WritSubjectID = 0;
                objEWritCat.WritSubjectCatID = 0;
                objEWritCat.WritSubjectCatName = this.txtWritSubjectCategory.Text;
                objEWritCat.Active = (chkWritSubCatActive.Checked == true) ? "Y" : "N";
                objEWritCat.Action = "A";
                objEWritCat.EntryBy = user.UserName;

                WritSubCatLST.Add(objEWritCat);
            }
            else
            {
                WritSubCatLST[grdWritCategory.SelectedIndex].WritSubjectID = int.Parse(this.grdWritCategory.SelectedRow.Cells[0].Text);
                WritSubCatLST[grdWritCategory.SelectedIndex].WritSubjectCatID = int.Parse(this.grdWritCategory.SelectedRow.Cells[1].Text);
                WritSubCatLST[grdWritCategory.SelectedIndex].WritSubjectCatName = this.txtWritSubjectCategory.Text;
                WritSubCatLST[grdWritCategory.SelectedIndex].Active = (chkWritSubCatActive.Checked == true) ? "Y" : "N"; ;
                WritSubCatLST[grdWritCategory.SelectedIndex].Action = (this.grdWritCategory.SelectedRow.Cells[4].Text == "A") ? "A" : "E";
                WritSubCatLST[grdWritCategory.SelectedIndex].EntryBy =user.UserName;

            }


            grdWritCategory.DataSource = WritSubCatLST;
            grdWritCategory.DataBind();

            this.grdWritCategory.SelectedIndex = -1;

            this.grdWritSubCatTitle.SelectedIndex = -1;
            this.grdWritSubCatTitle.DataSource = "";
            this.grdWritSubCatTitle.DataBind();

            this.grdWritSubCatSubTitle.SelectedIndex = -1;
            this.grdWritSubCatSubTitle.DataSource = "";
            this.grdWritSubCatSubTitle.DataBind();

            this.txtWritSubjectCategory.Text = "";
            this.chkWritSubCatActive.Checked = true;
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Add Writ Subject Category";
            this.lblStatus.Text = "Writ Subject Category Can't be Added To Grid<BR>" + ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdWritCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckNull.NullString(this.grdWritCategory.SelectedRow.Cells[4].Text) == "")
            this.grdWritCategory.SelectedRow.Cells[4].Text = "E";
        this.txtWritSubjectCategory.Text = this.grdWritCategory.SelectedRow.Cells[2].Text;
        this.chkWritSubCatActive.Checked = (this.grdWritCategory.SelectedRow.Cells[3].Text == "Y") ? true : false;

        
        ATTWritSubject WritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"];
        List<ATTWritCategory> WritSubCatLST =WritSubjectOBJ.WritCategoryLST;

        this.grdWritSubCatTitle.DataSource = WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST;
        this.grdWritSubCatTitle.DataBind();

        this.grdWritSubCatTitle.SelectedIndex = -1;

        this.grdWritSubCatSubTitle.DataSource = "";
        this.grdWritSubCatSubTitle.DataBind();



    }
    protected void btnAddWritSubCatTitle_Click(object sender, EventArgs e)
    {
        if (this.txtWritSubCatTitle.Text == "")
        {
            this.lblStatus.Text = "Add Writ Subject Category Title Status";
            this.lblStatusMessage.Text = "Writ Subject Category Title Can't Be Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.grdWritCategory.SelectedIndex == -1)
        {
            this.lblStatus.Text = "Add Writ Subject Category Title Status";
            this.lblStatusMessage.Text = "Please Select Writ Subject Category";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);


        ATTWritSubject WritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"];
        List<ATTWritCategory> WritSubCatLST = WritSubjectOBJ.WritCategoryLST;

        List<ATTWritCategoryTitle> WritSubCatTitleLST = WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST;

        try
        {
            if (grdWritSubCatTitle.SelectedIndex == -1)
            {
                ATTWritCategoryTitle objEWritSubCatTitle = new ATTWritCategoryTitle();
                objEWritSubCatTitle.WritSubjectID = 0;
                objEWritSubCatTitle.WritSubjectCatID = 0;
                objEWritSubCatTitle.WritSubjectCatTitleID = 0;
                objEWritSubCatTitle.WritSubjectCatTitleName = this.txtWritSubCatTitle.Text;
                objEWritSubCatTitle.Active = (chkWritSubCatTitleActive.Checked == true) ? "Y" : "N";
                objEWritSubCatTitle.Action = "A";
                objEWritSubCatTitle.EntryBy = user.UserName;

                WritSubCatTitleLST.Add(objEWritSubCatTitle);
            }
            else
            {
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].WritSubjectID = int.Parse(this.grdWritSubCatTitle.SelectedRow.Cells[0].Text);
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].WritSubjectCatID = int.Parse(this.grdWritSubCatTitle.SelectedRow.Cells[1].Text);
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].WritSubjectCatTitleID = int.Parse(this.grdWritSubCatTitle.SelectedRow.Cells[2].Text);
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].WritSubjectCatTitleName = this.txtWritSubCatTitle.Text;
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].Active = (chkWritSubCatTitleActive.Checked == true) ? "Y" : "N"; ;
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].Action = (this.grdWritSubCatTitle.SelectedRow.Cells[5].Text == "A") ? "A" : "E";
                WritSubCatTitleLST[grdWritSubCatTitle.SelectedIndex].EntryBy = user.UserName;
            }


            grdWritSubCatTitle.DataSource = WritSubCatTitleLST;
            grdWritSubCatTitle.DataBind();

            WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST = WritSubCatTitleLST;
            this.grdWritSubCatSubTitle.DataSource = "";
            this.grdWritSubCatSubTitle.DataBind();
            this.grdWritSubCatTitle.SelectedIndex = -1;

            this.txtWritSubCatTitle.Text = "";
            this.chkWritSubCatTitleActive.Checked = true;
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Add Writ Category Title Status";
            this.lblStatusMessage.Text = "Writ Subject Category Can't Be Added To Grid<BR>" + ex.ToString();
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnAddWritSubCatSubTitle_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

        if (this.grdWritSubCatTitle.SelectedIndex == -1)
        {
            this.lblStatus.Text = "Add Writ Subject Category Sub Title Status";
            this.lblStatusMessage.Text = "Please Select Writ Subject Category Sub Title";
            this.programmaticModalPopup.Show();
            return;
        }


        
        ATTWritSubject WritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"];
        List<ATTWritCategory> WritSubCatLST = WritSubjectOBJ.WritCategoryLST;
        List<ATTWritCategoryTitle> WritSubCatTitleLST = WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST;
        List<ATTWritCategorySubTitle> WritSubCatSubTitleLST = WritSubCatTitleLST[this.grdWritSubCatTitle.SelectedIndex].WritCategorySubTitleLST;

        try
        {
            if (grdWritSubCatSubTitle.SelectedIndex == -1)
            {
                ATTWritCategorySubTitle objEWritSubCatSubTitle = new ATTWritCategorySubTitle();
                objEWritSubCatSubTitle.WritSubjectID = 0;
                objEWritSubCatSubTitle.WritSubjectCatID = 0;
                objEWritSubCatSubTitle.WritSubjectCatTitleID = 0;
                objEWritSubCatSubTitle.WritSubjectCatSubTitleID = 0;
                objEWritSubCatSubTitle.WritSubjectCatSubTitleName = this.txtWritSubCatSubTitle.Text;
                objEWritSubCatSubTitle.Active = (chkWritSubCatSubTitleActive.Checked == true) ? "Y" : "N";
                objEWritSubCatSubTitle.Action = "A";
                objEWritSubCatSubTitle.EntryBy = user.UserName;

                WritSubCatSubTitleLST.Add(objEWritSubCatSubTitle);
            }
            else
            {
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].WritSubjectID = int.Parse(this.grdWritSubCatSubTitle.SelectedRow.Cells[0].Text);
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].WritSubjectCatID = int.Parse(this.grdWritSubCatSubTitle.SelectedRow.Cells[1].Text);
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].WritSubjectCatTitleID = int.Parse(this.grdWritSubCatSubTitle.SelectedRow.Cells[2].Text);
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].WritSubjectCatSubTitleID = int.Parse(this.grdWritSubCatSubTitle.SelectedRow.Cells[3].Text);
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].WritSubjectCatSubTitleName = this.txtWritSubCatSubTitle.Text;
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].Active = (chkWritSubCatSubTitleActive.Checked == true) ? "Y" : "N"; ;
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].Action = (this.grdWritSubCatSubTitle.SelectedRow.Cells[6].Text == "A") ? "A" : "E";
                WritSubCatSubTitleLST[grdWritSubCatSubTitle.SelectedIndex].EntryBy = user.UserName;
            }


            grdWritSubCatSubTitle.DataSource = WritSubCatSubTitleLST;
            grdWritSubCatSubTitle.DataBind();

            WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST[this.grdWritSubCatTitle.SelectedIndex].WritCategorySubTitleLST = WritSubCatSubTitleLST;
            this.grdWritSubCatSubTitle.SelectedIndex = -1;
            this.txtWritSubCatSubTitle.Text = "";
            this.chkWritSubCatSubTitleActive.Checked = true;
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = "Add Writ Category Sub Title Status";
            this.lblStatusMessage.Text = "Writ Subject Category Sub Title can't Be Added To Grid";
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdWritSubCatTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckNull.NullString(this.grdWritSubCatTitle.SelectedRow.Cells[5].Text) == "")
            this.grdWritSubCatTitle.SelectedRow.Cells[5].Text = "E";
        this.txtWritSubCatTitle.Text = this.grdWritSubCatTitle.SelectedRow.Cells[3].Text;
        this.chkWritSubCatTitleActive.Checked = (this.grdWritSubCatTitle.SelectedRow.Cells[4].Text == "Y") ? true : false;

        ATTWritSubject WritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"];
        List<ATTWritCategory> WritSubCatLST = WritSubjectOBJ.WritCategoryLST;


        this.grdWritSubCatSubTitle.DataSource = WritSubCatLST[this.grdWritCategory.SelectedIndex].WritCategoryTitleLST[this.grdWritSubCatTitle.SelectedIndex].WritCategorySubTitleLST;
        this.grdWritSubCatSubTitle.DataBind();

    }
    protected void grdWritSubCatSubTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckNull.NullString( this.grdWritSubCatSubTitle.SelectedRow.Cells[6].Text)=="")
            this.grdWritSubCatSubTitle.SelectedRow.Cells[6].Text = "E";
        this.txtWritSubCatSubTitle.Text = this.grdWritSubCatSubTitle.SelectedRow.Cells[4].Text;
        this.chkWritSubCatSubTitleActive.Checked = (this.grdWritSubCatSubTitle.SelectedRow.Cells[5].Text == "Y") ? true : false;

    }

    protected void lstWritSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearAll(0);

        List<ATTWritSubject> writSubjectLST = (List<ATTWritSubject>)Session["WritSubject"];
        createTempObj();

         Session["TempWritSubject"]= (ATTWritSubject)writSubjectLST[this.lstWritSubject.SelectedIndex].Clone();
         ATTWritSubject TempWritSubjectOBJ = (ATTWritSubject)Session["TempWritSubject"] ;
        this.txtWritSubject_RQD.Text = TempWritSubjectOBJ.WritSubjectName;
        this.chkWritActive.Checked = (TempWritSubjectOBJ.Active == "Y") ? true : false;

        this.grdWritCategory.DataSource = TempWritSubjectOBJ.WritCategoryLST;
        this.grdWritCategory.DataBind();
        this.grdWritCategory.SelectedIndex = -1;


 
    }

    private void createTempObj()
    {
        Session["TempWritSubject"] = new ATTWritSubject();
 
    }

    void clearAll(int clearListSelection)
    {
        this.txtWritSubject_RQD.Text = "";
        this.chkWritActive.Checked = true;

        this.txtWritSubjectCategory.Text = "";
        this.chkWritSubCatActive.Checked = true;
        this.grdWritCategory.DataSource = "";
        this.grdWritCategory.DataBind();
        this.grdWritCategory.SelectedIndex = -1;

        this.txtWritSubCatTitle.Text = "";
        this.chkWritSubCatTitleActive.Checked = true;
        this.grdWritSubCatTitle.DataSource = "";
        this.grdWritSubCatTitle.DataBind();
        this.grdWritSubCatTitle.SelectedIndex = -1;

        this.txtWritSubCatSubTitle.Text = "";
        this.chkWritSubCatSubTitleActive.Checked = true;
        this.grdWritSubCatSubTitle.DataSource = "";
        this.grdWritSubCatSubTitle.DataBind();
        this.grdWritSubCatSubTitle.SelectedIndex = -1;

        createTempObj();

        if (clearListSelection == 1)
            this.lstWritSubject.SelectedIndex = -1;
        
    }
    protected void grdWritCategory_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void grdWritSubCatTitle_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[5].Visible = false;
    }
    protected void grdWritSubCatSubTitle_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[6].Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll(1);
    }
}
