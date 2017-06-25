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
    public class BLLInvSupplierContact
    {
        public static List<ATTInvSupplierContact> GetSupplierContactList(int? supplierID)
        {
            List<ATTInvSupplierContact> lstSupplierContact = new List<ATTInvSupplierContact>();

            try
            {
                foreach (DataRow row in DLLInvSupplierContact.GetSupplierContactTable(supplierID).Rows)
                {
                    ATTInvSupplierContact obj = new ATTInvSupplierContact();

                    obj.SupplierID = int.Parse(row["SUPPLIERS_ID"].ToString());
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.ContactPerson = row["CONTACT_PERSON"].ToString();
                    obj.ContactPhone = row["CONTACT_PHONE"].ToString();
                    obj.ContactEmail = row["CONTACT_EMAIL"].ToString();
                    lstSupplierContact.Add(obj);
                }

                return lstSupplierContact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
