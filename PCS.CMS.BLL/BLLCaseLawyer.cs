using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

namespace PCS.CMS.BLL
{
    public class BLLCaseLawyer
    {
        public static bool SaveCaseLawyer(List< ATTCaseLaywer> CaseLawyerLST)
        {
            try
            {
                return DLLCaseLawyer.SaveCaseLawyers(CaseLawyerLST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTCaseLaywer> GetCaseLawyer(double? caseID, double? litigantID, double? lawyerID)
        {
            List<ATTCaseLaywer> CLLST = new List<ATTCaseLaywer>();
            try
            {
                foreach (DataRow row in DLLCaseLawyer.getCaseLawyer(caseID, litigantID, lawyerID).Rows)
                {
                    ATTCaseLaywer objCL = new ATTCaseLaywer();
                    objCL.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCL.LitigantType = row["LITIGANT_TYPE"].ToString();
                    objCL.LitigantID = double.Parse(row["LITIGANT_ID"].ToString());
                    objCL.LitigantName = row["LITIGANTNAME"].ToString();
                    objCL.LawyerID= double.Parse(row["LAWYER_ID"].ToString());
                    objCL.FromDate = row["FROM_DATE"] == System.DBNull.Value ? "" : row["FROM_DATE"].ToString();
                    objCL.LawyerName= row["LAWYERNAME"].ToString();
                    objCL.ToDate = "";
                    objCL.LicenceNo= row["LICENSE_NO"].ToString();
                    objCL.Action = "";

                    objCL.PersonOBJ = BLLPerson.GetPersons(objCL.LawyerID,null);


                    CLLST.Add(objCL);

                }


                return CLLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
