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
    public class DLLLitigantPrisonDetails
    {

        public static bool AddEditLitigantsPrisonDetails(List<ATTLitigantPrisonDetails> LitigantPrisonDetailsLST,double caseID, double litigantID, OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;
            try
            {
                foreach (ATTLitigantPrisonDetails obj in LitigantPrisonDetailsLST)
                {
                    if (obj.Action == "A")
                        InsertUpdateSQL = "SP_ADD_LIT_PRISON_DET";
                    else if (obj.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_LIT_PRISON_DET";

                    
                    paramArray = new List<OracleParameter>();


                    obj.CaseID = caseID;
                    obj.LitigantID = litigantID;

                    paramArray.Add(Utilities.GetOraParam("P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LITIGANT_ID", litigantID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_PRISON_PLACE", obj.PrisonPlace, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    //paramArray.Add(Utilities.GetOraParam("P_OLD_FROM_DATE", "", OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
               
                }
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }

        }


        public static DataTable GetLitigantPrisonDetails(double? caseID, double? litigantID)
        {
            string SelectSql = "";
            SelectSql = "SP_GET_LIT_PRISON_DET";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", litigantID, OracleDbType.Double, ParameterDirection.Input));
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
