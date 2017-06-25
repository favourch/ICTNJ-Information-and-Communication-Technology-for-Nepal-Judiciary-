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
    public class DLLInvOrgItemsKNJ
    {
        public static DataTable SearchItemsKNJ(ATTInvOrgItemsKNJ obj)
        {
            try
            {
                string strSelect = "";
                strSelect = "SELECT * FROM VW_INV_ORG_ITEMS_KNJ WHERE ITEMS_STATUS='S' ";
                List<OracleParameter> ParamList = new List<OracleParameter>();
                if (obj.OrgID > 0)
                {
                    strSelect += " AND ORG_ID = :itmOrgID";
                    ParamList.Add(Utilities.GetOraParam(":itmOrgID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (obj.ItemsCategoryID > 0)
                {
                    strSelect += " AND ITEMS_CATEGORY_ID = :itmCatID";
                    ParamList.Add(Utilities.GetOraParam(":itmCatID", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (obj.ItemsSubCategoryID > 0)
                {
                    strSelect += " AND ITEMS_SUB_CATEGORY_ID = :itmSubCatID";
                    ParamList.Add(Utilities.GetOraParam(":itmSubCatID", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (obj.ItemsID > 0)
                {
                    strSelect += " AND ITEMS_ID = :itmID";
                    ParamList.Add(Utilities.GetOraParam(":itmID", obj.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                }
                //if (obj.ItemsTypeID > 0)
                //{
                //    strSelect += " AND ITEMS_TYPE_ID = :itmTypeID";
                //    ParamList.Add(Utilities.GetOraParam(":itmTypeID", obj.ItemsTypeID, OracleDbType.Int64, ParameterDirection.Input));
                //}

                GetConnection conn = new GetConnection();
                OracleConnection con = conn.GetDbConn(Module.OAS);

                DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.Text, strSelect, ParamList.ToArray());
                return (DataTable)ds.Tables[0];
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchItemsKNJ(int? itmCatID, int? itmSubCatID)
        {
            try
            {
                string strSelect = "";
                strSelect = "SELECT * FROM VW_INV_ORG_ITEMS_KNJ WHERE ITEMS_STATUS='S' ";
                List<OracleParameter> ParamList = new List<OracleParameter>();

                if (itmCatID > 0)
                {
                    strSelect += "AND ITEMS_CATEGORY_ID = :itmCatID";
                    ParamList.Add(Utilities.GetOraParam(":itmCatID", itmCatID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (itmSubCatID > 0)
                {
                    strSelect += " AND ITEMS_SUB_CATEGORY_ID = :itmSubCatID";
                    ParamList.Add(Utilities.GetOraParam(":itmSubCatID", itmSubCatID, OracleDbType.Int64, ParameterDirection.Input));
                }

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

        public static bool SaveOrgItemsKNJ(List<ATTInvOrgItemsKNJ> lstKNJ, OracleTransaction Tran)
        {
            try
            {
                string sp ;
                OracleParameter[] paramArray = new OracleParameter[9];
                foreach (ATTInvOrgItemsKNJ objItemsKNJ in lstKNJ)
                {
                    sp = "";

                    if (objItemsKNJ.Action == "A")
                        sp = "sp_inv_add_org_items_knj";
                    else if (objItemsKNJ.Action == "E")
                        sp = "sp_inv_edit_org_items_knj";

                    if (sp != "")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objItemsKNJ.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_items_category_id", objItemsKNJ.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_items_sub_category_id", objItemsKNJ.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_items_id", objItemsKNJ.ItemsID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_seq_no", objItemsKNJ.KNJSeq, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[5] = Utilities.GetOraParam(":p_items_attributes", objItemsKNJ.ItemsAttrib, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_vehicle_reg_no", objItemsKNJ.VehRegNo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_items_status", objItemsKNJ.ItemsStatus, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":p_entry_by", objItemsKNJ.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure,sp,paramArray);
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        //public static bool SaveOrgItems(ATTInvOrgItems obj, OracleTransaction Tran)
        //{
        //    try
        //    {
        //        List<OracleParameter> paramArray = new List<OracleParameter>();
        //        paramArray.Add(Utilities.GetOraParam(":p_org_id", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.InputOutput));
        //        paramArray.Add(Utilities.GetOraParam(":p_quantity", obj.Quantity, OracleDbType.Int64, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_p_ji_kha_pa_no", obj.PanNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_active", obj.Active, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

        //        if (obj.Action == "A") //New Add
        //            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_add_org_items", paramArray.ToArray());

        //        paramArray.Clear();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}
    }


}
