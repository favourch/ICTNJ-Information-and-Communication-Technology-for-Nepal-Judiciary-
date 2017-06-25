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
    public class DLLPersonPhone
    {
        public static DataTable GetPersonPhone(double personId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_PERSON_PHONE";

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

        public static bool AddPersonPhone(List<ATTPersonPhone> lstPersonPhone, OracleTransaction Tran, double personID)
        {
            try
            {
                foreach (ATTPersonPhone lst in lstPersonPhone)
                {
                    if (lst.Action == "D")
                    {
                        OracleParameter[] deleteparamArray = new OracleParameter[3];
                        deleteparamArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        deleteparamArray[1] = Utilities.GetOraParam(":p_P_TYPE", lst.PType, OracleDbType.Varchar2, ParameterDirection.Input);
                        deleteparamArray[2] = Utilities.GetOraParam(":p_P_SNO", lst.PSNo, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_PERSON_PHONE", deleteparamArray);
                    }
                    else
                    {
                        OracleParameter[] paramArray = new OracleParameter[8];
                        paramArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_P_TYPE", lst.PType, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_P_SNO", lst.PSNo, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_PHONE", lst.Phone, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_ACTIVE", lst.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_REMARKS", lst.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_ENTRY_DATE", lst.EntryDate, OracleDbType.Date, ParameterDirection.Input);

                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSON_PHONE", paramArray);
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSON_PHONE", paramArray);
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
