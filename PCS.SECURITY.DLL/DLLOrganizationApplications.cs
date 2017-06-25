using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using PCS.FRAMEWORK;

using PCS.SECURITY.ATT;
using PCS.COREDL;

namespace PCS.SECURITY.DLL
{
    public class DLLOrganizationApplications
    {
        public static DataTable GetOrgApplicationsTable(int  orgID)
        {
            try
            {
                //string SPSelect = "SELECT * FROM APPLICATIONS a, ORGNIZATION_APPLICATIONS b where a.APPL_ID=b.APPL_ID and b.ORG_ID=:orgID ";
                string SPSelect = "SP_GET_ORG_APPLICATIONS";
                               OracleParameter[] ParamArray = new OracleParameter[3];

                               ParamArray[0] = Utilities.GetOraParam(":P_org_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                               ParamArray[1] = Utilities.GetOraParam(":P_APPL_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                               ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect,ParamArray);
                return (DataTable)ds.Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool AddOrganizationApplications(List< ATTOrganizationApplications> lstATT)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;

            try
            {
                DBConn = Conn.GetDbConn();

                string SPInsertUpdate = "";
                foreach (ATTOrganizationApplications objATT in lstATT)
                {
                    if (objATT.Action=="A")
                        SPInsertUpdate = "SP_ADD_ORG_APPLICATIONS";
                    else if (objATT.Action=="E")
                        SPInsertUpdate = "SP_EDIT_ORG_APPLICATIONS";
                    else if (objATT.Action=="R")
                        SPInsertUpdate="SP_DEL_ORG_APPLICATIONS";

                    OracleParameter[] ParamArray = new OracleParameter[3];

                    ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", objATT.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":p_APPL_ID", objATT.ApplID, OracleDbType.Int64, ParameterDirection.Input);
                    if (objATT.Action != "R")
                        ParamArray[2] = Utilities.GetOraParam(":p_FROM_DATE", objATT.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    else
                        ParamArray[2] = Utilities.GetOraParam(":p_TO_DATE", objATT.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SPInsertUpdate, ParamArray);
                }
                return true;
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

    }
}
