using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.BLL
{
    public class BLLMaagIssueHead
    {
        public static bool SaveMaagIssueHead(ATTMaagIssueHead objMaagIssueHead)
        {
            try
            {
                if (DLLMaagIssueHead.SaveMaagIssueHead(objMaagIssueHead))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
