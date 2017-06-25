using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.BLL
{
    public class BLLMaagFaaramHead
    {
        public static bool SaveMaagFaaramHead(ATTMaagFaaramHead objMaagFaaramHead)
        {
            try
            {
                if (DLLMaagFaaramHead.SaveMaagFaaramHead(objMaagFaaramHead))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool ApproveIssueMaag(ATTMaagFaaramHead objMaagFaaramHead)
        {
            try
            {
                if (DLLMaagFaaramHead.ApproveIssueMaag(objMaagFaaramHead))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<ATTMaagFaaramHead> GetMaagFaaramHead(ATTMaagFaaramHead objMaagFaaramHead)
        {
            List<ATTMaagFaaramHead> lstMaagFaaramHead = new List<ATTMaagFaaramHead>();

            foreach (DataRow row in DLLMaagFaaramHead.GetMaagFaaramHead(objMaagFaaramHead).Rows)
            {
                ATTMaagFaaramHead obj = new ATTMaagFaaramHead
                (
                ((row["ORG_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["ORG_ID"].ToString())),
                ((row["UNIT_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["UNIT_ID"].ToString())),
                ((row["REQ_NO"] == System.DBNull.Value) ? (double?)null : double.Parse(row["REQ_NO"].ToString())),
                ((row["REQ_DATE"] == System.DBNull.Value) ? "" : (row["REQ_DATE"].ToString())),
                ((row["REQ_BY"] == System.DBNull.Value) ? (double?)null : double.Parse(row["REQ_BY"].ToString())),
                ((row["ISSUE_TYPE"] == System.DBNull.Value) ? "" : (row["ISSUE_TYPE"].ToString()))
                );

                obj.OrgName = ((row["ORG_NAME"] == System.DBNull.Value) ? "" : (row["ORG_NAME"].ToString()));
                obj.UnitName = ((row["UNIT_NAME"] == System.DBNull.Value) ? "" : (row["UNIT_NAME"].ToString()));
                obj.ReqPerson = ((row["REQUEST_PERSON"] == System.DBNull.Value) ? "" : (row["REQUEST_PERSON"].ToString()));
                obj.ReqPurpose = ((row["REQ_PURPOSE"] == System.DBNull.Value) ? "" : (row["REQ_PURPOSE"].ToString()));
                obj.AppBy = ((row["APP_BY"] == System.DBNull.Value) ? (double?)null : double.Parse(row["APP_BY"].ToString()));
                obj.AppPerson = ((row["APPROVED_PERSON"] == System.DBNull.Value) ? "" : (row["APPROVED_PERSON"].ToString()));
                obj.AppDate = ((row["APP_DATE"] == System.DBNull.Value) ? "" : (row["APP_DATE"].ToString()));
                obj.AppYesNo = ((row["APP_YES_NO"] == System.DBNull.Value) ? "" : (row["APP_YES_NO"].ToString()));
                obj.IssueFlag = ((row["ISSUE_FLAG"] == System.DBNull.Value) ? "" : (row["ISSUE_FLAG"].ToString()));


                lstMaagFaaramHead.Add(obj);
            }
            return lstMaagFaaramHead;
        }
    }
}
