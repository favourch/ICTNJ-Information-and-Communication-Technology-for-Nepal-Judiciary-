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

public partial class MODULES_PMS_Forms_ImageGenerator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] bytes = Session["PMSImageRawData"] as byte[];
        if (bytes != null && bytes.Length > 0)
        {
            MemoryStream memoryStream = new MemoryStream();

            memoryStream.Write(bytes, 0, bytes.Length);

            Response.Buffer = true;
            Response.BinaryWrite(bytes);

            memoryStream.Dispose();
        }
    }
}
