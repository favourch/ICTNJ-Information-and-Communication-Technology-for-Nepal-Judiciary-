using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;

namespace PCS.DLPDS.BLL
{
    public class BLLProgramType
    {
        public static List<ATTProgramType> GetProgramTypeList(int programTypeID, string containDefaultValue)
        {
            List<ATTProgramType> ProgramTypeLST = new List<ATTProgramType>();

            foreach (DataRow row in DLLProgramType.GetProgramTypeTable(programTypeID).Rows)
            {
                ATTProgramType objProgramType = new ATTProgramType
                                                    (
                                                        int.Parse(row["PRG_TYPE_ID"].ToString()),
                                                        row["PRG_TYPE_NAME"].ToString(),
                                                        "A"
                                                    );

                ProgramTypeLST.Add(objProgramType);
            }
            if (containDefaultValue == "Y")
                ProgramTypeLST.Insert(0,new ATTProgramType(0, "--- Select Program Type ---", ""));

            return ProgramTypeLST;
        }
    }
}
