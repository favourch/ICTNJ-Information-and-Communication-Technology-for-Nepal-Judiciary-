using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLSectionClerkCase
    {
        public static bool SaveSectionClerkCase(List<ATTSectionClerkCase> lstSectionClerkCase)
        {
            try
            {
                return DLLSectionClerkCase.SaveSectionClerkCase(lstSectionClerkCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTSectionClerkCase> GetSecClerkCase(double caseID)
        {
            List<ATTSectionClerkCase> SectionClerkCaseLST = new List<ATTSectionClerkCase>();
            try
            {
                foreach (DataRow row in DLLSectionClerkCase.GetSectionClerkCase(caseID).Rows)
                {
                    ATTSectionClerkCase objSectionClerkCase = new ATTSectionClerkCase();
                    objSectionClerkCase.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objSectionClerkCase.UnitID = int.Parse(row["UNIT_ID"].ToString());
                    objSectionClerkCase.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                    objSectionClerkCase.CaseID = int.Parse(row["CASE_ID"].ToString());
                    objSectionClerkCase.SectionClerkID = int.Parse(row["SECTION_CLRK_ID"].ToString());
                    objSectionClerkCase.SectionClerkFromDate = row["SEC_CLRK_FROM_DATE"].ToString();
                    SectionClerkCaseLST.Add(objSectionClerkCase);
                }

                return SectionClerkCaseLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
