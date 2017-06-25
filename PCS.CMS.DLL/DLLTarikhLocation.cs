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
    public class DLLTarikhLocation
    {
        public static bool AddTarikhLocation(List<ATTTarikhLocation> lstTarikhLoc)
        {
            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.CMS);
            try
            {
                foreach (ATTTarikhLocation objTarikhLoc in lstTarikhLoc)
                {
                    if (objTarikhLoc.Action != "Rem")
                    {
                        string SPInsertUpdate = "";
                        if (objTarikhLoc.Action == "A")
                            SPInsertUpdate = "SP_ADD_TARIKH_LOCATION";
                        if (objTarikhLoc.Action == "R")
                            SPInsertUpdate = "SP_DEL_TARIKH_LOCATION";
                       

                        OracleParameter[] paramArray = new OracleParameter[6];
                        paramArray[0] = Utilities.GetOraParam("P_CASE_ID", objTarikhLoc.CaseID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam("P_PERSON_ID", objTarikhLoc.PersonID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam("P_COURT_ID", objTarikhLoc.CourtID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam("P_FROM_DATE", objTarikhLoc.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam("P_PERSON_TYPE", objTarikhLoc.PersonType, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam("P_ENTRY_BY", objTarikhLoc.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);


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


        public static DataTable GetTarikhLocation(int caseId)
        {
            GetConnection Conn = new GetConnection();
           
                string SelectSQL="SP_GET_TARIKH_LOCATION";

                //SelectSQL = "SELECT FIRST_NAME||' '||MID_NAME||' '||SUR_NAME AS Name,O.ORG_NAME,TL.FROM_DATE,TL.PERSON_TYPE,TL.CASE_ID,TL.PERSON_ID FROM TARIKH_LOCATION TL INNER JOIN PERSON P ON TL.PERSON_ID=P.P_ID INNER JOIN ORGNIZATIONS O ON TL.COURT_ID=O.ORG_ID  WHERE TL.CASE_ID =" + caseId;
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0]=Utilities.GetOraParam("P_CASE_ID",caseId,OracleDbType.Int16,ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool DeleteTarikhLocation(int caseId, int courtId,int personId)
        {
            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.CMS);
            try
            {
                
                        string SPInsertUpdate = "SP_DEL_TARIKH_LOCATION";

                        OracleParameter[] paramArray = new OracleParameter[3];

                        paramArray[0] = Utilities.GetOraParam("P_CASE_ID",caseId, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam("P_COURT_ID", courtId, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam("P_PERSON_ID", personId, OracleDbType.Int16, ParameterDirection.Input);
                      
                        SqlHelper.ExecuteNonQuery(Conn,CommandType.StoredProcedure, SPInsertUpdate, paramArray);

                        return true;         

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
            



        }
    }
}
