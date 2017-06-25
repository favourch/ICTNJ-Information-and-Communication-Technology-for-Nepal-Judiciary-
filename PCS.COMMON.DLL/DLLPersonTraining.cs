using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.COMMON.DLL
{
    public class DLLPersonTraining
    {
        public static DataTable GetPersonTraining(double pId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_TRAININGS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_PID", pId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj,CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool AddPersonTrainings(List<ATTPersonTraining> lstPersonTraining, OracleTransaction Tran, double pID)
        {
            try
            {
                foreach (ATTPersonTraining lst in lstPersonTraining)
                {
                    if (lst.Action == "D")
                    {
                        OracleParameter[] deleteparamArray = new OracleParameter[2];
                        deleteparamArray[0] = Utilities.GetOraParam(":p_PID", pID, OracleDbType.Double, ParameterDirection.Input);
                        deleteparamArray[1] = Utilities.GetOraParam(":p_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_TRAININGS", deleteparamArray);
                    }
                    else
                    {
                        OracleParameter[] paramArray = new OracleParameter[11];
                        paramArray[0] = Utilities.GetOraParam(":p_PID", pID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_SUBJECT", lst.Subject, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_INSTITUTION_ID", lst.InstitutionID, OracleDbType.Long, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_TO_DATE", lst.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_CERTIFICATE_NAME", lst.CertificateName, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_GRADE", lst.Grade, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":p_PERCENTAGE", lst.Percentage, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":p_REMARKS", lst.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_TRAININGS", paramArray);
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_TRAININGS", paramArray);
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
