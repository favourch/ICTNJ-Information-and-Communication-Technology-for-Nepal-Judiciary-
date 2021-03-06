using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLOrders
    {
        public static bool SaveOrders(ATTOrders objOrders)
        {
            try
            {
                return DLLOrders.SaveOrders(objOrders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrders> GetOrders(int? Orders, string active, int defaultFlag)
        {
            List<ATTOrders> OrdersList = new List<ATTOrders>();
            try
            {
                foreach (DataRow row in DLLOrders.GetOrders(Orders, active).Rows)
                {
                    ATTOrders Reglst = new ATTOrders(
                        int.Parse(row["ORDERS_ID"].ToString()),
                        row["ORDERS_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    OrdersList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    OrdersList.Insert(0, new ATTOrders(0, "छान्नुहोस", ""));
                return OrdersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
