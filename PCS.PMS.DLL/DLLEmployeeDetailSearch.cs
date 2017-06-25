using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeDetailSearch
    {
        public static DataTable DetailSearchEmployee(ATTEmployeeDetailSearch objEmployee)
        {
            try
            {
                string strSelectSQL = "";

                string tableName1 = "";
                string colName1 = "";
                string where1 = "";

                string tableName2 = "";
                string colName2 = "";
                string where2 = "";

                string tableName3 = "";
                string colName3 = "";
                string where3 = "";


                //if (objEmployee.Training != "")
                //{
                    tableName1 = ",TRAINING T";
                    colName1 = ",T.SEQ_NO as sub_id, T.subject";
                    where1 = " AND VW.EMP_ID=T.P_ID(+)";
                //}

                //if (objEmployee.QualificationList.Count > 0)
                //{
                    tableName2 = ",QUALIFICATION Q, DEGREE D";
                    colName2 = ",Q.SEQ_NO AS DEG_ID,D.DEGREE_NAME";
                    where2 = " AND VW.EMP_ID=Q.P_ID(+) AND Q.DEGREE_ID=D.DEGREE_ID(+)";
                //}

                //if (objEmployee.VisitList.Count > 0)
                //{
                    tableName3 = ",EMP_VISIT V,COUNTRY C";
                    colName3 = ",C.COUNTRY_ENG_NAME ,V.PURPOSE,V.FROM_DATE \"v_from_date\",V.TO_DATE, V.SEQ_NO AS COUNTRY_ID ";
                    where3 = " AND VW.EMP_ID=V.EMP_ID(+) AND V.COUNTRY=C.COUNTRY_ID(+)";
                //}

                    strSelectSQL = "SELECT VW.*,fn_add_years(VW.\"P_FROM_DATE\"," + objEmployee.RetirementYear + ") as retirement_date" + colName1 + colName2 + colName3 + " FROM VW_EMP_POSTING VW" + tableName1 + tableName2 + tableName3 + " WHERE 1=1" + where1 + where2 + where3;

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objEmployee.OrgID != null)
                {
                    strSelectSQL += " AND VW.ORG_ID=:ORGID";
                    paramArray.Add(new OracleParameter(":ORGID", objEmployee.OrgID));
                }

                if (objEmployee.FirstName != "")
                {
                    strSelectSQL += " AND upper(VW.FIRST_NAME) LIKE :FName||'%'";
                    paramArray.Add(new OracleParameter(":FName", objEmployee.FirstName.ToUpper()));
                }
                if (objEmployee.MiddleName != "")
                {
                    strSelectSQL += " AND upper(VW.MID_NAME) LIKE :MName||'%'";
                    paramArray.Add(new OracleParameter(":MName", objEmployee.MiddleName.ToUpper()));
                }

                if (objEmployee.SurName != "")
                {
                    strSelectSQL += " AND upper(VW.SUR_NAME) LIKE :SurName||'%'";
                    paramArray.Add(new OracleParameter(":SurName", objEmployee.SurName.ToUpper()));
                }

                if (objEmployee.SewaID != null)
                {
                    strSelectSQL += " AND VW.SEWA_ID =:SEWAID";
                    paramArray.Add(new OracleParameter(":SEWAID", objEmployee.SewaID));
                }

                if (objEmployee.SamuhaID != null)
                {
                    strSelectSQL += " AND VW.samuha_ID =:samuhaID";
                    paramArray.Add(new OracleParameter(":samuhaID", objEmployee.SamuhaID));
                }

                if (objEmployee.UpaSamuhaID != null)
                {
                    strSelectSQL += " AND VW.upa_samuha_ID =:upasamuhaID";
                    paramArray.Add(new OracleParameter(":upasamuhaID", objEmployee.UpaSamuhaID));
                }

                if (objEmployee.PostID != null)
                {
                    strSelectSQL += " AND VW.des_ID =:desID";
                    paramArray.Add(new OracleParameter(":desID", objEmployee.PostID));
                }

                if (objEmployee.LevelID != null)
                {
                    strSelectSQL += " AND VW.level_ID =:levelID";
                    paramArray.Add(new OracleParameter(":levelID", objEmployee.LevelID));
                }

                if (objEmployee.PostingTypeID != null)
                {
                    strSelectSQL += " AND VW.posting_type_id =:ptID";
                    paramArray.Add(new OracleParameter(":ptID", objEmployee.LevelID));
                }

                if (objEmployee.Gender != "")
                {
                    strSelectSQL += " AND VW.GENDER = :Gender";
                    paramArray.Add(new OracleParameter(":Gender", objEmployee.Gender));
                }

                if (objEmployee.DistrictID != null)
                {
                    strSelectSQL += " AND VW.birth_district = :distID";
                    paramArray.Add(new OracleParameter(":distID", objEmployee.DistrictID));
                }

                if (objEmployee.Training != "")
                {
                    strSelectSQL += " AND upper(T.subject) LIKE :subjectx||'%'";
                    paramArray.Add(new OracleParameter(":subjectx", objEmployee.Training.ToUpper()));
                }

                if (objEmployee.RetirementDate != "")
                {
                    strSelectSQL += " AND VW.\"P_FROM_DATE\"" + objEmployee.RetirementDateOperator + "fn_add_years(:rDate, -" + objEmployee.RetirementYear + ")";
                    paramArray.Add(new OracleParameter(":rDate", objEmployee.RetirementDate.Replace("/",".")));
                }

                if (objEmployee.QualificationList != null)
                if (objEmployee.QualificationList.Count > 0)
                {
                    strSelectSQL += " AND Q.DEGREE_ID in(" + DLLEmployeeDetailSearch.GetWhereInQueryString(objEmployee.QualificationList) + ")";
                }

                if (objEmployee.VisitList != null)
                if (objEmployee.VisitList.Count > 0)
                {
                    strSelectSQL += " AND V.COUNTRY in(" + DLLEmployeeDetailSearch.GetWhereInQueryString(objEmployee.VisitList) + ")";
                }

                strSelectSQL += " ORDER BY vw.emp_id, t.SEQ_NO , q.SEQ_NO , v.SEQ_NO";

                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.Text, strSelectSQL, Module.PMS, paramArray.ToArray()).Tables[0];
                return tbl;

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        static string GetWhereInQueryString(List<int> lst)
        {
            string Query = "";

            foreach (int i in lst)
            {
                Query = Query + i.ToString() + ", ";
            }

            if (Query.Length>0)
                Query = Query.Substring(0, Query.Length - 2);
            
            return Query;
        }

        public static DataTable PropertyReportSearch(ATTEmployeeDetailSearch objRptSearch)
        {
            GetConnection GetConn = new GetConnection();
            try
            {
                string SearchSQL = "";
                SearchSQL = QueryBuilder(objRptSearch);

                OracleConnection DBConn = GetConn.GetDbConn(Module.PMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SearchSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];

                return tbl;

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static string QueryBuilder(ATTEmployeeDetailSearch objEmployee)
        {
            try
            {
                string selectSQL = "";
                selectSQL = "SELECT A.*,B.LEVEL_NAME,B.DES_NAME,B.ORG_NAME,B.POSTING_TYPE_NAME ";
                selectSQL += "FROM VW_EMPLOYEES A,VW_EMP_POSTING B WHERE 1=1 ";

                if (objEmployee.OrgID != null)
                {
                    selectSQL += " AND B.ORG_ID=" + objEmployee.OrgID;
                }

                if (objEmployee.FirstName != "")
                {
                    selectSQL += " AND upper(A.FIRST_NAME) LIKE '"+ objEmployee.FirstName +"' || '%'";
                }

                if (objEmployee.MiddleName != "")
                {
                    selectSQL += " AND upper(A.MID_NAME) LIKE '" + objEmployee.MiddleName + "' || '%'";
                }

                if (objEmployee.SurName != "")
                {
                    selectSQL += " AND upper(A.SUR_NAME) LIKE '" + objEmployee.SurName + "' || '%'";
                }

                if (objEmployee.PostID != null)
                {
                    selectSQL += " AND B.des_ID =" + objEmployee.PostID;
                }

                if (objEmployee.LevelID != null)
                {
                    selectSQL += " AND B.level_ID =" + objEmployee.LevelID;
                }

                //selectSQL += " AND A.EMP_ID=B.EMP_ID(+)";
                selectSQL += " AND A.EMP_ID=B.EMP_ID";

                

                return selectSQL;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
