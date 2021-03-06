using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLOrganizationCaseType
    {
        //public static bool SaveOrgCaseType(List<ATTOrganizationCaseType> lstOrgCaseType)
        //{
        //    try
        //    {
        //        return DLLOrganizationCaseType.SaveOrgCaseType(lstOrgCaseType);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static List<ATTOrganizationCaseType> GetOrgCaseType(int? orgID,int? caseTypeID, string active, int defaultFlag,int regDiaryDV,int regSubDV,int regNameDV)
        {
            List<ATTOrganizationCaseType> OrgCaseTypeList = new List<ATTOrganizationCaseType>();
            try
            {
                foreach (DataRow row in DLLOrganizationCaseType.GetOrgCaseType(orgID,caseTypeID, active).Rows)
                {
                    ATTOrganizationCaseType attOCT = new ATTOrganizationCaseType
                        (
                            int.Parse(row["ORG_ID"].ToString()),
                            int.Parse(row["CASE_TYPE_ID"].ToString()),
                            row["ACTIVE"].ToString()
                        );
                    attOCT.CaseTypeName = row["CASE_TYPE_NAME"].ToString();

                    attOCT.LstRegistrationDiary = BLLRegistrationDiary.GetRegistrationDiary(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["CASE_TYPE_ID"].ToString()), null, null,regDiaryDV,regSubDV,regNameDV);
                    
                    attOCT.OrgCaseRegistrationTypeLST = BLLOrgCaseRegistrationType.GetOrgCaseRegType(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["CASE_TYPE_ID"].ToString()), null, "Y",1);

                    OrgCaseTypeList.Add(attOCT);


                }

                if (defaultFlag > 0)
                {
                    ATTOrganizationCaseType obj=new ATTOrganizationCaseType(0, 0, "");
                    obj.CaseTypeName="छान्नुहोस";
                    OrgCaseTypeList.Insert(0,obj );
                
                }
                return OrgCaseTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganizationCaseType> GetOrgByCaseType(int caseTypeID, string active, int defaultFlag)
        {
            List<ATTOrganizationCaseType> OrgCaseTypeList = new List<ATTOrganizationCaseType>();
            try
            {
                foreach (DataRow row in DLLOrganizationCaseType.GetOrgCaseType(null,caseTypeID, active).Rows)
                {
                    ATTOrganizationCaseType attOCT = new ATTOrganizationCaseType
                        (
                            int.Parse(row["ORG_ID"].ToString()),
                            int.Parse(row["CASE_TYPE_ID"].ToString()),
                            row["ACTIVE"].ToString()
                        );
                    attOCT.OrgName = row["ORG_NAME"].ToString();
                    attOCT.LstRegistrationDiary = BLLRegistrationDiary.GetRegistrationDiary(int.Parse(row["ORG_ID"].ToString()), caseTypeID, null, null,0,0,0);
                    OrgCaseTypeList.Add(attOCT);
                }

                if (defaultFlag > 0)
                    OrgCaseTypeList.Insert(0, new ATTOrganizationCaseType(0, 0, "छान्नुहोस"));
                return OrgCaseTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
