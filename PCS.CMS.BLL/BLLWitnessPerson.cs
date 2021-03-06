using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

namespace PCS.CMS.BLL
{
    public class BLLWitnessPerson
    {
        public static bool SaveWitnessPerson(List<ATTWitnessPerson> LstWP)
        {
            return DLLWitnessPerson.SaveWitnessPerson(LstWP);
        }

        public static List<ATTWitnessPerson> GetWitness(double? caseID, double? litigantID, double ? personID,double? witnessID)
        {
            List<ATTWitnessPerson> WPLST = new List<ATTWitnessPerson>();
            try
            {
                foreach (DataRow row in DLLWitnessPerson.getWitnessPerson(caseID, litigantID,personID,witnessID).Rows)
                {
                    ATTWitnessPerson objWP = new ATTWitnessPerson();
                    objWP.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objWP.LitigantType= row["LITIGANT_TYPE"].ToString();
                    objWP.LitigantID = double.Parse(row["LITIGANT_ID"].ToString());
                    objWP.LitigantName = row["LITIGANTNAME"].ToString();
                    objWP.PersonID =double.Parse( row["Person_ID"].ToString());
                    objWP.FromDate= row["FROM_DATE"] == System.DBNull.Value ? "" : row["FROM_DATE"].ToString();
                    objWP.WitnessName = row["WITNESSNAME"].ToString();
                    objWP.ToDate = "";
                    objWP.WitnessID=int.Parse( row["WITNESS_ID"].ToString());
                    objWP.Action = "";

                    objWP.PersonOBJ = BLLPerson.GetPersons(objWP.PersonID,null);

                    
                    WPLST.Add(objWP);

                }


                return WPLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
