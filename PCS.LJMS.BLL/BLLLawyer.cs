using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;

namespace PCS.LJMS.BLL
{
    public class BLLLawyer
    {

        //public static DataTable tblL;
        //public static DataTable tblLR;
        //public static DataTable tblPL;
        //public static DataTable tblPLR;

        public static bool UpdateLawyerDetails(ATTLawyerInfoSearch objLInfo)
        {
            try
            {
                if (DLLLawyer.UpdateLawyerInfo(objLInfo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


        public static bool SaveLawyerDetails(ATTLawyer objLawyer)
        {
            try
            {
                if (DLLLawyer.SaveLawyerDetails(objLawyer))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<ATTLawyer> GetLawyerDetails(double PID)
        {
            try
            {
                List<ATTLawyer> lst = new List<ATTLawyer>();

                DataTable tblL = DLLLawyer.GetLawyerDetailTable(PID);
                DataTable tblLR = BLLLawyerRenewal.GetLawyerRenewalDetails(PID);
                DataTable tblPL = BLLPrivateLawyer.GetPrivateLawyerDetails(PID);
                DataTable tblPLR = BLLPrivateLawyerRenewal.GetPrivateLawyerRenewalDetails(PID);

                foreach (DataRow row in tblL.Rows)
                {
                    ATTLawyer objLawyer = new ATTLawyer();
                    objLawyer.PID = int.Parse(row["P_ID"].ToString());
                    objLawyer.LawyerTypeID = int.Parse(row["LAWYER_TYPE_ID"].ToString());
                    objLawyer.LawyerTypeName = row["lawyer_type_description"].ToString(); 
                    objLawyer.LicenseNo = row["LICENSE_NO"].ToString();
                    objLawyer.FromDate = row["FROM_DATE"].ToString();

                    if (tblLR.Rows.Count > 0)
                    {
                        objLawyer.LstLawyerRenewal = SetLawyerRenewal(objLawyer,tblLR);
                    }

                    if (tblPL.Rows.Count > 0)
                    {
                        objLawyer.LstPrivateLawyer = SetPrivateLawyer(objLawyer,tblPL,tblPLR);
                    }

                    lst.Add(objLawyer);
                }

                return lst;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        private static List<ATTLawyerRenewal> SetLawyerRenewal(ATTLawyer objLawyer, DataTable tblLR)
        {
            try
            {
                List<ATTLawyerRenewal> lstLawyerRenewal = new List<ATTLawyerRenewal>();

                foreach (DataRow row in tblLR.Rows)
                {
                    if (objLawyer.PID == int.Parse(row["P_ID"].ToString()) &&
                        objLawyer.LawyerTypeID == int.Parse(row["LAWYER_TYPE_ID"].ToString()) &&
                        objLawyer.LicenseNo == row["LICENSE_NO"].ToString()
                       )
                    {
                        ATTLawyerRenewal objLawyerRenewal = new ATTLawyerRenewal();
                        objLawyerRenewal.PID = int.Parse(row["P_ID"].ToString());
                        objLawyerRenewal.LawyerTypeID = int.Parse(row["LAWYER_TYPE_ID"].ToString());
                        objLawyerRenewal.LawyerTypeName = row["lawyer_type_description"].ToString();
                        objLawyerRenewal.LicenseNo = row["LICENSE_NO"].ToString();
                        objLawyerRenewal.RenewalDate = row["RENEWAL_DATE"].ToString();
                        objLawyerRenewal.RenewalUpto = row["RENEWAL_UPTO"].ToString();
                        objLawyerRenewal.Action = "N";

                        lstLawyerRenewal.Add(objLawyerRenewal);
                        
                    }

                    
                }

                return lstLawyerRenewal;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private static List<ATTPrivateLawyer> SetPrivateLawyer(ATTLawyer objLawyer, DataTable tblPL, DataTable tblPLR)
        {
            try
            {
                List<ATTPrivateLawyer> lstPrivateLawyer = new List<ATTPrivateLawyer>();

                foreach (DataRow row in tblPL.Rows)
                {
                    if (objLawyer.PID == int.Parse(row["P_ID"].ToString()) &&
                        objLawyer.LawyerTypeID == int.Parse(row["LAWYER_TYPE_ID"].ToString()) &&
                        objLawyer.LicenseNo == row["LICENSE_NO"].ToString()
                       )
                    {
                        ATTPrivateLawyer objPrivateLawyer = new ATTPrivateLawyer();
                        objPrivateLawyer.PersonID = int.Parse(row["P_ID"].ToString());
                        objPrivateLawyer.LawyerTypeID = int.Parse(row["LAWYER_TYPE_ID"].ToString());
                        objPrivateLawyer.Lisence = row["LICENSE_NO"].ToString();
                        objPrivateLawyer.FromDate = row["P_FROM_DATE"].ToString();
                        objPrivateLawyer.UnitID = int.Parse(row["UNIT_ID"].ToString());
                        objPrivateLawyer.UnitName = row["unit_name"].ToString();
                        objPrivateLawyer.ToDate = "";
                        objPrivateLawyer.EntryBy = "";
                        objPrivateLawyer.Action = "N";

                        if (tblPLR.Rows.Count > 0)
                        {
                            objPrivateLawyer.LstRenewal = SetPrivateLawyerRenewal(objPrivateLawyer, tblPLR);
                        }
                        //P_ID,LAWYER_TYPE_ID,LICENSE_NO,P_FROM_DATE,UNIT_ID

                        lstPrivateLawyer.Add(objPrivateLawyer);

                    }


                }

                return lstPrivateLawyer;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private static List<ATTPrivateLawyerRenewal> SetPrivateLawyerRenewal(ATTPrivateLawyer objPrivateLawyer, DataTable tblPLR)
        {
            try
            {
                List<ATTPrivateLawyerRenewal> lstPrivateLawyerRenewal = new List<ATTPrivateLawyerRenewal>();

                foreach (DataRow row in tblPLR.Rows)
                {
                    if (objPrivateLawyer.PersonID == int.Parse(row["P_ID"].ToString()) &&
                        objPrivateLawyer.LawyerTypeID == int.Parse(row["LAWYER_TYPE_ID"].ToString()) &&
                        objPrivateLawyer.Lisence == row["LICENSE_NO"].ToString() &&
                        objPrivateLawyer.UnitID == int.Parse(row["UNIT_ID"].ToString())
                       )
                    {
                        ATTPrivateLawyerRenewal objPrivateLawyerRenewal = new ATTPrivateLawyerRenewal();
                        objPrivateLawyerRenewal.PersonID = int.Parse(row["P_ID"].ToString());
                        objPrivateLawyerRenewal.LawyerTypeID = int.Parse(row["LAWYER_TYPE_ID"].ToString());
                        objPrivateLawyerRenewal.Lisence = row["LICENSE_NO"].ToString();
                        objPrivateLawyerRenewal.UnitID = int.Parse(row["UNIT_ID"].ToString());
                        objPrivateLawyerRenewal.UnitName = row["unit_name"].ToString();
                        objPrivateLawyerRenewal.FromDate = row["P_FROM_DATE"].ToString(); 
                        objPrivateLawyerRenewal.RenewalDate = row["P_RENEWAL_DATE"].ToString();
                        objPrivateLawyerRenewal.RenewalUpto = row["P_RENEWAL_UPTO"].ToString();
                        objPrivateLawyerRenewal.EntryBy = "";
                        objPrivateLawyerRenewal.Action = "N";

                        lstPrivateLawyerRenewal.Add(objPrivateLawyerRenewal);
                    }
                }

                return lstPrivateLawyerRenewal;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }
}
