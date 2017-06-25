using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.PMS.DLL
{
    public class DLLAwardPunishment
    {
        public static DataTable GetAwards(double empid)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP = "SP_GET_EMP_AWARDS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_EMP_ID", empid, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPunishments(double empid)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP = "SP_GET_EMP_PUNISHMENTS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_EMP_ID", empid, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveAward(List<ATTAwardPunishment> LSTAward)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();

            string InsertUpdateDelete = "";
            try
            {
                foreach (ATTAwardPunishment var in LSTAward)
                {
                    if (var.Action == "A")
                    {
                        InsertUpdateDelete = "SP_ADD_EMP_AWARDS";
                    }
                    else if (var.Action == "E")
                    {
                        InsertUpdateDelete = "SP_EDIT_EMP_AWARDS";
                    }
                    else if (var.Action == "D")
                    {
                        InsertUpdateDelete = "SP_DEL_EMP_AWARDS";
                    }
                    if (var.Action == "A" || var.Action=="E")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", var.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", var.SequenceNo, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_AWARD ", var.Award, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_AWARD_DATE", var.AwardDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_VERIFIED_BY", var.VerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_VERIFIED_DATE", var.VerifiedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_REMARKS", var.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpdateDelete, paramArray.ToArray());
                    }
                    else if (var.Action == "D")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", var.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", var.SequenceNo, OracleDbType.Int32, ParameterDirection.Input));
                        DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpdateDelete, paramArray.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            Tran.Commit();
            return true;
        }

        public static bool SavePunishment(List<ATTAwardPunishment> LSTPunishment)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            string InsertUpdateDelete = "";
            try
            {
                foreach (ATTAwardPunishment var in LSTPunishment)
                {
                    if (var.Action == "A")
                    {
                        InsertUpdateDelete = "SP_ADD_EMP_PUNISHMENTS";
                    }
                      else if (var.Action == "E")
                    {
                        InsertUpdateDelete = "SP_EDIT_EMP_PUNISHMENTS";
                    }
                    else if (var.Action == "D")
                    {
                        InsertUpdateDelete = "SP_DEL_EMP_PUNISHMENTS";
                    }
                    if (var.Action == "A" || var.Action == "E")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", var.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", null, OracleDbType.Int32, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUNISHMENT", var.Punishment, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUNISHMENT_DATE", var.PunishmentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_VERIFIED_BY", var.VerifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_VERIFIED_DATE", var.VerifiedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_REMARKS", var.PunishmentRemarks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpdateDelete, paramArray.ToArray());
                    }
                    else if (var.Action == "D")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", var.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_SEQ_NO", var.SequenceNo, OracleDbType.Int32, ParameterDirection.Input));
                        DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpdateDelete, paramArray.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            Tran.Commit();
            return true;
        }
    }
}
