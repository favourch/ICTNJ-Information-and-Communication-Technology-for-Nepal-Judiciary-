using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.BLL
{
   public class BLLMessageReceiver
    {
        public static DataTable GetMessageReceiverListTable(string type, ATTUserLogin login)
        {
            try
            {
                DataTable tblMsgReceiver;
                tblMsgReceiver = DLLMessageReceiver.GetMessageReceiverListTable(type, login);
                return tblMsgReceiver;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

       public static bool UpdateMessageReceiver(int orgID, int msgID, int msgSeqID)
       {
           try
           {
               return DLLMessageReceiver.UpdateMessageReceiver(orgID, msgID, msgSeqID);
           }
           catch (Exception ex)
           {
               
               throw(ex);
           }
       }
    }
}
