using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static AjaxControlToolkit.Slide[] GetSlides()
    {
        AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[5];

        slides[0] = new AjaxControlToolkit.Slide("images/Blue hills.jpg", "Blue Hills", "Go Blue");
        slides[1] = new AjaxControlToolkit.Slide("images/Sunset.jpg", "Sunset", "Setting sun");
        slides[2] = new AjaxControlToolkit.Slide("images/Winter.jpg", "Winter", "Wintery...");
        slides[3] = new AjaxControlToolkit.Slide("images/Water lilies.jpg", "Water lillies", "Lillies in the water");
        slides[4] = new AjaxControlToolkit.Slide("images/VerticalPicture.jpg", "Sedona", "Portrait style picture");
        return (slides);
    }
}