using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLCountry
    {
        public static List<ATTCountry> GetCountries(int? countryID, int FlagForDefault)
        {
            List<ATTCountry> lstCountries = new List<ATTCountry>();

            foreach (DataRow row in DLLCountry.GetCountries(countryID).Rows)
            {
                ATTCountry obj = new ATTCountry(int.Parse(row["COUNTRY_ID"].ToString()),
                    ((row["COUNTRY_NEP_NAME"] == System.DBNull.Value) ? "" : (string)row["COUNTRY_NEP_NAME"]),
                    ((row["COUNTRY_ENG_NAME"] == System.DBNull.Value) ? "" : (string)row["COUNTRY_ENG_NAME"]),
                    ((row["COUNTRY_CODE"] == System.DBNull.Value) ? "" : (string)row["COUNTRY_CODE"]));
                lstCountries.Add(obj);
            }
            if (FlagForDefault == 0)
                lstCountries.Insert(0, new ATTCountry(0, "छान्नुहोस", "छान्नुहोस", ""));

            return lstCountries;
        }

        public static int SaveCountries(ATTCountry objCountries)
        {
            try
            {
                return DLLCountry.AddCountries(objCountries);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}