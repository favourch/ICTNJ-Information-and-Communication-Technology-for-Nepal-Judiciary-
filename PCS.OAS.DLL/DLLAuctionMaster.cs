using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
namespace PCS.OAS.DLL
{
    public class DLLAuctionMaster
    {
        public static bool SaveAuctionMaster(ATTAuctionMaster objItemsMaster)
        {
            GetConnection getConn = new GetConnection();
            OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            string SP = "";           
            if (objItemsMaster.Action == "A")
            {
                SP = "SP_INV_ADD_ITEMS_AUCTION";
            }
            if (objItemsMaster.Action == "E")
            {
                SP = "SP_INV_EDIT_ITEMS_AUCTION";
            }
            if (objItemsMaster.Action == "App")
            {
                SP = "SP_INV_APP_ITEMS_AUCTION";
            }
            try
            {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objItemsMaster.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_AUCTION_SEQ", objItemsMaster.AuctionSeq, OracleDbType.Int32, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_AUCTION_DATE", objItemsMaster.AuctionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_APP_BY", objItemsMaster.App_By, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_APP_DATE", objItemsMaster.App_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_APP_YES_NO", objItemsMaster.App_Yes_No, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objItemsMaster.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                    objItemsMaster.AuctionSeq = int.Parse(paramArray[1].Value.ToString());

                    DLLAuctionDetails.SaveAuctionDetails(Tran, objItemsMaster.AuctionSeq, objItemsMaster.LstAuctionDetails);
                    paramArray.Clear();

                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
