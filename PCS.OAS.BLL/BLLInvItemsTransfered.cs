using System;
using System.Collections.Generic;
using System.Text;


using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;


namespace PCS.OAS.BLL
{
   public class BLLInvItemsTransfered
    {
       
       public static bool SaveItemsTransfer(List<ATTInvItemsTransfered> LSTItemsTrans, string opt)
        {
            try
            {
                return DLLInvItemsTransfered.SaveItemsTransfer(LSTItemsTrans, opt);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
       public static List<ATTInvItemsTransfered> GetItemsTransfKBJList()
       {
           List<ATTInvItemsTransfered> lstItemsTransKBJLst = new List<ATTInvItemsTransfered>();
           try
           {
               foreach (DataRow row in DLLInvItemsTransfered.getItemsTransKBJ().Rows)
               {
                   ATTInvItemsTransfered obj = new ATTInvItemsTransfered();
                   obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                   obj.TransSEQ = int.Parse(row["TRFD_SEQ"].ToString());
                   obj.TransORG = int.Parse(row["TRFD_ORG"].ToString());
                   obj.TransfOrgName = row["TRFD_ORG_NAME"].ToString();
                   obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                   obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                   obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                   obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                   obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                   obj.ItemsName = row["ITEMS_NAME"].ToString();
                   obj.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                   obj.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                   obj.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                   obj.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                   obj.Quantity = int.Parse(row["QUANTITY"].ToString());
                   obj.DecisionDate = row["DECISION_DATE"].ToString();
                   obj.TransDate = row["TRFD_DATE"].ToString();
                   obj.TransVia = int.Parse(row["TRFD_VIA"].ToString());
                   obj.TransOrgUnit = int.Parse(row["TRFD_ORG_UNIT"].ToString());
                   obj.TransTo = int.Parse(row["TRFD_TO"].ToString());
                   if (row["TRFD_RCVD_BY"].ToString() != "")
                   {
                       obj.TransRecvBy = int.Parse(row["TRFD_RCVD_BY"].ToString());
                   }
                   else
                   {
                       obj.TransRecvBy = null;
                   }
                   obj.TransRecvDate = row["TRFD_RCVD_DATE"].ToString();
                   lstItemsTransKBJLst.Add(obj);
               }
               return lstItemsTransKBJLst;

           }
           catch (Exception)
           {

               throw;
           }
        
       }
       public static List<ATTInvItemsTransfered> GetItemsTransfKNJList()
       {
           List<ATTInvItemsTransfered> lstItemsTransKNJLst = new List<ATTInvItemsTransfered>();
           try
           {
               foreach (DataRow row in DLLInvItemsTransfered.getItemsTransfKNJ().Rows)
               {
                   ATTInvItemsTransfered obj = new ATTInvItemsTransfered();
                   obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                   obj.TransSEQ = int.Parse(row["TRFD_SEQ"].ToString());
                   obj.TransORG = int.Parse(row["TRFD_ORG"].ToString());
                   obj.TransfOrgName = row["TRFD_ORG_NAME"].ToString();
                   obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                   obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                   obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                   obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                   obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                   obj.ItemsName = row["ITEMS_NAME"].ToString();
                   obj.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                   obj.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                   obj.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                   obj.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                   // obj.Quantity = int.Parse(row["QUANTITY"].ToString());
                   obj.DecisionDate = row["DECISION_DATE"].ToString();
                   obj.TransDate = row["TRFD_DATE"].ToString();
                   obj.TransVia = int.Parse(row["TRFD_VIA"].ToString());
                   obj.TransOrgUnit = int.Parse(row["TRFD_ORG_UNIT"].ToString());
                   obj.TransTo = int.Parse(row["TRFD_TO"].ToString());
                   obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                   if (row["TRFD_RCVD_BY"].ToString() != "")
                   {
                       obj.TransRecvBy = int.Parse(row["TRFD_RCVD_BY"].ToString());
                   }
                   else
                   {
                       obj.TransRecvBy = null;
                   }
                   obj.TransRecvDate = row["TRFD_RCVD_DATE"].ToString();
                   lstItemsTransKNJLst.Add(obj);
               }
               return lstItemsTransKNJLst;

           }
           catch (Exception)
           {

               throw;
           }
       }
       public static List<ATTInvItemType> GetItemsType(int? itemsTypeID, string active)
       { 
           List<ATTInvItemType> LstItemType = new List<ATTInvItemType>();

           try
           {
               foreach (DataRow  row in DLLInvItemsTransfered.getItemsType(itemsTypeID,active).Rows)
               {
                   ATTInvItemType obj = new ATTInvItemType();
                   obj.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                   obj.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                   obj.Active = row["ACTIVE"].ToString();
                   LstItemType.Add(obj);
               }
               return LstItemType;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

     

       //public static List<ATTEmployeeWorkDivision> SearchEmployee(ATTEmployeeWorkDivision objEmpDiv)
       //{
       //    try
       //    {
       //        List<ATTEmployeeWorkDivision> LSTWrkDiv = new List<ATTEmployeeWorkDivision>();
       //        foreach (DataRow row in DLLEmployeeWorkDivision.SearchEmployee(objEmpDiv).Rows)
       //        {
       //            ATTEmployeeWorkDivision obj = new ATTEmployeeWorkDivision();
       //            obj.EmpID = int.Parse(row["EMP_ID"].ToString());
       //            string first_name = row["FIRST_NAME"].ToString();
       //            string mid_name = row["MID_NAME"].ToString();
       //            string sur_name = row["SUR_NAME"].ToString();
       //            if (mid_name != "")
       //            {
       //                obj.FullName = first_name + " " + mid_name + " " + sur_name;
       //            }
       //            else
       //            {
       //                obj.FullName = first_name + " " + sur_name;
       //            }
       //            //obj.OrgEmpNo = int.Parse(row["ORG_EMP_NO"].ToString());
       //            obj.Gender = row["GENDER"].ToString();
       //            obj.OrgID = int.Parse(row["ORG_ID"].ToString());
       //            obj.OrgName = row["ORG_NAME"].ToString();
       //            obj.DesID = int.Parse(row["DES_ID"].ToString());
       //            obj.DesName = row["DES_NAME"].ToString();
       //            obj.DesType = row["DES_TYPE"].ToString();
       //            obj.CreatedDate = row["CREATED_DATE"].ToString();
       //            obj.PostID = int.Parse(row["POST_ID"].ToString());
       //            obj.FromDate = row["FROM_DATE"].ToString();
       //            if (row["ORG_UNIT_ID"] != System.DBNull.Value)
       //            {
       //                obj.OrgUnitID = int.Parse(row["ORG_UNIT_ID"].ToString());
       //            }
       //            obj.UnitName = row["UNIT_NAME"].ToString();
       //            obj.UnitType = row["UNIT_TYPE"].ToString();
       //            //if (row["SECTION_ID"]!= System.DBNull.Value)
       //            //{
       //            //    obj.SectionID = int.Parse(row["SECTION_ID"].ToString());
       //            //}
       //            //obj.SectionName=row["SECTION_NAME"].ToString();
       //            obj.UnitFromDate = row["UNIT_FROM_DATE"].ToString();
       //            obj.ToDate = row["TO_DATE"].ToString();
       //            obj.Responsibility = row["RESPONSIBILITY"].ToString();
       //            obj.IsHeadOfUnit = row["UNIT_HEAD"].ToString();
       //            obj.Action = "";
       //            LSTWrkDiv.Add(obj);
       //        }
       //        return LSTWrkDiv;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw ex;
       //    }
       //}    
    }
}
