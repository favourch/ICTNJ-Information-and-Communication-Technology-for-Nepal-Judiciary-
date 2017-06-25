using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.LJMS.ATT;
using PCS.LJMS.DLL;

namespace PCS.LJMS.BLL
{
    public class BLLLawyerSearch
    {
        public static List<ATTLawyerSearch> GetLawyerList(ATTLawyerSearch search)
        {
            List<ATTLawyerSearch> lst = new List<ATTLawyerSearch>();
            char[] token ={ '_' };
            try
            {
                DataTable tbl = DLLLawyerSearch.GetLawyerTable(search);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTLawyerSearch obj = new ATTLawyerSearch();
                    obj.PersonID = double.Parse(row["P_ID"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MidName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                    obj.Lisence = row["license_no"].ToString();
                    obj.LawyerTypeName = row["lawyer_type_description"].ToString();
                    obj.LastRenewalDate = row["LAWYER_LAST_REN_DATE"].ToString();
                    obj.LastRenewalUpto = row["LAWYER_LAST_REN_UPTO"].ToString();
                    obj.PvtLawyerLastRenewalDate = row["P_LAWYER_LAST_REN_DATE"].ToString();
                    obj.PvtLawyerLastRenewalUpto = row["P_LAWYER_LAST_REN_UPTO"].ToString();
                    obj.UnitName = row["unit_name"].ToString();
                    obj.ACTIVE = row["ACTIVE"].ToString();
                    obj.Gender = row["gender"].ToString();

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTLawyerCount> GetLawyerCount(ATTLawyerCount cnt)
        {
            List<ATTLawyerCount> lst = new List<ATTLawyerCount>();

            try
            {
                foreach (DataRow row in DLLLawyerSearch.GetLawyerCount(cnt).Rows)
                {
                    ATTLawyerCount obj = new ATTLawyerCount();
                    if (cnt.Type == LawyerType.NepalBarCouncil)
                    {
                        obj.UnitName = row["unit_name"].ToString();
                    }
                    else
                    {
                        obj.UnitName = "";
                    }
                    obj.LawyerTypeName = row["lawyer_type_description"].ToString();
                    obj.Gender = row["gender"].ToString();
                    obj.Total = int.Parse(row["total"].ToString());

                    lst.Add(obj);
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
