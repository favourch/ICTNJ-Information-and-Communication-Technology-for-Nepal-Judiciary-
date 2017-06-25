using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.PMS.DLL
{
    public class DLLRetirement
    {
        public static bool SaveEmpRetirement(List<ATTRetirement> LSTRet)
        {
                OracleTransaction Tran;
                GetConnection conn = new GetConnection();
                OracleConnection DBConn = conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();
                string InsertUpDel = "";
                try
                {
                    foreach (ATTRetirement var in LSTRet)
                    {
                        if (var.action == "A")
                        {
                            InsertUpDel = "SP_ADD_EMP_RETIREMENT";
                        }
                        else if (var.action == "E")
                        {
                            InsertUpDel = "SP_EDIT_EMP_RETIREMENT";
                        }
                        if (var.action == "A" || var.action == "E")
                        {
                            List<OracleParameter> paramArray = new List<OracleParameter>();
                            paramArray.Add(Utilities.GetOraParam("p_emp_id", var.empID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_org_id", var.orgID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_des_id", var.desID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_created_date", var.createdDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_post_id", var.postID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_from_date", var.fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_retirement_date", var.retirementDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_is_self", var.isSelf, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_retirement_type", var.retirementType, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_retirement_desc", var.ApplDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_decision_date", var.decisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_decision_by", var.decisionBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_app_date", var.appDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_app_by", var.appBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_entry_by", var.entryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_decision_desc", var.decisionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_app_desc", var.appDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_is_decided", var.isDecided, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_is_approved", var.isApproved, OracleDbType.Varchar2, ParameterDirection.Input));

                            DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpDel, paramArray.ToArray());

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

        public static DataTable SearchEmployee(ATTRetirement objEmpRet)
        {
            try
            {
                string strSelect = "";
               strSelect = "SELECT * FROM VW_EMPLOYEE_WITH_POSTING WHERE 1=1";
                List<OracleParameter> ParamList = new List<OracleParameter>();
                if (objEmpRet.firstName != null)
                {
                    strSelect += "AND A.FIRST_NAME LIKE :firstName||'%'";
                    ParamList.Add(Utilities.GetOraParam(":firstName", objEmpRet.firstName, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.midName != null)
                {
                    strSelect += " AND A.MID_NAME LIKE :midName||'%'";
                    ParamList.Add(Utilities.GetOraParam(":midName", objEmpRet.midName, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.lastName != null)
                {
                    strSelect += " AND A.SUR_NAME LIKE :lastName||'%'";
                    ParamList.Add(Utilities.GetOraParam(":lastName", objEmpRet.lastName, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.orgID > 0)
                {
                    strSelect += "AND ORG_ID = :orgID";
                    ParamList.Add(Utilities.GetOraParam(":OrgID", objEmpRet.orgID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (objEmpRet.postID > 0)
                {
                    strSelect += " AND POST_ID = :postID";
                    ParamList.Add(Utilities.GetOraParam(":postID", objEmpRet.postID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (objEmpRet.gender != null)
                {
                    strSelect += " AND GENDER= :gender";
                    ParamList.Add(Utilities.GetOraParam(":gender", objEmpRet.gender, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.maritalStatus != null)
                {
                    strSelect += " AND MARTIAL_STATUS= :maritalStatus";
                    ParamList.Add(Utilities.GetOraParam(":maritalStatus", objEmpRet.maritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.maritalStatus != null)
                {
                    strSelect += " AND MARTIAL_STATUS= :maritalStatus";
                    ParamList.Add(Utilities.GetOraParam(":maritalStatus", objEmpRet.maritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpRet.dob != null)
                {
                    strSelect += " AND DOB= :dob";
                    ParamList.Add(Utilities.GetOraParam(":dob", objEmpRet.dob, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                strSelect += " ORDER BY ORG_ID";

                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.PMS);

                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.Text, strSelect, ParamList.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeeRetirement(ATTRetirement objRetirement, string opt)
        {
            try
            {
                List<OracleParameter> ParamList = new List<OracleParameter>();
                string select = "";
                if (opt == "appl" || opt=="dec")
                {
                    select = "SELECT * FROM VW_EMP_RETIREMENT WHERE 1=1 ";                
                    if (objRetirement.isDecided != "")
                    {
                        select += " AND IS_DECIDED=:IsDecided";
                        ParamList.Add(Utilities.GetOraParam(":IsDecided", objRetirement.isDecided, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                    if (objRetirement.isApproved != "")
                    {
                        select += " AND IS_APPROVED=:IsApproved";
                        ParamList.Add(Utilities.GetOraParam(":IsApproved", objRetirement.isApproved, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                else if(opt=="appr")
                {
                    select = "SELECT * FROM VW_EMP_RETIREMENT WHERE 1=1 ";                    
                    if (objRetirement.isDecided != "")
                    {
                        select += " AND IS_DECIDED=:IsDecided";
                        ParamList.Add(Utilities.GetOraParam(":IsDecided", objRetirement.isDecided, OracleDbType.Varchar2, ParameterDirection.Output));
                    }                   
                    if (objRetirement.isApproved != "")
                    {
                        select += " AND IS_APPROVED=:IsApproved";
                        ParamList.Add(Utilities.GetOraParam(":IsApproved", objRetirement.isApproved, OracleDbType.Varchar2, ParameterDirection.Output));
                    }
                }
                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.PMS);

                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.Text, select, ParamList.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
