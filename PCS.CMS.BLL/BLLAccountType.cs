using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLAccountType
    {
        public static bool SaveAccountType(ATTAccountType objAccountType)
        {
            try
            {
                return DLLAccountType.SaveAccountType(objAccountType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTAccountType> GetAccountType(int? AccountType, string active, int defaultFlag)
        {
            List<ATTAccountType> AccountTypeList = new List<ATTAccountType>();
            try
            {
                foreach (DataRow row in DLLAccountType.GetAccountType(AccountType, active).Rows)
                {
                    ATTAccountType Reglst = new ATTAccountType(
                        int.Parse(row["ACCOUNT_TYPE_ID"].ToString()),
                        row["ACCOUNT_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    AccountTypeList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    AccountTypeList.Insert(0, new ATTAccountType(0, "छान्नुहोस", ""));
                return AccountTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
