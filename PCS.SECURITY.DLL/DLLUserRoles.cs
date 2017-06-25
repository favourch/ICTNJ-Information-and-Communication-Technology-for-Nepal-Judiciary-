using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.SECURITY.ATT;

namespace PCS.SECURITY.DLL
{
    public class DLLUserRoles
    {
        public static DataTable GetUserRoleTable(string Username)
        {
            try
            {
                //string SelectSQL = "select * from users a, user_roles b,roles c,applications d ";
                //SelectSQL+="where a.USER_NAME=b.USER_NAME and b.ROLE_ID=c.ROLE_ID and b.APPL_ID=c.APPL_ID and c.APPL_ID =d.APPL_ID ";
                //SelectSQL += " and a.USER_NAME=:Username and b.TO_DATE IS  NULL ORDER BY d.APPL_ID ";
                string SPSelect = "Sp_GET_USER_ROLES";

                OracleParameter[] ParamArray = new OracleParameter[4];

                ParamArray[0] = Utilities.GetOraParam(":p_appl_ID", 1, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_user_name", Username, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_role_Id", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);
                
                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, ParamArray);
                return (DataTable)ds.Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool AddUserRoles(List< ATTUserRoles>Lst, OracleTransaction Tran)
        {
            try
            {
                string  SPInsertUpdate ;
                foreach (ATTUserRoles objATT in Lst)
                {
                    if (objATT.Action == "A")
                        SPInsertUpdate = "SP_ADD_USER_ROLES";
                    else if (objATT.Action == "E")
                        SPInsertUpdate = "SP_EDIT_USER_ROLES";
                    else
                        SPInsertUpdate = "SP_DEL_USER_ROLES";
                    OracleParameter[] ParamArray;
                    if (objATT.Action == "R")
                    {
                         ParamArray = new OracleParameter[4];

                        ParamArray[0] = Utilities.GetOraParam(":p_USER_NAME", objATT.UserName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":p_ROLE_ID", objATT.RoleID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[2] = Utilities.GetOraParam(":p_to_date", objATT.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplID, OracleDbType.Int64, ParameterDirection.Input);
                    
                    }
                    else
                    {
                        ParamArray = new OracleParameter[4];

                        ParamArray[0] = Utilities.GetOraParam(":p_USER_NAME", objATT.UserName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":p_ROLE_ID", objATT.RoleID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[2] = Utilities.GetOraParam(":p_FROM_DATE", objATT.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplID, OracleDbType.Int64, ParameterDirection.Input);
                    }
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SPInsertUpdate, ParamArray);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    //    public static bool EditUserRoles(List<ATTUserRoles> Lst, OracleTransaction Tran)
    //    {
    //        PCS.COREDL.GetConnection Conn = new GetConnection();
    //        OracleConnection DBConn;

    //        try
    //        {
    //            DBConn = Conn.GetDbConn();

    //            foreach (ATTUserRoles objATT in Lst)
    //            {
    //                string SPUpdate = "SP_EDIT_USER_ROLES";

    //                OracleParameter[] ParamArray = new OracleParameter[4];

    //                ParamArray[0] = Utilities.GetOraParam(":p_USER_NAME", objATT.UserName, OracleDbType.Varchar2, ParameterDirection.Input);
    //                ParamArray[1] = Utilities.GetOraParam(":p_ROLE_ID", objATT.RoleID, OracleDbType.Int64, ParameterDirection.InputOutput);
    //                ParamArray[2] = Utilities.GetOraParam(":p_FROM_DATE", "", OracleDbType.Varchar2, ParameterDirection.Input);
    //                ParamArray[3] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplID, OracleDbType.Int64, ParameterDirection.Input);

    //                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SPUpdate, ParamArray);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            Conn.CloseDbConn();
    //        }
    //    }


    }
}
