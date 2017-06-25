using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLSewa
    {
        public static List<ATTSewa> GetSewaList(int? sewaID)
        {
            List<ATTSewa> lstSewa = new List<ATTSewa>();
            
            try
            {
                List<ATTSamuha> lstSamuha = BLLSamuha.GetSamuhaList(null, null);
                foreach (DataRow row in DLLSewa.GetSewaTable(sewaID).Rows)
                {
                    ATTSewa sewa = new ATTSewa();
                    
                    sewa.SewaID = int.Parse(row["sewa_id"].ToString());
                    sewa.SewaName = row["sewa_name"].ToString();
                    sewa.EntryBy = row["entry_by"].ToString();
                    sewa.EntryOn = DateTime.Parse(row["entry_on"].ToString());
                    sewa.Action = "M";

                    sewa.LstSamuha = lstSamuha.FindAll
                                                (
                                                    delegate(ATTSamuha smu)
                                                    {
                                                        return smu.SewaID == sewa.SewaID;
                                                    }
                                                );

                    lstSewa.Add(sewa);
                }
                return lstSewa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddSewa(ATTSewa sewa)
        {
            try
            {
                
                return DLLSewa.AddSewa(sewa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
