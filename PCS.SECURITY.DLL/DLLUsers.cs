using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;


using Oracle.DataAccess.Client;

namespace PCS.SECURITY.DLL
{
    public  class DLLUsers
    {
        public static DataTable GetUsersTable(string  Username)
        {
            try
            {
                string SPSelect ;

                OracleParameter[] ParamArray; 

                if (Username == "")
                {
                    //SelectSQL = "SELECT * FROM USERS";
                    SPSelect = "SP_GET_USERS";
                    ParamArray= new OracleParameter[1];
                    ParamArray[0] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                }
                else
                {
                    //SelectSQL = "SELECT * FROM USERS a, ORGNIZATION_USERS b WHERE a.USER_NAME=b.USER_NAME  and b.USER_NAME=:Username";
                    ParamArray = new OracleParameter[3];
                    SPSelect = "SP_GET_ORG_USERS";
                    //ParamArray[0] = Utilities.GetOraParam(":Username", Username, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[0] = Utilities.GetOraParam(":P_org_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":Username", Username, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                }

                
                
                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect,ParamArray );
                return (DataTable)ds.Tables[0];
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool AddUsers(ATTUsers objUser, OracleTransaction Tran)
        {
            double? pID;
            try
            {
                string InsertUpdateSP = "";

                if (objUser.Action == "A")
                    InsertUpdateSP = "SP_ADD_USERS";
                else
                    InsertUpdateSP = "SP_EDIT_USERS";

                if (objUser.PID == 0)
                    pID = null;
                else
                    pID = objUser.PID;

                OracleParameter[] ParamArray = new OracleParameter[6];

                ParamArray[0] = Utilities.GetOraParam(":p_user_name", objUser.Username, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_password", objUser.Password, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_createdby", objUser.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_active", objUser.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":p_valid_upto", objUser.ValidUpto, OracleDbType.Date, ParameterDirection.Input);
                ParamArray[5] = Utilities.GetOraParam(":p_PID", pID, OracleDbType.Double, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, ParamArray);


                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        public static bool SaveUsers(ATTUsers objUser, OracleTransaction Tran,double pid)
        {
            
            try
            {
                string InsertUpdateSP = "";
                
                    if (objUser.Action == "A")
                        InsertUpdateSP = "SP_ADD_USERS";
                    else if(objUser.Action=="E")
                        InsertUpdateSP = "SP_EDIT_USERS";


                    if (objUser.Action == "A" || objUser.Action == "E")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[6];

                        ParamArray[0] = Utilities.GetOraParam(":p_user_name", objUser.Username, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":p_password", objUser.Password, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[2] = Utilities.GetOraParam(":p_createdby", objUser.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":p_active", objUser.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[4] = Utilities.GetOraParam(":p_valid_upto", objUser.ValidUpto, OracleDbType.Date, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":p_PID", pid, OracleDbType.Double, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, ParamArray);
                    }

                return true;
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        //public static bool UpdateUsers(ATTUsers objUser, OracleTransaction Tran)
        //{
        //    PCS.COREDL.GetConnection Conn = new GetConnection();
        //    OracleConnection DBConn;

        //    DBConn = Conn.GetDbConn();

        //    try
        //    {
        //        string UpdateSP = "";

        //        UpdateSP = "SP_EDIT_USERS";

        //        OracleParameter[] ParamArray = new OracleParameter[5];

        //        ParamArray[0] = Utilities.GetOraParam(":p_user_name", objUser.Username, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[1] = Utilities.GetOraParam(":p_password", objUser.Password, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[2] = Utilities.GetOraParam(":p_createdby", objUser.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[3] = Utilities.GetOraParam(":p_active", objUser.Active, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[4] = Utilities.GetOraParam(":p_valid_upto", objUser.ValidUpto, OracleDbType.Date, ParameterDirection.Input);

        //        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, UpdateSP, ParamArray);


        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}
