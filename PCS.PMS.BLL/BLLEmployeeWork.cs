using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.COMMON.BLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeWork
    {
        public static ObjectValidation Validate(ATTEmployeeWork obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.WorkDescription.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Work description cannot be empty.";
                return result;
            }

            if (obj.Unit.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Unit cannot be empty.";
                return result;
            }

            if (obj.HalfYearTarget.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Half year target cannot be empty.";
                return result;
            }

            if (obj.FullYearTarget.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Full year target cannot be empty.";
                return result;
            }

            if (obj.WorkProgress.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Work progress cannot be empty.";
                return result;
            }

            return result;
        }

        public static List<ATTEmployeeWork> GetEmployeeWork(double empID, string fromDate)
        {
            List<ATTEmployeeWork> workLst = new List<ATTEmployeeWork>();
            try
            {
                DataTable tbl = DLLEmployeeWork.GetEmployeeWork(empID, fromDate);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTEmployeeWork work = new ATTEmployeeWork();

                    work.EmpID = double.Parse(row["Emp_ID"].ToString());
                    work.EvalFromDate = row["Eval_from_date"].ToString();
                    work.WorkID = int.Parse(row["work_id"].ToString());
                    work.WorkDescription = row["work_description"].ToString();
                    work.Unit = row["unit"].ToString();
                    work.HalfYearTarget = row["half_year_target"].ToString();
                    work.FullYearTarget = row["full_year_target"].ToString();
                    work.WorkProgress = row["work_progress"].ToString();
                    work.AssignByOffice = row["assign_by_office"].ToString();
                    work.Remark = row["remarks"].ToString();
                    work.EntryBy = row["entry_by"].ToString();
                    work.EntryOn = DateTime.Parse(row["entry_on"].ToString());
                    work.Action = "E";

                    workLst.Add(work);
                }

                return workLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
