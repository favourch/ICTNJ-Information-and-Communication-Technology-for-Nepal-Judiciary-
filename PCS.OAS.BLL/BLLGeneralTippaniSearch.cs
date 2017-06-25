using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using System.Collections.Generic;

namespace PCS.OAS.BLL
{
    public class BLLGeneralTippaniSearch
    {
        public static List<ATTGeneralTippaniSearch> GetTippaniDetails(ATTGeneralTippaniSearch objTipp)
        {
            List<ATTGeneralTippaniSearch> lst = new List<ATTGeneralTippaniSearch>();
                            
		    try
            {
                DataTable dt = DLLGeneralTippaniSearch.GetTippaniDetails(objTipp);
                foreach (DataRow row in dt.Rows)
                {
                    ATTGeneralTippaniSearch obj = new ATTGeneralTippaniSearch();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.TippaniID = int.Parse(row["TIPPANI_ID"].ToString());
                    obj.TippaniSubjectID = int.Parse(row["TIPPANI_SUBJECT_ID"].ToString());
                    obj.TippaniSubject = row["TIPPANI_SUBJECT_NAME"].ToString();
                    obj.TippaniOn = row["TIPPANI_ON"].ToString();
                    obj.TippaniText = row["TIPPANI_TEXT"].ToString();
                    obj.FileNo = int.Parse(row["FILE_NO"].ToString());
                    obj.TippaniStatus = row["TIPPANI_STATUS_NAME"].ToString();
                    lst.Add(obj);

                }
                return lst;


	        }
	        catch (Exception)
	        {
        		
		        throw;
	        }
                }

    }
}
