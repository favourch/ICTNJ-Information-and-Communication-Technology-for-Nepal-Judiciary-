using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.SECURITY.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client ;



namespace PCS.SECURITY.DLL
{
    public class DLLOrganizationUSers
    {
        public static DataTable GetUsersTable()
        {
            try
            {
                string SelectSQL = "SELECT * FROM USERS";

                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.Text, SelectSQL);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool AddOrganizationUsers(ATTOrganizationUsers objOrgUser, OracleTransaction Tran)
        //{
        //    string InsertSQL;
        //    try
        //    {
        //        InsertSQL = "SP_ADD_ORG_USERS";

        //        OracleParameter[] ParamArray = new OracleParameter[3];

        //        ParamArray[0] = Utilities.GetOraParam(":p_org_id", objOrgUser.OrgID, OracleDbType.Int64, ParameterDirection.Input);
        //        ParamArray[1] = Utilities.GetOraParam(":p_user-name", objOrgUser.Username, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[2] = Utilities.GetOraParam(":p_from_date", objOrgUser.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);

        //        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSQL, ParamArray);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        //public static bool EditOrganizationUsers(ATTOrganizationUsers objOrgUser, OracleTransaction Tran)
        //{
        //    string UpdateSQL;
        //    try
        //    {

        //        UpdateSQL = "SP_ADD_ORG_USERS";

        //        OracleParameter[] ParamArray = new OracleParameter[3];

        //        ParamArray[0] = Utilities.GetOraParam(":p_org_id", objOrgUser.OrgID, OracleDbType.Int64, ParameterDirection.Input);
        //        ParamArray[1] = Utilities.GetOraParam(":p_user-name", objOrgUser.Username, OracleDbType.Varchar2, ParameterDirection.Input);
        //        ParamArray[2] = Utilities.GetOraParam(":p_from_date", objOrgUser.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);

        //        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, UpdateSQL, ParamArray);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        public static DataTable GetOrgUsersTable(int orgID)
        {
            try
            {
                //string SelectSQL = "SELECT * FROM USERS a, ORGNIZATION_USERS b WHERE a.USER_NAME=b.USER_NAME and b.ORG_ID=:orgID and b.TO_DATE IS NULL";
                string SPSelect = "SP_GET_ORG_USERS";
                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":P_org_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_User_name", null, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = PCS.COREDL.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool AddOrgUsers(ATTOrganizationUsers obj)
        {
            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;

            DBConn = Conn.GetDbConn();
            Tran = DBConn.BeginTransaction();

            try
            {
                string InsertUpdateSP = "";

                if (obj.ObjUsers != null)
                    DLLUsers.AddUsers(obj.ObjUsers, Tran);

                if (obj.Action == "A")
                    InsertUpdateSP = "SP_ADD_ORG_USERS";
                else
                    InsertUpdateSP = "SP_EDIT_ORG_USERS";

                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":p_Org_ID", obj.OrgID, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_User_name", obj.Username, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_From_Date", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, ParamArray);


                if (obj.LSTUserRoles != null)
                    DLLUserRoles.AddUserRoles(obj.LSTUserRoles, Tran);

                Tran.Commit();
                return true;
            }
            catch (System.Exception ex)
            {
                //OracleError
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }

        public static bool SaveOrganizationUsers(ATTOrganizationUsers obj, OracleTransaction Tran, double pid)
        {

            try
            {
                string InsertUpdateSP = "";

                if (obj.Action == "A")
                    InsertUpdateSP = "SP_ADD_ORG_USERS";
                if (obj.Action == "A")
                {
                    OracleParameter[] ParamArray = new OracleParameter[3];

                    ParamArray[0] = Utilities.GetOraParam(":p_Org_ID", obj.OrgID, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":p_User_name", obj.Username, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":p_From_Date", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, ParamArray);
                }

                return true;
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public static bool EditOrgUsers(ATTOrganizationUsers obj)
        {
            //PCS.COREDL.GetConnection Conn = new GetConnection();
            //OracleConnection DBConn;
            //OracleTransaction Tran;

            //DBConn = Conn.GetDbConn();
            //Tran = DBConn.BeginTransaction();

            //try
            //{
            //    string UpdateSP = "";

            //    if (obj.ObjUsers != null)
            //        DLLUsers.UpdateUsers(obj.ObjUsers, Tran);

            //    UpdateSP = "SP_EDIT_ORG_USERS";

            //    OracleParameter[] ParamArray = new OracleParameter[3];

            //    ParamArray[0] = Utilities.GetOraParam(":p_Org_ID", obj.OrgID, OracleDbType.Varchar2, ParameterDirection.Input);
            //    ParamArray[1] = Utilities.GetOraParam(":p_User_name", obj.Username, OracleDbType.Varchar2, ParameterDirection.Input);
            //    ParamArray[2] = Utilities.GetOraParam(":p_From_Date", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);

            //    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, UpdateSP, ParamArray);


            //    if (obj.ObjUsers.LSTUserRoles != null)
            //        DLLUserRoles.EditUserRoles(obj.ObjUsers.LSTUserRoles, Tran);

            //    Tran.Commit();
                return true;
            //}
            //catch (System.Exception ex)
            //{
            //    Tran.Rollback();
            //    throw ex;
            //}
            //finally
            //{
            //    Conn.CloseDbConn();
            //}
        }
    }


}
