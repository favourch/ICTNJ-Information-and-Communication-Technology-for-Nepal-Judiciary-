using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLCurrency
    {
        public static ObjectValidation Validate(ATTCurrency obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.CurrencyName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Currency name cannot be empty.";
                return OV;
            }

            return OV;
        }

        public static List<ATTCurrency> GetCurrencyList(int? currencyID)
        {
            List<ATTCurrency> lstCurrency = new List<ATTCurrency>();
            
            try
            {
                foreach (DataRow row in DLLCurrency.GetCurrencyTable(currencyID).Rows)
                {
                    ATTCurrency obj = new ATTCurrency
                                                    (
                                                        int.Parse(row["Currency_ID"].ToString()),
                                                        row["Currency_Name"].ToString()
                                                    );

                    lstCurrency.Add(obj);

                }
                return lstCurrency;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool AddCurrency(ATTCurrency obj,string username, string menuname)
        public static bool AddCurrency(ATTCurrency obj, Previlege pobj)
        {
            try
            {
                return DLLCurrency.AddCurrency(obj,pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool AddAuthor(ATTAuthor obj, Previlege pobj)
        //{
        //    try
        //    {
        //        return DLLAuthor.AddAuthor(obj, pobj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




        //public static bool EditCurrency(ATTCurrency obj, string username, string menuname)
        public static bool EditCurrency(ATTCurrency obj, Previlege pobj)
        {
            try
            {
                return DLLCurrency.EditCurrency(obj, pobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
