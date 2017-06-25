using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLGeneralTippaniProcess
    {
        public static bool AddGeneralTippaniProcess(List<ATTGeneralTippaniProcess> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID)
        {
            return false;
            //string SP = "";
            //List<OracleParameter> paramArray = new List<OracleParameter>();

            //try
            //{
            //    foreach (ATTGeneralTippaniProcess process in lst)
            //    {
            //        if (process.Action == "A")
            //            SP = "SP_ADD_TIPPANI_PROCESS";
            //        else if (process.Action == "E")
            //            SP = "SP_EDIT_TIPPANI_PROCESS";
            //        else if (process.Action == "D")
            //            SP = "SP_ADD_TIPPANI_PROCESS";

            //        paramArray.Add(Utilities.GetOraParam("P_ORG_ID", process.OrgID, OracleDbType.Int32, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int32, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PROCESS_ID", process.TippaniProcessID, OracleDbType.Int32, ParameterDirection.InputOutput));
            //        paramArray.Add(Utilities.GetOraParam("P_PROCESS_BY", process.ProcessBy, OracleDbType.Int32, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_PROCESS_ON", process.ProcessOn, OracleDbType.Varchar2, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_PROCESS_TO", process.ProcessTo, OracleDbType.Int32, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_STATUS", process.Status, OracleDbType.Int32, ParameterDirection.Input));
            //        paramArray.Add(Utilities.GetOraParam("P_SEND_TYPE", process.SendType, OracleDbType.Varchar2, ParameterDirection.Input));

            //        SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
            //        process.TippaniProcessID = int.Parse(paramArray[2].Value.ToString());
            //        paramArray.Clear();
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public static DataTable GetTippaniNextStatus(int orgID, int tippaniID, int tipPrcID)
        {
            string SP = "sp_get_tippani_next_status";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tip_prc_id", tipPrcID , OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            GetConnection DBConn = new GetConnection();

            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                DataTable tbl = SqlHelper.ExecuteDataset(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray()).Tables[0];

                return tbl;
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

        public static bool UpdateChannelPersonDecisionAndAddProcess(ATTGeneralTippaniProcess process, List<ATTGeneralTippaniProcess> lst, List<ATTGeneralTippaniAttachment> lstAttachment, TippaniSubject subject)
        {
            string SP = "SP_UPD_CHNL_PERSON_DECISION";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", process.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", process.TippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PRC_ID", process.TippaniProcessID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_NOTE", process.Note, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_STATUS", process.Status, OracleDbType.Int64, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = Conn.BeginTransaction();
            try
            {
                if (process != null)
                {
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                    if (lst != null && lst.Count > 0)
                        DLLGeneralTippaniProcess.AddGeneralTippaniProcessDetail(lst, Tran, (int)subject, subject, process.TippaniID);

                    if (lstAttachment != null && lstAttachment.Count > 0)
                        DLLGeneralTippaniAttachment.AddAttachment(lstAttachment, Tran, (int)subject, subject, process.TippaniID, process.TippaniProcessID);
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
                Tran.Dispose();
                DBConn.CloseDbConn();
            }
        }

        public static bool UpdateChannelPersonDecisionAndAddProcess(ATTGeneralTippaniProcess process, List<ATTGeneralTippaniProcess> lst, List<ATTGeneralTippaniAttachment> lstAttachment, TippaniSubject subject, List<ATTGeneralTippaniSummary> lstRec)
        {
            string SP = "SP_UPD_CHNL_PERSON_DECISION";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", process.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", process.TippaniID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PRC_ID", process.TippaniProcessID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_NOTE", process.Note, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_STATUS", process.Status, OracleDbType.Int64, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = Conn.BeginTransaction();
            try
            {
                if (process != null)
                {
                    if (lstRec.Count > 0)
                        DLLGeneralTippaniDetail.AddLeaveTippaniDetail(lstRec, Tran, (int)subject, subject, 0);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                    if (lst.Count > 0)
                        DLLGeneralTippaniProcess.AddGeneralTippaniProcessDetail(lst, Tran, (int)subject, subject, process.TippaniID);

                    if (lstAttachment.Count > 0)
                        DLLGeneralTippaniAttachment.AddAttachment(lstAttachment, Tran, (int)subject, subject, process.TippaniID, process.TippaniProcessID);
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
                Tran.Dispose();
                DBConn.CloseDbConn();
            }
        }

        //public static bool SendBackTippani(ATTGeneralTippaniProcess process, int tippaniSubjectID, List<ATTGeneralTippaniAttachment> lstAttachment)
        //{
        //    string SP = "";
        //    SP = "SP_ADD_TIPPANI_PROCESS_DETAIL";

        //    List<OracleParameter> paramArray = new List<OracleParameter>();

        //    paramArray.Add(Utilities.GetOraParam("P_ORG_ID", process.OrgID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", process.TippaniID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PROCESS_ID", process.TippaniProcessID, OracleDbType.Int32, ParameterDirection.InputOutput));
        //    paramArray.Add(Utilities.GetOraParam("P_SEND_BY", process.SendBy, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_SEND_ON", process.SendOn, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_SEND_TO", process.SendTo, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_NOTE", process.Note, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_STATUS", process.Status, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_SEND_TYPE", process.SendType, OracleDbType.Varchar2, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_SUBJECT_ID", tippaniSubjectID, OracleDbType.Int32, ParameterDirection.Input));
        //    paramArray.Add(Utilities.GetOraParam("P_IS_CHANEL_PERSON", process.IsChannelPerson, OracleDbType.Varchar2, ParameterDirection.Input));

        //    GetConnection DBConn = new GetConnection();

        //    try
        //    {
        //        OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
        //        SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
        //        process.TippaniProcessID = int.Parse(paramArray[2].Value.ToString());

        //        //if (lstAttachment.Count > 0)
        //        //    DLLGeneralTippaniAttachment.AddAttachment(lstAttachment, Tran, 0, TippaniSubject.Visit, process.TippaniID, process.TippaniProcessID);

        //        paramArray.Clear();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DBConn.CloseDbConn();
        //    }
        //}

        /***************************************************************************/

        public static bool AddGeneralTippaniProcessDetail(List<ATTGeneralTippaniProcess> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTGeneralTippaniProcess process in lst)
                {
                    if (process.Action == "A")
                        SP = "SP_ADD_TIPPANI_PROCESS_DETAIL";
                    else if (process.Action == "E")
                        SP = "SP_EDIT_TIPPANI_PROCESS_DETAIL";
                    else if (process.Action == "D")
                        SP = "SP_ADD_TIPPANI_PROCESS_DETAIL";

                    paramArray.Add(Utilities.GetOraParam("P_ORG_ID", process.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippaniID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_PROCESS_ID", process.TippaniProcessID, OracleDbType.Int32, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam("P_SENDER_ORG_ID", process.SenderOrgID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_SENDER_UNIT_ID", process.SenderUnitID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_SEND_BY", process.SendBy, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_SEND_ON", process.SendOn, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REC_ORG_ID", process.ReceiverOrgID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_REC_UNIT_ID", process.ReceiverUnitID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_SEND_TO", process.SendTo, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_NOTE", process.Note, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_STATUS", process.Status, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_SEND_TYPE", process.SendType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_TIPPANI_SUBJECT_ID", tippaniSubjectID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_IS_CHANEL_PERSON", process.IsChannelPerson, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_entry_by", process.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    
                    SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                    process.TippaniProcessID = int.Parse(paramArray[2].Value.ToString());
                    paramArray.Clear();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object GetTippaniText(int orgID, int TippaniID, int TippaniProcessID)
        {
            string SP = "sp_get_tippani_text";
            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", TippaniID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tip_prc_id", TippaniProcessID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_note", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            GetConnection DBConn = new GetConnection();

            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                object o = SqlHelper.ExecuteScalar(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());

                return o;
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