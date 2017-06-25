using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.DLL
{
    public class DLLAuctionApprove
    {
        public static DataTable GetAuctionDateDetails(int orgid, string AuctionDate, string AppYesNo)
        {
            string SelectSQL = "SP_INV_GET_ITEMS_AUCTION";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgid, OracleDbType.Int32, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_AUCTION_DATE", AuctionDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_APP_YES_NO", AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
