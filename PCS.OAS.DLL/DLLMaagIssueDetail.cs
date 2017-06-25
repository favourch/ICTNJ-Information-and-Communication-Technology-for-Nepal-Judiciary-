using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMaagIssueDetail
    {
        public static bool SaveMaagIssueDetail(List<ATTMaagIssueDetail> lst, double? issueSeq, OracleTransaction Tran)
        {
            string strSQL = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTMaagIssueDetail objMaagIssueDet in lst)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagIssueDet.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagIssueDet.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_NO", objMaagIssueDet.ReqNo, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ISSUE_SEQ", issueSeq, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", objMaagIssueDet.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", objMaagIssueDet.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_ID", objMaagIssueDet.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                    if (objMaagIssueDet.Action == "D")
                        strSQL = "SP_INV_DEL_MAAG_ISSUE_DETAILS";
                    else
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_DELIVERED_QTY", objMaagIssueDet.DeliveredQty, OracleDbType.Int64, ParameterDirection.Input));
                        if (objMaagIssueDet.Action == "A")
                            strSQL = "SP_INV_ADD_MAAG_ISSUE_DETAILS";
                        else if (objMaagIssueDet.Action == "E")
                            strSQL = "SP_INV_EDIT_MAAG_ISSUE_DETAILS";

                    }
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, strSQL, paramArray.ToArray());
                    paramArray.Clear();
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
