using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLSubmissionDetails
    {
        public static bool SaveSubmissionDetails(ATTSubmissionDetails objSD)
        {
            try
            {
                return DLLSubmissionDetails.SaveSubmissionDetails(objSD);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
