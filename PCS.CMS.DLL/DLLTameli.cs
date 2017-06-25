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
    public class DLLTameli
    {
        public static bool AddEditDeleteTameli(List<ATTTameli> TameliLIST)        
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramList = new List<OracleParameter>();           
            
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                
                foreach (ATTTameli tameli in TameliLIST)
                {
                    if (tameli.Action == "A")
                        InsertUpdateSQL = "SP_ADD_TAMELI";
                    else if (tameli.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_TAMELI";
                    else if (tameli.Action == "D")
                        InsertUpdateSQL = "SP_DEL_TAMELI";

                    if (tameli.Action == "A" || tameli.Action == "E")
                    {


                        paramList.Add(Utilities.GetOraParam(":P_CASE_ID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", tameli.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", tameli.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramList.Add(Utilities.GetOraParam(":P_WITNESS_ID", tameli.WitnessID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ATTORNEY_ID", tameli.AttorneyID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ISSUED_BY", tameli.IssuedBy, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_RECEIVED_DATE", tameli.ReceivedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_RECEIVED_BY", tameli.ReceivedBy, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMELI_DATE", tameli.TameliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMELI_YES_NO", tameli.TameliYesNo, OracleDbType.Varchar2, ParameterDirection.Input));

                        paramList.Add(Utilities.GetOraParam(":P_SEC_CLRK_RCVD_DATE", tameli.SecClrkRcvdDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMILDAAR_REMARKS", tameli.TamilDaarRemrks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_VERIFIED_DATE", tameli.VerifiedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_VERIFIED_BY", tameli.VerifiedBy, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_VERIFIED_YES_NO", tameli.VerifiedYesNo, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_VERIFIED_REMARKS", tameli.VerifiedRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ATTEND_DAYS", tameli.AttendDays, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_MYAAD_TYPE_ID", tameli.MyaadTypeID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMELI_TYPE_ID", tameli.TameliTypeID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMELI_STATUS_ID", tameli.TameliStatusID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_TAMELI_ORG", tameli.TameliOrg, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ENTRY_BY", tameli.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_OLD_ISSUED_DATE", tameli.OldIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());
                        tameli.SeqNo = int.Parse(paramList[3].Value.ToString());

                        //foreach (ATTTameliWitnessPerson TWP in tameli.TameliWitnessPersonLIST)
                        //{
                        //    TWP.SeqNo = tameli.SeqNo;
                        //    TWP.IssuedDate = tameli.IssuedDate;
                        //}
                        foreach (ATTTameliMedia TWP in tameli.TameliMediaLIST)
                        {
                            TWP.SeqNo = tameli.SeqNo;
                            TWP.IssueDate = tameli.IssuedDate;
                        }

                        // DLLTameliWitnessPerson.AddEditDeleteTameliWitnessPerson(tameli.TameliWitnessPersonLIST, Tran);
                        DLLTameliMedia.AddEditDeleteTameliMedia(tameli.TameliMediaLIST, Tran);

                        paramList.Clear();
                    }
                    if (tameli.Action == "D")
                    {
                        DLLTameliMedia.AddEditDeleteTameliMedia(tameli.TameliMediaLIST, Tran);
                        DLLTameliWitnessPerson.AddEditDeleteTameliWitnessPerson(tameli.TameliWitnessPersonLIST, Tran);
                        
                        paramList.Add(Utilities.GetOraParam(":P_CASE_ID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", tameli.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", tameli.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());
                        paramList.Clear();
                    }
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


        public static bool ProcessTameli(ATTTameli tameli)
        {
            string InsertUpdateSQL = "SP_PROCESS_TAMELI";
            List<OracleParameter> paramList = new List<OracleParameter>();

            GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            //OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {

                //foreach (ATTTameli tameli in TameliLIST)
                //{
                    //if (tameli.Action == "A")
                    //    InsertUpdateSQL = "SP_ADD_TAMELI";
                    //else if (tameli.Action == "E")
                        //InsertUpdateSQL = "SP_EDIT_TAMELI";

                    paramList.Add(Utilities.GetOraParam(":P_CASE_ID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", tameli.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", tameli.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
                    
                    paramList.Add(Utilities.GetOraParam(":P_VERIFIED_DATE", tameli.VerifiedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_VERIFIED_BY", tameli.VerifiedBy, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_VERIFIED_YES_NO", tameli.VerifiedYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(Utilities.GetOraParam(":P_VERIFIED_REMARKS", tameli.VerifiedRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                    
                    SqlHelper.ExecuteNonQuery(DBConn, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());
                   

                    paramList.Clear();
                //}

               
                return true;

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                //Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }
        public static bool SaveTamelildaarFeedBack(ATTTameli tameli)
        {
            string InsertUpdateSQL = "SP_SAVE_TAMELILDAAR_FEEDBACK";
            List<OracleParameter> paramList = new List<OracleParameter>();

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            
            try
            {               
                paramList.Add(Utilities.GetOraParam(":P_CASE_ID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", tameli.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", tameli.SeqNo, OracleDbType.Int64, ParameterDirection.Input));

                paramList.Add(Utilities.GetOraParam(":P_TAMELI_DATE", tameli.TameliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_TAMELI_YES_NO", tameli.TameliYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_SEC_CLRK_RCVD_DATE", tameli.SecClrkRcvdDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_TAMILDAAR_REMARKS", tameli.TamilDaarRemrks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_TAMELI_STATUS_ID",( tameli.TameliStatusID>0)?tameli.TameliStatusID:null, OracleDbType.Int64, ParameterDirection.Input));
                
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());
                DLLTameliWitnessPerson.AddEditDeleteTameliWitnessPerson(tameli.TameliWitnessPersonLIST, Tran);

                paramList.Clear();
                //}

                Tran.Commit();
                return true;

            }
            catch (OracleException oex)
            {
                Tran.Rollback();
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                //Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }
        public static bool AssignTamildaar(ATTTameli tameli)
        {
            string InsertUpdateSQL = "SP_ASSIGN_TAMILDAAR";
            List<OracleParameter> paramList = new List<OracleParameter>();

            GetConnection GetConn = new GetConnection();
            OracleConnection DbConn = GetConn.GetDbConn(Module.CMS);

            try
            {
                paramList.Add(Utilities.GetOraParam(":P_CASE_ID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_LITIGANT_ID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_ISSUE_DATE", tameli.IssuedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_SEQ_NO", tameli.SeqNo, OracleDbType.Int64, ParameterDirection.Input));


                paramList.Add(Utilities.GetOraParam(":P_RECEIVED_BY", tameli.ReceivedBy, OracleDbType.Int64, ParameterDirection.Input));
                paramList.Add(Utilities.GetOraParam(":P_RECEIVED_DATE", tameli.ReceivedDate, OracleDbType.Varchar2, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(DbConn, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramList.ToArray());

                paramList.Clear(); 
                
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
        //public static DataTable GetTameli(int? checkListID, string active)
        //{

        //    string SelectSql = "SP_GET_CHECK_LIST";
        //    List<OracleParameter> ParamArray = new List<OracleParameter>();
        //    ParamArray.Add(Utilities.GetOraParam(":P_CHECK_LIST_ID", checkListID, OracleDbType.Int64, ParameterDirection.Input));
        //    ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
        //    ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //    try
        //    {
        //        DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
        //        return (DataTable)ds.Tables[0];

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

        
    }
}
