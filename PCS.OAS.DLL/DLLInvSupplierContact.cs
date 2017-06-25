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
    public class DLLInvSupplierContact
    {
        public static DataTable GetSupplierContactTable(int? supplierID)//int? seqID
        {
            string SelectSP = "sp_inv_get_suppliers_contact";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_suppliers_id", supplierID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddSupplierContact(List<ATTInvSupplierContact> lstSupplierContact, int supplierID, OracleTransaction Tran)
        {
            string InsertSP = "";
            List<ATTInvSupplierContact> lst = lstSupplierContact.FindAll(
                                                      delegate(ATTInvSupplierContact obj)
                                                      {
                                                          return obj.Action != null;
                                                      }
                                                          );
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTInvSupplierContact supplierContact in lst)
                {
                    if (supplierContact.Action == "D")
                    {
                        InsertSP = "SP_INV_DEL_SUPPLIERS_CONTACT";


                        paramArray.Add(Utilities.GetOraParam(":P_SUPPLIERS_ID", supplierID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_SEQ_NO", supplierContact.SeqNo, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
                        supplierContact.SupplierID = supplierID;
                       
                        paramArray.Clear();
                    }
                    else
                    {

                        if (supplierContact.Action == "A")
                            InsertSP = "SP_INV_ADD_SUPPLIERS_CONTACT";
                        else if (supplierContact.Action == "E")
                            InsertSP = "SP_INV_EDIT_SUPPLIERS_CONTACT";


                        paramArray.Add(Utilities.GetOraParam(":P_SUPPLIERS_ID", supplierID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_SEQ_NO", supplierContact.SeqNo, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam(":P_CONTACT_PERSON", supplierContact.ContactPerson, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_CONTACT_PHONE", supplierContact.ContactPhone, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_CONTACT_EMAIL", supplierContact.ContactEmail, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", supplierContact.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
                        supplierContact.SupplierID = supplierID;
                        
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

    }
}
