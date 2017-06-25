using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace PCS.Utilities
{
    /// <summary>
    /// Class for cleaning unnecessary session
    /// </summary>
    public class SessionCleaner
    {
        public static void CleanSession(string[] SessionArray)
        {
            if (SessionArray == null || SessionArray.Length <= 0)
            {
                HttpContext.Current.Session.RemoveAll();
                return;
            }

            Dictionary<string, string> SessionInUse = new Dictionary<string, string>();
            foreach (string name in SessionArray)
            {
                SessionInUse.Add(name, "");
            }

            List<string> SessionToRemove = new List<string>();
            foreach (string key in HttpContext.Current.Session.Keys)
            {
                if (SessionInUse.ContainsKey(key) == false) 
                {
                    SessionToRemove.Add(key);
                }
            }

            foreach (string name in SessionToRemove)
            {
                HttpContext.Current.Session.Remove(name);
            }
        }
    }
}