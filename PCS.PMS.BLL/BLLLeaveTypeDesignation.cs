using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;



namespace PCS.PMS.BLL
{
    public class BLLLeaveTypeDesignation
    {

        public static List<ATTLeaveTypeDesignation> GetLeaveTypeDesignation(int? leaveTypeID, int? designationID)
        {
            List<ATTLeaveTypeDesignation> lstLeavetypeDesignation = new List<ATTLeaveTypeDesignation>();

            try
            {
                foreach (DataRow row in DLLLeaveTypeDesignation.GetLeaveTypeDesignation(leaveTypeID, designationID).Rows)
                {
                    ATTLeaveTypeDesignation ObjAtt = new ATTLeaveTypeDesignation();

                    ObjAtt.LeaveTypeID = int.Parse(row["LEAVE_TYPE_ID"].ToString());
                    ObjAtt.LeaveType = row["LEAVE_TYPE_NAME"].ToString();
                    ObjAtt.DesignationID = int.Parse(row["DES_ID"].ToString());
                    ObjAtt.Days = int.Parse(row["NO_OF_DAYS"].ToString());
                    ObjAtt.PeriodType = row["PERIOD_TYPE"].ToString();
                    if (row["PERIOD_TIMES"].ToString() != "")
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
                    //ObjAtt.EffectiveTillDate = DateTime.Parse(row["EFFECTIVE_TILL_DATE"].ToString());
                    //ObjAtt.EntryBy = row["ENTRY_BY"].ToString();
                    //ObjAtt.EntryDate = row["ENTRY_DATE"].ToString();
                    ObjAtt.Action = "";
                    lstLeavetypeDesignation.Add(ObjAtt);
                }

                return lstLeavetypeDesignation;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool SaveLeaveTypeDesignation(List<ATTLeaveTypeDesignation> lstATT)
        {
            try
            {
                return DLLLeaveTypeDesignation.SaveLeaveTypeDesignation(lstATT);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
