using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.CMS.DLL
{
    public class DLLWritSubCatTitle
    {
        public static bool AddWritSubCatTitle(List<ATTWritCategoryTitle> Lst, OracleTransaction Tran, int writSubjectID,int writSubCatID)
        {
            try
            {
                string SPInsertUpdate = "";
                foreach (ATTWritCategoryTitle objWritSubCatTitle in Lst)
                {
                    if (objWritSubCatTitle.Action == "A")
                        SPInsertUpdate = "SP_ADD_WRIT_SUB_CAT_TITLE";
                    else// if (objWritSubCatTitle.Action == "E")
                        SPInsertUpdate = "SP_EDIT_WRIT_SUB_CAT_TITLE";

                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubjectID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", writSubCatID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_TITLE_ID", objWritSubCatTitle.WritSubjectCatTitleID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_TITLE_NAME", objWritSubCatTitle.WritSubjectCatTitleName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objWritSubCatTitle.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objWritSubCatTitle.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SPInsertUpdate, paramArray.ToArray());
                    objWritSubCatTitle.WritSubjectID = writSubjectID;
                    objWritSubCatTitle.WritSubjectCatID = writSubCatID;
                    objWritSubCatTitle.WritSubjectCatTitleID = int.Parse(paramArray[2].Value.ToString());
                    objWritSubCatTitle.Action = "";
                    
                    
                    if (objWritSubCatTitle.WritCategorySubTitleLST != null)
                        DLLWritSubCatSubTitle.AddWritSubCatSubTitle(objWritSubCatTitle.WritCategorySubTitleLST, Tran, writSubjectID, writSubCatID, objWritSubCatTitle.WritSubjectCatTitleID);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetWritSubCatTitle(int? writSubID, int? writSubCatID, int? writSubCatTitleID, string active)
        {

            string SelectSql = "SP_GET_WRIT_SUB_CAT_TITLE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", writSubCatID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_TITLE_ID", writSubCatTitleID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
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
