using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLCourtFee
    {
        public static List<ATTCourtFee> GetCourtFee(int defaultFlag)
        {
            List<ATTCourtFee> CourtFeeLST = new List<ATTCourtFee>();
            try
            {
                foreach (DataRow row in DLLCourtFee.GetCourtFee().Rows)
                {
                    ATTCourtFee objCourtFee = new ATTCourtFee();
                    objCourtFee.FromDate= row["FROM_DATE"].ToString();
                    objCourtFee.FromAmount =double.Parse( row["FROM_AMOUNT"].ToString());
                    if (row["TO_AMOUNT"] == System.DBNull.Value)
                        objCourtFee.ToAmount = null;
                    else
                        objCourtFee.ToAmount = double.Parse(row["TO_AMOUNT"].ToString());
                    objCourtFee.AmtPer= double.Parse( row["AMT_PER"].ToString());
                    objCourtFee.AmtPerType= row["AMT_PER_TYPE"].ToString();
                    objCourtFee.FromToAmt = row["AMOUNT_RANGE"].ToString();
                    
                    CourtFeeLST.Add(objCourtFee);
                }

                if (defaultFlag > 0)
                {
                    //ATTCourtFee obj = new ATTCourtFee();
                    //obj.BenchTypeID = 0;
                    //obj.BenchTypeName = "छान्नुहोस";
                    //BenchTypeLST.Insert(0, obj);

                }
                return CourtFeeLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveCourtFee(List<ATTCourtFee> CourtFeeLST)
        {
            try
            {
                return DLLCourtFee.SaveCourtFee(CourtFeeLST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
