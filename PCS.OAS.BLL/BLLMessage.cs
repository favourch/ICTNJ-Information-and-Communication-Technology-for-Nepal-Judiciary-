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
    public class BLLMessage
    {
        public static DataTable tblMsg;
        public static DataTable tblMsgReceiver;
        public static DataTable tblMsgAttachment;

        public static bool SaveMessage(ATTMessage objMessage)
        {
            try
            {
                if (DLLMessage.SaveMessage(objMessage))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<ATTMessage> GetMessageByIDs(int? orgID, int? msgID)
        {
            List<ATTMessage> lst = new List<ATTMessage>();
            try
            {
                DataTable tbl = DLLMessage.GetMessageByIDs(orgID, msgID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTMessage msg = new ATTMessage();
                    msg.OrgID = int.Parse(row["org_id"].ToString());
                    msg.MessageID = int.Parse(row["msg_id"].ToString());
                    msg.Body = row["body"].ToString();
                    //fill remaining properties as required
                    lst.Add(msg);
                }

                tbl.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteMessage(List<ATTMessage> lst)
        {
            try
            {
                DLLMessage.DeleteMessage(lst);
                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static List<ATTMessage> GetMessageList(string type,ATTUserLogin login, string searchValue)
        {
            try
            {
                List<ATTMessage> lstMsg = new List<ATTMessage>();
                tblMsg = DLLMessage.GetMessageListTable(type,login,searchValue);

                tblMsgReceiver = BLLMessageReceiver.GetMessageReceiverListTable(type,login);

                tblMsgAttachment = BLLMessageAttachment.GetMessageAttachmentListTable(type, login);

                foreach (DataRow row in tblMsg.Rows)
                {
                    ATTMessage objMsg = new ATTMessage(
                                                           int.Parse(row["ORG_ID"].ToString()),
                                                           int.Parse(row["MSG_ID"].ToString()),
                                                           int.Parse(row["SENDER_ID"].ToString()),
                                                           row["S_FIRST_NAME"].ToString() +
                                                           (row["S_MID_NAME"].ToString() == "" ? "" : row["S_MID_NAME"].ToString()) +
                                                           (row["S_SUR_NAME"].ToString() == "" ? "" : row["S_SUR_NAME"].ToString()),
                                                           row["SUBJECT"].ToString(),
                                                           row["BODY"].ToString(),
                                                           "N",
                                                           DateTime.Parse(row["ENTRY_ON"].ToString())
                                                       );

                    objMsg.MessageTypeID = int.Parse(row["MSG_TYPE_ID"].ToString());

                    objMsg.TippaniOrgID =   row["TIP_ORG_ID"].ToString() == "" ? 0: int.Parse(row["TIP_ORG_ID"].ToString());
                    objMsg.TippaniID =   row["TIPPANI_ID"].ToString() == "" ? 0: int.Parse(row["TIPPANI_ID"].ToString());

                   
                    objMsg.LetterType = row["LETTER_TYPE"].ToString();
                    objMsg.Approve = row["APPROVE"].ToString();

                    //,LETTER_TYPE,APPROVE

                    if (type == "IN")
                    {
                        
                        objMsg.MsgSeq = int.Parse(row["MSG_SEQ"].ToString());
                        objMsg.MsgGrpType = row["is_grp_receiver"].ToString();
                        objMsg.LstMessageReceiver = SetMessageReceiver(objMsg, int.Parse(row["ORG_ID"].ToString()), int.Parse(row["MSG_ID"].ToString()), int.Parse(row["MSG_SEQ"].ToString()), type);

                        if (tblMsgAttachment.Rows.Count > 0)
                        {
                            objMsg.LstMsgAttachment = SetMessageAttachment(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["MSG_ID"].ToString()), int.Parse(row["MSG_SEQ"].ToString()), type);
                        }

                    }
                    else
                    {
                        objMsg.LstMessageReceiver = SetMessageReceiver(objMsg, int.Parse(row["ORG_ID"].ToString()), int.Parse(row["MSG_ID"].ToString()),null, type);

                        if (tblMsgAttachment.Rows.Count > 0)
                        {
                            objMsg.LstMsgAttachment = SetMessageAttachment(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["MSG_ID"].ToString()), null, type);
                        }

                    }

                    //if (tblMsgAttachment.Rows.Count > 0)
                    //{
                    //    objMsg.LstMsgAttachment = SetMessageAttachment(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["MSG_ID"].ToString()));
                    //}

                    lstMsg.Add(objMsg);
                }
                
                return lstMsg;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static List<ATTMessageAttachment> SetMessageAttachment(int orgID, int messageID, int? msgSeq, string type)
        {
            try
            {
                List<ATTMessageAttachment> lstMsgAttachment = new List<ATTMessageAttachment>();

                foreach (DataRow row in tblMsgAttachment.Rows)
                {
                    bool flag = false;
                    if (type == "IN")
                    {
                        if (orgID == int.Parse(row["ORG_ID"].ToString()) &&
                            messageID == int.Parse(row["MSG_ID"].ToString()) &&
                            msgSeq == int.Parse(row["MSG_SEQ"].ToString())
                            )
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        if (orgID == int.Parse(row["ORG_ID"].ToString()) &&
                             messageID == int.Parse(row["MSG_ID"].ToString())
                           )
                        {
                            flag = true;
                        }

                    }



                    //if (orgID == int.Parse(row["ORG_ID"].ToString()) &&
                    //     messageID == int.Parse(row["MSG_ID"].ToString())
                    //   )
                    if(flag)
                    {
                        ATTMessageAttachment objMsgAttachment = new ATTMessageAttachment(
                                                                                            int.Parse(row["ORG_ID"].ToString()),
                                                                                            int.Parse(row["MSG_ID"].ToString()),
                                                                                            int.Parse(row["MSG_ATTACH_ID"].ToString()),
                                                                                            row["FILE_NAME"].ToString().Trim(),
                                                                                            (byte[])(row["FILE_BYTES"])
                                                                                        );


                        if (row["FILE_NAME"].ToString().Trim().Length > 15)
                            objMsgAttachment.DisplayName = row["FILE_NAME"].ToString().Trim().Substring(0, 15) + ".....";
                        else
                            objMsgAttachment.DisplayName = row["FILE_NAME"].ToString().Trim();


                        lstMsgAttachment.Add(objMsgAttachment);
                    }
                }

                return lstMsgAttachment;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
            
        }

        public static List<ATTMessageReceiver> SetMessageReceiver(ATTMessage objMsg,int orgID, int messageID,int? msgSeq,string type)
        {
            List<ATTMessageReceiver> lstMsgReciever = new List<ATTMessageReceiver>();

            foreach (DataRow row in tblMsgReceiver.Rows)
            {
                bool flag = false;
                if(type == "IN")
                {
                    if (orgID == int.Parse(row["ORG_ID"].ToString()) &&
                        messageID == int.Parse(row["MSG_ID"].ToString()) &&
                        msgSeq == int.Parse(row["MSG_SEQ"].ToString())
                        )
                    {
                        flag = true;
                    }
                }
                else
                {
                    if (orgID == int.Parse(row["ORG_ID"].ToString()) &&
                         messageID == int.Parse(row["MSG_ID"].ToString())
                       )
                    {
                        flag = true;
                    }

                }

                if(flag)
                {
   
                       ATTMessageReceiver objMsgReceiver = new ATTMessageReceiver();
                       objMsgReceiver.OrgID = int.Parse(row["ORG_ID"].ToString());
                       objMsgReceiver.MessageID = int.Parse(row["MSG_ID"].ToString());
                       
                       
                       
                       objMsgReceiver.IsGrpReceiver = row["IS_GRP_RECEIVER"].ToString();

                       if (objMsgReceiver.IsGrpReceiver.Trim() == "Y")
                       {
                           

                           if (row["GRP_ORG_ID"].ToString() != "")
                               objMsgReceiver.ReceiverOrgID = int.Parse(row["GRP_ORG_ID"].ToString());
                           else
                               objMsgReceiver.ReceiverOrgID = null;

                           if (row["GRP_ID"].ToString() != "")
                               objMsgReceiver.GroupID = int.Parse(row["GRP_ID"].ToString());
                           else
                               objMsgReceiver.GroupID = null;

                           if (row["GRP_RECEIVER_ID"].ToString() != "")
                               objMsgReceiver.ReceiverID = int.Parse(row["GRP_RECEIVER_ID"].ToString());
                           else
                               objMsgReceiver.ReceiverID = null;

                           if (row["GRP_FROM_DATE"].ToString() != "")
                               objMsgReceiver.GrpFromDate =row["GRP_FROM_DATE"].ToString();

                           objMsgReceiver.Receiver = row["R_FIRST_NAME"].ToString() +
                                                  (row["R_MID_NAME"].ToString() == "" ? " " : row["R_MID_NAME"].ToString()) +
                                                  (row["R_SUR_NAME"].ToString() == "" ? " " : row["R_SUR_NAME"].ToString());
                      
                       }
                       else if (objMsgReceiver.IsGrpReceiver.Trim() == "N")
                       {
                           if (row["OTHER_RECEIVER_ID"].ToString() != "")
                               objMsgReceiver.OtherReceiverID = int.Parse(row["OTHER_RECEIVER_ID"].ToString());
                           else
                               objMsgReceiver.OtherReceiverID = null;

                           objMsgReceiver.ReceiverOrgID = null;
                           objMsgReceiver.GroupID = null;
                           objMsgReceiver.ReceiverID = null;
                           objMsgReceiver.GrpFromDate = null;

                           objMsgReceiver.OtherReceiver = row["R_FIRST_NAME"].ToString() +
                                                          (row["R_MID_NAME"].ToString() == "" ? " " : row["R_MID_NAME"].ToString()) +
                                                          (row["R_SUR_NAME"].ToString() == "" ? " " : row["R_SUR_NAME"].ToString());
                              

                       }



                       objMsgReceiver.Read = row["READ"].ToString();
                       objMsgReceiver.Action = "N";

                       objMsg.Read = objMsgReceiver.Read;

                       lstMsgReciever.Add(objMsgReceiver);
                       
                }
            }

            return lstMsgReciever;
        }

       
    }
}
