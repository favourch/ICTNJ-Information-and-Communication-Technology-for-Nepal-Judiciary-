using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;


namespace PCS.CMS.BLL
{
    public class BLLOrgApplication
    {
        public static List<ATTOrgApplication> GetOrgApplication(int? applicationID, int ? orgID, string active)
        {
            List<ATTOrgApplication> OrgApplicationLST = new List<ATTOrgApplication>();
            try
            {
                foreach (DataRow row in DLLOrgApplication.GetOrgApplication(applicationID, orgID, active).Rows)
                {
                    ATTOrgApplication objOrgApplication = new ATTOrgApplication();
                    objOrgApplication.ApplicationID= int.Parse(row["APPLICATION_ID"].ToString());
                    objOrgApplication.OrgID =int.Parse( row["ORG_ID"].ToString());
                    objOrgApplication.Active = row["ACTIVE"].ToString();

                    //objApplication.OrgApplicationLST = bllOrgApplication.GetOrgApplication(int.Parse(row["APPLICATION_ID"].ToString()), null, null);

                    OrgApplicationLST.Add(objOrgApplication);
                }

                
                return OrgApplicationLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
