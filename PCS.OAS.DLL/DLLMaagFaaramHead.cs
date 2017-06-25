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
    public class DLLMaagFaaramHead
    {
        public static bool SaveMaagFaaramHead(ATTMaagFaaramHead objMaagFaaramHead )
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            string strSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID",objMaagFaaramHead.OrgID,OracleDbType.Int64,ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID",objMaagFaaramHead.UnitID,OracleDbType.Int64,ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_REQ_NO",objMaagFaaramHead.ReqNo,OracleDbType.Double,ParameterDirection.InputOutput));
            if (objMaagFaaramHead.Action == "D")
                strSQL = "SP_INV_DEL_MAAG_FAARAM_HEAD";
            else
            {
                paramArray.Add(Utilities.GetOraParam(":P_REQ_DATE", objMaagFaaramHead.ReqDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_BY", objMaagFaaramHead.ReqBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REQ_PURPOSE", objMaagFaaramHead.ReqPurpose, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ISSUE_TYPE", objMaagFaaramHead.IssueType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_APP_BY", objMaagFaaramHead.AppBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_APP_DATE", objMaagFaaramHead.AppDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_APP_YES_NO", objMaagFaaramHead.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ISSUE_FLAG", objMaagFaaramHead.IssueFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMaagFaaramHead.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                if (objMaagFaaramHead.Action == "A")
                    strSQL = "SP_INV_ADD_MAAG_FAARAM_HEAD";
                else if (objMaagFaaramHead.Action == "E")
                    strSQL = "SP_INV_EDIT_MAAG_FAARAM_HEAD";
            }

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, strSQL, paramArray.ToArray());
                objMaagFaaramHead.ReqNo = int.Parse(paramArray[2].Value.ToString());
                paramArray.Clear();
                if (objMaagFaaramHead.LstMaagFaaramDetail.Count > 0)
                    DLLMaagFaaramDetail.SaveMaagFaaramDetail(objMaagFaaramHead.LstMaagFaaramDetail, objMaagFaaramHead.ReqNo, Tran);
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

        public static DataTable GetMaagFaaramHead(ATTMaagFaaramHead objMaagFaaramHead)
        {
            string strSql = "SELECT * FROM VW_MAAG_FAARAM_HEAD WHERE 1=1";
            List<OracleParameter> paramArray=new List<OracleParameter>();
            if (objMaagFaaramHead.OrgID != null)
            {
                strSql += " AND ORG_ID = :P_ORG_ID";
                paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagFaaramHead.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            }
            if (objMaagFaaramHead.UnitID != null)
            {
                strSql += " AND UNIT_ID = :P_UNIT_ID";
                paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramHead.UnitID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (objMaagFaaramHead.SelectApproval == true)
            {
                if (objMaagFaaramHead.AppYesNo == null)
                    strSql += " AND APP_YES_NO IS NULL";
                else
                {
                    strSql += " AND APP_YES_NO = :P_APP_YES_NO";
                    paramArray.Add(Utilities.GetOraParam(":P_APP_YES_NO", objMaagFaaramHead.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }
            }

            if (objMaagFaaramHead.SelectIssue == true)
            {
                if (objMaagFaaramHead.IssueFlag==null)
                    strSql += " AND ISSUE_FLAG IS NULL";
                else
                {
                strSql += " AND ISSUE_FLAG = :P_ISSUE_FLAG";
                paramArray.Add(Utilities.GetOraParam(":P_ISSUE_FLAG", objMaagFaaramHead.IssueFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                }
            }

            strSql += " ORDER BY ORG_ID,UNIT_ID,REQ_NO";
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, Module.OAS, paramArray.ToArray());
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

        public static bool ApproveIssueMaag(ATTMaagFaaramHead objMaagFaaramHead)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            string strSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagFaaramHead.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramHead.UnitID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_REQ_NO", objMaagFaaramHead.ReqNo, OracleDbType.Double, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":P_APP_BY", objMaagFaaramHead.AppBy, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_APP_DATE", objMaagFaaramHead.AppDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_APP_YES_NO", objMaagFaaramHead.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ISSUE_FLAG", objMaagFaaramHead.IssueFlag, OracleDbType.Varchar2, ParameterDirection.Input));

            if (objMaagFaaramHead.Action == "APP")
                strSQL = "SP_INV_APP_MAAG_FAARAM_HEAD";
            else if (objMaagFaaramHead.Action == "DELI")
                strSQL = "SP_INV_DELI_MAAG_FAARAM_HEAD";

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, strSQL, paramArray.ToArray());
                paramArray.Clear();
                if (objMaagFaaramHead.LstMaagFaaramDetail.Count > 0)
                    DLLMaagFaaramDetail.UpdateMaagFaaramDetAppQty(objMaagFaaramHead.LstMaagFaaramDetail, Tran);
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
