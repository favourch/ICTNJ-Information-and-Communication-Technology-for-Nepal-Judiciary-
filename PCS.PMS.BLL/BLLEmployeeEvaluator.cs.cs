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
    public class BLLEmployeeEvaluator
    {
        public static List<ATTEmployeeEvaluator> GetEmployeeEvaluationList(double empID, string fromDate)
        {
            List<ATTEmployeeEvaluator> lst = new List<ATTEmployeeEvaluator>();
            try
            {
                foreach (DataRow row in DLLEmployeeEvaluator.GetEmployeeEvaluator(empID, fromDate).Rows)
                {
                    ATTEmployeeEvaluator obj = new ATTEmployeeEvaluator();

                    obj.EmpID = double.Parse(row["emp_id"].ToString());
                    obj.EvalFromDate = row["eval_from_date"].ToString();
                    obj.GroupID = int.Parse(row["eval_group_id"].ToString());
                    obj.GroupName = row["eval_group_name"].ToString();
                    obj.PersonID = double.Parse(row["person_id"].ToString());
                    obj.PersonName = row["P_NAME"].ToString();
                    obj.Designation = row["designation"].ToString();
                    obj.SymbolNo = double.Parse(row["symbol_no"].ToString());
                    obj.Date = row["eval_date"].ToString();
                    obj.Remark = row["remarks"].ToString();
                    obj.EntryBy = row["entry_by"].ToString();
                    obj.Action = "N";

                    lst.Add(obj);
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
