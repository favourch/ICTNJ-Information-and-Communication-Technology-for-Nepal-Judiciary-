using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
   public  class BLLPost
    {

        public static ObjectValidation Validate(ATTPost ObjAttDL)
        {
            ObjectValidation OV = new ObjectValidation();

            if (ObjAttDL.PostName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Post Name cannot be Blank.";
                return OV;
            }


            return OV;
        }

        public static List<ATTPost> GetPost(int? PostId)
        {
            List<ATTPost> LstPost = new List<ATTPost>();

            try
            {


                foreach (DataRow row in DLLPost.GetPost(PostId).Rows)
                {
                    ATTPost ObjAtt = new ATTPost
                        (
                        int.Parse(row["POST_ID"].ToString()),
                        row["POST_NAME"].ToString()
                        );
                    List<ATTPostLevel> PostLevelList = BLLPostLevel.GetPostLevel(ObjAtt.PostID);

                    ObjAtt.LstPostLevel = PostLevelList.FindAll(delegate(ATTPostLevel att) { return att.PostID == ObjAtt.PostID; });

                    LstPost.Add(ObjAtt);
                }
                return LstPost;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SavePost(ATTPost ObjAtt)
        {
            try
            {
                return DLLPost.SavePost(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static bool DeletePost(int PostID)
        {

            try
            {
                return DLLPost.DeletePost(PostID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
