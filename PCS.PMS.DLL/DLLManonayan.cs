using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.PMS.DLL
{
    public class DLLManonayan
    {
        public static bool SaveManonayan(List<ATTManonayan> LstManonayan,OracleTransaction Tran,double empID)
        {
            string strAddEditManayan = "";
            foreach (ATTManonayan objManonayan in LstManonayan)
            {
                if (objManonayan.Action == "" || objManonayan.Action==null)
                    continue;
                if (objManonayan.Action == "A")
                    strAddEditManayan = "sp_add_emp_manonayan";
                else if (objManonayan.Action == "E")
                    strAddEditManayan = "SP_EDIT_EMP_MANONAYAN";
                else if (objManonayan.Action == "D")
                    strAddEditManayan = "sp_del_emp_manonayan";
                OracleParameter[] ParamArray = new OracleParameter[10];

                ParamArray[0] = Utilities.GetOraParam(":p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_manonayan_date", objManonayan.ManonayanDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_purpose", objManonayan.ManonayanPurpose, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_description", objManonayan.ManonayanDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":p_from_date", objManonayan.ManonayanFromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[5] = Utilities.GetOraParam(":p_to_date", objManonayan.ManonayanToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[6] = Utilities.GetOraParam(":p_app_by", objManonayan.ManonayanApprovedBY, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[7] = Utilities.GetOraParam(":p_app_date", objManonayan.ManonayanApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[8] = Utilities.GetOraParam(":p_app_yes_no", objManonayan.ManonayanApprovedYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[9] = Utilities.GetOraParam(":p_entry_by", objManonayan.ManonayanEntryBY, OracleDbType.Varchar2, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, strAddEditManayan, ParamArray);
            }
            return true;
        }

        public static DataTable GetManonayan(double EmpID)
        {
            GetConnection Conn = new GetConnection();
            OracleTransaction Tran = Conn.GetDbConn(Module.PMS).BeginTransaction();

            string strGetManonayan = "sp_get_emp_manonayan";
            OracleParameter[] ParamArray = new OracleParameter[2];
            ParamArray[0] = Utilities.GetOraParam(":p_emp_id", EmpID, OracleDbType.Double, ParameterDirection.Input);
            ParamArray[1] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);
            return SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, strGetManonayan, ParamArray).Tables[0];   
        }
    }
}
