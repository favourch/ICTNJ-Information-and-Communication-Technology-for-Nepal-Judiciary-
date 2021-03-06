using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
   public  class DLLDesignation
    {
        public static DataTable GetDesignation(int? DesgId,string desType)
        {
            try
            {
                string SelectDesignationSql = "SP_GET_DESIGNATIONS";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_DES_ID", DesgId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_TYPE", desType, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static bool SaveDesignation(ATTDesignation ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string InsertUpdateDesignation = "";
            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();

                if (ObjAtt.DesignationID == 0)
                    InsertUpdateDesignation = "SP_ADD_DESIGNATIONS";
                else
                    InsertUpdateDesignation = "SP_EDIT_DESIGNATIONS";

                OracleParameter[] ParamArray = new OracleParameter[5];

                ParamArray[0] = Utilities.GetOraParam(":p_DES_ID", ObjAtt.DesignationID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_DESG_NAME", ObjAtt.DesignationName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_DESG_TYPE", ObjAtt.DesignationType, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_SERVICE_PERIOD", ObjAtt.ServicePeriod, OracleDbType.Int32, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":p_AGE_LIMIT", ObjAtt.AgeLimit, OracleDbType.Int32, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDesignation, ParamArray);

                int DesgID = int.Parse(ParamArray[0].Value.ToString());

                ObjAtt.DesignationID = DesgID;

                Tran.Commit();

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


       public static bool DeleteDesignation(int DesgID)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string DeleteDesignationSql = "SP_DEL_DESIGNATIONS ";

            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();

                OracleParameter[] ParamArray = new OracleParameter[1];
                ParamArray[0] = Utilities.GetOraParam(":p_DES_ID", DesgID, OracleDbType.Int64, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeleteDesignationSql, ParamArray);
                Tran.Commit();

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
