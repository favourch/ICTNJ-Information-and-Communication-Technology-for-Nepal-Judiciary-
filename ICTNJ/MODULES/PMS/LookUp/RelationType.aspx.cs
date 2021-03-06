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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections.Generic;

public partial class MODULES_PMS_LookUp_RelationType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,32,1") == true)
        {
            if (!this.IsPostBack)
                LoadRelationType();
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadRelationType()
    {
        try
        {
            List<ATTRelationType> RelationTypeList = BLLRelationType.GetRelationTypes(null, 1);
            Session["RelationTypeList"] = RelationTypeList;
            this.lstRelationTypes.DataSource = RelationTypeList;
            this.lstRelationTypes.DataTextField = "RELATIONTYPENAME";
            this.lstRelationTypes.DataValueField = "RELATIONTYPEID";
            this.lstRelationTypes.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtRelationType_Rqd.Text == "")
        {
            this.lblStatusMessage.Text = "**र्कपया सम्बन्धको प्रकार भर्नुहोस्";
            this.programmaticModalPopup.Show();
            this.txtRelationType_Rqd.Focus();
            return;
        }
        int relationID = 0;
        string relationName = this.txtRelationType_Rqd.Text.Trim();
        List<ATTRelationType> RelationTypeList = (List<ATTRelationType>)Session["RelationTypeList"];
        ATTRelationType RelationType = new ATTRelationType(relationID, relationName);

        if (this.lstRelationTypes.SelectedIndex > -1)
        {
            RelationType.RelationTypeID = RelationTypeList[this.lstRelationTypes.SelectedIndex].RelationTypeID;
            RelationType.Action = "E";
        }
        else
            RelationType.Action = "A";
        if (this.txtCardinality.Text.Trim() != "")
            RelationType.RelationTypeCardinality = int.Parse(this.txtCardinality.Text.Trim());
        bool exists = RelationTypeList.Exists(delegate(ATTRelationType obj)
                                                {
                                                    return (obj.RelationTypeName == RelationType.RelationTypeName);
                                                }
                                             );
        if (exists)
        {
            this.lblStatusMessage.Text = "**सोहि नामको सम्बन्धको प्रकार पहिले नै उपलब्द छ";
            this.programmaticModalPopup.Show();
            this.txtRelationType_Rqd.Text = "";
            this.txtCardinality.Text = "";
            this.lstRelationTypes.SelectedIndex = -1;
            return;
            this.txtRelationType_Rqd.Focus();
        }
        try
        {
            BLLRelationType.SaveRelationType(RelationType);
            if (this.lstRelationTypes.SelectedIndex > -1)
                RelationTypeList[this.lstRelationTypes.SelectedIndex] = RelationType;
            else
                RelationTypeList.Add(RelationType);

            if (lstRelationTypes.SelectedIndex == -1)
            {
                this.lblStatusMessage.Text = "Relation Type Saved Successfully .";
                this.programmaticModalPopup.Show();
            }
            else
            {
                this.lblStatusMessage.Text = "Relation Type Updated Successfully .";
                this.programmaticModalPopup.Show();
            }
            this.lstRelationTypes.DataSource = RelationTypeList;
            this.lstRelationTypes.DataBind();
            this.txtRelationType_Rqd.Text = "";
            this.txtCardinality.Text = "";
            this.lstRelationTypes.SelectedIndex = -1;
            this.txtRelationType_Rqd.Focus();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtRelationType_Rqd.Text = "";
        this.txtCardinality.Text = "";
        this.lstRelationTypes.SelectedIndex = -1;
    }

    protected void lstRelationTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<ATTRelationType> RelationTypeList=(List<ATTRelationType>) Session["RelationTypeList"];
        this.txtRelationType_Rqd.Text = RelationTypeList[this.lstRelationTypes.SelectedIndex].RelationTypeName;
        if (RelationTypeList[this.lstRelationTypes.SelectedIndex].RelationTypeCardinality != null)
            this.txtCardinality.Text = RelationTypeList[this.lstRelationTypes.SelectedIndex].RelationTypeCardinality.ToString();
        else
            this.txtCardinality.Text = "";
    }
}
