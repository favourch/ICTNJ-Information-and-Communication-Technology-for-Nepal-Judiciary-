using System;
using System.Collections.Generic;
using System.Text;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;

namespace PCS.LJMS.BLL
{
    public class BLLLawyerPerson
    {
        public static bool SaveLawyerPerson(ATTLawyerPerson objLawyerPerson)
        {
            try
            {
                if (DLLLawyerPerson.SaveLawyerPerson(objLawyerPerson))
                {
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

        public static ATTLawyerPerson GetLawyerWithDetailInfoByID(double PID)
        {
            try
            {
                ATTLawyerPerson obj = new ATTLawyerPerson();

                ATTPerson objPerson = BLLPerson.GetPersonWithPersonnelAttributeByID(PID);
                //ATTPerson GetPersonWithPersonnelAttributeByID

                obj.PId = PID;
                obj.FirstName = objPerson.FirstName ;
                obj.MidName = objPerson.MidName ;
                obj.SurName = objPerson.SurName;
                obj.Gender = objPerson.Gender ;
                obj.DOB = objPerson.DOB ;
                obj.MaritalStatus = objPerson.MaritalStatus ;
                obj.CountryId = objPerson.CountryId ;
                obj.BirthDistrict = objPerson.BirthDistrict ;
                obj.ReligionId = objPerson.ReligionId ;
                obj.Photo = objPerson.Photo;

                obj.LstPersonAddress = objPerson.LstPersonAddress ;
                obj.LstPersonPhone = objPerson.LstPersonPhone ;
                obj.LstPersonEMail = objPerson.LstPersonEMail ;

                obj.LstPersonQualification = objPerson.LstPersonQualification;

                obj.LstLawyer = BLLLawyer.GetLawyerDetails(PID);

                return obj;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    }
}
