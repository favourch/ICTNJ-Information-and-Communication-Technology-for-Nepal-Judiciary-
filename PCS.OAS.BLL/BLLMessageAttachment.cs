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
    public class BLLMessageAttachment
    {
        public static DataTable GetMessageAttachmentListTable(string type, ATTUserLogin login)
        {
            try
            {
                DataTable tblMsgAttachment;
                tblMsgAttachment = DLLMessageAttachment.GetMessageAttachmentListTable(type, login);
                return tblMsgAttachment;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static List<ATTMessageAttachment> GetMsgAttachmentByIDs(int? orgID, int? msgID)
        {
            List<ATTMessageAttachment> lst = new List<ATTMessageAttachment>();
            try
            {
                DataTable tbl = DLLMessageAttachment.GetMsgAttachmentByIDs(orgID, msgID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTMessageAttachment att = new ATTMessageAttachment();
                    att.OrgID = int.Parse(row["org_id"].ToString());
                    att.MessageID = int.Parse(row["msg_id"].ToString());
                    att.AttachmentID = int.Parse(row["MSG_ATTACH_ID"].ToString());
                    att.FileName = row["FILE_NAME"].ToString();
                    att.ContentFile = row["FILE_BYTES"] as byte[];

                    lst.Add(att);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
