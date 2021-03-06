using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLReligion
    {
        public static List<ATTReligion> GetReligions(int? relgID,int FlagForDefault)
        {
            List<ATTReligion> lstReligions = new List<ATTReligion>();

            foreach (DataRow row in DLLReligion.GetReligions(relgID).Rows)
            {
                ATTReligion obj = new ATTReligion(int.Parse(row["RELIGION_ID"].ToString()),
                                        ((row["RELIGION_NEP_NAME"] == System.DBNull.Value) ? "" : (string)row["RELIGION_NEP_NAME"]),
                    ((row["RELIGION_ENG_NAME"] == System.DBNull.Value) ? "" : (string)row["RELIGION_ENG_NAME"]));

                lstReligions.Add(obj);
            }
            if (FlagForDefault == 0)
                lstReligions.Insert(0, new ATTReligion(0, "छान्नुहोस", ""));

            return lstReligions;
        }

        public static int SaveReligions(ATTReligion objReligions)
        {
            try
            {
                return DLLReligion.AddReligions(objReligions);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
