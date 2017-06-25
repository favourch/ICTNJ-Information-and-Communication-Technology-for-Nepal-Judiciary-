using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLVDC
    {
        public static List<ATTVDC> GetVDCs(int? distCode,int? vdcCode, int FlagForDefault)
        {
            List<ATTVDC> lstVDCs = new List<ATTVDC>();
            List<ATTWard> lstWards = BLLWard.GetWards(distCode, vdcCode, FlagForDefault);

            foreach (DataRow row in DLLVDC.GetVDCs(distCode,vdcCode).Rows)
            {
                ATTVDC obj = new ATTVDC(int.Parse(row["DISTCODE"].ToString()),
                    int.Parse(row["VDCCODE"].ToString()),
                    ((row["NEP_VDCNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_VDCNAME"]),                    
                    ((row["ENG_VDCNAME"] == System.DBNull.Value) ? "" : (string)row["ENG_VDCNAME"]),
                    ((row["VDC_UCODE"] == System.DBNull.Value) ? "" : (string)row["VDC_UCODE"]),
                    int.Parse(row["VDC_TYPE"].ToString()));

                obj.LstWards = lstWards.FindAll(delegate(ATTWard ward) { return obj.DistCode == ward.DistCode && obj.VdcCode == ward.VdcCode; });
                lstVDCs.Add(obj);
            }
            if (FlagForDefault == 0)
                lstVDCs.Insert(0, new ATTVDC(0,0, "-- Select VDC--", "", 0));

            return lstVDCs;
        }

        public static List<ATTVDC> GetVDCList(int? distCode, int? vdcCode)
        {
            List<ATTVDC> lstVDCs = new List<ATTVDC>();

            foreach (DataRow row in DLLVDC.GetVDCs(distCode, vdcCode).Rows)
            {
                ATTVDC obj = new ATTVDC(int.Parse(row["DISTCODE"].ToString()),
                    int.Parse(row["VDCCODE"].ToString()),
                    ((row["NEP_VDCNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_VDCNAME"]),
                    ((row["ENG_VDCNAME"] == System.DBNull.Value) ? "" : (string)row["ENG_VDCNAME"]),
                    ((row["VDC_UCODE"] == System.DBNull.Value) ? "" : (string)row["VDC_UCODE"]),
                    int.Parse(row["VDC_TYPE"].ToString()));
                lstVDCs.Add(obj);
            }
            return lstVDCs;
        }
    }
}
