using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLDegree
    {
        public static DataTable GetDegree(int? degreeID, string active)
        {
            try
            {
                string SelectDegreeSql = "SP_GET_DEGREES";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_DEGREE_ID", degreeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDegreeSql,ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool SaveDegree(List<ATTDegree> LstDegree, int DegreeLevelID, OracleTransaction Tran)
        {
            string InsertUpdateDeleteDegreeSql = "";
            int NewDegreeID;
            if (LstDegree.Count==0)
                return true;
            try
            {
                foreach (ATTDegree Att in LstDegree)
                {
                    if (Att.Flag == "D")
                    {
                        InsertUpdateDeleteDegreeSql = "SP_DEL_DEGREES";
                        
                        OracleParameter[] DeleteParamArray = new OracleParameter[1];
                        DeleteParamArray[0] = Utilities.GetOraParam(":p_DEGREE_ID", Att.DegreeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteDegreeSql, DeleteParamArray);
                    }
                    else
                    {
                        if (Att.Flag == "A")
                            InsertUpdateDeleteDegreeSql = "SP_ADD_DEGREES";
                        else if (Att.Flag == "E")
                            InsertUpdateDeleteDegreeSql = "SP_EDIT_DEGREES";
                        //else if (Att.Flag == "&nbsp;")
                        //    goto Terminate;
                        if (Att.Flag == "A" || Att.Flag == "E")
                        {
                            OracleParameter[] ParamArray = new OracleParameter[5];
                            ParamArray[0] = Utilities.GetOraParam(":p_DEGREE_ID", Att.DegreeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                            ParamArray[1] = Utilities.GetOraParam(":p_DEGREE_NAME", Att.DegreeName, OracleDbType.Varchar2, ParameterDirection.Input);
                            ParamArray[2] = Utilities.GetOraParam(":p_DEGREE_LEVEL_ID", DegreeLevelID, OracleDbType.Int64, ParameterDirection.Input);
                            ParamArray[3] = Utilities.GetOraParam(":p_ACTIVE", Att.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                            ParamArray[4] = Utilities.GetOraParam(":p_ENTRY_BY", Att.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteDegreeSql, ParamArray);


                            NewDegreeID = int.Parse(ParamArray[0].Value.ToString());

                            Att.DegreeLevelID = DegreeLevelID;
                            Att.DegreeID = NewDegreeID;

                            //Terminate:
                            //NewDegreeID = 0;
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
