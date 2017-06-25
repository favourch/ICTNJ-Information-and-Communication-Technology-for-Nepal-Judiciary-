using System;
using System.Collections.Generic;
using System.Text;

using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLAuctionApprove
    {
        public static List<ATTAuctionMaster> GetAuctionDateDetails(int orgid,string AuctionDate,string AppYesNo)
        {
            List<ATTAuctionMaster> lstitems = new List<ATTAuctionMaster>();
            try
            {
                foreach (DataRow row in DLLAuctionApprove.GetAuctionDateDetails(orgid,AuctionDate,AppYesNo).Rows)
                {
                    ATTAuctionMaster objitems = new ATTAuctionMaster();

                    objitems.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objitems.AuctionSeq = int.Parse(row["AUCTION_SEQ"].ToString());
                    objitems.AuctionDate = row["AUCTION_DATE"].ToString();
                    //objitems.App_By = int.Parse(row["APP_BY"].ToString());
                    objitems.App_Date = row["APP_DATE"].ToString();
                    objitems.App_Yes_No = row["APP_YES_NO"].ToString();
                    lstitems.Add(objitems);
                }
                return lstitems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
