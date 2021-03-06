using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLMemberPosition
    {

        public static ObjectValidation Validate(ATTMemberPosition obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.PositionName == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Member position name cannot be blank.";
                return result;
            }

            return result;
        }

        public static List<ATTMemberPosition> GetMemberPositionList(int? positionID, bool containDefault)
        {
            List<ATTMemberPosition> lst = new List<ATTMemberPosition>();
            try
            {
                foreach (DataRow row in DLLMemberPosition.GetMemberPositionTable(positionID).Rows)
                {
                    ATTMemberPosition obj = new ATTMemberPosition();

                    obj.PositionID = int.Parse(row["Position_ID"].ToString());
                    obj.PositionName = row["Position_Name"].ToString();
                    obj.Action = "E";

                    lst.Add(obj);
                }

                if (containDefault == true && lst.Count > 0)
                {
                    ATTMemberPosition def = new ATTMemberPosition();
                    def.PositionID = 0;
                    def.PositionName = "छान्नुहोस्";
                    lst.Insert(0, def);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMemberPosition(ATTMemberPosition member)
        {
            try
            {
                return DLLMemberPosition.AddMemberPosition(member);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
