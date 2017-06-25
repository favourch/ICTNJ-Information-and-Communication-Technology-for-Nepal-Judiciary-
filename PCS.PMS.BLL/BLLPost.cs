using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLPost
    {

        public static ObjectValidation Validate(ATTPost ObjAtt)
        {
            ObjectValidation OV = new ObjectValidation();
            if (ObjAtt.PostName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Post Name Cannot Be Blank.";
                return OV;
            }
            return OV;
        }

        public static List<ATTPost> GetOrgDesgPost(int? orgID, int? desID, string createdDate)
        {
            List<ATTPost> LstOrgDesgPost = new List<ATTPost>();

            try
            {
                foreach (DataRow row in DLLPost.GetOrganizationPosts(orgID, desID,createdDate).Rows)
                {
                    ATTPost ObjAtt = new ATTPost
                        (
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        (row["CREATED_DATE"] == System.DBNull.Value ? "" : (string)row["CREATED_DATE"]),
                        int.Parse(row["POST_ID"].ToString()),
                        (row["POST_NAME"] == System.DBNull.Value ? "" : (string)row["POST_NAME"]),
                        (row["OCCUPIED"] == System.DBNull.Value ? "" : (string)row["OCCUPIED"]));

                    ObjAtt.OrgName = (string)row["ORG_NAME"];
                    ObjAtt.DesName = (string)row["DES_NAME"];
                    LstOrgDesgPost.Add(ObjAtt);
                }
                return LstOrgDesgPost;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<ATTPost> GetOrgAvailableDesgPost(int? orgID, int? desID, string availablePost, string desType)
        {
            List<ATTPost> LstOrgDesgPost = new List<ATTPost>();
            try
            {
                foreach (DataRow row in DLLPost.GetOrgAvailableDesgPost(orgID, desID, availablePost, desType).Rows)
                {
                    ATTPost ObjAtt = new ATTPost
                        (
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        (row["CREATED_DATE"] == System.DBNull.Value ? "" : (string)row["CREATED_DATE"]),
                        int.Parse(row["POST_ID"].ToString()),
                        (row["POST_NAME"] == System.DBNull.Value ? "" : (string)row["POST_NAME"]),
                        (row["OCCUPIED"] == System.DBNull.Value ? "" : (string)row["OCCUPIED"]));
                    ObjAtt.DesName = (string)row["DES_NAME"];
                    LstOrgDesgPost.Add(ObjAtt);
                }
                return LstOrgDesgPost;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<ATTPost> GetAllDesgPost(int? orgID, int? desID, string created_date)
        {
            List<ATTPost> LstOrgDesgPost = new List<ATTPost>();
            try
            {
                foreach (DataRow row in DLLPost.GetAllDesgPost(orgID, desID, created_date).Rows)
                {
                    ATTPost ObjAtt = new ATTPost
                        (
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        (row["CREATED_DATE"] == System.DBNull.Value ? "" : (string)row["CREATED_DATE"]),
                        int.Parse(row["POST_ID"].ToString()),
                        (row["POST_NAME"] == System.DBNull.Value ? "" : (string)row["POST_NAME"]),
                        (row["OCCUPIED"] == System.DBNull.Value ? "" : (string)row["OCCUPIED"]));
                    ObjAtt.DesName = (string)row["DES_NAME"];
                    LstOrgDesgPost.Add(ObjAtt);
                }
                return LstOrgDesgPost;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool SavePosts(ATTPost ObjAtt)
        {
            try
            {
                return true;//DLLOrganizationDesignation.SaveOrganizationDesignation(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
