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
using System.Collections;

namespace PCS.OAS.DLL
{
    public  class DLLMessageReceiver
    {
        public static bool DeleteMessageReceiver(List<ATTMessage> lst, OracleTransaction Tran)
        {
            try
            {
                
                foreach (ATTMessage objMsg in lst)
                {
                    string sp = "SP_DEL_MESSAGE_RECEIVER";

                    OracleParameter[] paramArray = new OracleParameter[3];
                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID",objMsg.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MSG_ID",objMsg.MessageID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_MSG_SEQ",objMsg.MsgSeq, OracleDbType.Int64, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);
                }
            
                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static bool SaveMessageReceiver(ATTMessage objMessage, OracleTransaction Tran,string type)
        {
            try
            {
                string saveSQL = "SP_ADD_MESSAGE_RECEIVER";

                List<ATTMessageReceiver> lstMsgReceiver = new List<ATTMessageReceiver>();

                if (type == "R")
                {
                    lstMsgReceiver = objMessage.LstMessageReceiver;
                }
                else if (type == "Cc")
                {
                    lstMsgReceiver = objMessage.LstMessageCcReceiver;
                }

                foreach (ATTMessageReceiver objMsgReceiver in lstMsgReceiver)
                //foreach (ATTMessageReceiver objMsgReceiver in objMessage.LstMessageReceiver)
                {
                    OracleParameter[] paramArray = new OracleParameter[14];
                    objMsgReceiver.OrgID = objMessage.OrgID;
                    objMsgReceiver.MessageID = objMessage.MessageID;

                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMsgReceiver.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MSG_ID", objMsgReceiver.MessageID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_MSG_SEQ", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[3] = Utilities.GetOraParam(":P_IS_GRP_RECEIVER", objMsgReceiver.IsGrpReceiver, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_GRP_ORG_ID", objMsgReceiver.ReceiverOrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":P_GRP_ID", objMsgReceiver.GroupID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":P_GRP_RECEIVER_ID", objMsgReceiver.ReceiverID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":P_GRP_FROM_DATE", objMsgReceiver.GrpFromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":P_OTHER_ORG_ID", objMsgReceiver.OtherOrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":P_OTHER_UNIT_ID", objMsgReceiver.OtherUnitID, OracleDbType.Int64, ParameterDirection.Input);
                   
                    paramArray[10] = Utilities.GetOraParam(":P_OTHER_RECEIVER_ID", objMsgReceiver.OtherReceiverID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[11] = Utilities.GetOraParam(":P_IS_CC", objMsgReceiver.IsCc, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[12] = Utilities.GetOraParam(":P_ENTRY_BY", objMsgReceiver.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[13] = Utilities.GetOraParam(":ENTRY_ON", objMsgReceiver.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);
                }

                     return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static bool UpdateMessageReceiver(int orgID,int msgID, int msgSeqID)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                string updSQL = "SP_EDIT_MESSAGE_RECEIVER";
                
                OracleParameter[] paramArray = new OracleParameter[3];

                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID",orgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_MSG_ID",msgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_MSG_SEQ",msgSeqID, OracleDbType.Double, ParameterDirection.InputOutput);
               
                SqlHelper.ExecuteNonQuery(Tran,CommandType.StoredProcedure,updSQL,paramArray);

                Tran.Commit();

                return true;

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

        public static DataTable GetMessageReceiverListTable(string type,ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "SELECT distinct ORG_ID,MSG_ID,MSG_SEQ,IS_GRP_RECEIVER,GRP_ORG_ID,GRP_ID,GRP_RECEIVER_ID,GRP_FROM_DATE,OTHER_RECEIVER_ID,R_FIRST_NAME,R_MID_NAME,R_SUR_NAME,READ " + 
                                   "FROM VW_MESSAGE_DETAILS WHERE 1 = 1 ";

                if (login != null)
                {
                    if (type == "IN")
                    {
                        selectSQL += " AND  (GRP_RECEIVER_ID = " + login.PID + " OR OTHER_RECEIVER_ID = " + login.PID + ")";
                    }
                    else if (type == "OUT")
                    {
                        selectSQL += " AND  SENDER_ID = " + login.PID;
                    }
                }

                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

    }
}
