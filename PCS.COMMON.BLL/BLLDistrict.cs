using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLDistrict
    {
        public static List<ATTDistrict> GetDistricts(int? distCode, int FlagForDefault)
        {
            List<ATTDistrict> lstDistricts = new List<ATTDistrict>();
            List<ATTVDC> lstVDCs = BLLVDC.GetVDCs(distCode, null, FlagForDefault);

            foreach (DataRow row in DLLDistrict.GetDistricts(distCode).Rows)
            {
                ATTDistrict obj = new ATTDistrict(int.Parse(row["DISTCODE"].ToString()),
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),                    
                    ((row["ENG_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["ENG_DISTNAME"]),
                    ((row["DIST_UCODE"] == System.DBNull.Value) ? "" : (string)row["DIST_UCODE"]),
                    int.Parse(row["ZONE_ID"].ToString()));

                obj.LstVDCs = lstVDCs.FindAll(delegate(ATTVDC vdc) { return vdc.DistCode == obj.DistCode; });

                lstDistricts.Add(obj);
            }
            if (FlagForDefault == 0)
                lstDistricts.Insert(0, new ATTDistrict(0, "-- Select District--", "",0));

            return lstDistricts;
        }

        public static List<ATTDistrict> GetDistrictList(int? distCode)
        {
            List<ATTDistrict> lstDistricts = new List<ATTDistrict>();

            foreach (DataRow row in DLLDistrict.GetDistricts(distCode).Rows)
            {
                ATTDistrict obj = new ATTDistrict(int.Parse(row["DISTCODE"].ToString()),
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),
                    ((row["ENG_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["ENG_DISTNAME"]),
                    ((row["DIST_UCODE"] == System.DBNull.Value) ? "" : (string)row["DIST_UCODE"]),
                    int.Parse(row["ZONE_ID"].ToString()));

                lstDistricts.Add(obj);
            }
            return lstDistricts;
        }

    }
}