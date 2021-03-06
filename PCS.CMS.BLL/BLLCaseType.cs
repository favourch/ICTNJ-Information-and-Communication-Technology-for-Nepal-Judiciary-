using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseType
    {
        public static List<ATTCaseType> GetCaseType(int? caseTypeID, string active,int FlagForDefault)
        {
            try
            {
                List<ATTCaseType> caseTypeLIST = new List<ATTCaseType>();
                foreach (DataRow drow in DLLCaseType.GetCaseType(caseTypeID,active).Rows)
                {
                    ATTCaseType caseType = new ATTCaseType();

                    caseType.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    caseType.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    caseType.Appellant = drow["APPELLANT"].ToString();
                    caseType.Respondant = drow["RESPONDENT"].ToString();
                    caseType.Active = drow["ACTIVE"].ToString();
                    caseType.Action="";

                    caseType.OrganisationCaseTypesLIST = BLLOrganizationCaseType.GetOrgByCaseType(int.Parse(caseType.CaseTypeID.ToString()),null,0);

                    caseTypeLIST.Add(caseType);
                }
                if(FlagForDefault>0)
                    caseTypeLIST.Insert(0,new ATTCaseType(0,"छान्नुहोस","","",""));
                return caseTypeLIST;
            }
            catch (Exception ex )
            {                
                throw ex;
            }
        }

        public static bool AddEditDeleteCaseType(ATTCaseType caseType)
        {
            try
            {
               return DLLCaseType.AddEditDeleteCaseType(caseType);
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}
