using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.LJMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.LJMS.DLL
{
    public class DLLLawyerRenewal
    {
        public static bool SaveLawyerRenewalDetails(ATTLawyer objLawyer, OracleTransaction Tran)
        {
            try
            {
                string sp = "";

                foreach (ATTLawyerRenewal objLawyerRenw in objLawyer.LstLawyerRenewal)
                {
                    if(objLawyerRenw.Action == "A")
                        sp = "SP_ADD_LAWYER_RENEWAL";
                    else if(objLawyerRenw.Action == "E")
                        sp = "SP_EDIT_LAWYER_RENEWAL";

                    
                    if (sp != "")
                    {
                        OracleParameter[] paramArray = new OracleParameter[7];

                        paramArray[0] = Utilities.GetOraParam(":p_P_ID", objLawyer.PID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_LAWYER_TYPE_ID", objLawyerRenw.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_LICENSE_NO", objLawyerRenw.LicenseNo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":P_FROM_DATE", objLawyerRenw.RenewalDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_TO_DATE", objLawyerRenw.RenewalUpto, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_ENTRY_BY", objLawyerRenw.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_ENTRY_DATE", null, OracleDbType.Date, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure,sp,paramArray);
                        sp = "";
                    }

                    objLawyerRenw.PID = objLawyer.PID;
                }

                return true;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable GetLawyerRenewalDetails(double PID)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT DISTINCT P_ID,LAWYER_TYPE_ID,lawyer_type_description,LICENSE_NO,RENEWAL_DATE,RENEWAL_UPTO FROM vw_lawyer_info_details " +
                                   " WHERE RENEWAL_DATE IS NOT NULL AND RENEWAL_UPTO IS NOT NULL ";
                if (PID > 0)
                {
                    selectSQL += " AND P_ID = " + PID;
                }

                OracleConnection DBConn = GetConn.GetDbConn(Module.LJMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
