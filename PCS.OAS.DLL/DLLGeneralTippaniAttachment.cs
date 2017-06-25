using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
namespace PCS.OAS.DLL
{
    public class DLLGeneralTippaniAttachment
    {
        public static bool AddAttachment(List<ATTGeneralTippaniAttachment> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID, int processID)
        {
            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniAttachment attachment in lst)
                {
                    if (attachment.Action != "N")
                    {
                        if (attachment.Action == "A")
                            SP = "SP_ADD_TIPPANI_ATTACHMENT";
                        else if (attachment.Action == "E")
                            SP = "SP_EDIT_TIPPANI_ATTACHMENT";
                        else if (attachment.Action == "D")
                            SP = "SP_DEL_TIPPANI_ATTACHMENT";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", attachment.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PROCESS_ID", processID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ATTACHMENT_ID", attachment.AttachmentID, OracleDbType.Int16, ParameterDirection.InputOutput));
                        if (attachment.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_DOC_NAME", attachment.DocumentName, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DESCRIPTION", attachment.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_CONTENT", attachment.RawContent, OracleDbType.Blob, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_entry_by", attachment.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        attachment.AttachmentID = int.Parse(paramArray[3].Value.ToString());
                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAttachment(ATTGeneralTippaniAttachment attach)
        {
            string SQL = "SELECT * FROM VW_TIPPANI_ATTACHMENT_INFO WHERE 1 = 1";
            SQL = SQL + " AND ORG_ID = " + attach.OrgID.ToString();
            SQL = SQL + " AND TIPPANI_ID = " + attach.TippaniID.ToString();

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, null).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object GetAttachedFile(int orgID, int tippaniID, int prcID, int attID)
        {
            string SP = "SP_GET_TIPPANI_ATTACHMENT";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PROCESS_ID", prcID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ATTACHMENT_ID", attID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_content", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);

                object obj = SqlHelper.ExecuteScalar(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                
                return obj;
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
    }
}
