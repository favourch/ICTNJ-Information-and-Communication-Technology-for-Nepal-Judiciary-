using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLTameliWitnessPerson
    {
        public static bool AddEditDeleteTameliWitnessPerson(List<ATTTameliWitnessPerson> TameliWitPersonLIST,OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramList = new List<OracleParameter>();            
            try
            {
                foreach (ATTTameliWitnessPerson TamWitPerson in TameliWitPersonLIST)
                {
                    if (TamWitPerson.Action == "A")
                        InsertUpdateSQL = "SP_ADD_TAMELI_WIT_PERSON";
                    else if (TamWitPerson.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_TAMELI_WIT_PERSON";
                    else if (TamWitPerson.Action == "D")
                        InsertUpdateSQL = "SP_DEL_TAMELI_WIT_PERSON";

                    if (TamWitPerson.Action == "A" ||TamWitPerson.Action == "E")
                    {
                        paramList.Add(Utilities.GetOraParam(":P_CASE_ID", TamWitPerson.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", TamWitPerson.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", TamWitPerson.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", TamWitPerson.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_WIT_SEQ_NO", TamWitPerson.WitSeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramList.Add(Utilities.GetOraParam(":P_PERSON_FULL_NAME", TamWitPerson.FullName, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_PESON_POST", TamWitPerson.Post, OracleDbType.Varchar2, ParameterDirection.Input));

                        paramList.Add(Utilities.GetOraParam(":P_ENTRY_BY", TamWitPerson.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

              
                    }
                    if (TamWitPerson.Action == "D")
                    {
                        paramList.Add(Utilities.GetOraParam(":P_CASE_ID", TamWitPerson.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", TamWitPerson.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", TamWitPerson.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", TamWitPerson.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_WIT_SEQ_NO", TamWitPerson.WitSeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                        
                    }
                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());
                    paramList.Clear();

                }                
                return true;
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
            

        }
    }
}
