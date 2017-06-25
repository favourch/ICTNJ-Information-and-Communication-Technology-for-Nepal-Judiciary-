using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.DLPDS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.DLL
{
    public class DLLParticipantSearch
    {
        public static DataTable SearchParticipant(ATTParticipantSearch objParticipant)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT P_ID,FIRST_NAME,MID_NAME,SUR_NAME,GENDER,DOB,NEP_DISTNAME,FATHER_NAME,GFATHER_NAME FROM VW_PARTICIPANT_INFO WHERE 1=1";
                int i = 0;

                if (objParticipant.FirstName != null) i++;
                if (objParticipant.MiddleName != null) i++;
                if (objParticipant.SurName != null) i++;
                if (objParticipant.Gender != null) i++;
                if (objParticipant.District != null) i++;

                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;
                if (objParticipant.FirstName != null)
                {
                    strSelectSQL += " AND FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objParticipant.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objParticipant.MiddleName != null)
                {
                    strSelectSQL += " AND MID_NAME LIKE :MName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":MName", objParticipant.MiddleName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objParticipant.SurName != null)
                {
                    strSelectSQL += " AND SUR_NAME LIKE :SurName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SurName", objParticipant.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objParticipant.Gender != null)
                {
                    strSelectSQL += " AND GENDER = :Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objParticipant.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
                if (objParticipant.District != null)
                {
                    strSelectSQL += " AND NEP_DISTNAME = :District";
                    ParamArray[j] = Utilities.GetOraParam(":District", objParticipant.District, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                strSelectSQL += " ORDER BY P_ID";

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL,Module.DLPDS, ParamArray);
                return (DataTable)ds.Tables[0];
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

    }
}
