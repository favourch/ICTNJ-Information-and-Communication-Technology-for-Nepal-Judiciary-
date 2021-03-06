using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.FRAMEWORK;




namespace PCS.CMS.BLL
{
    public class BLLCaseRegistration
    {
        public static ObjectValidation Validate(ATTCaseRegistration caseX)
        {
            ObjectValidation result = new ObjectValidation();

            if (caseX.CourtID <= 0)
            {
                result.IsValid = false;
                result.ErrorMessage = "Please select court.";
                return result;
            }

            if (caseX.CaseRegistrationDate.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Case registration date cannot be blank..";
                return result;
            }

            if (caseX.FY.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Fiscal year cannot be blank..";
                return result;
            }

            return result;
        }

        public static bool RegisterCase(ATTCaseRegistration objCase)
        {
            try
            {
                return DLLCaseRegistration.RegisterCase(objCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateCaseSummary(ATTCaseRegistration objCase)
        {
            try
            {
                return DLLCaseRegistration.UpdateCaseSummary(objCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTCaseRegistration> GetCaseRegistration(double? caseID, 
                                                                    int defaultFlag,
                                                                    int AccFWDRQD,
                                                                    int AppOrRespRQD, 
                                                                    int checkListRQD, 
                                                                    int LawyerRQD,
                                                                    int EvidenceRQD,
                                                                    int DocumentsRQD,
                                                                    int SummaryRQD, 
                                                                    int WitnessRQD,
                                                                    string PersonDocActive    )
        {
            List<ATTCaseRegistration> CaseRegList = new List<ATTCaseRegistration>();
            try
            {
                foreach (DataRow row in DLLCaseRegistration.GetCaseRegistration(caseID).Rows)
                {
                    ATTCaseRegistration objCaseReg = new ATTCaseRegistration();
                    objCaseReg.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCaseReg.CourtID = int.Parse(row["COURT_ID"].ToString());
                    objCaseReg.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                    objCaseReg.CaseTypeName = row["CASE_TYPE_NAME"].ToString();
                    objCaseReg.RegDiaryID = int.Parse(row["REG_DIARY_ID"].ToString());
                    objCaseReg.RegDiaryName = row["REG_DIARY_NAME"].ToString();
                    objCaseReg.RegSubjectID = int.Parse(row["REG_SUBJECT_ID"].ToString());
                    objCaseReg.RegSubjectName = row["SUBJECT_NAME"].ToString();
                    objCaseReg.RegDiaryNameID = int.Parse(row["REG_DIARY_NAME_ID"].ToString());
                    objCaseReg.RegDiarySubName = row["REG_DIARY_SUB_NAME"].ToString();
                    objCaseReg.CaseRegistrationDate = row["CASE_REG_DATE"].ToString();
                    objCaseReg.ProceedingID=int.Parse(row["PROCEEDING_ID"].ToString());
                    objCaseReg.ProceedingType = row["PROCEEDING_NAME"].ToString();
                    objCaseReg.RegTypeID = int.Parse(row["REG_TYPE_ID"].ToString());
                    objCaseReg.RegTypeName = row["REG_TYPE_NAME"].ToString();
                    objCaseReg.AccountForwarded = row["ACCOUNT_FORWARDED"].ToString();

                    if (AccFWDRQD == 1)
                    {
                        objCaseReg.CaseAccountForwardLST = BLLCaseAccountForward.GetCaseAccountForward(objCaseReg.CaseID, null, "N");
                    }

                    if (AppOrRespRQD == 1)
                    {
                        objCaseReg.AppellantLST = BLLLitigants.GetLitigants(objCaseReg.CaseID, null, "A",0,1,PersonDocActive);
                        objCaseReg.RespondantLST = BLLLitigants.GetLitigants(objCaseReg.CaseID, null, "R",0,1,PersonDocActive);
                    }

                    if (checkListRQD == 1)
                    {
                        objCaseReg.CaseCheckListLST = BLLCaseCheckList.GetCaseCheckList(objCaseReg.CaseID, objCaseReg.CourtID, objCaseReg.CaseTypeID, objCaseReg.RegTypeID,null, 0);
                    }

                    if (LawyerRQD == 1)
                    {
                        objCaseReg.CaseLawyerLST = BLLCaseLawyer.GetCaseLawyer(objCaseReg.CaseID, null, null);
                    }

                    if (WitnessRQD == 1)
                    {
                        objCaseReg.WitnessPersonLST = BLLWitnessPerson.GetWitness(objCaseReg.CaseID, null, null, null);
                    }

                    if (EvidenceRQD == 1)
                        objCaseReg.CaseEvidenceLST = BLLCaseEvidence.GetCaseEvidence(objCaseReg.CaseID);

                    if (DocumentsRQD == 1)
                        objCaseReg.CaseDocumentLitLST = BLLCaseDocumentLit.GetCaseDocuments(objCaseReg.CaseID,null,null);

                    if (SummaryRQD == 1)
                    {
                        objCaseReg.CaseSummary = row["CASE_SUMMARY"].ToString();
                    }



                     
                    
                    
                    CaseRegList.Add(objCaseReg);

                    


                }

                //if (defaultFlag > 0)
                //    CaseStatusList.Insert(0, new ATTCaseStatus(0, "छान्नुहोस", ""));
                return CaseRegList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<ATTCaseRegistration> GetCaseVerification(double? caseID,
                                                                    int defaultFlag,
                                                                    string verifiedYN)
        {
            List<ATTCaseRegistration> CaseRegList = new List<ATTCaseRegistration>();
            try
            {
                foreach (DataRow row in DLLCaseRegistration.GetCaseVerification(caseID,verifiedYN).Rows)
                {
                    ATTCaseRegistration objCaseReg = new ATTCaseRegistration();
                    objCaseReg.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCaseReg.CourtID = int.Parse(row["COURT_ID"].ToString());
                    objCaseReg.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                    objCaseReg.CaseTypeName = row["CASE_TYPE_NAME"].ToString();
                    objCaseReg.RegDiaryID = int.Parse(row["REG_DIARY_ID"].ToString());
                    objCaseReg.RegDiaryName = row["REG_DIARY_NAME"].ToString();
                    objCaseReg.RegSubjectID = int.Parse(row["REG_SUBJECT_ID"].ToString());
                    objCaseReg.RegSubjectName = row["SUBJECT_NAME"].ToString();
                    objCaseReg.RegDiaryNameID = int.Parse(row["REG_DIARY_NAME_ID"].ToString());
                    objCaseReg.RegDiarySubName = row["REG_DIARY_SUB_NAME"].ToString();
                    objCaseReg.CaseRegistrationDate = row["CASE_REG_DATE"].ToString();
                    objCaseReg.ProceedingID = int.Parse(row["PROCEEDING_ID"].ToString());
                    objCaseReg.ProceedingType = row["PROCEEDING_NAME"].ToString();
                    objCaseReg.RegTypeID = int.Parse(row["REG_TYPE_ID"].ToString());
                    objCaseReg.RegTypeName = row["REG_TYPE_NAME"].ToString();
                    objCaseReg.AccountForwarded = row["ACCOUNT_FORWARDED"].ToString();

                    





                    CaseRegList.Add(objCaseReg);




                }

                //if (defaultFlag > 0)
                //    CaseStatusList.Insert(0, new ATTCaseStatus(0, "छान्नुहोस", ""));
                return CaseRegList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
