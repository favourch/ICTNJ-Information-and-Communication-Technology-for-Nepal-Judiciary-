using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using System.Data;

namespace PCS.CMS.DLL
{
    public class DLLMisil
    {
        public static bool SaveMisil(ATTMisil attCAM)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            string InsertUpdateSQL = "SP_ADD_MISIL";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAM.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_DATE", attCAM.ReqDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_ORG", attCAM.ReqOrg, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_DOC_TYPE_ID", attCAM.DocTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_CHALAANI_NO", attCAM.ReqChalaniNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_DATE", attCAM.ReqRecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_DARTAA_NO", attCAM.ReqRecDartaNo, OracleDbType.Varchar2, ParameterDirection.Input));
                if (attCAM.ReqRecPID == 0)
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_P_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_P_ID", attCAM.ReqRecPID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_REPLY_DATE", attCAM.ReqReplyDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_REPLY_CHALAANI_NO", attCAM.ReqReplyChalaniNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RCVD_DATE", attCAM.RecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RCVD_DARTAA_NO", attCAM.RecDartaNo, OracleDbType.Varchar2, ParameterDirection.Input));
                if (attCAM.RecPID == 0)
                    paramArray.Add(Utilities.GetOraParam(":P_RCVD_P_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                    paramArray.Add(Utilities.GetOraParam(":P_RCVD_P_ID", attCAM.RecPID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_IS_RETURN", attCAM.IsReturn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RETURN_DATE", attCAM.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REMARKS", attCAM.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAM.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
        public static bool EditMisil(ATTMisil attCAM)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            //OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            string InsertUpdateSQL = "SP_EDIT_MISIL";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();

                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAM.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_DATE", attCAM.ReqDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_ORG", attCAM.ReqOrg, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_DOC_TYPE_ID", attCAM.DocTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_CHALAANI_NO", attCAM.ReqChalaniNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_DATE", attCAM.ReqRecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_DARTAA_NO", attCAM.ReqRecDartaNo, OracleDbType.Varchar2, ParameterDirection.Input));
                if (attCAM.ReqRecPID == 0)
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_P_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_RCVD_P_ID", attCAM.ReqRecPID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_REPLY_DATE", attCAM.ReqReplyDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_REPLY_CHALAANI_NO", attCAM.ReqReplyChalaniNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RCVD_DATE", attCAM.RecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RCVD_DARTAA_NO", attCAM.RecDartaNo, OracleDbType.Varchar2, ParameterDirection.Input));
                if (attCAM.RecPID == 0)
                    paramArray.Add(Utilities.GetOraParam(":P_RCVD_P_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                    paramArray.Add(Utilities.GetOraParam(":P_RCVD_P_ID", attCAM.RecPID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_IS_RETURN", attCAM.IsReturn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RETURN_DATE", attCAM.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REMARKS", attCAM.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAM.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());

                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static DataTable GetMisilForProcessing(ATTMisil att)
        {
            try
            {
                string SelectSql = "SELECT * FROM VW_MISIL_PROCESS WHERE 1=1  ";

                List<OracleParameter> ParamLIST = new List<OracleParameter>();
                if (att.ReqOrg > 0)
                {
                    SelectSql += " AND REQ_ORG = :CourtId";
                    ParamLIST.Add(Utilities.GetOraParam(":CourtId", att.ReqOrg, OracleDbType.Int64, ParameterDirection.Input));
                }
                //SelectSql += " AND REQ_REPLY_CHALAANI_NO IS NULL ";
                SelectSql += " ORDER BY CASE_ID";

                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSql, ParamLIST.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
