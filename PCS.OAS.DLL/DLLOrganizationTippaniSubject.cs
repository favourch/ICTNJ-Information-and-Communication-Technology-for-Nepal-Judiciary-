using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLOrganizationTippaniSubject
    {
        public static DataTable GetOrganizaionTippaniSubject(int orgID)
        {
            string SP = "SP_GET_ORG_TIPPANI_SUBJECT";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int32, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddOrganizationTippaniSubject(List<ATTOrganizationTippaniSubject> lstATT)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;

            try
            {
                DBConn = Conn.GetDbConn(Module.OAS);

                string SPInsertUpdate = "";
                foreach (ATTOrganizationTippaniSubject objATT in lstATT)
                {
                    if (objATT.Action == "A")
                        SPInsertUpdate = "SP_ADD_ORG_TIPPANI";
                    else if (objATT.Action == "E")
                        SPInsertUpdate = "SP_EDIT_ORG_TIPPANI";
                   

                    OracleParameter[] ParamArray = new OracleParameter[4];
                    
                    ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", objATT.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":P_TIPPANI_SUBJECT_ID", objATT.TippaniSubjectID, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":P_FROM_DATE", objATT.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[3] = Utilities.GetOraParam(":P_TO_DATE", objATT.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);


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
