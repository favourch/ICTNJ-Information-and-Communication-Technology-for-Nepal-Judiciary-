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

public partial class MODULES_OAS_Test_CallBack : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        String cbReference = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "");
        String callbackScript = "function CallServer(arg, context) {" +
            cbReference + "; }";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);
    }
    public void RaiseCallbackEvent(String eventArgument)
    {

    }
    public string GetCallbackResult()
    {
        return "";
    }

}
