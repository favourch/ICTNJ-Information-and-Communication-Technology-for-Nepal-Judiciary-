using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
namespace PCS.CMS.BLL
{
    public class BLLPesiType
    {
        public static bool SavePesiType(ATTPesiType objPesiType)
        {
            try
            {
                return DLLPesiType.SavePesiType(objPesiType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTPesiType> GetPesiType(int? PesiTypeID, string active, int defaultFlag)
        {
            List<ATTPesiType> PesiTypeLST = new List<ATTPesiType>();
            try
            {
                foreach (DataRow row in DLLPesiType.GetPesiType(PesiTypeID, active).Rows)
                {
                    ATTPesiType objPesiType = new ATTPesiType();
                    objPesiType.PesiTypeID= int.Parse(row["PESI_TYPE_ID"].ToString());
                    objPesiType.PesiTypeName = row["PESI_TYPE_NAME"].ToString();
                    objPesiType.Active = row["ACTIVE"].ToString();
                    PesiTypeLST.Add(objPesiType);
                }

                if (defaultFlag > 0)
                {
                    ATTPesiType obj = new ATTPesiType();
                    obj.PesiTypeID= 0;
                    obj.PesiTypeName = "छान्नुहोस";
                    PesiTypeLST.Insert(0, obj);

                }
                return PesiTypeLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
