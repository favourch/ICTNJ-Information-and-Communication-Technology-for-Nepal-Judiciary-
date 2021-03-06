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


using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_PropertyDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,18,1") == true)
        {
            Session["OrgID"] = user.OrgID;
            if (!IsPostBack)
            {
                if (Session["PropDetailsEmpID"] != null)
                {
                    int empID = int.Parse(Session["PropDetailsEmpID"].ToString());
                    Session["PropDetailsEmpID"] = null;
                    LoadEmpOrgInfo(empID);
                }

                Session["PropertyCatList"] = null;
                Session["PropertyCatColList"] = null;
                Session["PCatCount"] = null;
                Session["rqd_lstPCatCols"] = null;
                Session["grdPCat"] = null;
                Session["SetSubDate"] = false;
                Session["SubDate"] = null;
                Session["alreadySet"] = null;
                Session["AmountDate"] = null;
                LoadProperty();
                LoadOrganisation();
                //CallCreateAmountDateGrid();
            }
        }
        else
            Response.Redirect("~/MODULES/EmployeeSearch.aspx", true);
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["PropertyCatOrgList"] = BLLOrganization.GetOrganizationNameList();
            this.drpOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["PropertyCatOrgList"];
            this.drpOrganisation_rqd.DataTextField = "OrgName";
            this.drpOrganisation_rqd.DataValueField = "OrgId";
            this.drpOrganisation_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "कार्यलय छान्नुहोस्";
            a.Value = "0";
            drpOrganisation_rqd.Items.Insert(0, a);

            //Session["DocSearchUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(null, null);
            //Session["DocSearchDocNameList"] = BLLDocument.GetDocumentNameList(null, null, null);


        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    public void LoadEmpOrgInfo(int empID)
    {
        try
        {
            List<ATTEmployeeSearch> lstEmpSearch;
            List<ATTEmployeeSearch> lstRqdEmpSearch;

            lstEmpSearch = (List<ATTEmployeeSearch>)Session["EmpSearchResult"];


            lstRqdEmpSearch = lstEmpSearch.FindAll(
                                                       delegate(ATTEmployeeSearch objEmp)
                                                       {
                                                           return objEmp.EmpID == empID;
                                                       }

                                                  );

            if (lstRqdEmpSearch.Count > 0)
            {
                foreach (ATTEmployeeSearch objEmp in lstRqdEmpSearch)
                {
                    Session["PrpEmpID"] = objEmp.EmpID;
                    txtEmployeeNo_rqd.Text = objEmp.SymbolNo;
                    txtName_rqd.Text = objEmp.RDFullName;
                    txtPost_rqd.Text = objEmp.LevelName + "/" + objEmp.DesName;
                    txtOffice_rqd.Text = objEmp.OrgName;
                }

                txtEmployeeNo_rqd.ReadOnly = true;
                txtName_rqd.ReadOnly = true;
                txtPost_rqd.ReadOnly = true;
                txtOffice_rqd.ReadOnly = true;
            }
            else
            {
                Response.Redirect("EmployeeSearch.aspx");
            }



            //Session["EmpOrgInfo"] = BLLVwEmployeeOrganisationInfo.GetEmployeeOrganisationInfoList(empID);

            //foreach (ATTVwEmployeeOrganisationInfo item in (List<ATTVwEmployeeOrganisationInfo>)Session["EmpOrgInfo"])
            //{
            //    txtEmployeeNo_rqd.Text = item.EmpID.ToString();
            //    if (item.FullName != "")
            //    {
            //        txtName_rqd.Text = item.FullName;
            //        txtPost_rqd.Text = item.LevelName + "/" + item.DesignationName;
            //        txtOffice_rqd.Text = item.OrgName;
            //    }
            //    else
            //    {
            //        this.lblStatusMessageTitle.Text = "Search Status";
            //        this.lblStatusMessage.Text = " No Search Data found !!!.";
            //        this.programmaticModalPopup.Show();
            //        //lblStatus.Text = " No Search Data found !!!.";
            //    }

            //}

            //if (txtName_rqd.Text == "")
            //{
            //    this.lblStatusMessageTitle.Text = "Search Status";
            //    this.lblStatusMessage.Text = " No Search Data found !!!.";
            //    this.programmaticModalPopup.Show();
                
            //}
            //txtEmployeeNo.ReadOnly = true;
            
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }
    
    public void LoadProperty()
    {
        try
        {
            Session["PropertyCategoryList"] = BLLPropertyCategory.GetPropertyCateogryList(null);
            
            List<ATTPropertyCategory> lst = new List<ATTPropertyCategory>();
            List<ATTPropertyCategory> lstRqd = new List<ATTPropertyCategory>();

            lst = (List<ATTPropertyCategory>)Session["PropertyCategoryList"];

            lstRqd = lst.FindAll(
                                      delegate(ATTPropertyCategory objPCC)
                                      {
                                          return objPCC.MasterType != "0";
                                      }
                                 );

            this.lstProperty.DataSource = lstRqd;
            this.lstProperty.DataTextField = "PCategoryName";
            this.lstProperty.DataValueField = "PCategoryID";
            this.lstProperty.DataBind();

            Session["PropertyCatColList"] = BLLPropertyCategoryColumns.GetPropertyCateogryColList(null);

        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status"; 
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadColumnList()
    {
        try
        {
            if (Session["rqd_lstPCatCols"] != null)
            {
                ArrayList myList = new ArrayList();
                ArrayList myListType = new ArrayList();

                foreach (ATTPropertyCategoryColumns CatCol in (List<ATTPropertyCategoryColumns>)Session["rqd_lstPCatCols"])
                {
                    myList.Add(CatCol.ColNo.ToString());
                    myListType.Add(CatCol.ColDataType.ToString());
                }

                Session["myList"] = (object)myList;
                Session["myListType"] = (object)myListType;
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lstProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["alreadySet"] != null)
            {
                bool flag = true ;
                ArrayList alreadySet = (ArrayList)Session["alreadySet"];
                for (int i = 0; i < alreadySet.Count; i++)
                {
                    if (alreadySet[i].ToString() == lstProperty.SelectedValue.ToString())
                    {
                        //lblStatus.Text = " Details for '" + lstProperty.SelectedItem.ToString() + "' is already set.";
                        this.lblStatusMessageTitle.Text = "Select status";
                        this.lblStatusMessage.Text = " Details for '" + lstProperty.SelectedItem.ToString() + "' is already set.";
                        this.programmaticModalPopup.Show();
                        
                        btnSave.Visible = false;
                        flag = false;
                    }
                }

                CallCreatGrid();

                //CallCreateAmountDateGrid();

                if (flag)
                {
                    btnSave.Visible = true;
                    lblStatus.Text = "";
                }
                
            }
            else
            {
                btnSave.Visible = true;
                lblStatus.Text = "";
                CallCreatGrid();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
      
    }
    
    protected void grdPropertyDetails_RowCreated1(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;

        if (Session["rqd_lstPCatCols"] != null)
        {
            List<ATTPropertyCategoryColumns> lstPCCRowCreated = (List<ATTPropertyCategoryColumns>)Session["rqd_lstPCatCols"];

            if (e.Row.RowType == DataControlRowType.Header)
            {
                int i = 0;
                foreach (ATTPropertyCategoryColumns CatCol in lstPCCRowCreated)
                {
                    row.Cells[i].Text = CatCol.ColName;
                    i = i + 1;
          
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                int j = 0;

                foreach (ATTPropertyCategoryColumns CatCol in lstPCCRowCreated)
                {
                    if (j > 0)
                    {
                        string TextBoxID = "TextBox" + Convert.ToString(j);
                        TextBox Box = (TextBox)e.Row.FindControl(TextBoxID);
                       

                        if (CatCol.ColDataType == "N")
                        {

                            if (Box.Text == "")
                            {
                                Box.Text = "0";
                                Box.MaxLength = 10;
                                Box.CssClass = "grdTxtBox";
                            }
                                
                           
                        }
                        else if (CatCol.ColDataType == "D")
                        {
                            if (Box.Text == "")
                            {
                                Box.Text = "0.0";
                                Box.MaxLength = 10;
                                Box.CssClass = "grdTxtBox";
                            }
                           
                        }
                        else
                        {
                            Box.MaxLength = 20;
                        }
                    }
                    j++;
                }
            }



        }

    }
    
    protected void grdPropertyDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        List<ATTPropertyCategoryColumns> lstPCCRowCreated = (List<ATTPropertyCategoryColumns>)Session["rqd_lstPCatCols"];

        if (Session["PCatCount"] != null)
        {
            int count = int.Parse(Session["PCatCount"].ToString());
            if (count >= lstPCCRowCreated.Count)
            {
                if (count < 15)
                {
                    while (count < 15)
                    {
                        row.Cells[count].Visible = false;
                        count = count + 1;
                    }
                }

            }
        }

        //--------------------------------------------------------------
        //NB: To make column with Active = N visible false
        //--------------------------------------------------------------

        int j = 0;
        foreach (ATTPropertyCategoryColumns CatCol in lstPCCRowCreated)
        {
           if (CatCol.Active == "N")
                row.Cells[j].Visible = false;

            j = j + 1;

        }

        //--------------------------------------------------------------
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i = 0;

            foreach (ATTPropertyCategoryColumns CatCol in lstPCCRowCreated)
            {
                if (i > 1)
                {
                    string TextBoxID = "TextBox" + Convert.ToString(i);
                    if (CatCol.ColDataType == "N")
                    {
                        ((TextBox)e.Row.FindControl(TextBoxID)).Attributes.Add("onkeypress", "return NumberOnly(event,this)");
                        //e.Row.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (CatCol.ColDataType == "D")
                    {
                        TextBox Box = (TextBox)e.Row.FindControl(TextBoxID);
                         //string val = Box.Text;

                        ((TextBox)e.Row.FindControl(TextBoxID)).Attributes.Add("onkeypress", "return DecimalOnly(event,this)");
                        // e.Row.HorizontalAlign = HorizontalAlign.Right;
                    }
                }
                i++;
            }
        }


    }
    
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        try
        {
            int rowIndex = 0;

            ArrayList myList = new ArrayList();
            ArrayList myListType = new ArrayList();

            if (Session["grdPCat"] != null)
            {
                DataTable dt = (DataTable)Session["grdPCat"];
                DataRow dr = null;

                myList = (ArrayList)Session["myList"];
                myListType = (ArrayList)Session["myListType"];

                if (dt.Rows.Count > 0)
                {
                    int count = int.Parse(myList.Count.ToString());


                    //------------------------------------------------------------------
                    // Get each row from gridview and add it to DataTable
                    //------------------------------------------------------------------
                    foreach (GridViewRow gvr in grdPropertyDetails.Rows)
                    {
                        ArrayList myTextBoxList = new ArrayList();

                        for (int j = 1; j < count; j++)
                        {
                            string TextBoxID = "TextBox" + Convert.ToString(j);
                            TextBox box = new TextBox();
                            box = (TextBox)gvr.Cells[j].FindControl(TextBoxID);

                            myTextBoxList.Add(box.Text);
                        }

                        dr = dt.Rows[rowIndex];

                        for (int k = 0; k < count; k++)
                        {
                            if (k < 1)
                                dr[myList[k].ToString()] = gvr.Cells[0].Text;
                            else
                            {
                                if (myListType[k].ToString() == "C")
                                    dr[myList[k].ToString()] = myTextBoxList[k - 1].ToString();
                                else if (myListType[k].ToString() == "N")
                                {
                                    int val;
                                    if (myTextBoxList[k - 1].ToString() == "")
                                    {
                                        val = 0;
                                    }
                                    else
                                        val = int.Parse(myTextBoxList[k - 1].ToString());

                                    dr[myList[k].ToString()] = val;
                                }
                                else if (myListType[k].ToString() == "D")
                                {
                                    //double decVal;
                                    string decVal;
                                    if (myTextBoxList[k - 1].ToString() == "")
                                    {
                                        //decVal = 0.0;
                                        decVal = "0.0";
                                    }
                                    else
                                    {
                                       // decVal = double.Parse(myTextBoxList[k - 1].ToString());
                                        decVal = myTextBoxList[k - 1].ToString();
                                    }

                                    //else
                                    //    decVal = int.Parse(myTextBoxList[k - 1].ToString());

                                    dr[myList[k].ToString()] = decVal;
                                }

                            }
                        }
                        dr.AcceptChanges();
                        rowIndex++;

                    }

                    //------------------------------------------------------------------
                    // Add empty row first to DataTable to show as first row in gridview
                    //------------------------------------------------------------------
                    dr = dt.NewRow();

                    for (int k = 0; k < count; k++)
                    {
                        if (k < 1)
                            dr[myList[k].ToString()] = dt.Rows.Count + 1;
                        else
                        {
                            if (myListType[k].ToString() == "C")
                                dr[myList[k].ToString()] = "";
                            else if (myListType[k].ToString() == "N")
                            {
                                dr[myList[k].ToString()] = 0;
                            }
                            else if (myListType[k].ToString() == "D")
                            {
                                //dr[myList[k].ToString()] = double.Parse("0.0");
                                dr[myList[k].ToString()] = "0.0";
                            }
                        }

                    }
                    dt.Rows.Add(dr);

                    //------------------------------------------------------------------
                    // End of add  empty row 
                    //------------------------------------------------------------------

                }
                Session["grdPCat"] = dt;
                // Add DataTable back to grid
                grdPropertyDetails.DataSource = dt;
                grdPropertyDetails.DataBind();

                SetPreviousData();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
       
   
    }

    private void SetPreviousData()
    {
        try
        {                      
            if (Session["grdPCat"] != null)
            {
                int rowIndex = 0;
                DataTable dt = (DataTable)Session["grdPCat"];
                ArrayList myList = new ArrayList();
                
                myList = (ArrayList)Session["myList"];

                int count = int.Parse(myList.Count.ToString());

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        for (int j = 1; j < count; j++)
                        {
                            string TextBoxID = "TextBox" + Convert.ToString(j);
                            TextBox box = new TextBox();
                            box = (TextBox)grdPropertyDetails.Rows[rowIndex].Cells[j].FindControl(TextBoxID);
                            box.Text = dt.Rows[i][myList[j].ToString()].ToString();
                               
                        }
                        rowIndex++;
                    }

               }

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SaveSubmissionDetails();

            if (Session["SetSubDate"].ToString() == "True")
            {
                if (Session["alreadySet"] != null)
                {
                    ArrayList alreadySet = (ArrayList)Session["alreadySet"];
                    for (int i = 0; i < alreadySet.Count; i++)
                    {
                        if (alreadySet[i].ToString() != lstProperty.SelectedValue.ToString())
                        {
                            SavePropertyDetails();
                            i = alreadySet.Count;
                        }
                        else
                        {
                            this.lblStatusMessageTitle.Text = "Select Status";
                            this.lblStatusMessage.Text = " Details for " + lstProperty.SelectedItem.ToString() + " already set previously !!!";
                            this.programmaticModalPopup.Show();
                           
                        }
                    }
                }
                else
                {
                    SavePropertyDetails();
                    
                }

            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        

    }

    public void SaveSubmissionDetails()
    {
        try
        {
            if (Session["SetSubDate"].ToString() == "False")
            {
                ATTSubmissionDetails objSD = new ATTSubmissionDetails();
                //objSD.EmpID = int.Parse(txtEmployeeNo_rqd.Text);
                objSD.EmpID = int.Parse(Session["PrpEmpID"].ToString());
                objSD.SubmissionDate = txtSubDate_RDT.Text;
                objSD.SubmissionOffice = drpOrganisation_rqd.SelectedItem.Text;
                objSD.SubmissionPlace = txtSubOffPlace_rqd.Text;

               

                if (BLLSubmissionDetails.SaveSubmissionDetails(objSD))
                {
                    this.lblStatusMessage.Text = "Property Details Saves Successfully.";
                    this.programmaticModalPopup.Show();
                    Session["SubDate"] = txtSubDate_RDT.Text;
                    if (Session["SubDate"] != null)
                    {
                        Session["SetSubDate"] = true;
                        txtSubDate_RDT.ReadOnly = true;
                        txtSubOffPlace_rqd.ReadOnly = true;
                        drpOrganisation_rqd.Enabled = false;
                    }
                    else
                    {
                        this.lblStatusMessageTitle.Text = "Submission Status";
                        this.lblStatusMessage.Text = "Enter Submission Details";
                        this.programmaticModalPopup.Show();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
        
    }

    public void SavePropertyDetails()
    {
        try
        {   //------------------------------------------------------------
            //NB: For Property Category Save
            //------------------------------------------------------------

            if (Session["grdPCat"] != null)
            {
                int rowIndex = 0;
                DataTable dtCurrentTable = (DataTable)Session["grdPCat"];

                ArrayList myList = new ArrayList();
                ArrayList myListType = new ArrayList();
                myList = (ArrayList)Session["myList"];
                myListType = (ArrayList)Session["myListType"];

                List<ATTPropertyDetails> lstPropertyDetail = new List<ATTPropertyDetails>();
                List<ATTPropertyIncome> lstPropertyIncome = new List<ATTPropertyIncome>();

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        int count = int.Parse(myList.Count.ToString());
                        ArrayList myTextBoxList = new ArrayList();

                        for (int j = 1; j < count; j++)
                        {
                            string TextBoxID = "TextBox" + Convert.ToString(j);
                            TextBox box = new TextBox();
                            box = (TextBox)grdPropertyDetails.Rows[rowIndex].Cells[j].FindControl(TextBoxID);

                            myTextBoxList.Add(box.Text);
                        }


                        for (int k = 1; k < count; k++)
                        {
                            ATTPropertyDetails objPD = new ATTPropertyDetails();
                            objPD.EmpID  = int.Parse(Session["PrpEmpID"].ToString());
                            objPD.PCatID = int.Parse(lstProperty.SelectedValue.ToString());
                            objPD.ColNo = k + 1;
                            objPD.RowNo = rowIndex + 1;
                            objPD.Value = myTextBoxList[k - 1].ToString();
                            objPD.SubDate = Session["SubDate"].ToString();
                           
                            lstPropertyDetail.Add(objPD);
                        }

                        rowIndex++;

                    }


                    
                   

                    //------------------------------------------------------------
                    //NB: For Amount Date  Save
                    //------------------------------------------------------------
                    if (Session["AmountDate"] != null)
                    {
                        if (grdAmountDate.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvr in grdAmountDate.Rows)
                            {
                                TextBox box1 = new TextBox();
                                box1 = (TextBox)gvr.Cells[1].FindControl("txtAmount_ad");

                                //int val = int.Parse(box1.Text);

                                TextBox box2 = new TextBox();
                                box2 = (TextBox)gvr.Cells[2].FindControl("txtDate_DT");
                                //string date = box2.Text;

                                ATTPropertyIncome objPInc = new ATTPropertyIncome();
                                objPInc.EmpID = int.Parse(Session["PrpEmpID"].ToString());
                                objPInc.PCatID = int.Parse(lstProperty.SelectedValue.ToString());
                                objPInc.SubDate = Session["SubDate"].ToString();
                                objPInc.Amount = Convert.ToDouble(box1.Text);
                                objPInc.Year = box2.Text;

                                lstPropertyIncome.Add(objPInc);
                            }
                        }
                    }

                    ATTPropertyDetails objPDToSave = new ATTPropertyDetails();
                    objPDToSave.LstPropertyDetails = lstPropertyDetail;
                    objPDToSave.LstPropertyIncome = lstPropertyIncome;


                    if (BLLPropertyDetails.SavePropertyDetails(objPDToSave))
                    {
                        ArrayList alreadySet = new ArrayList();

                        if (Session["alreadySet"] != null)
                            alreadySet = (ArrayList)Session["alreadySet"];


                        alreadySet.Add(lstProperty.SelectedValue);

                        Session["alreadySet"] = (object)alreadySet;
                        Session["AmountDate"] = null;
                        btnSave.Visible = false;

                        this.lblStatusMessageTitle.Text = "Save Status";

                        if (this.lblStatusMessageTitle.Text != "")
                        {
                            this.lblStatusMessage.Text = " Details for '" + lstProperty.SelectedItem + "' is saved successfully !!!";
                            this.programmaticModalPopup.Show();
                        }
                       
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void CallCreatGrid()
    {
        try
        {
                List<ATTPropertyCategory> lstPCat = (List<ATTPropertyCategory>)Session["PropertyCategoryList"];
                List<ATTPropertyCategoryColumns> lstPCatCols = (List<ATTPropertyCategoryColumns>)Session["PropertyCatColList"];

                ATTPropertyCategoryColumns objPCatCols = new ATTPropertyCategoryColumns();

                objPCatCols.LstPCatCols = lstPCatCols.FindAll(
                                                                    delegate(ATTPropertyCategoryColumns PCC)
                                                                    {
                                                                        return PCC.PCategoryID == int.Parse(this.lstProperty.SelectedValue);
                                                                    }
                                                               );

                if (objPCatCols.LstPCatCols.Count > 0)
                {
                    Session["rqd_lstPCatCols"] = objPCatCols.LstPCatCols;

                    if (CreateGrid(objPCatCols.LstPCatCols))
                    {

                        ATTPropertyCategory PC = lstPCat.Find(
                                                       delegate(ATTPropertyCategory PropCat)
                                                       {
                                                           return PropCat.PCategoryID == int.Parse(this.lstProperty.SelectedValue);
                                                       }

                                                   );

                        if (PC.Income == "Y")
                            CallCreateAmountDateGrid();
                        else
                        {
                            grdAmountDate.DataSource = null;
                            grdAmountDate.DataBind();
                        }

                        LoadColumnList();
                    }
                }
                else
                {
                    Session["rqd_lstPCatCols"] = null;
                    grdPropertyDetails.DataSource = null;
                    grdPropertyDetails.DataBind();

                    grdAmountDate.DataSource = null;
                    grdAmountDate.DataBind();

                    btnSave.Visible = false;
                }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void CallCreateAmountDateGrid()
    {
        try 
	    {
            Session["AmountDate"] = null;

            DataTable tbl = new DataTable();
            DataColumn col;

            col = new DataColumn();
            col.ColumnName = "col1";
            col.DataType = Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "col2";
            col.DataType = Type.GetType("System.Decimal");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "col3";
            //col.DataType = Type.GetType("System.Int32");
            col.DataType = Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "col4";
            col.DataType = Type.GetType("System.String"); ;
            tbl.Columns.Add(col);


            DataRow row = tbl.NewRow();

            row["Col1"] = "रु";
            row["Col2"] = 0.0;
            row["Col3"] = 0;
            row["Col4"] = "साल";

            tbl.Rows.Add(row);

            grdAmountDate.DataSource = tbl;
            grdAmountDate.DataBind();

            Session["AmountDate"] = tbl;
	    }
	    catch (Exception ex)
	    {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
	    }

    }

    public bool CreateGrid(List<ATTPropertyCategoryColumns> lstCatCols)
    {
        try
        {
            DataTable tbl = new DataTable();
            DataColumn col;

            DataRow row = tbl.NewRow();
            int i = 0;
            int j = 0;

            // NB: Dynamic Table column Creation
            foreach (ATTPropertyCategoryColumns CatCol in lstCatCols)
            {
                string dataType = "";

                switch (CatCol.ColDataType)
                {
                    case "N":
                        dataType = "System.Int32";
                        break;
                    case "C":
                        dataType = "System.String";
                        break;
                    case "D":
                        dataType = "System.Decimal";
                        break;
                    default:
                        dataType = "System.String";
                        break;
                }

                col = new DataColumn();
                col.ColumnName = CatCol.ColNo.ToString();
                col.DataType = Type.GetType(dataType);
                tbl.Columns.Add(col);

                j = j + 1;
            }

            if (j < 15)
            {
                while (j < 15)
                {
                    j = j + 1;

                    col = new DataColumn();
                    col.ColumnName = j.ToString();
                    col.DataType = Type.GetType("System.String");

                    tbl.Columns.Add(col);
                }
            }



            // NB: Dynamic Table row Creation

            foreach (ATTPropertyCategoryColumns CatCol in lstCatCols)
            {

                if (i == 0)
                    row[CatCol.ColNo.ToString()] = 1;
                else
                {

                    if (CatCol.ColDataType == "C")
                        row[CatCol.ColNo.ToString()] = "";
                    else if (CatCol.ColDataType == "N")
                        row[CatCol.ColNo.ToString()] = 0;
                    else if (CatCol.ColDataType == "D")
                        row[CatCol.ColNo.ToString()] = 0.0;

                }

                i = i + 1;
                if (i >= lstCatCols.Count)
                {
                    if (i < 15)
                    {
                        Session["PCatCount"] = i;
                        while (i < 15)
                        {
                            row[i.ToString()] = "";
                            i = i + 1;
                        }
                    }

                    tbl.Rows.Add(row);
                }

            }

            if (tbl.Rows.Count > 0)
            {

                grdPropertyDetails.DataSource = tbl;
                grdPropertyDetails.DataBind();
            }

            Session["grdPCat"] = tbl;

            return true;
     
        }
        catch (Exception ex)
        {

            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return false;
        }
       
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblStatus.Text = "";
    //        if (txtEmployeeNo_rqd.Text.ToString() != "")
    //        {
    //            int empID = int.Parse(txtEmployeeNo_rqd.Text.ToString());
    //            txtName_rqd.Text = "";
    //            txtOffice_rqd.Text = "";
    //            txtPost_rqd.Text = "";
    //            LoadEmpOrgInfo(empID);

    //            txtSubDate_RDT.Text = "";
    //            txtSubOffPlace_rqd.Text = "";
    //            drpOrganisation_rqd.SelectedIndex = -1;
    //            txtSubDate_RDT.ReadOnly = false;
    //            txtSubOffPlace_rqd.ReadOnly = false;
    //            drpOrganisation_rqd.Enabled = true;

    //            lstProperty.SelectedIndex = -1;
    //            grdPropertyDetails.DataSource = null;
    //            grdPropertyDetails.DataBind();

    //            grdAmountDate.DataSource = null;
    //            grdAmountDate.DataBind();
    //            btnSave.Visible = false;
                
    //            Session["SetSubDate"] = false;
    //            Session["SubDate"] = null;
    //            Session["alreadySet"] = null;
    //            Session["AmountDate"] = null;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblStatusMessageTitle.Text = "Error Status";
    //        this.lblStatusMessage.Text = ex.Message;
    //        this.programmaticModalPopup.Show();
    //    }
    // }

    protected void grdAmountDate_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (GridViewRow gvr in grdAmountDate.Rows)
            {
                //TextBox box1 = new TextBox();
                TextBox box1 = (TextBox)gvr.Cells[1].FindControl("txtAmount_ad");

                TextBox box2 = (TextBox)gvr.Cells[2].FindControl("txtDate_DT");

                if (box1.Text == "")
                {
                    box1.Text = "0.0";
                    box1.MaxLength = 10;
                    //box1.CssClass = "grdTxtBox";
                }

                if (box2.Text == "")
                {
                    box2.Text = "0";
                }

            }
        }
    }

    protected void grdAmountDate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((TextBox)e.Row.FindControl("txtAmount_ad")).Attributes.Add("onkeypress", "return DecimalOnly(event,this)");

            ((TextBox)e.Row.FindControl("txtDate_DT")).Attributes.Add("onkeypress", "return NumberOnly(event,this)");
           
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["AmountDate"] != null)
            {
                int rowIndex = 0;
                DataTable dt = (DataTable)Session["AmountDate"];
                DataRow dr = null;

                if (dt.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in grdAmountDate.Rows)
                    {
                        dr = dt.Rows[rowIndex];
                        for (int k = 0; k < 4; k++)
                        {
                            if (k == 1)
                            {
                                TextBox box1 = new TextBox();
                                box1 = (TextBox)gvr.Cells[1].FindControl("txtAmount_ad");

                                if (box1.Text == "")
                                {
                                    dr["col2"] = 0.0;
                                }
                                else
                                    dr["col2"] = Convert.ToDouble(box1.Text.ToString());
                            }
                            else if (k == 2)
                            {
                                TextBox box2 = new TextBox();
                                box2 = (TextBox)gvr.Cells[2].FindControl("txtDate_DT");

                                if (box2.Text == "")
                                {
                                    dr["col3"] = 0;
                                }
                                else
                                    dr["col3"] = box2.Text.ToString();
                                   // dr["col3"] = int.Parse(box2.Text.ToString());

                            }
                        }

                        dr.AcceptChanges();
                        rowIndex++;
                    }

                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }

                Session["AmountDate"] = dt;
                // Add DataTable back to grid
                grdAmountDate.DataSource = dt;
                grdAmountDate.DataBind();

                setPreviousAmountDateDetails();
            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void setPreviousAmountDateDetails()
    {
        try
        {
            if (Session["AmountDate"] != null)
            {
                int rowIndex = 0;
                DataTable dt = (DataTable)Session["AmountDate"];
                DataRow dr = null;

                if (dt.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in grdAmountDate.Rows)
                    {
                        dr = dt.Rows[rowIndex];

                        TextBox box1 = new TextBox();
                        box1 = (TextBox)gvr.Cells[1].FindControl("txtAmount_ad");
                        box1.Text = dr["col2"].ToString() ;

                        TextBox box2 = new TextBox();
                        box2 = (TextBox)gvr.Cells[2].FindControl("txtDate_DT");
                        box2.Text = dr["col3"].ToString();

                        rowIndex++;
                    }
                }


            }
        }
        catch (Exception ex)
        {
            this.lblStatusMessageTitle.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdPropertyDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
