using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLRegistrationDiarySubject
    {
        public static List<ATTRegistrationDiarySubject> GetRegistrationDiarySubject(int orgID,int caseTypeID, int regDiaryID, int? SubjectID, string active,int regSubDV,int regDiaryNameDV)
        {
            try
            {
                List<ATTRegistrationDiarySubject> registrationDiarySubjectLIST = new List<ATTRegistrationDiarySubject>();
                foreach (DataRow drow in DLLRegistrationDiarySubject.GetRegistrationDiarySubject(orgID,caseTypeID, regDiaryID,SubjectID,active).Rows)
                {
                    ATTRegistrationDiarySubject registrationDiarySubject = new ATTRegistrationDiarySubject();
                    registrationDiarySubject.OrgID = int.Parse(drow["ORG_ID"].ToString());
                    registrationDiarySubject.CaseTypeID=int.Parse(drow["CASE_TYPE_ID"].ToString());
                    registrationDiarySubject.RegistrationDiaryID=int.Parse(drow["REG_DIARY_ID"].ToString());
                    registrationDiarySubject.SubjectID=int.Parse(drow["SUBJECT_ID"].ToString());
                    registrationDiarySubject.SubjectName=drow["SUBJECT_NAME"].ToString();
                    registrationDiarySubject.Active=drow["ACTIVE"].ToString();
                    registrationDiarySubject.Action = "";

                    registrationDiarySubject.RegistrationDiaryNameLIST = BLLRegistrationDiaryName.GetRegistrationDiaryName
                                                                            (
                                                                            int.Parse(drow["ORG_ID"].ToString()),
                                                                            registrationDiarySubject.CaseTypeID, 
                                                                            registrationDiarySubject.RegistrationDiaryID, 
                                                                            int.Parse(registrationDiarySubject.SubjectID.ToString()),
                                                                            null, null,regDiaryNameDV);

                    registrationDiarySubjectLIST.Add(registrationDiarySubject);
                }
                if (regSubDV > 0)
                    registrationDiarySubjectLIST.Insert(0, new ATTRegistrationDiarySubject(0, 0, 0, "छान्नहोस", ""));
                return registrationDiarySubjectLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
