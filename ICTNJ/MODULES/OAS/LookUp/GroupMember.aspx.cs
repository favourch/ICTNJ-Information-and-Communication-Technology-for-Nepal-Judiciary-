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

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_OAS_LookUp_GroupMember : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("5,69,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                this.LoadOrganization();
                this.SetTemporaryGroupMember();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void SetTemporaryGroupMember()
    {
        Session["TmpGrpMember"] = new List<ATTGroupMember>();
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(0, "-------- Select Organization --------"));
            this.ddlOrg_Rqd.DataSource = lst;
            this.ddlOrg_Rqd.DataTextField = "OrgName";
            this.ddlOrg_Rqd.DataValueField = "OrgID";
            this.ddlOrg_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGroup();
        this.grdGrpMember.DataSource = "";
        this.grdGrpMember.DataBind();
    }

    void LoadGroup()
    {
        try
        {
            Session["Grouplst"] = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrg_Rqd.SelectedValue), false, 'G');
            this.lstCommittee.DataSource = Session["GroupLst"];
            this.lstCommittee.DataTextField = "GroupName";
            this.lstCommittee.DataValueField = "GroupID";
            this.lstCommittee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void grdGrpMember_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;

    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        if (this.ddlOrg_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select any organization from list";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.lstCommittee.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select any group from list";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTGroupMember> lst = (List<ATTGroupMember>)Session["TmpGrpMember"];
        string namelist = "";
        foreach (GridViewRow row in this.EmployeeSearch.GrdMemberEmployee.Rows)
        {
            CheckBox box = ((CheckBox)row.FindControl("chkSelect"));
            if (box.Checked == true)
            {
                ATTGroupMember member = new ATTGroupMember();

                member.OrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
                member.GroupID = int.Parse(this.lstCommittee.SelectedValue);
                member.EmpID = double.Parse(row.Cells[0].Text);
                member.EmpName = row.Cells[2].Text;
                member.MemberPostion.PositionID = 0;
                //member.OFromDate = ".";
                //member.ToDate = ".";
                //member.PositionID = 0;
                member.Action = "A";

                bool exist = lst.Exists
                                        (
                                            delegate(ATTGroupMember c)
                                            {
                                                return
                                                    c.OrgID == member.OrgID &&
                                                    c.GroupID == member.GroupID &&
                                                    c.EmpID == member.EmpID;

                                            }
                                        );

                if (exist == false)
                    lst.Add(member);
                else
                    namelist = namelist + "----  " + member.EmpName + "<br>";


                box.Checked = false;
            }
        }

        this.grdGrpMember.DataSource = lst;
        this.grdGrpMember.DataBind();

        this.SetGridColor();

        if (namelist != string.Empty)
        {
            this.lblStatusMessage.Text = "Following person::<br><br>" + namelist + "<br> has been already added for this Committee.<br>So these person cannot be added at this time.";
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ddlOrg_Rqd.SelectedIndex <= 0)
        {
            this.lblStatusMessage.Text = "Please select any organization from list";
            this.programmaticModalPopup.Show();
            return;
        }

        if (this.lstCommittee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "Please select any group from list";
            this.programmaticModalPopup.Show();
            return;
        }

        List<ATTGroupMember> lst = (List<ATTGroupMember>)Session["TmpGrpMember"];

        int index = 0;
        foreach (GridViewRow row in this.grdGrpMember.Rows)
        {
            lst[index].FromDate = ((TextBox)row.FindControl("txxFromDate_Rdt")).Text;
            //lst[index].ToDate = ((TextBox)row.FindControl("txtToDate_Dt")).Text;
            lst[index].ToDate = "";
            lst[index].MemberPostion.PositionID = 0;

            if (lst[index].Action != "D")
            {
                if
                    (
                        lst[index].FromDate == lst[index].OFromDate &&
                        lst[index].ToDate == lst[index].OToDate &&
                        lst[index].PositionID == lst[index].OPositionID && lst[index].Action != "A"
                    )
                    lst[index].Action = "N";
                else
                {
                    if (lst[index].Action == "A")
                        lst[index].Action = "A";
                    else
                        lst[index].Action = "E";
                }
            }

            index++;
        }

        try
        {
            BLLGroupMember.AddGroupMember(lst);
            lst.RemoveAll
                (
                    delegate(ATTGroupMember m)
                    {
                        return m.Action == "D";
                    }
                );
            List<ATTGroupMember> lstGroupMem = ((List<ATTGroup>)Session["GroupLst"])[this.lstCommittee.SelectedIndex].LstGroupMember;
            lstGroupMem = lst;

            this.ClearMe();

            this.lblStatusMessage.Text = "Group member successfully saved.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    string GetTrimedString(string s)
    {
        if (s == "&nbsp;")
            return "";
        else
            return s;
    }

    void ClearMe()
    {
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.lstCommittee.DataSource = "";
        this.lstCommittee.DataBind();

        this.grdGrpMember.DataSource = "";
        this.grdGrpMember.DataBind();

        this.SetTemporaryGroupMember();
    }

    protected void grdGrpMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTGroupMember> grpMemLst = ((List<ATTGroupMember>)Session["TmpGrpMember"]);

        if (this.grdGrpMember.Rows[e.RowIndex].Cells[3].Text == "A")
        {
            grpMemLst.RemoveAt(e.RowIndex);
            this.grdGrpMember.DataSource = grpMemLst;
            this.grdGrpMember.DataBind();
        }
        else if (this.grdGrpMember.Rows[e.RowIndex].Cells[3].Text == "N" || this.grdGrpMember.Rows[e.RowIndex].Cells[3].Text == "D")
        {
            if (((LinkButton)this.grdGrpMember.Rows[e.RowIndex].Cells[4].Controls[0]).Text == "Delete")
            {
                grpMemLst[e.RowIndex].Action = "D";
                this.grdGrpMember.DataSource = grpMemLst;
                this.grdGrpMember.DataBind();
                this.grdGrpMember.Rows[e.RowIndex].ForeColor = System.Drawing.Color.Red;
                ((LinkButton)this.grdGrpMember.Rows[e.RowIndex].Cells[4].Controls[0]).Text = "Undo";
            }
            else if (((LinkButton)this.grdGrpMember.Rows[e.RowIndex].Cells[4].Controls[0]).Text == "Undo")
            {
                grpMemLst[e.RowIndex].Action = "N";
                this.grdGrpMember.DataSource = grpMemLst;
                this.grdGrpMember.DataBind();
                this.grdGrpMember.Rows[e.RowIndex].ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)this.grdGrpMember.Rows[e.RowIndex].Cells[4].Controls[0]).Text = "Delete";
            }
        }

        this.SetGridColor();
    }

    void SetGridColor()
    {
        foreach (GridViewRow row in this.grdGrpMember.Rows)
        {
            if (row.Cells[3].Text == "D")
            {
                row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)row.Cells[4].Controls[0]).Text = "Undo";
            }
            else if (row.Cells[3].Text == "N" || row.Cells[3].Text == "A")
            {
                row.ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)row.Cells[4].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        this.ClearMe();
    }

    protected void grdGrpMember_DataBound(object sender, EventArgs e)
    {
        //if (this.grdGrpMember.Rows.Count > 0)
        //{
        //    this.pnlGroupMember.Visible = true;
        //}
        //else
        //{
        //    this.pnlGroupMember.Visible = false;
        //}
    }

    protected void lstCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTGroup> lstGrp = ((List<ATTGroup>)Session["GroupLst"]);
        List<ATTGroupMember> lstGrpMem = lstGrp[this.lstCommittee.SelectedIndex].LstGroupMember;

        List<ATTGroupMember> tmplstGrpMem = (List<ATTGroupMember>)Session["TmpGrpMember"];

        tmplstGrpMem.Clear();
        foreach (ATTGroupMember mem in lstGrpMem)
        {
            ATTGroupMember tmp = new ATTGroupMember();

            tmp.OrgID = mem.OrgID;
            tmp.GroupID = mem.GroupID;
            tmp.EmpID = mem.EmpID;
            tmp.EmpName = mem.EmpName;
            tmp.FromDate = mem.FromDate;
            tmp.ToDate = mem.ToDate;
            tmp.MemberPostion.PositionID = mem.MemberPostion.PositionID;
            tmp.MemberPostion.PositionName = mem.MemberPostion.PositionName;
            tmp.Action = mem.Action;
            tmp.OFromDate = mem.FromDate;
            tmp.OToDate = mem.ToDate;
            tmp.OPositionID = mem.PositionID;

            tmplstGrpMem.Add(tmp);
        }

        this.grdGrpMember.DataSource = tmplstGrpMem;
        this.grdGrpMember.DataBind();
    }
}