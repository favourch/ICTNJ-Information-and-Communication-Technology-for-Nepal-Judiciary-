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
    public class DLLLibraryMaterial
    {
        public static object GetLMAttachmentFile(int orgID, int libraryID, decimal lMaterialID)
        {
            string SelectSQL = "SP_GET_LM_CONTENTFILE";

            OracleParameter[] paramArray = new OracleParameter[4];
            
            paramArray[0] = Utilities.GetOraParam(":ORGID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":LIBRARYID", libraryID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":LMATERIALID", lMaterialID, OracleDbType.Decimal, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                return SqlHelper.ExecuteScalar(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
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

        public static long AddLibraryMaterial(ATTLibraryMaterial obj,Previlege pobj)
        {
           
                string InsertSP;
                OracleParameter[] paramArray;
                if (obj.Action == "A")
                {
                    InsertSP = "SP_ADD_LIBRARY_MATERIAL";
                    paramArray = new OracleParameter[18];
                    paramArray[17] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                }
                else
                {
                    InsertSP = "SP_EDIT_LIBRARY_MATERIAL";
                    paramArray = new OracleParameter[17];
                }

                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_L_MATERIAL_ID", obj.LMaterialID, OracleDbType.Decimal, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":p_MT_ID", obj.LibraryMaterialType, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_CATEGORY_ID", obj.LibraryMaterialCategory, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_CALL_NO", obj.CallNo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_CORPORATE_BODY", obj.CorporateBody, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":p_TITLE", obj.Title, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":p_SERIES_STATE", obj.SeriesStatement, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":p_NOTE", obj.Note, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":p_BRD_SUBJECT_HEADING", obj.BoardSubjectHeading, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[11] = Utilities.GetOraParam(":p_GEO_DESC", obj.GeoDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[12] = Utilities.GetOraParam(":p_LANG_ID", obj.LanguageID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[13] = Utilities.GetOraParam(":p_PHY_DESC", obj.PhysicalDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[14] = Utilities.GetOraParam(":p_PUBLISHER_ID", obj.PublisherID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[15] = Utilities.GetOraParam(":p_CONTENT_FILE", obj.ContentFile, OracleDbType.Blob, ParameterDirection.Input);
                paramArray[16] = Utilities.GetOraParam(":p_FILE_TYPE", obj.CFileType, OracleDbType.Varchar2, ParameterDirection.Input);

                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                string modeName = "";
                if (obj.Action == "A")
                {
                    modeName = "add";
                }
                else if (obj.Action == "M")
                {
                    modeName = "update";
                }

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " " + modeName + " Library Material.");

                OracleTransaction Tran = DBConn.BeginTransaction();

                try
                {
                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertSP, paramArray);
                    obj.LMaterialID = long.Parse(paramArray[2].Value.ToString());



                    DLLLibraryMaterialKeyword.AddLibraryMaterialKeyword(obj.LstLMKeyword, obj.LMaterialID, Tran);

                    DLLLibraryMaterialAuthor.AddLibraryMaterialAuthor(obj.LstLMAuthor, obj.LMaterialID, Tran);

                   

                    Tran.Commit();

                    return obj.LMaterialID;
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw ex;
                }
                finally
                {
                    GetConn.CloseDbConn();
                }
            
           
        }
        public static bool AddLibraryMaterialCopy(List<ATTLibraryMaterialCopy> LMCpyLst,long LMID)
        {
                        
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                       
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                DLLLibraryMaterialCopy.AddLibraryMaterialCopy(LMCpyLst, LMID, Tran);

                Tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }


        }

        
        public static DataTable GetSearchedLibraryMaterialTable(ATTLibraryMaterial criteria, string keywordCollection, string authorCollection)
        {
            string SelectVW = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            string columnName = "Org_ID,Library_ID,L_Material_ID,Accession_ID,Title,MT_ID,Category_ID,Call_NO,Corporate_Body,Series_State,Note,Brd_Subject_Heading,Geo_Desc,Phy_Desc,Lang_ID,Publisher_ID,File_Type,Edition,Pub_Date,Reg_Date,Isbn_Issn,Price,Currency_ID,MT_COPY_LOC";
            SelectVW = "  SELECT " + columnName + " FROM VW_LIBRARY_INFO WHERE ORG_ID=" + criteria.OrgID + " AND LIBRARY_ID=" + criteria.LibraryID;

            if (criteria.LibraryMaterialType > 0)
            {
                SelectVW += " AND MT_ID=" + criteria.LibraryMaterialType;
            }

            if (criteria.LibraryMaterialCategory > 0)
            {
                SelectVW += " AND CATEGORY_ID=" + criteria.LibraryMaterialCategory;
            }

            if (criteria.LanguageID > 0)
            {
                SelectVW += " AND LANG_ID=" + criteria.LanguageID;
            }

            if (criteria.PublisherID > 0)
            {
                SelectVW += " AND PUBLISHER_ID=" + criteria.PublisherID;
            }

            if (criteria.CallNo != "")
            {
                SelectVW += " AND UPPER(CALL_NO)=:CALLNO";
                paramArray.Add(Utilities.GetOraParam(":CALLNO", criteria.CallNo.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }
            
            if (keywordCollection != "")
            {
                SelectVW += " AND (ORG_ID,LIBRARY_ID,L_MATERIAL_ID)";
                SelectVW += " IN";
                SelectVW += " (SELECT DISTINCT ORG_ID,LIBRARY_ID,L_MATERIAL_ID FROM VW_LM_KEYWORD WHERE KEYWORD_ID IN (" + keywordCollection + ") AND ORG_ID=" + criteria.OrgID + " AND LIBRARY_ID=" + criteria.LibraryID + ")";
            }

            if (authorCollection != "")
            {
                SelectVW += " AND (ORG_ID,LIBRARY_ID,L_MATERIAL_ID)";
                SelectVW += " IN";
                SelectVW += " (SELECT DISTINCT ORG_ID,LIBRARY_ID,L_MATERIAL_ID FROM VW_LM_AUTHOR WHERE AUTHOR_ID IN (" + authorCollection + ") AND ORG_ID=" + criteria.OrgID + " AND LIBRARY_ID=" + criteria.LibraryID + ")";
            }

            SelectVW += " ORDER BY L_MATERIAL_ID, ACCESSION_ID";

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SelectVW, Module.LIS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
