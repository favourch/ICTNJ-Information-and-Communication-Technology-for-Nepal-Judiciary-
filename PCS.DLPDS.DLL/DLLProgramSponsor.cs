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
    public class DLLProgramSponsor
    {


        public static DataTable GetProgramSponsorTable(int orgID, int programID, int sponsorID)
        {
            string SelectSP = "SP_GET_PROGRAM_SPONSOR";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);

            if (sponsorID > 0)
                paramArray[2] = Utilities.GetOraParam(":p_SPONSOR_ID", sponsorID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[2] = Utilities.GetOraParam(":p_SPONSOR_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

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




        public static bool AddProgramSponsor(List<ATTProgramSponsor> LSTPrgSponsor,int programID, OracleTransaction Tran)
        {
            string InsertUpdateSP = "";

            foreach (ATTProgramSponsor objPrgSponsor in LSTPrgSponsor)
            {
                if (objPrgSponsor.Action == "A")
                    InsertUpdateSP = "SP_ADD_PROGRAM_SPONSOR";
                else if (objPrgSponsor.Action == "E")
                    InsertUpdateSP = "SP_EDIT_PROGRAM_SPONSOR";


                OracleParameter[] paramArray = new OracleParameter[7];
                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objPrgSponsor.OrgID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", (objPrgSponsor.ProgramID == 0) ? programID : objPrgSponsor.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_SPONSOR_ID", objPrgSponsor.SponsorID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_FROM_DATE", objPrgSponsor.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_BUDGET", objPrgSponsor.Budget, OracleDbType.Double, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_CURRENCY", objPrgSponsor.Currency, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_TO_DATE", objPrgSponsor.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);


                try
                {
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                    if (objPrgSponsor.Action == "A")
                    {
                        objPrgSponsor.SponsorID = int.Parse(paramArray[0].Value.ToString());
                        objPrgSponsor.ProgramID = programID;
                    }

                    objPrgSponsor.Action = "";


                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
            return true;
        }
    }
}
