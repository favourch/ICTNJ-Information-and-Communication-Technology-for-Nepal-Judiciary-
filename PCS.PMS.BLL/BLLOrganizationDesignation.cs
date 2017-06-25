using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLOrganizationDesignation
    {

        public static ObjectValidation Validate(ATTOrganizationDesignation ObjAtt)
        {
            ObjectValidation OV = new ObjectValidation();
            if (ObjAtt.OrgID==0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select The Organization.";
                return OV;
            }

            if (ObjAtt.DesID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select The Designation.";
                return OV;
            }
            if (ObjAtt.TotalSeats == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Total Seats Cannot Be Empty.";
                return OV;
            }

            if (ObjAtt.SewaID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select Sewa.";
                return OV;
            }

            if (ObjAtt.SamuhaID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select Samuha.";
                return OV;
            }
            if (ObjAtt.UpaSamuhaID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select UpaSamuma.";
                return OV;
            }

            if (ObjAtt.DesgLevelID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Select Shreni.";
                return OV;
            }

            return OV;
        }

        public static List<ATTOrganizationDesignation> GetOrganizationDesignation(int? orgID, int? desID,string desType)
        {
            List<ATTOrganizationDesignation> LstOrganizationDesignation = new List<ATTOrganizationDesignation>();

            try
            {
                foreach (DataRow row in DLLOrganizationDesignation.GetOrganizationDesignation(orgID,desID,desType).Rows)
                {
                    ATTOrganizationDesignation ObjAtt = new ATTOrganizationDesignation
                        (
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        int.Parse(row["TOT_SEATS"].ToString()),
                        int.Parse(row["SEWA_ID"].ToString()),
                        int.Parse(row["SAMUHA_ID"].ToString()),
                        int.Parse(row["UPASAMUHA_ID"].ToString()),
                        int.Parse(row["DESG_LEVEL_ID"].ToString()));

                    ObjAtt.CreatedDate = (string)row["CREATED_DATE"];
                    ObjAtt.SewaName = (string)row["SEWA_NAME"];
                    ObjAtt.SamuhaName = (string)row["SAMUHA_NAME"];
                    ObjAtt.UpaSamuhaName = (string)row["UPA_SAMUHA_NAME"];
                    ObjAtt.DesgLevelName = (string)row["LEVEL_NAME"];
                    ObjAtt.OrgName = (string)row["ORG_NAME"];
                    ObjAtt.DesName = (string)row["DES_NAME"];
                    ObjAtt.DesType = (string)row["DES_TYPE"];
                    if (row["PARENT_ORG"] != System.DBNull.Value)
                        ObjAtt.ParentOrg = int.Parse(row["PARENT_ORG"].ToString());
                    if (row["PARENT_DES"] != System.DBNull.Value)
                        ObjAtt.ParentDes = int.Parse(row["PARENT_DES"].ToString());
                    LstOrganizationDesignation.Add(ObjAtt);
                }
                return LstOrganizationDesignation;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool SaveOrganizationDesignation(ATTOrganizationDesignation ObjAtt)
        {
            try
            {
                return DLLOrganizationDesignation.SaveOrganizationDesignation(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
