using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;


namespace PCS.DLPDS.BLL
{
    public class BLLCourse
    {
        public static List<ATTCourse> GetCourseList(int orgID, int programID, int courseID, string ContainDefCourseValue)
        {
            List<ATTCourse> courseLST = new List<ATTCourse>();

            foreach (DataRow row in DLLCourse.GetCourseTable(orgID, programID, courseID).Rows)
            {
                ATTCourse objCourse = new ATTCourse
                                                    (
                                                        int.Parse(row["ORG_ID"].ToString()),
                                                        int.Parse(row["PROGRAM_ID"].ToString()),
                                                        int.Parse(row["COURSE_ID"].ToString()),
                                                        row["COURSE_TITLE"].ToString(),
                                                        (row["DESCRIPTION"] == System.DBNull.Value) ? "" : row["DESCRIPTION"].ToString(),
                                                        row["ACTIVE"].ToString(),
                                                        ""

                                                    );

                //objProgram.PrgSponsorLST=bllp

                courseLST.Add(objCourse);
            }
            if (ContainDefCourseValue == "Y")
            {
                ATTCourse objCourse= new ATTCourse(0,0,0,"---Select Course ---","","","");
                courseLST.Insert(0,objCourse);
            }

            return courseLST;
        }
    }
}
