using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;
using PCS.COMMON;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeLeave
    {
        public static bool SaveEmpLeaveApplication(List<ATTEmployeeLeave> LSTEmployeeLeave)
        {
            try
            {
                return DLLEmployeeLeave.SaveEmpLeaveApplication(LSTEmployeeLeave);
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            
        }

        public static List<ATTEmployeeLeave> GetEmployeeLeave(int? empID, string REQ_REC_APP)
        {
            List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();

            try
            {
                if (REQ_REC_APP == "REQ")
                {
                    foreach (DataRow row in DLLEmployeeLeave.GetEmployeeLeave(empID, REQ_REC_APP).Rows)
                    {
                        ATTEmployeeLeave ObjAtt = new ATTEmployeeLeave();
                        ObjAtt.EmpID = int.Parse(row["EMP_ID"].ToString());
                        ObjAtt.EmpFullName = row["EMPLOYEENAME"].ToString();
                        ObjAtt.ApplDate = row["APPL_DATE"].ToString();
                        ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                        ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                        ObjAtt.ReqdFrom = row["REQ_FROM_DATE"].ToString();
                        ObjAtt.ReqdTo = row["REQ_TO_DATE"].ToString();
                        ObjAtt.EmpDays = int.Parse(row["REQ_NO_OF_DAYS"].ToString());
                        ObjAtt.EmpReason = row["REQ_REASON"].ToString();
                        //ObjAtt.EntryBy = row["ENTRY_BY"].ToString();
                        //ObjAtt.EntryDate = row["ENTRY_DATE"].ToString();
                        ObjAtt.Action = "";
                        lstEmployeeLeave.Add(ObjAtt);
                    }
                }
                else if (REQ_REC_APP == "REC")
                {
                    foreach (DataRow row in DLLEmployeeLeave.GetEmployeeLeave(empID, REQ_REC_APP).Rows)
                    {
                        ATTEmployeeLeave ObjAtt = new ATTEmployeeLeave();
                        ObjAtt.EmpID = int.Parse(row["EMP_ID"].ToString());
                        ObjAtt.EmpFullName = row["EMPLOYEENAME"].ToString();
                        ObjAtt.ApplDate = row["APPL_DATE"].ToString();
                        ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                        ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                        ObjAtt.ReqdFrom = row["REQ_FROM_DATE"].ToString();
                        ObjAtt.ReqdTo = row["REQ_TO_DATE"].ToString();
                        ObjAtt.EmpDays = int.Parse(row["REQ_NO_OF_DAYS"].ToString());
                        ObjAtt.EmpReason = row["REQ_REASON"].ToString();
                        ObjAtt.RecByName = row["RCMDNAME"].ToString();
                        ObjAtt.RecDate = row["REC_DATE"].ToString();
                        ObjAtt.RecFrom = row["REC_FROM_DATE"].ToString();
                        ObjAtt.RecTo = row["REC_TO_DATE"].ToString();
                        if (row["REC_NO_OF_DAYS"].ToString()==""){ObjAtt.RecDays = null;}
                        else ObjAtt.RecDays = int.Parse(row["REC_NO_OF_DAYS"].ToString());
                        ObjAtt.Recommended = row["REC_YES_NO"].ToString();
                        ObjAtt.RecReason = row["REC_REASON"].ToString();
                        ObjAtt.Action = "";
                        lstEmployeeLeave.Add(ObjAtt);
                    }
                }
                else if (REQ_REC_APP == "APP")
                {
                    foreach (DataRow row in DLLEmployeeLeave.GetEmployeeLeave(empID, REQ_REC_APP).Rows)
                    {
                        ATTEmployeeLeave ObjAtt = new ATTEmployeeLeave();
                        ObjAtt.EmpID = int.Parse(row["EMP_ID"].ToString());
                        ObjAtt.EmpFullName = row["EMPLOYEENAME"].ToString();
                        ObjAtt.ApplDate = row["APPL_DATE"].ToString();
                        ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                        ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                        ObjAtt.ReqdFrom = row["REQ_FROM_DATE"].ToString();
                        ObjAtt.ReqdTo = row["REQ_TO_DATE"].ToString();
                        ObjAtt.EmpDays = int.Parse(row["REQ_NO_OF_DAYS"].ToString());
                        ObjAtt.EmpReason = row["REQ_REASON"].ToString();

                        ObjAtt.RecByName = row["RCMDNAME"].ToString();
                        ObjAtt.RecDate = row["REC_DATE"].ToString();
                        ObjAtt.RecFrom = row["REC_FROM_DATE"].ToString();
                        ObjAtt.RecTo = row["REC_TO_DATE"].ToString();
                        if (row["REC_NO_OF_DAYS"].ToString() == "") { ObjAtt.RecDays = null; }
                        else ObjAtt.RecDays = int.Parse(row["REC_NO_OF_DAYS"].ToString());
                        ObjAtt.RecReason = row["REC_REASON"].ToString();
                        ObjAtt.Recommended = row["REC_YES_NO"].ToString();

                        ObjAtt.AppByName = row["APPNAME"].ToString();
                        ObjAtt.AppDate = row["APP_DATE"].ToString();
                        ObjAtt.AppFrom = row["APP_FROM_DATE"].ToString();
                        ObjAtt.AppTo = row["APP_TO_DATE"].ToString();
                        if (row["APP_NO_OF_DAYS"].ToString() == "") { ObjAtt.AppDays = null; }
                        else ObjAtt.AppDays = int.Parse(row["APP_NO_OF_DAYS"].ToString());
                        ObjAtt.Approved = row["APP_YES_NO"].ToString();
                        ObjAtt.AppReason = row["APP_REASON"].ToString();
                        ObjAtt.Action = "";
                        lstEmployeeLeave.Add(ObjAtt);
                    }
                }
                return lstEmployeeLeave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeeLeave> GetEmpDesLeave(int eid)
        {
            List<ATTEmployeeLeave> lstEmployeeLeave = new List<ATTEmployeeLeave>();
            try
            {
                foreach (DataRow row in DLLEmployeeLeave.GetEmpDesLeave(eid).Rows)
                {
                    ATTEmployeeLeave ObjAtt = new ATTEmployeeLeave();
                    ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                    ObjAtt.NoOfDays = int.Parse(row["NO_OF_DAYS"].ToString());
                    ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                    lstEmployeeLeave.Add(ObjAtt);
                }
                return lstEmployeeLeave;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
