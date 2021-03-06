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

public partial class MODULES_OAS_Tippani_TippaniChannel : System.Web.UI.Page
{
    new ATTUserLogin User
    {
        get { return Session["Login_User_Detail"] as ATTUserLogin; }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack==false)
        {
            ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];

            this.LoadTippaniSubject();
            this.LoadOrganization();
            this.LoadDesignations();
            this.LoadCommitteePost();

            //this.ddlTippaniOrg.SelectedValue = user.OrgID;
            this.ddlTippaniOrg.SelectedValue = "9";
            this.ddlTippaniOrg.Enabled = false;

            this.LoadTemporaryChannelSession();
        }
    }

    void LoadTemporaryChannelSession()
    {
        Session["TempTippaniSubject"] = new ATTOrganizationTippaniSubject();
    }

    void LoadOrganizationUnit()
    {
        try
        {
            List<ATTOrganizationUnit> lst = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(this.ddlOrganization.SelectedValue), null);
            lst.Insert(0, new ATTOrganizationUnit(-1, -1, "--- शाखा ---"));
            this.ddlUnit.DataSource = lst;
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadCommitteePost()
    {
        try
        {
            this.ddlCommitteePost.DataSource = BLLMemberPosition.GetMemberPositionList(null, true);
            this.ddlCommitteePost.DataTextField = "PositionName";
            this.ddlCommitteePost.DataValueField = "PositionID";
            this.ddlCommitteePost.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrganizationNameList();
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));
            
            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();

            this.ddlTippaniOrg.DataSource = OrganizationList;
            this.ddlTippaniOrg.DataTextField = "ORGNAME";
            this.ddlTippaniOrg.DataValueField = "ORGID";
            this.ddlTippaniOrg.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void LoadDesignations()
    {
        string desType = "";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", ""));
            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    void LoadTippaniSubject()
    {
        ATTUserLogin user = (ATTUserLogin)Session["Login_User_Detail"];

        try
        {
            Session["TippaniSubjectLst"] = BLLOrganizationTippaniSubject.GetOrganizaionTippaniSubjectList(this.User.OrgID, null, false);
            //Session["TippaniSubjectLst"] = BLLOrganizationTippaniSubject.GetOrganizaionTippaniSubjectList(user.OrgID, null, false);
            this.lstTippaniSubject.DataSource = Session["TippaniSubjectLst"];
            this.lstTippaniSubject.DataTextField = "TippaniSubjectName";
            this.lstTippaniSubject.DataValueField = "TippaniSubjectID";
            this.lstTippaniSubject.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            List<ATTGroupPersonSearch> lstPersonSearch;
            lstPersonSearch = BLLGroupPersonSearch.GetEmployeeFromWorkDistribution(GetFilter(), "5, 3");
            Session["PopupPersonSearch"] = lstPersonSearch;
            this.grdEmployee.DataSource = lstPersonSearch;
            this.grdEmployee.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = "Error Status";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    private ATTGroupPersonSearch GetFilter()
    {
        ATTGroupPersonSearch SearchPerson = new ATTGroupPersonSearch();

        SearchPerson.Gender = "";
        SearchPerson.MaritalStatus = "";
        SearchPerson.IniType = "";
        SearchPerson.PostName = "";

        SearchPerson.FirstName = this.txtFName.Text.Trim();
        SearchPerson.MiddleName = this.txtMName.Text.Trim();
        SearchPerson.SurName = this.txtSurName.Text.Trim();

        if (this.ddlGender.SelectedIndex > 0) SearchPerson.Gender = this.ddlGender.SelectedValue;

        SearchPerson.DOB = this.txtDOB.Text.Trim();

        if (this.ddlMarStatus.SelectedIndex > 0) SearchPerson.MaritalStatus = this.ddlMarStatus.SelectedValue;

        if (this.ddlOrganization.SelectedIndex > 0) SearchPerson.IniType = this.ddlOrganization.SelectedValue;

        if (this.ddlDesignation.SelectedIndex > 0) SearchPerson.PostName = this.ddlDesignation.SelectedValue;

        if (this.ddlUnit.SelectedIndex > 0)
            SearchPerson.UnitID = int.Parse(this.ddlUnit.SelectedValue);

        if (this.ddlCommitteePost.SelectedIndex > 0)
            SearchPerson.GMPositionID = int.Parse(this.ddlCommitteePost.SelectedValue);

        return SearchPerson;
    }

    void ClearControls()
    {
        this.txtSymbolNo.Text = "";
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtSurName.Text = "";
        this.txtDOB.Text = "";
        this.ddlGender.SelectedIndex = 0;
        this.ddlMarStatus.SelectedIndex = 0;
        this.ddlOrganization.SelectedIndex = 0;
        this.ddlDesignation.SelectedIndex = 0;

        this.grdEmployee.DataSource = "";
        this.grdEmployee.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearControls();
    }

    protected void grdEmployee_DataBound(object sender, EventArgs e)
    {
        if (this.grdEmployee.Rows.Count > 0)
        {
            this.lblSearch.Text = "Total person: " + this.grdEmployee.Rows.Count.ToString();
        }
        else
        {
            this.lblSearch.Text = "";
        }
    }

    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[13].Visible = false;
        e.Row.Cells[14].Visible = false;
        e.Row.Cells[15].Visible = false;
        e.Row.Cells[16].Visible = false;
        e.Row.Cells[17].Visible = false;
        e.Row.Cells[18].Visible = false;
        e.Row.Cells[19].Visible = false;

        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //    if (((ATTPersonSearch)e.Row.DataItem).ApplicationID != 5)
        //        ((LinkButton)e.Row.Cells[11].Controls[0]).Enabled = false;
    }

    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrganizationUnit();

        //try
        //{
        //    this.ddlUnit.DataSource = BLLGroup.GetGroupListWithMember(int.Parse(this.ddlOrganization.SelectedValue), true);
        //    this.ddlUnit.DataTextField = "GroupName";
        //    this.ddlUnit.DataValueField = "GroupID";
        //    this.ddlUnit.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    this.lblStatusMessage.Text = "Error Status";
        //    this.lblStatusMessage.Text = ex.Message;
        //}
    }

    protected void btnAddChannelPerson_Click(object sender, EventArgs e)
    {
        if (this.lstTippaniSubject.SelectedIndex<0)
        {
            this.lblStatusMessage.Text = "Please select Tippani Subject from list.";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTOrganizationTippaniSubject tippani = (ATTOrganizationTippaniSubject)Session["TempTippaniSubject"];
        List<ATTTippaniChannel> lst = tippani.LstTippaniChannel;
        tippani.TippaniSubjectID = int.Parse(this.lstTippaniSubject.SelectedValue);

        int index = 0;
        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            lst[index].FromDate = ((TextBox)row.FindControl("txtFromDate_Rdt")).Text;
            lst[index].ChannelPersonOrder = int.Parse(((DropDownList)row.FindControl("ddlOrder_Rqd")).SelectedValue);
            lst[index].ChannelPersonType = ((DropDownList)row.FindControl("ddlType_Rqd")).SelectedValue;
            lst[index].IsFinalApprover = ((CheckBox)row.FindControl("chkApprover")).Checked;
            lst[index].ToDate = "";

            if (lst[index].Action != "D")
            {
                if
                    (
                        lst[index].NewValue == lst[index].OldValue && lst[index].Action != "A"
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


        string namelist = "";

        foreach (GridViewRow row in this.grdEmployee.Rows)
        {
            bool selected = ((CheckBox)row.FindControl("chkSelect")).Checked;
            
            if (selected == true)
            {
                ATTTippaniChannel channel = new ATTTippaniChannel();

                //channel.OrgID = int.Parse(this.ddlTippaniOrg.SelectedValue);
                channel.ChannelSeqID = 0;
                channel.OTOrgID = ((List<ATTOrganizationTippaniSubject>)Session["TippaniSubjectLst"])[this.lstTippaniSubject.SelectedIndex].OrgID;
                channel.OTFromDate = ((List<ATTOrganizationTippaniSubject>)Session["TippaniSubjectLst"])[this.lstTippaniSubject.SelectedIndex].FromDate;
                channel.TippaniSubjectID = int.Parse(this.lstTippaniSubject.SelectedValue);
                channel.ChannelPersonID = double.Parse(row.Cells[1].Text);
                channel.FromDate = "";
                channel.ToDate = "";
                channel.ChannelPersonOrder = 0;
                channel.ChannelPersonType = "0";
                channel.IsFinalApprover = false;
                channel.ChannelPersonName = row.Cells[2].Text;
                channel.OrgName = this.FilterText(row.Cells[7].Text);
                channel.DegName = this.FilterText(row.Cells[8].Text);
                channel.UnitID = int.Parse(row.Cells[15].Text);
                channel.UnitName = row.Cells[11].Text;
                channel.CommitteeName = this.FilterText(row.Cells[9].Text);
                channel.PostName = this.FilterText(row.Cells[10].Text);
                channel.OrgID = int.Parse(row.Cells[13].Text);
                channel.DesID = int.Parse(row.Cells[14].Text);
                channel.CreatedDate = row.Cells[16].Text;
                channel.PostID = int.Parse(row.Cells[17].Text);
                channel.PostFromDate = row.Cells[18].Text;
                channel.UnitFromDate = row.Cells[19].Text;
                channel.EntryBy = this.User.UserName;
                channel.Action = "A";

                bool exist = tippani.LstTippaniChannel.Exists
                                                            (
                                                                delegate(ATTTippaniChannel c)
                                                                {
                                                                    return
                                                                        c.TippaniSubjectID == channel.TippaniSubjectID &&
                                                                        c.ChannelPersonID == channel.ChannelPersonID;

                                                                }
                                                            );
                if (exist == false)
                    tippani.LstTippaniChannel.Add(channel);
                else
                    namelist = namelist + "----  " + channel.ChannelPersonName + "<br>";

                ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            }
        }

        this.grdChannelPerson.DataSource = tippani.LstTippaniChannel;
        this.grdChannelPerson.DataBind();
        this.grdChannelPerson.Focus();

        this.SetGridColor(12, 13, this.grdChannelPerson);

        if (namelist != string.Empty)
        {
            this.lblStatusMessage.Text = "Following person::<br><br>" + namelist + "<br> has been already added for this Tippani.<br>So these person cannot be added at this time.";
            this.programmaticModalPopup.Show();
        }
    }

    string FilterText(string s)
    {
        if (s == "&nbsp;")
            return "";
        else
            return s;
    }

    protected void grdChannelPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[14].Visible = false;
        e.Row.Cells[15].Visible = false;
        e.Row.Cells[16].Visible = false;
        e.Row.Cells[17].Visible = false;
        e.Row.Cells[18].Visible = false;
        e.Row.Cells[19].Visible = false;
        e.Row.Cells[20].Visible = false;
        e.Row.Cells[21].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string tableClientID = this.grdChannelPerson.ClientID;

            e.Row.Cells[2].Text = (e.Row.RowIndex + 1).ToString();
            ((CheckBox)e.Row.FindControl("chkApprover")).Attributes.Add("onclick", "ProcessFinalApprover(this)");
        }
    }

    protected void grdChannelPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // need to set five parameter and include SetGridColor(x,y,z) function

        List<ATTTippaniChannel> lst = ((ATTOrganizationTippaniSubject)Session["TempTippaniSubject"]).LstTippaniChannel;//param 1

        int ActIndex = 12;//param 2
        int DelCmdIndex = 13;//param 3
        GridView grd = this.grdChannelPerson;//param 4
        GridViewRow CurrentRow = this.grdChannelPerson.Rows[e.RowIndex];//param 5

        if (CurrentRow.Cells[ActIndex].Text == "A")
        {
            lst.RemoveAt(e.RowIndex);
            grd.DataSource = lst;
            grd.DataBind();
        }
        else if (CurrentRow.Cells[ActIndex].Text == "N" || CurrentRow.Cells[ActIndex].Text == "D" || CurrentRow.Cells[ActIndex].Text == "E")
        {
            if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Delete")
            {
                lst[e.RowIndex].Action = "D";
                grd.DataSource = lst;
                grd.DataBind();
            }
            else if (((LinkButton)CurrentRow.Cells[DelCmdIndex].Controls[0]).Text == "Undo")
            {
                lst[e.RowIndex].Action = "N";
                grd.DataSource = lst;
                grd.DataBind();
            }
        }
        this.SetGridColor(ActIndex, DelCmdIndex, grd);
    }

    void SetGridColor(int ActIndex, int DelCmdIndex, GridView grd)
    {
        foreach (GridViewRow row in grd.Rows)
        {
            if (row.Cells[ActIndex].Text == "D")
            {
                row.ForeColor = System.Drawing.Color.Red;
                ((LinkButton)row.Cells[DelCmdIndex].Controls[0]).Text = "Undo";
            }
            else if (row.Cells[ActIndex].Text == "N" || row.Cells[ActIndex].Text == "A" || row.Cells[ActIndex].Text == "E")
            {
                row.ForeColor = System.Drawing.Color.FromName("#1D2A5B");
                ((LinkButton)row.Cells[DelCmdIndex].Controls[0]).Text = "Delete";
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.lstTippaniSubject.SelectedIndex < 0)
        {
            this.lblStatusMessage.Text = "Please select any Tippani Subject from list";
            this.programmaticModalPopup.Show();
            return;
        }

        ATTOrganizationTippaniSubject tippani = (ATTOrganizationTippaniSubject)Session["TempTippaniSubject"];
        List<ATTTippaniChannel> lst = tippani.LstTippaniChannel;

        int index = 0;
        foreach (GridViewRow row in this.grdChannelPerson.Rows)
        {
            lst[index].FromDate = ((TextBox)row.FindControl("txtFromDate_Rdt")).Text;
            lst[index].ChannelPersonOrder = int.Parse(((DropDownList)row.FindControl("ddlOrder_Rqd")).SelectedValue);
            lst[index].ChannelPersonType = ((DropDownList)row.FindControl("ddlType_Rqd")).SelectedValue;
            lst[index].IsFinalApprover = ((CheckBox)row.FindControl("chkApprover")).Checked;
            lst[index].ToDate = "";

            if (lst[index].Action != "D")
            {
                if
                    (
                        lst[index].NewValue == lst[index].OldValue && lst[index].Action != "A"
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
            BLLTippaniChannel.AddTippaniChannel(lst);
            lst.RemoveAll
                (
                    delegate(ATTTippaniChannel c)
                    {
                        return c.Action == "D";
                    }
                );
            List<ATTOrganizationTippaniSubject> orgLst = (List<ATTOrganizationTippaniSubject>)Session["TippaniSubjectLst"];

            if (this.lstTippaniSubject.SelectedIndex < 0)
                orgLst.Add(tippani);
            else
                orgLst[this.lstTippaniSubject.SelectedIndex] = tippani;

            this.ClearME();

            this.lblStatusMessage.Text = "Tippani Subject Channel saved successfully.";
            this.programmaticModalPopup.Show();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void ClearME()
    {
        this.LoadTemporaryChannelSession();
        this.lstTippaniSubject.SelectedIndex = -1;
        this.grdChannelPerson.DataSource = "";
        this.grdChannelPerson.DataBind();
    }

    protected void lstTippaniSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["TempTippaniSubject"] = BLLTippaniSubject.CreateDeepCopy(((List<ATTOrganizationTippaniSubject>)Session["TippaniSubjectLst"])[this.lstTippaniSubject.SelectedIndex]);

        List<ATTTippaniChannel> lst = ((ATTOrganizationTippaniSubject)Session["TempTippaniSubject"]).LstTippaniChannel;
        this.grdChannelPerson.DataSource = lst;
        this.grdChannelPerson.DataBind();
    }

    protected void btnCancelSubmit_Click(object sender, EventArgs e)
    {
        this.ClearME();
    }
}
