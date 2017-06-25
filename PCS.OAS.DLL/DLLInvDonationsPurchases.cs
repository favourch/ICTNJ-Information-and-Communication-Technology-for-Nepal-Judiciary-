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

namespace PCS.OAS.DLL
{
    public class DLLInvDonationsPurchases 
    {
        public static bool saveDonationPurchases(ATTInvDonationsPurchases obj)
        {            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":p_org_id ", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_date ", obj.DonationPurchaseDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_seq", obj.DonationPurchaseSeq, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_type", obj.DonationPurchaseType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_org", obj.DonationPurchaseOrg, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_qty ", obj.DonationPurchaseQty, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_don_pur_unit_price", obj.DonationPurchaseUnitPrice, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_rcvd_by", obj.ReceivedBy, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_rcvd_date", obj.ReceivedDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_entry_by ", obj.EntrBy, OracleDbType.Varchar2, ParameterDirection.Input));
            
            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
                if (obj.Action == "A") //New Add
                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_add_don_purchases", paramArray.ToArray());
                else if (obj.Action == "E") //Update
                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_edit_don_purchases", paramArray.ToArray());
                obj.DonationPurchaseSeq = int.Parse(paramArray[5].Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
