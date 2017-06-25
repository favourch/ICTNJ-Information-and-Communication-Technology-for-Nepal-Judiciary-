using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.CMS.DLL
{
    public class DLLMelMilapKartaOath
    {
        public static bool SaveMelMilaapKartaaOath(List<ATTMelMilapKartaOath> MMKOLst, OracleTransaction Tran)
        {            
            string InsertUpdateSQL = "";
            try
            {
                foreach (ATTMelMilapKartaOath attMMK in MMKOLst)
                {
                    if (attMMK.Action == "")
                        continue;
                    if (attMMK.Action == "A")
                        InsertUpdateSQL = "SP_ADD_MM_KARTAA_OATH";
                    else if (attMMK.Action == "D")
                        InsertUpdateSQL = "SP_DEL_MM_KARTAA_OATH";
                    else if (attMMK.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_MM_KARTAA_OATH";
                    if (attMMK.Action=="A"||attMMK.Action=="E")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", attMMK.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_PERSON_ID", attMMK.PersonID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", attMMK.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_JUDGE_ID", attMMK.JudgeID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attMMK.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_OLD_JUDGE_ID", attMMK.OldJudgeID, OracleDbType.Double, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    }
                }                
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            
        }

        public static DataTable GetMelMilaapKartaaOath(int orgID,double mmkID)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            string SelectSQL = "SP_GET_MM_KARTAA_OATH";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PERSON_ID", mmkID, OracleDbType.Double, ParameterDirection.Input));
                //paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", attMMK.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramArray.Add(Utilities.GetOraParam(":P_JUDGE_ID", attMMK.PID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray.ToArray());
                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
