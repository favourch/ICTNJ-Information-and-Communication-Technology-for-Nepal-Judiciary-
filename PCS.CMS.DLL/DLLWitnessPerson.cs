using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLWitnessPerson
    {
        public static bool SaveWitnessPerson(List<ATTWitnessPerson> LstWP)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            try
            {
                foreach (ATTWitnessPerson objWP in LstWP)
                {

                    if (objWP.Action == "D" && objWP.WitnessID > 0)
                    {
                        string DelSql = "SP_DEL_WITNESS_PERSON";
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam(":P_WITNESS_ID", objWP.WitnessID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, DelSql, paramArray.ToArray());
                    }
                    else if (objWP.Action == "A" || objWP.Action == "E")
                    {
                        double personID = objWP.PersonID;
                        objWP.PersonOBJ.PId = personID;
                        if (personID == 0)
                        {
                            personID = int.Parse(DLLPerson.AddPersonnelDetails(objWP.PersonOBJ, Tran).ToString());
                        }
                        string InsertUpdateSQL = "";
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objWP.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", objWP.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_PERSON_ID", personID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objWP.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_WITNESS_ID", objWP.WitnessID, OracleDbType.Int32, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objWP.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (objWP.Action == "A")
                            InsertUpdateSQL = "SP_ADD_CASE_WITNESS";
                        else
                            InsertUpdateSQL = "SP_EDIT_CASE_WITNESS";

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());

                        objWP.WitnessID = int.Parse(paramArray[4].Value.ToString());

                    }
                    else
                        continue;
                }
                Tran.Commit();
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
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static DataTable getWitnessPerson(double? caseID,double? litigantID,double? personID,double? witnessID)
        {
            string SelectSql = "SP_GET_CASE_WITNESS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", litigantID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_PERSON_ID", personID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_WITNESS_ID", witnessID, OracleDbType.Int32, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC",null,OracleDbType.RefCursor,ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

       
    }
}
