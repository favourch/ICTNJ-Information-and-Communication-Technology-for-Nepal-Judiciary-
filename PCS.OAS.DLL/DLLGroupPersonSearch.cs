using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
namespace PCS.OAS.DLL
{
    public class DLLGroupPersonSearch
    {
        public static DataTable GetEmployeeFromWorkDistribution(ATTGroupPersonSearch person, string applicationlst)
        {
            string tbl = "VW_EMP_WORK_DISTRIBUTION";

            if (person.GroupID > 0 || person.GMPositionID > 0)
            {
                tbl = "VW_GROUP_MEMBER_INFO";
            }

            string SQL = "select * from " + tbl + " WHERE 1 = 1";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (person.FirstName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(FIRST_NAME) LIKE :FName||'%'";
                paramArray.Add(Utilities.GetOraParam(":FName", person.FirstName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MiddleName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(MID_NAME) LIKE :MName||'%'";
                paramArray.Add(Utilities.GetOraParam(":MName", person.MiddleName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.SurName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(SUR_NAME) LIKE :SName||'%'";
                paramArray.Add(Utilities.GetOraParam(":SName", person.SurName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.Gender != "")
            {
                SQL = SQL + " AND GENDER= :Gender";
                paramArray.Add(Utilities.GetOraParam(":Gender", person.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.DOB != "")
            {
                SQL = SQL + " AND DOB= :DOBX";
                paramArray.Add(Utilities.GetOraParam(":DOBX", person.DOB, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MaritalStatus != "")
            {
                SQL = SQL + " AND MARTIAL_STATUS= :MStatus";
                paramArray.Add(Utilities.GetOraParam(":MStatus", person.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.IniType != "")
            {
                SQL = SQL + " AND ORG_ID= :ORGID";
                paramArray.Add(Utilities.GetOraParam(":ORGID", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.UnitID > 0)
            {
                SQL = SQL + " AND ORG_UNIT_ID= :UNITID";
                paramArray.Add(Utilities.GetOraParam(":UNITID", person.UnitID, OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.PostName != "")
            {
                SQL = SQL + " AND DES_ID= :DES_ID";
                paramArray.Add(Utilities.GetOraParam(":DES_ID", int.Parse(person.PostName), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GroupID > 0)
            {
                SQL = SQL + " AND G_ORG_ID=:gorg_id AND GROUP_ID=:GRP_ID";
                paramArray.Add(Utilities.GetOraParam(":gorg_id", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":GRP_ID", person.GroupID, OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GMPositionID > 0)
            {
                SQL = SQL + " AND POSITION_ID=:pos_id";
                paramArray.Add(Utilities.GetOraParam(":pos_id", person.GMPositionID, OracleDbType.Int32, ParameterDirection.Input));
            }

            SQL = SQL + " AND org_unit_id is not null";
            //SQL = SQL + " AND INI_TYPE IN (" + applicationlst + ")";

            SQL = SQL + " order by emp_id";

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetGroupPersonWithEmployee(ATTGroupPersonSearch person, string applicationlst)
        {
            string tbl = "VW_EMPLOYEE_WITH_POSTING";

            if (person.GroupID > 0 || person.GMPositionID > 0)
            {
                tbl = "VW_GROUP_MEMBER_INFO";
            }

            string SQL = "select * from " + tbl + " WHERE 1 = 1";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (person.FirstName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(FIRST_NAME) LIKE :FName||'%'";
                paramArray.Add(Utilities.GetOraParam(":FName", person.FirstName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MiddleName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(MID_NAME) LIKE :MName||'%'";
                paramArray.Add(Utilities.GetOraParam(":MName", person.MiddleName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.SurName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(SUR_NAME) LIKE :SName||'%'";
                paramArray.Add(Utilities.GetOraParam(":SName", person.SurName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.Gender != "")
            {
                SQL = SQL + " AND GENDER= :Gender";
                paramArray.Add(Utilities.GetOraParam(":Gender", person.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.DOB != "")
            {
                SQL = SQL + " AND DOB= :DOBX";
                paramArray.Add(Utilities.GetOraParam(":DOBX", person.DOB, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MaritalStatus != "")
            {
                SQL = SQL + " AND MARTIAL_STATUS= :MStatus";
                paramArray.Add(Utilities.GetOraParam(":MStatus", person.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.IniType != "")
            {
                SQL = SQL + " AND ORG_ID= :ORGID";
                paramArray.Add(Utilities.GetOraParam(":ORGID", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.PostName != "")
            {
                SQL = SQL + " AND DES_ID= :DES_ID";
                paramArray.Add(Utilities.GetOraParam(":DES_ID", int.Parse(person.PostName), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GroupID > 0)
            {
                SQL = SQL + " AND G_ORG_ID=:gorg_id AND GROUP_ID=:GRP_ID";
                paramArray.Add(Utilities.GetOraParam(":gorg_id", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":GRP_ID", person.GroupID, OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GMPositionID > 0)
            {
                SQL = SQL + " AND POSITION_ID=:pos_id";
                paramArray.Add(Utilities.GetOraParam(":pos_id", person.GMPositionID, OracleDbType.Int32, ParameterDirection.Input));
            }

            SQL = SQL + " AND INI_TYPE IN (" + applicationlst + ")";

            SQL = SQL + " order by p_id";

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeeWithPosting(ATTGroupPersonSearch person, string applicationlst)
        {
            string tbl = "VW_EMPLOYEE_WITH_POSTING";

            if (person.GroupID > 0 || person.GMPositionID > 0)
            {
                tbl = "VW_GROUP_MEMBER_INFO";
            }

            string SQL = "select * from " + tbl + " WHERE 1 = 1";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (person.SymbolNo != "")
            {
                SQL = SQL + " AND symbol_no = :symbolno";
                paramArray.Add(Utilities.GetOraParam(":symbolno", person.SymbolNo, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.FirstName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(FIRST_NAME) LIKE :FName||'%'";
                paramArray.Add(Utilities.GetOraParam(":FName", person.FirstName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MiddleName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(MID_NAME) LIKE :MName||'%'";
                paramArray.Add(Utilities.GetOraParam(":MName", person.MiddleName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.SurName.Trim() != "")
            {
                SQL = SQL + " AND UPPER(SUR_NAME) LIKE :SName||'%'";
                paramArray.Add(Utilities.GetOraParam(":SName", person.SurName.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.Gender != "")
            {
                SQL = SQL + " AND GENDER= :Gender";
                paramArray.Add(Utilities.GetOraParam(":Gender", person.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.DOB != "")
            {
                SQL = SQL + " AND DOB= :DOBX";
                paramArray.Add(Utilities.GetOraParam(":DOBX", person.DOB, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.MaritalStatus != "")
            {
                SQL = SQL + " AND MARTIAL_STATUS= :MStatus";
                paramArray.Add(Utilities.GetOraParam(":MStatus", person.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (person.IniType != "")
            {
                SQL = SQL + " AND ORG_ID= :ORGID";
                paramArray.Add(Utilities.GetOraParam(":ORGID", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.PostName != "")
            {
                SQL = SQL + " AND DES_ID= :DES_ID";
                paramArray.Add(Utilities.GetOraParam(":DES_ID", int.Parse(person.PostName), OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GroupID > 0)
            {
                SQL = SQL + " AND G_ORG_ID=:gorg_id AND GROUP_ID=:GRP_ID";
                paramArray.Add(Utilities.GetOraParam(":gorg_id", int.Parse(person.IniType), OracleDbType.Int32, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":GRP_ID", person.GroupID, OracleDbType.Int32, ParameterDirection.Input));
            }

            if (person.GMPositionID > 0)
            {
                SQL = SQL + " AND POSITION_ID=:pos_id";
                paramArray.Add(Utilities.GetOraParam(":pos_id", person.GMPositionID, OracleDbType.Int32, ParameterDirection.Input));
            }

            SQL = SQL + " AND INI_TYPE IN (" + applicationlst + ")";

            SQL = SQL + " order by p_id";

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
