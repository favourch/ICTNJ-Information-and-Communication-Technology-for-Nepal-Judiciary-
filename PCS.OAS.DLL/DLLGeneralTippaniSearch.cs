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
    public class DLLGeneralTippaniSearch
    {
        public static DataTable GetTippaniDetails(ATTGeneralTippaniSearch obj)
        {

            string query = "SELECT ORG_ID, TIPPANI_ID, TIPPANI_SUBJECT_ID,TIPPANI_SUBJECT_NAME,"
                            +"TIPPANI_ON, TIPPANI_TEXT,FILE_NO,FINAL_STATUS,TIPPANI_STATUS_NAME,"
                            +"ORG_NAME FROM VW_TIPPANI_INFO WHERE 1=1";
            List<OracleParameter> paramArray=new List<OracleParameter>();

          
            if (obj.OrgID>0)
            {
                query += " AND ORG_ID=:org_id";
                paramArray.Add(Utilities.GetOraParam(":org_id",obj.OrgID,OracleDbType.Int16,ParameterDirection.Input));

            }
            if(obj.TippaniSubjectID>0)
            {
                query+=" AND TIPPANI_SUBJECT_ID=:tip_sub_id";
                paramArray.Add(Utilities.GetOraParam(":tip_sub_id",obj.TippaniSubjectID,OracleDbType.Int16,ParameterDirection.Input));
            }
            if(obj.FileNo>0)
            {
                query+=" AND FILE_NO=:file_no";
                paramArray.Add(Utilities.GetOraParam(":file_no",obj.FileNo,OracleDbType.Int16,ParameterDirection.Input));
            }

            if(obj.FromDate!="" && obj.ToDate!="")
            {
                query+=" AND TIPPANI_ON >=:from_date AND TIPPANI_ON <=:to_date";
                paramArray.Add(Utilities.GetOraParam(":from_date",obj.FromDate,OracleDbType.Varchar2,ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":to_date",obj.ToDate,OracleDbType.Varchar2,ParameterDirection.Input));

            }
            if (obj.FinalStatus > 0)
            {
                query += " AND FINAL_STATUS=:final_status";
                paramArray.Add(Utilities.GetOraParam(":final_status", obj.FinalStatus, OracleDbType.Int16, ParameterDirection.Input));
            }
            try
            {
            GetConnection DBcon = new GetConnection();
            OracleConnection con = DBcon.GetDbConn(Module.OAS);
            return SqlHelper.ExecuteDataset(con,CommandType.Text,query,paramArray.ToArray()).Tables[0];
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
