using System;
using System.Collections.Generic;
using System.Text;

using PCS.LJMS.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.LJMS.DLL
{
    public class DLLLawyerPerson
    {
        public static bool SaveLawyerPerson(ATTLawyerPerson objLawyerPerson)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.LJMS).BeginTransaction();
            double pID = 0;
            try
            {
                pID = DLLPerson.AddPersonnelDetails(objLawyerPerson, Tran);

                DLLLawyer.SaveLawyerDetails(pID, objLawyerPerson.LstLawyer, Tran);

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
    }
}
