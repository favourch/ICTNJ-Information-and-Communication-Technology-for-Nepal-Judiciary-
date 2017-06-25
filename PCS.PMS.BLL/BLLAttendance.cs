using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLAttendance
    {
        public static List<ATTAttendance> GetEmpAttendance(int orgid,int desid,string yearmonth)
        {
            List<ATTAttendance> LSTAttendacne = new List<ATTAttendance>();
            try
            {
                foreach(DataRow row in DLLAttendance.GetEmpAttendance(orgid,desid,yearmonth).Rows)
                {
                    ATTAttendance objEmpAttendance=new ATTAttendance();
                    objEmpAttendance.OrgID = int.Parse(row["EMP_ID"].ToString());
                    objEmpAttendance.OrgName = row["ORG_NAME"].ToString();
                    objEmpAttendance.DesID = int.Parse(row["DES_ID"].ToString());
                    objEmpAttendance.DesName = row["DES_NAME"].ToString();
                    objEmpAttendance.EmpID = double.Parse(row["EMP_ID"].ToString());
                    objEmpAttendance.EmpFullName = row["EMPLOYEE_NAME"].ToString();
                    objEmpAttendance.LogDate = row["LOGDATE"].ToString();
                    objEmpAttendance.PresentDate = row["PRESENT_DATE"].ToString();
                    LSTAttendacne.Add(objEmpAttendance);
                }
                return LSTAttendacne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
