using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.LJMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LJMS.DLL
{
    public class DLLLawyerSearch
    {
        public static DataTable GetLawyerTable(ATTLawyerSearch search)
        {
            string SQL = "select * from VW_LAWYER_INFO where 1=1 ";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (search.FirstName != "")
            {
                SQL = SQL + " and first_name like :fname||'%'";
                paramArray.Add(Utilities.GetOraParam(":fname", search.FirstName, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (search.MidName != "")
            {
                SQL = SQL + " and mid_name like :mname||'%'";
                paramArray.Add(Utilities.GetOraParam(":mname", search.MidName, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (search.SurName != "")
            {
                SQL = SQL + " and sur_name like :sname||'%'";
                paramArray.Add(Utilities.GetOraParam(":sname", search.SurName, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (search.Lisence != "")
            {
                SQL = SQL + " and license_no = :lisence";
                paramArray.Add(Utilities.GetOraParam(":lisence", search.Lisence, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (search.LawyerTypeID > 0)
            {
                SQL = SQL + " and lawyer_type_id = :ltID";
                paramArray.Add(Utilities.GetOraParam(":ltID", search.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input));
            }

            if (search.UnitID > 0)
            {
                SQL = SQL + " and unit_id = :unit";
                paramArray.Add(Utilities.GetOraParam(":unit", search.UnitID, OracleDbType.Int16, ParameterDirection.Input));
            }

            if (search.Gender != "")
            {
                SQL = SQL + " and gender = :gender";
                paramArray.Add(Utilities.GetOraParam(":gender", search.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (search.ACTIVE != "")
            {
                SQL = SQL + " and active = :activex";
                paramArray.Add(Utilities.GetOraParam(":activex", search.ACTIVE, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            SQL = SQL + " order by lawyer_type_id, license_no";

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.LJMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetLawyerCount(ATTLawyerCount cnt)
        {
            string SQL;
            if (cnt.Type == LawyerType.NepalBarAssociation)
                SQL = "select * from VW_LAWYER_TYPE_WISE_CNT where 1 = 1 ";
            else
                SQL = "select * from VW_UNIT_LAWYER_TYPE_WISE_CNT where 1 = 1 ";

            if (cnt.LawyerTypeID > 0)
            {
                SQL = SQL + " and lawyer_type_id = " + cnt.LawyerTypeID;
            }

            if (cnt.UnitID > 0)
            {
                SQL = SQL + " and unit_id = " + cnt.UnitID;
            }

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.LJMS, null).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}