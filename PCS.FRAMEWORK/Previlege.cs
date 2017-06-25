using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.FRAMEWORK
{
    public class Previlege
    {
        private string _Username;
        public string Username
        {
            get { return this._Username; }
            set { this._Username = value; }
        }

        private string _Menuname;
        public string Menuname
        {
            get { return this._Menuname; }
            set { this._Menuname = value; }
        }

        private int _ApplID;
        public int ApplID
        {
            get { return this._ApplID; }
            set { this._ApplID = value; }
        }

        private PrevilegeType _PType;
        public PrevilegeType PType
        {
            get { return this._PType; }
            set { this._PType = value; }
        }

        public Previlege(string username, string menuname, int applID, PrevilegeType pType)
        {
            this.Username = username;
            this.Menuname = menuname;
            this.ApplID = applID;
            this.PType = pType;
        }


        public enum PrevilegeType
        {
            P_SELECT,
            P_ADD,
            P_EDIT,
            P_DELETE
        }

        private static string GetAccessString(string username, string menuname, int appID, OracleConnection Conn)
        {
            string PreviledeSQL = "SP_GET_ACCESS_STRING";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":p_MENUNAME", menuname, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_USERNAME", username, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", appID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_ACCESS_STRING", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramArray[3].Size = 8;

            try
            {
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, PreviledeSQL, paramArray.ToArray());

                if (paramArray[3].Value == null || paramArray[3].Value == System.DBNull.Value)
                    return "";
                else
                    return paramArray[3].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check previlege for add, edit, select and delete action
        /// </summary>
        /// <param name="username">Application's username extracted from session</param>
        /// <param name="pType">Previlege type depending upon application's function, procedure</param>
        /// <param name="requiredMenuName">Actual form's menuname assigned to form</param>
        /// <returns></returns>
        public static bool HasPrevilege(Previlege Pobj, OracleConnection Conn)
        {
            try
            {
                string PS = Previlege.GetAccessString(Pobj.Username, Pobj.Menuname, Pobj.ApplID, Conn);
                return Previlege.HasPrevilegeFlag(PS, Pobj.PType);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool HasPrevilege(string username, Previlege.PrevilegeType PType, string menuname)
        {
            return false;
        }

        private static bool HasPrevilegeFlag(string PS, PrevilegeType pType)
        {
            int pIndex = -1;

            if (pType == PrevilegeType.P_SELECT)
                pIndex = 0;
            else if (pType == PrevilegeType.P_ADD)
                pIndex = 1;
            else if (pType == PrevilegeType.P_EDIT)
                pIndex = 2;
            else if (pType == PrevilegeType.P_DELETE)
                pIndex = 3;

            char[] token ={ '_' };

            if (PS.Split(token)[pIndex] == "Y")
                return true;
            else
                return false;
        }
    }
}