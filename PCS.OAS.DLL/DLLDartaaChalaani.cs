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
    public class DLLDartaaChalaani
    {
        public static DataTable GetDartaaChalaaniByIDs(int orgID, string regDate, int regNo)
        {
            string SP = "sp_GET_DARTAA_CHALANI_BY_IDs";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_reg_date", regDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_reg_no", regNo, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static DataTable GetDartaaChalaani(int? docID, int? unitID, int? orgID)
        //{
        //    string SelectSQL = "SP_GET_DOCUMENT";

        //    OracleParameter[] paramArray = new OracleParameter[4];
        //    paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int16, ParameterDirection.Input);
        //    paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", unitID, OracleDbType.Int16, ParameterDirection.Input);
        //    paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", docID, OracleDbType.Int16, ParameterDirection.Input);
        //    paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

        //    GetConnection GetConn = new GetConnection();

        //    try
        //    {
        //        OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
        //        SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
        //        OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

        //        DataTable tbl = new DataTable();
        //        tbl.Load(reader, LoadOption.OverwriteChanges);

        //        return tbl;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw (ex);
        //    }
        //    finally
        //    {
        //        GetConn.CloseDbConn();
        //    }
        //}

        /// <summary>
        /// Add ItemUnit object to database
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>
        /// <returns>return bool</returns>
        public static bool SaveDartaaChalaani(ATTDartaaChalaani obj)
        {
            GetConnection getConn = new GetConnection();
            OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
           // OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {

                //foreach (ATTInvItems obj in lstItems)
                //{
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":p_org_id", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_reg_date", obj.RegDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_reg_no", obj.RegNo, OracleDbType.Double, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":p_reg_type", obj.RegType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_subject", obj.Subject, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_description", obj.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_phy_dig_flag", obj.PhysicalDigital, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_reg_file", obj.RegFile, OracleDbType.Blob, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_fwd_unit", obj.FwdUnit, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_fwd_person", obj.FwdPerson, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_send_org", obj.SendOrg, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_send_unit", obj.SendUnit, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_send_person", obj.SendPerson, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_send_date", obj.SendDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                                        
                        SqlHelper.ExecuteNonQuery(DBConn , CommandType.StoredProcedure, "sp_add_dartaa_chalaani", paramArray.ToArray());
                     obj.RegNo = int.Parse(paramArray[2].Value.ToString());
                    paramArray.Clear();
                //}
               // Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
