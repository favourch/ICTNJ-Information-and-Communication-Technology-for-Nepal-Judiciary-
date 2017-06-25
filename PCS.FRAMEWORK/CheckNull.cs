using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.FRAMEWORK
{
    public class CheckNull
    {
        public static string NullString(string stringToCheck)
        {
            if (stringToCheck == "&nbsp;")
                return "";
            else
                return stringToCheck;
        }

        public static double NulldblValue(string stringToCheck)
        {
            if (stringToCheck == "&nbsp;")
                return 0;
            else
                return double.Parse(stringToCheck);
        }

        public static int NullintValue(string stringToCheck)
        {
            if (stringToCheck == "&nbsp;")
                return 0;
            else
                return int.Parse(stringToCheck);
        }


        
    }
}
