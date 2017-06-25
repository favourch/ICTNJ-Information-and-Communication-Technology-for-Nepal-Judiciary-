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
    public class BLLEmployeeLeaveApprove
    {
        public static bool LeaveApprove(ATTEmployeeLeave objEmpLeave)
        {
            try
            {
                return DLLEmployeeLeaveApprove.LeaveApprove(objEmpLeave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTEmployeeLeave> LeaveCheck(ATTEmployeeLeave objEmpLeave)
        {
            List<ATTEmployeeLeave> lstEmpLeaveApp = new List<ATTEmployeeLeave>();
            try
            {
                //foreach (ATTLeaveTypeEmployee var in LSTEmpLeave)
                //{
                foreach (DataRow drow in DLLEmployeeLeaveApprove.LeaveCheck(objEmpLeave).Rows)
                    {
                        ATTEmployeeLeave objEmpAppCheck = new ATTEmployeeLeave();

                        objEmpAppCheck.OutMessage = drow["Out_Message"].ToString();
                        objEmpAppCheck.PeriodType = drow["Period_Type"].ToString();
                        objEmpAppCheck.PeriodCount = int.Parse(drow["Period_Count"].ToString());
                        objEmpAppCheck.PFY = drow["Fiscal_Year"].ToString();
                       

                        //if (objEmpAppCheck.OutMessage == "OK")
                        //{
                        //    get_ok(objEmpAppCheck.PeriodCount, objEmpAppCheck.PFY, objEmpAppCheck.PeriodType);
                        //}

                        lstEmpLeaveApp.Add(objEmpAppCheck);
                    }
                //}
                
                return lstEmpLeaveApp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeeLeave> GetaApprovedLeave( string fromdate, string todate,int orgid,int desid)
        {
            List<ATTEmployeeLeave> LSTApprovedLeaves = new List<ATTEmployeeLeave>();
            try
            {
                foreach (DataRow row in DLLEmployeeLeaveApprove.GetApprovedLeaves(fromdate, todate, orgid, desid).Rows)
                {
                    ATTEmployeeLeave objEmpApprLeaves = new ATTEmployeeLeave();
                    objEmpApprLeaves.EmpID=int.Parse(row["EMP_ID"].ToString());
                    objEmpApprLeaves.EmpFullName = row["EMPFULLNAME"].ToString();
                    //objEmpApprLeaves.AppTo=row["TO_DATE"].ToString();
                    objEmpApprLeaves.ApprovedLeaves = row["EMP_APPR_LEAVE"].ToString();
                    LSTApprovedLeaves.Add(objEmpApprLeaves);
                }
                return LSTApprovedLeaves;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
    }
}

