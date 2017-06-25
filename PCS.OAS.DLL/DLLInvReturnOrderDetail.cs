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
    public class DLLInvReturnOrderDetail
    {
        public static bool SaveUpdateReturnOrderDetail(ATTInvReturnOrder objRo, OracleTransaction Tran)
        {
            try
            {
                string sp = "";

                foreach (ATTInvReturnOrderDetail objRoDetail in objRo.LstReturnOrderDetail)
                {
                    sp = "";

                    if (objRoDetail.Action == "A")
                        sp = "sp_inv_add_return_order_det";
                    else if (objRoDetail.Action == "E")
                        sp = "sp_inv_edit_return_order_det";


                     if (objRoDetail.Action != "N" && sp != "")
                     {
                         objRoDetail.ReturnSeq = objRo.ReturnSeq;

                         List<OracleParameter> paramArray = new List<OracleParameter>();
                         // ,        
                         paramArray.Add(Utilities.GetOraParam(":p_org_id", objRoDetail.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_order_no", objRoDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_delivery_seq", objRoDetail.DeliverySeq, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_return_seq", objRoDetail.ReturnSeq, OracleDbType.Int64, ParameterDirection.Input));

                         paramArray.Add(Utilities.GetOraParam(":p_items_category_id", objRoDetail.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", objRoDetail.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_items_id",objRoDetail.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_seq_no",objRoDetail.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                         paramArray.Add(Utilities.GetOraParam(":p_return_qty",objRoDetail.ReturnQty, OracleDbType.Int64, ParameterDirection.Input));

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
