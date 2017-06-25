using System;
using System.Collections.Generic;
using System.Text;
//Using section
using System.Data;
using PCS.LIS.ATT;
using PCS.LIS.DLL;
using PCS.FRAMEWORK;

namespace PCS.LIS.BLL
{
    public class BLLPublisher
    {
        public static bool SavePublisher(ATTPublisher obj, Previlege pobj)
        {
            try
            {
                return PCS.LIS.DLL.DLLPublisher.AddPublisher(obj,pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTPublisher> GetPublisherList()
        {
            List<ATTPublisher> PublisherTypeLST = new List<ATTPublisher>();

            foreach (DataRow row in  DLLPublisher.GetPublisher().Rows)
            {
                ATTPublisher PL = new ATTPublisher(int.Parse(row["PUBLISHER_ID"].ToString()),
                                                            row["PUBLISHER_NAME"].ToString(),
                                                            row["PUBLISHER_ADDRESS"].ToString()
                                                  );
                PublisherTypeLST.Add(PL);
            }
            return PublisherTypeLST;
        }

        public static bool UpdatePublisherType(ATTPublisher objPT,Previlege pobj)
        {
            try
            {
                DLLPublisher.UpdatePublisherType(objPT,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Delete publisher
        public static bool DeletePublisher(ATTPublisher objPT)
        {
            try
            {
                //if(Previlege.HasPrevilege(

                DLLPublisher.DeletePublisher(objPT);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
