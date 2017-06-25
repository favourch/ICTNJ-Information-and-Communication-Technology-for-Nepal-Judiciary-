using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public  class DLLTameliMedia
    {
        public static bool AddEditDeleteTameliMedia(List<ATTTameliMedia> lstTameliMedia ,OracleTransaction Tran)
        {
            string InsertUpdateDeleteSQL = "";       

            try
            {
                foreach (ATTTameliMedia tameliMedia in lstTameliMedia)
                {
                    if (tameliMedia.Action == "A")
                        InsertUpdateDeleteSQL = "SP_ADD_TAMELI_MEDIA";
                    else if (tameliMedia.Action == "E")
                        InsertUpdateDeleteSQL = "SP_EDIT_TAMELI_MEDIA";
                    else if (tameliMedia.Action == "D")
                        InsertUpdateDeleteSQL = "SP_DEL_TAMELI_MEDIA";

                    OracleParameter[] ParamArray;
                    if (tameliMedia.Action == "A" || tameliMedia.Action == "E")
                    {                       
                        ParamArray = new OracleParameter[7];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", tameliMedia.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", tameliMedia.LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_ISSUED_DATE", tameliMedia.IssueDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_SEQ_NO", tameliMedia.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput);
                        //ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_ATTORNEY_ID", tameliMedia.AttorneyID, OracleDbType.Int64, ParameterDirection.Input);
                        //ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_WITNESS_ID", tameliMedia.WitnessID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_MEDIA_FULL_NAME", tameliMedia.MediaFullName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_MEDIA_PUB_DATE", tameliMedia.MediaPublicationDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", tameliMedia.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);                        
                    }
                    if (tameliMedia.Action == "D")
                    {
                        ParamArray = new OracleParameter[4];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", tameliMedia.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", tameliMedia.LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_ISSUED_DATE", tameliMedia.IssueDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_SEQ_NO", tameliMedia.SeqNo, OracleDbType.Int64, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                    }
                }

                //Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            
        }
    }
}
