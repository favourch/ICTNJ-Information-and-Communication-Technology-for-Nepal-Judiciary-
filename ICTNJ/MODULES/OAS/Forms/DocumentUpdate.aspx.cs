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

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;

public partial class MODULES_OAS_Forms_DocumentUpate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int OrgID  = int.Parse(Session["OasEditOrgID"].ToString());
            int UnitID = int.Parse(Session["OasEditunitID"].ToString());
            int DocID  = int.Parse(Session["OasEditDocID"].ToString());

            Session["DocSeq"] = "";
            Session["AttachID"] = "";
            Session["DocID"] = "";

            Session["lstRqdDocDetail"] = GetRqdDocDetail(OrgID, UnitID, DocID);

            foreach (ATTDocument item in (List<ATTDocument>)Session["lstRqdDocDetail"])
            {
               
                //txtUnitName.Text = GetUnitName(item.UnitID);

                LoadUnit();
                LoadFlowType();
                LoadDocCategory();

                txtOrganisation.Text = GetOrgName(item.OrgID);
               //txtDocID.Text = item.DocID.ToString();
                txtDocName_rqd.Text = item.DocumentName.ToString();
                txtDocDescription.Text = item.DocDescription;
                drpUnit_rqd.SelectedValue = item.UnitID.ToString();
                drpFlowType_rqd.SelectedValue = item.DocFlowType.ToString();
                drpDocCategory_rqd.SelectedValue = item.DocCategory.ToString();


                if (item.LstDocAttachment.Count > 0)
                {
                    grdDocAttachment.DataSource = item.LstDocAttachment;
                    grdDocAttachment.DataBind();
                    Session["lstDocUpdAttachment"] = item.LstDocAttachment;
                }

                if (item.LstDocProcess.Count > 0)
                {
                    grdDocProcess.DataSource = item.LstDocProcess;
                    grdDocProcess.DataBind();
                    Session["lstDocUpdProcess"] = item.LstDocProcess;
                }
             
                Session["DocID"] = item.DocID.ToString();
           }

        }

       
    }

    public List<ATTDocument> GetRqdDocDetail(int orgID,int unitID,int docID)
    {
        List<ATTDocument> lstDocDetail = new List<ATTDocument>();
        List<ATTDocument> lstRequiredDocDetail = new List<ATTDocument>();


        lstDocDetail = (List<ATTDocument>)Session["DocSearchResultList"];

        lstRequiredDocDetail = lstDocDetail.FindAll(
                                                        delegate(ATTDocument objDoc)
                                                        {
                                                            return ((objDoc.OrgID == orgID) && (objDoc.UnitID == unitID) && (objDoc.DocID == docID));
                                                        }

                                                    );
        return lstRequiredDocDetail;
    }

    public string GetUnitName(int unitID)
    {
        string unitName = "";
        List<ATTOrganizationUnit> lstUpdUnit = new List<ATTOrganizationUnit>();
        List<ATTOrganizationUnit> lstRequiredUnit = new List<ATTOrganizationUnit>();

        lstUpdUnit = (List<ATTOrganizationUnit>)Session["DocSearchUnitList"];

        lstRequiredUnit = lstUpdUnit.FindAll(
                                                       delegate(ATTOrganizationUnit objUnit)
                                                       {
                                                           return (objUnit.UnitID == unitID);
                                                       }

                                             );


        foreach (ATTOrganizationUnit itemUnit in lstRequiredUnit)
        {
            unitName = itemUnit.UnitName;
        }

        return unitName;
    }

    public string GetOrgName(int orgID)
    {
        string orgName = "";
        List<ATTOrganization> lstUpdOrganisation = new List<ATTOrganization>();
        List<ATTOrganization> lstRequiredOrganisation = new List<ATTOrganization>();

        lstUpdOrganisation = (List<ATTOrganization>)Session["DocSearchOrgList"];


        lstRequiredOrganisation = lstUpdOrganisation.FindAll(
                                                                delegate(ATTOrganization objOrg)
                                                                {
                                                                    return (orgID == objOrg.OrgID);
                                                                }
                                                             );

        foreach (ATTOrganization itemOrg in lstRequiredOrganisation)
        {
           orgName = itemOrg.OrgName; 
        }

        return orgName;
    }

    protected void btnChangeProcess_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Session["DocSeq"].ToString() != "") && (Session["DocID"].ToString() != ""))
            {
                List<ATTDocumentProcess> lstUpdProcess = new List<ATTDocumentProcess>();

                string sentTo = "";
                string sentType = "";
                string status = "";
                string note = "";

                if (Session["lstDocUpdProcess"] != null)
                {
                    lstUpdProcess = (List<ATTDocumentProcess>)Session["lstDocUpdProcess"];

                    sentTo = txtSentTo.Text;
                    sentType = drpSentType.SelectedValue;
                    status = drpSentStatus.SelectedValue;
                    note = txtNote.Text;
                }

                foreach (ATTDocumentProcess itemAProcess in lstUpdProcess)
                {
                    if ((itemAProcess.DocSequence == double.Parse(Session["DocSeq"].ToString()))&&
                        (itemAProcess.DocID == int.Parse(Session["DocID"].ToString())))
                    {
                        itemAProcess.SentTo = sentTo;
                        itemAProcess.SentType = sentType;
                        itemAProcess.Status = status;
                        itemAProcess.Note = note;
                    }
                }

                grdDocProcess.DataSource = lstUpdProcess;
                grdDocProcess.DataBind();

                txtSentTo.Text = "";
                txtNote.Text = "";
                drpSentType.SelectedIndex = -1;
                drpSentStatus.SelectedIndex = -1;
                lblStatus.Text = "";

                Session["DocSeq"] = null;
                Session["lstDocUpdProcess"] = lstUpdProcess;
                btnChangeProcess.Visible = false;

            }
            else
                lblStatus.Text = " Only update of existing data is allowed ...";

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
        
    }

    protected void btnChangeAttach_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["AttachID"].ToString() != "")
            {
                  List<ATTDocumentAttachment> lstUpdAttachment = new List<ATTDocumentAttachment>();
         
                  string AttachedFileName = "";
                  string AttachFileDetail = "";
                  string ContentFileType = "";  

                  byte[] ContentFile = null;
                 
                  if (Session["lstDocUpdAttachment"] != null)
                  {
                      lstUpdAttachment = (List<ATTDocumentAttachment>)Session["lstDocUpdAttachment"];

                      if (this.FileUpload1.HasFile == true)
                      {
                          ContentFile      = this.FileUpload1.FileBytes;
                          ContentFileType  = Path.GetExtension(this.FileUpload1.FileName);
                          AttachedFileName = Path.GetFileName(this.FileUpload1.PostedFile.FileName);
                          AttachFileDetail = this.txtAttachFileDesc.Text;
                      }
                      else 
                      {
                          AttachedFileName = this.txtAttachFileName.Text;
                          AttachFileDetail = this.txtAttachFileDesc.Text;

                      }
                  }


                  foreach (ATTDocumentAttachment itemAttach in lstUpdAttachment)
                  {
                      if(itemAttach.AttachmentID == int.Parse(Session["AttachID"].ToString()))
                      {
                        
                          if (this.FileUpload1.HasFile == true)
                          {
                              itemAttach.ContentFile = ContentFile;
                              itemAttach.FileName = AttachedFileName;
                              itemAttach.FileDescription = AttachFileDetail;
                              itemAttach.CFileType = ContentFileType;
                          }
                          else
                          {
                              itemAttach.FileName = AttachedFileName;
                              itemAttach.FileDescription = AttachFileDetail;
                          }

                         
                      }
                  }

                  grdDocAttachment.DataSource = lstUpdAttachment;
                  grdDocAttachment.DataBind();

                  txtAttachFileName.Text = "";
                  txtAttachFileDesc.Text = "";
                  lblStatus.Text = "";

                  Session["AttachID"] = null;
                  Session["lstDocUpdAttachment"] = lstUpdAttachment;
                  btnChangeAttach.Visible = false;
            }
            else
                lblStatus.Text = " Only update of existing data is allowed ...";

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
         

    }

    protected void grdDocAttachment_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = grdDocAttachment.Rows[e.NewSelectedIndex];
        Session["AttachID"] = row.Cells[1].Text;
        txtAttachFileName.Text = row.Cells[2].Text.ToString();

        if (row.Cells[4].Text.ToString() != "&nbsp;")
            txtAttachFileDesc.Text = row.Cells[4].Text.ToString();

        btnChangeAttach.Visible = true;

    }

    protected void grdDocProcess_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = grdDocProcess.Rows[e.NewSelectedIndex];
        Session["DocSeq"] = row.Cells[1].Text.ToString();
        txtSentTo.Text = row.Cells[2].Text.ToString();
        drpSentType.SelectedValue = row.Cells[3].Text.ToString();
        drpSentStatus.SelectedValue = row.Cells[4].Text.ToString();

        if (row.Cells[3].Text == "Forward")
            drpSentType.SelectedValue = "F";
        else if (row.Cells[3].Text == "Backward")
            drpSentType.SelectedValue = "B";


        if (row.Cells[4].Text == "Approved")
            drpSentStatus.SelectedValue = "A";
        else if (row.Cells[4].Text == "Pending")
            drpSentStatus.SelectedValue = "P";
        else if (row.Cells[4].Text == "Cancel")
            drpSentStatus.SelectedValue = "C";

        if (row.Cells[6].Text.ToString() != "&nbsp;")
            txtNote.Text = row.Cells[6].Text.ToString();
        else
            txtNote.Text = "";

        btnChangeProcess.Visible = true;
    }

    protected void grdDocAttachment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;
        row.Cells[3].Visible = false;
    }
    
    protected void grdDocProcess_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        row.Cells[1].Visible = false;

            
    }
   
    public void LoadUnit()
    {
        try
        {
            this.drpUnit_rqd.DataSource = (List<ATTOrganizationUnit>)Session["DocSearchUnitList"];
            this.drpUnit_rqd.DataTextField = "UnitName";
            this.drpUnit_rqd.DataValueField = "UnitID";
            this.drpUnit_rqd.DataBind();

            ListItem a = new ListItem();
            a.Selected = true;
            a.Text = "Select Unit";
            a.Value = "0";
            drpUnit_rqd.Items.Insert(0, a);

        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    public void LoadFlowType()
    {
        try
        {
            this.drpFlowType_rqd.DataSource = (List<ATTDocumentFlowType>)Session["DocSearchFlowTypeList"];
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

    public void LoadDocCategory()
    {
        try
        {
            this.drpDocCategory_rqd.DataSource = (List<ATTDocumentCategory>)Session["DocSearchCategory"];
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
            throw (ex);
        }

    }
    
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        finalUpdate();
    }
    protected void btnUpdate1_Click1(object sender, EventArgs e)
    {
        finalUpdate();
    }
    
    public void finalUpdate()
    {
        try
        {
            foreach (ATTDocument item in (List<ATTDocument>)Session["lstRqdDocDetail"])
            {
                if(drpUnit_rqd.SelectedIndex > 0)
                    item.UnitID = int.Parse(drpUnit_rqd.SelectedValue);

                item.DocFlowType = int.Parse(drpFlowType_rqd.SelectedValue);
                item.DocFlowTypeName = drpFlowType_rqd.SelectedItem.ToString();
                item.DocCategory = int.Parse(drpDocCategory_rqd.SelectedValue);
                item.DocCategoryName = drpDocCategory_rqd.SelectedItem.ToString();
                item.DocumentName = txtDocName_rqd.Text;
                item.DocDescription = txtDocDescription.Text;

                if (Session["lstDocUpdAttachment"] != null)
                    item.LstDocAttachment = (List<ATTDocumentAttachment>)Session["lstDocUpdAttachment"];

                if (Session["lstDocUpdProcess"] != null)
                    item.LstDocProcess = (List<ATTDocumentProcess>)Session["lstDocUpdProcess"];

                if (BLLDocument.UpdateDocument(item))
                {
                   //BLLDocument.UpdateDocument(item);
                    //this.lblStatus.Text = " Document Updated Successfully !!!! ";
                    Session["Flag"] = 1;
                    Response.Redirect("OASSearch.aspx");
                }

            }

          

        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    protected void grdDocProcess_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (row.Cells[3].Text == "F")
            row.Cells[3].Text = "Forward";
        else if (row.Cells[3].Text == "B")
            row.Cells[3].Text = "Backward";


        if (row.Cells[4].Text == "A")
            row.Cells[4].Text = "Approved";
        else if (row.Cells[4].Text == "P")
            row.Cells[4].Text = "Pending";
        else if (row.Cells[4].Text == "C")
            row.Cells[4].Text = "Cancel";

        if (row.Cells[5].Text == "N")
            row.Cells[5].Text = "No";
        else if (row.Cells[5].Text == "Y")
            row.Cells[5].Text = "Yes";
    }
}
