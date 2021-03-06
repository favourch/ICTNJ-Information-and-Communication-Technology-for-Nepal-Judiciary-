using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.DLL
{
    public class DLLUserLogin
    {
        //public static ATTUserLogin GetUserLogin(string userName, string password, int orgID)
        //{
        //    string LoginSP = "SP_LOGIN";
            
        //    List<OracleParameter> paramArray = new List<OracleParameter>();

        //    paramArray.Add(Utilities.GetOraParam(":p_user_name", userName.Trim(), OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray[0].Size = 10;
        //    paramArray.Add(Utilities.GetOraParam(":p_password", password.Trim(), OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray[1].Size = 10;
        //    paramArray.Add(Utilities.GetOraParam(":p_org_id", orgID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam(":P_message", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //    paramArray[3].Size = 50;
        //    paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

        //    GetConnection GetConn = new GetConnection();

        //    try
        //    {
        //        OracleConnection DBConn = GetConn.GetDbConn();
        //        SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, LoginSP, paramArray.ToArray());

        //        ATTUserLogin user = new ATTUserLogin();
        //        user.UserMessage = paramArray[3].Value.ToString();

        //        if (user.UserMessage.ToUpper() == "OK")
        //        {
        //            OracleDataReader reader = ((OracleRefCursor)paramArray[4].Value).GetDataReader();

        //            DataTable tbl = new DataTable();
        //            tbl.Load(reader, LoadOption.OverwriteChanges);
        //            foreach (DataRow row in tbl.Rows)
        //            {
        //                user.MenuList.Add(row["Menu_Name"].ToString(), row["Menu_Name"].ToString());
        //            }
        //        }

        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        GetConn.CloseDbConn();
        //    }
        //}

        public static ATTUserLogin GetUserLogin(string userName, string password,int ApplID)
        {
            string LoginSP = "SP_LOGIN";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam(":p_user_name", userName.Trim(), OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray[0].Size = 10;
            paramArray.Add(Utilities.GetOraParam(":p_password", password.Trim(), OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray[1].Size = 10;
            paramArray.Add(Utilities.GetOraParam(":P_message", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramArray[2].Size = 50;

            paramArray.Add(Utilities.GetOraParam(":P_Org_ID", null, OracleDbType.Int64, ParameterDirection.Output));
            paramArray.Add(Utilities.GetOraParam(":P_Org_Name", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramArray[4].Size = 100;
            paramArray.Add(Utilities.GetOraParam(":P_Org_Address", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramArray[5].Size = 300;
            paramArray.Add(Utilities.GetOraParam(":P_ID", null, OracleDbType.Double, ParameterDirection.Output));
                        
            //paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            GetConnection GetConn = new GetConnection();
            GetConnection GetConn1 = new GetConnection();


            try
            {
                OracleConnection DBConn = GetConn.GetDbConn();
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, LoginSP, paramArray.ToArray());

                ATTUserLogin user = new ATTUserLogin();
                user.UserMessage = paramArray[2].Value.ToString();
                user.OrgID = int.Parse(paramArray[3].Value.ToString());
                user.OrgName = paramArray[4].Value.ToString();
                user.OrgAddress = paramArray[5].Value.ToString();
                user.PID = (paramArray[6].Value == System.DBNull.Value) ? 0 : double.Parse(paramArray[6].Value.ToString());

                List<OracleParameter> paramArray1 = new List<OracleParameter>();
                paramArray1.Add(Utilities.GetOraParam("p_emp_id", user.PID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray1.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));
                OracleConnection DBConn1 = GetConn1.GetDbConn(Module.PMS);
                DataTable tbl = SqlHelper.ExecuteDataset(DBConn1, CommandType.StoredProcedure, "sp_get_user_unit", paramArray1.ToArray()).Tables[0];

                if (tbl.Rows.Count == 1)
                {
                    user.UnitID = int.Parse(tbl.Rows[0][0].ToString());
                    user.UnitName = tbl.Rows[0][1].ToString();
                }
                //if (user.UserMessage.ToUpper() == "OK")
                //{
                //    string strUserMenus = "SP_GET_USER_MENUS";
                //    List<OracleParameter> paramArrayUserMenus = new List<OracleParameter>();
                //    paramArrayUserMenus.Add(Utilities.GetOraParam(":p_user_name", userName, OracleDbType.Varchar2, ParameterDirection.Input));
                //    paramArrayUserMenus.Add(Utilities.GetOraParam(":p_appl_id", ApplID, OracleDbType.Int64, ParameterDirection.Input));
                //    paramArrayUserMenus.Add(Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));
                //    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, strUserMenus, paramArrayUserMenus.ToArray());
                //    OracleDataReader reader = ((OracleRefCursor)paramArrayUserMenus[2].Value).GetDataReader();
                //    DataTable tbl = new DataTable();

                //    tbl.Load(reader, LoadOption.OverwriteChanges);
                //    foreach (DataRow row in tbl.Rows)
                //    {
                //        AccessColumn col = new AccessColumn();

                //        col.PSelect = row["P_SELECT"].ToString();
                //        col.PAdd = row["P_ADD"].ToString();
                //        col.PEdit = row["P_EDIT"].ToString();
                //        col.PDelete = row["P_DELETE"].ToString();

                //        user.MenuList.Add(row["Menu_ID"].ToString(), col);
                //    }
                //}

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
                GetConn1.CloseDbConn();
            }
        }

        public static Dictionary<string, AccessColumn> GetUserApplicationMenu(string username, int applID)
        {
            Dictionary<string, AccessColumn> DList = new Dictionary<string, AccessColumn>();
            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn();

                string strUserMenus = "SP_GET_USER_MENUS";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                paramArray.Add(Utilities.GetOraParam(":p_user_name", username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":p_appl_id", applID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataTable tbl = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, strUserMenus, paramArray.ToArray()).Tables[0];

                foreach (DataRow row in tbl.Rows)
                {
                    AccessColumn col = new AccessColumn();

                    col.PSelect = row["P_SELECT"].ToString();
                    col.PAdd = row["P_ADD"].ToString();
                    col.PEdit = row["P_EDIT"].ToString();
                    col.PDelete = row["P_DELETE"].ToString();

                    DList.Add(row["Menu_ID"].ToString(), col);
                }

                return DList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
