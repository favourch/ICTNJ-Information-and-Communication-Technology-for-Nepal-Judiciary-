using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEvaluationGroup
    {
        public static List<ATTEvaluationGroup> GetEvaluationGroupList(Default defGroup,Default defCriteria, Default defGrade,string active)
        {
            List<ATTEvaluationGroup> lst = new List<ATTEvaluationGroup>();
            try
            {
                List<ATTEvaluationCriteria> lstCriteria = BLLEvaluationCriteria.GetEvaluationCriteriaList(null, defCriteria, active);

                foreach (DataRow row in DLLEvaluationGroup.GetEvaluationGroupTable().Rows)
                {
                    ATTEvaluationGroup grp = new ATTEvaluationGroup();
                    grp.GroupID = int.Parse(row["Eval_Group_ID"].ToString());
                    grp.GroupName = row["Eval_Group_Name"].ToString();

                    grp.LstEvaluationCriteria = lstCriteria.FindAll
                                                                    (
                                                                        delegate(ATTEvaluationCriteria crit)
                                                                        {
                                                                            return
                                                                                crit.GroupID == grp.GroupID;
                                                                        }
                                                                    );

                    lst.Add(grp);

                    if (defCriteria == Default.Yes && grp.LstEvaluationCriteria.Count > 0)
                    {
                        ATTEvaluationCriteria defaultCrit = new ATTEvaluationCriteria();
                        defaultCrit.EvaluationCriteriaName = "----- बिवरण छन्नुहोस -----";
                        grp.LstEvaluationCriteria.Insert(0, defaultCrit);
                    }
                }

                if (defGroup == Default.Yes)
                {
                    ATTEvaluationGroup defaultX = new ATTEvaluationGroup(0, "----- समुह छन्नुहोस -----");
                    lst.Insert(0, defaultX);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveEvaluationGroup(ATTEvaluationGroup obj)
        {
            try
            {
                return DLLEvaluationGroup.SaveEvaluationGroup(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
