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
using System.Text;

public partial class MODULES_LIS_Forms_LibraryMaterial : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();

    new public ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

    public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
    {
        Byte[] stringBytes = encoding.GetBytes(input);
        StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
        foreach (byte b in stringBytes)
        {
            sbBytes.AppendFormat("{0:X2}", b);
        }
        return sbBytes.ToString();
    }

    public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
    {
        int numberChars = hexInput.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
        }
        return encoding.GetString(bytes);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string hex = ConvertStringToHex("System.Runtime.Seria", Encoding.Unicode);
        //string data = ConvertHexToString(hex, Encoding.Unicode);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("4,9,1") == true || user.MenuList.ContainsKey("4,10,1") == true)
        {
            if (this.IsPostBack == false)
            {

                this.lnkViewFile.Visible = false;

                this.LoadOrganization();
                this.LoadLibrary();
                this.LoadCategory();
                this.LoadMaterialType();
                this.LoadLanguage();
                this.LoadPublisher();
                this.LoadKeyword();
                this.LoadAuthor();
                this.LoadCurrency();
                this.LoadRegDate();

                Session["LibMatID"] = null;


                this.CreateSessionForLibraryMaterial();

                this.ClearLibraryMaterialControl();

                try
                {
                  
                    ATTLibraryMaterial libraryMat = (ATTLibraryMaterial)Session["LibraryMatToEdit"];
                    if (libraryMat != null)
                    {
                        this.LoadLibraryMaterialToEdit(libraryMat);
                        this.LoadLibraryMaterialCopy(libraryMat);
                        Session["LibraryMatToEdit"] = null;
                        this.hdnAction.Value = "M";
                        this.LoadValidationSymbol();
                    }

                    this.lnkViewFile.Visible = true;
                }
                catch (Exception)
                {
                }
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

            this.ddlCategory_Rqd.DataSource = l;
            this.ddlCategory_Rqd.DataTextField = "CategoryName";
            this.ddlCategory_Rqd.DataValueField = "CategoryID";
            this.ddlCategory_Rqd.DataBind();
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

            this.ddlType_Rqd.DataSource = l;
            this.ddlType_Rqd.DataTextField = "MaterialTypeName";
            this.ddlType_Rqd.DataValueField = "MaterialID";
            this.ddlType_Rqd.DataBind();
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

            this.ddlLanguage_Rqd.DataSource = l;
            this.ddlLanguage_Rqd.DataTextField = "LookupLanguageName";
            this.ddlLanguage_Rqd.DataValueField = "LookupLanguageID";
            this.ddlLanguage_Rqd.DataBind();
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

            this.ddlPublisher_Rqd.DataSource = l;
            this.ddlPublisher_Rqd.DataTextField = "PublisherName";
            this.ddlPublisher_Rqd.DataValueField = "PublisherID";
            this.ddlPublisher_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void LoadLibraryMaterialToEdit(ATTLibraryMaterial library)
    {
        Session["LM_LibraryMaterial"] = library;

        Session["LibMatID"] = library.LMaterialID;
        this.ddlOrg.SelectedValue = library.OrgID.ToString();
        this.ddlLibrary.SelectedValue = library.LibraryID.ToString();
        this.ddlCategory_Rqd.SelectedValue = library.LibraryMaterialCategory.ToString();
        this.ddlType_Rqd.SelectedValue = library.LibraryMaterialType.ToString();
        this.txtCallNo_Rqd.Text = library.CallNo;
        this.ddlLanguage_Rqd.SelectedValue = library.LanguageID.ToString();
        this.ddlPublisher_Rqd.SelectedValue = library.PublisherID.ToString();
        this.txtCorporateBody.Text = library.CorporateBody;
        this.txtTitle_Rqd.Text = library.Title;
        this.txtSeriesState.Text = library.SeriesStatement;
        this.txtNote.Text = library.Note;
        this.txtBrdSubHeading.Text = library.BoardSubjectHeading;
        this.txtGeoDescription.Text = library.GeoDescription;
        this.txtPhyDescription.Text = library.PhysicalDescription;

        library.LstLMKeyword = BLLLibraryMaterialKeyword.GetLibraryMaterialKeywordList(library.OrgID, library.LibraryID, library.LMaterialID);
        this.grdKeyword.DataSource = library.LstLMKeyword;
        this.grdKeyword.DataBind();

        library.LstLMAuthor = BLLLibraryMaterialAuthor.GetLibraryMaterialAuthorList(library.OrgID, library.LibraryID, library.LMaterialID);
        this.grdAuthor.DataSource = library.LstLMAuthor;
        this.grdAuthor.DataBind();



    }
    void LoadLibraryMaterialCopy(ATTLibraryMaterial library)
    {
        //Session["LMCopy"] = library.LstLMCopy;
        List<ATTLibraryMaterialCopy> LstLibCpy = BLLLibraryMaterialCopy.GetLMCopy(library.OrgID, library.LibraryID, library.LMaterialID);
        Session["LMCopy"] = LstLibCpy;
        this.libMatCopyGrd.DataSource = LstLibCpy;
        this.libMatCopyGrd.DataBind();

    }



    void CreateSessionForLibraryMaterial()
    {
        Session["LM_LibraryMaterial"] = new ATTLibraryMaterial();
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
            this.ddlLibrary.DataSource = BLLLibrary.GetLibraryList(user.OrgID, null, 'N');
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
            List<ATTKeyword> lst = BLLKeyword.GetKeywordList(null);
            lst.Insert(0, new ATTKeyword(-1, "--- Select Keyword ---"));
            this.ddlKeyword.DataSource = lst;
            this.ddlKeyword.DataTextField = "KeywordName";
            this.ddlKeyword.DataValueField = "KeywordID";

            this.ddlKeyword.DataBind();
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
            List<ATTAuthor> lst = BLLAuthor.GetAuthorList(null);
            lst.Insert(0, new ATTAuthor(-1, "--- Select Author ---"));
            this.ddlAuthor.DataSource = lst;
            this.ddlAuthor.DataTextField = "AuthorName";
            this.ddlAuthor.DataValueField = "AuthorID";

            this.ddlAuthor.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAddKeyword_Click(object sender, EventArgs e)
    {
        if (this.ddlKeyword.SelectedIndex <= 0)
        {
            return;
        }

        ATTLibraryMaterial LM = (ATTLibraryMaterial)Session["LM_LibraryMaterial"];

        GridViewRow row;
        int rowCount = 0;
        foreach (ATTLibraryMaterialKeyword ky in LM.LstLMKeyword)
        {
            row = this.grdKeyword.Rows[rowCount];
            ky.HasChecked = ((CheckBox)row.FindControl("chkKeyword")).Checked;

            rowCount = rowCount + 1;
        }

        ATTKeyword key = new ATTKeyword
                                        (
                                            int.Parse(this.ddlKeyword.SelectedValue),
                                            this.ddlKeyword.SelectedItem.Text
                                        );

        ATTLibraryMaterialKeyword LMkey = new ATTLibraryMaterialKeyword();

        LMkey.OrgID = int.Parse(this.ddlOrg.SelectedValue);
        LMkey.LibraryID = int.Parse(this.ddlLibrary.SelectedValue);
        if (this.hdnAction.Value != "M")
            LMkey.LMaterialID = 0;
        LMkey.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        LMkey.EntryOn = DateTime.Now;
        LMkey.Action = "A";
        LMkey.HasChecked = false;

        LMkey.Keyword = key;

        ATTLibraryMaterialKeyword existKey = LM.LstLMKeyword.Find
                            (
                                delegate(ATTLibraryMaterialKeyword lmk)
                                {
                                    return
                                        lmk.OrgID == LMkey.OrgID &&
                                        lmk.LibraryID == LMkey.LibraryID &&
                                        lmk.KeywordID == LMkey.KeywordID;
                                }
                            );

        if (existKey != null)
            return;


        LM.LstLMKeyword.Add(LMkey);

        this.grdKeyword.DataSource = LM.LstLMKeyword;
        this.grdKeyword.DataBind();

    }

    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
        if (this.ddlAuthor.SelectedIndex <= 0)
        {
            return;
        }

        ATTLibraryMaterial LM = (ATTLibraryMaterial)Session["LM_LibraryMaterial"];

        GridViewRow row;
        int rowCount = 0;
        foreach (ATTLibraryMaterialAuthor ath in LM.LstLMAuthor)
        {
            row = this.grdAuthor.Rows[rowCount];
            ath.HasChecked = ((CheckBox)row.FindControl("chkAuthor")).Checked;

            rowCount = rowCount + 1;
        }

        ATTAuthor author = new ATTAuthor
                                        (
                                            int.Parse(this.ddlAuthor.SelectedValue),
                                            this.ddlAuthor.SelectedItem.Text
                                        );

        ATTLibraryMaterialAuthor LMAuthor = new ATTLibraryMaterialAuthor();

        LMAuthor.OrgID = int.Parse(this.ddlOrg.SelectedValue);
        LMAuthor.LibraryID = int.Parse(this.ddlLibrary.SelectedValue);
        if (this.hdnAction.Value != "M")
            LMAuthor.LMaterialID = 0;
        LMAuthor.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        LMAuthor.EntryOn = DateTime.Now;
        LMAuthor.Action = "A";

        LMAuthor.Author = author;

        ATTLibraryMaterialAuthor existAuthor = LM.LstLMAuthor.Find
                            (
                                delegate(ATTLibraryMaterialAuthor lma)
                                {
                                    return
                                        lma.OrgID == LMAuthor.OrgID &&
                                        lma.LibraryID == LMAuthor.LibraryID &&
                                        lma.AuthorID == LMAuthor.AuthorID;
                                }
                            );

        if (existAuthor != null)
            return;

        LM.LstLMAuthor.Add(LMAuthor);

        this.grdAuthor.DataSource = LM.LstLMAuthor;
        this.grdAuthor.DataBind();
    }

    public bool ServerValidateAll()
    {
        bool status = true;

        if (ddlCategory_Rqd.SelectedIndex == 0)
        {
            sb.Append("Category must be selected</br>");
            status = false;
        }
        if (ddlType_Rqd.SelectedIndex == 0)
        {
            sb.Append("Type must be selected</br>");
            status = false;
        }
        if (txtCallNo_Rqd.Text == "")
        {
            sb.Append("Call No must not be blank</br>");
            status = false;
        }
        if (ddlLanguage_Rqd.SelectedIndex == 0)
        {
            sb.Append("Language must be selected</br>");
            status = false;
        }
        if (ddlPublisher_Rqd.SelectedIndex == 0)
        {
            sb.Append("Publisher must be selected</br>");
            status = false;
        }
        if (txtCorporateBody.Text == "")
        {
            sb.Append("Corporate Body must be not be blank</br>");
            status = false;
        }
        if (txtTitle_Rqd.Text == "")
        {
            sb.Append("Title must not be blank</br>");
            status = false;
        }
        if (editionTxt.Text == "")
        {
            sb.Append("Edition Cannot be left blank</br>");
            status = false;
        }
        if (pubDateTxt.Text == "")
        {
            sb.Append("Publication Date cannot be left blank</br>");
            status = false;

        }
        if (priceTxt.Text == "")
        {
            sb.Append("Price Cannot be left blank</br>");
            status = false;

        }
        if (isbnTxt.Text == "")
        {
            sb.Append("ISBN Cannot be left blank</br>");
            status = false;

        }
        if (locTxt.Text == "")
        {
            sb.Append("Location Cannot be left blank</br>");
            status = false;

        }

        return status;
    }
    public bool ServerValidateMaster()
    {
        bool status = true;

        if (ddlCategory_Rqd.SelectedIndex == 0)
        {
            sb.Append("Category must be selected</br>");
            status = false;
        }
        if (ddlType_Rqd.SelectedIndex == 0)
        {
            sb.Append("Type must be selected</br>");
            status = false;
        }
        if (txtCallNo_Rqd.Text == "")
        {
            sb.Append("Call No must not be blank</br>");
            status = false;
        }
        if (ddlLanguage_Rqd.SelectedIndex == 0)
        {
            sb.Append("Language must be selected</br>");
            status = false;
        }
        if (ddlPublisher_Rqd.SelectedIndex == 0)
        {
            sb.Append("Publisher must be selected</br>");
            status = false;
        }
        if (txtCorporateBody.Text == "")
        {
            sb.Append("Corporate Body must be not be blank</br>");
            status = false;
        }
        if (txtTitle_Rqd.Text == "")
        {
            sb.Append("Title must not be blank</br>");
            status = false;
        }
       

        return status;
    }





    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.hdnAction.Value == "")
        {
            if (!ServerValidateAll())
            {
                this.lblStatusMessage.Text = sb.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
        else if (this.hdnAction.Value == "M")
        {
            if (!ServerValidateMaster())
            {
                this.lblStatusMessage.Text = sb.ToString();
                this.programmaticModalPopup.Show();
                return;
            }
        }
        string ext = System.IO.Path.GetExtension(this.fupAttachment.FileName);

        if (ext == "pdf" || ext == "jpeg" || ext == "jpg" || ext == "gif")
        {
            this.lblStatusMessage.Text = "Uploaded file's extention must be of 'pdf' or 'jpg' or 'jpeg' or 'gif'.";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTLibraryMaterial LM = (ATTLibraryMaterial)Session["LM_LibraryMaterial"];

        LM.OrgID = int.Parse(this.ddlOrg.SelectedValue);
        LM.LibraryID = int.Parse(this.ddlLibrary.SelectedValue);
        if (this.hdnAction.Value != "M")
            LM.LMaterialID = 0;
        LM.LibraryMaterialType = int.Parse(this.ddlType_Rqd.SelectedValue);
        LM.LibraryMaterialCategory = int.Parse(this.ddlCategory_Rqd.Text);
        LM.CallNo = this.txtCallNo_Rqd.Text;
        LM.CorporateBody = this.txtCorporateBody.Text;
        LM.Title = this.txtTitle_Rqd.Text;
        LM.SeriesStatement = this.txtSeriesState.Text;
        LM.Note = this.txtNote.Text;
        LM.BoardSubjectHeading = this.txtBrdSubHeading.Text;
        LM.GeoDescription = this.txtGeoDescription.Text;
        LM.LanguageID = int.Parse(this.ddlLanguage_Rqd.SelectedValue);
        LM.PublisherID = int.Parse(this.ddlPublisher_Rqd.SelectedValue);
        LM.PhysicalDescription = this.txtPhyDescription.Text;
        LM.EntryBy = ((ATTUserLogin)Session["Login_User_Detail"]).UserName;
        LM.EntryOn = DateTime.Now;
        //LM.ContentFile = null;
        //LM.CFileType = "";
        if (this.hdnAction.Value == "M")
            LM.Action = "M";
        else
            LM.Action = "A";

        if (this.fupAttachment.HasFile == true)
        {
            LM.ContentFile = this.fupAttachment.FileBytes;
            LM.CFileType = System.IO.Path.GetExtension(this.fupAttachment.FileName);
        }

        ObjectValidation OV = BLLLibraryMaterial.Validate(LM);
        if (OV.IsValid == false)
        {
            //this.lblMaterialStatus.Text = OV.ErrorMessage;
            this.lblStatusMessage.Text = OV.ErrorMessage;
            this.programmaticModalPopup.Show();
            return;
        }

        GridViewRow keyRow;
        int keyRowCount = 0;
        bool keyChecked;
        foreach (ATTLibraryMaterialKeyword ky in LM.LstLMKeyword)
        {
            keyRow = this.grdKeyword.Rows[keyRowCount];

            keyChecked = ((CheckBox)keyRow.FindControl("chkKeyword")).Checked;
            if (keyChecked == true && ky.Action == "A")
                ky.Action = "N";
            else if (keyChecked == true && ky.Action == "M")
                ky.Action = "D";
            else if (keyChecked == false && ky.Action == "M")
                ky.Action = "N";

            keyRowCount = keyRowCount + 1;
        }

        GridViewRow authorRow;
        int authorRowCount = 0;
        bool authorChecked;
        foreach (ATTLibraryMaterialAuthor au in LM.LstLMAuthor)
        {
            authorRow = this.grdAuthor.Rows[authorRowCount];

            authorChecked = ((CheckBox)authorRow.FindControl("chkAuthor")).Checked;
            if (authorChecked == true && au.Action == "A")
                au.Action = "N";
            else if (authorChecked == true && au.Action == "M")
                au.Action = "D";
            else if (authorChecked == false && au.Action == "M")
                au.Action = "N";

            authorRowCount = authorRowCount + 1;
        }



        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        try
        {
            if (LM.Action == "A")
            {
                if (user.MenuList["4,9,1"] == null || user.MenuList["4,9,1"].PAdd == "N")
                {
                    this.lblStatusMessage.Text = Utilities.PreviledgeMsg + " add Library Material.";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }
            else if (LM.Action == "M")
            {
                if (user.MenuList["4,9,1"] == null || user.MenuList["4,9,1"].PEdit == "N")
                {
                    this.lblStatusMessage.Text = Utilities.PreviledgeMsg + " update Library Material.";
                    this.programmaticModalPopup.Show();
                    return;
                }
            }

            Previlege.PrevilegeType pType = Previlege.PrevilegeType.P_ADD;
            string modeName = "";

            if (LM.Action == "A")
            {
                pType = Previlege.PrevilegeType.P_ADD;
                modeName = "added";
            }
            else if (LM.Action == "M")
            {
                pType = Previlege.PrevilegeType.P_EDIT;
                modeName = "updated";
            }
            
            Previlege pobj = new Previlege(user.UserName, "4,9,1", 4, pType);


            Session["LM"] = LM;

            //save details
            //save master detail every time
            if (Session["LibMatID"] == null)
            {
                LM.Action = "A";
               
            }
            else
            {
                LM.Action = "M";
                LM.LMaterialID = long.Parse(Session["LibMatID"].ToString());

            }
            long LMID = BLLLibraryMaterial.AddLibraryMaterial(LM, pobj);
            Session["LibMatID"] = LMID;

            if (this.hdnAction.Value=="M")
            {
                if (this.libMatCopyGrd.SelectedIndex > -1)
                {
                    SaveLibraryDetails(LMID,"M",long.Parse(Session["AccessionID"].ToString()));
                    LoadLibraryMaterialCopyGrid(LMID);
                }
                else if (this.libMatCopyGrd.SelectedIndex < 0)
                {
                    if (this.editionTxt.Text != "" && this.pubDateTxt.Text != "" && this.priceTxt.Text != "" && this.isbnTxt.Text != "")
                    {
                        SaveLibraryDetails(LMID, "A", 0);
                        LoadLibraryMaterialCopyGrid(LMID);
                    }
                  
                }
            }
            else if (this.hdnAction.Value!="M")
            {
                if (this.libMatCopyGrd.SelectedIndex > -1)
                {
                    //update the material copy
                    SaveLibraryDetails(LMID, "M", long.Parse(Session["AccessionID"].ToString()));
                    LoadLibraryMaterialCopyGrid(LMID);
                }
                else if (this.libMatCopyGrd.SelectedIndex < 0)
                {
                    //add new material copy
                    SaveLibraryDetails(LMID, "A", 0);
                    LoadLibraryMaterialCopyGrid(LMID);
                }
            }

            
            this.ClearLibraryMaterialControl();
            this.ClearLMCopyControls();
            this.LoadRegDate();

            this.lblStatusMessage.Text = "Library material " + modeName + " successfully.";
            this.programmaticModalPopup.Show();


        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }

    }

    void SaveLibraryDetails(long? LibMatID,string action,long acc_id)
    {
        long LMID = 0;

        if (LibMatID == null)
        {
            LMID = long.Parse(Session["LibMatID"].ToString());
        }
        else
        {
            LMID = LibMatID.Value;
        }

        ATTLibraryMaterial LMObj = (ATTLibraryMaterial)Session["LM"];
        ////---------Add Material Copy---------
        ATTLibraryMaterialCopy libCopyObj = new ATTLibraryMaterialCopy();
        libCopyObj.Edition = editionTxt.Text;
        libCopyObj.PublicationDate = pubDateTxt.Text;
        libCopyObj.RegistrationDate = DateTime.Now;
        regDateTxt.Text = DateTime.Now.ToShortDateString();
        libCopyObj.Price = double.Parse(priceTxt.Text);
        libCopyObj.CurrencyID = int.Parse(this.ddlCurrency.SelectedValue);
        libCopyObj.Location = locTxt.Text;
        libCopyObj.Action = action;
        libCopyObj.AccessionID = acc_id;       
        libCopyObj.IsbnIssnNo = isbnTxt.Text;
        libCopyObj.OrgID = LMObj.OrgID;
        libCopyObj.LibraryID = LMObj.LibraryID;
        libCopyObj.EntryBy = LMObj.EntryBy;

        List<ATTLibraryMaterialCopy> lstLMCpy = new List<ATTLibraryMaterialCopy>();
        lstLMCpy.Add(libCopyObj);
        BLLLibraryMaterial.AddLibraryMaterialCopy(lstLMCpy, LMID);      

    }

    void LoadLibraryMaterialCopyGrid(long LMID)
    {
        ATTLibraryMaterial LMObj = (ATTLibraryMaterial)Session["LM"];
        List<ATTLibraryMaterialCopy> LMCopy = BLLLibraryMaterialCopy.GetLMCopy(LMObj.OrgID, LMObj.LibraryID, LMID);
        libMatCopyGrd.DataSource = LMCopy;
        libMatCopyGrd.DataBind();
        Session["LMCopy"] = LMCopy;
    }

    void ClearLibraryMaterialControl()
    {
        //Session["FileByte"] = null;
        //this.hdnFileName.Value = "";
        //this.lblFileName.Text = "";


        this.lnkViewFile.Visible = false;
        this.CreateSessionForLibraryMaterial();




    }
    void ClearLMCopyControls()
    {
        editionTxt.Text = "";
        pubDateTxt.Text = "";
        regDateTxt.Text = "";
        priceTxt.Text = "";
        isbnTxt.Text = "";
        locTxt.Text = "";
        this.ddlCurrency.SelectedIndex = 0;
        this.libMatCopyGrd.SelectedIndex = -1;
    }

    protected void btnFullCancel_Click(object sender, EventArgs e)
    {
        this.ClearLibraryMaterialControl();
        this.ClearLMCopyControls();
        this.ClearMasterAll();
        this.CreateNewLMIDSession();
        this.LoadRegDate();
        this.hdnAction.Value = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        //Response.ContentType = "text/plain";
        Response.BinaryWrite(this.fupAttachment.FileBytes);
        Response.End();
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Session["FileByte"] = this.fupAttachment.FileBytes;
        //Response.ClearHeaders();
        //Response.ClearContent();
        //Response.ContentType = "application/pdf";
        //Response.BinaryWrite(this.fupAttachment.FileBytes);
        //Response.End();
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void lnkViewFile_Click(object sender, EventArgs e)
    {

    }
    protected void btnGetKeyword_Click(object sender, EventArgs e)
    {
        this.LoadKeyword();
    }
    protected void btnGetAuthor_Click(object sender, EventArgs e)
    {
        this.LoadAuthor();
    }

    protected void btnNewPublisher_Click(object sender, EventArgs e)
    {

    }
    protected void btnGetPublisher_Click(object sender, EventArgs e)
    {
        this.LoadPublisher();
    }
    void LoadCurrency()
    {
        List<ATTCurrency> lstCurrency = BLLCurrency.GetCurrencyList(null);
        Session["Currency"] = lstCurrency;
        ddlCurrency.DataSource = lstCurrency;
        ddlCurrency.DataTextField = "CurrencyName";
        ddlCurrency.DataValueField = "CurrencyID";
        ddlCurrency.DataBind();
    }
    void LoadRegDate()
    {
        regDateTxt.Text = DateTime.Now.ToShortDateString();
    }
    protected void libMatCopyGrd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.hdnAction.Value == "M")
        {

            List<ATTLibraryMaterialCopy> LMCopy = (List<ATTLibraryMaterialCopy>)Session["LMCopy"];
            editionTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].Edition;
            pubDateTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].PublicationDate.ToString();
            regDateTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].RegistrationDate.ToShortDateString();
            priceTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].Price.ToString();
            isbnTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].IsbnIssnNo.ToString();
            locTxt.Text = LMCopy[this.libMatCopyGrd.SelectedIndex].Location.ToString();
            int currID = LMCopy[this.libMatCopyGrd.SelectedIndex].CurrencyID;
            Session["AccessionID"] = LMCopy[this.libMatCopyGrd.SelectedIndex].AccessionID;

            List<ATTCurrency> lstCurrency = (List<ATTCurrency>)Session["Currency"];
            int index = lstCurrency.FindIndex(

                delegate(ATTCurrency obj)
                {
                    return obj.CurrencyID == currID;
                }
                );

            ddlCurrency.SelectedIndex = index;

        }
        else
        {
            List<ATTLibraryMaterialCopy> LMCopyLst = (List<ATTLibraryMaterialCopy>)Session["LMCopy"];
            editionTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].Edition;
            pubDateTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].PublicationDate.ToString();
            regDateTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].RegistrationDate.ToShortDateString();
            priceTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].Price.ToString();
            isbnTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].IsbnIssnNo.ToString();
            locTxt.Text = LMCopyLst[this.libMatCopyGrd.SelectedIndex].Location.ToString();
            int currID = LMCopyLst[this.libMatCopyGrd.SelectedIndex].CurrencyID;
            Session["AccessionID"] = LMCopyLst[this.libMatCopyGrd.SelectedIndex].AccessionID;

            List<ATTCurrency> lstCurrency = (List<ATTCurrency>)Session["Currency"];
            int index = lstCurrency.FindIndex(

                delegate(ATTCurrency obj)
                {
                    return obj.CurrencyID == currID;
                }
                );

            ddlCurrency.SelectedIndex = index;

        }
    }

    void CreateNewLMIDSession()
    {
        Session["LibMatID"] = null;
    }
    void ClearMasterAll()
    {
        this.lnkViewFile.Visible = false;
        this.hdnAction.Value = "";
        this.CreateSessionForLibraryMaterial();



        this.ddlLibrary.SelectedIndex = 0;

        this.ddlCategory_Rqd.SelectedIndex = 0;
        this.ddlType_Rqd.SelectedIndex = 0;
        this.txtCallNo_Rqd.Text = "";
        this.ddlLanguage_Rqd.SelectedIndex = 0;
        this.ddlPublisher_Rqd.SelectedIndex = 0;
        this.ddlAuthor.SelectedIndex = 0;
        this.ddlKeyword.SelectedIndex = 0;
        this.txtCorporateBody.Text = "";
        this.txtTitle_Rqd.Text = "";
        this.txtSeriesState.Text = "";
        this.txtNote.Text = "";
        this.txtBrdSubHeading.Text = "";
        this.txtGeoDescription.Text = "";
        this.txtPhyDescription.Text = "";


        this.grdKeyword.DataSource = null;
        this.grdKeyword.DataBind();

        this.grdAuthor.DataSource = null;
        this.grdAuthor.DataBind();

        this.libMatCopyGrd.DataSource = null;
        this.libMatCopyGrd.DataBind();



    }
    protected void libMatCopyGrd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[2].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<ATTCurrency> lstCurrency = (List<ATTCurrency>)Session["Currency"];
            int index = lstCurrency.FindIndex(

                delegate(ATTCurrency obj)
                {
                    return obj.CurrencyID == int.Parse(e.Row.Cells[5].Text);
                }
                );
            Label lb = (Label)e.Row.FindControl("currLbl");
            lb.Text = lstCurrency[index].CurrencyName;
        }
        
    }

    public void LoadValidationSymbol()
    {
        if (this.hdnAction.Value == "M")
        {
            this.edtVal.Visible = false;
            this.pubDateVal.Visible = false;
            this.priceVal.Visible = false;
            this.isbnVal.Visible = false;
        }
        else if (this.hdnAction.Value == "")
        {
            this.edtVal.Visible = true;
            this.pubDateVal.Visible = true;
            this.priceVal.Visible = true;
            this.isbnVal.Visible = true;
        }
    }
}