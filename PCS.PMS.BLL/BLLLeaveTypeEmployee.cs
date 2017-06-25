using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLLeaveTypeEmployee
    {
        public static List<ATTLeaveTypeEmployee> GetLeaveTypeEmployee(int? leaveTypeID, int? empID)
        {
            List<ATTLeaveTypeEmployee> lstLeavetypeEmployee = new List<ATTLeaveTypeEmployee>();

            try
            {
                foreach (DataRow row in DLLLeaveTypeEmployee.GetLeaveTypeEmployee(leaveTypeID, empID).Rows)
                {
                    ATTLeaveTypeEmployee ObjAtt = new ATTLeaveTypeEmployee();

                    ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                    ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                    ObjAtt.EmpID = int.Parse(row["EMP_ID"].ToString());
                    ObjAtt.Days = int.Parse(row["NO_OF_DAYS"].ToString());
                    ObjAtt.PeriodType = row["PERIOD_TYPE"].ToString();
                    if (row["PERIOD_TIMES"].ToString()!="")
                    {
                        ObjAtt.PeriodTimes = int.Parse(row["PERIOD_TIMES"].ToString());                        
                    }
                    ObjAtt.IsAccural = (row["IS_ACCRUAL"].ToString() == "Y" ? true : false);
                    if (row["MAX_ACCRUAL_DAYS"].ToString() != "")
                    {
                        ObjAtt.AccuralDays = int.Parse(row["MAX_ACCRUAL_DAYS"].ToString());
                    }
                    ObjAtt.Active = (row["ACTIVE"].ToString() == "Y" ? true : false);
                    ObjAtt.EffectiveFromDate = row["FROM_DATE"].ToString();
                    //ObjAtt.EffectiveTillDate = DateTime.Parse(row["TO_DATE"].ToString());
                    //ObjAtt.EntryBy = row["ENTRY_BY"].ToString();
                    //ObjAtt.EntryDate = row["ENTRY_DATE"].ToString();
                    ObjAtt.Action = "";
                    lstLeavetypeEmployee.Add(ObjAtt);
                }

                return lstLeavetypeEmployee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool SaveLeaveTypeEmployee(List<ATTLeaveTypeEmployee> lstLeaveTypeEmployee)
        {
            try
            {
                return DLLLeaveTypeEmployee.SaveLeaveTypeEmployee(lstLeaveTypeEmployee);
            }
            catch (Exception ex)
            {
                throw ex;
               
            } 
            
        }
    }
}
