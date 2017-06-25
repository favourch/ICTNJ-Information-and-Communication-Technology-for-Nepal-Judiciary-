using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.CMS.DLL
{
    public class DLLAttorney
    {
        public static DataTable GetAttorney(double? CaseID ,string active)
        {
            try
            {
                string SelectSql = "SP_GET_ATTORNEY";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", CaseID, OracleDbType.Double, ParameterDirection.Input);
                //ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                //ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_PERSON_ID", PersonID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteAttorney(List<ATTAttorney> attorneyLST)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                foreach (ATTAttorney attorneyObj in attorneyLST)
                {
                    if (attorneyObj.Action == "A")
                        InsertUpdateDeleteSQL = "SP_ADD_ATTORNEY";
                    else if (attorneyObj.Action == "E")
                        InsertUpdateDeleteSQL = "SP_EDIT_ATTORNEY";
                    else if (attorneyObj.Action == "D")
                        InsertUpdateDeleteSQL = "SP_DEL_ATTORNEY";

                    OracleParameter[] ParamArray;
                    if (attorneyObj.Action == "A" || attorneyObj.Action == "E")
                    {
                        //int personID = attorneyObj.PersonID;                        
                        //if (personID == 0)
                        //{
                        //    attorneyObj.Person.PId = personID;
                        //personID = int.Parse(DLLPerson.AddPersonnelDetails(attorneyObj.Person, Tran).ToString());
                        //}

                        ParamArray = new OracleParameter[8];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", attorneyObj.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", attorneyObj.LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_PERSON_ID", attorneyObj.PersonID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ATTORNEY_ID", attorneyObj.AttorneyID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_ATTORNEY_TYPE_ID", attorneyObj.AttorneyTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_FROM_DATE", attorneyObj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", attorneyObj.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[7] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", attorneyObj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                        attorneyObj.AttorneyID = int.Parse(ParamArray[3].Value.ToString());
                        attorneyObj.Action = "";
                    }
                    if (attorneyObj.Action == "D")
                    {
                        ParamArray = new OracleParameter[4];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", attorneyObj.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", attorneyObj.LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_PERSON_ID", attorneyObj.PersonID, OracleDbType.Int64, ParameterDirection.Input);
                        //ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ATTORNEY_ID", attorneyObj.AttorneyID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_FROM_DATE", attorneyObj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        
                       
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                        
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
                GetConn.CloseDbConn();
            }
        }
    }
}
