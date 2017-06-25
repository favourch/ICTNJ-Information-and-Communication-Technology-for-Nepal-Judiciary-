using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using Oracle.DataAccess.Client;

namespace PCS.SECURITY.DLL
{
    public class DLLApplicationForm
    {
        public static DataTable GetApplicationFormTable(int appID,int formID)
        {
            string SelectSQL = "SP_GET_APPLICATION_FORMS";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            //int paramSize = 0;

            if (formID > 0)
                paramArray.Add(Utilities.GetOraParam(":p_FORM_ID", formID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam(":p_FORM_ID", null, OracleDbType.Int64, ParameterDirection.Input));

            if (appID > 0)
                paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", appID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", null, OracleDbType.Int64, ParameterDirection.Input));

            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddApplicationFormWithMenu(List<ATTApplication> lstApp)
        {
            string InsertSQL = "SP_ADD_APPLICATION_FORMS";
            
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();
            
            try
            {
                double formID;
                foreach (ATTApplication app in lstApp)
                {
                    foreach (ATTApplicationForm form in app.LstApplicationForm)
                    {
                        formID = form.FormID;
                        if (form.Action == "A")
                        {
                            OracleParameter[] paramArray = new OracleParameter[4];
                            paramArray[0] = Utilities.GetOraParam(":p_APPL_ID", form.ApplicationID, OracleDbType.Int64, ParameterDirection.Input);
                            paramArray[1] = Utilities.GetOraParam(":p_FORM_ID", form.FormID, OracleDbType.Int64, ParameterDirection.InputOutput);
                            paramArray[2] = Utilities.GetOraParam(":p_FORM_DESCRIPTION", form.FormDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                            paramArray[3] = Utilities.GetOraParam(":p_FORM_NAME", form.FormName, OracleDbType.Varchar2, ParameterDirection.Input);

                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSQL, paramArray[1], paramArray);

                            formID = double.Parse(paramArray[1].Value.ToString());
                            form.Action = "M";
                        }
                        DLLMenu.AddMenu(form.LstMenu, Tran, formID);
                    }
                }

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
