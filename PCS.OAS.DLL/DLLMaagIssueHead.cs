using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMaagIssueHead
    {
        public static bool SaveMaagIssueHead(ATTMaagIssueHead objMaagIssueHead)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            string strSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagIssueHead.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagIssueHead.UnitID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_REQ_NO", objMaagIssueHead.ReqNo, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ISSUE_SEQ", objMaagIssueHead.IssueSeq, OracleDbType.Int64, ParameterDirection.InputOutput));
            if (objMaagIssueHead.Action == "D")
                strSQL = "SP_INV_DEL_MAAG_ISSUE_HEAD";
            else
            {
                paramArray.Add(Utilities.GetOraParam(":P_ISSUE_DATE", objMaagIssueHead.IssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ISSUE_BY", objMaagIssueHead.IssueBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RCVD_BY", objMaagIssueHead.RcvdBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REMARKS", objMaagIssueHead.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMaagIssueHead.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                if (objMaagIssueHead.Action == "A")
                    strSQL = "SP_INV_ADD_MAAG_ISSUE_HEAD";
                else if (objMaagIssueHead.Action == "E")
                    strSQL = "SP_INV_EDIT_MAAG_ISSUE_HEAD";
            }

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, strSQL, paramArray.ToArray());
                objMaagIssueHead.IssueSeq = int.Parse(paramArray[3].Value.ToString());
                paramArray.Clear();
                if (objMaagIssueHead.LstMaagIssueDetail.Count > 0)
                    DLLMaagIssueDetail.SaveMaagIssueDetail(objMaagIssueHead.LstMaagIssueDetail, objMaagIssueHead.IssueSeq, Tran);
                Tran.Commit();
                return true;
            }
            catch (OracleException oex)
            {
                Tran.Rollback();
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
