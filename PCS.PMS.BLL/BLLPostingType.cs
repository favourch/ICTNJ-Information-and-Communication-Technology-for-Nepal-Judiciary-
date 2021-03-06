using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLPostingType
    {
        public static ObjectValidation Validate(ATTPostingType ObjAtt)
        {
            ObjectValidation OV = new ObjectValidation();
            if (ObjAtt.PostingTypeName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "**र्कपया नियुक्तिको किसिम भर्नुहोस्";
                return OV;
            }
            return OV;
        }

        public static List<ATTPostingType> GetPostingType(int? PostingTypeId, string active)
        {
            List<ATTPostingType> lstPostingType = new List<ATTPostingType>();

            try
            {
                foreach (DataRow row in DLLPostingType.GetPostingType(PostingTypeId, active).Rows)
                {
                    ATTPostingType ObjAtt = new ATTPostingType
                        (
                        int.Parse(row["POSTING_TYPE_ID"].ToString()),
                        row["POSTING_TYPE_NAME"].ToString(),
                        (row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"]
                        );

                    lstPostingType.Add(ObjAtt);
                }
                return lstPostingType;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool SavePostingType(ATTPostingType ObjAtt)
        {
            try
            {
                return DLLPostingType.SavePostingType(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static bool DeletePostingType(int PostingTypeID)
        {
            try
            {
                return DLLPostingType.DeletePostingType(PostingTypeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
