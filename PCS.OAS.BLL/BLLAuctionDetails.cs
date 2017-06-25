using System;
using System.Collections.Generic;
using System.Text;

using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLAuctionDetails
    {
        public static List<ATTAuctionDetails> GetAuctionDetailsDT(string AuctionDate)
        {
            try
            {
                List<ATTAuctionDetails> LSTItemsKNJ = new List<ATTAuctionDetails>();
                foreach (DataRow row in DLLAuctionDetails.GetAuctionDetailsDT(AuctionDate).Rows)
                {
                    ATTAuctionDetails obj = new ATTAuctionDetails();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.AuctionSequence = int.Parse(row["AUCTION_SEQ"].ToString());
                    obj.AuctionDate = row["AUCTION_DATE"].ToString();
                    if (obj.AppBy != 0)
                    {
                        obj.AppBy = int.Parse(row["APP_BY"].ToString());
                    }
                    obj.FirstName = row["APP_PERSON"].ToString();
                    //obj.MiddleName = row["MID_NAME"].ToString();
                    //obj.LastName = row["SUR_NAME"].ToString();
                    obj.AppDate = row["APP_DATE"].ToString();
                    obj.AppYesNo = row["APP_YES_NO"].ToString();
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());                   
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.JI_KHA_PA_NO = row["JI_KHA_PA_NO"].ToString();
                    obj.UnitPrice = int.Parse(row["UNIT_PRICE"].ToString());
                    obj.AuctionAmount = row["AUCTION_AMOUNT"].ToString();
                    obj.AuctionWinner = row["AUCTION_WINNER"].ToString();
                    obj.ItemsStatus = row["ITEMS_STATUS"].ToString();
                    obj.Remarks = row["REMARKS"].ToString();
                    LSTItemsKNJ.Add(obj);
                }
                return LSTItemsKNJ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
