using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLGroupPersonSearch
    {
        public static List<ATTGroupPersonSearch> GetEmployeeFromWorkDistribution(ATTGroupPersonSearch person, string applicationlst)
        {
            List<ATTGroupPersonSearch> lst = new List<ATTGroupPersonSearch>();

            try
            {
                foreach (DataRow row in DLLGroupPersonSearch.GetEmployeeFromWorkDistribution(person, applicationlst).Rows)
                {
                    ATTGroupPersonSearch obj = new ATTGroupPersonSearch();

                    obj.PersonID = double.Parse(row["emp_id"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MiddleName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                    obj.Gender = row["gender"].ToString();
                    obj.DOB = row["DOB"].ToString();
                    //obj.MaritalStatus = row["MARTIAL_STATUS"].ToString();
                    obj.MaritalStatus = "";
                    //obj.District = row["ENG_DISTNAME"].ToString();
                    obj.District = "";
                    obj.IniType = row["org_name"].ToString();
                    obj.PostName = row["des_name"].ToString();
                    obj.UnitID = int.Parse(row["org_unit_id"].ToString());
                    obj.UnitName = row["unit_name"].ToString();
                    obj.UnitFromDate = row["unit_from_date"].ToString();
                    //obj.ApplicationID = int.Parse(row["INI_TYPE"].ToString());
                    obj.OrgID = row["org_id"].ToString() == "" ? 0 : int.Parse(row["org_id"].ToString());
                    obj.DesID = row["des_id"].ToString() == "" ? 0 : int.Parse(row["des_id"].ToString());
                    obj.CreatedDate = row["created_date"].ToString();
                    obj.PostID = row["post_id"].ToString() == "" ? 0 : int.Parse(row["post_id"].ToString());
                    obj.PostFromDate = row["from_date"].ToString();

                    if (person.GroupID > 0 || person.GMPositionID > 0)
                    {
                        obj.GroupName = row["group_name"].ToString();
                        obj.GMPositionName = row["gm_position"].ToString();
                    }

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGroupPersonSearch> GetGroupPersonWithEmployee(ATTGroupPersonSearch person, string applicationlst)
        {
            List<ATTGroupPersonSearch> lst = new List<ATTGroupPersonSearch>();

            try
            {
                foreach (DataRow row in DLLGroupPersonSearch.GetGroupPersonWithEmployee(person, applicationlst).Rows)
                {
                    ATTGroupPersonSearch obj = new ATTGroupPersonSearch();

                    obj.PersonID = double.Parse(row["p_id"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MiddleName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                    obj.Gender = row["gender"].ToString();
                    obj.DOB = row["DOB"].ToString();
                    obj.MaritalStatus = row["MARTIAL_STATUS"].ToString();
                    obj.District = row["ENG_DISTNAME"].ToString();
                    obj.IniType = row["org_name"].ToString();
                    obj.PostName = row["des_name"].ToString();
                    obj.ApplicationID = int.Parse(row["INI_TYPE"].ToString());
                    obj.OrgID = row["org_id"].ToString() == "" ? 0 : int.Parse(row["org_id"].ToString());
                    obj.DesID = row["des_id"].ToString() == "" ? 0 : int.Parse(row["des_id"].ToString());
                    obj.CreatedDate = row["des_id"].ToString();
                    obj.PostID = row["post_id"].ToString() == "" ? 0 : int.Parse(row["post_id"].ToString());
                    obj.PostFromDate = row["post_from_date"].ToString();

                    if (person.GroupID > 0 || person.GMPositionID > 0)
                    {
                        obj.GroupName = row["group_name"].ToString();
                        obj.GMPositionName = row["gm_position"].ToString();
                    }

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGroupPersonSearch> GetEmployeeWithPosting(ATTGroupPersonSearch person, string applicationlst)
        {
            List<ATTGroupPersonSearch> lst = new List<ATTGroupPersonSearch>();

            try
            {
                foreach (DataRow row in DLLGroupPersonSearch.GetEmployeeWithPosting(person, applicationlst).Rows)
                {
                    ATTGroupPersonSearch obj = new ATTGroupPersonSearch();

                    obj.PersonID = double.Parse(row["p_id"].ToString());
                    obj.FirstName = row["first_name"].ToString();
                    obj.MiddleName = row["mid_name"].ToString();
                    obj.SurName = row["sur_name"].ToString();
                    obj.Gender = row["gender"].ToString();
                    obj.DOB = row["DOB"].ToString();
                    obj.MaritalStatus = row["MARTIAL_STATUS"].ToString();
                    obj.District = row["ENG_DISTNAME"].ToString();
                    obj.IniType = row["org_name"].ToString();
                    obj.PostName = row["des_name"].ToString();
                    obj.ApplicationID = int.Parse(row["INI_TYPE"].ToString());
                    obj.OrgID = row["org_id"].ToString() == "" ? 0 : int.Parse(row["org_id"].ToString());
                    obj.DesID = row["des_id"].ToString() == "" ? 0 : int.Parse(row["des_id"].ToString());
                    obj.CreatedDate = row["des_id"].ToString();
                    obj.PostID = row["post_id"].ToString() == "" ? 0 : int.Parse(row["post_id"].ToString());
                    obj.PostFromDate = row["post_from_date"].ToString();

                    if (person.GroupID > 0 || person.GMPositionID > 0)
                    {
                        obj.GroupName = row["group_name"].ToString();
                        obj.GMPositionName = row["gm_position"].ToString();
                    }

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
