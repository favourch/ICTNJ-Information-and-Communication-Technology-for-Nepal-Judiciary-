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

public partial class MODULES_LIS_Forms_FileViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        PCS.LIS.ATT.ATTLibraryMaterial obj = (PCS.LIS.ATT.ATTLibraryMaterial)Session["LM_LibraryMaterial"];

        byte[] bytes = null;
        try
        {
            bytes = PCS.LIS.BLL.BLLLibraryMaterial.GetLMAttachmentFile(obj.OrgID, obj.LibraryID, obj.LMaterialID);
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
            return;
        }

        if (bytes == null)
        {
            this.lblStatus.Text = "No file to view.";
            return;
        }
        
        Response.ClearHeaders();
        Response.ClearContent();

        if (obj.CFileType.ToUpper() == ".TXT")
            Response.ContentType = "text/plain";
        else if (obj.CFileType.ToUpper() == ".PDF")
            Response.ContentType = "application/pdf";
        else if (obj.CFileType.ToUpper() == ".JPG" || obj.CFileType.ToUpper() == ".JPEG")
            Response.ContentType = "image/jpeg";
        else if (obj.CFileType.ToUpper() == ".GIF")
            Response.ContentType = "image/gif";

        Response.BinaryWrite(bytes);
        Response.End();

        GC.Collect();
        GC.SuppressFinalize(bytes);
        bytes = null;
    }
}
