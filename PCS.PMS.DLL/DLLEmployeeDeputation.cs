using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;

using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeDeputation
    {
        public static bool AddEmpForDeputationDetail(ATTEmployeeDeputaion obj) // added by shanjeev
        {
            string sp = "";
            if (obj.Action == "A")

                sp = "SP_ADD_EMP_DEPUTATION";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_application_date ", obj.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_dep_org_id ", obj.DepOrgID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_decision_ver_by", obj.DecisionVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_responsibilities", obj.Responsibilities, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIP_ORG_ID", obj.TipOrgID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", obj.TippaniID, OracleDbType.Int32, ParameterDirection.Input));
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.PMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, sp, paramArray.ToArray());

                Tran.Commit();
                return true;

            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw new Exception("Error occur while adding duptation details" + ex.Message);
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }

        public static DataTable GetEmpForDeputation(ATTEmployeeDeputaion objDP,string choice)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP="";
            if (choice == "wod")
            {
                SelectSP = "SP_GET_EMP_WO_DEPUTATION";
            }
            else if (choice == "wld")
            {
                SelectSP = "SP_GET_EMP_W_DEP_WO_LEAVE";
            }
            else if (choice == "wd")
            {
                SelectSP = "SP_GET_EMP_W_DEPUTATION";
            }
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID",objDP.OrgID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE", objDP.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramArray.Add(Utilities.GetOraParam("P_ORG_ID", objEmpDep.OrgID, OracleDbType.Double, ParameterDirection.Input));
            //paramArray.Add(Utilities.GetOraParam("P_ORG_ID", objEmpDep.OrgID, OracleDbType.Double, ParameterDirection.Input));
            //paramArray.Add(Utilities.GetOraParam("P_ORG_ID", objEmpDep.OrgID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public static DataTable GetEmpForDepReturn(int orgid, string active)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP = "SP_GET_EMP_W_DEPUTATION";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID",orgid, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE",active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool SaveEmpForDeputation(List<ATTEmployeeDeputaion> LSTEmpDep)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateDel = "";
                foreach (ATTEmployeeDeputaion obj in LSTEmpDep)
                {
                    if (obj.Action == "A")
                    {
                        InsertUpdateDel = "SP_ADD_EMP_DEPUTATION";
                    }
                    else if (obj.Action == "E")
                    {
                        InsertUpdateDel = "SP_EDIT_LEAVE_DEPUTATION";
                    }
                    else if (obj.Action=="ER")
                    {
                        InsertUpdateDel="SP_EDIT_RETURN_DEPUTATION";
                    }
                    else if (obj.Action == "D")
                    {
                        InsertUpdateDel="SP_DEL_EMP_DEPUTATION";
                    }
                    if (obj.Action == "A")
                    {

                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_dep_org_id ", obj.DepOrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_ver_by", obj.DecisionVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_responsibilities", obj.Responsibilities, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_active",obj.Active,OracleDbType.Varchar2,ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());

                    }
                    else if (obj.Action == "E")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_leave_date", obj.LeaveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_leave_ver_by", obj.LeaveVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());
                    }
                    else if (obj.Action == "ER")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.PostFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_return_date ", obj.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_return_ver_by", obj.ReturnVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());
                    }
                    else if(obj.Action == "D")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            Tran.Commit();
            return true;
        }

        public static bool SaveEmpployeeDeputation(List<ATTEmployeeDeputaion> LSTEmpDep, OracleTransaction Tran, double empID)
        {
            try
            {
                string InsertUpdateDel = "";
                foreach (ATTEmployeeDeputaion obj in LSTEmpDep)
                {
                    if (obj.Action == "A")
                    {
                        InsertUpdateDel = "SP_ADD_EMP_DEPUTATION";
                    }
                    else if (obj.Action == "E")
                    {
                        InsertUpdateDel = "SP_EDIT_EMP_DEPUTATION";
                    }
                    else if (obj.Action == "D")
                    {
                        InsertUpdateDel = "SP_DEL_EMP_DEPUTATION";
                    }
                    if (obj.Action == "A")
                    {

                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_application_date ", obj.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_dep_org_id ", obj.DepOrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_ver_by", obj.DecisionVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_responsibilities", obj.Responsibilities, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_TIP_ORG_ID", null, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_TIPPANI_ID", null, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_leave_date", obj.LeaveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_leave_ver_by", obj.LeaveVerifiedBy, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_return_date", obj.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());

                    }
                    else if (obj.Action == "E")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_application_date ", obj.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_dep_org_id", obj.DepOrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_decision_ver_by", obj.DecisionVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_responsibilities", obj.Responsibilities, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());
                    }
                    else if (obj.Action == "D")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_application_date", obj.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDel, paramArray.ToArray());
                    }
                }
                return true;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }   
        }

        public static DataTable GetDeputationOrganisations()
        {
            try
            {
                string sql = "select a.DEP_ORG_NAME,a.DEP_ORG_ID from vw_emp_deputation a";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, sql, Module.PMS);
                return (DataTable)ds.Tables[0];

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable SearchEmployeeDeputation(ATTEmployeeDeputaion objEmployee, string searchType)
        {
            try
            {
                string strSelectSQL = "";
                if (searchType == "All")
                {
                    strSelectSQL = "SELECT DISTINCT A.EMP_ID,A.EMP_NAME,A.FIRST_NAME,A.MID_NAME,A.SUR_NAME,A.DOB,A.GENDER,A.SYMBOL_NO,"
                                    + "A.ORG_EMP_NO,A.ORG_ID,A.ORG_NAME,A.DES_ID,A.DES_NAME,A.DES_TYPE,A.FROM_DATE FROM VW_EMP_DEPUTATION A WHERE 1=1";
                }
                else if (searchType == "Current")
                {
                    strSelectSQL = "SELECT DISTINCT A.EMP_ID,A.EMP_NAME,A.FIRST_NAME,A.MID_NAME,A.SUR_NAME,A.DOB,A.GENDER,A.SYMBOL_NO,"
                                    + "A.ORG_EMP_NO,A.ORG_ID,A.ORG_NAME,A.DES_ID,A.DES_NAME,A.DES_TYPE,A.FROM_DATE FROM VW_EMP_DEPUTATION A WHERE A.ORG_ID IS NOT NULL";
                }

                int i = 0;

                if (objEmployee.EmpID != 0.0) i++;
                if (objEmployee.FirstName != null) i++;
                if (objEmployee.MiddleName != null) i++;
                if (objEmployee.LastName != null) i++;
                if (objEmployee.Gender != null) i++;
                if (objEmployee.DOB != null) i++;
                if (objEmployee.SymbolNo != null) i++;
                if (objEmployee.DesID != 0) i++;
                if (objEmployee.OrgID != 0) i++;
                if (objEmployee.DepOrgID != 0) i++;
               

                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objEmployee.EmpID != 0.0)
                {
                    strSelectSQL += " AND A.EMP_ID =:EmpID";
                    ParamArray[j] = Utilities.GetOraParam(":EmpID", objEmployee.EmpID, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.FirstName != null)
                {
                    strSelectSQL += " AND A.FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objEmployee.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.MiddleName != null)
                {
                    strSelectSQL += " AND A.MID_NAME LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objEmployee.MiddleName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.LastName != null)
                {
                    strSelectSQL += " AND A.SUR_NAME LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objEmployee.LastName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.Gender != null)
                {
                    strSelectSQL += " AND A.GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objEmployee.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.DOB != null)
                {
                    strSelectSQL += " AND A.DOB = :DOB";
                    ParamArray[j] = Utilities.GetOraParam(":DOB", objEmployee.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.SymbolNo != null)
                {
                    strSelectSQL += " AND A.SYMBOL_NO = :SymbolNo";
                    ParamArray[j] = Utilities.GetOraParam(":SymbolNo", objEmployee.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.DesID != 0)
                {
                    strSelectSQL += " AND A.DES_ID = :DesID";
                    ParamArray[j] = Utilities.GetOraParam(":DesID", objEmployee.DesID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

                if (objEmployee.OrgID != 0)
                {
                    strSelectSQL += " AND A.ORG_ID = :OrgID";
                    ParamArray[j] = Utilities.GetOraParam(":OrgID", objEmployee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }
                if (objEmployee.DepOrgID != 0)
                {
                    strSelectSQL += " AND A.DEP_ORG_ID = :DepOrgID";
                    ParamArray[j] = Utilities.GetOraParam(":DepOrgID", objEmployee.DepOrgID, OracleDbType.Int64, ParameterDirection.Input);
                    j++;
                }

               

                strSelectSQL += " ORDER BY A.EMP_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetEmpForDeputationInfo(int? orgid, string active, double empid)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP = "SP_GET_EMP_DEPUTATION";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgid, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            paramArray.Add(Utilities.GetOraParam("p_emp_id", empid, OracleDbType.Double, ParameterDirection.Input));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public static bool AddEmpForDeputationDetail(ATTEmployeeDeputaion obj) 
        //{
        //    string sp = "";
        //    if (obj.Action == "A")

        //        sp = "SP_ADD_EMP_DEPUTATION";
        //    List<OracleParameter> paramArray = new List<OracleParameter>();
        //    paramArray.Add(Utilities.GetOraParam("p_emp_id", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_des_id", obj.DesID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_created_date", obj.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_post_id ", obj.PostID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_from_date ", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_application_date ", obj.ApplicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_decision_date", obj.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_dep_org_id ", obj.DepOrgID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_decision_ver_by", obj.DecisionVerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_responsibilities", obj.Responsibilities, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_TIP_ORG_ID", obj.TipOrgID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", obj.TippaniID, OracleDbType.Int32, ParameterDirection.Input));
        //    GetConnection GetConn = new GetConnection();
        //    OracleTransaction Tran = GetConn.GetDbConn(Module.PMS).BeginTransaction();
        //    try
        //    {
        //        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, sp, paramArray.ToArray());

        //        Tran.Commit();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        Tran.Rollback();
        //        throw new Exception("Error occur while adding duptation details" + ex.Message);
        //    }
        //    finally
        //    {
        //        GetConn.CloseDbConn();
        //    }

        //}

    }
}
