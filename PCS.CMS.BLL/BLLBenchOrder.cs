using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLBenchOrder
    {

        public static List<ATTBenchOrder> GetBenchAssignments(int? orgId, int? bench_type_id, string assignment_date)
        {
            List<ATTBenchOrder> lst = new List<ATTBenchOrder>();


            try
            {
                DataTable dt = DLLBenchOrder.GetBenchAssignments(orgId, bench_type_id, assignment_date);

                //DataColumn[] PK =
                //        {
                //            dt.Columns["ORG_ID"],
                //            dt.Columns["BENCH_TYPE_ID"],
                //            dt.Columns["BENCH_NO"],
                //            dt.Columns["FROM_DATE"],
                //            dt.Columns["SEQ_NO"],
                //            dt.Columns["CASE_ID"],
                //            dt.Columns["ASSIGNMENT_DATE"]
                //        };

               // dt.PrimaryKey = PK;

                foreach (DataRow row in dt.Rows)
                {

                    ATTBenchOrder obj = new ATTBenchOrder();
                    obj.CaseNumber = row["CASE_NUMBER"].ToString();
                    obj.CaseReg = row["REG_NUMBER"].ToString();
                    obj.Appelant = row["APPELLANT"].ToString();
                    obj.Respondent = row["RESPONDENT"].ToString();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.BenchTypeID = int.Parse(row["BENCH_TYPE_ID"].ToString());
                    obj.AssignmentDate = row["ASSIGNMENT_DATE"].ToString();
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.FromDate = row["FROM_DATE"].ToString();
                    obj.BenchNo = int.Parse(row["BENCH_NO"].ToString());
                    obj.Action = "N";
                    obj.CaseID = int.Parse(row["CASE_ID"].ToString());

                    //bool blnExists = lst.Exists
                    //(
                    //delegate(ATTBenchOrder o)
                    //{
                    //    return o.OrgID == obj.OrgID &&
                    //       o.BenchTypeID == obj.BenchTypeID &&
                    //       o.BenchNo == obj.BenchNo &&
                    //       o.FromDate == obj.FromDate &&
                    //       o.SeqNo == obj.SeqNo &&
                    //       o.CaseID == obj.CaseID &&
                    //       o.AssignmentDate == obj.AssignmentDate;
                    //}
                    //);

                    //if (blnExists == false)
                    //{
                    //    obj.LstBenchOrder = GetOrderList(dt, obj);
                    //    lst.Add(obj);
                    //}
                    lst.Add(obj);

                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //static List<BenchOrder> GetOrderList(DataTable tbl,ATTBenchOrder obj)
        //{
        //    //object[] PKvalues ={obj.OrgID,
        //    //               obj.BenchTypeID,
        //    //               obj.BenchNo ,
        //    //               obj.FromDate ,
        //    //               obj.SeqNo ,
        //    //               obj.CaseID ,
        //    //               obj.AssignmentDate };
        //    //foreach (DataRow row in tbl.Rows.Find(PKvalues))
        //    //{
                
        //    //}
        //    List<BenchOrder> lst = new List<BenchOrder>();
        //    string filter = "case_id ='"+obj.CaseID+"' and org_id='"+obj.OrgID+"' and bench_type_id='"+obj.BenchTypeID+"' and bench_no='"+obj.BenchNo+"' and from_date='"+obj.FromDate+"' and seq_no='"+obj.SeqNo+"' and assignment_date='"+obj.AssignmentDate+"'";
        //    foreach (DataRow row in tbl.Select(filter))
        //    {
        //        BenchOrder objBO = new BenchOrder();
        //        objBO.OrderName = row["ORDERS_NAME"].ToString();
        //        objBO.OrderID = int.Parse(row["ORDER_ID"].ToString());
        //        objBO.Action = "N";
        //        lst.Add(objBO);
        //    }
        //    return lst;
        //}

        public static List<ATTBenchOrder> GetBenchOrders(int orgId, int benchTypeId, int benchNo, string fromDate, int seqNo, int caseId, string assignmentDate)
        {
            List<ATTBenchOrder> lst = new List<ATTBenchOrder>();


            try
            {
                DataTable dt = DLLBenchOrder.GetBenchOrders(orgId, benchTypeId, benchNo, fromDate, seqNo, caseId, assignmentDate);

               foreach (DataRow row in dt.Rows)
                {

                    ATTBenchOrder obj = new ATTBenchOrder();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.BenchTypeID = int.Parse(row["BENCH_TYPE_ID"].ToString());
                    obj.BenchNo = int.Parse(row["BENCH_NO"].ToString());
                    obj.FromDate = row["FROM_DATE"].ToString();
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.CaseID = int.Parse(row["CASE_ID"].ToString());
                    obj.AssignmentDate = row["ASSIGNMENT_DATE"].ToString();

                    if (row["ORDERS_ID"] != DBNull.Value)
                    {
                        obj.OrderID = int.Parse(row["ORDERS_ID"].ToString());
                        obj.OrderName = row["ORDERS_NAME"].ToString();
                    }
                    else
                    {
                        obj.Remarks = row["REMARKS"].ToString();
                    }
                    obj.BoSeqNo = int.Parse(row["BO_SEQ_NO"].ToString());
                   
                    obj.Action = "N";
                  
                    lst.Add(obj);

                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateCaseBenchOrders(List<ATTBenchOrder> lstBenchOrders)
        {
            try
            {
                return DLLBenchOrder.UpdateBenchOrders(lstBenchOrders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
