using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
namespace PCS.CMS.DLL
{
    public class DLLCaseLawyer
    {

        public static bool SaveCaseLawyers(List<ATTCaseLaywer> CaseLawyerLST)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            try
            {

                foreach (ATTCaseLaywer objCaseLawyer in CaseLawyerLST)
                {
                    paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objCaseLawyer.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", objCaseLawyer.LitigantID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_LAWYER_ID", objCaseLawyer.LawyerID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objCaseLawyer.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_LICENCE_NO", objCaseLawyer.LicenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objCaseLawyer.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    if (objCaseLawyer.Action == "A")
                        InsertUpdateSQL = "SP_ADD_CASE_LAWYER";
                    else if (objCaseLawyer.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_CASE_LAWYER";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());

                }


                Tran.Commit();
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }


        public static DataTable getCaseLawyer(double? caseID, double? litigantID, double? lawyerID)
        {
            string SelectSql = "SP_GET_CASE_LAWYER";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", litigantID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_LAWYER_ID", lawyerID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

    }
}
