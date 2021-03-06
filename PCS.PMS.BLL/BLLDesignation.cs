using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
   public class BLLDesignation
    {
        public static ObjectValidation Validate(ATTDesignation ObjAttDL)
        {
            ObjectValidation OV = new ObjectValidation();

            if (ObjAttDL.DesignationName== "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "कृपया पद राख्नुहोस.";
                return OV;
            }

            if (ObjAttDL.DesignationType == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "कृपया पदको किसिम छान्नुहोस.";
                return OV;
            }
            if (ObjAttDL.ServicePeriod == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "र्कपया सेवा अवधि भर्नुहोस्";
            }
            if (ObjAttDL.AgeLimit == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "र्कपया उमेर सिमा भर्नुहोस्";
            }

            return OV;
        }

       public static List<ATTDesignation> GetDesignation(int? DesgId, string desType)
        {
            List<ATTDesignation> LstDesg = new List<ATTDesignation>();

            try
            {
                foreach (DataRow row in DLLDesignation.GetDesignation(DesgId,desType).Rows)
                {
                    ATTDesignation ObjAtt = new ATTDesignation
                        (
                        int.Parse(row["DES_ID"].ToString()),
                        row["DES_NAME"].ToString(),
                        row["DES_TYPE"].ToString(),
                        int.Parse(row["SERVICE_PERIOD"].ToString()),
                        int.Parse(row["AGE_LIMIT"].ToString())
                        );
                    LstDesg.Add(ObjAtt);
                }
                return LstDesg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SaveDesignation(ATTDesignation ObjAtt)
        {
            try
            {
                return DLLDesignation.SaveDesignation(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static bool DeleteDesignation(int DesgID)
        {

            try
            {
                return DLLDesignation.DeleteDesignation(DesgID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
