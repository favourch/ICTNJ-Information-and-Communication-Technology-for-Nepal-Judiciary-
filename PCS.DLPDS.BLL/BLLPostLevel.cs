using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
   public class BLLPostLevel
    {
       
        public static List<ATTPostLevel> GetPostLevel(int? PostId)
        {
            List<ATTPostLevel> LstPostLevel = new List<ATTPostLevel>();

            try
            {


                foreach (DataRow row in DLLPostLevel.GetPostLevel(PostId).Rows)
                {
                    ATTPostLevel ObjAtt = new ATTPostLevel
                        (
                        int.Parse(row["POST_ID"].ToString()),
                        int.Parse(row["LEVEL_ID"].ToString()),
                        row["LEVEL_NAME"].ToString(),
                        ""
                        );


                    LstPostLevel.Add(ObjAtt);
                }
                return LstPostLevel;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
    }
}
