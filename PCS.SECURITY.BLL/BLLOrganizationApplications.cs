using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.BLL
{
    public class BLLOrganizationApplications
    {
        public List<ATTOrganizationApplications> GetOrgApplications(int orgID)
        {
            return (GetOrgApplicationsList(PCS.SECURITY.DLL.DLLOrganizationApplications.GetOrgApplicationsTable(orgID)));
        }


        private static List<ATTOrganizationApplications> GetOrgApplicationsList(DataTable tbl)
        {
            List<ATTOrganizationApplications> OrgApplicationLST = new List<ATTOrganizationApplications>();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganizationApplications OrgApplicationObj = new ATTOrganizationApplications
                                                        (
                                                            int.Parse (row["ORG_ID"].ToString ()),
                                                            int.Parse(row["APPL_ID"].ToString()),
                                                            (string)row["FROM_DATE"].ToString (),
                                                            (string)row["TO_DATE"].ToString (),
                                                            "E"
                                                        );
                    //OrgApplicationObj.LSTApplication = BLLApplication.GetApplicationByIDList(int.Parse(row["ORG_ID"].ToString()));
                    OrgApplicationObj.Applications = new ATTApplication
                                                 (
                                                     int.Parse(row["APPL_ID"].ToString()),
                                                     (string)row["APPL_SHORT_NAME"].ToString(),
                                                     (string)row["APPL_FULL_NAME"].ToString(),
                                                     (string)row["DESCRIPTION"].ToString(),
                                                     "E"
                                                     
                                                  );

                    OrgApplicationObj.LSTRoles = BLLRoles.GetApplicationRoles(int.Parse(row["APPL_ID"].ToString()));
                                                                    
                                                                      
                    OrgApplicationLST.Add(OrgApplicationObj);
                }
                return OrgApplicationLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool AddOrganizationApplications(List<ATTOrganizationApplications> lstOrgApplications)
        {
            try
            {
                return DLLOrganizationApplications.AddOrganizationApplications(lstOrgApplications);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
