using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using Oracle.DataAccess.Client;

namespace PCS.COMMON.DLL
{
    public class DLLPhone
    {
        public static DataTable GetPhone(int? OrgId)
        {
            try
            {
                string SelectPhoneSQL = "SP_GET_ORG_PHONE";
                
                OracleParameter[] ParamArray = new OracleParameter[3];
                
                ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":p_active", null, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectPhoneSQL, ParamArray);
                
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveOrganizationPhone(List<PCS.COMMON.ATT.ATTPhone> lstPhone, OracleTransaction Tran, int OrgID)
        {
            string InsertPhoneSQL;
            string DeletePhoneSQL;
            //string username = "shyam";

            if (lstPhone.Count == 0)
                return true;

            try
            {


                //DeletePhoneSQL = "SP_DEL_ORG_PHONE";
                //OracleParameter[] ParamDeleteArray = new OracleParameter[1];

                //ParamDeleteArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input);

                //SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeletePhoneSQL, ParamDeleteArray);

                foreach (ATT.ATTPhone ObjPhone in lstPhone)
                {
                    InsertPhoneSQL = "";
                    if (ObjPhone.Action == "A")
                        InsertPhoneSQL = "SP_ADD_ORG_PHONE";
                    else if (ObjPhone.Action == "E")
                        InsertPhoneSQL = "SP_EDIT_ORG_PHONE";
                    OracleParameter[] ParamArray = new OracleParameter[7];

                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":p_P_TYPE", ObjPhone.PhoneTypeId, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":p_P_SNO", ObjPhone.PSno, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":p_PHONE", ObjPhone.Phone, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":p_ACTIVE", ObjPhone.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":p_REMARKS", ObjPhone.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":p_ENTRY_BY", ObjPhone.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    if (ObjPhone.Action != "")
                        COREDL.SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertPhoneSQL, ParamArray);

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
