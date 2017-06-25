using System;
using System.Collections.Generic;
using System.Text;
//
using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.DLPDS.BLL
{
    public class BLLFacultyMember
    {
        public static bool SaveFacultyMember(ATTFacultyMember objFacultyMember)
        {
            try
            {
                return DLLFacultyMember.SaveFacultyMember(objFacultyMember);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public static List<ATTFacultyMember> getFacultyMember()
        //{
            //List<ATTFacultyMember> lstFaculty = new List<ATTFacultyMember>();
            //foreach (DataRow varRow in DLLFacultyMember.GetFacultyMember().Rows)
            //{
            //    ATTFacultyMember attF = new ATTFacultyMember
            //        (
            //            int.Parse(varRow["ORG_ID"].ToString()), //Table's Column
            //            int.Parse(varRow["FACULTY_ID"].ToString()),
            //            double.Parse(varRow["P_ID"].ToString()),
            //            varRow["FROM_DATE"].ToString(),
            //            varRow["TO_DATE"].ToString(),
            //            varRow["P_NAME"].ToString()
            //        );
            //    lstFaculty.Add(attF);
            //}
            //return lstFaculty;
            
        //}

        public static DataTable GetFacultyMemberTable(int? orgID, int? facultyID)
        {
            try
            {
                return DLLFacultyMember.GetFacultyMember(orgID, facultyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
