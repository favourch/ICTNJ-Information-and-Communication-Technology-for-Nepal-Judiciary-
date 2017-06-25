using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.DLL
{
    public class DLLReligion
    {
        public static DataTable GetReligions(int? relgId)
        {
            try
            {
                string SelectSql = "SP_GET_RELIGIONS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":ReligionID", relgId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds=SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSql, ParamArray);

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

        public static int AddReligions(ATTReligion objReligions)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();
            int religionID = 0;
            try
            {
                string InsertUpdateSQL = "";

                if (objReligions.ReligionId <= 0)
                    InsertUpdateSQL = "SP_ADD_RELIGIONS";
                else
                    InsertUpdateSQL = "SP_EDIT_RELIGIONS";

                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":p_RELG_ID", objReligions.ReligionId, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_RELG_NEP_NAME", objReligions.ReligionNepName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_RELG_ENG_NAME", objReligions.ReligionEngName, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray[0], ParamArray);
                religionID = int.Parse(ParamArray[0].Value.ToString());
                Tran.Commit();

                return religionID;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }
    }
}
