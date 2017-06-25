using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonPhone
    {
        public static List<ATTPersonPhone> GetPersonPhone(object obj, double personID)
        {
            List<ATTPersonPhone> PhoneList = new List<ATTPersonPhone>();
            try
            {
                foreach (DataRow row in DLLPersonPhone.GetPersonPhone(personID, obj).Rows)
                {
                    ATTPersonPhone Phone = new ATTPersonPhone(
                        double.Parse(row["P_ID"].ToString()), (string)row["P_TYPE"],
                        int.Parse(row["P_SNO"].ToString()),
                        (row["PHONE"] == System.DBNull.Value ? "" : (string)row["PHONE"]),
                        (row["ACTIVE"] == System.DBNull.Value ? "" : (string)row["ACTIVE"]),
                        (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]),
                        "", DateTime.Now);

                    Phone.PhoneType = (string)row["PHONE_TYPE"];

                    PhoneList.Add(Phone);

                }
                return PhoneList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
