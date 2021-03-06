using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLOrganisationBenchType
    {
        public static bool SaveOrganisationBenchType(List<ATTOrganisationBenchType> BenchTypeLst)
        {
            try
            {
                return DLLOrganisationBenchType.SaveOrganisationBenchType(BenchTypeLst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTOrganisationBenchType> GetOrganisationBenchType(int? OrgID, int? BenchTypeID, string active)
        {
            List<ATTOrganisationBenchType> OrganisationBenchTypeLST = new List<ATTOrganisationBenchType>();
            try
            {
                foreach (DataRow row in DLLOrganisationBenchType.GetOrganisationBenchType(OrgID, BenchTypeID, active).Rows)
                {
                    ATTOrganisationBenchType objOrganisationBenchType = new ATTOrganisationBenchType();

                    objOrganisationBenchType.OrganisationID = int.Parse(row["ORG_ID"].ToString());
                    objOrganisationBenchType.OrganisationName = row["ORG_NAME"].ToString();
                    objOrganisationBenchType.BenchTypeID = int.Parse(row["BENCH_TYPE_ID"].ToString());
                    objOrganisationBenchType.BenchTypeName = row["BENCH_TYPE_NAME"].ToString();                    
                    objOrganisationBenchType.Active = row["ACTIVE"].ToString();

                    OrganisationBenchTypeLST.Add(objOrganisationBenchType);
                }

                //if (defaultFlag > 0)
                //{
                //    ATTOrganisationBenchType obj = new ATTOrganisationBenchType();
                //    obj.BenchTypeID = 0;
                //    obj.BenchTypeName = "छान्नुहोस";
                //    OrganisationBenchTypeLST.Insert(0, obj);

                //}
                return OrganisationBenchTypeLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
