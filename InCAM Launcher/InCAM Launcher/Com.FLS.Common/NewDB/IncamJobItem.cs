using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.FLS.Common
{
    public class IncamJobItem
    {
        private DateTime _updated = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
        private int _size = 0;
        private string _creator = "";
        private string _dbName = "";
        private string _latinName = "";
        private string _comment = "";
        private DateTime _created = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
        private string _name = "";
        private string _customer_name = "";
        private string _lastUser = "";
        private string _idbVer = "";
        private string _customer = "";
        private int _numSignalLyrs = 0;

        public DateTime Updated
        {
            get
            {
                return this._updated;
            }
            set
            {
                this._updated = value;
            }
        }

        public int Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }

        public string Creater
        {
            get
            {
                return this._creator;
            }
            set
            {
                this._creator = value;
            }
        }

        public string DbName
        {
            get
            {
                return this._dbName;
            }
            set
            {
                this._dbName = value;
            }
        }

        public string LatinName
        {
            get
            {
                return this._latinName;
            }
            set
            {
                this._latinName = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                this._comment = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return this._created;
            }
            set
            {
                this._created = value;
            }
        }

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

        public string Customer_name
        {
            get
            {
                return this._customer_name;
            }
            set
            {
                this._customer_name = value;
            }
        }

        public string LastUser
        {
            get
            {
                return this._lastUser;
            }
            set
            {
                this._lastUser = value;
            }
        }

        public string IdbVer
        {
            get
            {
                return this._idbVer;
            }
            set
            {
                this._idbVer = value;
            }
        }

        public string Customer
        {
            get
            {
                return this._customer;
            }
            set
            {
                this._customer = value;
            }
        }

        public int NumSignalLyrs
        {
            get
            {
                return this._numSignalLyrs;
            }
            set
            {
                this._numSignalLyrs = value;
            }
        }
    }
}


