using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.COREDL;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLWitnessSearch
    {
        public static DataTable SearchWitnessPerson(ATTWitnessSearch objWitnessSearch)
        {
            try
            {
                string strSelectSQL = "";

                strSelectSQL = "SELECT CASE_ID,LITIGANT_ID,PERSON_ID,WITNESS_ID,WITNESSNAME,FROM_DATE,WIT_GENDER,WIT_DOB FROM VW_LITIGANTS_WITNESS WHERE 1=1";
                int i = 0;

                if (objWitnessSearch.CaseID  != null) i++;
                if (objWitnessSearch.LItigantID != null) i++;
                if (objWitnessSearch.LitigantName != null) i++;
                if (objWitnessSearch.Gender != null) i++;
                

                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;

                if (objWitnessSearch.CaseID != null)
                {
                    strSelectSQL += " AND CASE_ID = :CASETID ";
                    ParamArray[j] = Utilities.GetOraParam(":CASETID", objWitnessSearch.CaseID, OracleDbType.Int32, ParameterDirection.Input);
                    j++;
                }
                if (objWitnessSearch.LItigantID != null)
                {
                    strSelectSQL += " AND LITIGANT_ID = :LITIGANTID ";
                    ParamArray[j] = Utilities.GetOraParam(":LITIGANTID", objWitnessSearch.LItigantID, OracleDbType.Int32, ParameterDirection.Input);
                    j++;
                }
                if (objWitnessSearch.LitigantName != null)
                {
                    strSelectSQL += " AND LITIGANTNAME LIKE :LITIGANAME ||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":LITIGANAME", objWitnessSearch.LitigantName, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objWitnessSearch.Gender != null)
                {
                    strSelectSQL += " AND GENTER =:GENTER ||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":GENTER", objWitnessSearch.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }
               
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.CMS, ParamArray);
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
