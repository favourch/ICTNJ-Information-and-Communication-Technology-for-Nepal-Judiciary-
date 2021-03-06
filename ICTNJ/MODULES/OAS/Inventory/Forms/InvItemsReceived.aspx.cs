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

using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_Inventory_Forms_InvItemsReceived : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (!IsPostBack)
        {
            LoadItemsType();
            Session["ItemsTransfKNJ"] = new List<ATTInvItemsTransfered>();
            Session["ItemsTransfKBJ"] = new List<ATTInvItemsTransfered>();
            Panel2.Visible = false;
        
        }
    }
    private void LoadItemsType()
    {
        try
        {
            List<ATTInvItemType> lstItemsType = BLLInvItemsTransfered.GetItemsType(null,"Y");
            lstItemsType.Insert(0, new ATTInvItemType(0, "छान्नुहोस्", ""));
            ddlItemsType.DataTextField = "ItemsTypeName";
            ddlItemsType.DataValueField = "ItemsTypeID";
            ddlItemsType.DataSource = lstItemsType;
            ddlItemsType.DataBind();
            Session["ItemsType:"] = lstItemsType;

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    private void LoadItemsTransfKBJ ()
    {
        try
        {
            List<ATTInvItemsTransfered> lstItemsTransKBJ = BLLInvItemsTransfered.GetItemsTransfKBJList();
            grdItemsTransfRecv.DataSource = lstItemsTransKBJ.FindAll(
                delegate(ATTInvItemsTransfered obj) 
                {
                    return obj.TransRecvBy == null;
                }
                );
            grdItemsTransfRecv.DataBind();
            Session["ItemsTransfKBJ"] = lstItemsTransKBJ;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Could not Load list of items transfered" + ex.Message;
            this.programmaticModalPopup.Show();

        }
    }
    private void LoadItemsTransKNJ()
    {
        try
        {
            List<ATTInvItemsTransfered> lstItemsTransKNJ = BLLInvItemsTransfered.GetItemsTransfKNJList();
            grdItemsTransfRecv.DataSource = lstItemsTransKNJ.FindAll(
                delegate(ATTInvItemsTransfered obj)
                {
                    return obj.TransRecvBy == null;
                }
                ); ;
            grdItemsTransfRecv.DataBind();
            Session["ItemsTransfKNJ"] = lstItemsTransKNJ;

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Could not Load list of items transfered" + ex.Message;
            this.programmaticModalPopup.Show();

        }
    }
    protected void grdItemsTransfRecv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdItemsTransfRecv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int itemType = ((List<ATTInvItemType>)Session["ItemsType:"])[ddlItemsType.SelectedIndex].ItemsTypeID;
        if (itemType == 1)
        {
            e.Row.Cells[5].Visible = true;
            e.Row.Cells[21].Visible = false;
           
        }
        else if (itemType == 2)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[21].Visible = true;
        }
    }
    protected void ddlItemsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlItemsType.SelectedIndex > 0)
            {
                int itemType = ((List<ATTInvItemType>)Session["ItemsType:"])[ddlItemsType.SelectedIndex].ItemsTypeID;
                if (itemType == 1)
                {
                    LoadItemsTransfKBJ();
                    Panel2.Visible = true;
                }
                else if (itemType == 2)
                {
                    LoadItemsTransKNJ();
                    Panel2.Visible = true;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlItemsType.SelectedIndex == 0)
            {
                this.lblStatusMessage.Text = "समानको किसिम छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
            if (this.txtReceivedDate.Text == "")
            {
                this.lblStatusMessage.Text = "बुझिलिएको मिति हाल्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }
           
            List<ATTInvItemsTransfered> lstNew = new List<ATTInvItemsTransfered>();
            List<ATTInvItemsTransfered> lstItemsTransfKNJ = new List<ATTInvItemsTransfered>();
            List<ATTInvItemsTransfered> lstItemsTransfKBJ = new List<ATTInvItemsTransfered>();
            if (this.ddlItemsType.SelectedIndex == 2)
            {
                lstItemsTransfKNJ = (List<ATTInvItemsTransfered>)Session["ItemsTransfKNJ"];
            }
            else
            {
                lstItemsTransfKBJ = (List<ATTInvItemsTransfered>)Session["ItemsTransfKBJ"];
            }
            ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

            if (lstItemsTransfKNJ.Count > 0)
            {
                if (((CheckBox)grdItemsTransfRecv.HeaderRow.FindControl("chkAllItems")).Checked == true)
                {
                    foreach (ATTInvItemsTransfered var in lstItemsTransfKNJ)
                    {
                        var.OrgID = var.OrgID;
                        var.ItemsCategoryID = var.ItemsCategoryID;
                        var.ItemsSubCategoryID = var.ItemsSubCategoryID;
                        var.ItemsID = var.ItemsID;
                        var.TransORG = var.TransORG;
                        var.TransSEQ = var.TransSEQ;
                        var.SeqNo = var.SeqNo;
                        // var.Quantity = var.Quantity;
                        var.DecisionDate = var.DecisionDate;
                        var.TransDate = var.TransDate;
                        var.TransVia = var.TransVia;
                        var.TransOrgUnit = var.TransOrgUnit;
                        var.TransTo = var.TransTo;
                        var.TransRecvDate = this.txtReceivedDate.Text.Trim();
                        var.TransRecvBy = user.OrgID;
                        var.ReturnBy = var.ReturnBy;
                        var.ReturnDate = var.ReturnDate;
                        var.ReturnVia = var.ReturnVia;
                        var.ReturnRecvBy = var.ReturnRecvBy;
                        var.ReturnRecvDate = var.ReturnRecvDate;
                        var.Action = "E";
                    }
                    if (BLLInvItemsTransfered.SaveItemsTransfer(lstItemsTransfKNJ, "receive"))
                    {
                        this.lblStatusMessage.Text = "Received Items Saved";
                        this.programmaticModalPopup.Show();
                        Session["ItemsTransfKNJ"] = null;
                    }
                }
                else
                {
                    int count = 0;
                    foreach (GridViewRow row in grdItemsTransfRecv.Rows)
                    {
                        if (((CheckBox)row.FindControl("chkItems")).Checked == true)
                        {
                            ATTInvItemsTransfered obj = new ATTInvItemsTransfered();
                            obj.OrgID = int.Parse(row.Cells[1].Text);
                            obj.TransSEQ = int.Parse(row.Cells[2].Text);
                            obj.TransORG = int.Parse(row.Cells[3].Text);
                            obj.TransfOrgName = row.Cells[4].Text;
                            //obj.Quantity = int.Parse(row.Cells[5].Text);
                            obj.DecisionDate = row.Cells[6].Text;
                            obj.TransDate = row.Cells[7].Text;
                            obj.TransVia = int.Parse(row.Cells[8].Text);
                            obj.TransOrgUnit = int.Parse(row.Cells[9].Text);
                            obj.TransTo = int.Parse(row.Cells[10].Text);
                            obj.ItemsCategoryID = int.Parse(row.Cells[11].Text);
                            obj.ItemsCategoryName = row.Cells[12].Text;
                            obj.ItemsSubCategoryID = int.Parse(row.Cells[13].Text);
                            obj.ItemsSubCategoryName = row.Cells[14].Text;
                            obj.ItemsID = int.Parse(row.Cells[15].Text);
                            obj.ItemsName = row.Cells[16].Text;
                            obj.ItemsTypeID = int.Parse(row.Cells[17].Text);
                            obj.ItemsTypeName = row.Cells[18].Text;
                            obj.ItemsUnitID = int.Parse(row.Cells[19].Text);
                            obj.ItemsUnitName = row.Cells[20].Text;
                            obj.SeqNo = int.Parse(row.Cells[21].Text);
                            obj.TransRecvBy = user.OrgID;
                            obj.TransRecvDate = this.txtReceivedDate.Text.Trim();
                            obj.ReturnBy = null;
                            obj.ReturnDate = "";
                            obj.ReturnRecvDate = "";
                            obj.ReturnVia = null;
                            obj.Action = "E";
                            lstNew.Add(obj);
                            count++;
                        }
                    }
                    if (BLLInvItemsTransfered.SaveItemsTransfer(lstNew, "receive"))
                    {
                        this.lblStatusMessage.Text = "Received Items Saved";
                        this.programmaticModalPopup.Show();
                        Session["ItemsTransfKNJ"] = null;
                    }
                }

            }
            else if (lstItemsTransfKBJ.Count > 0)
            {
                if (((CheckBox)grdItemsTransfRecv.HeaderRow.FindControl("chkAllItems")).Checked == true)
                {
                    foreach (ATTInvItemsTransfered var in lstItemsTransfKBJ)
                    {
                        var.OrgID = var.OrgID;
                        var.ItemsCategoryID = var.ItemsCategoryID;
                        var.ItemsSubCategoryID = var.ItemsSubCategoryID;
                        var.ItemsID = var.ItemsID;
                        var.TransORG = var.TransORG;
                        var.TransSEQ = var.TransSEQ;
                        var.Quantity = var.Quantity;
                        var.DecisionDate = var.DecisionDate;
                        var.TransDate = var.TransDate;
                        var.TransVia = var.TransVia;
                        var.TransOrgUnit = var.TransOrgUnit;
                        var.TransTo = var.TransTo;
                        var.TransRecvDate = this.txtReceivedDate.Text.Trim();
                        var.TransRecvBy = user.OrgID;
                        var.ReturnBy = var.ReturnBy;
                        var.ReturnDate = var.ReturnDate;
                        var.ReturnVia = var.ReturnVia;
                        var.ReturnRecvBy = var.ReturnRecvBy;
                        var.ReturnRecvDate = var.ReturnRecvDate;
                        var.Action = "E";
                    }
                    if (BLLInvItemsTransfered.SaveItemsTransfer(lstItemsTransfKBJ, "receive"))
                    {
                        this.lblStatusMessage.Text = "Received Items Saved";
                        this.programmaticModalPopup.Show();
                        Session["ItemsTransfKBJ"] = null;
                    }
                }
                else
                {

                    int count = 0;
                    foreach (GridViewRow row in grdItemsTransfRecv.Rows)
                    {
                        if (((CheckBox)row.FindControl("chkItems")).Checked == true)
                        {
                            ATTInvItemsTransfered obj = new ATTInvItemsTransfered();
                            obj.OrgID = int.Parse(row.Cells[1].Text);
                            obj.TransSEQ = int.Parse(row.Cells[2].Text);
                            obj.TransORG = int.Parse(row.Cells[3].Text);
                            obj.TransfOrgName = row.Cells[4].Text;
                            obj.Quantity = int.Parse(row.Cells[5].Text);
                            obj.DecisionDate = row.Cells[6].Text;
                            obj.TransDate = row.Cells[7].Text;
                            obj.TransVia = int.Parse(row.Cells[8].Text);
                            obj.TransOrgUnit = int.Parse(row.Cells[9].Text);
                            obj.TransTo = int.Parse(row.Cells[10].Text);
                            obj.ItemsCategoryID = int.Parse(row.Cells[11].Text);
                            obj.ItemsCategoryName = row.Cells[12].Text;
                            obj.ItemsSubCategoryID = int.Parse(row.Cells[13].Text);
                            obj.ItemsSubCategoryName = row.Cells[14].Text;
                            obj.ItemsID = int.Parse(row.Cells[15].Text);
                            obj.ItemsName = row.Cells[16].Text;
                            obj.ItemsTypeID = int.Parse(row.Cells[17].Text);
                            obj.ItemsTypeName = row.Cells[18].Text;
                            obj.ItemsUnitID = int.Parse(row.Cells[19].Text);
                            obj.ItemsUnitName = row.Cells[20].Text;
                            obj.TransRecvBy = user.OrgID;
                            obj.TransRecvDate = this.txtReceivedDate.Text.Trim();
                            obj.ReturnBy = null;
                            obj.ReturnDate = "";
                            obj.ReturnRecvDate = "";
                            obj.ReturnVia = null;
                            obj.Action = "E";
                            lstNew.Add(obj);
                            count++;
                        }
                    }
                    if (BLLInvItemsTransfered.SaveItemsTransfer(lstNew, "receive"))
                    {
                        this.lblStatusMessage.Text = "Received Items Saved";
                        this.programmaticModalPopup.Show();
                        Session["ItemsTransfKBJ"] = null;
                    }
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
       
        ClearControls();
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    private void ClearControls()
    {
        ddlItemsType.SelectedIndex = 0;
        txtReceivedDate.Text = "";
        Panel2.Visible = false;
    }
    private bool CheckDateIsValid(string oldDate, string newDate)
    {
        string[] oldDt = oldDate.Split(new char[] { '/' });
        string[] newDt = newDate.Split(new char[] { '/' });

        int oldYr = int.Parse(oldDt[0]);
        int oldMth = int.Parse(oldDt[1]);
        int oldDy = int.Parse(oldDt[2]);

        int newYr = int.Parse(newDt[0]);
        int newMth = int.Parse(newDt[1]);
        int newDy = int.Parse(newDt[2]);

        bool val = false;

        if (newYr > oldYr)
        {
            val = true;
        }
        else if (newYr < oldYr)
        {
            val = false;
        }
        else if (newYr == oldYr)
        {
            if (newMth > oldMth)
            {
                val = true;
            }
            else if (newMth < oldMth)
            {
                val = false;
            }
            else if (newMth == oldMth)
            {
                if (newDy > oldDy)
                {
                    val = true;
                }
                else if (newDy < oldDy)
                {
                    val = false;
                }
                else if (newDy == oldDy)
                {
                    val = false;
                }
            }
        }

        return val;
    }
    
}
