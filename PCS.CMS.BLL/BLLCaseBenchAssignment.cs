using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseBenchAssignment
    {
        public static bool AddEditDeleteCaseBenchAssignment(List<ATTCaseBenchAssignment> objLST)
        {
            try
            {
                return DLLCaseBenchAssignment.AddEditDeleteCaseBenchAssignment(objLST);

            }
            catch (Exception ex)
            {

                            throw ex;
            }

        }
    }
}
