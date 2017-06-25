using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLEmployee
    {
        public static bool SaveEmployeeDetails(ATTEmployee objEmployee)
        {
            try
            {
                return DLLEmployee.SaveEmployeeDetails(objEmployee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static ATTEmployee GetEmployees(double empID,string symbolNo)
        {
            ATTEmployee emp=new ATTEmployee();
            object obj;
            try
            {
                obj = DLLEmployee.GetConnection();
                emp.LstEmployeeVisits = BLLEmployeeVisits.GetEmployeeVisits(obj, empID);
                emp.LstEmployeeExperience = BLLEmployeeExperience.GetEmployeeExperience(obj, empID);
                emp.LstEmployeePosting = BLLEmployeePosting.GetEmployeeAllPosting(obj, empID);
                //emp.LSTAttachments = BLLPersonAttachments.GetAttachments(obj, empID);
                emp.LstEmployeePublication = BLLEmployeePublication.GetEmployeePublication(empID, obj);
                emp.LstEmpRelativeBeneficiary = BLLVwEmpRelativeBeneficiary.GetEmpRelativeBeneficiary(empID, obj);
                emp.LstInsurance = BLLInsurance.GetEmpInsurance(empID);
                emp.LSTEmpDeputation = BLLEmployeeDeputation.GetEmpForDeputationInfo(null, "Y", empID);
                emp.LstManonayan = BLLManonayan.GetManonayan(empID);
                emp.ObjPerson = BLLPerson.GetPersonnelDetails(obj, empID);
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DLLEmployee.CloseConnection();
            }
        }
        public static List<ATTEmployee> GetEmployeeList()
        {
            List<ATTEmployee> LSTEmp = new List<ATTEmployee>();   
            try
            {
                foreach(DataRow rw in DLLEmployee.GetEmployeeList().Rows)
                {
                    ATTEmployee obj = new ATTEmployee();
                    obj.SymbolNo = rw["SYMBOL_NO"].ToString();
                    obj.OrgEmpNo = rw["ORG_EMP_NO"].ToString();
                    LSTEmp.Add(obj);
                }
                return LSTEmp;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
