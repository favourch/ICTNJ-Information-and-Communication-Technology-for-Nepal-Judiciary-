using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.SECURITY.BLL
{
    public class BLLUserLogin
    {
        public static Dictionary<string, AccessColumn> GetUserApplicationMenu(string username, int applID)
        {
            try
            {
                return PCS.SECURITY.DLL.DLLUserLogin.GetUserApplicationMenu(username, applID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTUserLogin GetUserLogin(string userName, string password,int applID)
        {
            try
            {
                return PCS.SECURITY.DLL.DLLUserLogin.GetUserLogin(userName, password,applID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
