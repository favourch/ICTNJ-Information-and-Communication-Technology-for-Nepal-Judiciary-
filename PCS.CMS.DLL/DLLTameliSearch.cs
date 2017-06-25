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
    public class DLLTameliSearch
    {
        public static DataTable GetTameliSearch(ATTTameliSearch tameli)
        {

            try
            {
               // string SelectSql = "SELECT * FROM VW_TAMELI_INFO  WHERE 1=1  ";
                string SelectSql = "SELECT * FROM VW_TAMELI_INFO  WHERE ((court_id=" + tameli.OrgID + " and tameli_org is null and received_by>0) or (tameli_org =" + tameli.OrgID + " and received_by>0 ))";

                List<OracleParameter> ParamLIST = new List<OracleParameter>();

                if (tameli.CaseID > 0)
                {
                    SelectSql += " AND CASE_ID = :CaseID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));

                }
                if (tameli.LitigantID > 0)
                {
                    SelectSql += " AND LITIGANT_ID = :LitigantID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (tameli.CaseTypeID > 0)
                {
                    SelectSql += " AND CASE_TYPE_ID = :CaseTypeID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseTypeID", tameli.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));

                }
                if (tameli.RegNo != null)
                {
                    if (tameli.RegNo != "")
                    {
                        SelectSql += " AND REG_NO = :RegNo";
                        ParamLIST.Add(Utilities.GetOraParam(":RegNo", tameli.RegNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.CaseNo != null)
                {
                    if (tameli.CaseNo != "")
                    {
                        SelectSql += " AND CASE_NO = :CaseNo";
                        ParamLIST.Add(Utilities.GetOraParam(":CaseNo", tameli.CaseNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                if (tameli.CaseRegDate != null)
                {
                    if (tameli.CaseRegDate != "")
                    {
                        SelectSql += " AND CASE_REG_DATE = :CaseRegDate";
                        ParamLIST.Add(Utilities.GetOraParam(":CaseRegDate", tameli.CaseRegDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                if (tameli.TameliYesNo != null)
                {
                    if (tameli.TameliYesNo == "null")
                    {
                        SelectSql += " AND TAMELI_YES_NO is NULL  ";
                    }
                    else if (tameli.TameliYesNo == "notnull")
                    {
                        SelectSql += " AND TAMELI_YES_NO is NOT NULL  ";
                    }
                    else if (tameli.TameliYesNo != "")
                    {
                        SelectSql += " AND TAMELI_YES_NO = :TameliYesNo";
                        ParamLIST.Add(Utilities.GetOraParam(":TameliYesNo", tameli.TameliYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.TameliDate != null)
                {
                    if (tameli.TameliDate== "null")
                    {
                        SelectSql += " AND TAMELI_DATE is NULL  ";
                    }
                    else if (tameli.TameliDate == "notnull")
                    {
                        SelectSql += " AND TAMELI_DATE is not  NULL  ";
                    }
                    else if (tameli.TameliDate != "")
                    {
                        SelectSql += " AND TAMELI_DATE = :TameliDate";
                        ParamLIST.Add(Utilities.GetOraParam(":TameliDate", tameli.TameliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.SecClrkRcvdDate != null)
                {
                    if (tameli.SecClrkRcvdDate == "null")
                    {
                        SelectSql += " AND SEC_CLRK_RCVD_DATE is NULL  ";
                    }
                    else if (tameli.TameliDate == "notnull")
                    {
                        SelectSql += " AND TAMELI_DATE is not  NULL  ";
                    }
                    else if (tameli.TameliYesNo != "")
                    {
                        SelectSql += " AND SEC_CLRK_RCVD_DATE = :SecClrkRcvdDate";
                        ParamLIST.Add(Utilities.GetOraParam(":SecClrkRcvdDate", tameli.SecClrkRcvdDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.VerifiedYesNo != null)
                {
                    if (tameli.VerifiedYesNo == "null")
                    {
                        SelectSql += " AND VERIFIED_YES_NO is NULL  ";
                    }
                    else if (tameli.VerifiedYesNo == "notnull")
                    {
                        SelectSql += " AND VERIFIED_YES_NO is not  NULL  ";
                    }
                    else 
                    {
                        SelectSql += " AND VERIFIED_YES_NO = :VerifiedYesNo";
                        ParamLIST.Add(Utilities.GetOraParam(":VerifiedYesNo", tameli.VerifiedYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    
                    }
                }


                SelectSql += " ORDER BY ISSUED_DATE";

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
        public static DataTable GetTameliForFeedBack(ATTTameliSearch tameli)
        {

            try
            {
                string SelectSql = "SELECT * FROM VW_TAMELI_INFO  WHERE ((court_id=" + tameli.OrgID + " and tameli_org is null and received_by>0) or (tameli_org =" + tameli.OrgID + " and received_by>0 ))";
                
                List<OracleParameter> ParamLIST = new List<OracleParameter>();

                if (tameli.CaseID > 0)
                {
                    SelectSql += " AND CASE_ID = :CaseID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseID", tameli.CaseID, OracleDbType.Int64, ParameterDirection.Input));

                }
                if (tameli.LitigantID > 0)
                {
                    SelectSql += " AND LITIGANT_ID = :LitigantID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseID", tameli.LitigantID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (tameli.CaseTypeID > 0)
                {
                    SelectSql += " AND CASE_TYPE_ID = :CaseTypeID";
                    ParamLIST.Add(Utilities.GetOraParam(":CaseTypeID", tameli.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));

                }
                if (tameli.RegNo != null)
                {
                    if (tameli.RegNo != "")
                    {
                        SelectSql += " AND REG_NO = :RegNo";
                        ParamLIST.Add(Utilities.GetOraParam(":RegNo", tameli.RegNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.CaseNo != null)
                {
                    if (tameli.CaseNo != "")
                    {
                        SelectSql += " AND CASE_NO = :CaseNo";
                        ParamLIST.Add(Utilities.GetOraParam(":CaseNo", tameli.CaseNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                if (tameli.CaseRegDate != null)
                {
                    if (tameli.CaseRegDate != "")
                    {
                        SelectSql += " AND CASE_REG_DATE = :CaseRegDate";
                        ParamLIST.Add(Utilities.GetOraParam(":CaseRegDate", tameli.CaseRegDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                if (tameli.TameliYesNo != null)
                {
                    if (tameli.TameliYesNo == "null")
                    {
                        SelectSql += " AND TAMELI_YES_NO is NULL  ";
                    }
                    else if (tameli.TameliYesNo != "")
                    {
                        SelectSql += " AND TAMELI_YES_NO = :TameliYesNo";
                        ParamLIST.Add(Utilities.GetOraParam(":TameliYesNo", tameli.TameliYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.TameliDate != null)
                {
                    if (tameli.TameliDate == "null")
                    {
                        SelectSql += " AND TAMELI_DATE is NULL  ";
                    }
                    else if (tameli.TameliDate == "notnull")
                    {
                        SelectSql += " AND TAMELI_DATE is not  NULL  ";
                    }
                    else if (tameli.TameliDate != "")
                    {
                        SelectSql += " AND TAMELI_DATE = :TameliDate";
                        ParamLIST.Add(Utilities.GetOraParam(":TameliDate", tameli.TameliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.SecClrkRcvdDate != null)
                {
                    if (tameli.SecClrkRcvdDate == "null")
                    {
                        SelectSql += " AND SEC_CLRK_RCVD_DATE is NULL  ";
                    }
                    else if (tameli.TameliDate == "notnull")
                    {
                        SelectSql += " AND TAMELI_DATE is not  NULL  ";
                    }
                    else if (tameli.TameliYesNo != "")
                    {
                        SelectSql += " AND SEC_CLRK_RCVD_DATE = :SecClrkRcvdDate";
                        ParamLIST.Add(Utilities.GetOraParam(":SecClrkRcvdDate", tameli.SecClrkRcvdDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }
                if (tameli.VerifiedYesNo != null)
                {
                    if (tameli.VerifiedYesNo == "null")
                    {
                        SelectSql += " AND VERIFIED_YES_NO is NULL  ";
                    }
                    else if (tameli.VerifiedYesNo == "notnull")
                    {
                        SelectSql += " AND VERIFIED_YES_NO is not  NULL  ";
                    }
                    else
                    {
                        SelectSql += " AND VERIFIED_YES_NO = :VerifiedYesNo";
                        ParamLIST.Add(Utilities.GetOraParam(":VerifiedYesNo", tameli.VerifiedYesNo, OracleDbType.Varchar2, ParameterDirection.Input));

                    }
                }


                SelectSql += " ORDER BY ISSUED_DATE";

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
        public static DataTable GetTameliForAssigningTamildaar(int orgID)
        {

            try
            {
                string SelectSql = "SELECT * FROM VW_TAMELI_INFO  WHERE TAMELI_ORG=" + orgID + " AND RECEIVED_BY is null";
            
                SelectSql += " ORDER BY ISSUED_DATE";
                List<OracleParameter> ParamLIST = new List<OracleParameter>();
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
