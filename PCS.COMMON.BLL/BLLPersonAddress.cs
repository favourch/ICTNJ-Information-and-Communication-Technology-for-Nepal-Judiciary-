using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonAddress
    {
        public static List<ATTPersonAddress> GetPersonAddress(object obj, double personID)
        {
            List<ATTPersonAddress> AddressList = new List<ATTPersonAddress>();
            try
            {
                foreach (DataRow row in DLLPersonAddress.GetPersonAddress(personID, obj).Rows)
                {
                    int? district = null;
                    int? vdc = null;
                    int? ward = null;
                    if (row["DISTRICT"] != System.DBNull.Value)
                        district = int.Parse(row["DISTRICT"].ToString());
                    if (row["VDC"] != System.DBNull.Value)
                        vdc = int.Parse(row["VDC"].ToString());
                    if (row["WARD"] != System.DBNull.Value)
                        ward = int.Parse(row["WARD"].ToString());

                    ATTPersonAddress Address = new ATTPersonAddress(
                        double.Parse(row["P_ID"].ToString()), (string)row["ADTYPE_ID"],
                        int.Parse(row["AD_SNO"].ToString()), district, vdc, ward,
                        (row["TOLE"] == System.DBNull.Value ? "" : (string)row["TOLE"]),
                        "",
                        "", DateTime.Now);

                    if (row["NEP_DISTNAME"] != System.DBNull.Value)
                        Address.NepDistrictName = (string)row["NEP_DISTNAME"];
                    if (row["NEP_VDCNAME"] != System.DBNull.Value)
                        Address.NepVDCName = (string)row["NEP_VDCNAME"];
                    Address.AddressType = (string)row["ADDRESS_TYPE"];

                    AddressList.Add(Address);

                }
                return AddressList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}