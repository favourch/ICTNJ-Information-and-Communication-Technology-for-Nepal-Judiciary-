using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    /// <summary>
    /// This class implements the bussines rule of author and communicate with data layer
    /// </summary>
    public class BLLAuthor
    {
        /// <summary>
        /// Validates Author object
        /// </summary>
        /// <param name="obj">object of ATTAuthor</param>
        /// <returns>object of ObjectValidation</returns>
        public static ObjectValidation Validate(ATTAuthor obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.AuthorName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Author name cannot be empty.";
                return OV;
            }

            return OV;
        }

        /// <summary>
        /// Get list of author
        /// </summary>
        /// <param name="authorID">Author ID for filter criteria</param>
        /// <returns> List<> of ATTAuthor</returns>
        public static List<ATTAuthor> GetAuthorList(int? authorID)
        {
            List<ATTAuthor> lstAuthor = new List<ATTAuthor>();

            try
            {
                foreach (DataRow row in DLLAuthor.GetAuthorTable(authorID).Rows)
                {
                    ATTAuthor obj = new ATTAuthor
                                                    (
                                                        int.Parse(row["Author_ID"].ToString()),
                                                        row["Author_Name"].ToString()
                                                    );

                    lstAuthor.Add(obj);

                }
                return lstAuthor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Passes author object to data layer to add in database
        /// </summary>
        /// <param name="obj">ATTAuthor object</param>
        /// <param name="username">username for checking previlege at database level</param>
        /// <param name="menuname">menuname for checking previlege at database level</param>
        /// <returns>return bool</returns>
        public static bool AddAuthor(ATTAuthor obj,Previlege pobj)
        {
            try
            {
                return DLLAuthor.AddAuthor(obj, pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Passes author object to data layer to update in database
        /// </summary>
        /// <param name="obj">ATTAuthor object</param>
        /// <param name="username">username for checking previlege at database level</param>
        /// <param name="menuname">menuname for checking previlege at database level</param>
        /// <returns>return bool</returns>
        public static bool EditAuthor(ATTAuthor obj, Previlege pobj)
        {
            try
            {
                return DLLAuthor.EditAuthor(obj, pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
