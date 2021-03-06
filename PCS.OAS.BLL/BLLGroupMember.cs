using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLGroupMember
    {
        public static bool AddGroupMember(List<ATTGroupMember> lst)
        {
            try
            {
                return DLLGroupMember.AddGroupMember(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGroupMember> GetGroupMemberList(int? groupID)
        {
            try
            {
                List<ATTGroupMember> lstGroupMember = new List<ATTGroupMember>();

                foreach (DataRow row in DLLGroupMember.GetGroupMemberListTable(groupID).Rows)
                {
                    ATTGroupMember objGroupMember = new ATTGroupMember(  int.Parse(row["ORG_ID"].ToString()),
                                                                         int.Parse(row["GROUP_ID"].ToString()),
                                                                         int.Parse(row["EMP_ID"].ToString()),
                                                                         row["FROM_DATE"].ToString(),
                                                                         row["TO_DATE"].ToString(),
                                                                         (row["POSITION_ID"]==DBNull.Value?0:int.Parse(row["POSITION_ID"].ToString())),
                                                                         row["FIRST_NAME"].ToString() +
                                                                         (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                                                         (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString())
                                                                      );
                   
                    objGroupMember.Action = "N";
                    objGroupMember.OFromDate = objGroupMember.FromDate;
                    objGroupMember.OToDate = objGroupMember.ToDate;
                    objGroupMember.OPositionID = objGroupMember.PositionID;

                    objGroupMember.MemberPostion.PositionName = row["Position_name"].ToString();
                    lstGroupMember.Add(objGroupMember);
                }

                return lstGroupMember;

            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
       
    }
}
