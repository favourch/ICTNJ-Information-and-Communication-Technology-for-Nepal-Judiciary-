using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;
using PCS.COMMON;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeWorkDivision
    {
        public static bool SaveEmpWorkDivision(List<ATTEmployeeWorkDivision> LSTEmpWorkDiv)
        {
            try
            {
                return DLLEmployeeWorkDivision.SaveEmpWorkDivision(LSTEmpWorkDiv);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static List<ATTEmployeeWorkDivision> SearchEmployee(ATTEmployeeWorkDivision objEmpDiv)
        {
            try
            {
                List<ATTEmployeeWorkDivision> LSTWrkDiv = new List<ATTEmployeeWorkDivision>();
                foreach (DataRow row in DLLEmployeeWorkDivision.SearchEmployee(objEmpDiv).Rows)
                {
                    ATTEmployeeWorkDivision obj = new ATTEmployeeWorkDivision();
                    obj.EmpID = int.Parse(row["EMP_ID"].ToString());
                    string first_name = row["FIRST_NAME"].ToString();
                    string mid_name=row["MID_NAME"].ToString();
                    string sur_name = row["SUR_NAME"].ToString();
                    if (mid_name != "")
                    {
                        obj.FullName = first_name + " " + mid_name + " " + sur_name;
                    }
                    else
                    {
                        obj.FullName = first_name + " " + sur_name;
                    }
                    //obj.OrgEmpNo = int.Parse(row["ORG_EMP_NO"].ToString());
                    obj.Gender = row["GENDER"].ToString();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.DesID = int.Parse(row["DES_ID"].ToString());
                    obj.DesName = row["DES_NAME"].ToString();
                    obj.DesType = row["DES_TYPE"].ToString();
                    obj.CreatedDate = row["CREATED_DATE"].ToString();
                    obj.PostID = int.Parse(row["POST_ID"].ToString());
                    obj.FromDate = row["FROM_DATE"].ToString();
                    if (row["ORG_UNIT_ID"] != System.DBNull.Value)
                    {
                         obj.OrgUnitID = int.Parse(row["ORG_UNIT_ID"].ToString());
                    }
                    obj.UnitName = row["UNIT_NAME"].ToString();
                    obj.UnitType = row["UNIT_TYPE"].ToString();
                    //if (row["SECTION_ID"]!= System.DBNull.Value)
                    //{
                    //    obj.SectionID = int.Parse(row["SECTION_ID"].ToString());
                    //}
                    //obj.SectionName=row["SECTION_NAME"].ToString();
                    obj.UnitFromDate = row["UNIT_FROM_DATE"].ToString();
                    obj.ToDate=row["TO_DATE"].ToString();
                    obj.Responsibility = row["RESPONSIBILITY"].ToString();
                    obj.IsHeadOfUnit = row["UNIT_HEAD"].ToString();
                    obj.Action = "";
                    LSTWrkDiv.Add(obj);
                }
                return LSTWrkDiv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
    }
}
