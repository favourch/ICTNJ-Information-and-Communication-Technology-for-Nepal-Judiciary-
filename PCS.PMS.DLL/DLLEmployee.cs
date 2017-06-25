using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;
using Oracle.DataAccess.Client;

namespace PCS.PMS.DLL
{
    public class DLLEmployee
    {
        public static bool SaveEmployeeDetails(ATTEmployee objEmployee)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.PMS).BeginTransaction();
            double employeeID;
            //double relativeID = 0;
            try
            {
                employeeID = DLLPerson.AddPersonnelDetails(objEmployee.ObjPerson, Tran);

                OracleParameter[] paramArray = new OracleParameter[7];
                paramArray[0] = Utilities.GetOraParam(":p_EMP_ID", employeeID, OracleDbType.Double, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_SYMBOL_NO", objEmployee.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_ORG_EMP_NO", objEmployee.OrgEmpNo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_IDENTITY_MARK", objEmployee.IdentityMark, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_ENTRY_BY", objEmployee.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_PF_NO", objEmployee.PFNo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_CIT_NO", objEmployee.CitznNo, OracleDbType.Varchar2, ParameterDirection.Input);

                if (objEmployee.EmpID == 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_EMPLOYEES", paramArray[0], paramArray);
                else if (objEmployee.EmpID > 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_EMPLOYEES", paramArray[0], paramArray);

                if (objEmployee.LstEmployeeVisits.Count > 0)
                    DLLEmployeeVisits.AddEmployeeVisits(objEmployee.LstEmployeeVisits, Tran, employeeID);
                if (objEmployee.LstEmployeeExperience.Count > 0)
                    DLLEmployeeExperience.AddEmployeeExperiences(objEmployee.LstEmployeeExperience, Tran, employeeID);
                if (objEmployee.LstEmployeePosting.Count > 0)
                    DLLEmployeePosting.SaveEmployeePosting(objEmployee.LstEmployeePosting, Tran, employeeID);
                if (objEmployee.LstEmployeePublication.Count > 0)
                    DLLEmployeePublication.AddEmployeePublication(objEmployee.LstEmployeePublication, Tran, employeeID);
                if (objEmployee.LstEmployeeBeneficiary.Count > 0)
                    DLLEmployeeBeneficiary.SaveBeneficiary(objEmployee.LstEmployeeBeneficiary, Tran, employeeID);
                if (objEmployee.LstInsurance.Count > 0)
                    DLLInsurance.SaveEmpInsurance(objEmployee.LstInsurance, Tran, employeeID);
                if (objEmployee.LSTAttachments.Count > 0)
                    DLLPersonAttachments.SaveAttachments(objEmployee.LSTAttachments, Tran, employeeID);
                if (objEmployee.ObjUser.Username != "" && objEmployee.ObjUser.Password != "")
                    DLLUsers.SaveUsers(objEmployee.ObjUser, Tran,employeeID);
                if (objEmployee.OrgUser.Username != "")
                    DLLOrganizationUSers.SaveOrganizationUsers(objEmployee.OrgUser,Tran,employeeID);
                if (objEmployee.LSTEmpDeputation!=null)
                    DLLEmployeeDeputation.SaveEmpployeeDeputation(objEmployee.LSTEmpDeputation, Tran, employeeID);
                if (objEmployee.LstManonayan.Count > 0)
                    DLLManonayan.SaveManonayan(objEmployee.LstManonayan, Tran, employeeID);

                objEmployee.EmpID = employeeID;
                Tran.Commit();
                return true;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static DataTable GetEmployeeList()
        {
            try
            {
                string sql = "SELECT DISTINCT ORG_EMP_NO,SYMBOL_NO FROM EMPLOYEE WHERE 1=1";
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, sql, Module.PMS);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public static object GetConnection()
        {
            GetConnection gc = new GetConnection();
            return gc.GetDbConn(Module.PMS);
        }

        public static void CloseConnection()
        {
            GetConnection gc = new GetConnection();
            gc.CloseDbConn();
        }

    }
}
