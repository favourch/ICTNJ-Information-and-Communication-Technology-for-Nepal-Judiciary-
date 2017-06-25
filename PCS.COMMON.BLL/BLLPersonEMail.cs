using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonEMail
    {
        public static List<ATTPersonEMail> GetPersonEMail(object obj, double personID)
        {
            List<ATTPersonEMail> EMailList = new List<ATTPersonEMail>();
            try
            {
                foreach (DataRow row in DLLPersonEMail.GetPersonEMail(personID, obj).Rows)
                {
                    ATTPersonEMail EMail = new ATTPersonEMail(
                        double.Parse(row["P_ID"].ToString()), (string)row["E_TYPE"],
                        int.Parse(row["E_SNO"].ToString()),
                        (row["EMAIL"] == System.DBNull.Value ? "" : (string)row["EMAIL"]),
                        (row["ACTIVE"] == System.DBNull.Value ? "" : (string)row["ACTIVE"]),
                        (row["REMARK"] == System.DBNull.Value ? "" : (string)row["REMARK"]),
                        "",DateTime.Now);

                    EMail.EMailType = (string)row["EMAIL_TYPE"];

                    EMailList.Add(EMail);

                }
                return EMailList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
