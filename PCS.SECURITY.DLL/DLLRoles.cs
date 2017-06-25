using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.SECURITY.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.SECURITY.DLL
{
    public class DLLRoles
    {
        public static DataTable GetRolesTable(int? applID, int? roleID)
        {
            string SPSelect = "SP_GET_ROLES";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":P_ROLE_ID", roleID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_APPL_ID", applID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, ParamArray).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddRoles(ATTRoles objATT)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;

            try
            {
                DBConn = Conn.GetDbConn();

                string InsertUpdateSQL = "";

                if (objATT.RoleID <= 0)
                    InsertUpdateSQL = "SP_ADD_ROLES";
                else
                    InsertUpdateSQL = "SP_EDIT_ROLES";

                OracleParameter[] ParamArray = new OracleParameter[4];

                ParamArray[0] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplicationID,OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_ROLE_ID", objATT.RoleID,OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[2] = Utilities.GetOraParam(":p_ROLE_NAME", objATT.RoleName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_ROLE_DESCRIPTION", objATT.RoleDescription, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }

        public static int AddRolesAndRoleMenus(List<ATTRoles> lstRoles)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();

            int roleID=0;
            int applID = 0;
            try
            {
                foreach (ATTRoles lst in lstRoles)
                {
                        OracleParameter[] paramArray = new OracleParameter[4];
                        paramArray[0] = Utilities.GetOraParam(":p_APPL_ID", lst.ApplicationID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_ROLE_ID", lst.RoleID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[2] = Utilities.GetOraParam(":p_ROLE_NAME", lst.RoleName, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_ROLE_DESRIPTION", lst.RoleDescription, OracleDbType.Varchar2, ParameterDirection.Input);

                    if(lst.RoleID==0)
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_ROLES", paramArray[1], paramArray);
                    else if(lst.RoleID>0)
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_ROLES", paramArray[1], paramArray);

                        roleID = int.Parse(paramArray[1].Value.ToString());
                        applID = int.Parse(paramArray[0].Value.ToString());

                    DLLRoleMenus.AddRoleMenus(lst.LstRoleMenus, Tran, roleID,applID);
                }

                Tran.Commit();

                return roleID;
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }


        public static DataTable GetApplicationRoleTable(int? applID,int? roleID)
        {
            try
            {
                string SPSelect = "SP_GET_ROLES";
                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":P_ROLE_ID", roleID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_APPL_ID", applID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, ParamArray).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
