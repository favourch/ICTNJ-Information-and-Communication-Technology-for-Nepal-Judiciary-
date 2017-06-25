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

public partial class MODULES_OAS_UserControls_TippaniHistory : System.Web.UI.UserControl
{

    private int _OrgID;
    public int OrgID
    {
        get { return this._OrgID; }
        set { this._OrgID = value; }
    }

    private int _TippaniID;
    public int TippaniID
    {
        get { return this._TippaniID; }
        set { this._TippaniID = value; }
    }

    private int _ProcessID;
    public int ProcessID
    {
        get { return this._ProcessID; }
        set { this._ProcessID = value; }
    }

    public DataList dLstTippaniHistory
    {
        get { return this.dLstHistory; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        HtmlLink myHtmlLink = new HtmlLink();

        myHtmlLink.Href = "~/MODULES/COMMON/Collapse Panel/StyleSheet.css";
        myHtmlLink.Attributes.Add("rel", "stylesheet");
        myHtmlLink.Attributes.Add("type", "text/css");

        this.Page.Header.Controls.Add(myHtmlLink);
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    public void LoadTippaniHistory(ATTGeneralTippaniRequestInfo info)
    {
        try
        {
            decimal d = 0;
            List<ATTGeneralTippaniRequestInfo> lst = BLLGeneralTippaniRequestInfo.GetTippaniRequestInfoList(info, 0, 0, ref d);

            this.dLstHistory.DataSource = lst;
            //int index = lst.FindIndex
            //                        (
            //                            delegate(ATTGeneralTippaniRequestInfo i)
            //                            {
            //                                return i.TippaniProcessID == this.ProcessID;
            //                            }
            //                        );
            //this.dLstHistory.SelectedIndex = index;
            this.dLstHistory.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    public void ClearTippaniHistory()
    {
        this.dLstHistory.DataSource = "";
        this.dLstHistory.DataBind();
    }

    protected void dLstHistory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {
            ((Label)e.Item.FindControl("lblHistoryCount")).Text = (e.Item.ItemIndex + 1).ToString() + " )";
        }
    }

    protected void dLstAttachment_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
        {
            ((Label)e.Item.FindControl("lblCount")).Text = (e.Item.ItemIndex + 1).ToString() + ". ";
        }
    }

    protected void lnkFile_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;

        char[] token ={ '/' };
        int orgID = int.Parse(lnk.CommandArgument.Split(token)[0]);
        int tippaniID = int.Parse(lnk.CommandArgument.Split(token)[1]);
        int tippaniProcessID = int.Parse(lnk.CommandArgument.Split(token)[2]);
        int attachmentID = int.Parse(lnk.CommandArgument.Split(token)[3]);

        try
        {
            byte[] bytes = BLLGeneralTippaniAttachment.GetAttachedFile(orgID, tippaniID, tippaniProcessID, attachmentID);

            string mimeType = "application/octet-stream";
            
            string ext = System.IO.Path.GetExtension(lnk.Text);
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lnk.Text);
            Response.AddHeader("Content-Length", bytes.Length.ToString());
            Response.ContentType = mimeType;
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();
            Response.End();
            
            GC.Collect();
            GC.SuppressFinalize(bytes);
            bytes = null;
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
}
