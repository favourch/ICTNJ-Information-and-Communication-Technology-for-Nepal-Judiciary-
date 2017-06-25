using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.DLL
{
    public class DLLPerson
    {

        public static DataTable GetPersonDetails(double personId)
        {
            try
            {
                string SelectSql = "SP_GET_PERSONS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_P_ID", personId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static DataTable GetPersonListTable(int? pID)
        {
            try
            {
                string SelectSQL = "SELECT P_ID,FIRST_NAME,MID_NAME,SUR_NAME FROM VW_PERSON_ADDRESS_INFO";

                OracleParameter[] paramArray = new OracleParameter[1];
                paramArray[0] = Utilities.GetOraParam(":PID", pID, OracleDbType.Int64, ParameterDirection.Input);

                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn();
                //OracleConnection DBConn = G
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double AddPersonnelDetails(ATTPerson objPerson, OracleTransaction Tran)
        {
            double personID = 0;
            try
            {
                OracleParameter[] paramArray = new OracleParameter[17];
                paramArray[0] = Utilities.GetOraParam(":p_P_ID", objPerson.PId, OracleDbType.Double, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":p_FIRST_NAME", objPerson.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_MID_NAME", objPerson.MidName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_SUR_NAME", objPerson.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_DOB", objPerson.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_GENDER", objPerson.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_MARTIAL_STATUS", objPerson.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":p_FATHER_NAME", objPerson.FatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":p_GFATHER_NAME", objPerson.GFatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":p_COUNTRY_ID", objPerson.CountryId, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":p_BIRTH_DISTRICT", objPerson.BirthDistrict, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[11] = Utilities.GetOraParam(":p_RELIGION_ID", objPerson.ReligionId, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[12] = Utilities.GetOraParam(":p_INI_UNIT", objPerson.IniUnit, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[13] = Utilities.GetOraParam(":p_INI_TYPE", objPerson.IniType, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[14] = Utilities.GetOraParam(":p_ENTRY_BY", objPerson.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                if (objPerson.Photo != null && objPerson.Photo.Length <= 0)
                    paramArray[15] = Utilities.GetOraParam(":p_PHOTO", null, OracleDbType.Blob, ParameterDirection.Input);
                else
                    paramArray[15] = Utilities.GetOraParam(":p_PHOTO", objPerson.Photo, OracleDbType.Blob, ParameterDirection.Input);

                    paramArray[16] = Utilities.GetOraParam(":p_ENTITY_TYPE", objPerson.EntityType, OracleDbType.Varchar2, ParameterDirection.Input);


                if (objPerson.PId == 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSONS", paramArray[0], paramArray);
                else if (objPerson.PId > 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSONS", paramArray[0], paramArray);

                personID = double.Parse(paramArray[0].Value.ToString());
                if (objPerson.LstPersonAddress.Count > 0)
                    DLLPersonAddress.AddPersonAddress(objPerson.LstPersonAddress, Tran, personID);
                if (objPerson.LstPersonPhone.Count > 0)
                    DLLPersonPhone.AddPersonPhone(objPerson.LstPersonPhone, Tran, personID);
                if (objPerson.LstPersonEMail.Count > 0)
                    DLLPersonEMail.AddPersonEMail(objPerson.LstPersonEMail, Tran, personID);
                if (objPerson.LstPersonQualification.Count > 0)
                    DLLPersonQualification.AddPersonQualifications(objPerson.LstPersonQualification, Tran, personID);
                if (objPerson.LstPersonTraining.Count > 0)
                    DLLPersonTraining.AddPersonTrainings(objPerson.LstPersonTraining, Tran, personID);
                if (objPerson.LstPersonDocuments.Count > 0)
                    DLLPersonDocuments.SavePersonDocuments(objPerson.LstPersonDocuments, Tran, personID);
                return personID;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
        }

        public static object GetConnection()
        {
            try
            {
                return new GetConnection().GetDbConn(Module.PMS) as object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CloseConnection(object conn)
        {
            (conn as OracleConnection).Close();
            (conn as OracleConnection).Dispose();
            return true;
        }

        public static DataTable GetPersonWithPersonnelAttributeByID(object conn, double personID)
        {
            string SQL;

            SQL = "SELECT P.P_ID, P.FIRST_NAME, P.MID_NAME, P.SUR_NAME, P.DOB, P.GENDER, ";
            SQL = SQL + "P.MARTIAL_STATUS, P.FATHER_NAME, P.GFATHER_NAME,";
            SQL = SQL + "P.COUNTRY_ID, P.BIRTH_DISTRICT, P.RELIGION_ID, P.ENTRY_DATE, P.P_PHOTO FROM PERSON P";
            SQL = SQL + " where p_id=" + personID.ToString();

            try
            {
                return SqlHelper.ExecuteDataset(conn as OracleConnection, CommandType.Text, SQL).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double AddPersonnelDetails(List<ATTPerson> PersonLST, OracleTransaction Tran)
        {
            double personID = 0;
            try
            {
                foreach (ATTPerson objPerson in PersonLST)
                {
                    OracleParameter[] paramArray = new OracleParameter[17];
                    paramArray[0] = Utilities.GetOraParam(":p_P_ID", objPerson.PId, OracleDbType.Double, ParameterDirection.InputOutput);
                    paramArray[1] = Utilities.GetOraParam(":p_FIRST_NAME", objPerson.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_MID_NAME", objPerson.MidName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":p_SUR_NAME", objPerson.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_DOB", objPerson.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_GENDER", objPerson.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_MARTIAL_STATUS", objPerson.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":p_FATHER_NAME", objPerson.FatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":p_GFATHER_NAME", objPerson.GFatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":p_COUNTRY_ID", objPerson.CountryId, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":p_BIRTH_DISTRICT", objPerson.BirthDistrict, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[11] = Utilities.GetOraParam(":p_RELIGION_ID", objPerson.ReligionId, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[12] = Utilities.GetOraParam(":p_INI_UNIT", objPerson.IniUnit, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[13] = Utilities.GetOraParam(":p_INI_TYPE", objPerson.IniType, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[14] = Utilities.GetOraParam(":p_ENTRY_BY", objPerson.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);


                    if (objPerson.Photo != null && objPerson.Photo.Length <= 0)
                        paramArray[15] = Utilities.GetOraParam(":p_PHOTO", null, OracleDbType.Blob, ParameterDirection.Input);
                    else
                        paramArray[15] = Utilities.GetOraParam(":p_PHOTO", objPerson.Photo, OracleDbType.Blob, ParameterDirection.Input);

                    paramArray[16] = Utilities.GetOraParam(":p_ENTITY_TYPE", objPerson.EntityType, OracleDbType.Varchar2, ParameterDirection.Input);

                    if (objPerson.PId == 0)
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSONS", paramArray[0], paramArray);
                    else if (objPerson.PId > 0)
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSONS", paramArray[0], paramArray);

                    personID = double.Parse(paramArray[0].Value.ToString());
                    objPerson.PId = personID;
                    if (objPerson.LstPersonAddress.Count > 0)
                        DLLPersonAddress.AddPersonAddress(objPerson.LstPersonAddress, Tran, personID);
                    if (objPerson.LstPersonPhone.Count > 0)
                        DLLPersonPhone.AddPersonPhone(objPerson.LstPersonPhone, Tran, personID);
                    if (objPerson.LstPersonEMail.Count > 0)
                        DLLPersonEMail.AddPersonEMail(objPerson.LstPersonEMail, Tran, personID);
                }
                return personID;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

        }

        public static bool AddPersonnelDetails(ATTPerson objPerson)
        {


            PCS.COREDL.GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;

            DBConn = Conn.GetDbConn();
            Tran = DBConn.BeginTransaction();


            double personID = 0;
            try
            {
                OracleParameter[] paramArray = new OracleParameter[17];
                paramArray[0] = Utilities.GetOraParam(":p_P_ID", objPerson.PId, OracleDbType.Double, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":p_FIRST_NAME", objPerson.FirstName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_MID_NAME", objPerson.MidName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_SUR_NAME", objPerson.SurName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_DOB", objPerson.DOB, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_GENDER", objPerson.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_MARTIAL_STATUS", objPerson.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":p_FATHER_NAME", objPerson.FatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":p_GFATHER_NAME", objPerson.GFatherName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":p_COUNTRY_ID", objPerson.CountryId, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":p_BIRTH_DISTRICT", objPerson.BirthDistrict, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[11] = Utilities.GetOraParam(":p_RELIGION_ID", objPerson.ReligionId, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[12] = Utilities.GetOraParam(":p_INI_UNIT", objPerson.IniUnit, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[13] = Utilities.GetOraParam(":p_INI_TYPE", objPerson.IniType, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[14] = Utilities.GetOraParam(":p_ENTRY_BY", objPerson.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                if (objPerson.Photo != null && objPerson.Photo.Length <= 0)
                    paramArray[15] = Utilities.GetOraParam(":p_PHOTO", null, OracleDbType.Blob, ParameterDirection.Input);
                else
                    paramArray[15] = Utilities.GetOraParam(":p_PHOTO", objPerson.Photo, OracleDbType.Blob, ParameterDirection.Input);
                paramArray[16] = Utilities.GetOraParam(":P_ENTITY_TYPE", objPerson.EntityType, OracleDbType.Varchar2, ParameterDirection.Input);

                if (objPerson.PId == 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_PERSONS", paramArray[0], paramArray);
                else if (objPerson.PId > 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_PERSONS", paramArray[0], paramArray);

                personID = double.Parse(paramArray[0].Value.ToString());
                objPerson.PId = personID;
                if (objPerson.LstPersonAddress.Count > 0)
                    DLLPersonAddress.AddPersonAddress(objPerson.LstPersonAddress, Tran, personID);
                if (objPerson.LstPersonPhone.Count > 0)
                    DLLPersonPhone.AddPersonPhone(objPerson.LstPersonPhone, Tran, personID);
                if (objPerson.LstPersonEMail.Count > 0)
                    DLLPersonEMail.AddPersonEMail(objPerson.LstPersonEMail, Tran, personID);

                Tran.Commit();
                return true;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

        }
    }
}
