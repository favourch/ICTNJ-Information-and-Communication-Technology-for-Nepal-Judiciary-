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
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.SECURITY.ATT;

public partial class MODULES_LIS_LookUp_MaterialSearch : System.Web.UI.Page
{
    public bool IsCheckedAuthor;
    public bool IsCheckedKeyword;

    protected void Page_Load(object sender, EventArgs e)
    {

        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("4,9,3") == true)
        {
            if (!IsPostBack)
            {
                this.LoadAuthor();
                this.LoadLanguage();
                this.LoadKeywords();
                this.tblSearchHeader.Visible = false;
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int[] CheckedAuthors = new int[20];
            int[] CheckedKeywords = new int[20];
            int LanguageID;
            LanguageID = int.Parse(drpLanguage.SelectedValue.ToString());

            CheckedAuthors = getCheckedAuthor();
            CheckedKeywords = getCheckedKeyword();

            if ((IsCheckedAuthor)&&(IsCheckedKeyword))
                Session["SearchList"] = BLLLibraryMaterialAuthor.SearchMaterial(LanguageID, CheckedAuthors, CheckedKeywords);
            else if ((IsCheckedAuthor) && (!IsCheckedKeyword))
                Session["SearchList"] = BLLLibraryMaterialAuthor.SearchMaterial(LanguageID, CheckedAuthors, null);
            else if ((!IsCheckedAuthor) && (IsCheckedKeyword))
                Session["SearchList"] = BLLLibraryMaterialAuthor.SearchMaterial(LanguageID, null, CheckedKeywords);
            else
                Session["SearchList"] = BLLLibraryMaterialAuthor.SearchMaterial(LanguageID,null,null);

           
            this.grdSearchResult.DataSource = (List<ATTLibraryMaterialAuthor>)Session["SearchList"];
            this.grdSearchResult.DataBind();
           
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
       
     }

    public void CreateHeading()
    {
        TableRow tr = new TableRow();

        //// Create column 1
        TableCell td1 = new TableCell();
        Label _lblSNo = new Label();
        _lblSNo.Text = "SNO.";
        _lblSNo.Width = 30;
        td1.Controls.Add(_lblSNo);


        //// Create column 2
        TableCell td2 = new TableCell();
        Label _lblCallNo = new Label();
        _lblCallNo.Text = "Call No";
        _lblCallNo.Width = 120;
        td2.Controls.Add(_lblCallNo);

        //// Create column 2
        TableCell td3 = new TableCell();
        Label _lblCategoryName = new Label();
        _lblCategoryName.Text = "Category Name";
        _lblCategoryName.Width = 125;
        td3.Controls.Add(_lblCategoryName);

        //// Create column 3
        TableCell td4 = new TableCell();
        Label _lblCategoryDescription = new Label();
        _lblCategoryDescription.Text = "Category Description";
        _lblCategoryDescription.Width =144;
        td4.Controls.Add(_lblCategoryDescription);

        //// Create column 4
        TableCell td5 = new TableCell();
        Label _lblLanguage = new Label();
        _lblLanguage.Text = "Language";
        _lblLanguage.Width = 85;
        td5.Controls.Add(_lblLanguage);

        //// Create column 5
        TableCell td6 = new TableCell();
        Label _lblPublisherName = new Label();
        _lblPublisherName.Text = "Publisher Name";
        _lblPublisherName.Width = 160;
        td6.Controls.Add(_lblPublisherName);

        //// Create column 6
        TableCell td7 = new TableCell();
        Label _lblCorporateBody = new Label();
        _lblCorporateBody.Text = "Corporate Body";
        _lblCorporateBody.Width = 154;
        td7.Controls.Add(_lblCorporateBody);

        tr.Cells.Add(td1);
        tr.Cells.Add(td2);
        tr.Cells.Add(td3);
        tr.Cells.Add(td4);
        tr.Cells.Add(td5);
        tr.Cells.Add(td6);
        tr.Cells.Add(td7);

        tblSearchHeader.Rows.Add(tr);
    }
    public int[] getCheckedKeyword()
    {
        try
        {
            CheckBox cbKeyword = new CheckBox();
            int[] CheckedKeywords = new int[20];
            int j = 0;

            foreach (GridViewRow gvrow in this.grdKeyword.Rows)
            {
                cbKeyword = (CheckBox)(gvrow.Cells[0].FindControl("chkKeyword"));
                if (cbKeyword.Checked)
                {
                    CheckedKeywords[j] = int.Parse(gvrow.Cells[1].Text.ToString());
                    IsCheckedKeyword = true;
                }
                j++;
            }

            return CheckedKeywords;

        }
        catch (Exception ex)
        {            
            throw(ex);
        }
       
    }

    public int[] getCheckedAuthor()
    {
        try
        {
            CheckBox cbAuthor = new CheckBox();
            int[] CheckedAuthors = new int[20];
            int i = 0;

            foreach (GridViewRow gvrow in this.grdAuthor.Rows)
            {
                cbAuthor = (CheckBox)(gvrow.Cells[0].FindControl("chkAuthor"));
                if (cbAuthor.Checked)
                {
                    CheckedAuthors[i] = int.Parse(gvrow.Cells[1].Text.ToString());
                    IsCheckedAuthor = true;
                }
                i++;
            }

            return CheckedAuthors;

        }
        catch (Exception ex)
        {
            
            throw(ex);
        }
    }

    protected void grdAuthor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
     
    }

    protected void grdKeyword_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
     
    }

    public void LoadAuthor()
    {
        try
        {
            Session["AuthorList"] = BLLAuthor.GetAuthorList(null);

            this.grdAuthor.DataSource = (List<ATTAuthor>)Session["AuthorList"];
            this.grdAuthor.DataBind();

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    public void LoadLanguage()
    {
        try
        {
            Session["LanguageList"] = BLLLanguage.GetLanguage();
            this.drpLanguage.DataSource = (List<ATTLanguage>)Session["LanguageList"];
            this.drpLanguage.DataTextField = "LanguageName";
            this.drpLanguage.DataValueField = "LanguageID";
            this.drpLanguage.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select";
            a.Value = "0";
            drpLanguage.Items.Insert(0, a);
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    public void LoadKeywords()
    {
        try
        {
            Session["KeywordsList"] = BLLKeyword.GetKeywordList(null);

            this.grdKeyword.DataSource = (List<ATTKeyword>)Session["KeywordsList"];
            this.grdKeyword.DataBind();

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void grdSearchResult_DataBound(object sender, EventArgs e)
    {
        if (this.grdSearchResult.Rows.Count<=0)
        {
            if(hfStatusHidden.Value.ToString() == "1")
                this.lblSearchStatus.Text = " Proceed Search ... ";
            else
                this.lblSearchStatus.Text = " No Search datas found... ";

            hfStatusHidden.Value = "0";

            this.tblSearchHeader.Visible = false;
                   
        }
        else if (this.grdSearchResult.Rows.Count > 0)
        {
           
            this.lblSearchStatus.Text = " Search Related datas ... ";
            this.tblSearchHeader.Visible = true;
            CreateHeading();

            
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.grdSearchResult.DataSource = "";
        this.grdSearchResult.DataBind();

        this.tblSearchHeader.Visible = false;

    }
}

