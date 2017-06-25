using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using PCS.COMMON.DLL;
using PCS.COMMON.ATT;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLLitigants
    {


        public static bool AddEditLitigants(List<ATTLitigants> LitigantLST, OracleTransaction Tran,double caseID)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;
            try
            {
                foreach (ATTLitigants obj in LitigantLST)
                {
                    double litigantID = 0;
                    if (obj.Action == "A")
                        InsertUpdateSQL = "SP_ADD_LITIGANTS";
                    else if (obj.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_LITIGANTS";

                    if (obj.PersonOBJ != null)
                       litigantID= DLLPerson.AddPersonnelDetails(obj.PersonOBJ, Tran);

                    paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam("P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LITIGANT_ID", litigantID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LITIGANT_TYPE", obj.LitigantType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LITIGANT_SUB_TYPE_ID", obj.LitigantSubTypeID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_DISPLAY_NAME", obj.DisplayName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_S_NO", obj.SNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_IS_PRISONED", obj.IsPrisoned, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
               
                    obj.CaseID = caseID;
                    obj.LitigantID = litigantID;

                    if (obj.LitigantPrisonDetailsLST.Count > 0)
                        DLLLitigantPrisonDetails.AddEditLitigantsPrisonDetails(obj.LitigantPrisonDetailsLST, caseID, litigantID, Tran);

                }

                  

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }

        }



        public static DataTable GetLitigants(double? caseID,double ? litigantID,string litigantType)
        {
            string SelectSql = "";
            SelectSql = "SP_GET_LITIGANTS";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", litigantID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_LITIGANT_TYPE", litigantType, OracleDbType.Varchar2, ParameterDirection.Input));
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
