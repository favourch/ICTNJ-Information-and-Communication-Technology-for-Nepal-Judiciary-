using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
   public  class BLLManonayan
    {
       public static List<ATTManonayan> GetManonayan(double EmpID)
       {
           List<ATTManonayan> lstManonayan = new List<ATTManonayan>();
           ATTManonayan att;
           try
           {
               foreach (DataRow row in DLLManonayan.GetManonayan(EmpID).Rows)
               {
                   att = new ATTManonayan();
                   att.EmpID = double.Parse(row["EMP_ID"].ToString());
                   att.ManonayanDate = row["MANONAYAN_DATE"].ToString();
                   att.ManonayanPurpose = row["PURPOSE"].ToString();
                   att.ManonayanDescription = row["DESCRIPTION"].ToString();
                   att.ManonayanFromDate = row["FROM_DATE"].ToString();
                   att.ManonayanToDate = row["TO_DATE"].ToString();
                   if (row["APP_BY"].ToString() != "")
                       att.ManonayanApprovedBY = double.Parse(row["APP_BY"].ToString());
                   att.ManonayanApprovedDate = row["APP_DATE"].ToString();
                   att.ManonayanApprovedYesNo = row["APP_YES_NO"].ToString();
                   att.Action = "";
                   lstManonayan.Add(att);
               }
               return lstManonayan;
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
    }
}
