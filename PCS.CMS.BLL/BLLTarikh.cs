using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLTarikh
    {
       

        public static bool AddTarikh(List<ATTTarikh> lst)
        {
            try
            {
                return DLLTarikh.AddTarikh(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddTarikhDetails(List<ATTTarikh> lst)
        {
            try
            {
                return DLLTarikh.AddTarikhDetails(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTTarikh> GetTarikhDetails(int caseId,string tarikhDate)
        {
            List<ATTTarikh> lst = new List<ATTTarikh>();
            try
            {
                DataTable dt = DLLTarikh.GetTarikhDetails(caseId, tarikhDate);
                foreach (DataRow row in dt.Rows)
                {
                    ATTTarikh obj = new ATTTarikh();
                    obj.CaseID = int.Parse(row["CASE_ID"].ToString());
                    obj.PersonID = int.Parse(row["PERSON_ID"].ToString());
                    obj.PersonName = row["FULLNAME"].ToString();
                    obj.TarikhDate = row["TAREKH_DATE"].ToString();
                    obj.PresentDate = row["PRESENT_DATE"].ToString();
                    obj.TakenTime = row["TAKEN_DATE"].ToString();
                    obj.TarikhTime = row["TAREKH_TIME"].ToString();
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

        public static List<ATTTarikh> GetTarikh(int caseId)
        {
            List<ATTTarikh> lst = new List<ATTTarikh>();
            try
            {
                DataTable dt = DLLTarikh.GetTarikh(caseId);
                foreach (DataRow row in dt.Rows)
                {
                    ATTTarikh obj = new ATTTarikh();
                    obj.CaseID = int.Parse(row["CASE_ID"].ToString());
                    obj.TarikhDate = row["TAREKH_DATE"].ToString();
                    obj.TarikhTime = row["TAREKH_TIME"].ToString();
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
