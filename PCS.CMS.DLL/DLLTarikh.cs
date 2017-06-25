using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COREDL;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLTarikh
    {
      
         public static bool AddTarikh(List<ATTTarikh> lstTarikh)
        {
            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.CMS);
            try
            {
                foreach (ATTTarikh objTarikh in lstTarikh)
                {

                    if (objTarikh.Action != "N")
                    {

                        string SPInsertUpdate = "";
                        if (objTarikh.Action == "A")
                            SPInsertUpdate = "SP_ADD_TARIKH";
                        if (objTarikh.Action == "E")
                            SPInsertUpdate = "SP_EDIT_TARIKH";
                        if (objTarikh.Action == "R")
                            SPInsertUpdate = "SP_DEL_TARIKH";


                        OracleParameter[] paramArray = new OracleParameter[4];
                        paramArray[0] = Utilities.GetOraParam("P_CASE_ID", objTarikh.CaseID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam("P_TARIKH_DATE", objTarikh.TarikhDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam("P_TARIKH_TIME", objTarikh.TarikhTime, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam("P_ENTRY_BY", objTarikh.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);



                        SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SPInsertUpdate, paramArray);

                    }
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
            return true;

        }

        public static bool AddTarikhDetails(List<ATTTarikh> lst)
        {
            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.CMS);
            try
            {
                foreach (ATTTarikh objTarikh in lst)
                {

                    if (objTarikh.Action != "N")
                    {
                        string SPInsertUpdate = "";
                        if (objTarikh.Action == "A")
                            SPInsertUpdate = "SP_ADD_TARIKH_DETAILS";
                        if (objTarikh.Action == "E")
                            SPInsertUpdate = "SP_EDIT_TARIKH_DETAILS";
                        if (objTarikh.Action == "R")
                            SPInsertUpdate = "SP_DEL_TARIKH_DETAILS";


                        List<OracleParameter> paramList = new List<OracleParameter>();
                        
                       paramList.Add(Utilities.GetOraParam("P_CASE_ID", objTarikh.CaseID, OracleDbType.Int16, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam("P_TARIKH_DATE", objTarikh.TarikhDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam("P_PERSON_ID", objTarikh.PersonID, OracleDbType.Int16, ParameterDirection.Input));
                        if (objTarikh.Action != "R")
                        {
                            paramList.Add(Utilities.GetOraParam("P_PERSON_TYPE", objTarikh.PersonType, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramList.Add(Utilities.GetOraParam("P_TAKEN_DATE", objTarikh.TakenTime, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramList.Add(Utilities.GetOraParam("P_PRESENT_DATE", objTarikh.PresentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramList.Add(Utilities.GetOraParam("P_REMARKS", objTarikh.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramList.Add(Utilities.GetOraParam("P_ENTRY_BY", objTarikh.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }



                        SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SPInsertUpdate, paramList.ToArray());

                    }
                }


            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
            return true;

        }

        public static DataTable GetTarikhDetails(int caseID,string tarikhDate)
        {
            GetConnection Conn = new GetConnection();

            string SelectSQL = "SP_GET_TARIKH_DETAILS";


            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam("P_CASE_ID", caseID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_TARIKH_DATE", tarikhDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetTarikh(int caseID)
        {
            GetConnection Conn = new GetConnection();

            string SelectSQL = "SP_GET_TARIKH";


            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam("P_CASE_ID", caseID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
    }
}
