using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.CMS.DLL
{
    public class DLLCaseSearch
    {
        public static DataTable GetCaseSearch(ATTCaseSearch caseSearch)
        {

            try
            {
                string SelectSql = "SELECT * FROM VW_CASE_REG  WHERE 1=1  ";

                List<OracleParameter> ParamLIST = new List<OracleParameter>();
                if (caseSearch.CourtID > 0)
                {
                    SelectSql += " AND COURT_ID = :CourtId";
                    ParamLIST.Add(Utilities.GetOraParam(":CourtId", caseSearch.CourtID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (!string.IsNullOrEmpty(caseSearch.CaseNo))
                {
                    SelectSql += " AND CASE_NUMBER = :CaseNo";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseNo", caseSearch.CaseNo, OracleDbType.Varchar2, ParameterDirection.Input));

                }
                if (!string.IsNullOrEmpty(caseSearch.RegNo))
                {
                    SelectSql += " AND REG_NUMBER = :RegNo";
                    ParamLIST.Add(Utilities.GetOraParam(":RegNo", caseSearch.RegNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (caseSearch.CaseTypeID > 0)
                {
                    SelectSql += " AND CASE_TYPE_ID = :CaseTypeID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseTypeID", caseSearch.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (!string.IsNullOrEmpty(caseSearch.RegDate))
                {
                    SelectSql += " AND CASE_REG_DATE = :RegDate";
                    ParamLIST.Add(Utilities.GetOraParam(":RegDate", caseSearch.RegDate, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (!string.IsNullOrEmpty(caseSearch.Appelant))
                {                   
                    SelectSql += " AND APPELLANT LIKE  '%'|| :Appelant ||'%' ";
                    ParamLIST.Add(Utilities.GetOraParam(":Appelant", caseSearch.Appelant, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (!string.IsNullOrEmpty(caseSearch.Respondant))
                {
                    SelectSql += " AND RESPONDENT LIKE  '%'|| :Respondant ||'%' ";
                    ParamLIST.Add(Utilities.GetOraParam(":Respondant", caseSearch.Respondant, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                //if (caseSearch.LitigantSubTypeID > 0)
                //{
                //    SelectSql += " AND LITIGANT_SUB_TYPE_ID = :LitigantSubTypeId";
                //    ParamLIST.Add(Utilities.GetOraParam(":LitigantSubTypeId", caseSearch.LitigantSubTypeID, OracleDbType.Int64, ParameterDirection.Input));
                //}

                if (!string.IsNullOrEmpty(caseSearch.AccountForwarded))
                {
                    SelectSql += " AND ACCOUNT_FORWARDED = :AccForwarded";
                    ParamLIST.Add(Utilities.GetOraParam(":AccForwarded", caseSearch.AccountForwarded, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (caseSearch.Verified != null)
                {
                    if (caseSearch.Verified == "U")
                    {
                        SelectSql += " AND VERIFIED_YES_NO is null";
                    }
                    else
                    {

                        SelectSql += " AND VERIFIED_YES_NO = :Verified";
                        ParamLIST.Add(Utilities.GetOraParam(":Verified", caseSearch.Verified, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                if (caseSearch.DecisionYesNo != null)
                {
                    if (caseSearch.DecisionYesNo == "U")
                    {
                        SelectSql += " AND DECISION_YES_NO is null";
                    }
                    else
                    {
                        SelectSql += " AND DECISION_YES_NO = :Verified";
                        ParamLIST.Add(Utilities.GetOraParam(":Verified", caseSearch.DecisionYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                



                SelectSql += " ORDER BY CASE_ID";

                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSql, ParamLIST.ToArray());
                return (DataTable)ds.Tables[0];

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, SelectSql, ParamLIST.ToArray());                
                //return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
