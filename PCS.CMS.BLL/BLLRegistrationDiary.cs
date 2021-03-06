using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLRegistrationDiary
    {
        public static List<ATTRegistrationDiary> GetRegistrationDiary(int orgID,int caseTypeID, int? regDiaryID, string active,int regDiaryDV,int regSubDV,int regNameDV)
        {
            try
            {
                List<ATTRegistrationDiary> registrationDiaryLIST = new List<ATTRegistrationDiary>();
                foreach (DataRow drow in DLLRegistrationDiary.GetRegistrationDiary(orgID,caseTypeID,regDiaryID,active).Rows)
                {
                    ATTRegistrationDiary registrationDiary = new ATTRegistrationDiary();

                    registrationDiary.OrgID = int.Parse(drow["ORG_ID"].ToString());
                    registrationDiary.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    registrationDiary.RegistrationDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    registrationDiary.RegistrationDiaryName = drow["REG_DIARY_NAME"].ToString();
                    registrationDiary.RegistrationDiaryCode = drow["REG_DIARY_CODE"].ToString();
                    registrationDiary.Active = drow["ACTIVE"].ToString();
                    registrationDiary.Action = "";

                    registrationDiary.RegistrationDiarySubjectLIST = BLLRegistrationDiarySubject.GetRegistrationDiarySubject(int.Parse(drow["ORG_ID"].ToString()),registrationDiary.CaseTypeID, int.Parse(registrationDiary.RegistrationDiaryID.ToString()), null, null,regSubDV,regNameDV);

                    registrationDiaryLIST.Add(registrationDiary);
                }
                if (regDiaryDV > 0)
                    registrationDiaryLIST.Insert(0, new ATTRegistrationDiary(0, 0, "छान्नहोस", "", ""));
                
                return registrationDiaryLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteRegistrationDiary(List<ATTRegistrationDiary> registrationDiaryLST)
        {
            try
            {
                return DLLRegistrationDiary.AddEditDeleteRegistrationDiary(registrationDiaryLST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

