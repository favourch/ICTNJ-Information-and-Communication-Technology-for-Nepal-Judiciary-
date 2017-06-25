using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLPersonAttachments
    {
        public static bool SaveAttachments(List<ATTPersonAttachments> LstAttachments, OracleTransaction Tran, double empid)
        {
            //GetConnection conn = new GetConnection();
            //OracleConnection dbconn = conn.GetDbConn(Module.PMS);
            string InsertSQL = "";
            try
            {
                foreach (ATTPersonAttachments obj in LstAttachments)
                {
                    if (obj.Action == "A")
                    {
                        InsertSQL = "SP_ADD_EMP_ATTACHMENTS";
                    }
                    else if (obj.Action == "E")
                    {
                        InsertSQL = "SP_EDIT_EMP_ATTACHMENTS";
                    }
                    if (obj.Action == "A" || obj.Action == "E")
                    {
                        OracleParameter[] paramArray = new OracleParameter[7];
                        paramArray[0] = Utilities.GetOraParam("P_EMP_ID", empid, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam("P_ATT_SEQ", obj.AttSeq, OracleDbType.Int32, ParameterDirection.InputOutput);
                        paramArray[2] = Utilities.GetOraParam("P_ATT_DATE", obj.AttachmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam("P_ATT_SUBJECT", obj.AttachmentTitle, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam("P_ATT_CONTENT", obj.AttachmentDocs, OracleDbType.Blob, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam("P_ATT_REMARKS", obj.AttachmentDesc, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSQL, paramArray);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
