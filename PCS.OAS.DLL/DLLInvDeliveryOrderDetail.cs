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
    public class DLLInvDeliveryOrderDetail
    {
        public static bool SaveUpdateDeliveryOrderDetail(ATTInvDeliveryOrder objDo, OracleTransaction Tran)
        {
            try
            {
                string sp = "";

                foreach (ATTInvDeliveryOrderDetail objDoDetail in objDo.lstDeliveryOrderDetail)
                {
                    if (objDoDetail.Action == "A")
                        sp = "sp_inv_add_delivery_order_det";
                    else if (objDoDetail.Action == "E")
                        sp = "sp_inv_edit_delivery_order_det";


                    if (objDoDetail.Action != "N" && sp != "")
                    {
                        objDoDetail.OrgID = objDo.OrgID;
                        objDoDetail.UnitID = objDo.UnitID;
                        objDoDetail.OrderNo = objDo.OrderNo;
                        objDoDetail.DeliverySeq = objDo.DeliverySeq;
                       
                        List<OracleParameter> paramArray = new List<OracleParameter>();

                        paramArray.Add(Utilities.GetOraParam(":p_org_id", objDoDetail.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_order_no", objDoDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_delivery_seq", objDoDetail.DeliverySeq, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_category_id", objDoDetail.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", objDoDetail.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_items_id", objDoDetail.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_seq_no",objDoDetail.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":p_delivery_qty", objDoDetail.TotalDeliveryQty, OracleDbType.Int64, ParameterDirection.Input));
                         
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());
                       
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
