using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCauseList
    {
        public static bool SaveCauseList(ATTCauseList objCauseList)
        {
            try
            {
                return DLLCauseList.SaveCauseList(objCauseList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTCauseList> GetCauseList(int? CauseListID, string active, int defaultFlag)
        {
            List<ATTCauseList> CauseList = new List<ATTCauseList>();
            try
            {
                foreach (DataRow row in DLLCauseList.GetCauseList(CauseListID, active).Rows)
                {
                    ATTCauseList cslst = new ATTCauseList(
                        int.Parse(row["CL_ENTRY_TYPE_ID"].ToString()),
                        row["CL_ENTRY_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    CauseList.Add(cslst);
                }

                if (defaultFlag > 0)
                    CauseList.Insert(0, new ATTCauseList(0, "छान्नुहोस", ""));
                return CauseList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
