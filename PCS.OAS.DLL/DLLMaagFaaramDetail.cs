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
    public class DLLMaagFaaramDetail
    {
        public static bool SaveMaagFaaramDetail(List<ATTMaagFaaramDetail> lst, double? reqNo, OracleTransaction Tran)
        {
            string strSQL = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTMaagFaaramDetail objMaagFaaramDet in lst)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagFaaramDet.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramDet.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_NO", reqNo, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", objMaagFaaramDet.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", objMaagFaaramDet.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_ID", objMaagFaaramDet.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                    if (objMaagFaaramDet.Action == "D")
                        strSQL = "SP_INV_DEL_MAAG_FAARAM_DET";
                    else
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_REQ_QTY", objMaagFaaramDet.ReqQty, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_REMARKS", objMaagFaaramDet.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_APP_QTY", objMaagFaaramDet.AppQty, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMaagFaaramDet.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (objMaagFaaramDet.Action == "A")
                            strSQL = "SP_INV_ADD_MAAG_FAARAM_DET";
                        else if (objMaagFaaramDet.Action == "E")
                            strSQL = "SP_INV_EDIT_MAAG_FAARAM_DET";

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

        public static DataTable GetMaagFaaramDetail(ATTMaagFaaramDetail objMaagFaaramDetail)
        {
            string strSql = "SELECT * FROM VW_MAAG_FAARAM_DETAILS WHERE 1=1";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            if (objMaagFaaramDetail.OrgID != null)
            {
                strSql += " AND ORG_ID = :P_ORG_ID";
                paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagFaaramDetail.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            }
            
            if (objMaagFaaramDetail.UnitID != null)
            {
                strSql += " AND UNIT_ID = :P_UNIT_ID";
                paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramDetail.UnitID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (objMaagFaaramDetail.ReqNo != null)
            {
                strSql += " AND REQ_NO = :P_REQ_NO";
                paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramDetail.ReqNo, OracleDbType.Double, ParameterDirection.Input));
            }

            strSql += " ORDER BY ORG_ID,UNIT_ID,REQ_NO";
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, Module.OAS, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateMaagFaaramDetAppQty(List<ATTMaagFaaramDetail> lst, OracleTransaction Tran)
        {
            string strSQL = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTMaagFaaramDetail objMaagFaaramDet in lst)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objMaagFaaramDet.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objMaagFaaramDet.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_REQ_NO", objMaagFaaramDet.ReqNo, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", objMaagFaaramDet.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", objMaagFaaramDet.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_ID", objMaagFaaramDet.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_APP_QTY", objMaagFaaramDet.AppQty, OracleDbType.Int64, ParameterDirection.Input));
                    strSQL = "SP_INV_APP_QTY_MAAG_FAARAM_DET";
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
