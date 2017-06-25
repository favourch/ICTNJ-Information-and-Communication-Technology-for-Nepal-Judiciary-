using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLGeneralTippaniDetail
    {
        public static bool AddGeneralTippaniDetail
            (
                List<ATTGeneralTippaniDetail> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {
            try
            {
                if (subject == TippaniSubject.Leave) //1. leave tippani
                {
                    DLLGeneralTippaniDetail.AddLeaveTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Visit) //2. visit tippani
                {
                    DLLGeneralTippaniDetail.AddVisitTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Posting) //3. posting tippani
                {
                    DLLGeneralTippaniDetail.AddPostingTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Training) //4. training tippani
                {
                    DLLGeneralTippaniDetail.AddTrainingTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Deputation) //5. deputaion tippani
                {
                    DLLGeneralTippaniDetail.AddDeputationTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Punishment) //6. punishment tippani
                {
                    DLLGeneralTippaniDetail.AddPunishmentTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Award) //7. award tippani
                {
                    DLLGeneralTippaniDetail.AddAwardTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }
                else if (subject == TippaniSubject.Committee) //8. committee tippani
                {
                    DLLGeneralTippaniDetail.AddCommitteeTippaniDetail(lst, tran, tippaniSubjectID, subject, tippaniID);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetLeaveTippaniDetail(int orgID, int tippaniID, int tippaniProcessID, LeaveMode mode)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetLeaveTippaniDetail(orgID, tippaniID, tippaniProcessID, mode);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["Emp_ID"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.ApplicationDate = row["APPL_DATE"].ToString();
                    tippani.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                    tippani.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                    tippani.ReqFromDate = row["REQ_FROM_DATE"].ToString();
                    tippani.ReqToDate = row["REQ_TO_DATE"].ToString();
                    tippani.ReqNoOfDays = row["REQ_NO_OF_DAYS"].ToString() == "" ? 0 : int.Parse(row["REQ_NO_OF_DAYS"].ToString());
                    tippani.ReqReason = row["REQ_REASON"].ToString();
                    tippani.RecBy = row["REC_BY"].ToString() == "" ? 0 : double.Parse(row["REC_BY"].ToString());
                    tippani.RecDate = row["REC_DATE"].ToString();
                    tippani.RecFromDate = row["REC_FROM_DATE"].ToString();
                    tippani.RecToDate = row["REC_TO_DATE"].ToString();
                    tippani.RecNoOfDays = row["REC_NO_OF_DAYS"].ToString() == "" ? 0 : int.Parse(row["REC_NO_OF_DAYS"].ToString());
                    tippani.RecYesNo = row["REC_YES_NO"].ToString();
                    tippani.RecReason = row["REC_REASON"].ToString();
                    tippani.AppBy = row["APP_BY"].ToString() == "" ? 0 : double.Parse(row["APP_BY"].ToString());
                    tippani.AppDate = row["APP_DATE"].ToString();
                    tippani.AppFromDate = row["APP_FROM_DATE"].ToString();
                    tippani.AppToDate = row["APP_TO_DATE"].ToString();
                    tippani.AppNoOfDays = row["APP_NO_OF_DAYS"].ToString() == "" ? 0 : int.Parse(row["APP_NO_OF_DAYS"].ToString());
                    tippani.AppYesNo = row["APP_YES_NO"].ToString();
                    tippani.AppReason = row["APP_REASON"].ToString();
                    tippani.LeaveFY = row["LEAVE_FY"].ToString();
                    tippani.LeavePeriodUnit = row["LEAVE_PERIOD_UNIT"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetVisitTippaniDetail(int orgID, int tippaniID, int tippaniProcessID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetVisitTippaniDetail(orgID, tippaniID, tippaniProcessID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.VisitPurpose = row["purpose"].ToString();
                    tippani.VisitLocation = row["location"].ToString();
                    tippani.VisitCountryID = int.Parse(row["country"].ToString());
                    tippani.VisitCountryName = row["Country_nep_name"].ToString();
                    tippani.VisitFromDate = row["visit_from_date"].ToString();
                    tippani.VisitToDate = row["visit_to_date"].ToString();
                    tippani.VisitRemark = row["remarks"].ToString();
                    tippani.VisitVehicle = row["Vehicle"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetPostingTippaniDetail(int orgID, int tippaniID, int subjectID, int tippaniProcessID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetPostingTippaniDetail(orgID, tippaniID, subjectID, tippaniProcessID);
                foreach(DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    //tippani.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    //tippani.TippaniText = row["tippani_text"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    //tippani.Note = row["note"].ToString();
                    //tippani.Note = "";
                    tippani.PostOrgID = int.Parse(row["post_org_id"].ToString());
                    tippani.PostOrgName = row["post_org_name"].ToString();
                    tippani.DesID = int.Parse(row["des_id"].ToString());
                    tippani.PostDesName = row["post_des_name"].ToString();
                    tippani.PostingTypeID = int.Parse(row["posting_type_id"].ToString());
                    tippani.PostingTypeName = row["posting_type_name"].ToString();
                    tippani.CreatedDate = row["created_date"].ToString();
                    tippani.PostID = int.Parse(row["post_id"].ToString());
                    //tippani.PostName = row["post_name"].ToString();
                    //tippani.PostID = 0;
                    tippani.PostName = "";
                    tippani.FromDate = row["post_from_date"].ToString();
                    tippani.ToDate = row["POST_TO_DATE"].ToString();
                    tippani.JoiningDate = row["joining_date"].ToString();
                    tippani.DecisionDate = row["decision_date"].ToString();
                    tippani.LeaveDate = row["leave_date"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);

                    //tippani.ProcessStatus = (row["status"].ToString() == "") ? 0 : int.Parse(row["status"].ToString());
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetTrainingTippaniDetail(int orgID, int tippaniID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetTrainingTippaniDetail(orgID, tippaniID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.TrnSubject = row["trn_subject"].ToString();
                    tippani.TrnInstitutionID = int.Parse(row["trn_institution_ID"].ToString());
                    tippani.TrnInstitutionName = row["institution_name"].ToString();
                    tippani.TrnFromDate = row["trn_from_date"].ToString();
                    tippani.TrnToDate = row["trn_to_date"].ToString();
                    tippani.TrnRemark = row["trn_remark"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetDeputationTippaniDetail(int orgID, int tippaniID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetDeputationTippaniDetail(orgID, tippaniID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.DepToOrgID = int.Parse(row["dep_to_org_id"].ToString());
                    tippani.DepToOrgName = row["dep_to_org_name"].ToString();
                    tippani.DepFromDate = row["dep_from_date"].ToString();
                    tippani.DepDecisionDate = row["DEP_DECISION_DATE"].ToString();
                    tippani.DepLeaveDate = row["dep_leave_date"].ToString();
                    tippani.DepResponsibility = row["DEP_RESPONSIBLITY"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetPunishmentTippaniDetail(int orgID, int tippaniID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetPunishmentTippaniDetail(orgID, tippaniID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.Punishment = row["punishment"].ToString();
                    tippani.PunishmentDate = row["punishment_date"].ToString();
                    tippani.PunishmentRemark = row["pun_remark"].ToString();
                    tippani.Action = "N";
                    
                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniSummary> GetAwardTippaniDetail(int orgID, int tippaniID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetAwardTippaniDetail(orgID, tippaniID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.Award = row["award"].ToString();
                    tippani.AwardDate = row["award_date"].ToString();
                    tippani.AwardRemark = row["awd_remark"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTGeneralTippaniSummary> GetCommitteeTippaniDetail(int orgID, int tippaniID)
        {
            List<ATTGeneralTippaniSummary> lst = new List<ATTGeneralTippaniSummary>();

            try
            {
                DataTable tbl = DLLGeneralTippaniDetail.GetCommitteeTippaniDetail(orgID, tippaniID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniSummary tippani = new ATTGeneralTippaniSummary();

                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.EmpID = double.Parse(row["emp_id"].ToString());
                    tippani.OrgName = row["org_name"].ToString();
                    tippani.DesName = row["des_name"].ToString();
                    tippani.EmpName = row["p_name"].ToString();
                    tippani.CommitteeOrgID = int.Parse(row["comm_org_id"].ToString());
                    tippani.CommitteeID = int.Parse(row["committee_ID"].ToString());
                    tippani.CommitteeOrgName = row["comm_org_name"].ToString();
                    tippani.CommitteeName = row["COMMITTEE_NAME"].ToString();
                    tippani.Action = "N";

                    lst.Add(tippani);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}