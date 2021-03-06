using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.IO;

using Oracle.DataAccess.Client;

namespace PCS.FRAMEWORK
{
    public enum Action
    {
        Add,
        Edit,
        Delete,
        None
    }

    public enum Default
    {
        Yes,
        No
    }

    public class Utilities
    {

        public static string[] NepaliMonthList ={ "बैशाख", "जेठ", "अषाढ", "श्रवण", "भदौ", "अशोज", "कर्त्तिक", "मंसिर", "पौष", "माघ", "फागुन", "चैत" };

        public static string[] EnglishMonthList ={ };

        public static string PreviledgeMsg = "Insufficient previlege to";

        public static OracleParameter GetOraParam(string paramName, object paramValue, OracleDbType paramDBType, ParameterDirection paramDirection)
        {
            return new OracleParameter(paramName, paramDBType, paramValue, paramDirection);
        }

        /// <summary>
        /// Convert file into array of byte and return byte[], return null if file doesn't exist.
        /// </summary>
        /// <param name="serverPathOfFile">Server path for file</param>
        /// <returns></returns>
        public static byte[] GetBytesFromFile(string serverPathOfFile)
        {
            if (File.Exists(serverPathOfFile) == false)
            {
                return null;
            }

            FileStream fs = new FileStream(serverPathOfFile, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            return bytes;
        }

        public static string FormateDate(DateTime DT)
        {
            char[] token ={ '/' };
            string[] array = DT.ToShortDateString().Split(token);

            return Utilities.FormateCode(array[0], 2) + "/" + Utilities.FormateCode(array[1], 2) + "/" + Utilities.FormateCode(array[2], 4);
        }

        private static string FormateCode(string Code, int Length)
        {
            string Prefix = "00000";
            Code = Prefix + Code;
            return Code.Substring(Code.Length - Length, Length);
        }
    }
}
