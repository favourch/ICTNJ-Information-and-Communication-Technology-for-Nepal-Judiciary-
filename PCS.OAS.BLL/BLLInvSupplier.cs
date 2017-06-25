using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
   public class BLLInvSupplier
    {
       public static bool AddSupplier(ATTInvSupplier supplier)
       {
           try
           {
               return DLLInvSupplier.AddSupplier(supplier);
               
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static List<ATTInvSupplier> GetSupplierList(int? supplierID)
       {
           List<ATTInvSupplier> lstsupplierList = new List<ATTInvSupplier>();

           try
           {
               foreach (DataRow row in DLLInvSupplier.GetSupplierTable(supplierID).Rows)
               {
                   ATTInvSupplier supplier = new ATTInvSupplier();


                   supplier.SupplierID = int.Parse(row["SUPPLIERS_ID"].ToString());
                   supplier.SupplierName = row["SUPPLIERS_NAME"].ToString();
                   supplier.SupplierAddress = row["SUPPLIERS_ADDRESS"].ToString();
                   supplier.PanNo = row["pan_no"].ToString();
                   supplier.Active = row["ACTIVE"].ToString();
                   //supplier.EntryBy= row["ENTRY_BY"].ToString();
                   supplier.Action = "";
                   supplier.LstSupplierContact = BLLInvSupplierContact.GetSupplierContactList(supplier.SupplierID);
                   lstsupplierList.Add(supplier);
               }
               return lstsupplierList;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



    }
}
