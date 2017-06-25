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
    public class DLLInvPurchaseOrder
    {
        public static int SavePurchaseOrder(ATTInvPurchaseOrder objPo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
     
            try
            {
                if (objPo.Action == "A")
                {
                    int orderCount = CheckPurOrderAvailability(objPo, Tran);

                    if (orderCount > 0)
                    {
                        Tran.Commit();
                        return -1;
                    }
                }

                string sp = "";
                int countPoDetail = objPo.lstPurchaseOrderDetail.Count;

                if (objPo.Action == "A")
                    sp = "sp_inv_add_purchase_order";
                else if(objPo.Action == "E")
                    sp = "sp_inv_edit_purchase_order";


                 if (objPo.Action != "N" && sp != "")
                 {

                    OracleParameter[] paramArray = new OracleParameter[11];

                    paramArray[0]  = Utilities.GetOraParam(":p_org_id",objPo.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1]  = Utilities.GetOraParam(":p_order_no", objPo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2]  = Utilities.GetOraParam(":p_order_date",objPo.OrderDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[3]  = Utilities.GetOraParam(":p_suppliers_id",objPo.SupplierID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4]  = Utilities.GetOraParam(":p_rec_by", objPo.RecBy, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5]  = Utilities.GetOraParam(":p_rec_date",objPo.RecDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6]  = Utilities.GetOraParam(":p_rec_yes_no",objPo.RecYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7]  = Utilities.GetOraParam(":p_app_by",objPo.AppBy, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":p_app_date",objPo.AppDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":p_app_yes_no",objPo.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":p_entry_by",objPo.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);
                }

                if (countPoDetail > 0)
                    DLLInvPurchaseOrderDetail.SavePurchaseOrderDetail(objPo, Tran);
                        
                Tran.Commit();

                return 0;
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }

        public static int RecomendApprovePurchaseOrder(ATTInvPurchaseOrder objPo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                string sp = "";
                int countPoDetail = objPo.lstPurchaseOrderDetail.Count;

                if (objPo.Type == 1)
                    sp = "SP_INV_REC_PURCHASE_ORDER";
                else if (objPo.Type == 2)
                    sp = "SP_INV_APP_PURCHASE_ORDER";

                if (objPo.Type != null && sp != "")
                {

                    List<OracleParameter> paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam(":p_org_id", objPo.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                   // paramArray.Add(Utilities.GetOraParam(":p_unit_id", objPo.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_order_no", objPo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (objPo.Type == 1)
                    {

                        paramArray.Add(Utilities.GetOraParam(":p_rec_by", objPo.RecBy, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_rec_date", objPo.RecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_rec_yes_no", objPo.RecYesNo, OracleDbType.Varchar2, ParameterDirection.Input));

                    }
                    else if (objPo.Type == 2)
                    {
                        paramArray.Add(Utilities.GetOraParam(":p_app_by", objPo.AppBy, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_app_date", objPo.AppDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_app_yes_no", objPo.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }

                    SqlHelper.ExecuteNonQuery(Tran,CommandType.StoredProcedure, sp, paramArray.ToArray());

                    paramArray.Clear();
                }

                if (countPoDetail > 0)
                    DLLInvPurchaseOrderDetail.SavePurchaseOrderDetail(objPo, Tran);

                Tran.Commit();

                if (objPo.Type == 1)
                    return 1;
                else if (objPo.Type == 2)
                    return 2;
                else
                    return 3;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static int CheckPurOrderAvailability(ATTInvPurchaseOrder objPo, OracleTransaction Tran)
        {
            try
            {
                string chkPurOrderSQL = "SELECT  CHECK_PUR_ORDER_AVAILABILITY("  + objPo.OrgID + ",'"
                                                                                 + objPo.OrderNo + "')" +
                                        "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text,chkPurOrderSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int orderCount = int.Parse(tbl.Rows[0][0].ToString());

                return orderCount;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
