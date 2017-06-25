using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvOrgItems
    {
        public static bool SaveOrgItems(List<ATTInvOrgItems> lstItems)
        {
            GetConnection getConn = new GetConnection();
            OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {

                foreach (ATTInvOrgItems obj in lstItems)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":p_org_id", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));                    
                    paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.InputOutput));                    
                    paramArray.Add(Utilities.GetOraParam(":p_quantity", obj.Quantity, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_p_ji_kha_pa_no", obj.PanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (obj.Action == "A") //New Add
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_add_org_items", paramArray.ToArray());
                    else if (obj.Action == "E") //Update
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_edit_org_items", paramArray.ToArray());
                    obj.ItemsID = int.Parse(paramArray[0].Value.ToString());

                    paramArray.Clear();
                }
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

        public static bool SaveOrgItems(ATTInvOrgItems obj,OracleTransaction Tran)
        {
            try
            {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":p_org_id", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":p_quantity", obj.Quantity, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_p_ji_kha_pa_no", obj.PanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (obj.Action == "A") //New Add
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_add_org_items", paramArray.ToArray());
                   
                    paramArray.Clear();
              
                    return true;
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
           
        }


        public static DataTable GetOrgInvItems(int orgID, string active)
        {
            string SelectSP = "select * from VW_INV_ORG_ITEMS where 1=1 ";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (orgID > 0)
            {
                SelectSP = SelectSP + " and org_id=:org_id ";
                paramArray.Add(Utilities.GetOraParam(":org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (active != null)
            {
                if (active != "")
                {
                    SelectSP = SelectSP + " and active=:active ";
                    paramArray.Add(Utilities.GetOraParam(":active", active, OracleDbType.Varchar2, ParameterDirection.Input));
                }
            }

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SelectSP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CheckExistsOrgItems(ATTInvOrgItems objInvOItems)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
               
                string sql = "SELECT  CHECK_EXISTS_INV_ORG_ITEM(" + objInvOItems.OrgID + ","
                                                                  + objInvOItems.ItemsCategoryID + ","
                                                                  + objInvOItems.ItemsSubCategoryID + ",'"
                                                                  + objInvOItems.ItemsID + "')" +
                            "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, sql);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int existsOrgItems = int.Parse(tbl.Rows[0][0].ToString());

                return existsOrgItems;

            }
            catch (Exception ex)
            {
               
                throw (ex);
            }
          
        }
    }
}
