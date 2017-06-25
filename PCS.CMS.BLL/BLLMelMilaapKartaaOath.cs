using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COMMON.ATT;


namespace PCS.CMS.BLL
{
    public class BLLMelMilaapKartaaOath
    {
        public static List<ATTMelMilapKartaOath> GetMelMilaapKartaaOath(int OrgID,double mmkID)
        {
            List<ATTMelMilapKartaOath> LstMelMilaapKartaaOath = new List<ATTMelMilapKartaOath>();
            try
            {
                foreach (DataRow row in DLLMelMilapKartaOath.GetMelMilaapKartaaOath(OrgID,mmkID).Rows)
                {
                    ATTMelMilapKartaOath attMMK = new ATTMelMilapKartaOath();
                    attMMK.OrgID = int.Parse(row["ORG_ID"].ToString());
                    attMMK.PersonID = double.Parse(row["PERSON_ID"].ToString());                    
                    attMMK.FromDate = row["FROM_DATE"].ToString();
                    attMMK.JudgeID = double.Parse(row["JUDGE_ID"].ToString());
                    attMMK.OldJudgeID = attMMK.JudgeID;
                    attMMK.JudgeName = row["JUDGENAME"].ToString();
                    LstMelMilaapKartaaOath.Add(attMMK);
                }
                return LstMelMilaapKartaaOath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
