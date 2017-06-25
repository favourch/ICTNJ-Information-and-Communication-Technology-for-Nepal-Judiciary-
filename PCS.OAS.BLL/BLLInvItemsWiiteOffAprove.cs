using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
namespace PCS.OAS.BLL
{
    public class BLLInvItemsWiiteOffAprove
    {
        public static List<ATTInvItemsWriteOff> GetWriteOffDateDetails(int orgid, string WriteOffDate, string AppYesNo)
        {
            List<ATTInvItemsWriteOff> lstitems = new List<ATTInvItemsWriteOff>();
            try
            {
                foreach (DataRow row in DLLInvItemsWiiteOffAprove.GetWriteOffDateDetails(orgid, WriteOffDate, AppYesNo).Rows)
                {
                    ATTInvItemsWriteOff objitems = new ATTInvItemsWriteOff();

                    objitems.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objitems.WriteOffSEQ = int.Parse(row["WRITEOFF_SEQ"].ToString());
                    objitems.WriteoffDate = row["WRITEOFF_DATE"].ToString();
                    //objitems.App_By = int.Parse(row["APP_BY"].ToString());
                    objitems.AppDate = row["APP_DATE"].ToString();
                    objitems.AppYesNo = row["APP_YES_NO"].ToString();
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
