using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLTippaniChannel
    {
        public static DataTable GetTippaniChannel(int? orgID, int? tippaniSubjectID)
        {
            string SQL = "select * from VW_TIPPANI_CHANNEL_INFO WHERE 1 = 1 ";

            if (orgID != null)
            {
                SQL = SQL + " and ot_org_id = " + orgID.ToString();
            }

            if (tippaniSubjectID != null)
            {
                SQL = SQL + " and tippani_subject_id = " + tippaniSubjectID.ToString();
            }

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, null).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddTippaniChannel(List<ATTTippaniChannel> lst)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection DBConn = new GetConnection();
            OracleTransaction Tran = DBConn.GetDbConn(Module.OAS).BeginTransaction();
            try
            {
                foreach (ATTTippaniChannel channel in lst)
                {
                    if (channel.Action == "A")
                        SP = "SP_ADD_CHANNEL_PERSON";
                    else if (channel.Action == "E")
                        SP = "SP_EDIT_CHANNEL_PERSON";
                    else if (channel.Action == "D")
                        SP = "SP_DEL_CHANNEL_PERSON";

                    if (channel.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("p_CHANNEL_SEQ_ID", channel.ChannelSeqID, OracleDbType.Int16, ParameterDirection.InputOutput));
                        if (channel.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("p_ot_org_id", channel.OTOrgID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_TIPPANI_SUBJECT_ID", channel.TippaniSubjectID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_ot_from_date", channel.OTFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_T_FROM_DATE", channel.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_EMP_ID", channel.ChannelPersonID, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_ORG_ID", channel.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_DES_ID", channel.DesID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_org_unit_id", channel.UnitID, OracleDbType.Int16, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_unit_from_date", channel.UnitFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_CREATED_DATE", channel.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_POST_ID", channel.PostID, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_FROM_DATE", channel.PostFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_TO_DATE", channel.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_CHANNEL_PERSON_ORDER", channel.ChannelPersonOrder, OracleDbType.Int32, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_CHANNEL_PERSON_TYPE", channel.ChannelPersonType, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_IS_FINAL_APPROVER", channel.IsFinalApprover == true ? "Y" : "N", OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_ENTRY_BY", channel.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        channel.ChannelSeqID = int.Parse(paramArray[0].Value.ToString());
                        if (channel.Action != "D")
                            channel.Action = "N";

                        paramArray.Clear();
                    }
                }

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
                DBConn.CloseDbConn();
            }
        }

        public static object GetLoginEmpType(int orgID, int subjectID, double empID)
        {
            string SQL = "SP_GET_LOGIN_EMP_TYPE";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_sub_id", subjectID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_type", "m", OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramArray[3].Size = 10;

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SQL, paramArray.ToArray());
                object obj = paramArray[3].Value;
                return obj;
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

        public static int CheckLoginUserIsChannelMember(int orgId, int subjectID, double empID)
        {
            string SQL = "SP_CHK_LOGIN_USER_IS_CHNL_PER";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgId, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_subject_id", subjectID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_count", null, OracleDbType.Int32, ParameterDirection.InputOutput));
            paramArray[3].Size = 4;

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SQL, paramArray.ToArray());
                object obj = paramArray[3].Value;
                return int.Parse(obj.ToString());
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
