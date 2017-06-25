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

using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public class RemoveMenuItemList
{
    private MenuItem _ChildMenuItem;
    public MenuItem ChildMenuItem
    {
        get { return this._ChildMenuItem; }
        set { this._ChildMenuItem = value; }
    }

    private MenuItem _ParentMenuItem;
    public MenuItem ParentMenuItem
    {
        get { return this._ParentMenuItem; }
        set { this._ParentMenuItem = value; }
    }

    public RemoveMenuItemList(MenuItem child, MenuItem parent)
    {
        this.ChildMenuItem = child;
        this.ParentMenuItem = parent;
    }
}

public partial class MODULES_LJMS_LJMSMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.Master.IsPostBack == false)
        {
            if (Session["Login_User_Detail"] != null)
            {
                this.GetAllMenuItems(this.LJMSMenu);
                ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
                this.headerText1.Text = user.OrgName;
                this.headerText2.Text = user.OrgAddress;

                Session["NepDate"] = BLLDate.getNepDate();
                Session["EngDate"] = BLLDate.getEngDate();
                //this.lbldate.Text = (string)Session["NepDate"] + "<BR>" + (string)Session["EngDate"]; 
            }
        }
    }


    protected void GetAllMenuItems(Menu mnu)
    {
        Dictionary<string, AccessColumn> mnuLst = ((PCS.SECURITY.ATT.ATTUserLogin)Session["Login_User_Detail"]).MenuList;

        List<RemoveMenuItemList> menuItemListToRemove = new List<RemoveMenuItemList>();
        //List<RemoveMenuItemList> menuItemListToRemoveForm2L = new List<RemoveMenuItemList>();

        foreach (MenuItem lvl1 in mnu.Items)
        {
            foreach (MenuItem lvl2 in lvl1.ChildItems)
            {
                //menuItemListToRemoveForm2L.Add(new RemoveMenuItemList(lvl2, lvl2.Parent));
                if (!mnuLst.ContainsKey(lvl2.Value) && lvl2.ChildItems.Count <= 0)
                {
                    menuItemListToRemove.Add(new RemoveMenuItemList(lvl2, lvl2.Parent));
                }
                foreach (MenuItem lvl3 in lvl2.ChildItems)
                {
                    if (!mnuLst.ContainsKey(lvl3.Value) && lvl3.ChildItems.Count <= 0)
                    {
                        menuItemListToRemove.Add(new RemoveMenuItemList(lvl3, lvl3.Parent));
                    }
                    foreach (MenuItem lvl4 in lvl3.ChildItems)
                    {
                        if (!mnuLst.ContainsKey(lvl4.Value) && lvl4.ChildItems.Count <= 0)
                        {
                            menuItemListToRemove.Add(new RemoveMenuItemList(lvl4, lvl4.Parent));
                        }
                        foreach (MenuItem lvl5 in lvl4.ChildItems)
                        {
                            {
                                menuItemListToRemove.Add(new RemoveMenuItemList(lvl5, lvl5.Parent));
                            }
                        }
                    }
                }
            }
        }

        foreach (RemoveMenuItemList removeMe in menuItemListToRemove)
        {
            removeMe.ParentMenuItem.ChildItems.Remove(removeMe.ChildMenuItem);
        }

        //foreach (MenuItem lvl1 in mnu.Items)
        //{
        //    foreach (MenuItem lvl2 in lvl1.ChildItems)
        //    {
        //        if (lvl2.ChildItems.Count <= 0)
        //            lvl2.Parent.ChildItems.Remove(lvl2);
        //    }
        //}
    }

    protected void LJMSMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.ToolTip == "#")
            return;

        Session["List_Menuname"] = e.Item.Value;
        Response.Redirect("~/" + e.Item.ToolTip + ".aspx"); ;
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();

        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Redirect("~/MODULES/Login.aspx", true);
    }
    protected void LJMSMenu_MenuItemDataBound(object sender, MenuEventArgs e)
    {

    }
}
