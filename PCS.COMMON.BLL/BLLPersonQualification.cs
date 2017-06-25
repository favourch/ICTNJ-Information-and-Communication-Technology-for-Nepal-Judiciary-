using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonQualification
    {
        public static List<ATTPersonQualification> GetPersonQualification(object obj, double pID)
        {
            try
            {
                List<ATTPersonQualification> QualificationList = new List<ATTPersonQualification>();
                foreach (DataRow row in DLLPersonQualification.GetPersonQualification(pID, obj).Rows)
                {
                    long? institutionID = null;
                    float? percentage = null;
                    if ((row["INSTITUTION_ID"]) != System.DBNull.Value)
                        institutionID = long.Parse(row["INSTITUTION_ID"].ToString());
                    if ((row["PERCENTAGE"]) != System.DBNull.Value)
                        percentage = float.Parse(row["PERCENTAGE"].ToString());

                    ATTPersonQualification Qualification = new ATTPersonQualification(
                        double.Parse(row["P_ID"].ToString()), int.Parse(row["SEQ_NO"].ToString()),
                        (row["SUBJECT"] == System.DBNull.Value ? "" : (string)row["SUBJECT"]),
                        int.Parse(row["DEGREE_ID"].ToString()), institutionID,
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]),
                        (row["GRADE"] == System.DBNull.Value ? "" : (string)row["GRADE"]),
                        percentage, (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]),
                    "");

                    if (row["DEGREE_NAME"] != System.DBNull.Value)
                        Qualification.DegreeName = (string)row["DEGREE_NAME"];
                    if (row["INSTITUTION_NAME"] != System.DBNull.Value)
                        Qualification.InstitutionName = (string)row["INSTITUTION_NAME"];
                    QualificationList.Add(Qualification);
                }

                return QualificationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
