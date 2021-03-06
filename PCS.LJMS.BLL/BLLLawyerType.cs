using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.LJMS.ATT;
using PCS.LJMS.DLL;

namespace PCS.LJMS.BLL
{
    public class BLLLawyerType
    {
        public static List<ATTLawyerType> GetLawyerTypeList(int? ltID, bool containDefault)
        {
            List<ATTLawyerType> lst = new List<ATTLawyerType>();
            try
            {
                foreach (DataRow row in DLLLawyerType.GetLawyerTypeListTable(ltID).Rows)
                {
                    ATTLawyerType obj = new ATTLawyerType();

                    obj.LawyerTypeID = int.Parse(row["LAWYER_TYPE_ID"].ToString());
                    obj.LawyerTypeDescription = row["LAWYER_TYPE_DESCRIPTION"].ToString();
                    obj.Active = row["ACTIVE"].ToString();


                    lst.Add(obj);
                }
                if (lst.Count > 0 && containDefault == true)
                {
                    ATTLawyerType def = new ATTLawyerType();
                    def.LawyerTypeID = -1;
                    def.LawyerTypeDescription = "छान्नुहोस्";
                    lst.Insert(0, def);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
