using System;
using System.Collections.Generic;
using System.Text;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeExperience
    {
        public static List<ATTEmployeeExperience> GetEmployeeExperience(object obj, double empID)
        {
            try
            {
                List<ATTEmployeeExperience> ExperienceList = new List<ATTEmployeeExperience>();
                foreach (DataRow row in DLLEmployeeExperience.GetEmployeeExperience(empID, obj).Rows)
                {
                    ATTEmployeeExperience Experience = new ATTEmployeeExperience(
                        double.Parse(row["EMP_ID"].ToString()), int.Parse(row["SEQ_NO"].ToString()),
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]),
                        (row["POSTING_LOCATION"] == System.DBNull.Value ? "" : (string)row["POSTING_LOCATION"]),
                        (row["JOB_LOCATION"] == System.DBNull.Value ? "" : (string)row["JOB_LOCATION"]),
                        (row["CLASSIFICATION"] == System.DBNull.Value ? "" : (string)row["CLASSIFICATION"]),
                        (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]),
                    "");
                    ExperienceList.Add(Experience);
                }

                return ExperienceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
