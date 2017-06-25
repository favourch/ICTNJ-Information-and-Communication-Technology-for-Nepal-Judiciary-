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
  public class DLLInvSupplier
    {
      public static DataTable GetSupplierTable(int? supplierID)
      {

          string SelectSP = "sp_inv_get_suppliers";
          OracleParameter[] paramArray = new OracleParameter[3];
          paramArray[0] = Utilities.GetOraParam(":p_suppliers_id", supplierID, OracleDbType.Int64, ParameterDirection.Input);
          paramArray[1] = Utilities.GetOraParam(":p_active", null, OracleDbType.Int64, ParameterDirection.Input);
          paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

          try
          {
              return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.OAS, paramArray).Tables[0];
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
      public static bool AddSupplier(ATTInvSupplier supplier)
      {
          string InsertSP = "";

          if (supplier.Action == "A")
              InsertSP = "SP_INV_ADD_SUPPLIERS";
          else if(supplier.Action == "E")
              InsertSP = "SP_INV_EDIT_SUPPLIERS";

          List<OracleParameter> paramArray = new List<OracleParameter>();
          paramArray.Add(Utilities.GetOraParam(":P_SUPPLIERS_ID",supplier.SupplierID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
          paramArray.Add(Utilities.GetOraParam(":P_SUPPLIERS_NAME", supplier.SupplierName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":P_SUPPLIERS_ADDRESS", supplier.SupplierAddress, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_pan_no", supplier.PanNo, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", supplier.Active, OracleDbType.Varchar2, ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", supplier.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          

          GetConnection GetConn = new GetConnection();
          OracleTransaction Tran = GetConn.GetDbConn(Module.OAS).BeginTransaction();
          try
          {
              SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
              supplier.SupplierID = int.Parse(paramArray[0].Value.ToString());
              DLLInvSupplierContact.AddSupplierContact(supplier.LstSupplierContact, supplier.SupplierID, Tran);
              Tran.Commit();
              return true;
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
