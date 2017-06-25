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
    public class DLLInvPurchaseOrderDetail
    {
        public static bool SavePurchaseOrderDetail(ATTInvPurchaseOrder objPo, OracleTransaction Tran)
        {
            try
            {
                string sp = "";

                foreach (ATTInvPurchaseOrderDetail objPoDetail in objPo.lstPurchaseOrderDetail)
                {
                    if (objPoDetail.Action == "A")
                        sp = "sp_inv_add_purchase_order_det";
                    else if (objPoDetail.Action == "E")
                        sp = "sp_inv_edit_purchase_order_det";
                    else if (objPoDetail.Action == "D")
                        sp = "sp_inv_del_purchase_order_det";



                    if (objPoDetail.Action != "N" && sp != "")
                    {
                        objPoDetail.OrgID = objPo.OrgID;
                        objPoDetail.UnitID = objPo.UnitID;
                        objPoDetail.OrderNo = objPo.OrderNo;
                        objPoDetail.EntryBy = objPo.EntryBy;

                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        
                        paramArray.Add(Utilities.GetOraParam(":p_org_id", objPoDetail.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_order_no", objPoDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_category_id", objPoDetail.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", objPoDetail.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_id", objPoDetail.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_seq_no", objPoDetail.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                           
                        if (sp != "sp_inv_del_purchase_order_det")
                        {
                            paramArray.Add(Utilities.GetOraParam(":p_manu_company", objPoDetail.ManuCompany, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":p_manu_date", objPoDetail.ManuDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":p_brand", objPoDetail.Brand, OracleDbType.Varchar2, ParameterDirection.Input));


                            paramArray.Add(Utilities.GetOraParam(":p_total_quantity", objPoDetail.TotalQty, OracleDbType.Int64, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":p_unit_price", objPoDetail.UnitPrice, OracleDbType.Double, ParameterDirection.Input));
                           // paramArray.Add(Utilities.GetOraParam(":p_specifications", objPoDetail.Specification, OracleDbType.Varchar2, ParameterDirection.Input));

                            paramArray.Add(Utilities.GetOraParam(":p_entry_by", objPoDetail.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                        }

     
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());

                        sp = "";
                    }
                  
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable GetPurchaseOrderDetail(string orderNo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                string srchSQL =   " SELECT distinct items_category_id, items_category_name, items_sub_category_id,"
                                 + " items_sub_category_name,SEQ_NO,manu_company,manu_date,brand,  items_id, items_name,"
                                 + " total_quantity, unit_price"
                                 + " FROM vw_inv_purchase_orders WHERE 1=1 ";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (orderNo != "")
                {
                    srchSQL = srchSQL + " AND ORDER_NO =:order_no ";
                    paramArray.Add(Utilities.GetOraParam(":order_no",orderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                DataTable tbl = new DataTable();

                tbl = SqlHelper.ExecuteDataset(CommandType.Text, srchSQL, Module.OAS, paramArray.ToArray()).Tables[0];

                return tbl;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    
    }
}
