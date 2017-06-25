using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLWitnessSearch
    {
        public static List<ATTWitnessSearch> SearchWitnessPerson(ATTWitnessSearch objWitnessSearch)
        {
            List<ATTWitnessSearch> lstWitnessPerson = new List<ATTWitnessSearch>();

            foreach (DataRow row in DLLWitnessSearch.SearchWitnessPerson(objWitnessSearch).Rows)
            {
                ATTWitnessSearch obj = new ATTWitnessSearch();
                obj.CaseID = int.Parse(row["CASE_ID"].ToString());
                obj.LItigantID = int.Parse(row["LITIGANT_ID"].ToString());
                obj.PersonID = int.Parse(row["PERSON_ID"].ToString());
                obj.WitnessID = int.Parse(row["WITNESS_ID"].ToString());
                obj.WitnessName = row["WITNESSNAME"].ToString();
                obj.FromDate = row["FROM_DATE"].ToString();
                obj.WitnessGender = row["WIT_GENDER"].ToString();
                obj.WitnessDOB = row["WIT_DOB"].ToString();
                lstWitnessPerson.Add(obj);
            }
            return lstWitnessPerson;
        }
    }
}
