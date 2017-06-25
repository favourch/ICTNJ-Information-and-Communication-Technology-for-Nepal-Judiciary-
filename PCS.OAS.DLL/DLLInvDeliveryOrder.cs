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
    public class DLLInvDeliveryOrder
    {
        public static bool SaveUpdateDeliveryOrder(ATTInvDeliveryOrder objDo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                string sp = "";
                int countDoDetail = objDo.lstDeliveryOrderDetail.Count;

                if (objDo.Action == "A")
                    sp = "sp_inv_add_delivery_order";
                else if (objDo.Action == "E")
                    sp = "sp_inv_edit_delivery_order";

                if (objDo.Action != "N" && sp != "")
                {
                    OracleParameter[] paramArray = new OracleParameter[9];

                    paramArray[0] = Utilities.GetOraParam(":p_org_id",objDo.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    //paramArray[1] = Utilities.GetOraParam(":p_unit_id",objDo.UnitID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_order_no",objDo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_delivery_seq",null, OracleDbType.Int32, ParameterDirection.InputOutput);
                    paramArray[3] = Utilities.GetOraParam(":p_delivery_person",objDo.DeliveryPerson, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_delivery_date",objDo.DeliveryDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_rcvd_by",objDo.ReceiverID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_rcvd_date",objDo.ReceivedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":p_invoice_no",objDo.InvoiceNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":p_entry_by",objDo.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                    objDo.DeliverySeq = int.Parse(paramArray[2].Value.ToString());

                }

                if (countDoDetail > 0)
                {
                    DLLInvDeliveryOrderDetail.SaveUpdateDeliveryOrderDetail(objDo, Tran);
                }

               
                Tran.Commit();

                return true;
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

    }
}
