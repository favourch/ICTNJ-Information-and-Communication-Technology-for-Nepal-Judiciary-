using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLProgram
    {
        public static ObjectValidation Validate(ATTProgram objProgram)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objProgram.OrgID  <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization ID cannot be blank.";
                return OV;
            }

            if (objProgram.ProgramName== "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Program Name Cannot be Blank.";
                return OV;
            }

            if (objProgram.ProgramTypeID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Select Program Type";
                return OV;
            }

            if (objProgram.LaunchDate == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Launch Date Can't Be Left Blank";
                return OV;
            
            }
            return OV;
        }


        public static List<ATTProgram> GetProgramList(int orgID,int programID,string ContainDefPorgramValue,string ContainDefPrgCoordinatorValue,string ContainDefPrgSponsorValue,string ContainDefSessionValue,string ContainDefSessionCourseValue, string ContainDefCourseValue)
        {
            List<ATTProgram> PorgramLST = new List<ATTProgram>();

            foreach (DataRow row in DLLProgram.GetProgramTable(orgID,programID).Rows)
            {
                ATTProgram objProgram = new ATTProgram
                                                    (
                                                        int.Parse(row["ORG_ID"].ToString()),
                                                        int.Parse(row["PROGRAM_ID"].ToString()),
                                                        row["PROGRAM_NAME"].ToString(),
                                                        int.Parse(row["PRG_TYPE_ID"].ToString()),
                                                        row["DESCRIPTION"].ToString(),
                                                        row["ACTIVE"].ToString(),
                                                        row["LAUNCH_DATE"].ToString(),
                                                        row["DURATION"].ToString(),
                                                        (row["DURATION_TYPE_ID"]==System.DBNull.Value)?0: int.Parse(row["DURATION_TYPE_ID"].ToString()),
                                                        row["TO_DATE"].ToString(),
                                                        row["LOCATION"].ToString(),
                                                        "A"
                                                    );
                objProgram.PrgCoordinatorLST = BLLProgramCoordinator.GetProgramCoordinatorList(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["PROGRAM_ID"].ToString()), 0,ContainDefPrgCoordinatorValue);

                objProgram.PrgSponsorLST = BLLProgramSponsor.GetProgramSponsorList(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["PROGRAM_ID"].ToString()), 0,ContainDefPrgSponsorValue);

                objProgram.SessionLST = BLLSessions.GetSessionList(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["PROGRAM_ID"].ToString()), 0, ContainDefSessionValue, ContainDefSessionCourseValue);

                objProgram.CourseLST = BLLCourse.GetCourseList(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["PROGRAM_ID"].ToString()), 0,ContainDefCourseValue);


                PorgramLST.Add(objProgram);
            }
            if (ContainDefPorgramValue == "Y")
                PorgramLST.Insert(0, new ATTProgram(0, 0, "--- Select Program ---", 0, "", "", "", "", 0, "", "", ""));
            return PorgramLST;
        }


        public static bool AddProgram(ATTProgram objProgram)
        {
            try
            {
                DLLProgram.AddProgram(objProgram);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
