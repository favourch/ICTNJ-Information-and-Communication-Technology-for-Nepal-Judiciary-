using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COMMON.BLL;


namespace PCS.CMS.BLL
{
    public class BLLLitigants
    {
        public static List<ATTLitigants> GetLitigants(double ? caseID, double ? litigantID, string litigantType,int lawyerRQD,int witnessRQD,string PersonDocActive)
        {
            List<ATTLitigants> LitigantLST = new List<ATTLitigants>();
            try
            {
                foreach (DataRow row in DLLLitigants.GetLitigants(caseID, litigantID,litigantType).Rows)
                {
                    ATTLitigants objLit = new ATTLitigants();
                    objLit.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objLit.LitigantID = double.Parse(row["LITIGANT_ID"].ToString());
                    objLit.LitigantName = row["LITIGANTNAME"].ToString();
                    objLit.LitigantType = row["LITIGANT_TYPE"].ToString();
                    objLit.LitigantSubTypeID = row["LITIGANT_SUB_TYPE_ID"] == System.DBNull.Value ? 0 : int.Parse(row["LITIGANT_SUB_TYPE_ID"].ToString());
                    objLit.DisplayName = row["DISPLAY_NAME"] == System.DBNull.Value ? "" : row["DISPLAY_NAME"].ToString();
                    objLit.IsPrisoned = row["IS_PRISONED"].ToString();
                    objLit.EntityType = row["Entity_Type"].ToString();
                    objLit.Action = "";

                    if (objLit.IsPrisoned == "Y")
                        objLit.LitigantPrisonDetailsLST= BLLLitigantPrisonDetails.GetLitigantPrisonDetails(objLit.CaseID, objLit.LitigantID);

                    objLit.PersonOBJ = BLLPerson.GetPersons(objLit.LitigantID,PersonDocActive);

                    if (lawyerRQD == 1)
                    { }

                    if (witnessRQD == 1)
                    {
                        //objLit.wi
                    }

                    LitigantLST.Add(objLit);

                }

                
                return LitigantLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
