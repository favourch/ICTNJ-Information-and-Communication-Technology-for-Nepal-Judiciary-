using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLKeyword
    {
        public static ObjectValidation Validate(ATTKeyword obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.KeywordName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Keyword name cannot be empty.";
                return OV;
            }

            return OV;
        }

        public static List<ATTKeyword> GetKeywordList(int? keywordID)
        {
            List<ATTKeyword> lstKeyword = new List<ATTKeyword>();

            try
            {
                foreach (DataRow row in DLLKeyword.GetKeywordTable(keywordID).Rows)
                {
                    ATTKeyword obj = new ATTKeyword
                                                    (
                                                        int.Parse(row["Keyword_ID"].ToString()),
                                                        row["Keyword_Name"].ToString()
                                                    );

                    lstKeyword.Add(obj);

                }
                return lstKeyword;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddKeyword(ATTKeyword obj, Previlege pobj)
        {
            try
            {
               return DLLKeyword.AddKeyword(obj,pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EditKeyword(ATTKeyword obj, Previlege pobj)
        {
            try
            {
                return DLLKeyword.EditKeyword(obj,pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
