using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.OAS.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvItems
    {
        //public static DataTable getInvItems(int itemcategoryID, string active)
        //{
        //    List<OracleParameter> para = new List<OracleParameter>();
        //    para.Add(Utilities.GetOraParam(":P_CATEGORY_ID", itemcategoryID, OracleDbType.Int64, ParameterDirection.Input));
        //    para.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
        //    para.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

        //    GetConnection getConn = new GetConnection();
        //    try
        //    {
        //        OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
        //        SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_GET_ITEMS", para.ToArray());
        //        OracleDataReader reader = ((OracleRefCursor)para[2].Value).GetDataReader();
        //        DataTable tbl = new DataTable();
        //        tbl.Load(reader, LoadOption.OverwriteChanges);
        //        return tbl;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        getConn.CloseDbConn();
        //    }
        //}
        public static DataTable getInvItems(ATTInvItems obj)
        {
            string strSql = "SELECT * FROM VW_INV_ITEMS_LIST WHERE 1=1";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (obj.ItemsCategoryID > 0)
            {
                strSql += " AND ITEMS_CATEGORY_ID =:ItemsCategoryID";
                paramArray.Add(Utilities.GetOraParam(":ItemsCategoryID", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
            }


            if (obj.ItemsSubCategoryID > 0 || obj.ItemsSubCategoryID == -1)
            {
                strSql += " AND ITEMS_SUB_CATEGORY_ID =:ItemsSubCategoryID";
                paramArray.Add(Utilities.GetOraParam(":ItemsSubCategoryID", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (obj.Active != null)
            {
                if (obj.Active != "")
                {
                    strSql += " AND ACTIVE =:Active";
                    paramArray.Add(Utilities.GetOraParam(":Active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                }

            }

            strSql += " ORDER BY ITEMS_CATEGORY_ID,ITEMS_SUB_CATEGORY_ID,ITEMS_NAME ASC";

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, Module.OAS, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add ItemUnit object to database
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>
        /// <returns>return bool</returns>
        public static bool SaveItems(List<ATTInvItems> lstItems)
        {
            GetConnection getConn = new GetConnection();
            OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {

                foreach (ATTInvItems obj in lstItems)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":p_items_cd", obj.ItemsCD, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_name", obj.ItemsName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_short_name", obj.ItemsShortName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_type_id", obj.ItemsTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_unit_id", obj.ItemsUnitID, OracleDbType.Int64, ParameterDirection.Input));
                    //paramArray.Add(Utilities.GetOraParam(":p_items_specifications", obj.ItemsSpecification, OracleDbType.Varchar2, ParameterDirection.Input));
                    //paramArray.Add(Utilities.GetOraParam(":p_issued_to", obj.IssuedTo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    if (obj.Action == "A") //New Add
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_add_items", paramArray.ToArray());
                    else if (obj.Action == "E") //Update
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_edit_items", paramArray.ToArray());
                    obj.ItemsID = int.Parse(paramArray[2].Value.ToString());

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
    }
}
