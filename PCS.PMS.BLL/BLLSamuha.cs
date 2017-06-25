using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLSamuha
    {
        public static List<ATTSamuha> GetSamuhaList(int? sewaID, int? samuhaID)
        {
            List<ATTSamuha> lstSamuha = new List<ATTSamuha>();

            try
            {
                List<ATTUpaSamuha> lstUpaSamuha = BLLUpaSamuha.GetUpaSamuhaList(null, null, null);

                foreach (DataRow row in DLLSamuha.GetSamuhaTable(sewaID,samuhaID).Rows)
                {
                    ATTSamuha samuha = new ATTSamuha();

                    samuha.SewaID = int.Parse(row["sewa_id"].ToString());
                    samuha.SamuhaID = int.Parse(row["samuha_id"].ToString());
                    samuha.SamuhaName = row["samuha_name"].ToString();
                    samuha.EntryBy = row["entry_by"].ToString();
                    samuha.EntryOn = DateTime.Parse(row["entry_on"].ToString());
                    samuha.Action = "M";

                    samuha.LstUpaSamuha = lstUpaSamuha.FindAll
                                                        (
                                                            delegate(ATTUpaSamuha ups)
                                                            {
                                                                return ups.SewaID == samuha.SewaID &&
                                                                    ups.SamuhaID == samuha.SamuhaID;
                                                            }
                                                        );

                    lstSamuha.Add(samuha);
                }
                return lstSamuha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
