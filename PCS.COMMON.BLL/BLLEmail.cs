using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.COMMON.ATT;
using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL

{
    public class BLLEmail
    {
        public static List<ATTEmail> GetEmail(int? OrgId)
        {
            try
            {
                return (GetEmailList(DLLEmail.GetEmail(OrgId)));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<ATTEmail> GetEmailList(DataTable tbl)
        {
            List<ATTEmail> lst = new List<ATTEmail>();
            
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTEmail ATTObj = new ATTEmail
                                                (
                                                int.Parse(row["org_id"].ToString()),
                                               (string)row["e_type"],
                                                (string)row["email_type"],
                                                int.Parse(row["e_sno"].ToString()),
                                                (string)row["email"],
                                                (string)row["active"],
                                                "shyam remarks",
                                              null,
                                               DateTime.Now
                                                );


                    lst.Add(ATTObj);
                }
                return lst;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
