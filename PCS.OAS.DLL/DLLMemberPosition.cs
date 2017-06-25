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
    public class DLLMemberPosition
    {
        public static DataTable GetMemberPositionTable(int? PositionID)
        {
            string SP = "SP_GET_MEMBER_POSITION";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_position_id", PositionID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMemberPosition(ATTMemberPosition member)
        {
            string SP = "";

            if (member.Action == "A")
                SP = "sp_add_member_position";
            else if(member.Action=="E")
                SP = "sp_edit_member_position";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_position_id", member.PositionID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_position_name", member.PositionName, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                member.PositionID = int.Parse(paramArray[0].Value.ToString());

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
    }
}
