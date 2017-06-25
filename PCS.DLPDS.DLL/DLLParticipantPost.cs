using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
//Using section.
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.DLPDS.ATT;
using PCS.COMMON.DLL;

namespace PCS.DLPDS.DLL
{
    public class DLLParticipantPost
    {
        public static bool SaveParticipantPost(List<ATTParticipantPost> lstParticipantPost,OracleTransaction Tran,double personID)
        {
            string InsertUpdatePostSql = "";
            try
            {

                foreach (ATTParticipantPost lst in lstParticipantPost)
                {
                    OracleParameter[] ParamArray = new OracleParameter[4];
                    ParamArray[0] = Utilities.GetOraParam(":P_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":P_POST_ID", lst.PostID, OracleDbType.Int32, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":P_LEVEL_ID", lst.LevelID, OracleDbType.Int32, ParameterDirection.Input);
                    ParamArray[3] = Utilities.GetOraParam(":P_FROM_DATE",lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    if (lst.Action == "A")
                        InsertUpdatePostSql = "SP_ADD_PARTICIPANT_POST";
                    else if (lst.Action == "E")
                        InsertUpdatePostSql = "SP_EDIT_PARTICIPANT_POST";
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostSql, ParamArray);

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
                throw ex;
            }
        }

        public static bool SaveParticipantPost(List<ATTParticipantPost> lstParticipantPost)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.DLPDS).BeginTransaction();
            double personID;
            string InsertUpdatePostSql = "";
            try
            {
                personID = DLLPerson.AddPersonnelDetails(lstParticipantPost[0].ObjPerson, Tran);
                foreach (ATTParticipantPost lst in lstParticipantPost)
                {
                    OracleParameter[] ParamArray = new OracleParameter[4];
                    ParamArray[0] = Utilities.GetOraParam(":P_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                    ParamArray[1] = Utilities.GetOraParam(":P_POST_ID", lst.PostID, OracleDbType.Int32, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":P_LEVEL_ID", lst.LevelID, OracleDbType.Int32, ParameterDirection.Input);
                    ParamArray[3] = Utilities.GetOraParam(":P_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    if (lst.Action == "A")
                        InsertUpdatePostSql = "SP_ADD_PARTICIPANT_POST";
                    else if (lst.Action == "E")
                        InsertUpdatePostSql = "SP_EDIT_PARTICIPANT_POST";
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostSql, ParamArray);
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

    }
}
