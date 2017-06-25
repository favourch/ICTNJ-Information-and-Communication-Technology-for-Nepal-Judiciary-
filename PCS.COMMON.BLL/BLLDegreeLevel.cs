using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLDegreeLevel
    {
        public static ObjectValidation Validate(ATTDegreeLevel ObjAttDL)
        {
            ObjectValidation OV = new ObjectValidation();

            if (ObjAttDL.DegreeLevelName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Degree Level Name cannot be Blank.";
                return OV;
            }

           
            return OV;
        }

        public static List<ATTDegreeLevel> GetDegreeLevel(int? degreeLevelId, string active)
        {
            List<ATTDegreeLevel> LstDegreeLevel = new List<ATTDegreeLevel>();
            
            try
            {
                

                foreach (DataRow row in DLLDegreeLevel.GetDegreeLevel(degreeLevelId, active).Rows)
                {
                    ATTDegreeLevel ObjAtt = new ATTDegreeLevel
                        (
                        int.Parse(row["DEGREE_LEVEL_ID"].ToString()),
                        row["DEGREE_LEVEL_NAME"].ToString(),
                        (row["ACTIVE"] == System.DBNull.Value) ? "" : (string)row["ACTIVE"]
                        );

                    List<ATTDegree> DegreeList = BLLDegree.GetDegree(null, "");

                    ObjAtt.LstDegree = DegreeList.FindAll(
                                                            delegate(ATTDegree Degree) 
                                                            { return ObjAtt.DegreeLevelID == Degree.DegreeLevelID; }
                                                          );

                    LstDegreeLevel.Add(ObjAtt);
                }
                return LstDegreeLevel;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public static bool SaveDegreeLevel(ATTDegreeLevel ObjAtt)
        {
            try
            {
                return DLLDegreeLevel.SaveDegreeLevel(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        
        public static bool DeleteDegreeLevel(int DegreeLevelID)
        {

            try
            {
                return DLLDegreeLevel.DeleteDegreeLevel(DegreeLevelID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}


