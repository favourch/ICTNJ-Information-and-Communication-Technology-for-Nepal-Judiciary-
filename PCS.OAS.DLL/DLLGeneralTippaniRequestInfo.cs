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


namespace PCS.OAS.DLL
{
    public class DLLGeneralTippaniRequestInfo
    {
        public static DataTable GetTippaniRequestInfo(ATTGeneralTippaniRequestInfo info, int sIndex, int eIndex, ref decimal totalRecord)
        {
            string orderString = "";
            string SP = "SELECT V.ORG_ID, V.TIPPANI_ID, V.TIPPANI_PROCESS_ID, ";
            SP += " V.SEND_TYPE, V.IS_CHANNEL_PERSON, V.TIPPANI_TEXT, ";
            SP += "V.SENDER_ORG_ID, V.SENDER_UNIT_ID, V.SENDER_ORG_NAME,";
            SP += "V.SENDER_UNIT_NAME, V.PROCESS_BY_ID, V.PROCESS_BY, ";
            SP += "V.SEND_ON, V.RECEIVER_ORG_ID, V.RECEIVER_UNIT_ID, ";
            SP += "V.RECEIVER_ORG_NAME, V.RECEIVER_UNIT_NAME, V.PROCESS_TO_ID, ";
            SP += "V.PROCESS_TO, V.TIPPANI_SUBJECT_ID, V.TIPPANI_SUBJECT_NAME, ";
            SP += "V.TIPPANI_STATUS_ID, V.TIPPANI_STATUS_NAME, V.PRIORITY_ID, ";
            SP += "V.PROCESS_STATUS_ID, V.PROCESS_STATUS_NAME, '' NOTE ";
            SP += "FROM VW_TIPPANI_PROCESS_DETAIL V WHERE 1 = 1 ";
            string criteria = "";

            criteria = criteria + " and V.org_id = " + info.OrgID.ToString();
            criteria = criteria + " and V.tippani_subject_id = " + info.TippaniSubjectID.ToString();

            if (info.ProcessToID > 0)
            {
                criteria = criteria + " AND V.PROCESS_TO_ID = " + info.ProcessToID.ToString();
                orderString = "V.PROCESS_TO_ID";
            }

            if (info.ProcessByID > 0)
            {
                criteria = criteria + " AND PROCESS_BY_ID = " + info.ProcessByID.ToString();
                orderString = "V.PROCESS_BY_ID";
            }

            criteria = criteria + " AND V.PROCESS_BY_ID IS NOT NULL";
            criteria = criteria + info.Filter;

            //SP = SP + " ORDER BY TP.TIP_FROM_ORG_ID, TP.TIPPANI_ID, TP." + orderString + ", TP.SEND_ON, TP.STATUS_ID"; ;
            criteria = criteria + " ORDER BY v.org_id, v.TIPPANI_ID desc, v.TIPPANI_PROCESS_ID desc, v.SEND_ON, v.process_STATUS_ID"; ;

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                if (totalRecord > 0)
                {
                    totalRecord = (decimal)SqlHelper.ExecuteScalar(Conn, CommandType.Text, "SELECT COUNT(*) FROM VW_TIPPANI_PROCESS_DETAIL V WHERE 1 = 1 " + criteria, null);
                }

                DataTable tbl = SqlHelper.ExecuteDataset(Conn, CommandType.Text, SP + criteria, sIndex, eIndex, null).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetTippaniRequestHistory(ATTGeneralTippaniRequestInfo info)
        {
            //string orderString = "";
            string SP = "SELECT V.ORG_ID, V.TIPPANI_ID, V.TIPPANI_PROCESS_ID, ";
            SP += " V.SEND_TYPE, V.IS_CHANNEL_PERSON, V.TIPPANI_TEXT, ";
            SP += "V.SENDER_ORG_ID, V.SENDER_UNIT_ID, V.SENDER_ORG_NAME,";
            SP += "V.SENDER_UNIT_NAME, V.PROCESS_BY_ID, V.PROCESS_BY, ";
            SP += "V.SEND_ON, V.RECEIVER_ORG_ID, V.RECEIVER_UNIT_ID, ";
            SP += "V.RECEIVER_ORG_NAME, V.RECEIVER_UNIT_NAME, V.PROCESS_TO_ID, ";
            SP += "V.PROCESS_TO, V.TIPPANI_SUBJECT_ID, V.TIPPANI_SUBJECT_NAME, ";
            SP += "V.TIPPANI_STATUS_ID, V.TIPPANI_STATUS_NAME, V.PRIORITY_ID, ";
            SP += "V.PROCESS_STATUS_ID, V.PROCESS_STATUS_NAME, V.NOTE ";
            SP += "FROM VW_TIPPANI_PROCESS_DETAIL V WHERE 'SJ' = 'SJ' and";

            SP = SP + " V.org_id = " + info.OrgID.ToString();
            SP = SP + " and V.tippani_id = " + info.TippaniID.ToString();

            SP = SP + " ORDER BY V.TIPPANI_PROCESS_ID";
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SP, Module.OAS, null).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
