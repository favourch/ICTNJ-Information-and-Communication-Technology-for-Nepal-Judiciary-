using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLGeneralTippaniDetail
    {
        public static bool AddLeaveTippaniDetail
            (
                List<ATTGeneralTippaniDetail> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {

            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        SP = DLLGeneralTippaniDetail.GetLeaveLevelSP(detail.LeaveLevel, detail.Action);
                        paramArray = DLLGeneralTippaniDetail.GetLeaveLevelSpParameter(detail, tippaniID);

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddLeaveTippaniDetail
            (
                List<ATTGeneralTippaniSummary> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {

            string SP;
            List<OracleParameter> paramArray;

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        SP = DLLGeneralTippaniDetail.GetLeaveLevelSP(detail.LeaveLevel, detail.Action);
                        paramArray = DLLGeneralTippaniDetail.GetLeaveLevelSpParameter(detail, tippaniID);

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetLeaveLevelSP(LeaveMode mode, string action)
        {
            string sp = "";

            if (mode == LeaveMode.Request)
            {
                if (action == "A")
                    sp = "SP_ADD_LEAVE_REQUEST_DETAIL";
                else if (action == "E")
                    sp = "SP_EDIT_LEAVE_TIPPANI_DETAIL";
                else if (action == "D")
                    sp = "sp_del_tippani_detail";
            }
            else if (mode == LeaveMode.Recommend)
                sp = "SP_UP_LEAVE_TIPPANI_DETAIL_REC";
            else if (mode == LeaveMode.Approve)
                sp = "SP_UP_LEAVE_TIPPANI_DETAIL_APP";
            
            return sp;
        }

        private static List<OracleParameter> GetLeaveLevelSpParameter(ATTGeneralTippaniDetail detail, int tippaniID)
        {
            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (detail.LeaveLevel == LeaveMode.Request)
            {
                paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                if (detail.Action != "D")
                {
                    paramArray.Add(Utilities.GetOraParam("P_APPL_DATE", detail.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LEAVE_TYPE_ID", detail.LeaveTypeID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REQ_FROM_DATE", detail.ReqFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REQ_TO_DATE", detail.ReqToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REQ_NO_OF_DAYS", detail.ReqNoOfDays, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REQ_REASON", detail.ReqReason, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LEAVE_ENTRY_BY", detail.LeaveEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LEAVE_ENTRY_DATE", detail.LeaveEntryOn, OracleDbType.Date, ParameterDirection.Input));
                }
            }
            else if (detail.LeaveLevel == LeaveMode.Recommend)
            {
                paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", detail.TippaniID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_BY", detail.RecBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_DATE", detail.RecDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_FROM_DATE", detail.RecFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_TO_DATE", detail.RecToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_NO_OF_DAYS", detail.RecNoOfDays, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_YES_NO", detail.RecYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_REC_REASON", detail.RecReason, OracleDbType.Varchar2, ParameterDirection.Input));
            }
            else if (detail.LeaveLevel == LeaveMode.Approve)
            {
                paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", detail.TippaniID, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_BY", detail.AppBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_DATE", detail.AppDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_FROM_DATE", detail.AppFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_TO_DATE", detail.AppToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_NO_OF_DAYS", detail.AppNoOfDays, OracleDbType.Int16, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_YES_NO", detail.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_APP_REASON", detail.AppReason, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            return paramArray;
        }

        public static bool AddVisitTippaniDetail
            (
                List<ATTGeneralTippaniDetail> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {

            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_VISIT_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_VISIT_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "SP_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        //paramArray.Add(Utilities.GetOraParam("P_TIPPANI_SNO", detail.TippaniSNO, OracleDbType.Int16, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_PURPOSE", detail.VisitPurpose, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_LOCATION", detail.VisitLocation, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_COUNTRY", detail.VisitCountryID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_VISIT_FROM_DATE", detail.VisitFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_VISIT_TO_DATE", detail.VisitToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_VEHICLE", detail.VisitVehicle, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_REMARKS", detail.VisitRemark, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_VISIT_ENTRY_BY", detail.VisitEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_VISIT_ENTRY_DATE", detail.VisitEntryOn, OracleDbType.Date, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());
                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddPostingTippaniDetail
            (
                List<ATTGeneralTippaniDetail> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {

            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            
            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_POSTING_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_POSTING_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "sp_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        //paramArray.Add(Utilities.GetOraParam("P_TIPPANI_SNO", detail.TippaniSNO, OracleDbType.Int16, ParameterDirection.InputOutput));
                        if (detail.Action == "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        }
                        else
                        {
                            paramArray.Add(Utilities.GetOraParam("P_POST_ORG_ID", detail.PostOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DES_ID", detail.DesID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_CREATED_DATE", detail.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_ID", detail.PostID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_FROM_DATE", detail.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_TO_DATE", detail.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_JOINING_DATE", detail.JoiningDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DECISION_DATE", detail.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_LEAVE_DATE", detail.LeaveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POSTING_TYPE_ID", detail.PostingTypeID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POSTING_CLASS", "", OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_ENTRY_BY", detail.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_ENTRY_DATE", DateTime.Now, OracleDbType.Date, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());

                        paramArray.Clear();
                        if (detail.Action == "D")
                        {
                            SP = "sp_reset_post_occupied_tippani";
                            
                            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.PostOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DES_ID", detail.DesID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_CREATED_DATE", detail.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_ID", detail.PostID, OracleDbType.Int32, ParameterDirection.Input));
                           
                            SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                            paramArray.Clear();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddTrainingTippaniDetail
            (
                List<ATTGeneralTippaniDetail> lst,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID
            )
        {

            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_TRAINING_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_TRN_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "sp_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_TRN_SUBJECT", detail.TrnSubject, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_INSTITUTION_ID", detail.TrnInstitutionID, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_TRN_FROM_DATE", detail.TrnFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_TRN_TO_DATE", detail.TrnToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_TRN_REMARKS", detail.TrnRemark, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_TRN_ENTRY_BY", detail.TrnEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddDeputationTippaniDetail
        (
            List<ATTGeneralTippaniDetail> lst,
            object tran,
            int tippaniSubjectID,
            TippaniSubject subject,
            int tippaniID
        )
        {

            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_DEP_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_DEP_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "sp_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_DEP_ORG_ID", detail.DepOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DES_ID", detail.DepDesID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_CREATED_DATE", detail.DepCreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_POST_ID", detail.DepPostID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", detail.DepFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DECISION_DATE", detail.DepDecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DEP_TO_ORG_ID", detail.DepToOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_LEAVE_DATE", detail.DepLeaveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_RESPONSIBILITY", detail.DepResponsibility, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", detail.DepEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddPunishmentTippaniDetail
        (
            List<ATTGeneralTippaniDetail> lst,
            object tran,
            int tippaniSubjectID,
            TippaniSubject subject,
            int tippaniID
        )
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_PUN_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_PUN_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "sp_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_PUNISHMENT", detail.Punishment, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_PUN_DATE", detail.PunishmentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_PUN_REMARK", detail.PunishmentRemark, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", detail.PunEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddAwardTippaniDetail
        (
            List<ATTGeneralTippaniDetail> lst,
            object tran,
            int tippaniSubjectID,
            TippaniSubject subject,
            int tippaniID
        )
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "SP_ADD_AWARD_TIPPANI_DETAIL";
                        else if (detail.Action == "E")
                            SP = "SP_EDIT_AWARD_TIPPANI_DETAIL";
                        else if (detail.Action == "D")
                            SP = "SP_del_tippani_detail";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_AWARD", detail.Award, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_AWARD_DATE", detail.AwardDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_AWD_REMARK", detail.AwardRemark, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", detail.AwdEntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddCommitteeTippaniDetail
        (
            List<ATTGeneralTippaniDetail> lst,
            object tran,
            int tippaniSubjectID,
            TippaniSubject subject,
            int tippaniID
        )
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTGeneralTippaniDetail detail in lst)
                {
                    if (detail.Action != "N")
                    {
                        if (detail.Action == "A")
                            SP = "sp_add_comm_by_tippani_detail";
                        else if (detail.Action == "E")
                            SP = "";
                        else if (detail.Action == "D")
                            SP = "SP_DEL_TIPPANI_DETAIL";

                        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", detail.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("p_com_org_id", detail.CommitteeOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_committee_id", detail.CommitteeID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", detail.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        //detail.TippaniSNO = int.Parse(paramArray[2].Value.ToString());

                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static DataTable GetLeaveTippaniDetail(int orgID, int tippaniID, int tippaniProcessID, LeaveMode mode)
        {
            string SP = "sp_GET_LEAVE_TIPPANI_DETAIL";

            string status = null;
            if (mode == LeaveMode.Approve)
                status = "Y";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tipani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_LEAVE_MODE,", null, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetVisitTippaniDetail(int orgID, int tippaniID, int tippaniProcessID)
        {
            string SP = "SP_GET_VISIT_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tipani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PRC_ID", tippaniProcessID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPostingTippaniDetail(int orgID, int tippaniID, int subjectID, int tippaniProcessID)
        {
            string SP = "SP_GET_POSTING_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tipani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_SUBJETC_ID", subjectID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PRC_ID", tippaniProcessID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTrainingTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "SP_GET_TRAINING_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDeputationTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "SP_GET_DEP_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPunishmentTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "SP_GET_PUN_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAwardTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "SP_GET_AWARD_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCommitteeTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "SP_GET_COMM_TIPPANI_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}