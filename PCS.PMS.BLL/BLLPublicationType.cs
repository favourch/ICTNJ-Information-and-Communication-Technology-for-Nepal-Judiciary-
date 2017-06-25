using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLPublicationType
    {
        public static List<ATTPublicationType> GetPublicationType(int? pubtypeid,string active)
        {
            List<ATTPublicationType> LstPubType = new List<ATTPublicationType>();
            try
            {
                foreach (DataRow row in DLLPublicationType.GetPublicationType(pubtypeid, active).Rows)
                {
                    ATTPublicationType objPublicationType = new ATTPublicationType(
                                                                                        int.Parse(row["PUB_TYPE_ID"].ToString()),
                                                                                        row["PUB_TYPE_NAME"].ToString(),
                                                                                        row["ACTIVE"].ToString(),
                                                                                        ""
                                                                                   );
                    LstPubType.Add(objPublicationType);

                }
                return LstPubType;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SavePublicationType(ATTPublicationType ObjAtt)
        {
            try
            {
                return DLLPublicationType.SavePublicationType(ObjAtt);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
