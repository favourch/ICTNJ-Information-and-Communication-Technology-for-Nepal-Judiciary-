using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.DLL
{
    public class DLLRelationType
    {
        public static DataTable GetRelationType(int? relationTypeID)
        {
            string SelectSP = "SP_GET_RELATION_TYPES";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":P_RELATION_TYPE_ID", relationTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveRelationType(ATTRelationType obj)
        {
            string SP = "";
            if (obj.Action == "A")
                SP = "SP_ADD_RELATION_TYPES";
            else if (obj.Action == "E")
                SP = "SP_EDIT_RELATION_TYPES";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection getConn = new GetConnection();
            OracleTransaction Tran = getConn.GetDbConn().BeginTransaction();
            paramArray.Add(Utilities.GetOraParam(":RELATION_TYPE_ID", obj.RelationTypeID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":RELATION_TYPE_NAME", obj.RelationTypeName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":RELATION_TYPE_CARDINALITY", obj.RelationTypeCardinality, OracleDbType.Int64, ParameterDirection.Input));

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                int relationTypeID = int.Parse(paramArray[0].Value.ToString());
                obj.RelationTypeID = relationTypeID;
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
