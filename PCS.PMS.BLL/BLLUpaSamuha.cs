using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLUpaSamuha
    {
        public static List<ATTUpaSamuha> GetUpaSamuhaList(int? sewaID, int? samuhaID, int? upaSamuhaID)
        {
            List<ATTUpaSamuha> lstUpaSamuha = new List<ATTUpaSamuha>();

            try
            {
                foreach (DataRow row in DLLUpaSamuha.GetUpaSamuhaTable(sewaID,samuhaID,upaSamuhaID).Rows)
                {
                    ATTUpaSamuha obj = new ATTUpaSamuha();

                    obj.SewaID = int.Parse(row["sewa_id"].ToString());
                    obj.SamuhaID = int.Parse(row["samuha_id"].ToString());
                    obj.UpaSamuhaID = int.Parse(row["upa_samuha_id"].ToString());
                    obj.UpaSamuhaName = row["upa_samuha_name"].ToString();
                    obj.EntryBy = row["entry_by"].ToString();
                    obj.EntryOn = DateTime.Parse(row["entry_on"].ToString());
                    obj.Action = "M";

                    lstUpaSamuha.Add(obj);
                }

                return lstUpaSamuha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
