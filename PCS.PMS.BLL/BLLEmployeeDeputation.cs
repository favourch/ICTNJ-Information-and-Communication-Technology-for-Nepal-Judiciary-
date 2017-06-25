using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeDeputation
    {
        public static bool AddEmpForDeputationDetail(ATTEmployeeDeputaion obj)
        {
            try
            {
                return DLLEmployeeDeputation.AddEmpForDeputationDetail(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occur while adding Duptation" + ex.Message);
            }
        }

        public static List<ATTEmployeeDeputaion> GetEmpForDeputation(ATTEmployeeDeputaion obj,string choice)
        {
            try
            {
                List<ATTEmployeeDeputaion> LSTDep = new List<ATTEmployeeDeputaion>();
                if (choice == "wod")
                {
                    foreach (DataRow row in DLLEmployeeDeputation.GetEmpForDeputation(obj, choice).Rows)
                    {
                        ATTEmployeeDeputaion objDep = new ATTEmployeeDeputaion();
                        objDep.EmpID = double.Parse(row["p_id"].ToString());
                        objDep.EmpName = row["employeename"].ToString();
                        objDep.Gender = row["gender"].ToString();
                        objDep.OrgID = int.Parse(row["org_id"].ToString());
                        objDep.OrgName = row["org_name"].ToString();
                        objDep.DesID = int.Parse(row["des_id"].ToString());
                        objDep.DesName = row["des_name"].ToString();
                        objDep.CreatedDate = row["created_date"].ToString();
                        objDep.PostID = int.Parse(row["post_id"].ToString());
                        objDep.FromDate = row["from_date"].ToString();
                        objDep.Action = "";
                        LSTDep.Add(objDep);
                    }

                }
                else if (choice == "wld")
                {
                    foreach (DataRow row in DLLEmployeeDeputation.GetEmpForDeputation(obj, choice).Rows)
                    {
                        ATTEmployeeDeputaion objDep = new ATTEmployeeDeputaion();
                        objDep.EmpID = double.Parse(row["p_id"].ToString());
                        objDep.EmpName = row["employeename"].ToString();
                        objDep.Gender = row["gender"].ToString();
                        objDep.OrgID = int.Parse(row["org_id"].ToString());
                        objDep.OrgName = row["org_name"].ToString();
                        objDep.DesID = int.Parse(row["des_id"].ToString());
                        objDep.DesName = row["des_name"].ToString();
                        objDep.CreatedDate = row["created_date"].ToString();
                        objDep.PostID = int.Parse(row["post_id"].ToString());
                        objDep.FromDate = row["from_date"].ToString();
                        objDep.DecisionDate = row["decision_date"].ToString();
                        objDep.DepOrgID = int.Parse(row["dep_org_id"].ToString());
                        objDep.DepOrgName = row["dep_org_name"].ToString();
                        objDep.Responsibilities = row["responsibilities"].ToString();
                        objDep.Action = "";
                        LSTDep.Add(objDep);
                    }
                }
                else if (choice == "wd")
                {
                    foreach (DataRow row in DLLEmployeeDeputation.GetEmpForDeputation(obj, choice).Rows)
                    {
                        ATTEmployeeDeputaion objDep = new ATTEmployeeDeputaion();
                        objDep.EmpID = double.Parse(row["p_id"].ToString());
                        objDep.EmpName = row["employeename"].ToString();
                        objDep.Gender = row["gender"].ToString();
                        objDep.OrgID = int.Parse(row["org_id"].ToString());
                        objDep.OrgName = row["org_name"].ToString();
                        objDep.DesID = int.Parse(row["des_id"].ToString());
                        objDep.DesName = row["des_name"].ToString();
                        objDep.CreatedDate = row["created_date"].ToString();
                        objDep.PostID = int.Parse(row["post_id"].ToString());
                        objDep.FromDate = row["from_date"].ToString();
                        objDep.DecisionDate = row["decision_date"].ToString();
                        objDep.DepOrgID = int.Parse(row["dep_org_id"].ToString());
                        objDep.DepOrgName = row["dep_org_name"].ToString();
                        objDep.Responsibilities = row["responsibilities"].ToString();
                        objDep.LeaveDate = row["leave_date"].ToString();
                        objDep.ReturnDate = row["return_date"].ToString();
                        objDep.Action = "";
                        LSTDep.Add(objDep);
                    }
                }
                return LSTDep;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public static List<ATTEmployeeDeputaion> GetEmpForDeputationReturn(int orgid,string active)
        {
            try
            {
                List<ATTEmployeeDeputaion> LSTEmpDepReturn = new List<ATTEmployeeDeputaion>();
                foreach (DataRow row in DLLEmployeeDeputation.GetEmpForDepReturn(orgid,active).Rows)
                {
                    ATTEmployeeDeputaion objEmpDepReturn = new ATTEmployeeDeputaion();
                    objEmpDepReturn.EmpID = int.Parse(row["p_id"].ToString());
                    objEmpDepReturn.EmpName = row["employeename"].ToString();
                    objEmpDepReturn.Gender =row["gender"].ToString();
                    objEmpDepReturn.OrgID = int.Parse(row["org_id"].ToString());
                    objEmpDepReturn.OrgName = row["org_name"].ToString();
                    objEmpDepReturn.DesID = int.Parse(row["des_id"].ToString());
                    objEmpDepReturn.DesName = row["des_name"].ToString();
                    objEmpDepReturn.CreatedDate = row["created_date"].ToString();
                    objEmpDepReturn.PostID=int.Parse(row["post_id"].ToString());
                    objEmpDepReturn.PostFromDate = row["from_date"].ToString();
                    objEmpDepReturn.DecisionDate = row["decision_date"].ToString();
                    objEmpDepReturn.DepOrgID = int.Parse(row["dep_org_id"].ToString());
                    objEmpDepReturn.DepOrgName = row["dep_org_name"].ToString();
                    objEmpDepReturn.LeaveDate = row["leave_date"].ToString();
                    objEmpDepReturn.ReturnDate = row["return_date"].ToString();
                    objEmpDepReturn.Responsibilities = row["responsibilities"].ToString();
                    LSTEmpDepReturn.Add(objEmpDepReturn);
                }
                return LSTEmpDepReturn;
            }
            catch (Exception ex)
            {  
                throw ex;
            }

        }

        public static bool SaveEmpForDeputation(List<ATTEmployeeDeputaion> LSTEmpDep)
        {
            try
            {
                DLLEmployeeDeputation.SaveEmpForDeputation(LSTEmpDep);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
           
        }

        public static List<ATTEmployeeDeputaion> GetDeputationOrganisation()
        {
            List<ATTEmployeeDeputaion> lstDepOrg = new List<ATTEmployeeDeputaion>();
            try
            {
                
                 foreach (DataRow row in DLLEmployeeDeputation.GetDeputationOrganisations().Rows)
                 {
                     ATTEmployeeDeputaion obj = new ATTEmployeeDeputaion();
                     obj.DepOrgID = int.Parse(row["DEP_ORG_ID"].ToString());
                     obj.DepOrgName = row["DEP_ORG_NAME"].ToString();
                     lstDepOrg.Add(obj);
                 }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return lstDepOrg;
        }

        public static List<ATTEmployeeDeputaion> SearchEmployeeDeputation(ATTEmployeeDeputaion objEmployee, string searchType)
        //flag defines whether or not to load employee other attributes.0-no,1-yes
        {
            List<ATTEmployeeDeputaion> lstEmployee = new List<ATTEmployeeDeputaion>();

            foreach (DataRow row in DLLEmployeeDeputation.SearchEmployeeDeputation(objEmployee, searchType).Rows)
            {
                ATTEmployeeDeputaion obj = new ATTEmployeeDeputaion();
                obj.EmpName=row["EMP_NAME"].ToString();
                obj.EmpID=int.Parse(row["EMP_ID"].ToString());
                obj.SymbolNo=((row["SYMBOL_NO"] == System.DBNull.Value) ? "" : (string)row["SYMBOL_NO"]);
                obj.Gender=((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]);
                obj.DOB=((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]);
                if (!(row["ORG_EMP_NO"] == System.DBNull.Value))
                {
                    obj.OrgEmpNo = int.Parse(row["ORG_EMP_NO"].ToString());
                }
                else obj.OrgEmpNo = null;            
                              
                lstEmployee.Add(obj);
            }
            return lstEmployee;
        }

        public static List<ATTEmployeeDeputaion> GetEmpForDeputationInfo(int? orgid, string active, double empid)
        {
            try
            {
                List<ATTEmployeeDeputaion> lstEmployeeDeputaion = new List<ATTEmployeeDeputaion>();
                foreach (DataRow row in DLLEmployeeDeputation.GetEmpForDeputationInfo(orgid, active, empid).Rows)
                {
                    ATTEmployeeDeputaion objEmpDeputation = new ATTEmployeeDeputaion();
                    //if (row["org_id"].ToString() != "")
                    //{
                    //    objEmpDeputation.OrgID = int.Parse(row["org_id"].ToString());
                    //}
                    objEmpDeputation.DepOrgName = row["dep_org_name"].ToString();
                    //objEmpDeputation.DesName = row["des_name"].ToString();
                    if (row["des_id"].ToString() != "")
                    {
                        objEmpDeputation.DesID = int.Parse(row["des_id"].ToString());
                    }
                    objEmpDeputation.DecisionDate = row["decision_date"].ToString();
                    if (row["decision_ver_by"].ToString()!="")
                    {
                        objEmpDeputation.DecisionVerifiedBy = int.Parse(row["decision_ver_by"].ToString()); 
                    }
                    objEmpDeputation.ApplicationDate = row["application_date"].ToString();
                    //if (row["dep_org_id"].ToString() != "")
                    //{
                    //    objEmpDeputation.DepOrgID = int.Parse(row["dep_org_id"].ToString());
                    //}
                    objEmpDeputation.DepOrgName = row["dep_org_name"].ToString();
                    objEmpDeputation.LeaveDate = row["leave_date"].ToString();
                    objEmpDeputation.ReturnDate = row["return_date"].ToString();
                    objEmpDeputation.Responsibilities = row["responsibilities"].ToString();
                    lstEmployeeDeputaion.Add(objEmpDeputation);
                }
                return lstEmployeeDeputaion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
