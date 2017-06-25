using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLLibrary
    {

        public static ObjectValidation Validate(ATTLibrary objLib)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objLib.OrgID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization ID cannot be blank.";
                return OV;
            }

            if (objLib.EntryBy == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Invalid user.";
                return OV;
            }

            if (objLib.LibraryName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Library name cannot be blank.";
                return OV;
            }

            //if (objLib.EntryOn != DateTime.Now.Date)
            //{
            //    OV.IsValid = false;
            //    OV.ErrorMessage = "Entry date should be current date.";
            //    return OV;
            //}

            return OV;
        }

        public static List<ATTLibrary> GetLibraryNameList()
        {
            List<ATTLibrary> lstLibraryName = new List<ATTLibrary>();

            try
            {
                foreach (DataRow row in DLLLibrary.GetLibraryNameListTable().Rows)
                {
                    ATTLibrary LibObj = new ATTLibrary
                                                    (int.Parse(row["org_id"].ToString()),
                                                        int.Parse(row["Library_ID"].ToString()),
                                                        row["Library_Name"].ToString()
                                                    );

                    lstLibraryName.Add(LibObj);

                }
                return lstLibraryName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTLibrary> GetLibraryList(int orgID, int? libraryID, char containDefaultValue)
        {
            List<ATTLibrary> LibraryLST = new List<ATTLibrary>();

            foreach (DataRow row in DLLLibrary.GetLibraryTable(orgID, libraryID).Rows)
            {
                ATTLibrary library = new ATTLibrary
                                                    (
                                                        int.Parse(row["Library_ID"].ToString()),
                                                        orgID,
                                                        row["Library_Name"].ToString(),
                                                        row["Location"].ToString(),
                                                        "a",
                                                        DateTime.Now
                                                    );

                LibraryLST.Add(library);
            }

            if (containDefaultValue.ToString().ToUpper() == "Y")
                LibraryLST.Insert(0, new ATTLibrary(0, 0, "--- Select Library ---", "", "", DateTime.Now));

            return LibraryLST;
        }

        public static bool AddLibrary(ATTLibrary obj,Previlege pobj)
        {
            try
            {
                DLLLibrary.AddLibrary(obj,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EditLibrary(ATTLibrary obj,Previlege pobj)
        {
            try
            {
                DLLLibrary.EditLibrary(obj,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
