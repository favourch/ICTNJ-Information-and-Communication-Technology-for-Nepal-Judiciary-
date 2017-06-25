using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLTarikhLocation
    {

        public static bool AddTarikhLocation(List<ATTTarikhLocation> lstTarikhLocation)
        {
            try
            {
                return DLLTarikhLocation.AddTarikhLocation(lstTarikhLocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteTarikhLocation(int caseId, int personId, int courtId)
        {
            try
            {
                return DLLTarikhLocation.DeleteTarikhLocation(caseId, courtId, personId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTTarikhLocation> GetTarikhLocation(int caseId)
        {
            List<ATTTarikhLocation> lst = new List<ATTTarikhLocation>();
            try
            {
                DataTable dt = DLLTarikhLocation.GetTarikhLocation(caseId);
                foreach (DataRow row in dt.Rows)
                {
                    ATTTarikhLocation obj = new ATTTarikhLocation();
                    obj.Name = row["FULLNAME"].ToString();
                    obj.Court = row["ORG_NAME"].ToString();
                    obj.FromDate = row["FROM_DATE"].ToString();
                    obj.CaseID = int.Parse(row["CASE_ID"].ToString());
                    obj.PersonID = int.Parse(row["PERSON_ID"].ToString());
                    obj.CourtID=int.Parse(row["ORG_ID"].ToString());
                    obj.Action = "N";
                    lst.Add(obj);

                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
