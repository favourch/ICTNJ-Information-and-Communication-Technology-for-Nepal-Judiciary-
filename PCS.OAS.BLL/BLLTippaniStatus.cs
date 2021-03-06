using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
    public class BLLTippaniStatus
    {
        public static System.Drawing.Color GetColor(int i)
        {
            System.Drawing.Color color = new System.Drawing.Color();
            switch (i)
            {
                case 1://initialize
                    color = System.Drawing.Color.Green;
                    break;
                case 2://recommend
                    color = System.Drawing.Color.Orange;
                    break;
                case 3://approve
                    color = System.Drawing.Color.Blue;
                    break;
                case 4://cancel
                    color = System.Drawing.Color.Red;
                    break;
                case 5://none
                    color = System.Drawing.Color.Orange;
                    break;
                default:
                    color = System.Drawing.Color.Green;
                    break;
            }
            return color;
        }

        public static List<ATTTippaniStatus> GetTippaniStatusList(bool containDefault)
        {
            List<ATTTippaniStatus> lst = new List<ATTTippaniStatus>();

            try
            {
                DataTable tbl = DLLTippaniStatus.GetTippaniStatusTable();
                foreach (DataRow row in tbl.Rows)
                {
                    ATTTippaniStatus status = new ATTTippaniStatus();

                    status.TippaniStatusID = int.Parse(row["Tippani_Status_ID"].ToString());
                    status.TippaniStatusName = row["Tippani_Status_Name"].ToString();
                    status.Action = "N";

                    lst.Add(status);
                }

                if (containDefault == true)
                {
                    ATTTippaniStatus d = new ATTTippaniStatus();
                    d.TippaniStatusID = -1;
                    d.TippaniStatusName = "---- स्थिति छन्नुहोस ----";

                    lst.Insert(0, d);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTTippaniStatus> GetTippaniStatusList(bool containDefault, string employeeType)
        {
            List<ATTTippaniStatus> lst = new List<ATTTippaniStatus>();

            try
            {
                DataTable tbl = DLLTippaniStatus.GetTippaniStatusTable();
                foreach (DataRow row in tbl.Rows)
                {
                    ATTTippaniStatus status = new ATTTippaniStatus();

                    status.TippaniStatusID = int.Parse(row["Tippani_Status_ID"].ToString());
                    status.TippaniStatusName = row["Tippani_Status_Name"].ToString();
                    status.Action = "N";

                    lst.Add(status);
                }

                if (employeeType == "REC" || employeeType == "OUT")
                {
                    lst.RemoveAll
                                (
                                    delegate(ATTTippaniStatus s)
                                    {
                                        return s.TippaniStatusID != 5 && s.TippaniStatusID != 4 && s.TippaniStatusID != 2;
                                    }
                                );
                }
                else if (employeeType == "APP")
                {
                    lst.RemoveAll
                                (
                                    delegate(ATTTippaniStatus s)
                                    {
                                        return s.TippaniStatusID != 5 && s.TippaniStatusID != 4 && s.TippaniStatusID != 3 && s.TippaniStatusID != 2;
                                    }
                                );
                }
                else if (employeeType == "ERR" || employeeType == "INI" || employeeType == null)
                {
                    lst.Clear();
                }

                if (containDefault == true)
                {
                    ATTTippaniStatus d = new ATTTippaniStatus();
                    d.TippaniStatusID = -1;
                    d.TippaniStatusName = "---- स्थिति छन्नुहोस ----";

                    lst.Insert(0, d);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
