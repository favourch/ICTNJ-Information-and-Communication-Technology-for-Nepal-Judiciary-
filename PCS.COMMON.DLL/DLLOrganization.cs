using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.COREDL;
using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;


namespace PCS.COMMON.DLL
{
    public class DLLOrganization
    {
        public static DataTable GetOrganization()
        {
            try
            {
                string SelectSql = "select * from VW_ORG_INFO order by org_id";
                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.Text, SelectSql);

                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetOrganization(string searchValue)
        {
            try
            {
                string SelectSql = " select * from VW_ORG_INFO " + 
                                   " where org_name like '" + searchValue +"%'"+
                                   " order by org_id";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, SelectSql);
                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetOrganizationByID(int OrgID)
        {
            try
            {
                //string SelectSql = "SELECT org_id, org_name, org_type,org_sub_type, parent_id AS parentorgname FROM ORGNIZATIONS WHERE org_id = :OrgID";
                string SelectSql = "select * from VW_ORG_INFO where org_id=:OrgID order by org_id";
                OracleParameter[] ParamArray = new OracleParameter[1];
                ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":OrgID", OrgID, OracleDbType.Int64, ParameterDirection.Input);
                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.Text, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int SaveOrganization(ATTOrganization ObjATT)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;

            try
            {
                DBConn = Conn.GetDbConn();
                Tran = DBConn.BeginTransaction();

                string InsertUpdateSQL = "";

                if (ObjATT.OrgID <= 0)
                    InsertUpdateSQL = "SP_ADD_ORGNIZATIONS";
                else
                    InsertUpdateSQL = "SP_EDIT_ORGNIZATIONS";

                OracleParameter[] ParamArray = new OracleParameter[12];

                ParamArray[0] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_ID", ObjATT.OrgID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_NAME", ObjATT.OrgName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_TYPE", ObjATT.OrgType, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_SUB_TYPE", ObjATT.OrgSubType, OracleDbType.Varchar2, ParameterDirection.Input);
                if (ObjATT.ParentId == 0)
                {
                    ParamArray[4] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_PARENT_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                }
                else
                {
                    ParamArray[4] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_PARENT_ID", ObjATT.ParentId, OracleDbType.Int64, ParameterDirection.Input);
                }
                ParamArray[5] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_ADDRESS", ObjATT.OrgAddress, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[6] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_STREET_NAME", ObjATT.OrgStreetName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[7] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_VDC_MUNI", ObjATT.OrgVdcMuni, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[8] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_URL", ObjATT.OrgUrl, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[9] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_WARD_NO", ObjATT.OrgWardNo, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[10] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_DIST", ObjATT.OrgDistrict, OracleDbType.Int64, ParameterDirection.Input);
               if(ObjATT.OrgEquCode==0)
                ParamArray[11] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_EQU_CODE", null, OracleDbType.Int64, ParameterDirection.Input);
               else
                ParamArray[11] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_ORG_EQU_CODE", ObjATT.OrgEquCode, OracleDbType.Int64, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray);

                int OrgID = int.Parse(ParamArray[0].Value.ToString());


                DLLPhone.SaveOrganizationPhone(ObjATT.LstPhone, Tran, OrgID);

                DLLEmail.SaveOrganizationEmail(ObjATT.LstEmail, Tran, OrgID);

                Tran.Commit();

                return OrgID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }

        public static DataTable GetOrgWithChilds(int orgID)
        {
            try
            {
                string SelectSql = "SP_GET_ORG_WITH_CHILDS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static DataTable GetAllOrganization(int? orgID, string orgType, string orgEquCode)
        {
            try
            {
                string SelectSql = "SP_GET_ORGNIZATIONS";

                OracleParameter[] ParamArray = new OracleParameter[4];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_org_type", orgType, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_org_equ_code", orgEquCode, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
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
    }
}