using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COMMON;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeWorkDivision
    {
        public static bool SaveEmpWorkDivision(List<ATTEmployeeWorkDivision> LSTEmpWrkDiv)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            try
            {
               string InsertUpdateDLSP = "";
               foreach (ATTEmployeeWorkDivision var in LSTEmpWrkDiv)
               {
                   if (var.Action == "A")
                   {
                       InsertUpdateDLSP = "SP_ADD_EMP_WORK_DIST";
                   }
                   OracleParameter[] paramArray = new OracleParameter[11];
                   paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", var.EmpID, OracleDbType.Double, ParameterDirection.Input);
                   paramArray[1] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                   paramArray[2] = Utilities.GetOraParam(":P_DES_ID", var.DesID, OracleDbType.Int32, ParameterDirection.Input);
                   paramArray[3] = Utilities.GetOraParam(":P_CREATED_DATE", var.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   paramArray[4] = Utilities.GetOraParam(":P_POST_ID", var.PostID, OracleDbType.Int32, ParameterDirection.Input);
                   paramArray[5] = Utilities.GetOraParam(":P_FROM_DATE", var.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   paramArray[6] = Utilities.GetOraParam(":P_UNIT_ID", var.OrgUnitID, OracleDbType.Int32, ParameterDirection.Input);
                   paramArray[7] = Utilities.GetOraParam(":P_UNIT_FROM_DATE", var.UnitFromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   //paramArray[7] = Utilities.GetOraParam(":P_SECTION_ID", var.SectionID, OracleDbType.Int32, ParameterDirection.Input);
                   //paramArray[8] = Utilities.GetOraParam(":P_SEC_FROM_DATE", var.SectionFromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   paramArray[8] = Utilities.GetOraParam(":P_RESPONSIBILITY", var.Responsibility, OracleDbType.Varchar2, ParameterDirection.Input);
                   paramArray[9] = Utilities.GetOraParam(":P_UNIT_HEAD", var.IsHeadOfUnit, OracleDbType.Varchar2, ParameterDirection.Input);
                  // paramArray[11] = Utilities.GetOraParam(":P_SECTION_HEAD", var.IsHeadOfSection, OracleDbType.Varchar2, ParameterDirection.Input);
                   paramArray[10] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                   SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDLSP, paramArray);
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

        public static DataTable SearchEmployee(ATTEmployeeWorkDivision objEmpWrkDiv)
        {
            try
            {
                string strSelect = "";
                strSelect = "SELECT * FROM VW_EMP_WORK_DISTRIBUTION WHERE 1=1 ";
                List<OracleParameter> ParamList = new List<OracleParameter>();
                if (objEmpWrkDiv.OrgID > 0)
                {
                    strSelect += "AND ORG_ID = :OrgID";
                    ParamList.Add(Utilities.GetOraParam(":OrgID", objEmpWrkDiv.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (objEmpWrkDiv.OrgUnitID !=null)
                {
                    strSelect += " AND ORG_UNIT_ID = :OrgUnitID";
                    ParamList.Add(Utilities.GetOraParam(":OrgUnitID", objEmpWrkDiv.OrgUnitID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (objEmpWrkDiv.SectionID >0)
                {
                    strSelect += " AND SECTION_ID = :SectionID";
                    ParamList.Add(Utilities.GetOraParam(":SectionID", objEmpWrkDiv.SectionID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (objEmpWrkDiv.DesType != null)
                {
                    strSelect += " AND DES_TYPE= :DesType";
                    ParamList.Add(Utilities.GetOraParam(":DesType", objEmpWrkDiv.DesType, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (objEmpWrkDiv.DesID >0)
                {
                    strSelect += " AND DES_ID = :DesID";
                    ParamList.Add(Utilities.GetOraParam(":DesID", objEmpWrkDiv.DesID, OracleDbType.Int64, ParameterDirection.Input));

                }
                if (objEmpWrkDiv.SymbolNo != null)
                {
                    strSelect += " AND SYMBOL_NO = :SymbolNo";
                    ParamList.Add(Utilities.GetOraParam(":SymbolNo", objEmpWrkDiv.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input));

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
    }
}
