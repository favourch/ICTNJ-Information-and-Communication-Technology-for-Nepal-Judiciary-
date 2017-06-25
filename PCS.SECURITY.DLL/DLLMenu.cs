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
    public class DLLMenu
    {
        public static DataTable GetMenuTable(int appID,int formID,int MenuID)
        {
            string SelectSQL = "SP_GET_MENUS";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (appID > 0)
                paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", appID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", null, OracleDbType.Int64, ParameterDirection.Input));

            if (formID > 0)
                paramArray.Add(Utilities.GetOraParam(":p_FORM_ID", formID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam(":p_FORM_ID", null, OracleDbType.Int64, ParameterDirection.Input));

            if (MenuID > 0)
                paramArray.Add(Utilities.GetOraParam(":p_MENU_ID", MenuID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam(":p_MENU_ID", null, OracleDbType.Int64, ParameterDirection.Input));

            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMenu(List<ATTMenu> lstMenu, OracleTransaction tran, double formID)
        {
            string InsertSQL = "SP_ADD_MENUS";
            
            try
            {
                foreach (ATTMenu menu in lstMenu)
                {
                    if (menu.Action == "A")
                    {
                        OracleParameter[] paramArray = new OracleParameter[9];
                        paramArray[0] = Utilities.GetOraParam(":p_APPL_ID", menu.ApplicationID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_FORM_ID", formID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[2] = Utilities.GetOraParam(":p_MENU_ID", menu.MenuID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_MENU_NAME", menu.MenuName, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_MENU_DESCRIPTION", menu.MenuDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_P_SELECT", menu.PSelect, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_P_ADD", menu.PAdd, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_P_EDIT", menu.PEdit, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_P_DELETE", menu.PDelete, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertSQL, paramArray[2], paramArray);
                        menu.Action = "M";
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
