using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;

namespace PCS.DLPDS.BLL
{
    public class BLLParticipantSearch
    {
        public static List<ATTParticipantSearch> SearchParticipant(ATTParticipantSearch objParticipant)
        {
            List<ATTParticipantSearch> lstParticipant = new List<ATTParticipantSearch>();

            foreach (DataRow row in DLLParticipantSearch.SearchParticipant(objParticipant).Rows)
            {
                ATTParticipantSearch obj = new ATTParticipantSearch(double.Parse(row["P_ID"].ToString()),
                    ((row["FIRST_NAME"] == System.DBNull.Value) ? "" : (string)row["FIRST_NAME"]),
                    ((row["MID_NAME"] == System.DBNull.Value) ? "" : (string)row["MID_NAME"]),
                    ((row["SUR_NAME"] == System.DBNull.Value) ? "" : (string)row["SUR_NAME"]),
                    ((row["GENDER"] == System.DBNull.Value) ? "" : (string)row["GENDER"]),
                    ((row["DOB"] == System.DBNull.Value) ? "" : (string)row["DOB"]),
                    ((row["NEP_DISTNAME"] == System.DBNull.Value) ? "" : (string)row["NEP_DISTNAME"]),
                    ((row["FATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["FATHER_NAME"]),
                    ((row["GFATHER_NAME"] == System.DBNull.Value) ? "" : (string)row["GFATHER_NAME"]));

                lstParticipant.Add(obj);
            }
            return lstParticipant;
        }
    }
}
