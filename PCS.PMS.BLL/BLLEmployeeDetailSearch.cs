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
    public class BLLEmployeeDetailSearch
    {
        public static DataTable DetailSearchEmployee(ATTEmployeeDetailSearch objEmployee)
        {
            try
            {
                return DLLEmployeeDetailSearch.DetailSearchEmployee(objEmployee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeeDetailSearch> DetailSearchEmployeeList(ATTEmployeeDetailSearch objEmployee)
        {
            List<ATTEmployeeDetailSearch> lst = new List<ATTEmployeeDetailSearch>();
            try
            {
                foreach (DataRow row in DLLEmployeeDetailSearch.DetailSearchEmployee(objEmployee).Rows)
                {
                    ATTEmployeeDetailSearch obj = new ATTEmployeeDetailSearch();
                    obj.EmpID = double.Parse(row["emp_id"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MiddleName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                    obj.SewaName = row["sewa_name"].ToString();
                    obj.SamuhaName = row["samuha_name"].ToString();
                    obj.UpaSamuhaName = row["upa_samuha_name"].ToString();
                    obj.PostName = row["des_name"].ToString();
                    obj.LevelName = row["level_name"].ToString();
                    obj.PostingTypeName = row["posting_type_name"].ToString();
                    obj.Gender = row["Gender"].ToString();
                    obj.DistrictName = row["eng_distname"].ToString();
                    obj.SubjectID = (row["Sub_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["Sub_ID"].ToString());
                    obj.Training = row["subject"].ToString();
                    //obj.RetirementDate = row["subject"].ToString();
                    obj.DegreeID = (row["Deg_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["Deg_ID"].ToString());
                    obj.QualificationName = row["DEGREE_NAME"].ToString();
                    obj.VisitCountryID = (row["country_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["country_ID"].ToString());
                    obj.VisitCountryName = row["COUNTRY_ENG_NAME"].ToString();
                    obj.VisitPurpose = row["purpose"].ToString();
                    obj.VisitFromDate = row["v_from_date"].ToString();
                    obj.VisitToDate = row["to_date"].ToString();
                    obj.JoiningDate = row["p_from_date"].ToString();
                    obj.RetirementDate = row["retirement_date"].ToString();
                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeeDetailSearch> PropertyReportSearchList(ATTEmployeeDetailSearch objEmployee)
        {
            List<ATTEmployeeDetailSearch> lst = new List<ATTEmployeeDetailSearch>();
            try
            {
                foreach (DataRow row in DLLEmployeeDetailSearch.PropertyReportSearch(objEmployee).Rows)
                {
                    ATTEmployeeDetailSearch obj = new ATTEmployeeDetailSearch();

                    //obj.EmpID = d


                    obj.OrgName = row["Org_Name"].ToString();
                    obj.EmpID = double.Parse(row["emp_id"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MiddleName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                   
                    obj.PostName = row["des_name"].ToString();
                    obj.LevelName = row["level_name"].ToString();
                    obj.PostingTypeName = row["posting_type_name"].ToString();
                    obj.Gender = row["Gender"].ToString();
                   
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
