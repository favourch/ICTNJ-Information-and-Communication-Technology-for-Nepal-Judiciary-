
using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public  class BLLTameli
    {
        
        public static bool AddEditDeleteTameli(List<ATTTameli> TameliLIST)
        {
            try
            {
                return DLLTameli.AddEditDeleteTameli(TameliLIST);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        public static bool ProcessTameli(ATTTameli tameli)
        {
            try
            {
                return DLLTameli.ProcessTameli(tameli);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool SaveTamelildaarFeedBack(ATTTameli tameli)
        {
            try
            {
                return DLLTameli.SaveTamelildaarFeedBack(tameli);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool AssignTamildaar(ATTTameli tameli)
        {
            try
            {
                return DLLTameli.AssignTamildaar(tameli);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
