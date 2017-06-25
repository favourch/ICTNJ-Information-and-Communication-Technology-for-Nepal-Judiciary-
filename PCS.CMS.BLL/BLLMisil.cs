using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLMisil
    {
       public static bool SaveMisil(ATTMisil att)
       {
           try
           {

               return DLLMisil.SaveMisil(att);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static bool EditMisil(ATTMisil att)
       {
           try
           {

               return DLLMisil.EditMisil(att);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public static List<ATTMisil> GetMisilForProcessing(ATTMisil searchCriteria )
       {
           try
           {
               

               List<ATTMisil> lstMisil = new List<ATTMisil>();
               foreach (DataRow dr in DLLMisil.GetMisilForProcessing(searchCriteria).Rows)
               {
                   ATTMisil obj = new ATTMisil();

                   obj.CaseID = double.Parse(dr["CASE_ID"].ToString());
                   obj.ReqDate = dr["REQ_DATE"].ToString();
                   obj.ReqOrg =int.Parse( dr["REQ_ORG"].ToString());
                   obj.DocTypeID = int.Parse(dr["DOCUMENT_TYPE_ID"].ToString());
                   obj.DocTYpeName = dr["DOCUMENT_TYPE_NAME"].ToString();

                   obj.ReqChalaniNo = dr["REQ_CHALAANI_NO"].ToString();
                   obj.ReqRecDate = dr["REQ_RCVD_DATE"].ToString();
                   obj.ReqRecDartaNo = dr["REQ_RCVD_DARTAA_NO"].ToString();
                   obj.ReqRecPID = double.Parse((dr["REQ_RCVD_P_ID"].ToString() == "" ? "0" : dr["REQ_RCVD_P_ID"].ToString()));
                   obj.ReqReplyDate = dr["REQ_REPLY_DATE"].ToString();
                   obj.ReqReplyChalaniNo = dr["REQ_REPLY_CHALAANI_NO"].ToString();
                  
                   obj.RecDate = dr["RCVD_DATE"].ToString();
              
                   obj.RecDartaNo = dr["RCVD_DARTAA_NO"].ToString();
                   obj.RecPID = double.Parse((dr["RCVD_P_ID"].ToString() == "" ? "0" : dr["RCVD_P_ID"].ToString()));
                   obj.OrgName = dr["ORG_NAME"].ToString();

                   obj.IsReturn = dr["IS_RETURN"].ToString();
                   obj.ReturnDate = dr["RETURN_DATE"].ToString();
                   obj.Remarks = dr["REMARKS"].ToString();
                   obj.CaseNo = dr["CASE_NUMBER"].ToString();
                   obj.RegNo = dr["REG_NUMBER"].ToString();
                   obj.CaseTypeName = dr["CASE_TYPE_NAME"].ToString();
                   //obj.CaseName = dr["CASE_NAME"].ToString();
                   obj.Appelant = dr["APPELLANT"].ToString();
                   obj.Respondant = dr["RESPONDENT"].ToString();



                   lstMisil.Add(obj);
               }
               return lstMisil;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
