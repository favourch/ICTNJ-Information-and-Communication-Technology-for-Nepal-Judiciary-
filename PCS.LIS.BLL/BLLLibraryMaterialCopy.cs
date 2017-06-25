using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLLibraryMaterialCopy
    {
        public static ObjectValidation Validate(ATTLibraryMaterialCopy obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.OrgID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Organization.";
                return OV;
            }

            if (obj.LibraryID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Library.";
                return OV;
            }

            if (obj.EntryBy == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Invalid user.";
                return OV;
            }

            return OV;
        }

        public static List<ATTLibraryMaterialCopy> GetLMCopy(int orgID, int libraryID, decimal lMaterialID)
        {
            List<ATTLibraryMaterialCopy> lstLMCopy = new List<ATTLibraryMaterialCopy>();
            foreach (DataRow row in DLLLibraryMaterialCopy.GetLMCopy(orgID, libraryID, lMaterialID).Rows)
            {
                ATTLibraryMaterialCopy libCopy = new ATTLibraryMaterialCopy();
                libCopy.AccessionID = int.Parse(row["accession_id"].ToString());
                libCopy.Edition = row["Edition"].ToString();
                libCopy.PublicationDate = row["Pub_Date"].ToString();
                libCopy.RegistrationDate = (DateTime)row["Reg_Date"];
                libCopy.IsbnIssnNo = row["Isbn_Issn"].ToString();
                libCopy.Price = double.Parse((row["Price"] == System.DBNull.Value) ? "0" : row["Price"].ToString());
                libCopy.CurrencyID = int.Parse(row["Currency_ID"].ToString());
                libCopy.Location = row["location"].ToString();

                lstLMCopy.Add(libCopy);
            }
            return lstLMCopy;
        }
    }
}
