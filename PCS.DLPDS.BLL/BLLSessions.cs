using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using PCS.DLPDS.ATT;
using PCS.DLPDS.DLL;
using PCS.FRAMEWORK;


namespace PCS.DLPDS.BLL
{
    public class BLLSessions
    {
        public static List<ATTSession> GetSessionList(int orgID, int programID, int sessionID, string ContainDefSessionValue, string ContainDefSessionCourseValue)
        {
            List<ATTSession> SessionLST = new List<ATTSession>();

            foreach (DataRow row in DLLSession.GetSessionTable(orgID, programID, sessionID).Rows)
            {
                ATTSession objSession= new ATTSession
                                                    (
                                                        int.Parse(row["ORG_ID"].ToString()),
                                                        int.Parse(row["PROGRAM_ID"].ToString()),
                                                        int.Parse(row["SESSION_ID"].ToString()),
                                                        row["SESSION_NAME"].ToString(),
                                                        row["FROM_DATE"].ToString(),
                                                        (row["TIME"]==System.DBNull.Value)?"":row["TIME"].ToString(),
                                                        row["TO_DATE"].ToString(),
                                                        ""
                                                        
                                                    );

                objSession.LstSessionCourse = BLL.BLLSessionCourse.GetSessionCourseList(orgID, programID, int.Parse(row["SESSION_ID"].ToString()), 0, ContainDefSessionCourseValue);
                
                SessionLST.Add(objSession);
            }

            if (ContainDefSessionValue == "Y")
            {
                ATTSession objSession = new ATTSession(0, 0, 0, "---Select Session ---", "", "", "", "");
                SessionLST.Insert(0, objSession);
            }

            return SessionLST;
        }
    }
}
