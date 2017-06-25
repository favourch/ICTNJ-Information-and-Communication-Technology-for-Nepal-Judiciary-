using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLLitigantSearch
    {
        public static List<ATTLitigantSearch> GetLitigantSearch(ATTLitigantSearch litigantSearch)
        {
            try
            {
                
                List<ATTLitigantSearch> litigantLIST = new List<ATTLitigantSearch>();
                foreach (DataRow drow in DLLLitigantSearch.GetLitigantSearch(litigantSearch).Rows)
                {
                    ATTLitigantSearch litigant = new ATTLitigantSearch();
                    if (drow["CASE_ID"] != null)
                    {
                        if (drow["CASE_ID"].ToString() != "")
                            litigant.CaseID = int.Parse(drow["CASE_ID"].ToString());
                    }
                    if (drow["COURT_ID"] != null)
                    {
                        if (drow["COURT_ID"].ToString() != "")
                            litigant.CourtID = int.Parse(drow["COURT_ID"].ToString());
                    }
                    litigant.CaseRegDate = drow["CASE_REG_DATE"].ToString();
                    litigant.CaseNo = drow["CASE_NUMBER"].ToString();
                    litigant.RegNo = drow["REG_NUMBER"].ToString();
                    if (drow["CASE_TYPE_ID"] != null)
                    {
                        if (drow["CASE_TYPE_ID"].ToString() != "")
                            litigant.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    }
                    litigant.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    if (drow["REG_DIARY_ID"] != null)
                    {
                        if (drow["REG_DIARY_ID"].ToString() != "")
                            litigant.RegistrationDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    }
                    litigant.RegistrationDiary = drow["REG_DIARY"].ToString();
                    litigant.RegistrationDiaryCode = drow["REG_DIARY_CODE"].ToString();
                    if (drow["REG_SUBJECT_ID"] != null)
                    {
                        if (drow["REG_SUBJECT_ID"].ToString() != "")
                            litigant.RegistrationSubjectID = int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    }
                    litigant.SubjectName = drow["SUBJECT_NAME"].ToString();
                    if (drow["REG_DIARY_NAME_ID"] != null)
                    {
                        if (drow["REG_DIARY_NAME_ID"].ToString() != "")
                            litigant.RegistrationDiaryNameID = int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    }
                    litigant.RegistrationDiaryName = drow["REG_DIARY_NAME"].ToString();

                    if (drow["WRIT_SUB_ID"] != null)
                    {
                        if (drow["WRIT_SUB_ID"].ToString() != "")
                            litigant.WritSubID = int.Parse(drow["WRIT_SUB_ID"].ToString());
                    }
                    litigant.WritSubName = drow["WRIT_SUB_NAME"].ToString();
                    if (drow["WRIT_CAT_ID"] != null)
                    {
                        if (drow["WRIT_CAT_ID"].ToString() != "")
                            litigant.WritCatID = int.Parse(drow["WRIT_CAT_ID"].ToString());
                    }
                    litigant.WritSubCatName = drow["WRIT_SUB_CAT_NAME"].ToString();
                    if (drow["WRIT_CAT_TITLE_ID"] != null)
                    {
                        if (drow["WRIT_CAT_TITLE_ID"].ToString() != "")
                            litigant.WritCatTitleID = int.Parse(drow["WRIT_CAT_TITLE_ID"].ToString());
                    }
                    litigant.WritSubCatTitleName = drow["WRIT_SUB_CAT_TITLE_NAME"].ToString();
                    if (drow["WRIT_CAT_SUBTITLE_ID"] != null)
                    {
                        if (drow["WRIT_CAT_SUBTITLE_ID"].ToString() != "")

                            litigant.WritCatSubTitleID = int.Parse(drow["WRIT_CAT_SUBTITLE_ID"].ToString());
                    }
                    litigant.WritSubCatSubTitleName = drow["WRIT_SUB_CAT_SUBTITLE_NAME"].ToString();

                    litigant.LitigantID = int.Parse(drow["LITIGANT_ID"].ToString());
                    litigant.LitigantName = drow["LITIGANTNAME"].ToString();

                    litigant.DOB = drow["DOB"].ToString();
                    litigant.Gender = drow["GENDER"].ToString();

                    litigant.DisplayName = drow["DISPLAY_NAME"].ToString();
                    litigant.LitigantType = drow["LITIGANT_TYPE"].ToString();
                    if (drow["LITIGANT_SUB_TYPE_ID"] != null)
                    {
                        if (drow["LITIGANT_SUB_TYPE_ID"].ToString() != "")
                            litigant.LitigantSubTypeID = int.Parse(drow["LITIGANT_SUB_TYPE_ID"].ToString());
                    }
                    litigant.LitigantSubTypeName = drow["LITIGANT_SUB_TYPE_NAME"].ToString();
                    if (drow["S_NO"] != null)
                    {
                        if (drow["S_NO"].ToString() != "")
                            litigant.SNo = int.Parse(drow["S_NO"].ToString());
                    }
                    litigant.IsPrisoned = drow["IS_PRISONED"].ToString();
                    
                    litigant.AccountForwarded = drow["ACCOUNT_FORWARDED"].ToString();
                    litigant.Verified = drow["VERIFIED_YES_NO"].ToString();

                    litigantLIST.Add(litigant);
                }

                return litigantLIST;
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
