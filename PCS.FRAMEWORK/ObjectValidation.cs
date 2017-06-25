using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.FRAMEWORK
{
    public class ObjectValidation
    {
        private bool _IsValid;
        public bool IsValid
        {
            get { return this._IsValid; }
            set { this._IsValid = value; }
        }

        private string _ErrMsg;
        public string ErrorMessage
        {
            get { return this._ErrMsg; }
            set { this._ErrMsg = value; }
        }

        public ObjectValidation()
        {
            this.IsValid = true;
            this.ErrorMessage = "";
        }
    }
}
