using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.COMMON.DLL;
using PCS.COMMON.ATT;

using PCS.FRAMEWORK;
using PCS.SECURITY.BLL;
using PCS.SECURITY.ATT;


namespace PCS.COMMON.BLL
{
    public class BLLOrganization
    {
        public static ObjectValidation Validate(ATTOrganization objOrg)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objOrg.OrgName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Name cannot be Blank.";
                return OV;
            }

            if (objOrg.OrgType == "0")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Type cannot be Blank.";
                return OV;
            }

            if (objOrg.OrgSubType == "0")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Sub Type cannot be Blank.";
                return OV;
            }
            if (objOrg.OrgDistrict == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization District cannot be Blank.";
                return OV;
            }

            if (objOrg.OrgVdcMuni == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization VDC cannot be Blank.";
                return OV;
            }
            if (objOrg.OrgWardNo == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Ward cannot be Blank.";
                return OV;
            }
            if (objOrg.OrgAddress == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Address cannot be Blank.";
                return OV;
            }

            return OV;
        }

        public static List<ATTOrganization> GetOrganizationNameList()
        {
            List<ATTOrganization> lstOrgName = new List<ATTOrganization>();

            try
            {
                foreach (DataRow row in DLLOrganization.GetOrganization().Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                    (
                                                        int.Parse(row["org_id"].ToString()),
                                                        row["org_name"].ToString()
                                                    );

                    lstOrgName.Add(OrgObj);

                }
                return lstOrgName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> GetOrganizationNameList(string searchValue)
        {
            List<ATTOrganization> lstOrgName = new List<ATTOrganization>();

            try
            {
                foreach (DataRow row in DLLOrganization.GetOrganization(searchValue).Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                    (
                                                        int.Parse(row["org_id"].ToString()),
                                                        row["org_name"].ToString()
                                                    );

                    lstOrgName.Add(OrgObj);

                }
                return lstOrgName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<ATTOrganization> getOrganizationApplicationUserRoleList(DataTable tbl)
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();

            try
            {

                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                                 (
                                                                     int.Parse(row["org_id"].ToString()),
                                                                     (string)row["org_name"].ToString(),
                                                                     (string)row["org_type"].ToString(),
                                                                     (string)row["org_sub_type"].ToString(),
                                                                     (row["parent_id"] == System.DBNull.Value) ? 0 : int.Parse(row["parent_id"].ToString())
                                                                 );

                    OrgObj.LSTOrgApplications = new BLLOrganizationApplications().GetOrgApplications(int.Parse(row["org_id"].ToString()));

                    OrgObj.LSTOrgUsers = new BLLOrganizationUsers().GetOrgUsers(int.Parse(row["org_id"].ToString()));
                    lst.Add(OrgObj);
                }
                //lst.Insert(0, new ATTOrganization(0, "--- Select One ---", "", "", 0));
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> getOrganizationApplicationUserRole(int flgDefault, int orgID)
        {
            return (getOrganizationApplicationUserRoleList(PCS.COMMON.DLL.DLLOrganization.GetOrganizationByID(orgID)));

        }

        private static List<ATTOrganization> getOrganizationApplicationList(DataTable tbl)
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();

            try
            {

                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                                 (
                                                                     int.Parse(row["org_id"].ToString()),
                                                                     (string)row["org_name"].ToString(),
                                                                     (string)row["org_type"].ToString(),
                                                                     (string)row["org_sub_type"].ToString(),
                                                                     (row["parent_id"] == System.DBNull.Value) ? 0 : int.Parse(row["parent_id"].ToString())
                                                                 );

                    OrgObj.LSTOrgApplications = new BLLOrganizationApplications().GetOrgApplications(int.Parse(row["org_id"].ToString()));

                    lst.Add(OrgObj);
                }
                lst.Insert(0, new ATTOrganization(0, "--- Select One ---", "", "", 0));
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> getOrganizationApplication(int flgDefault)
        {
            return (getOrganizationApplicationList(PCS.COMMON.DLL.DLLOrganization.GetOrganization()));

        }

        private static List<ATTOrganization> GetOrganizationList(DataTable tbl)
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            List<ATTEmail> lstOrgEMail = BLLEmail.GetEmail(null);
            List<ATTPhone> lstOrgPhone = BLLPhone.GetPhone(null);

            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                                    (
                                                                    int.Parse(row["org_id"].ToString()),
                                                                    (string)row["org_name"],
                                                                    ((row["org_type"] == System.DBNull.Value) ? "" : (string)row["org_type"]),
                                                                    ((row["org_sub_type"] == System.DBNull.Value) ? "" : (string)row["org_sub_type"]),
                                                                    ((row["parent_id"] == System.DBNull.Value) ? 0 : int.Parse(row["parent_id"].ToString())),
                                                                    ((row["org_address"] == System.DBNull.Value) ? "" : (string)row["org_address"]),
                                                                    ((row["org_street_name"] == System.DBNull.Value) ? "" : (string)row["org_street_name"]),
                                                                    ((row["org_vdc_muni"] == System.DBNull.Value) ? 0 : int.Parse(row["org_vdc_muni"].ToString())),
                                                                    ((row["org_url"] == System.DBNull.Value) ? "" : (string)row["org_url"]),
                                                                    ((row["org_ward_no"] == System.DBNull.Value) ? 0 : int.Parse(row["org_ward_no"].ToString())),
                                                                    ((row["org_dist"] == System.DBNull.Value) ? 0 : int.Parse(row["org_dist"].ToString())),
                                                                    ((row["org_equ_code"] == System.DBNull.Value) ? 0 : int.Parse(row["org_equ_code"].ToString())),
                                                                    ((row["zone_id"] == System.DBNull.Value) ? 0 : int.Parse(row["zone_id"].ToString()))
                                                                     );
                    OrgObj.LstEmail = lstOrgEMail.FindAll(delegate(ATTEmail email) { return email.OrgId == OrgObj.OrgID; });
                    OrgObj.LstPhone = lstOrgPhone.FindAll(delegate(ATTPhone phone) { return phone.OrgId == OrgObj.OrgID; });
                    // In GetOrganizationList(DataTable tbl) below code is added by shanjeev Sah
                    OrgObj.NepDistname = row["DIST_UCODE"].ToString();
                    OrgObj.NepVdcname = row["VDC_UCODE"].ToString();
                    //OrgObj.ZoneName = row["zone_name"].ToString();

                    lst.Add(OrgObj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> GetOrganization()
        {
            try
            {
                return (GetOrganizationList(PCS.COMMON.DLL.DLLOrganization.GetOrganization()));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<ATTOrganization> GetOrganizationByID(int OrgID)
        {
            try
            {
                return GetOrganizationList(DLLOrganization.GetOrganizationByID(OrgID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<ATTOrganization> GetOrganizationList(DataTable tbl, int OrgDV)
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            List<ATTEmail> lstOrgEMail = BLLEmail.GetEmail(null);
            List<ATTPhone> lstOrgPhone = BLLPhone.GetPhone(null);

            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization
                                                                    (
                                                                    int.Parse(row["org_id"].ToString()),
                                                                    (string)row["org_name"],
                                                                    ((row["org_type"] == System.DBNull.Value) ? "" : (string)row["org_type"]),
                                                                    ((row["org_sub_type"] == System.DBNull.Value) ? "" : (string)row["org_sub_type"]),
                                                                    ((row["parent_id"] == System.DBNull.Value) ? 0 : int.Parse(row["parent_id"].ToString())),
                                                                    ((row["org_address"] == System.DBNull.Value) ? "" : (string)row["org_address"]),
                                                                    ((row["org_street_name"] == System.DBNull.Value) ? "" : (string)row["org_street_name"]),
                                                                    ((row["org_vdc_muni"] == System.DBNull.Value) ? 0 : int.Parse(row["org_vdc_muni"].ToString())),
                                                                    ((row["org_url"] == System.DBNull.Value) ? "" : (string)row["org_url"]),
                                                                    ((row["org_ward_no"] == System.DBNull.Value) ? 0 : int.Parse(row["org_ward_no"].ToString())),
                                                                    ((row["org_dist"] == System.DBNull.Value) ? 0 : int.Parse(row["org_dist"].ToString())),
                                                                    ((row["org_equ_code"] == System.DBNull.Value) ? 0 : int.Parse(row["org_equ_code"].ToString())),
                                                                    ((row["zone_id"] == System.DBNull.Value) ? 0 : int.Parse(row["zone_id"].ToString()))
                                                                     );
                    OrgObj.LstEmail = lstOrgEMail.FindAll(delegate(ATTEmail email) { return email.OrgId == OrgObj.OrgID; });
                    OrgObj.LstPhone = lstOrgPhone.FindAll(delegate(ATTPhone phone) { return phone.OrgId == OrgObj.OrgID; });

                    lst.Add(OrgObj);
                }
                if (OrgDV != 0)
                    lst.Insert(0, new ATTOrganization(0, "छान्नहोस"));
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> GetOrganization(int OrgDV)
        {
            try
            {
                return (GetOrganizationList(PCS.COMMON.DLL.DLLOrganization.GetOrganization(), OrgDV));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<ATTOrganization> GetOrganizationByID(int OrgID, int orgDV)
        {
            try
            {
                return GetOrganizationList(DLLOrganization.GetOrganizationByID(OrgID), orgDV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOrganization(ATTOrganization Obj)
        {
            try
            {
                return PCS.COMMON.DLL.DLLOrganization.SaveOrganization(Obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<ATTOrganization> GetOrgWithChilds(int orgID)
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            try
            {

                foreach (DataRow row in DLLOrganization.GetOrgWithChilds(orgID).Rows)
                {
                    ATTOrganization OrgObj = new ATTOrganization();
                    OrgObj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    OrgObj.OrgName = (string)row["ORG_NAME"];
                    OrgObj.OrgEquCode = ((row["ORG_EQU_CODE"] == System.DBNull.Value) ? 0 : int.Parse(row["ORG_EQU_CODE"].ToString()));
                    OrgObj.LSTOrgUnit = BLLOrganizationUnit.GetOrganizationUnits(OrgObj.OrgID, null);
                    lst.Add(OrgObj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganization> GetAllOrganization(int? orgID, string orgType, string orgEquCode)
        {
            List<ATTOrganization> lstOrg = new List<ATTOrganization>();
            try
            {
                foreach (DataRow row in DLLOrganization.GetAllOrganization(orgID, orgType, orgEquCode).Rows)
                {
                    ATTOrganization obj = new ATTOrganization();
                    obj.OrgSubType = row["ORG_SUB_TYPE"].ToString();
                    obj.OrgID = int.Parse(row["org_id"].ToString());
                    // obj.ParentId = int.Parse(row["PARENT_ID"].ToString());
                    obj.OrgType = row["org_type"].ToString();
                    obj.OrgName = row["ORG_NAME"].ToString();
                    //obj.OrgAddress = row["ORG_ADDRESS"].ToString();
                    //obj.OrgStreetName = row["ORG_STREET_NAME"].ToString();
                    //obj.OrgVdcMuni = int.Parse(row["ORG_VDC_MUNI"].ToString());
                    //obj.OrgUrl = row["ORG_URL"].ToString();
                    //obj.OrgWardNo = int.Parse(row["ORG_WARD_NO"].ToString());
                    //obj.OrgDistrict = int.Parse(row["ORG_DIST"].ToString());
                    obj.OrgEquCodes = row["ORG_EQU_CODE"].ToString();
                    lstOrg.Add(obj);


                }
                return lstOrg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
