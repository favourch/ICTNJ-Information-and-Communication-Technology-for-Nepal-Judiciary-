using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLGeneralTippani
    {
        public static System.Drawing.Color GetActionColor(string action)
        {
            System.Drawing.Color col = new System.Drawing.Color();
            
            if (action == "A")
                col = System.Drawing.Color.Green;
            else if (action == "E" || action == "N")
                col = System.Drawing.Color.Blue;
            else if (action == "D")
                col = System.Drawing.Color.Red;

            return col;
        }

        public static ATTGeneralTippani GetTippaniDetail(int orgID, int tippaniID)
        {
            try
            {
                ATTGeneralTippani tippani = new ATTGeneralTippani();
                DataTable tbl = DLLGeneralTippani.GetTippaniDetail(orgID, tippaniID);
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];
                    tippani.OrgID = int.Parse(row["org_id"].ToString());
                    tippani.TippaniID = int.Parse(row["tippani_id"].ToString());
                    tippani.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    tippani.TippaniText = row["tippani_text"].ToString();
                    tippani.FileNo = int.Parse(row["file_no"].ToString());
                    tippani.FinalStatus = int.Parse(row["final_status"].ToString());
                    tippani.PriorityID = int.Parse(row["priority_id"].ToString());
                }

                return tippani;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetDateDifference(string NepaliToDate, string NepaliFromDate)
        {
            try
            {
                return DLLGeneralTippani.GetDateDifference(NepaliToDate, NepaliFromDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddGeneralTippani(ATTGeneralTippani tippani)
        {
            object conn;
            object tran;

            try
            {
                conn = DLLGeneralTippani.GetConnection();
                tran = DLLGeneralTippani.BeginTransaction(conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                DLLGeneralTippani.AddGeneralTippani(tippani, tran);

                if (tippani.Committee != null)
                {
                    BLLCommitteeByTippani.AddCommitteeByTippani(tippani.Committee, tran, tippani.TippaniSubjectID, tippani.TippaniName, tippani.TippaniID);
                    foreach (ATTGeneralTippaniDetail d in tippani.LstTippaniDetail)
                    {
                        d.CommitteeID = tippani.Committee.CommitteeID;
                    }
                }

                if (tippani.LstTippaniDetail.Count > 0)
                    BLLGeneralTippaniDetail.AddGeneralTippaniDetail(tippani.LstTippaniDetail, tran, tippani.TippaniSubjectID, tippani.TippaniName, tippani.TippaniID);

                if (tippani.LstTippaniProcess.Count > 0)
                    BLLGeneralTippaniProcess.AddGeneralTippaniProcessDetail(tippani.LstTippaniProcess, tran, tippani.TippaniSubjectID, tippani.TippaniName, tippani.TippaniID);

                if (tippani.LstTippaniAttachment.Count > 0)
                    BLLGeneralTippaniAttachment.AddAttachment(tippani.LstTippaniAttachment, tran, tippani.TippaniSubjectID, tippani.TippaniName, tippani.TippaniID, tippani.LstTippaniProcess[0].TippaniProcessID);

                DLLGeneralTippani.CommitTransaction(tran);
                return true;
            }
            catch (Exception ex)
            {
                DLLGeneralTippani.RollbackTransaction(tran);
                throw ex;
            }
            finally
            {
                DLLGeneralTippani.CloseConnection(conn);
            }
        }

        public static List<ATTGeneralTippaniRequestInfo> GetGeneralTippaniInfo(ATTGeneralTippaniRequestInfo info, int sIndex, int eIndex, ref decimal totalRecord)
        {
            List<ATTGeneralTippaniRequestInfo> lst = new List<ATTGeneralTippaniRequestInfo>();
            try
            {
                foreach (DataRow row in DLLGeneralTippani.GetGeneralTippaniInfo(info, sIndex, eIndex, ref totalRecord).Rows)
                {
                    ATTGeneralTippaniRequestInfo obj = new ATTGeneralTippaniRequestInfo();

                    obj.OrgID = int.Parse(row["org_id"].ToString());
                    obj.TippaniID = int.Parse(row["tippani_id"].ToString());
                    obj.ProcessBy = row["p_name"].ToString();
                    obj.ProcessByID = int.Parse(row["emp_id"].ToString());
                    obj.TippaniStatusName = row["tippani_status_name"].ToString();
                    obj.ProcessOn = row["tippani_on"].ToString();

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTUnreadTippani> GetUnreadTippani(double empID, int subjectID)
        {
            List<ATTUnreadTippani> lst = new List<ATTUnreadTippani>();
            try
            {
                DataTable tbl = DLLGeneralTippani.GetUnreadTippani(empID, subjectID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTUnreadTippani mail = new ATTUnreadTippani();
                    mail.EmpID = double.Parse(row["emp_id"].ToString());
                    mail.TippaniName = row["TIPPANI_SUBJECT_NAME"].ToString();
                    mail.SubjectID = int.Parse(row["TIPPANI_SUBJECT_ID"].ToString());
                    mail.Number = int.Parse(row["number"].ToString());

                    lst.Add(mail);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
