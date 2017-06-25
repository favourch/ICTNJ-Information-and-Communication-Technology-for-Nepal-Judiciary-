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
    public class DLLInvReturnOrder
    {
        public static bool SaveUpdateReturnOrder(ATTInvReturnOrder objRo)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                string sp = "";
                int countRoDetail = objRo.LstReturnOrderDetail.Count;

                if (objRo.Action == "A")
                    sp = "sp_inv_add_return_order";
                else if (objRo.Action == "E")
                    sp = "sp_inv_edit_return_order";

                 if (objRo.Action != "N" && sp != "")
                 {
                     OracleParameter[] paramArray = new OracleParameter[7];

                     paramArray[0] = Utilities.GetOraParam(":p_org_id", objRo.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    // paramArray[1] = Utilities.GetOraParam(":p_unit_id", objRo.UnitID, OracleDbType.Int64, ParameterDirection.Input);
                     paramArray[1] = Utilities.GetOraParam(":p_order_no", objRo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input);
                     paramArray[2] = Utilities.GetOraParam(":p_delivery_seq", objRo.DeliverySeq, OracleDbType.Int32, ParameterDirection.Input);
                     paramArray[3] = Utilities.GetOraParam(":p_return_seq", objRo.ReturnSeq, OracleDbType.Int32, ParameterDirection.InputOutput);
                     paramArray[4] = Utilities.GetOraParam(":p_return_date", objRo.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input);
                     paramArray[5] = Utilities.GetOraParam(":p_return_remarks", objRo.ReturnRemarks, OracleDbType.Varchar2, ParameterDirection.Input);
                     paramArray[6] = Utilities.GetOraParam(":p_entry_by", objRo.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                     SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                     objRo.ReturnSeq = int.Parse(paramArray[3].Value.ToString());

                 }


                if (countRoDetail > 0)
                {
                    DLLInvReturnOrderDetail.SaveUpdateReturnOrderDetail(objRo, Tran);
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
