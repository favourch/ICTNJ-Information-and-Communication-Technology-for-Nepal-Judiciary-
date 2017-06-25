using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLOrgUnitHead
    {
        public static bool SaveOrgUnitHead(ATTOrgUnitHead att)
        {
            try
            {
                return DLLOrgUnitHead.SaveOrgUnitHead(att);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrgUnitHead> SearchEmployee(ATTOrgUnitHead objOrgUnitHead)
        {
            List<ATTOrgUnitHead> lstOUH = new List<ATTOrgUnitHead>();
            ATTOrgUnitHead attOUH;
            foreach (DataRow row in DLLOrgUnitHead.SearchEmployee(objOrgUnitHead).Rows)
            {
                attOUH = new ATTOrgUnitHead();
                attOUH.OrgID = int.Parse(row["ORG_ID"].ToString());
                attOUH.UnitID = int.Parse(row["UNIT_ID"].ToString());
                attOUH.UnitName = row["UNIT_NAME"].ToString();
                attOUH.EmpID = int.Parse(row["EMP_ID"].ToString());
                attOUH.EmpName = row["FIRST_NAME"].ToString() + " " + row["MID_NAME"].ToString() + "" + row["SUR_NAME"].ToString();
                attOUH.FromDate = row["FROM_DATE"].ToString();
                attOUH.ToDate = row["TO_DATE"].ToString();
                attOUH.UnitHead = row["UNIT_HEAD"].ToString();
                attOUH.OfficeHead = row["OFFICE_HEAD"].ToString();
                lstOUH.Add(attOUH);
            }
            return lstOUH;
        }
    }
}
