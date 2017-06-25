using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
namespace PCS.OAS.BLL
{
    public class BLLGeneralTippaniAttachment
    {
        public static bool AddAttachment(List<ATTGeneralTippaniAttachment> lst, object tran, int tippaniSubjectID, TippaniSubject subject, int tippaniID, int processID)
        {
            try
            {
                return DLLGeneralTippaniAttachment.AddAttachment(lst, tran, tippaniSubjectID, subject, tippaniID, processID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGeneralTippaniAttachment> GetAttachment(ATTGeneralTippaniAttachment attach, string tippaniList)
        {
            List<ATTGeneralTippaniAttachment> lst = new List<ATTGeneralTippaniAttachment>();
            
            try
            {
                if (tippaniList != "")
                {
                    tippaniList = tippaniList.Remove(tippaniList.LastIndexOf(','), 2);

                    DataTable tbl = DLLGeneralTippaniAttachment.GetAttachment(attach);
                    foreach (DataRow row in tbl.Rows)
                    {
                        ATTGeneralTippaniAttachment attachment = new ATTGeneralTippaniAttachment();
                        attachment.OrgID = int.Parse(row["org_id"].ToString());
                        attachment.TippaniID = int.Parse(row["tippani_id"].ToString());
                        attachment.TippaniProcessID = int.Parse(row["tippani_process_id"].ToString());
                        attachment.AttachmentID = int.Parse(row["attachment_id"].ToString());
                        attachment.DocumentName = row["doc_name"].ToString();
                        attachment.Description = row["Description"].ToString();
                        attachment.Action = "N";

                        lst.Add(attachment);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] GetAttachedFile(int orgID, int tippaniID, int prcID, int attID)
        {
            try
            {
                object obj = DLLGeneralTippaniAttachment.GetAttachedFile(orgID, tippaniID, prcID, attID);
                return obj as byte[];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
