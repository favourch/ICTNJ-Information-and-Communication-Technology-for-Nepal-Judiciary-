using System;
using System.Collections.Generic;
using System.Text;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeePosting
    {
        public static List<ATTEmployeePosting> GetEmpPosting(double empID)
        {
            ATTEmployee emp = new ATTEmployee();
            object obj;
            try
            {
                obj = DLLEmployee.GetConnection();
                emp.LstEmployeePosting = BLLEmployeePosting.GetEmployeePosting(obj, empID);
                return emp.LstEmployeePosting;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DLLEmployee.CloseConnection();
            }
        }

        public static List<ATTEmployeePosting> GetEmployeePosting(object obj, double empID)
        {
            try
            {
                List<ATTEmployeePosting> PostingList = new List<ATTEmployeePosting>();
                foreach (DataRow row in DLLEmployeePosting.GetEmployeePosting(empID,obj).Rows)
                {
                    ATTEmployeePosting Posting = new ATTEmployeePosting
                        (
                        double.Parse(row["EMP_ID"].ToString()),
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        (row["CREATED_DATE"] == System.DBNull.Value ? "" : (string)row["CREATED_DATE"]),
                        int.Parse(row["POST_ID"].ToString()),
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        int.Parse(row["POSTING_TYPE_ID"].ToString()),
                        ""
                        );

                    Posting.OrgName = (row["ORG_NAME"] == System.DBNull.Value ? "" : (string)row["ORG_NAME"]);
                    Posting.DesName = (row["DES_NAME"] == System.DBNull.Value ? "" : (string)row["DES_NAME"]);
                    Posting.PostName = (row["POST_NAME"] == System.DBNull.Value ? "" : (string)row["POST_NAME"]);
                    Posting.PostingTypeName = (row["POSTING_TYPE_NAME"] == System.DBNull.Value ? "" : (string)row["POSTING_TYPE_NAME"]);
                    Posting.ToDate = (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]);
                    Posting.JoiningDate = (row["JOINING_DATE"] == System.DBNull.Value ? "" : (string)row["JOINING_DATE"]);
                    Posting.DecisionDate = (row["DECISION_DATE"] == System.DBNull.Value ? "" : (string)row["DECISION_DATE"]);
                    Posting.LeaveDate = (row["LEAVE_DATE"] == System.DBNull.Value ? "" : (string)row["LEAVE_DATE"]);
                    if (row["SALARY"].ToString() != "")
                    {
                        Posting.EmpSalary = int.Parse(row["SALARY"].ToString());
                    }
                    if (row["ALLOWANCE"].ToString() != "")
                    {
                        Posting.EmpAllowance = int.Parse(row["ALLOWANCE"].ToString());
                    }
                    Posting.EmpKitaabDartaNo = (row["KITAAB_DARTAA_NO"] == System.DBNull.Value ? "" : (string)row["KITAAB_DARTAA_NO"]);
                    Posting.EmpPostingRemarks = (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]);
                    Posting.PostingAttachmentDocs = row["ATTACHMENT"] as byte[];
                    Posting.PostingAttachmentContent = (row["ATTACHMENT_FILE_NAME"] == System.DBNull.Value ? "" : (string)row["ATTACHMENT_FILE_NAME"]);
                    Posting.EntryBy = "";
                    PostingList.Add(Posting);
                }
                return PostingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeePosting> GetEmployeeAllPosting(object obj, double empID)
        {
            try
            {
                List<ATTEmployeePosting> PostingList = new List<ATTEmployeePosting>();
                foreach (DataRow row in DLLEmployeePosting.GetEmployeeAllPosting(empID, obj).Rows)
                {
                    ATTEmployeePosting Posting = new ATTEmployeePosting
                        (
                        double.Parse(row["EMP_ID"].ToString()),
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DES_ID"].ToString()),
                        (row["CREATED_DATE"] == System.DBNull.Value ? "" : (string)row["CREATED_DATE"]),
                        int.Parse(row["POST_ID"].ToString()),
                        (row["FROM_DATE"] == System.DBNull.Value ? "" : (string)row["FROM_DATE"]),
                        int.Parse(row["POSTING_TYPE_ID"].ToString()),
                        ""
                        );

                    Posting.OrgName = (row["ORG_NAME"] == System.DBNull.Value ? "" : (string)row["ORG_NAME"]);
                    Posting.DesName = (row["DES_NAME"] == System.DBNull.Value ? "" : (string)row["DES_NAME"]);
                    Posting.PostName = (row["POST_NAME"] == System.DBNull.Value ? "" : (string)row["POST_NAME"]);
                    Posting.PostingTypeName = (row["POSTING_TYPE_NAME"] == System.DBNull.Value ? "" : (string)row["POSTING_TYPE_NAME"]);
                    Posting.ToDate = (row["TO_DATE"] == System.DBNull.Value ? "" : (string)row["TO_DATE"]);
                    Posting.JoiningDate = (row["JOINING_DATE"] == System.DBNull.Value ? "" : (string)row["JOINING_DATE"]);
                    Posting.DecisionDate = (row["DECISION_DATE"] == System.DBNull.Value ? "" : (string)row["DECISION_DATE"]);
                    Posting.LeaveDate = (row["LEAVE_DATE"] == System.DBNull.Value ? "" : (string)row["LEAVE_DATE"]);
                    if (row["SALARY"].ToString() != "")
                    {
                        Posting.EmpSalary = int.Parse(row["SALARY"].ToString());
                    }
                    if (row["ALLOWANCE"].ToString() != "")
                    {
                        Posting.EmpAllowance = int.Parse(row["ALLOWANCE"].ToString());
                    }
                    Posting.EmpKitaabDartaNo = (row["KITAAB_DARTAA_NO"] == System.DBNull.Value ? "" : (string)row["KITAAB_DARTAA_NO"]);
                    Posting.EmpPostingRemarks = (row["REMARKS"] == System.DBNull.Value ? "" : (string)row["REMARKS"]);
                    Posting.PostingAttachmentDocs = row["ATTACHMENT"] as byte[];
                    Posting.PostingAttachmentContent = (row["ATTACHMENT_FILE_NAME"] == System.DBNull.Value ? "" : (string)row["ATTACHMENT_FILE_NAME"]);
                    Posting.EntryBy = "";
                    PostingList.Add(Posting);
                }
                return PostingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTEmployeePosting GetEmployeeCurrentPosting(double empID)
        {       
            try
            {
                string val= DLLEmployeePosting.GetEmployeeCurrentPosting(empID);
                int i = val.IndexOf(" ");
                String desgID = val.Substring(0, i + 1);

                ATTEmployeePosting OBJ = new ATTEmployeePosting();
                OBJ.DesID = int.Parse(desgID);
                OBJ.DesName = val.Substring( i ,val.Length-1);
                return OBJ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeePosting> GetEmployeePostingHistory(int empID,int? orgID)
        {
            try
            {
                List<ATTEmployeePosting> lst = new List<ATTEmployeePosting>();

                DataTable tbl = new DataTable();
                tbl = DLLEmployeePosting.GetEmployeePostingHistory(empID,orgID);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTEmployeePosting obj = new ATTEmployeePosting();

                    obj.EmpID = int.Parse(row["EMP_ID"].ToString());
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.DesID = int.Parse(row["DES_ID"].ToString());
                    obj.DesName = row["DES_NAME"].ToString();
                    obj.PostingTypeID = int.Parse(row["POSTING_TYPE_ID"].ToString());
                    obj.PostingTypeName = row["POSTING_TYPE_NAME"].ToString();
                    obj.FromDate = row["FROM_DATE"].ToString();
                    obj.CreatedDate = row["CREATED_DATE"].ToString();
                    obj.PostID = int.Parse(row["POST_ID"].ToString());
                    //obj.FromDate = row["FROM_DATE"].ToString();
                    lst.Add(obj);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ATTEmployeePosting> GetEmployeeWithPostingList(int? orgID)
        {
            try
            {
                List<ATTEmployeePosting> lst = new List<ATTEmployeePosting>();

                DataTable tbl = new DataTable();
                tbl = DLLEmployeePosting.GetEmployeeWithPostingListTable(orgID);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTEmployeePosting obj = new ATTEmployeePosting();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.EmpID = int.Parse(row["P_ID"].ToString());
                    obj.EmpName = row["FIRST_NAME"].ToString() + " " +
                                  (row["MID_NAME"].ToString() == "" ? "" : row["MID_NAME"].ToString()) + " " +
                                  (row["SUR_NAME"].ToString() == "" ? "" : row["SUR_NAME"].ToString());
                    obj.DesID = int.Parse(row["DES_ID"].ToString());
                    obj.DesName = row["DES_NAME"].ToString();


                    lst.Add(obj);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static ATTEmployeePosting GetEmployeeCurrentPostingAllInfo(double empID)
        {

            try
            {
                string val = DLLEmployeePosting.GetEmployeeCurrentPostingAllInfo(empID);

                string[] arr = val.Split('#');

                ATTEmployeePosting obj = new ATTEmployeePosting();
                obj.OrgID = int.Parse(arr[0].ToString());// returns organization ID 
                obj.OrgName = arr[1].ToString();    
                obj.DesID = int.Parse(arr[2].ToString());
                obj.DesName = arr[3].ToString();
                obj.CreatedDate = arr[4].ToString();
                obj.PostID = int.Parse(arr[5].ToString());
                obj.PostName = arr[6].ToString();
                obj.FromDate = arr[7].ToString();
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
