using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLRelationType
    {
        public static bool SaveRelationType(ATTRelationType obj)
        {
            try
            {
                return DLLRelationType.SaveRelationType(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTRelationType> GetRelationTypes(int? relationTypeID, int FlagForDefault)
        {
            List<ATTRelationType> lstRelationTypes = new List<ATTRelationType>();

            foreach (DataRow row in DLLRelationType.GetRelationType(relationTypeID).Rows)
            {
                ATTRelationType obj = new ATTRelationType(int.Parse(row["RELATION_TYPE_ID"].ToString()),
                                        ((row["RELATION_TYPE_NAME"] == System.DBNull.Value) ? "" : (string)row["RELATION_TYPE_NAME"]));
                int? relationTypeCardinality = null;
                if (row["RELATION_TYPE_CARDINALITY"] != System.DBNull.Value)
                    relationTypeCardinality = int.Parse(row["RELATION_TYPE_CARDINALITY"].ToString());
                obj.RelationTypeCardinality = relationTypeCardinality;
                lstRelationTypes.Add(obj);
            }
            if (FlagForDefault == 0)
                lstRelationTypes.Insert(0, new ATTRelationType(0, "छान्नुहोस"));

            return lstRelationTypes;
        }
    }
}
