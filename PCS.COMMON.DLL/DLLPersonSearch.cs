using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.DLL
{
    public class DLLPersonSearch
    {
        public static DataTable SearchPerson(ATTPersonSearch objPerson)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT P_ID,FIRST_NAME,MID_NAME,SUR_NAME,GENDER,DOB,MARTIAL_STATUS,BIRTH_DISTRICT,COUNTRY_ID,";
                strSelectSQL += "NEP_DISTNAME,FATHER_NAME,GFATHER_NAME FROM VW_PERSON_ADDRESS_INFO WHERE 1=1";
                int i = 0;

                if (objPerson.FirstName != null) i++;
                if (objPerson.MiddleName != null)i++;
                if (objPerson.SurName != null) i++;
                if (objPerson.Gender != null) i++;
                if (objPerson.District != null) i++;
                if (objPerson.IniType != null) i++;

                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objPerson.FirstName != null)
                {
                    strSelectSQL += " AND FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objPerson.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.MiddleName != null)
                {
                    strSelectSQL += " AND MID_NAME LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objPerson.MiddleName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.SurName != null)
                {
                    strSelectSQL += " AND SUR_NAME LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objPerson.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.Gender != null)
                {
                    strSelectSQL += " AND GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objPerson.Gender,OracleDbType.Varchar2,ParameterDirection.Input);
                    j++;
                }
                if (objPerson.District != null)
                {
                    strSelectSQL+= " AND NEP_DISTNAME = :District";
                    ParamArray[j] = Utilities.GetOraParam(":District", objPerson.District,OracleDbType.Varchar2,ParameterDirection.Input);
                    j++;
                }

                if (objPerson.IniType != null)
                {
                    strSelectSQL += " AND INI_TYPE = :IniType";
                    ParamArray[j] = Utilities.GetOraParam(":IniType", objPerson.IniType, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                strSelectSQL += " ORDER BY P_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
