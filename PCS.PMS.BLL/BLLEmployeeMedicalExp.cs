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
    public class BLLEmployeeMedicalExp
    {
        public static List<ATTEmployeeMedicalExp> GetEmployeeMedicalExp(double? empID)
        {
            List<ATTEmployeeMedicalExp> lst = new List<ATTEmployeeMedicalExp>();
            try
            {
                foreach (DataRow row in DLLEmployeeMedicalExp.GetEmployeeMedicalExp(empID).Rows)
                {
                    double? dblAmountTaken = null;
                    if (row["AMOUNT_TAKEN"]!=System.DBNull.Value)
                        dblAmountTaken=double.Parse(row["AMOUNT_TAKEN"].ToString());
                    ATTEmployeeMedicalExp obj = new ATTEmployeeMedicalExp
                        (
                        double.Parse(row["EMP_ID"].ToString()),
                        int.Parse(row["SEQ_NO"].ToString()),
                        (row["PARTICULARS"] == System.DBNull.Value ? "" : (string)row["PARTICULARS"]),
                        (row["DATE_TAKEN"] == System.DBNull.Value ? "" : (string)row["DATE_TAKEN"]),
                        dblAmountTaken);
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveEmployeeMedicalExp(List<ATTEmployeeMedicalExp> lstEmployeeMedicalExp)
        {
            try
            {
                return DLLEmployeeMedicalExp.SaveEmployeeMedicalExp(lstEmployeeMedicalExp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}