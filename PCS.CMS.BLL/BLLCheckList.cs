using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCheckList
    {
        public static bool SaveCheckList(ATTCheckList objCheckList)
        {
            try
            {
                return DLLCheckList.SaveCheckList(objCheckList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTCheckList> GetCheckList(int? checkListID, string active,int defaultFlag)
        {
            List<ATTCheckList> CheckList = new List<ATTCheckList>();
            try
            {
                foreach (DataRow row in DLLCheckList.GetCheckList(checkListID, active).Rows)
                {
                    ATTCheckList chklst = new ATTCheckList(
                        int.Parse(row["CHECK_LIST_ID"].ToString()),
                        row["CHECK_LIST_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    chklst.CheckListType = row["CHECK_LIST_TYPE"].ToString();
                    CheckList.Add(chklst);
                }

                if (defaultFlag > 0)
                    CheckList.Insert(0, new ATTCheckList(0, "छान्नुहोस", ""));
                return CheckList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
