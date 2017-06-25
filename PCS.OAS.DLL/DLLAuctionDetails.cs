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
    public class DLLAuctionDetails
    {
        /// <summary>
        /// Add Auction Details object to database
        /// </summary>
        /// <param name="obj">ATTAuctionDetails object</param>
        /// <returns>return bool</returns>
        public static bool SaveAuctionDetails(OracleTransaction Tran,int AuctiionSeq,List<ATTAuctionDetails> lstItemsDetails)
        {
            if (lstItemsDetails.Count > 0)
            {
                string Sp = "";
                List<OracleParameter> paramArray = new List<OracleParameter>();

                try
                {
                    foreach (ATTAuctionDetails obj in lstItemsDetails)
                    {
                        if (obj.Action == "A")
                        {
                            Sp = "SP_INV_ADD_ITEMS_AUCTION_DT";
                        }
                        else if (obj.Action == "E")
                        {
                            Sp = "SP_INV_EDIT_ITEMS_AUCTION_DT";
                        }

                        paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_AUCTION_SEQ", AuctiionSeq, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_SUB_CATEGORY_ID", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ITEMS_ID", obj.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_SEQ_NO", obj.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_AUCTION_AMOUNT", obj.AuctionAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_AUCTION_WINNER", obj.AuctionWinner, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_REMARKS", obj.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, Sp, paramArray.ToArray());

                        paramArray.Clear();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return true;
            }
        }

        public static DataTable GetAuctionDetailsDT(string AuctionDate)
        {
            try
            {
            //    APP_YES_NO!='Y'"
                string strSelect = "";
                strSelect = "SELECT * FROM VW_INV_ORG_ITEMS_AUCTION WHERE 1=1";
                List<OracleParameter> ParamList = new List<OracleParameter>();

                if (AuctionDate !=null)
                {
                    strSelect += " AND AUCTION_DATE = :auctionDate";
                    ParamList.Add(Utilities.GetOraParam(":auctionDate", AuctionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                strSelect += " AND APP_YES_NO is null";

                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.OAS);

                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.Text, strSelect, ParamList.ToArray());
                return (DataTable)ds.Tables[0];
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
