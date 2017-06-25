using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLDocumentFlowType
    {
        public static List<ATTDocumentFlowType> GetFlowTypeList(int? flowID)
        {
            List<ATTDocumentFlowType> lstFlowType = new List<ATTDocumentFlowType>();

            try
            {
                foreach(DataRow row in DLLDocumentFlowType.GetDocFlowTypeListTable(flowID).Rows)
                {
                    ATTDocumentFlowType FlowTypeObj = new ATTDocumentFlowType(
                                                                                int.Parse(row["DOC_FLOW_ID"].ToString()),
                                                                                row["DOC_FLOW_NAME"].ToString(),
                                                                                row["DF_DESCRIPTION"].ToString()
                                                                             );

                    lstFlowType.Add(FlowTypeObj);
                }
                return lstFlowType;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    
    }
}
