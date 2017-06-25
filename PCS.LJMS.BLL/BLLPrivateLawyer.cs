using System;
using System.Collections.Generic;
using System.Text;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.LJMS.BLL
{
    public class BLLPrivateLawyer
    {
        public static bool AddPrivateLawyerInfoList(List<ATTPrivateLawyer> lst)
        {
            try
            {
                return DLLPrivateLawyer.AddPrivateLawyerInfoList(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTPrivateLawyer> GetPrivateLawyerInfo(double PID)
        {
            List<ATTPrivateLawyer> lst = new List<ATTPrivateLawyer>();
            try
            {
                List<ATTPrivateLawyerRenewal> lstRenewal = BLLPrivateLawyerRenewal.GetPrivateLawyerRenewal(PID);
                foreach (DataRow row in DLL.DLLPrivateLawyer.GetPrivateLawyerInfo(PID).Rows)
                {
                    ATTPrivateLawyer obj = new ATTPrivateLawyer();

                    obj.PersonID = double.Parse(row["p_id"].ToString());
                    obj.LawyerTypeID = int.Parse(row["lawyer_type_id"].ToString());
                    obj.Lisence = row["LICENSE_NO"].ToString();
                    obj.UnitID = int.Parse(row["unit_id"].ToString());
                    obj.UnitName = row["unit_name"].ToString();
                    obj.FromDate = row["from_date"].ToString();
                    obj.ToDate = row["to_date"].ToString();
                    obj.EntryBy = "";
                    obj.Action = "N";
                    obj.LstRenewal = lstRenewal.FindAll
                                                    (
                                                        delegate(ATTPrivateLawyerRenewal r)
                                                        {
                                                            return
                                                                r.PersonID == obj.PersonID &&
                                                                r.LawyerTypeID == obj.LawyerTypeID &&
                                                                r.Lisence == obj.Lisence &&
                                                                r.UnitID == obj.UnitID;
                                                        }
                                                    );

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPrivateLawyerDetails(double PID)
        {
            try
            {
                return DLLPrivateLawyer.GetPrivateLawyerDetailsTable(PID);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}