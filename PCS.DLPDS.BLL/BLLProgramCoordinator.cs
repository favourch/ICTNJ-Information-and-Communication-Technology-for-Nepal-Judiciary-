using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLProgramCoordinator
    {
        //public static bool AddProgramCoordinator(ATTProgramCoordinator objPrgCoordinator)
        //{
        //    try
        //    {
        //        DLLProgramCoordinator.AddProgramCoordinator(;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static List<ATTProgramCoordinator> GetProgramCoordinatorList(int orgID, int programID, int prgCoordinatorID, string ContainDefPrgCoordinatorValue)
        {
            List<ATTProgramCoordinator> ProgramCoordinatorLST = new List<ATTProgramCoordinator>();

            foreach (DataRow row in DLLProgramCoordinator.GetProgramCoordinatorTable(orgID, programID, prgCoordinatorID).Rows)
            {
                ATTProgramCoordinator objPrgCordinator = new ATTProgramCoordinator
                                                    (
                                                        int.Parse(row["ORG_ID"].ToString()),
                                                        int.Parse(row["PROGRAM_ID"].ToString()),
                                                        int.Parse(row["PRG_COORDINATOR_ID"].ToString()),
                                                        row["COORDINATOR_NAME"].ToString(),
                                                        double.Parse(row["P_ID"].ToString()),
                                                        int.Parse(row["COORDINATOR_TYPE_ID"].ToString()),
                                                        row["COORDINATOR_TYPE_NAME"].ToString(),
                                                        ""
                                                    );
//                objPrgSponsor.SponsorOBJ.SponsorName = row["SPONSOR_NAME"].ToString();


                ProgramCoordinatorLST.Add(objPrgCordinator);
            }
            if (ContainDefPrgCoordinatorValue == "Y")
            {
                ATTProgramCoordinator objPrgCoordinator = new ATTProgramCoordinator(0, 0, 0, "---Select Coordinator ---", 0, 0, "", "");
                ProgramCoordinatorLST.Insert(0, objPrgCoordinator);
            }
            return ProgramCoordinatorLST;
        }

    }
}
