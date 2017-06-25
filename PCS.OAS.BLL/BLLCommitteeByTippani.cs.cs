using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;


namespace PCS.OAS.BLL
{
    public class BLLCommitteeByTippani
    {
        public static int AddCommitteeByTippani
        (
            ATTCommitteeByTippani comm,
                object tran,
                int tippaniSubjectID,
                TippaniSubject subject,
                int tippaniID

        )
        {
            try
            {
                return DLLCommitteeByTippani.AddCommitteeByTippani(comm, tran, tippaniSubjectID, subject, tippaniID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTCommitteeByTippani GetCommitteeByTippaniByTIDs(int orgID, int tippaniID)
        {
            ATTCommitteeByTippani obj = null;

            try
            {
                DataTable tbl = DLLCommitteeByTippani.GetCommitteeByTippaniByTIDs(orgID, tippaniID);
                if (tbl.Rows.Count == 1)
                {
                    DataRow row = tbl.Rows[0];

                    obj = new ATTCommitteeByTippani();

                    obj.CommitteeOrgID = int.Parse(row["comm_org_id"].ToString());
                    obj.CommitteeOrgName = row["org_name"].ToString();
                    obj.CommitteeID = int.Parse(row["committee_id"].ToString());
                    obj.CommitteeName = row["committee_name"].ToString();
                    obj.Description = row["description"].ToString();
                    obj.Type = row["type"].ToString();
                    obj.OrgID = int.Parse(row["org_id"].ToString());
                    obj.TippaniID = int.Parse(row["tippani_id"].ToString());
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
