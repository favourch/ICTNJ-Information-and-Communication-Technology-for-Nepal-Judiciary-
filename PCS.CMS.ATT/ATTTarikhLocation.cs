using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
   public  class ATTTarikhLocation
    {
       private int _CaseID;
       public int CaseID
       {
           get { return _CaseID; }
           set { _CaseID = value; }
       }

       private int _PersonID;
       public int PersonID
       {
           get { return _PersonID; }
           set { _PersonID = value; }
       }

       private int _CourtID;
       public int CourtID
       {
           get { return _CourtID; }
           set { _CourtID = value; }
       }

       private  string _FromDate;
       public string FromDate
       {
           get { return _FromDate; }
           set { _FromDate = value; }
       }

       private string _PersonType;
       public string PersonType
       {
           get { return _PersonType; }
           set { _PersonType = value; }
       }

       private string _EntryBy;
       public string EntryBy
       {
           get { return _EntryBy; }
           set { _EntryBy = value; }
       }

       private string _EntryDate;
       public string EntryDate
       {
           get { return _EntryDate; }
           set { _EntryDate = value; }
       }

       private string _Action;
       public string Action
       {
           get { return _Action; }
           set { _Action = value; }
       }
       public ATTTarikhLocation() { }


       private string _Name;
       public string Name
       {
           get { return _Name; }
           set { _Name = value; }
       }

       private string _Court;
       public string Court
       {
           get { return _Court; }
           set { _Court = value; }
       }
    }
}
