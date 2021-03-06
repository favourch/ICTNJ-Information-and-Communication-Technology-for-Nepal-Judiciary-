using System;
using System.Collections.Generic;
using System.Text;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.LJMS.BLL
{
    public class BLLUnit
    {
        public static List<ATTUnit> GetUnitList(string status, bool containDefault)
        {
            List<ATTUnit> lst = new List<ATTUnit>();

            try
            {
                DataTable tbl = DLLUnit.GetUnitTable(status);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTUnit unit = new ATTUnit();
                    unit.UnitID = int.Parse(row["Unit_id"].ToString());
                    unit.UnitName = row["Unit_name"].ToString();
                    unit.UnitAddress = row["Unit_Address"].ToString();
                    unit.UnitPhone = row["Unit_Phone"].ToString();
                    unit.Active = row["active"].ToString();
                    unit.Action = "N";

                    lst.Add(unit);
                }
                if (lst.Count > 0 && containDefault == true)
                {
                    ATTUnit def = new ATTUnit();
                    def.UnitID = -1;
                    def.UnitName = "छान्नुहोस्";
                    lst.Insert(0, def);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddUnit(ATTUnit unit)
        {
            try
            {
                return DLLUnit.AddUnit(unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
