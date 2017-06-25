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
    public class DLLGroupMember
    {
        public static bool AddGroupMember(List<ATTGroupMember> lst)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection DBConn = new GetConnection();
            OracleTransaction Tran = DBConn.GetDbConn(Module.OAS).BeginTransaction();
            try
            {
                foreach (ATTGroupMember member in lst)
                {
                    if (member.Action == "A")
                        SP = "sp_add_group_member";
                    else if (member.Action == "E")
                        SP = "sp_Edit_group_member";
                    else if (member.Action == "D")
                        SP = "SP_DEL_GROUP_MEMBER";

                    if (member.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("p_org_id", member.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_group_id", member.GroupID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", member.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date", member.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (member.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("p_to_date", member.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            if (member.MemberPostion.PositionID == 0)
                            paramArray.Add(Utilities.GetOraParam("p_pos_id", null, OracleDbType.Int16, ParameterDirection.Input));
                            else
                            paramArray.Add(Utilities.GetOraParam("p_pos_id", member.MemberPostion.PositionID, OracleDbType.Int16, ParameterDirection.Input));
                           

                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        paramArray.Clear();
                    }
                }

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
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetGroupMemberListTable(int? groupID)
        {
            string SelectSQL = "SP_GET_GROUP_MEMBER";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", groupID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[1].Value).GetDataReader();

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
