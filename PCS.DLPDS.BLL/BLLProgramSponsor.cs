using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLProgramSponsor
    {
        public static List<ATTProgramSponsor> GetProgramSponsorList(int orgID, int programID, int sponsorID, string ContainDefPrgSponsorValue)
        {
            List<ATTProgramSponsor> ProgramSponsorLST = new List<ATTProgramSponsor>();

            foreach (DataRow row in DLLProgramSponsor.GetProgramSponsorTable(orgID, programID,sponsorID).Rows)
            {
                ATTProgramSponsor objPrgSponsor = new ATTProgramSponsor
                                                    (
                                                        int.Parse(row["ORG_ID"].ToString()),
                                                        int.Parse(row["PROGRAM_ID"].ToString()),
                                                        int.Parse(row["SPONSOR_ID"].ToString()),
                                                        row["FROM_DATE"].ToString(),
                                                        (row["BUDGET"]==System.DBNull.Value)?0:double.Parse(row["BUDGET"].ToString()),
                                                        (row["CURRENCY"]==System.DBNull.Value)?"":row["CURRENCY"].ToString(),
                                                        (row["TO_DATE"]==System.DBNull.Value)?"":row["TO_DATE"].ToString(),
                                                        ""
                                                    );
                objPrgSponsor.SponsorOBJ.SponsorName = row["SPONSOR_NAME"].ToString();

                //objProgram.PrgSponsorLST=bllp

                ProgramSponsorLST.Add(objPrgSponsor);
            }

            if (ContainDefPrgSponsorValue == "Y")
            {
                ATTProgramSponsor objPrgSponsor = new ATTProgramSponsor(0, 0, 0, "", 0, "", "", "");
                ProgramSponsorLST.Insert(0, objPrgSponsor);
            }

            return ProgramSponsorLST;
        }


    }
}
