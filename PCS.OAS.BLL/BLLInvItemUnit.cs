using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLInvItemUnit
    {
        /// <summary>
        /// Validates ItemUnit object
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>
        /// <returns>ObjectValidation object</returns>
        public static ObjectValidation Validate(ATTInvItemUnit obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.ItemUnitName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Item name cannot be empty.";
                return OV;
            }

            return OV;
        }

        /// <summary>
        /// get ItemUnit object from database
        /// </summary>        
        public static List<ATTInvItemUnit> GetItemList(int? ItemID, string active)
        {
            List<ATTInvItemUnit> lstInvItem = new List<ATTInvItemUnit>();
            try
            {
                foreach (DataRow row in DLLInvItemUnit.GetItemTable(ItemID,active).Rows)
                {
                    ATTInvItemUnit obj = new ATTInvItemUnit
                                                   (
                                                   int.Parse(row["items_unit_id"].ToString()),
                        row["items_unit_name"].ToString(),
                        (row["active"] == System.DBNull.Value) ? "" : (string)row["active"]                                                      
                                                   );

                    lstInvItem.Add(obj);
                }
                return lstInvItem;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTInvItemUnit> GetItemList(int? ItemID, string active,bool flag)
        {
            List<ATTInvItemUnit> lstInvItem = new List<ATTInvItemUnit>();
            try
            {
                foreach (DataRow row in DLLInvItemUnit.GetItemTable(ItemID, active).Rows)
                {
                    ATTInvItemUnit obj = new ATTInvItemUnit
                                                   (
                                                   int.Parse(row["items_unit_id"].ToString()),
                        row["items_unit_name"].ToString(),
                        (row["active"] == System.DBNull.Value) ? "" : (string)row["active"]
                                                   );

                    lstInvItem.Add(obj);
                }
                if (flag)
                {
                   lstInvItem.Insert(0,new ATTInvItemUnit(-1,"--छान्नुहोस्--","") );
                }
                return lstInvItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Passes item object to data layer to add in database
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>        
        /// <returns>return bool</returns>
        public static bool SaveItemUnit(ATTInvItemUnit obj)
        {
            try
            {
                return DLLInvItemUnit.SaveItemUnit(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
