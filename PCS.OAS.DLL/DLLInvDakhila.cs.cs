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
    public static class DLLInvDakhila
    {
        public static bool SaveDakhila(List<ATTInvDakhila> lst)
        {
            string sp ;
           
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            OracleParameter[] paramArray = new OracleParameter[11];
                        
            try
            {
                foreach (ATTInvDakhila objDak in lst)
                {
                    sp = "";

                    if (objDak.JelaaKhataNo.Trim() != "")
                    {
                        ATTInvOrgItems objOItms = new ATTInvOrgItems();

                        objOItms.OrgID = int.Parse(objDak.OrgID.ToString());
                        objOItms.ItemsCategoryID = int.Parse(objDak.ItemsCategoryID.ToString());
                        objOItms.ItemsSubCategoryID = int.Parse(objDak.ItemsSubCategoryID.ToString());
                        objOItms.ItemsID = objDak.ItemsID;
                        objOItms.PanNo = objDak.JelaaKhataNo;
                        objOItms.Active = "Y";
                        objOItms.Action = "A";
                        objOItms.EntryBy = objDak.EntryBy;

                        DLLInvOrgItems.SaveOrgItems(objOItms, Tran);
                    }

                   

                    if (objDak.Action == "A")
                        sp = "sp_inv_add_direct_entry";
                    else if (objDak.Action == "E")
                        sp = "sp_inv_edit_direct_entry";

                    if (sp != "")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objDak.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_items_category_id", objDak.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_items_sub_category_id", objDak.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_items_id", objDak.ItemsID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_seq_no", objDak.DirectEntrySeq, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[5] = Utilities.GetOraParam(":p_dir_entry_date", objDak.DirectEntryDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_dir_entry_type", objDak.DirectEntryType, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_don_organization", objDak.DonationOrg, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":p_items_unit_price", objDak.UnitPrice, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":p_total_quantity", objDak.Quantity, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":p_entry_by", objDak.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                    }

                    if (objDak.ItemsTypeID == 2 && objDak.LstKNJ.Count > 0)
                    {
                        DLLInvOrgItemsKNJ.SaveOrgItemsKNJ(objDak.LstKNJ, Tran);
                    }
                    else if(objDak.ItemsTypeID == 2)
                    {
                        int i = 0;

                      
                        List<ATTInvOrgItemsKNJ> lstKNJ = new List<ATTInvOrgItemsKNJ>();

                        while (i < objDak.Quantity)
                        {
                            ATTInvOrgItemsKNJ objOKnj = new ATTInvOrgItemsKNJ();

                            objOKnj.OrgID = objDak.OrgID;
                            objOKnj.ItemsCategoryID = objDak.ItemsCategoryID;
                            objOKnj.ItemsSubCategoryID = objDak.ItemsSubCategoryID;
                            objOKnj.ItemsID = objDak.ItemsID;
                            objOKnj.ItemsStatus = "S";
                            objOKnj.Action = "A";
                            objOKnj.EntryBy = objDak.EntryBy;

                            lstKNJ.Add(objOKnj);
                            i++;
                        }

                        if (lstKNJ.Count > 0)
                            DLLInvOrgItemsKNJ.SaveOrgItemsKNJ(lstKNJ, Tran);
                    }
                  
                }
               
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static bool ApproveDakhila(ATTInvDakhila objDak)
        {
            string sp;

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            OracleParameter[] paramArray = new OracleParameter[8];

            try
            {    
                    sp = "";

                    if (objDak.Action == "A")
                        sp = "sp_inv_app_direct_entry";
                    else if (objDak.Action == "E")
                        sp = "";

                    if (sp != "")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objDak.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_items_category_id", objDak.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_items_sub_category_id", objDak.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_items_id", objDak.ItemsID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":p_seq_no", objDak.DirectEntrySeq, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":p_app_by", objDak.AppBy, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":p_app_date", objDak.AppDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_app_yes_no", objDak.AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
                   
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                    }

                  
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
