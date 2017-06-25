using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLInvItems
    {

        // <summary>
        /// Validates ItemUnit object
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>
        /// <returns>ObjectValidation object</returns>
        public static ObjectValidation Validate(ATTInvItems obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.ItemsName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Items name cannot be empty.";
                return OV;
            }           
            if (obj.ItemsCategoryID < 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Item Category";
                return OV;
            }
            if (obj.ItemsTypeID < 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Item type";
                return OV;
            }
            if (obj.ItemsUnitID < 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Item unit";
                return OV;
            }            
            return OV;
        }

        public static List<ATTInvItems> GetInvItems(ATTInvItems obj)
        {
            List<ATTInvItems> lstitems = new List<ATTInvItems>();
            try
            {
                foreach (DataRow row in DLLInvItems.getInvItems(obj).Rows)
                {
                    ATTInvItems objitems = new ATTInvItems();

                    objitems.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    objitems.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    objitems.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    objitems.ItemsCD = row["ITEMS_CD"].ToString();
                    objitems.ItemsName = row["ITEMS_NAME"].ToString();
                    objitems.ItemsShortName = row["ITEMS_SHORT_NAME"].ToString();
                    objitems.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());                                        
                    objitems.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                   // objitems.ItemsSpecification = row["ITEMS_SPECIFICATIONS"].ToString();
                    //objitems.IssuedTo = row["ISSUED_TO"].ToString();
                    objitems.Active = row["active"].ToString();                   
                    lstitems.Add(objitems);
                }
                return lstitems;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Passes item object to data layer to add in database
        /// </summary>
        /// <param name="obj">ATTInvItems object</param>        
        /// <returns>return bool</returns>
        public static bool SaveItems(List<ATTInvItems> lstItems)
        {
            try
            {
                return DLLInvItems.SaveItems(lstItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
