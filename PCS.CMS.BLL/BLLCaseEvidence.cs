using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

using PCS.FRAMEWORK;



namespace PCS.CMS.BLL
{
    public class BLLCaseEvidence
    {
        public static List<ATTCaseEvidence> GetCaseEvidence(double? CaseID)
        {
            List<ATTCaseEvidence> CaseEvidenceList = new List<ATTCaseEvidence>();
            try
            {
                foreach (DataRow row in DLLCaseEvidence.GetCaseEvidence(CaseID).Rows)
                {
                    ATTCaseEvidence CElst = new ATTCaseEvidence();
                    CElst.CaseID=  double.Parse(row["CASE_ID"].ToString());
                     CElst.EvidenceID=int.Parse(   row["EVIDENCE_ID"].ToString());
                    CElst.Evidence=row["EVIDENCE"].ToString();
                    CaseEvidenceList.Add(CElst);
                }

                return CaseEvidenceList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
