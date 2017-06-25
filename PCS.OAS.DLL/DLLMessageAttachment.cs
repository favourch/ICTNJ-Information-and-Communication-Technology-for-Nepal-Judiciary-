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
    public class DLLMessageAttachment
    {
        public static DataTable GetMsgAttachmentByIDs(int? orgID, int? msgID)
        {
            string SP = "sp_get_msg_attachment_by_ids";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_msg_id", msgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveMessageAttachment(ATTMessage objMessage, OracleTransaction Tran)
        {
            try
            {
                string saveSQL = "SP_ADD_MESSAGE_ATTACHMENT";

                foreach (ATTMessageAttachment objMsgAttachment in objMessage.LstMsgAttachment)
                {
                    OracleParameter[] paramArray = new OracleParameter[5];
                    objMsgAttachment.OrgID = objMessage.OrgID;
                    objMsgAttachment.MessageID = objMessage.MessageID;

                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMsgAttachment.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MSG_ID", objMsgAttachment.MessageID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_ATTACHMENT_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[3] = Utilities.GetOraParam(":p_FILE_BYTES", objMsgAttachment.ContentFile, OracleDbType.Blob, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_FILE_NAME", objMsgAttachment.FileName, OracleDbType.Varchar2, ParameterDirection.Input);
                    
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable GetMessageAttachmentListTable(string type, ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "SELECT ORG_ID,MSG_ID,msg_seq,MSG_ATTACH_ID,FILE_NAME,FILE_BYTES " +
                                   "FROM VW_MESSAGE_DETAILS " + 
                                   " WHERE MSG_ATTACH_ID IS NOT NULL ";

            

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
