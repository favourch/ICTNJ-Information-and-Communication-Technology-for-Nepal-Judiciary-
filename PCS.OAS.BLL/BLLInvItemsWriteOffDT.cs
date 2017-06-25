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
    public class BLLInvItemsWriteOffDT
    {
        public static List<ATTInvItemsWriteOffDT> GetWriteOffDetailsDT(string MinahaDate)
        {
            try
            {
                List<ATTInvItemsWriteOffDT> LSTItemsKNJ = new List<ATTInvItemsWriteOffDT>();
                foreach (DataRow row in DLLInvItemsWriteOffDT.GetWriteOffDetailsDT(MinahaDate).Rows)
                {
                    ATTInvItemsWriteOffDT obj = new ATTInvItemsWriteOffDT();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.WriteOffSEQ = int.Parse(row["WRITEOFF_SEQ"].ToString());
                    obj.WriteOffDate = row["WRITEOFF_DATE"].ToString();
                    if (obj.AppBy != 0)
                    {
                        obj.AppBy = int.Parse(row["APP_BY"].ToString());
                    }
                    obj.FirstName = row["APP_PERSON"].ToString();
                    //obj.MiddleName = row["MID_NAME"].ToString();
                    //obj.LastName = row["SUR_NAME"].ToString();
                    obj.AppDate = row["APP_DATE"].ToString();
                    obj.AppYesNo = row["APP_YES_NO"].ToString();
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.JI_KHA_PA_NO = row["JI_KHA_PA_NO"].ToString();
                    obj.UnitPrice = int.Parse(row["UNIT_PRICE"].ToString());
                    obj.ItemsStatus = row["ITEMS_STATUS"].ToString();
                    obj.Remarks = row["REMARKS"].ToString();
                    LSTItemsKNJ.Add(obj);
                }
                return LSTItemsKNJ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
