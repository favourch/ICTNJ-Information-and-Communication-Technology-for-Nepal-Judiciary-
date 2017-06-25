using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvSrchPurchaseOrder
    {
        public  static DataTable SrchPurchaseOrder(ATTInvSrchPurchaseOrder objSrchPo,int type)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            
            try
            {
                string srchSQL =     " SELECT distinct ORG_ID,SUPPLIERS_ID,SUPPLIERS_NAME,ORDER_DATE,ORDER_NO, "
                                   + " REC_BY,REC_DATE,REC_YES_NO,APP_BY,APP_DATE,APP_YES_NO "
                                   + " FROM vw_inv_purchase_orders WHERE 1=1";


                if(type == 1)
                    srchSQL = srchSQL + " AND REC_YES_NO IS NULL AND APP_YES_NO IS NULL";
                else if (type == 2)
                    srchSQL = srchSQL + " AND REC_YES_NO IS NOT NULL AND APP_YES_NO IS NULL";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objSrchPo.UnitID > 0)
                {

                    srchSQL = srchSQL + " AND UNIT_ID=:unit_id";
                    paramArray.Add(Utilities.GetOraParam(":unit_id", objSrchPo.UnitID, OracleDbType.Int32, ParameterDirection.Input));

                }

                if (objSrchPo.SectionID > 0)
                {

                    srchSQL = srchSQL + " AND SECTION_ID=:section_id";
                    paramArray.Add(Utilities.GetOraParam(":unit_id", objSrchPo.SectionID, OracleDbType.Int32, ParameterDirection.Input));

                }

                if (objSrchPo.OrderNo.Trim() != "")
                {
                    srchSQL = srchSQL + " AND ORDER_NO =:order_no ";
                    paramArray.Add(Utilities.GetOraParam(":order_no", objSrchPo.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (objSrchPo.OrderDate.Trim() != "")
                {
                    srchSQL = srchSQL + " AND ORDER_DATE =:order_date ";
                    paramArray.Add(Utilities.GetOraParam(":order_date", objSrchPo.OrderDate, OracleDbType.Varchar2, ParameterDirection.Input));
                }

                if (objSrchPo.SupplierID > 0)
                {

                    srchSQL = srchSQL + " AND SUPPLIERS_ID=:supplier_id";
                    paramArray.Add(Utilities.GetOraParam(":supplier_id", objSrchPo.SupplierID, OracleDbType.Int32, ParameterDirection.Input));

                }

                return SqlHelper.ExecuteDataset(CommandType.Text, srchSQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
