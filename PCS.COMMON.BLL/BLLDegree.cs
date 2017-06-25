using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
   public class BLLDegree
    {


       public static ObjectValidation Validate(ATTDegree ObjAttDegree)
       {
           ObjectValidation OV = new ObjectValidation();

           if (ObjAttDegree.DegreeName == "")
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Degree Name cannot be Blank.";
               return OV;
           }

           if (ObjAttDegree.DegreeLevelID == 0)
           {
               OV.IsValid = false;
               OV.ErrorMessage = "Degree Level cannot be Blank.";
               return OV;
           }
         
           return OV;
       }
       public static List<ATTDegree> GetDegree(int? degreeID,string active)
       {
           List<ATTDegree> LstDegree = new List<ATTDegree>();

           try
           {


               foreach (DataRow row in DLLDegree.GetDegree(degreeID, active).Rows)
               {
                   ATTDegree ObjAtt = new ATTDegree
                       (
                       (row["DEGREE_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["DEGREE_ID"].ToString()),
                       (row["DEGREE_LEVEL_ID"] == System.DBNull.Value) ? 0 : int.Parse(row["DEGREE_LEVEL_ID"].ToString()),
                       (row["DEGREE_NAME"] == System.DBNull.Value) ? "" : (string)row["DEGREE_NAME"],
                       (row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"],
                       ""
                       );
                 
                   LstDegree.Add(ObjAtt);

               }
               return LstDegree;
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       //public static bool SaveDegree(List<ATTDegree> LstAtt,int NewDegreeLevelID)
       //{
       //    try
       //    {
       //        return DLLDegree.SaveDegree(LstAtt,NewDegreeLevelID);
       //    }
       //    catch (Exception ex)
       //    {

       //        throw ex;
       //    }

       //}

      
    }
}
