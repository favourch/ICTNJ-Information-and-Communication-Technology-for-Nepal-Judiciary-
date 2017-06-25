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

public partial class MODULES_OAS_Test_XMLDataSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbl = new DataTable("employee");
        tbl.Columns.Add("name");
        tbl.Columns.Add("sex");
        tbl.Columns.Add("address");

        DataRow row = tbl.NewRow();
        row[0] = "suraj";
        row[1] = "male";
        row[2] = "banasthali";

        DataRow row2 = tbl.NewRow();
        row2[0] = "Rabin";
        row2[1] = "male";
        row[2] = "banasthali";

        tbl.Rows.Add(row);
        tbl.Rows.Add(row2);

        //tbl.WriteXml("C:\\test.xml");
    }
}
