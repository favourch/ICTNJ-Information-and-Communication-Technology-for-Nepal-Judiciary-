using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLApplication
    {
        public static bool SaveApplication(ATTApplication objApplication)
        {
            try
            {
                return DllApplication.SaveApplication(objApplication);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTApplication> GetApplication(int? applicationID,string applicationType, string active, int defaultFlag)
        {
            List<ATTApplication> ApplicationLST = new List<ATTApplication>();
            try
            {
                foreach (DataRow row in DllApplication.GetApplication (applicationID,applicationType, active).Rows)
                {
                    ATTApplication objApplication = new ATTApplication();
                    objApplication.ApplicationID= int.Parse(row["APPLICATION_ID"].ToString());
                    objApplication.ApplicationName = row["APPLICATION_NAME"].ToString();
                    objApplication.ApplicationType= row["APPLICATION_TYPE"].ToString();
                    objApplication.Active = row["ACTIVE"].ToString();

                    objApplication.OrgApplicationLST = BLLOrgApplication.GetOrgApplication(int.Parse(row["APPLICATION_ID"].ToString()), null, null);

                    ApplicationLST.Add(objApplication);
                }

                if (defaultFlag > 0)
                {
                    ATTApplication obj = new ATTApplication();
                    obj.ApplicationID= 0;
                    obj.ApplicationName = "छान्नुहोस";
                    ApplicationLST.Insert(0, obj);

                }
                return ApplicationLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
