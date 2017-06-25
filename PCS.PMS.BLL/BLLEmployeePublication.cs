using System;
using System.Collections.Generic;
using System.Text;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeePublication
    {
        public static List<ATTEmployeePublication> GetEmployeePublication(double empId, object obj)
        {
            List<ATTEmployeePublication> lst = new List<ATTEmployeePublication>();
            try
            {
                foreach (DataRow row in DLLEmployeePublication.GetEmployeePublication(empId,obj).Rows)
                {
                    ATTEmployeePublication pub = new ATTEmployeePublication();

                    pub.EmpID = double.Parse(row["Emp_ID"].ToString());
                    pub.PublicationID = int.Parse(row["pub_id"].ToString());
                    pub.PubTypeID = int.Parse(row["pub_type_id"].ToString());
                    pub.PublicationName = row["publication"].ToString();
                    pub.Publisher = row["Publisher_org"].ToString();
                    pub.PublicationDate = row["Publication_Date"].ToString();
                    pub.Action = "N";

                    lst.Add(pub);
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
