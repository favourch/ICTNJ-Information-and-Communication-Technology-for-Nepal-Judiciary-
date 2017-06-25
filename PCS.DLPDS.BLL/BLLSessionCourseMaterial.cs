using System;
using System.Collections.Generic;
using System.Text;
using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using System.Data;

namespace PCS.DLPDS.BLL
{
    public class BLLSessionCourseMaterial
    {
        public static List<ATTSessionCourseMaterial> GetSessionCourseMaretial(int orgID, int prgID, int sessionID, int CourseID, int CMID)
        {
            List<ATTSessionCourseMaterial> lstMat = new List<ATTSessionCourseMaterial>();
            try
            {
                foreach (DataRow row in DLLSessionCourseMaterial.GetSessionCourseMaretial(orgID, prgID, sessionID, CourseID, CMID).Rows)
                {
                    ATTSessionCourseMaterial mat = new ATTSessionCourseMaterial();

                    mat.OrgID = int.Parse(row["org_id"].ToString());
                    mat.ProgramID = int.Parse(row["program_id"].ToString());
                    mat.SessionID = int.Parse(row["session_id"].ToString());
                    mat.CourseID = int.Parse(row["course_id"].ToString());
                    mat.MaterialID = int.Parse(row["course_mat_id"].ToString());
                    mat.MaterialName = row["course_mat_name"].ToString();
                    if (row["course_mat_type_id"] == System.DBNull.Value || row["course_mat_type_id"] == null)
                        mat.MaterialTypeID = 0;
                    else
                        mat.MaterialTypeID = int.Parse(row["course_mat_type_id"].ToString());
                    mat.Action = "M";

                    lstMat.Add(mat);
                }

                return lstMat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
