using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLVwEmpRelativeBeneficiary
    {
        public static List<ATTVwEmpRelativeBeneficiary> GetEmpRelativeBeneficiary(double empID, object obj)
        {
            List<ATTVwEmpRelativeBeneficiary> lstEmpBeneficiary = new List<ATTVwEmpRelativeBeneficiary>();

            foreach (DataRow row in DLLVwEmpRelativeBeneficiary.GetEmpRelativeBeneficiary(empID,obj).Rows)
            {
                int? birthDistrict = null;
                if (row["BIRTH_DISTRICT"] != System.DBNull.Value)
                    birthDistrict = int.Parse(row["BIRTH_DISTRICT"].ToString());
                ATTVwEmpRelativeBeneficiary objBen = new ATTVwEmpRelativeBeneficiary
                    (
                    double.Parse(row["P_ID"].ToString()),
                    double.Parse(row["RELATIVE_ID"].ToString()),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["MARTIAL_STATUS"] == System.DBNull.Value) ? "" : (string)row["MARTIAL_STATUS"]),
                    birthDistrict,
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),
                    int.Parse(row["RELATION_TYPE_ID"].ToString()),
                    ((row["RELATION_TYPE_NAME"] == System.DBNull.Value) ? "" : (string)row["RELATION_TYPE_NAME"]),
                    ((row["OCCUPATION"] == System.DBNull.Value) ? "" : (string)row["OCCUPATION"]),
                    ((row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"]),
                    ((row["BENEFICIARY_SINCE"] == System.DBNull.Value) ? "" : (string)row["BENEFICIARY_SINCE"])
                );

                lstEmpBeneficiary.Add(objBen);
            }
            return lstEmpBeneficiary;
        }

    }
}