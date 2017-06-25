using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLLibraryMaterial
    {
        public static ObjectValidation Validate(ATTLibraryMaterial obj)
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

            if (obj.LibraryMaterialCategory <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Category.";
                return OV;
            }

            if (obj.LibraryMaterialType <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Type.";
                return OV;
            }

            if (obj.CallNo == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Call no cannot be blank.";
                return OV;
            }

            if (obj.Title == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Title cannot be blank.";
                return OV;
            }

            if (obj.ContentFile != null)
            {
                decimal size = decimal.Parse(obj.ContentFile.Length.ToString());
                size = size / 1024;
                size = size / 1024;
                size = Math.Round(size, 2);

                if (size > 2)
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "File size cannot be greater then 2 MB.Currrent file size: " + size.ToString() + " MB";
                    return OV;
                }
            }

            if (obj.ContentFile != null)
            {
                if (obj.CFileType.ToUpper() != ".TXT" && obj.CFileType.ToUpper() != ".PDF" && obj.CFileType.ToUpper() != ".JPG" && obj.CFileType.ToUpper() != ".JPEG" && obj.CFileType.ToUpper() != ".GIF")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "File must be of (pdf, jpg, jpeg, txt) type.";
                    return OV;
                }
            }

            if (obj.EntryBy == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Invalid user.";
                return OV;
            }

            return OV;
        }

        public static long AddLibraryMaterial(ATTLibraryMaterial obj, Previlege pobj)
        {
            try
            {
                return DLLLibraryMaterial.AddLibraryMaterial(obj, pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddLibraryMaterialCopy(List<ATTLibraryMaterialCopy> obj,long LMID)
        {
            try
            {
                return DLLLibraryMaterial.AddLibraryMaterialCopy(obj, LMID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static byte[] GetLMAttachmentFile(int orgID, int libraryID, decimal lMaterialID)
        {
            object obj;
            byte[] bytes;

            try
            {
                obj = DLLLibraryMaterial.GetLMAttachmentFile(orgID, libraryID, lMaterialID);
                if (obj == System.DBNull.Value || obj == null)
                    bytes = null;
                else
                    bytes = (byte[])obj;

                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTLibraryMaterial> GetSearchedLibraryMaterialList(ATTLibraryMaterial criteria, string keyCollection, string authorCollection, string action)
        {
            try
            {
                #region "Commented logic for merging material copy"
                //List<ATTLibraryMaterial> lstLM = new List<ATTLibraryMaterial>();
                //DataTable tblLM = DLLLibraryMaterial.GetSearchedLibraryMaterialTable();

                //int orgID;
                //int libraryID;
                //long lMaterialID;
                //long accessionID;

                //ATTLibraryMaterial tempLib = new ATTLibraryMaterial();

                //foreach (DataRow row in tblLM.Rows)
                //{
                //    ATTLibraryMaterial lib = null;

                //    orgID = int.Parse(row["Org_ID"].ToString());
                //    libraryID = int.Parse(row["Library_ID"].ToString());
                //    lMaterialID = long.Parse(row["L_Material_ID"].ToString());
                //    accessionID = long.Parse(row["Accession_ID"].ToString());

                //    lib = lstLM.Find
                //                    (
                //                        delegate(ATTLibraryMaterial LM)
                //                        {
                //                            return LM.OrgID == orgID &&
                //                                LM.LibraryID == libraryID &&
                //                                LM.LMaterialID == lMaterialID;
                //                        }
                //                    );

                //    if (lib == null)
                //    {
                //        lib = new ATTLibraryMaterial();
                //        lib.OrgID = orgID;
                //        lib.LibraryID = libraryID;
                //        lib.LMaterialID = lMaterialID;

                //        tempLib = lib;

                //        lstLM.Add(tempLib);
                //    }

                //    ATTLibraryMaterialCopy libCopy = null;

                //    libCopy = tempLib.LstLMCopy.Find
                //                                    (
                //                                        delegate(ATTLibraryMaterialCopy copy)
                //                                        {
                //                                            return
                //                                                copy.OrgID == orgID &&
                //                                                copy.LibraryID == libraryID &&
                //                                                copy.LMaterialID == lMaterialID &&
                //                                                copy.AccessionID == accessionID;
                //                                        }
                //                                    );

                //    if (libCopy == null)
                //    {
                //        libCopy = new ATTLibraryMaterialCopy();
                //        libCopy.OrgID = orgID;
                //        libCopy.LibraryID = libraryID;
                //        libCopy.LMaterialID = lMaterialID;
                //        libCopy.AccessionID = accessionID;

                //        tempLib.LstLMCopy.Add(libCopy);
                //    }
                //}
                //return lstLM;

                #endregion

                DataTable tbl = DLLLibraryMaterial.GetSearchedLibraryMaterialTable(criteria, keyCollection, authorCollection);

                List<ATTLibraryMaterial> lstLM = new List<ATTLibraryMaterial>();

                int orgID;
                int libraryID;
                long lMaterialID;
                long accessionID;

                ATTLibraryMaterial tempLib = new ATTLibraryMaterial();

                foreach (DataRow row in tbl.Rows)
                {
                    ATTLibraryMaterial lib = null;

                    orgID = int.Parse(row["Org_ID"].ToString());
                    libraryID = int.Parse(row["Library_ID"].ToString());
                    lMaterialID = long.Parse(row["L_Material_ID"].ToString());
                    accessionID = long.Parse(row["Accession_ID"].ToString());

                    lib = lstLM.Find
                                    (
                                        delegate(ATTLibraryMaterial LM)
                                        {
                                            return LM.OrgID == orgID &&
                                                LM.LibraryID == libraryID &&
                                                LM.LMaterialID == lMaterialID;
                                        }
                                    );

                    if (lib == null)
                    {
                        lib = new ATTLibraryMaterial();
                        lib.OrgID = orgID;
                        lib.LibraryID = libraryID;
                        lib.LMaterialID = lMaterialID;
                        lib.Title = row["Title"].ToString();
                        lib.LibraryMaterialType = int.Parse(row["MT_ID"].ToString());
                        lib.LibraryMaterialCategory = int.Parse(row["Category_ID"].ToString());
                        lib.CallNo = row["Call_NO"].ToString();
                        lib.CorporateBody = row["Corporate_Body"].ToString();
                        lib.SeriesStatement = row["Series_State"].ToString();
                        lib.Note = row["Note"].ToString();
                        lib.BoardSubjectHeading = row["Brd_Subject_Heading"].ToString();
                        lib.GeoDescription = row["Geo_Desc"].ToString();
                        lib.PhysicalDescription = row["Phy_Desc"].ToString();
                        lib.LanguageID = int.Parse(row["Lang_ID"].ToString());
                        lib.PublisherID = int.Parse(row["Publisher_ID"].ToString());
                        //if (row["Content_File"] == System.DBNull.Value)
                        //    lib.ContentFile = null;
                        //else
                        //    lib.ContentFile = (byte[])row["Content_File"];
                        lib.CFileType = row["File_Type"].ToString();

                        lib.Action = action;

                        tempLib = lib;

                        lstLM.Add(tempLib);
                    }

                    ATTLibraryMaterialCopy libCopy = null;

                    libCopy = tempLib.LstLMCopy.Find
                                                    (
                                                        delegate(ATTLibraryMaterialCopy copy)
                                                        {
                                                            return
                                                                copy.OrgID == orgID &&
                                                                copy.LibraryID == libraryID &&
                                                                copy.LMaterialID == lMaterialID &&
                                                                copy.AccessionID == accessionID;
                                                        }
                                                    );

                    if (libCopy == null)
                    {
                        libCopy = new ATTLibraryMaterialCopy();

                        libCopy.OrgID = orgID;
                        libCopy.LibraryID = libraryID;
                        libCopy.LMaterialID = lMaterialID;
                        libCopy.AccessionID = accessionID;
                        libCopy.Edition = row["Edition"].ToString();
                        libCopy.PublicationDate = row["Pub_Date"].ToString();
                        libCopy.RegistrationDate = (DateTime)row["Reg_Date"];
                        libCopy.IsbnIssnNo = row["Isbn_Issn"].ToString();
                        libCopy.Price = double.Parse((row["Price"] == System.DBNull.Value) ? "0" : row["Price"].ToString());
                        libCopy.CurrencyID = int.Parse(row["Currency_ID"].ToString());
                        libCopy.Location = row["MT_COPY_LOC"].ToString();
                        libCopy.Action = action;

                        tempLib.LstLMCopy.Add(libCopy);
                    }
                }

                return lstLM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}