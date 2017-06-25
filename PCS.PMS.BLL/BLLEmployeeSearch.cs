using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeSearch
    {
        public static List<ATTEmployeeSearch> SearchEmployee(ATTEmployeeSearch objEmployee)
            //flag defines whether or not to load employee other attributes.0-no,1-yes
        {
            List<ATTEmployeeSearch> lstEmployee = new List<ATTEmployeeSearch>();

            foreach (DataRow row in DLLEmployeeSearch.SearchEmployee(objEmployee).Rows)
            {
                ATTEmployeeSearch obj = new ATTEmployeeSearch(double.Parse(row["EMP_ID"].ToString()),
                    ((row["SYMBOL_NO"] == System.DBNull.Value) ? "" : (string)row["SYMBOL_NO"]),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    ((row["MARTIAL_STATUS"] == System.DBNull.Value) ? "" : (string)row["MARTIAL_STATUS"]));

                if (row["COUNTRY_ID"] == System.DBNull.Value)
                    obj.CountryID = null;
                else
                    obj.CountryID = int.Parse(row["COUNTRY_ID"].ToString());

                if (row["BIRTH_DISTRICT"] == System.DBNull.Value)
                    obj.BirthDistrict = null;
                else
                    obj.BirthDistrict = int.Parse(row["BIRTH_DISTRICT"].ToString());

                if (row["RELIGION_ID"] == System.DBNull.Value)
                    obj.ReligionID = null;
                else
                    obj.ReligionID = int.Parse(row["RELIGION_ID"].ToString());


                obj.IdentityMark = ((row["IDENTITY_MARK"] == System.DBNull.Value) ? "" : (string)row["IDENTITY_MARK"]);
                obj.DesName = ((row["DES_NAME"] == System.DBNull.Value) ? "" : (string)row["DES_NAME"]);
                obj.OrgName = ((row["ORG_NAME"] == System.DBNull.Value) ? "" : (string)row["ORG_NAME"]);
                obj.LevelName = ((row["LEVEL_NAME"] == System.DBNull.Value) ? "" : (string)row["LEVEL_NAME"]);
                obj.CitznNo = ((row["CIT_NO"] == System.DBNull.Value) ? "" : (string)row["CIT_NO"]);
                obj.PFNo = ((row["PROVIDENT_FUND_NO"] == System.DBNull.Value) ? "" : (string)row["PROVIDENT_FUND_NO"]);
                if (row["ORG_EMP_NO"]!= System.DBNull.Value)
                {
                    obj.OfficeNo = int.Parse(row["ORG_EMP_NO"].ToString());
                }
                
                lstEmployee.Add(obj);
            }
            return lstEmployee;
        }

        public static List<ATTEmployeeSearch> SearchEmployeeForOrgUnitHead(ATTEmployeeSearch objEmployee)
        //flag defines whether or not to load employee other attributes.0-no,1-yes
        {
            List<ATTEmployeeSearch> lstEmployee = new List<ATTEmployeeSearch>();

            foreach (DataRow row in DLLEmployeeSearch.SearchEmployeeForOrgUnitHead(objEmployee).Rows)
            {
                ATTEmployeeSearch obj = new ATTEmployeeSearch(double.Parse(row["EMP_ID"].ToString()),
                    ((row["SYMBOL_NO"] == System.DBNull.Value) ? "" : (string)row["SYMBOL_NO"]),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    "");


                obj.OrgName = ((row["ORG_NAME"] == System.DBNull.Value) ? "" : (string)row["ORG_NAME"]);
                obj.UnitName = ((row["UNIT_NAME"] == System.DBNull.Value) ? "" : (string)row["UNIT_NAME"]);
                obj.FromDate = ((row["FROM_DATE"] == System.DBNull.Value) ? "" : (string)row["FROM_DATE"]);
                obj.ToDate = ((row["TO_DATE"] == System.DBNull.Value) ? "" : (string)row["TO_DATE"]);
                obj.UnitHead = ((row["UNIT_HEAD"] == System.DBNull.Value) ? "" : (string)row["UNIT_HEAD"]);
                obj.OfficeHead = ((row["OFFICE_HEAD"] == System.DBNull.Value) ? "" : (string)row["OFFICE_HEAD"]);

                if (row["ORG_EMP_NO"] != System.DBNull.Value)
                {
                    obj.OfficeNo = int.Parse(row["ORG_EMP_NO"].ToString());
                }
                if (row["ORG_ID"] != System.DBNull.Value)
                {
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                }
                if (row["UNIT_ID"] != System.DBNull.Value)
                {
                    obj.UnitID = int.Parse(row["UNIT_ID"].ToString());
                }

                lstEmployee.Add(obj);
            }
            return lstEmployee;
        }


        public static List<ATTPersonSearch> SearchPersonWithPostIF(ATTPersonSearch objPerson)
        {
            List<ATTPersonSearch> lstPerson = new List<ATTPersonSearch>();

            foreach (DataRow row in DLLEmployeeSearch.SearchPersonWithPostIF(objPerson).Rows)
            {
                ATTPersonSearch obj = new ATTPersonSearch(double.Parse(row["P_ID"].ToString()),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),
                    ((row["FATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["FATHER_NAME"]),
                    ((row["GFATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["GFATHER_NAME"]),
                    ((row["POST_NAME"] == System.DBNull.Value) ? "." : (string)row["POST_NAME"]));

                lstPerson.Add(obj);
            }
            return lstPerson;
        }

    }
}
