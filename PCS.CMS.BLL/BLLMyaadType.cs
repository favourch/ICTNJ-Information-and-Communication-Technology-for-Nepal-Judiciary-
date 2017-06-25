using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLMyaadType
    {
        public static List<ATTMyaadType> GetMyaadType(int? myaadTypeID, string active)
        {
            try
            {
                List<ATTMyaadType> myaadTypeLIST = new List<ATTMyaadType>();
                foreach (DataRow drow in DLLMyaadType.GetMyaadType(myaadTypeID, active).Rows)
                {
                    ATTMyaadType myaadType = new ATTMyaadType();

                    myaadType.MyaadTypeID = int.Parse(drow["MYAAD_TYPE_ID"].ToString());
                    myaadType.MyaadTypeName = drow["MYAAD_TYPE_NAME"].ToString();
                    myaadType.Litigant = drow["LITIGANT"].ToString();
                    myaadType.Attorney = drow["ATTORNEYS"].ToString();
                    myaadType.Witness = drow["WITNESS"].ToString();
                    myaadType.Active = drow["ACTIVE"].ToString();
                    myaadType.Action = ""; 
                  
                    myaadTypeLIST.Add(myaadType);
                }
                return myaadTypeLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddEditDeleteMyaadType(ATTMyaadType myaadType)
        {
            try
            {
                return DLLMyaadType.AddEditDeleteMyaadType(myaadType);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
