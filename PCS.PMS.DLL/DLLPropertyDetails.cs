using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLPropertyDetails
    {

        public static bool SavePropertyDetails(ATTPropertyDetails objPDetails)
        {
            GetConnection Conn = new GetConnection();
            //OracleConnection DBConn = Conn.GetDbConn("PMS_ADMIN", "PMS_ADMIN");
            OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                string SaveSQL = "SP_ADD_PROPERTYDETAILS";

                
                

                foreach (ATTPropertyDetails objPD in objPDetails.LstPropertyDetails)
                {
                    OracleParameter[] paramArray = new OracleParameter[6];
                    paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", objPD.EmpID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_SUB_DATE", objPD.SubDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_PCAT_ID", objPD.PCatID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":P_COL_NO", objPD.ColNo, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_ROW_NO", objPD.RowNo, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":P_VALUE", objPD.Value, OracleDbType.Varchar2, ParameterDirection.Input);


                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SaveSQL, paramArray);
                }

                if (objPDetails.LstPropertyIncome.Count > 0)
                    DLLPropertyIncome.SavePropertyIncome(objPDetails.LstPropertyIncome, Tran);

                Tran.Commit();

                return true;

            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw(ex);
            }
            
        }

        public static bool SavePropertyDetails(List<ATTPropertyDetails> lstPropertyDetails)
        {
            GetConnection Conn = new GetConnection();
            try
            {
                string SaveSQL = "SP_ADD_PROPERTYDETAILS";
                
                //OracleConnection DBConn = Conn.GetDbConn("PMS_ADMIN", "PMS_ADMIN");
                OracleConnection DBConn = Conn.GetDbConn(Module.PMS);

                foreach (ATTPropertyDetails objPD in lstPropertyDetails)
                {
                    OracleParameter[] paramArray = new OracleParameter[6];
                    paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", objPD.EmpID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_SUB_DATE",objPD.SubDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_PCAT_ID", objPD.PCatID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":P_COL_NO", objPD.ColNo, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_ROW_NO", objPD.RowNo, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":P_VALUE", objPD.Value, OracleDbType.Varchar2, ParameterDirection.Input);
                   

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SaveSQL, paramArray);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Conn.CloseDbConn();
            }

        }
    }
}
