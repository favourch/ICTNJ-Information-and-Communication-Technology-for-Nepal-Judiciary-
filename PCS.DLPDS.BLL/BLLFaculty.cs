using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLFaculty
    {
        public static List<ATTFaculty> GetFacultyList(int orgID, int facultyID)
        {
            List<ATTFaculty> FacultyLST = new List<ATTFaculty>();

            foreach (DataRow row in DLLFaculty.GetFacultyTable(orgID,facultyID).Rows)
            {
                ATTFaculty objFaculty = new ATTFaculty();
                objFaculty.OrgID = int.Parse(row["ORG_ID"].ToString());
                objFaculty.FacultyID = int.Parse(row["FACULTY_ID"].ToString());
                objFaculty.FacultyName = row["FACULTY_NAME"].ToString();
                objFaculty.Description = row["DESCRIPTION"].ToString();
                objFaculty.Active = row["ACTIVE"].ToString();

                FacultyLST.Add(objFaculty);
            }

            return FacultyLST;
        }
    }
}
