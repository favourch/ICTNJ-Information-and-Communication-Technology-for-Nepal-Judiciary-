using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.OAS.ATT;
using PCS.PMS.ATT;


namespace PCS.OAS.DLL
{
    public class DLLInvItemsTransfered
    {

        public static bool SaveItemsTransfer(List<ATTInvItemsTransfered> LSTItemsTrans,string opt)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.OAS);
            Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateItemsTransfered = "";
                foreach (ATTInvItemsTransfered var in LSTItemsTrans)
                {
                    int itemTypeID = var.ItemsTypeID;

                    if (var.Action == "A")
                    {
                        InsertUpdateItemsTransfered = "SP_INV_ADD_ITEMS_TRANSFER";
                    }
                    else if (var.Action == "E")
                    {
                        InsertUpdateItemsTransfered = "SP_INV_EDIT_ITEMS_TRANSFER";
                    }

                    if (opt == "transfer")
                    {
                        if (itemTypeID == 1)
                        {
                            if (var.Action == "A" || var.Action == "E")
                            {
                                OracleParameter[] paramArray = new OracleParameter[20];
                                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[1] = Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", var.ItemsCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[2] = Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", var.ItemsSubCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[3] = Utilities.GetOraParam(":P_ITEMS_ID", var.ItemsID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[4] = Utilities.GetOraParam(":P_TRFD_ORG", var.TransORG, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[5] = Utilities.GetOraParam(":P_TRFD_SEQ", var.TransSEQ, OracleDbType.Int32, ParameterDirection.InputOutput);
                                paramArray[6] = Utilities.GetOraParam(":P_QUANTITY", var.Quantity, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[7] = Utilities.GetOraParam(":P_DECISION_DATE ", var.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[8] = Utilities.GetOraParam(":P_TRFD_DATE", var.TransDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[9] = Utilities.GetOraParam(":P_TRFD_VIA", var.TransVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[10] = Utilities.GetOraParam(":P_TRFD_RCVD_BY", var.TransRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[11] = Utilities.GetOraParam(":P_TRFD_ORG_UNIT", var.TransOrgUnit, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[12] = Utilities.GetOraParam(":P_TRFD_TO", var.TransTo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[13] = Utilities.GetOraParam(":P_TRFD_RCVD_DATE", var.TransRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[14] = Utilities.GetOraParam(":P_RETURN_BY", var.ReturnBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[15] = Utilities.GetOraParam(":P_RETURN_DATE", var.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[16] = Utilities.GetOraParam(":P_RETURN_VIA", var.ReturnVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[17] = Utilities.GetOraParam(":P_RETURN_RCVD_BY", var.ReturnRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[18] = Utilities.GetOraParam(":P_RETURN_RCVD_DATE", var.ReturnRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[19] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateItemsTransfered, paramArray);
                                var.TransSEQ = int.Parse(paramArray[5].Value.ToString());

                            }
                        }

                        else if (itemTypeID == 2)
                        {
                            if (var.Action == "A")
                            {
                                InsertUpdateItemsTransfered = "SP_INV_ADD_ITEMS_TRANSFER_KNJ";
                            }
                            else if (var.Action == "E")
                            {
                                InsertUpdateItemsTransfered = "SP_INV_EDIT_ITEMS_TRANSFER_KNJ";
                            }
                            if (var.Action == "A" || var.Action == "E")
                            {
                                OracleParameter[] paramArr = new OracleParameter[20];
                                paramArr[0] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[1] = Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", var.ItemsCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[2] = Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", var.ItemsSubCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[3] = Utilities.GetOraParam(":P_ITEMS_ID", var.ItemsID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[4] = Utilities.GetOraParam(":P_SEQ_NO", var.SeqNo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[5] = Utilities.GetOraParam(":P_TRFD_ORG", var.TransORG, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[6] = Utilities.GetOraParam(":P_TRFD_SEQ", var.TransSEQ, OracleDbType.Int32, ParameterDirection.InputOutput);
                                paramArr[7] = Utilities.GetOraParam(":P_DECISION_DATE", var.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[8] = Utilities.GetOraParam(":P_TRFD_DATE", var.TransDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[9] = Utilities.GetOraParam(":P_TRFD_VIA", var.TransVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[10] = Utilities.GetOraParam(":P_TRFD_RCVD_BY", var.TransRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[11] = Utilities.GetOraParam(":P_TRFD_ORG_UNIT", var.TransOrgUnit, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[12] = Utilities.GetOraParam(":P_TRFD_TO", var.TransTo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[13] = Utilities.GetOraParam(":P_TRFD_RCVD_DATE", var.TransRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[14] = Utilities.GetOraParam(":P_RETURN_BY", var.ReturnBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[15] = Utilities.GetOraParam(":P_RETURN_DATE", var.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[16] = Utilities.GetOraParam(":P_RETURN_VIA", var.ReturnVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[17] = Utilities.GetOraParam(":P_RETURN_RCVD_BY", var.ReturnRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[18] = Utilities.GetOraParam(":P_RETURN_RCVD_DATE", var.ReturnRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[19] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateItemsTransfered, paramArr);
                                var.TransSEQ = int.Parse(paramArr[6].Value.ToString());
                            }
                        }
                    }
                    else if (opt == "receive")
                    {
                        if (itemTypeID == 1)
                        {
                            if (var.Action == "A" || var.Action == "E")
                            {
                                OracleParameter[] paramArray = new OracleParameter[20];
                                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[1] = Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", var.ItemsCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[2] = Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", var.ItemsSubCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[3] = Utilities.GetOraParam(":P_ITEMS_ID", var.ItemsID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[4] = Utilities.GetOraParam(":P_TRFD_ORG", var.TransORG, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[5] = Utilities.GetOraParam(":P_TRFD_SEQ", var.TransSEQ, OracleDbType.Int32, ParameterDirection.InputOutput);
                                paramArray[6] = Utilities.GetOraParam(":P_QUANTITY", var.Quantity, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[7] = Utilities.GetOraParam(":P_DECISION_DATE ", var.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[8] = Utilities.GetOraParam(":P_TRFD_DATE", var.TransDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[9] = Utilities.GetOraParam(":P_TRFD_VIA", var.TransVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[10] = Utilities.GetOraParam(":P_TRFD_RCVD_BY", var.TransRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[11] = Utilities.GetOraParam(":P_TRFD_ORG_UNIT", var.TransOrgUnit, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[12] = Utilities.GetOraParam(":P_TRFD_TO", var.TransTo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[13] = Utilities.GetOraParam(":P_TRFD_RCVD_DATE", var.TransRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[14] = Utilities.GetOraParam(":P_RETURN_BY", var.ReturnBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[15] = Utilities.GetOraParam(":P_RETURN_DATE", var.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[16] = Utilities.GetOraParam(":P_RETURN_VIA", var.ReturnVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[17] = Utilities.GetOraParam(":P_RETURN_RCVD_BY", var.ReturnRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArray[18] = Utilities.GetOraParam(":P_RETURN_RCVD_DATE", var.ReturnRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArray[19] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateItemsTransfered, paramArray);
                                var.TransSEQ = int.Parse(paramArray[5].Value.ToString());

                            }
                        }
                        else if (itemTypeID == 2)
                        {
                            if (var.Action == "A")
                            {
                                InsertUpdateItemsTransfered = "SP_INV_ADD_ITEMS_TRANSFER_KNJ";
                            }
                            else if (var.Action == "E")
                            {
                                InsertUpdateItemsTransfered = "SP_INV_EDIT_ITEMS_TRANSFER_KNJ";
                            }
                            if (var.Action == "A" || var.Action == "E")
                            {
                                OracleParameter[] paramArr = new OracleParameter[20];
                                paramArr[0] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[1] = Utilities.GetOraParam(":P_ITEMS_CATEGORY_ID", var.ItemsCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[2] = Utilities.GetOraParam(":P_ITEMS_SUB_CATEGORY_ID", var.ItemsSubCategoryID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[3] = Utilities.GetOraParam(":P_ITEMS_ID", var.ItemsID, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[4] = Utilities.GetOraParam(":P_SEQ_NO", var.SeqNo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[5] = Utilities.GetOraParam(":P_TRFD_ORG", var.TransORG, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[6] = Utilities.GetOraParam(":P_TRFD_SEQ", var.TransSEQ, OracleDbType.Int32, ParameterDirection.InputOutput);
                                paramArr[7] = Utilities.GetOraParam(":P_DECISION_DATE", var.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[8] = Utilities.GetOraParam(":P_TRFD_DATE", var.TransDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[9] = Utilities.GetOraParam(":P_TRFD_VIA", var.TransVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[10] = Utilities.GetOraParam(":P_TRFD_RCVD_BY", var.TransRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[11] = Utilities.GetOraParam(":P_TRFD_ORG_UNIT", var.TransOrgUnit, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[12] = Utilities.GetOraParam(":P_TRFD_TO", var.TransTo, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[13] = Utilities.GetOraParam(":P_TRFD_RCVD_DATE", var.TransRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[14] = Utilities.GetOraParam(":P_RETURN_BY", var.ReturnBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[15] = Utilities.GetOraParam(":P_RETURN_DATE", var.ReturnDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[16] = Utilities.GetOraParam(":P_RETURN_VIA", var.ReturnVia, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[17] = Utilities.GetOraParam(":P_RETURN_RCVD_BY", var.ReturnRecvBy, OracleDbType.Int32, ParameterDirection.Input);
                                paramArr[18] = Utilities.GetOraParam(":P_RETURN_RCVD_DATE", var.ReturnRecvDate, OracleDbType.Varchar2, ParameterDirection.Input);
                                paramArr[19] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateItemsTransfered, paramArr);
                                var.TransSEQ = int.Parse(paramArr[6].Value.ToString());
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            Tran.Commit();
            return true;
        }
        public static DataTable getItemsTransKBJ()
        {
            string strSql = "SELECT * FROM VW_INV_ORG_ITEMS_TRANSFER WHERE 1=1";

            List<OracleParameter> paramArray = new List<OracleParameter>();


            strSql += " ORDER BY ITEMS_ID,ITEMS_NAME,ITEMS_TYPE_ID,ITEMS_TYPE_NAME ASC";

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
        public static DataTable getItemsTransfKNJ()
        {
            string strSql = "SELECT * FROM VW_INV_ORG_ITEMS_TRANSFER_KNJ WHERE 1=1";

            List<OracleParameter> paramArray = new List<OracleParameter>();


            strSql += " ORDER BY ITEMS_ID,ITEMS_NAME,ITEMS_TYPE_ID,ITEMS_TYPE_NAME ASC";

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
        public static DataTable getItemsType(int? itemsTypeID, string active)
        {
            string strSql = "SP_INV_GET_ITEMS_TYPE";
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_items_type_id ", itemsTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_active", active, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, strSql, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static DataTable SearchEmployee(ATTEmployeeWorkDivision objEmpWrkDiv)
        //{
        //    try
        //    {
        //        string strSelect = "";
        //        strSelect = "SELECT * FROM VW_EMP_WORK_DISTRIBUTION WHERE 1=1 ";
        //        List<OracleParameter> ParamList = new List<OracleParameter>();
        //        if (objEmpWrkDiv.OrgID > 0)
        //        {
        //            strSelect += "AND ORG_ID = :OrgID";
        //            ParamList.Add(Utilities.GetOraParam(":OrgID", objEmpWrkDiv.OrgID, OracleDbType.Int64, ParameterDirection.Input));
        //        }
        //        if (objEmpWrkDiv.OrgUnitID != null)
        //        {
        //            strSelect += " AND ORG_UNIT_ID = :OrgUnitID";
        //            ParamList.Add(Utilities.GetOraParam(":OrgUnitID", objEmpWrkDiv.OrgUnitID, OracleDbType.Int64, ParameterDirection.Input));
        //        }
                       
        //        strSelect += " ORDER BY ORG_ID";

        //        GetConnection conn = new GetConnection();
        //        OracleConnection obj = conn.GetDbConn(Module.PMS);

        //        DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.Text, strSelect, ParamList.ToArray());
        //        return (DataTable)ds.Tables[0];
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}