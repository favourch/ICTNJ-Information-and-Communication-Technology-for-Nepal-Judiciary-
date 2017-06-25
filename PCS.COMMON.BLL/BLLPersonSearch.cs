using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLPersonSearch
    {
        public static List<ATTPersonSearch> SearchPerson(ATTPersonSearch objPerson)
        {
            List<ATTPersonSearch> lstPerson = new List<ATTPersonSearch>();

            foreach (DataRow row in DLLPersonSearch.SearchPerson(objPerson).Rows)
            {
                ATTPersonSearch obj = new ATTPersonSearch(double.Parse(row["P_ID"].ToString()),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),
                    ((row["FATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["FATHER_NAME"]),
                    ((row["GFATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["GFATHER_NAME"]));

                obj.MaritalStatus = (row["MARTIAL_STATUS"] == System.DBNull.Value ? "" : (string)row["MARTIAL_STATUS"]);
                if (row["BIRTH_DISTRICT"] != System.DBNull.Value)
                    obj.BirthDistrict = int.Parse(row["BIRTH_DISTRICT"].ToString());
                if (row["COUNTRY_ID"] != System.DBNull.Value)
                    obj.CountryID = int.Parse(row["COUNTRY_ID"].ToString());
                lstPerson.Add(obj);
            }
            return lstPerson;
        }
    }
}
