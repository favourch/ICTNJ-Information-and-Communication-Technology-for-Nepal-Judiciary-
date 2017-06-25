using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.CMS.DLL
{
    public class DLLCaseRegistration
    {
        public static bool RegisterCase(ATTCaseRegistration objCaseRegistration)
        {
            string SP = "";

            if (objCaseRegistration.Action == "A")
                SP = "sp_add_case";
            else if (objCaseRegistration.Action == "E")
                SP ="sp_edit_case";
            else if (objCaseRegistration.Action == "D")
                SP = "sp_del_case";

            List<OracleParameter> paramArray = new List<OracleParameter>();
     
            paramArray.Add(Utilities.GetOraParam("P_CASE_ID", objCaseRegistration.CaseID, OracleDbType.Double, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_COURT_ID", objCaseRegistration.CourtID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_CASE_TYPE_ID", objCaseRegistration.CaseTypeID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_REG_TYPE_ID", objCaseRegistration.RegTypeID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_REG_DIARY_ID", objCaseRegistration.RegDiaryID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_REG_SUBJECT_ID", objCaseRegistration.RegSubjectID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_REG_DIARY_NAME_ID", objCaseRegistration.RegDiaryNameID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_CASE_REG_DATE", objCaseRegistration.CaseRegistrationDate, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_REG_NO", objCaseRegistration.RegistrationNumber, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_CASE_NO", objCaseRegistration.CaseNumber, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_WRIT_SUB_ID", objCaseRegistration.WritSubjectID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_WRIT_CAT_ID", objCaseRegistration.WritCatID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_WRIT_CAT_TITLE_ID", objCaseRegistration.WirtCatTitleID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_WRIT_CAT_SUBTITLE_ID", objCaseRegistration.WritCatSubTitleID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACCOUNT_FORWARDED", objCaseRegistration.AccountForwarded, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_VERIFIED_BY", objCaseRegistration.VerifiedBy, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_VERIFIED_YES_NO", objCaseRegistration.VerifiedYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_VERIFIED_DATE", objCaseRegistration.VerifiedDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_DARPITH_REMARKS", objCaseRegistration.DarpithRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_PROCEEDING_ID", objCaseRegistration.ProceedingID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_CASE_SUMMARY", objCaseRegistration.CaseSummary, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RELATED_CASE_ID", objCaseRegistration.RelatedCaseID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_FY", objCaseRegistration.FY, OracleDbType.Varchar2, ParameterDirection.Input));
            
            paramArray.Add(Utilities.GetOraParam("CASE_NUMBER", null, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("REG_NUMBER", null, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray[8].Size = 100;
            paramArray[9].Size = 100;
            paramArray[23].Size = 100;
            paramArray[24].Size = 100;
      

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            
                
            try
            {
               SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                
                objCaseRegistration.CaseID = double.Parse(paramArray[0].Value.ToString());
                objCaseRegistration.CaseNumber = paramArray[22].Value.ToString();
                objCaseRegistration.RegistrationNumber = paramArray[23].Value.ToString();

                if (objCaseRegistration.AppellantLST.Count > 0)
                    DLLLitigants.AddEditLitigants(objCaseRegistration.AppellantLST, Tran,objCaseRegistration.CaseID);

                if (objCaseRegistration.RespondantLST.Count > 0)
                    DLLLitigants.AddEditLitigants(objCaseRegistration.RespondantLST, Tran, objCaseRegistration.CaseID);

                if (objCaseRegistration.CaseCheckListLST.Count > 0)
                    DLLCaseCheckList.AddEditCaseCheckList(objCaseRegistration.CaseCheckListLST, Tran,objCaseRegistration.CaseID);

                if (objCaseRegistration.CaseAccountForwardLST.Count > 0)
                    DLLCaseAccountForward.SaveCaseAccountForward(objCaseRegistration.CaseAccountForwardLST, Tran,objCaseRegistration.CaseID);


                Tran.Commit();
                return true;
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

        //UPDATE CASE SUMMARY
        public static bool UpdateCaseSummary(ATTCaseRegistration objCaseRegistration)
        {
            string SP = "";

            
            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("P_CASE_ID", objCaseRegistration.CaseID, OracleDbType.Double, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_CASE_SUMMARY", objCaseRegistration.CaseSummary, OracleDbType.Varchar2, ParameterDirection.Input));
            
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();


            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "UPDATE_CASE_REG_SUMMARY", paramArray.ToArray());


                if (objCaseRegistration.CaseDocumentLST.Count > 0)
                {
                    List<ATTCaseDocuments> CDLST= DLLCaseDocuments.SaveCaseDocument(objCaseRegistration.CaseDocumentLST, Tran);
                    int idx;
                    foreach (ATTCaseDocumentsLit obj in objCaseRegistration.CaseDocumentLitLST)
                    {
                        idx = CDLST.FindIndex(delegate(ATTCaseDocuments objCD)
                                            {
                                                return obj.DocSeq == objCD.DocSeq && obj.Action != "" ;
                                            });
                        obj.DocumentID = CDLST[idx].DocumentID;
                    }
                }
                if (objCaseRegistration.CaseDocumentLitLST.Count>0)
                {
                    DLLCaseDocumentLit.SaveCaseDocumentLit(objCaseRegistration.CaseDocumentLitLST, Tran);
                }

                if (objCaseRegistration.CaseEvidenceLST.Count > 0)
                    DLLCaseEvidence.SaveCaseEvidence(objCaseRegistration.CaseEvidenceLST, Tran);


                Tran.Commit();
                return true;
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

        public static DataTable GetCaseRegistration(double? CaseID)
        {
            string SelectSql = "";
             SelectSql = "SP_GET_CASE_REGISTRATION";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", CaseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static DataTable GetCaseVerification(double? CaseID,string verifiedYN)
        {
            string SelectSql = "";
            SelectSql = "SP_GET_CASE_REGISTRATION";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", CaseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_VERIFIED_YN", verifiedYN, OracleDbType.Varchar2, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
