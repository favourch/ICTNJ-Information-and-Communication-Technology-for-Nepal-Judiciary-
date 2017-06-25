using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLWard
    {


        public static List<ATTWard> GetWards(int? distCode, int? vdcCode, int FlagForDefault)
        {
            List<ATTWard> lstWards = new List<ATTWard>();

            foreach (DataRow row in DLLWard.GetWards(distCode,vdcCode).Rows)
            {
                ATTWard obj = new ATTWard(int.Parse(row["DISTCODE"].ToString()),
                    int.Parse(row["VDCCODE"].ToString()),
                    int.Parse(row["WARD"].ToString()));

                lstWards.Add(obj);
            }
            if (FlagForDefault == 0)
                lstWards.Insert(0, new ATTWard(0, 0, 0));

            return lstWards;
        }
        public static List<ATTWard> GetWardList(int? distCode, int? vdcCode)
        {
            List<ATTWard> lstWards = new List<ATTWard>();

            foreach (DataRow row in DLLWard.GetWards(distCode, vdcCode).Rows)
            {
                ATTWard obj = new ATTWard(int.Parse(row["DISTCODE"].ToString()),
                    int.Parse(row["VDCCODE"].ToString()),
                    int.Parse(row["WARD"].ToString()));

                lstWards.Add(obj);
            }
            return lstWards;
        }

    }
}
