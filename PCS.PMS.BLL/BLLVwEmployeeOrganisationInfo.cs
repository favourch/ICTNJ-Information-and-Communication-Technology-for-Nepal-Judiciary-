using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLVwEmployeeOrganisationInfo
    {
        public static List<ATTVwEmployeeOrganisationInfo> GetEmployeeOrganisationInfoList(int? empID)
        {
            List<ATTVwEmployeeOrganisationInfo> lstEmpOrgInfoLst = new List<ATTVwEmployeeOrganisationInfo>();

            foreach (DataRow row in DLLVwEmployeeOrganisationInfo.GetEmployeeOrganisationInfoListTable(empID).Rows)
            {
                ATTVwEmployeeOrganisationInfo objEmpOrgInfo = new ATTVwEmployeeOrganisationInfo(
                                                                                                int.Parse(row["EMP_ID"].ToString()),
                                                                                                int.Parse(row["ORG_ID"].ToString()),
                                                                                                row["ORG_NAME"].ToString(),
                                                                                                row["FIRST_NAME"].ToString(),
                                                                                                row["MID_NAME"].ToString(),
                                                                                                row["SUR_NAME"].ToString(),
                                                                                                row["DES_NAME"].ToString(),
                                                                                                row["LEVEL_NAME"].ToString()
                                                                                               );
                                                                                         
                lstEmpOrgInfoLst.Add(objEmpOrgInfo);
            }
            return lstEmpOrgInfoLst;
           
        }
    }
}
