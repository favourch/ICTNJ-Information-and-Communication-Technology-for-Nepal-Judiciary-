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
using PCS.CMS.BLL;
using PCS.CMS.ATT;
using PCS.SECURITY.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

using System.Collections.Generic;
using System.Reflection;

using PCS.FRAMEWORK;
using AjaxControlToolkit;

public partial class MODULES_CMS_Tarikh_Tarikh : System.Web.UI.Page
{


    int courtID = 9;
    string entryBy = "Suman";
    int userID = 8;
      
    
    


    public List<ATTAttorney> ALLAttorneyLIST
    {
        get { return (Session["ALLAttorneyLIST"] == null) ? new List<ATTAttorney>() : (List<ATTAttorney>)Session["ALLAttorneyLIST"]; }
        set { Session["ALLAttorneyLIST"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsLIST
    {
        get { return (Session["LitigantsLIST"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsLIST"]; }
        set { Session["LitigantsLIST"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsAppelant
    {
        get { return (Session["LitigantsAppelant"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsAppelant"]; }
        set { Session["LitigantsAppelant"] = value; }
    }
    public List<ATTLitigantSearch> LitigantsRespondant
    {
        get { return (Session["LitigantsRespondant"] == null) ? new List<ATTLitigantSearch>() : (List<ATTLitigantSearch>)Session["LitigantsRespondant"]; }
        set { Session["LitigantsRespondant"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.pnlMain.Visible = false;
            
            this.panel1.Visible = false;
            this.addBtnDiv.Visible = false;
            
           
          
        }
    }

    private void GetAllLitigants(int caseID)
    {

        try
        {
            ATTLitigantSearch obj = new ATTLitigantSearch();
            obj.CourtID = courtID;
            obj.CaseID = caseID;
            List<ATTLitigantSearch> lstLitigants = BLLLitigantSearch.GetLitigantSearch(obj);

            LitigantsLIST = lstLitigants;
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }
    private void GetAllAttorney(int caseID)
    {
        try
        {
            List<ATTAttorney> lst = BLLAttorney.GetAttorney(caseID, "Y");
            ALLAttorneyLIST = lst;
        }
        catch (Exception ex)
        {

            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }

    }

    private void LoadLitigants()
    {

        if (LitigantsLIST.Count > 0)
        {

            List<ATTLitigantSearch> lstLITT = LitigantsLIST;

            List<ATTLitigantSearch> lstApp = lstLITT.FindAll(
                                                                   delegate(ATTLitigantSearch litg)
                                                                   {
                                                                       return (litg.LitigantType == "A");
                                                                   }
                                                               );
            LitigantsAppelant = lstApp;
            grdLitigantsApp.DataSource = LitigantsAppelant;
            grdLitigantsApp.DataBind();
            if (lstApp.Count == 0) pnlApp.Height = Unit.Pixel(5);
            else pnlApp.Height = Unit.Pixel(200);


            List<ATTLitigantSearch> lstRes = lstLITT.FindAll(
                                                                 delegate(ATTLitigantSearch litg)
                                                                 {
                                                                     return (litg.LitigantType == "R");
                                                                 }
                                                             );
            LitigantsRespondant = lstRes;
            grdLitigantRes.DataSource = LitigantsRespondant;
            grdLitigantRes.DataBind();
            if (lstRes.Count == 0) pnlRes.Height = Unit.Pixel(5);
            else pnlRes.Height = Unit.Pixel(200);
        }
        else
        {
            grdLitigantsApp.DataSource = null;
            grdLitigantsApp.DataBind();
            grdLitigantRes.DataSource = null;
            grdLitigantRes.DataBind();
            pnlApp.Height = Unit.Pixel(5);
            pnlRes.Height = Unit.Pixel(5);
        }
    }
    private List<ATTAttorney> GetAttorneyByLitigantID(int litigantID)
    {
        List<ATTAttorney> lst = ALLAttorneyLIST;
        return lst.FindAll(
                                delegate(ATTAttorney obj)
                                {
                                    return (obj.LitigantID == litigantID && obj.ToDate == "");
                                }
                           );
    }





   

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void grdLitigantsApp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (LitigantsAppelant.Count > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].Width = Unit.Pixel(200);
            e.Row.Cells[9].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[12].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "<pre>        </pre>";



            int litigantID = int.Parse(e.Row.Cells[2].Text);

            // GridView grd1 = (GridView)(((Panel)e.Row.FindControl("pnlAttorney1")).FindControl("grdAttorney1"));
            GridView grd1 = (GridView)e.Row.FindControl("grdAttorney1");
            grd1.DataSource = GetAttorneyByLitigantID(litigantID);
            grd1.DataBind();
            this.panel1.Visible = true;




        }

    }
   
   
    protected void grdLitigantsRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (LitigantsRespondant.Count > 0)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[9].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[7].Text;
            string isPrisoned = e.Row.Cells[12].Text;

            if (gender == "M") e.Row.Cells[7].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[7].Text = "महिला";
            else e.Row.Cells[7].Text = "अन्य";

            e.Row.Cells[13].Text = (isPrisoned == "Y") ? "थुनुवा" : "<pre>        </pre>";



            int litigantID = int.Parse(e.Row.Cells[2].Text);

            //GridView grd1 = (GridView)(((Panel)e.Row.FindControl("pnlAttorney")).FindControl("grdAttorney"));
            GridView grd1 = (GridView)e.Row.FindControl("grdAttorney");


            grd1.DataSource = GetAttorneyByLitigantID(litigantID);
            grd1.DataBind();



        }
    }
   
    protected void grdAttorney_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message.ToString();
            this.programmaticModalPopup.Show();
        }



    }
    protected void grdTamWitPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string gender = e.Row.Cells[5].Text;

            if (gender == "M") e.Row.Cells[5].Text = "पुरुष";
            else if (gender == "F") e.Row.Cells[5].Text = "महिला";
            else e.Row.Cells[6].Text = "अन्य";
        }


    }
    

  
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }
    private void WebForm1_BubbleClick(object sender, EventArgs e)
    {
        //Response.Write("WebForm1 :: WebForm1_BubbleClick from " +
        //               sender.GetType().ToString() + "<BR>");

        int caseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);


        //Session["CaseID"] = caseID;
        GetAllAttorney(caseID);
        
        GetTarikh();
     

        GetAllLitigants(caseID);
        LoadLitigants();
        this.pnlMain.Visible = true;
        this.addBtnDiv.Visible = true;
        
        Session["TarikhList1"] = Session["Tarikh"];

        
        


    }

   
    private void WebForm1_BubbleClickBtn(object sender, EventArgs e)
    {
        if (((GridView)CaseSearch1.FindControl("grdCase")).Rows.Count < 1)
        {
            grdLitigantsApp.DataSource = null;
            grdLitigantRes.DataSource = null;
            grdLitigantsApp.DataBind();
            grdLitigantRes.DataBind();
        }



        this.pnlMain.Visible = false;
        this.addBtnDiv.Visible = false;

    }
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        CaseSearch1.BubbleClick += new EventHandler(WebForm1_BubbleClick);
        CaseSearch1.BubbleClickBtn += new EventHandler(WebForm1_BubbleClickBtn);

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        TarikhFunction();
      

        if (this.tarikhGrid.SelectedIndex > -1)
        {
            List<ATTTarikh> tarikhDetailsList = (List<ATTTarikh>)Session["TarikhList"];
            List<ATTTarikh> tarikhList = (List<ATTTarikh>)Session["Tarikh"];

            foreach (ATTTarikh objT in tarikhDetailsList)
            {
                if (objT.Action != "A" && objT.Action!="R")
                {
                    objT.Action = "E";
                }
            }

            for (int i = 0; i < tarikhListGrid.Rows.Count;i++ )
            {
                int index = tarikhDetailsList.FindIndex
                (   
                        delegate(ATTTarikh obj1)
                        {
                            return (obj1.PersonID ==Convert.ToInt32(this.tarikhListGrid.DataKeys[i].Values["PersonID"]));
                        }
                    );
                tarikhDetailsList[index].TakenTime = ((TextBox)tarikhListGrid.Rows[i].FindControl("takenDateTxtEdit")).Text;
                tarikhDetailsList[index].PresentDate = ((TextBox)tarikhListGrid.Rows[i].FindControl("presentDateTxtEdit")).Text;
                tarikhDetailsList[index].TarikhDate = tarikhGrid.SelectedRow.Cells[0].Text;
            }

            try
            {
                if (BLLTarikh.AddTarikh(tarikhList) && BLLTarikh.AddTarikhDetails(tarikhDetailsList))
                {
                    lblStatusMessage.Text = "Save Successful";
                    this.programmaticModalPopup.Show();
                }

            }
            catch (Exception ex)
            {
                lblStatusMessage.Text = "Problem while saving data" + ex.Message;
                this.programmaticModalPopup.Show();
            }


            ClearControls();
            GetTarikh();

        }
        else
        {
            this.lblStatusMessage.Text = "Please select Tarikh";
            this.programmaticModalPopup.Show();
        }

    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();

    }

    protected void ClearControls()
    {
        
        foreach (GridViewRow grow in grdLitigantsApp.Rows)
        {
            CheckBox cb = (CheckBox)grow.FindControl("chk");
            cb.Checked = false;
            {

            }
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney1")).Rows)
            {
                CheckBox cb1 = (CheckBox)grow1.FindControl("chk");
                cb1.Checked = false;
            }
        }

        foreach (GridViewRow grow in grdLitigantRes.Rows)
        {
            CheckBox cb = (CheckBox)grow.FindControl("chkRes");
            cb.Checked = false;

            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney")).Rows)
            {
                CheckBox cb1 = (CheckBox)grow1.FindControl("chk");
                cb1.Checked = false;
            }
        }


        tarikhDateTxt.Text = "";
        tarikhTimeTxt.Text = "";
        tarikhGrid.DataSource = null;
        tarikhDateTxt.Enabled = true;
        tarikhGrid.SelectedIndex = -1;
        tarikhListGrid.DataBind();
    }



    protected void addBtn_Click(object sender, EventArgs e)
    {
        List<ATTTarikh> lstTarikh = (List<ATTTarikh>)Session["TarikhList"];
        if (tarikhGrid.SelectedIndex<0)
            lstTarikh = new List<ATTTarikh>();
       

        foreach (GridViewRow grow in grdLitigantsApp.Rows)
        {
            if (((CheckBox)grow.FindControl("chk")).Checked)
            {
                ATTTarikh obj = new ATTTarikh();

                obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                obj.PersonID = int.Parse(grow.Cells[2].Text.Trim());
                obj.PersonType = "S";
                obj.PersonName = grow.Cells[6].Text;
                obj.Action = "A";
                lstTarikh.Add(obj);

            }
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney1")).Rows)
            {
                if (((CheckBox)grow1.FindControl("chk")).Checked)
                {
                    ATTTarikh obj = new ATTTarikh();
                    obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                    obj.PersonID = int.Parse(grow1.Cells[2].Text.Trim());
                    obj.PersonType = "W";
                    obj.Action = "A";
                    obj.PersonName = grow1.Cells[8].Text;

                    lstTarikh.Add(obj);
                }
            }
        }

        foreach (GridViewRow grow in grdLitigantRes.Rows)
        {
            if (((CheckBox)grow.FindControl("chkRes")).Checked)
            {
                ATTTarikh obj = new ATTTarikh();
                obj.CaseID = int.Parse(grow.Cells[1].Text.Trim());
                obj.PersonID = int.Parse(grow.Cells[2].Text.Trim());
                obj.PersonType = "S";
                obj.Action = "A";
                obj.PersonName = grow.Cells[6].Text;
                lstTarikh.Add(obj);
            }
            foreach (GridViewRow grow1 in ((GridView)grow.FindControl("grdAttorney")).Rows)
            {
                if (((CheckBox)grow1.FindControl("chk")).Checked)
                {
                    ATTTarikh obj = new ATTTarikh();
                    obj.CaseID = int.Parse(grow1.Cells[0].Text.Trim());
                    obj.PersonID = int.Parse(grow1.Cells[2].Text.Trim());
                    obj.PersonType = "W";
                    obj.Action = "A";
                    obj.PersonName = grow1.Cells[8].Text;
                    
                    lstTarikh.Add(obj);
                }
            }
        }

        //throw error if none of the litigants are selected
        if (lstTarikh.Count==0)
        {
            lblStatusMessage.Text = "No data selected";
            this.programmaticModalPopup.Show();
            return;
        }

        

        if (lstTarikh.Count > 0)
        {
            
            //removing multiple occurences of person_id in case of attorney
            foreach (ATTTarikh obj in lstTarikh)
            {
                int personId = obj.PersonID;
                int count = 0;

                obj.EntryBy = entryBy;
                for (int i = 0; i < lstTarikh.Count; i++)
                {
                    if (personId == lstTarikh[i].PersonID)
                       {
                           count++;
                        if (count > 1)
                        {
                            lstTarikh[i].Action = "Rem";
                        }
                    }
                }
            }
        }

      
       
       
        lstTarikh.RemoveAll(
            delegate(ATTTarikh obj)
            {
                return obj.Action == "Rem";
            }

            );
        
        Session["TarikhList"] = lstTarikh;
        tarikhListGrid.DataSource = lstTarikh;
        tarikhListGrid.DataBind();

    }
    //protected void tarikhDetailsGrid_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridViewRow row = ((GridView)sender).SelectedRow;

    //    if (row == null) return;

    //    ModalPopupExtender Extender = row.FindControl("extPerson") as ModalPopupExtender;


    //    if (Extender != null)
    //    {
    //        Extender.Show();
    //    }
    //}

  
    //protected void tarikhDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    e.Row.Cells[0].Visible = false;
    //}
    //protected void tarikhListGrid_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    this.tarikhListGrid.EditIndex = e.NewEditIndex;
    //    this.tarikhListGrid.DataSource = (List<ATTTarikh>)Session["TarikhList"];
    //    this.tarikhListGrid.DataBind();
    //}
    //protected void tarikhListGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    this.tarikhListGrid.EditIndex = -1;
    //    this.tarikhListGrid.DataSource = (List<ATTTarikh>)Session["TarikhList"];
    //    this.tarikhListGrid.DataBind();
    //}
    //protected void tarikhListGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    List<ATTTarikh> tarikhLst=(List<ATTTarikh>)Session["TarikhList"];
    //    int personId = Convert.ToInt32(this.tarikhListGrid.DataKeys[(e.RowIndex)].Values["PersonID"]);

    //    int index = tarikhLst.FindIndex
    //    (
    //        delegate(ATTTarikh obj)
    //        {
    //            return obj.PersonID == personId;

    //        }
    //    );

        
    //    tarikhLst[index].TakenTime = ((TextBox)tarikhListGrid.Rows[e.RowIndex].Cells[1].FindControl("takenDateTxtEdit")).Text;
    //    tarikhLst[index].PresentDate = ((TextBox)tarikhListGrid.Rows[e.RowIndex].Cells[2].FindControl("presentDateTxtEdit")).Text;
    //    tarikhLst[index].Action = "E";
    //    Session["TarikhList"] = tarikhLst;
    //    this.tarikhListGrid.EditIndex = -1;
    //    this.tarikhListGrid.DataSource = (List<ATTTarikh>)Session["TarikhList"];
    //    this.tarikhListGrid.DataBind();





    //}
    protected void saveTarikhListBtn_Click(object sender, EventArgs e)
    {
        if (this.tarikhGrid.SelectedIndex > -1)
        {
            
            ATTTarikh tarikh=new ATTTarikh();
            List<ATTTarikh> listTarikh = new List<ATTTarikh>();
           
            tarikh.CaseID=int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
            tarikh.TarikhDate = tarikhGrid.SelectedRow.Cells[0].Text;
            tarikh.TarikhTime =((TextBox)tarikhGrid.SelectedRow.FindControl("tarikhTimeTxt")).Text;
            tarikh.Action="E";

        
        List<ATTTarikh> tarikhLst = (List<ATTTarikh>)Session["TarikhList"];
        try
        {
            BLLTarikh.AddTarikhDetails(tarikhLst);
            BLLTarikh.AddTarikh(listTarikh);
            lblStatusMessage.Text = "Tarikh List Updated Successfully";
            this.programmaticModalPopup.Show();
            return;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Tarikh List Could not be updated " + ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    }

    protected void GetTarikh()
    {
        int caseId=int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
        List<ATTTarikh> lst = BLLTarikh.GetTarikh(caseId);
        Session["Tarikh"] = lst;
        tarikhGrid.DataSource = lst;
        tarikhGrid.DataBind();
    }

    
    protected void GetTarkihList(int caseId, string tarikhDate)
    {

        List<ATTTarikh> tarikhList = BLLTarikh.GetTarikhDetails(caseId, tarikhDate);
        Session["TarikhList"] = tarikhList;
        this.tarikhListGrid.DataSource = tarikhList;
        this.tarikhListGrid.DataBind();

    }
    protected void tarikhGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        tarikhDateTxt.Enabled = true;
        int caseId = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
        string tarikhDate = tarikhGrid.SelectedRow.Cells[0].Text;
        GetTarkihList(caseId, tarikhDate);
        tarikhDateTxt.Text = tarikhDate;
        tarikhTimeTxt.Text = tarikhGrid.SelectedRow.Cells[1].Text;

        List<ATTTarikh> lst = (List<ATTTarikh>)Session["Tarikh"];
        if (lst[this.tarikhGrid.SelectedIndex].Action != "A")
        {
            tarikhDateTxt.Enabled = false;
        }
        
        
    }
    protected void tarikhListGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         List<ATTTarikh> tarikhLst = new List<ATTTarikh>();
        

        if (Session["TempTarikhList"]== null)
        {
            tarikhLst = (List<ATTTarikh>)Session["TarikhList"];
        }
        else
        {
           tarikhLst = (List<ATTTarikh>)Session["TempTarikhList"];
        }

            int personId = Convert.ToInt32(this.tarikhListGrid.DataKeys[(e.RowIndex)].Values["PersonID"]);

            int index = tarikhLst.FindIndex
            (
                delegate(ATTTarikh obj)
                {
                    return obj.PersonID == personId;
                }
            );

            List<ATTTarikh> newList = (List<ATTTarikh>)Session["TarikhList"];
            int index1 = newList.FindIndex
               (
                   delegate(ATTTarikh obj)
                   {
                       return obj.PersonID == personId;
                   }
               );

            tarikhLst[index].Action = "R";
          
            newList[index1].Action = "R";
            Session["TarikhList"] = newList;

            this.tarikhListGrid.EditIndex = -1;

            List<ATTTarikh> tempList = new List<ATTTarikh>();
            tempList.AddRange(tarikhLst);
            tempList.RemoveAt(index);
            this.tarikhListGrid.DataSource = tempList;
            Session["TempTarikhList"] = tempList;
            this.tarikhListGrid.DataBind();
        
    }

    protected void TarikhFunction()
    {
        if (tarikhGrid.SelectedIndex < 0)
        {
            if (tarikhDateTxt.Text == "")
            {
                this.lblStatusMessage.Text = "कृपया तारिख मिति राख्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }

            List<ATTTarikh> lst = (List<ATTTarikh>)Session["Tarikh"];
            ATTTarikh obj = new ATTTarikh();
            obj.TarikhDate = tarikhDateTxt.Text;
            obj.TarikhTime = tarikhTimeTxt.Text;
            obj.CaseID = int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
            obj.Action = "A";
            obj.EntryBy = entryBy;
            lst.Add(obj);
            tarikhGrid.DataSource = lst;
            tarikhGrid.DataBind();
            tarikhGrid.SelectedIndex = tarikhGrid.Rows.Count - 1;
            Session["TarikhList1"] = lst;
        }
        else if (tarikhGrid.SelectedIndex > -1)
        {
            List<ATTTarikh> lst = (List<ATTTarikh>)Session["Tarikh"];
            lst[this.tarikhGrid.SelectedIndex].TarikhTime = tarikhTimeTxt.Text;
            lst[this.tarikhGrid.SelectedIndex].CaseID= int.Parse(((GridView)CaseSearch1.FindControl("grdCase")).SelectedRow.Cells[2].Text);
            lst[this.tarikhGrid.SelectedIndex].Action = "E";
            tarikhGrid.DataSource = lst;
            tarikhGrid.DataBind();
            
            Session["TarikhList1"] = lst;
        }
    }

    protected void ClearTarikh()
    {
        this.tarikhDateTxt.Text = "";
        this.tarikhDateTxt.Enabled = true;
        this.tarikhTimeTxt.Text = "";
        this.tarikhGrid.SelectedIndex = -1;
        this.tarikhListGrid.DataBind();
    }
}
