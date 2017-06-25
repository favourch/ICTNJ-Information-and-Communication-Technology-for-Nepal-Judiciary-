using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeSearch
    {
        public static DataTable SearchEmployee(ATTEmployeeSearch objEmployee)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT A.* FROM VW_EMPLOYEES A WHERE 1=1";
                
                int i = 0;

                if (objEmployee.EmpID != null) i++;
                if (objEmployee.FirstName != null) i++;
                if (objEmployee.MiddleName != null) i++;
                if (objEmployee.SurName != null) i++;
                if (objEmployee.Gender != null) i++;
                if (objEmployee.DOB != null) i++;
                if (objEmployee.MaritalStatus != null) i++;
                if (objEmployee.SymbolNo != null) i++;
                if (objEmployee.DesID != null) i++;
                if (objEmployee.OrgID != null) i++;
                if (objEmployee.IniType != null) i++;
                if (objEmployee.IniUnit != null) i++;
                if (objEmployee.DesType != null) i++;
                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objEmployee.EmpID != null)
                {
                    strSelectSQL += " AND A.EMP_ID =:EmpID";
                    ParamArray[j] = Utilities.GetOraParam(":EmpID", objEmployee.EmpID, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.FirstName != null)
                {
                    strSelectSQL += " AND A.FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objEmployee.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.MiddleName != null)
                {
                    strSelectSQL += " AND A.MID_NAME LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objEmployee.MiddleName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.SurName != null)
                {
                    strSelectSQL += " AND A.SUR_NAME LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objEmployee.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.Gender != null)
                {
                    strSelectSQL += " AND A.GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objEmployee.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.DOB != null)
                {
                    strSelectSQL += " AND A.DOB = :DOB";
                    ParamArray[j] = Utilities.GetOraParam(":DOB", objEmployee.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.MaritalStatus != null)
                {
                    strSelectSQL += " AND A.MARTIAL_STATUS = :MaritalStatus";
                    ParamArray[j] = Utilities.GetOraParam(":MaritalStatus", objEmployee.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.SymbolNo != null)
                {
                    strSelectSQL += " AND A.SYMBOL_NO = :SymbolNo";
                    ParamArray[j] = Utilities.GetOraParam(":SymbolNo", objEmployee.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.DesID != null)
                {
                    strSelectSQL += " AND A.DES_ID = :DesID";
                    ParamArray[j] = Utilities.GetOraParam(":DesID", objEmployee.DesID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.OrgID != null)
                {
                    strSelectSQL += " AND A.ORG_ID = :OrgID";
                    ParamArray[j] = Utilities.GetOraParam(":OrgID", objEmployee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.IniType != null)
                {
                    strSelectSQL += " AND A.INI_TYPE = :IniType";
                    ParamArray[j] = Utilities.GetOraParam(":IniType", objEmployee.IniType, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.IniUnit != null)
                {
                    strSelectSQL += " AND A.INI_UNIT = :IniUnit";
                    ParamArray[j] = Utilities.GetOraParam(":IniUnit", objEmployee.IniUnit, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.DesType != null)
                {
                    strSelectSQL += " AND NVL(A.DES_TYPE,'O') = :DesType";
                    ParamArray[j] = Utilities.GetOraParam(":DesType", objEmployee.DesType, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                strSelectSQL += " ORDER BY A.EMP_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.PMS, ParamArray);
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

        public static DataTable SearchEmployeeForOrgUnitHead(ATTEmployeeSearch objEmployee)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT A.* FROM VW_EMP_ORG_UNIT_HEAD A WHERE 1=1";

                int i = 0;

                if (objEmployee.EmpID != null) i++;
                if (objEmployee.FirstName != null) i++;
                if (objEmployee.MiddleName != null) i++;
                if (objEmployee.SurName != null) i++;
                if (objEmployee.Gender != null) i++;
                if (objEmployee.DOB != null) i++;
                if (objEmployee.SymbolNo != null) i++;
                if (objEmployee.OrgID != null) i++;
                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objEmployee.EmpID != null)
                {
                    strSelectSQL += " AND A.EMP_ID =:EmpID";
                    ParamArray[j] = Utilities.GetOraParam(":EmpID", objEmployee.EmpID, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.FirstName != null)
                {
                    strSelectSQL += " AND A.FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objEmployee.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.MiddleName != null)
                {
                    strSelectSQL += " AND A.MID_NAME LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objEmployee.MiddleName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.SurName != null)
                {
                    strSelectSQL += " AND A.SUR_NAME LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objEmployee.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.Gender != null)
                {
                    strSelectSQL += " AND A.GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objEmployee.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.DOB != null)
                {
                    strSelectSQL += " AND A.DOB = :DOB";
                    ParamArray[j] = Utilities.GetOraParam(":DOB", objEmployee.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                
                if (objEmployee.SymbolNo != null)
                {
                    strSelectSQL += " AND A.SYMBOL_NO = :SymbolNo";
                    ParamArray[j] = Utilities.GetOraParam(":SymbolNo", objEmployee.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
              
                if (objEmployee.OrgID != null)
                {
                    strSelectSQL += " AND A.ORG_ID = :OrgID";
                    ParamArray[j] = Utilities.GetOraParam(":OrgID", objEmployee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }
              
                strSelectSQL += " ORDER BY A.EMP_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.PMS, ParamArray);
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

        public static DataTable SearchPersonWithPostIF(ATTPersonSearch objPerson)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT P_ID,FIRST_NAME,MID_NAME,SUR_NAME,GENDER,DOB,NEP_DISTNAME,FATHER_NAME,GFATHER_NAME,POST_NAME FROM VW_EMP_POSTNAME WHERE 1=1";
                int i = 0;

                if (objPerson.FirstName != null) i++;
                if (objPerson.MiddleName != null) i++;
                if (objPerson.SurName != null) i++;
                if (objPerson.Gender != null) i++;
                if (objPerson.District != null) i++;
                if (objPerson.IniType != null) i++;

                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objPerson.FirstName != null)
                {
                    strSelectSQL += " AND UPPER(FIRST_NAME) LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objPerson.FirstName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.MiddleName != null)
                {
                    strSelectSQL += " AND UPPER(MID_NAME) LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objPerson.MiddleName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.SurName != null)
                {
                    strSelectSQL += " AND UPPER(SUR_NAME) LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objPerson.SurName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.Gender != null)
                {
                    strSelectSQL += " AND GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objPerson.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objPerson.District != null)
                {
                    strSelectSQL += " AND NEP_DISTNAME = :District";
                    ParamArray[j] = Utilities.GetOraParam(":District", objPerson.District, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objPerson.IniType != null)
                {
                    strSelectSQL += " AND INI_TYPE = :IniType";
                    ParamArray[j] = Utilities.GetOraParam(":IniType", objPerson.IniType, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                //strSelectSQL += " ORDER BY P_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.PMS, ParamArray);
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
