using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
   public class BLLJudgeWorkList
    {
       public static List<ATTJudgeWorkList> GetJudgeWorkList(int? JwcId)
        {
            
            List<ATTJudgeWorkList> LstWork = new List<ATTJudgeWorkList>();

            try
            {
                foreach (DataRow row in DLLJudgeWorkList.GetJudgeWorkList(JwcId).Rows)
                {
                    ATTJudgeWorkList ObjAtt = new ATTJudgeWorkList
                        (
                        int.Parse(row["JWC_ID"].ToString()),
                        row["JWC_NAME"].ToString(),
                        (row["ACTIVE"].ToString() == "Y") ? true : false,
                        ""//row["ENTRY_BY"].ToString()
                        );
                    ObjAtt.EntryOn = DateTime.Now;
                    //ObjAtt.EntryOn = DateTime.Parse(row["ENTRY_ON"].ToString());

                    LstWork.Add(ObjAtt);
                }
                return LstWork;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       public static bool SaveJudgeWorkList(ATTJudgeWorkList ObjAtt)
        {
            try
            {
                return DLLJudgeWorkList.SaveWork(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       public static List<ATTJudgeWorkList> GetCurrentJudgesList(int orgID)
       {
           try
           {
               List<ATTJudgeWorkList> JudgesList = new List<ATTJudgeWorkList>();
               foreach (DataRow row in DLLJudgeWorkList.GetCurrentJudgesList(orgID).Rows)
               {
                   ATTJudgeWorkList JudgesName = new ATTJudgeWorkList(double.Parse(row["EMP_ID"].ToString()), (string)row["EMPNAME"]);
                   JudgesList.Add(JudgesName);
               }
               return JudgesList;
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
    }
}
