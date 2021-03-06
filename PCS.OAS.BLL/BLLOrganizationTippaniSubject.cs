using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLOrganizationTippaniSubject
    {
        public static List<ATTOrganizationTippaniSubject> GetOrganizaionTippaniSubjectList(int orgID,int? subjectID, bool containtDefault)
        {
            List<ATTOrganizationTippaniSubject> lst = new List<ATTOrganizationTippaniSubject>();

            try
            {
                List<ATTTippaniChannel> channelLst = BLLTippaniChannel.GetTippaniChannelList(orgID, subjectID);
                foreach (DataRow row in DLLOrganizationTippaniSubject.GetOrganizaionTippaniSubject(orgID).Rows)
                {
                    ATTOrganizationTippaniSubject obj = new ATTOrganizationTippaniSubject();
                    
                    obj.OrgID = int.Parse(row["org_id"].ToString());
                    obj.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    obj.TippaniSubjectName = row["tippani_subject_name"].ToString();
                    obj.FromDate = row["from_date"].ToString();
                    obj.ToDate = row["to_date"].ToString();

                    obj.LstTippaniChannel = channelLst.FindAll
                                                                (
                                                                    delegate(ATTTippaniChannel c)
                                                                    {
                                                                        return c.OrgID == obj.OrgID
                                                                            && c.TippaniSubjectID == obj.TippaniSubjectID;
                                                                    }
                                                                );


                    lst.Add(obj);
                }
                if (lst.Count > 0 && containtDefault == true)
                {
                    ATTOrganizationTippaniSubject obj = new ATTOrganizationTippaniSubject();

                    obj.OrgID = -1;
                    obj.TippaniSubjectID = -1;
                    obj.TippaniSubjectName = "---- टिप्पणी बिषय छन्नुहोस ----";
                    lst.Insert(0, obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool AddOrganizationTippaniSubject(List<ATTOrganizationTippaniSubject> lstOrgTippaniSubject)
        {
            try
            {
                return DLLOrganizationTippaniSubject.AddOrganizationTippaniSubject(lstOrgTippaniSubject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
