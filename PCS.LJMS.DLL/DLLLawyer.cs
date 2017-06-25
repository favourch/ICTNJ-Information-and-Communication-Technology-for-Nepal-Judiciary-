using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.LJMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.LJMS.DLL
{
    public class DLLLawyer
    {
        public static bool SaveLawyerDetails(double pID,List<ATTLawyer> lstLawyer,OracleTransaction Tran)
        {
            try
            {
                string sp = "";

                if (pID > 0)
                {
                    foreach (ATTLawyer objLawyer in lstLawyer)
                    {
                        if (objLawyer.Action == "A")
                        {
                            sp = "SP_ADD_LAWYER_INFO";
                        }
                        else if (objLawyer.Action == "E")
                        {
                            sp = "SP_EDIT_LAWYER_INFO";
                        }

                        objLawyer.PID = pID;

                        if (sp != "")
                        {
                            OracleParameter[] paramArray = new OracleParameter[6];
                            paramArray[0] = Utilities.GetOraParam(":p_P_ID", objLawyer.PID, OracleDbType.Double, ParameterDirection.Input);
                            paramArray[1] = Utilities.GetOraParam(":P_LAWYER_TYPE_ID", objLawyer.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input);
                            paramArray[2] = Utilities.GetOraParam(":P_LICENSE_NO", objLawyer.LicenseNo, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[3] = Utilities.GetOraParam(":P_FROM_DATE", objLawyer.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[4] = Utilities.GetOraParam(":P_TO_DATE", "", OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[5] = Utilities.GetOraParam(":p_ENTRY_BY", objLawyer.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                            sp = "";
                        }

                        if (objLawyer.LstLawyerRenewal.Count > 0)
                        {
                            if (DLLLawyerRenewal.SaveLawyerRenewalDetails(objLawyer, Tran) == false)
                            {
                                return false;
                            }
                        }

                        if (objLawyer.LstPrivateLawyer.Count > 0)
                        {
                            if (DLLPrivateLawyer.AddPrivateLawyerInfoList(objLawyer.LstPrivateLawyer, Tran, pID) == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveLawyerDetails(ATTLawyer objLawyer)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.LJMS).BeginTransaction();
            double pID;
            try
            {
                pID = DLLPerson.AddPersonnelDetails(objLawyer.ObjPerson, Tran);
                
                objLawyer.PID = pID;

                if (pID > 0)
                {
                    string sp = "SP_ADD_LAWYER_INFO ";

                    OracleParameter[] paramArray = new OracleParameter[6];
                    paramArray[0] = Utilities.GetOraParam(":p_P_ID", pID, OracleDbType.Double, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_LAWYER_TYPE_ID", objLawyer.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_LICENSE_NO", objLawyer.LicenseNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":P_FROM_DATE", objLawyer.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_TO_DATE","", OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_ENTRY_BY", objLawyer.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                    if (objLawyer.LstLawyerRenewal.Count > 0)
                    {
                        //DLLLawyerRenewal.SaveLawyerRenewalDetails(objLawyer, Tran);
                        DLLLawyer.SaveLawyerDetails(objLawyer);
                    }

                    //if (objLawyer.LstPrivateLawyer.Count > 0)
                    //{
                    //    DLLLawyer.SaveLawyerDetails(objLawyer);
                    //}
                    
                    Tran.Commit();
                    return true;
                }
                else
                {
                    Tran.Rollback();
                    return false; 
                }
                
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
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

        public static bool UpdateLawyerInfo(ATTLawyerInfoSearch objLInfo)
        {

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.LJMS).BeginTransaction();

            string sp = "SP_EDIT_LAWYER_INFO_STATUS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_P_ID", objLInfo.PERSONID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_LTypeID", objLInfo.LTYPEID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_LicenceNo", objLInfo.LICENSENO, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_active", objLInfo.ACTIVE, OracleDbType.Varchar2, ParameterDirection.Input));

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());
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

        public static DataTable GetLawyerDetailTable(double PID)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT DISTINCT P_ID,LAWYER_TYPE_ID,lawyer_type_description,LICENSE_NO,FROM_DATE FROM vw_lawyer_info_details ";

                if (PID > 0)
                {
                    selectSQL += " WHERE P_ID = " + PID;
                }

                OracleConnection DBConn = GetConn.GetDbConn(Module.LJMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

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

    }
}
