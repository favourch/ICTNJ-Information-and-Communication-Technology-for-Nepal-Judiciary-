using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLOrgDecisionType
    {
        public static bool SaveOrgDecisionType(List<ATTOrgDecisionType> LstOrgDecType,int DecTypeID,OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";
            try
            {
                foreach (ATTOrgDecisionType objOrgDecType in LstOrgDecType)
                {

                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objOrgDecType.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_DECISION_TYPE_ID", DecTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objOrgDecType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objOrgDecType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    if (objOrgDecType.Action == "A")
                        InsertUpdateSQL = "SP_ADD_ORG_DECISION_TYPE";
                    else if (objOrgDecType.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_ORG_DECISION_TYPE";
                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }

                return true;
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

        public static DataTable GetOrgDecisionType(int OrgID, int? DecisionTypeID, string active, string loadAll)
        {

            string SelectSql = "";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            if (loadAll == "Y")
            {
                ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input));
                SelectSql = "SP_GET_ORG_DECISION_TYPE";
            }
            else
                SelectSql = "SP_GET_ALL_ORG_DEC_TYPE";

            ParamArray.Add(Utilities.GetOraParam(":P_DECISION_TYPE_ID", DecisionTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
