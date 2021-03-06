using System;
using System.Collections.Generic;
using System.Text;


using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLDecisionType
    {
        public static bool SaveDecisionType(ATTDecisionType objDecType)
        {
            try
            {
                return DLLDecisionType.SaveDecisionType(objDecType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTDecisionType> GetDecisionType(int? DecType, string active, int defaultFlag)
        {
            List<ATTDecisionType> DecTypeList = new List<ATTDecisionType>();
            try
            {
                foreach (DataRow row in DLLDecisionType.GetDecisionType(DecType, active).Rows)
                {
                    ATTDecisionType objDec = new ATTDecisionType(
                        int.Parse(row["DECISION_TYPE_ID"].ToString()),
                        row["DECISION_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    DecTypeList.Add(objDec);

                }

                if (defaultFlag > 0)
                    DecTypeList.Insert(0, new ATTDecisionType(0, "छान्नुहोस", ""));
                return DecTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
