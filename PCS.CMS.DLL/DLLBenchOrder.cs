using System;
using System.Collections.Generic;
using System.Text;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.CMS.DLL
{
    public class DLLBenchOrder
    {
        public static DataTable GetBenchAssignments(int? orgId, int? benchTypeId, string benchDate)
        {
            GetConnection Conn = new GetConnection();

            string SelectSQL = "SP_GET_BENCH_ASSIGNMENT";

            //SelectSQL = "SELECT FIRST_NAME||' '||MID_NAME||' '||SUR_NAME AS Name,O.ORG_NAME,TL.FROM_DATE,TL.PERSON_TYPE,TL.CASE_ID,TL.PERSON_ID FROM TARIKH_LOCATION TL INNER JOIN PERSON P ON TL.PERSON_ID=P.P_ID INNER JOIN ORGNIZATIONS O ON TL.COURT_ID=O.ORG_ID  WHERE TL.CASE_ID =" + caseId;
            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam("P_ORG_ID", orgId, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_BENCH_TYPE_ID", benchTypeId, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam("P_ASSIGNMENT_DATE", benchDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static DataTable GetBenchOrders(int orgId, int benchTypeId,int benchNo,string fromDate, int seqNo, int caseId, string assignmentDate)
        {
            GetConnection Conn = new GetConnection();

            string SelectSQL = "SP_GET_BENCH_ORDERS";

            //SelectSQL = "SELECT FIRST_NAME||' '||MID_NAME||' '||SUR_NAME AS Name,O.ORG_NAME,TL.FROM_DATE,TL.PERSON_TYPE,TL.CASE_ID,TL.PERSON_ID FROM TARIKH_LOCATION TL INNER JOIN PERSON P ON TL.PERSON_ID=P.P_ID INNER JOIN ORGNIZATIONS O ON TL.COURT_ID=O.ORG_ID  WHERE TL.CASE_ID =" + caseId;
            OracleParameter[] paramArray = new OracleParameter[8];
            paramArray[0] = Utilities.GetOraParam("P_ORG_ID", orgId, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_BENCH_TYPE_ID", benchTypeId, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam("P_BENCH_NO", benchNo, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam("P_FROM_DATE", fromDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam("P_SEQ_NO", seqNo, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam("P_CASE_ID", caseId, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam("P_ASSIGNMENT_DATE", assignmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static bool UpdateBenchOrders(List<ATTBenchOrder> lstBenchOrders)
        {
            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.CMS);
            try
            {
                foreach (ATTBenchOrder objBenchOrder in lstBenchOrders)
                {

                    if (objBenchOrder.Action != "N")
                    {
                        string SPInsertUpdate = "";
                        if (objBenchOrder.Action == "A")
                            SPInsertUpdate = "SP_ADD_CASE_BENCH_ORDER";
                        if (objBenchOrder.Action == "R")
                            SPInsertUpdate = "SP_DEL_CASE_BENCH_ORDER";
                        if (objBenchOrder.Action == "E")
                            SPInsertUpdate = "SP_EDIT_CASE_BENCH_ORDER";
                        int? ordId;
                        if (objBenchOrder.OrderID == 0)
                            ordId = null;
                        else
                            ordId = objBenchOrder.OrderID;

                        OracleParameter[] paramArray = new OracleParameter[11];
                        paramArray[0] = Utilities.GetOraParam("P_ORG_ID", objBenchOrder.OrgID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam("P_BENCH_TYPE_ID", objBenchOrder.BenchTypeID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam("P_BENCH_NO", objBenchOrder.BenchNo, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam("P_FROM_DATE", objBenchOrder.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam("P_SEQ_NO", objBenchOrder.SeqNo, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam("P_CASE_ID", objBenchOrder.CaseID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam("P_ASSIGNMENT_DATE", objBenchOrder.AssignmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam("P_BO_SEQ_NO", objBenchOrder.BoSeqNo, OracleDbType.Int16, ParameterDirection.InputOutput);
                        paramArray[8] = Utilities.GetOraParam("P_ORDER_ID", ordId, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam("P_REMARKS", objBenchOrder.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam("P_ENTRY_BY", objBenchOrder.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);



                        SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SPInsertUpdate, paramArray);
                        objBenchOrder.BoSeqNo=int.Parse(paramArray[7].Value.ToString());

                    }
                }


            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
            return true;



        }
    }
}
