using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LIS.DLL
{
    public class DLLLibraryMaterialAuthor
    {
        public static DataTable GetLibraryMaterialAuthorTable(int orgID, int libraryID, decimal lMaterialID)
        {
            string SelectSQL = "SELECT * FROM VW_LM_AUTHOR WHERE ORG_ID=:ORGID AND LIBRARY_ID=:LIBRARYID AND L_MATERIAL_ID=:LMATERIALID";

            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":ORGID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":LIBRARYID", libraryID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":LMATERIALID", lMaterialID, OracleDbType.Decimal, ParameterDirection.Input);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SelectSQL,Module.LIS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool AddLibraryMaterialAuthor(List<ATTLibraryMaterialAuthor> lstAuthor, long lMaterialID, OracleTransaction tran)
        {
            string InsertSP;
            InsertSP = "";

            try
            {
                foreach (ATTLibraryMaterialAuthor obj in lstAuthor)
                {
                    OracleParameter[] paramArray = new OracleParameter[1];
                    if (obj.Action == "A")
                    {
                        InsertSP = "SP_ADD_LM_AUTHOR";
                        paramArray = new OracleParameter[5];
                        paramArray[4] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    }
                    else if (obj.Action == "D")
                    {
                        InsertSP = "SP_DEL_LM_AUTHOR";
                        paramArray = new OracleParameter[4];
                    }

                    if (obj.Action != "N")
                    {
                        paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":p_L_MATERIAL_ID", lMaterialID, OracleDbType.Long, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":p_AUTHOR_ID", obj.AuthorID, OracleDbType.Int64, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertSP, paramArray);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable SearchMaterialTable(int langID, int[] checkedAuthors, int[] checkedKeywords)
        {
            GetConnection GetConn = new GetConnection();
            try
            {
                string SearchSQL = "";
                SearchSQL = QueryBuilder(langID, checkedAuthors, checkedKeywords);

                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SearchSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];

                return tbl;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static string QueryBuilder(int langID, int[] checkedAuthors, int[] checkedKeywords)
        {
            try
            {
                string SearchSQL = "";
                string AuthorSQL = "";
                string KeywordSQL = "";

                if (checkedAuthors != null)
                {
                    AuthorSQL = GetAuthorQuery(checkedAuthors);
                }

                if (checkedKeywords != null)
                {
                    KeywordSQL = GetKeywordQuery(checkedKeywords);
                }

                SearchSQL = GetFinalQuery(langID, AuthorSQL, KeywordSQL);

                return SearchSQL;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string GetFinalQuery(int langID, string AuthorSQL, string KeywordSQL)
        {
            try
            {
                string FinalSQL = "";
                //string GeneralSQL = "  SELECT Distinct VWL.l_material_id, VWL.org_id,VWL.library_id,VWL.LIBRARY_NAME,VWL.category_name,VWL.m_cat_desc,VWL.price,VWL.edition,VWL.lang_name,VWL.currency_name FROM VW_LIBRARY_INFO VWL";

                string GeneralSQL = "  SELECT Distinct VWL.l_material_id, VWL.org_id,VWL.library_id,VWL.LIBRARY_NAME,VWL.category_name,"
                                   + " VWL.m_cat_desc,VWL.lang_name,VWL.call_no,VWL.corporate_body,VWL.publisher_name FROM VW_LIBRARY_INFO VWL";
                
                string FlexibleSQL = "";

                if ((AuthorSQL != "") && (KeywordSQL != ""))
                {
                    FlexibleSQL = "SELECT KY.ORG_ID,KY.LIBRARY_ID,KY.KEYWORD_ID,KY.l_material_id FROM " + KeywordSQL + "," + AuthorSQL + " WHERE KY.ORG_ID=AU.ORG_ID";
                    FinalSQL = GeneralSQL + ",(" + FlexibleSQL + ")FNL ";
                    FinalSQL = FinalSQL + " WHERE VWL.ORG_ID=FNL.ORG_ID AND VWL.LIBRARY_ID=FNL.LIBRARY_ID AND VWL.l_material_id=FNL.l_material_id  ";

                }
                else if ((AuthorSQL != "") && (KeywordSQL == ""))
                {
                    FlexibleSQL = KeywordSQL;
                    FinalSQL = GeneralSQL + "," + AuthorSQL;
                    FinalSQL = FinalSQL + " WHERE AU.ORG_ID=VWL.ORG_ID ";

                }
                else if ((AuthorSQL == "") && (KeywordSQL != ""))
                {
                    FlexibleSQL = KeywordSQL;
                    FinalSQL = GeneralSQL + "," + FlexibleSQL;
                    FinalSQL = FinalSQL + " WHERE KY.ORG_ID=VWL.ORG_ID ";
                }
                else
                {
                    FinalSQL = GeneralSQL;
                }

                if (langID != 0)
                {
                    if ((AuthorSQL != "") || (KeywordSQL != ""))
                        FinalSQL = FinalSQL + " AND VWL.lang_ID = " + langID;
                    else
                        FinalSQL = FinalSQL + " WHERE VWL.lang_ID = " + langID;

                }
                FinalSQL = FinalSQL + " ORDER BY VWL.category_name ";

                return FinalSQL;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string GetAuthorQuery(int[] checkedAuthors)
        {
            try
            {
                string AuthorSQL = "";
                AuthorSQL = "(SELECT * FROM vw_lm_author ";
                AuthorSQL = AuthorSQL + " WHERE AUTHOR_ID IN " + GetCheckedAuthorList(checkedAuthors) + ") AU";
                return AuthorSQL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string GetKeywordQuery(int[] checkedKeywords)
        {
            try
            {
                string KeywordSQL = "";
                KeywordSQL = "(SELECT * FROM VW_LM_KEYWORD ";
                KeywordSQL = KeywordSQL + " WHERE KEYWORD_ID IN " + GetCheckedKeywordList(checkedKeywords) + ") KY ";
                return KeywordSQL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string GetCheckedAuthorList(int[] checkedAuthors)
        {
            try
            {
                string checkedAuthorsList = "";

                for (int i = 0; i < checkedAuthors.Length; i++)
                {
                    if (checkedAuthors[i] != 0)
                    {
                        checkedAuthorsList = checkedAuthorsList + checkedAuthors[i] + ",";
                    }
                }

                return " (" + (checkedAuthorsList.Substring(0, checkedAuthorsList.Length - 1)) + ") ";

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string GetCheckedKeywordList(int[] checkedKeywords)
        {
            try
            {
                string checkedKeywordsList = "";

                for (int j = 0; j < checkedKeywords.Length; j++)
                {
                    if (checkedKeywords[j] != 0)
                    {
                        checkedKeywordsList = checkedKeywordsList + checkedKeywords[j] + ",";
                    }
                }

                return " (" + (checkedKeywordsList.Substring(0, checkedKeywordsList.Length - 1)) + ")";

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
    }
}
