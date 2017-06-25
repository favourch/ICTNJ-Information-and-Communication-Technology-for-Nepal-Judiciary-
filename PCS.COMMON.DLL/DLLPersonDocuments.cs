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
    public class DLLPersonDocuments
    {
        public static DataTable GetPersonDocuments(double personId, object obj, string personDocActive)
        {
            try
            {
                string SelectSql = "SP_GET_PERSON_DOCUMENTS";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_P_ID", personId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_ACTIVE", personDocActive, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds;// = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                if (obj == null)
                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, ParamArray);
                else
                    ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);


                //                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool SavePersonDocuments(List<ATTPersonDocuments> lstPersonDocuments, OracleTransaction Tran, double personID)
        {
            try
            {
                lstPersonDocuments.RemoveAll(delegate(ATTPersonDocuments obj)
                                            {
                                                return obj.Action == "";
                                            });
                foreach (ATTPersonDocuments lst in lstPersonDocuments)
                {
                    if (lst.Action == "D")
                    {
                        OracleParameter[] deleteparamArray = new OracleParameter[2];
                        deleteparamArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        deleteparamArray[1] = Utilities.GetOraParam(":p_DOC_TYPE_ID", lst.DocTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_PERSON_DOCUMENTS", deleteparamArray);
                    }
                    else
                    {
                        OracleParameter[] paramArray = new OracleParameter[9];
                        paramArray[0] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_DOC_TYPE_ID", lst.DocTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_DOC_NUMBER", lst.DocNumber, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_ISSUED_FROM", lst.IssuedFrom, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_ISSUED_ON", lst.IssuedOn, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_ISSUED_BY", lst.IssuedBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_ACTIVE", lst.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":p_ENTRY_DATE", lst.EntryDate, OracleDbType.Date, ParameterDirection.Input);

                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSON_DOCUMENTS", paramArray);
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSON_DOCUMENTS", paramArray);
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
