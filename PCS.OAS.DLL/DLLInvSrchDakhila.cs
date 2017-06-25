using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvSrchDakhila
    {
        public static DataTable SrchDirectEntry(ATTInvSrchDakhila objSrchDak)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            try
            {
                string srchSQL = " SELECT * FROM vw_inv_Direct_Entry   "
                                + " WHERE 1=1 AND APP_YES_NO is  null ";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objSrchDak.OrgID != null)
                {
                    srchSQL = srchSQL + " AND ORG_ID =:ORG_ID ";
                    paramArray.Add(Utilities.GetOraParam(":ORG_ID", objSrchDak.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (objSrchDak.ItemsCategoryID != null)
                {
                    srchSQL = srchSQL + " AND ITEMS_CATEGORY_ID =:ITEMS_CATEGORY_ID ";
                    paramArray.Add(Utilities.GetOraParam(":ITEMS_CATEGORY_ID", objSrchDak.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (objSrchDak.ItemsSubCategoryID != null)
                {
                    srchSQL = srchSQL + " AND ITEMS_SUB_CATEGORY_ID =:ITEMS_SUB_CATEGORY_ID ";
                    paramArray.Add(Utilities.GetOraParam(":ITEMS_SUB_CATEGORY_ID", objSrchDak.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (objSrchDak.ItemsID != null)
                {
                    srchSQL = srchSQL + " AND ITEMS_ID =:ITEMS_ID ";
                    paramArray.Add(Utilities.GetOraParam(":ITEMS_ID", objSrchDak.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (objSrchDak.DirectEntryDate != "____/__/__")
                {
                    srchSQL = srchSQL + " AND DIR_ENTRY_DATE =:DIR_ENTRY_DATE ";
                    paramArray.Add(Utilities.GetOraParam(":DIR_ENTRY_DATE", objSrchDak.DirectEntryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                }




                return SqlHelper.ExecuteDataset(CommandType.Text, srchSQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
