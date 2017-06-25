using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLInsurance
    {
        public static List<ATTInsurance> GetEmpInsurance(double empID)
        {
            try
            {
                List<ATTInsurance> LSTInsurance = new List<ATTInsurance>();
                ATTInsurance objInsurance = new ATTInsurance();
                foreach (DataRow rw in DLLInsurance.GetEmpInsurance(empID).Rows)
                {
                    objInsurance.CompanyName = rw["COMPANY_NAME"].ToString();
                    objInsurance.InsuranceNo = rw["INSURANCE_NO"].ToString();
                    objInsurance.FromDate = rw["FROM_DATE"].ToString();
                    objInsurance.MaturityDate = rw["MATURITY_DATE"].ToString();
                    LSTInsurance.Add(objInsurance);
                }
                return LSTInsurance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
