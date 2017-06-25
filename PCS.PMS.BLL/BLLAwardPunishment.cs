using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLAwardPunishment
    {
        public static bool SaveAward(List<ATTAwardPunishment> LSTAward)
        {
            try
            {
                return DLLAwardPunishment.SaveAward(LSTAward);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SavePunishment(List<ATTAwardPunishment> LSTPunishment)
        {
            try
            {
                return DLLAwardPunishment.SavePunishment(LSTPunishment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTAwardPunishment> GetAwards(double empid)
        {
            List<ATTAwardPunishment> LSTAward = new List<ATTAwardPunishment>();
            try
            {
                foreach (DataRow var in DLLAwardPunishment.GetAwards(empid).Rows)
                {
                    ATTAwardPunishment objAwards = new ATTAwardPunishment();
                    objAwards.EmpID = int.Parse(var["emp_id"].ToString());
                    //objAwards.EmpName = var[""].ToString();
                    objAwards.SequenceNo = int.Parse(var["seq_no"].ToString());
                    objAwards.Award = var["award"].ToString();
                    objAwards.AwardDate = var["award_date"].ToString();
                    objAwards.VerifiedBy = var["verified_by"].ToString();
                    objAwards.VerifiedDate = var["verified_date"].ToString();
                    objAwards.Remarks = var["remarks"].ToString();
                    objAwards.Action = "";
                    LSTAward.Add(objAwards);
                }
                return LSTAward;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static List<ATTAwardPunishment> GetPunishments(double empid)
        {
            List<ATTAwardPunishment> LSTPunishments = new List<ATTAwardPunishment>();
            try
            {
                foreach (DataRow var in DLLAwardPunishment.GetPunishments(empid).Rows)
                {
                    ATTAwardPunishment objPunishments = new ATTAwardPunishment();
                    objPunishments.EmpID = int.Parse(var["emp_id"].ToString());
                    objPunishments.SequenceNo = int.Parse(var["seq_no"].ToString());
                    objPunishments.Punishment = var["punishment"].ToString();
                    objPunishments.PunishmentDate = var["punishment_date"].ToString();
                    objPunishments.VerifiedBy = var["verified_by"].ToString();
                    objPunishments.VerifiedDate = var["verified_date"].ToString();
                    objPunishments.PunishmentRemarks = var["remarks"].ToString();
                    objPunishments.Action = "";
                    LSTPunishments.Add(objPunishments);
                }
                return LSTPunishments;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
