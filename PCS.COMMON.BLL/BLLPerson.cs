using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLPerson
    {
        public static ATTPerson GetPersons(double personID, string personDocActive)
        {
            //List<ATTVDC> lstVDCs = new List<ATTVDC>();
            ATTPerson obj = new ATTPerson();

            foreach (DataRow row in DLLPerson.GetPersonDetails(personID).Rows)
            {
                obj.PId = double.Parse(row["P_ID"].ToString());
                obj.FirstName = row["FIRST_NAME"].ToString();
                obj.MidName = (row["MID_NAME"] == System.DBNull.Value) ? "" : row["MID_NAME"].ToString();
                obj.SurName = row["SUR_NAME"].ToString();

                obj.DOB = row["DOB"] == System.DBNull.Value ? "" : row["DOB"].ToString();
                obj.Gender = row["GENDER"] == System.DBNull.Value ? "" : row["GENDER"].ToString();
                obj.MaritalStatus = row["MARTIAL_STATUS"] == System.DBNull.Value ? "" : row["MARTIAL_STATUS"].ToString();
                //this.ddlCountry.SelectedValue
                if (row["BIRTH_DISTRICT"] == System.DBNull.Value)
                    obj.BirthDistrict = null;
                else
                    obj.BirthDistrict = int.Parse(row["BIRTH_DISTRICT"].ToString());

                //obj.BirthDistrict = row["BIRTH_DISTRICT"] == System.DBNull.Value ? 0 :int.Parse( row["BIRTH_DISTRICT"].ToString());
                obj.ReligionId = row["RELIGION_ID"] == System.DBNull.Value ? 0 : int.Parse(row["RELIGION_ID"].ToString());
                //this.txtIdentityMark.Text=objPerson.i
                obj.IniType = int.Parse(row["INI_TYPE"].ToString());
                obj.IniUnit = int.Parse(row["INI_UNIT"].ToString());
                obj.EntityType = row["ENTITY_TYPE"].ToString();

                obj.LstPersonAddress = BLLPersonAddress.GetPersonAddress(null, obj.PId);
                obj.LstPersonPhone = BLLPersonPhone.GetPersonPhone(null, obj.PId);
                obj.LstPersonEMail = BLLPersonEMail.GetPersonEMail(null, obj.PId);
                obj.LstRelatives = BLLRelatives.GetRelatives(null, obj.PId);
                obj.LstPersonDocuments = BLLPersonDocuments.GetPersonDocuments(null, obj.PId, personDocActive);
            }
            return obj;
        }


        public static ATTPerson GetPersonnelDetails(object obj, double personID)
        {
            ATTPerson person=new ATTPerson();
            try
            {
                person.LstPersonAddress = BLLPersonAddress.GetPersonAddress(obj, personID);
                person.LstPersonEMail = BLLPersonEMail.GetPersonEMail(obj, personID);
                person.LstPersonPhone = BLLPersonPhone.GetPersonPhone(obj, personID);
                person.LstPersonQualification = BLLPersonQualification.GetPersonQualification(obj, personID);
                person.LstPersonTraining = BLLPersonTraining.GetPersonTraining(obj, personID);
                person.LstPersonDocuments = BLLPersonDocuments.GetPersonDocuments(obj, personID,null);
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTPerson GetPersonWithPersonnelAttributeByID(double personID)
        {
            object conn;

            try
            {
                conn = DLLPerson.GetConnection();
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            try
            {
                DataRow row = DLLPerson.GetPersonWithPersonnelAttributeByID(conn, personID).Rows[0];

                ATTPerson person = new ATTPerson();

                person.PId = double.Parse(row["P_ID"].ToString());
                person.FirstName = row["FIRST_NAME"].ToString();
                person.MidName = row["MID_NAME"].ToString();
                person.SurName = row["SUR_NAME"].ToString();
                person.Gender = row["GENDER"].ToString();
                person.DOB = row["DOB"].ToString();
                person.MaritalStatus = row["MARTIAL_STATUS"].ToString();
                person.CountryId = row["country_id"] == System.DBNull.Value ? (int?)null : int.Parse(row["country_id"].ToString());
                person.BirthDistrict = row["birth_district"] == System.DBNull.Value ? (int?)null : int.Parse(row["birth_district"].ToString());
                person.ReligionId = row["religion_id"] == System.DBNull.Value ? (int?)null : int.Parse(row["religion_id"].ToString());
                person.Photo = row["p_photo"] as byte[];

                person.LstPersonAddress = BLLPersonAddress.GetPersonAddress(conn, personID);
                person.LstPersonPhone = BLLPersonPhone.GetPersonPhone(conn, personID);
                person.LstPersonEMail = BLLPersonEMail.GetPersonEMail(conn, personID);
                person.LstPersonQualification = BLLPersonQualification.GetPersonQualification(conn, personID);
                //person.ls

                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DLLPerson.CloseConnection(conn);
            }
        }

        public static bool SavePerson(List<ATTPerson> PersonLST)
        {
            try
            {
                return PCS.COMMON.DLL.DLLPerson.AddPersonnelDetails(PersonLST[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static bool SavePerson(ATTPerson objPerson)
        {
            try
            {
                return PCS.COMMON.DLL.DLLPerson.AddPersonnelDetails(objPerson);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
