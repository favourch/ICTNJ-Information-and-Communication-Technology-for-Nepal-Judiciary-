using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
   public class BLLSessionCourse
    {
       public static bool SaveSessionCourse(List<ATTSessionCourse> LstSC)
       {
           try
           {
               return DLLSessionCourse.SaveSessionCourse(LstSC);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
           
       }



       public static List<ATTSessionCourse> GetSessionCourseList(int orgID, int programID, int sessionID, int CourseID, string ContainDefSessionCourseValue)
       {
           List<ATTSessionCourse> SessionCourseLST = new List<ATTSessionCourse>();

           foreach (DataRow row in DLLSessionCourse.GetSessionCourseTable(orgID, programID, sessionID,CourseID).Rows)
           {
               ATTSessionCourse SC = new ATTSessionCourse
                                                   (
                                                       int.Parse(row["ORG_ID"].ToString()),
                                                       int.Parse(row["PROGRAM_ID"].ToString()),
                                                       int.Parse(row["SESSION_ID"].ToString()),
                                                       int.Parse(row["COURSE_ID"].ToString()),
                                                       row["FROM_DATE"].ToString(),
                                                       (row["TO_DATE"] == System.DBNull.Value) ? "" : row["TO_DATE"].ToString(),
                                                       "",
                                                       ""

                                                   );
               SC.CourseName = row["COURSE_TITLE"].ToString();

               SC.LstSessionCourseMaterial = BLLSessionCourseMaterial.GetSessionCourseMaretial(SC.OrgID, SC.ProgramID, SC.SessionID, SC.CourseID, -1);
               SC.LstSessionCourseMember = BLLSessionCourseMember.GetSessionCourseMember(SC.OrgID, SC.ProgramID, SC.SessionID, SC.CourseID);

               SessionCourseLST.Add(SC);
           }
           if (ContainDefSessionCourseValue == "Y")
           {
               ATTSessionCourse Default = new ATTSessionCourse();
               Default.CourseName = "----- Select Course -----";
               SessionCourseLST.Insert(0, Default);
           }



           return SessionCourseLST;
       }

       public static bool AddSessionCourseMaterialNMember(ATTSessionCourse SC)
       {
           try
           {
               return DLLSessionCourse.AddSessionCourseMaterialNMember(SC);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

    }
}
