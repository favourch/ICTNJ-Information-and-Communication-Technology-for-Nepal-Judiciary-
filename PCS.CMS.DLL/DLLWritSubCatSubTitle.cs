using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLWritSubCatSubTitle
    {
        public static bool AddWritSubCatSubTitle(List<ATTWritCategorySubTitle> Lst, OracleTransaction Tran, int writSubjectID,int writSubCatID,int writSubCatTitleID)
        {
            try
            {
                string SPInsertUpdate = "";
                foreach (ATTWritCategorySubTitle objWritSubCatSubTitle in Lst)
                {
                    if (objWritSubCatSubTitle.Action == "A")
                        SPInsertUpdate = "SP_ADD_WRIT_SUB_CAT_SUBTITLE";
                    else //if (objWritSubCatSubTitle.Action == "E")
                        SPInsertUpdate = "SP_EDIT_WRIT_SUB_CAT_SUBTITLE";

                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubjectID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", writSubCatID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_TITLE_ID", writSubCatTitleID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_SUBTITLE_ID", objWritSubCatSubTitle.WritSubjectCatSubTitleID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_SUBTITLE_NAME", objWritSubCatSubTitle.WritSubjectCatSubTitleName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objWritSubCatSubTitle.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objWritSubCatSubTitle.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SPInsertUpdate, paramArray.ToArray());
                    objWritSubCatSubTitle.WritSubjectID = writSubjectID;
                    objWritSubCatSubTitle.WritSubjectCatID = writSubCatID;
                    objWritSubCatSubTitle.WritSubjectCatTitleID = writSubCatTitleID;
                    objWritSubCatSubTitle.WritSubjectCatSubTitleID= int.Parse(paramArray[3].Value.ToString());
                    objWritSubCatSubTitle.Action = "";

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetWritSubCatSubTitle(int? writSubID,int? writSubCatID, int? writSubCatTitleID, int? writSubCatSubTitleID,  string active)
        {

            string SelectSql = "SP_GET_WRIT_SUB_CAT_SUBTITLE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_ID", writSubCatID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_TITLE_ID", writSubCatTitleID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_CAT_SUBTITLE_ID", writSubCatSubTitleID, OracleDbType.Int64, ParameterDirection.Input));
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
