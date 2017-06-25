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
  public class DLLInvItemsWriteOff
    {
      public static bool AddUpdateItemsWriteOff(ATTInvItemsWriteOff itemsWriteOff)
      {
          GetConnection getConn = new GetConnection();
          OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
          OracleTransaction Tran = DBConn.BeginTransaction();
          string InsertSP = "";

          if (itemsWriteOff.Action == "A")
              InsertSP = "SP_INV_ADD_ITEMS_WRITE_OFF";
          else if (itemsWriteOff.Action == "E")
              InsertSP = "SP_INV_EDIT_ITEMS_WRITE_OFF";
          else if (itemsWriteOff.Action == "App")
              InsertSP = "SP_INV_APP_ITEMS_WRITE_OFF";

          List<OracleParameter> paramArray = new List<OracleParameter>();

          paramArray.Add(Utilities.GetOraParam(":p_org_id", itemsWriteOff.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_writeoff_seq", itemsWriteOff.WriteOffSEQ, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
          paramArray.Add(Utilities.GetOraParam(":p_writeoff_date", itemsWriteOff.WriteoffDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_app_by", itemsWriteOff.AppBy, OracleDbType.Int64, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_app_date", itemsWriteOff.AppDate, OracleDbType.Varchar2, ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_app_yes_no", itemsWriteOff.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_entry_by", itemsWriteOff.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          try
          {
              SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
              itemsWriteOff.WriteOffSEQ = int.Parse(paramArray[1].Value.ToString());
              DLLInvItemsWriteOffDT.AddUpdateDeleteItemsWriteOffDT(itemsWriteOff.LstItemsWriteOffDT,itemsWriteOff.WriteOffSEQ, Tran);
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
              getConn.CloseDbConn();
          }
      }

    }
}
