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
  public  class DLLInvItemsWriteOffDT
    {
   //p_org_id                  inv_org_items_writeoff_det.org_id%TYPE,
   //p_writeoff_seq            inv_org_items_writeoff_det.writeoff_seq%TYPE,
   //p_items_category_id       inv_org_items_writeoff_det.items_category_id%TYPE,
   //p_items_sub_category_id   inv_org_items_writeoff_det.items_sub_category_id%TYPE,
   //p_items_id                inv_org_items_writeoff_det.items_id%TYPE,
   //p_seq_no                  inv_org_items_writeoff_det.seq_no%TYPE,
   //p_remarks                 inv_org_items_writeoff_det.remarks%TYPE

      public static bool AddUpdateDeleteItemsWriteOffDT(List<ATTInvItemsWriteOffDT> lstItemsWriteOffDT, int writeoffSeq, OracleTransaction Tran)
      {
          if (lstItemsWriteOffDT.Count > 0)
          {
              string SP = "";
              List<OracleParameter> paramArray = new List<OracleParameter>();

              try
              {
                  foreach (ATTInvItemsWriteOffDT itemsWriteOffDT in lstItemsWriteOffDT)
                  {
                      //if (itemsWriteOffDT.Action == "D")
                      //{
                      //    SP = "sp_inv_del_items_write_off_dt";
                      //    paramArray.Add(Utilities.GetOraParam(":p_org_id", itemsWriteOffDT.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_writeoff_seq", writeoffSeq, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_items_category_id", itemsWriteOffDT.ItemsCategoryID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", itemsWriteOffDT.ItemsSubCategoryID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_items_id", itemsWriteOffDT.ItemsID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_seq_no", itemsWriteOffDT.SeqNo, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                      //    paramArray.Add(Utilities.GetOraParam(":p_remarks", itemsWriteOffDT.Remarks, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                      //    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SP, paramArray.ToArray());
                      //    itemsWriteOffDT.WriteOffSEQ = writeoffSeq;

                      //    paramArray.Clear();
                      //}

                      if (itemsWriteOffDT.Action == "A")
                          SP = "sp_inv_add_items_write_off_dt";
                      else if (itemsWriteOffDT.Action == "E")
                          SP = "sp_inv_add_items_write_off_dt";
                      if (SP != "")
                      {

                          paramArray.Add(Utilities.GetOraParam(":p_org_id", itemsWriteOffDT.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_writeoff_seq", writeoffSeq, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_items_category_id", itemsWriteOffDT.ItemsCategoryID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", itemsWriteOffDT.ItemsSubCategoryID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_items_id", itemsWriteOffDT.ItemsID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_seq_no", itemsWriteOffDT.SeqNo, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                          paramArray.Add(Utilities.GetOraParam(":p_remarks", itemsWriteOffDT.Remarks, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                          SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SP, paramArray.ToArray());
                          itemsWriteOffDT.WriteOffSEQ = writeoffSeq;

                          paramArray.Clear();
                      }
                  }

                  return true;
              }

              catch (Exception ex)
              {
                  throw ex;
              }
          }
          else
          {
              return true;
          }
      }

      public static DataTable GetWriteOffDetailsDT(string MinahaDate)
      {
          try
          {
              //    APP_YES_NO!='Y'"
              string strSelect = "";
              strSelect = "SELECT * FROM VW_INV_ORG_ITEMS_WRITEOFF WHERE 1=1";
              List<OracleParameter> ParamList = new List<OracleParameter>();

              if (MinahaDate != null)
              {
                  strSelect += " AND WRITEOFF_DATE = :minahaDate";
                  ParamList.Add(Utilities.GetOraParam(":minahaDate", MinahaDate, OracleDbType.Varchar2, ParameterDirection.Input));
              }
              strSelect += " AND APP_YES_NO is null";

              GetConnection conn = new GetConnection();
              OracleConnection obj = conn.GetDbConn(Module.OAS);

              DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.Text, strSelect, ParamList.ToArray());
              return (DataTable)ds.Tables[0];
          }

          catch (Exception ex)
          {
              throw ex;
          }
      }
    }
}
