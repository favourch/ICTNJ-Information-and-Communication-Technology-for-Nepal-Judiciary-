using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
namespace PCS.CMS.ATT
{
    public class BLLBenchFormation
    {
        public static bool SaveBenchFormation(ATTBenchFormation objBenchFormation)
        {
            try
            {
                return DLLBenchFormation.SaveBenchFormation(objBenchFormation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTBenchFormation> GetBenchFormation(int orgID,  int defaultFlag)
        {
            List<ATTBenchFormation> BenchFormationLST = new List<ATTBenchFormation>();
            try
            {
                foreach (DataRow row in DLLBenchFormation.GetBenchFormation(orgID).Rows)
                {
                    ATTBenchFormation objBenchFormation = new ATTBenchFormation();
                    objBenchFormation.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objBenchFormation.BenchTypeID = int.Parse(row["BENCH_TYPE_ID"].ToString());
                    objBenchFormation.BenchNo = int.Parse(row["BENCH_NO"].ToString());
                    objBenchFormation.FromDate = row["FROM_DATE"].ToString();
                    objBenchFormation.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    objBenchFormation.BenchTypeName = row["BENCH_TYPE_NAME"].ToString();
                    objBenchFormation.BenchDesc = row["BENCH_DESC"].ToString();
                    objBenchFormation.JudgeList = DLLBenchFormation.GetJudgeList(objBenchFormation);
                    BenchFormationLST.Add(objBenchFormation);
                }

                //if (defaultFlag > 0)
                //{
                //    ATTBenchFormation obj = new ATTBenchFormation();
                //    obj.BenchFormationID = 0;
                //    obj.BenchFormationName = "छान्नुहोस";
                //    BenchFormationLST.Insert(0, obj);

                //}
                return BenchFormationLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
