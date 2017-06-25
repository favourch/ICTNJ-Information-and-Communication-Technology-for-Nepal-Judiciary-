using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using PCS.CMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;
using PCS.COREDL;
using System.Data;

namespace PCS.CMS.DLL
{
   public class DLLMelMilaapKartaa
    {
       public static bool SaveMelMilaapKartaa(List<ATTMelMilaapKartaa> MMKLst,List<ATTPerson> PersonList)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            string InsertUpdateSQL = "";
            try
            {
               
                double PID = 0;
                if (PersonList!=null)
                    PID = DLLPerson.AddPersonnelDetails(PersonList,Tran);

                foreach (ATTMelMilaapKartaa attMMK in MMKLst)
                {
                    if (PID > 0)
                        attMMK.PID = PID;
                    
                    if (attMMK.Action == "")
                        continue;
                   
                    if (attMMK.Action == "A")
                        InsertUpdateSQL = "SP_ADD_MM_KARTAA";
                    else if (attMMK.Action == "D")
                        InsertUpdateSQL = "SP_DEL_MM_KARTAA";
                    else
                        InsertUpdateSQL = "SP_EDIT_MM_KARTAA";

                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", attMMK.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_PERSON_ID", attMMK.PID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", attMMK.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_POST", attMMK.Post, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_EXPERIENCE", attMMK.Experience, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attMMK.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    if (attMMK.OathLst!=null)
                    {
                        foreach (ATTMelMilapKartaOath obj in attMMK.OathLst)
                        {
                            obj.PersonID = attMMK.PID;
                        }
                        
                        DLLMelMilapKartaOath.SaveMelMilaapKartaaOath(attMMK.OathLst, Tran);                        
                    }
                }
                Tran.Commit();
                return true;
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

       public static DataTable GetMelMilaapKartaa(int orgID)
       {
           GetConnection GetConn = new GetConnection();
           OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
           string SelectSQL = "SP_GET_MM_KARTAA";
           try
           {
               List<OracleParameter> paramArray = new List<OracleParameter>();
               paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
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
