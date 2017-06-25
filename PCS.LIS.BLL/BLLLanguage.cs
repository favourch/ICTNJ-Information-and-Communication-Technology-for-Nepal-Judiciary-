using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.LIS.DLL;
using PCS.FRAMEWORK;

namespace PCS.LIS.BLL
{
    public class BLLLanguage
    {
        public static bool SaveLanguage(ATTLookupLanguage obj,Previlege pobj)
        {
            try
            {
                return PCS.LIS.DLL.DLLLookupLanguage.AddLanguage(obj,pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTLookupLanguage> GetLanguageList()
        {
            List<ATTLookupLanguage> LanguageTypeLST = new List<ATTLookupLanguage>();

            foreach (DataRow row in DLLLookupLanguage.GetLanguage().Rows)
            {
                ATTLookupLanguage LL = new ATTLookupLanguage(int.Parse(row["LANG_ID"].ToString()),
                                                            row["LANG_NAME"].ToString()
                                                            );
                LanguageTypeLST.Add(LL);
            }
            return LanguageTypeLST;
        }

        public static bool UpdateLanguageType(ATTLookupLanguage objLT,Previlege pobj)
        {
            try
            {
                DLLLookupLanguage.UpdateLanguageType(objLT,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteLanguage(ATTLookupLanguage objLT)
        {
            try
            {
                //if (Previlege.HasPrevilege(username, Previlege.PrevilegeType.P_DELETE, menuname) == false)
                //    throw new ArgumentException(Utilities.PreviledgeMsg + " delete Language.");

                DLLLookupLanguage.DeleteLanguage(objLT);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTLanguage> GetLanguage()
        {
            List<ATTLanguage> LanguageLst = new List<ATTLanguage>();

            foreach (DataRow row in DLLLookupLanguage.GetLanguage().Rows)
            {
                ATTLanguage objLanguage = new ATTLanguage(int.Parse(row["lang_id"].ToString()),
                                                            row["lang_name"].ToString()
                                                  );
                LanguageLst.Add(objLanguage);
            }

            return LanguageLst;

        }

    }

   
}
