using System;
using System.Data;
using System.Configuration;
using System.Web;
using Oracle.DataAccess.Client;

using PCS.LJMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LJMS.DLL
{
    public class DLLLawyerInfoSearch
    {
        public static DataTable GetLawyerInfoSearchTbl(ATTLawyerInfoSearch objLISrch)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.LJMS);

                string selectSQL = "SELECT * FROM VW_LAWYER_INFO WHERE 1=1 ";
                int i = 0;

                #region
                /*
                if (objLISrch.UNITID != null)
                    i++;
                if (objLISrch.LTYPEID != null)
                    i++;
                if (objLISrch.LGENDER != null)
                    i++;
                if (objLISrch.LICENSENO != null)
                    i++;
                if (objLISrch.FNAME != null)
                    i++;
                if (objLISrch.SURNAME != null)
                    i++;
                if (objLISrch.LRENEWALUPTO != null)
                    i++;
                if (objLISrch.PLRENEWALUPTO != null)
                    i++;
                if (objLISrch.PERSONID != null)
                    i++;
                if (objLISrch.LAWYERID != null)
                    i++;
                if (objLISrch.PLAWYERID != null)
                    i++;
                */
                # endregion

                if (objLISrch.FNAME != null)
                    i++;
                if(objLISrch.SURNAME != null)
                    i++;
                if (objLISrch.LICENSENO != null)
                    i++;
                if (objLISrch.LTYPEID != null)
                    i++;
                if (objLISrch.LRENEWALUPTO != null && objLISrch.LRENEWALUPTO != "")
                    i++;
                if (objLISrch.UNITID != null)
                    i++;
                if (objLISrch.PLRENEWALUPTO != null && objLISrch.PLRENEWALUPTO != "")
                    i++;
                if (objLISrch.TODATE != null && objLISrch.TODATE != "")
                    i++;


                OracleParameter[] ParamArray = new OracleParameter[i];
                int j = 0;

                if (objLISrch.FNAME != null)
                {
                    selectSQL = selectSQL + " AND first_name LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objLISrch.FNAME, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.SURNAME != null)
                {
                    selectSQL = selectSQL + " AND sur_name LIKE :SName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SName", objLISrch.SURNAME, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.LICENSENO != null)
                {
                    selectSQL = selectSQL + " AND license_no = :LicenseNo";
                    ParamArray[j] = Utilities.GetOraParam(":LicenseNo", objLISrch.LICENSENO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.LTYPEID != null)
                {
                    selectSQL = selectSQL + " AND lawyer_type_id=:LTypeID";
                    ParamArray[j] = Utilities.GetOraParam(":LTypeID", objLISrch.LTYPEID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }

                //if (objLISrch.LRENEWALUPTO != null && objLISrch.LRENEWALUPTO != "")
                //{
                //    selectSQL = selectSQL + " AND lawyer_last_ren_upto <= :LRenewalUpto";
                //    ParamArray[j] = Utilities.GetOraParam(":LRenewalUpto", objLISrch.LRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                //    j++;
                //}

                if (objLISrch.LRENEWALUPTO != null && objLISrch.LRENEWALUPTO != "")
                {
                    if(objLISrch.INRANGE.Trim() == "Y")
                        selectSQL = selectSQL + " AND lawyer_last_ren_upto between :LRenewalUpto AND :ToDate";
                    else
                        selectSQL = selectSQL + " AND lawyer_last_ren_upto not between :LRenewalUpto AND :ToDate";

                    ParamArray[j] = Utilities.GetOraParam(":LRenewalUpto", objLISrch.LRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                    ParamArray[j] = Utilities.GetOraParam(":ToDate", objLISrch.TODATE, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.UNITID != null)
                {
                    selectSQL = selectSQL + " AND unit_id=:UnitID";
                    ParamArray[j] = Utilities.GetOraParam(":UnitID", objLISrch.UNITID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }

                //if (objLISrch.PLRENEWALUPTO != null && objLISrch.PLRENEWALUPTO != "")
                //{
                //    selectSQL = selectSQL + " AND p_lawyer_last_ren_upto <= :PLRenewalUpto";
                //    ParamArray[j] = Utilities.GetOraParam(":PLRenewalUpto", objLISrch.PLRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                //    j++;
                //}

                if (objLISrch.PLRENEWALUPTO != null && objLISrch.PLRENEWALUPTO != "")
                {
                    if (objLISrch.INRANGE.Trim() == "Y")
                        selectSQL = selectSQL + " AND p_lawyer_last_ren_upto between :PLRenewalUpto AND :ToDate";
                    else
                        selectSQL = selectSQL + " AND p_lawyer_last_ren_upto not between :PLRenewalUpto AND :ToDate";
                    
                    ParamArray[j] = Utilities.GetOraParam(":PLRenewalUpto", objLISrch.PLRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                    ParamArray[j] = Utilities.GetOraParam(":ToDate", objLISrch.TODATE, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }


                #region
                /*

                if (objLISrch.UNITID != null)
                {
                    selectSQL = selectSQL + " AND UNIT_ID=:UnitID";
                    ParamArray[j] = Utilities.GetOraParam(":UnitID", objLISrch.UNITID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }
                if (objLISrch.LTYPEID != null)
                {
                    selectSQL = selectSQL + " AND LTYPE_ID=:LTypeID";
                    ParamArray[j] = Utilities.GetOraParam(":LTypeID", objLISrch.LTYPEID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }
                if (objLISrch.LGENDER != null)
                {
                    selectSQL = selectSQL + " AND L_GENDER=:Gender";
                    ParamArray[j] = Utilities.GetOraParam(":Gender", objLISrch.LGENDER, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }


                if (objLISrch.LICENSENO != null)
                {
                    selectSQL = selectSQL + " AND LICENSE_NO = :LicenseNo";
                    ParamArray[j] = Utilities.GetOraParam(":LicenseNo", objLISrch.LICENSENO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.FNAME != null)
                {
                    selectSQL = selectSQL + " AND FIRST_NAME LIKE :FName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":FName", objLISrch.FNAME, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.SURNAME != null)
                {
                    selectSQL = selectSQL + " AND SUR_NAME LIKE :SName||'%'";
                    ParamArray[j] = Utilities.GetOraParam(":SName", objLISrch.SURNAME, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.LRENEWALUPTO != null)
                {
                    selectSQL = selectSQL + " AND L_RENEWAL_UPTO <= :LRenewalUpto";
                    ParamArray[j] = Utilities.GetOraParam(":LRenewalUpto", objLISrch.LRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.PLRENEWALUPTO != null)
                {
                    selectSQL = selectSQL + " AND PL_RENEWAL_UPTO <= :PLRenewalUpto";
                    ParamArray[j] = Utilities.GetOraParam(":PLRenewalUpto", objLISrch.PLRENEWALUPTO, OracleDbType.Varchar2, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.PERSONID != null)
                {
                    selectSQL = selectSQL + " AND P_ID = :PID";
                    ParamArray[j] = Utilities.GetOraParam(":PID", objLISrch.PERSONID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.LAWYERID != null)
                {
                    selectSQL = selectSQL + " AND L_ID = :LID";
                    ParamArray[j] = Utilities.GetOraParam(":LID", objLISrch.LAWYERID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }

                if (objLISrch.PLAWYERID != null)
                {
                    selectSQL = selectSQL + " AND PL_ID = :PLID";
                    ParamArray[j] = Utilities.GetOraParam(":PLID", objLISrch.PLAWYERID, OracleDbType.Int16, ParameterDirection.Input);
                    j++;
                }
                  */

                #endregion

                selectSQL = selectSQL + " order by lawyer_type_id ";

                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL, ParamArray);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDuplicateLawyer(string SQL)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.LJMS);

                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SQL, null);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
