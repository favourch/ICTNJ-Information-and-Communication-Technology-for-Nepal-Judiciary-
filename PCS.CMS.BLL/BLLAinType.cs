using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLAinType
    {
        public static bool SaveAinType(ATTAinType objAinType)
        {
            try
            {
                return DLLAinType.SaveAinType(objAinType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTAinType> GetAinType(int? ainType, string active, int defaultFlag)
        {
            List<ATTAinType> AinTypeList = new List<ATTAinType>();
            try
            {
                foreach (DataRow row in DLLAinType.GetAinType(ainType, active).Rows)
                {
                    ATTAinType Reglst = new ATTAinType(
                        int.Parse(row["AIN_TYPE_ID"].ToString()),
                        row["AIN_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    AinTypeList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    AinTypeList.Insert(0, new ATTAinType(0, "छान्नुहोस", ""));
                return AinTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
