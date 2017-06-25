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

using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_LIS_Forms_LibraryMaterialEditor : System.Web.UI.Page
{
    internal ATTLibraryMaterial LibraryMaterial
    {
        get { return ((List<ATTLibraryMaterial>)Session["LibraryMaterialEditor"])[this.grdSearch.SelectedIndex]; }
    }

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
        if (user.MenuList.ContainsKey("4,10,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadOrganization();
                this.LoadLibrary();
                this.LoadKeyword();
                this.LoadAuthor();
                this.LoadCategory();
                this.LoadMaterialType();
                this.LoadLanguage();
                this.LoadPublisher();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadCategory()
    {
        try
        {
            List<ATTMaterialCategory> l = BLLMaterialCategory.GetMaterialCategory();
            l.Insert(0, new ATTMaterialCategory(0, "--- Select Category ---", "", ""));

            this.ddlCategory.DataSource = l;
            this.ddlCategory.DataTextField = "CategoryName";
            this.ddlCategory.DataValueField = "CategoryID";
            this.ddlCategory.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadMaterialType()
    {
        try
        {
            List<ATTMaterialType> l = BLLMaterialType.GetMaterialType();
            l.Insert(0, new ATTMaterialType(0, "--- Select Type ---", "", ""));

            this.ddlType.DataSource = l;
            this.ddlType.DataTextField = "MaterialTypeName";
            this.ddlType.DataValueField = "MaterialID";
            this.ddlType.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadLanguage()
    {
        try
        {
            List<ATTLookupLanguage> l = BLLLanguage.GetLanguageList();
            l.Insert(0, new ATTLookupLanguage(0, "--- Select Language ---", "", ""));

            this.ddlLanguage.DataSource = l;
            this.ddlLanguage.DataTextField = "LookupLanguageName";
            this.ddlLanguage.DataValueField = "LookupLanguageID";
            this.ddlLanguage.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadPublisher()
    {
        try
        {
            List<ATTPublisher> l = BLLPublisher.GetPublisherList();
            l.Insert(0, new ATTPublisher(0, "--- Select Publisher ---", "", "", ""));

            this.ddlPublisher.DataSource = l;
            this.ddlPublisher.DataTextField = "PublisherName";
            this.ddlPublisher.DataValueField = "PublisherID";
            this.ddlPublisher.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    void LoadOrganization()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            this.ddlOrg.DataSource = BLLOrganization.GetOrganizationByID(user.OrgID);
            this.ddlOrg.DataTextField = "OrgName";
            this.ddlOrg.DataValueField = "OrgID";
            this.ddlOrg.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadLibrary()
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            this.ddlLibrary.DataSource = BLLLibrary.GetLibraryList(user.OrgID, 1, 'N');
            this.ddlLibrary.DataTextField = "LibraryName";
            this.ddlLibrary.DataValueField = "LibraryID";
            this.ddlLibrary.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadKeyword()
    {
        try
        {
            this.lstKeyword.DataSource = BLLKeyword.GetKeywordList(null);
            this.lstKeyword.DataTextField = "KeywordName";
            this.lstKeyword.DataValueField = "KeywordID";
            this.lstKeyword.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadAuthor()
    {
        try
        {
            this.lstAuthor.DataSource = BLLAuthor.GetAuthorList(null);
            this.lstAuthor.DataTextField = "AuthorName";
            this.lstAuthor.DataValueField = "AuthorID";
            this.lstAuthor.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.hdnPagingIndex.Value == "")
                this.hdnPagingIndex.Value = "0";
            else
                this.hdnPagingIndex.Value = (int.Parse(this.hdnPagingIndex.Value) + 1).ToString();

            string keywordCollection = this.GetCriteriaCollectionFromList(this.lstKeyword);
            string authorCollection = this.GetCriteriaCollectionFromList(this.lstAuthor);

            ATTLibraryMaterial obj = new ATTLibraryMaterial();

            obj.OrgID = int.Parse(this.ddlOrg.SelectedValue);
            obj.LibraryID = int.Parse(this.ddlLibrary.SelectedValue);
            obj.LibraryMaterialType = int.Parse(this.ddlType.SelectedValue);
            obj.LibraryMaterialCategory = int.Parse(this.ddlCategory.SelectedValue);
            obj.LanguageID = int.Parse(this.ddlLanguage.SelectedValue);
            obj.PublisherID = int.Parse(this.ddlPublisher.SelectedValue);
            obj.CallNo = this.txtCallNo.Text;

            Session["LibraryMaterialEditor"] = BLLLibraryMaterial.GetSearchedLibraryMaterialList(obj, keywordCollection, authorCollection, "M");
            this.grdSearch.DataSource = (List<ATTLibraryMaterial>)Session["LibraryMaterialEditor"];
            this.grdSearch.DataBind();
            this.lblRecordCount.Text = "Total " + this.grdSearch.Rows.Count.ToString() + " record found.";

            this.LoadImageX.Width = new Unit(0);
            this.LoadImageX.Height = new Unit(0);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string GetCriteriaCollectionFromList(CheckBoxList listbox)
    {
        string collection = "";
        foreach (ListItem li in listbox.Items)
        {
            if (li.Selected == true)
                collection += li.Value.ToString() + ", ";
        }
         
        if (collection == "")
            return "";
        else
            return collection.Substring(0, collection.Length - 2);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearMyControls();
    }

    void ClearMyControls()
    {
        this.ddlLibrary.SelectedIndex = 0;
        this.ddlCategory.SelectedIndex = 0;
        this.ddlType.SelectedIndex = 0;
        this.ddlLanguage.SelectedIndex = 0;
        this.ddlPublisher.SelectedIndex = 0;
        this.txtCallNo.Text = "";

        this.UnSelectListbox(this.lstAuthor);
        this.UnSelectListbox(this.lstKeyword);

        this.grdSearch.DataSource = "";
        this.grdSearch.DataBind();

        this.lblRecordCount.Text = "";
    }

    void UnSelectListbox(CheckBoxList lst)
    {
        foreach (ListItem li in lst.Items)
        {
            if (li.Selected == true)
                li.Selected = false;
        }
    }

    protected void grdSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        List<ATTLibraryMaterial> lstLibMat=(List<ATTLibraryMaterial>)Session["LibraryMaterialEditor"];
        Session["LibraryMatToEdit"] = lstLibMat[grdSearch.SelectedIndex];
        Response.Redirect("LibraryMaterial.aspx");
    }
}
