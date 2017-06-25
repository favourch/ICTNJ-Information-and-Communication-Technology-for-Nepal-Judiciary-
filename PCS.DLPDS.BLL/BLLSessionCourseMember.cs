using System;
using System.Collections.Generic;
using System.Text;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.DLPDS.BLL
{
    public class BLLSessionCourseMember
    {
        public static List<ATTSessionCourseMember> GetSessionCourseMember(int orgID, int prgID, int sessionID, int ? CourseID)
        {
            List<ATTSessionCourseMember> lstMem = new List<ATTSessionCourseMember>();
            try
            {
                foreach (DataRow grow in DLLSessionCourseMember.GetSessionCourseMember(orgID,prgID,sessionID,CourseID).Rows)
                {
                    ATTSessionCourseMember member = new ATTSessionCourseMember();
                    
                    member.OrgID = int.Parse(grow["org_id"].ToString());
                    member.ProgramID = int.Parse(grow["program_id"].ToString());
                    member.SessionID = int.Parse(grow["session_id"].ToString());
                    member.CourseID = int.Parse(grow["course_id"].ToString());
                    member.FacultyID = int.Parse(grow["faculty_id"].ToString()); ;
                    member.PID = int.Parse(grow["p_id"].ToString());
                    member.FromDate = grow["from_date"].ToString();
                    member.AssignmentDate = grow["assignment_date"].ToString();
                    member.ToDate = grow["to_date"].ToString();
                    member.Action = "M";

                    lstMem.Add(member);
                }

                return lstMem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<ATTSessionCourseMember> GetSessionCourseMemberForMarks(int orgID, int prgID, int sessionID, int? CourseID)
        {
            List<ATTSessionCourseMember> lstMem = new List<ATTSessionCourseMember>();
            try
            {
                foreach (DataRow grow in DLLSessionCourseMember.GetSessionCourseMemberForMarks(orgID, prgID, sessionID, CourseID).Rows)
                {
                    ATTSessionCourseMember member = new ATTSessionCourseMember();

                    member.OrgID = int.Parse(grow["org_id"].ToString());
                    member.ProgramID = int.Parse(grow["program_id"].ToString());
                    member.SessionID = int.Parse(grow["session_id"].ToString());
                    member.CourseID = int.Parse(grow["course_id"].ToString());
                    member.FacultyID = int.Parse(grow["faculty_id"].ToString()); ;
                    member.PID = int.Parse(grow["p_id"].ToString());
                    member.PersonName= grow["person_name"].ToString();
                    member.FromDate = grow["from_date"].ToString();
                    member.AssignmentDate = grow["assignment_date"].ToString();
                    member.ToDate = grow["to_date"].ToString();
                    member.MarksObtained= (grow["marksobtained"] == System.DBNull.Value) ? 0 : int.Parse(grow["marksobtained"].ToString());

                    member.Action = "M";

                    lstMem.Add(member);
                }

                return lstMem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateResourcePersonMarks(List<ATTSessionCourseMember> SCMLst)
        {
            try
            {
                DLLSessionCourseMember.UpdateResourcePersonMarks(SCMLst);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
