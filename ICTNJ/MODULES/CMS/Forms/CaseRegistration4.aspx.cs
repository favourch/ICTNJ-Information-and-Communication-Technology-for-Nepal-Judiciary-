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

using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;

public class DocFup
{
    private FileUpload _FUP;
    public FileUpload FUP
    {
        get { return _FUP; }
        set { _FUP = value; }
    }

    private int _DocSeq;

    public int DocSeq
    {
        get { return _DocSeq; }
        set { _DocSeq = value; }
    }
	

    private string _FileName;
    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    private byte[] _FileContents;
    public byte[] FileContents
    {
        get { return _FileContents; }
        set { _FileContents = value; }
    }


	
	
}

public partial class MODULES_CMS_Forms_CaseRegistration4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack == false)
        {
           
                Session["Evidence"] = new List<ATTCaseEvidence>();
                Session["SEQ"] = 1;

              
            Session["Evidence"] = new List<ATTCaseEvidence>();
            Session["BindToGrid"] = new List<DocFup>();
            Session["CaseDocuments"]=new List<ATTCaseDocuments>();
            Session["LitDocuments"] = new List<ATTCaseDocumentsLit>();

            List<DocFup> fupLST = (List<DocFup>)Session["BindToGrid"];
            DocFup dFup = new DocFup();
            dFup.FUP = new FileUpload();
            fupLST.Add(dFup);
            
            this.grdDocuments.DataSource = fupLST;
            this.grdDocuments.DataBind();

            if (Session["CaseNo"] != null)
            {
                this.txtCaseNo.Text = Session["CaseNo"].ToString();
                Session["CaseNo"] = null;
                LoadCaseRegistrationDetails(double.Parse(this.txtCaseNo.Text), sender, e);
            }
                
        }
    }

    public void LoadCaseDocuments()
    {
        
    }

    public ATTCaseRegistration LoadCaseRegistrationDetails(double caseNo, object sender, EventArgs e)
    {
        ATTCaseRegistration objCR = ((List<ATTCaseRegistration>)BLLCaseRegistration.GetCaseRegistration(caseNo, 1,0, 1, 0, 0, 1, 1, 1, 0, null))[0];


        lblCaseNo.Text = objCR.CaseID.ToString();
        //Case Details
        this.lblCaseType.Text = objCR.CaseTypeName;
        this.lblRegType.Text = objCR.RegTypeName;
        this.lblRegDiary.Text = objCR.RegDiaryName;
        this.lblRegSubject.Text = objCR.RegSubjectName;
        this.lblRegSubName.Text = objCR.RegDiarySubName;
        this.lblRegDate.Text = objCR.CaseRegistrationDate;
        this.lblPreceedingType.Text = objCR.ProceedingType;
        this.lblForwardToAccount.Text = objCR.AccountForwarded == "Y" ? "पठाउने" : "नपठाउने";



        Session["Appellant"] = objCR.AppellantLST;
        Session["Respondant"] = objCR.RespondantLST;

        this.grdAppellant.DataSource = objCR.AppellantLST;
        this.grdAppellant.DataBind();

        this.grdRespondant.DataSource = objCR.RespondantLST;
        this.grdRespondant.DataBind();

        this.heCaseSummary.Text = objCR.CaseSummary;

        this.grdEvidence.DataSource = objCR.CaseEvidenceLST;
        this.grdEvidence.DataBind();
        Session["Evidence"] = objCR.CaseEvidenceLST;

        this.grdLitDocument.DataSource = objCR.CaseDocumentLitLST;
        this.grdLitDocument.DataBind();
        Session["LitDocuments"] = objCR.CaseDocumentLitLST;

        return objCR;
    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        ATTCaseRegistration objCR = new ATTCaseRegistration();
        objCR.CaseID = double.Parse(this.lblCaseNo.Text);
        objCR.CaseSummary = this.heCaseSummary.Text;
        objCR.Action = "E";

        //ADDS CASE EVIDENCE TO THE LIST
        ATTCaseEvidence objCaseEvidence;// = new ATTCaseEvidence();
        foreach (GridViewRow    gvRow    in this.grdEvidence.Rows)
        {
            if (CheckNull.NullString(gvRow.Cells[2].Text) != "")
            {
                objCaseEvidence = new ATTCaseEvidence();
                objCaseEvidence.CaseID = double.Parse(this.lblCaseNo.Text);
                objCaseEvidence.EvidenceID = int.Parse(gvRow.Cells[0].Text);
                objCaseEvidence.Evidence = gvRow.Cells[1].Text;
                objCaseEvidence.EntryBy = user.UserName;
                objCaseEvidence.Action = gvRow.Cells[2].Text;

                objCR.CaseEvidenceLST.Add(objCaseEvidence);
            }
        }

        //ADDS CASE DOCUMENTS
        List<ATTCaseDocuments> CDocLST = (List<ATTCaseDocuments>)Session["CaseDocuments"];
        //List<ATTCaseDocuments> CaseDocLST = new List<ATTCaseDocuments>();
        //ATTCaseDocuments CaseDocOBJ;
        //foreach (DocFup obj in CDocLST)
        //{
        //    CaseDocOBJ = new ATTCaseDocuments();
        //    CaseDocOBJ.CaseID = double.Parse(lblCaseNo.Text);
        //    CaseDocOBJ.DocSeq = obj.DocSeq;
        //    CaseDocOBJ.DocumentID = 0;
        //    CaseDocOBJ.DocumentFileName = obj.FileName;
        //    CaseDocOBJ.DocumentContent = obj.FileContents;
        //    CaseDocOBJ.EntryBy = "manoz";
        //    CaseDocOBJ.Action = "A";

        //    CaseDocLST.Add(CaseDocOBJ);

        //}
        CDocLST.RemoveAll(delegate(ATTCaseDocuments obj)
                            {
                                return obj.DocumentFileName == null;
                            });
        objCR.CaseDocumentLST = CDocLST;

        //ADDS CASE LITIGANT DOCUMENTS
        List<ATTCaseDocumentsLit> CaseDocLitLST = (List<ATTCaseDocumentsLit>)Session["LitDocuments"];
        CaseDocLitLST.RemoveAll(delegate(ATTCaseDocumentsLit obj)
                                {
                                    return obj.Action =="";
                                });
        objCR.CaseDocumentLitLST = CaseDocLitLST;

        if (BLLCaseRegistration.UpdateCaseSummary(objCR) == true)
        {
            Session["CaseNo"] = this.txtCaseNo.Text;
            Response.Redirect("CaseRegistrationInfo.aspx");
        }


        
    }
    protected void btnAddEvidence_Click(object sender, EventArgs e)
    {
        if (this.txtEvidence.Text == "")
        {
            this.lblStatusMessage.Text = "Evidence Can't Be Blank";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        List<ATTCaseEvidence> EvidenceLST = (List<ATTCaseEvidence>)Session["Evidence"];
        
        if (this.grdEvidence.SelectedIndex == -1)
        {
            ATTCaseEvidence objEvidence = new ATTCaseEvidence();
            objEvidence.CaseID = 1;// double.Parse(this.lblCaseNo.Text);
            objEvidence.EvidenceID = 0;
            objEvidence.Evidence = this.txtEvidence.Text;
            objEvidence.EntryBy = user.UserName;
            objEvidence.Action = "A";
            EvidenceLST.Add(objEvidence);
        }
        else
        {

            EvidenceLST[this.grdEvidence.SelectedIndex].Evidence = this.txtEvidence.Text;
            EvidenceLST[this.grdEvidence.SelectedIndex].Action = "E";
        }
        
        this.grdEvidence.DataSource = EvidenceLST;
        this.grdEvidence.DataBind();

        this.grdEvidence.SelectedIndex = -1;

        this.txtEvidence.Text = "";

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        GridViewInsert();
    }
    protected void btnMinus_Click(object sender, EventArgs e)
    {

    }
    protected void grdCourtFee_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    
    protected void GridViewInsert()
    {

        int seq = int.Parse(Session["SEQ"].ToString());
        List<DocFup> fupLST = (List<DocFup>)Session["BindToGrid"];
        DocFup dFup = fupLST[fupLST.Count - 1];

        
        FileUpload fup;
        
        fup = (FileUpload)this.grdDocuments.Rows[this.grdDocuments.Rows.Count - 1].FindControl("fupDocuments");
        //dFup.FUP = fup;
        if (fup.HasFile != true)
        {
            this.lblStatusMessage.Text = "Documents Not Attached For Last Row";
            this.programmaticModalPopup.Show();
            return;
        }
        dFup.FileName =fup.FileName;
        dFup.FileContents = fup.FileBytes;
        dFup.DocSeq = seq;
        
        fupLST.Add(new DocFup());
        grdDocuments.DataSource = fupLST;
        grdDocuments.DataBind();

        seq += 1;
        Session["SEQ"] = seq;
       Session["BindToGrid"] = fupLST;
    }
    protected void grdCourtFee_DataBound(object sender, EventArgs e)
    {
        int sno = 1;
        Label lbl;
        FileUpload fup;
        foreach (GridViewRow gvRow in this.grdDocuments.Rows)
        {
            lbl = (Label)gvRow.FindControl("lblSNo");
            lbl.Text = "कागज-पत्र " + sno.ToString();
            if (sno < this.grdDocuments.Rows.Count)
            {
                fup = (FileUpload)gvRow.FindControl("fupDocuments");
                fup.Enabled = false;
            }

            sno += 1;

            
        }
    }

    protected void imgDelDocuments_Click(object sender, ImageClickEventArgs e)
    {
        List<DocFup> fupLST = (List<DocFup>)Session["BindToGrid"];
        int i = int.Parse(((ImageButton)sender).CommandName);
        if (i != this.grdDocuments.Rows.Count - 1)
            fupLST.RemoveAt(i);

        this.grdDocuments.DataSource = fupLST;
        this.grdDocuments.DataBind();
    }
    protected void grdDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            ((ImageButton)e.Row.FindControl("imgDelDocuments")).CommandName = e.Row.RowIndex.ToString();
    }
    protected void btnAddLitDoc_Click(object sender, EventArgs e)
    {
        //int seq=1;

        #region "VALIDATES LITIGANT DOCUMENTS"
        //CHECKS IF THE LAST ROW OF THE DOCUMENT GRID IS ADDED OR NOT
        if (((FileUpload)grdDocuments.Rows[this.grdDocuments.Rows.Count - 1].FindControl("fupDocuments")).HasFile == true)
        {
            this.lblStatusMessage.Text = "Last Document Has Not Been Added To The List";
            this.programmaticModalPopup.Show();
            return;
        }

        //CHECKS EITHER ONLY OF APPELLANT OR RESPONDANT IS SELECTED
        int cntAppellant = 0;
        int cntRespondant = 0;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                cntAppellant += 1;
            }
        }

        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                cntRespondant += 1;
            }
        }

        if (cntAppellant == 0 && cntRespondant==0)
        {
            this.lblStatusMessage.Text = "Please Select Either Appellant or Respondant to assign Lawyer";
            this.programmaticModalPopup.Show();
            return;
        }

        if (cntAppellant > 0 && cntRespondant > 0)
        {
            this.lblStatusMessage.Text = "Both Appellant or Respondant Can't Be Selected At the Same Time";
            this.programmaticModalPopup.Show();
            return;
        }
        #endregion


        //INITITALIZING OBJECTS
        List<DocFup> fupLST = (List<DocFup>)Session["BindToGrid"];
        List<ATTCaseDocuments> CaseDocLST = (List<ATTCaseDocuments>)Session["CaseDocuments"];
        ATTCaseDocuments objCaseDoc;
        List<ATTCaseDocumentsLit> CaseDocLitLST = (List<ATTCaseDocumentsLit>)Session["LitDocuments"];
        ATTCaseDocumentsLit objCaseDocLit;
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        
        //PREPARING CASE DOCUMENTS
        foreach (DocFup obj in fupLST)
        {
            objCaseDoc = new ATTCaseDocuments();
            objCaseDoc.CaseID = double.Parse(lblCaseNo.Text);
            objCaseDoc.DocSeq = obj.DocSeq;
            objCaseDoc.DocumentID = 0;
            objCaseDoc.DocumentFileName = obj.FileName;
            objCaseDoc.DocumentContent = obj.FileContents;
            objCaseDoc.EntryBy =user.UserName;
            objCaseDoc.Action = "A";

            CaseDocLST.Add(objCaseDoc);
        }


        //ADDING DOCUMENTS FOR APPELLANTS
        int documentRowCount = 0;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            documentRowCount = 0;

            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                foreach (DocFup obj in fupLST)
                {
                    if (documentRowCount < fupLST.Count - 1)
                    {
                        objCaseDocLit = new ATTCaseDocumentsLit();
                        objCaseDocLit.CaseID = double.Parse(this.lblCaseNo.Text);
                        objCaseDocLit.LitigantID = double.Parse(gvRow.Cells[1].Text);
                        objCaseDocLit.LitType = "A";
                        objCaseDocLit.LitigantName = gvRow.Cells[2].Text;

                        objCaseDocLit.DocSeq = obj.DocSeq;
                        objCaseDocLit.FileName = obj.FileName;
                        //objCaseDoc.DocumentFile = obj.FileContents;
                        objCaseDocLit.Action = "A";
                        objCaseDocLit.EntryBy = user.UserName;

                        CaseDocLitLST.Add(objCaseDocLit);

                        documentRowCount += 1;
                    }


                }
            }
        }


        //ADDING DOCUMENTS FOR RESPONDANTS
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            if (((CheckBox)gvRow.FindControl("chkSelect")).Checked == true)
            {
                documentRowCount = 0;
                foreach (DocFup obj in fupLST)
                {
                    if (documentRowCount < fupLST.Count - 1)
                    {
                        objCaseDocLit = new ATTCaseDocumentsLit();
                        objCaseDocLit.CaseID = double.Parse(this.lblCaseNo.Text);
                        objCaseDocLit.LitigantID = double.Parse(gvRow.Cells[1].Text);
                        objCaseDocLit.LitType = "R";
                        objCaseDocLit.LitigantName = gvRow.Cells[2].Text;

                        objCaseDocLit.DocSeq = 0;
                        objCaseDocLit.FileName = obj.FileName;
                        //objCaseDoc.DocumentFile = obj.FileContents;
                        objCaseDocLit.EntryBy = user.UserName;
                        objCaseDocLit.Action = "A";

                        CaseDocLitLST.Add(objCaseDocLit);

                        documentRowCount += 1;
                    }


                }
            }
        }

        CaseDocLitLST.Sort(delegate(ATTCaseDocumentsLit o1, ATTCaseDocumentsLit o2)
                            {
                                return o2.LitigantType.CompareTo(o1.LitigantType).CompareTo(o2.LitigantID.CompareTo(o1.LitigantID));
                            });
        this.grdLitDocument.DataSource = CaseDocLitLST;
        this.grdLitDocument.DataBind();


        //Clearing Grid Controls
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }

        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }

        fupLST.Clear();
        fupLST.Add(new DocFup());
        this.grdDocuments.DataSource = fupLST;
        this.grdDocuments.DataBind();

    }
    protected void grdLitDocument_DataBound(object sender, EventArgs e)
    {
        for (int rowIndex = this.grdLitDocument.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = grdLitDocument.Rows[rowIndex];
            GridViewRow gvPreviousRow = grdLitDocument.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count - 3;
            cellCount++)
            {
                if (gvRow.Cells[cellCount].Text ==
                gvPreviousRow.Cells[cellCount].Text)
                {
                    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                    {
                        gvRow.Cells[cellCount].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[cellCount].RowSpan =
                        gvPreviousRow.Cells[cellCount].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[cellCount].Visible = false;
                }
            }
        }
    }

    private void ClearControls()
    {
        this.grdEvidence.DataSource = "";
        this.grdEvidence.DataBind();

        this.grdAppellant.DataSource = "";
        this.grdAppellant.DataBind();

        this.grdRespondant.DataSource = "";
        this.grdRespondant.DataBind();

        Session["BindToGrid"] = new List<DocFup>();

        List<DocFup> fupLST = (List<DocFup>)Session["BindToGrid"];
        DocFup dFup = new DocFup();
        dFup.FUP = new FileUpload();
        fupLST.Add(dFup);

        this.grdDocuments.DataSource = fupLST;
        this.grdDocuments.DataBind();

        this.grdLitDocument.DataSource = "";
        this.grdLitDocument.DataBind();

        heCaseSummary.Text = "";

    }
    protected void lstEvidence_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
    }
    protected void grdEvidence_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTCaseEvidence> EvidenceLST = (List<ATTCaseEvidence>)Session["Evidence"];
        ATTCaseEvidence objEvidence = EvidenceLST[this.grdEvidence.SelectedIndex];
        this.txtEvidence.Text = objEvidence.Evidence;
    }
    protected void grdLitDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTCaseDocumentsLit> CaseDocLST = (List<ATTCaseDocumentsLit>)Session["LitDocuments"];
        if (this.grdLitDocument.Rows[e.RowIndex].Cells[7].Text == "A")
            CaseDocLST.RemoveAt(e.RowIndex);
        else
            CaseDocLST[e.RowIndex].Action = "D";

        this.grdLitDocument.DataSource = CaseDocLST;
        this.grdLitDocument.DataBind();
    }
    protected void lnkFileName_Click(object sender, EventArgs e)
    {
        string mimeType = "application/octet-stream";
        byte[] bytes;
        int i = int.Parse(((LinkButton)sender).CommandName);
        if (this.grdLitDocument.Rows[i].Cells[4].Text != "0")
        {
            List<ATTCaseDocuments> CDLST = BLLCaseDocuments.GetCaseDocuments(double.Parse(this.grdLitDocument.Rows[i].Cells[0].Text), int.Parse(this.grdLitDocument.Rows[i].Cells[4].Text));
            bytes = CDLST[0].DocumentContent;

        }
        else
        {
            List<ATTCaseDocuments> CaseDocLST = (List<ATTCaseDocuments>)Session["LitDocuments"];
            bytes = CaseDocLST[int.Parse(((LinkButton)sender).CommandName)].DocumentContent;

        }

        string ext = System.IO.Path.GetExtension(((LinkButton)sender).Text);
        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (regKey != null && regKey.GetValue("Content Type") != null)
            mimeType = regKey.GetValue("Content Type").ToString();

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + ((LinkButton)sender).Text);
        Response.AddHeader("Content-Length", bytes.Length.ToString());
        Response.ContentType = mimeType;
        Response.BinaryWrite(bytes);
        Response.End();

        GC.Collect();
        GC.SuppressFinalize(bytes);
        bytes = null;

    }
    protected void grdLitDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
            ((LinkButton)e.Row.FindControl("lnkFileName")).CommandName = e.Row.RowIndex.ToString();
    }
    protected void cbSelectAllAppellantss_CheckedChanged(object sender, EventArgs e)
    {
        //Checks All Appellants
        
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = cbSelectAllAppellantss.Checked == true ? true : false;
        }

        //Unchecks AllRespondsnts
        cbSelectAllRespondants.Checked = false;
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }
    }
    protected void cbSelectAllRespondants_CheckedChanged(object sender, EventArgs e)
    {
        //Checks All Respondants
        foreach (GridViewRow gvRow in this.grdRespondant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = cbSelectAllRespondants.Checked==true ? true : false;
        }

        //Unchecks All Appellants
        cbSelectAllAppellantss.Checked = false;
        foreach (GridViewRow gvRow in this.grdAppellant.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkSelect")).Checked = false;
        }
    }
    protected void grdRespondant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Enabled = false;
        e.Row.Cells[1].Visible = false;
    }
    protected void grdEvidence_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
    protected void grdAppellant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
}
