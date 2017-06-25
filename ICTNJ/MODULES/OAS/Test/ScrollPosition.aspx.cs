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
public partial class MODULES_OAS_Test_ScrollPosition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.GridView1.DataSource = "abcedfghijklmnopqrst";
            this.GridView1.DataBind();

        }
        this.TextBox1.Text = "aaaa";
        this.TextBox2.Text = "bbbbb";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = "aaaa";
        this.TextBox2.Text = "bbbbb";
        //Request.file
    }
}
