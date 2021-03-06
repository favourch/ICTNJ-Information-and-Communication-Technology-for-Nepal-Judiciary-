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
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;


public partial class MODULES_OAS_UserControls_TippaniAttachment : System.Web.UI.UserControl
{
    private string _ActionMode = "A";
    public string ActionMode
    {
        set { this._ActionMode = value; }
        get { return this._ActionMode.Trim(); }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            if (this.ActionMode == "A")
            {
                Session["Tippani_Attachment"] = new List<ATTGeneralTippaniAttachment>();
            }
        }
    }

    protected void grdAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "return confirm('Do you really want to delete?');");

            ATTGeneralTippaniAttachment attach = e.Row.DataItem as ATTGeneralTippaniAttachment;
            System.Drawing.Color c = BLLGeneralTippani.GetActionColor(attach.Action);
            e.Row.ForeColor = c;

            if (attach.Action == "D")
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Text = "Undo";
            }
            else if (attach.Action == "N" || attach.Action == "A" || attach.Action == "E")
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.fupAttachment.HasFile == false)
        {
            this.lblStatusMessage.Text = "कृपया कागजपत्र दिनुहोस।";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTGeneralTippaniAttachment> lst = Session["Tippani_Attachment"] as List<ATTGeneralTippaniAttachment>;

        ATTGeneralTippaniAttachment attachment = new ATTGeneralTippaniAttachment();
        attachment.OrgID = 0;
        attachment.TippaniID = 0;
        attachment.TippaniProcessID = 0;
        attachment.AttachmentID = 0;
        attachment.DocumentName = this.fupAttachment.FileName;
        attachment.Description = this.txtDescription.Text;
        attachment.RawContent = this.fupAttachment.FileBytes;
        attachment.Action = "A";
        lst.Add(attachment);

        this.grdAttachment.DataSource = lst;
        this.grdAttachment.DataBind();

        this.txtDescription.Text = "";
    }

    public void Clear()
    {
        this.txtDescription.Text = "";
        this.grdAttachment.DataSource = "";
        this.grdAttachment.DataBind();
        Session["Tippani_Attachment"] = new List<ATTGeneralTippaniAttachment>();
        this.ActionMode = "A";
    }

    public List<ATTGeneralTippaniAttachment> GetAttachment(int orgID, int tippaniID, string entryBy)
    {
        List<ATTGeneralTippaniAttachment> lst = Session["Tippani_Attachment"] as List<ATTGeneralTippaniAttachment>;
        foreach (ATTGeneralTippaniAttachment attachment in lst)
        {
            attachment.OrgID = orgID;
            attachment.TippaniID = tippaniID;
            attachment.TippaniProcessID = 0;
            attachment.EntryBy = entryBy;
        }
        return lst;
    }

    public void SetAttachment(List<ATTGeneralTippaniAttachment> lst)
    {
        this.grdAttachment.DataSource = lst;
        this.grdAttachment.DataBind();
    }

    protected void grdAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGeneralTippaniAttachment> lst = Session["Tippani_Attachment"] as List<ATTGeneralTippaniAttachment>;
        ATTGeneralTippaniAttachment currentO = lst[e.RowIndex];
        GridViewRow CurrentRow = this.grdAttachment.Rows[e.RowIndex];

        int DelCmdIndex = 6;

        if (currentO.Action == "A")
        {
            GC.Collect();
            GC.SuppressFinalize(lst[e.RowIndex].RawContent);
            lst[e.RowIndex].RawContent = null;

            lst.RemoveAt(e.RowIndex);
            this.grdAttachment.DataSource = lst;
            this.grdAttachment.DataBind();
        }
        else if (currentO.Action == "N" || currentO.Action == "D" || currentO.Action == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                this.grdAttachment.DataSource = lst;
                this.grdAttachment.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                this.grdAttachment.DataSource = lst;
                this.grdAttachment.DataBind();
            }
        }
    }

    public void LoadTippaniAttachmentDetail(int orgID, int tippaniID)
    {
        ATTGeneralTippaniAttachment info = new ATTGeneralTippaniAttachment();
        info.OrgID = orgID;
        info.TippaniID = tippaniID;

        try
        {
            List<ATTGeneralTippaniAttachment> lst = BLLGeneralTippaniAttachment.GetAttachment(info, tippaniID.ToString() + ", ");
            this.grdAttachment.DataSource = lst;
            this.grdAttachment.DataBind();
            Session["Tippani_Attachment"] = lst;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadAttachmentFromMessage(int orgID, int msgID)
    {
        try
        {
            List<ATTMessageAttachment> mlist = BLLMessageAttachment.GetMsgAttachmentByIDs(orgID, msgID);
            List<ATTGeneralTippaniAttachment> lst = new List<ATTGeneralTippaniAttachment>();
            foreach (ATTMessageAttachment att in mlist)
            {
                ATTGeneralTippaniAttachment ah = new ATTGeneralTippaniAttachment();
                ah.OrgID = 0;
                ah.TippaniID = 0;
                ah.TippaniProcessID = 0;
                ah.AttachmentID = 0;
                ah.DocumentName = att.FileName;
                ah.Description = "";
                ah.RawContent = att.ContentFile;
                ah.Action = "A";
                lst.Add(ah);
            }
           
            foreach (ATTMessageAttachment attach in mlist)
            {
                if (attach.ContentFile != null)
                {
                    GC.Collect();
                    GC.SuppressFinalize(attach.ContentFile);
                    attach.ContentFile = null;
                }
            }
            
            this.grdAttachment.DataSource = lst;
            this.grdAttachment.DataBind();
            Session["Tippani_Attachment"] = lst;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void LoadAttachmentFromDartaaChalaani(int orgID, string regDate, int regNo)
    {
        try
        {
            List<ATTDartaaChalaani> dlist = BLLDartaaChalaani.GetDartaaChalaaniByIDs(orgID, regDate, regNo);
            List<ATTGeneralTippaniAttachment> lst = new List<ATTGeneralTippaniAttachment>();
            foreach (ATTDartaaChalaani att in dlist)
            {
                if (att.FileName != "" && att.RegFile != null)
                {
                    ATTGeneralTippaniAttachment ah = new ATTGeneralTippaniAttachment();
                    ah.OrgID = 0;
                    ah.TippaniID = 0;
                    ah.TippaniProcessID = 0;
                    ah.AttachmentID = 0;
                    ah.DocumentName = att.FileName;
                    ah.Description = "";
                    ah.RawContent = att.RegFile;
                    ah.Action = "A";
                    lst.Add(ah);
                }
            }

            foreach (ATTDartaaChalaani attach in dlist)
            {
                if (attach.RegFile != null)
                {
                    GC.Collect();
                    GC.SuppressFinalize(attach.RegFile);
                    attach.RegFile = null;
                }
            }

            this.grdAttachment.DataSource = lst;
            this.grdAttachment.DataBind();
            Session["Tippani_Attachment"] = lst;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
