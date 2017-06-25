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
    public class DLLCommitteeByTippani
    {
        public static int AddCommitteeByTippani
        (
            ATTCommitteeByTippani comm,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID

        )
        {
            string SP = "";

            if (comm.Action == "A")
                SP = "SP_ADD_COMMITTEE_BY_TIPPANI";
            else if (comm.Action == "E")
                SP = "SP_UP_COMMITTEE_BY_TIPPANI";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_comm_org_id", comm.CommitteeOrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_committee_id", comm.CommitteeID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_committee_name", comm.CommitteeName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_description", comm.Description, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_type", comm.Type, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_org_id", comm.OrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_entry_by", comm.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

            try
            {
                SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                int CID = int.Parse(paramArray[1].Value.ToString());
                comm.CommitteeID = CID;
                return CID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCommitteeByTippaniByTIDs(int orgID, int tippaniID)
        {
            string SP = "sp_get_comm_by_tippani";
            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
