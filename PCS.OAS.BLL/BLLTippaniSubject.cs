using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.OAS.BLL
{
    public class BLLTippaniSubject
    {
        public static List<ATTTippaniSubject> GetTippaniSubjectList(int orgID, bool containDefault)
        {
            List<ATTTippaniSubject> lst = new List<ATTTippaniSubject>();
            try
            {
                DataTable tbl = DLLTippaniSubject.GetTippaniSubjectList(orgID);
                //List<ATTTippaniChannel> channelLst = BLLTippaniChannel.GetTippaniChannelList(null);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTTippaniSubject tippani = new ATTTippaniSubject();

                    tippani.TippaniSubjectID = int.Parse(row["tippani_subject_id"].ToString());
                    tippani.TippaniSubjectName = row["tippani_subject_name"].ToString();
                    tippani.TippaniSubjectText = row["tippani_subject_text"].ToString();
                    tippani.Action = "N";

                    /*tippani.LstTippaniChannel = channelLst.FindAll
                                                                (
                                                                    delegate(ATTTippaniChannel c)
                                                                    {
                                                                        return c.TippaniSubjectID == tippani.TippaniSubjectID;
                                                                    }
                                                                );*/

                    lst.Add(tippani);
                }

                if (lst.Count > 0 && containDefault == true)
                {
                    ATTTippaniSubject def = new ATTTippaniSubject();
                    def.TippaniSubjectID = -1;
                    def.TippaniSubjectName = "--- टिप्पणी बिषय छन्नुहोस ---";
                    lst.Insert(0, def);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTOrganizationTippaniSubject CreateDeepCopy(ATTOrganizationTippaniSubject lst)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, lst);
            m.Position = 0;
            ATTOrganizationTippaniSubject DeepCopyLst = (ATTOrganizationTippaniSubject)b.Deserialize(m);
            m.Close();
            m.Dispose();
            return DeepCopyLst;
        }
    }
}
