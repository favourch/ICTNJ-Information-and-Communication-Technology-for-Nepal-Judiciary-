using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseSearch
    {
        public static List<ATTCaseSearch> GetCaseSearch(ATTCaseSearch caseSrchSearch)
        {
            try
            {
                
                List<ATTCaseSearch> caseSrchLIST = new List<ATTCaseSearch>();
                foreach (DataRow drow in DLLCaseSearch.GetCaseSearch(caseSrchSearch).Rows)
                {
                    ATTCaseSearch caseSrch = new ATTCaseSearch();
                    if (drow["CASE_ID"] != null)
                    {
                        if (drow["CASE_ID"].ToString() != "")
                            caseSrch.CaseID = int.Parse(drow["CASE_ID"].ToString());
                    }
                    if (drow["COURT_ID"] != null)
                    {
                        if (drow["COURT_ID"].ToString() != "")
                            caseSrch.CourtID = int.Parse(drow["COURT_ID"].ToString());
                    }
                    caseSrch.CaseRegDate = drow["CASE_REG_DATE"].ToString();
                    caseSrch.CaseNo = drow["CASE_NUMBER"].ToString();
                    caseSrch.RegNo = drow["REG_NUMBER"].ToString();
                    if (drow["CASE_TYPE_ID"] != null)
                    {
                        if (drow["CASE_TYPE_ID"].ToString() != "")
                            caseSrch.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    }
                    caseSrch.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    if (drow["REG_DIARY_ID"] != null)
                    {
                        if (drow["REG_DIARY_ID"].ToString() != "")
                            caseSrch.RegistrationDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    }
                    caseSrch.RegistrationDiary = drow["REG_DIARY_NAME"].ToString();
                    caseSrch.RegistrationDiaryCode = drow["REG_DIARY_CODE"].ToString();
                    if (drow["REG_SUBJECT_ID"] != null)
                    {
                        if (drow["REG_SUBJECT_ID"].ToString() != "")
                            caseSrch.RegistrationSubjectID = int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    }
                    caseSrch.SubjectName = drow["SUBJECT_NAME"].ToString();
                    if (drow["REG_DIARY_NAME_ID"] != null)
                    {
                        if (drow["REG_DIARY_NAME_ID"].ToString() != "")
                            caseSrch.RegistrationDiaryNameID = int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    }
                    caseSrch.RegDiaryNameDesc = drow["REG_DIARY_NAME_DESC"].ToString();




                    if (drow["WRIT_SUB_ID"] != null)
                    {
                        if (drow["WRIT_SUB_ID"].ToString() != "")
                            caseSrch.WritSubID = int.Parse(drow["WRIT_SUB_ID"].ToString());
                    }
                    caseSrch.WritSubName = drow["WRIT_SUB_NAME"].ToString();
                    if (drow["WRIT_CAT_ID"] != null)
                    {
                        if (drow["WRIT_CAT_ID"].ToString() != "")
                            caseSrch.WritCatID = int.Parse(drow["WRIT_CAT_ID"].ToString());
                    }
                    caseSrch.WritSubCatName = drow["WRIT_SUB_CAT_NAME"].ToString();
                    if (drow["WRIT_CAT_TITLE_ID"] != null)
                    {
                        if (drow["WRIT_CAT_TITLE_ID"].ToString() != "")
                            caseSrch.WritCatTitleID = int.Parse(drow["WRIT_CAT_TITLE_ID"].ToString());
                    }
                    caseSrch.WritSubCatTitleName = drow["WRIT_SUB_CAT_TITLE_NAME"].ToString();
                    if (drow["WRIT_CAT_SUBTITLE_ID"] != null)
                    {
                        if (drow["WRIT_CAT_SUBTITLE_ID"].ToString() != "")

                            caseSrch.WritCatSubTitleID = int.Parse(drow["WRIT_CAT_SUBTITLE_ID"].ToString());
                    }
                    caseSrch.WritSubCatSubTitleName = drow["WRIT_SUB_CAT_SUBTITLE_NAME"].ToString();

                    
                    caseSrch.AccountForwarded = drow["ACCOUNT_FORWARDED"].ToString();
                    caseSrch.Verified = drow["VERIFIED_YES_NO"].ToString();

                    if (drow["VERIFIED_BY"] != null)
                    {
                        if (drow["VERIFIED_BY"].ToString() != "")
                            caseSrch.VerifiedBy = int.Parse(drow["VERIFIED_BY"].ToString());
                    }
                    if (drow["DECISION_YES_NO"] != null)
                    {
                        if (drow["DECISION_YES_NO"].ToString() != "")
                            caseSrch.DecisionYesNo =drow["DECISION_YES_NO"].ToString();
                    }
                    caseSrch.VerifiedDate = drow["VERIFIED_DATE"].ToString();
                    caseSrch.DarpithRemarks = drow["DARPITH_REMARKS"].ToString();
                    if (drow["PROCEEDING_ID"] != null)
                    {
                        if (drow["PROCEEDING_ID"].ToString() != "")
                            caseSrch.ProceedingID = int.Parse(drow["PROCEEDING_ID"].ToString());
                    }
                    caseSrch.CaseSummary = drow["CASE_SUMMARY"].ToString();
                    if (drow["RELATED_CASE_ID"] != null)
                    {
                        if (drow["RELATED_CASE_ID"].ToString() != "")
                            caseSrch.RelatedCaseID = int.Parse(drow["RELATED_CASE_ID"].ToString());
                    } 
                    caseSrch.FY = drow["FY"].ToString();
                    caseSrch.Appelant = drow["APPELLANT"].ToString();
                    caseSrch.Respondant = drow["RESPONDENT"].ToString();


                    caseSrchLIST.Add(caseSrch);
                }

                return caseSrchLIST;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static string ConvertNullToEmptyString(string strinput)
        {
            return (strinput == null ? "" : strinput);
        }
    }
}
