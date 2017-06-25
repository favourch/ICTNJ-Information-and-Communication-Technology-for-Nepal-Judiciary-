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
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

public partial class capthanew : System.Web.UI.Page
{
    private Random rand = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateImage();
        }
    }

    private void CreateImage()
    {
        string code = GetRandomText();

        Bitmap bitmap = new Bitmap(200, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bitmap);
        Pen pen = new Pen(Color.Yellow);
        Rectangle rect = new Rectangle(0, 0, 200, 60);

        SolidBrush b = new SolidBrush(Color.CornflowerBlue);
        SolidBrush blue = new SolidBrush(Color.Black);

        int counter = 0;

        g.DrawRectangle(pen, rect);
        g.FillRectangle(b, rect);

        for (int i = 0; i < code.Length; i++)
        {
            g.DrawString(code[i].ToString(), new Font("Tahoma", 10 + rand.Next(15, 20), FontStyle.Italic), blue, new PointF(10 + counter, 10));
            counter += 28;
        }

        DrawRandomLines(g);

        bitmap.Save(Response.OutputStream, ImageFormat.Gif);
        
        g.Dispose();
        bitmap.Dispose();
    }

    private void DrawRandomLines(Graphics g)
    {
        SolidBrush green = new SolidBrush(Color.Yellow);
        for (int i = 0; i < 15; i++)
        {
            g.DrawLines(new Pen(green, 1), GetRandomPoints());
        }
    }

    private Point[] GetRandomPoints()
    {
        Point[] points = { new Point(rand.Next(0, 150), rand.Next(1, 150)), new Point(rand.Next(0, 200), rand.Next(1, 190)) };
        return points;
    }

    private string GetRandomText()
    {
        Random random = new Random();
        int randomInt = random.Next(100000, 999999);
        Session["RandomStr"] = randomInt;

        return Session["RandomStr"].ToString();
    }
}

