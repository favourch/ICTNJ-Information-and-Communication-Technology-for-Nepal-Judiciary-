using System;
using System.Collections.Generic;
using System.Text;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLTameliStatus
    {
        
            public static List<ATTTameliStatus> GetTameliStatus(int? tameliStatusID, string active)
            {
                try
                {
                    List<ATTTameliStatus> tameliStatusLIST = new List<ATTTameliStatus>();
                    foreach (DataRow drow in DLLTameliStatus.GetTameliStatus(tameliStatusID, active).Rows)
                    {
                        ATTTameliStatus tameliStatus = new ATTTameliStatus();

                        tameliStatus.TameliStatusID = int.Parse(drow["TAMELI_STATUS_ID"].ToString());
                        tameliStatus.TameliStatusName = drow["TAMELI_STATUS_NAME"].ToString();
                        tameliStatus.Active = drow["ACTIVE"].ToString();
                        tameliStatus.Action = "";

                        tameliStatusLIST.Add(tameliStatus);
                    }
                    return tameliStatusLIST;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public static bool AddEditDeleteTameliStatus(ATTTameliStatus tameliStatus)
            {
                try
                {
                    return DLLTameliStatus.AddEditDeleteTameliStatus(tameliStatus);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
       
    }
}
