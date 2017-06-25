using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
   public class BLLLeaveType
    {
        public static ObjectValidation Validate(ATTLeaveType ObjAtt)
        {
            ObjectValidation OV = new ObjectValidation();

            if (ObjAtt.LeaveTypeName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Leave Type Name cannot be Blank.";
                return OV;
            }


            return OV;
        }

        public static List<ATTLeaveType> GetLeaveType(int? LeaveTypeId, string active)
        {
            List<ATTLeaveType> lstLeaveType = new List<ATTLeaveType>();

            try
            {
                foreach (DataRow row in DLLLeaveType.GetLeaveType(LeaveTypeId, active).Rows)
                {
                    ATTLeaveType ObjAtt = new ATTLeaveType
                        (
                        int.Parse(row["LEAVE_TYPE_ID"].ToString()),
                        row["LEAVE_TYPE_NAME"].ToString(),
                        (string) row["GENDER"],
                        (row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"]
                        );
                    lstLeaveType.Add(ObjAtt);
                }
                return lstLeaveType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveLeaveType(ATTLeaveType ObjAtt)
        {
            try
            {
                return DLLLeaveType.SaveLeaveType(ObjAtt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       public static bool DeleteLeaveType(int LeaveTypeID)
        {
            try
            {
                return DLLLeaveType.DeleteLeaveType(LeaveTypeID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
