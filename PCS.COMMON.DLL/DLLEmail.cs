using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COREDL;
using Oracle.DataAccess.Client;

namespace PCS.COMMON.DLL
{
    public class DLLEmail
    {
        public static DataTable GetEmail(int? OrgId)
        {
            try
            {
                string SelectEmailSQL = "SP_GET_ORG_EMAIL";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":p_active", null, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectEmailSQL, ParamArray);
                
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool SaveOrganizationEmail(List<ATTEmail> lstEmail, OracleTransaction Tran, Int64 OrgID)
        {
            //string DeleteEmailSQL;
            string InsertEmailSQL;
            //string EntryBy = "shyam";

            if (lstEmail.Count == 0)
                return true;

            try
            {
                //DeleteEmailSQL = "SP_DEL_ORG_EMAIL";
                //OracleParameter[] ParamDeleteArray = new OracleParameter[1];

                //ParamDeleteArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input);

                //SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeleteEmailSQL, ParamDeleteArray);

                foreach (ATTEmail ObjEmail in lstEmail)
                {
                    InsertEmailSQL = "";
                    if (ObjEmail.Action == "A")
                        InsertEmailSQL = "SP_ADD_ORG_EMAIL";
                    else if (ObjEmail.Action == "E")
                        InsertEmailSQL = "SP_EDIT_ORG_EMAIL";
                    OracleParameter[] ParamArray = new OracleParameter[7];

                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":p_E_TYPE", ObjEmail.EmailTypeId, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":p_E_SNO", ObjEmail.ESNo, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":p_EMAIL", ObjEmail.Email, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":p_ACTIVE", ObjEmail.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":p_REMARKS", ObjEmail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":p_ENTRY_BY", ObjEmail.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    if (ObjEmail.Action != "")
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertEmailSQL, ParamArray);
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
