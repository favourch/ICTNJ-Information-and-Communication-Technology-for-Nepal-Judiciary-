using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLMessagePerson
    {
        public static List<ATTMessagePerson> GetMessagePersonList(int? orgID,int? unitID,string searchValue,bool ContainDefault)
        {
            List<ATTMessagePerson> lstMsgPerson = new List<ATTMessagePerson>();

            foreach (DataRow row in DLLMessagePerson.GetMessagePersonListTable(orgID,unitID,searchValue).Rows)
            {
                ATTMessagePerson objMsgPerson = new ATTMessagePerson(
                                                                        int.Parse(row["EMP_ID"].ToString()),
                                                                         row["FIRST_NAME"].ToString() +
                                                                        (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                                                        (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString())
                                                                                
                                                                    );
                lstMsgPerson.Add(objMsgPerson);
            }

            if (ContainDefault == true && lstMsgPerson.Count > 0)
            {
                lstMsgPerson.Insert(0, new ATTMessagePerson(0, "छान्नुहोस्"));
            }

            return lstMsgPerson;
  
        }
    }
}
