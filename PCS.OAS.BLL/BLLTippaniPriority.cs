using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;

namespace PCS.OAS.BLL
{
    public class BLLTippaniPriority
    {
        public static List<ATTTippaniPriority> GetTippaniPriority()
        {
            List<ATTTippaniPriority> lst = new List<ATTTippaniPriority>();
            lst.Add(new ATTTippaniPriority(0, "--- प्राथमिक्ता छान्नुहोस् ---"));
            lst.Add(new ATTTippaniPriority(1, "अति आवश्यक"));
            lst.Add(new ATTTippaniPriority(2, "आवश्यक"));
            lst.Add(new ATTTippaniPriority(3, "साधारण"));
            return lst;
        }
    }
}
