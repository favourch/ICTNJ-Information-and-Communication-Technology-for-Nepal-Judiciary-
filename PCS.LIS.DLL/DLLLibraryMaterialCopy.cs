using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LIS.DLL
{
    public class DLLLibraryMaterialCopy
    {
        public static bool AddLibraryMaterialCopy(List<ATTLibraryMaterialCopy> lstCopy, long lMaterialID, OracleTransaction Tran)
        {
            string InsertSP = "";

            try
            {
                ATTLibraryMaterialCopy obj = lstCopy[0];
              
                    OracleParameter[] paramArray = new OracleParameter[1];
                    if (obj.Action == "A")
                    {
                        InsertSP = "SP_ADD_LIBRARY_MATERIAL_COPY";
                        paramArray = new OracleParameter[12];
                        paramArray[11] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    }
                    else if (obj.Action == "M")
                    {
                        InsertSP = "SP_EDIT_LIBRARY_MATERIAL_COPY";
                        paramArray = new OracleParameter[11];
                    }
                    else if (obj.Action == "D")
                    {
                        InsertSP = "SP_DEL_LIBRARY_MATERIAL_COPY";
                        paramArray = new OracleParameter[4];
                    }
                    else if (obj.Action == "N")
                    {
                    }

                    if (obj.Action != "N")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_L_MATERIAL_ID", lMaterialID, OracleDbType.Long, ParameterDirection.InputOutput);
                        paramArray[3] = Utilities.GetOraParam(":p_ACCESSION_ID", obj.AccessionID, OracleDbType.Long, ParameterDirection.Input);
                        if (obj.Action != "D")
                        {
                            paramArray[4] = Utilities.GetOraParam(":p_EDITION", obj.Edition, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[5] = Utilities.GetOraParam(":p_PUB_DATE", obj.PublicationDate, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[6] = Utilities.GetOraParam(":p_REG_DATE", obj.RegistrationDate, OracleDbType.Date, ParameterDirection.Input);
                            paramArray[7] = Utilities.GetOraParam(":p_ISBN_ISSN", obj.IsbnIssnNo, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[8] = Utilities.GetOraParam(":p_PRICE", obj.Price, OracleDbType.Long, ParameterDirection.Input);
                            paramArray[9] = Utilities.GetOraParam(":p_CURRENCY_ID", obj.CurrencyID, OracleDbType.Int64, ParameterDirection.Input);
                            paramArray[10] = Utilities.GetOraParam(":p_LOCATION", obj.Location, OracleDbType.Varchar2, ParameterDirection.Input);

                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSP, paramArray);
                    }
                

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetLMCopy(int orgID, int libraryID, decimal lMaterialID)
        {
            string SelectSQL = "SP_GET_LIBRARY_MATERIAL_COPY";

            OracleParameter[] paramArray = new OracleParameter[4];

            paramArray[0] = Utilities.GetOraParam(":ORGID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":LIBRARYID", libraryID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":LMATERIALID", lMaterialID, OracleDbType.Decimal, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
               SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
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
    }
}
