using System;
using System.Collections.Generic;
using System.Text;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.LJMS.BLL
{
    public class BLLPrivateLawyerRenewal
    {
        public static List<ATTPrivateLawyerRenewal> GetPrivateLawyerRenewal(double PID)
        {
            List<ATTPrivateLawyerRenewal> lst = new List<ATTPrivateLawyerRenewal>();
            try
            {
                foreach (DataRow row in DLL.DLLPrivateLawyerRenewal.GetPrivateLawyerRenewal(PID).Rows)
                {
                    ATTPrivateLawyerRenewal obj = new ATTPrivateLawyerRenewal();

                    obj.PersonID = double.Parse(row["p_id"].ToString());
                    obj.LawyerTypeID = int.Parse(row["lawyer_type_id"].ToString());
                    obj.Lisence = row["LICENSE_NO"].ToString();
                    obj.UnitID = int.Parse(row["unit_id"].ToString());
                    obj.UnitName = row["unit_name"].ToString();
                    obj.RenewalDate = row["renewal_date"].ToString();
                    obj.RenewalUpto = row["renewal_upto"].ToString();
                    obj.EntryBy = "";
                    obj.Action = "N";

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPrivateLawyerRenewalDetails(double PID)
        {
            try
            {
                return DLLPrivateLawyerRenewal.GetPrivateLawyerRenewalDetailsTable(PID);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
