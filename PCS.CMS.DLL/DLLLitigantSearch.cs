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
    public class DLLLitigantSearch
    {
        

        public static DataTable GetLitigantSearch(ATTLitigantSearch litigantSearch)
        {

            try
            {                
                string SelectSql = "SELECT * FROM VW_CASE_REGISTRATION  WHERE 1=1  ";
             
                List<OracleParameter> ParamLIST = new List<OracleParameter>();
                if (litigantSearch.CourtID > 0)
                {
                    SelectSql += " AND COURT_ID = :CourtId";
                    ParamLIST.Add(Utilities.GetOraParam(":CourtId", litigantSearch.CourtID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (litigantSearch.CaseID > 0)
                {
                    SelectSql += " AND CASE_ID = :CaseId";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseId", litigantSearch.CaseID, OracleDbType.Int64, ParameterDirection.Input));
                } 
               
                if (!string.IsNullOrEmpty(litigantSearch.CaseNo))
                {                   
                    SelectSql += " AND CASE_NUMBER = :CaseNo";
                    ParamLIST.Add( Utilities.GetOraParam(":CaseNo", litigantSearch.CaseNo, OracleDbType.Varchar2, ParameterDirection.Input));
                   
                }
                if (!string.IsNullOrEmpty(litigantSearch.RegNo ))
                {
                    SelectSql += " AND REG_NUMBER = :RegNo";
                    ParamLIST.Add(Utilities.GetOraParam(":RegNo", litigantSearch.RegNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (!string.IsNullOrEmpty( litigantSearch.LitigantType ))
                {
                    SelectSql += " AND LITIGANT_TYPE = :LitigantType";
                    ParamLIST.Add(Utilities.GetOraParam(":LitigantType", litigantSearch.LitigantType, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (litigantSearch.LitigantSubTypeID>0)
                {
                    SelectSql += " AND LITIGANT_SUB_TYPE_ID = :LitigantSubTypeId";
                    ParamLIST.Add(Utilities.GetOraParam(":LitigantSubTypeId", litigantSearch.LitigantSubTypeID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (!string.IsNullOrEmpty(litigantSearch.AccountForwarded))
                {
                    SelectSql += " AND ACCOUNT_FORWARDED = :AccForwarded";
                    ParamLIST.Add(Utilities.GetOraParam(":AccForwarded", litigantSearch.AccountForwarded, OracleDbType.Varchar2, ParameterDirection.Input));
                }
                if (!string.IsNullOrEmpty(litigantSearch.Verified))
                {
                    SelectSql += " AND Verified = :Verified";
                    ParamLIST.Add(Utilities.GetOraParam(":Verified", litigantSearch.Verified, OracleDbType.Varchar2, ParameterDirection.Input));
                }


                SelectSql += " ORDER BY CASE_ID";

                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSql,ParamLIST.ToArray());
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
