using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using Oracle.DataAccess.Client;

namespace PCS.SECURITY.DLL
{
    public class DLLRoleMenus
    {
        public static DataTable GetRoleMenusTable(int applID, int roleID, int formID, int menuID)
        {
            string SPSelect = "SP_GET_ROLE_MENUS";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[5];

                ParamArray[0] = Utilities.GetOraParam(":P_APPL_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ROLE_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_FORM_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_MENU_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, ParamArray).Tables[0];
                return tbl;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddRoleMenus1(ATTRoleMenus objATT)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;

            try
            {
                DBConn = Conn.GetDbConn();

                string InsertUpdateSQL = "";

                if (objATT.RoleID <= 0)
                    InsertUpdateSQL = "SP_ADD_ROLE_MENUS";
                else
                    InsertUpdateSQL = "SP_EDIT_ROLE_MENUS";

                OracleParameter[] ParamArray = new OracleParameter[4];

                ParamArray[0] = Utilities.GetOraParam(":p_ROLE_ID", objATT.RoleID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_MENU_ID", objATT.MenuID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[2] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplicationID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[3] = Utilities.GetOraParam(":p_FORM_ID", objATT.FormID, OracleDbType.Int64, ParameterDirection.InputOutput);

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

        public static bool AddRoleMenus(List<ATTRoleMenus> lstRoleMenus, OracleTransaction tran, int roleID,int applID)
        {
            try
            {
                foreach (ATTRoleMenus lst in lstRoleMenus)
                {
                    string InsertUpdateDeleteSQL = "";
                    if (lst.Action != "D")
                    {
                        OracleParameter[] paramArray = new OracleParameter[8];
                        paramArray[0] = Utilities.GetOraParam(":p_ROLE_ID", roleID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_APPL_ID", applID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_FORM_ID", lst.FormID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_MENU_ID", lst.MenuID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_P_SELECT", lst.PSelect, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_P_ADD", lst.PAdd, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_P_EDIT", lst.PEdit, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_P_DELETE", lst.PDelete, OracleDbType.Varchar2, ParameterDirection.Input);
                        if (lst.Action == "A")
                            InsertUpdateDeleteSQL = "SP_ADD_ROLE_MENUS";
                        else if (lst.Action == "E")
                            InsertUpdateDeleteSQL = "SP_EDIT_ROLE_MENUS";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, paramArray);

                    }

                    else if (lst.Action == "D")
                    {
                        OracleParameter[] DeleteparamArray = new OracleParameter[4];
                        DeleteparamArray[0] = Utilities.GetOraParam(":p_ROLE_ID", roleID, OracleDbType.Int64, ParameterDirection.Input);
                        DeleteparamArray[1] = Utilities.GetOraParam(":p_APPL_ID", applID, OracleDbType.Int64, ParameterDirection.Input);
                        DeleteparamArray[2] = Utilities.GetOraParam(":p_FORM_ID", lst.FormID, OracleDbType.Int64, ParameterDirection.Input);
                        DeleteparamArray[3] = Utilities.GetOraParam(":p_MENU_ID", lst.MenuID, OracleDbType.Int64, ParameterDirection.Input);
                        InsertUpdateDeleteSQL = "SP_DEL_ROLE_MENUS";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, DeleteparamArray);
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

