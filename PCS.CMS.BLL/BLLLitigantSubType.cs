using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;


namespace PCS.CMS.BLL
{
    public class BLLLitigantSubType
    {
        public static List<ATTLitigantSubType> GetLitigantSubType(int? litigantSubTypeID, string active, int litSubTypeDV)
        {
            try
            {
                List<ATTLitigantSubType> litigantSubTypeLIST = new List<ATTLitigantSubType>();
                foreach (DataRow drow in DLLLitigantSubType.GetLitigantSubType(litigantSubTypeID, active).Rows)
                {
                    ATTLitigantSubType litigantSubType = new ATTLitigantSubType();

                    litigantSubType.LitigantSubTypeID = int.Parse(drow["LITIGANT_SUB_TYPE_ID"].ToString());
                    litigantSubType.LitigantSubTypeName = drow["LITIGANT_SUB_TYPE_NAME"].ToString();
                    litigantSubType.Active = drow["ACTIVE"].ToString();
                    litigantSubType.Action = "";

                    litigantSubTypeLIST.Add(litigantSubType);
                }
                if (litSubTypeDV > 0)
                {
                    litigantSubTypeLIST.Insert(0,new ATTLitigantSubType(0,"छान्नहोस",""));
                }
                return litigantSubTypeLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddEditDeleteLitigantSubType(ATTLitigantSubType litigantSubType)
        {
            try
            {
                return DLLLitigantSubType.AddEditDeleteLitigantSubType(litigantSubType);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
