using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;
namespace PCS.CMS.BLL
{
    public class BLLAttorney
    {

        public static List<ATTAttorney> GetAttorney(double? CaseID,string active)
        {
            try
            {
                List<ATTAttorney> attorneyLIST = new List<ATTAttorney>();
                foreach (DataRow drow in DLLAttorney.GetAttorney(CaseID, active).Rows)
                {
                    ATTAttorney attorney = new ATTAttorney();

                    attorney.CaseID = double.Parse(drow["CASE_ID"].ToString());
                    attorney.LitigantID = double.Parse(drow["LITIGANT_ID"].ToString());
                    attorney.PersonID = double.Parse(drow["PERSON_ID"].ToString());
                    attorney.AttorneyID = double.Parse(drow["ATTORNEY_ID"].ToString());
                    attorney.AttorneyTypeID = int.Parse(drow["ATTORNEY_TYPE_ID"].ToString());
                    attorney.FromDate = drow["FROM_DATE"].ToString();
                    attorney.ToDate = drow["TO_DATE"].ToString();
                    attorney.Active = drow["ACTIVE"].ToString();
                    attorney.Action = "";

                    attorney.LitigantName = drow["LITIGANTNAME"].ToString();
                    attorney.LitigantGender = drow["LIT_GENDER"].ToString();
                    attorney.LitigantDOB = drow["LIT_DOB"].ToString();
                    attorney.AttorneyName = drow["ATTORNEYNAME"].ToString();
                    attorney.AttorneyGender = drow["ATT_GENDER"].ToString();
                    attorney.AttorneyDOB = drow["ATT_DOB"].ToString();
                    attorney.AttorneyType = drow["ATTORNEY_TYPE_NAME"].ToString();

                    attorneyLIST.Add(attorney);
                }
                return attorneyLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddEditDeleteAttorney(List<ATTAttorney> attorneyLST)
        {
            try
            {
                return DLLAttorney.AddEditDeleteAttorney(attorneyLST);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
