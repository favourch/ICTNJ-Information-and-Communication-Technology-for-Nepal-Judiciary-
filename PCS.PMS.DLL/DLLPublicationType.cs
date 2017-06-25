using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.PMS.ATT;
using System.Data;


namespace PCS.PMS.DLL
{
    public class DLLPublicationType
    {
        public static DataTable GetPublicationType(int? pubtypeid, string active)
        {
            string SelectCmd = "SP_GET_PUB_TYPE";
            OracleParameter[] paramArray = new OracleParameter[3];

            paramArray[0] = Utilities.GetOraParam(":P_PUBLICATION_TYPE_ID", pubtypeid, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection conn = new GetConnection();

            try
            {
                OracleConnection DBConn = conn.GetDbConn(Module.PMS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectCmd, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();
                DataTable dtb = new DataTable();
                dtb.Load(reader, LoadOption.OverwriteChanges);
                return dtb;
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

        public static bool SavePublicationType(ATTPublicationType ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            string InsertUpdatePubTypeSql = "";

            if (ObjAtt.Action == "A")
                InsertUpdatePubTypeSql = "SP_PMS_ADD_PUBLICATION_TYPE";
            else if(ObjAtt.Action == "E")
                InsertUpdatePubTypeSql = "SP_PMS_EDIT_PUBLICATION_TYPE";

            try
            {
                OracleParameter[] ParamArray = new OracleParameter[4];
                ParamArray[0] = Utilities.GetOraParam(":P_PUB_TYPE_ID", ObjAtt.PubTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(": P_PUB_TYPE_NAME", ObjAtt.PubTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_ACTIVE  ", ObjAtt.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePubTypeSql, ParamArray);
                ObjAtt.PubTypeID = int.Parse(ParamArray[0].Value.ToString());
                ObjAtt.PubTypeName = ParamArray[1].Value.ToString();
                ObjAtt.Active = ParamArray[2].Value.ToString();
                Tran.Commit();
                return true;

                //return newPublicationTypeID;

            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }
    }
}
