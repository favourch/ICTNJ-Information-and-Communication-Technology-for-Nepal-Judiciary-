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
    public class DLLGroup
    {
        public static bool AddGroup(ATTGroup obj)
        {
            string SP = "";
            if (obj.Action == "A")
                SP = "sp_add_group";
            else
                SP = "sp_edit_group";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_group_id", obj.GroupID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_group_name", obj.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_description", obj.Description, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_type", obj.Type, OracleDbType.Char, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();

            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                obj.GroupID = int.Parse(paramArray[1].Value.ToString());
                return true;
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

        public static DataTable GetGroupListTable(int? orgID, char type)
        {
            string SelectSQL = "SP_GET_GROUP";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_SEARCH_VALUE", null, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_TYPE", type, OracleDbType.Char, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

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
