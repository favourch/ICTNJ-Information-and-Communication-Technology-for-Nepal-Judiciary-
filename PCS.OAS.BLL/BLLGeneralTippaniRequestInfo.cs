using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
namespace PCS.OAS.BLL
{
    public class BLLGeneralTippaniRequestInfo
    {
        public static List<ATTGeneralTippaniRequestInfo> GetTippaniRequestInfoList(ATTGeneralTippaniRequestInfo info, int sIndex, int eIndex, ref decimal totalRecord)
        {
            List<ATTGeneralTippaniRequestInfo> lst = new List<ATTGeneralTippaniRequestInfo>();

            try
            {
                DataTable tbl = new DataTable();

                if (info.RequestType == TippaniProcessRequestType.Request)
                    tbl = DLLGeneralTippaniRequestInfo.GetTippaniRequestInfo(info, sIndex, eIndex, ref totalRecord);
                else if (info.RequestType == TippaniProcessRequestType.History)
                    tbl = DLLGeneralTippaniRequestInfo.GetTippaniRequestHistory(info);

                string tippaniList = "";

                foreach (DataRow row in tbl.Rows)
                {
                    ATTGeneralTippaniRequestInfo obj = new ATTGeneralTippaniRequestInfo();

                    obj.OrgID = int.Parse(row["org_id"].ToString());
                    obj.TippaniID = int.Parse(row["tippani_id"].ToString());
                    obj.TippaniProcessID = int.Parse(row["tippani_process_id"].ToString());
                    obj.ProcessByID = (row["process_by_id"].ToString() == "") ? 0 : double.Parse(row["process_by_id"].ToString());
                    obj.ProcessBy = row["process_by"].ToString();
                    obj.IsChannelPerson = row["is_channel_person"].ToString();
                    obj.TippaniSubject = row["tippani_text"].ToString();
                    obj.ProcessOn = row["send_on"].ToString();
                    obj.ProcessToID = double.Parse(row["process_to_id"].ToString());
                    obj.ProcessTo = row["process_to"].ToString();
                    obj.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    obj.TippaniSubjectName = row["tippani_subject_name"].ToString();
                    obj.TippaniStatusID = int.Parse(row["tippani_status_ID"].ToString());
                    obj.TippaniStatusName = row["tippani_status_Name"].ToString();
                    obj.ProcessStatusID = (row["process_status_ID"].ToString() == "") ? 0 : int.Parse(row["process_status_ID"].ToString());
                    obj.ProcessStatusName = row["process_status_Name"].ToString();
                    obj.Note = row["note"].ToString();
                    obj.SenderOrgID = (row["sender_org_id"].ToString() == "") ? 0 : int.Parse(row["sender_org_id"].ToString());
                    obj.SenderUnitID = (row["sender_unit_id"].ToString() == "") ? 0 : int.Parse(row["sender_unit_id"].ToString());
                    obj.SenderOrgName = row["sender_org_name"].ToString();
                    obj.SenderUnitName = row["sender_unit_name"].ToString();
                    obj.ReceiverOrgID = int.Parse(row["receiver_org_id"].ToString());
                    obj.ReceiverUnitID = int.Parse(row["receiver_unit_id"].ToString());
                    obj.ReceiverOrgName = row["receiver_org_name"].ToString();
                    obj.ReceiverUnitName = row["receiver_unit_name"].ToString();
                    
                    tippaniList = tippaniList + obj.TippaniID.ToString() + ", ";
                    
                    lst.Add(obj);
                }

                if (info.RequestType == TippaniProcessRequestType.History)
                {
                    ATTGeneralTippaniAttachment infox = new ATTGeneralTippaniAttachment();
                    infox.OrgID = info.OrgID;
                    infox.TippaniID = info.TippaniID;
                    List<ATTGeneralTippaniAttachment> lstAttachment = BLLGeneralTippaniAttachment.GetAttachment(infox, tippaniList);

                    foreach (ATTGeneralTippaniRequestInfo request in lst)
                    {
                        request.LstAttachment = lstAttachment.FindAll
                                                                (
                                                                    delegate(ATTGeneralTippaniAttachment a)
                                                                    {
                                                                        return a.OrgID == request.OrgID
                                                                        && a.TippaniID == request.TippaniID
                                                                        && a.TippaniProcessID == request.TippaniProcessID;
                                                                    }
                                                                );
                    }
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
