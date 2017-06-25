using System;
using System.Collections.Generic;
using System.Text;


using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLCaseAccountForward
    {
       public static bool SaveCaseAccountForward(ATTCaseAccountForward attCAF)
       {
           try
           {
               return DLLCaseAccountForward.SaveCaseAccountForward(attCAF);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static List<ATTCaseAccountForward> GetCaseAccountForward(double caseID, int ? accountTypeID, string paid)
       {
           List<ATTCaseAccountForward> CAFList = new List<ATTCaseAccountForward>();

           try
           {
               foreach (DataRow row in DLLCaseAccountForward.GetCaseAccountForward(caseID,accountTypeID,paid).Rows)
               {
                   ATTCaseAccountForward att = new ATTCaseAccountForward
                       (
                           int.Parse(row["CASE_ID"].ToString()),
                           int.Parse(row["ACCOUNT_TYPE_ID"].ToString()),
                           int.Parse(row["TOT_AMOUNT"].ToString()),
                           row["PAID"].ToString()
                       );
                   att.AccountTypeName = row["ACCOUNT_TYPE_NAME"].ToString();
                   CAFList.Add(att);
               }
               return CAFList;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static List<ATTCaseAccountForward> GetUnPaidAmount(int courtID,string paid)
       {
           List<ATTCaseAccountForward> CAFList = new List<ATTCaseAccountForward>();

           try
           {
               foreach (DataRow row in DLLCaseAccountForward.GetUnPaidAmount(courtID,paid).Rows)
               {
                   ATTCaseAccountForward att = new ATTCaseAccountForward
                       (
                           int.Parse(row["CASE_ID"].ToString()),
                           int.Parse(row["ACCOUNT_TYPE_ID"].ToString()),
                           int.Parse(row["TOT_AMOUNT"].ToString()),
                           row["PAID"].ToString()
                       );
                   att.AccountTypeName = row["ACCOUNT_TYPE_NAME"].ToString();
                   att.Appellants = row["APPELLANTLIST"].ToString();
                   att.Respondents = row["RESPONDENTLIST"].ToString();
                   att.CaseName = row["CASETYPENAME"].ToString();
                   CAFList.Add(att);
               }
               return CAFList;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
