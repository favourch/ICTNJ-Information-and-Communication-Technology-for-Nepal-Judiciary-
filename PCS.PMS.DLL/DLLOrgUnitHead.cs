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
   public class DLLOrgUnitHead
    {
        public static bool SaveOrgUnitHead(ATTOrgUnitHead objOrgUnitHead)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateDLSP = "";

                if (objOrgUnitHead.Action == "A")
                    InsertUpdateDLSP = "SP_ADD_ORG_UNIT_HEAD";
                //else if (objOrgUnitHead.Action == "E")
                //    InsertUpdateDLSP = "SP_EDIT_ORG_UNIT_HEAD";
                
                OracleParameter[] paramArray = new OracleParameter[8];
                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objOrgUnitHead.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_UNIT_ID", objOrgUnitHead.UnitID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_EMP_ID", objOrgUnitHead.EmpID, OracleDbType.Double, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":P_FROM_DATE", objOrgUnitHead.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":P_TO_DATE", objOrgUnitHead.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":P_UNIT_HEAD", objOrgUnitHead.UnitHead, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":P_OFFICE_HEAD", objOrgUnitHead.OfficeHead, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":P_ENTRY_BY", objOrgUnitHead.EntryBY, OracleDbType.Varchar2, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDLSP, paramArray);

            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            Tran.Commit();
            return true;
        }

       public static DataTable SearchEmployee(ATTOrgUnitHead objOrgUnitHead)
        {
            try
            {
                string strSelect = "";
                strSelect = "SELECT * FROM VW_EMP_ORG_UNIT_HEAD WHERE 1=1 ";
                List<OracleParameter> ParamList = new List<OracleParameter>();
                if (objOrgUnitHead.OrgID > 0)
                {
                    strSelect += "AND ORG_ID = :OrgID";
                    ParamList.Add(Utilities.GetOraParam(":OrgID", objOrgUnitHead.OrgID, OracleDbType.Int64, ParameterDirection.Input));
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
