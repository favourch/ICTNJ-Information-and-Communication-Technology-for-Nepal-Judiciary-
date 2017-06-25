using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLTameliSearch
    {
        public static List<ATTTameliSearch> GetTameliSearch(ATTTameliSearch tameli)
        {
            try
            {
                List<ATTTameliSearch> tameliInfoList = new List<ATTTameliSearch>();
                foreach (DataRow drow in DLLTameliSearch.GetTameliSearch(tameli).Rows)
                {
                    ATTTameliSearch tameliInfo = new ATTTameliSearch();
                    if (drow["COURT_ID"] != null)
                    {
                        if (int.Parse(drow["COURT_ID"].ToString())>0)
                        {
                            if (drow["COURT_ID"].ToString() != "") tameliInfo.OrgID = int.Parse(drow["COURT_ID"].ToString());
                            
                        }
                    }
                    if (drow["CASE_ID"] != null)
                    {
                        if (drow["CASE_ID"].ToString() != "")tameliInfo.CaseID = int.Parse(drow["CASE_ID"].ToString());                            
                    }
                    if (drow["CASE_TYPE_ID"] != null)
                    {
                        if (drow["CASE_TYPE_ID"].ToString() != "") tameliInfo.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    }
                    tameliInfo.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    if (drow["REG_TYPE_ID"] != null)
                    {
                        if (drow["REG_TYPE_ID"].ToString() != "") tameliInfo.RegTypeID = int.Parse(drow["REG_TYPE_ID"].ToString());
                    }
                    tameliInfo.RegTypeName = drow["REG_TYPE_NAME"].ToString();
                    if (drow["REG_DIARY_ID"] != null)
                    {
                        if (drow["REG_DIARY_ID"].ToString() != "") tameliInfo.RegDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    }
                    if (drow["REG_SUBJECT_ID"] != null)
                    {
                        if (drow["REG_SUBJECT_ID"].ToString() != "") tameliInfo.RegSubjectID = int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    }
                    tameliInfo.SubjectName = drow["SUBJECT_NAME"].ToString();
                    if (drow["REG_DIARY_NAME_ID"] != null)
                    {
                        if (drow["REG_DIARY_NAME_ID"].ToString() != "") tameliInfo.RegDiaryNameID = int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    }
                    tameliInfo.RegDiarySubName = drow["REG_DIARY_SUB_NAME"].ToString();

                    tameliInfo.CaseRegDate = drow["CASE_REG_DATE"].ToString();
                    tameliInfo.RegNo = drow["REG_NO"].ToString();
                    tameliInfo.CaseNo = drow["CASE_NO"].ToString();


                    if (drow["LITIGANT_ID"] != null)
                    {
                        if (drow["LITIGANT_ID"].ToString() != "")tameliInfo.LitigantID = int.Parse(drow["LITIGANT_ID"].ToString());                            
                    }
                    tameliInfo.LitigantName = drow["LITIGANTNAME"].ToString();
                    tameliInfo.IssuedDate = drow["ISSUED_DATE"].ToString();
                    if (drow["SEQ_NO"] != null)
                    {
                        if (drow["SEQ_NO"].ToString() != "") tameliInfo.SeqNo = int.Parse(drow["SEQ_NO"].ToString());
                    }
                    if (drow["ATTORNEY_ID"] != null)
                    {
                        if (drow["ATTORNEY_ID"].ToString() != "") tameliInfo.AttorneyID = int.Parse(drow["ATTORNEY_ID"].ToString());
                    }
                    tameliInfo.AttorneyFullName = drow["ATTORNEYFLLNAME"].ToString();

                    
                    if (drow["ISSUED_BY"] != null)
                    {
                        if (drow["ISSUED_BY"].ToString() != "")tameliInfo.IssuedBy = int.Parse(drow["ISSUED_BY"].ToString());                            
                    }
                    tameliInfo.IssuedPerson = drow["ISSUEDPERSON"].ToString();
                    tameliInfo.ReceivedDate = drow["RECEIVED_DATE"].ToString();
                    if (drow["RECEIVED_BY"] != null)
                    {
                        if (drow["RECEIVED_BY"].ToString() != "")tameliInfo.ReceivedBy = int.Parse(drow["RECEIVED_BY"].ToString());                            
                    }
                    tameliInfo.TamildaarName = drow["TAMILDAARNAME"].ToString();
                    tameliInfo.TameliDate = drow["TAMELI_DATE"].ToString();
                    tameliInfo.TameliYesNo = drow["TAMELI_YES_NO"].ToString();

                    tameliInfo.SecClrkRcvdDate = drow["SEC_CLRK_RCVD_DATE"].ToString();
                    tameli.TamilDaarRemrks = drow["TAMILDAAR_REMARKS"].ToString();
                    tameliInfo.VerifiedDate = drow["VERIFIED_DATE"].ToString();
                    if (drow["VERIFIED_BY"] != null)
                    {
                        if (drow["VERIFIED_BY"].ToString() != "")tameliInfo.VerifiedBy = int.Parse(drow["VERIFIED_BY"].ToString());                            
                    }
                    tameliInfo.SectionClerkName=drow["SECTIONCLERKNAME"].ToString();
                    tameliInfo.VerifiedRemarks=drow["VERIFIED_REMARKS"].ToString();
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "")tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());                            
                    }
                    tameliInfo.MyaadTypeName = drow["MYAAD_TYPE_NAME"].ToString();
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "")tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());                            
                    }
                    tameliInfo.TameliTypeName = drow["TAMELI_TYPE_NAME"].ToString();
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "")tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());                            
                    }
                    tameliInfo.TameliStatusName = drow["TAMELI_STATUS_NAME"].ToString();
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "")tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());                            
                    }
                    tameliInfo.OrgName = drow["ORG_NAME"].ToString();




                    if (drow["WITNESS_ID"] != null)
                    {
                        if (drow["WITNESS_ID"].ToString() != "") tameliInfo.WitnessID = int.Parse(drow["WITNESS_ID"].ToString());
                    }
                    tameliInfo.WitnessFullName = drow["WITNESSFULLNAME"].ToString();
                    //tameliInfo.WitnessDOB = drow["WIT_DOB"].ToString();
                    //tameliInfo.WitnessGender = drow["WIT_GENDER"].ToString();
                    tameliInfo.VerifiedYesNo = drow["VERIFIED_YES_NO"].ToString();

                    if (drow["ATTEND_DAYS"] != null)
                    {
                        if (drow["ATTEND_DAYS"].ToString() != "") tameliInfo.AttendDays = int.Parse(drow["ATTEND_DAYS"].ToString());
                    }
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "") tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "") tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "") tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                    }
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "") tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());
                    }
                    tameliInfo.RegDiaryName = drow["REG_DIARY_NAME"].ToString();
                    tameliInfo.MyaadType = drow["MYAAD_TYPE"].ToString();


                    tameliInfoList.Add(tameliInfo);  
                }
                return tameliInfoList;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public static List<ATTTameliSearch> GetTameliForFeedBack(ATTTameliSearch tameli)
        {
            try
            {
                List<ATTTameliSearch> tameliInfoList = new List<ATTTameliSearch>();
                foreach (DataRow drow in DLLTameliSearch.GetTameliForFeedBack(tameli).Rows)
                {
                    ATTTameliSearch tameliInfo = new ATTTameliSearch();
                    if (drow["COURT_ID"] != null)
                    {
                        if (drow["COURT_ID"].ToString() != "") tameliInfo.OrgID = int.Parse(drow["COURT_ID"].ToString());
                    }
                    if (drow["CASE_ID"] != null)
                    {
                        if (drow["CASE_ID"].ToString() != "") tameliInfo.CaseID = int.Parse(drow["CASE_ID"].ToString());
                    }
                    if (drow["CASE_TYPE_ID"] != null)
                    {
                        if (drow["CASE_TYPE_ID"].ToString() != "") tameliInfo.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    }
                    tameliInfo.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    if (drow["REG_TYPE_ID"] != null)
                    {
                        if (drow["REG_TYPE_ID"].ToString() != "") tameliInfo.RegTypeID = int.Parse(drow["REG_TYPE_ID"].ToString());
                    }
                    tameliInfo.RegTypeName = drow["REG_TYPE_NAME"].ToString();
                    if (drow["REG_DIARY_ID"] != null)
                    {
                        if (drow["REG_DIARY_ID"].ToString() != "") tameliInfo.RegDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    }
                    if (drow["REG_SUBJECT_ID"] != null)
                    {
                        if (drow["REG_SUBJECT_ID"].ToString() != "") tameliInfo.RegSubjectID = int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    }
                    tameliInfo.SubjectName = drow["SUBJECT_NAME"].ToString();
                    if (drow["REG_DIARY_NAME_ID"] != null)
                    {
                        if (drow["REG_DIARY_NAME_ID"].ToString() != "") tameliInfo.RegDiaryNameID = int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    }
                    tameliInfo.RegDiarySubName = drow["REG_DIARY_SUB_NAME"].ToString();

                    tameliInfo.CaseRegDate = drow["CASE_REG_DATE"].ToString();
                    tameliInfo.RegNo = drow["REG_NO"].ToString();
                    tameliInfo.CaseNo = drow["CASE_NO"].ToString();


                    if (drow["LITIGANT_ID"] != null)
                    {
                        if (drow["LITIGANT_ID"].ToString() != "") tameliInfo.LitigantID = int.Parse(drow["LITIGANT_ID"].ToString());
                    }
                    tameliInfo.LitigantName = drow["LITIGANTNAME"].ToString();
                    tameliInfo.IssuedDate = drow["ISSUED_DATE"].ToString();
                    if (drow["SEQ_NO"] != null)
                    {
                        if (drow["SEQ_NO"].ToString() != "") tameliInfo.SeqNo = int.Parse(drow["SEQ_NO"].ToString());
                    }
                    if (drow["ATTORNEY_ID"] != null)
                    {
                        if (drow["ATTORNEY_ID"].ToString() != "") tameliInfo.AttorneyID = int.Parse(drow["ATTORNEY_ID"].ToString());
                    }
                    tameliInfo.AttorneyFullName = drow["ATTORNEYFLLNAME"].ToString();


                    if (drow["ISSUED_BY"] != null)
                    {
                        if (drow["ISSUED_BY"].ToString() != "") tameliInfo.IssuedBy = int.Parse(drow["ISSUED_BY"].ToString());
                    }
                    tameliInfo.IssuedPerson = drow["ISSUEDPERSON"].ToString();
                    tameliInfo.ReceivedDate = drow["RECEIVED_DATE"].ToString();
                    if (drow["RECEIVED_BY"] != null)
                    {
                        if (drow["RECEIVED_BY"].ToString() != "") tameliInfo.ReceivedBy = int.Parse(drow["RECEIVED_BY"].ToString());
                    }
                    tameliInfo.TamildaarName = drow["TAMILDAARNAME"].ToString();
                    tameliInfo.TameliDate = drow["TAMELI_DATE"].ToString();
                    tameliInfo.TameliYesNo = drow["TAMELI_YES_NO"].ToString();

                    tameliInfo.SecClrkRcvdDate = drow["SEC_CLRK_RCVD_DATE"].ToString();
                    tameli.TamilDaarRemrks = drow["TAMILDAAR_REMARKS"].ToString();
                    tameliInfo.VerifiedDate = drow["VERIFIED_DATE"].ToString();
                    if (drow["VERIFIED_BY"] != null)
                    {
                        if (drow["VERIFIED_BY"].ToString() != "") tameliInfo.VerifiedBy = int.Parse(drow["VERIFIED_BY"].ToString());
                    }
                    tameliInfo.SectionClerkName = drow["SECTIONCLERKNAME"].ToString();
                    tameliInfo.VerifiedRemarks = drow["VERIFIED_REMARKS"].ToString();
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "") tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    }
                    tameliInfo.MyaadTypeName = drow["MYAAD_TYPE_NAME"].ToString();
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "") tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    }
                    tameliInfo.TameliTypeName = drow["TAMELI_TYPE_NAME"].ToString();
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "") tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                    }
                    tameliInfo.TameliStatusName = drow["TAMELI_STATUS_NAME"].ToString();
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "") tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());
                    }
                    tameliInfo.OrgName = drow["ORG_NAME"].ToString();




                    if (drow["WITNESS_ID"] != null)
                    {
                        if (drow["WITNESS_ID"].ToString() != "") tameliInfo.WitnessID = int.Parse(drow["WITNESS_ID"].ToString());
                    }
                    tameliInfo.WitnessFullName = drow["WITNESSFULLNAME"].ToString();
                    //tameliInfo.WitnessDOB = drow["WIT_DOB"].ToString();
                    //tameliInfo.WitnessGender = drow["WIT_GENDER"].ToString();
                    tameliInfo.VerifiedYesNo = drow["VERIFIED_YES_NO"].ToString();

                    if (drow["ATTEND_DAYS"] != null)
                    {
                        if (drow["ATTEND_DAYS"].ToString() != "") tameliInfo.AttendDays = int.Parse(drow["ATTEND_DAYS"].ToString());
                    }
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "") tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "") tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "") tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                    }
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "") tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());
                    }
                    tameliInfo.RegDiaryName = drow["REG_DIARY_NAME"].ToString();
                    tameliInfo.MyaadType = drow["MYAAD_TYPE"].ToString();


                    tameliInfoList.Add(tameliInfo);
                }
                return tameliInfoList;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static List<ATTTameliSearch> GetTameliForAssigningTamildaar(int OrgID)
        {
            try
            {
                List<ATTTameliSearch> tameliInfoList = new List<ATTTameliSearch>();
                foreach (DataRow drow in DLLTameliSearch.GetTameliForAssigningTamildaar(OrgID).Rows)
                {
                    ATTTameliSearch tameliInfo = new ATTTameliSearch();
                    if (drow["COURT_ID"] != null)
                    {
                        if (drow["COURT_ID"].ToString() != "") tameliInfo.OrgID = int.Parse(drow["COURT_ID"].ToString());
                    }
                    if (drow["CASE_ID"] != null)
                    {
                        if (drow["CASE_ID"].ToString() != "") tameliInfo.CaseID = int.Parse(drow["CASE_ID"].ToString());
                    }
                    if (drow["CASE_TYPE_ID"] != null)
                    {
                        if (drow["CASE_TYPE_ID"].ToString() != "") tameliInfo.CaseTypeID = int.Parse(drow["CASE_TYPE_ID"].ToString());
                    }
                    tameliInfo.CaseTypeName = drow["CASE_TYPE_NAME"].ToString();
                    if (drow["REG_TYPE_ID"] != null)
                    {
                        if (drow["REG_TYPE_ID"].ToString() != "") tameliInfo.RegTypeID = int.Parse(drow["REG_TYPE_ID"].ToString());
                    }
                    tameliInfo.RegTypeName = drow["REG_TYPE_NAME"].ToString();
                    if (drow["REG_DIARY_ID"] != null)
                    {
                        if (drow["REG_DIARY_ID"].ToString() != "") tameliInfo.RegDiaryID = int.Parse(drow["REG_DIARY_ID"].ToString());
                    }
                    if (drow["REG_SUBJECT_ID"] != null)
                    {
                        if (drow["REG_SUBJECT_ID"].ToString() != "") tameliInfo.RegSubjectID = int.Parse(drow["REG_SUBJECT_ID"].ToString());
                    }
                    tameliInfo.SubjectName = drow["SUBJECT_NAME"].ToString();
                    if (drow["REG_DIARY_NAME_ID"] != null)
                    {
                        if (drow["REG_DIARY_NAME_ID"].ToString() != "") tameliInfo.RegDiaryNameID = int.Parse(drow["REG_DIARY_NAME_ID"].ToString());
                    }
                    tameliInfo.RegDiarySubName = drow["REG_DIARY_SUB_NAME"].ToString();

                    tameliInfo.CaseRegDate = drow["CASE_REG_DATE"].ToString();
                    tameliInfo.RegNo = drow["REG_NO"].ToString();
                    tameliInfo.CaseNo = drow["CASE_NO"].ToString();


                    if (drow["LITIGANT_ID"] != null)
                    {
                        if (drow["LITIGANT_ID"].ToString() != "") tameliInfo.LitigantID = int.Parse(drow["LITIGANT_ID"].ToString());
                    }
                    tameliInfo.LitigantName = drow["LITIGANTNAME"].ToString();
                    tameliInfo.IssuedDate = drow["ISSUED_DATE"].ToString();
                    if (drow["SEQ_NO"] != null)
                    {
                        if (drow["SEQ_NO"].ToString() != "") tameliInfo.SeqNo = int.Parse(drow["SEQ_NO"].ToString());
                    }
                    if (drow["ATTORNEY_ID"] != null)
                    {
                        if (drow["ATTORNEY_ID"].ToString() != "") tameliInfo.AttorneyID = int.Parse(drow["ATTORNEY_ID"].ToString());
                    }
                    tameliInfo.AttorneyFullName = drow["ATTORNEYFLLNAME"].ToString();


                    if (drow["ISSUED_BY"] != null)
                    {
                        if (drow["ISSUED_BY"].ToString() != "") tameliInfo.IssuedBy = int.Parse(drow["ISSUED_BY"].ToString());
                    }
                    tameliInfo.IssuedPerson = drow["ISSUEDPERSON"].ToString();
                    tameliInfo.ReceivedDate = drow["RECEIVED_DATE"].ToString();
                    if (drow["RECEIVED_BY"] != null)
                    {
                        if (drow["RECEIVED_BY"].ToString() != "") tameliInfo.ReceivedBy = int.Parse(drow["RECEIVED_BY"].ToString());
                    }
                    tameliInfo.TamildaarName = drow["TAMILDAARNAME"].ToString();
                    tameliInfo.TameliDate = drow["TAMELI_DATE"].ToString();
                    tameliInfo.TameliYesNo = drow["TAMELI_YES_NO"].ToString();

                    tameliInfo.SecClrkRcvdDate = drow["SEC_CLRK_RCVD_DATE"].ToString();
                    tameliInfo.TamilDaarRemrks = drow["TAMILDAAR_REMARKS"].ToString();
                    tameliInfo.VerifiedDate = drow["VERIFIED_DATE"].ToString();
                    if (drow["VERIFIED_BY"] != null)
                    {
                        if (drow["VERIFIED_BY"].ToString() != "") tameliInfo.VerifiedBy = int.Parse(drow["VERIFIED_BY"].ToString());
                    }
                    tameliInfo.SectionClerkName = drow["SECTIONCLERKNAME"].ToString();
                    tameliInfo.VerifiedRemarks = drow["VERIFIED_REMARKS"].ToString();
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "") tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    }
                    tameliInfo.MyaadTypeName = drow["MYAAD_TYPE_NAME"].ToString();
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "") tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    }
                    tameliInfo.TameliTypeName = drow["TAMELI_TYPE_NAME"].ToString();
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "") tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                    }
                    tameliInfo.TameliStatusName = drow["TAMELI_STATUS_NAME"].ToString();
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "") tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());
                    }
                    tameliInfo.OrgName = drow["ORG_NAME"].ToString();




                    if (drow["WITNESS_ID"] != null)
                    {
                        if (drow["WITNESS_ID"].ToString() != "") tameliInfo.WitnessID = int.Parse(drow["WITNESS_ID"].ToString());
                    }
                    tameliInfo.WitnessFullName = drow["WITNESSFULLNAME"].ToString();
                    //tameliInfo.WitnessDOB = drow["WIT_DOB"].ToString();
                    //tameliInfo.WitnessGender = drow["WIT_GENDER"].ToString();
                    tameliInfo.VerifiedYesNo = drow["VERIFIED_YES_NO"].ToString();

                    if (drow["ATTEND_DAYS"] != null)
                    {
                        if (drow["ATTEND_DAYS"].ToString() != "") tameliInfo.AttendDays = int.Parse(drow["ATTEND_DAYS"].ToString());
                    }
                    if (drow["MYAAD_TYPE_ID"] != null)
                    {
                        if (drow["MYAAD_TYPE_ID"].ToString() != "") tameliInfo.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_TYPE_ID"] != null)
                    {
                        if (drow["TAMELI_TYPE_ID"].ToString() != "") tameliInfo.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    }
                    if (drow["TAMELI_STATUS_ID"] != null)
                    {
                        if (drow["TAMELI_STATUS_ID"].ToString() != "") tameliInfo.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                    }
                    if (drow["TAMELI_ORG"] != null)
                    {
                        if (drow["TAMELI_ORG"].ToString() != "") tameliInfo.TameliOrg = int.Parse(drow["TAMELI_ORG"].ToString());
                    }
                    tameliInfo.RegDiaryName = drow["REG_DIARY_NAME"].ToString();
                    tameliInfo.MyaadType = drow["MYAAD_TYPE"].ToString();


                    tameliInfoList.Add(tameliInfo);
                }
                return tameliInfoList;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
