using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;


namespace PCS.OAS.BLL
{
    public class BLLGeneralTippaniProcess
    {
        public static int GetTippaniNextStatus(int orgID, int tippaniID, int tipPrcID)
        {
            int status;
            try
            {
                DataTable tbl = DLLGeneralTippaniProcess.GetTippaniNextStatus(orgID, tippaniID, tipPrcID);
                if (tbl.Rows.Count == 0)
                {
                    status = -1;
                }
                else if (tbl.Rows[0][0].ToString() == "")
                {
                    status = 0;
                }
                else
                {
                    status = int.Parse(tbl.Rows[0][0].ToString());
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddGeneralTippaniProcess(List<ATTGeneralTippaniProcess> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID)
        {
            try
            {
                return DLLGeneralTippaniProcess.AddGeneralTippaniProcess(lst, tran , tippaniSubjectID, subject, tippaniID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateChannelPersonDecisionAndAddProcess(ATTGeneralTippaniProcess process, List<ATTGeneralTippaniProcess> lst, List<ATTGeneralTippaniAttachment> lstAttachment, TippaniSubject subject)
        {
            try
            {
                return DLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(process, lst, lstAttachment, subject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateChannelPersonDecisionAndAddProcess(ATTGeneralTippaniProcess process, List<ATTGeneralTippaniProcess> lst, List<ATTGeneralTippaniAttachment> lstAttachment, TippaniSubject subject, List<ATTGeneralTippaniSummary> lstRec)
        {
            try
            {
                return DLLGeneralTippaniProcess.UpdateChannelPersonDecisionAndAddProcess(process, lst, lstAttachment, subject, lstRec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool SendBackTippani(ATTGeneralTippaniProcess process, int subjectID, List<ATTGeneralTippaniAttachment> lstAttachment)
        //{
        //    try
        //    {
        //        return DLLGeneralTippaniProcess.SendBackTippani(process, subjectID, lstAttachment);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /*********************************************************/

        public static bool AddGeneralTippaniProcessDetail(List<ATTGeneralTippaniProcess> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID)
        {
            try
            {
                return DLLGeneralTippaniProcess.AddGeneralTippaniProcessDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetTippaniText(int orgID, int TippaniID, int TippaniProcessID)
        {
            try
            {
                object o = DLLGeneralTippaniProcess.GetTippaniText(orgID, TippaniID, TippaniProcessID);
                return o.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
