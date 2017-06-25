using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
   public class BLLParticipant
    {
       public static bool SaveParticipant(List<ATTParticipant> lstParticipant)
       {
           try
           {
               return DLLParticipant.SaveParticipant(lstParticipant);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
           
       }

       public static bool SaveParticipant(ATTParticipant objParticipant)
       {
           try
           {
               return DLLParticipant.SaveParticipant(objParticipant);
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public static List<ATTParticipant> GetParticipant(int OrgID,int ProgramID)
       {
           List<ATTParticipant> ParticipantList = new List<ATTParticipant>();

           try
           {
               foreach (DataRow row in DLLParticipant.GetParticipant(OrgID, ProgramID).Rows)
               {
                   ATTParticipant ObjAtt = new ATTParticipant
                       (
                       0,
                       0,
                       double.Parse(row["P_ID"].ToString()),
                       ((row["NAME"] == System.DBNull.Value) ? "" : (string)row["NAME"]),
                       "12/12/12",
                       "O"
                       );
                   ParticipantList.Add(ObjAtt);
               }
               return ParticipantList;

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
    }

   }
