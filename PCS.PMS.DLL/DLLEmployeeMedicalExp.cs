using System;
using System.Collections.Generic;
using System.Text;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeMedicalExp
    {
        public static DataTable GetEmployeeMedicalExp(double? empID)
        {
            string SelectSP = "SP_GET_EMP_MEDICAL_EXP";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", empID, OracleDbType.Double, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SaveEmployeeMedicalExp(List<ATTEmployeeMedicalExp> lstEmpMedExp)
        {
            GetConnection getConn = new GetConnection();
            OracleTransaction Tran = getConn.GetDbConn(Module.PMS).BeginTransaction();
            try
            {
                foreach (ATTEmployeeMedicalExp lst in lstEmpMedExp)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    if (lst.Action == "D")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", lst.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_EMP_MEDICAL_EXP", paramArray.ToArray());
                    }
                    else
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", lst.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("P_PARTICULARS", lst.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_DATE_TAKEN", lst.DateTaken, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_AMOUNT_TAKEN", lst.AmountTaken, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_EMP_MEDICAL_EXP", paramArray.ToArray());
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_EMP_MEDICAL_EXP", paramArray.ToArray());
                        paramArray.Clear();
                    }

                }
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
