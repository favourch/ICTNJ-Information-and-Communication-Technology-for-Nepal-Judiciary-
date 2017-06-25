using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;


namespace PCS.OAS.BLL
{
    public class BLLDartaaChalaani
    {
        public static List<ATTDartaaChalaani> GetDartaaChalaaniByIDs(int orgID, string regDate, int regNo)
        {
            List<ATTDartaaChalaani> lst = new List<ATTDartaaChalaani>();
            try
            {
                DataTable tbl = DLLDartaaChalaani.GetDartaaChalaaniByIDs(orgID, regDate, regNo);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTDartaaChalaani dar = new ATTDartaaChalaani();
                    dar.OrgID = int.Parse(row["org_id"].ToString());
                    dar.RegDate = row["reg_date"].ToString();
                    dar.RegNo = int.Parse(row["reg_no"].ToString());
                    dar.Description = row["description"].ToString();
                    dar.RegFile = row["reg_file"] as byte[];
                    dar.FileName = row["file_name"].ToString();
                    // fill remaining properties as required :: future use

                    lst.Add(dar);
                }
                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static List<ATTInvItems> GetDartaaChalaani(ATTDartaaChalaani obj)
        //{
        //    List<ATTInvItems> lstitems = new List<ATTInvItems>();
        //    try
        //    {
        //        //foreach (DataRow row in DLLDartaaChalaani.GetDartaaChalaani(obj.doc,.Rows)
        //        //{
        //        //    ATTInvItems objitems = new ATTInvItems();

        //        //    objitems.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
        //        //    objitems.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
        //        //    objitems.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
        //        //    objitems.ItemsCD = row["ITEMS_CD"].ToString();
        //        //    objitems.ItemsName = row["ITEMS_NAME"].ToString();
        //        //    objitems.ItemsShortName = row["ITEMS_SHORT_NAME"].ToString();
        //        //    objitems.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
        //        //    objitems.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
        //        //    objitems.ItemsSpecification = row["ITEMS_SPECIFICATIONS"].ToString();
        //        //    objitems.IssuedTo = row["ISSUED_TO"].ToString();
        //        //    objitems.Active = row["active"].ToString();
        //        //    lstitems.Add(objitems);
        //        //}
        //        return lstitems;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Passes item object to data layer to add in database
        /// </summary>
        /// <param name="obj">ATTInvItems object</param>        
        /// <returns>return bool</returns>
        public static bool SaveDartaaChalaani(ATTDartaaChalaani obj)
        {
            try
            {
              
                return DLLDartaaChalaani.SaveDartaaChalaani(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
