using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLRelatives
    {
        public static double SaveRelatives(ATTRelatives objRelatives, OracleTransaction Tran, double personID)
        {
            double relativeID = 0;
            try
            {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    if (objRelatives.Action == "D")
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_P_ID", objRelatives.PId, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_RELATIVE_ID", objRelatives.RelativeId, OracleDbType.Varchar2, ParameterDirection.Input));
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_RELATIVES", paramArray.ToArray());
                        paramArray.Clear();
                    }
                    else
                    {
                        relativeID = DLLPerson.AddPersonnelDetails(objRelatives.ObjPerson, Tran);
                        paramArray.Add(Utilities.GetOraParam(":P_P_ID", personID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_RELATIVE_ID", relativeID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_RELATION_TYPE_ID", objRelatives.RelationTypeId, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_OCCUPATION", objRelatives.Occupation, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objRelatives.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objRelatives.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                        if (objRelatives.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_RELATIVES", paramArray.ToArray());
                        else if (objRelatives.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_RELATIVES", paramArray.ToArray());
                        paramArray.Clear();

                    }
                    return relativeID;
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

    }
}
