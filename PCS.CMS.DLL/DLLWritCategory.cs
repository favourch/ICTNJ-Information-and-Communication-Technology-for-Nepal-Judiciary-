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
    public class DLLWritCategory
    {
        public static bool AddWritCategory(List<ATTWritCategory> Lst, OracleTransaction Tran,int writSubjectID)
        {
            try
            {
                string SPInsertUpdate="";
                foreach (ATTWritCategory objWritSubCat in Lst)
                {
                    if (objWritSubCat.Action == "A")
                        SPInsertUpdate = "SP_ADD_WRIT_SUBJECT_CATEGORY";
                    else //if (objWritSubCat.Action == "E")
                        SPInsertUpdate = "SP_EDIT_WRIT_SUBJECT_CATEGORY";

                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubjectID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", objWritSubCat.WritSubjectCatID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_NAME", objWritSubCat.WritSubjectCatName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objWritSubCat.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objWritSubCat.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SPInsertUpdate, paramArray.ToArray());
                    objWritSubCat.WritSubjectID = writSubjectID;
                    objWritSubCat.WritSubjectCatID= int.Parse(paramArray[1].Value.ToString());
                    objWritSubCat.Action = "";

                    if (objWritSubCat.WritCategoryTitleLST != null)
                        DLLWritSubCatTitle.AddWritSubCatTitle(objWritSubCat.WritCategoryTitleLST, Tran, writSubjectID, objWritSubCat.WritSubjectCatID);
                        

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetWritSubCat(int? writSubID, int? writSubCatID, string active)
        {

            string SelectSql = "SP_GET_WRIT_SUBJECT_CATEGORY";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", writSubCatID, OracleDbType.Int64, ParameterDirection.Input));
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
