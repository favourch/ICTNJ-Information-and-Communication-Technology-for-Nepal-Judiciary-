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

public partial class MODULES_OAS_Test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.GridView1.DataSource = "Suraj";
            this.GridView1.DataBind();
        }

        this.TextBox1.Text = "aaaa";
        this.TextBox2.Text = "bbbbb";

        int ix = 0;
        int jx = ix++;

        this.TextBox1.Text = "i: " + ix.ToString();
        this.TextBox2.Text = "j: " + jx.ToString();

        int[] a ={ 15, 8, 9, 45, 100, 84, 2, 78 };
        
        int temp;
        int total_loop = 0;
        //for (int i = 0; i < a.Length; i++)
        //{
        //    for (int j = 0; j < a.Length - i - 1; j++)
        //    {
        //        if (a[j] > a[j + 1])
        //        {
        //            temp = a[j + 1];
        //            a[j + 1] = a[j];
        //            a[j] = temp;
        //        }
        //        loop_j = loop_j + 1;
        //        total_loop = total_loop + 1;
        //    }
        //    loop_i = loop_i + 1;
        //}

        //Insertion sort
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] > a[j])
                {
                    temp = a[j];
                    a[j] = a[i];
                    a[i] = temp;
                }
                total_loop = total_loop + 1;
            }
        }

        foreach (int i in a)
        {
            Response.Write(i.ToString() + "<br>");
        }
        Response.Write("<br>Total loop(Insertion sort): " + total_loop.ToString());

        int[][] arr = new int[4][];
        arr[0] = new int[3];
        arr[1] = new int[2];
        arr[2] = new int[5];
        arr[3] = new int[4];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = "aaaa";
        this.TextBox2.Text = "bbbbb";
    }

    protected void Select(object sender, EventArgs e)
    { 
    }

    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Command1(object sender, CommandEventArgs e)
    {

    }
}
