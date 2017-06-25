using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLDurationType
    {

        public static List<ATTDurationType> GetDurationTypeList(int durationTypeID, string containDefaultValue)
        {
            List<ATTDurationType> DurationTypeLST = new List<ATTDurationType>();

            foreach (DataRow row in DLLDurationType.GetDurationTypeTable(durationTypeID).Rows)
            {
                ATTDurationType objDurationType = new ATTDurationType
                                                    (
                                                        int.Parse(row["DURATION_TYPE_ID"].ToString()),
                                                        row["DURATION_TYPE_NAME"].ToString(),
                                                        "A"
                                                    );

                DurationTypeLST.Add(objDurationType);
            }

            if (containDefaultValue=="Y")
                DurationTypeLST.Insert(0,new ATTDurationType(0,"--- Select Duration Type ---",""));
                                            

            return DurationTypeLST;
        }
    }
}
