using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLZone
    {
        public static List<ATTZone> GetZones(int? zoneID, int FlagForDefault)
        {
            List<ATTZone> lstZones = new List<ATTZone>();

            foreach (DataRow row in DLLZone.GetZones(zoneID).Rows)
            {
                ATTZone obj = new ATTZone(int.Parse(row["ZONE_ID"].ToString()),
                    ((row["ZONE_NAME"] == System.DBNull.Value) ? "" : (string)row["ZONE_NAME"]));
                lstZones.Add(obj);
            }
            if (FlagForDefault == 0)
                lstZones.Insert(0, new ATTZone(0,"-- Select Zone--"));

            return lstZones;
        }
    }
}
