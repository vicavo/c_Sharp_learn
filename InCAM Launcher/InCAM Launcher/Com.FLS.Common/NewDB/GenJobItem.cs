using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.FLS.Common
{
    public class GenJobItem
    {
        private string _name = "";
        private string _db = "";
        private string _access = "";

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Db
        {
            get
            {
                return this._db;
            }
            set
            {
                this._db = value;
            }
        }

        public string Access
        {
            get
            {
                return this._access;
            }
            set
            {
                this._access = value;
            }
        }


    }
}
