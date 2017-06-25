using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLTippaniChannel
    {
        public static List<ATTTippaniChannel> GetTippaniChannelList(int? orgID, int? tippaniSubjectID)
        {
            List<ATTTippaniChannel> lst = new List<ATTTippaniChannel>();
            try
            {
                DataTable tbl = DLLTippaniChannel.GetTippaniChannel(orgID, tippaniSubjectID);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTTippaniChannel channel = new ATTTippaniChannel();

                    channel.ChannelSeqID = int.Parse(row["channel_seq_id"].ToString());
                    channel.OTOrgID = int.Parse(row["ot_org_id"].ToString());
                    channel.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    channel.ChannelPersonID = double.Parse(row["emp_id"].ToString());
                    channel.OTFromDate = row["OT_FROM_DATE"].ToString();
                    channel.FromDate = row["tc_from_date"].ToString();
                    channel.ToDate = "";
                    channel.ChannelPersonOrder = int.Parse(row["channel_person_order"].ToString());
                    channel.ChannelPersonType = row["channel_person_type"].ToString();
                    channel.IsFinalApprover = row["is_final_approver"].ToString() == "Y" ? true : false;
                    channel.ChannelPersonName = row["p_name"].ToString();
                    channel.OrgName = row["org_name"].ToString();
                    channel.DegName = row["des_name"].ToString();
                    channel.CommitteeName = row["group_name"].ToString();
                    channel.PostName = row["position_name"].ToString();
                    channel.OrgID = int.Parse(row["org_id"].ToString());
                    channel.DesID = int.Parse(row["des_id"].ToString());
                    channel.CreatedDate = row["created_date"].ToString();
                    channel.PostID = int.Parse(row["post_id"].ToString());
                    channel.PostFromDate = row["from_date"].ToString();
                    channel.OrgID = int.Parse(row["org_id"].ToString());
                    channel.UnitID = int.Parse(row["org_unit_id"].ToString());
                    channel.UnitName = row["unit_name"].ToString();
                    channel.UnitFromDate = row["unit_from_date"].ToString();
                    channel.UnitOrgID = int.Parse(row["org_id"].ToString());

                    channel.Action = "N";

                    //channel.OrgID = int.Parse(row["tc_org_id"].ToString());
                    //channel.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    //channel.ChannelPersonID = double.Parse(row["channel_person_id"].ToString());
                    //channel.ChannelPersonName = row["p_name"].ToString();
                    //channel.OrgName = row["org_name"].ToString();
                    //channel.CommitteeName = row["group_name"].ToString();
                    //channel.PostName = row["position_name"].ToString();
                    //channel.FromDate = row["from_date"].ToString();
                    //channel.ChannelPersonOrder = int.Parse(row["channel_person_order"].ToString());
                    //channel.ChannelPersonType = row["channel_person_type"].ToString();
                    //channel.IsFinalApprover = row["is_final_approver"].ToString() == "Y" ? true : false;
                    //channel.OldValue = channel.FromDate + "|" + channel.ChannelPersonOrder + "|" + channel.ChannelPersonType + "|" + channel.IsFinalApprover.ToString();
                    //channel.Action = "N";

                    lst.Add(channel);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddTippaniChannel(List<ATTTippaniChannel> lst)
        {
            try
            {
                return DLLTippaniChannel.AddTippaniChannel(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetLoginEmpType(int orgID, int subjectID, double empID)
        {
            try
            {
                object obj = DLLTippaniChannel.GetLoginEmpType(orgID, subjectID, empID);
                return obj.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckLoginUserIsChannelMember(int orgId, int subjectID, double empID)
        {
            try
            {
                int c = DLLTippaniChannel.CheckLoginUserIsChannelMember(orgId, subjectID, empID);
                if (c <= 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
