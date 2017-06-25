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
using System.IO;
using System.Collections.Generic;

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;

public partial class MODULES_OAS_Forms_Document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadOrganisation();
            this.LoadFlowType();
            this.LoadDocCategory();
           
            Session["ProcessTbl"] = null;
            Session["LstDocAttachment"] = null;
            Session["LstDocProcess"] = null;
            Session["LstDocCategory"] = null;
        }
    }

    //public void LoadUnit()
    //{
    //    try
    //    {
    //        Session["DocUnitList"] = BLLUnit.GetUnitList(null, null);
    //        this.drpUnit_rqd.DataSource = (List<ATTUnit>)Session["DocUnitList"];
    //        this.drpUnit_rqd.DataTextField = "UnitName";
    //        this.drpUnit_rqd.DataValueField = "UnitID";
    //        this.drpUnit_rqd.DataBind();

    //        ListItem a = new ListItem();
    //        a.Selected = true;
    //        a.Text = "Select Unit";
    //        a.Value = "0";
    //        drpUnit_rqd.Items.Insert(0, a);
            
    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblStatus.Text = ex.Message;
    //    }    
    //}

    public void LoadDocCategory()
    {
        try
        {
            Session["LstDocCategory"] = BLLDocumentCategory.GetDocCategoryList(null);
            this.drpDocCategory_rqd.DataSource = (List<ATTDocumentCategory>)Session["LstDocCategory"];
            this.drpDocCategory_rqd.DataTextField = "CategoryName";
            this.drpDocCategory_rqd.DataValueField = "FileCatID";
            this.drpDocCategory_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Category";
            a.Value = "0";
            drpDocCategory_rqd.Items.Insert(0, a);
        }
        catch (Exception ex)
        {            
            throw(ex);
        }

    }

    public void LoadFlowType()
    {
        try
        {
            Session["DocFlowTypeList"] = BLLDocumentFlowType.GetFlowTypeList(null);
            this.drpFlowType_rqd.DataSource = (List<ATTDocumentFlowType>)Session["DocFlowTypeList"];
            this.drpFlowType_rqd.DataTextField = "DocFlowName";
            this.drpFlowType_rqd.DataValueField = "DocFlowID";
            this.drpFlowType_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Flow Type";
            a.Value = "0";
            drpFlowType_rqd.Items.Insert(0, a);

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["DocOrgList"] = BLLOrganization.GetOrganizationNameList();
            this.drpOrganisation_rqd.DataSource = (List<ATTOrganization>)Session["DocOrgList"];
            this.drpOrganisation_rqd.DataTextField = "OrgName";
            this.drpOrganisation_rqd.DataValueField = "OrgId";
            this.drpOrganisation_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Organisation";
            a.Value = "0";
            drpOrganisation_rqd.Items.Insert(0, a);

            Session["DocUnitList"] = BLLOrganizationUnit.GetOrganizationUnits(null, null);

            //Session["DocUnitList"] = BLLUnit.GetUnitList(null, null);

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        List<ATTDocumentAttachment> lstAttachment = new List<ATTDocumentAttachment>();
        try
        {
            string AttachedFileName ="";
            string FileDesc="";
            byte[] ContentFile = null;
            string ContentFileType="";



            if (Session["LstDocAttachment"] != null)
            {
                lstAttachment = (List<ATTDocumentAttachment>)Session["LstDocAttachment"];
            }

            if (this.FileUpload1.HasFile == true)
            {
                ContentFile = this.FileUpload1.FileBytes;
                ContentFileType = Path.GetExtension(this.FileUpload1.FileName);
                AttachedFileName = Path.GetFileName(this.FileUpload1.PostedFile.FileName);
                FileDesc = this.txtFileDescription.Text;

                lstAttachment.Add(new ATTDocumentAttachment(ContentFile, ContentFileType, AttachedFileName, FileDesc));

                //ObjectValidation OV = BLLDocument.ValidateDocumentAttachment(lstAttachment);
                ObjectValidation OV = BLLDocumentAttachment.ValidateDocumentAttachment(lstAttachment);


                if (OV.IsValid == false)
                {
                    this.lblDocAttachementStatus.Text = OV.ErrorMessage;
                    return;
                }

                Session["LstDocAttachment"] = lstAttachment;

                this.gvFiles.DataSource = Session["LstDocAttachment"];
                this.gvFiles.DataBind();

                this.txtFileDescription.Text = "";
                this.lblDocAttachementStatus.Text = " ";
            }
            else
                this.lblDocAttachementStatus.Text = "Please Browse File to Attach.";
        

        }
        catch (Exception ex)
        {
            lblDocAttachementStatus.Text = ex.Message;
     
        }
    }

    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        List<ATTDocumentProcess> lstDocProcess = new List<ATTDocumentProcess>();

        try
        {
            string SentTo = "";
            string SentType = "";
            String Status = "";
            string Note = "";

            if (Session["LstDocProcess"] != null)
            {
                lstDocProcess = (List<ATTDocumentProcess>)Session["LstDocProcess"];
            }

            SentTo = txtSendTo.Text;
            SentType = drpSentType.SelectedValue;
            Status = drpSentStatus.SelectedValue;
            Note = txtNote.Text;

            lstDocProcess.Add(new ATTDocumentProcess(SentTo, SentType, Status, Note));

            //ObjectValidation OV = BLLDocument.ValidateDocumentProcess(lstDocProcess);
            ObjectValidation OV = BLLDocumentProcess.ValidateDocumentProcess(lstDocProcess);

            if (OV.IsValid == false)
            {
                this.lblDocProcessStatus.Text = OV.ErrorMessage;
                return;
            }

            Session["LstDocProcess"] = lstDocProcess;


            DataTable tbl = new DataTable();

            if (Session["ProcessTbl"] != null)
                tbl = (DataTable)Session["ProcessTbl"];
            else
            {
                DataColumn dtCol0 = new DataColumn("SentTo");
                DataColumn dtCol1 = new DataColumn("SentType");
                DataColumn dtCol2 = new DataColumn("Status");
                DataColumn dtCol3 = new DataColumn("Note");
                tbl.Columns.Add(dtCol0);
                tbl.Columns.Add(dtCol1);
                tbl.Columns.Add(dtCol2);
                tbl.Columns.Add(dtCol3);
            }


            DataRow row = tbl.NewRow();
            row["SentTo"] = SentTo;

            if (drpSentStatus.SelectedIndex > 0)
                row["SentType"] = drpSentType.SelectedItem;
            else
                row["SentType"] = "";

            if (drpSentStatus.SelectedIndex > 0)
                row["Status"] = drpSentStatus.SelectedItem;
            else
                row["Status"] = "";

            row["Note"] = Note;
            tbl.Rows.Add(row);

            this.grdDocProcess.DataSource = tbl;
            this.grdDocProcess.DataBind();

            Session["ProcessTbl"] = tbl;

            txtSendTo.Text = "";
            drpSentType.SelectedIndex = -1;
            drpSentStatus.SelectedIndex = -1;
            txtNote.Text = "";

            lblDocProcessStatus.Text = "";
        }
        catch (Exception ex)
        {
            lblDocProcessStatus.Text = ex.Message;
        }

    }

    protected void drpOrganisation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.drpUnit_rqd.Items.Clear();

        if (this.drpOrganisation_rqd.SelectedIndex > 0)
        {

            List<ATTOrganizationUnit> lstUnit = (List<ATTOrganizationUnit>)Session["DocUnitList"];

            ATTOrganizationUnit objUnitName = new ATTOrganizationUnit();

            objUnitName.LstUnitName = lstUnit.FindAll(
                                                        delegate(ATTOrganizationUnit UnitName)
                                                        {
                                                            return UnitName.OrgID == int.Parse(this.drpOrganisation_rqd.SelectedValue);
                                                        }

                                                     );

            this.drpUnit_rqd.DataSource = objUnitName.LstUnitName;
            this.drpUnit_rqd.DataTextField = "UnitName";
            this.drpUnit_rqd.DataValueField = "UnitID";
            this.drpUnit_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Unit";
            a.Value = "0";
            drpUnit_rqd.Items.Insert(0, a);

            drpUnit_rqd.Enabled = true;
        }
        else
        {
            drpUnit_rqd.Enabled = false;
        }
       
       
    }

    protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTDocumentAttachment> lstAttachment = (List<ATTDocumentAttachment>)Session["LstDocAttachment"];
        lstAttachment.RemoveAt(e.RowIndex);
        Session["LstDocAttachment"] = lstAttachment;

        this.gvFiles.DataSource = Session["LstDocAttachment"];
        this.gvFiles.DataBind();
  
    }
    protected void gvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            e.Row.Cells[3].Attributes.Add("onClick", "return confirm('Are you sure to remove ?');");
    }

    //protected void gvFiles_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //int rowID = e.RowIndex;
    //    //List<ATTDocumentAttachment> lstAttachment = (List<ATTDocumentAttachment>)Session["LstDocAttachment"];
    //    //lstAttachment.RemoveAt(gvFiles.SelectedIndex);
    //    //Session["LstDocAttachment"] = lstAttachment;
    //    //GridViewDeleteEventArgs deleterow = new GridViewDeleteEventArgs(gvFiles.SelectedIndex);
    //    //gvFiles_RowDeleting(sender, deleterow);


    //}
    
    protected void grdDocProcess_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            e.Row.Cells[5].Attributes.Add("onClick", "return confirm('Are you sure to remove ?');");
    }

    protected void grdDocProcess_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTDocumentProcess> lstDocProcess = (List<ATTDocumentProcess>)Session["LstDocProcess"];
        lstDocProcess.RemoveAt(e.RowIndex);
        Session["LstDocProcess"] = lstDocProcess;

        int rowID = e.RowIndex;

        DataTable dt = (DataTable)Session["ProcessTbl"];

        if (dt.Rows.Count >= 1)
        {
            if (rowID <= (dt.Rows.Count - 1))
            {
                dt.Rows.Remove(dt.Rows[rowID]);
            }
        }

        Session["ProcessTbl"] = dt;
        grdDocProcess.DataSource = dt;
        grdDocProcess.DataBind();
    }
    
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        this.SaveDocument();
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        this.SaveDocument();
    }

    public void SaveDocument()
    {
        try
        {
            ATTDocument Doc = new ATTDocument();
            Doc.OrgID = int.Parse(drpOrganisation_rqd.SelectedValue);
            
            if(this.drpOrganisation_rqd.SelectedIndex > 0)
                Doc.UnitID = int.Parse(drpUnit_rqd.SelectedValue);
            
            Doc.DocFlowType = int.Parse(drpFlowType_rqd.SelectedValue);
            Doc.DocumentName = txtDocName_rqd.Text;
            Doc.DocCategory = int.Parse(drpDocCategory_rqd.SelectedValue);
            Doc.DocDescription = txtDocDesc.Text;

            ObjectValidation OV = BLLDocument.ValidateDocument(Doc);

            if (OV.IsValid == false)
            {
                this.lblStatus.Text = OV.ErrorMessage;
                return;
            }

            if (Session["LstDocAttachment"] != null)
                Doc.LstDocAttachment = (List<ATTDocumentAttachment>)Session["LstDocAttachment"];

            if (Session["LstDocProcess"] != null)
                Doc.LstDocProcess = (List<ATTDocumentProcess>)Session["LstDocProcess"];

            if (BLLDocument.SaveDocument(Doc))
            {
                this.lblStatus.Text = " Document Added Successfully !!!! ";

                this.gvFiles.DataSource = null;
                this.gvFiles.DataBind();

                this.grdDocProcess.DataSource = null;
                this.grdDocProcess.DataBind();

                Session["LstDocAttachment"] = null;
                Session["LstDocProcess"] = null;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearForm", "javascript:clearForm();", true);

                drpUnit_rqd.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }


}
