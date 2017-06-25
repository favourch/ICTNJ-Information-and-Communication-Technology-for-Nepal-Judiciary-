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

public class Student
{
    private int _ID;
    public int ID
    {
        get { return this._ID; }
        set { this._ID = value; }
    }

    private string _Name;
    public string Name
    {
        get { return this._Name; }
        set { this._Name = value; }
    }

    private string _Address;
    public string Address
    {
        get { return this._Address; }
        set { this._Address = value; }
    }

    public Student(int id, string name, string address)
    {
        this.ID = id;
        this.Name = name;
        this.Address = address;
    }
}

public class Teacher
{
    private int _Code;
    public int Code
    {
        get { return this._Code; }
        set { this._Code = value; }
    }

    private string _Post;
    public string Post
    {
        get { return this._Post; }
        set { this._Post = value; }
    }

    private int _DesignationLevel;
    public int DesignationLevel
    {
        get { return this._DesignationLevel; }
        set { this._DesignationLevel = value; }
    }

    public Teacher(int code, string post, int level)
    {
        this.Code = code;
        this.Post = post;
        this.DesignationLevel = level;
    }
}

public class Class
{
    private int _CID;
    public int CID
    {
        get { return this._CID; }
        set { this._CID = value; }
    }

    private string _ClassName;
    public string ClassName
    {
        get { return this._ClassName; }
        set { this._ClassName = value; }
    }

    public Class(int id, string name)
    {
        this.CID = id;
        this.ClassName = name;
    }
}

public partial class MODULES_OAS_Test_AutoGenerateColumn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            //System.Collections.Generic.List<Student> lst = new System.Collections.Generic.List<Student>();
            //lst.Add(new Student(1, "Suraj Shrestha", "Bansthali"));
            //lst.Add(new Student(2, "Rabin Shrestha", "Bansthali"));
            //lst.Add(new Student(3, "Bal Krishne Shrestha", "Battar"));
            //lst.Add(new Student(4, "Hem lal Shrestha", "Bidur"));

            ////this.GridView1.AutoGenerateColumns = true;
            //this.GridView1.DataSource = lst;
            //this.GridView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns.Clear();

        BoundField id = new BoundField();
        id.DataField = "ID";
        id.HeaderText = "ID";
        this.GridView1.Columns.Add(id);

        BoundField name = new BoundField();
        name.DataField = "Name";
        name.HeaderText = "Name";
        this.GridView1.Columns.Add(name);

        BoundField address = new BoundField();
        address.DataField = "Address";
        address.HeaderText = "Address";
        this.GridView1.Columns.Add(address);

        System.Collections.Generic.List<Student> lst = new System.Collections.Generic.List<Student>();
        lst.Add(new Student(1, "Suraj Shrestha", "Bansthali"));
        lst.Add(new Student(2, "Rabin Shrestha", "Bansthali"));
        lst.Add(new Student(3, "Bal Krishne Shrestha", "Battar"));
        lst.Add(new Student(4, "Hem lal Shrestha", "Bidur"));

        this.GridView1.DataSource = lst;
        this.GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns.Clear();

        BoundField post = new BoundField();
        post.DataField = "Post";
        post.HeaderText = "Post";
        this.GridView1.Columns.Add(post);

        BoundField code = new BoundField();
        code.DataField = "Code";
        code.HeaderText = "Code";
        this.GridView1.Columns.Add(code);

        BoundField Designation = new BoundField();
        Designation.DataField = "DesignationLevel";
        Designation.HeaderText = "DesignationLevel";
        this.GridView1.Columns.Add(Designation);

        System.Collections.Generic.List<Teacher> lst = new System.Collections.Generic.List<Teacher>();
        lst.Add(new Teacher(451, "Professor", 1));
        lst.Add(new Teacher(375, "Lecture", 3));
        lst.Add(new Teacher(242, "Reader", 2));

        this.GridView1.DataSource = lst;
        this.GridView1.DataBind();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridViewRow row = this.GridView1.Rows[0];
        this.Label1.Text = "First Student ID :: " + row.Cells[0].Text;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        GridViewRow row = this.GridView1.Rows[0];
        this.Label1.Text = "First Post ID :: " + row.Cells[1].Text;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns.Clear();

        BoundField CID = new BoundField();
        CID.DataField = "CID";
        CID.HeaderText = "CID";
        this.GridView1.Columns.Add(CID);

        BoundField ClassName = new BoundField();
        ClassName.DataField = "ClassName";
        ClassName.HeaderText = "ClassName";
        this.GridView1.Columns.Add(ClassName);

        System.Collections.Generic.List<Class> lst = new System.Collections.Generic.List<Class>();
        lst.Add(new Class(11, "First Room"));
        lst.Add(new Class(12, "Second Room"));
        lst.Add(new Class(13, "Third Room"));

        this.GridView1.DataSource = lst;
        this.GridView1.DataBind();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        GridViewRow row = this.GridView1.Rows[0];
        this.Label1.Text = "First Class ID :: " + row.Cells[0].Text;
    }
}