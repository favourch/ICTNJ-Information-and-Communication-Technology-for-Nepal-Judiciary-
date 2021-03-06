using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLRegistrationDiaryName
    {
        public static List<ATTRegistrationDiaryName> GetRegistrationDiaryName(int orgID,int caseTypeID, int regDiaryID, int SubjectID, int? regDiaryNameID, string active,int regDiaryNameDV)
        {
            try
            {
                List<ATTRegistrationDiaryName> registrationDiaryNameLIST = new List<ATTRegistrationDiaryName>();
                foreach (DataRow drow in DLLRegistrationDiaryName.GetRegistrationDiaryName(orgID,caseTypeID,regDiaryID, SubjectID,regDiaryNameID,active).Rows)
                {
                    ATTRegistrationDiaryName registrationDiaryName=new ATTRegistrationDiaryName();
                   
                    registrationDiaryName.OrgID = int.Parse(drow["ORG_ID"].ToString());
                    registrationDiaryName.CaseTypeID=int.Parse(drow["CASE_TYPE_ID"].ToString());
                    registrationDiaryName.RegistrationDiaryID=int.Parse(drow["REG_DIARY_ID"].ToString());
                    registrationDiaryName.RegistrationSubjectID=int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    registrationDiaryName.RegistrationDiaryNameID=int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    registrationDiaryName.RegistrationDiaryName=drow["REG_DIARY_NAME"].ToString();
                    registrationDiaryName.RegistrationDiaryNameDescription=drow["REG_DIARY_NAME_DESC"].ToString();
                    registrationDiaryName.Active=drow["ACTIVE"].ToString();
                    registrationDiaryName.Action="";

                    registrationDiaryNameLIST.Add(registrationDiaryName);
                }
                if (regDiaryNameDV > 0)
                    registrationDiaryNameLIST.Insert(0, new ATTRegistrationDiaryName(0, 0, 0, 0, "छान्नहोस", "", ""));
                return registrationDiaryNameLIST;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
