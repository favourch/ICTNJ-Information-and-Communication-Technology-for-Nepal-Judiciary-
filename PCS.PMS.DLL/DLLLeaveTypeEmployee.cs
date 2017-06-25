using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLLeaveTypeEmployee
    {
        public static DataTable GetLeaveTypeEmployee(int? leaveTypeID, int? empID)
        {
            try       
            {

                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.PMS);

            string GetLeaveTypeEmployeeSQL = "SP_GET_LEAVE_TYPE_EMP";
                
            OracleParameter[] ParamArray = new OracleParameter[3];

            ParamArray[0] = Utilities.GetOraParam(":P_LEAVE_TYPE_ID", leaveTypeID, OracleDbType.Int64, ParameterDirection.Input);
            ParamArray[1] = Utilities.GetOraParam(":P_EMP_ID", empID, OracleDbType.Int64, ParameterDirection.Input);
            ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            
            DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, GetLeaveTypeEmployeeSQL, ParamArray);
                return (DataTable)ds.Tables[0];
                    
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        public static bool SaveLeaveTypeEmployee(List<ATTLeaveTypeEmployee> lstLeaveTypeEmployee)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn = Conn.GetDbConn(Module.PMS);

            string SaveLeaveTypeEmpoloyeeSQL = "";
            OracleTransaction Tran ;
            Tran = DBConn.BeginTransaction();
            try
            {
               
                foreach (ATTLeaveTypeEmployee ObjAtt in lstLeaveTypeEmployee)
                {
                    if (ObjAtt.Action == "A")
                        SaveLeaveTypeEmpoloyeeSQL = "SP_ADD_LEAVE_TYPE_EMP";
                    else if (ObjAtt.Action == "E" )
                        SaveLeaveTypeEmpoloyeeSQL = "SP_EDIT_LEAVE_TYPE_EMP";


                    if (ObjAtt.Action != "" && ObjAtt.Action != null &&ObjAtt.Action!="D")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[10];

                        ParamArray[0] = Utilities.GetOraParam(":P_LEAVE_TYPE_ID", ObjAtt.LeaveTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":P_EMP_ID", ObjAtt.EmpID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = Utilities.GetOraParam(":P_FROM_DATE", ObjAtt.EffectiveFromDate, OracleDbType.Varchar2, ParameterDirection.Input);                        
                        ParamArray[3] = Utilities.GetOraParam(":P_NO_OF_DAYS", ObjAtt.Days, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[4] = Utilities.GetOraParam(":P_PERIOD_TYPE", ObjAtt.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":P_PERIOD_TIMES", ObjAtt.PeriodTimes, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[6] = Utilities.GetOraParam(":P_IS_ACCRUAL", (ObjAtt.IsAccural?"Y":"N"), OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[7] = Utilities.GetOraParam(":P_ACCRUAL_DAYS", ObjAtt.AccuralDays, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[8] = Utilities.GetOraParam(":P_ACTIVE", (ObjAtt.Active?"Y":"N"), OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SaveLeaveTypeEmpoloyeeSQL, ParamArray);
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
                Conn.CloseDbConn();
            }
 
        }
    }
}
