using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;
namespace PCS.PMS.ATT
{
    public class ATTEmployeeBeneficiary
    {
        private double _EmpId;
        public double EmpId
        {
            get { return this._EmpId; }
            set { this._EmpId = value; }
        }

        private double _BenId;
        public double BenId
        {
            get { return this._BenId; }
            set { this._BenId = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private bool _IsBeneficiary;
        public bool IsBeneficiary
        {
            get { return this._IsBeneficiary; }
            set { this._IsBeneficiary = value; }
        }

        private ATTRelatives _ObjRelatives;
        public ATTRelatives ObjRelatives
        {
            get { return this._ObjRelatives; }
            set { this._ObjRelatives = value; }
        }

        public ATTEmployeeBeneficiary()
        {
        }

        public ATTEmployeeBeneficiary(double empID, double benID, string fromDate, string toDate)
        {
            this.EmpId = empID;
            this.BenId = benID;
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }
    }
}
