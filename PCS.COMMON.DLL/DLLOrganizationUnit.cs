using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLOrganizationUnit
    {
        public static DataTable GetOrganizationUnits(int? orgId, int? unitId)
        {
            try
            {
                string SelectSql = "SP_GET_ORGANIZATION_UNITS";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_UNIT_ID", unitId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, ParamArray);
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

        public static bool SaveOrganizationUnit(List<ATTOrganizationUnit> LSTOrgUnit)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();
            try
            {
                foreach (ATTOrganizationUnit objOrgUnit in LSTOrgUnit)
                {
                    string InsertUpdateSQL = "";

                    if (objOrgUnit.Action == "A")
                    {
                        InsertUpdateSQL = "SP_ADD_ORGANIZATION_UNITS";
                    }
                    else if (objOrgUnit.Action == "E")
                    {
                        InsertUpdateSQL = "SP_EDIT_ORGANIZATION_UNITS";
                    }
                    if (objOrgUnit.Action == "A" || objOrgUnit.Action == "E")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[7];

                        ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", objOrgUnit.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":p_UNIT_ID", objOrgUnit.UnitID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[2] = Utilities.GetOraParam(":p_UNIT_NAME", objOrgUnit.UnitName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":p_PARENT_ORG_ID", objOrgUnit.ParentOrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[4] = Utilities.GetOraParam(":p_PARENT_UNIT_ID", objOrgUnit.ParentUnitID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":p_UNIT_TYPE", objOrgUnit.UnitType, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = Utilities.GetOraParam(":p_ENTRY_BY", objOrgUnit.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray);
                        objOrgUnit.UnitID = int.Parse(ParamArray[1].Value.ToString());
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

        
        public static DataTable GetOrganizationUnitHead(int? orgId, int? unitId)
        {
            try
            {
                string SelectSql = "SP_GET_ORG_UNIT_WITH_HEAD";
                List<OracleParameter> ParamArray = new List<OracleParameter>();
                ParamArray.Add(Utilities.GetOraParam(":p_ORG_ID", orgId, OracleDbType.Int64, ParameterDirection.Input));
                ParamArray.Add(Utilities.GetOraParam(":p_UNIT_ID", unitId, OracleDbType.Int64, ParameterDirection.Input));
                ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.PMS, ParamArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SrchOrganizationUnitHead(int? orgID,string searchValue)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                string SelectSql = " select * from vw_get_org_unit_with_head " +
                                   " where org_id = " + orgID + 
                                   " AND  unit_name like '" + searchValue + "%'" ;

                OracleConnection DBConn = GetConn.GetDbConn(Module.PMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSql);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static DataTable GetOrgUnitWithChild(int? orgid, int? unitid)
        {
            try
            {
                string Select = "SP_GET_UNIT_WITH_CHILDS";
                List<OracleParameter> ParamArray = new List<OracleParameter>();
                ParamArray.Add(Utilities.GetOraParam(":p_ORG_ID", orgid, OracleDbType.Int64, ParameterDirection.Input));
                ParamArray.Add(Utilities.GetOraParam(":p_UNIT_ID", unitid, OracleDbType.Int64, ParameterDirection.Input));
                ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, Select, Module.PMS, ParamArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOrganizationUnits(string unitType, int orgID)
        {
            try
            {
                string selectSQL = " SELECT  ORG_ID,UNIT_ID,UNIT_NAME,PARENT_ORG_ID,PARENT_UNIT_ID,UNIT_TYPE " +
                                   " From VW_ORGNIZATION_UNITS " +
                                   " WHERE 1=1 AND UNIT_TYPE ='" + unitType + "' AND ORG_ID = " + orgID;

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, selectSQL);
                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;


            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }
}
