using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLTarekhCourtBato
    {
        public static bool SaveTarikhCourtBato(ATTTarekhCourtBato attTCB)
        {
            try
            {
                return DLLTarekhCourtBato.SaveTarekhCourtBato(attTCB);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTTarekhCourtBato> GetTarikhCourtBato(int courtID)
        {
            List<ATTTarekhCourtBato> lstTCB = new List<ATTTarekhCourtBato>();
            try
            {
                foreach (DataRow row in DLLTarekhCourtBato.GetTarekhCourtBato(courtID).Rows)
                {
                    ATTTarekhCourtBato TarekhCourtBato = new ATTTarekhCourtBato
                      (
                      int.Parse(row["COURT_ID"].ToString()),
                      (string)row["FROM_DATE"],
                      int.Parse(row["TOT_DAYS"].ToString()),
                      int.Parse(row["BATO_KO_MYAAD"].ToString())
                      );
                    lstTCB.Add(TarekhCourtBato);
                }
                return lstTCB;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
       
    }
}
