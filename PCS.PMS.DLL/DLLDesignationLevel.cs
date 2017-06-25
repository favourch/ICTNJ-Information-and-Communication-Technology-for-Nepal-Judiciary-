using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.PMS.ATT;

namespace PCS.PMS.DLL
{
    public class DLLDesignationLevel
    {
        public static bool SaveDesignationLevel(ATTDesignationLevel att_obj)
        {
            string InsertUpdateDL;
            InsertUpdateDL = "";
            if (att_obj.LevelID > 0)
                InsertUpdateDL = "SP_EDIT_LEVEL";
            else if (att_obj.LevelID == 0)
                InsertUpdateDL = "SP_ADD_LEVEL";

            OracleParameter[] paramArray = new OracleParameter[3];

            paramArray[0] = Utilities.GetOraParam(":Level_ID", att_obj.LevelID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":Level_Name", att_obj.LevelName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":Entry_By", att_obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            GetConnection conn = new GetConnection();

            try
            {
                OracleConnection DBconn = conn.GetDbConn(Module.PMS);
                SqlHelper.ExecuteNonQuery(DBconn, CommandType.StoredProcedure, InsertUpdateDL, paramArray);
                att_obj.LevelID = int.Parse(paramArray[0].Value.ToString());

                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.CloseDbConn();
            }
        }

        public static DataTable GetDesignationLevelTable()
        {
            string SelectDL;
            SelectDL = "SP_GET_LEVEL";

            OracleParameter[] paramArray = new OracleParameter[1];

            //paramArray[0] = Utilities.GetOraParam(":Level_ID", levelID, OracleDbType.Int64, ParameterDirection.InputOutput);
            //paramArray[1] = Utilities.GetOraParam(":Level_Name", levelName, OracleDbType.Varchar2, ParameterDirection.Output);
            paramArray[0] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection conn = new GetConnection();

            try
            {
                OracleConnection DBconn = conn.GetDbConn(Module.PMS);
                SqlHelper.ExecuteNonQuery(DBconn, CommandType.StoredProcedure, SelectDL, paramArray);

                OracleDataReader rdr = ((OracleRefCursor)paramArray[0].Value).GetDataReader();
                DataTable tbl = new DataTable();
                tbl.Load(rdr, LoadOption.OverwriteChanges);

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.CloseDbConn();
            }
        }


    }
}
