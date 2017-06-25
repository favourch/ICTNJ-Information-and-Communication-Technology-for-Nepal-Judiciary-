using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLCaseCheckList
    {

        public static bool AddEditCaseCheckList(List<ATTCaseCheckList> CaseCheckListLST, OracleTransaction Tran,double caseID)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;

            try
            {
                foreach (ATTCaseCheckList obj in CaseCheckListLST)
                {
                    if (obj.Action == "A")
                        InsertUpdateSQL = "SP_ADD_CASE_CHECKLIST";
                    else if (obj.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_CASE_CHECKLIST";

                    paramArray = new List<OracleParameter>();


                    paramArray.Add(Utilities.GetOraParam("P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ORG_ID", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_CASE_TYPE_ID", obj.CaseTypeID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REG_TYPE_ID", obj.RegTypeID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_CHECK_LIST_ID", obj.CheckListID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_FULL_FILLED", obj.FulFilled, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REMARKS", obj.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray() );
                        

                }



                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }

        }


        public static DataTable GetCaseCheckList(double caseID,int  orgID,int?  caseTypeID,int regTypeID,int ? checkListID)
        {

            string SelectSql = "SP_GET_CASE_CHECKLIST";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int16, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Varchar2, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_REG_TYPE_ID", regTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_CHECK_LIST_ID", checkListID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



    }
}
