using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
  public class BLLInvItemsWriteOff
    {
      public static bool AddUpdateItemsWriteOff(ATTInvItemsWriteOff itemsWriteOff)
      {
          try
          {
              return DLLInvItemsWriteOff.AddUpdateItemsWriteOff(itemsWriteOff);

          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
    }
}
