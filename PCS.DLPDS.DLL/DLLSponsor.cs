using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;


namespace PCS.DLPDS.DLL
{
    public class DLLSponsor
    {

        public static DataTable GetSponsorTable(int sponsorID)
        {
            string SelectSP = "SP_GET_SPONSOR";

            OracleParameter[] paramArray = new OracleParameter[2];
            if (sponsorID>0)
                paramArray[0] = Utilities.GetOraParam(":p_SPONSOR_ID", sponsorID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[0] = Utilities.GetOraParam(":p_SPONSOR_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[1].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }


        public static bool AddSponsor(ATTSponsor objSponsor)
        {
            string InsertUpdateSP = "";

                if (objSponsor.Action == "A")
                    InsertUpdateSP = "SP_ADD_SPONSOR";
                else if (objSponsor.Action == "E")
                    InsertUpdateSP = "SP_EDIT_SPONSOR";


                OracleParameter[] paramArray = new OracleParameter[2];
                paramArray[0] = Utilities.GetOraParam(":p_SPONSOR_ID", objSponsor.SponsorID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":p_SPONSOR_NAME", objSponsor.SponsorName, OracleDbType.Varchar2, ParameterDirection.Input);

                GetConnection GetConn = new GetConnection();

                try
                {
                    OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                    if (objSponsor.Action == "A")
                        objSponsor.SponsorID = int.Parse(paramArray[0].Value.ToString());
                    return true;
                    
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                    
                }
                
        }
    }
}
