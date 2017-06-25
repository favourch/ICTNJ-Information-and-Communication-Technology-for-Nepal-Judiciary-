using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLTameliType
    {
        public static List<ATTTameliType> GetTameliType(int? tameliTypeID, string active)
        {
            try
            {
                List<ATTTameliType> tameliTypeLIST = new List<ATTTameliType>();
                foreach (DataRow drow in DLLTameliType.GetTameliType(tameliTypeID, active).Rows)
                {
                    ATTTameliType tameliType = new ATTTameliType();

                    tameliType.TameliTypeID = int.Parse(drow["TAMELI_TYPE_ID"].ToString());
                    tameliType.TameliTypeName = drow["TAMELI_TYPE_NAME"].ToString();
                    tameliType.Active = drow["ACTIVE"].ToString();
                    tameliType.Action = ""; 
                  
                    tameliTypeLIST.Add(tameliType);
                }
                return tameliTypeLIST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddEditDeleteTameliType(ATTTameliType tameliType)
        {
            try
            {
                return DLLTameliType.AddEditDeleteTameliType(tameliType);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
