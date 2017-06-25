using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL
{
   public class BLLInstitution
    {
       public static ObjectValidation Validate(ATTInstitution ObjAttInst)
       {
           ObjectValidation OV = new ObjectValidation();

           if (ObjAttInst.InstitutionName == "")
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Institution Name cannot be Blank.";
               return OV;
           }

           if (ObjAttInst.BoardName == "")
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Board Name cannot be Blank.";
               return OV;
           }

           if (ObjAttInst.Location == "")
           {
               OV.IsValid = false;
               OV.ErrorMessage = " Location cannot be Blank.";
               return OV;
           }
           if (ObjAttInst.CountryID == 0)
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Country cannot be Blank.";
               return OV;
           }

           if (ObjAttInst.InstitutionType == "")
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Select Institution Type";
               return OV;
           }

           return OV;
       }

       public static List<ATTInstitution> GetInstitution(int? institutionID, string active)
       {
           List<ATTInstitution> LstInstitution = new List<ATTInstitution>();

           try
           {


               foreach (DataRow row in DLLInstitution.GetInstitution(institutionID, active).Rows)
               {
                   ATTInstitution ObjAtt = new ATTInstitution
                       (
                       (row["INSTITUTION_ID"] == System.DBNull.Value) ? 0 : long.Parse(row["INSTITUTION_ID"].ToString()),
                       (row["INSTITUTION_NAME"] == System.DBNull.Value) ? "" : (string)row["INSTITUTION_NAME"],
                       (row["BOARD_NAME"] == System.DBNull.Value) ? "" : (string)row["BOARD_NAME"],
                       (row["LOCATION"] == System.DBNull.Value) ? "" : (string)row["LOCATION"],
                       (row["COUNTRY_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["COUNTRY_ID"].ToString()),
                       (row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"],
                       (row["INSTITUTION_TYPE"] == System.DBNull.Value) ? "" : (string)row["INSTITUTION_TYPE"],
                       ""
                       );

                   ObjAtt.InstitutionNameBoardCountry = (row["INSTITUTION_NAME"] == System.DBNull.Value) ? "" : (string)row["INSTITUTION_NAME"] + "(";
                   ObjAtt.InstitutionNameBoardCountry += (row["BOARD_NAME"] == System.DBNull.Value) ? "" : (string)row["BOARD_NAME"] + ",";
                   ObjAtt.InstitutionNameBoardCountry += (row["LOCATION"] == System.DBNull.Value) ? "" : (string)row["LOCATION"] + ",";
                   ObjAtt.InstitutionNameBoardCountry += (row["COUNTRY_NEP_NAME"] == System.DBNull.Value) ? "" : (string)row["COUNTRY_NEP_NAME"] + ",";

                   if (ObjAtt.InstitutionNameBoardCountry.Substring(ObjAtt.InstitutionNameBoardCountry.Length-1) != "(")
                   {
                       ObjAtt.InstitutionNameBoardCountry = ObjAtt.InstitutionNameBoardCountry.Substring(0, ObjAtt.InstitutionNameBoardCountry.Length - 1);
                       ObjAtt.InstitutionNameBoardCountry += ")";
                   }

                   else
                       ObjAtt.InstitutionNameBoardCountry = ObjAtt.InstitutionNameBoardCountry.Substring(0, ObjAtt.InstitutionNameBoardCountry.Length - 1);

                   LstInstitution.Add(ObjAtt);
               }               
               return LstInstitution;
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       public static int SaveInstitution(ATTInstitution ObjAtt)
       {
           try
           {
               return DLLInstitution.SaveInstitution(ObjAtt);
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public static bool DeleteInstitution(int institutionID)
       {
           try
           {
               return DLLInstitution.DeleteInstitution(institutionID);

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

    }
}
