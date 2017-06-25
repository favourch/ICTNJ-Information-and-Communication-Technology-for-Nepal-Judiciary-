using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLPersonDocuments
    {
        public static List<ATTPersonDocuments> GetPersonDocuments(object obj, double personID, string personDocActive)
        {
            List<ATTPersonDocuments> DocumentsList = new List<ATTPersonDocuments>();
            try
            {
                foreach (DataRow row in DLLPersonDocuments.GetPersonDocuments(personID, obj, personDocActive).Rows)
                {
                    int? issuedFrom = null;
                    if (row["ISSUED_FROM"] != System.DBNull.Value)
                        issuedFrom = int.Parse(row["ISSUED_FROM"].ToString());
                    ATTPersonDocuments Documents = new ATTPersonDocuments(
                        double.Parse(row["P_ID"].ToString()),
                        int.Parse(row["DOC_TYPE_ID"].ToString()),
                        (row["DOC_NUMBER"] == System.DBNull.Value ? "" : (string)row["DOC_NUMBER"]),
                        issuedFrom,
                        (row["ISSUED_ON"] == System.DBNull.Value ? "" : (string)row["ISSUED_ON"]),
                        (row["ISSUED_BY"] == System.DBNull.Value ? "" : (string)row["ISSUED_BY"]),
                        "", "");

                    Documents.DocTypeName = (row["DOC_TYPE_NAME"] == System.DBNull.Value ? "" : (string)row["DOC_TYPE_NAME"]);
                    //Documents.NepDistName = (row["NEP_DISTNAME"] == System.DBNull.Value ? "" : (string)row["NEP_DISTNAME"]);
                    Documents.DistUcodeName = (row["DIST_UCODE"] == System.DBNull.Value ? "" : (string)row["DIST_UCODE"]);

                    DocumentsList.Add(Documents);
                }
                return DocumentsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}