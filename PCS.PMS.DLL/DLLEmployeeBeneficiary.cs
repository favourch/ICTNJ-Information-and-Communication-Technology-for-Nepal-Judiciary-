using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeBeneficiary
    {
        public static bool SaveBeneficiary( List<ATTEmployeeBeneficiary> lstBeneficiaries, OracleTransaction Tran, double empID)
        {
            double benID = 0;
            try
            {
                foreach (ATTEmployeeBeneficiary lst in lstBeneficiaries)
                {
                    if (lst.Action != "")
                    {
                        List<OracleParameter> paramArray = new List<OracleParameter>();
                        if (lst.Action == "D")
                        {
                            paramArray.Add(Utilities.GetOraParam(":P_P_ID", lst.EmpId, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_BENEFICIARY_ID", lst.BenId, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_BENEFICIARIES", paramArray.ToArray());
                            paramArray.Clear();
                        }
                        else
                        {
                            benID = DLLRelatives.SaveRelatives(lst.ObjRelatives, Tran, empID);
                            paramArray.Add(Utilities.GetOraParam(":P_P_ID", empID, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_BENEFICIARY_ID", benID, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_TO_DATE", lst.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                            if (lst.Action == "A")
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_BENEFICIARIES", paramArray.ToArray());
                            else if (lst.Action == "E")
                                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_BENEFICIARIES", paramArray.ToArray());
                            paramArray.Clear();
                        }
                    }
                }
                return true;
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
