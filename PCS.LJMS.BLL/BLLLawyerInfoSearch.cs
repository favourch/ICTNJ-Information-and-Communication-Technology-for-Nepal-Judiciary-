using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.LJMS.ATT;
using PCS.LJMS.DLL;

namespace PCS.LJMS.BLL
{
    public class BLLLawyerInfoSearch
    {
        public static List<ATTLawyerInfoSearch> GetLawyerInfoSearchList(ATTLawyerInfoSearch objLIsrch)
        {
            List<ATTLawyerInfoSearch> lst = new List<ATTLawyerInfoSearch>();
            try
            {
                DataTable tbl = DLLLawyerInfoSearch.GetLawyerInfoSearchTbl(objLIsrch);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTLawyerInfoSearch obj = new ATTLawyerInfoSearch();
                    obj.PERSONID = double.Parse(row["p_id"].ToString());
                    obj.FNAME = row["FIRST_NAME"].ToString();
                    obj.MNAME = row["MID_NAME"].ToString() == "" ? "" : row["MID_NAME"].ToString();
                    obj.LNAME = row["SUR_NAME"].ToString();
                    obj.LICENSENO = row["license_no"].ToString();
                    obj.LTYPEID = int.Parse(row["lawyer_type_id"].ToString());
                    obj.LTYPE = row["lawyer_type_description"].ToString();
                    obj.LRENEWALUPTO = row["lawyer_last_ren_date"].ToString();
                    obj.ACTIVE = row["active"].ToString();

                    int? unitId;

                    if (row["unit_id"].ToString() == "")
                        unitId = null;
                    else
                        unitId = int.Parse(row["unit_id"].ToString());

                    obj.UNITID = unitId;
                    obj.UNITNAME =  row["unit_name"].ToString() == "" ? "" : row["unit_name"].ToString();
                    obj.PLRENEWALUPTO = row["p_lawyer_last_ren_date"].ToString() == "" ? "" : row["p_lawyer_last_ren_date"].ToString();

                    if (obj.LRENEWALUPTO != null && obj.LRENEWALUPTO != "")
                    {
                        obj.DISPLAYDATE = obj.LRENEWALUPTO;
                    }
                    else if (obj.PLRENEWALUPTO != null && obj.PLRENEWALUPTO != "")
                    {
                        obj.DISPLAYDATE = obj.PLRENEWALUPTO;
                    }
                    else
                        obj.DISPLAYDATE = "";


                    lst.Add(obj);
                                       
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTLawyerInfoSearch> getDuplicateEntry(string strFilter)
        {
            List<ATTLawyerInfoSearch> lst = new List<ATTLawyerInfoSearch>();
            try
            {
                foreach (DataRow row in DLLLawyerInfoSearch.GetDuplicateLawyer(strFilter).Rows)
                {
                    ATTLawyerInfoSearch obj = new ATTLawyerInfoSearch();
                    obj.PERSONID = double.Parse(row["p_id"].ToString());
                    obj.FNAME = row["FIRST_NAME"].ToString();
                    obj.MNAME = row["MID_NAME"].ToString() == "" ? "" : row["MID_NAME"].ToString();
                    obj.LNAME = row["SUR_NAME"].ToString();
                    obj.LICENSENO = row["license_no"].ToString();
                    obj.LTYPEID = int.Parse(row["lawyer_type_id"].ToString());
                    obj.LTYPE = row["lawyer_type_description"].ToString();
                    obj.LRENEWALUPTO = row["lawyer_last_ren_date"].ToString();

                    int? unitId;

                    if (row["unit_id"].ToString() == "")
                        unitId = null;
                    else
                        unitId = int.Parse(row["unit_id"].ToString());

                    obj.UNITID = unitId;
                    obj.UNITNAME = row["unit_name"].ToString() == "" ? "" : row["unit_name"].ToString();
                    obj.PLRENEWALUPTO = row["p_lawyer_last_ren_date"].ToString() == "" ? "" : row["p_lawyer_last_ren_date"].ToString();

                    lst.Add(obj);
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
