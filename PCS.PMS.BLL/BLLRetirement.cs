using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLRetirement
    {
        public static bool SaveEmpRetirement(List<ATTRetirement> LSTRet)
        {
            try
            {
                return DLLRetirement.SaveEmpRetirement(LSTRet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<ATTRetirement> SearchEmployee(ATTRetirement objEmpRet)
        {
            try
            {
                List<ATTRetirement> LSTEmpRet = new List<ATTRetirement>();
                foreach (DataRow row in DLLRetirement.SearchEmployee(objEmpRet).Rows)
                {
                    ATTRetirement obj = new ATTRetirement();
                    obj.empID = int.Parse(row["P_ID"].ToString());
                    string first_name = row["FIRST_NAME"].ToString();
                    string mid_name = row["MID_NAME"].ToString();
                    string sur_name = row["SUR_NAME"].ToString();
                    if (mid_name != "")
                    {
                        obj.fullName = first_name + " " + mid_name + " " + sur_name;
                    }
                    else
                    {
                        obj.fullName = first_name + " " + sur_name;
                    }
                    //obj.OrgEmpNo = int.Parse(row["ORG_EMP_NO"].ToString());
                    obj.gender = row["GENDER"].ToString();
                    obj.orgID = int.Parse(row["ORG_ID"].ToString());
                    obj.orgName = row["ORG_NAME"].ToString();
                    obj.desID = int.Parse(row["DES_ID"].ToString());
                    obj.desName = row["DES_NAME"].ToString();
                    obj.desType = row["DES_TYPE"].ToString();
                    obj.createdDate = row["CREATED_DATE"].ToString();
                    obj.postID = int.Parse(row["POST_ID"].ToString());
                    obj.fromDate = row["POST_FROM_DATE"].ToString();
                    obj.action = "";
                    LSTEmpRet.Add(obj);
                }
                return LSTEmpRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ATTRetirement> GetEmployeeRetirement(ATTRetirement objRetirement, string opt)
        {
            List<ATTRetirement> LST = new List<ATTRetirement>();
            try
            {
                if (opt == "appl")
                {
                    foreach (DataRow row in DLLRetirement.GetEmployeeRetirement(objRetirement,opt).Rows)
                    {
                        ATTRetirement objEmpRet = new ATTRetirement();
                        objEmpRet.empID = int.Parse(row["EMP_ID"].ToString());
                        objEmpRet.orgID = int.Parse(row["ORG_ID"].ToString());
                        objEmpRet.postID = int.Parse(row["POST_ID"].ToString());
                        objEmpRet.desID = int.Parse(row["DES_ID"].ToString());
                        objEmpRet.createdDate = row["CREATED_DATE"].ToString();
                        objEmpRet.fromDate = row["FROM_DATE"].ToString();
                        objEmpRet.fullName = row["EMP_NAME"].ToString();
                        objEmpRet.gender = row["GENDER"].ToString();
                        objEmpRet.retirementDate = row["RETIREMENT_DATE"].ToString();
                        objEmpRet.isSelf = row["IS_SELF"].ToString();
                        objEmpRet.retirementType = row["RETIREMENT_TYPE"].ToString();
                        objEmpRet.ApplDesc = row["APP_DESC"].ToString();
                        objEmpRet.isDecided = row["IS_DECIDED"].ToString();
                        objEmpRet.isApproved = row["IS_APPROVED"].ToString();
                        LST.Add(objEmpRet);
                    }
                }
                else if (opt == "dec")
                {
                    foreach (DataRow row in DLLRetirement.GetEmployeeRetirement(objRetirement, opt).Rows)
                    {
                        ATTRetirement objEmpRet = new ATTRetirement();
                        objEmpRet.empID = int.Parse(row["EMP_ID"].ToString());
                        objEmpRet.orgID = int.Parse(row["ORG_ID"].ToString());
                        objEmpRet.postID = int.Parse(row["POST_ID"].ToString());
                        objEmpRet.desID = int.Parse(row["DES_ID"].ToString());
                        objEmpRet.createdDate = row["CREATED_DATE"].ToString();
                        objEmpRet.fromDate = row["FROM_DATE"].ToString();
                        objEmpRet.fullName = row["EMP_NAME"].ToString();
                        objEmpRet.gender = row["GENDER"].ToString();
                        objEmpRet.retirementDate = row["RETIREMENT_DATE"].ToString();
                        objEmpRet.isSelf = row["IS_SELF"].ToString();
                        objEmpRet.retirementType = row["RETIREMENT_TYPE"].ToString();
                        objEmpRet.ApplDesc = row["APP_DESC"].ToString();
                        objEmpRet.decisionDate = row["DECISION_DATE"].ToString();
                        if (row["DECISION_BY"] != System.DBNull.Value)
                        {
                            objEmpRet.decisionBy = int.Parse(row["DECISION_BY"].ToString());
                        }
                        objEmpRet.decPerson = row["DECISION_PERSON"].ToString();
                        objEmpRet.decisionDesc = row["DECISION_DESC"].ToString();
                        objEmpRet.isDecided = row["IS_DECIDED"].ToString();
                        objEmpRet.isApproved = row["IS_APPROVED"].ToString();
                        LST.Add(objEmpRet);
                    }
                }
                else if (opt == "appr")
                {
                    foreach (DataRow row in DLLRetirement.GetEmployeeRetirement(objRetirement, opt).Rows)
                    {
                        ATTRetirement objEmpRet = new ATTRetirement();
                        objEmpRet.empID = int.Parse(row["EMP_ID"].ToString());
                        objEmpRet.orgID = int.Parse(row["ORG_ID"].ToString());
                        objEmpRet.postID = int.Parse(row["POST_ID"].ToString());
                        objEmpRet.createdDate = row["CREATED_DATE"].ToString();
                        objEmpRet.fromDate = row["FROM_DATE"].ToString();
                        objEmpRet.fullName = row["EMP_NAME"].ToString();
                        objEmpRet.gender = row["GENDER"].ToString();
                        objEmpRet.retirementDate = row["RETIREMENT_DATE"].ToString();
                        objEmpRet.isSelf = row["IS_SELF"].ToString();
                        objEmpRet.retirementType = row["RETIREMENT_TYPE"].ToString();
                        objEmpRet.ApplDesc = row["APP_DESC"].ToString();
                        objEmpRet.decisionDate = row["DECISION_DATE"].ToString();
                        objEmpRet.decisionBy = int.Parse(row["DECISION_BY"].ToString());
                        objEmpRet.decPerson = row["DECISION_PERSON"].ToString();
                        objEmpRet.decisionDesc = row["DECISION_DESC"].ToString();
                        objEmpRet.appDate = row["APP_DATE"].ToString();
                        if (row["APP_BY"] != System.DBNull.Value)
                        {
                            objEmpRet.appBy = int.Parse(row["APP_BY"].ToString());
                        }
                        objEmpRet.apprPerson = row["APP_PERSON"].ToString();
                        objEmpRet.appDesc = row["APP_DESC"].ToString();
                        objEmpRet.isDecided = row["IS_DECIDED"].ToString();
                        objEmpRet.isApproved = row["IS_APPROVED"].ToString();
                        LST.Add(objEmpRet);
                    }
                }
                return LST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
