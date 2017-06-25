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
    public class DLLInvSrchDeliveryOrder
    {
        public static DataTable SrchDeliveryOrder(ATTInvSrchDeliveryOrder objSrchDo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            try
            {
                string srchSQL = " SELECT * FROM vw_inv_delivery_orders WHERE 1=1 AND TOTAL_QUANTITY > TOTAL_DELIVERED ";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objSrchDo.OrderNo.Trim() != "")
                {
                    srchSQL = srchSQL + " AND ORDER_NO =:order_no ";
                    paramArray.Add(Utilities.GetOraParam(":order_no", objSrchDo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                                
                return SqlHelper.ExecuteDataset(CommandType.Text, srchSQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SrchDeliveredOrder(ATTInvSrchDeliveryOrder objSrchDo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            try
            {
                //string srchSQL = " SELECT DISTINCT org_id, order_no, delivery_seq, delivery_person,"
                //                                 +"delivery_date, rcvd_by, rcvd_date, invoice_no,"
                //                                 + "first_name,mid_name,sur_name "
                //                + " FROM vw_inv_delivered_orders  "
                //                + " WHERE 1=1 AND delivery_qty <> 0  ";

                string srchSQL = " SELECT DISTINCT org_id, order_no, delivery_seq, delivery_person,"
                                                + "delivery_date, rcvd_by, rcvd_date, invoice_no,"
                                                + "first_name,mid_name,sur_name "
                               + " FROM vw_inv_delivered_orders  "
                               + " WHERE 1=1 AND total_delivered > total_returned  ";


                //AND delivery_qty > total_returned

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objSrchDo.OrderNo.Trim() != "")
                {
                    srchSQL = srchSQL + " AND ORDER_NO =:order_no ";
                    paramArray.Add(Utilities.GetOraParam(":order_no", objSrchDo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                return SqlHelper.ExecuteDataset(CommandType.Text, srchSQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable DeliveredOrderDetail(ATTInvDeliveryOrder objDo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            try
            {
                string srchSQL = " SELECT DISTINCT org_id, order_no, delivery_seq, items_category_id,items_category_name, "
                                                 + "items_sub_category_id,items_sub_category_name, items_id,items_name,SEQ_NO, total_delivered,total_returned "
                                + " FROM vw_inv_delivered_orders "
                                + " WHERE 1=1 AND  total_delivered >  total_returned ";

                //delivery_qty > total_returned 


                List<OracleParameter> paramArray = new List<OracleParameter>();

               
                if (objDo.OrderNo.Trim() != "")
                {
                    srchSQL = srchSQL + " AND ORDER_NO =:order_no ";
                    paramArray.Add(Utilities.GetOraParam(":order_no", objDo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (objDo.DeliverySeq != null)
                {
                    srchSQL = srchSQL + " AND DELIVERY_SEQ =:delivery_seq ";
                    paramArray.Add(Utilities.GetOraParam(":delivery_seq", objDo.DeliverySeq, OracleDbType.Varchar2, ParameterDirection.Input));
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
