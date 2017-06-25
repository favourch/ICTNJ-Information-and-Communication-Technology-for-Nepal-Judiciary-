using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonTraining
    {
        public static List<ATTPersonTraining> GetPersonTraining(object obj, double pID)
        {
            try
            {
                List<ATTPersonTraining> TrainingList = new List<ATTPersonTraining>();
                foreach (DataRow row in DLLPersonTraining.GetPersonTraining(pID, obj).Rows)
                {
                    long? institutionID = null;
                    float? percentage = null;
                    if ((row["INSTITUTION_ID"]) != System.DBNull.Value)
                        institutionID = long.Parse(row["INSTITUTION_ID"].ToString());
                    if ((row["PERCENTAGE"]) != System.DBNull.Value)
                        percentage = float.Parse(row["PERCENTAGE"].ToString());

                    ATTPersonTraining Training = new ATTPersonTraining(
                        double.Parse(row["P_ID"].ToString()), int.Parse(row["SEQ_NO"].ToString()),
                        (row["SUBJECT"] == System.DBNull.Value ? "" : (string)row["SUBJECT"]),
                        (row["CERTIFICATE_NAME"] == System.DBNull.Value ? "" : (string)row["CERTIFICATE_NAME"]), institutionID,
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]),
                        (row["GRADE"] == System.DBNull.Value ? "" : (string)row["GRADE"]),
                        percentage, (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]),
                    "");

                    if (row["INSTITUTION_NAME"] != System.DBNull.Value)
                        Training.InstitutionName = (string)row["INSTITUTION_NAME"];


                    TrainingList.Add(Training);
                }
                return TrainingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
