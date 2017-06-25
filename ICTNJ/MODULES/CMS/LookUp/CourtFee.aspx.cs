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
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.BLL;


public partial class MODULES_CMS_LookUp_CourtFee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack == false)
        {
            LoadCourtFee();
        }

    }

    void LoadCourtFee()
    {
        Session["CourtFee"] = BLLCourtFee.GetCourtFee(0);
        List<ATTCourtFee> CourtFeeLST = (List<ATTCourtFee>)Session["CourtFee"];

        this.grdCourtFee.DataSource = CourtFeeLST;
        this.grdCourtFee.DataBind();
    }

    int i=0;
    protected void grdCourtFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void grdCourtFee_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void grdCourtFee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdCourtFee_PreRender(object sender, EventArgs e)
    {
       
    }

    //protected void GridViewInsert(object sender, EventArgs e)
    protected void GridViewInsert()
    {
        if (ValidateCourtFee() == false)
            return;

        List<ATTCourtFee> CourtFeeLST = new List<ATTCourtFee>();

        TextBox tbFromAmount;
        TextBox tbToAmount;
        TextBox tbFee;
        DropDownList ddl;
        //
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            tbFromAmount = (TextBox)gvRow.FindControl("txtFromAmount");
            tbToAmount = (TextBox)gvRow.FindControl("txtAmountTo");
            tbFee = (TextBox)gvRow.FindControl("txtFee");
            ddl = (DropDownList)gvRow.FindControl("ddlAmtPerType");

            ATTCourtFee objCourtFee = new ATTCourtFee();
            objCourtFee.FromDate = "";
            objCourtFee.FromAmount = double.Parse(tbFromAmount.Text);
            if (tbToAmount.Text == "")
                objCourtFee.ToAmount = null;
            else
                objCourtFee.ToAmount = double.Parse(tbToAmount.Text);
            objCourtFee.AmtPer = double.Parse(tbFee.Text);
            objCourtFee.AmtPerType = ddl.SelectedValue;
            objCourtFee.FromToAmt = "";

            CourtFeeLST.Add(objCourtFee);
        }
        //Session["CourtFee"] = CourtFeeLST;


        ATTCourtFee obj = new ATTCourtFee();
        obj.AmtPerType = "0";
        CourtFeeLST.Add(obj);
        //Session["CourtFee"] = CourtFeeLST;
        grdCourtFee.DataSource = CourtFeeLST;
        grdCourtFee.DataBind();

        Session["CourtFee"] = CourtFeeLST;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateCourtFee() == false)
            return;

        List<ATTCourtFee> CourtFeeLST = new List<ATTCourtFee>();
        double ? ToAmount;
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            ATTCourtFee objCourtFee = new ATTCourtFee();
            objCourtFee.FromAmount = double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text);
            if (((TextBox)gvRow.FindControl("txtAmountTo")).Text=="")
            {
               ToAmount= null;
            }
            else
            {
                ToAmount=double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text);
            }
            objCourtFee.ToAmount = ToAmount; 
            objCourtFee.AmtPer = double.Parse(((TextBox)gvRow.FindControl("txtFee")).Text);
            objCourtFee.AmtPerType =((DropDownList)gvRow.FindControl("ddlAmtPerType")).SelectedValue;//)?0: ((TextBox)gvRow.FindControl("ddlAmtPerType")).Text;
            objCourtFee.EntryBy = "manoz";
            CourtFeeLST.Add(objCourtFee);
        }

        if (BLLCourtFee.SaveCourtFee(CourtFeeLST))
        {
            LoadCourtFee();
        }
 
        
    }
    protected void grdCourtFee_DataBound(object sender, EventArgs e)
    {
        int sno=1;
        Label lbl;
        foreach (GridViewRow  gvRow  in this.grdCourtFee.Rows)
        {
            lbl =(Label) gvRow.FindControl("lblSNo");
            lbl.Text = NumberToRoman(sno);
            sno += 1;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        GridViewInsert();
    }


    bool ValidateCourtFee()
    {
        int i = 0;
        TextBox tb;
        double PrevToAmount = 0;
        double PrevFromAmount = 0;
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            tb = (TextBox)gvRow.FindControl("txtFromAmount");
            if (tb.Text == "" || (double.Parse(tb.Text) == 0 && i != 0))
            {
                this.lblStatusMessage.Text = "From Amount Can't Be Blank.<BR> Please Fill From Amount in Row " +NumberToRoman (i + 1);
                this.programmaticModalPopup.Show();
                return false;
            }

            tb = (TextBox)gvRow.FindControl("txtFee");
            if (tb.Text == "")
            {
                this.lblStatusMessage.Text = "Court Fee Can't Be Blank.<BR> Please Fill Court Fee in Row " + NumberToRoman(i + 1);
                this.programmaticModalPopup.Show();
                return false;
            }

            DropDownList ddl = (DropDownList)gvRow.FindControl("ddlAmtPerType");
            if (ddl.SelectedValue == "0")
            {
                this.lblStatusMessage.Text = "Please Select Court Fee Type in Row " + NumberToRoman(i + 1);
                this.programmaticModalPopup.Show();
                return false;
            }

            i += 1;
        }

        i = 1;
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            if (i < grdCourtFee.Rows.Count && ((TextBox)gvRow.FindControl("txtAmountTo")).Text == "")
            {
                this.lblStatusMessage.Text = "To Amount Can't Be Blank in Row " +NumberToRoman( i); ;
                this.programmaticModalPopup.Show();
                return false;
            }
            i += 1;
        }

        i = 0;
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            if (i == 0)
                PrevFromAmount = double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text);
            else
            {
                if (double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text) <= PrevFromAmount)
                {
                    this.lblStatusMessage.Text = "Invalid From Amount in Row" + NumberToRoman(i + 1) + "<BR>" + "From Amount Can't Be Less Than The Preceeding Rows.";
                    this.programmaticModalPopup.Show();
                    return false;
                }
            }

            if (i == 0)
                PrevToAmount = double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text);
            else
            {
                if (i + 1 < this.grdCourtFee.Rows.Count)
                    if (double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text) <= PrevToAmount)
                    {
                        this.lblStatusMessage.Text = "Invalid To Amount in Row " + NumberToRoman(i + 1) + "<BR>" + "To Amount Can't Be Less Than The Preceeding Rows.";
                        this.programmaticModalPopup.Show();
                        return false;
                    }
            }
            i += 1;
        }




        i = 0;
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            

            if (i == 0)
            {
                if (double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text) >= double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text))
                {
                    this.lblStatusMessage.Text = "From Amount Can't Be Greater Than To Amount<BR>Invalid Amounts in " + NumberToRoman(i + 1);
                    this.programmaticModalPopup.Show();
                    return false;
                }
                else
                {
                    PrevToAmount = double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text);

                }
            }

            
            if (i != 0)
            {
                if ((i + 1) < this.grdCourtFee.Rows.Count)
                {
                    if (double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text) >= double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text))
                    {
                        this.lblStatusMessage.Text = "<B>From Amount<B> Can't Be Greater Than or Equal To <B>To Amount<B><BR>Invalid Amounts in " + NumberToRoman(i + 1);
                        this.programmaticModalPopup.Show();
                        return false;
                    }
                }
                else
                {

                    if (double.Parse(((TextBox)gvRow.FindControl("txtFromAmount")).Text) <= PrevToAmount)
                    {
                        this.lblStatusMessage.Text = "From Amount in Row " + NumberToRoman(i + 1) + " Can't Be Less Than To Amount in Row " +NumberToRoman( i);
                        this.programmaticModalPopup.Show();
                        return false;
                    }
                }
            }


            PrevToAmount = ((TextBox)gvRow.FindControl("txtAmountTo")).Text == "" ? 0 : double.Parse(((TextBox)gvRow.FindControl("txtAmountTo")).Text);
            i += 1;
        }

        i = 0;


        //Validating Amount Percent Against From date and To Date
        foreach (GridViewRow gvRow in this.grdCourtFee.Rows)
        {
            TextBox tbFromAmount = (TextBox)gvRow.FindControl("txtFromAmount");
            TextBox tbToAmount = (TextBox)gvRow.FindControl("txtAmountTo");
            TextBox tbFee = (TextBox)gvRow.FindControl("txtFee");
            DropDownList ddlAmtPerType = (DropDownList)gvRow.FindControl("ddlAmtPerType");

            if (i + 1 < this.grdCourtFee.Rows.Count)
            {
                if (ddlAmtPerType.SelectedValue == "P" && (double.Parse(tbFee.Text) > 100))
                {
                    this.lblStatusMessage.Text = "Court Fee In Row " + NumberToRoman(i + 1) + " Is Greater Than 100 Percent ";
                    this.programmaticModalPopup.Show();
                    return false;
                }

                if ((double.Parse(tbToAmount.Text) <= double.Parse(tbFee.Text)) && ddlAmtPerType.SelectedValue == "F")
                {
                    this.lblStatusMessage.Text = "Invalid Court Fee in Row " + NumberToRoman(i + 1) + "<BR>Court Fee Should Not Be Greater Than To Amount.";
                    this.programmaticModalPopup.Show();
                    return false;
                }
            }

            i += 1;

        }

        return true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        LoadCourtFee();
    }
    protected void btnMinus_Click(object sender, EventArgs e)
    {
        List<ATTCourtFee> CourtFeeLST = (List<ATTCourtFee>)Session["CourtFee"];
        CourtFeeLST.RemoveAt(CourtFeeLST.Count-1);
        this.grdCourtFee.DataSource = CourtFeeLST;
        this.DataBind();
    }

    public string NumberToRoman(int number)
    {
        // Validate
        if (number < 0 || number > 3999)
            throw new ArgumentException("Value must be in the range 0 - 3,999.");

        if (number == 0) return "N";

        // Set up key numerals and numeral pairs
        int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        // Initialise the string builder
        StringBuilder result = new StringBuilder();

        // Loop through each of the values to diminish the number
        for (int i = 0; i < 13; i++)
        {
            // If the number being converted is less than the test value, append
            // the corresponding numeral or numeral pair to the resultant string
            while (number >= values[i])
            {
                number -= values[i];
                result.Append(numerals[i]);
            }
        }

        // Done
        return result.ToString();
    }
    
}
