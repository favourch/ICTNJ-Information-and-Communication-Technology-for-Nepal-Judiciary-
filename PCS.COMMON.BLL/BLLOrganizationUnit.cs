using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLOrganizationUnit
    {
        public static ObjectValidation Validate(ATTOrganizationUnit ObjAtt)
        {
            ObjectValidation OV = new ObjectValidation();

            if (ObjAtt.UnitName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Unit Name cannot be Blank.";
                return OV;
            }
            return OV;
        }

        public static List<ATTOrganizationUnit> GetOrganizationUnits(int? orgID, int? unitID)
        {
            List<ATTOrganizationUnit> lstOrgUnits = new List<ATTOrganizationUnit>();
            try
            {
                foreach (DataRow row in DLLOrganizationUnit.GetOrganizationUnits(orgID, unitID).Rows)
                {
                    ATTOrganizationUnit objOrgUnits = new ATTOrganizationUnit(
                        int.Parse(row["ORG_ID"].ToString()), 
                        int.Parse(row["UNIT_ID"].ToString()),
                        (string)row["UNIT_NAME"]);
                    if (row["PARENT_ORG_ID"] != System.DBNull.Value)
                        objOrgUnits.ParentOrgID = int.Parse(row["PARENT_ORG_ID"].ToString());
                    if (row["PARENT_UNIT_ID"] != System.DBNull.Value)
                        objOrgUnits.ParentUnitID = int.Parse(row["PARENT_UNIT_ID"].ToString());
                    objOrgUnits.UnitType = (row["UNIT_TYPE"] == System.DBNull.Value) ? "" : (string)row["UNIT_TYPE"];
                    lstOrgUnits.Add(objOrgUnits);
                }
                return lstOrgUnits;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganizationUnit> GetUnitHead(int? orgid, int? unitid)
        {
            List<ATTOrganizationUnit> lstOrgUnitHead = new List<ATTOrganizationUnit>();
            try
            {
                foreach (DataRow row in DLLOrganizationUnit.GetOrganizationUnitHead(orgid, unitid).Rows)
                {
                    ATTOrganizationUnit objOrgUnitHead = new ATTOrganizationUnit();
                    objOrgUnitHead.OrgID = int.Parse(row["ORG_ID"].ToString());
                    if (row["ORG_UNIT_ID"] != System.DBNull.Value)
                        objOrgUnitHead.UnitID = int.Parse(row["ORG_UNIT_ID"].ToString());

                    objOrgUnitHead.UnitName = (string)row["UNIT_NAME"];

                    if (row["EMP_ID"] != System.DBNull.Value)
                        objOrgUnitHead.EmpID = int.Parse(row["EMP_ID"].ToString());

                    objOrgUnitHead.EmpName = row["HEAD_P_NAME"].ToString();

                    lstOrgUnitHead.Add(objOrgUnitHead);
                }
                return lstOrgUnitHead;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTOrganizationUnit> SrchOrganizationUnitHead(int? orgid, string searchValue)
        {
            List<ATTOrganizationUnit> lstOrgUnitHead = new List<ATTOrganizationUnit>();
            try
            {
                foreach (DataRow row in DLLOrganizationUnit.SrchOrganizationUnitHead(orgid,searchValue).Rows)
                {
                    ATTOrganizationUnit objOrgUnitHead = new ATTOrganizationUnit();
                    objOrgUnitHead.OrgID = int.Parse(row["ORG_ID"].ToString());
                    if (row["ORG_UNIT_ID"] != System.DBNull.Value)
                        objOrgUnitHead.UnitID = int.Parse(row["ORG_UNIT_ID"].ToString());

                    objOrgUnitHead.UnitName = (string)row["UNIT_NAME"];

                    if (row["EMP_ID"] != System.DBNull.Value)
                        objOrgUnitHead.EmpID = int.Parse(row["EMP_ID"].ToString());

                    objOrgUnitHead.EmpName = row["HEAD_P_NAME"].ToString();

                    lstOrgUnitHead.Add(objOrgUnitHead);
                }
                return lstOrgUnitHead;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganizationUnit> GetOrgUnitWithChild(int? orgid, int? unitid)
        {
            List<ATTOrganizationUnit> lstOrgUnit = new List<ATTOrganizationUnit>();
            try
            {
                foreach (DataRow row in DLLOrganizationUnit.GetOrgUnitWithChild(orgid, unitid).Rows)
                {
                    ATTOrganizationUnit objOrgUnit = new ATTOrganizationUnit();
                    objOrgUnit.OrgID = int.Parse(row["ORG_ID"].ToString());
                    if (row["PARENT_ORG_ID"] != System.DBNull.Value)
                        objOrgUnit.ParentOrgID = int.Parse(row["PARENT_ORG_ID"].ToString());
                    if (row["UNIT_ID"] != System.DBNull.Value)
                        objOrgUnit.UnitID = int.Parse(row["UNIT_ID"].ToString());
                    objOrgUnit.UnitName = (string)row["UNIT_NAME"];
                    if (row["UNIT_TYPE"] != System.DBNull.Value)
                        objOrgUnit.UnitType = (string)row["UNIT_TYPE"];
                    if (row["PARENT_UNIT_ID"] != System.DBNull.Value)
                        objOrgUnit.ParentUnitID = int.Parse(row["PARENT_UNIT_ID"].ToString());
                    lstOrgUnit.Add(objOrgUnit);
                }
                return lstOrgUnit;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveOrganizationUnit(List<ATTOrganizationUnit> ListOrgUnit)
        {
            try
            {
                DLLOrganizationUnit.SaveOrganizationUnit(ListOrgUnit);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganizationUnit> GetOrganizationUnits(string unitType, int orgID)
        {
            List<ATTOrganizationUnit> lstOrgUnits = new List<ATTOrganizationUnit>();
            try
            {
                DataTable tbl = new DataTable();
                tbl = DLLOrganizationUnit.GetOrganizationUnits(unitType, orgID);


                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganizationUnit objOrgUnits = new ATTOrganizationUnit(
                                                                                 int.Parse(row["ORG_ID"].ToString()),
                                                                                 int.Parse(row["UNIT_ID"].ToString()),
                                                                                 (string)row["UNIT_NAME"]
                                                                              );

                    //ORG_ID,UNIT_ID,UNIT_NAME,PARENT_ORG_ID,PARENT_UNIT_ID,UNIT_TYPE 

                    if (row["PARENT_ORG_ID"] != System.DBNull.Value)
                        objOrgUnits.ParentOrgID = int.Parse(row["PARENT_ORG_ID"].ToString());
                    if (row["PARENT_UNIT_ID"] != System.DBNull.Value)
                        objOrgUnits.ParentUnitID = int.Parse(row["PARENT_UNIT_ID"].ToString());

                    objOrgUnits.UnitType = row["UNIT_TYPE"].ToString();

                    lstOrgUnits.Add(objOrgUnits);
                }

                return lstOrgUnits;
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }


   }
}