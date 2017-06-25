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
    public class DLLPersonEMail
    {
        public static DataTable GetPersonEMail(double personId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_PERSON_EMAIL";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_P_ID", personId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_ACTIVE", null, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool AddPersonEMail(List<ATTPersonEMail> lstPersonEMail, OracleTransaction Tran, double personID)
        {
            try
            {
                foreach (ATTPersonEMail lst in lstPersonEMail)
                {
                    if (lst.Action == "D")
                    {
                        OracleParameter[] deleteparamArray = new OracleParameter[3];
                        deleteparamArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        deleteparamArray[1] = Utilities.GetOraParam(":p_E_TYPE", lst.EType, OracleDbType.Varchar2, ParameterDirection.Input);
                        deleteparamArray[2] = Utilities.GetOraParam(":p_E_SNO", lst.ESNo, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_PERSON_EMAIL", deleteparamArray);
                    }

                    else
                    {
                        OracleParameter[] paramArray = new OracleParameter[8];
                        paramArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_E_TYPE", lst.EType, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_E_SNO", lst.ESNo, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_EMAIL", lst.EMail, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_ACTIVE", lst.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_REMARKS", lst.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_ENTRY_DATE", lst.EntryDate, OracleDbType.Date, ParameterDirection.Input);

                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSON_EMAIL", paramArray);
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSON_EMAIL", paramArray);
                    }
                }
                return true;
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
