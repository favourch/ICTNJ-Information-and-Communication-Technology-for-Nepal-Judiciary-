using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
namespace PCS.CMS.BLL
{
    public class BLLBench
    {
        public static bool SaveBench(List<ATTBench> lstBench)
        {
            try
            {
                return DLLBench.SaveBench(lstBench);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTBench> GetBench(int orgID, int? benchNo, string active, int defaultFlag)
        {
            List<ATTBench> BenchLST = new List<ATTBench>();
            try
            {
                foreach (DataRow row in DLLBench.GetBench(orgID, benchNo, active).Rows)
                {
                    ATTBench objBench = new ATTBench();
                    objBench.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objBench.BenchNo = int.Parse(row["BENCH_NO"].ToString());
                    objBench.BenchDesc = row["BENCH_DESC"].ToString();
                    objBench.Active = row["ACTIVE"].ToString();
                    BenchLST.Add(objBench);
                }

                if (defaultFlag > 0)
                {
                    ATTBench obj = new ATTBench();
                    obj.BenchNo = 0;
                    obj.BenchDesc = "छान्नुहोस";
                    BenchLST.Insert(0, obj);

                }
                return BenchLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
