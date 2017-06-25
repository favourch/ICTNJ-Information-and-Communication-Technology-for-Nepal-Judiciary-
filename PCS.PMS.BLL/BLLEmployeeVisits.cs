using System;
using System.Collections.Generic;
using System.Text;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeVisits
    {
        public static List<ATTEmployeeVisits> GetEmployeeVisits(object obj, double empID)
        {
            try
            {
                List<ATTEmployeeVisits> VisitsList = new List<ATTEmployeeVisits>();
                foreach (DataRow row in DLLEmployeeVisits.GetEmployeeVisit(empID, obj).Rows)
                {
                    int? countryID = null;
                    if (row["COUNTRY"] != System.DBNull.Value)
                        countryID = int.Parse(row["COUNTRY"].ToString());

                    ATTEmployeeVisits Visits = new ATTEmployeeVisits(
                        double.Parse(row["EMP_ID"].ToString()), int.Parse(row["SEQ_NO"].ToString()),
                        (row["PURPOSE"] == System.DBNull.Value ? "" : (string)row["PURPOSE"]),
                        (row["LOCATION"] == System.DBNull.Value ? "" : (string)row["LOCATION"]), countryID,
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]),
                        (row["VEHICLE"] == System.DBNull.Value ? "" : (string)row["VEHICLE"]),
                        (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]),
                    "");
                    Visits.CountryNepName = (row["COUNTRY_NEP_NAME"] == System.DBNull.Value ? "" : (string)row["COUNTRY_NEP_NAME"]);
                    VisitsList.Add(Visits);
                }

                return VisitsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
