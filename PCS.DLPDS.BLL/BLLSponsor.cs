using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;


namespace PCS.DLPDS.BLL
{
    public class BLLSponsor
    {
        public static ObjectValidation Validate(ATTSponsor objSponsor)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objSponsor.SponsorName== "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Sponsor Name Cannot be Blank.";
                return OV;
            }
            return OV;
        }



        public static bool AddProgram(ATTSponsor objSponsor)
        {
            try
            {
                DLLSponsor.AddSponsor(objSponsor);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTSponsor> GetSponsorList(int sponsorID, string containDefaultValue)
        {
            List<ATTSponsor> SponsorLST = new List<ATTSponsor >();

            foreach (DataRow row in DLLSponsor.GetSponsorTable(sponsorID).Rows)
            {
                ATTSponsor objSponsor = new ATTSponsor
                                                    (
                                                        int.Parse(row["SPONSOR_ID"].ToString()),
                                                        row["SPONSOR_Name"].ToString(),
                                                        "A"
                                                    );

                SponsorLST.Add(objSponsor);
            }
            if (containDefaultValue=="Y")
                SponsorLST.Insert(0,new ATTSponsor(0,"--- Select Sponsor ---",""));

            return SponsorLST;
        }
    }
}
