using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLRegistrationType
    {
        public static bool SaveRegistrationType(ATTRegistrationType objRegTypet)
        {
            try
            {
                return DLLRegistrationType.SaveRegistrationType(objRegTypet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static List<ATTRegistrationType> GetRegistrationType(int? regType, string active, int defaultFlag)
       {
           List<ATTRegistrationType> RegTypeList = new List<ATTRegistrationType>();
           try
           {
               foreach (DataRow row in DLLRegistrationType.GetRegistrationType(regType, active).Rows)
               {
                   ATTRegistrationType Reglst = new ATTRegistrationType(
                       int.Parse(row["REG_TYPE_ID"].ToString()),
                       row["REG_TYPE_NAME"].ToString(),
                       row["ACTIVE"].ToString());
                   RegTypeList.Add(Reglst);
               }

               if (defaultFlag > 0)
                   RegTypeList.Insert(0, new ATTRegistrationType(0, "छान्नुहोस", ""));
               return RegTypeList;

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
