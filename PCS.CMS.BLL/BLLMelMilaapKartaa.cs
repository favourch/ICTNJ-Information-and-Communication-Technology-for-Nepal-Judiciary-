using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COMMON.ATT;


namespace PCS.CMS.BLL
{
   public class BLLMelMilaapKartaa
    {
       public static bool SaveMelMilaapKarta(List<ATTMelMilaapKartaa> MMKLst,List<ATTPerson> PersonList)
       {
           try
           {
               return DLLMelMilaapKartaa.SaveMelMilaapKartaa(MMKLst, PersonList);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static List<ATTMelMilaapKartaa> GetMelMilaapKartaa(int OrgID)
       {
           List<ATTMelMilaapKartaa> LstMelMilaapKartaa = new List<ATTMelMilaapKartaa>();
           try
           {
               foreach (DataRow row in DLLMelMilaapKartaa.GetMelMilaapKartaa(OrgID).Rows)
               {
                   ATTMelMilaapKartaa attMMK = new ATTMelMilaapKartaa();
                   attMMK.OrgID = int.Parse(row["ORG_ID"].ToString());
                   attMMK.PID = double.Parse(row["PERSON_ID"].ToString());
                   attMMK.FullName = row["FULLNAME"].ToString();
                   attMMK.FromDate=row["FROM_DATE"].ToString();
                   attMMK.Post=row["POST"].ToString();
                   attMMK.Experience=row["EXPERIENCE"].ToString();
                   attMMK.OathLst = BLLMelMilaapKartaaOath.GetMelMilaapKartaaOath(attMMK.OrgID, attMMK.PID);
                   foreach (ATTMelMilapKartaOath oath in attMMK.OathLst)
                   {
                       attMMK.OathJudges = attMMK.OathJudges + (attMMK.OathJudges == null ? "" : ",") + oath.JudgeName;
                   }
                   attMMK.Action = "";
                   LstMelMilaapKartaa.Add(attMMK);
               }
               return LstMelMilaapKartaa;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}

