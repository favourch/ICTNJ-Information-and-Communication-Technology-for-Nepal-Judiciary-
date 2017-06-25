using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.DLL
{
    public class DLLMessage
    {
        public static DataTable GetMessageByIDs(int? orgID, int? msgID)
        {
            string SP = "sp_get_message_by_ids";
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

        public static bool DeleteMessage(List<ATTMessage> lst)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                if (lst.Count > 0)
                    DLLMessageReceiver.DeleteMessageReceiver(lst,Tran);

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
        public static bool SaveMessage(ATTMessage objMessage)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            string saveSQL = "SP_ADD_MESSAGE";

            int countReceiver = objMessage.LstMessageReceiver.Count;
            int countAttachment = objMessage.LstMsgAttachment.Count;
            int countCcReceiver = objMessage.LstMessageCcReceiver.Count;

            OracleParameter[] paramArray = new OracleParameter[17];
            paramArray[0] = Utilities.GetOraParam(":P_ORG_IDD",objMessage.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_MSG_ID",objMessage.MessageID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[2] = Utilities.GetOraParam(":P_MSG_TYPE_ID",objMessage.MessageTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_SENDER_ID",objMessage.SenderID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_SUBJECT",objMessage.Subject, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":P_BODY",objMessage.Body, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":P_PARENT_MSG_ID", objMessage.ParentMsgID, OracleDbType.Int64, ParameterDirection.Input);
          
            paramArray[7] = Utilities.GetOraParam(":P_LETTER_TYPE", objMessage.LetterType, OracleDbType.Varchar2, ParameterDirection.Input);

            paramArray[8] = Utilities.GetOraParam(":P_TO_ORG_ID", objMessage.ToOrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":P_TO_UNIT_ID", objMessage.ToUnitID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":P_TO_P_ID", objMessage.ToPID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[11] = Utilities.GetOraParam(":P_FROM_ORG_ID", objMessage.FromOrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[12] = Utilities.GetOraParam(":P_FROM_UNIT_ID", objMessage.FromUnitID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[13] = Utilities.GetOraParam(":P_FROM_P_ID", objMessage.FromPID, OracleDbType.Int64, ParameterDirection.Input);
           

            paramArray[14] = Utilities.GetOraParam(":P_APPROVE", objMessage.Approve, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[15] = Utilities.GetOraParam(":P_ENTRY_BY",objMessage.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[16] = Utilities.GetOraParam(":ENTRY_ON",objMessage.EntryOn, OracleDbType.Date, ParameterDirection.Input);


            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);
                objMessage.MessageID = int.Parse(paramArray[1].Value.ToString());
                
             
                if (countReceiver > 0)
                {
                    DLLMessageReceiver.SaveMessageReceiver(objMessage, Tran,"R");
                }

                if (countAttachment > 0)
                {
                    DLLMessageAttachment.SaveMessageAttachment(objMessage, Tran);
                }

                if (countCcReceiver > 0)
                {
                    DLLMessageReceiver.SaveMessageReceiver(objMessage, Tran,"Cc");
                }

                Tran.Commit();

                return true ;

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

        public static DataTable GetMessageListTable(string type,ATTUserLogin login,string searchValue)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "";
                               
                if (login != null)
                {
                    if (type == "IN")
                    {
                        selectSQL = " SELECT distinct org_id, msg_id,MSG_TYPE_ID,MSG_SEQ,is_grp_receiver, sender_id, subject, BODY, entry_on,s_first_name, s_mid_name, s_sur_name,LETTER_TYPE,APPROVE,TIP_ORG_ID,TIPPANI_ID FROM VW_MESSAGE_DETAILS WHERE 1=1 ";

                        selectSQL += " AND  (GRP_RECEIVER_ID = " + login.PID + " OR OTHER_RECEIVER_ID = " + login.PID + ")";
                    }
                    else if (type == "OUT")
                    {
                        selectSQL = " SELECT distinct org_id, msg_id,MSG_TYPE_ID, sender_id, subject, BODY, entry_on,s_first_name, s_mid_name, s_sur_name,LETTER_TYPE,APPROVE,TIP_ORG_ID,TIPPANI_ID FROM VW_MESSAGE_DETAILS WHERE 1=1 ";

                        selectSQL += " AND  SENDER_ID = " + login.PID;
                    }
                }

                if (searchValue.Trim() != "")
                    selectSQL += " AND SUBJECT LIKE '" + searchValue + "%'";

                selectSQL += " ORDER BY ENTRY_ON DESC";


                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text,selectSQL);

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
