using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLBenchType
    {
        public static bool SaveBenchType(ATTBenchType objBenchType)
        {
            try
            {
                return DLLBenchType.SaveBenchType(objBenchType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTBenchType> GetBenchType(int? BenchTypeID, string active, int defaultFlag)
        {
            List<ATTBenchType> BenchTypeLST = new List<ATTBenchType>();
            try
            {
                foreach (DataRow row in DLLBenchType.GetBenchType(BenchTypeID, active).Rows)
                {
                    ATTBenchType objBenchType = new ATTBenchType();
                    objBenchType.BenchTypeID = int.Parse(row["BENCH_TYPE_ID"].ToString());
                    objBenchType.BenchTypeName = row["BENCH_TYPE_NAME"].ToString();
                    objBenchType.Active = row["ACTIVE"].ToString();
                    BenchTypeLST.Add(objBenchType);
                }

                if (defaultFlag > 0)
                {
                    ATTBenchType obj = new ATTBenchType();
                    obj.BenchTypeID = 0;
                    obj.BenchTypeName = "छान्नुहोस";
                    BenchTypeLST.Insert(0, obj);

                }
                return BenchTypeLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
