using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL
{
    public class BLLPhone
    {
        public static  List<ATT.ATTPhone> GetPhoneList(DataTable tbl)
        {

            List<ATT.ATTPhone> lst = new List<PCS.COMMON.ATT.ATTPhone>();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    
                    ATT.ATTPhone ObjAtt = new PCS.COMMON.ATT.ATTPhone
                                                                    (
                                                                    int.Parse(row["org_id"].ToString()),
                                                                    (string)row["p_type"],
                                                                    (string)row["phone_type"],
                                                                    int.Parse(row["p_sno"].ToString()),
                                                                    (string)row["phone"],
                                                                    (string)row["active"],
                                                                    "shyam remarks",
                                                                   null,
                                                                    DateTime.Now
                                                                    );
                    lst.Add(ObjAtt);

                }
                return lst;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static List<ATT.ATTPhone> GetPhone(int? OrgId)
        {
            try
            {
                return (GetPhoneList(DLLPhone.GetPhone(OrgId)));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

    }
}
