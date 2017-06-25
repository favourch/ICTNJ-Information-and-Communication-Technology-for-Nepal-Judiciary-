using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LIS.DLL
{
    public class DLLLibraryMaterialKeyword
    {

        public static DataTable GetLibraryMaterialKeywordTable(int orgID, int libraryID, decimal lMaterialID)
        {
            string SelectSQL = "SELECT * FROM VW_LM_KEYWORD WHERE ORG_ID=:ORGID AND LIBRARY_ID=:LIBRARYID AND L_MATERIAL_ID=:LMATERIALID";
            
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":ORGID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":LIBRARYID", libraryID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":LMATERIALID", lMaterialID, OracleDbType.Decimal, ParameterDirection.Input);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SelectSQL, Module.LIS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddLibraryMaterialKeyword(List<ATTLibraryMaterialKeyword> lstkeyword, long lMaterialID, OracleTransaction tran)
        {
            string InsertSP = "";

            try
            {
                foreach (ATTLibraryMaterialKeyword obj in lstkeyword)
                {
                    OracleParameter[] paramArray = new OracleParameter[1];
                    if (obj.Action == "A")
                    {
                        InsertSP = "SP_ADD_LM_KEYWORD";
                        paramArray = new OracleParameter[5];
                        paramArray[4] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    }
                    else if (obj.Action == "D")
                    {
                        InsertSP = "SP_DEL_LM_KEYWORD";
                        paramArray = new OracleParameter[4];
                    }

                    if (obj.Action != "N")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_L_MATERIAL_ID", lMaterialID, OracleDbType.Long, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_Keyword_ID", obj.KeywordID, OracleDbType.Int64, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertSP, paramArray);
                    }
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
